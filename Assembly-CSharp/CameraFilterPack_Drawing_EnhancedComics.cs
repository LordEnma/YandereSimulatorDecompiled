// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Drawing_EnhancedComics
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/EnhancedComics")]
public class CameraFilterPack_Drawing_EnhancedComics : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(0.0f, 1f)]
  public float DotSize = 0.15f;
  [Range(0.0f, 1f)]
  public float _ColorR = 0.9f;
  [Range(0.0f, 1f)]
  public float _ColorG = 0.4f;
  [Range(0.0f, 1f)]
  public float _ColorB = 0.4f;
  [Range(0.0f, 1f)]
  public float _Blood = 0.5f;
  [Range(0.0f, 1f)]
  public float _SmoothStart = 0.02f;
  [Range(0.0f, 1f)]
  public float _SmoothEnd = 0.1f;
  public Color ColorRGB = new Color(1f, 0.0f, 0.0f);

  private Material material
  {
    get
    {
      if ((Object) this.SCMaterial == (Object) null)
      {
        this.SCMaterial = new Material(this.SCShader);
        this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
      }
      return this.SCMaterial;
    }
  }

  private void Start()
  {
    this.SCShader = Shader.Find("CameraFilterPack/Drawing_EnhancedComics");
    if (SystemInfo.supportsImageEffects)
      return;
    this.enabled = false;
  }

  private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
  {
    if ((Object) this.SCShader != (Object) null)
    {
      this.TimeX += Time.deltaTime;
      if ((double) this.TimeX > 100.0)
        this.TimeX = 0.0f;
      this.material.SetFloat("_TimeX", this.TimeX);
      this.material.SetFloat("_DotSize", this.DotSize);
      this.material.SetFloat("_ColorR", this._ColorR);
      this.material.SetFloat("_ColorG", this._ColorG);
      this.material.SetFloat("_ColorB", this._ColorB);
      this.material.SetFloat("_Blood", this._Blood);
      this.material.SetColor("_ColorRGB", this.ColorRGB);
      this.material.SetFloat("_SmoothStart", this._SmoothStart);
      this.material.SetFloat("_SmoothEnd", this._SmoothEnd);
      Graphics.Blit((Texture) sourceTexture, destTexture, this.material);
    }
    else
      Graphics.Blit((Texture) sourceTexture, destTexture);
  }

  private void Update()
  {
  }

  private void OnDisable()
  {
    if (!(bool) (Object) this.SCMaterial)
      return;
    Object.DestroyImmediate((Object) this.SCMaterial);
  }
}
