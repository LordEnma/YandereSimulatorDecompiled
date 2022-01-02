using System;
using RetroAesthetics;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000376 RID: 886
public class NewTitleScreenScript : MonoBehaviour
{
	// Token: 0x060019E4 RID: 6628 RVA: 0x0010D51C File Offset: 0x0010B71C
	private void Start()
	{
		MissionModeGlobals.MissionMode = false;
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
		if (PlayerGlobals.Kills > 0 || (GameGlobals.RivalEliminationID > 0 && !GameGlobals.NonlethalElimination))
		{
			this.BloodProjector.SetActive(true);
			this.LoveLetter.SetActive(false);
			this.Knife.SetActive(true);
		}
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
			PlayerPrefs.SetInt("UnlockedDebugMode", 1);
		}
		if (PlayerPrefs.GetInt("UnlockedDebugMode") == 1)
		{
			this.ExtrasLabel.alpha = 1f;
		}
		this.EightiesLogo.alpha = 0f;
	}

	// Token: 0x060019E5 RID: 6629 RVA: 0x0010D7E8 File Offset: 0x0010B9E8
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
						OptionGlobals.EnableShadows = false;
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

	// Token: 0x060019E6 RID: 6630 RVA: 0x0010ECFC File Offset: 0x0010CEFC
	private void UpdateBloom(float Intensity, float Radius)
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.intensity = Intensity;
		settings.bloom.radius = Radius;
		settings.bloom.softKnee = 1f;
		this.Profile.bloom.settings = settings;
		settings.bloom.softKnee = 1f;
	}

	// Token: 0x060019E7 RID: 6631 RVA: 0x0010ED68 File Offset: 0x0010CF68
	private void UpdateDOF(float Focus)
	{
		Focus *= ((float)Screen.width / 1280f + (float)Screen.height / 720f) * 0.5f;
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x060019E8 RID: 6632 RVA: 0x0010EDC4 File Offset: 0x0010CFC4
	private void ResetVignette()
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		settings.color = new Color(1f, 0.75f, 1f);
		ChromaticAberrationModel.Settings settings2 = this.Profile.chromaticAberration.settings;
		settings2.intensity = 0.1f;
		this.Profile.vignette.settings = settings;
		this.Profile.chromaticAberration.settings = settings2;
	}

	// Token: 0x060019E9 RID: 6633 RVA: 0x0010EE3C File Offset: 0x0010D03C
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

	// Token: 0x060019EA RID: 6634 RVA: 0x0010EEE8 File Offset: 0x0010D0E8
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
		this.ExtrasLabel.alpha = 0.5f;
		if (PlayerPrefs.GetInt("UnlockedDebugMode") == 1)
		{
			this.ExtrasLabel.alpha = 1f;
		}
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
	}

	// Token: 0x060019EB RID: 6635 RVA: 0x0010F0D4 File Offset: 0x0010D2D4
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
		this.ExtrasLabel.alpha = 0.5f;
		if (PlayerPrefs.GetInt("UnlockedDebugMode") == 1)
		{
			this.ExtrasLabel.alpha = 1f;
		}
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
	}

	// Token: 0x060019EC RID: 6636 RVA: 0x0010F2A8 File Offset: 0x0010D4A8
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

	// Token: 0x060019ED RID: 6637 RVA: 0x0010F318 File Offset: 0x0010D518
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
		OptionGlobals.DisableTint = false;
		DateGlobals.Weekday = DayOfWeek.Saturday;
	}

	// Token: 0x0400299F RID: 10655
	public CameraFilterPack_TV_Vignetting Vignette;

	// Token: 0x040029A0 RID: 10656
	public SelectiveGrayscale Grayscale;

	// Token: 0x040029A1 RID: 10657
	public TitleScreenOsanaScript Osana;

	// Token: 0x040029A2 RID: 10658
	public TitleDemoChecklistScript TitleDemoChecklist;

	// Token: 0x040029A3 RID: 10659
	public TitleSaveFilesScript TitleSaveFiles;

	// Token: 0x040029A4 RID: 10660
	public InputManagerScript InputManager;

	// Token: 0x040029A5 RID: 10661
	public TitleSponsorScript TitleSponsor;

	// Token: 0x040029A6 RID: 10662
	public NewSettingsScript NewSettings;

	// Token: 0x040029A7 RID: 10663
	public InputDeviceScript InputDevice;

	// Token: 0x040029A8 RID: 10664
	public PromptBarScript PromptBar;

	// Token: 0x040029A9 RID: 10665
	public PostProcessingProfile Profile;

	// Token: 0x040029AA RID: 10666
	public Animation YandereAnimation;

	// Token: 0x040029AB RID: 10667
	public GameObject CongratulationsWindow;

	// Token: 0x040029AC RID: 10668
	public GameObject BloodProjector;

	// Token: 0x040029AD RID: 10669
	public GameObject LoveLetter;

	// Token: 0x040029AE RID: 10670
	public GameObject Knife;

	// Token: 0x040029AF RID: 10671
	public AudioSource[] FountainSFX;

	// Token: 0x040029B0 RID: 10672
	public AudioSource Jukebox;

	// Token: 0x040029B1 RID: 10673
	public AudioSource MyAudio;

	// Token: 0x040029B2 RID: 10674
	public AudioClip SpookyEightiesMusic;

	// Token: 0x040029B3 RID: 10675
	public AudioClip SpookyMusic;

	// Token: 0x040029B4 RID: 10676
	public Transform LookAtTarget;

	// Token: 0x040029B5 RID: 10677
	public UIPanel TitleScreenPanel;

	// Token: 0x040029B6 RID: 10678
	public UISprite EightiesWindow;

	// Token: 0x040029B7 RID: 10679
	public UISprite DemoWindow;

	// Token: 0x040029B8 RID: 10680
	public UISprite DemoChecklist;

	// Token: 0x040029B9 RID: 10681
	public UISprite ModeSelection;

	// Token: 0x040029BA RID: 10682
	public UISprite CheatEntry;

	// Token: 0x040029BB RID: 10683
	public UISprite SaveFiles;

	// Token: 0x040029BC RID: 10684
	public UISprite Darkness;

	// Token: 0x040029BD RID: 10685
	public UISprite Settings;

	// Token: 0x040029BE RID: 10686
	public UISprite Sponsors;

	// Token: 0x040029BF RID: 10687
	public UISprite Cursor;

	// Token: 0x040029C0 RID: 10688
	public UILabel[] Questions;

	// Token: 0x040029C1 RID: 10689
	public UILabel ExtrasLabel;

	// Token: 0x040029C2 RID: 10690
	public UILabel CheatLabel;

	// Token: 0x040029C3 RID: 10691
	public UILabel PressStart;

	// Token: 0x040029C4 RID: 10692
	public UILabel DebugLog;

	// Token: 0x040029C5 RID: 10693
	public AudioClip Whoosh;

	// Token: 0x040029C6 RID: 10694
	public float BloomIntensity = 40f;

	// Token: 0x040029C7 RID: 10695
	public float SpeedUpFactor = 1f;

	// Token: 0x040029C8 RID: 10696
	public float BloomRadius = 7f;

	// Token: 0x040029C9 RID: 10697
	public float DepthFocus = 2f;

	// Token: 0x040029CA RID: 10698
	public float Speed = 1f;

	// Token: 0x040029CB RID: 10699
	public float DebugTimer;

	// Token: 0x040029CC RID: 10700
	public int CurrentQuestion = 1;

	// Token: 0x040029CD RID: 10701
	public int PositionX;

	// Token: 0x040029CE RID: 10702
	public int Selection = 1;

	// Token: 0x040029CF RID: 10703
	public int Options = 7;

	// Token: 0x040029D0 RID: 10704
	public int Frame;

	// Token: 0x040029D1 RID: 10705
	public int Phase = 1;

	// Token: 0x040029D2 RID: 10706
	public int Log;

	// Token: 0x040029D3 RID: 10707
	public bool FadeQuestion;

	// Token: 0x040029D4 RID: 10708
	public bool QuickStart;

	// Token: 0x040029D5 RID: 10709
	public bool WeekSelect;

	// Token: 0x040029D6 RID: 10710
	public bool Eighties;

	// Token: 0x040029D7 RID: 10711
	public bool ForVideo;

	// Token: 0x040029D8 RID: 10712
	public bool FadeOut;

	// Token: 0x040029D9 RID: 10713
	public AudioClip MakeSelection;

	// Token: 0x040029DA RID: 10714
	public AudioClip MoveCursor;

	// Token: 0x040029DB RID: 10715
	public RetroCameraEffect EightiesEffects;

	// Token: 0x040029DC RID: 10716
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x040029DD RID: 10717
	public AudioSource EightiesJukebox;

	// Token: 0x040029DE RID: 10718
	public AudioSource CurrentJukebox;

	// Token: 0x040029DF RID: 10719
	public Material VaporwaveSkybox;

	// Token: 0x040029E0 RID: 10720
	public UILabel MissionModeLabel;

	// Token: 0x040029E1 RID: 10721
	public UITexture EightiesLogo;

	// Token: 0x040029E2 RID: 10722
	public GameObject HeartPanel;

	// Token: 0x040029E3 RID: 10723
	public GameObject PalmTrees;

	// Token: 0x040029E4 RID: 10724
	public GameObject DemoText;

	// Token: 0x040029E5 RID: 10725
	public GameObject Trees;

	// Token: 0x040029E6 RID: 10726
	public GameObject AyanoHair;

	// Token: 0x040029E7 RID: 10727
	public GameObject RyobaHair;

	// Token: 0x040029E8 RID: 10728
	public SkinnedMeshRenderer YandereRenderer;

	// Token: 0x040029E9 RID: 10729
	public GameObject EightiesFilter;

	// Token: 0x040029EA RID: 10730
	public GameObject NormalLogo;

	// Token: 0x040029EB RID: 10731
	public Material NormalSkybox;

	// Token: 0x040029EC RID: 10732
	public Mesh EightiesUniform;

	// Token: 0x040029ED RID: 10733
	public Mesh ModernUniform;

	// Token: 0x040029EE RID: 10734
	public Font Futura;

	// Token: 0x040029EF RID: 10735
	public Font VCR;

	// Token: 0x040029F0 RID: 10736
	public string[] EightiesRivalNames;

	// Token: 0x040029F1 RID: 10737
	public string[] RivalNames;
}
