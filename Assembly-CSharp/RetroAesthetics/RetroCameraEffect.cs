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
		// Token: 0x06002289 RID: 8841 RVA: 0x001EDE74 File Offset: 0x001EC074
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

		// Token: 0x0600228A RID: 8842 RVA: 0x001EDF1E File Offset: 0x001EC11E
		public virtual void FadeIn(float speed = 1f, Action callback = null)
		{
			this._isFading = true;
			this.gammaScale = 0f;
			this._gammaTarget = 1f;
			this._gammaDelta = speed;
			this._callback = callback;
		}

		// Token: 0x0600228B RID: 8843 RVA: 0x001EDF4B File Offset: 0x001EC14B
		public virtual void FadeOut(float speed = 1f, Action callback = null)
		{
			this._isFading = true;
			this._gammaTarget = 0f;
			this._gammaDelta = -1f * speed;
			this._callback = callback;
		}

		// Token: 0x0600228C RID: 8844 RVA: 0x001EDF74 File Offset: 0x001EC174
		private void Awake()
		{
			this._material = new Material(Shader.Find("Hidden/RetroCameraEffect"));
			this._material.SetTexture("_SecondaryTex", this.noiseTexture);
			this._material.SetFloat("_OffsetPosY", 0f);
			this._material.SetFloat("_DisplacementAmplitude", this.displacementAmplitude / 1000f);
			this._material.SetFloat("_DisplacementFrequency", this.displacementFrequency);
			this._material.SetFloat("_DisplacementSpeed", this.displacementSpeed);
		}

		// Token: 0x0600228D RID: 8845 RVA: 0x001EE00C File Offset: 0x001EC20C
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

		// Token: 0x0600228E RID: 8846 RVA: 0x001EE0A0 File Offset: 0x001EC2A0
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

		// Token: 0x04004A76 RID: 19062
		[Tooltip("If enabled, simulated TV noise is added to the output.")]
		public bool useStaticNoise = true;

		// Token: 0x04004A77 RID: 19063
		[Tooltip("Static noise texture. White regions represent noise.")]
		public Texture noiseTexture;

		// Token: 0x04004A78 RID: 19064
		[SerializeField]
		[Range(0f, 2.5f)]
		[Tooltip("Amount of TV noise to blend into the output.")]
		public float staticIntensity = 0.5f;

		// Token: 0x04004A79 RID: 19065
		[Space]
		public RetroCameraEffect.GlitchDirections randomGlitches = RetroCameraEffect.GlitchDirections.Vertical;

		// Token: 0x04004A7A RID: 19066
		[SerializeField]
		[Range(0f, 2.5f)]
		public float glitchIntensity = 1f;

		// Token: 0x04004A7B RID: 19067
		[SerializeField]
		[Range(0f, 100f)]
		public int glitchFrequency = 10;

		// Token: 0x04004A7C RID: 19068
		[Space]
		public bool useDisplacementWaves = true;

		// Token: 0x04004A7D RID: 19069
		[SerializeField]
		[Range(0f, 5f)]
		public float displacementAmplitude = 1f;

		// Token: 0x04004A7E RID: 19070
		[SerializeField]
		[Range(10f, 150f)]
		public float displacementFrequency = 100f;

		// Token: 0x04004A7F RID: 19071
		[SerializeField]
		[Range(0f, 5f)]
		public float displacementSpeed = 1f;

		// Token: 0x04004A80 RID: 19072
		[Space]
		public bool useChromaticAberration = true;

		// Token: 0x04004A81 RID: 19073
		[SerializeField]
		[Range(0f, 50f)]
		public float chromaticAberration = 10f;

		// Token: 0x04004A82 RID: 19074
		[Space]
		public bool useVignette = true;

		// Token: 0x04004A83 RID: 19075
		[SerializeField]
		[Range(0f, 1f)]
		public float vignette = 0.1f;

		// Token: 0x04004A84 RID: 19076
		[Space]
		public bool useBottomNoise = true;

		// Token: 0x04004A85 RID: 19077
		[Range(0f, 0.5f)]
		public float bottomHeight = 0.04f;

		// Token: 0x04004A86 RID: 19078
		[Range(0f, 3f)]
		public float bottomIntensity = 1f;

		// Token: 0x04004A87 RID: 19079
		public bool useBottomStretch = true;

		// Token: 0x04004A88 RID: 19080
		[Space]
		public bool useRadialDistortion = true;

		// Token: 0x04004A89 RID: 19081
		public float radialIntensity = 20f;

		// Token: 0x04004A8A RID: 19082
		public float radialCurvature = 4f;

		// Token: 0x04004A8B RID: 19083
		[Space]
		public float gammaScale = 1f;

		// Token: 0x04004A8C RID: 19084
		[Space]
		public bool useScanlines = true;

		// Token: 0x04004A8D RID: 19085
		public float scanlineSize = 512f;

		// Token: 0x04004A8E RID: 19086
		[Range(0f, 1f)]
		public float scanlineIntensity = 0.5f;

		// Token: 0x04004A8F RID: 19087
		[HideInInspector]
		public Material _material;

		// Token: 0x04004A90 RID: 19088
		private bool _isFading;

		// Token: 0x04004A91 RID: 19089
		private float _gammaTarget;

		// Token: 0x04004A92 RID: 19090
		private float _gammaDelta;

		// Token: 0x04004A93 RID: 19091
		private Action _callback;

		// Token: 0x02000692 RID: 1682
		public enum GlitchDirections
		{
			// Token: 0x0400500C RID: 20492
			None,
			// Token: 0x0400500D RID: 20493
			Vertical,
			// Token: 0x0400500E RID: 20494
			Horizontal,
			// Token: 0x0400500F RID: 20495
			Both
		}
	}
}
