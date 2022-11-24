// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Colors_HSV
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/HSV")]
public class CameraFilterPack_Colors_HSV : MonoBehaviour
{
  public Shader SCShader;
  [Range(0.0f, 360f)]
  public float _HueShift = 180f;
  [Range(-32f, 32f)]
  public float _Saturation = 1f;
  [Range(-32f, 32f)]
  public float _ValueBrightness = 1f;
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
    if (SystemInfo.supportsImageEffects)
      return;
    this.enabled = false;
  }

  private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
  {
    if ((Object) this.SCShader != (Object) null)
    {
      this.material.SetFloat("_HueShift", this._HueShift);
      this.material.SetFloat("_Sat", this._Saturation);
      this.material.SetFloat("_Val", this._ValueBrightness);
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
