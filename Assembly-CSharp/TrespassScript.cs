// Decompiled with JetBrains decompiler
// Type: TrespassScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TrespassScript : MonoBehaviour
{
  public GameObject YandereObject;
  public YandereScript Yandere;
  public PoliceScript Police;
  public bool HideNotification;
  public bool OffLimits;
  public bool FacultyRoom;

  private void OnTriggerEnter(Collider other)
  {
    if (!this.enabled || other.gameObject.layer != 13)
      return;
    this.YandereObject = other.gameObject;
    this.Yandere = other.gameObject.GetComponent<YandereScript>();
    if (!((Object) this.Yandere != (Object) null))
      return;
    if (!this.Yandere.Trespassing)
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Intrude);
    this.Yandere.Trespassing = true;
  }

  private void OnTriggerExit(Collider other)
  {
    if (!((Object) this.Yandere != (Object) null) || !((Object) other.gameObject == (Object) this.YandereObject))
      return;
    this.Yandere.Trespassing = false;
    if (!this.FacultyRoom)
      return;
    this.Yandere.StudentManager.CanSelfReport = false;
    this.Yandere.StudentManager.UpdateTeachers();
  }
}
