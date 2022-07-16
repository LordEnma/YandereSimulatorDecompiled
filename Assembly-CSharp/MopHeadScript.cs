// Decompiled with JetBrains decompiler
// Type: MopHeadScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MopHeadScript : MonoBehaviour
{
  public BloodPoolScript BloodPool;
  public MopScript Mop;

  private void OnTriggerStay(Collider other)
  {
    if ((double) this.Mop.Bloodiness >= 100.0 || !(other.tag == "Puddle"))
      return;
    this.BloodPool = other.gameObject.GetComponent<BloodPoolScript>();
    if ((Object) this.BloodPool != (Object) null)
    {
      this.BloodPool.Grow = false;
      other.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
      if (this.BloodPool.Blood)
      {
        this.Mop.Bloodiness += Time.deltaTime * 10f;
        this.Mop.UpdateBlood();
      }
      this.Mop.StudentBloodID = this.BloodPool.StudentBloodID;
      if ((double) other.transform.localScale.x >= 0.100000001490116)
        return;
      Object.Destroy((Object) other.gameObject);
    }
    else
    {
      FootprintScript component = other.transform.GetChild(0).GetComponent<FootprintScript>();
      if ((Object) component != (Object) null)
        this.Mop.StudentBloodID = component.StudentBloodID;
      Object.Destroy((Object) other.gameObject);
    }
  }
}
