// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Colors_RgbClamp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/RgbClamp")]
public class CameraFilterPack_Colors_RgbClamp : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(0.0f, 1f)]
  public float Red_Start;
  [Range(0.0f, 1f)]
  public float Red_End = 1f;
  [Range(0.0f, 1f)]
  public float Green_Start;
  [Range(0.0f, 1f)]
  public float Green_End = 1f;
  [Range(0.0f, 1f)]
  public float Blue_Start;
  [Range(0.0f, 1f)]
  public float Blue_End = 1f;
  [Range(0.0f, 1f)]
  public float RGB_Start;
  [Range(0.0f, 1f)]
  public float RGB_End = 1f;

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
    this.SCShader = Shader.Find("CameraFilterPack/Colors_RgbClamp");
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
      this.material.SetFloat("_Value", this.Red_Start);
      this.material.SetFloat("_Value2", this.Red_End);
      this.material.SetFloat("_Value3", this.Green_Start);
      this.material.SetFloat("_Value4", this.Green_End);
      this.material.SetFloat("_Value5", this.Blue_Start);
      this.material.SetFloat("_Value6", this.Blue_End);
      this.material.SetFloat("_Value7", this.RGB_Start);
      this.material.SetFloat("_Value8", this.RGB_End);
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
