using System;

namespace NotificationSamples
{
	/// <summary>
	/// Represents a notification that was scheduled with <see cref="DontDestroyOnLoad.ScheduleNotification"/>.
	/// </summary>
	public class PendingNotification
	{
		/// <summary>
		/// Whether to reschedule this event if it hasn't displayed once the app is foregrounded again.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Only valid if the <see cref="DontDestroyOnLoad"/>'s <see cref="DontDestroyOnLoad.Mode"/>
		/// flag is set to <see cref="DontDestroyOnLoad.OperatingMode.RescheduleAfterClearing"/>.
		/// </para>
		/// <para>
		/// Will not function for any notifications that are using a delivery scheduling method that isn't time
		/// based, such as iOS location notifications.
		/// </para>
		/// </remarks>
		public bool Reschedule;
		
		/// <summary>
		/// The scheduled notification.
		/// </summary>
		public readonly IGameNotification Notification;

		/// <summary>
		/// Instantiate a new instance of <see cref="PendingNotification"/> from a <see cref="IGameNotification"/>.
		/// </summary>
		/// <param name="notification">The notification to create from.</param>
		public PendingNotification(IGameNotification notification)
		{
			Notification = notification ?? throw new ArgumentNullException(nameof(notification));
		}
	}
}
