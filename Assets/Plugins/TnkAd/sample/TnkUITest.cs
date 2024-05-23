using UnityEngine;
using System.Collections;


public class TnkUITest : MonoBehaviour
{

    void Start()
        {
#if UNITY_ANDROID        // 안드로이드의 app_id 사용
        TnkAd.RwdPlugin2.Instance.initInstance("3040807040519322223915040708030f");
#elif UNITY_IOS          // iOS의 app_id 사용
        TnkAd.RwdPlugin2.Instance.initInstance("a060a0c0f0c1c875578c1c0e070a0f01");
#endif
        // 유저 식별값 설정
        TnkAd.RwdPlugin2.Instance.setUserName("test_name");
        // 오퍼월 이벤트 전달받을 핸들러 설정
        TnkAd.RwdPlugin2.Instance.setTnkAdAnalytics("testhandler");

        // COPPA 설정
        TnkAd.RwdPlugin2.Instance.setCOPPA(false);
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Application.Quit();

            }
        }
    }

    void OnGUI()
    {
        // be sure that put handler object named 'testhandler' in your scene. (It should be named in Unity Inspector)

        string title = "Test Title";

        if (GUI.Button(new Rect(100, 100, 200, 80), "Show Offerwall (Activity)"))
        {
            TnkAd.RwdPlugin2.Instance.showAdList("무료 충전소");
        }

        if (GUI.Button(new Rect(100, 400, 200, 80), "Query point"))
        {
            Debug.Log("Query point");
            TnkAd.RwdPlugin2.Instance.queryPoint("testhandler");
        }

        if (GUI.Button(new Rect(100, 500, 200, 80), "Purchase Item"))
        {
            Debug.Log("Purchase Item");
            TnkAd.RwdPlugin2.Instance.purchaseItem(100, "item01", "testhandler");

        }

        if (GUI.Button(new Rect(100, 600, 200, 80), "ETC Test"))
        {
            Debug.Log("ETC Test 2");
            TnkAd.RwdPlugin2.Instance.queryPublishState("testhandler");
        }
    }
}
