// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_3D_Snow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Snow")]
public class CameraFilterPack_3D_Snow : MonoBehaviour
{
  public Shader SCShader;
  public bool _Visualize;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(0.0f, 100f)]
  public float _FixDistance = 5f;
  [Range(-0.5f, 0.99f)]
  public float Snow_Near = 0.08f;
  [Range(0.0f, 1f)]
  public float Snow_Far = 0.55f;
  [Range(0.0f, 1f)]
  public float Fade = 1f;
  [Range(0.0f, 2f)]
  public float Intensity = 1f;
  [Range(0.4f, 2f)]
  public float Size = 1f;
  [Range(0.0f, 0.5f)]
  public float Speed = 0.275f;
  [Range(0.0f, 1f)]
  public float SnowWithoutObject = 1f;
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
    this.Texture2 = Resources.Load("CameraFilterPack_Blizzard1") as Texture2D;
    this.SCShader = Shader.Find("CameraFilterPack/3D_Snow");
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
      this.material.SetFloat("_Value4", this.Speed * 6f);
      this.material.SetFloat("_Value5", this.Size);
      this.material.SetFloat("_Visualize", this._Visualize ? 1f : 0.0f);
      this.material.SetFloat("_FixDistance", this._FixDistance);
      this.material.SetFloat("Drop_Near", this.Snow_Near);
      this.material.SetFloat("Drop_Far", this.Snow_Far);
      this.material.SetFloat("Drop_With_Obj", this.SnowWithoutObject);
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
