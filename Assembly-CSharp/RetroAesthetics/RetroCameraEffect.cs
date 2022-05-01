using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000558 RID: 1368
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[ImageEffectAllowedInSceneView]
	public class RetroCameraEffect : MonoBehaviour
	{
		// Token: 0x060022E8 RID: 8936 RVA: 0x001F628C File Offset: 0x001F448C
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

		// Token: 0x060022E9 RID: 8937 RVA: 0x001F6336 File Offset: 0x001F4536
		public virtual void FadeIn(float speed = 1f, Action callback = null)
		{
			this._isFading = true;
			this.gammaScale = 0f;
			this._gammaTarget = 1f;
			this._gammaDelta = speed;
			this._callback = callback;
		}

		// Token: 0x060022EA RID: 8938 RVA: 0x001F6363 File Offset: 0x001F4563
		public virtual void FadeOut(float speed = 1f, Action callback = null)
		{
			this._isFading = true;
			this._gammaTarget = 0f;
			this._gammaDelta = -1f * speed;
			this._callback = callback;
		}

		// Token: 0x060022EB RID: 8939 RVA: 0x001F638C File Offset: 0x001F458C
		private void Awake()
		{
			this._material = new Material(Shader.Find("Hidden/RetroCameraEffect"));
			this._material.SetTexture("_SecondaryTex", this.noiseTexture);
			this._material.SetFloat("_OffsetPosY", 0f);
			this._material.SetFloat("_DisplacementAmplitude", this.displacementAmplitude / 1000f);
			this._material.SetFloat("_DisplacementFrequency", this.displacementFrequency);
			this._material.SetFloat("_DisplacementSpeed", this.displacementSpeed);
		}

		// Token: 0x060022EC RID: 8940 RVA: 0x001F6424 File Offset: 0x001F4624
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

		// Token: 0x060022ED RID: 8941 RVA: 0x001F64B8 File Offset: 0x001F46B8
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

		// Token: 0x04004B7D RID: 19325
		[Tooltip("If enabled, simulated TV noise is added to the output.")]
		public bool useStaticNoise = true;

		// Token: 0x04004B7E RID: 19326
		[Tooltip("Static noise texture. White regions represent noise.")]
		public Texture noiseTexture;

		// Token: 0x04004B7F RID: 19327
		[SerializeField]
		[Range(0f, 2.5f)]
		[Tooltip("Amount of TV noise to blend into the output.")]
		public float staticIntensity = 0.5f;

		// Token: 0x04004B80 RID: 19328
		[Space]
		public RetroCameraEffect.GlitchDirections randomGlitches = RetroCameraEffect.GlitchDirections.Vertical;

		// Token: 0x04004B81 RID: 19329
		[SerializeField]
		[Range(0f, 2.5f)]
		public float glitchIntensity = 1f;

		// Token: 0x04004B82 RID: 19330
		[SerializeField]
		[Range(0f, 100f)]
		public int glitchFrequency = 10;

		// Token: 0x04004B83 RID: 19331
		[Space]
		public bool useDisplacementWaves = true;

		// Token: 0x04004B84 RID: 19332
		[SerializeField]
		[Range(0f, 5f)]
		public float displacementAmplitude = 1f;

		// Token: 0x04004B85 RID: 19333
		[SerializeField]
		[Range(10f, 150f)]
		public float displacementFrequency = 100f;

		// Token: 0x04004B86 RID: 19334
		[SerializeField]
		[Range(0f, 5f)]
		public float displacementSpeed = 1f;

		// Token: 0x04004B87 RID: 19335
		[Space]
		public bool useChromaticAberration = true;

		// Token: 0x04004B88 RID: 19336
		[SerializeField]
		[Range(0f, 50f)]
		public float chromaticAberration = 10f;

		// Token: 0x04004B89 RID: 19337
		[Space]
		public bool useVignette = true;

		// Token: 0x04004B8A RID: 19338
		[SerializeField]
		[Range(0f, 1f)]
		public float vignette = 0.1f;

		// Token: 0x04004B8B RID: 19339
		[Space]
		public bool useBottomNoise = true;

		// Token: 0x04004B8C RID: 19340
		[Range(0f, 0.5f)]
		public float bottomHeight = 0.04f;

		// Token: 0x04004B8D RID: 19341
		[Range(0f, 3f)]
		public float bottomIntensity = 1f;

		// Token: 0x04004B8E RID: 19342
		public bool useBottomStretch = true;

		// Token: 0x04004B8F RID: 19343
		[Space]
		public bool useRadialDistortion = true;

		// Token: 0x04004B90 RID: 19344
		public float radialIntensity = 20f;

		// Token: 0x04004B91 RID: 19345
		public float radialCurvature = 4f;

		// Token: 0x04004B92 RID: 19346
		[Space]
		public float gammaScale = 1f;

		// Token: 0x04004B93 RID: 19347
		[Space]
		public bool useScanlines = true;

		// Token: 0x04004B94 RID: 19348
		public float scanlineSize = 512f;

		// Token: 0x04004B95 RID: 19349
		[Range(0f, 1f)]
		public float scanlineIntensity = 0.5f;

		// Token: 0x04004B96 RID: 19350
		[HideInInspector]
		public Material _material;

		// Token: 0x04004B97 RID: 19351
		private bool _isFading;

		// Token: 0x04004B98 RID: 19352
		private float _gammaTarget;

		// Token: 0x04004B99 RID: 19353
		private float _gammaDelta;

		// Token: 0x04004B9A RID: 19354
		private Action _callback;

		// Token: 0x0200069C RID: 1692
		public enum GlitchDirections
		{
			// Token: 0x040050F2 RID: 20722
			None,
			// Token: 0x040050F3 RID: 20723
			Vertical,
			// Token: 0x040050F4 RID: 20724
			Horizontal,
			// Token: 0x040050F5 RID: 20725
			Both
		}
	}
}
