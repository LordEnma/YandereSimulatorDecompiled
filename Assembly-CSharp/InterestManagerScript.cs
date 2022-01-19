using System;
using UnityEngine;

// Token: 0x02000337 RID: 823
public class InterestManagerScript : MonoBehaviour
{
	// Token: 0x060018D2 RID: 6354 RVA: 0x000F4BC2 File Offset: 0x000F2DC2
	private void Start()
	{
	}

	// Token: 0x060018D3 RID: 6355 RVA: 0x000F4BC4 File Offset: 0x000F2DC4
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

	// Token: 0x060018D4 RID: 6356 RVA: 0x000F5120 File Offset: 0x000F3320
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

	// Token: 0x0400261E RID: 9758
	public StudentManagerScript StudentManager;

	// Token: 0x0400261F RID: 9759
	public YandereScript Yandere;

	// Token: 0x04002620 RID: 9760
	public Transform[] Clubs;

	// Token: 0x04002621 RID: 9761
	public Transform DelinquentZone;

	// Token: 0x04002622 RID: 9762
	public Transform Library;

	// Token: 0x04002623 RID: 9763
	public Transform Kitten;

	// Token: 0x04002624 RID: 9764
	public string[] TopicNames;

	// Token: 0x04002625 RID: 9765
	public bool[] Ignore;

	// Token: 0x04002626 RID: 9766
	public int FollowerID;
}
