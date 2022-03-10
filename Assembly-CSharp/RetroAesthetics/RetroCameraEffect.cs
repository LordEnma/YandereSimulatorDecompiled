using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x0200054D RID: 1357
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[ImageEffectAllowedInSceneView]
	public class RetroCameraEffect : MonoBehaviour
	{
		// Token: 0x060022A8 RID: 8872 RVA: 0x001F069C File Offset: 0x001EE89C
		public virtual void Glitch(float amount = 1f)
		{
			Vector2 zero = Vector2.zero;
			if (this.randomGlitches == RetroCameraEffect.GlitchDirections.Horizontal || this.randomGlitches == RetroCameraEffect.GlitchDirections.Both)
			{
				zero.x = UnityEngine.Random.Range(-0.25f * amount, 0.25f * amount);
			}
			if (this.randomGlitches == RetroCameraEffect.GlitchDirections.Vertical || this.randomGlitches == RetroCameraEffect.GlitchDirections.Both)
			{
				zero.y = UnityEngine.Random.Range(-0.25f * amount, 0.25f * amount);
			}
			this._material.SetVector("_OffsetPos", zero);
			this._material.SetFloat("_ChromaticAberration", UnityEngine.Random.Range(this.chromaticAberration, amount * this.chromaticAberration * 2.5f));
		}

		// Token: 0x060022A9 RID: 8873 RVA: 0x001F0746 File Offset: 0x001EE946
		public virtual void FadeIn(float speed = 1f, Action callback = null)
		{
			this._isFading = true;
			this.gammaScale = 0f;
			this._gammaTarget = 1f;
			this._gammaDelta = speed;
			this._callback = callback;
		}

		// Token: 0x060022AA RID: 8874 RVA: 0x001F0773 File Offset: 0x001EE973
		public virtual void FadeOut(float speed = 1f, Action callback = null)
		{
			this._isFading = true;
			this._gammaTarget = 0f;
			this._gammaDelta = -1f * speed;
			this._callback = callback;
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x001F079C File Offset: 0x001EE99C
		private void Awake()
		{
			this._material = new Material(Shader.Find("Hidden/RetroCameraEffect"));
			this._material.SetTexture("_SecondaryTex", this.noiseTexture);
			this._material.SetFloat("_OffsetPosY", 0f);
			this._material.SetFloat("_DisplacementAmplitude", this.displacementAmplitude / 1000f);
			this._material.SetFloat("_DisplacementFrequency", this.displacementFrequency);
			this._material.SetFloat("_DisplacementSpeed", this.displacementSpeed);
		}

		// Token: 0x060022AC RID: 8876 RVA: 0x001F0834 File Offset: 0x001EEA34
		private void Update()
		{
			if (this._isFading)
			{
				this.gammaScale += this._gammaDelta * Time.deltaTime;
				if ((this.gammaScale > this._gammaTarget && this._gammaDelta > 0f) || (this.gammaScale < this._gammaTarget && this._gammaDelta < 0f))
				{
					this.gammaScale = this._gammaTarget;
					this._isFading = false;
					if (this._callback != null)
					{
						this._callback();
					}
					this._callback = null;
				}
			}
		}

		// Token: 0x060022AD RID: 8877 RVA: 0x001F08C8 File Offset: 0x001EEAC8
		public void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (this._material == null)
			{
				this.Awake();
			}
			this._material.SetFloat("_OffsetNoiseX", UnityEngine.Random.Range(0f, 1f));
			float @float = this._material.GetFloat("_OffsetNoiseY");
			this._material.SetFloat("_OffsetNoiseY", @float + UnityEngine.Random.Range(-0.05f, 0.05f));
			if (this.randomGlitches != RetroCameraEffect.GlitchDirections.None)
			{
				if (UnityEngine.Random.Range(0, 15) == 0)
				{
					this._material.SetFloat("_DisplacementAmplitude", UnityEngine.Random.Range(0f, 10f * this.displacementAmplitude / 1000f));
				}
				else
				{
					this._material.SetFloat("_DisplacementAmplitude", this.displacementAmplitude / 1000f);
				}
			}
			Vector2 vector = this._material.GetVector("_OffsetPos");
			if (vector.y > 0f)
			{
				vector.y -= UnityEngine.Random.Range(0f, vector.y);
			}
			else if (vector.y < 0f)
			{
				vector.y += UnityEngine.Random.Range(0f, -vector.y);
			}
			if (vector.x > 0f)
			{
				vector.x -= UnityEngine.Random.Range(0f, vector.x);
			}
			else if (vector.x < 0f)
			{
				vector.x += UnityEngine.Random.Range(0f, -vector.x);
			}
			this._material.SetVector("_OffsetPos", vector);
			float float2 = this._material.GetFloat("_ChromaticAberration");
			if (float2 > this.chromaticAberration)
			{
				this._material.SetFloat("_ChromaticAberration", float2 - 15f * Time.deltaTime);
			}
			else if (this.randomGlitches != RetroCameraEffect.GlitchDirections.None && UnityEngine.Random.Range(0, 100 - this.glitchFrequency) == 0)
			{
				this.Glitch(this.glitchIntensity);
			}
			if (this.useStaticNoise)
			{
				this._material.EnableKeyword("NOISE_ON");
			}
			else
			{
				this._material.DisableKeyword("NOISE_ON");
			}
			if (this.useChromaticAberration)
			{
				this._material.EnableKeyword("CHROMATIC_ON");
			}
			else
			{
				this._material.DisableKeyword("CHROMATIC_ON");
			}
			if (this.useDisplacementWaves)
			{
				this._material.EnableKeyword("DISPLACEMENT_ON");
			}
			else
			{
				this._material.DisableKeyword("DISPLACEMENT_ON");
			}
			if (this.useVignette)
			{
				this._material.EnableKeyword("VIGNETTE_ON");
			}
			else
			{
				this._material.DisableKeyword("VIGNETTE_ON");
			}
			if (this.useBottomNoise)
			{
				this._material.EnableKeyword("NOISE_BOTTOM_ON");
			}
			else
			{
				this._material.DisableKeyword("NOISE_BOTTOM_ON");
			}
			if (this.useBottomStretch)
			{
				this._material.EnableKeyword("BOTTOM_STRETCH_ON");
			}
			else
			{
				this._material.DisableKeyword("BOTTOM_STRETCH_ON");
			}
			if (this.useRadialDistortion)
			{
				this._material.EnableKeyword("RADIAL_DISTORTION_ON");
			}
			else
			{
				this._material.DisableKeyword("RADIAL_DISTORTION_ON");
			}
			if (this.useScanlines)
			{
				this._material.EnableKeyword("SCANLINES_ON");
			}
			else
			{
				this._material.DisableKeyword("SCANLINES_ON");
			}
			this._material.SetFloat("_StaticIntensity", this.staticIntensity);
			this._material.SetFloat("_ChromaticAberration", this.chromaticAberration);
			this._material.SetFloat("_Vignette", this.vignette);
			this._material.SetFloat("_NoiseBottomHeight", this.bottomHeight);
			this._material.SetFloat("_NoiseBottomIntensity", this.bottomIntensity);
			this._material.SetFloat("_RadialDistortion", this.radialIntensity * 0.01f);
			this._material.SetFloat("_RadialDistortionCurvature", this.radialCurvature);
			this._material.SetFloat("_ScanlineSize", this.scanlineSize);
			this._material.SetFloat("_ScanlineIntensity", (1f - this.scanlineIntensity) * 1.34f);
			this._material.SetFloat("_Gamma", this.gammaScale);
			Graphics.Blit(source, destination, this._material);
		}

		// Token: 0x04004AC0 RID: 19136
		[Tooltip("If enabled, simulated TV noise is added to the output.")]
		public bool useStaticNoise = true;

		// Token: 0x04004AC1 RID: 19137
		[Tooltip("Static noise texture. White regions represent noise.")]
		public Texture noiseTexture;

		// Token: 0x04004AC2 RID: 19138
		[SerializeField]
		[Range(0f, 2.5f)]
		[Tooltip("Amount of TV noise to blend into the output.")]
		public float staticIntensity = 0.5f;

		// Token: 0x04004AC3 RID: 19139
		[Space]
		public RetroCameraEffect.GlitchDirections randomGlitches = RetroCameraEffect.GlitchDirections.Vertical;

		// Token: 0x04004AC4 RID: 19140
		[SerializeField]
		[Range(0f, 2.5f)]
		public float glitchIntensity = 1f;

		// Token: 0x04004AC5 RID: 19141
		[SerializeField]
		[Range(0f, 100f)]
		public int glitchFrequency = 10;

		// Token: 0x04004AC6 RID: 19142
		[Space]
		public bool useDisplacementWaves = true;

		// Token: 0x04004AC7 RID: 19143
		[SerializeField]
		[Range(0f, 5f)]
		public float displacementAmplitude = 1f;

		// Token: 0x04004AC8 RID: 19144
		[SerializeField]
		[Range(10f, 150f)]
		public float displacementFrequency = 100f;

		// Token: 0x04004AC9 RID: 19145
		[SerializeField]
		[Range(0f, 5f)]
		public float displacementSpeed = 1f;

		// Token: 0x04004ACA RID: 19146
		[Space]
		public bool useChromaticAberration = true;

		// Token: 0x04004ACB RID: 19147
		[SerializeField]
		[Range(0f, 50f)]
		public float chromaticAberration = 10f;

		// Token: 0x04004ACC RID: 19148
		[Space]
		public bool useVignette = true;

		// Token: 0x04004ACD RID: 19149
		[SerializeField]
		[Range(0f, 1f)]
		public float vignette = 0.1f;

		// Token: 0x04004ACE RID: 19150
		[Space]
		public bool useBottomNoise = true;

		// Token: 0x04004ACF RID: 19151
		[Range(0f, 0.5f)]
		public float bottomHeight = 0.04f;

		// Token: 0x04004AD0 RID: 19152
		[Range(0f, 3f)]
		public float bottomIntensity = 1f;

		// Token: 0x04004AD1 RID: 19153
		public bool useBottomStretch = true;

		// Token: 0x04004AD2 RID: 19154
		[Space]
		public bool useRadialDistortion = true;

		// Token: 0x04004AD3 RID: 19155
		public float radialIntensity = 20f;

		// Token: 0x04004AD4 RID: 19156
		public float radialCurvature = 4f;

		// Token: 0x04004AD5 RID: 19157
		[Space]
		public float gammaScale = 1f;

		// Token: 0x04004AD6 RID: 19158
		[Space]
		public bool useScanlines = true;

		// Token: 0x04004AD7 RID: 19159
		public float scanlineSize = 512f;

		// Token: 0x04004AD8 RID: 19160
		[Range(0f, 1f)]
		public float scanlineIntensity = 0.5f;

		// Token: 0x04004AD9 RID: 19161
		[HideInInspector]
		public Material _material;

		// Token: 0x04004ADA RID: 19162
		private bool _isFading;

		// Token: 0x04004ADB RID: 19163
		private float _gammaTarget;

		// Token: 0x04004ADC RID: 19164
		private float _gammaDelta;

		// Token: 0x04004ADD RID: 19165
		private Action _callback;

		// Token: 0x02000691 RID: 1681
		public enum GlitchDirections
		{
			// Token: 0x0400502D RID: 20525
			None,
			// Token: 0x0400502E RID: 20526
			Vertical,
			// Token: 0x0400502F RID: 20527
			Horizontal,
			// Token: 0x04005030 RID: 20528
			Both
		}
	}
}
