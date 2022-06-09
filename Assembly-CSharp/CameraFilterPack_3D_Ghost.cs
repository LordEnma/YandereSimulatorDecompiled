// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_3D_Ghost
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Ghost")]
public class CameraFilterPack_3D_Ghost : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  public bool _Visualize;
  private Material SCMaterial;
  [Range(0.0f, 100f)]
  public float _FixDistance = 5f;
  [Range(-0.5f, 0.99f)]
  public float Ghost_Near = 0.08f;
  [Range(0.0f, 1f)]
  public float Ghost_Far = 0.55f;
  [Range(0.0f, 2f)]
  public float Intensity = 1f;
  [Range(0.0f, 1f)]
  public float GhostWithoutObject = 1f;
  [Range(-1f, 1f)]
  public float GhostPosX;
  [Range(-1f, 1f)]
  public float GhostPosY;
  [Range(0.1f, 8f)]
  public float GhostFade2 = 2f;
  [Range(-1f, 1f)]
  public float GhostFade;
  [Range(0.5f, 1.5f)]
  public float GhostSize = 0.9f;

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
    this.SCShader = Shader.Find("CameraFilterPack/3D_Ghost");
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
      this.material.SetFloat("GhostPosX", this.GhostPosX);
      this.material.SetFloat("GhostPosY", this.GhostPosY);
      this.material.SetFloat("GhostFade", this.GhostFade);
      this.material.SetFloat("GhostFade2", this.GhostFade2);
      this.material.SetFloat("GhostSize", this.GhostSize);
      this.material.SetFloat("_Visualize", this._Visualize ? 1f : 0.0f);
      this.material.SetFloat("_FixDistance", this._FixDistance);
      this.material.SetFloat("Drop_Near", this.Ghost_Near);
      this.material.SetFloat("Drop_Far", this.Ghost_Far);
      this.material.SetFloat("Drop_With_Obj", this.GhostWithoutObject);
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
