// Decompiled with JetBrains decompiler
// Type: MatchTriggerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
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
    this.Student.Combust();
    if (this.Candle)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
