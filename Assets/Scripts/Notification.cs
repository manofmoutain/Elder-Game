using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class Notification : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void SendNotification(string title, string text)
    {
        var c = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
            CanShowBadge = true,
            EnableLights=true,
            LockScreenVisibility=LockScreenVisibility.Public
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);

        var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0) ;

        var notification = new AndroidNotification() {
            Title = title,
            Text = text,
            FireTime = dateTime
        };
        if(DateTime.Now.Hour==12){
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnApplicationPause(bool isPause){
        if (isPause)
        {
            SendNotification("幸福樂齡", "前往完成今日任務~");
        }
    }
}
