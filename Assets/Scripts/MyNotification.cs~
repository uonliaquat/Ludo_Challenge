using System;
using UnityEngine;

namespace Assets.SimpleAndroidNotifications
{
    public class MyNotification : MonoBehaviour
    {

        public void MakeNotification(string message)
        {
            var notificationParams = new NotificationParams
            {
                Id = UnityEngine.Random.Range(0, int.MaxValue),
                Delay = TimeSpan.FromSeconds(3),
                Title = "Ludo Challenge",
                Message = message,
                Ticker = "Ticker",
                Sound = true,
                Vibrate = true,
                Light = true,
                SmallIcon = NotificationIcon.Star,
                SmallIconColor = new Color(0, 0.5f, 0),
                LargeIcon = "app_icon"
            };

            NotificationManager.SendCustom(notificationParams);
        }
    }
}
