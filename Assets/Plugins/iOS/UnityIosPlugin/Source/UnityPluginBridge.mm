
#import <Foundation/Foundation.h>
#include "UnityFramework/UnityFramework-Swift.h"
#include "UnityInterface.h"

extern "C" {
    
#pragma mark - Functions

    char* toUtf8String(char *szStr){
        NSString *nsSt = [NSString stringWithUTF8String:szStr];
        char * utf8String = strdup([nsSt UTF8String]);
        return utf8String;
    }

    int _addTwoNumberInIOS(int a , int b) {
        int result = [[UnityPlugin shared] AddTwoNumberWithA:(a) b:(b)];
        return result;
    }

    void _iniInstance(){
        [[UnityPlugin shared] initInstance];
    }

    void _iniInstanceWithName(char *appId){
        [[UnityPlugin shared] initInstanceWithAppId:(appId)];
    }
    
    void _applicationStarted() {
        [[UnityPlugin shared] applicationStarted];
    }

    void _setUserName(char *userName){
        [[UnityPlugin shared] setUserNameWithUserName:(userName)];
    }

    void _setUserAge(int age){
        [[UnityPlugin shared]setUserAgeWithAge:(age)];
    }

    void _setGender(int gender){
        [[UnityPlugin shared]setGenderWithGender:(gender)];
    }

    void _setCOPPA(bool isCOPPA){
        [[UnityPlugin shared]setCOPPAWithIsCOPPA:(isCOPPA)];
    }

    void _showAdList(char *title){
        [[UnityPlugin shared]showAdListWithTitle:(title)];
    }

    void _actionCompleted(char *actionName){
        [[UnityPlugin shared]actionCompletedWithActionName:(actionName)];
    }

    void _buyCompleted(char *itemName){
        [[UnityPlugin shared]buyCompletedWithItemName:(itemName)];
    }

    void _queryPoint(char *handlerName){
        NSString *nsSt = [NSString stringWithUTF8String:handlerName];
        char * utf8String = strdup([nsSt UTF8String]);
        [[UnityPlugin shared]queryPoint:^(NSString * msg) {
            UnitySendMessage(utf8String, "onReturnQueryPointBinding", [msg UTF8String]);
        }];
    }

    void _withdrawPoints(char *desc, char *handlerName){
        NSString *nsSt = [NSString stringWithUTF8String:handlerName];
        char * utf8String = strdup([nsSt UTF8String]);
        [[UnityPlugin shared]withdrawPointsWithDesc:(desc) ch:^(NSString * msg){
            UnitySendMessage(utf8String, "onReturnWithdrawPointsBinding", [msg UTF8String]);
        }];
    }

    void _purchaseItem(int cost, char *itemName, char *handlerName){
        NSString *nsSt = [NSString stringWithUTF8String:handlerName];
        char * utf8String = strdup([nsSt UTF8String]);
        [[UnityPlugin shared]purchaseItemWithCost:(cost) itemName:(itemName) ch:^(NSString * msg){
            UnitySendMessage(utf8String, "onReturnPurchaseItemBinding", [msg UTF8String]);
        }];
    }

    void _queryPublishState(char *handlerName){
        NSString *nsSt = [NSString stringWithUTF8String:handlerName];
        char * utf8String = strdup([nsSt UTF8String]);
        [[UnityPlugin shared]queryPublishState:^(NSString * msg) {
            UnitySendMessage(utf8String, "onReturnQueryPublishStateBinding", [msg UTF8String]);
        }];
    }

    void _setTnkAdAnalytics(char *handlerName){
        NSString *nsSt = [NSString stringWithUTF8String:handlerName];
        char * utf8String = strdup([nsSt UTF8String]);
        [[UnityPlugin shared]setTnkAdAnalytics:^(NSString * msg) {
            UnitySendMessage(utf8String, "onOfferwallEventBinding", [msg UTF8String]);
        }];
    }
    
    

}
