﻿using UnityEngine;
using System.Collections;
using System;

namespace TnkAd {
	public class EventHandler : MonoBehaviour {
		// publishing state 
		public const int PUB_STAT_NO = 0; // not publishing yet
		public const int PUB_STAT_YES = 1; // publising state
		public const int PUB_STAT_TEST = 2; // testing state

		// onClose(int type)
		public const int CLOSE_SIMPLE = 0; // users simply closed ad view.
		public const int CLOSE_CLICK = 1; // users clicked ad view.
		public const int CLOSE_EXIT = 2; // users clicked exit app button.

		// onFailure(int errCode)
		public const int FAIL_NO_AD = -1;  // no ad available
		public const int FAIL_NO_IMAGE = -2; // ad image not available
		public const int FAIL_TIMEOUT = -3;  // ad not arrived in 5 secs.
		public const int FAIL_CANCELED = -4; // ad frequency setting
		public const int FAIL_NOT_PREPARED = -5; // prepare not invoked.

		public const int FAIL_SYSTEM = -9;

		// Set 'Handler Name' in Unity Inspector
		public string handlerName;
		
		void Awake() {
            //Debug.Log("##### Awake() handlerName = " + handlerName);
            gameObject.name = handlerName;
			DontDestroyOnLoad( gameObject );
		}
		
		public void onReturnQueryPointBinding(string point) {
			//Debug.Log("##### onReturnQueryPointBinding() point = " + point);
			int pnt = int.Parse (point);
			onReturnQueryPoint (pnt);
		}

		public void onReturnWithdrawPointsBinding(string point) {
            //Debug.Log("##### onReturnWithdrawPointsBinding() point = " + point);
            int pnt = int.Parse (point);
			onReturnWithdrawPoints (pnt);
		}

		public void onReturnPurchaseItemBinding(string point) {
			//Debug.Log("##### onReturnPurcaseItemBinding() point = " + point);
			char[] delimiterChars = {','};
			string[] str = point.Split (delimiterChars);
			long pnt = long.Parse (str[0]);
			long seq = long.Parse (str[1]);
			onReturnPurchaseItem (pnt, seq);
		}

		public void onReturnQueryPublishStateBinding(string state) {
			//Debug.Log("##### onReturnQueryPublishStateBinding() state = " + state);
			int stat = int.Parse (state);
			onReturnQueryPublishState (stat);
		}

		public void onFailureBinding(int errCode) {
            //Debug.Log("##### onFailureBinding() error = " + error);
            onFailure(errCode);
		}
		
		public void onLoadBinding(string dummy) {
			//Debug.Log("##### onLoadBinding() ");
			onLoad ();
		}
		
		public void onShowBinding(string dummy) {
			//Debug.Log("##### onShowBinding() ");
			onShow ();
		}

        public void onCloseBinding(string type)
        {
            //Debug.Log("##### onCloseBinding() type = " + type);
            int typeCode = int.Parse(type);
            onClose(typeCode);
        }

		// ServiceCallback methods
		public virtual void onReturnQueryPoint(int point) {}
		public virtual void onReturnWithdrawPoints(int point) {}
		public virtual void onReturnPurchaseItem(long curPoint, long seqId) {}
		public virtual void onReturnQueryPublishState(int state) {}

		// TnkAdListener methods
		public virtual void onFailure(int errCode) { }
        public virtual void onLoad() { }
        public virtual void onShow() { }
        public virtual void onClose(int type) { }
    }
}