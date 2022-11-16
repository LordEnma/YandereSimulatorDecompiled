// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Vision_SniperScore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/SniperScore")]
public class CameraFilterPack_Vision_SniperScore : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(0.0f, 1f)]
  public float Fade = 1f;
  [Range(0.0f, 1f)]
  public float Size = 0.45f;
  [Range(0.01f, 0.4f)]
  public float Smooth = 0.045f;
  [Range(0.0f, 1f)]
  public float _Cible = 0.5f;
  [Range(0.0f, 1f)]
  public float _Distortion = 0.5f;
  [Range(0.0f, 1f)]
  public float _ExtraColor = 0.5f;
  [Range(0.0f, 1f)]
  public float _ExtraLight = 0.35f;
  public Color _Tint = new Color(0.0f, 0.6f, 0.0f, 0.25f);
  [Range(0.0f, 10f)]
  private float StretchX = 1f;
  [Range(0.0f, 10f)]
  private float StretchY = 1f;
  [Range(-1f, 1f)]
  public float _PosX;
  [Range(-1f, 1f)]
  public float _PosY;

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
    this.SCShader = Shader.Find("CameraFilterPack/Vision_SniperScore");
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
      this.material.SetFloat("_Fade", this.Fade);
      this.material.SetFloat("_TimeX", this.TimeX);
      this.material.SetFloat("_Value", this.Size);
      this.material.SetFloat("_Value2", this.Smooth);
      this.material.SetFloat("_Value3", this.StretchX);
      this.material.SetFloat("_Value4", this.StretchY);
      this.material.SetFloat("_Cible", this._Cible);
      this.material.SetFloat("_ExtraColor", this._ExtraColor);
      this.material.SetFloat("_Distortion", this._Distortion);
      this.material.SetFloat("_PosX", this._PosX);
      this.material.SetFloat("_PosY", this._PosY);
      this.material.SetColor("_Tint", this._Tint);
      this.material.SetFloat("_ExtraLight", this._ExtraLight);
      Vector2 vector2 = new Vector2((float) Screen.width, (float) Screen.height);
      this.material.SetVector("_ScreenResolution", new Vector4(vector2.x, vector2.y, vector2.y / vector2.x, 0.0f));
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
