// Decompiled with JetBrains decompiler
// Type: TimePortalScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
    if ((double) this.Timer <= 1.10000002384186)
      return;
    this.Delinquent[this.ID].Suck = true;
    this.Timer = 1f;
    ++this.ID;
    if (this.ID <= 9)
      return;
    this.enabled = false;
  }
}
