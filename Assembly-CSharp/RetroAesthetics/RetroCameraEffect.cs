using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x0200054A RID: 1354
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[ImageEffectAllowedInSceneView]
	public class RetroCameraEffect : MonoBehaviour
	{
		// Token: 0x06002292 RID: 8850 RVA: 0x001EEC30 File Offset: 0x001ECE30
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

		// Token: 0x06002293 RID: 8851 RVA: 0x001EECDA File Offset: 0x001ECEDA
		public virtual void FadeIn(float speed = 1f, Action callback = null)
		{
			this._isFading = true;
			this.gammaScale = 0f;
			this._gammaTarget = 1f;
			this._gammaDelta = speed;
			this._callback = callback;
		}

		// Token: 0x06002294 RID: 8852 RVA: 0x001EED07 File Offset: 0x001ECF07
		public virtual void FadeOut(float speed = 1f, Action callback = null)
		{
			this._isFading = true;
			this._gammaTarget = 0f;
			this._gammaDelta = -1f * speed;
			this._callback = callback;
		}

		// Token: 0x06002295 RID: 8853 RVA: 0x001EED30 File Offset: 0x001ECF30
		private void Awake()
		{
			this._material = new Material(Shader.Find("Hidden/RetroCameraEffect"));
			this._material.SetTexture("_SecondaryTex", this.noiseTexture);
			this._material.SetFloat("_OffsetPosY", 0f);
			this._material.SetFloat("_DisplacementAmplitude", this.displacementAmplitude / 1000f);
			this._material.SetFloat("_DisplacementFrequency", this.displacementFrequency);
			this._material.SetFloat("_DisplacementSpeed", this.displacementSpeed);
		}

		// Token: 0x06002296 RID: 8854 RVA: 0x001EEDC8 File Offset: 0x001ECFC8
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

		// Token: 0x06002297 RID: 8855 RVA: 0x001EEE5C File Offset: 0x001ED05C
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

		// Token: 0x04004A8A RID: 19082
		[Tooltip("If enabled, simulated TV noise is added to the output.")]
		public bool useStaticNoise = true;

		// Token: 0x04004A8B RID: 19083
		[Tooltip("Static noise texture. White regions represent noise.")]
		public Texture noiseTexture;

		// Token: 0x04004A8C RID: 19084
		[SerializeField]
		[Range(0f, 2.5f)]
		[Tooltip("Amount of TV noise to blend into the output.")]
		public float staticIntensity = 0.5f;

		// Token: 0x04004A8D RID: 19085
		[Space]
		public RetroCameraEffect.GlitchDirections randomGlitches = RetroCameraEffect.GlitchDirections.Vertical;

		// Token: 0x04004A8E RID: 19086
		[SerializeField]
		[Range(0f, 2.5f)]
		public float glitchIntensity = 1f;

		// Token: 0x04004A8F RID: 19087
		[SerializeField]
		[Range(0f, 100f)]
		public int glitchFrequency = 10;

		// Token: 0x04004A90 RID: 19088
		[Space]
		public bool useDisplacementWaves = true;

		// Token: 0x04004A91 RID: 19089
		[SerializeField]
		[Range(0f, 5f)]
		public float displacementAmplitude = 1f;

		// Token: 0x04004A92 RID: 19090
		[SerializeField]
		[Range(10f, 150f)]
		public float displacementFrequency = 100f;

		// Token: 0x04004A93 RID: 19091
		[SerializeField]
		[Range(0f, 5f)]
		public float displacementSpeed = 1f;

		// Token: 0x04004A94 RID: 19092
		[Space]
		public bool useChromaticAberration = true;

		// Token: 0x04004A95 RID: 19093
		[SerializeField]
		[Range(0f, 50f)]
		public float chromaticAberration = 10f;

		// Token: 0x04004A96 RID: 19094
		[Space]
		public bool useVignette = true;

		// Token: 0x04004A97 RID: 19095
		[SerializeField]
		[Range(0f, 1f)]
		public float vignette = 0.1f;

		// Token: 0x04004A98 RID: 19096
		[Space]
		public bool useBottomNoise = true;

		// Token: 0x04004A99 RID: 19097
		[Range(0f, 0.5f)]
		public float bottomHeight = 0.04f;

		// Token: 0x04004A9A RID: 19098
		[Range(0f, 3f)]
		public float bottomIntensity = 1f;

		// Token: 0x04004A9B RID: 19099
		public bool useBottomStretch = true;

		// Token: 0x04004A9C RID: 19100
		[Space]
		public bool useRadialDistortion = true;

		// Token: 0x04004A9D RID: 19101
		public float radialIntensity = 20f;

		// Token: 0x04004A9E RID: 19102
		public float radialCurvature = 4f;

		// Token: 0x04004A9F RID: 19103
		[Space]
		public float gammaScale = 1f;

		// Token: 0x04004AA0 RID: 19104
		[Space]
		public bool useScanlines = true;

		// Token: 0x04004AA1 RID: 19105
		public float scanlineSize = 512f;

		// Token: 0x04004AA2 RID: 19106
		[Range(0f, 1f)]
		public float scanlineIntensity = 0.5f;

		// Token: 0x04004AA3 RID: 19107
		[HideInInspector]
		public Material _material;

		// Token: 0x04004AA4 RID: 19108
		private bool _isFading;

		// Token: 0x04004AA5 RID: 19109
		private float _gammaTarget;

		// Token: 0x04004AA6 RID: 19110
		private float _gammaDelta;

		// Token: 0x04004AA7 RID: 19111
		private Action _callback;

		// Token: 0x0200068C RID: 1676
		public enum GlitchDirections
		{
			// Token: 0x04004FF2 RID: 20466
			None,
			// Token: 0x04004FF3 RID: 20467
			Vertical,
			// Token: 0x04004FF4 RID: 20468
			Horizontal,
			// Token: 0x04004FF5 RID: 20469
			Both
		}
	}
}
