// Decompiled with JetBrains decompiler
// Type: BarScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BarScript : MonoBehaviour
{
  public float Speed;
  public float Goal;

  private void Start() => this.transform.localScale = new Vector3(0.0f, 1f, 1f);

  private void Update()
  {
    if ((double) this.Goal == 0.0)
    {
      this.transform.localScale = new Vector3(this.transform.localScale.x + this.Speed * Time.deltaTime, 1f, 1f);
      if ((double) this.transform.localScale.x <= 0.1)
        return;
      this.transform.localScale = new Vector3(0.0f, 1f, 1f);
    }
    else
    {
      this.Speed += Time.deltaTime;
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(this.Goal, 1f, 1f), Time.deltaTime * this.Speed);
    }
  }
}
