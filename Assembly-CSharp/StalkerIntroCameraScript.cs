// Decompiled with JetBrains decompiler
// Type: StalkerIntroCameraScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class StalkerIntroCameraScript : MonoBehaviour
{
  public Animation YandereAnim;
  public Transform Yandere;
  public float Speed;

  private void Update()
  {
    if ((double) this.YandereAnim["f02_wallJump_00"].time <= (double) this.YandereAnim["f02_wallJump_00"].length)
      return;
    this.Speed += Time.deltaTime;
    this.Yandere.position = Vector3.Lerp(this.Yandere.position, new Vector3(14.33333f, 0.0f, 15f), Time.deltaTime * this.Speed);
    this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(13.75f, 1.4f, 14.5f), Time.deltaTime * this.Speed);
    this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, new Vector3(15f, 180f, 0.0f), Time.deltaTime * this.Speed);
  }
}
