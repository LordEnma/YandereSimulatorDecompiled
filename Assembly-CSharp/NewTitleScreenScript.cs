using System;
using RetroAesthetics;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x0200037B RID: 891
public class NewTitleScreenScript : MonoBehaviour
{
	// Token: 0x06001A17 RID: 6679 RVA: 0x0011092C File Offset: 0x0010EB2C
	private void Start()
	{
		Debug.Log("Upon entering the title screen, DepthOfField settings are: " + OptionGlobals.DepthOfField.ToString());
		GameGlobals.VtuberID = 0;
		MissionModeGlobals.MissionMode = false;
		Debug.Log(string.Concat(new string[]
		{
			"Entering title screen.  GameGlobals.Profile is ",
			GameGlobals.Profile.ToString(),
			". GameGlobals.Eighties is ",
			GameGlobals.Eighties.ToString(),
			"."
		}));
		this.Eighties = GameGlobals.Eighties;
		Time.timeScale = 2f;
		this.YandereAnimation["f02_idleCouncilStrict_00"].speed = 0.5f;
		base.transform.position = new Vector3(0f, 0.5f, -18f);
		base.transform.eulerAngles = new Vector3(-15f, 0f, 0f);
		this.LookAtTarget.position = new Vector3(0f, 5.055138f, 0f);
		this.UpdateBloom(this.BloomIntensity, this.BloomRadius);
		this.UpdateDOF(this.DepthFocus);
		this.ResetVignette();
		this.ModeSelection.alpha = 0f;
		this.DemoChecklist.alpha = 0f;
		this.CheatEntry.alpha = 0f;
		this.PressStart.alpha = 0f;
		this.SaveFiles.alpha = 0f;
		this.Settings.alpha = 0f;
		this.Sponsors.alpha = 0f;
		this.Cursor.alpha = 0f;
		this.Profile.colorGrading.enabled = false;
		this.BloodProjector.SetActive(false);
		this.LoveLetter.SetActive(true);
		this.Knife.SetActive(false);
		if (this.Eighties)
		{
			this.EnableEightiesEffects();
		}
		else
		{
			this.DisableEightiesEffects();
		}
		if (SchoolGlobals.SchoolAtmosphereSet && SchoolGlobals.SchoolAtmosphere < 0.5f)
		{
			this.EightiesJukebox.clip = this.SpookyEightiesMusic;
			this.Jukebox.clip = this.SpookyMusic;
			this.EightiesJukebox.Play();
			this.Jukebox.Play();
			this.Grayscale.enabled = true;
			this.Vignette.enabled = true;
		}
		if (OptionGlobals.DrawDistance == 0 || OptionGlobals.DrawDistanceLimit == 0)
		{
			OptionGlobals.DrawDistanceLimit = 350;
			OptionGlobals.DrawDistance = 350;
		}
		this.NewSettings.UpdateGraphics();
		GameGlobals.TransitionToPostCredits = false;
		GameGlobals.DarkEnding = false;
		GameGlobals.Debug = false;
		if (DateGlobals.Week == 2 && !GameGlobals.PlayerHasBeatenDemo && !this.Eighties)
		{
			this.CongratulationsWindow.SetActive(true);
			GameGlobals.PlayerHasBeatenDemo = true;
		}
		this.EightiesLogo.alpha = 0f;
		this.VtuberHairs[1].SetActive(false);
	}

	// Token: 0x06001A18 RID: 6680 RVA: 0x00110C10 File Offset: 0x0010EE10
	private void Update()
	{
		if (this.Frame == 1)
		{
			if (this.Eighties)
			{
				this.EnableEightiesEffects();
			}
			else
			{
				this.DisableEightiesEffects();
			}
			GameGlobals.Debug = false;
		}
		this.Frame++;
		if (Input.GetKey(KeyCode.Escape))
		{
			if (Input.GetKeyDown("-"))
			{
				Time.timeScale -= 1f;
			}
			if (Input.GetKeyDown("="))
			{
				Time.timeScale += 1f;
			}
			this.DebugTimer += Time.deltaTime;
			if (this.DebugTimer > 100f)
			{
				DateGlobals.Week = 2;
				GameGlobals.RivalEliminationID = 1;
				GameGlobals.NonlethalElimination = false;
				SceneManager.LoadScene("NewTitleScene");
			}
		}
		if (this.Log == 0)
		{
			if (Input.GetKeyDown("l"))
			{
				this.Log++;
			}
		}
		else if (this.Log == 1)
		{
			if (Input.GetKeyDown("o"))
			{
				this.Log++;
			}
		}
		else if (this.Log == 2)
		{
			if (Input.GetKeyDown("g"))
			{
				this.DebugLog.gameObject.SetActive(true);
				this.Log++;
			}
		}
		else if (this.Log == 3)
		{
			this.DebugLog.text = "GameGlobals.Debug is: " + GameGlobals.Debug.ToString() + " and QuickStart is: " + this.QuickStart.ToString();
		}
		if (Input.GetKeyDown("m"))
		{
			this.CurrentJukebox.volume = 0f;
		}
		this.Cursor.transform.parent.Rotate(new Vector3(Time.deltaTime * 100f, 0f, 0f), Space.Self);
		if (this.Phase != 2)
		{
			this.Cursor.alpha = Mathf.MoveTowards(this.Cursor.alpha, 0f, Time.deltaTime);
		}
		this.Cursor.transform.parent.localPosition = Vector3.Lerp(this.Cursor.transform.parent.localPosition, new Vector3((float)this.PositionX, 300f - 75f * (float)this.Selection, this.Cursor.transform.parent.localPosition.z), Time.deltaTime * 10f);
		if (!this.FadeOut)
		{
			if (this.InputDevice.Type == InputDeviceType.Gamepad)
			{
				this.PressStart.text = "PRESS START";
			}
			else
			{
				this.PressStart.text = "PRESS ENTER";
			}
			if (this.Phase < 2)
			{
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 0.5f, -17f), Time.deltaTime * 0.5f * this.SpeedUpFactor);
				this.EightiesLogo.alpha = Mathf.MoveTowards(this.EightiesLogo.alpha, 1f, Time.deltaTime * 0.2f);
				this.BloomIntensity = Mathf.Lerp(this.BloomIntensity, 1f, Time.deltaTime * this.Speed);
				this.BloomRadius = Mathf.Lerp(this.BloomRadius, 4f, Time.deltaTime * this.Speed);
				this.UpdateBloom(this.BloomIntensity, this.BloomRadius);
				this.UpdateDOF(2f);
			}
			if (this.Phase == 0)
			{
				if (Input.anyKeyDown)
				{
					this.Speed += 1f;
				}
				if (this.BloomIntensity < 1.1f)
				{
					if (this.CongratulationsWindow.activeInHierarchy)
					{
						if (!this.PromptBar.Show)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Cool, thanks bro!";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						if (Input.GetButtonDown("A"))
						{
							this.CongratulationsWindow.SetActive(false);
							this.PromptBar.Show = false;
						}
					}
					else
					{
						this.PressStart.alpha = Mathf.MoveTowards(this.PressStart.alpha, 1f, Time.deltaTime);
						if (Input.GetButtonDown("Start"))
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Confirm";
							this.PromptBar.Label[5].text = "Change Selection";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
							this.Speed = 0f;
							this.Phase++;
						}
					}
				}
			}
			else if (this.Phase == 1)
			{
				this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0f, 5.055138f, 0f), Time.deltaTime);
				this.ModeSelection.alpha = Mathf.MoveTowards(this.ModeSelection.alpha, 1f, Time.deltaTime);
				this.PressStart.alpha = Mathf.MoveTowards(this.PressStart.alpha, 0f, Time.deltaTime);
				if (this.Eighties)
				{
					this.EightiesWindow.alpha = Mathf.MoveTowards(this.EightiesWindow.alpha, 1f, Time.deltaTime * 10f);
					this.DemoWindow.alpha = Mathf.MoveTowards(this.DemoWindow.alpha, 0.25f, Time.deltaTime * 10f);
				}
				else
				{
					this.EightiesWindow.alpha = Mathf.MoveTowards(this.EightiesWindow.alpha, 0.25f, Time.deltaTime * 10f);
					this.DemoWindow.alpha = Mathf.MoveTowards(this.DemoWindow.alpha, 1f, Time.deltaTime * 10f);
				}
				if (this.ModeSelection.alpha == 1f && this.LookAtTarget.position.y > 3f)
				{
					if (this.InputManager.TappedLeft || this.InputManager.TappedRight)
					{
						this.Eighties = !this.Eighties;
						GameGlobals.Eighties = this.Eighties;
						if (this.Eighties)
						{
							this.EnableEightiesEffects();
						}
						else
						{
							this.DisableEightiesEffects();
						}
					}
					if (Input.GetButtonDown("A"))
					{
						this.PromptBar.Label[0].text = "Make Selection";
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.Label[4].text = "Change Selection";
						this.PromptBar.Label[5].text = "";
						this.PromptBar.UpdateButtons();
						this.MyAudio.clip = this.Whoosh;
						this.MyAudio.pitch = 0.5f;
						this.MyAudio.volume = 1f;
						this.MyAudio.Play();
						this.Speed = 0f;
						this.Phase = 2;
					}
				}
			}
			else if (this.Phase == 2)
			{
				this.Speed += Time.deltaTime * 2f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-0.666666f, 1.195f, -2.9f), Time.deltaTime * this.Speed);
				this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0f, 1.195f, -2.263333f), Time.deltaTime * this.Speed);
				this.DepthFocus = Mathf.Lerp(this.DepthFocus, 1f, Time.deltaTime * this.Speed);
				this.UpdateDOF(this.DepthFocus);
				this.Settings.alpha = Mathf.MoveTowards(this.Settings.alpha, 0f, Time.deltaTime);
				this.Sponsors.alpha = Mathf.MoveTowards(this.Sponsors.alpha, 0f, Time.deltaTime);
				this.SaveFiles.alpha = Mathf.MoveTowards(this.SaveFiles.alpha, 0f, Time.deltaTime);
				this.CheatEntry.alpha = Mathf.MoveTowards(this.CheatEntry.alpha, 0f, Time.deltaTime);
				this.DemoChecklist.alpha = Mathf.MoveTowards(this.DemoChecklist.alpha, 0f, Time.deltaTime);
				if (this.Speed > 3f)
				{
					this.Cursor.alpha = Mathf.MoveTowards(this.Cursor.alpha, 1f, Time.deltaTime);
					if (this.Cursor.alpha == 1f)
					{
						if (!this.PromptBar.Show && !this.ForVideo)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Make Selection";
							this.PromptBar.Label[1].text = "Back";
							this.PromptBar.Label[4].text = "Change Selection";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						if (this.InputManager.TappedDown)
						{
							this.Selection++;
							this.UpdateCursor();
						}
						if (this.InputManager.TappedUp)
						{
							this.Selection--;
							this.UpdateCursor();
						}
						if (Input.GetButtonDown("A"))
						{
							if (this.ForVideo)
							{
								this.Phase = 7;
							}
							else
							{
								this.PromptBar.Show = false;
								if (this.Selection == 1)
								{
									this.TitleSaveFiles.enabled = true;
									this.Speed = 0f;
									this.Phase = 3;
								}
								else if (this.Selection == 2)
								{
									this.TitleDemoChecklist.enabled = true;
									this.Speed = 0f;
									this.Phase = 4;
								}
								else if (this.Selection == 4)
								{
									this.TitleSponsor.enabled = true;
									this.Speed = 0f;
									this.Phase = 5;
								}
								else if (this.Selection == 5)
								{
									this.NewSettings.enabled = true;
									this.NewSettings.Cursor.alpha = 0f;
									this.NewSettings.Selection = 1;
									this.Speed = 0f;
									this.Phase = 6;
								}
								else if (this.Selection == 7)
								{
									if (this.ExtrasLabel.alpha == 1f)
									{
										this.Speed = 0f;
										this.Phase = 7;
									}
									else
									{
										this.PromptBar.Show = true;
									}
								}
								else if ((this.Selection == 3 && !this.Eighties) || this.Selection == 6 || this.Selection == 8)
								{
									this.FadeOut = true;
								}
								this.MyAudio.clip = this.MakeSelection;
								this.MyAudio.volume = 0.5f;
								this.MyAudio.pitch = 1f;
								this.MyAudio.Play();
							}
						}
						else if (Input.GetButtonDown("B"))
						{
							this.PromptBar.Label[1].text = "";
							this.PromptBar.Label[4].text = "";
							this.PromptBar.Label[5].text = "Change Selection";
							this.PromptBar.UpdateButtons();
							this.SpeedUpFactor = 10f;
							this.Speed = 0f;
							this.Phase = 1;
						}
					}
				}
			}
			else if (this.Phase == 3)
			{
				this.Speed += Time.deltaTime * 2f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0.125f, 0.875f, -2.66666f), Time.deltaTime * this.Speed);
				this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0.1f, 0.875f, 0f), Time.deltaTime * this.Speed);
				this.SaveFiles.alpha = Mathf.MoveTowards(this.SaveFiles.alpha, 1f, Time.deltaTime);
				this.DepthFocus = Mathf.Lerp(this.DepthFocus, 0.225f, Time.deltaTime * this.Speed);
				this.UpdateDOF(this.DepthFocus);
			}
			else if (this.Phase == 4)
			{
				this.Speed += Time.deltaTime * 2f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 29.5f, 0f), Time.deltaTime * this.Speed);
				this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0f, 0f, 0.1f), Time.deltaTime * this.Speed);
				this.DemoChecklist.alpha = Mathf.MoveTowards(this.DemoChecklist.alpha, 1f, Time.deltaTime);
				this.DepthFocus = Mathf.Lerp(this.DepthFocus, 2f, Time.deltaTime * this.Speed);
				this.UpdateDOF(this.DepthFocus);
			}
			else if (this.Phase == 5)
			{
				this.Speed += Time.deltaTime * 2f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 0.66f, -1.6f), Time.deltaTime * this.Speed);
				this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0f, 0.66f, 0f), Time.deltaTime * this.Speed);
				this.Sponsors.alpha = Mathf.MoveTowards(this.Sponsors.alpha, 1f, Time.deltaTime);
				this.DepthFocus = Mathf.Lerp(this.DepthFocus, 1f, Time.deltaTime * this.Speed);
				this.UpdateDOF(this.DepthFocus);
			}
			else if (this.Phase == 6)
			{
				this.Speed += Time.deltaTime * 2f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 0.85f, -4f), Time.deltaTime * this.Speed);
				this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0f, 0.85f, 0f), Time.deltaTime * this.Speed);
				this.Settings.alpha = Mathf.MoveTowards(this.Settings.alpha, 1f, Time.deltaTime);
				this.DepthFocus = Mathf.Lerp(this.DepthFocus, 2f, Time.deltaTime * this.Speed);
				this.UpdateDOF(this.DepthFocus);
			}
			else if (this.Phase == 7)
			{
				this.Speed += Time.deltaTime * 2f;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 2.4f, -0.5f), Time.deltaTime * this.Speed);
				this.LookAtTarget.position = Vector3.Lerp(this.LookAtTarget.position, new Vector3(0f, 2.4f, 0f), Time.deltaTime * this.Speed);
				this.DepthFocus = Mathf.Lerp(this.DepthFocus, 0.5f, Time.deltaTime * this.Speed);
				this.UpdateDOF(this.DepthFocus);
				this.CheatEntry.alpha = Mathf.MoveTowards(this.CheatEntry.alpha, 1f, Time.deltaTime);
				if (this.Speed > 3f)
				{
					if (!this.PromptBar.Show)
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[1].text = "Go Back";
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = true;
					}
					if (Input.GetKeyDown(KeyCode.Return))
					{
						if (this.CheatLabel.text == "debug" || this.CheatLabel.text == "Debug")
						{
							this.CheatLabel.text = "Type 'debug' while at school!";
							GameGlobals.Debug = true;
						}
						else if (this.CheatLabel.text == "Nice Boat")
						{
							this.CheatLabel.text = "Awwwww, you remembered!";
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.PromptBar.Show = false;
						this.Speed = 0f;
						this.Phase = 2;
					}
				}
			}
			else if (this.Phase == 8)
			{
				if (this.TitleScreenPanel.alpha > 0f)
				{
					this.TitleScreenPanel.alpha = Mathf.MoveTowards(this.TitleScreenPanel.alpha, 0f, Time.deltaTime * 2f);
				}
				else if (!this.FadeQuestion)
				{
					this.Questions[this.CurrentQuestion].alpha = Mathf.MoveTowards(this.Questions[this.CurrentQuestion].alpha, 1f, Time.deltaTime * 2f);
					if (Input.GetButtonDown("A"))
					{
						this.FadeQuestion = true;
					}
				}
				else
				{
					this.Questions[this.CurrentQuestion].alpha = Mathf.MoveTowards(this.Questions[this.CurrentQuestion].alpha, 0f, Time.deltaTime * 2f);
					if (this.Questions[this.CurrentQuestion].alpha == 0f)
					{
						this.FadeQuestion = false;
						this.CurrentQuestion++;
					}
				}
			}
		}
		else
		{
			this.PromptBar.Show = false;
			this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime * 0.5f);
			this.CurrentJukebox.volume = Mathf.MoveTowards(this.CurrentJukebox.volume, 0f, Time.deltaTime * 0.5f);
			this.FountainSFX[1].volume = Mathf.MoveTowards(this.FountainSFX[1].volume, 0f, Time.deltaTime * 0.5f);
			this.FountainSFX[2].volume = Mathf.MoveTowards(this.FountainSFX[2].volume, 0f, Time.deltaTime * 0.5f);
			if (this.Darkness.alpha == 1f)
			{
				Time.timeScale = 1f;
				if (this.Selection == 1)
				{
					if (PlayerPrefs.GetInt("ProfileCreated_" + GameGlobals.Profile.ToString()) == 0)
					{
						PlayerPrefs.SetInt("ProfileCreated_" + GameGlobals.Profile.ToString(), 1);
						PlayerGlobals.Money = 10f;
						DateGlobals.Weekday = DayOfWeek.Sunday;
						DateGlobals.PassDays = 1;
						this.UpdateDOF(2f);
						if (this.WeekSelect)
						{
							this.SetEightiesVariables();
							GameGlobals.EightiesTutorial = false;
							SceneManager.LoadScene("WeekSelectScene");
						}
						else if (this.QuickStart)
						{
							GameGlobals.CameFromTitleScreen = true;
							SceneManager.LoadScene("CalendarScene");
						}
						else if (this.Eighties)
						{
							this.SetEightiesVariables();
							SceneManager.LoadScene("EightiesCutsceneScene");
						}
						else
						{
							StudentGlobals.FemaleUniform = 1;
							StudentGlobals.MaleUniform = 1;
							OptionGlobals.DisableTint = true;
							SceneManager.LoadScene("SenpaiScene");
						}
					}
					else if (!GameGlobals.EightiesTutorial)
					{
						if (DateGlobals.Week < 11)
						{
							GameGlobals.CameFromTitleScreen = true;
							SceneManager.LoadScene("CalendarScene");
						}
						else
						{
							SceneManager.LoadScene("LoadingScene");
						}
					}
					else
					{
						SceneManager.LoadScene("EightiesCutsceneScene");
					}
				}
				else if (this.Selection == 3)
				{
					SceneManager.LoadScene("MissionModeScene");
				}
				else if (this.Selection == 6)
				{
					SceneManager.LoadScene("CreditsScene");
				}
				else if (this.Selection == 8)
				{
					Application.Quit();
				}
			}
		}
		base.transform.LookAt(this.LookAtTarget);
	}

	// Token: 0x06001A19 RID: 6681 RVA: 0x0011212C File Offset: 0x0011032C
	private void UpdateBloom(float Intensity, float Radius)
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.intensity = Intensity;
		settings.bloom.radius = Radius;
		settings.bloom.softKnee = 1f;
		this.Profile.bloom.settings = settings;
		settings.bloom.softKnee = 1f;
	}

	// Token: 0x06001A1A RID: 6682 RVA: 0x00112198 File Offset: 0x00110398
	private void UpdateDOF(float Focus)
	{
		Focus *= ((float)Screen.width / 1280f + (float)Screen.height / 720f) * 0.5f;
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x06001A1B RID: 6683 RVA: 0x001121F4 File Offset: 0x001103F4
	private void ResetVignette()
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		settings.color = new Color(1f, 0.75f, 1f);
		ChromaticAberrationModel.Settings settings2 = this.Profile.chromaticAberration.settings;
		settings2.intensity = 0.1f;
		this.Profile.vignette.settings = settings;
		this.Profile.chromaticAberration.settings = settings2;
	}

	// Token: 0x06001A1C RID: 6684 RVA: 0x0011226C File Offset: 0x0011046C
	private void UpdateCursor()
	{
		if (this.Selection > this.Options)
		{
			this.Selection = 1;
		}
		else if (this.Selection < 1)
		{
			this.Selection = this.Options;
		}
		if (this.Selection == 1)
		{
			this.PositionX = 0;
		}
		else if (this.Selection == 2)
		{
			this.PositionX = 20;
		}
		else
		{
			this.PositionX = 40 + this.Selection * 10;
		}
		this.MyAudio.clip = this.MoveCursor;
		this.MyAudio.volume = 0.5f;
		this.MyAudio.pitch = 1f;
		this.MyAudio.Play();
	}

	// Token: 0x06001A1D RID: 6685 RVA: 0x00112318 File Offset: 0x00110518
	private void EnableEightiesEffects()
	{
		GameObjectUtils.SetLayerRecursively(this.EightiesLogo.transform.parent.gameObject, 5);
		RenderSettings.skybox = this.VaporwaveSkybox;
		this.VaporwaveVisuals.ApplyNormalView();
		this.EightiesEffects.enabled = true;
		this.CurrentJukebox = this.EightiesJukebox;
		this.EightiesJukebox.volume = 0.5f;
		this.Jukebox.volume = 0f;
		this.MissionModeLabel.alpha = 0.5f;
		this.EightiesLogo.gameObject.SetActive(true);
		this.Osana.gameObject.SetActive(false);
		this.NormalLogo.SetActive(false);
		this.HeartPanel.SetActive(true);
		this.DemoText.SetActive(false);
		this.AyanoHair.SetActive(false);
		this.RyobaHair.SetActive(true);
		this.EightiesFilter.SetActive(true);
		this.PalmTrees.SetActive(true);
		this.Trees.SetActive(false);
		this.ChangeTextOutline();
		this.ExtrasLabel.alpha = 1f;
		this.PressStart.trueTypeFont = this.VCR;
		GameGlobals.Profile = 11;
		GameGlobals.Eighties = true;
		this.TitleSaveFiles.EightiesPrefix = 10;
		this.TitleSaveFiles.SaveDatas[1].ID = 11;
		this.TitleSaveFiles.SaveDatas[2].ID = 12;
		this.TitleSaveFiles.SaveDatas[3].ID = 13;
		this.TitleSaveFiles.SaveDatas[1].Start();
		this.TitleSaveFiles.SaveDatas[2].Start();
		this.TitleSaveFiles.SaveDatas[3].Start();
		this.YandereRenderer.sharedMesh = this.ModernUniform;
		this.UpdateBloodyStatus();
	}

	// Token: 0x06001A1E RID: 6686 RVA: 0x001124EC File Offset: 0x001106EC
	private void DisableEightiesEffects()
	{
		GameObjectUtils.SetLayerRecursively(this.EightiesLogo.transform.parent.gameObject, 0);
		RenderSettings.skybox = this.NormalSkybox;
		this.VaporwaveVisuals.DisableNormalView();
		this.EightiesEffects.enabled = false;
		this.CurrentJukebox = this.Jukebox;
		this.EightiesJukebox.volume = 0f;
		this.Jukebox.volume = 0.5f;
		this.MissionModeLabel.alpha = 1f;
		this.EightiesLogo.gameObject.SetActive(false);
		this.Osana.gameObject.SetActive(true);
		this.HeartPanel.SetActive(false);
		this.NormalLogo.SetActive(true);
		this.DemoText.SetActive(true);
		this.AyanoHair.SetActive(true);
		this.RyobaHair.SetActive(false);
		this.EightiesFilter.SetActive(false);
		this.PalmTrees.SetActive(false);
		this.Trees.SetActive(true);
		this.ChangeTextOutline();
		this.ExtrasLabel.alpha = 1f;
		GameGlobals.Profile = 1;
		GameGlobals.Eighties = false;
		this.TitleSaveFiles.EightiesPrefix = 0;
		this.TitleSaveFiles.SaveDatas[1].ID = 1;
		this.TitleSaveFiles.SaveDatas[2].ID = 2;
		this.TitleSaveFiles.SaveDatas[3].ID = 3;
		this.TitleSaveFiles.SaveDatas[1].Start();
		this.TitleSaveFiles.SaveDatas[2].Start();
		this.TitleSaveFiles.SaveDatas[3].Start();
		this.YandereRenderer.sharedMesh = this.EightiesUniform;
		this.UpdateBloodyStatus();
	}

	// Token: 0x06001A1F RID: 6687 RVA: 0x001126A8 File Offset: 0x001108A8
	private void ChangeTextOutline()
	{
		foreach (UILabel uilabel in UnityEngine.Object.FindObjectsOfType<UILabel>())
		{
			if (this.Eighties)
			{
				uilabel.effectColor = new Color(0f, 0f, 0f);
			}
			else
			{
				uilabel.effectColor = new Color(1f, 0.5f, 1f);
				this.TitleSaveFiles.UpdateOutlines();
			}
		}
	}

	// Token: 0x06001A20 RID: 6688 RVA: 0x00112718 File Offset: 0x00110918
	private void SetEightiesVariables()
	{
		GameGlobals.EightiesTutorial = true;
		GameGlobals.Eighties = true;
		for (int i = 1; i < 101; i++)
		{
			StudentGlobals.SetStudentPhotographed(i, true);
		}
		StudentGlobals.FemaleUniform = 6;
		StudentGlobals.MaleUniform = 1;
		DateGlobals.Weekday = DayOfWeek.Saturday;
	}

	// Token: 0x06001A21 RID: 6689 RVA: 0x00112758 File Offset: 0x00110958
	private void UpdateBloodyStatus()
	{
		if (PlayerGlobals.Kills > 0 || (GameGlobals.RivalEliminationID > 0 && !GameGlobals.NonlethalElimination))
		{
			this.BloodProjector.SetActive(true);
			this.LoveLetter.SetActive(false);
			this.Knife.SetActive(true);
			return;
		}
		this.BloodProjector.SetActive(false);
		this.LoveLetter.SetActive(true);
		this.Knife.SetActive(false);
	}

	// Token: 0x06001A22 RID: 6690 RVA: 0x001127C8 File Offset: 0x001109C8
	private void LateUpdate()
	{
		if (this.ID < this.Letter.Length && Input.GetKeyDown(this.Letter[this.ID]))
		{
			this.ID++;
			if (this.ID == this.Letter.Length)
			{
				this.PikaLoliMode.SetActive(true);
				GameGlobals.VtuberID = 1;
				this.UpdateModeDescLabels();
			}
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.Spaces++;
			if (this.Spaces > 19)
			{
				this.PikaLoliMode.SetActive(true);
				GameGlobals.VtuberID = 1;
				this.UpdateModeDescLabels();
			}
		}
	}

	// Token: 0x06001A23 RID: 6691 RVA: 0x00112868 File Offset: 0x00110A68
	private void UpdateModeDescLabels()
	{
		this.ModeDescLabel[1].text = "Play as " + this.VtuberNames[GameGlobals.VtuberID] + " in the year 2023.\n\nThis mode is still in development, and currently only features one rival girl.";
		this.ModeDescLabel[2].text = "Play as " + this.VtuberNames[GameGlobals.VtuberID] + " in the year 1989.\n\nThis mode is complete, and features ten rival girls.";
		this.VtuberHairs[GameGlobals.VtuberID].SetActive(true);
		this.RyobaHair.transform.position = new Vector3(0f, 100f, 0f);
		this.AyanoHair.transform.position = new Vector3(0f, 100f, 0f);
	}

	// Token: 0x04002A26 RID: 10790
	public CameraFilterPack_TV_Vignetting Vignette;

	// Token: 0x04002A27 RID: 10791
	public SelectiveGrayscale Grayscale;

	// Token: 0x04002A28 RID: 10792
	public TitleScreenOsanaScript Osana;

	// Token: 0x04002A29 RID: 10793
	public TitleDemoChecklistScript TitleDemoChecklist;

	// Token: 0x04002A2A RID: 10794
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x04002A2B RID: 10795
	public InputManagerScript InputManager;

	// Token: 0x04002A2C RID: 10796
	public TitleSponsorScript TitleSponsor;

	// Token: 0x04002A2D RID: 10797
	public NewSettingsScript NewSettings;

	// Token: 0x04002A2E RID: 10798
	public InputDeviceScript InputDevice;

	// Token: 0x04002A2F RID: 10799
	public PromptBarScript PromptBar;

	// Token: 0x04002A30 RID: 10800
	public PostProcessingProfile Profile;

	// Token: 0x04002A31 RID: 10801
	public Animation YandereAnimation;

	// Token: 0x04002A32 RID: 10802
	public GameObject CongratulationsWindow;

	// Token: 0x04002A33 RID: 10803
	public GameObject BloodProjector;

	// Token: 0x04002A34 RID: 10804
	public GameObject LoveLetter;

	// Token: 0x04002A35 RID: 10805
	public GameObject Knife;

	// Token: 0x04002A36 RID: 10806
	public AudioSource[] FountainSFX;

	// Token: 0x04002A37 RID: 10807
	public AudioSource Jukebox;

	// Token: 0x04002A38 RID: 10808
	public AudioSource MyAudio;

	// Token: 0x04002A39 RID: 10809
	public AudioClip SpookyEightiesMusic;

	// Token: 0x04002A3A RID: 10810
	public AudioClip SpookyMusic;

	// Token: 0x04002A3B RID: 10811
	public Transform LookAtTarget;

	// Token: 0x04002A3C RID: 10812
	public UIPanel TitleScreenPanel;

	// Token: 0x04002A3D RID: 10813
	public UISprite EightiesWindow;

	// Token: 0x04002A3E RID: 10814
	public UISprite DemoWindow;

	// Token: 0x04002A3F RID: 10815
	public UISprite DemoChecklist;

	// Token: 0x04002A40 RID: 10816
	public UISprite ModeSelection;

	// Token: 0x04002A41 RID: 10817
	public UISprite CheatEntry;

	// Token: 0x04002A42 RID: 10818
	public UISprite SaveFiles;

	// Token: 0x04002A43 RID: 10819
	public UISprite Darkness;

	// Token: 0x04002A44 RID: 10820
	public UISprite Settings;

	// Token: 0x04002A45 RID: 10821
	public UISprite Sponsors;

	// Token: 0x04002A46 RID: 10822
	public UISprite Cursor;

	// Token: 0x04002A47 RID: 10823
	public UILabel[] Questions;

	// Token: 0x04002A48 RID: 10824
	public UILabel ExtrasLabel;

	// Token: 0x04002A49 RID: 10825
	public UILabel CheatLabel;

	// Token: 0x04002A4A RID: 10826
	public UILabel PressStart;

	// Token: 0x04002A4B RID: 10827
	public UILabel DebugLog;

	// Token: 0x04002A4C RID: 10828
	public AudioClip Whoosh;

	// Token: 0x04002A4D RID: 10829
	public float BloomIntensity = 40f;

	// Token: 0x04002A4E RID: 10830
	public float SpeedUpFactor = 1f;

	// Token: 0x04002A4F RID: 10831
	public float BloomRadius = 7f;

	// Token: 0x04002A50 RID: 10832
	public float DepthFocus = 2f;

	// Token: 0x04002A51 RID: 10833
	public float Speed = 1f;

	// Token: 0x04002A52 RID: 10834
	public float DebugTimer;

	// Token: 0x04002A53 RID: 10835
	public int CurrentQuestion = 1;

	// Token: 0x04002A54 RID: 10836
	public int PositionX;

	// Token: 0x04002A55 RID: 10837
	public int Selection = 1;

	// Token: 0x04002A56 RID: 10838
	public int Options = 7;

	// Token: 0x04002A57 RID: 10839
	public int Frame;

	// Token: 0x04002A58 RID: 10840
	public int Phase = 1;

	// Token: 0x04002A59 RID: 10841
	public int Log;

	// Token: 0x04002A5A RID: 10842
	public bool FadeQuestion;

	// Token: 0x04002A5B RID: 10843
	public bool QuickStart;

	// Token: 0x04002A5C RID: 10844
	public bool WeekSelect;

	// Token: 0x04002A5D RID: 10845
	public bool Eighties;

	// Token: 0x04002A5E RID: 10846
	public bool ForVideo;

	// Token: 0x04002A5F RID: 10847
	public bool FadeOut;

	// Token: 0x04002A60 RID: 10848
	public AudioClip MakeSelection;

	// Token: 0x04002A61 RID: 10849
	public AudioClip MoveCursor;

	// Token: 0x04002A62 RID: 10850
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04002A63 RID: 10851
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x04002A64 RID: 10852
	public AudioSource EightiesJukebox;

	// Token: 0x04002A65 RID: 10853
	public AudioSource CurrentJukebox;

	// Token: 0x04002A66 RID: 10854
	public Material VaporwaveSkybox;

	// Token: 0x04002A67 RID: 10855
	public UILabel MissionModeLabel;

	// Token: 0x04002A68 RID: 10856
	public UITexture EightiesLogo;

	// Token: 0x04002A69 RID: 10857
	public GameObject HeartPanel;

	// Token: 0x04002A6A RID: 10858
	public GameObject PalmTrees;

	// Token: 0x04002A6B RID: 10859
	public GameObject DemoText;

	// Token: 0x04002A6C RID: 10860
	public GameObject Trees;

	// Token: 0x04002A6D RID: 10861
	public GameObject AyanoHair;

	// Token: 0x04002A6E RID: 10862
	public GameObject RyobaHair;

	// Token: 0x04002A6F RID: 10863
	public SkinnedMeshRenderer YandereRenderer;

	// Token: 0x04002A70 RID: 10864
	public GameObject EightiesFilter;

	// Token: 0x04002A71 RID: 10865
	public GameObject NormalLogo;

	// Token: 0x04002A72 RID: 10866
	public Material NormalSkybox;

	// Token: 0x04002A73 RID: 10867
	public Mesh EightiesUniform;

	// Token: 0x04002A74 RID: 10868
	public Mesh ModernUniform;

	// Token: 0x04002A75 RID: 10869
	public Font Futura;

	// Token: 0x04002A76 RID: 10870
	public Font VCR;

	// Token: 0x04002A77 RID: 10871
	public string[] EightiesRivalNames;

	// Token: 0x04002A78 RID: 10872
	public string[] RivalNames;

	// Token: 0x04002A79 RID: 10873
	public GameObject PikaLoliMode;

	// Token: 0x04002A7A RID: 10874
	public string[] Letter;

	// Token: 0x04002A7B RID: 10875
	public int ID;

	// Token: 0x04002A7C RID: 10876
	public string[] VtuberNames;

	// Token: 0x04002A7D RID: 10877
	public UILabel[] ModeDescLabel;

	// Token: 0x04002A7E RID: 10878
	public GameObject[] VtuberHairs;

	// Token: 0x04002A7F RID: 10879
	public int Spaces;
}
