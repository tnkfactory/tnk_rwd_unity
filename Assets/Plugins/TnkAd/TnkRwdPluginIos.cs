
using System.Runtime.InteropServices;

namespace TnkAd
{
	public class TnkRwdPluginIos// : ITnkRwdPlugin2
	{

		private static TnkRwdPluginIos _instance;

		public static TnkRwdPluginIos Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new TnkRwdPluginIos();
				}

				return _instance;
			}
		}

		[DllImport("__Internal")]
		private static extern int _addTwoNumberInIOS(int a, int b);

		[DllImport("__Internal")]
		private static extern void _iniInstance();

		[DllImport("__Internal")]
		private static extern void _iniInstanceWithName(string appId);

		[DllImport("__Internal")]
		private static extern void _applicationStarted();

		[DllImport("__Internal")]
		private static extern void _setUserName(string userName);

		[DllImport("__Internal")]
		private static extern void _setUserAge(int age);

		[DllImport("__Internal")]
		private static extern void _setGender(int gender);

		[DllImport("__Internal")]
		private static extern void _setCOPPA(bool isCOPPA);

		[DllImport("__Internal")]
		private static extern void _showAdList(string title);

		[DllImport("__Internal")]
		private static extern void _actionCompleted(string actionName);

		[DllImport("__Internal")]
		private static extern void _buyCompleted(string itemName);

		[DllImport("__Internal")]
		private static extern void _queryPoint(string handleName);

		[DllImport("__Internal")]
		private static extern void _withdrawPoints(string desc, string handleName);

		[DllImport("__Internal")]
		private static extern void _purchaseItem(int cost, string itemName, string handleName);

		[DllImport("__Internal")]
		private static extern void _queryPublishState(string handleName);
		
		
		
		
		
		// #region Callback from native
		//
		// void __onReturnQueryPointBinding(string message)
		// {
		// 	(impl as GarlicWebviewiOSImpl).__fromnative_onReceiverdError (message);
		// }
		

		///////////////
		public void initInstance()
		{
			_iniInstance();
		}

		public void initInstance(string appId)
		{
			_iniInstanceWithName(appId);
		}

		public void applicationStarted()
		{
			_applicationStarted();
		}

		public void setUserName(string userName)
		{
			_setUserName(userName);
		}

		public void setUserAge(int age)
		{
			_setUserAge(age);
		}

		public void setUserGender(int gender)
		{
			_setGender(gender);
		}

		public void setCOPPA(bool isCOPPA)
		{
			_setCOPPA(isCOPPA);
		}

		public void showAdList(string title)
		{
			_showAdList(title);
		}

		public void actionCompleted(string actionName)
		{
			_actionCompleted(actionName);
		}

		public void buyCompleted(string itemName)
		{
			_buyCompleted(itemName);
		}

		public void queryPoint(string handleName)
		{
			_queryPoint(handleName);
		}

		public void withdrawPoints(string desc, string handleName)
		{
			_withdrawPoints(desc, handleName);
		}

		public void purchaseItem(int cost, string itemName, string handleName)
		{
			_purchaseItem(cost, itemName, handleName);
		}

		public void queryPublishState(string handleName)
		{
			_queryPublishState(handleName);
		}

	}
}