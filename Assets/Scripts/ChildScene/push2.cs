using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NotificationSamples;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class push2 : MonoBehaviour
{


    [SerializeField] private DontDestroyOnLoad notificationsManager;
    private int notificationDelay;

    private void InitalizNotifications()
    {
        GameNotificationChannel channel = new GameNotificationChannel("push", "Mobile Notifications", "Just a notification");
        notificationsManager.Initialize(channel);
    }

    public void OnTimeInput(string text)
    {
        if (int.TryParse(text, out int sec))
            notificationDelay = sec;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitalizNotifications();
    }

    public void CreateNotification()
    {
        CreateNotification2("Diabeto_2", "Пора делать инъекцию", DateTime.Now.AddSeconds(1));
     

    }

    public void CreateNotification2(string title, string body, DateTime time)
    {
        IGameNotification notification = notificationsManager.CreateNotification();
        {
            notification.Title = title;
            notification.Body = body;
            notification.DeliveryTime = time;
            notificationsManager.ScheduleNotification(notification);
        }
    }

}

