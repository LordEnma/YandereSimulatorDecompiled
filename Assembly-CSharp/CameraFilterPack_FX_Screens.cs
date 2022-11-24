// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_FX_Screens
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Screens")]
public class CameraFilterPack_FX_Screens : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(0.0f, 256f)]
  public float Tiles = 8f;
  [Range(0.0f, 5f)]
  public float Speed = 0.25f;
  public Color color = new Color(0.0f, 1f, 1f, 1f);
  [Range(-1f, 1f)]
  public float PosX;
  [Range(-1f, 1f)]
  public float PosY;

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
    this.SCShader = Shader.Find("CameraFilterPack/FX_Screens");
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
      this.material.SetFloat("_Value", this.Tiles);
      this.material.SetFloat("_Value2", this.Speed);
      this.material.SetFloat("_Value3", this.PosX);
      this.material.SetFloat("_Value4", this.PosY);
      this.material.SetColor("_color", this.color);
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
