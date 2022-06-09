// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Colors_Adjust_FullColors
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/ColorsAdjust/FullColors")]
public class CameraFilterPack_Colors_Adjust_FullColors : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(-200f, 200f)]
  public float Red_R = 100f;
  [Range(-200f, 200f)]
  public float Red_G;
  [Range(-200f, 200f)]
  public float Red_B;
  [Range(-200f, 200f)]
  public float Red_Constant;
  [Range(-200f, 200f)]
  public float Green_R;
  [Range(-200f, 200f)]
  public float Green_G = 100f;
  [Range(-200f, 200f)]
  public float Green_B;
  [Range(-200f, 200f)]
  public float Green_Constant;
  [Range(-200f, 200f)]
  public float Blue_R;
  [Range(-200f, 200f)]
  public float Blue_G;
  [Range(-200f, 200f)]
  public float Blue_B = 100f;
  [Range(-200f, 200f)]
  public float Blue_Constant;

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
    this.SCShader = Shader.Find("CameraFilterPack/Colors_Adjust_FullColors");
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
      this.material.SetFloat("_Red_R", this.Red_R / 100f);
      this.material.SetFloat("_Red_G", this.Red_G / 100f);
      this.material.SetFloat("_Red_B", this.Red_B / 100f);
      this.material.SetFloat("_Green_R", this.Green_R / 100f);
      this.material.SetFloat("_Green_G", this.Green_G / 100f);
      this.material.SetFloat("_Green_B", this.Green_B / 100f);
      this.material.SetFloat("_Blue_R", this.Blue_R / 100f);
      this.material.SetFloat("_Blue_G", this.Blue_G / 100f);
      this.material.SetFloat("_Blue_B", this.Blue_B / 100f);
      this.material.SetFloat("_Red_C", this.Red_Constant / 100f);
      this.material.SetFloat("_Green_C", this.Green_Constant / 100f);
      this.material.SetFloat("_Blue_C", this.Blue_Constant / 100f);
      this.material.SetVector("_ScreenResolution", new Vector4((float) sourceTexture.width, (float) sourceTexture.height, 0.0f, 0.0f));
      Graphics.Blit((Texture) sourceTexture, destTexture, this.material);
    }
    else
      Graphics.Blit((Texture) sourceTexture, destTexture);
  }

  private void Update()
  {
    int num = Application.isPlaying ? 1 : 0;
  }

  private void OnDisable()
  {
    if (!(bool) (Object) this.SCMaterial)
      return;
    Object.DestroyImmediate((Object) this.SCMaterial);
  }
}
