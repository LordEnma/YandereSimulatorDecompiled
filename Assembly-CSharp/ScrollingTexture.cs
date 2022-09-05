// Decompiled with JetBrains decompiler
// Type: ScrollingTexture
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
