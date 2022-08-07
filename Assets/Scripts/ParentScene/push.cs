using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NotificationSamples;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class push : MonoBehaviour
{
    public Text Text_Input_date;
    public Text Text_date;

    

   [SerializeField] private DontDestroyOnLoad notificationsManager;
    private int notificationDelay;

    private void InitalizNotifications()
    {
        GameNotificationChannel channel = new GameNotificationChannel("push","Mobile Notifications","Just a notification");
        notificationsManager.Initialize(channel);
    }

    public void OnTimeInput (string text)
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
        CreateNotification("Diabeto_2","Пора выписывать рецепты", DateTime.Now.AddSeconds (10));
        Text_date.text = Text_Input_date.text;

    }

    private void CreateNotification(string title, string body, DateTime time)
    {
        IGameNotification notification = notificationsManager.CreateNotification();
        if (Text_Input_date.text != "")
        {
            notification.Title = title;
            notification.Body = body;
            notification.DeliveryTime = time;
            notificationsManager.ScheduleNotification(notification);
        }
    }

}
