// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_AAA_SuperHexagon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Super Hexagon")]
public class CameraFilterPack_AAA_SuperHexagon : MonoBehaviour
{
  public Shader SCShader;
  [Range(0.0f, 1f)]
  public float _AlphaHexa = 1f;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(0.2f, 10f)]
  public float HexaSize = 2.5f;
  public float _BorderSize = 1f;
  public Color _BorderColor = new Color(0.75f, 0.75f, 1f, 1f);
  public Color _HexaColor = new Color(0.0f, 0.5f, 1f, 1f);
  public float _SpotSize = 2.5f;
  public Vector2 center = new Vector2(0.5f, 0.5f);
  public float Radius = 0.25f;

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
    this.SCShader = Shader.Find("CameraFilterPack/AAA_Super_Hexagon");
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
      this.material.SetFloat("_Value", this.HexaSize);
      this.material.SetFloat("_PositionX", this.center.x);
      this.material.SetFloat("_PositionY", this.center.y);
      this.material.SetFloat("_Radius", this.Radius);
      this.material.SetFloat("_BorderSize", this._BorderSize);
      this.material.SetColor("_BorderColor", this._BorderColor);
      this.material.SetColor("_HexaColor", this._HexaColor);
      this.material.SetFloat("_AlphaHexa", this._AlphaHexa);
      this.material.SetFloat("_SpotSize", this._SpotSize);
      this.material.SetVector("_ScreenResolution", new Vector4((float) sourceTexture.width, (float) sourceTexture.height, 0.0f, 0.0f));
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
