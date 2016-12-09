# Xamarin-BaseAppITTMarconiRovereto
Base App Xamarin with MVVM, Repository Pattern, Push Notification Azure, Maps


IOS: Missinig PushNotification and Maps



Before starting the project, you must check the "task list" (VS => View => Task List) ["CTRL + \ + T"]
'cause missing the Azure Endpoint for push notification and Map Id String
   
   UWP : 
   
//TODO UWP maps number take it from microsoft developer website when you create a new app
FormsMaps.Init("");

//TODO UWP - ListenConnectionString take it from Azure portal when you create new NOTIFICATION HUB 
var ListenConnectionString = "Endpoint=sb://xxxxxxxxxxxxxx.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=xxxxxx/XXXXXXXXXXXXXXXXXXXXXXXXXXXX=";

//TODO UWP - NotificationHubName take it from Azure portal when you create new NOTIFICATION HUB 
var NotificationHubName = "xxxxxNotificationHub";


DROID: 

//TODO ANDRODID - Sender ID is Google Api Poject Number
public const string SenderId = "533819xxxxx";

//TODO ANDRODID - ListenConnectionString take it from Azure portal when you create new NOTIFICATION HUB 
public const string ListenConnectionString = "Endpoint=sb://xxxxxxxxxxxxxx.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=xxxxxx/XXXXXXXXXXXXXXXXXXXXXXXXXXXX=";

//TODO ANDRODID - NotificationHubName take it from Azure portal when you create new NOTIFICATION HUB 
public const string NotificationHubName = "xxxxxNotificationHub";

