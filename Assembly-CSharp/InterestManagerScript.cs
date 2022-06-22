// Decompiled with JetBrains decompiler
// Type: InterestManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
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
    for (int topicID = 1; topicID < 11; ++topicID)
    {
      if (!this.Ignore[topicID] && (double) Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[topicID].position) < 4.0 && !ConversationGlobals.GetTopicLearnedByStudent(topicID, this.FollowerID))
      {
        this.Yandere.NotificationManager.TopicName = this.TopicNames[topicID];
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
        ConversationGlobals.SetTopicLearnedByStudent(topicID, this.FollowerID, true);
        this.Ignore[topicID] = true;
      }
    }
    if (!this.Ignore[11] && (double) Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[11].position) < 4.0 && !ConversationGlobals.GetTopicLearnedByStudent(11, this.FollowerID))
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
    if (!this.Ignore[15] && (double) Vector3.Distance(this.Yandere.Follower.transform.position, this.Kitten.position) < 2.5 && !ConversationGlobals.GetTopicLearnedByStudent(15, this.FollowerID))
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
    if (!this.Ignore[16] && (double) Vector3.Distance(this.Yandere.Follower.transform.position, this.Clubs[6].position) < 4.0 && !ConversationGlobals.GetTopicLearnedByStudent(16, this.FollowerID))
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
    if (!this.Ignore[17] && (double) Vector3.Distance(this.Yandere.Follower.transform.position, this.DelinquentZone.position) < 4.0 && !ConversationGlobals.GetTopicLearnedByStudent(17, this.FollowerID))
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
    if (this.Ignore[18] || (double) Vector3.Distance(this.Yandere.Follower.transform.position, this.Library.position) >= 4.0 || ConversationGlobals.GetTopicLearnedByStudent(18, this.FollowerID))
      return;
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

  public void UpdateIgnore()
  {
    for (int index = 1; index < 26; ++index)
      this.Ignore[index] = false;
    int studentId = this.Yandere.Follower.StudentID;
    for (int topicID = 1; topicID < 26; ++topicID)
    {
      if (ConversationGlobals.GetTopicLearnedByStudent(topicID, studentId))
        this.Ignore[topicID] = true;
    }
  }
}
