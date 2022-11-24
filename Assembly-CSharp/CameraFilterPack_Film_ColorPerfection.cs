// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Film_ColorPerfection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Film/ColorPerfection")]
public class CameraFilterPack_Film_ColorPerfection : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(0.0f, 4f)]
  public float Gamma = 0.55f;
  [Range(0.0f, 10f)]
  private float Value2 = 1f;
  [Range(0.0f, 10f)]
  private float Value3 = 1f;
  [Range(0.0f, 10f)]
  private float Value4 = 1f;

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
    this.SCShader = Shader.Find("CameraFilterPack/Film_ColorPerfection");
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
      this.material.SetFloat("_Value", this.Gamma);
      this.material.SetFloat("_Value2", this.Value2);
      this.material.SetFloat("_Value3", this.Value3);
      this.material.SetFloat("_Value4", this.Value4);
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
