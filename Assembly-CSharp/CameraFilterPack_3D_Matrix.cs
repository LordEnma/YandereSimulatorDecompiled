// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_3D_Matrix
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Matrix")]
public class CameraFilterPack_3D_Matrix : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  private Material SCMaterial;
  public bool _Visualize;
  [Range(0.0f, 100f)]
  public float _FixDistance = 1f;
  [Range(-5f, 5f)]
  public float LightIntensity = 1f;
  [Range(0.0f, 6f)]
  public float MatrixSize = 1f;
  [Range(-4f, 4f)]
  public float MatrixSpeed = 1f;
  [Range(0.0f, 1f)]
  public float Fade = 1f;
  public Color _MatrixColor = new Color(0.0f, 1f, 0.0f, 1f);
  public static Color ChangeColorRGB;
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
    this.Texture2 = Resources.Load("CameraFilterPack_3D_Matrix1") as Texture2D;
    this.SCShader = Shader.Find("CameraFilterPack/3D_Matrix");
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
      this.material.SetFloat("_DepthLevel", this.Fade);
      this.material.SetFloat("_FixDistance", this._FixDistance);
      this.material.SetFloat("_MatrixSize", this.MatrixSize);
      this.material.SetColor("_MatrixColor", this._MatrixColor);
      this.material.SetFloat("_MatrixSpeed", this.MatrixSpeed * 2f);
      this.material.SetFloat("_Visualize", this._Visualize ? 1f : 0.0f);
      this.material.SetFloat("_LightIntensity", this.LightIntensity);
      this.material.SetTexture("_MainTex2", (Texture) this.Texture2);
      this.material.SetFloat("_FarCamera", 1000f / this.GetComponent<Camera>().farClipPlane);
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
