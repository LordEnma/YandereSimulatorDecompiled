// Decompiled with JetBrains decompiler
// Type: MusicCreditScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MusicCreditScript : MonoBehaviour
{
  public UILabel SongLabel;
  public UILabel BandLabel;
  public UIPanel Panel;
  public bool Slide;
  public float Timer;

  private void Start()
  {
    this.transform.localPosition = new Vector3(400f, this.transform.localPosition.y, this.transform.localPosition.z);
    this.Panel.enabled = false;
  }

  private void Update()
  {
    if (!this.Slide)
      return;
    this.Timer += Time.deltaTime;
    if ((double) this.Timer < 5.0)
    {
      this.transform.localPosition = new Vector3(Mathf.Lerp(this.transform.localPosition.x, 0.0f, Time.deltaTime * 10f), this.transform.localPosition.y, this.transform.localPosition.z);
    }
    else
    {
      this.transform.localPosition = new Vector3(this.transform.localPosition.x + Time.deltaTime, this.transform.localPosition.y, this.transform.localPosition.z);
      this.transform.localPosition = new Vector3(this.transform.localPosition.x + Mathf.Abs(this.transform.localPosition.x * 0.01f) * (Time.deltaTime * 1000f), this.transform.localPosition.y, this.transform.localPosition.z);
      if ((double) this.transform.localPosition.x <= 400.0)
        return;
      this.transform.localPosition = new Vector3(400f, this.transform.localPosition.y, this.transform.localPosition.z);
      this.Panel.enabled = false;
      this.Slide = false;
      this.Timer = 0.0f;
    }
  }
}
