// Decompiled with JetBrains decompiler
// Type: TimePortalScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TimePortalScript : MonoBehaviour
{
  public DelinquentScript[] Delinquent;
  public GameObject BlackHole;
  public float Timer;
  public bool Suck;
  public int ID;

  private void Update()
  {
    if (Input.GetKeyDown("space"))
      this.Suck = true;
    if (!this.Suck)
      return;
    Object.Instantiate<GameObject>(this.BlackHole, this.transform.position + new Vector3(0.0f, 1f, 0.0f), Quaternion.identity);
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 1.1000000238418579)
      return;
    this.Delinquent[this.ID].Suck = true;
    this.Timer = 1f;
    ++this.ID;
    if (this.ID <= 9)
      return;
    this.enabled = false;
  }
}
