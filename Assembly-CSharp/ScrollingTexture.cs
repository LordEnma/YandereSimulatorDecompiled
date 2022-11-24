// Decompiled with JetBrains decompiler
// Type: ScrollingTexture
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
