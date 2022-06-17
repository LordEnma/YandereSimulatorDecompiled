// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_EXTRA_SHOWFPS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/EXTRA/SHOWFPS")]
public class CameraFilterPack_EXTRA_SHOWFPS : MonoBehaviour
{
  public Shader SCShader;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(8f, 42f)]
  public float Size = 12f;
  [Range(0.0f, 100f)]
  private int FPS = 1;
  [Range(0.0f, 10f)]
  private float Value3 = 1f;
  [Range(0.0f, 10f)]
  private float Value4 = 1f;
  private float accum;
  private int frames;
  public float frequency = 0.5f;

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
    this.FPS = 0;
    this.StartCoroutine(this.FPSX());
    this.SCShader = Shader.Find("CameraFilterPack/EXTRA_SHOWFPS");
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
      this.material.SetFloat("_Value", this.Size);
      this.material.SetFloat("_Value2", (float) this.FPS);
      this.material.SetFloat("_Value3", this.Value3);
      this.material.SetFloat("_Value4", this.Value4);
      this.material.SetVector("_ScreenResolution", new Vector4((float) sourceTexture.width, (float) sourceTexture.height, 0.0f, 0.0f));
      Graphics.Blit((Texture) sourceTexture, destTexture, this.material);
    }
    else
      Graphics.Blit((Texture) sourceTexture, destTexture);
  }

  private IEnumerator FPSX()
  {
    while (true)
    {
      this.FPS = (int) (this.accum / (float) this.frames);
      this.accum = 0.0f;
      this.frames = 0;
      yield return (object) new WaitForSeconds(this.frequency);
    }
  }

  private void Update()
  {
    this.accum += Time.timeScale / Time.deltaTime;
    ++this.frames;
  }

  private void OnDisable()
  {
    if (!(bool) (Object) this.SCMaterial)
      return;
    Object.DestroyImmediate((Object) this.SCMaterial);
  }
}
