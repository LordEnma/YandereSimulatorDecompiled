// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Glasses_On_5
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Futuristic Montain")]
public class CameraFilterPack_Glasses_On_5 : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  [Range(0.0f, 1f)]
  public float Fade = 0.2f;
  [Range(0.0f, 0.1f)]
  public float VisionBlur = 0.005f;
  public Color GlassesColor = new Color(0.1f, 0.1f, 0.1f, 1f);
  public Color GlassesColor2 = new Color(0.45f, 0.45f, 0.45f, 0.25f);
  [Range(0.0f, 1f)]
  public float GlassDistortion = 0.6f;
  [Range(0.0f, 1f)]
  public float GlassAberration = 0.3f;
  [Range(0.0f, 1f)]
  public float UseFinalGlassColor;
  [Range(0.0f, 1f)]
  public float UseScanLine = 0.4f;
  [Range(1f, 512f)]
  public float UseScanLineSize = 358f;
  public Color GlassColor = new Color(0.1f, 0.3f, 1f, 1f);
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
    this.Texture2 = Resources.Load("CameraFilterPack_Glasses_On6") as Texture2D;
    this.SCShader = Shader.Find("CameraFilterPack/Glasses_On");
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
      this.material.SetFloat("UseFinalGlassColor", this.UseFinalGlassColor);
      this.material.SetFloat("Fade", this.Fade);
      this.material.SetFloat("VisionBlur", this.VisionBlur);
      this.material.SetFloat("GlassDistortion", this.GlassDistortion);
      this.material.SetFloat("GlassAberration", this.GlassAberration);
      this.material.SetColor("GlassesColor", this.GlassesColor);
      this.material.SetColor("GlassesColor2", this.GlassesColor2);
      this.material.SetColor("GlassColor", this.GlassColor);
      this.material.SetFloat("UseScanLineSize", this.UseScanLineSize);
      this.material.SetFloat("UseScanLine", this.UseScanLine);
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
