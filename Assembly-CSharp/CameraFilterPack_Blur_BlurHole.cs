// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Blur_BlurHole
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Blur Hole")]
public class CameraFilterPack_Blur_BlurHole : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  [Range(1f, 16f)]
  public float Size = 10f;
  [Range(-1f, 1f)]
  public float _Radius = 0.25f;
  [Range(-4f, 4f)]
  public float _SpotSize = 1f;
  [Range(0.0f, 1f)]
  public float _CenterX = 0.5f;
  [Range(0.0f, 1f)]
  public float _CenterY = 0.5f;
  [Range(0.0f, 1f)]
  public float _AlphaBlur = 1f;
  [Range(0.0f, 1f)]
  public float _AlphaBlurInside;
  private Material SCMaterial;

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
    this.SCShader = Shader.Find("CameraFilterPack/BlurHole");
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
      this.material.SetFloat("_Distortion", this.Size);
      this.material.SetFloat("_Radius", this._Radius);
      this.material.SetFloat("_SpotSize", this._SpotSize);
      this.material.SetFloat("_CenterX", this._CenterX);
      this.material.SetFloat("_CenterY", this._CenterY);
      this.material.SetFloat("_Alpha", this._AlphaBlur);
      this.material.SetFloat("_Alpha2", this._AlphaBlurInside);
      this.material.SetVector("_ScreenResolution", (Vector4) new Vector2((float) Screen.width, (float) Screen.height));
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
