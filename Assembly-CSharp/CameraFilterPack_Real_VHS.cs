// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Real_VHS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/Real VHS HQ")]
public class CameraFilterPack_Real_VHS : MonoBehaviour
{
  public Shader SCShader;
  private Material SCMaterial;
  private Texture2D VHS;
  private Texture2D VHS2;
  [Range(0.0f, 1f)]
  public float TRACKING = 0.212f;
  [Range(0.0f, 1f)]
  public float JITTER = 1f;
  [Range(0.0f, 1f)]
  public float GLITCH = 1f;
  [Range(0.0f, 1f)]
  public float NOISE = 1f;
  [Range(-1f, 1f)]
  public float Brightness;
  [Range(0.0f, 1.5f)]
  public float Constrast = 1f;

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
    this.SCShader = Shader.Find("CameraFilterPack/Real_VHS");
    this.VHS = Resources.Load("CameraFilterPack_VHS1") as Texture2D;
    this.VHS2 = Resources.Load("CameraFilterPack_VHS2") as Texture2D;
    if (SystemInfo.supportsImageEffects)
      return;
    this.enabled = false;
  }

  public static Texture2D GetRTPixels(Texture2D t, RenderTexture rt, int sx, int sy)
  {
    RenderTexture active = RenderTexture.active;
    RenderTexture.active = rt;
    t.ReadPixels(new Rect(0.0f, 0.0f, (float) t.width, (float) t.height), 0, 0);
    RenderTexture.active = active;
    return t;
  }

  private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
  {
    if ((Object) this.SCShader != (Object) null)
    {
      this.material.SetTexture("VHS", (Texture) this.VHS);
      this.material.SetTexture("VHS2", (Texture) this.VHS2);
      this.material.SetFloat("TRACKING", this.TRACKING);
      this.material.SetFloat("JITTER", this.JITTER);
      this.material.SetFloat("GLITCH", this.GLITCH);
      this.material.SetFloat("NOISE", this.NOISE);
      this.material.SetFloat("Brightness", this.Brightness);
      this.material.SetFloat("CONTRAST", 1f - this.Constrast);
      RenderTexture temporary = RenderTexture.GetTemporary(382, 576, 0);
      temporary.filterMode = FilterMode.Trilinear;
      Graphics.Blit((Texture) sourceTexture, temporary, this.material);
      Graphics.Blit((Texture) temporary, destTexture);
      RenderTexture.ReleaseTemporary(temporary);
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
