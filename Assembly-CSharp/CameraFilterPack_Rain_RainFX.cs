// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Rain_RainFX
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/New Rain FX")]
public class CameraFilterPack_Rain_RainFX : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(-8f, 8f)]
  public float Speed = 1f;
  [Range(0.0f, 1f)]
  public float Fade = 1f;
  [HideInInspector]
  public int Count;
  private Vector4[] Coord = new Vector4[4];
  public static Color ChangeColorRGB;
  private Texture2D Texture2;
  private Texture2D Texture3;

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
    this.Texture2 = Resources.Load("CameraFilterPack_RainFX_Anm2") as Texture2D;
    this.Texture3 = Resources.Load("CameraFilterPack_RainFX_Anm") as Texture2D;
    this.SCShader = Shader.Find("CameraFilterPack/RainFX");
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
      this.material.SetFloat("_Speed", this.Speed);
      this.material.SetVector("_ScreenResolution", new Vector4((float) sourceTexture.width, (float) sourceTexture.height, 0.0f, 0.0f));
      this.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
      AnimationCurve animationCurve1 = new AnimationCurve();
      AnimationCurve animationCurve2 = new AnimationCurve();
      animationCurve2.AddKey(0.0f, 0.01f);
      animationCurve2.AddKey(64f, 5f);
      animationCurve2.AddKey(128f, 80f);
      animationCurve2.AddKey((float) byte.MaxValue, (float) byte.MaxValue);
      animationCurve2.AddKey(300f, (float) byte.MaxValue);
      for (int index = 0; index < 4; ++index)
      {
        this.Coord[index].z += 0.5f;
        if ((double) this.Coord[index].w == -1.0)
          this.Coord[index].x = -5f;
        if ((double) this.Coord[index].z > 254.0)
          this.Coord[index] = new Vector4(Random.Range(0.0f, 0.9f), Random.Range(0.2f, 1.1f), 0.0f, (float) Random.Range(0, 3));
        this.material.SetVector("Coord" + (index + 1).ToString(), new Vector4(this.Coord[index].x, this.Coord[index].y, (float) (int) animationCurve2.Evaluate(this.Coord[index].z), this.Coord[index].w));
      }
      this.material.SetTexture("Texture2", (Texture) this.Texture2);
      this.material.SetTexture("Texture3", (Texture) this.Texture3);
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
