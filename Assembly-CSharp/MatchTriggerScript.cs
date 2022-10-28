// Decompiled with JetBrains decompiler
// Type: MatchTriggerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MatchTriggerScript : MonoBehaviour
{
  public StudentScript Student;
  public bool Fireball;
  public bool Candle;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 9)
      return;
    this.Student = other.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
    if (!((Object) this.Student != (Object) null) || this.Student.StudentID <= 1 || !this.Student.Gas && !this.Fireball)
      return;
    if ((Object) this.Student.Yandere.PickUp != (Object) null && this.Student.Yandere.PickUp.OpenFlame)
      this.Student.Yandere.Sanity -= (PlayerGlobals.PantiesEquipped == 10 ? 10f : 20f) * this.Student.Yandere.Numbness;
    this.Student.Combust();
    if (this.Candle)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
