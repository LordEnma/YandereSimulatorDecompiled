// Decompiled with JetBrains decompiler
// Type: MusicCreditScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MusicCreditScript : MonoBehaviour
{
  public UILabel SongLabel;
  public UILabel BandLabel;
  public UISprite Sprite;
  public bool Slide;
  public float Timer;

  private void Start()
  {
    this.transform.localPosition = new Vector3(400f, this.transform.localPosition.y, this.transform.localPosition.z);
    this.Sprite.enabled = false;
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
      this.Sprite.enabled = false;
      this.Slide = false;
      this.Timer = 0.0f;
    }
  }
}
