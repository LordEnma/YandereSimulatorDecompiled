using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using XInputDotNetPure;

// Token: 0x02000234 RID: 564
public class CameraEffectsScript : MonoBehaviour
{
	// Token: 0x06001219 RID: 4633 RVA: 0x0008B478 File Offset: 0x00089678
	private void Start()
	{
		this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, 0f);
		this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, 0f);
		this.Profile.colorGrading.enabled = false;
		this.SmartphoneCamera.depthTextureMode = DepthTextureMode.DepthNormals;
	}

	// Token: 0x0600121A RID: 4634 RVA: 0x0008B52C File Offset: 0x0008972C
	private void Update()
	{
		if (this.VibrationCheck)
		{
			this.VibrationTimer = Mathf.MoveTowards(this.VibrationTimer, 0f, Time.deltaTime);
			if (this.VibrationTimer == 0f)
			{
				GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
				this.VibrationCheck = false;
			}
		}
		if (this.Streaks.color.a > 0f)
		{
			this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, this.Streaks.color.a - Time.deltaTime);
			this.UpdateBloom(1f + this.Streaks.color.a * 4f);
			if (this.Streaks.color.a <= 0f)
			{
				this.UpdateBloom(1f);
			}
		}
		if (this.MurderStreaks.color.a > 0f)
		{
			this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, this.MurderStreaks.color.a - Time.deltaTime);
		}
		float num = 1f - this.Yandere.Sanity * 0.01f;
		if (this.EffectStrength != num)
		{
			this.EffectStrength = Mathf.MoveTowards(this.EffectStrength, num, Time.deltaTime * 10f);
			this.UpdateVignette(this.EffectStrength);
			this.UpdateChroma(this.EffectStrength);
		}
	}

	// Token: 0x0600121B RID: 4635 RVA: 0x0008B6F8 File Offset: 0x000898F8
	public void Alarm()
	{
		GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
		this.VibrationCheck = true;
		this.VibrationTimer = 0.1f;
		this.UpdateBloom(2f);
		this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, 1f);
		AudioSource.PlayClipAtPoint(this.Noticed, this.Yandere.Head.position);
	}

	// Token: 0x0600121C RID: 4636 RVA: 0x0008B794 File Offset: 0x00089994
	public void MurderWitnessed()
	{
		GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
		this.VibrationCheck = true;
		this.VibrationTimer = 0.1f;
		this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, 1f);
		this.Yandere.Jukebox.SFX.PlayOneShot(this.Yandere.Noticed ? this.SenpaiNoticed : this.MurderNoticed);
	}

	// Token: 0x0600121D RID: 4637 RVA: 0x0008B838 File Offset: 0x00089A38
	public void DisableCamera()
	{
		if (!this.OneCamera)
		{
			this.OneCamera = true;
			return;
		}
		this.OneCamera = false;
	}

	// Token: 0x0600121E RID: 4638 RVA: 0x0008B854 File Offset: 0x00089A54
	public void UpdateBloom(float Bloom)
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.intensity = Bloom;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x0600121F RID: 4639 RVA: 0x0008B890 File Offset: 0x00089A90
	public void UpdateThreshold(float Threshold)
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.threshold = Threshold;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x06001220 RID: 4640 RVA: 0x0008B8CC File Offset: 0x00089ACC
	public void UpdateBloomKnee(float Knee)
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.softKnee = Knee;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x06001221 RID: 4641 RVA: 0x0008B908 File Offset: 0x00089B08
	public void UpdateBloomRadius(float Radius)
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.radius = Radius;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x06001222 RID: 4642 RVA: 0x0008B944 File Offset: 0x00089B44
	public void EnableBloom()
	{
		this.Profile.bloom.enabled = true;
	}

	// Token: 0x06001223 RID: 4643 RVA: 0x0008B958 File Offset: 0x00089B58
	public void UpdateChroma(float Chroma)
	{
		ChromaticAberrationModel.Settings settings = this.Profile.chromaticAberration.settings;
		settings.intensity = Chroma;
		this.Profile.chromaticAberration.settings = settings;
	}

	// Token: 0x06001224 RID: 4644 RVA: 0x0008B990 File Offset: 0x00089B90
	public void UpdateVignette(float Vignette)
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		if (!this.Yandere.YandereVision)
		{
			settings.intensity = 0.5f - 0.25f * Vignette;
		}
		settings.color = new Color(1f - 1f * Vignette, 0.75f - 0.75f * Vignette, 1f - 1f * Vignette, 1f);
		this.Profile.vignette.settings = settings;
	}

	// Token: 0x06001225 RID: 4645 RVA: 0x0008BA18 File Offset: 0x00089C18
	public void SetVignettePink()
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		settings.color = new Color(1f, 0.75f, 1f, 1f);
		this.Profile.vignette.settings = settings;
	}

	// Token: 0x06001226 RID: 4646 RVA: 0x0008BA68 File Offset: 0x00089C68
	public void UpdateDOF(float Focus)
	{
		Focus *= ((float)Screen.width / 1280f + (float)Screen.height / 720f) * 0.5f;
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x040016D4 RID: 5844
	public PostProcessingProfile Profile;

	// Token: 0x040016D5 RID: 5845
	public YandereScript Yandere;

	// Token: 0x040016D6 RID: 5846
	public UITexture MurderStreaks;

	// Token: 0x040016D7 RID: 5847
	public UITexture Streaks;

	// Token: 0x040016D8 RID: 5848
	public float EffectStrength;

	// Token: 0x040016D9 RID: 5849
	public float VibrationTimer;

	// Token: 0x040016DA RID: 5850
	public bool VibrationCheck;

	// Token: 0x040016DB RID: 5851
	public bool OneCamera;

	// Token: 0x040016DC RID: 5852
	public AudioClip MurderNoticed;

	// Token: 0x040016DD RID: 5853
	public AudioClip SenpaiNoticed;

	// Token: 0x040016DE RID: 5854
	public AudioClip Noticed;

	// Token: 0x040016DF RID: 5855
	public Camera SmartphoneCamera;
}
