// Decompiled with JetBrains decompiler
// Type: ScrollingTexture
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
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
