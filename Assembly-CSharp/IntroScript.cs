using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

// Token: 0x0200033E RID: 830
public class IntroScript : MonoBehaviour
{
	// Token: 0x0600190A RID: 6410 RVA: 0x000F8070 File Offset: 0x000F6270
	private void Start()
	{
		Application.targetFrameRate = 60;
		this.LoveSickCheck();
		this.Circle.fillAmount = 0f;
		if (!this.New)
		{
			this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		}
		this.Label.text = string.Empty;
		this.SkipTimer = 15f;
		if (this.New)
		{
			RenderSettings.ambientLight = new Color(1f, 1f, 1f);
			this.BloodyHandsAnim["f02_clenchFists_00"].speed = 0.166666f;
			this.HoleInChestAnim["f02_holeInChest_00"].speed = 0f;
			this.YoungRyobaAnim["f02_introHoldHands_00"].speed = 0f;
			this.YoungFatherAnim["introHoldHands_00"].speed = 0f;
			this.BrightenEnvironment();
			base.transform.position = new Vector3(0f, 1.255f, 0.2f);
			base.transform.eulerAngles = new Vector3(45f, 0f, 0f);
			this.HoleInChestAnim.gameObject.SetActive(false);
			this.BloodyHandsAnim.gameObject.SetActive(true);
			this.Montage.gameObject.SetActive(false);
			this.ConfessionScene.SetActive(false);
			this.ParentAndChild.SetActive(false);
			this.DeathCorridor.SetActive(false);
			this.Stalking.SetActive(false);
			this.School.SetActive(false);
			this.Room.SetActive(false);
			this.SetToDefault();
			DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
			settings.focusDistance = 0.66666f;
			settings.aperture = 32f;
			this.Profile.depthOfField.settings = settings;
			Renderer[] componentsInChildren = this.Corridors.gameObject.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].material.color = new Color(0.75f, 0.75f, 0.75f, 1f);
			}
			this.AttackAnim[1]["f02_katanaHighSanityA_00"].speed = 2.5f;
			this.AttackAnim[2]["f02_katanaHighSanityB_00"].speed = 2.5f;
			this.AttackAnim[3]["f02_batLowSanityA_00"].speed = 2.5f;
			this.AttackAnim[4]["f02_batLowSanityB_00"].speed = 2.5f;
			this.AttackAnim[5]["f02_katanaLowSanityA_00"].speed = 2.5f;
			this.AttackAnim[6]["f02_katanaLowSanityB_00"].speed = 2.5f;
			this.MotherAnim["f02_parentTalking_00"].speed = 0.75f;
			this.ChildAnim["f02_childListening_00"].speed = 0.75f;
			for (int j = 4; j < this.Cue.Length; j++)
			{
				if (j < 21)
				{
					this.Cue[j] += 3.898f;
				}
				else if (j > 32)
				{
					this.Cue[j] += 4f;
				}
				else
				{
					this.Cue[j] += 2f;
				}
				if (j > 40)
				{
					this.Cue[j] += 3f;
				}
			}
		}
		this.VtuberCheck();
	}

	// Token: 0x0600190B RID: 6411 RVA: 0x000F8410 File Offset: 0x000F6610
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
		if (Input.GetButton("X"))
		{
			this.Circle.fillAmount = Mathf.MoveTowards(this.Circle.fillAmount, 1f, Time.deltaTime);
			this.SkipTimer = 15f;
			if (this.Circle.fillAmount == 1f)
			{
				this.FadeOut = true;
			}
			this.SkipPanel.alpha = 1f;
		}
		else
		{
			this.Circle.fillAmount = Mathf.MoveTowards(this.Circle.fillAmount, 0f, Time.deltaTime);
			this.SkipTimer -= Time.deltaTime * 2f;
			this.SkipPanel.alpha = this.SkipTimer / 10f;
		}
		this.StartTimer += Time.deltaTime;
		if (this.StartTimer > 1f && !this.Narrating)
		{
			this.Narration.Play();
			this.Narrating = true;
			if (this.BGM != null)
			{
				this.BGM.Play();
			}
		}
		this.Timer = this.Narration.time;
		if (this.ID < this.Cue.Length && this.Narration.time > this.Cue[this.ID])
		{
			this.Label.text = this.Lines[this.ID];
			this.ID++;
		}
		if (this.FadeOut)
		{
			this.FadeOutDarkness.color = new Color(this.FadeOutDarkness.color.r, this.FadeOutDarkness.color.g, this.FadeOutDarkness.color.b, Mathf.MoveTowards(this.FadeOutDarkness.color.a, 1f, Time.deltaTime));
			this.Circle.fillAmount = 1f;
			this.Narration.volume = this.FadeOutDarkness.color.a;
			if (this.FadeOutDarkness.color.a == 1f)
			{
				SceneManager.LoadScene("PhoneScene");
			}
		}
		if (!this.New)
		{
			if (this.Narration.time > 39.75f && this.Narration.time < 73f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime * 0.5f));
			}
			if (this.Narration.time > 73f && this.Narration.time < 105.5f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			}
			if (this.Narration.time > 105.5f && this.Narration.time < 134f)
			{
				this.Darkness.color = new Color(1f, 0f, 0f, 1f);
			}
			if (this.Narration.time > 134f && this.Narration.time < 147f)
			{
				this.Darkness.color = new Color(0f, 0f, 0f, 1f);
			}
			if (this.Narration.time > 147f && this.Narration.time < 152f)
			{
				this.Logo.transform.localScale = new Vector3(this.Logo.transform.localScale.x + Time.deltaTime * 0.1f, this.Logo.transform.localScale.y + Time.deltaTime * 0.1f, this.Logo.transform.localScale.z + Time.deltaTime * 0.1f);
				this.LoveSickLogo.transform.localScale = new Vector3(this.LoveSickLogo.transform.localScale.x + Time.deltaTime * 0.05f, this.LoveSickLogo.transform.localScale.y + Time.deltaTime * 0.05f, this.LoveSickLogo.transform.localScale.z + Time.deltaTime * 0.05f);
				this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, 1f);
				this.LoveSickLogo.color = new Color(this.LoveSickLogo.color.r, this.LoveSickLogo.color.g, this.LoveSickLogo.color.b, 1f);
			}
			if (this.Narration.time > 155.898f)
			{
				this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, 0f);
				this.LoveSickLogo.color = new Color(this.LoveSickLogo.color.r, this.LoveSickLogo.color.g, this.LoveSickLogo.color.b, 0f);
			}
			if (this.Narration.time > 159.898f)
			{
				SceneManager.LoadScene("PhoneScene");
			}
		}
		if (this.New)
		{
			if (this.ID > 19)
			{
				this.AnimTimer += Time.deltaTime;
			}
			if (this.ID > 52)
			{
				if (!this.Narration.isPlaying)
				{
					if (this.MontageParent != null)
					{
						UnityEngine.Object.Destroy(this.MontageParent.gameObject);
						this.Darkness.color = new Color(0f, 0f, 0f, 0f);
						this.Montage.gameObject.SetActive(false);
						this.PostProcessing.enabled = true;
						this.Label.enabled = false;
						this.GUIPP.enabled = true;
						this.Speed = 0f;
						if (GameGlobals.LoveSick)
						{
							this.LoveSickLogo.gameObject.SetActive(true);
						}
						else
						{
							this.Logo.gameObject.SetActive(true);
						}
						DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
						settings.focusDistance = 10f;
						this.Profile.depthOfField.settings = settings;
						this.Profile.depthOfField.enabled = true;
						BloomModel.Settings settings2 = this.Profile.bloom.settings;
						settings2.bloom.intensity = 1f;
						this.Profile.bloom.settings = settings2;
						this.Profile.bloom.enabled = true;
						GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
						this.VibrationCheck = true;
						this.VibrationTimer = 0.1f;
					}
					this.Logo.transform.localScale = new Vector3(this.Logo.transform.localScale.x + Time.deltaTime * 0.1f, this.Logo.transform.localScale.y + Time.deltaTime * 0.1f, this.Logo.transform.localScale.z + Time.deltaTime * 0.1f);
					this.LoveSickLogo.transform.localScale = new Vector3(this.LoveSickLogo.transform.localScale.x + Time.deltaTime * 0.05f, this.LoveSickLogo.transform.localScale.y + Time.deltaTime * 0.05f, this.LoveSickLogo.transform.localScale.z + Time.deltaTime * 0.05f);
					this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, 1f);
					this.LoveSickLogo.color = new Color(this.LoveSickLogo.color.r, this.LoveSickLogo.color.g, this.LoveSickLogo.color.b, 1f);
					this.Speed += Time.deltaTime;
					if (this.Speed > 11f)
					{
						SceneManager.LoadScene("PhoneScene");
						return;
					}
					if (this.Speed > 5f && (this.Logo.gameObject.activeInHierarchy || this.LoveSickLogo.gameObject.activeInHierarchy))
					{
						this.LoveSickLogo.gameObject.SetActive(false);
						this.Logo.gameObject.SetActive(false);
						GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
						this.VibrationCheck = true;
						this.VibrationTimer = 0.1f;
						return;
					}
				}
			}
			else if (this.ID > 51)
			{
				if (this.DeathCorridor.activeInHierarchy)
				{
					RenderSettings.ambientLight = new Color(1f, 1f, 1f);
					this.Darkness.color = new Color(0f, 0f, 0f, 0f);
					this.DeathCorridor.SetActive(false);
					this.PostProcessing.enabled = false;
					this.BloodParent.SetActive(false);
					this.Stalking.SetActive(false);
					this.BGM.volume = 1f;
					this.Speed = 0f;
					this.SetToDefault();
					DepthOfFieldModel.Settings settings3 = this.Profile.depthOfField.settings;
					settings3.focusDistance = 10f;
					this.Profile.depthOfField.settings = settings3;
					this.Profile.depthOfField.enabled = false;
					BloomModel.Settings settings4 = this.Profile.bloom.settings;
					settings4.bloom.intensity = 0.5f;
					this.Profile.bloom.settings = settings4;
					this.Profile.bloom.enabled = false;
					this.VibrationIntensity = 0f;
				}
				this.Speed += 1f;
				if (this.Speed > 2f)
				{
					this.Speed = 0f;
					this.TextureID++;
					if (this.TextureID == 31)
					{
						this.TextureID = 1;
					}
					if (this.TextureID > 10 && this.TextureID < 21)
					{
						this.PostProcessing.enabled = true;
					}
					else
					{
						this.PostProcessing.enabled = false;
					}
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.MontagePrefab, base.transform.position, Quaternion.identity);
					gameObject.GetComponent<Renderer>().material.mainTexture = this.Textures[this.TextureID];
					gameObject.transform.parent = this.MontageParent;
					gameObject.transform.localScale = new Vector3(0.6833265f, 0.38444048f, 0.33333f);
					gameObject.transform.localPosition = new Vector3(UnityEngine.Random.Range(-0.633333f, 0.633333f), UnityEngine.Random.Range(-0.29f, 0.29f), (float)this.PhotosSpawned * -0.0001f);
					gameObject.transform.localEulerAngles = new Vector3(0f, 0f, UnityEngine.Random.Range(-15f, 15f));
					this.Montage.material.mainTexture = this.Textures[this.TextureID];
					this.PhotosSpawned++;
				}
				if (this.Timer > 225f)
				{
					this.Darkness.color = new Color(0f, 0f, 0f, 1f);
					return;
				}
				this.VibrationIntensity += Time.deltaTime * 0.2f;
				GamePad.SetVibration(PlayerIndex.One, this.VibrationIntensity, this.VibrationIntensity);
				this.VibrationCheck = true;
				this.VibrationTimer = 0.1f;
				return;
			}
			else
			{
				if (this.ID > 41)
				{
					if (base.transform.position.z < 0f)
					{
						RenderSettings.ambientLight = new Color(0.2f, 0.2f, 0.2f);
						this.AttackPair[3].SetActive(false);
						this.DeathCorridor.SetActive(true);
						this.Stalking.SetActive(false);
						this.Quad.SetActive(false);
						base.transform.position = new Vector3(0f, 1f, 0f);
						base.transform.eulerAngles = new Vector3(0f, 0f, -15f);
						ColorGradingModel.Settings settings5 = this.Profile.colorGrading.settings;
						settings5.basic.saturation = 1f;
						settings5.channelMixer.red = new Vector3(1f, 0f, 0f);
						settings5.channelMixer.green = new Vector3(0f, 1f, 0f);
						settings5.channelMixer.blue = new Vector3(0f, 0f, 1f);
						this.Profile.colorGrading.settings = settings5;
						this.Rotation = -15f;
						this.Speed = 0f;
						this.BGM.volume = 0.5f;
					}
					this.Speed += Time.deltaTime * 0.015f;
					base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 1f, 34f), Time.deltaTime * this.Speed);
					this.Rotation = Mathf.Lerp(this.Rotation, 15f, Time.deltaTime * this.Speed);
					base.transform.eulerAngles = new Vector3(0f, 0f, this.Rotation);
					if (this.ID < 51)
					{
						this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.2f);
					}
					else
					{
						this.Alpha = 1f;
					}
					this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
					return;
				}
				if (this.ID > 33)
				{
					if (this.School.activeInHierarchy)
					{
						this.School.SetActive(false);
						this.Stalking.SetActive(true);
						base.transform.position = new Vector3(-0.02f, 1.12f, 1f);
						base.transform.eulerAngles = new Vector3(0f, 0f, 0f);
						this.SetToDefault();
						this.Speed = 0f;
					}
					if (this.ID < 40)
					{
						this.VibrationIntensity += Time.deltaTime * 0.05f;
						GamePad.SetVibration(PlayerIndex.One, this.VibrationIntensity, this.VibrationIntensity);
						this.VibrationCheck = true;
						this.VibrationTimer = 0.1f;
					}
					if (this.ID < 37)
					{
						this.Speed += Time.deltaTime * 0.1f;
						base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-0.02f, 1.12f, -0.25f), Time.deltaTime * this.Speed);
						this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.2f);
					}
					else
					{
						if (this.Speed > 0f)
						{
							this.CameraRotationY = 0f;
							this.Speed = 0f;
						}
						this.Speed -= Time.deltaTime * 0.1f;
						base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0.3f, 0.8f, -0.25f), Time.deltaTime * this.Speed * -1f);
						this.CameraRotationY = Mathf.Lerp(this.CameraRotationY, -15f, Time.deltaTime * this.Speed * -1f);
						base.transform.eulerAngles = new Vector3(0f, this.CameraRotationY, 0f);
						if (this.Timer > 179f)
						{
							this.StalkerAnim.Play("f02_clenchFist_00");
						}
						if (this.ID == 40)
						{
							this.Alpha = 1f;
						}
						if (this.ID > 39)
						{
							this.BGM.volume += Time.deltaTime;
						}
						if (this.Timer > 186f)
						{
							this.DeathCorridor.SetActive(true);
							this.Alpha = 1f;
						}
						else if (this.Timer > 185.6f)
						{
							this.AttackPair[2].SetActive(false);
							this.AttackPair[3].SetActive(true);
							GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
							this.VibrationCheck = true;
							this.VibrationTimer = 0.2f;
							this.Alpha = 0f;
						}
						else if (this.Timer > 185.2f)
						{
							this.Alpha = 1f;
						}
						else if (this.Timer > 184.8f)
						{
							this.AttackPair[1].SetActive(false);
							this.AttackPair[2].SetActive(true);
							GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
							this.VibrationCheck = true;
							this.VibrationTimer = 0.2f;
							this.Alpha = 0f;
						}
						else if (this.Timer > 184.4f)
						{
							this.Alpha = 1f;
						}
						else if (this.Timer > 184f)
						{
							ColorGradingModel.Settings settings6 = this.Profile.colorGrading.settings;
							settings6.channelMixer.red = new Vector3(0.1f, 0f, 0f);
							settings6.channelMixer.green = Vector3.zero;
							settings6.channelMixer.blue = Vector3.zero;
							this.Profile.colorGrading.settings = settings6;
							this.Alpha = 0f;
							this.Stalking.SetActive(false);
							this.Quad.SetActive(true);
							this.AttackPair[1].SetActive(true);
							GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
							this.VibrationCheck = true;
							this.VibrationTimer = 0.2f;
						}
					}
					this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
					return;
				}
				if (this.ID > 31)
				{
					if (!this.Osana.activeInHierarchy)
					{
						base.transform.position = new Vector3(0.5f, 1.366666f, 0.25f);
						base.transform.eulerAngles = new Vector3(15f, -67.5f, 0f);
						this.SenpaiAnim.transform.parent.localPosition = new Vector3(0.533333f, 0f, -6.9f);
						this.SenpaiAnim.transform.parent.localEulerAngles = new Vector3(0f, 90f, 0f);
						this.SenpaiAnim.Play("Monday_1");
						this.Osana.SetActive(true);
						DepthOfFieldModel.Settings settings7 = this.Profile.depthOfField.settings;
						settings7.focusDistance = 1.5f;
						this.Profile.depthOfField.settings = settings7;
						this.YandereAnim["f02_Intro_00"].speed = 0.33333f;
						this.Darkness.color = new Color(0f, 0f, 0f, 0f);
						this.Alpha = 0f;
					}
					base.transform.Translate(Vector3.forward * 0.01f * Time.deltaTime, Space.Self);
					this.TurnRed();
					if (this.Narration.time > 156.2f)
					{
						this.Darkness.color = new Color(0f, 0f, 0f, 1f);
						this.Alpha = 1f;
						return;
					}
				}
				else if (this.ID > 27)
				{
					if (base.transform.position.x > 0f)
					{
						base.transform.position = new Vector3(-1.5f, 1f, -1.5f);
						base.transform.eulerAngles = new Vector3(0f, 45f, 0f);
						this.YandereAnim["f02_Intro_00"].time += 0f;
						this.SenpaiAnim["Intro_00"].time += 0f;
						this.YandereAnim["f02_Intro_00"].speed = 1.33333f;
						this.SenpaiAnim["Intro_00"].speed = 1.33333f;
						this.Speed = 0f;
						DepthOfFieldModel.Settings settings8 = this.Profile.depthOfField.settings;
						settings8.focusDistance = 1.5f;
						settings8.aperture = 11.2f;
						this.Profile.depthOfField.settings = settings8;
					}
					if (this.ID > 28)
					{
						this.Speed += Time.deltaTime * 0.1f;
						base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-1.1f, 1.33333f, 1f), Time.deltaTime * this.Speed);
						base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, new Vector3(0f, 135f, 0f), Time.deltaTime * this.Speed);
					}
					if (this.ID > 29)
					{
						this.Stars.Stop();
						this.Bubbles.Stop();
					}
					if (this.ID > 30)
					{
						this.TurnNeutral();
						return;
					}
				}
				else
				{
					if (this.ID > 23)
					{
						if (this.EyeTimer == 0f)
						{
							base.transform.position = new Vector3(0f, 0.9f, 0f);
							base.transform.eulerAngles = new Vector3(15f, -45f, 0f);
							this.YandereAnim["f02_Intro_00"].speed = 0.2f;
							this.SenpaiAnim["Intro_00"].speed = 0.2f;
							this.Yandere.materials[2].SetFloat("_BlendAmount", 1f);
							DepthOfFieldModel.Settings settings9 = this.Profile.depthOfField.settings;
							settings9.focusDistance = 1.5f;
							settings9.aperture = 11.2f;
							this.Profile.depthOfField.settings = settings9;
						}
						this.EyeTimer += Time.deltaTime;
						if (this.EyeTimer > 0.1f)
						{
							this.Yandere.materials[2].SetTextureOffset("_OverlayTex", new Vector2(UnityEngine.Random.Range(-0.01f, 0.01f), UnityEngine.Random.Range(-0.01f, 0.01f)));
							this.EyeTimer -= 0.1f;
						}
						base.transform.Translate(Vector3.forward * -0.1f * Time.deltaTime, Space.Self);
						return;
					}
					if (this.ID > 19)
					{
						if (this.Room.gameObject.activeInHierarchy)
						{
							this.Room.gameObject.SetActive(false);
							this.School.SetActive(true);
							base.transform.localPosition = new Vector3(-3f, 1f, 1.5f);
							this.Darkness.color = new Color(0f, 0f, 0f, 1f);
							this.Alpha = 1f;
							this.Speed = 0f;
							ColorGradingModel.Settings settings10 = this.Profile.colorGrading.settings;
							settings10.basic.saturation = 0f;
							this.Profile.colorGrading.settings = settings10;
							DepthOfFieldModel.Settings settings11 = this.Profile.depthOfField.settings;
							settings11.focusDistance = 10f;
							settings11.aperture = 5.6f;
							this.Profile.depthOfField.settings = settings11;
							this.Yandere.materials[2].SetFloat("_BlendAmount", 0f);
						}
						if (this.Narration.time < 94.898f)
						{
							base.transform.position = Vector3.MoveTowards(base.transform.position, new Vector3(0f, 1f, -2f), Time.deltaTime * 1.09f);
						}
						else
						{
							DepthOfFieldModel.Settings settings12 = this.Profile.depthOfField.settings;
							settings12.focusDistance = 1.2f;
							settings12.aperture = 11.2f;
							this.Profile.depthOfField.settings = settings12;
							if (this.Narration.time < 101.5f)
							{
								base.transform.position = new Vector3(-0.25f, 0.75f, -0.25f);
								base.transform.eulerAngles = new Vector3(22.5f, -45f, 0f);
								this.Senpai.transform.position = new Vector3(0f, -0.2f, 0f);
							}
							else
							{
								this.Speed += Time.deltaTime * 0.5f;
								this.Senpai.transform.position = Vector3.Lerp(this.Senpai.transform.position, new Vector3(0f, 0f, 0f), Time.deltaTime * this.Speed * 2f);
								base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-0.25f, 0.66666f, -1.25f), Time.deltaTime * this.Speed * 0.5f);
								this.CameraRotationX = Mathf.Lerp(this.CameraRotationX, 0f, Time.deltaTime * this.Speed);
								this.CameraRotationY = Mathf.Lerp(this.CameraRotationY, 0f, Time.deltaTime * this.Speed);
								base.transform.eulerAngles = new Vector3(this.CameraRotationX, this.CameraRotationY, 0f);
							}
						}
						if (this.ID > 21)
						{
							this.YandereAnim["f02_Intro_00"].speed = Mathf.MoveTowards(this.YandereAnim["f02_Intro_00"].speed, 0.1f, Time.deltaTime);
							this.SenpaiAnim["Intro_00"].speed = Mathf.MoveTowards(this.SenpaiAnim["Intro_00"].speed, 0.1f, Time.deltaTime);
							if (this.Narration.time > 106.5f)
							{
								ColorGradingModel.Settings settings13 = this.Profile.colorGrading.settings;
								settings13.basic.saturation = Mathf.MoveTowards(settings13.basic.saturation, 2f, Time.deltaTime);
								settings13.channelMixer.red = Vector3.MoveTowards(settings13.channelMixer.red, new Vector3(2f, 0f, 0f), Time.deltaTime);
								settings13.channelMixer.blue = Vector3.MoveTowards(settings13.channelMixer.blue, new Vector3(0f, 0f, 2f), Time.deltaTime);
								this.Profile.colorGrading.settings = settings13;
								this.Particles.SetActive(true);
							}
						}
						else if (this.Narration.time > 98f)
						{
							this.YandereAnim["f02_Intro_00"].speed = 1f;
							this.SenpaiAnim["Intro_00"].speed = 1f;
						}
						else if (this.Narration.time > 97f)
						{
							this.YandereAnim["f02_Intro_00"].speed = 3f;
							this.SenpaiAnim["Intro_00"].speed = 3f;
						}
						this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.2f);
						this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
						return;
					}
					if (this.ID > 15)
					{
						if (this.ParentAndChild.gameObject.activeInHierarchy)
						{
							this.ParentAndChild.gameObject.SetActive(false);
							this.Room.SetActive(true);
							base.transform.position = new Vector3(0f, 1f, 0f);
							this.Darkness.color = new Color(0f, 0f, 0f, 1f);
							this.Alpha = 1f;
							this.Speed = 0.1f;
							DepthOfFieldModel.Settings settings14 = this.Profile.depthOfField.settings;
							settings14.focusDistance = 10f;
							this.Profile.depthOfField.settings = settings14;
						}
						base.transform.position -= new Vector3(0f, 0f, Time.deltaTime * this.Speed * 0.75f);
						if (this.Narration.time > 88.898f)
						{
							this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.66666f);
						}
						else
						{
							this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.2f);
						}
						this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
						return;
					}
					if (this.ID > 13)
					{
						if (this.ConfessionScene.gameObject.activeInHierarchy)
						{
							this.ConfessionScene.gameObject.SetActive(false);
							this.ParentAndChild.SetActive(true);
							this.X = 15f;
							this.Y = -90f;
							this.X2 = 15f;
							this.Y2 = -90f;
							this.Z2 = 0f;
							base.transform.position = new Vector3(0f, 0.5f, -1f);
							this.Darkness.color = new Color(0f, 0f, 0f, 1f);
							this.Alpha = 1f;
							this.Speed = 0.1f;
							ColorGradingModel.Settings settings15 = this.Profile.colorGrading.settings;
							settings15.basic.saturation = 1f;
							this.Profile.colorGrading.settings = settings15;
							BloomModel.Settings settings16 = this.Profile.bloom.settings;
							settings16.bloom.intensity = 1f;
							this.Profile.bloom.settings = settings16;
							DepthOfFieldModel.Settings settings17 = this.Profile.depthOfField.settings;
							settings17.focusDistance = 10f;
							settings17.aperture = 11.2f;
							this.Profile.depthOfField.settings = settings17;
						}
						base.transform.position -= new Vector3(0f, 0f, Time.deltaTime * this.Speed);
						if (this.Narration.time > 69.898f)
						{
							this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
						}
						else
						{
							this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.2f);
						}
						this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
						return;
					}
					if (this.ID > 9)
					{
						if (this.HoleInChestAnim.gameObject.activeInHierarchy)
						{
							this.HoleInChestAnim.gameObject.SetActive(false);
							this.ConfessionScene.SetActive(true);
							base.transform.position = new Vector3(0f, 1f, -1f);
							this.Darkness.color = new Color(0f, 0f, 0f, 1f);
							this.Alpha = 1f;
							this.Speed = 0.1f;
							DepthOfFieldModel.Settings settings18 = this.Profile.depthOfField.settings;
							settings18.focusDistance = 1f;
							this.Profile.depthOfField.settings = settings18;
							ColorGradingModel.Settings settings19 = this.Profile.colorGrading.settings;
							settings19.basic.saturation = 0f;
							this.Profile.colorGrading.settings = settings19;
						}
						base.transform.position -= new Vector3(0f, 0f, Time.deltaTime * this.Speed);
						if (this.ID > 10)
						{
							this.YoungRyobaAnim["f02_introHoldHands_00"].speed = 0.5f;
							this.YoungRyobaAnim.Play();
							this.YoungFatherAnim["introHoldHands_00"].speed = 0.5f;
							this.YoungFatherAnim.Play();
							this.Brightness = Mathf.MoveTowards(this.Brightness, 1f, Time.deltaTime * 0.25f);
							this.BrightenEnvironment();
							this.Blossoms.Play();
							this.X = Mathf.MoveTowards(this.X, 0f, Time.deltaTime * 10f);
						}
						if (this.ID > 11)
						{
							ColorGradingModel.Settings settings20 = this.Profile.colorGrading.settings;
							settings20.basic.saturation = settings20.basic.saturation + Time.deltaTime * 0.25f;
							BloomModel.Settings settings21 = this.Profile.bloom.settings;
							settings21.bloom.intensity = 1f + settings20.basic.saturation;
							this.Profile.bloom.settings = settings21;
							this.Profile.colorGrading.settings = settings20;
						}
						if (this.Narration.time > 56.898f)
						{
							this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
						}
						else
						{
							this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.2f);
						}
						this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
						return;
					}
					if (this.ID > 4)
					{
						if (this.BloodyHandsAnim.gameObject.activeInHierarchy)
						{
							base.transform.position = new Vector3(0.012f, 1.13f, 0.029f);
							base.transform.eulerAngles = Vector3.zero;
							this.BloodyHandsAnim.gameObject.SetActive(false);
							this.HoleInChestAnim.gameObject.SetActive(true);
							this.Alpha = 0f;
							this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
							this.SetToDefault();
						}
						this.Speed = Mathf.MoveTowards(this.Speed, 0.1f, Time.deltaTime * 0.01f);
						base.transform.position -= new Vector3(0f, 0f, Time.deltaTime * this.Speed);
						if (base.transform.position.z < -0.05f)
						{
							this.SecondSpeed = Mathf.MoveTowards(this.SecondSpeed, 0.1f, Time.deltaTime * 0.1f);
							base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(base.transform.position.x, 1f, base.transform.position.z), Time.deltaTime * this.SecondSpeed);
						}
						if (base.transform.position.z < -0.5f)
						{
							this.HoleInChestAnim["f02_holeInChest_00"].speed = 0.5f;
							this.HoleInChestAnim.Play();
						}
						if (this.ID > 8)
						{
							this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.2f);
							this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
							return;
						}
					}
					else if (this.ID > 0)
					{
						if (this.Timer < 2f)
						{
							this.BloodyHandsAnim["f02_clenchFists_00"].time = 0.6f;
							this.BloodyHandsAnim["f02_clenchFists_00"].speed = 0f;
						}
						else
						{
							this.BloodyHandsAnim["f02_clenchFists_00"].speed = 0.07f;
						}
						if (this.ID > 3)
						{
							this.Alpha = 1f;
							this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
							this.BGM.volume = Mathf.MoveTowards(this.BGM.volume, 0.5f, Time.deltaTime * 0.266666f);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600190C RID: 6412 RVA: 0x000FAC0C File Offset: 0x000F8E0C
	private void LateUpdate()
	{
		if (this.New)
		{
			if (this.ID < 41)
			{
				if (this.Narration.time > 103f)
				{
					if (this.ID < 24)
					{
						this.LeftArm.localEulerAngles = new Vector3(0f, 15f, 0f);
						this.BookRight.localEulerAngles = new Vector3(0f, 180f, -90f);
						this.BookLeft.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.BookRight.parent.parent.localPosition = new Vector3(-0.12f, -0.04f, 0f);
						this.BookRight.parent.parent.localEulerAngles = new Vector3(0f, -15f, -135f);
						this.BookRight.parent.parent.parent.localEulerAngles = new Vector3(45f, 45f, 0f);
					}
					else
					{
						this.BookRight.parent.parent.localPosition = new Vector3(-0.075f, -0.085f, 0f);
						this.BookRight.parent.parent.localEulerAngles = new Vector3(0f, -45f, -90f);
						this.BookRight.localEulerAngles = new Vector3(0f, 180f, -45f);
						this.BookLeft.localEulerAngles = new Vector3(0f, 180f, 45f);
					}
				}
				else if (this.Narration.time > 94.898f)
				{
					this.Rotation = 22.5f;
				}
			}
			if (this.Narration.time > 104f && this.Narration.time < 190f)
			{
				this.ThirdSpeed += Time.deltaTime;
				this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 3.6f * this.ThirdSpeed);
			}
			this.Neck.localEulerAngles += new Vector3(this.Rotation, 0f, 0f);
			if (this.Narration.time > 99f)
			{
				this.Weight = Mathf.MoveTowards(this.Weight, 0f, Time.deltaTime * 20f);
			}
			else if (this.Narration.time > 96.648f)
			{
				this.Weight = Mathf.MoveTowards(this.Weight, 50f, Time.deltaTime * 100f);
			}
			this.Yandere.SetBlendShapeWeight(5, this.Weight);
			this.Ponytail.transform.eulerAngles = new Vector3(this.X, this.Y, this.Z);
			this.Ponytail.transform.GetChild(0).eulerAngles = new Vector3(0f, 90f, 0f);
			this.RightHair.transform.eulerAngles = new Vector3(this.X2, this.Y2, this.Z2);
			this.LeftHair.transform.eulerAngles = new Vector3(this.X2, this.Y2, this.Z2);
			this.Ponytail2.transform.eulerAngles = new Vector3(this.X, this.Y, this.Z);
			this.RightHair2.transform.eulerAngles = new Vector3(this.X2, this.Y2, this.Z2);
			this.LeftHair2.transform.eulerAngles = new Vector3(this.X2, this.Y2, this.Z2);
			this.RightHand.localEulerAngles += new Vector3(UnityEngine.Random.Range(1f, -1f), UnityEngine.Random.Range(1f, -1f), UnityEngine.Random.Range(1f, -1f));
		}
	}

	// Token: 0x0600190D RID: 6413 RVA: 0x000FB044 File Offset: 0x000F9244
	private void LoveSickCheck()
	{
		if (GameGlobals.LoveSick)
		{
			Camera.main.backgroundColor = new Color(0f, 0f, 0f, 1f);
			foreach (GameObject gameObject in UnityEngine.Object.FindObjectsOfType<GameObject>())
			{
				UISprite component = gameObject.GetComponent<UISprite>();
				if (component != null)
				{
					component.color = new Color(1f, 0f, 0f, component.color.a);
				}
				UITexture component2 = gameObject.GetComponent<UITexture>();
				if (component2 != null)
				{
					component2.color = new Color(1f, 0f, 0f, component2.color.a);
				}
				UILabel component3 = gameObject.GetComponent<UILabel>();
				if (component3 != null && component3.color != Color.black)
				{
					component3.color = new Color(1f, 0f, 0f, component3.color.a);
				}
			}
			this.FadeOutDarkness.color = new Color(0f, 0f, 0f, 0f);
			this.LoveSickLogo.enabled = true;
			this.Logo.enabled = false;
			return;
		}
		this.LoveSickLogo.enabled = false;
	}

	// Token: 0x0600190E RID: 6414 RVA: 0x000FB19C File Offset: 0x000F939C
	private void BrightenEnvironment()
	{
		this.TreeRenderer[0].materials[0].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
		this.TreeRenderer[0].materials[1].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
		this.TreeRenderer[1].materials[0].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
		this.TreeRenderer[1].materials[1].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
		this.TreeRenderer[2].materials[0].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
		this.TreeRenderer[2].materials[1].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
		this.GrassBlades.material.SetColor("_BladeTopColor", new Color(0f, this.Brightness * 0.5f, 0f, 1f));
		this.Petals.material.color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
		this.Mound.material.color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
		this.Sky.material.color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
		this.YoungFatherRenderer.materials[0].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
		this.YoungFatherRenderer.materials[1].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
		this.YoungFatherRenderer.materials[2].color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
		this.YoungFatherHairRenderer.material.color = new Color(this.Brightness, this.Brightness, this.Brightness, 1f);
	}

	// Token: 0x0600190F RID: 6415 RVA: 0x000FB438 File Offset: 0x000F9638
	private void TurnNeutral()
	{
		ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
		settings.channelMixer.red = Vector3.MoveTowards(settings.channelMixer.red, new Vector3(1f, 0f, 0f), Time.deltaTime * 0.66666f);
		settings.channelMixer.green = Vector3.MoveTowards(settings.channelMixer.green, new Vector3(0f, 1f, 0f), Time.deltaTime * 0.66666f);
		settings.channelMixer.blue = Vector3.MoveTowards(settings.channelMixer.blue, new Vector3(0f, 0f, 1f), Time.deltaTime * 0.66666f);
		this.Profile.colorGrading.settings = settings;
	}

	// Token: 0x06001910 RID: 6416 RVA: 0x000FB518 File Offset: 0x000F9718
	private void TurnRed()
	{
		ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
		settings.basic.saturation = Mathf.MoveTowards(settings.basic.saturation, 1f, Time.deltaTime * 0.1f);
		settings.channelMixer.red = Vector3.MoveTowards(settings.channelMixer.red, new Vector3(1f, 0f, 0f), Time.deltaTime * 0.1f);
		settings.channelMixer.green = Vector3.MoveTowards(settings.channelMixer.green, new Vector3(0f, 0.5f, 0f), Time.deltaTime * 0.1f);
		settings.channelMixer.blue = Vector3.MoveTowards(settings.channelMixer.blue, new Vector3(0f, 0f, 0.5f), Time.deltaTime * 0.1f);
		this.Profile.colorGrading.settings = settings;
	}

	// Token: 0x06001911 RID: 6417 RVA: 0x000FB624 File Offset: 0x000F9824
	private void SetToDefault()
	{
		ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
		settings.basic.saturation = 1f;
		settings.channelMixer.red = new Vector3(1f, 0f, 0f);
		settings.channelMixer.green = new Vector3(0f, 1f, 0f);
		settings.channelMixer.blue = new Vector3(0f, 0f, 1f);
		this.Profile.colorGrading.settings = settings;
		DepthOfFieldModel.Settings settings2 = this.Profile.depthOfField.settings;
		settings2.focusDistance = 10f;
		settings2.aperture = 11.2f;
		this.Profile.depthOfField.settings = settings2;
		BloomModel.Settings settings3 = this.Profile.bloom.settings;
		settings3.bloom.intensity = 1f;
		this.Profile.bloom.settings = settings3;
	}

	// Token: 0x06001912 RID: 6418 RVA: 0x000FB734 File Offset: 0x000F9934
	private void VtuberCheck()
	{
		if (GameGlobals.VtuberID > 0)
		{
			for (int i = 1; i < this.OriginalHairs.Length; i++)
			{
				this.OriginalHairs[i].SetActive(false);
				this.VtuberHairs[i].SetActive(true);
			}
			for (int i = 1; i < this.UniformSetters.Length; i++)
			{
				this.UniformSetters[i].AyanoFace = this.VtuberFaces[GameGlobals.VtuberID];
				this.UniformSetters[i].SetFemaleUniform();
			}
			for (int i = 0; i < 13; i++)
			{
				this.YandereRenderer.SetBlendShapeWeight(i, 0f);
			}
			this.YandereRenderer.SetBlendShapeWeight(9, 100f);
			this.ChildRenderer.materials[0].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
			this.ChildRenderer.materials[2].mainTexture = this.VtuberEyes[GameGlobals.VtuberID];
			return;
		}
		for (int j = 1; j < this.VtuberHairs.Length; j++)
		{
			this.VtuberHairs[j].SetActive(false);
		}
	}

	// Token: 0x040026B0 RID: 9904
	public PostProcessingBehaviour PostProcessing;

	// Token: 0x040026B1 RID: 9905
	public PostProcessingBehaviour GUIPP;

	// Token: 0x040026B2 RID: 9906
	public PostProcessingProfile Profile;

	// Token: 0x040026B3 RID: 9907
	public GameObject[] AttackPair;

	// Token: 0x040026B4 RID: 9908
	public GameObject MontagePrefab;

	// Token: 0x040026B5 RID: 9909
	public GameObject ConfessionScene;

	// Token: 0x040026B6 RID: 9910
	public GameObject ParentAndChild;

	// Token: 0x040026B7 RID: 9911
	public GameObject DeathCorridor;

	// Token: 0x040026B8 RID: 9912
	public GameObject BloodParent;

	// Token: 0x040026B9 RID: 9913
	public GameObject Particles;

	// Token: 0x040026BA RID: 9914
	public GameObject Stalking;

	// Token: 0x040026BB RID: 9915
	public GameObject School;

	// Token: 0x040026BC RID: 9916
	public GameObject Osana;

	// Token: 0x040026BD RID: 9917
	public GameObject Room;

	// Token: 0x040026BE RID: 9918
	public GameObject Quad;

	// Token: 0x040026BF RID: 9919
	public Texture[] Textures;

	// Token: 0x040026C0 RID: 9920
	public Transform RightForeArm;

	// Token: 0x040026C1 RID: 9921
	public Transform LeftForeArm;

	// Token: 0x040026C2 RID: 9922
	public Transform RightWrist;

	// Token: 0x040026C3 RID: 9923
	public Transform LeftWrist;

	// Token: 0x040026C4 RID: 9924
	public Transform MontageParent;

	// Token: 0x040026C5 RID: 9925
	public Transform Corridors;

	// Token: 0x040026C6 RID: 9926
	public Transform RightHand;

	// Token: 0x040026C7 RID: 9927
	public Transform Senpai;

	// Token: 0x040026C8 RID: 9928
	public Transform Head;

	// Token: 0x040026C9 RID: 9929
	public Animation BloodyHandsAnim;

	// Token: 0x040026CA RID: 9930
	public Animation HoleInChestAnim;

	// Token: 0x040026CB RID: 9931
	public Animation YoungFatherAnim;

	// Token: 0x040026CC RID: 9932
	public Animation YoungRyobaAnim;

	// Token: 0x040026CD RID: 9933
	public Animation StalkerAnim;

	// Token: 0x040026CE RID: 9934
	public Animation YandereAnim;

	// Token: 0x040026CF RID: 9935
	public Animation SenpaiAnim;

	// Token: 0x040026D0 RID: 9936
	public Animation MotherAnim;

	// Token: 0x040026D1 RID: 9937
	public Animation ChildAnim;

	// Token: 0x040026D2 RID: 9938
	public Animation[] AttackAnim;

	// Token: 0x040026D3 RID: 9939
	public Renderer[] TreeRenderer;

	// Token: 0x040026D4 RID: 9940
	public Renderer YoungFatherHairRenderer;

	// Token: 0x040026D5 RID: 9941
	public Renderer YoungFatherRenderer;

	// Token: 0x040026D6 RID: 9942
	public Renderer GrassBlades;

	// Token: 0x040026D7 RID: 9943
	public Renderer Montage;

	// Token: 0x040026D8 RID: 9944
	public Renderer Petals;

	// Token: 0x040026D9 RID: 9945
	public Renderer Mound;

	// Token: 0x040026DA RID: 9946
	public Renderer Sky;

	// Token: 0x040026DB RID: 9947
	public SkinnedMeshRenderer Yandere;

	// Token: 0x040026DC RID: 9948
	public ParticleSystem Blossoms;

	// Token: 0x040026DD RID: 9949
	public ParticleSystem Bubbles;

	// Token: 0x040026DE RID: 9950
	public ParticleSystem Stars;

	// Token: 0x040026DF RID: 9951
	public UISprite FadeOutDarkness;

	// Token: 0x040026E0 RID: 9952
	public UITexture LoveSickLogo;

	// Token: 0x040026E1 RID: 9953
	public UIPanel SkipPanel;

	// Token: 0x040026E2 RID: 9954
	public UISprite Darkness;

	// Token: 0x040026E3 RID: 9955
	public UISprite Circle;

	// Token: 0x040026E4 RID: 9956
	public UITexture Logo;

	// Token: 0x040026E5 RID: 9957
	public UILabel Label;

	// Token: 0x040026E6 RID: 9958
	public AudioSource Narration;

	// Token: 0x040026E7 RID: 9959
	public AudioSource BGM;

	// Token: 0x040026E8 RID: 9960
	public string[] Lines;

	// Token: 0x040026E9 RID: 9961
	public float[] Cue;

	// Token: 0x040026EA RID: 9962
	public bool Narrating;

	// Token: 0x040026EB RID: 9963
	public bool Musicing;

	// Token: 0x040026EC RID: 9964
	public bool FadeOut;

	// Token: 0x040026ED RID: 9965
	public bool New;

	// Token: 0x040026EE RID: 9966
	public float CameraRotationX;

	// Token: 0x040026EF RID: 9967
	public float CameraRotationY;

	// Token: 0x040026F0 RID: 9968
	public float ThirdSpeed;

	// Token: 0x040026F1 RID: 9969
	public float SecondSpeed;

	// Token: 0x040026F2 RID: 9970
	public float Speed;

	// Token: 0x040026F3 RID: 9971
	public float Brightness;

	// Token: 0x040026F4 RID: 9972
	public float StartTimer;

	// Token: 0x040026F5 RID: 9973
	public float SkipTimer;

	// Token: 0x040026F6 RID: 9974
	public float EyeTimer;

	// Token: 0x040026F7 RID: 9975
	public float Alpha;

	// Token: 0x040026F8 RID: 9976
	public float Timer;

	// Token: 0x040026F9 RID: 9977
	public float AnimTimer;

	// Token: 0x040026FA RID: 9978
	public int PhotosSpawned;

	// Token: 0x040026FB RID: 9979
	public int TextureID;

	// Token: 0x040026FC RID: 9980
	public int ID;

	// Token: 0x040026FD RID: 9981
	public float VibrationIntensity;

	// Token: 0x040026FE RID: 9982
	public float VibrationTimer;

	// Token: 0x040026FF RID: 9983
	public bool VibrationCheck;

	// Token: 0x04002700 RID: 9984
	public Transform RightHair;

	// Token: 0x04002701 RID: 9985
	public Transform LeftHair;

	// Token: 0x04002702 RID: 9986
	public Transform Ponytail;

	// Token: 0x04002703 RID: 9987
	public Transform RightHair2;

	// Token: 0x04002704 RID: 9988
	public Transform LeftHair2;

	// Token: 0x04002705 RID: 9989
	public Transform Ponytail2;

	// Token: 0x04002706 RID: 9990
	public Transform BookRight;

	// Token: 0x04002707 RID: 9991
	public Transform BookLeft;

	// Token: 0x04002708 RID: 9992
	public Transform LeftArm;

	// Token: 0x04002709 RID: 9993
	public Transform Neck;

	// Token: 0x0400270A RID: 9994
	public float Rotation;

	// Token: 0x0400270B RID: 9995
	public float Weight;

	// Token: 0x0400270C RID: 9996
	public float X;

	// Token: 0x0400270D RID: 9997
	public float Y;

	// Token: 0x0400270E RID: 9998
	public float Z;

	// Token: 0x0400270F RID: 9999
	public float X2;

	// Token: 0x04002710 RID: 10000
	public float Y2;

	// Token: 0x04002711 RID: 10001
	public float Z2;

	// Token: 0x04002712 RID: 10002
	public UniformSetterScript[] UniformSetters;

	// Token: 0x04002713 RID: 10003
	public GameObject[] OriginalHairs;

	// Token: 0x04002714 RID: 10004
	public GameObject[] VtuberHairs;

	// Token: 0x04002715 RID: 10005
	public Texture[] VtuberFaces;

	// Token: 0x04002716 RID: 10006
	public Texture[] VtuberEyes;

	// Token: 0x04002717 RID: 10007
	public SkinnedMeshRenderer YandereRenderer;

	// Token: 0x04002718 RID: 10008
	public SkinnedMeshRenderer ChildRenderer;
}
