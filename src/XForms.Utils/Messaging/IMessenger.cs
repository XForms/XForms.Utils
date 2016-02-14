using System;

namespace XForms.Utils.Messaging
{
	/// <summary>
	/// Author: Thomas Bandt
	/// https://thomasbandt.com/a-nicer-messaging-interface-for-xamarinforms
	/// </summary>
	public interface IMessenger
	{
		void Send<TMessage>(TMessage message, object sender = null) where TMessage : IMessage;
		void Subscribe<TMessage>(object subscriber, Action<object, TMessage> callback) where TMessage : IMessage;
		void Unsubscribe<TMessage>(object subscriber) where TMessage : IMessage;
	}
}
