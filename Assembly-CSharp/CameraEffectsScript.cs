using UnityEngine;
using UnityEngine.PostProcessing;
using XInputDotNetPure;

public class CameraEffectsScript : MonoBehaviour
{
	public PostProcessingProfile Profile;

	public YandereScript Yandere;

	public UITexture MurderStreaks;

	public UITexture Streaks;

	public float EffectStrength;

	public float VibrationTimer;

	public bool VibrationCheck;

	public bool OneCamera;

	public AudioClip MurderNoticed;

	public AudioClip SenpaiNoticed;

	public AudioClip Noticed;

	public Camera SmartphoneCamera;

	public float ZoomFactor;

	public float NewFocus;

	private void Start()
	{
		MurderStreaks.color = new Color(MurderStreaks.color.r, MurderStreaks.color.g, MurderStreaks.color.b, 0f);
		Streaks.color = new Color(Streaks.color.r, Streaks.color.g, Streaks.color.b, 0f);
		Profile.colorGrading.enabled = false;
		SmartphoneCamera.depthTextureMode = DepthTextureMode.DepthNormals;
	}

	private void Update()
	{
		if (VibrationCheck)
		{
			VibrationTimer = Mathf.MoveTowards(VibrationTimer, 0f, Time.deltaTime);
			if (VibrationTimer == 0f)
			{
				GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
				VibrationCheck = false;
			}
		}
		if (Streaks.color.a > 0f)
		{
			Streaks.color = new Color(Streaks.color.r, Streaks.color.g, Streaks.color.b, Streaks.color.a - Time.deltaTime);
			UpdateBloom(1f + Streaks.color.a * 4f);
			if (Streaks.color.a <= 0f)
			{
				UpdateBloom(1f);
			}
		}
		if (MurderStreaks.color.a > 0f)
		{
			MurderStreaks.color = new Color(MurderStreaks.color.r, MurderStreaks.color.g, MurderStreaks.color.b, MurderStreaks.color.a - Time.deltaTime);
		}
		float num = 1f - Yandere.Sanity * 0.01f;
		if (EffectStrength != num)
		{
			EffectStrength = Mathf.MoveTowards(EffectStrength, num, Time.deltaTime * 10f);
			UpdateVignette(EffectStrength);
			UpdateChroma(EffectStrength);
		}
	}

	public void Alarm()
	{
		GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
		VibrationCheck = true;
		VibrationTimer = 0.1f;
		UpdateBloom(2f);
		Streaks.color = new Color(Streaks.color.r, Streaks.color.g, Streaks.color.b, 1f);
		AudioSource.PlayClipAtPoint(Noticed, Yandere.Head.position);
	}

	public void MurderWitnessed()
	{
		GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
		VibrationCheck = true;
		VibrationTimer = 0.1f;
		MurderStreaks.color = new Color(MurderStreaks.color.r, MurderStreaks.color.g, MurderStreaks.color.b, 1f);
		Yandere.Jukebox.SFX.PlayOneShot(Yandere.Noticed ? SenpaiNoticed : MurderNoticed);
	}

	public void DisableCamera()
	{
		if (!OneCamera)
		{
			OneCamera = true;
		}
		else
		{
			OneCamera = false;
		}
	}

	public void UpdateBloom(float Bloom)
	{
		BloomModel.Settings settings = Profile.bloom.settings;
		settings.bloom.intensity = Bloom;
		Profile.bloom.settings = settings;
	}

	public void UpdateThreshold(float Threshold)
	{
		BloomModel.Settings settings = Profile.bloom.settings;
		settings.bloom.threshold = Threshold;
		Profile.bloom.settings = settings;
	}

	public void UpdateBloomKnee(float Knee)
	{
		BloomModel.Settings settings = Profile.bloom.settings;
		settings.bloom.softKnee = Knee;
		Profile.bloom.settings = settings;
	}

	public void UpdateBloomRadius(float Radius)
	{
		BloomModel.Settings settings = Profile.bloom.settings;
		settings.bloom.radius = Radius;
		Profile.bloom.settings = settings;
	}

	public void EnableBloom()
	{
		Profile.bloom.enabled = true;
	}

	public void UpdateChroma(float Chroma)
	{
		ChromaticAberrationModel.Settings settings = Profile.chromaticAberration.settings;
		settings.intensity = Chroma;
		Profile.chromaticAberration.settings = settings;
	}

	public void UpdateVignette(float Vignette)
	{
		VignetteModel.Settings settings = Profile.vignette.settings;
		if (!Yandere.YandereVision)
		{
			settings.intensity = 0.5f - 0.25f * Vignette;
		}
		settings.color = new Color(1f - 1f * Vignette, 0.75f - 0.75f * Vignette, 1f - 1f * Vignette, 1f);
		Profile.vignette.settings = settings;
	}

	public void SetVignettePink()
	{
		VignetteModel.Settings settings = Profile.vignette.settings;
		settings.color = new Color(1f, 0.75f, 1f, 1f);
		Profile.vignette.settings = settings;
	}

	public void UpdateDOF(float Focus)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		Profile.depthOfField.settings = settings;
		UpdateAperture(5.6f);
	}

	public float GetDOF()
	{
		return Profile.depthOfField.settings.focusDistance;
	}

	public void UpdateAperture(float Aperture)
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		float num = (float)Screen.width / 1280f;
		settings.aperture = Aperture * num;
		settings.focalLength = 50f;
		Profile.depthOfField.settings = settings;
	}
}
