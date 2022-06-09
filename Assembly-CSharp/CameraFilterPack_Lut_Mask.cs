// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Lut_Mask
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Lut/Mask")]
public class CameraFilterPack_Lut_Mask : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  private Vector4 ScreenResolution;
  private Material SCMaterial;
  public Texture2D LutTexture;
  private Texture3D converted3DLut;
  [Range(0.0f, 1f)]
  public float Blend = 1f;
  public Texture2D Mask;
  [Range(0.0f, 1f)]
  public float Inverse = 1f;
  private string MemoPath;

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
    this.SCShader = Shader.Find("CameraFilterPack/Lut_Mask");
    if (SystemInfo.supportsImageEffects)
      return;
    this.enabled = false;
  }

  public void SetIdentityLut()
  {
    int num1 = 16;
    Color[] colors = new Color[num1 * num1 * num1];
    float num2 = (float) (1.0 / (1.0 * (double) num1 - 1.0));
    for (int index1 = 0; index1 < num1; ++index1)
    {
      for (int index2 = 0; index2 < num1; ++index2)
      {
        for (int index3 = 0; index3 < num1; ++index3)
          colors[index1 + index2 * num1 + index3 * num1 * num1] = new Color((float) index1 * 1f * num2, (float) index2 * 1f * num2, (float) index3 * 1f * num2, 1f);
      }
    }
    if ((bool) (Object) this.converted3DLut)
      Object.DestroyImmediate((Object) this.converted3DLut);
    this.converted3DLut = new Texture3D(num1, num1, num1, TextureFormat.ARGB32, false);
    this.converted3DLut.SetPixels(colors);
    this.converted3DLut.Apply();
  }

  public bool ValidDimensions(Texture2D tex2d) => (bool) (Object) tex2d && tex2d.height == Mathf.FloorToInt(Mathf.Sqrt((float) tex2d.width));

  public void Convert(Texture2D temp2DTex)
  {
    if ((bool) (Object) temp2DTex)
    {
      int num1 = temp2DTex.width * temp2DTex.height;
      int height = temp2DTex.height;
      if (!this.ValidDimensions(temp2DTex))
      {
        Debug.LogWarning((object) ("The given 2D texture " + temp2DTex.name + " cannot be used as a 3D LUT."));
      }
      else
      {
        Color[] pixels = temp2DTex.GetPixels();
        Color[] colors = new Color[pixels.Length];
        for (int index1 = 0; index1 < height; ++index1)
        {
          for (int index2 = 0; index2 < height; ++index2)
          {
            for (int index3 = 0; index3 < height; ++index3)
            {
              int num2 = height - index2 - 1;
              colors[index1 + index2 * height + index3 * height * height] = pixels[index3 * height + index1 + num2 * height * height];
            }
          }
        }
        if ((bool) (Object) this.converted3DLut)
          Object.DestroyImmediate((Object) this.converted3DLut);
        this.converted3DLut = new Texture3D(height, height, height, TextureFormat.ARGB32, false);
        this.converted3DLut.SetPixels(colors);
        this.converted3DLut.Apply();
      }
    }
    else
      this.SetIdentityLut();
  }

  private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
  {
    if ((Object) this.SCShader != (Object) null || !SystemInfo.supports3DTextures)
    {
      this.TimeX += Time.deltaTime;
      if ((double) this.TimeX > 100.0)
        this.TimeX = 0.0f;
      if ((Object) this.converted3DLut == (Object) null)
        this.Convert(this.LutTexture);
      this.converted3DLut.wrapMode = TextureWrapMode.Clamp;
      this.material.SetFloat("_Blend", this.Blend);
      this.material.SetTexture("_LutTex", (Texture) this.converted3DLut);
      this.material.SetTexture("_MaskTex", (Texture) this.Mask);
      this.material.SetFloat("_Inverse", this.Inverse);
      Graphics.Blit((Texture) sourceTexture, destTexture, this.material, QualitySettings.activeColorSpace == ColorSpace.Linear ? 1 : 0);
    }
    else
      Graphics.Blit((Texture) sourceTexture, destTexture);
  }

  private void OnValidate()
  {
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
