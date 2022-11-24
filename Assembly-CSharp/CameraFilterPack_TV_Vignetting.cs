// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_TV_Vignetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Vignetting")]
public class CameraFilterPack_TV_Vignetting : MonoBehaviour
{
  public Shader SCShader;
  private Material SCMaterial;
  private Texture2D Vignette;
  [Range(0.0f, 1f)]
  public float Vignetting = 1f;
  [Range(0.0f, 1f)]
  public float VignettingFull;
  [Range(0.0f, 1f)]
  public float VignettingDirt;
  public Color VignettingColor = new Color(0.0f, 0.0f, 0.0f, 1f);

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
    this.SCShader = Shader.Find("CameraFilterPack/TV_Vignetting");
    this.Vignette = Resources.Load("CameraFilterPack_TV_Vignetting1") as Texture2D;
    if (SystemInfo.supportsImageEffects)
      return;
    this.enabled = false;
  }

  private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
  {
    if ((Object) this.SCShader != (Object) null)
    {
      this.material.SetTexture("Vignette", (Texture) this.Vignette);
      this.material.SetFloat("_Vignetting", this.Vignetting);
      this.material.SetFloat("_Vignetting2", this.VignettingFull);
      this.material.SetColor("_VignettingColor", this.VignettingColor);
      this.material.SetFloat("_VignettingDirt", this.VignettingDirt);
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
