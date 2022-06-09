// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_NewGlitch5
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch5")]
public class CameraFilterPack_NewGlitch5 : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(0.0f, 1f)]
  public float __Speed = 1f;
  [Range(0.0f, 1f)]
  public float _Fade = 1f;
  [Range(0.0f, 1f)]
  public float _Parasite = 1f;
  [Range(0.0f, 0.0f)]
  public float _ZoomX = 1f;
  [Range(0.0f, 0.0f)]
  public float _ZoomY = 1f;
  [Range(0.0f, 0.0f)]
  public float _PosX = 1f;
  [Range(0.0f, 0.0f)]
  public float _PosY = 1f;

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
    this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch5");
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
      this.material.SetFloat("_Speed", this.__Speed);
      this.material.SetFloat("Fade", this._Fade);
      this.material.SetFloat("Parasite", this._Parasite);
      this.material.SetFloat("ZoomX", this._ZoomX);
      this.material.SetFloat("ZoomY", this._ZoomY);
      this.material.SetFloat("PosX", this._PosX);
      this.material.SetFloat("PosY", this._PosY);
      this.material.SetVector("_ScreenResolution", new Vector4((float) sourceTexture.width, (float) sourceTexture.height, 0.0f, 0.0f));
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
