// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Atmosphere_Rain_Pro_3D
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/Rain_Pro_3D")]
public class CameraFilterPack_Atmosphere_Rain_Pro_3D : MonoBehaviour
{
  public Shader SCShader;
  public bool _Visualize;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(0.0f, 100f)]
  public float _FixDistance = 3f;
  [Range(0.0f, 1f)]
  public float Fade = 1f;
  [Range(0.0f, 2f)]
  public float Intensity = 0.5f;
  public bool DirectionFollowCameraZ;
  [Range(-0.45f, 0.45f)]
  public float DirectionX = 0.12f;
  [Range(0.4f, 2f)]
  public float Size = 1.5f;
  [Range(0.0f, 0.5f)]
  public float Speed = 0.275f;
  [Range(0.0f, 0.5f)]
  public float Distortion = 0.025f;
  [Range(0.0f, 1f)]
  public float StormFlashOnOff = 1f;
  [Range(0.0f, 1f)]
  public float DropOnOff = 1f;
  [Range(-0.5f, 0.99f)]
  public float Drop_Near;
  [Range(0.0f, 1f)]
  public float Drop_Far = 0.5f;
  [Range(0.0f, 1f)]
  public float Drop_With_Obj = 0.2f;
  [Range(0.0f, 1f)]
  public float Myst = 0.1f;
  [Range(0.0f, 1f)]
  public float Drop_Floor_Fluid;
  public Color Myst_Color = new Color(0.5f, 0.5f, 0.5f, 1f);
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
    this.Texture2 = Resources.Load("CameraFilterPack_Atmosphere_Rain_FX") as Texture2D;
    this.SCShader = Shader.Find("CameraFilterPack/Atmosphere_Rain_Pro_3D");
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
      this.material.SetFloat("_Value", this.Fade);
      this.material.SetFloat("_Value2", this.Intensity);
      if (this.DirectionFollowCameraZ)
      {
        float z = this.GetComponent<Camera>().transform.rotation.z;
        if ((double) z > 0.0 && (double) z < 360.0)
          this.material.SetFloat("_Value3", z);
        if ((double) z < 0.0)
          this.material.SetFloat("_Value3", z);
      }
      else
        this.material.SetFloat("_Value3", this.DirectionX);
      this.material.SetFloat("_Value4", this.Speed);
      this.material.SetFloat("_Value5", this.Size);
      this.material.SetFloat("_Value6", this.Distortion);
      this.material.SetFloat("_Value7", this.StormFlashOnOff);
      this.material.SetFloat("_Value8", this.DropOnOff);
      this.material.SetFloat("_FixDistance", this._FixDistance);
      this.material.SetFloat("_Visualize", this._Visualize ? 1f : 0.0f);
      this.material.SetFloat("Drop_Near", this.Drop_Near);
      this.material.SetFloat("Drop_Far", this.Drop_Far);
      this.material.SetFloat("Drop_With_Obj", 1f - this.Drop_With_Obj);
      this.material.SetFloat("Myst", this.Myst);
      this.material.SetColor("Myst_Color", this.Myst_Color);
      this.material.SetFloat("Drop_Floor_Fluid", this.Drop_Floor_Fluid);
      this.material.SetVector("_ScreenResolution", new Vector4((float) sourceTexture.width, (float) sourceTexture.height, 0.0f, 0.0f));
      this.material.SetTexture("Texture2", (Texture) this.Texture2);
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
