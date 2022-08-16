// Decompiled with JetBrains decompiler
// Type: MusicRippleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MusicRippleScript : MonoBehaviour
{
  public Renderer MyRenderer;
  public Texture[] Sprite;
  public float Timer;
  public float FPS;
  public int Frame;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= (double) this.FPS)
      return;
    this.Timer = 0.0f;
    ++this.Frame;
    if (this.Frame == this.Sprite.Length)
      Object.Destroy((Object) this.gameObject);
    else
      this.MyRenderer.material.mainTexture = this.Sprite[this.Frame];
  }
}
