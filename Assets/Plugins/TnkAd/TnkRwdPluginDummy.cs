using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;


public class TnkRwdPluginDummy : ITnkRwdPlugin2 {

    private static TnkRwdPluginDummy _instance;

    public static TnkRwdPluginDummy Instance {
        get {
            if(_instance == null) {
                _instance = new TnkRwdPluginDummy();
            }
            return _instance;
        }
    }

    TnkRwdPluginDummy() {
        Debug.Log("com.tnkfactory.ad.unity.TnkUnityPlugin");
    }

    void ITnkRwdPlugin2.initInstance(){
        Debug.Log("initInstance");
    }

    void ITnkRwdPlugin2.initInstance(string appId) {
            Debug.Log("initInstance");
    }

    void ITnkRwdPlugin2.applicationStarted() {
        Debug.Log("applicationStarted");
    }

    void ITnkRwdPlugin2.setUserName(string userName) {
        Debug.Log("setUserName");
    }

    void ITnkRwdPlugin2.setUserAge(int age) {
        Debug.Log("setUserAge");
    }

    // 0 for male, 1 for female
    void ITnkRwdPlugin2.setUserGender(int gender) {
        Debug.Log("setUserGender");
    }

    void ITnkRwdPlugin2.setCOPPA(bool isCOPPA) {
        Debug.Log("setCOPPA");
    }

    void enableCurrencyFormat(bool useFormat) {
        Debug.Log("enableCurrencyFormat");
    }
    void ITnkRwdPlugin2.showAdList(string title) {
        Debug.Log("showAdList");
    }

    void ITnkRwdPlugin2.actionCompleted(string actionName) {
        Debug.Log("actionCompleted");
    }

    void ITnkRwdPlugin2.buyCompleted(string itemName) {
        Debug.Log("buyCompleted");
    }

    void ITnkRwdPlugin2.queryPoint(string handlerName) {
        Debug.Log("queryPoint");
    }

    void ITnkRwdPlugin2.withdrawPoints(string desc, string handlerName) {
        Debug.Log("withdrawPoints");
    }

    void ITnkRwdPlugin2.purchaseItem(int cost, string itemName, string handlerName) {
        Debug.Log("purchaseItem");
    }

    void ITnkRwdPlugin2.queryPublishState(string handlerName) {
        Debug.Log("queryPublishState");
    }

    void ITnkRwdPlugin2.setTnkAdAnalytics(string handlerName) {
        Debug.Log("setTnkAdAnalytics");

    }

}
