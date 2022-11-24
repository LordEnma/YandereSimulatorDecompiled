// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_TV_VHS_Rewind
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VHS_Rewind")]
public class CameraFilterPack_TV_VHS_Rewind : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(0.0f, 1f)]
  public float Cryptage = 1f;
  [Range(-20f, 20f)]
  public float Parasite = 9f;
  [Range(-20f, 20f)]
  public float Parasite2 = 12f;
  [Range(0.0f, 1f)]
  private float WhiteParasite = 1f;

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
    this.SCShader = Shader.Find("CameraFilterPack/TV_VHS_Rewind");
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
      this.material.SetFloat("_Value", this.Cryptage);
      this.material.SetFloat("_Value2", this.Parasite);
      this.material.SetFloat("_Value3", this.Parasite2);
      this.material.SetFloat("_Value4", this.WhiteParasite);
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
