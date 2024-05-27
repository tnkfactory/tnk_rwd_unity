
import Foundation
import TnkRwdSdk2
import AppTrackingTransparency


@objc public class UnityPlugin : NSObject {

    public typealias ReqHandler = (String) -> Void

    @objc public static let shared = UnityPlugin()
    @objc public func AddTwoNumber(a:Int,b:Int ) -> Int {

        let result = a+b;
        // print("call from unity plugin \(result)")
        return result;
    }

    @objc public func initInstance() {
        // print("call from unity plugin initInstance")

    }

    @objc public func initInstance(appId:UnsafePointer<CChar>) {
        let strAppId = String(validatingUTF8: appId)!
        TnkSession.initInstance(appId: strAppId)
    }

    @objc public func applicationStarted() {
        TnkSession.sharedInstance()?.applicationStarted()
    }

    @objc public func setUserName(userName:UnsafePointer<CChar> ) {
        let strUserName = String(validatingUTF8: userName)!
        TnkSession.sharedInstance()?.setUserName(strUserName)
//        print("call from unity plugin setUserName \(userName)")
    }

    @objc public func setUserAge(age:Int) {
//        TnkSession.sharedInstance()?.setUserA()
        // print("call from unity plugin setUserAge \(age)")
    }

    @objc public func setGender(gender :Int) {
//        TnkSession.sharedInstance()?.gen
//        print("call from unity plguin setGender \(gender)")
    }

    @objc public func setCOPPA(isCOPPA:Bool) {
        TnkSession.sharedInstance()?.setCOPPA(isCOPPA)
        // print("call from unity plugin setCOPPA \(isCOPPA)")
    }

    @objc public func enableCurrencyFormat(useFormat:Bool) {
//        TnkSession.sharedInstance()?.cur
        // print("call from unity plugin enableCurrencyFormat \(useFormat)")
    }

    @objc public func showAdList(title:UnsafePointer<CChar>) {

        let rootVc = UnityFramework.getInstance().appController()!.rootViewController!

        let strTitle = String(validatingUTF8: title)!

        TnkAlerts.showATTPopup(rootVc, agreeAction: {
            DispatchQueue.main.asyncAfter(deadline: .now() + 1) {
                let rootVc = UnityFramework.getInstance().appController()!.rootViewController!
                let vc = AdOfferwallViewController()
                vc.title = strTitle
                vc.offerwallListener = UnityPlugin.customEventListener

                let navController = UINavigationController(rootViewController: vc)
                navController.modalPresentationStyle = .fullScreen
                navController.navigationBar.titleTextAttributes = [.foregroundColor: UIColor.black]

                rootVc.present(navController, animated: true)
            }
           }, denyAction:{
               DispatchQueue.main.asyncAfter(deadline: .now() + 1) {
                   let rootVc = UnityFramework.getInstance().appController()!.rootViewController!
                   let vc = AdOfferwallViewController()
                   vc.title = strTitle
                   vc.offerwallListener = UnityPlugin.customEventListener

                   let navController = UINavigationController(rootViewController: vc)
                   navController.modalPresentationStyle = .fullScreen
                   navController.navigationBar.titleTextAttributes = [.foregroundColor: UIColor.black]

                   rootVc.present(navController, animated: true)
               }
           })

        // print("call from unity plugin showAdList \(strTitle)")
    }

    @objc public func actionCompleted(actionName:UnsafePointer<CChar>) {
        TnkSession.sharedInstance()?.actionCompleted(actionName: String(validatingUTF8: actionName)!)
        // print("call from unity plugin actionCompleted \(actionName)")
    }

    @objc public func buyCompleted(itemName:UnsafePointer<CChar>) {
//        TnkSession.sharedInstance()?.bu(String(validatingUTF8: itemName)!)
        // print("method not found")
    }

    @objc public func queryPoint(_ ch: @escaping ReqHandler) {
        TnkSession.sharedInstance()?.queryPoint{
            (point) in
            ch(String(point))
            // print("call from unity plugin queryPoint \(point)")
        }
    }

    @objc public func withdrawPoints(desc:UnsafePointer<CChar>, ch: @escaping ReqHandler) {
        let strDesc = String(validatingUTF8: desc)!
        TnkSession.sharedInstance()?.withdrawPoints(strDesc) {
            (point, trId) in
            ch(String(point))
        }
        // print("call from unity plugin withdrawPoints \(desc)")
    }

    @objc public func purchaseItem(cost:Int, itemName:UnsafePointer<CChar>, ch: @escaping ReqHandler) {
        TnkSession.sharedInstance()?.purchaseItem(String(validatingUTF8: itemName)!, cost: cost){
            (point, trId) in
            ch("\(point),\(trId)")
        }
        // print("call from unity plugin purchaseItem \(cost) \(itemName)")
    }

    @objc public func queryPublishState(_ ch: @escaping ReqHandler) {
        TnkSession.sharedInstance()?.queryPublishState {
            (state) in
            ch(String(state))
        }
    }

    @objc public func didAdDataLoaded(headerMessage: String?,
                             totalPoint: Int,
                             totalCount: Int,
                             multiRewardPoint: Int,
                             multiRewardCount: Int) {
        if let ch = UnityPlugin.reqHandler{
            ch("{\"event\":\"tnk_ev_data_loaded\", \"item_id\":\"didAdDataLoaded\", \"item_name\":\"didAdDataLoaded\"}");
        }

        // print("### message = \(headerMessage)")
    }

    @objc public func didMenuSelected(menuId: Int, menuName:String, filterId: Int, filterName:String) {
        if let ch = UnityPlugin.reqHandler{
            ch("{\"event\":\"tnk_ev_category\", \"item_id\":\"\(menuId)\", \"item_name\":\"\(menuName)\"}");
            ch("{\"event\":\"tnk_ev_filter\", \"item_id\":\"\(filterId)\", \"item_name\":\"\(filterName)\"}");
        }
        // print("### menuId: \(menuId) \(menuName), filterId: \(filterId) \(filterName)")
    }

    @objc public func didAdItemClicked(appId: Int, appName: String) {
        if let ch = UnityPlugin.reqHandler{
            ch("{\"event\":\"tnk_ev_ad_click\", \"item_id\":\"\(appId)\", \"item_name\":\"\(appName)\"}");
        }
        // print("### adItem: \(appId) \(appName)")
    }

    @objc public func didOfferwallRemoved() {
        if let ch = UnityPlugin.reqHandler{
            ch("{\"event\":\"OfferwallRemoved\", \"item_id\":\"AdOfferwallViewController\", \"item_name\":\"AdOfferwallViewController\"}");
        }
        // print("### offerwall removed")
    }

    public static var reqHandler = nil as ReqHandler?
    static var customEventListener = CustomOfferwallEventListener()
    @objc public func setTnkAdAnalytics(_ ch: @escaping ReqHandler) {
        UnityPlugin.reqHandler = ch
    }


    // custom eventListener class CustomOfferwallEventListener
    public class CustomOfferwallEventListener : NSObject, OfferwallEventListener {
        public func didAdDataLoaded(headerMessage: String?, totalPoint: Int, totalCount: Int, multiRewardPoint: Int, multiRewardCount: Int) {
            UnityPlugin.shared.didAdDataLoaded(headerMessage: headerMessage, totalPoint: totalPoint, totalCount: totalCount, multiRewardPoint: multiRewardPoint, multiRewardCount: multiRewardCount)
        }

        public func didMenuSelected(menuId: Int, menuName: String, filterId: Int, filterName: String) {
            UnityPlugin.shared.didMenuSelected(menuId: menuId, menuName: menuName, filterId: filterId, filterName: filterName)
        }

        public func didAdItemClicked(appId: Int, appName: String) {
            UnityPlugin.shared.didAdItemClicked(appId: appId, appName: appName)
        }

        public func didOfferwallRemoved() {
            UnityPlugin.shared.didOfferwallRemoved()
        }
    }




}
