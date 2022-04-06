using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000356 RID: 854
public class LivingRoomCutsceneScript : MonoBehaviour
{
	// Token: 0x0600197C RID: 6524 RVA: 0x001003BC File Offset: 0x000FE5BC
	private void Start()
	{
		this.VtuberCheck();
		this.SkipPanel.alpha = 0f;
		if (this.BlondePony != null && GameGlobals.BlondeHair)
		{
			this.PonytailRenderer.material.mainTexture = this.BlondePony;
		}
		this.YandereCosmetic.FemaleUniformID = StudentGlobals.FemaleUniform;
		this.YandereCosmetic.SetFemaleUniform();
		this.YandereCosmetic.RightWristband.SetActive(false);
		this.YandereCosmetic.LeftWristband.SetActive(false);
		this.YandereCosmetic.ThickBrows.SetActive(false);
		this.ID = 0;
		while (this.ID < this.YandereCosmetic.FemaleHair.Length)
		{
			GameObject gameObject = this.YandereCosmetic.FemaleHair[this.ID];
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.YandereCosmetic.TeacherHair.Length)
		{
			GameObject gameObject2 = this.YandereCosmetic.TeacherHair[this.ID];
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.YandereCosmetic.FemaleAccessories.Length)
		{
			GameObject gameObject3 = this.YandereCosmetic.FemaleAccessories[this.ID];
			if (gameObject3 != null)
			{
				gameObject3.SetActive(false);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.YandereCosmetic.TeacherAccessories.Length)
		{
			GameObject gameObject4 = this.YandereCosmetic.TeacherAccessories[this.ID];
			if (gameObject4 != null)
			{
				gameObject4.SetActive(false);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.YandereCosmetic.ClubAccessories.Length)
		{
			GameObject gameObject5 = this.YandereCosmetic.ClubAccessories[this.ID];
			if (gameObject5 != null)
			{
				gameObject5.SetActive(false);
			}
			this.ID++;
		}
		foreach (GameObject gameObject6 in this.YandereCosmetic.Scanners)
		{
			if (gameObject6 != null)
			{
				gameObject6.SetActive(false);
			}
		}
		foreach (GameObject gameObject7 in this.YandereCosmetic.Flowers)
		{
			if (gameObject7 != null)
			{
				gameObject7.SetActive(false);
			}
		}
		foreach (GameObject gameObject8 in this.YandereCosmetic.PunkAccessories)
		{
			if (gameObject8 != null)
			{
				gameObject8.SetActive(false);
			}
		}
		foreach (GameObject gameObject9 in this.YandereCosmetic.RedCloth)
		{
			if (gameObject9 != null)
			{
				gameObject9.SetActive(false);
			}
		}
		foreach (GameObject gameObject10 in this.YandereCosmetic.Kerchiefs)
		{
			if (gameObject10 != null)
			{
				gameObject10.SetActive(false);
			}
		}
		for (int j = 0; j < 10; j++)
		{
			this.YandereCosmetic.Fingernails[j].gameObject.SetActive(false);
		}
		this.ID = 0;
		this.YandereCosmetic.FemaleHair[1].SetActive(true);
		this.YandereCosmetic.MyRenderer.materials[2].mainTexture = this.YandereCosmetic.DefaultFaceTexture;
		this.Subtitle.text = string.Empty;
		this.RightEyeRenderer.material.color = new Color(0.33f, 0.33f, 0.33f, 1f);
		this.LeftEyeRenderer.material.color = new Color(0.33f, 0.33f, 0.33f, 1f);
		if (GameGlobals.VtuberID > 0)
		{
			this.RightEyeRenderer.material.color = Color.white;
			this.LeftEyeRenderer.material.color = Color.white;
		}
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
		this.EliminationPanel.alpha = 0f;
		this.Panel.alpha = 1f;
		this.ColorCorrection.saturation = 1f;
		this.Noise.intensityMultiplier = 0f;
		this.Obscurance.intensity = 0f;
		this.Vignette.enabled = false;
		this.Vignette.intensity = 1f;
		this.Vignette.blur = 1f;
		this.Vignette.chromaticAberration = 1f;
		if (EventGlobals.OsanaConversation)
		{
			this.PrologueLabel.transform.localPosition = new Vector3(0f, 125f, 0f);
			this.PrologueLabel.text = "Osana is eager to report her stalker to the police.\n\nHowever, she knows that the process could take a long time, so she decides to visit Ayano's house and get her cat back before contacting the police.\n\nThe next morning, Osana arrives at Ayano's house...";
			this.WarningLabel.SetActive(true);
			this.CatStuff.SetActive(true);
			this.OsanaCutscene = true;
			this.Lines = this.RivalData.OsanaIntroLines;
			this.Times = this.RivalData.OsanaIntroTimes;
			this.MyAudio.clip = this.RivalData.OsanaIntro;
			this.BGM.volume = 0.1f;
			if (SchemeGlobals.GetSchemeStage(6) == 9)
			{
				SchemeGlobals.SetSchemeStage(6, 100);
			}
		}
		if (GameGlobals.Eighties)
		{
			this.EightiesLabel.gameObject.SetActive(true);
			this.SkipPanel.gameObject.SetActive(false);
			this.PrologueLabel.enabled = false;
			this.WarningLabel.SetActive(false);
			this.Rival.SetActive(false);
			this.Eighties = true;
		}
	}

	// Token: 0x0600197D RID: 6525 RVA: 0x001009B4 File Offset: 0x000FEBB4
	private void Update()
	{
		if (this.Phase > 3 && !this.WaitingForInput && this.Timer < 172f && !this.NoSkip)
		{
			this.SkipPanel.alpha += Time.deltaTime;
			if (Input.GetButton("X"))
			{
				this.SkipPanel.alpha = 1f;
				this.SkipCircle.fillAmount -= Time.deltaTime;
				if (this.SkipCircle.fillAmount == 0f)
				{
					this.SkipCircle.fillAmount = 1f;
					if (!this.DecisionMade)
					{
						this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = 43f;
						this.Rival.GetComponent<Animation>()["FriendshipRival"].time = 43f;
						this.Yandere.GetComponent<Animation>()["FriendshipYandere"].speed = 0f;
						this.Rival.GetComponent<Animation>()["FriendshipRival"].speed = 0f;
						this.FriendshipCamera.gameObject.GetComponent<Animation>().Play();
						this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = 43f;
						this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0f;
						this.MyAudio.Play();
						this.MyAudio.time = 43f;
						this.WaitingForInput = true;
						this.Timer = 43f;
						this.Phase = 5;
						this.ID = 17;
					}
					else
					{
						if (!this.DruggedTea && this.Branch < 3)
						{
							this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = 172f;
							this.Rival.GetComponent<Animation>()["FriendshipRival"].time = 172f;
							this.Yandere.GetComponent<Animation>()["FriendshipYandere"].speed = 0f;
							this.Rival.GetComponent<Animation>()["FriendshipRival"].speed = 0f;
							this.FriendshipCamera.gameObject.GetComponent<Animation>().Play();
							this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = 172f;
							this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0f;
							this.CameraIDs = this.RivalData.OsanaBefriendCameraIDs;
							this.Lines = this.RivalData.OsanaBefriendLines;
							this.Times = this.RivalData.OsanaBefriendTimes;
							this.Yandere.gameObject.SetActive(true);
							this.MyAudio.clip = this.RivalData.OsanaBefriend;
							this.MyAudio.Play();
							this.MyAudio.time = 100f;
							this.SkipPanel.alpha = 0f;
							this.CutsceneLimit = 172f;
							this.Timer = 172f;
							this.Branch = 2;
							this.Phase = 5;
							this.ID = 37;
						}
						else
						{
							this.Rival.GetComponent<Animation>()["FriendshipRival"].speed = 1f;
							base.transform.parent = this.OsanaEyes;
							base.transform.localPosition = new Vector3(0f, 0f, 0f);
							base.transform.LookAt(this.AyanoEyes);
							this.Vignette.enabled = true;
							this.BlurVision = true;
							this.Yandere.gameObject.SetActive(true);
							this.Yandere.GetComponent<Animation>().Play("f02_evilWitness_00");
							this.Yandere.GetComponent<Animation>()["f02_evilWitness_00"].time = 2f;
							this.Yandere.GetComponent<Animation>()["f02_evilWitness_00"].speed = 0.25f;
							base.transform.parent = this.AyanoEyes;
							base.transform.localPosition = new Vector3(0f, 0f, 0.5f);
							base.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
							this.FollowCamera = false;
							this.CameraIDs = this.RivalData.OsanaBetrayCameraIDs;
							this.Lines = this.RivalData.OsanaBetrayLines;
							this.Times = this.RivalData.OsanaBetrayTimes;
							this.MyAudio.clip = this.RivalData.OsanaBetray;
							this.MyAudio.time = 32f;
							this.MyAudio.Play();
							this.CutsceneLimit = 110f;
							this.Timer = 103f;
							this.Branch = 3;
							this.Phase = 5;
							this.ID = 9;
						}
						this.SkipPanel.alpha = 0f;
						this.NoSkip = true;
					}
				}
			}
			else
			{
				this.SkipCircle.fillAmount = 1f;
			}
		}
		if (this.Phase == 1)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f && Input.GetButtonDown("A"))
				{
					this.Timer = 0f;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 2)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a == 1f)
			{
				this.Vignette.enabled = true;
				this.Prologue.SetActive(false);
				if (!this.Eighties)
				{
					base.transform.parent = this.LivingRoomCamera;
					base.transform.localPosition = new Vector3(-0.65f, 0f, 0f);
					base.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
					this.Phase++;
					if (!this.OsanaCutscene)
					{
						this.BGM.Play();
					}
				}
				else
				{
					base.transform.position = this.TeaCamera.position;
					base.transform.rotation = this.TeaCamera.rotation;
					this.TeaSet.SetActive(true);
					this.Phase = 100;
				}
			}
		}
		else if (this.Phase == 3)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0f, Time.deltaTime);
				if (this.Panel.alpha == 0f)
				{
					this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = 0f;
					this.Rival.GetComponent<Animation>()["FriendshipRival"].time = 0f;
					if (this.OsanaCutscene)
					{
						this.Yandere.GetComponent<Animation>()["FriendshipYandere"].speed = 0f;
						this.Rival.GetComponent<Animation>()["FriendshipRival"].speed = 0f;
					}
					this.LivingRoomCamera.gameObject.GetComponent<Animation>().Play();
					this.Timer = 0f;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 4)
		{
			this.SkipPanel.alpha += Time.deltaTime;
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f && this.OsanaCutscene && !this.BGM.isPlaying)
			{
				this.BGM.Play();
			}
			if (this.Timer > 10f)
			{
				base.transform.parent = this.FriendshipCamera;
				base.transform.localPosition = new Vector3(-0.65f, 0f, 0f);
				base.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
				this.FriendshipCamera.gameObject.GetComponent<Animation>().Play();
				this.MyAudio.Play();
				this.Subtitle.text = this.Lines[0];
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			if (Input.GetKeyDown(KeyCode.Z))
			{
				this.Timer += 2f;
				this.MyAudio.time += 2f;
				if (this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed > 0f)
				{
					this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time += 2f;
				}
			}
			this.Timer += Time.deltaTime;
			if (this.Timer < 166f && !this.OsanaCutscene)
			{
				this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = this.MyAudio.time + this.AnimOffset;
				this.Rival.GetComponent<Animation>()["FriendshipRival"].time = this.MyAudio.time + this.AnimOffset;
			}
			if (this.ID < this.Times.Length)
			{
				if (this.MyAudio.time > this.Times[this.ID] || !this.MyAudio.isPlaying)
				{
					if (this.OsanaCutscene)
					{
						if (this.Branch == 1)
						{
							this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = this.MyAudio.time + this.AnimOffset;
							this.Rival.GetComponent<Animation>()["FriendshipRival"].time = this.MyAudio.time + this.AnimOffset;
						}
						else
						{
							this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = this.MyAudio.time + 66f;
							this.Rival.GetComponent<Animation>()["FriendshipRival"].time = this.MyAudio.time + 66f;
							if (this.Branch == 3)
							{
								this.Rival.GetComponent<Animation>()["FriendshipRival"].time = this.MyAudio.time + 67f;
							}
						}
						if (this.ID > 1 && this.Branch > 1)
						{
							if (this.CameraIDs[this.ID] == 0f)
							{
								this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 1f;
							}
							else if (this.CameraIDs[this.ID] == 1000f)
							{
								this.Rival.GetComponent<Animation>()["FriendshipRival"].speed = 1f;
								base.transform.parent = this.OsanaEyes;
								base.transform.localPosition = new Vector3(0f, 0f, 0f);
								base.transform.LookAt(this.AyanoEyes);
								this.Vignette.enabled = true;
								this.FollowCamera = true;
								this.BlurVision = true;
							}
							else if (this.CameraIDs[this.ID] == 1001f)
							{
								if (this.FollowCamera)
								{
									this.Yandere.GetComponent<Animation>().Play("f02_evilWitness_00");
									this.Yandere.GetComponent<Animation>()["f02_evilWitness_00"].time = 2f;
									this.Yandere.GetComponent<Animation>()["f02_evilWitness_00"].speed = 0.25f;
								}
								base.transform.parent = this.AyanoEyes;
								base.transform.localPosition = new Vector3(0f, 0f, 0.5f);
								base.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
								this.FollowCamera = false;
							}
							else if (this.CameraIDs[this.ID] == 1002f)
							{
								this.Darkness.alpha = 0f;
								this.Panel.alpha = 1f;
								this.BlurSpeed = 10f;
								this.Fall = true;
							}
							else
							{
								this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = this.CameraIDs[this.ID];
								this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0f;
							}
						}
					}
					this.Subtitle.text = this.Lines[this.ID];
					this.ID++;
					if (this.ID == 3)
					{
						this.OfferTea.SetActive(false);
					}
				}
			}
			else if (this.OsanaCutscene && this.Branch == 1)
			{
				this.Subtitle.text = "Here's your tea.";
				this.OfferTea.SetActive(true);
				this.Yandere.SetActive(true);
				if (!this.DruggedTea)
				{
					Debug.Log("Transitioning into Befriend branch NOW.");
					this.CameraIDs = this.RivalData.OsanaBefriendCameraIDs;
					this.Lines = this.RivalData.OsanaBefriendLines;
					this.Times = this.RivalData.OsanaBefriendTimes;
					this.MyAudio.clip = this.RivalData.OsanaBefriend;
					this.MyAudio.time = 0f;
					this.MyAudio.Play();
					this.CutsceneLimit = 172f;
					this.Branch = 2;
				}
				else
				{
					Debug.Log("Transitioning into Betray branch NOW.");
					this.CameraIDs = this.RivalData.OsanaBetrayCameraIDs;
					this.Lines = this.RivalData.OsanaBetrayLines;
					this.Times = this.RivalData.OsanaBetrayTimes;
					this.MyAudio.clip = this.RivalData.OsanaBetray;
					this.MyAudio.time = 0f;
					this.MyAudio.Play();
					this.CutsceneLimit = 110f;
					this.Branch = 3;
				}
				this.ID = 1;
			}
			if (this.OsanaCutscene)
			{
				if (this.Branch == 1)
				{
					if (this.ID == 12)
					{
						if (!this.TeaSteam.activeInHierarchy)
						{
							base.transform.parent = null;
							base.transform.position = this.KettleCameraOrigin.position;
							base.transform.rotation = this.KettleCameraOrigin.rotation;
							this.TeaSteam.SetActive(true);
						}
						else
						{
							this.Speed += Time.deltaTime * 0.2f;
							base.transform.position = Vector3.Lerp(base.transform.position, this.KettleCameraDestination.position, Time.deltaTime * this.Speed);
						}
					}
					else if (this.ID > 12 && this.ID < 16)
					{
						base.transform.position = new Vector3(-6f, 1f, 3f);
						base.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
					}
					else if (this.ID > 17 && this.ID < 24 && !this.DecisionMade)
					{
						this.SkipPanel.alpha = Mathf.MoveTowards(this.SkipPanel.alpha, 0f, Time.deltaTime);
						if (!this.TeaSet.activeInHierarchy)
						{
							this.WaitingForInput = true;
							base.transform.parent = null;
							base.transform.position = this.TeaCamera.position;
							base.transform.rotation = this.TeaCamera.rotation;
							this.Yandere.SetActive(false);
							this.TeaSet.SetActive(true);
							this.AnimOffset += 2f;
						}
						if (Input.GetButtonDown("A"))
						{
							this.WaitingForInput = false;
							this.DecisionMade = true;
						}
						if (Input.GetButtonDown("B"))
						{
							this.WaitingForInput = false;
							this.DecisionMade = true;
							this.DruggedTea = true;
						}
					}
					else
					{
						base.transform.parent = this.FriendshipCamera;
						base.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
						if (this.ID == 16 && this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time < 44f)
						{
							this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = 44f;
							this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0f;
						}
					}
				}
				else
				{
					int branch = this.Branch;
				}
			}
			if (!this.OsanaCutscene)
			{
				if (this.MyAudio.time > 54f)
				{
					this.DecreaseYandereEffects();
				}
				else if (this.MyAudio.time > 42f)
				{
					this.IncreaseYandereEffects();
				}
			}
			else if (this.Branch == 1)
			{
				if (this.DecisionMade || this.MyAudio.time > 60f)
				{
					this.DecreaseYandereEffects();
				}
				else if (this.MyAudio.time > 43f)
				{
					this.IncreaseYandereEffects();
				}
			}
			if (this.Timer > this.CutsceneLimit)
			{
				Animation component = this.Yandere.GetComponent<Animation>();
				component["FriendshipYandere"].speed = -0.2f;
				component.Play("FriendshipYandere");
				component["FriendshipYandere"].time = component["FriendshipYandere"].length;
				this.Subtitle.text = string.Empty;
				this.Phase = 10;
			}
		}
		else if (this.Phase == 6)
		{
			if (!this.MyAudio.isPlaying)
			{
				this.MyAudio.clip = this.DramaticBoom;
				this.MyAudio.Play();
				this.Subtitle.text = string.Empty;
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			if (!this.MyAudio.isPlaying)
			{
				if (!this.OsanaCutscene)
				{
					StudentGlobals.SetStudentKidnapped(81, false);
					StudentGlobals.SetStudentBroken(81, true);
					SchoolGlobals.KidnapVictim = 0;
					StudentGlobals.SetStudentKidnapped(30, true);
					StudentGlobals.SetStudentSanity(30, 100f);
					SchoolGlobals.KidnapVictim = 30;
					if (DateGlobals.PassDays < 1)
					{
						DateGlobals.PassDays = 1;
					}
					SceneManager.LoadScene("CalendarScene");
				}
				else
				{
					this.BetrayRival();
					Debug.Log("EventGlobals.OsanaConversation is currently: " + EventGlobals.OsanaConversation.ToString());
				}
				HomeGlobals.StartInBasement = true;
			}
		}
		else if (this.Phase == 10)
		{
			this.BGM.volume = 0f;
			this.SubDarkness.color = new Color(this.SubDarkness.color.r, this.SubDarkness.color.g, this.SubDarkness.color.b, Mathf.MoveTowards(this.SubDarkness.color.a, 1f, Time.deltaTime * 0.2f));
			if (this.SubDarkness.color.a == 1f)
			{
				if (DateGlobals.PassDays < 1)
				{
					DateGlobals.PassDays = 1;
				}
				this.BefriendRival();
				EventGlobals.OsanaConversation = false;
				Debug.Log("EventGlobals.OsanaConversation has been set to: " + EventGlobals.OsanaConversation.ToString());
			}
		}
		else if (this.Phase == 100)
		{
			if (!this.DecisionMade)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f)
				{
					if (Input.GetButtonDown("A"))
					{
						if (DateGlobals.Week < 10)
						{
							this.EightiesLabel.text = "Over a cup of tea, Ryoba describes the deep feelings she has for her Senpai, and explains how heartbroken she would feel if anyone took the boy away from her. She asks the girl to stay away from her Senpai.\n\nRyoba's rival cannot bring herself to compete romantically with someone who entered a life-threatening situation to help her out. She agrees to stay away from Ryoba's Senpai.\n\nRyoba's rival is no longer a threat, and the two girls are now the best of friends!";
						}
						else
						{
							this.EightiesLabel.text = "After the massive favor that Ryoba did for Sonoko, she can no longer consider Ryoba to be a murder suspect.\n\nOver a cup of tea, Ryoba describes the deep feelings she has for her Senpai, and explains how heartbroken she would feel if anyone took the boy away from her. She asks Sonoko to stay away from her Senpai.\n\nSonoko states that she must continue to investigate Senpai as a potential murder suspect, but will not attempt to date him.\n\nSonoko is no longer a threat, and the two girls are now the best of friends!";
						}
						this.DecisionMade = true;
					}
					if (Input.GetButtonDown("B"))
					{
						this.EightiesLabel.text = "Ryoba's rival drinks the drugged tea and passes out. When she wakes up...";
						this.DecisionMade = true;
						this.DruggedTea = true;
					}
				}
			}
			else
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				if (this.Darkness.color.a == 1f)
				{
					this.Prologue.SetActive(true);
					this.DecisionMade = false;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 101)
		{
			if (!this.DecisionMade)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				if (Input.GetButtonDown("A"))
				{
					this.DecisionMade = true;
				}
			}
			else
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				if (this.Darkness.color.a == 1f)
				{
					if (this.DruggedTea)
					{
						this.BetrayRival();
					}
					else
					{
						this.BefriendRival();
					}
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			Time.timeScale -= 1f;
		}
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			Time.timeScale += 1f;
		}
		this.MyAudio.pitch = Time.timeScale;
		if (this.BlurVision)
		{
			this.BGM.pitch -= Time.deltaTime * 0.05f;
			this.Vignette.intensity += Time.deltaTime * this.BlurSpeed;
			this.Vignette.blur += Time.deltaTime * this.BlurSpeed;
			this.Vignette.chromaticAberration += Time.deltaTime * this.BlurSpeed;
			if (this.Fall)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				base.transform.localPosition -= new Vector3(0f, Time.deltaTime * 0.5f, 0f);
				base.transform.localEulerAngles += new Vector3(Time.deltaTime * 180f, Time.deltaTime * 180f, Time.deltaTime * 180f);
				this.BGM.volume -= Time.deltaTime;
				if (this.Darkness.color.a == 1f)
				{
					this.ExitTimer += Time.deltaTime;
					if (this.ExitTimer > 3f)
					{
						this.Phase = 7;
					}
				}
			}
		}
	}

	// Token: 0x0600197E RID: 6526 RVA: 0x001023F4 File Offset: 0x001005F4
	private void LateUpdate()
	{
		if (this.Phase > 2)
		{
			if (base.transform.parent != null)
			{
				if (this.OsanaCutscene)
				{
					if (this.FriendshipCamera.position.z > 2.4f)
					{
						base.transform.localPosition = new Vector3(-1.4f + this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f));
					}
					else if (this.Branch != 3)
					{
						base.transform.localPosition = new Vector3(-0.65f + this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f));
					}
				}
				else
				{
					base.transform.localPosition = new Vector3(-0.65f + this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f), this.ShakeStrength * UnityEngine.Random.Range(-1f, 1f));
				}
			}
			this.CutsceneCamera.position = new Vector3(this.CutsceneCamera.position.x + this.xOffset, this.CutsceneCamera.position.y, this.CutsceneCamera.position.z + this.zOffset);
			this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
			this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
			this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
			this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
		}
		if (this.FollowCamera)
		{
			this.AyanoHead.transform.LookAt(base.transform.position);
		}
	}

	// Token: 0x0600197F RID: 6527 RVA: 0x001026EC File Offset: 0x001008EC
	private void IncreaseYandereEffects()
	{
		if (!this.Jukebox.isPlaying)
		{
			this.Jukebox.Play();
		}
		this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.1f, Time.deltaTime * 0.1f);
		this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, 5f, Time.deltaTime * 4f / 10f);
		this.Vignette.blur = this.Vignette.intensity;
		this.Vignette.chromaticAberration = this.Vignette.intensity;
		this.ColorCorrection.saturation = Mathf.MoveTowards(this.ColorCorrection.saturation, 0f, Time.deltaTime / 10f);
		this.Noise.intensityMultiplier = Mathf.MoveTowards(this.Noise.intensityMultiplier, 3f, Time.deltaTime * 3f / 10f);
		this.Obscurance.intensity = Mathf.MoveTowards(this.Obscurance.intensity, 3f, Time.deltaTime * 3f / 10f);
		if (!this.OsanaCutscene)
		{
			this.ShakeStrength = Mathf.MoveTowards(this.ShakeStrength, 0.01f, Time.deltaTime * 0.01f / 10f);
		}
		this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, 0.9f, Time.deltaTime);
		if (this.MyAudio.time > 45f)
		{
			if (this.MyAudio.time > 54f)
			{
				this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 0f, Time.deltaTime);
				return;
			}
			if (!this.OsanaCutscene)
			{
				this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 1f, Time.deltaTime);
				if (Input.GetButtonDown("X"))
				{
					this.MyAudio.clip = this.RivalProtest;
					this.MyAudio.volume = 1f;
					this.MyAudio.Play();
					this.Jukebox.gameObject.SetActive(false);
					this.BGM.gameObject.SetActive(false);
					this.Subtitle.text = "Wait, what are you doing?! That's not funny! Stop! Let me go! ...n...NO!!!";
					this.SubDarknessBG.color = new Color(this.SubDarknessBG.color.r, this.SubDarknessBG.color.g, this.SubDarknessBG.color.b, 1f);
					this.Phase++;
				}
			}
		}
	}

	// Token: 0x06001980 RID: 6528 RVA: 0x001029B0 File Offset: 0x00100BB0
	private void DecreaseYandereEffects()
	{
		this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0f, Time.deltaTime / 5f);
		this.MyAudio.volume = Mathf.MoveTowards(this.MyAudio.volume, 1f, Time.deltaTime * 0.1f / 5f);
		this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, 1f, Time.deltaTime * 4f / 5f);
		this.Vignette.blur = this.Vignette.intensity;
		this.Vignette.chromaticAberration = this.Vignette.intensity;
		this.ColorCorrection.saturation = Mathf.MoveTowards(this.ColorCorrection.saturation, 1f, Time.deltaTime / 5f);
		this.Noise.intensityMultiplier = Mathf.MoveTowards(this.Noise.intensityMultiplier, 0f, Time.deltaTime * 3f / 5f);
		this.Obscurance.intensity = Mathf.MoveTowards(this.Obscurance.intensity, 0f, Time.deltaTime * 3f / 5f);
		this.ShakeStrength = Mathf.MoveTowards(this.ShakeStrength, 0f, Time.deltaTime * 0.01f / 5f);
		this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 0f, Time.deltaTime);
		this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, 0f, Time.deltaTime);
	}

	// Token: 0x06001981 RID: 6529 RVA: 0x00102B6C File Offset: 0x00100D6C
	private void BetrayRival()
	{
		StudentGlobals.SetStudentKidnapped(10 + DateGlobals.Week, true);
		StudentGlobals.SetStudentSanity(10 + DateGlobals.Week, 100f);
		SchoolGlobals.KidnapVictim = 10 + DateGlobals.Week;
		EventGlobals.OsanaConversation = true;
		SceneManager.LoadScene("GenocideScene");
		GameGlobals.RivalEliminationID = 11;
		GameGlobals.NonlethalElimination = true;
		GameGlobals.SpecificEliminationID = 3;
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("Betray", 1);
		}
	}

	// Token: 0x06001982 RID: 6530 RVA: 0x00102BDB File Offset: 0x00100DDB
	private void BefriendRival()
	{
		SceneManager.LoadScene("CalendarScene");
		GameGlobals.RivalEliminationID = 4;
		GameGlobals.NonlethalElimination = true;
		GameGlobals.SpecificEliminationID = 2;
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("Befriend", 1);
		}
	}

	// Token: 0x06001983 RID: 6531 RVA: 0x00102C0C File Offset: 0x00100E0C
	private void VtuberCheck()
	{
		if (GameGlobals.VtuberID > 0)
		{
			this.OriginalHair.transform.position = new Vector3(0f, 100f, 0f);
			this.YandereCosmetic.FaceTexture = this.VtuberFaces[GameGlobals.VtuberID];
			this.YandereCosmetic.DefaultFaceTexture = this.VtuberFaces[GameGlobals.VtuberID];
			this.YandereCosmetic.FemaleHairRenderers[1].material.mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
			this.RightEyeRenderer.material.mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
			this.LeftEyeRenderer.material.mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
			this.RightEyeRenderer.material.color = Color.white;
			this.LeftEyeRenderer.material.color = Color.white;
			this.ID = 0;
			while (this.ID < 13)
			{
				this.YandereRenderer.SetBlendShapeWeight(this.ID, 0f);
				this.ID++;
			}
			this.YandereRenderer.SetBlendShapeWeight(9, 100f);
			return;
		}
		for (int i = 1; i < this.VtuberHairs.Length; i++)
		{
			this.VtuberHairs[i].SetActive(false);
		}
	}

	// Token: 0x04002877 RID: 10359
	public ColorCorrectionCurves ColorCorrection;

	// Token: 0x04002878 RID: 10360
	public CosmeticScript YandereCosmetic;

	// Token: 0x04002879 RID: 10361
	public AmbientObscurance Obscurance;

	// Token: 0x0400287A RID: 10362
	public RivalDataScript RivalData;

	// Token: 0x0400287B RID: 10363
	public Vignetting Vignette;

	// Token: 0x0400287C RID: 10364
	public NoiseAndGrain Noise;

	// Token: 0x0400287D RID: 10365
	public UISprite SkipCircle;

	// Token: 0x0400287E RID: 10366
	public UIPanel SkipPanel;

	// Token: 0x0400287F RID: 10367
	public SkinnedMeshRenderer YandereRenderer;

	// Token: 0x04002880 RID: 10368
	public Renderer RightEyeRenderer;

	// Token: 0x04002881 RID: 10369
	public Renderer LeftEyeRenderer;

	// Token: 0x04002882 RID: 10370
	public Transform KettleCameraDestination;

	// Token: 0x04002883 RID: 10371
	public Transform KettleCameraOrigin;

	// Token: 0x04002884 RID: 10372
	public Transform FriendshipCamera;

	// Token: 0x04002885 RID: 10373
	public Transform LivingRoomCamera;

	// Token: 0x04002886 RID: 10374
	public Transform CutsceneCamera;

	// Token: 0x04002887 RID: 10375
	public Transform AyanoHead;

	// Token: 0x04002888 RID: 10376
	public Transform TeaCamera;

	// Token: 0x04002889 RID: 10377
	public Transform AyanoEyes;

	// Token: 0x0400288A RID: 10378
	public Transform OsanaEyes;

	// Token: 0x0400288B RID: 10379
	public UIPanel EliminationPanel;

	// Token: 0x0400288C RID: 10380
	public UIPanel Panel;

	// Token: 0x0400288D RID: 10381
	public UISprite SubDarknessBG;

	// Token: 0x0400288E RID: 10382
	public UISprite SubDarkness;

	// Token: 0x0400288F RID: 10383
	public UISprite Darkness;

	// Token: 0x04002890 RID: 10384
	public UILabel EightiesLabel;

	// Token: 0x04002891 RID: 10385
	public UILabel PrologueLabel;

	// Token: 0x04002892 RID: 10386
	public UILabel Subtitle;

	// Token: 0x04002893 RID: 10387
	public Vector3 RightEyeOrigin;

	// Token: 0x04002894 RID: 10388
	public Vector3 LeftEyeOrigin;

	// Token: 0x04002895 RID: 10389
	public AudioClip DramaticBoom;

	// Token: 0x04002896 RID: 10390
	public AudioClip RivalProtest;

	// Token: 0x04002897 RID: 10391
	public AudioSource Jukebox;

	// Token: 0x04002898 RID: 10392
	public AudioSource MyAudio;

	// Token: 0x04002899 RID: 10393
	public AudioSource BGM;

	// Token: 0x0400289A RID: 10394
	public GameObject WarningLabel;

	// Token: 0x0400289B RID: 10395
	public GameObject TeaSteam;

	// Token: 0x0400289C RID: 10396
	public GameObject CatStuff;

	// Token: 0x0400289D RID: 10397
	public GameObject OfferTea;

	// Token: 0x0400289E RID: 10398
	public GameObject Prologue;

	// Token: 0x0400289F RID: 10399
	public GameObject Yandere;

	// Token: 0x040028A0 RID: 10400
	public GameObject TeaSet;

	// Token: 0x040028A1 RID: 10401
	public GameObject Rival;

	// Token: 0x040028A2 RID: 10402
	public Transform RightEye;

	// Token: 0x040028A3 RID: 10403
	public Transform LeftEye;

	// Token: 0x040028A4 RID: 10404
	public float CutsceneLimit = 167f;

	// Token: 0x040028A5 RID: 10405
	public float ShakeStrength;

	// Token: 0x040028A6 RID: 10406
	public float AnimOffset;

	// Token: 0x040028A7 RID: 10407
	public float ExitTimer;

	// Token: 0x040028A8 RID: 10408
	public float EyeShrink;

	// Token: 0x040028A9 RID: 10409
	public float xOffset;

	// Token: 0x040028AA RID: 10410
	public float zOffset;

	// Token: 0x040028AB RID: 10411
	public float Timer;

	// Token: 0x040028AC RID: 10412
	public float Speed;

	// Token: 0x040028AD RID: 10413
	public bool WaitingForInput;

	// Token: 0x040028AE RID: 10414
	public bool OsanaCutscene;

	// Token: 0x040028AF RID: 10415
	public bool DecisionMade;

	// Token: 0x040028B0 RID: 10416
	public bool FollowCamera;

	// Token: 0x040028B1 RID: 10417
	public bool BlurVision;

	// Token: 0x040028B2 RID: 10418
	public bool DruggedTea;

	// Token: 0x040028B3 RID: 10419
	public bool Eighties;

	// Token: 0x040028B4 RID: 10420
	public bool NoSkip;

	// Token: 0x040028B5 RID: 10421
	public bool Fall;

	// Token: 0x040028B6 RID: 10422
	public float[] CameraIDs;

	// Token: 0x040028B7 RID: 10423
	public string[] Lines;

	// Token: 0x040028B8 RID: 10424
	public float[] Times;

	// Token: 0x040028B9 RID: 10425
	public float BlurSpeed = 1f;

	// Token: 0x040028BA RID: 10426
	public int Branch = 1;

	// Token: 0x040028BB RID: 10427
	public int Phase = 1;

	// Token: 0x040028BC RID: 10428
	public int ID = 1;

	// Token: 0x040028BD RID: 10429
	public Texture ZTR;

	// Token: 0x040028BE RID: 10430
	public int ZTRID;

	// Token: 0x040028BF RID: 10431
	public Renderer PonytailRenderer;

	// Token: 0x040028C0 RID: 10432
	public Texture BlondePony;

	// Token: 0x040028C1 RID: 10433
	public GameObject OriginalHair;

	// Token: 0x040028C2 RID: 10434
	public GameObject[] VtuberHairs;

	// Token: 0x040028C3 RID: 10435
	public Texture[] VtuberFaces;

	// Token: 0x040028C4 RID: 10436
	public Texture[] VtuberEyes;

	// Token: 0x040028C5 RID: 10437
	public Renderer[] Eye;
}
