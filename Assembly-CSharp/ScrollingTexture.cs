// Decompiled with JetBrains decompiler
// Type: ScrollingTexture
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
  public Renderer MyRenderer;
  public float Offset;
  public float Speed;

  private void Start() => this.MyRenderer = this.GetComponent<Renderer>();

  private void Update()
  {
    this.Offset += Time.deltaTime * this.Speed;
    this.MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(this.Offset, this.Offset));
  }
}
