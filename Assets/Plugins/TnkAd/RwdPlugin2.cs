using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

namespace TnkAd {

	public class RwdPlugin2 {
		private static RwdPlugin2 _instance;

		public static RwdPlugin2 Instance {
			get {
				if(_instance == null) {
					_instance = new RwdPlugin2();
				}
				return _instance;
			}
		}
        
#if UNITY_ANDROID
        private TnkAdPluginAndroid tnkRwd = TnkAdPluginAndroid.Instance; 
		public RwdPlugin2() {
			//pluginClass = new AndroidJavaClass("com.tnkfactory.ad.unity.TnkUnityPlugin");
		}

		public void initInstance() {
            tnkRwd.initInstance();
		}

        public void initInstance(string appId) {
            tnkRwd.initInstance(appId);
		}

		public void applicationStarted() {
            tnkRwd.applicationStarted();
        }

		public void setUserName(string userName) {
            tnkRwd.setUserName(userName);
        }

        public void setUserAge(int age) {
            tnkRwd.setUserAge(age);
        }

        // 0 for male, 1 for female
        public void setUserGender(int gender) {
            tnkRwd.setUserGender(gender);
        }

        public void setCOPPA(bool isCOPPA) {
            tnkRwd.setCOPPA(isCOPPA);
        }

        public void enableCurrencyFormat(bool useFormat) {
            tnkRwd.enableCurrencyFormat(useFormat);
        }
        public void showAdList(string title) {
            tnkRwd.showAdList(title);
        }

        public void actionCompleted(string actionName) {
            tnkRwd.actionCompleted(actionName);
        }

        public void buyCompleted(string itemName) {
            tnkRwd.buyCompleted(itemName);
        }

        public void queryPoint(string handlerName) {
            tnkRwd.queryPoint(handlerName);
        }

        public void withdrawPoints(string desc, string handlerName) {
            tnkRwd.withdrawPoints(desc, handlerName);
        }

        public void purchaseItem(int cost, string itemName, string handlerName) {
            tnkRwd.purchaseItem(cost, itemName, handlerName);
        }

        public void queryPublishState(string handlerName) {
            tnkRwd.queryPublishState(handlerName);
        }

    
# elif UNITY_IOS
        private TnkRwdPluginIos tnkRwd = TnkRwdPluginIos.Instance; 
		public RwdPlugin2() {
			//pluginClass = new AndroidJavaClass("com.tnkfactory.ad.unity.TnkUnityPlugin");
		}

		public void initInstance() {
            tnkRwd.initInstance();
		}

        public void initInstance(string appId) {
            tnkRwd.initInstance(appId);
		}

		public void applicationStarted() {
            tnkRwd.applicationStarted();
        }

		public void setUserName(string userName) {
            tnkRwd.setUserName(userName);
        }

        public void setUserAge(int age) {
            tnkRwd.setUserAge(age);
        }

        // 0 for male, 1 for female
        public void setUserGender(int gender) {
            tnkRwd.setUserGender(gender);
        }

        public void setCOPPA(bool isCOPPA) {
            tnkRwd.setCOPPA(isCOPPA);
        }

        public void enableCurrencyFormat(bool useFormat) {
            // tnkRwd.enableCurrencyFormat(useFormat);
        }
        public void showAdList(string title) {
            tnkRwd.showAdList(title);
        }

        public void actionCompleted(string actionName) {
            tnkRwd.actionCompleted(actionName);
        }

        public void buyCompleted(string itemName) {
            tnkRwd.buyCompleted(itemName);
        }

        public void queryPoint(string handlerName) {
            tnkRwd.queryPoint(handlerName);
        }

        public void withdrawPoints(string desc, string handlerName) {
            tnkRwd.withdrawPoints(desc, handlerName);
        }

        public void purchaseItem(int cost, string itemName, string handlerName) {
            tnkRwd.purchaseItem(cost, itemName, handlerName);
        }

        public void queryPublishState(string handlerName) {
            tnkRwd.queryPublishState(handlerName);
        }
#endif
    }
}
