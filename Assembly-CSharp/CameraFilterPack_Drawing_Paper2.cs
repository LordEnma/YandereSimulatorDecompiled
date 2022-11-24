// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Drawing_Paper2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Paper2")]
public class CameraFilterPack_Drawing_Paper2 : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  public Color Pencil_Color = new Color(0.0f, 0.371f, 0.78f, 1f);
  [Range(0.0001f, 0.0022f)]
  public float Pencil_Size = 0.0008f;
  [Range(0.0f, 2f)]
  public float Pencil_Correction = 0.76f;
  [Range(0.0f, 1f)]
  public float Intensity = 1f;
  [Range(0.0f, 2f)]
  public float Speed_Animation = 1f;
  [Range(0.0f, 1f)]
  public float Corner_Lose = 0.85f;
  [Range(0.0f, 1f)]
  public float Fade_Paper_to_BackColor;
  [Range(0.0f, 1f)]
  public float Fade_With_Original = 1f;
  public Color Back_Color = new Color(1f, 1f, 1f, 1f);
  private Material SCMaterial;
  private Texture2D Texture2;

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
    this.Texture2 = Resources.Load("CameraFilterPack_Paper3") as Texture2D;
    this.SCShader = Shader.Find("CameraFilterPack/Drawing_Paper2");
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
      this.material.SetColor("_PColor", this.Pencil_Color);
      this.material.SetFloat("_Value1", this.Pencil_Size);
      this.material.SetFloat("_Value2", this.Pencil_Correction);
      this.material.SetFloat("_Value3", this.Intensity);
      this.material.SetFloat("_Value4", this.Speed_Animation);
      this.material.SetFloat("_Value5", this.Corner_Lose);
      this.material.SetFloat("_Value6", this.Fade_Paper_to_BackColor);
      this.material.SetFloat("_Value7", this.Fade_With_Original);
      this.material.SetColor("_PColor2", this.Back_Color);
      this.material.SetTexture("_MainTex2", (Texture) this.Texture2);
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
