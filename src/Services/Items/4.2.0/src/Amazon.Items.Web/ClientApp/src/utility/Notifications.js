import React from "react";
import {
    NotificationContainer,
    NotificationManager
} from "react-notifications";
class Notifications {
    static createNotification(prop) {
        return () => {
            switch (prop.type) {
                case "info":
                    NotificationManager.info(prop.message);
                    break;
                case "success":
                    NotificationManager.success(prop.message, "Title here");
                    break;
                case "warning":
                    NotificationManager.warning(
                        "Warning message",
                        "Close after 3000ms",
                        3000
                    );
                    break;
                case "error":
                    NotificationManager.error("Error message", "Click me!", 5000, () => {
                        alert("callback");
                    });
                    break;
            }
        };
    }
}
export default Notifications;