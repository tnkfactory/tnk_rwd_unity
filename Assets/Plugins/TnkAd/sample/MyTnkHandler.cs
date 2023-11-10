using UnityEngine;
using System.Collections;

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

    void __onReturnQueryPointBinding(string message)
    {
	    Debug.Log("##### __onReturnQueryPointBinding() point = " + message);
    }
}
