// Decompiled with JetBrains decompiler
// Type: TrespassScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
