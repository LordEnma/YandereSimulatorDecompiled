// Decompiled with JetBrains decompiler
// Type: DoorOpenerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DoorOpenerScript : MonoBehaviour
{
  public StudentScript Student;
  public DoorScript Door;

  private void Start() => this.gameObject.layer = 1;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 9)
      return;
    this.Student = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) this.Student != (Object) null) || this.Student.Dying || this.Door.Open || this.Door.Locked)
      return;
    this.Door.Student = this.Student;
    this.Door.OpenDoor();
  }

  private void OnTriggerStay(Collider other)
  {
    if (this.Door.Open || other.gameObject.layer != 9)
      return;
    this.Student = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) this.Student != (Object) null) || this.Student.Dying || this.Door.Open || this.Door.Locked)
      return;
    this.Door.Student = this.Student;
    this.Door.OpenDoor();
  }
}
