// Decompiled with JetBrains decompiler
// Type: FloatScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FloatScript : MonoBehaviour
{
  public bool Down;
  public float Float;
  public float Speed;
  public float Limit;
  public float DownLimit;
  public float UpLimit;

  private void Update()
  {
    if (!this.Down)
    {
      this.Float += Time.deltaTime * this.Speed;
      if ((double) this.Float > (double) this.Limit)
        this.Down = true;
    }
    else
    {
      this.Float -= Time.deltaTime * this.Speed;
      if ((double) this.Float < -1.0 * (double) this.Limit)
        this.Down = false;
    }
    this.transform.localPosition += new Vector3(0.0f, this.Float * Time.deltaTime, 0.0f);
    if ((double) this.transform.localPosition.y > (double) this.UpLimit)
      this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.UpLimit, this.transform.localPosition.z);
    if ((double) this.transform.localPosition.y >= (double) this.DownLimit)
      return;
    this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.DownLimit, this.transform.localPosition.z);
  }
}
