using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000483 RID: 1155
public class TutorialScript : MonoBehaviour
{
	// Token: 0x06001ED9 RID: 7897 RVA: 0x001B0AC4 File Offset: 0x001AECC4
	private void Start()
	{
		if (!GameGlobals.EightiesTutorial)
		{
			base.gameObject.SetActive(false);
			return;
		}
		Debug.Log("The game believes that we are currently in the 1980s Mode tutorial sequence.");
		this.Yandere.NotificationManager.transform.localPosition = new Vector3(0f, 100f, 0f);
		this.Yandere.RightFootprintSpawner.MyCollider.enabled = false;
		this.Yandere.LeftFootprintSpawner.MyCollider.enabled = false;
		this.MainCamera.clearFlags = CameraClearFlags.Color;
		this.MainCamera.backgroundColor = new Color(1f, 1f, 1f, 1f);
		RenderSettings.fogColor = new Color(1f, 1f, 1f, 1f);
		RenderSettings.fogMode = FogMode.Exponential;
		RenderSettings.fogDensity = 0.1f;
		this.ExitWindow.localScale = new Vector3(0f, 0f, 0f);
		this.Yandere.Incinerator.CannotIncinerate = true;
		this.Yandere.Incinerator.enabled = false;
		this.Yandere.CameraEffects.EnableBloom();
		this.Yandere.HeartCamera.enabled = false;
		this.Yandere.CanMove = false;
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
		this.PhantomGirlOutline.transform.position = new Vector3(0f, 1000f, 0f);
		this.PhantomGirlOutline.SetActive(false);
		this.StudentManager.Graffiti[1].transform.parent.gameObject.SetActive(false);
		this.HeartbeatCamera.SetActive(false);
		this.OutOfOrderSign.SetActive(false);
		this.PauseScreen.SetActive(false);
		this.Blocker[1].SetActive(true);
		this.Blocker[2].SetActive(true);
		this.Jukebox.SetActive(false);
		this.FPSBG.SetActive(false);
		this.FPS.SetActive(false);
		this.WoodChipper[0].enabled = false;
		this.WoodChipper[1].enabled = false;
		this.WoodChipper[0].Prompt.Hide();
		this.WoodChipper[1].Prompt.Hide();
		this.WoodChipper[0].BucketPrompt.Hide();
		this.WoodChipper[0].Prompt.enabled = false;
		this.WoodChipper[1].Prompt.enabled = false;
		this.WoodChipper[0].BucketPrompt.enabled = false;
		this.VictimPrompt.Hide();
		this.VictimPrompt.enabled = false;
		this.VictimGirl.SetActive(false);
		this.MainCamera.farClipPlane = 50f;
		this.Yandere.WeaponManager.DisableAllWeapons();
		this.Knife.gameObject.SetActive(true);
		this.Knife.Prompt.enabled = false;
		this.Knife.Prompt.Hide();
		this.InstructionLabel.alpha = 0f;
		this.UpdateInstructionText();
		this.Clock.BloomFadeSpeed = 5f;
		this.Clock.StopTime = true;
		this.Clock.BloomWait = 1f;
		this.Knife.Undroppable = true;
		this.SubtitleLabel.text = "";
		this.ReputationHUD.alpha = 0f;
		this.SanityHUD.alpha = 0f;
		this.ClockHUD.alpha = 0f;
		for (int i = 1; i < this.PromptsToDisable.Length; i++)
		{
			this.PromptsToDisable[i].Hide();
			this.PromptsToDisable[i].enabled = false;
		}
	}

	// Token: 0x06001EDA RID: 7898 RVA: 0x001B0EA4 File Offset: 0x001AF0A4
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
		{
			this.TogglePauseScreen();
		}
		if (this.Pause)
		{
			if (Input.GetButtonDown("A"))
			{
				this.EightiesEffectsEnabled = !this.EightiesEffectsEnabled;
				OptionGlobals.DisableStatic = !this.EightiesEffectsEnabled;
				OptionGlobals.DisableDisplacement = !this.EightiesEffectsEnabled;
				OptionGlobals.DisableAbberation = !this.EightiesEffectsEnabled;
				OptionGlobals.DisableVignette = !this.EightiesEffectsEnabled;
				OptionGlobals.DisableDistortion = !this.EightiesEffectsEnabled;
				OptionGlobals.DisableScanlines = true;
				OptionGlobals.DisableNoise = !this.EightiesEffectsEnabled;
				OptionGlobals.DisableTint = !this.EightiesEffectsEnabled;
				this.EightiesEffectEnabler.UpdateEightiesEffects();
				this.TogglePauseScreen();
			}
			else if (Input.GetButtonDown("Y"))
			{
				this.Phase = 54;
				this.TogglePauseScreen();
				Time.timeScale = 5f;
			}
			else if (Input.GetButtonDown("X"))
			{
				this.ReturnToTitleScreen = true;
				this.Phase = 54;
				this.TogglePauseScreen();
				Time.timeScale = 5f;
			}
			else if (Input.GetButtonDown("B"))
			{
				this.TogglePauseScreen();
			}
		}
		if (!this.Clock.UpdateBloom)
		{
			if (!this.Cutscene)
			{
				if (this.Phase > 51 && this.Phase < 54)
				{
					this.ClockHUD.alpha = Mathf.MoveTowards(this.ClockHUD.alpha, 1f, Time.deltaTime);
				}
				else if (this.Phase > 47)
				{
					this.ReputationHUD.alpha = Mathf.MoveTowards(this.ReputationHUD.alpha, 1f, Time.deltaTime);
				}
				else if (this.Phase > 46)
				{
					this.StudentManager.Students[25].Witnessed = StudentWitnessType.Tutorial;
				}
				else if (this.Phase > 45)
				{
					if (this.StudentManager.Students[2] != null)
					{
						this.StudentManager.Students[2].Pathfinding.target = this.Destination[47];
						this.StudentManager.Students[2].CurrentDestination = this.Destination[47];
					}
				}
				else if (this.Phase > 44)
				{
					this.SanityHUD.alpha = Mathf.MoveTowards(this.SanityHUD.alpha, 1f, Time.deltaTime);
				}
				else if (this.Phase == 15 && !this.CanPickUp)
				{
					this.StudentManager.Students[2].CharacterAnimation.Play("f02_knifeStealthB_00");
					this.StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].time = this.StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].length;
				}
				if (this.Phase > 53)
				{
					this.BGM[1].volume = Mathf.MoveTowards(this.BGM[1].volume, 0f, Time.deltaTime * 0.2f);
				}
				else if (this.Phase > 52)
				{
					if (!this.MyAudio.isPlaying)
					{
						this.BGM[1].volume = Mathf.MoveTowards(this.BGM[1].volume, 1f, Time.deltaTime * 0.2f);
					}
					else
					{
						this.BGM[1].volume = Mathf.MoveTowards(this.BGM[1].volume, 0.5f, Time.deltaTime * 0.2f);
					}
					this.BGM[2].volume = Mathf.MoveTowards(this.BGM[2].volume, 0f, Time.deltaTime * 0.2f);
				}
				else if (this.Phase > 45)
				{
					if (!this.MyAudio.isPlaying)
					{
						this.BGM[2].volume = Mathf.MoveTowards(this.BGM[2].volume, 1f, Time.deltaTime * 0.2f);
					}
					else
					{
						this.BGM[2].volume = Mathf.MoveTowards(this.BGM[2].volume, 0.5f, Time.deltaTime * 0.2f);
					}
					this.BGM[3].volume = Mathf.MoveTowards(this.BGM[3].volume, 0f, Time.deltaTime * 0.2f);
				}
				else if (this.Phase > 13)
				{
					this.BGM[2].volume = Mathf.MoveTowards(this.BGM[2].volume, 0f, Time.deltaTime * 0.2f);
					if (!this.MyAudio.isPlaying)
					{
						this.BGM[3].volume = Mathf.MoveTowards(this.BGM[3].volume, 1f, Time.deltaTime * 0.2f);
					}
					else
					{
						this.BGM[3].volume = Mathf.MoveTowards(this.BGM[3].volume, 0.5f, Time.deltaTime * 0.2f);
					}
				}
				else if (this.Phase > 5)
				{
					this.BGM[1].volume = Mathf.MoveTowards(this.BGM[1].volume, 0f, Time.deltaTime * 0.2f);
					if (!this.MyAudio.isPlaying)
					{
						this.BGM[2].volume = Mathf.MoveTowards(this.BGM[2].volume, 1f, Time.deltaTime * 0.2f);
					}
					else
					{
						this.BGM[2].volume = Mathf.MoveTowards(this.BGM[2].volume, 0.5f, Time.deltaTime * 0.2f);
					}
				}
				else if (!this.MyAudio.isPlaying)
				{
					this.BGM[1].volume = Mathf.MoveTowards(this.BGM[1].volume, 1f, Time.deltaTime * 0.2f);
				}
				else
				{
					this.BGM[1].volume = Mathf.MoveTowards(this.BGM[1].volume, 0.5f, Time.deltaTime * 0.2f);
				}
				if (this.Yandere.Laughing)
				{
					RenderSettings.fogColor = new Color((this.Yandere.Sanity - 50f) / 50f, (this.Yandere.Sanity - 50f) / 50f, (this.Yandere.Sanity - 50f) / 50f, 1f);
					this.MainCamera.backgroundColor = RenderSettings.fogColor;
				}
				if (this.FadeInstructions)
				{
					this.InstructionLabel.alpha = Mathf.MoveTowards(this.InstructionLabel.alpha, 0f, Time.deltaTime * 2f);
					if (this.InstructionLabel.alpha == 0f)
					{
						if (!this.TransitionToCutscene)
						{
							this.FadeInstructions = false;
							this.Phase++;
							if (this.InputDevice.Type == InputDeviceType.Gamepad)
							{
								this.InstructionLabel.text = this.GamepadInstructions[this.Phase];
							}
							else
							{
								this.InstructionLabel.text = this.KeyboardInstructions[this.Phase];
							}
						}
						else
						{
							this.Cutscene = true;
						}
					}
				}
				else
				{
					this.InstructionLabel.alpha = Mathf.MoveTowards(this.InstructionLabel.alpha, 1f, Time.deltaTime * 2f);
					if (this.InstructionLabel.alpha == 1f)
					{
						if (this.Phase == 1)
						{
							float axis = Input.GetAxis("Vertical");
							float axis2 = Input.GetAxis("Horizontal");
							float axis3 = Input.GetAxis("Mouse X");
							float axis4 = Input.GetAxis("Mouse Y");
							if (!this.CameraProgress && (axis != 0f || axis2 != 0f))
							{
								this.CameraProgress = true;
							}
							if (!this.MovementProgress && (axis3 != 0f || axis4 != 0f))
							{
								this.MovementProgress = true;
							}
							if ((this.CameraProgress && this.MovementProgress) || this.Yandere.transform.position.z > -50f)
							{
								if (Vector3.Distance(this.Yandere.transform.position, this.Destination[3].position) < 1f)
								{
									this.Phase += 2;
								}
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 2)
						{
							if (Input.GetButtonDown("LS") || Input.GetKeyDown("t") || Vector3.Distance(this.Yandere.transform.position, this.Destination[3].position) < 1f)
							{
								if (Vector3.Distance(this.Yandere.transform.position, this.Destination[3].position) < 1f)
								{
									this.Phase++;
								}
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 3)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 1f)
							{
								this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
								this.FadeInstructions = true;
								this.Yandere.Frozen = true;
							}
						}
						else if (this.Phase == 4)
						{
							if (this.FirstDoor.Open)
							{
								this.FadeInstructions = true;
								this.Yandere.Frozen = false;
							}
						}
						else if (this.Phase == 5)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 0.5f)
							{
								this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
								this.Knife.Prompt.enabled = true;
								this.FadeInstructions = true;
								this.Yandere.Frozen = true;
							}
						}
						else if (this.Phase == 6)
						{
							if (this.Yandere.Armed || this.Yandere.Weapon[1] != null)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 7)
						{
							if (!this.Yandere.Armed)
							{
								this.Blocker[2].SetActive(false);
								this.Blocker[3].SetActive(true);
								this.FadeInstructions = true;
								this.Yandere.Frozen = false;
							}
						}
						else if (this.Phase == 8)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 1f)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 9)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 0.5f)
							{
								this.FadeInstructions = true;
								this.Yandere.Frozen = false;
							}
						}
						else if (this.Phase == 10)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 0.5f && !this.BathroomDoor.Open)
							{
								this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
								this.Yandere.RPGCamera.enabled = false;
								this.TransitionToCutscene = true;
								this.Blocker[4].SetActive(true);
								this.FadeInstructions = true;
								this.Yandere.CanMove = false;
							}
						}
						else if (this.Phase == 11)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 1f)
							{
								this.VictimPrompt.enabled = true;
								this.FadeInstructions = true;
								this.Yandere.Frozen = true;
							}
						}
						else if (this.Phase == 12)
						{
							if (this.VictimPrompt.Circle[0].fillAmount == 0f)
							{
								this.VictimPrompt.Hide();
								this.VictimPrompt.enabled = false;
								this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
								this.InstructionLabel.alpha = 0f;
								this.FadeInstructions = true;
								this.Yandere.CanMove = false;
								this.Cutscene = true;
								this.Animator[this.Speaker[this.CutscenePhase]].CrossFade(this.Animations[this.CutscenePhase]);
								this.SubtitleLabel.text = this.Text[this.CutscenePhase];
								this.MyAudio.clip = this.Voice[this.CutscenePhase];
								this.MyAudio.Play();
							}
						}
						else if (this.Phase == 13)
						{
							if (this.Yandere.Armed)
							{
								this.WeaponMenu.enabled = false;
								this.WeaponMenu.InstantHide();
								this.VictimPrompt.enabled = true;
								this.VictimPrompt.HideButton[0] = true;
								this.VictimPrompt.HideButton[2] = false;
								this.PickUpBlocker.SetActive(true);
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 14)
						{
							if (this.VictimPrompt.Circle[2].fillAmount != 1f)
							{
								this.VictimPrompt.Hide();
								this.VictimPrompt.enabled = false;
								AudioSource.PlayClipAtPoint(this.ReversePianoNote, this.MainCamera.transform.position);
								this.Yandere.CharacterAnimation.CrossFade("f02_knifeStealthA_00");
								this.Animator[2].CrossFade("f02_knifeStealthB_00");
								this.DOF = this.Profile.depthOfField.enabled;
								this.Profile.depthOfField.enabled = false;
								this.Yandere.RPGCamera.enabled = false;
								this.PickUpBlocker.SetActive(false);
								this.InstructionLabel.alpha = 0f;
								this.WeaponMenu.enabled = true;
								this.FadeInstructions = true;
								this.Yandere.CanMove = false;
								this.Cutscene = true;
							}
						}
						else if (this.Phase == 15)
						{
							if (this.Yandere.PickUp != null && this.Yandere.PickUp.GarbageBagBox)
							{
								this.Ragdoll.Prompt.enabled = true;
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 16)
						{
							if (this.Ragdoll.Concealed)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 17)
						{
							if (this.Yandere.PickUp == null)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 18)
						{
							if (this.Yandere.PickUp != null && this.Yandere.PickUp.Bucket != null)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 19)
						{
							if (this.Yandere.PickUp != null && this.Yandere.PickUp.Bucket != null && this.Yandere.PickUp.Bucket.Full)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 20)
						{
							if (this.Yandere.PickUp == null)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 21)
						{
							if (this.Yandere.PickUp != null && this.Yandere.PickUp.Bleach)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 22)
						{
							if (this.Bucket.Bleached)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 23)
						{
							if (this.Yandere.PickUp == null)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 24)
						{
							if (this.Yandere.PickUp != null && this.Yandere.PickUp.Mop != null)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 25)
						{
							if (this.Yandere.PickUp != null && this.Yandere.PickUp.Mop != null && this.Yandere.PickUp.Mop.Bleached)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 26)
						{
							if (this.Yandere.YandereVision)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 27)
						{
							if (this.BloodParent.childCount == 0)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 28)
						{
							if (this.Yandere.PickUp == null)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 29)
						{
							if (this.Yandere.Carrying)
							{
								this.Blocker[1].SetActive(false);
								this.Blocker[3].SetActive(false);
								this.Blocker[4].SetActive(false);
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 30)
						{
							if (this.Yandere.Carrying && Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 0.5f)
							{
								this.Yandere.Incinerator.enabled = true;
								this.FadeInstructions = true;
								this.Yandere.Frozen = true;
							}
						}
						else if (this.Phase == 31)
						{
							if (this.Yandere.Dumping)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 32)
						{
							if (this.Yandere.Armed)
							{
								this.Knife.Undroppable = false;
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 33)
						{
							if (this.Knife.Dumped)
							{
								this.FadeInstructions = true;
								this.Yandere.Frozen = false;
							}
						}
						else if (this.Phase == 34)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 1f)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 35)
						{
							if (this.Locker.Open)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 36)
						{
							if (this.Yandere.Schoolwear == 0)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 37)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 0.5f)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 38)
						{
							if (this.Yandere.Bloodiness == 0f)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 39)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 1f)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 40)
						{
							if (this.Yandere.Schoolwear == 3)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 41)
						{
							if (this.Yandere.PickUp != null && this.Yandere.PickUp.Clothing)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 42)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 0.5f)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 43)
						{
							if (this.Yandere.Incinerator.BloodyClothing > 0)
							{
								this.Yandere.Incinerator.CannotIncinerate = false;
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 44)
						{
							if (this.Yandere.Incinerator.Timer > 0f)
							{
								this.FadeInstructions = true;
								this.Yandere.Frozen = true;
							}
						}
						else if (this.Phase == 45)
						{
							if (Input.GetButtonDown("A"))
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 46)
						{
							if (this.Yandere.Sanity == 100f)
							{
								if (this.StudentManager.Students[2] != null)
								{
									UnityEngine.Object.Destroy(this.StudentManager.Students[2].gameObject);
									this.StudentManager.Students[2] = null;
								}
								this.StudentManager.ForceSpawn = true;
								this.StudentManager.SpawnPositions[25] = this.Destination[this.Phase + 1].transform;
								this.StudentManager.SpawnID = 25;
								this.StudentManager.SpawnStudent(25);
								this.StudentManager.Students[25].FocusOnYandere = true;
								this.StudentManager.Students[25].Blind = true;
								this.StudentManager.Students[25].enabled = true;
								this.StudentManager.Students[25].Start();
								this.StudentManager.Students[25].OriginalIdleAnim = "f02_idleShort_01";
								this.StudentManager.Students[25].IdleAnim = "f02_idleShort_01";
								this.StudentManager.Students[25].transform.eulerAngles = new Vector3(0f, 90f, 0f);
								this.StudentManager.Students[25].Indoors = true;
								this.StudentManager.Students[25].Spawned = true;
								if (this.StudentManager.Students[25].ShoeRemoval.Locker == null)
								{
									this.StudentManager.Students[25].ShoeRemoval.Start();
								}
								this.StudentManager.Students[25].ShoeRemoval.PutOnShoes();
								this.StudentManager.StayInOneSpot(25);
								this.Blocker[5].SetActive(true);
								this.FadeInstructions = true;
								this.Yandere.Frozen = false;
							}
						}
						else if (this.Phase == 47)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 4f)
							{
								this.StudentManager.Students[25].Witnessed = StudentWitnessType.Tutorial;
								this.StudentManager.Students[25].Reputation.PendingRep -= 10f;
								this.StudentManager.Students[25].PendingRep = -10f;
								this.StudentManager.Students[25].Witness = true;
								this.StudentManager.Students[25].Alarm = 200f;
								this.Yandere.CameraEffects.Alarm();
								this.TransitionToCutscene = true;
								this.FadeInstructions = true;
								this.Yandere.Frozen = true;
							}
						}
						else if (this.Phase == 48)
						{
							if (Input.GetButtonDown("A"))
							{
								this.FadeInstructions = true;
								this.Yandere.Frozen = false;
							}
						}
						else if (this.Phase == 49)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 1f)
							{
								this.StudentManager.Students[25].Prompt.HideButton[0] = false;
								this.StudentManager.Students[25].Witness = true;
								this.FadeInstructions = true;
								this.Yandere.Frozen = true;
							}
						}
						else if (this.Phase == 50)
						{
							if (this.Yandere.Talking)
							{
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 51)
						{
							if (this.StudentManager.Students[25].Forgave && !this.Yandere.Talking)
							{
								this.StudentManager.Students[25].Reputation.PendingRep = 0f;
								this.Yandere.RPGCamera.enabled = false;
								this.MainCamera.transform.position = new Vector3(0f, 14f, -38.566666f);
								this.MainCamera.transform.eulerAngles = Vector3.zero;
								this.StudentManager.Students[25].gameObject.SetActive(false);
								this.Blocker[5].SetActive(false);
								this.MainCamera.clearFlags = CameraClearFlags.Skybox;
								this.MainCamera.farClipPlane = 350f;
								RenderSettings.fog = false;
								this.Clock.PresentTime = 1079f;
								this.FadeInstructions = true;
							}
						}
						else if (this.Phase == 52)
						{
							if (Input.GetButtonDown("A"))
							{
								this.ExitPortal.gameObject.SetActive(true);
								this.Yandere.RPGCamera.enabled = true;
								this.FadeInstructions = true;
								this.Yandere.Frozen = false;
							}
						}
						else if (this.Phase == 53)
						{
							if (this.ExitPortal.Circle[0].fillAmount == 0f)
							{
								this.InstructionLabel.gameObject.SetActive(false);
								this.Yandere.Frozen = true;
								this.Phase++;
							}
						}
						else if (this.Phase == 54)
						{
							this.TutorialFadeOut.alpha = Mathf.MoveTowards(this.TutorialFadeOut.alpha, 1f, Time.deltaTime * 0.2f);
							if (this.TutorialFadeOut.alpha == 1f)
							{
								if (!this.ReturnToTitleScreen)
								{
									GameGlobals.EightiesTutorial = false;
									GameGlobals.EightiesCutsceneID = 1;
									OptionGlobals.Fog = false;
									SceneManager.LoadScene("EightiesCutsceneScene");
								}
								else
								{
									SceneManager.LoadScene("NewTitleScene");
								}
							}
						}
					}
				}
			}
			else
			{
				if (this.CutscenePhase == 0)
				{
					this.Yandere.MainCamera.transform.position = new Vector3(25f, 9f, -29f);
					this.Yandere.MainCamera.transform.eulerAngles = new Vector3(0f, 75f, 0f);
					this.VictimGirl.SetActive(true);
					this.Animator[2].Play("f02_walkShy_00");
					this.CutscenePhase++;
				}
				else if (this.CutscenePhase == 1)
				{
					this.VictimGirl.transform.position += new Vector3(Time.deltaTime, 0f, 0f);
					this.Animator[2].CrossFade("f02_walkShy_00");
					if (Input.GetButtonDown("A"))
					{
						this.VictimGirl.transform.position = new Vector3(29.5f, 8f, -28.5f);
					}
					if (this.VictimGirl.transform.position.x >= 29.5f)
					{
						this.VictimGirl.transform.position = new Vector3(29.5f, 8f, -28.5f);
						this.SubtitleLabel.text = this.Text[this.CutscenePhase];
						this.MyAudio.clip = this.Voice[this.CutscenePhase];
						this.MyAudio.Play();
						this.Animator[2].CrossFade("f02_idleShy_00");
						this.CutscenePhase++;
					}
				}
				else if (this.CutscenePhase == 2)
				{
					if (Input.GetButtonDown("A"))
					{
						this.MyAudio.Stop();
					}
					if (!this.MyAudio.isPlaying)
					{
						this.Yandere.RPGCamera.enabled = true;
						this.TransitionToCutscene = false;
						this.SubtitleLabel.text = "";
						this.Yandere.CanMove = true;
						this.Cutscene = false;
						this.CutscenePhase++;
					}
				}
				else if (this.CutscenePhase < 7)
				{
					if (this.CutscenePhase < 5)
					{
						this.Rotation = Mathf.Lerp(this.Rotation, -90f, Time.deltaTime * 5f);
						this.VictimGirl.transform.localEulerAngles = new Vector3(0f, this.Rotation, 0f);
					}
					else
					{
						this.Rotation = Mathf.Lerp(this.Rotation, 90f, Time.deltaTime * 5f);
						this.VictimGirl.transform.localEulerAngles = new Vector3(0f, this.Rotation, 0f);
					}
					this.Yandere.MoveTowardsTarget(new Vector3(28.5f, 8f, -28.5f));
					this.Yandere.targetRotation = Quaternion.LookRotation(this.VictimGirl.transform.position - this.Yandere.transform.position);
					this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.Yandere.targetRotation, Time.deltaTime * 10f);
					if (Input.GetButtonDown("A"))
					{
						this.MyAudio.Stop();
					}
					if (this.Animator[this.Speaker[this.CutscenePhase]][this.Animations[this.CutscenePhase]].time >= this.Animator[this.Speaker[this.CutscenePhase]][this.Animations[this.CutscenePhase]].length)
					{
						if (this.Speaker[this.CutscenePhase] == 1)
						{
							this.Animator[1].CrossFade(this.Yandere.IdleAnim);
						}
						else if (this.CutscenePhase == 5)
						{
							this.Animator[2].CrossFade("f02_idleShame_00");
						}
						else
						{
							this.Animator[2].CrossFade("f02_idleShy_00");
						}
					}
					if (!this.MyAudio.isPlaying)
					{
						this.CutscenePhase++;
						if (this.CutscenePhase < 7)
						{
							this.Animator[1].CrossFade(this.Yandere.IdleAnim);
							this.Animator[2].CrossFade("f02_idleShy_00");
							this.Animator[this.Speaker[this.CutscenePhase]].CrossFade(this.Animations[this.CutscenePhase]);
							this.SubtitleLabel.text = this.Text[this.CutscenePhase];
							this.MyAudio.clip = this.Voice[this.CutscenePhase];
							this.MyAudio.Play();
						}
					}
				}
				else if (this.CutscenePhase == 7)
				{
					this.TransitionToCutscene = false;
					this.SubtitleLabel.text = "";
					this.Yandere.CanMove = true;
					this.Cutscene = false;
					this.CutscenePhase++;
				}
				else if (this.CutscenePhase == 8)
				{
					this.BGM[2].volume = Mathf.MoveTowards(this.BGM[2].volume, 0f, Time.deltaTime * 0.2f);
					this.BGM[3].volume = Mathf.MoveTowards(this.BGM[3].volume, 0f, Time.deltaTime * 0.2f);
					this.Yandere.MainCamera.transform.position = new Vector3(30f, 9.366666f, -28.5f);
					this.Yandere.MainCamera.transform.eulerAngles = new Vector3(0f, -90f, 0f);
					this.VictimGirl.transform.eulerAngles = new Vector3(0f, 90f, 0f);
					this.VictimGirl.transform.position = new Vector3(29.5f, 8f, -28.5f);
					this.Yandere.transform.position = new Vector3(28.82f, 8f, -28.5f);
					this.Yandere.EquippedWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
					this.Yandere.CharacterAnimation["f02_knifeStealthA_00"].speed = Mathf.MoveTowards(this.Yandere.CharacterAnimation["f02_knifeStealthA_00"].speed, 0.1f, Time.deltaTime);
					this.Animator[2]["f02_knifeStealthB_00"].speed = Mathf.MoveTowards(this.Animator[2]["f02_knifeStealthB_00"].speed, 0.1f, Time.deltaTime);
					if (this.Yandere.CharacterAnimation["f02_knifeStealthA_00"].time > 0.5f)
					{
						this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, 1f, Time.deltaTime);
					}
					if (this.Yandere.CharacterAnimation["f02_knifeStealthA_00"].time > this.Yandere.CharacterAnimation["f02_knifeStealthA_00"].length * 0.475f)
					{
						this.Yandere.RPGCamera.mouseX = 45f;
						this.Yandere.RPGCamera.mouseY = 45f;
						this.Yandere.RPGCamera.mouseXSmooth = -315f;
						this.Yandere.RPGCamera.mouseYSmooth = -315f;
						this.Yandere.RPGCamera.GetDesiredPosition();
						this.Yandere.RPGCamera.PositionUpdate();
						this.SubtitleLabel.text = this.Text[this.CutscenePhase];
						this.MyAudio.clip = this.Voice[this.CutscenePhase];
						this.MyAudio.Play();
						this.BGM[2].volume = 0f;
						this.BGM[3].volume = 0f;
						this.Darkness.alpha = 1f;
						this.CutscenePhase++;
					}
				}
				else if (this.CutscenePhase == 9)
				{
					if (this.StudentManager.Students[2] == null)
					{
						this.StudentManager.ForceSpawn = true;
						this.StudentManager.SpawnPositions[2] = this.VictimGirl.transform;
						this.StudentManager.SpawnID = 2;
						this.StudentManager.SpawnStudent(2);
					}
					else if (!this.StudentManager.Students[2].Ragdoll.enabled)
					{
						this.StudentManager.Students[2].CharacterAnimation.Play("f02_knifeStealthB_00");
						this.StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].time = this.StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].length;
						this.StudentManager.Students[2].transform.position = new Vector3(29.9f, 8f, -29.4f);
						this.StudentManager.Students[2].transform.eulerAngles = new Vector3(0f, -90f, 0f);
						this.StudentManager.Students[2].BecomeRagdoll();
						this.StudentManager.Students[2].Cosmetic.FemaleHair[this.StudentManager.Students[2].Cosmetic.Hairstyle].SetActive(false);
						this.StudentManager.Students[2].Cosmetic.HairRenderer = this.StudentManager.Students[2].Cosmetic.FemaleHairRenderers[57];
						this.StudentManager.Students[2].Cosmetic.FemaleHair[57].SetActive(true);
						this.StudentManager.Students[2].Cosmetic.Hairstyle = 57;
						this.Ragdoll = this.StudentManager.Students[2].Ragdoll;
					}
					if (this.MyAudio.time > this.MyAudio.clip.length - 0.2f)
					{
						this.Yandere.RPGCamera.enabled = true;
					}
					if (!this.MyAudio.isPlaying)
					{
						AudioSource.PlayClipAtPoint(this.DramaticPianoNote, this.MainCamera.transform.position);
						this.MainCamera.backgroundColor = new Color(0f, 0f, 0f, 1f);
						RenderSettings.fogColor = new Color(0f, 0f, 0f, 1f);
						this.BGM[3].volume = 0.5f;
						this.Knife.Blood.enabled = true;
						this.Knife.MurderWeapon = true;
						this.Knife.Bloody = true;
						this.Yandere.Bloodiness += 100f;
						this.Yandere.Sanity -= 50f;
						this.StudentManager.Students[2].CharacterAnimation.enabled = true;
						this.StudentManager.Students[2].CharacterAnimation.Play("f02_knifeStealthB_00");
						this.StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].time = this.StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].length;
						this.Profile.depthOfField.enabled = this.DOF;
						this.TransitionToCutscene = false;
						this.VictimGirl.SetActive(false);
						this.SubtitleLabel.text = "";
						this.Yandere.Frozen = false;
						this.Yandere.CanMove = true;
						this.Darkness.alpha = 0f;
						this.CanPickUp = true;
						this.Cutscene = false;
						this.CutscenePhase++;
					}
				}
				else if (this.CutscenePhase == 10 && this.StudentManager.Students[25].Routine)
				{
					this.TransitionToCutscene = false;
					this.Yandere.Frozen = true;
					this.Cutscene = false;
					this.CutscenePhase++;
				}
				if (this.BGM[1].volume > 0f)
				{
					this.BGM[1].volume = Mathf.MoveTowards(this.BGM[1].volume, 0.5f, Time.deltaTime);
				}
				else if (this.BGM[2].volume > 0f)
				{
					this.BGM[2].volume = Mathf.MoveTowards(this.BGM[2].volume, 0.5f, Time.deltaTime);
				}
				else if (this.BGM[3].volume > 0f)
				{
					this.BGM[3].volume = Mathf.MoveTowards(this.BGM[3].volume, 0.5f, Time.deltaTime);
				}
			}
		}
		else if (!this.MusicSynced)
		{
			this.MusicTimer += Time.deltaTime;
			if (this.MusicTimer > 1f)
			{
				this.BGM[1].time = 0f;
				this.BGM[2].time = 0f;
				this.BGM[3].time = 0f;
				this.BGM[1].Play();
				this.BGM[2].Play();
				this.BGM[3].Play();
				this.MusicSynced = true;
			}
		}
		else
		{
			this.BGM[1].volume = Mathf.MoveTowards(this.BGM[1].volume, 1f, Time.deltaTime * 0.2f);
		}
		if (this.InputDevice.Type != this.PreviousInputDevice)
		{
			this.UpdateInstructionText();
		}
	}

	// Token: 0x06001EDB RID: 7899 RVA: 0x001B38C8 File Offset: 0x001B1AC8
	private void UpdateInstructionText()
	{
		this.PreviousInputDevice = this.InputDevice.Type;
		if (this.InputDevice.Type == InputDeviceType.Gamepad)
		{
			this.InstructionLabel.text = this.GamepadInstructions[this.Phase];
			return;
		}
		this.InstructionLabel.text = this.KeyboardInstructions[this.Phase];
	}

	// Token: 0x06001EDC RID: 7900 RVA: 0x001B3928 File Offset: 0x001B1B28
	private void LateUpdate()
	{
		if (this.EyeShrink > 0f)
		{
			this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
			this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
			this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
			this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
		}
		if (this.CutscenePhase == 8)
		{
			this.RightArm.localEulerAngles += new Vector3(15f, 0f, 0f);
		}
	}

	// Token: 0x06001EDD RID: 7901 RVA: 0x001B3A90 File Offset: 0x001B1C90
	public void TogglePauseScreen()
	{
		this.Pause = !this.Pause;
		if (this.Pause)
		{
			Time.timeScale = 0f;
			this.ExitWindow.localScale = new Vector3(1f, 1f, 1f);
			return;
		}
		Time.timeScale = 1f;
		this.ExitWindow.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x0400401F RID: 16415
	public EightiesEffectEnablerScript EightiesEffectEnabler;

	// Token: 0x04004020 RID: 16416
	public StudentManagerScript StudentManager;

	// Token: 0x04004021 RID: 16417
	public InputDeviceType PreviousInputDevice;

	// Token: 0x04004022 RID: 16418
	public PostProcessingProfile Profile;

	// Token: 0x04004023 RID: 16419
	public InputDeviceScript InputDevice;

	// Token: 0x04004024 RID: 16420
	public WeaponMenuScript WeaponMenu;

	// Token: 0x04004025 RID: 16421
	public PromptScript VictimPrompt;

	// Token: 0x04004026 RID: 16422
	public UILabel InstructionLabel;

	// Token: 0x04004027 RID: 16423
	public TallLockerScript Locker;

	// Token: 0x04004028 RID: 16424
	public PromptScript ExitPortal;

	// Token: 0x04004029 RID: 16425
	public DoorScript BathroomDoor;

	// Token: 0x0400402A RID: 16426
	public RagdollScript Ragdoll;

	// Token: 0x0400402B RID: 16427
	public YandereScript Yandere;

	// Token: 0x0400402C RID: 16428
	public Transform BloodParent;

	// Token: 0x0400402D RID: 16429
	public UILabel SubtitleLabel;

	// Token: 0x0400402E RID: 16430
	public DoorScript FirstDoor;

	// Token: 0x0400402F RID: 16431
	public Transform ExitWindow;

	// Token: 0x04004030 RID: 16432
	public BucketScript Bucket;

	// Token: 0x04004031 RID: 16433
	public AudioSource MyAudio;

	// Token: 0x04004032 RID: 16434
	public WeaponScript Knife;

	// Token: 0x04004033 RID: 16435
	public Camera MainCamera;

	// Token: 0x04004034 RID: 16436
	public ClockScript Clock;

	// Token: 0x04004035 RID: 16437
	public UISprite TutorialFadeOut;

	// Token: 0x04004036 RID: 16438
	public UISprite ReputationHUD;

	// Token: 0x04004037 RID: 16439
	public UISprite SanityHUD;

	// Token: 0x04004038 RID: 16440
	public UISprite ClockHUD;

	// Token: 0x04004039 RID: 16441
	public UISprite Darkness;

	// Token: 0x0400403A RID: 16442
	public UISprite HUD;

	// Token: 0x0400403B RID: 16443
	public string[] KeyboardInstructions;

	// Token: 0x0400403C RID: 16444
	public string[] GamepadInstructions;

	// Token: 0x0400403D RID: 16445
	public string[] Animations;

	// Token: 0x0400403E RID: 16446
	public string[] Text;

	// Token: 0x0400403F RID: 16447
	public WoodChipperScript[] WoodChipper;

	// Token: 0x04004040 RID: 16448
	public PromptScript[] PromptsToDisable;

	// Token: 0x04004041 RID: 16449
	public Transform[] Destination;

	// Token: 0x04004042 RID: 16450
	public Animation[] Animator;

	// Token: 0x04004043 RID: 16451
	public GameObject[] Blocker;

	// Token: 0x04004044 RID: 16452
	public AudioSource[] BGM;

	// Token: 0x04004045 RID: 16453
	public AudioClip[] Voice;

	// Token: 0x04004046 RID: 16454
	public int[] Speaker;

	// Token: 0x04004047 RID: 16455
	public AudioClip DramaticPianoNote;

	// Token: 0x04004048 RID: 16456
	public AudioClip ReversePianoNote;

	// Token: 0x04004049 RID: 16457
	public GameObject PhantomGirlOutline;

	// Token: 0x0400404A RID: 16458
	public GameObject HeartbeatCamera;

	// Token: 0x0400404B RID: 16459
	public GameObject OutOfOrderSign;

	// Token: 0x0400404C RID: 16460
	public GameObject PickUpBlocker;

	// Token: 0x0400404D RID: 16461
	public GameObject PauseScreen;

	// Token: 0x0400404E RID: 16462
	public GameObject VictimGirl;

	// Token: 0x0400404F RID: 16463
	public GameObject Jukebox;

	// Token: 0x04004050 RID: 16464
	public GameObject FPSBG;

	// Token: 0x04004051 RID: 16465
	public GameObject FPS;

	// Token: 0x04004052 RID: 16466
	public bool EightiesEffectsEnabled;

	// Token: 0x04004053 RID: 16467
	public bool TransitionToCutscene;

	// Token: 0x04004054 RID: 16468
	public bool ReturnToTitleScreen;

	// Token: 0x04004055 RID: 16469
	public bool FadeInstructions;

	// Token: 0x04004056 RID: 16470
	public bool MovementProgress;

	// Token: 0x04004057 RID: 16471
	public bool CameraProgress;

	// Token: 0x04004058 RID: 16472
	public bool MusicSynced;

	// Token: 0x04004059 RID: 16473
	public bool CanPickUp;

	// Token: 0x0400405A RID: 16474
	public bool Cutscene;

	// Token: 0x0400405B RID: 16475
	public bool Pause;

	// Token: 0x0400405C RID: 16476
	public bool DOF;

	// Token: 0x0400405D RID: 16477
	public int CutscenePhase;

	// Token: 0x0400405E RID: 16478
	public int Phase;

	// Token: 0x0400405F RID: 16479
	public float MusicTimer;

	// Token: 0x04004060 RID: 16480
	public float SpawnTimer;

	// Token: 0x04004061 RID: 16481
	public float Rotation = 90f;

	// Token: 0x04004062 RID: 16482
	public float Timer;

	// Token: 0x04004063 RID: 16483
	public float RagdollRotation;

	// Token: 0x04004064 RID: 16484
	public Vector3 RightEyeOrigin;

	// Token: 0x04004065 RID: 16485
	public Vector3 LeftEyeOrigin;

	// Token: 0x04004066 RID: 16486
	public Transform RightArm;

	// Token: 0x04004067 RID: 16487
	public Transform RightEye;

	// Token: 0x04004068 RID: 16488
	public Transform LeftEye;

	// Token: 0x04004069 RID: 16489
	public float EyeShrink;
}
