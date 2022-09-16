// Decompiled with JetBrains decompiler
// Type: MatchTriggerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
