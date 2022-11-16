// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_AAA_BloodOnScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Blood On Screen")]
public class CameraFilterPack_AAA_BloodOnScreen : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  [Range(0.02f, 1.6f)]
  public float Blood_On_Screen = 1f;
  public Color Blood_Color = Color.red;
  [Range(0.0f, 2f)]
  public float Blood_Intensify = 0.7f;
  [Range(0.0f, 2f)]
  public float Blood_Darkness = 0.5f;
  [Range(0.0f, 1f)]
  public float Blood_Distortion_Speed = 0.25f;
  [Range(0.0f, 1f)]
  public float Blood_Fade = 1f;
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
    this.Texture2 = Resources.Load("CameraFilterPack_AAA_BloodOnScreen1") as Texture2D;
    this.SCShader = Shader.Find("CameraFilterPack/AAA_BloodOnScreen");
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
      this.material.SetFloat("_Value", Mathf.Clamp(this.Blood_On_Screen, 0.02f, 1.6f));
      this.material.SetFloat("_Value2", Mathf.Clamp(this.Blood_Intensify, 0.0f, 2f));
      this.material.SetFloat("_Value3", Mathf.Clamp(this.Blood_Darkness, 0.0f, 2f));
      this.material.SetFloat("_Value4", Mathf.Clamp(this.Blood_Fade, 0.0f, 1f));
      this.material.SetFloat("_Value5", Mathf.Clamp(this.Blood_Distortion_Speed, 0.0f, 2f));
      this.material.SetColor("_Color2", this.Blood_Color);
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
