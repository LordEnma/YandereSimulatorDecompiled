// Decompiled with JetBrains decompiler
// Type: NotificationManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NotificationManagerScript : MonoBehaviour
{
  public YandereScript Yandere;
  public Transform NotificationSpawnPoint;
  public Transform NotificationParent;
  public GameObject Notification;
  public int NotificationsSpawned;
  public int Phase = 1;
  public ClockScript Clock;
  public string PersonaName;
  public string PreviousText;
  public string CustomText;
  public string TopicName;
  public string[] ClubNames;
  private NotificationTypeAndStringDictionary NotificationMessages;

  private void Awake()
  {
    NotificationTypeAndStringDictionary stringDictionary = new NotificationTypeAndStringDictionary();
    stringDictionary.Add(NotificationType.Bloody, "Visibly Bloody");
    stringDictionary.Add(NotificationType.Body, "Near Body");
    stringDictionary.Add(NotificationType.Insane, "Visibly Insane");
    stringDictionary.Add(NotificationType.Armed, "Visibly Armed");
    stringDictionary.Add(NotificationType.Lewd, "Visibly Lewd");
    stringDictionary.Add(NotificationType.Intrude, "Intruding");
    stringDictionary.Add(NotificationType.Late, "Late For Class");
    stringDictionary.Add(NotificationType.Info, "Learned New Info");
    stringDictionary.Add(NotificationType.Topic, "Learned New Topic: ");
    stringDictionary.Add(NotificationType.Opinion, "Learned how a student feels about: ");
    stringDictionary.Add(NotificationType.Complete, "Mission Complete");
    stringDictionary.Add(NotificationType.Exfiltrate, "Leave School");
    stringDictionary.Add(NotificationType.Evidence, "Evidence Recorded");
    stringDictionary.Add(NotificationType.ClassSoon, "Class Begins Soon");
    stringDictionary.Add(NotificationType.ClassNow, "Class Begins Now");
    stringDictionary.Add(NotificationType.Eavesdropping, "Eavesdropping");
    stringDictionary.Add(NotificationType.Clothing, "Cannot Attack; No Spare Clothing");
    stringDictionary.Add(NotificationType.Persona, "Persona");
    stringDictionary.Add(NotificationType.Custom, this.CustomText);
    this.NotificationMessages = stringDictionary;
  }

  private void Update()
  {
    if ((double) this.NotificationParent.localPosition.y > 1.0 / 1000.0 + -0.048999998718500137 * (double) this.NotificationsSpawned)
      this.NotificationParent.localPosition = new Vector3(this.NotificationParent.localPosition.x, Mathf.Lerp(this.NotificationParent.localPosition.y, -0.049f * (float) this.NotificationsSpawned, Time.deltaTime * 10f), this.NotificationParent.localPosition.z);
    if (this.Phase == 1)
    {
      if ((double) this.Clock.HourTime <= 8.3999996185302734)
        return;
      if (!this.Yandere.InClass)
      {
        this.Yandere.StudentManager.TutorialWindow.ShowClassMessage = true;
        this.DisplayNotification(NotificationType.ClassSoon);
      }
      ++this.Phase;
    }
    else if (this.Phase == 2)
    {
      if ((double) this.Clock.HourTime <= 8.5)
        return;
      if (!this.Yandere.InClass)
        this.DisplayNotification(NotificationType.ClassNow);
      ++this.Phase;
    }
    else if (this.Phase == 3)
    {
      if ((double) this.Clock.HourTime <= 13.399999618530273)
        return;
      if (!this.Yandere.InClass)
        this.DisplayNotification(NotificationType.ClassSoon);
      ++this.Phase;
    }
    else
    {
      if (this.Phase != 4 || (double) this.Clock.HourTime <= 13.5)
        return;
      if (!this.Yandere.InClass)
        this.DisplayNotification(NotificationType.ClassNow);
      ++this.Phase;
    }
  }

  public void DisplayNotification(NotificationType Type)
  {
    if (this.Yandere.Egg)
      return;
    GameObject gameObject = Object.Instantiate<GameObject>(this.Notification);
    NotificationScript component = gameObject.GetComponent<NotificationScript>();
    gameObject.transform.parent = this.NotificationParent;
    gameObject.transform.localPosition = new Vector3(0.0f, (float) (0.60275000333786011 + 0.048999998718500137 * (double) this.NotificationsSpawned), 0.0f);
    gameObject.transform.localEulerAngles = Vector3.zero;
    component.NotificationManager = this;
    string str1;
    this.NotificationMessages.TryGetValue(Type, out str1);
    if (Type != NotificationType.Persona && Type != NotificationType.Custom)
    {
      string str2 = "";
      if (Type == NotificationType.Topic || Type == NotificationType.Opinion)
        str2 = this.TopicName;
      component.Label.text = str1 + str2;
    }
    else
      component.Label.text = Type != NotificationType.Custom ? this.PersonaName + " " + str1 : this.CustomText;
    ++this.NotificationsSpawned;
    component.ID = this.NotificationsSpawned;
    this.PreviousText = this.CustomText;
  }
}
