using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000545 RID: 1349
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[ImageEffectAllowedInSceneView]
	public class RetroCameraEffect : MonoBehaviour
	{
		// Token: 0x06002268 RID: 8808 RVA: 0x001EAAE0 File Offset: 0x001E8CE0
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

		// Token: 0x06002269 RID: 8809 RVA: 0x001EAB8A File Offset: 0x001E8D8A
		public virtual void FadeIn(float speed = 1f, Action callback = null)
		{
			this._isFading = true;
			this.gammaScale = 0f;
			this._gammaTarget = 1f;
			this._gammaDelta = speed;
			this._callback = callback;
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x001EABB7 File Offset: 0x001E8DB7
		public virtual void FadeOut(float speed = 1f, Action callback = null)
		{
			this._isFading = true;
			this._gammaTarget = 0f;
			this._gammaDelta = -1f * speed;
			this._callback = callback;
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x001EABE0 File Offset: 0x001E8DE0
		private void Awake()
		{
			this._material = new Material(Shader.Find("Hidden/RetroCameraEffect"));
			this._material.SetTexture("_SecondaryTex", this.noiseTexture);
			this._material.SetFloat("_OffsetPosY", 0f);
			this._material.SetFloat("_DisplacementAmplitude", this.displacementAmplitude / 1000f);
			this._material.SetFloat("_DisplacementFrequency", this.displacementFrequency);
			this._material.SetFloat("_DisplacementSpeed", this.displacementSpeed);
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001EAC78 File Offset: 0x001E8E78
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

		// Token: 0x0600226D RID: 8813 RVA: 0x001EAD0C File Offset: 0x001E8F0C
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

		// Token: 0x04004A13 RID: 18963
		[Tooltip("If enabled, simulated TV noise is added to the output.")]
		public bool useStaticNoise = true;

		// Token: 0x04004A14 RID: 18964
		[Tooltip("Static noise texture. White regions represent noise.")]
		public Texture noiseTexture;

		// Token: 0x04004A15 RID: 18965
		[SerializeField]
		[Range(0f, 2.5f)]
		[Tooltip("Amount of TV noise to blend into the output.")]
		public float staticIntensity = 0.5f;

		// Token: 0x04004A16 RID: 18966
		[Space]
		public RetroCameraEffect.GlitchDirections randomGlitches = RetroCameraEffect.GlitchDirections.Vertical;

		// Token: 0x04004A17 RID: 18967
		[SerializeField]
		[Range(0f, 2.5f)]
		public float glitchIntensity = 1f;

		// Token: 0x04004A18 RID: 18968
		[SerializeField]
		[Range(0f, 100f)]
		public int glitchFrequency = 10;

		// Token: 0x04004A19 RID: 18969
		[Space]
		public bool useDisplacementWaves = true;

		// Token: 0x04004A1A RID: 18970
		[SerializeField]
		[Range(0f, 5f)]
		public float displacementAmplitude = 1f;

		// Token: 0x04004A1B RID: 18971
		[SerializeField]
		[Range(10f, 150f)]
		public float displacementFrequency = 100f;

		// Token: 0x04004A1C RID: 18972
		[SerializeField]
		[Range(0f, 5f)]
		public float displacementSpeed = 1f;

		// Token: 0x04004A1D RID: 18973
		[Space]
		public bool useChromaticAberration = true;

		// Token: 0x04004A1E RID: 18974
		[SerializeField]
		[Range(0f, 50f)]
		public float chromaticAberration = 10f;

		// Token: 0x04004A1F RID: 18975
		[Space]
		public bool useVignette = true;

		// Token: 0x04004A20 RID: 18976
		[SerializeField]
		[Range(0f, 1f)]
		public float vignette = 0.1f;

		// Token: 0x04004A21 RID: 18977
		[Space]
		public bool useBottomNoise = true;

		// Token: 0x04004A22 RID: 18978
		[Range(0f, 0.5f)]
		public float bottomHeight = 0.04f;

		// Token: 0x04004A23 RID: 18979
		[Range(0f, 3f)]
		public float bottomIntensity = 1f;

		// Token: 0x04004A24 RID: 18980
		public bool useBottomStretch = true;

		// Token: 0x04004A25 RID: 18981
		[Space]
		public bool useRadialDistortion = true;

		// Token: 0x04004A26 RID: 18982
		public float radialIntensity = 20f;

		// Token: 0x04004A27 RID: 18983
		public float radialCurvature = 4f;

		// Token: 0x04004A28 RID: 18984
		[Space]
		public float gammaScale = 1f;

		// Token: 0x04004A29 RID: 18985
		[Space]
		public bool useScanlines = true;

		// Token: 0x04004A2A RID: 18986
		public float scanlineSize = 512f;

		// Token: 0x04004A2B RID: 18987
		[Range(0f, 1f)]
		public float scanlineIntensity = 0.5f;

		// Token: 0x04004A2C RID: 18988
		[HideInInspector]
		public Material _material;

		// Token: 0x04004A2D RID: 18989
		private bool _isFading;

		// Token: 0x04004A2E RID: 18990
		private float _gammaTarget;

		// Token: 0x04004A2F RID: 18991
		private float _gammaDelta;

		// Token: 0x04004A30 RID: 18992
		private Action _callback;

		// Token: 0x0200068C RID: 1676
		public enum GlitchDirections
		{
			// Token: 0x04004F9D RID: 20381
			None,
			// Token: 0x04004F9E RID: 20382
			Vertical,
			// Token: 0x04004F9F RID: 20383
			Horizontal,
			// Token: 0x04004FA0 RID: 20384
			Both
		}
	}
}
