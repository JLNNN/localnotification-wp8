window.scheduleLocalNotificationsWP8 = function(str, callback) {
    cordova.exec(callback, function(err) {
        console.log(err);
    }, "LocalNotificationWP8", "schedule", [str]);
};

window.cancelAllLocalNotificationsWP8 = function(callback) {
    cordova.exec(callback, function(err) {
        console.log(err);
    }, "LocalNotificationWP8", "cancelAll");
};
