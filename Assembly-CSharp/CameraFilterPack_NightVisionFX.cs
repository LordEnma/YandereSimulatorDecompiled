// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_NightVisionFX
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision FX")]
public class CameraFilterPack_NightVisionFX : MonoBehaviour
{
  public Shader SCShader;
  public CameraFilterPack_NightVisionFX.preset Preset;
  private CameraFilterPack_NightVisionFX.preset PresetMemo;
  private float TimeX = 1f;
  private Material SCMaterial;
  [Range(0.0f, 1f)]
  public float OnOff;
  [Range(0.2f, 2f)]
  public float Greenness = 1f;
  [Range(0.0f, 1f)]
  public float Vignette = 1f;
  [Range(0.0f, 1f)]
  public float Vignette_Alpha = 1f;
  [Range(-10f, 10f)]
  public float Distortion = 1f;
  [Range(0.0f, 1f)]
  public float Noise = 1f;
  [Range(-2f, 1f)]
  public float Intensity = -1f;
  [Range(0.0f, 2f)]
  public float Light = 1f;
  [Range(0.0f, 1f)]
  public float Light2 = 1f;
  [Range(0.0f, 2f)]
  public float Line = 1f;
  [Range(-2f, 2f)]
  public float Color_R;
  [Range(-2f, 2f)]
  public float Color_G;
  [Range(-2f, 2f)]
  public float Color_B;
  [Range(0.0f, 1f)]
  public float _Binocular_Size = 0.499f;
  [Range(0.0f, 1f)]
  public float _Binocular_Smooth = 0.113f;
  [Range(0.0f, 1f)]
  public float _Binocular_Dist = 0.286f;

  private Material material
  {
    get
    {
      if ((UnityEngine.Object) this.SCMaterial == (UnityEngine.Object) null)
      {
        this.SCMaterial = new Material(this.SCShader);
        this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
      }
      return this.SCMaterial;
    }
  }

  private void Start()
  {
    this.SCShader = Shader.Find("CameraFilterPack/NightVisionFX");
    if (SystemInfo.supportsImageEffects)
      return;
    this.enabled = false;
  }

  private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
  {
    if ((UnityEngine.Object) this.SCShader != (UnityEngine.Object) null)
    {
      this.TimeX += Time.deltaTime;
      if ((double) this.TimeX > 100.0)
        this.TimeX = 0.0f;
      this.material.SetFloat("_TimeX", this.TimeX);
      this.material.SetFloat("_OnOff", this.OnOff);
      this.material.SetFloat("_Greenness", this.Greenness);
      this.material.SetFloat("_Vignette", this.Vignette);
      this.material.SetFloat("_Vignette_Alpha", this.Vignette_Alpha);
      this.material.SetFloat("_Distortion", this.Distortion);
      this.material.SetFloat("_Noise", this.Noise);
      this.material.SetFloat("_Intensity", this.Intensity);
      this.material.SetFloat("_Light", this.Light);
      this.material.SetFloat("_Light2", this.Light2);
      this.material.SetFloat("_Line", this.Line);
      this.material.SetFloat("_Color_R", this.Color_R);
      this.material.SetFloat("_Color_G", this.Color_G);
      this.material.SetFloat("_Color_B", this.Color_B);
      this.material.SetFloat("_Size", this._Binocular_Size);
      this.material.SetFloat("_Dist", this._Binocular_Dist);
      this.material.SetFloat("_Smooth", this._Binocular_Smooth);
      this.material.SetVector("_ScreenResolution", (Vector4) new Vector2((float) Screen.width, (float) Screen.height));
      Graphics.Blit((Texture) sourceTexture, destTexture, this.material);
    }
    else
      Graphics.Blit((Texture) sourceTexture, destTexture);
  }

  private void Update()
  {
    if (this.PresetMemo == this.Preset)
      return;
    this.PresetMemo = this.Preset;
    float[] numArray1 = new float[12]
    {
      0.757f,
      0.098f,
      0.458f,
      -2.49f,
      0.559f,
      -0.298f,
      1.202f,
      0.515f,
      1f,
      0.0f,
      0.0f,
      0.0f
    };
    float[] numArray2 = new float[12]
    {
      0.2f,
      0.202f,
      0.68f,
      -1.49f,
      0.084f,
      -0.019f,
      2f,
      0.166f,
      550f * (float) Math.PI / 887f,
      -0.1f,
      0.15f,
      -0.07f
    };
    float[] numArray3 = new float[12]
    {
      1.45f,
      0.01f,
      0.112f,
      -0.07f,
      0.111f,
      -0.077f,
      0.071f,
      0.0f,
      0.245f,
      0.0f,
      0.0f,
      0.0f
    };
    float[] numArray4 = new float[12]
    {
      0.779f,
      0.185f,
      0.706f,
      1.21f,
      0.24f,
      0.138f,
      2f,
      0.07f,
      1.224f,
      -0.21f,
      -0.34f,
      0.0f
    };
    float[] numArray5 = new float[12]
    {
      0.2f,
      0.028f,
      0.706f,
      1.21f,
      0.397f,
      -0.24f,
      2f,
      0.298f,
      1.224f,
      -0.08f,
      0.48f,
      -0.57f
    };
    float[] numArray6 = new float[12]
    {
      0.2f,
      0.159f,
      0.622f,
      -2.28f,
      0.409f,
      -0.24f,
      0.166f,
      0.028f,
      2f,
      -0.08f,
      0.22f,
      0.57f
    };
    float[] numArray7 = new float[12]
    {
      2f,
      0.054f,
      1f,
      -2.28f,
      0.409f,
      -1f,
      2f,
      0.187f,
      0.241f,
      0.0f,
      1.58f,
      0.21f
    };
    float[] numArray8 = new float[12]
    {
      2f,
      0.054f,
      1f,
      1.28f,
      0.409f,
      -1f,
      0.41f,
      0.656f,
      0.427f,
      0.95f,
      -0.35f,
      1.41f
    };
    float[] numArray9 = new float[12]
    {
      2f,
      0.281f,
      0.156f,
      1.85f,
      0.709f,
      -1f,
      0.41f,
      0.109f,
      0.34f,
      0.95f,
      0.36f,
      -0.14f
    };
    float[] numArray10 = new float[12]
    {
      0.905f,
      0.281f,
      0.156f,
      1.85f,
      0.558f,
      -275f * (float) Math.PI / 887f,
      1.639f,
      0.252f,
      1.074f,
      0.46f,
      0.95f,
      0.58f
    };
    float[] numArray11 = new float[12];
    if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_FX)
      numArray11 = numArray1;
    if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Classic)
      numArray11 = numArray2;
    if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Full)
      numArray11 = numArray3;
    if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Dark)
      numArray11 = numArray4;
    if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Sharp)
      numArray11 = numArray5;
    if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_BlueSky)
      numArray11 = numArray6;
    if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Low_Light)
      numArray11 = numArray7;
    if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Pinky)
      numArray11 = numArray8;
    if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_RedBurn)
      numArray11 = numArray9;
    if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_PurpleShadow)
      numArray11 = numArray10;
    if (this.Preset == CameraFilterPack_NightVisionFX.preset.Night_Vision_Personalized)
      return;
    this.Greenness = numArray11[0];
    this.Vignette = numArray11[1];
    this.Vignette_Alpha = numArray11[2];
    this.Distortion = numArray11[3];
    this.Noise = numArray11[4];
    this.Intensity = numArray11[5];
    this.Light = numArray11[6];
    this.Light2 = numArray11[7];
    this.Line = numArray11[8];
    this.Color_R = numArray11[9];
    this.Color_G = numArray11[10];
    this.Color_B = numArray11[11];
  }

  private void OnDisable()
  {
    if (!(bool) (UnityEngine.Object) this.SCMaterial)
      return;
    UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.SCMaterial);
  }

  public enum preset
  {
    Night_Vision_Personalized = -1, // 0xFFFFFFFF
    Night_Vision_FX = 0,
    Night_Vision_Classic = 1,
    Night_Vision_Full = 2,
    Night_Vision_Dark = 3,
    Night_Vision_Sharp = 4,
    Night_Vision_BlueSky = 5,
    Night_Vision_Low_Light = 6,
    Night_Vision_Pinky = 7,
    Night_Vision_RedBurn = 8,
    Night_Vision_PurpleShadow = 9,
  }
}
