// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_3D_Anomaly
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Anomaly")]
public class CameraFilterPack_3D_Anomaly : MonoBehaviour
{
  public Shader SCShader;
  public bool _Visualize;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(0.0f, 100f)]
  public float _FixDistance = 23f;
  [Range(-0.5f, 0.99f)]
  public float Anomaly_Near = 0.045f;
  [Range(0.0f, 1f)]
  public float Anomaly_Far = 0.11f;
  [Range(0.0f, 2f)]
  public float Intensity = 1f;
  [Range(0.0f, 1f)]
  public float AnomalyWithoutObject = 1f;
  [Range(0.1f, 1f)]
  public float Anomaly_Distortion = 0.25f;
  [Range(4f, 64f)]
  public float Anomaly_Distortion_Size = 12f;
  [Range(-4f, 8f)]
  public float Anomaly_Intensity = 2f;

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
    this.SCShader = Shader.Find("CameraFilterPack/3D_Anomaly");
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
      this.material.SetFloat("_Value2", this.Intensity);
      this.material.SetFloat("Anomaly_Distortion", this.Anomaly_Distortion);
      this.material.SetFloat("Anomaly_Distortion_Size", this.Anomaly_Distortion_Size);
      this.material.SetFloat("Anomaly_Intensity", this.Anomaly_Intensity);
      this.material.SetFloat("_Visualize", this._Visualize ? 1f : 0.0f);
      this.material.SetFloat("_FixDistance", this._FixDistance);
      this.material.SetFloat("Anomaly_Near", this.Anomaly_Near);
      this.material.SetFloat("Anomaly_Far", this.Anomaly_Far);
      this.material.SetFloat("Anomaly_With_Obj", this.AnomalyWithoutObject);
      this.material.SetVector("_ScreenResolution", new Vector4((float) sourceTexture.width, (float) sourceTexture.height, 0.0f, 0.0f));
      this.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
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
