using System;
using NUnit.Framework;
using XForms.Utils.Messaging;
using XForms.Utils.Tests.Mocks;

namespace XForms.Utils.Tests.Messaging
{
	[TestFixture()]
	public class MessagerTests
	{
		[Test]
		public void Messager_CorrectSubscription_Test()
		{
			var subscriber = new FakeSubscriber();
			var message = new FakeOneMessage { Text = "Test message" };
			var messenger = new Messenger();
			FakeOneMessage receivedMessage = null;

			messenger.Subscribe<FakeOneMessage>(subscriber, (s, m) =>
				{
					receivedMessage = m;
				});
			
			messenger.Send(message);

			Assert.AreSame(message, receivedMessage);
			Assert.AreEqual(message.Text, receivedMessage.Text);
		}

		[Test]
		public void Messager_IncorrectSubscription_Test()
		{
			var subscriber = new FakeSubscriber();
			var message = new FakeTwoMessage();
			var messenger = new Messenger();
			FakeOneMessage receivedMessage = null;

			messenger.Subscribe<FakeOneMessage>(subscriber, (s, m) =>
				{
					receivedMessage = m;
				});
			
			messenger.Send(message);

			Assert.AreNotSame(message, receivedMessage);
		}

		[TestCase(1)]
		[TestCase(10)]
		[TestCase(1000)]
		public void Messager_Unsubscription_Test(int countSend)
		{
			var subscriber1 = new FakeSubscriber();
			var subscriber2 = new FakeSubscriber();
			var message = new FakeOneMessage { Text = "Test message" };
			var messenger = new Messenger();
			byte firstSubscriberNumber = 0;
			byte secondSubscriberNumber = 0;

			messenger.Subscribe<FakeOneMessage>(subscriber1, (s, m) =>
				{
					firstSubscriberNumber++;
					messenger.Unsubscribe<FakeOneMessage>(subscriber1);
				});
			messenger.Subscribe<FakeOneMessage>(subscriber2, (s, m) =>
				{
					secondSubscriberNumber++;
				});
			
			for (int i = 0; i < countSend; i++)
			{
				messenger.Send(message);
			}

			Assert.AreEqual(1, firstSubscriberNumber);
			Assert.AreEqual(countSend, secondSubscriberNumber);
		}
	}
}

