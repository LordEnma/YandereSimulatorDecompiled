// Decompiled with JetBrains decompiler
// Type: MusicRippleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
