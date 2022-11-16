// Decompiled with JetBrains decompiler
// Type: InterestManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
    if (!GameGlobals.Eighties)
      return;
    this.TopicNames[14] = "Jokes";
  }

  private void Update()
  {
    if (!((Object) this.Yandere.Follower != (Object) null))
      return;
    for (int Topic = 1; Topic < 11; ++Topic)
    {
      if (!this.Ignore[Topic] && (double) Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[Topic].position) < 4.0 && !this.StudentManager.GetTopicLearnedByStudent(Topic, this.FollowerID))
      {
        this.Yandere.NotificationManager.TopicName = this.TopicNames[Topic];
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
        this.StudentManager.SetTopicLearnedByStudent(Topic, this.FollowerID, true);
        this.Ignore[Topic] = true;
      }
    }
    if (!this.Ignore[11] && (double) Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[11].position) < 4.0 && !this.StudentManager.GetTopicLearnedByStudent(11, this.FollowerID))
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
      this.StudentManager.SetTopicLearnedByStudent(11, this.FollowerID, true);
      this.StudentManager.SetTopicLearnedByStudent(12, this.FollowerID, true);
      this.StudentManager.SetTopicLearnedByStudent(13, this.FollowerID, true);
      this.StudentManager.SetTopicLearnedByStudent(14, this.FollowerID, true);
      this.Ignore[11] = true;
    }
    if (!this.Ignore[15] && (double) Vector3.Distance(this.Yandere.Follower.transform.position, this.Kitten.position) < 2.5 && !this.StudentManager.GetTopicLearnedByStudent(15, this.FollowerID))
    {
      this.Yandere.NotificationManager.TopicName = "Cats";
      if (!ConversationGlobals.GetTopicDiscovered(15))
      {
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        ConversationGlobals.SetTopicDiscovered(15, true);
      }
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
      this.StudentManager.SetTopicLearnedByStudent(15, this.FollowerID, true);
      this.Ignore[15] = true;
    }
    if (!this.Ignore[16] && (double) Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[6].position) < 4.0 && !this.StudentManager.GetTopicLearnedByStudent(16, this.FollowerID))
    {
      this.Yandere.NotificationManager.TopicName = "Justice";
      if (!ConversationGlobals.GetTopicDiscovered(16))
      {
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        ConversationGlobals.SetTopicDiscovered(16, true);
      }
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
      this.StudentManager.SetTopicLearnedByStudent(16, this.FollowerID, true);
      this.Ignore[16] = true;
    }
    if (!this.Ignore[17] && (double) Vector3.Distance(this.Yandere.Follower.transform.position, this.DelinquentZone.position) < 4.0 && !this.StudentManager.GetTopicLearnedByStudent(17, this.FollowerID))
    {
      this.Yandere.NotificationManager.TopicName = "Violence";
      if (!ConversationGlobals.GetTopicDiscovered(17))
      {
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        ConversationGlobals.SetTopicDiscovered(17, true);
      }
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
      this.StudentManager.SetTopicLearnedByStudent(17, this.FollowerID, true);
      this.Ignore[17] = true;
    }
    if (this.Ignore[18] || (double) Vector3.Distance(this.Yandere.Follower.transform.position, this.Library.position) >= 4.0 || this.StudentManager.GetTopicLearnedByStudent(18, this.FollowerID))
      return;
    this.Yandere.NotificationManager.TopicName = "Reading";
    if (!ConversationGlobals.GetTopicDiscovered(18))
    {
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
      ConversationGlobals.SetTopicDiscovered(18, true);
    }
    this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
    this.StudentManager.SetTopicLearnedByStudent(18, this.FollowerID, true);
    this.Ignore[18] = true;
  }

  public void UpdateIgnore()
  {
    for (int index = 1; index < 26; ++index)
      this.Ignore[index] = false;
    int studentId = this.Yandere.Follower.StudentID;
    for (int Topic = 1; Topic < 26; ++Topic)
    {
      if (this.StudentManager.GetTopicLearnedByStudent(Topic, studentId))
        this.Ignore[Topic] = true;
    }
  }
}
