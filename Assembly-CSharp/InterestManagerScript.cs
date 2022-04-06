using System;
using UnityEngine;

// Token: 0x0200033B RID: 827
public class InterestManagerScript : MonoBehaviour
{
	// Token: 0x060018F7 RID: 6391 RVA: 0x000F6D8E File Offset: 0x000F4F8E
	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			this.TopicNames[14] = "Jokes";
		}
	}

	// Token: 0x060018F8 RID: 6392 RVA: 0x000F6DA8 File Offset: 0x000F4FA8
	private void Update()
	{
		if (this.Yandere.Follower != null)
		{
			for (int i = 1; i < 11; i++)
			{
				if (!this.Ignore[i] && Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[i].position) < 4f && !ConversationGlobals.GetTopicLearnedByStudent(i, this.FollowerID))
				{
					this.Yandere.NotificationManager.TopicName = this.TopicNames[i];
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
					ConversationGlobals.SetTopicLearnedByStudent(i, this.FollowerID, true);
					this.Ignore[i] = true;
				}
			}
			if (!this.Ignore[11] && Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[11].position) < 4f && !ConversationGlobals.GetTopicLearnedByStudent(11, this.FollowerID))
			{
				if (!ConversationGlobals.GetTopicDiscovered(11))
				{
					this.Yandere.NotificationManager.TopicName = "Video Games";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					this.Yandere.NotificationManager.TopicName = "Anime";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					this.Yandere.NotificationManager.TopicName = "Cosplay";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					this.Yandere.NotificationManager.TopicName = "Memes";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(11, true);
					ConversationGlobals.SetTopicDiscovered(12, true);
					ConversationGlobals.SetTopicDiscovered(13, true);
					ConversationGlobals.SetTopicDiscovered(14, true);
				}
				this.Yandere.NotificationManager.TopicName = "Video Games";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				this.Yandere.NotificationManager.TopicName = "Anime";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				this.Yandere.NotificationManager.TopicName = "Cosplay";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				this.Yandere.NotificationManager.TopicName = "Memes";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(11, this.FollowerID, true);
				ConversationGlobals.SetTopicLearnedByStudent(12, this.FollowerID, true);
				ConversationGlobals.SetTopicLearnedByStudent(13, this.FollowerID, true);
				ConversationGlobals.SetTopicLearnedByStudent(14, this.FollowerID, true);
				this.Ignore[11] = true;
			}
			if (!this.Ignore[15] && Vector3.Distance(this.Yandere.Follower.transform.position, this.Kitten.position) < 2.5f && !ConversationGlobals.GetTopicLearnedByStudent(15, this.FollowerID))
			{
				this.Yandere.NotificationManager.TopicName = "Cats";
				if (!ConversationGlobals.GetTopicDiscovered(15))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(15, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(15, this.FollowerID, true);
				this.Ignore[15] = true;
			}
			if (!this.Ignore[16] && Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[6].position) < 4f && !ConversationGlobals.GetTopicLearnedByStudent(16, this.FollowerID))
			{
				this.Yandere.NotificationManager.TopicName = "Justice";
				if (!ConversationGlobals.GetTopicDiscovered(16))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(16, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(16, this.FollowerID, true);
				this.Ignore[16] = true;
			}
			if (!this.Ignore[17] && Vector3.Distance(this.Yandere.Follower.transform.position, this.DelinquentZone.position) < 4f && !ConversationGlobals.GetTopicLearnedByStudent(17, this.FollowerID))
			{
				this.Yandere.NotificationManager.TopicName = "Violence";
				if (!ConversationGlobals.GetTopicDiscovered(17))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(17, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(17, this.FollowerID, true);
				this.Ignore[17] = true;
			}
			if (!this.Ignore[18] && Vector3.Distance(this.Yandere.Follower.transform.position, this.Library.position) < 4f && !ConversationGlobals.GetTopicLearnedByStudent(18, this.FollowerID))
			{
				this.Yandere.NotificationManager.TopicName = "Reading";
				if (!ConversationGlobals.GetTopicDiscovered(18))
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
					ConversationGlobals.SetTopicDiscovered(18, true);
				}
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(18, this.FollowerID, true);
				this.Ignore[18] = true;
			}
		}
	}

	// Token: 0x060018F9 RID: 6393 RVA: 0x000F7304 File Offset: 0x000F5504
	public void UpdateIgnore()
	{
		for (int i = 1; i < 26; i++)
		{
			this.Ignore[i] = false;
		}
		int studentID = this.Yandere.Follower.StudentID;
		for (int i = 1; i < 26; i++)
		{
			if (ConversationGlobals.GetTopicLearnedByStudent(i, studentID))
			{
				this.Ignore[i] = true;
			}
		}
	}

	// Token: 0x0400267E RID: 9854
	public StudentManagerScript StudentManager;

	// Token: 0x0400267F RID: 9855
	public YandereScript Yandere;

	// Token: 0x04002680 RID: 9856
	public Transform[] Clubs;

	// Token: 0x04002681 RID: 9857
	public Transform DelinquentZone;

	// Token: 0x04002682 RID: 9858
	public Transform Library;

	// Token: 0x04002683 RID: 9859
	public Transform Kitten;

	// Token: 0x04002684 RID: 9860
	public string[] TopicNames;

	// Token: 0x04002685 RID: 9861
	public bool[] Ignore;

	// Token: 0x04002686 RID: 9862
	public int FollowerID;
}
