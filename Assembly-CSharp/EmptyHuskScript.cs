// Decompiled with JetBrains decompiler
// Type: EmptyHuskScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EmptyHuskScript : MonoBehaviour
{
  public StudentScript TargetStudent;
  public Animation MyAnimation;
  public GameObject DarkAura;
  public Transform Mouth;
  public float[] BloodTimes;
  public int EatPhase;

  private void Update()
  {
    if (this.EatPhase < this.BloodTimes.Length && (double) this.MyAnimation["f02_sixEat_00"].time > (double) this.BloodTimes[this.EatPhase])
    {
      Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.Mouth.position, Quaternion.identity).GetComponent<RandomStabScript>().Biting = true;
      ++this.EatPhase;
    }
    if ((double) this.MyAnimation["f02_sixEat_00"].time < (double) this.MyAnimation["f02_sixEat_00"].length)
      return;
    if ((Object) this.DarkAura != (Object) null)
      Object.Instantiate<GameObject>(this.DarkAura, this.transform.position + Vector3.up * 0.81f, Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }
}
