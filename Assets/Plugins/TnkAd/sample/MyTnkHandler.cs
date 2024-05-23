using UnityEngine;
using System.Collections;
using SimpleJSON;

public class MyTnkHandler : TnkAd.EventHandler {

	public override void onReturnQueryPoint(int point) {
		Debug.Log("##### onReturnQueryPoint() point = " + point.ToString());
    }

	public override void onReturnWithdrawPoints(int point) {
		Debug.Log("##### onReturnWithdrawPoints() point = " + point.ToString());
	}

	public override void onReturnPurchaseItem(long curPoint, long seqId) {
		Debug.Log("##### onReturnPurchaseItem() point = " + curPoint.ToString() + ", seqId = " + seqId.ToString());
	}

	public override void onReturnQueryPublishState(int state) {
		Debug.Log("##### onReturnQueryPublishState() state = " + state.ToString());
	}

	public override void onFailure(int errCode) {
		Debug.Log("##### TnkAd.Listener onFailure() errCode = " + errCode);
	}

	public override void onLoad() {
		Debug.Log("##### TnkAd.Listener onLoad() ");
	}

    public override void onShow() {
		Debug.Log("##### TnkAd.Listener onShow() ");
	}

    public override void onClose(int type) {
        Debug.Log("##### TnkAd.Listener onClose() type = " + type.ToString());
        if (type == CLOSE_EXIT) {
            Application.Quit();
        }
    }


	// event
	const string SELECT_CATEGORY = "tnk_ev_category";       // 카테고리 선택          // 카테고리 아이디, 카테고리명

	const string SELECT_FILTER = "tnk_ev_filter";           // 필터 선택            // 필터 아이디, 필터명
	const string CLICK_MENU = "tnk_ev_menu";                // 메뉴 선택            // 메뉴 이름, 메뉴 이름(cps_search, cps_my, offerwall_my)
	const string SEARCH_CPS = "tnk_ev_search_cps";          // cps 검색            // "cps_search", 검색 키워드
	const string CLICK_BANNER = "tnk_ev_banner_click";      // 배너 클릭            // app id, app name(광고명)
	const string CLICK_AD = "tnk_ev_ad_click";              // 광고 클릭            // app id, app name(광고명)
	const string JOIN_AD = "tnk_ev_ad_join";                // 광고 상세에서 참여 클릭  // app id, app name(광고명)
	const string AD_DETAIL_CLOSE = "ad_detail_close";       // 광고 클릭            // app id, app name(광고명)
	const string ACTIVITY_FINISH = "activity_finish";       // 오퍼월 액티비티 종료됨
	const string OFFERWALL_REMOVED = "OfferwallRemoved";       // 카테고리 선택          // 카테고리 아이디, 카테고리명

	// value
    public override void onOfferwallEvent(string message)
    {
		var jObj = JSON.Parse(message);
		string ev = jObj["event"];
		string id = jObj["item_id"];
		string name = jObj["item_name"];
		//Debug.Log("##### offerwall event : " + ev + " - id : " + id + " - name : " + name );
		if(ev == ACTIVITY_FINISH || ev == OFFERWALL_REMOVED) {
			//Debug.Log("##### offerwall closed #####");
		}
    }
}
