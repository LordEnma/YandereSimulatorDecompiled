// Decompiled with JetBrains decompiler
// Type: MGPMWaterScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MGPMWaterScript : MonoBehaviour
{
  public Renderer MyRenderer;
  public Texture[] Sprite;
  public float Speed;
  public float Timer;
  public float FPS;
  public int Frame;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer > (double) this.FPS)
    {
      this.Timer = 0.0f;
      ++this.Frame;
      if (this.Frame == this.Sprite.Length)
        this.Frame = 0;
      this.MyRenderer.material.mainTexture = this.Sprite[this.Frame];
    }
    this.transform.localPosition = new Vector3(0.0f, this.transform.localPosition.y - this.Speed * Time.deltaTime, 3f);
    if ((double) this.transform.localPosition.y >= -640.0)
      return;
    this.transform.localPosition = new Vector3(0.0f, this.transform.localPosition.y + 1280f, 3f);
  }
}
