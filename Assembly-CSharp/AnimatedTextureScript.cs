// Decompiled with JetBrains decompiler
// Type: AnimatedTextureScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AnimatedTextureScript : MonoBehaviour
{
  [SerializeField]
  private Renderer MyRenderer;
  [SerializeField]
  private int Start;
  [SerializeField]
  private int Frame;
  [SerializeField]
  private int Limit;
  [SerializeField]
  private float FramesPerSecond;
  [SerializeField]
  private float CurrentSeconds;
  public Texture[] Image;

  private void Awake()
  {
  }

  private float SecondsPerFrame => 1f / this.FramesPerSecond;

  private void Update()
  {
    this.CurrentSeconds += Time.unscaledDeltaTime;
    while ((double) this.CurrentSeconds >= (double) this.SecondsPerFrame)
    {
      this.CurrentSeconds -= this.SecondsPerFrame;
      ++this.Frame;
      if (this.Frame > this.Limit)
        this.Frame = this.Start;
    }
    this.MyRenderer.material.mainTexture = this.Image[this.Frame];
  }
}
