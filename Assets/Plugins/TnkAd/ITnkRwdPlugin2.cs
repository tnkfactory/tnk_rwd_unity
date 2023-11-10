
public interface ITnkRwdPlugin2
{
    void  initInstance();

    void  initInstance(string appId);
        
    void  applicationStarted();

    void  setUserName(string userName);

    void  setUserAge(int age);

    void  setUserGender(int gender);

    void  setCOPPA(bool isCOPPA);

    void  showAdList(string title);

    void  actionCompleted(string actionName);

    void  buyCompleted(string itemName);

    void  queryPoint(string handleName);

    void  withdrawPoints(string desc, string handleName);

    void  purchaseItem(int cost, string itemName, string handleName);

    void  queryPublishState(string handleName);
    }
