// Decompiled with JetBrains decompiler
// Type: MGPMGifScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MGPMGifScript : MonoBehaviour
{
  public Texture[] Frames;
  public Renderer MyRenderer;
  public float Timer;
  public float FPS;
  public int ID;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= (double) this.FPS)
      return;
    ++this.ID;
    if (this.ID == this.Frames.Length)
      this.ID = 0;
    this.MyRenderer.material.mainTexture = this.Frames[this.ID];
    this.Timer = 0.0f;
  }
}
