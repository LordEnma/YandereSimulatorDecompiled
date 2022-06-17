// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Oculus_NightVision2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 2")]
public class CameraFilterPack_Oculus_NightVision2 : MonoBehaviour
{
  private string ShaderName = "CameraFilterPack/Oculus_NightVision2";
  public Shader SCShader;
  [Range(0.0f, 1f)]
  public float FadeFX = 1f;
  private float TimeX = 1f;
  private Material SCMaterial;
  private float[] Matrix9;

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

  private void ChangeFilters() => this.Matrix9 = new float[12]
  {
    200f,
    -200f,
    -200f,
    195f,
    4f,
    -160f,
    200f,
    -200f,
    -200f,
    -200f,
    10f,
    -200f
  };

  private void Start()
  {
    this.ChangeFilters();
    this.SCShader = Shader.Find(this.ShaderName);
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
      this.material.SetFloat("_Red_R", this.Matrix9[0] / 100f);
      this.material.SetFloat("_Red_G", this.Matrix9[1] / 100f);
      this.material.SetFloat("_Red_B", this.Matrix9[2] / 100f);
      this.material.SetFloat("_Green_R", this.Matrix9[3] / 100f);
      this.material.SetFloat("_Green_G", this.Matrix9[4] / 100f);
      this.material.SetFloat("_Green_B", this.Matrix9[5] / 100f);
      this.material.SetFloat("_Blue_R", this.Matrix9[6] / 100f);
      this.material.SetFloat("_Blue_G", this.Matrix9[7] / 100f);
      this.material.SetFloat("_Blue_B", this.Matrix9[8] / 100f);
      this.material.SetFloat("_Red_C", this.Matrix9[9] / 100f);
      this.material.SetFloat("_Green_C", this.Matrix9[10] / 100f);
      this.material.SetFloat("_Blue_C", this.Matrix9[11] / 100f);
      this.material.SetFloat("_FadeFX", this.FadeFX);
      this.material.SetVector("_ScreenResolution", new Vector4((float) sourceTexture.width, (float) sourceTexture.height, 0.0f, 0.0f));
      Graphics.Blit((Texture) sourceTexture, destTexture, this.material);
    }
    else
      Graphics.Blit((Texture) sourceTexture, destTexture);
  }

  private void OnValidate() => this.ChangeFilters();

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
