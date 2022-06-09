// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_EyesVision_2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Eyes 2")]
public class CameraFilterPack_EyesVision_2 : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  [Range(1f, 32f)]
  public float _EyeWave = 15f;
  [Range(0.0f, 10f)]
  public float _EyeSpeed = 1f;
  [Range(0.0f, 8f)]
  public float _EyeMove = 2f;
  [Range(0.0f, 1f)]
  public float _EyeBlink = 1f;
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
    this.Texture2 = Resources.Load("CameraFilterPack_eyes_vision_2") as Texture2D;
    this.SCShader = Shader.Find("CameraFilterPack/EyesVision_2");
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
      this.material.SetFloat("_Value", this._EyeWave);
      this.material.SetFloat("_Value2", this._EyeSpeed);
      this.material.SetFloat("_Value3", this._EyeMove);
      this.material.SetFloat("_Value4", this._EyeBlink);
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
