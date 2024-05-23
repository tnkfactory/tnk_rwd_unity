using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace TnkAd {

	public class Plugin {
		private static Plugin _instance;

		public static Plugin Instance {
			get {
				if(_instance == null) {
					_instance = new Plugin();
				}
				return _instance;
			}
		}

		private AndroidJavaClass pluginClass;

		public Plugin() {
			pluginClass = new AndroidJavaClass("com.tnkfactory.ad.unity.TnkUnityPlugin");
		}

		public void initInstance() {
			pluginClass.CallStatic ("initInstance");
		}

        public void initInstance(string appId) {
			pluginClass.CallStatic ("initInstance", appId);
		}

		public void applicationStarted() {
            pluginClass.CallStatic("applicationStarted");
        }

		public void setUserName(string userName) {
            pluginClass.CallStatic("setUserName", userName);
        }

        public void setUserAge(int age) {
            pluginClass.CallStatic("setUserAge", age);
        }

        // 0 for male, 1 for female
        public void setUserGender(int gender) {
            pluginClass.CallStatic("setUserGender", gender);
        }

        public void setCOPPA(bool isCOPPA) {
            pluginClass.CallStatic("setCOPPA", isCOPPA);
        }

        public void enableCurrencyFormat(bool useFormat) {
            pluginClass.CallStatic("enableCurrencyFormat", useFormat);
        }
        public void showAdList(string title) {
            pluginClass.CallStatic("showAdList", title);
        }

        public void actionCompleted(string actionName) {
            pluginClass.CallStatic("actionCompleted", actionName);
        }

        public void buyCompleted(string itemName) {
            pluginClass.CallStatic("buyCompleted", itemName);
        }

        public void queryPoint(string handlerName) {
            pluginClass.CallStatic("queryPoint", handlerName);
        }

        public void withdrawPoints(string desc, string handlerName) {
            pluginClass.CallStatic("withdrawPoints", desc, handlerName);
        }

        public void purchaseItem(int cost, string itemName, string handlerName) {
            pluginClass.CallStatic("purchaseItem", cost, itemName, handlerName);
        }

        public void queryPublishState(string handlerName) {
            pluginClass.CallStatic("queryPublishState", handlerName);
        }

        public void  setTnkAdAnalytics(string handlerName){
            pluginClass.CallStatic("setTnkAdAnalytics", handlerName);
        }
    }
}
