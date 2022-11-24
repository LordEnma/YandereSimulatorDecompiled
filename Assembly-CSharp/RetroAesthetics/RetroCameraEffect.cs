// Decompiled with JetBrains decompiler
// Type: RetroAesthetics.RetroCameraEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace RetroAesthetics
{
  [ExecuteInEditMode]
  [RequireComponent(typeof (Camera))]
  [ImageEffectAllowedInSceneView]
  public class RetroCameraEffect : MonoBehaviour
  {
    [Tooltip("If enabled, simulated TV noise is added to the output.")]
    public bool useStaticNoise = true;
    [Tooltip("Static noise texture. White regions represent noise.")]
    public Texture noiseTexture;
    [SerializeField]
    [Range(0.0f, 2.5f)]
    [Tooltip("Amount of TV noise to blend into the output.")]
    public float staticIntensity = 0.5f;
    [Space]
    public RetroCameraEffect.GlitchDirections randomGlitches = RetroCameraEffect.GlitchDirections.Vertical;
    [SerializeField]
    [Range(0.0f, 2.5f)]
    public float glitchIntensity = 1f;
    [SerializeField]
    [Range(0.0f, 100f)]
    public int glitchFrequency = 10;
    [Space]
    public bool useDisplacementWaves = true;
    [SerializeField]
    [Range(0.0f, 5f)]
    public float displacementAmplitude = 1f;
    [SerializeField]
    [Range(10f, 150f)]
    public float displacementFrequency = 100f;
    [SerializeField]
    [Range(0.0f, 5f)]
    public float displacementSpeed = 1f;
    [Space]
    public bool useChromaticAberration = true;
    [SerializeField]
    [Range(0.0f, 50f)]
    public float chromaticAberration = 10f;
    [Space]
    public bool useVignette = true;
    [SerializeField]
    [Range(0.0f, 1f)]
    public float vignette = 0.1f;
    [Space]
    public bool useBottomNoise = true;
    [Range(0.0f, 0.5f)]
    public float bottomHeight = 0.04f;
    [Range(0.0f, 3f)]
    public float bottomIntensity = 1f;
    public bool useBottomStretch = true;
    [Space]
    public bool useRadialDistortion = true;
    public float radialIntensity = 20f;
    public float radialCurvature = 4f;
    [Space]
    public float gammaScale = 1f;
    [Space]
    public bool useScanlines = true;
    public float scanlineSize = 512f;
    [Range(0.0f, 1f)]
    public float scanlineIntensity = 0.5f;
    [HideInInspector]
    public Material _material;
    private bool _isFading;
    private float _gammaTarget;
    private float _gammaDelta;
    private Action _callback;

    public virtual void Glitch(float amount = 1f)
    {
      Vector2 zero = Vector2.zero;
      if (this.randomGlitches == RetroCameraEffect.GlitchDirections.Horizontal || this.randomGlitches == RetroCameraEffect.GlitchDirections.Both)
        zero.x = UnityEngine.Random.Range(-0.25f * amount, 0.25f * amount);
      if (this.randomGlitches == RetroCameraEffect.GlitchDirections.Vertical || this.randomGlitches == RetroCameraEffect.GlitchDirections.Both)
        zero.y = UnityEngine.Random.Range(-0.25f * amount, 0.25f * amount);
      this._material.SetVector("_OffsetPos", (Vector4) zero);
      this._material.SetFloat("_ChromaticAberration", UnityEngine.Random.Range(this.chromaticAberration, (float) ((double) amount * (double) this.chromaticAberration * 2.5)));
    }

    public virtual void FadeIn(float speed = 1f, Action callback = null)
    {
      this._isFading = true;
      this.gammaScale = 0.0f;
      this._gammaTarget = 1f;
      this._gammaDelta = speed;
      this._callback = callback;
    }

    public virtual void FadeOut(float speed = 1f, Action callback = null)
    {
      this._isFading = true;
      this._gammaTarget = 0.0f;
      this._gammaDelta = -1f * speed;
      this._callback = callback;
    }

    private void Awake()
    {
      this._material = new Material(Shader.Find("Hidden/RetroCameraEffect"));
      this._material.SetTexture("_SecondaryTex", this.noiseTexture);
      this._material.SetFloat("_OffsetPosY", 0.0f);
      this._material.SetFloat("_DisplacementAmplitude", this.displacementAmplitude / 1000f);
      this._material.SetFloat("_DisplacementFrequency", this.displacementFrequency);
      this._material.SetFloat("_DisplacementSpeed", this.displacementSpeed);
    }

    private void Update()
    {
      if (!this._isFading)
        return;
      this.gammaScale += this._gammaDelta * Time.deltaTime;
      if (((double) this.gammaScale <= (double) this._gammaTarget || (double) this._gammaDelta <= 0.0) && ((double) this.gammaScale >= (double) this._gammaTarget || (double) this._gammaDelta >= 0.0))
        return;
      this.gammaScale = this._gammaTarget;
      this._isFading = false;
      if (this._callback != null)
        this._callback();
      this._callback = (Action) null;
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
      if ((UnityEngine.Object) this._material == (UnityEngine.Object) null)
        this.Awake();
      this._material.SetFloat("_OffsetNoiseX", UnityEngine.Random.Range(0.0f, 1f));
      this._material.SetFloat("_OffsetNoiseY", this._material.GetFloat("_OffsetNoiseY") + UnityEngine.Random.Range(-0.05f, 0.05f));
      if (this.randomGlitches != RetroCameraEffect.GlitchDirections.None)
      {
        if (UnityEngine.Random.Range(0, 15) == 0)
          this._material.SetFloat("_DisplacementAmplitude", UnityEngine.Random.Range(0.0f, (float) (10.0 * (double) this.displacementAmplitude / 1000.0)));
        else
          this._material.SetFloat("_DisplacementAmplitude", this.displacementAmplitude / 1000f);
      }
      Vector2 vector = (Vector2) this._material.GetVector("_OffsetPos");
      if ((double) vector.y > 0.0)
        vector.y -= UnityEngine.Random.Range(0.0f, vector.y);
      else if ((double) vector.y < 0.0)
        vector.y += UnityEngine.Random.Range(0.0f, -vector.y);
      if ((double) vector.x > 0.0)
        vector.x -= UnityEngine.Random.Range(0.0f, vector.x);
      else if ((double) vector.x < 0.0)
        vector.x += UnityEngine.Random.Range(0.0f, -vector.x);
      this._material.SetVector("_OffsetPos", (Vector4) vector);
      float num = this._material.GetFloat("_ChromaticAberration");
      if ((double) num > (double) this.chromaticAberration)
        this._material.SetFloat("_ChromaticAberration", num - 15f * Time.deltaTime);
      else if (this.randomGlitches != RetroCameraEffect.GlitchDirections.None && UnityEngine.Random.Range(0, 100 - this.glitchFrequency) == 0)
        this.Glitch(this.glitchIntensity);
      if (this.useStaticNoise)
        this._material.EnableKeyword("NOISE_ON");
      else
        this._material.DisableKeyword("NOISE_ON");
      if (this.useChromaticAberration)
        this._material.EnableKeyword("CHROMATIC_ON");
      else
        this._material.DisableKeyword("CHROMATIC_ON");
      if (this.useDisplacementWaves)
        this._material.EnableKeyword("DISPLACEMENT_ON");
      else
        this._material.DisableKeyword("DISPLACEMENT_ON");
      if (this.useVignette)
        this._material.EnableKeyword("VIGNETTE_ON");
      else
        this._material.DisableKeyword("VIGNETTE_ON");
      if (this.useBottomNoise)
        this._material.EnableKeyword("NOISE_BOTTOM_ON");
      else
        this._material.DisableKeyword("NOISE_BOTTOM_ON");
      if (this.useBottomStretch)
        this._material.EnableKeyword("BOTTOM_STRETCH_ON");
      else
        this._material.DisableKeyword("BOTTOM_STRETCH_ON");
      if (this.useRadialDistortion)
        this._material.EnableKeyword("RADIAL_DISTORTION_ON");
      else
        this._material.DisableKeyword("RADIAL_DISTORTION_ON");
      if (this.useScanlines)
        this._material.EnableKeyword("SCANLINES_ON");
      else
        this._material.DisableKeyword("SCANLINES_ON");
      this._material.SetFloat("_StaticIntensity", this.staticIntensity);
      this._material.SetFloat("_ChromaticAberration", this.chromaticAberration);
      this._material.SetFloat("_Vignette", this.vignette);
      this._material.SetFloat("_NoiseBottomHeight", this.bottomHeight);
      this._material.SetFloat("_NoiseBottomIntensity", this.bottomIntensity);
      this._material.SetFloat("_RadialDistortion", this.radialIntensity * 0.01f);
      this._material.SetFloat("_RadialDistortionCurvature", this.radialCurvature);
      this._material.SetFloat("_ScanlineSize", this.scanlineSize);
      this._material.SetFloat("_ScanlineIntensity", (float) ((1.0 - (double) this.scanlineIntensity) * 1.3400000333786011));
      this._material.SetFloat("_Gamma", this.gammaScale);
      Graphics.Blit((Texture) source, destination, this._material);
    }

    public enum GlitchDirections
    {
      None,
      Vertical,
      Horizontal,
      Both,
    }
  }
}
