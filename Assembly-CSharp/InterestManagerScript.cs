using UnityEngine;

public class InterestManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public Transform[] Clubs;

	public Transform DelinquentZone;

	public Transform Library;

	public Transform Kitten;

	public string[] TopicNames;

	public bool[] Ignore;

	public int FollowerID;

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			TopicNames[14] = "Jokes";
		}
	}

	private void Update()
	{
		if (!(Yandere.Follower != null))
		{
			return;
		}
		for (int i = 1; i < 11; i++)
		{
			if (!Ignore[i] && Vector3.Distance(Yandere.Follower.transform.position, Clubs[i].position) < 4f && !StudentManager.GetTopicLearnedByStudent(i, FollowerID))
			{
				Yandere.NotificationManager.TopicName = TopicNames[i];
				Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				StudentManager.SetTopicLearnedByStudent(i, FollowerID, boolean: true);
				Ignore[i] = true;
			}
		}
		if (!Ignore[11] && Vector3.Distance(Yandere.Follower.transform.position, Clubs[11].position) < 4f && !StudentManager.GetTopicLearnedByStudent(11, FollowerID))
		{
			if (!ConversationGlobals.GetTopicDiscovered(11))
			{
				Yandere.NotificationManager.TopicName = "Video Games";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				Yandere.NotificationManager.TopicName = "Anime";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				Yandere.NotificationManager.TopicName = "Cosplay";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				Yandere.NotificationManager.TopicName = "Memes";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				ConversationGlobals.SetTopicDiscovered(11, value: true);
				ConversationGlobals.SetTopicDiscovered(12, value: true);
				ConversationGlobals.SetTopicDiscovered(13, value: true);
				ConversationGlobals.SetTopicDiscovered(14, value: true);
			}
			Yandere.NotificationManager.TopicName = "Video Games";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
			Yandere.NotificationManager.TopicName = "Anime";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
			Yandere.NotificationManager.TopicName = "Cosplay";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
			Yandere.NotificationManager.TopicName = "Memes";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
			StudentManager.SetTopicLearnedByStudent(11, FollowerID, boolean: true);
			StudentManager.SetTopicLearnedByStudent(12, FollowerID, boolean: true);
			StudentManager.SetTopicLearnedByStudent(13, FollowerID, boolean: true);
			StudentManager.SetTopicLearnedByStudent(14, FollowerID, boolean: true);
			Ignore[11] = true;
		}
		if (!Ignore[15] && Vector3.Distance(Yandere.Follower.transform.position, Kitten.position) < 2.5f && !StudentManager.GetTopicLearnedByStudent(15, FollowerID))
		{
			Yandere.NotificationManager.TopicName = "Cats";
			if (!ConversationGlobals.GetTopicDiscovered(15))
			{
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				ConversationGlobals.SetTopicDiscovered(15, value: true);
			}
			Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
			StudentManager.SetTopicLearnedByStudent(15, FollowerID, boolean: true);
			Ignore[15] = true;
		}
		if (!Ignore[16] && Vector3.Distance(Yandere.Follower.transform.position, Clubs[6].position) < 4f && !StudentManager.GetTopicLearnedByStudent(16, FollowerID))
		{
			Yandere.NotificationManager.TopicName = "Justice";
			if (!ConversationGlobals.GetTopicDiscovered(16))
			{
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				ConversationGlobals.SetTopicDiscovered(16, value: true);
			}
			Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
			StudentManager.SetTopicLearnedByStudent(16, FollowerID, boolean: true);
			Ignore[16] = true;
		}
		if (!Ignore[17] && Vector3.Distance(Yandere.Follower.transform.position, DelinquentZone.position) < 4f && !StudentManager.GetTopicLearnedByStudent(17, FollowerID))
		{
			Yandere.NotificationManager.TopicName = "Violence";
			if (!ConversationGlobals.GetTopicDiscovered(17))
			{
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				ConversationGlobals.SetTopicDiscovered(17, value: true);
			}
			Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
			StudentManager.SetTopicLearnedByStudent(17, FollowerID, boolean: true);
			Ignore[17] = true;
		}
		if (!Ignore[18] && Vector3.Distance(Yandere.Follower.transform.position, Library.position) < 4f && !StudentManager.GetTopicLearnedByStudent(18, FollowerID))
		{
			Yandere.NotificationManager.TopicName = "Reading";
			if (!ConversationGlobals.GetTopicDiscovered(18))
			{
				Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				ConversationGlobals.SetTopicDiscovered(18, value: true);
			}
			Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
			StudentManager.SetTopicLearnedByStudent(18, FollowerID, boolean: true);
			Ignore[18] = true;
		}
	}

	public void UpdateIgnore()
	{
		for (int i = 1; i < 26; i++)
		{
			Ignore[i] = false;
		}
		int studentID = Yandere.Follower.StudentID;
		for (int i = 1; i < 26; i++)
		{
			if (StudentManager.GetTopicLearnedByStudent(i, studentID))
			{
				Ignore[i] = true;
			}
		}
	}
}
