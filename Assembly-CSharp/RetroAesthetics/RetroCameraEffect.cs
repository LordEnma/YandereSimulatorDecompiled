using System;
using UnityEngine;

namespace RetroAesthetics
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[ImageEffectAllowedInSceneView]
	public class RetroCameraEffect : MonoBehaviour
	{
		public enum GlitchDirections
		{
			None = 0,
			Vertical = 1,
			Horizontal = 2,
			Both = 3
		}

		[Tooltip("If enabled, simulated TV noise is added to the output.")]
		public bool useStaticNoise = true;

		[Tooltip("Static noise texture. White regions represent noise.")]
		public Texture noiseTexture;

		[SerializeField]
		[Range(0f, 2.5f)]
		[Tooltip("Amount of TV noise to blend into the output.")]
		public float staticIntensity = 0.5f;

		[Space]
		public GlitchDirections randomGlitches = GlitchDirections.Vertical;

		[SerializeField]
		[Range(0f, 2.5f)]
		public float glitchIntensity = 1f;

		[SerializeField]
		[Range(0f, 100f)]
		public int glitchFrequency = 10;

		[Space]
		public bool useDisplacementWaves = true;

		[SerializeField]
		[Range(0f, 5f)]
		public float displacementAmplitude = 1f;

		[SerializeField]
		[Range(10f, 150f)]
		public float displacementFrequency = 100f;

		[SerializeField]
		[Range(0f, 5f)]
		public float displacementSpeed = 1f;

		[Space]
		public bool useChromaticAberration = true;

		[SerializeField]
		[Range(0f, 50f)]
		public float chromaticAberration = 10f;

		[Space]
		public bool useVignette = true;

		[SerializeField]
		[Range(0f, 1f)]
		public float vignette = 0.1f;

		[Space]
		public bool useBottomNoise = true;

		[Range(0f, 0.5f)]
		public float bottomHeight = 0.04f;

		[Range(0f, 3f)]
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

		[Range(0f, 1f)]
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
			if (randomGlitches == GlitchDirections.Horizontal || randomGlitches == GlitchDirections.Both)
			{
				zero.x = UnityEngine.Random.Range(-0.25f * amount, 0.25f * amount);
			}
			if (randomGlitches == GlitchDirections.Vertical || randomGlitches == GlitchDirections.Both)
			{
				zero.y = UnityEngine.Random.Range(-0.25f * amount, 0.25f * amount);
			}
			_material.SetVector("_OffsetPos", zero);
			_material.SetFloat("_ChromaticAberration", UnityEngine.Random.Range(chromaticAberration, amount * chromaticAberration * 2.5f));
		}

		public virtual void FadeIn(float speed = 1f, Action callback = null)
		{
			_isFading = true;
			gammaScale = 0f;
			_gammaTarget = 1f;
			_gammaDelta = speed;
			_callback = callback;
		}

		public virtual void FadeOut(float speed = 1f, Action callback = null)
		{
			_isFading = true;
			_gammaTarget = 0f;
			_gammaDelta = -1f * speed;
			_callback = callback;
		}

		private void Awake()
		{
			_material = new Material(Shader.Find("Hidden/RetroCameraEffect"));
			_material.SetTexture("_SecondaryTex", noiseTexture);
			_material.SetFloat("_OffsetPosY", 0f);
			_material.SetFloat("_DisplacementAmplitude", displacementAmplitude / 1000f);
			_material.SetFloat("_DisplacementFrequency", displacementFrequency);
			_material.SetFloat("_DisplacementSpeed", displacementSpeed);
		}

		private void Update()
		{
			if (!_isFading)
			{
				return;
			}
			gammaScale += _gammaDelta * Time.deltaTime;
			if ((gammaScale > _gammaTarget && _gammaDelta > 0f) || (gammaScale < _gammaTarget && _gammaDelta < 0f))
			{
				gammaScale = _gammaTarget;
				_isFading = false;
				if (_callback != null)
				{
					_callback();
				}
				_callback = null;
			}
		}

		public void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (_material == null)
			{
				Awake();
			}
			_material.SetFloat("_OffsetNoiseX", UnityEngine.Random.Range(0f, 1f));
			float num = _material.GetFloat("_OffsetNoiseY");
			_material.SetFloat("_OffsetNoiseY", num + UnityEngine.Random.Range(-0.05f, 0.05f));
			if (randomGlitches != GlitchDirections.None)
			{
				if (UnityEngine.Random.Range(0, 15) == 0)
				{
					_material.SetFloat("_DisplacementAmplitude", UnityEngine.Random.Range(0f, 10f * displacementAmplitude / 1000f));
				}
				else
				{
					_material.SetFloat("_DisplacementAmplitude", displacementAmplitude / 1000f);
				}
			}
			Vector2 vector = _material.GetVector("_OffsetPos");
			if (vector.y > 0f)
			{
				vector.y -= UnityEngine.Random.Range(0f, vector.y);
			}
			else if (vector.y < 0f)
			{
				vector.y += UnityEngine.Random.Range(0f, 0f - vector.y);
			}
			if (vector.x > 0f)
			{
				vector.x -= UnityEngine.Random.Range(0f, vector.x);
			}
			else if (vector.x < 0f)
			{
				vector.x += UnityEngine.Random.Range(0f, 0f - vector.x);
			}
			_material.SetVector("_OffsetPos", vector);
			float num2 = _material.GetFloat("_ChromaticAberration");
			if (num2 > chromaticAberration)
			{
				_material.SetFloat("_ChromaticAberration", num2 - 15f * Time.deltaTime);
			}
			else if (randomGlitches != GlitchDirections.None && UnityEngine.Random.Range(0, 100 - glitchFrequency) == 0)
			{
				Glitch(glitchIntensity);
			}
			if (useStaticNoise)
			{
				_material.EnableKeyword("NOISE_ON");
			}
			else
			{
				_material.DisableKeyword("NOISE_ON");
			}
			if (useChromaticAberration)
			{
				_material.EnableKeyword("CHROMATIC_ON");
			}
			else
			{
				_material.DisableKeyword("CHROMATIC_ON");
			}
			if (useDisplacementWaves)
			{
				_material.EnableKeyword("DISPLACEMENT_ON");
			}
			else
			{
				_material.DisableKeyword("DISPLACEMENT_ON");
			}
			if (useVignette)
			{
				_material.EnableKeyword("VIGNETTE_ON");
			}
			else
			{
				_material.DisableKeyword("VIGNETTE_ON");
			}
			if (useBottomNoise)
			{
				_material.EnableKeyword("NOISE_BOTTOM_ON");
			}
			else
			{
				_material.DisableKeyword("NOISE_BOTTOM_ON");
			}
			if (useBottomStretch)
			{
				_material.EnableKeyword("BOTTOM_STRETCH_ON");
			}
			else
			{
				_material.DisableKeyword("BOTTOM_STRETCH_ON");
			}
			if (useRadialDistortion)
			{
				_material.EnableKeyword("RADIAL_DISTORTION_ON");
			}
			else
			{
				_material.DisableKeyword("RADIAL_DISTORTION_ON");
			}
			if (useScanlines)
			{
				_material.EnableKeyword("SCANLINES_ON");
			}
			else
			{
				_material.DisableKeyword("SCANLINES_ON");
			}
			_material.SetFloat("_StaticIntensity", staticIntensity);
			_material.SetFloat("_ChromaticAberration", chromaticAberration);
			_material.SetFloat("_Vignette", vignette);
			_material.SetFloat("_NoiseBottomHeight", bottomHeight);
			_material.SetFloat("_NoiseBottomIntensity", bottomIntensity);
			_material.SetFloat("_RadialDistortion", radialIntensity * 0.01f);
			_material.SetFloat("_RadialDistortionCurvature", radialCurvature);
			_material.SetFloat("_ScanlineSize", scanlineSize);
			_material.SetFloat("_ScanlineIntensity", (1f - scanlineIntensity) * 1.34f);
			_material.SetFloat("_Gamma", gammaScale);
			Graphics.Blit(source, destination, _material);
		}
	}
}
