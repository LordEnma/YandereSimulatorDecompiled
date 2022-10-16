// Decompiled with JetBrains decompiler
// Type: TimePortalScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
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
