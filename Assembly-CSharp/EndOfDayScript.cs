using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020002A6 RID: 678
public class EndOfDayScript : MonoBehaviour
{
	// Token: 0x06001419 RID: 5145 RVA: 0x000BFB70 File Offset: 0x000BDD70
	public void Start()
	{
		Debug.Log("The End-of-Day GameObject has just fired its Start() function.");
		this.VoidGoddess.Start();
		GameGlobals.PoliceYesterday = false;
		this.YandereInitialPosition = this.Yandere.transform.position;
		this.YandereInitialRotation = this.Yandere.transform.rotation;
		if (GameGlobals.SenpaiMourning)
		{
			this.StopMourning = true;
		}
		this.Yandere.MainCamera.gameObject.SetActive(false);
		this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, 1f);
		this.PreviouslyActivated = true;
		base.GetComponent<AudioSource>().volume = 0f;
		this.Clock.enabled = false;
		this.Clock.MainLight.color = new Color(1f, 1f, 1f, 1f);
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
		this.UpdateScene();
		this.CopAnimation[5]["idleShort_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
		this.CopAnimation[6]["idleShort_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
		this.CopAnimation[7]["idleShort_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
		Time.timeScale = 1f;
		for (int i = 1; i < 6; i++)
		{
			this.Yandere.CharacterAnimation[this.Yandere.CreepyIdles[i]].weight = 0f;
			this.Yandere.CharacterAnimation[this.Yandere.CreepyWalks[i]].weight = 0f;
		}
		this.ClothingWithRedPaint += this.Incinerator.ClothingWithRedPaint;
		foreach (object obj in this.Police.BloodParent)
		{
			PickUpScript component = ((Transform)obj).gameObject.GetComponent<PickUpScript>();
			if (component != null && component.RedPaint)
			{
				this.ClothingWithRedPaint++;
			}
		}
		int num = 0;
		if (this.Police.Corpses > 1)
		{
			foreach (RagdollScript ragdollScript in this.Police.CorpseList)
			{
				if (ragdollScript != null && (ragdollScript.MurderSuicide || ragdollScript.Student.MurderedByStudent))
				{
					num++;
				}
			}
		}
		if (num > 1)
		{
			this.Police.MurderSuicideScene = true;
		}
		this.ClubLimit = this.ClubArray.Length;
		if (!GameGlobals.Eighties)
		{
			this.ClubLimit--;
		}
		else
		{
			base.GetComponent<AudioSource>().clip = this.EightiesBGM;
			base.GetComponent<AudioSource>().Play();
		}
		if (!this.Counselor.Lecturing)
		{
			this.EODCamera.localPosition = new Vector3(1f, 1.8f, -2.5f);
			this.EODCamera.localEulerAngles = new Vector3(22.5f, -22.5f, 0f);
			this.TextWindow.SetActive(true);
		}
	}

	// Token: 0x0600141A RID: 5146 RVA: 0x000BFF28 File Offset: 0x000BE128
	private void Update()
	{
		this.Yandere.UpdateSlouch();
		if (Input.GetKeyDown("space"))
		{
			this.EndOfDayDarkness.color = new Color(0f, 0f, 0f, 1f);
			this.Darken = true;
		}
		if (this.EndOfDayDarkness.color.a == 0f && Input.GetButtonDown("A"))
		{
			this.Darken = true;
		}
		if (this.Darken)
		{
			this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, Mathf.MoveTowards(this.EndOfDayDarkness.color.a, 1f, Time.deltaTime * 2f));
			if (this.EndOfDayDarkness.color.a == 1f)
			{
				if (this.Senpai == null && this.StudentManager.Students[1] != null)
				{
					this.Senpai = this.StudentManager.Students[1];
					this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Senpai.CharacterAnimation.enabled = true;
				}
				if (this.Senpai != null)
				{
					this.Senpai.gameObject.SetActive(false);
				}
				if (this.Rival == null && this.StudentManager.Students[this.StudentManager.RivalID] != null)
				{
					this.Rival = this.StudentManager.Students[this.StudentManager.RivalID];
					this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Rival.CharacterAnimation.enabled = true;
				}
				if (this.Rival != null)
				{
					this.Rival.gameObject.SetActive(false);
				}
				this.Yandere.transform.parent = null;
				this.Yandere.transform.position = new Vector3(0f, 0f, -75f);
				this.EODCamera.localPosition = new Vector3(1f, 1.8f, -2.5f);
				this.EODCamera.localEulerAngles = new Vector3(22.5f, -22.5f, 0f);
				if (this.KidnappedVictim != null)
				{
					this.KidnappedVictim.gameObject.SetActive(false);
				}
				this.CardboardBox.parent = null;
				this.SearchingCop.SetActive(false);
				this.MurderScene.SetActive(false);
				this.Cops.SetActive(false);
				this.TabletCop.SetActive(false);
				this.ShruggingCops.SetActive(false);
				this.SecuritySystemScene.SetActive(false);
				this.OpenTranqCase.SetActive(false);
				this.ClosedTranqCase.SetActive(false);
				this.GaudyRing.SetActive(false);
				this.AnswerSheet.SetActive(false);
				this.Fence.SetActive(false);
				this.SCP.SetActive(false);
				this.Headmaster.SetActive(false);
				this.ArrestingCops.SetActive(false);
				this.Mask.SetActive(false);
				this.EyeWitnessScene.SetActive(false);
				this.ScaredCops.SetActive(false);
				this.EightiesGaudyRing.SetActive(false);
				if (this.WitnessList[1] != null)
				{
					this.WitnessList[1].gameObject.SetActive(false);
				}
				if (this.WitnessList[2] != null)
				{
					this.WitnessList[2].gameObject.SetActive(false);
				}
				if (this.WitnessList[3] != null)
				{
					this.WitnessList[3].gameObject.SetActive(false);
				}
				if (this.WitnessList[4] != null)
				{
					this.WitnessList[4].gameObject.SetActive(false);
				}
				if (this.WitnessList[5] != null)
				{
					this.WitnessList[5].gameObject.SetActive(false);
				}
				if (this.Patsy != null)
				{
					this.Patsy.gameObject.SetActive(false);
				}
				if (!this.GameOver)
				{
					this.Darken = false;
					this.UpdateScene();
				}
				else
				{
					this.Heartbroken.transform.parent.transform.parent = null;
					this.Heartbroken.transform.parent.gameObject.SetActive(true);
					this.Heartbroken.Cursor.HeartbrokenCamera.depth = 6f;
					if (this.Police.Deaths + PlayerGlobals.Kills > 50)
					{
						this.Heartbroken.Noticed = true;
					}
					else
					{
						this.Heartbroken.Noticed = false;
						this.Heartbroken.Arrested = true;
					}
					this.MainCamera.SetActive(false);
					base.gameObject.SetActive(false);
					Time.timeScale = 1f;
				}
				if (this.RivalName == "")
				{
					if (this.StudentManager.Eighties)
					{
						this.Protagonist = "Ryoba";
						this.RivalName = this.EightiesRivalNames[DateGlobals.Week];
					}
					else
					{
						this.RivalName = this.RivalNames[DateGlobals.Week];
					}
				}
			}
		}
		else
		{
			this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, Mathf.MoveTowards(this.EndOfDayDarkness.color.a, 0f, Time.deltaTime * 2f));
		}
		AudioSource component = base.GetComponent<AudioSource>();
		component.volume = Mathf.MoveTowards(component.volume, 1f, Time.deltaTime * 2f);
		if (this.WitnessList[2] != null)
		{
			this.WitnessList[2].CharacterAnimation.Play(this.WitnessList[2].IdleAnim);
		}
		if (this.WitnessList[3] != null)
		{
			this.WitnessList[3].CharacterAnimation.Play(this.WitnessList[3].IdleAnim);
		}
		if (this.WitnessList[4] != null)
		{
			this.WitnessList[4].CharacterAnimation.Play(this.WitnessList[4].IdleAnim);
		}
		if (this.WitnessList[5] != null)
		{
			this.WitnessList[5].CharacterAnimation.Play(this.WitnessList[5].IdleAnim);
		}
		if (this.ClubManager.LeaderMissing)
		{
			this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
			this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
			this.EODCamera.Translate(Vector3.forward * 0f, Space.Self);
		}
	}

	// Token: 0x0600141B RID: 5147 RVA: 0x000C0644 File Offset: 0x000BE844
	public void UpdateScene()
	{
		this.Label.color = new Color(0f, 0f, 0f, 1f);
		if (this.Counselor.LectureID == 0)
		{
			this.ID = 0;
			while (this.ID < this.WeaponManager.Weapons.Length)
			{
				if (this.WeaponManager.Weapons[this.ID] != null)
				{
					this.WeaponManager.Weapons[this.ID].gameObject.SetActive(false);
				}
				this.ID++;
			}
		}
		if (this.PoliceArrived)
		{
			if (Input.GetKeyDown(KeyCode.Backspace))
			{
				this.Finish();
			}
			if (this.Phase == 1)
			{
				Time.timeScale = 1f;
				GameGlobals.PoliceYesterday = true;
				this.CopAnimation[1]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
				this.CopAnimation[2]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
				this.CopAnimation[3]["walk_00"].speed = UnityEngine.Random.Range(0.9f, 1.1f);
				this.Counselor.LectureID = 0;
				this.Cops.SetActive(true);
				bool flag = false;
				if (this.Yandere.Egg && !flag)
				{
					this.Label.text = "The police arrive at school.";
					this.Phase = 999;
					return;
				}
				if (this.Police.PoisonScene)
				{
					this.Label.text = "The police and the paramedics arrive at school.";
					this.Phase = 103;
					return;
				}
				if (this.Police.DrownVictims == 1)
				{
					this.Label.text = "The police arrive at school.";
					this.Phase = 104;
					return;
				}
				if (this.Police.ElectroScene)
				{
					this.Label.text = "The police arrive at school.";
					this.Phase = 105;
					return;
				}
				if (this.Police.MurderSuicideScene)
				{
					this.Label.text = "The police arrive at school, and discover what appears to be the scene of a murder-suicide.";
					this.Phase++;
					return;
				}
				this.Label.text = "The police arrive at school.";
				if (this.Police.SuicideScene)
				{
					this.Phase = 102;
					return;
				}
				this.Phase++;
				return;
			}
			else if (this.Phase == 2)
			{
				if (this.Police.Corpses != 0)
				{
					Debug.Log("Corpses were present at school.");
					this.MurderScene.SetActive(true);
					List<string> list = new List<string>();
					foreach (RagdollScript ragdollScript in this.Police.CorpseList)
					{
						if (ragdollScript != null && !ragdollScript.Disposed)
						{
							if (ragdollScript.Student.StudentID == this.StudentManager.RivalID)
							{
								Debug.Log("The rival died, and now the game is determining exactly how she died.");
								this.RivalEliminationMethod = RivalEliminationType.Murdered;
								if (ragdollScript.Student.Electrified || ragdollScript.Student.Electrocuted || ragdollScript.Student.DeathType == DeathType.Burning || ragdollScript.Student.DeathType == DeathType.Weight || ragdollScript.Student.DeathType == DeathType.Drowning || ragdollScript.Student.DeathType == DeathType.Poison || ragdollScript.Student.DeathType == DeathType.Explosion)
								{
									this.RivalEliminationMethod = RivalEliminationType.Accident;
								}
								if (ragdollScript.Student.DeathType == DeathType.Burning)
								{
									GameGlobals.SpecificEliminationID = 5;
									if (!GameGlobals.Debug)
									{
										PlayerPrefs.SetInt("Burn", 1);
									}
								}
								else if (ragdollScript.Student.DeathType == DeathType.Electrocution)
								{
									Debug.Log("The game should now be informing the Content Checklist that the player has performed an electrocution.");
									GameGlobals.SpecificEliminationID = 8;
									if (!GameGlobals.Debug)
									{
										PlayerPrefs.SetInt("Electrocute", 1);
									}
								}
								else if (ragdollScript.Student.DeathType == DeathType.Weight)
								{
									GameGlobals.SpecificEliminationID = 6;
									if (!GameGlobals.Debug)
									{
										PlayerPrefs.SetInt("Crush", 1);
									}
								}
								else if (ragdollScript.Student.DeathType == DeathType.Drowning)
								{
									Debug.Log("The rival drowned.");
									if (this.PoolEvent)
									{
										Debug.Log("The player eliminated the rival during a pool event.");
										GameGlobals.SpecificEliminationID = 16;
										if (!GameGlobals.Debug)
										{
											PlayerPrefs.SetInt("Pool", 1);
										}
									}
									else
									{
										Debug.Log("The player did not eliminate the rival during a pool event.");
										GameGlobals.SpecificEliminationID = 7;
										if (!GameGlobals.Debug)
										{
											PlayerPrefs.SetInt("Drown", 1);
										}
									}
								}
								else if (ragdollScript.Decapitated)
								{
									GameGlobals.SpecificEliminationID = 10;
									if (!GameGlobals.Debug)
									{
										PlayerPrefs.SetInt("Fan", 1);
									}
								}
								else if (ragdollScript.Student.DeathType == DeathType.Poison)
								{
									GameGlobals.SpecificEliminationID = 15;
									if (!GameGlobals.Debug)
									{
										PlayerPrefs.SetInt("Poison", 1);
									}
								}
								else if (ragdollScript.Student.DeathType == DeathType.Falling)
								{
									GameGlobals.SpecificEliminationID = 17;
									if (!GameGlobals.Debug)
									{
										PlayerPrefs.SetInt("Push", 1);
									}
								}
								else if (ragdollScript.Student.Hunted)
								{
									GameGlobals.SpecificEliminationID = 14;
									if (!GameGlobals.Debug)
									{
										if (ragdollScript.Student.MurderedByFragile)
										{
											PlayerPrefs.SetInt("DrivenToMurder", 1);
										}
										else
										{
											PlayerPrefs.SetInt("MurderSuicide", 1);
										}
									}
									Debug.Log("The game knows that the rival died as part of a murder-suicide.");
								}
								else if (ragdollScript.Student.DeathType == DeathType.Weapon)
								{
									Debug.Log("The game believes that the rival died from a ''Weapon''.");
									GameGlobals.SpecificEliminationID = 1;
									if (!GameGlobals.Debug)
									{
										PlayerPrefs.SetInt("Attack", 1);
									}
								}
								else if (ragdollScript.Student.DeathType == DeathType.Explosion)
								{
									Debug.Log("The game knows that the rival died from an explosion.");
									GameGlobals.SpecificEliminationID = 20;
									if (!GameGlobals.Debug)
									{
										PlayerPrefs.SetInt("Attack", 1);
									}
								}
								else
								{
									Debug.Log("We know that the rival died, but we didn't get any noteworthy information about her death...");
								}
							}
							else if (ragdollScript.Student.StudentID > 10 && ragdollScript.Student.StudentID < DateGlobals.Week + 10)
							{
								Debug.Log("A previous rival's corpse has been discovered.");
								this.SetFormerRivalDeath(ragdollScript.Student.StudentID - 10, ragdollScript.Student);
							}
							this.VictimArray[this.Corpses] = ragdollScript.Student.StudentID;
							list.Add(ragdollScript.Student.Name);
							this.Corpses++;
						}
					}
					list.Sort();
					string text = "The police discover the corpse" + ((list.Count == 1) ? string.Empty : "s") + " of ";
					if (list.Count == 1)
					{
						this.Label.text = text + list[0] + ".";
					}
					else if (list.Count == 2)
					{
						this.Label.text = string.Concat(new string[]
						{
							text,
							list[0],
							" and ",
							list[1],
							"."
						});
					}
					else if (list.Count < 6)
					{
						this.Label.text = "The police discover multiple corpses on school grounds.";
						StringBuilder stringBuilder = new StringBuilder();
						for (int j = 0; j < list.Count - 1; j++)
						{
							stringBuilder.Append(list[j] + ", ");
						}
						stringBuilder.Append("and " + list[list.Count - 1] + ".");
						this.Label.text = text + stringBuilder.ToString();
					}
					else
					{
						this.Label.text = "The police discover more than five corpses on school grounds.";
					}
					this.Phase++;
					return;
				}
				Debug.Log("Zero corpses were present at school.");
				if (!this.Police.PoisonScene && !this.Police.SuicideScene)
				{
					if (this.Police.LimbParent.childCount > 0 || this.Police.GarbageParent.childCount > 0)
					{
						if (this.Police.LimbParent.childCount + this.Police.GarbageParent.childCount == 1)
						{
							this.Label.text = "The police find a severed body part at school.";
						}
						else
						{
							this.Label.text = "The police find multiple severed body parts at school.";
						}
						this.MurderScene.SetActive(true);
					}
					else
					{
						this.SearchingCop.SetActive(true);
						if (this.Police.BloodParent.childCount - this.ClothingWithRedPaint > 0)
						{
							this.Label.text = "The police find mysterious blood stains, but are unable to locate any corpses on school grounds.";
						}
						else if (this.ClothingWithRedPaint == 0)
						{
							this.Label.text = "The police are unable to locate any corpses on school grounds.";
						}
						else
						{
							this.Label.text = "The police find clothing that is stained with red paint, but are unable to locate any actual blood stains, and cannot locate any corpses, either.";
						}
					}
					this.Phase++;
					return;
				}
				this.SearchingCop.SetActive(true);
				this.Label.text = "The police are unable to locate any other corpses on school grounds.";
				this.Phase++;
				return;
			}
			else if (this.Phase == 3)
			{
				this.WeaponManager.CheckWeapons();
				if (this.WeaponManager.MurderWeapons != 0)
				{
					this.MurderWeapon = null;
					this.ID = 0;
					while (this.ID < this.WeaponManager.Weapons.Length)
					{
						if (this.MurderWeapon == null)
						{
							WeaponScript weaponScript = this.WeaponManager.Weapons[this.ID];
							if (weaponScript != null && weaponScript.Blood.enabled)
							{
								if (!weaponScript.AlreadyExamined)
								{
									weaponScript.gameObject.SetActive(true);
									weaponScript.AlreadyExamined = true;
									this.MurderWeapon = weaponScript;
									this.WeaponID = this.ID;
								}
								else
								{
									weaponScript.gameObject.SetActive(false);
								}
							}
						}
						this.ID++;
					}
					List<string> list2 = new List<string>();
					this.ID = 0;
					while (this.ID < this.MurderWeapon.Victims.Length)
					{
						if (this.MurderWeapon.Victims[this.ID])
						{
							list2.Add(this.JSON.Students[this.ID].Name);
						}
						this.ID++;
					}
					list2.Sort();
					this.Victims = list2.Count;
					string name = this.MurderWeapon.Name;
					string str = (name[name.Length - 1] != 's') ? ("a " + name.ToLower() + " that is") : (name.ToLower() + " that are");
					string text2 = "The police discover " + str + " stained with the blood of ";
					if (list2.Count == 1)
					{
						this.Label.text = text2 + list2[0] + ".";
					}
					else if (list2.Count == 2)
					{
						this.Label.text = string.Concat(new string[]
						{
							text2,
							list2[0],
							" and ",
							list2[1],
							"."
						});
					}
					else
					{
						StringBuilder stringBuilder2 = new StringBuilder();
						for (int k = 0; k < list2.Count - 1; k++)
						{
							stringBuilder2.Append(list2[k] + ", ");
						}
						stringBuilder2.Append("and " + list2[list2.Count - 1] + ".");
						this.Label.text = text2 + stringBuilder2.ToString();
					}
					this.Weapons++;
					this.Phase++;
					this.MurderWeapon.transform.parent = base.transform;
					this.MurderWeapon.transform.localPosition = new Vector3(0.6f, 1.4f, -1.5f);
					this.MurderWeapon.transform.localEulerAngles = new Vector3(-45f, 90f, -90f);
					this.MurderWeapon.MyRigidbody.useGravity = false;
					this.MurderWeapon.Rotate = true;
					return;
				}
				this.ShruggingCops.SetActive(true);
				if (this.Weapons == 0)
				{
					this.Label.text = "The police are unable to locate any murder weapons.";
					this.Phase += 2;
					return;
				}
				this.Phase += 2;
				this.UpdateScene();
				return;
			}
			else if (this.Phase == 4)
			{
				if (this.MurderWeapon.FingerprintID == 0)
				{
					this.ShruggingCops.SetActive(true);
					this.Label.text = "The police find no fingerprints on the weapon.";
					this.Phase = 3;
					return;
				}
				if (this.MurderWeapon.FingerprintID == 100)
				{
					this.TeleportYandere();
					this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
					if (this.Yandere.StudentManager.Eighties)
					{
						this.Yandere.LoseGentleEyes();
					}
					this.Label.text = "The police find " + this.Protagonist + "'s fingerprints on the weapon.";
					this.Phase = 100;
					return;
				}
				int fingerprintID = this.WeaponManager.Weapons[this.WeaponID].FingerprintID;
				this.TabletCop.SetActive(true);
				this.CopAnimation[4]["scienceTablet_00"].speed = 0f;
				this.TabletPortrait.material.mainTexture = this.VoidGoddess.Portraits[fingerprintID].mainTexture;
				this.Label.text = "The police find the fingerprints of " + this.JSON.Students[fingerprintID].Name + " on the weapon.";
				this.Phase = 101;
				return;
			}
			else if (this.Phase == 5)
			{
				if (this.Police.PhotoEvidence > 0)
				{
					this.TeleportYandere();
					this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
					if (this.Yandere.StudentManager.Eighties)
					{
						this.Yandere.LoseGentleEyes();
					}
					this.ShruggingCops.SetActive(false);
					this.Label.text = "The police find a smartphone with photographic evidence of " + this.Protagonist + " committing a crime.";
					this.Phase = 100;
					return;
				}
				this.Phase++;
				this.UpdateScene();
				return;
			}
			else if (this.Phase == 6)
			{
				if (!SchoolGlobals.HighSecurity)
				{
					this.Phase++;
					this.UpdateScene();
					return;
				}
				this.SecuritySystemScene.SetActive(true);
				if (!this.SecuritySystem.Evidence)
				{
					this.Label.text = "The police investigate the security camera recordings, but cannot find anything incriminating in the footage.";
					this.Phase++;
					return;
				}
				if (!this.SecuritySystem.Masked)
				{
					this.Label.text = "The police investigate the security camera recordings, and find incriminating footage of " + this.Protagonist + ".";
					this.Phase = 100;
					return;
				}
				this.Label.text = "The police investigate the security camera recordings, and find footage of a suspicious masked person.";
				this.Police.MaskReported = true;
				this.Phase++;
				return;
			}
			else if (this.Phase == 7)
			{
				this.ID = 1;
				while (this.ID < this.StudentManager.Students.Length)
				{
					if (this.StudentManager.Students[this.ID] != null && this.StudentManager.Students[this.ID].Alive && this.StudentManager.Students[this.ID].Persona != PersonaType.Coward && this.StudentManager.Students[this.ID].Persona != PersonaType.Spiteful && this.StudentManager.Students[this.ID].Club != ClubType.Delinquent && !this.StudentManager.Students[this.ID].SawMask && this.StudentManager.Students[this.ID].WitnessedMurder)
					{
						this.EyeWitnesses++;
						this.WitnessList[this.EyeWitnesses] = this.StudentManager.Students[this.ID];
					}
					this.ID++;
				}
				if (this.EyeWitnesses <= 0)
				{
					this.Phase++;
					this.UpdateScene();
					return;
				}
				this.DisableThings(this.WitnessList[1]);
				this.DisableThings(this.WitnessList[2]);
				this.DisableThings(this.WitnessList[3]);
				this.DisableThings(this.WitnessList[4]);
				this.DisableThings(this.WitnessList[5]);
				this.WitnessList[1].transform.localPosition = Vector3.zero;
				if (this.WitnessList[2] != null)
				{
					this.WitnessList[2].transform.localPosition = new Vector3(-1f, 0f, -0.5f);
				}
				if (this.WitnessList[3] != null)
				{
					this.WitnessList[3].transform.localPosition = new Vector3(1f, 0f, -0.5f);
				}
				if (this.WitnessList[4] != null)
				{
					this.WitnessList[4].transform.localPosition = new Vector3(-2f, 0f, -1f);
				}
				if (this.WitnessList[5] != null)
				{
					this.WitnessList[5].transform.localPosition = new Vector3(1.5f, 0f, -1f);
				}
				if (this.WitnessList[1].Male)
				{
					this.WitnessList[1].CharacterAnimation.Play("carefreeTalk_02");
				}
				else
				{
					this.WitnessList[1].CharacterAnimation.Play("f02_carefreeTalk_02");
				}
				this.EyeWitnessScene.SetActive(true);
				if (this.EyeWitnesses == 1)
				{
					this.Label.text = string.Concat(new string[]
					{
						"One student accuses ",
						this.Protagonist,
						" of murder, but nobody else can corroborate that students' claims, so the police are unable to develop reasonable justification to arrest ",
						this.Protagonist,
						"."
					});
					this.Phase++;
					return;
				}
				if (this.EyeWitnesses < 5)
				{
					this.Label.text = "Several students accuse " + this.Protagonist + " of murder, but there are not enough witnesses to provide the police with reasonable justification to arrest her.";
					this.Phase++;
					return;
				}
				this.Label.text = "Numerous students accuse " + this.Protagonist + " of murder, providing the police with enough justification to arrest her.";
				this.Phase = 100;
				return;
			}
			else if (this.Phase == 8)
			{
				this.ShruggingCops.SetActive(false);
				if (this.Yandere.Sanity > 33.33333f)
				{
					if ((this.Yandere.Bloodiness > 0f && !this.Yandere.RedPaint) || (this.Yandere.Gloved && this.Yandere.Gloves.Blood.enabled))
					{
						if (this.Arrests == 0)
						{
							this.TeleportYandere();
							this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
							if (this.Yandere.StudentManager.Eighties)
							{
								this.Yandere.LoseGentleEyes();
							}
							this.Label.text = string.Concat(new string[]
							{
								"The police notice that ",
								this.Protagonist,
								"'s clothing is bloody. They confirm that the blood is not hers. ",
								this.Protagonist,
								" is unable to convince the police that she did not commit murder."
							});
							this.Phase = 100;
							return;
						}
						this.TeleportYandere();
						this.Yandere.CharacterAnimation["YandereConfessionRejected"].time = 4f;
						this.Yandere.CharacterAnimation.Play("YandereConfessionRejected");
						this.Label.text = string.Concat(new string[]
						{
							"The police notice that ",
							this.Protagonist,
							"'s clothing is bloody. They confirm that the blood is not hers. ",
							this.Protagonist,
							" is able to convince the police that she was splashed with blood while witnessing a murder."
						});
						if (!this.TranqCase.Occupied)
						{
							this.Phase += 2;
							return;
						}
						this.Phase++;
						return;
					}
					else
					{
						if (this.Police.BloodyClothing - this.ClothingWithRedPaint > 0)
						{
							this.TeleportYandere();
							this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
							if (this.Yandere.StudentManager.Eighties)
							{
								this.Yandere.LoseGentleEyes();
							}
							this.Label.text = string.Concat(new string[]
							{
								"The police find bloody clothing that has traces of ",
								this.Protagonist,
								"'s DNA. ",
								this.Protagonist,
								" is unable to convince the police that she did not commit murder."
							});
							this.Phase = 100;
							return;
						}
						this.TeleportYandere();
						this.Yandere.CharacterAnimation["YandereConfessionRejected"].time = 4f;
						this.Yandere.CharacterAnimation.Play("YandereConfessionRejected");
						this.Label.text = string.Concat(new string[]
						{
							"The police question all students in the school, including ",
							this.Protagonist,
							". The police are unable to link ",
							this.Protagonist,
							" to any crimes."
						});
						if (!this.TranqCase.Occupied)
						{
							this.Phase += 2;
						}
						else if (this.TranqCase.VictimID == this.ArrestID)
						{
							this.Phase += 2;
						}
						else
						{
							this.Phase++;
						}
						if (this.Yandere.StudentManager.Eighties)
						{
							this.Yandere.LoseGentleEyes();
							return;
						}
					}
				}
				else
				{
					this.TeleportYandere();
					this.Yandere.CharacterAnimation.Play("f02_disappointed_00");
					if (this.Yandere.StudentManager.Eighties)
					{
						this.Yandere.LoseGentleEyes();
					}
					if (this.Yandere.Bloodiness == 0f)
					{
						this.Label.text = string.Concat(new string[]
						{
							"The police question ",
							this.Protagonist,
							", who exhibits extremely unusual behavior. The police decide to investigate ",
							this.Protagonist,
							" further, and eventually learn of her crimes."
						});
						this.Phase = 100;
						return;
					}
					this.Label.text = string.Concat(new string[]
					{
						"The police notice that ",
						this.Protagonist,
						" is covered in blood and exhibiting extremely unusual behavior. The police decide to investigate ",
						this.Protagonist,
						" further, and eventually learn of her crimes."
					});
					this.Phase = 100;
					return;
				}
			}
			else
			{
				if (this.Phase == 9)
				{
					this.KidnappedVictim = this.StudentManager.Students[this.TranqCase.VictimID];
					this.KidnappedVictim.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.KidnappedVictim.CharacterAnimation.enabled = true;
					this.KidnappedVictim.gameObject.SetActive(true);
					this.KidnappedVictim.Ragdoll.Zs.SetActive(false);
					this.KidnappedVictim.transform.parent = base.transform;
					this.KidnappedVictim.transform.localPosition = new Vector3(0f, 0.145f, 0f);
					this.KidnappedVictim.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
					this.KidnappedVictim.CharacterAnimation.Play("f02_sit_06");
					this.KidnappedVictim.WhiteQuestionMark.SetActive(true);
					this.OpenTranqCase.SetActive(true);
					this.Label.text = "The police discover " + this.JSON.Students[this.TranqCase.VictimID].Name + " inside of a musical instrument case. However, she is unable to recall how she got inside of the case. The police are unable to determine what happened.";
					StudentGlobals.SetStudentKidnapped(this.TranqCase.VictimID, false);
					StudentGlobals.SetStudentMissing(this.TranqCase.VictimID, false);
					this.TranqCase.VictimClubType = ClubType.None;
					this.TranqCase.VictimID = 0;
					this.TranqCase.Occupied = false;
					this.Phase++;
					return;
				}
				if (this.Phase == 10)
				{
					if (this.Police.MaskReported)
					{
						this.Mask.SetActive(true);
						GameGlobals.MasksBanned = true;
						if (this.SecuritySystem.Masked)
						{
							this.Label.text = "In security camera footage, the killer was wearing a mask. As a result, the police are unable to gather meaningful information about the murderer. To prevent this from ever happening again, the Headmaster decides to ban all masks from the school from this day forward.";
						}
						else
						{
							this.Label.text = "Witnesses state that the killer was wearing a mask. As a result, the police are unable to gather meaningful information about the murderer. To prevent this from ever happening again, the Headmaster decides to ban all masks from the school from this day forward.";
						}
						this.Police.MaskReported = false;
						this.Phase++;
						return;
					}
					this.Phase++;
					this.UpdateScene();
					return;
				}
				else if (this.Phase == 11)
				{
					this.Cops.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					this.Cops.SetActive(true);
					if (this.Arrests == 0)
					{
						if (this.DeadPerps == 0)
						{
							this.Label.text = "The police do not have enough evidence to perform an arrest. The police investigation ends, and students are free to leave.";
						}
						else if (this.Police.MurderSuicideScene)
						{
							this.Label.text = "The police conclude that a murder-suicide took place, but are unable to take any further action. The police investigation ends, and students are free to leave.";
						}
						else
						{
							this.Label.text = "The police believe that they know the identity of the killer, but they cannot locate the suspect at school. The police leave to search for the person that they believe is the killer. The police investigation ends, and students are free to leave.";
						}
					}
					else if (this.Arrests == 1)
					{
						this.Label.text = "The police believe that they have arrested the perpetrator of the crime. The police investigation ends, and students are free to leave.";
					}
					else
					{
						this.Label.text = "The police believe that they have arrested the perpetrators of the crimes. The police investigation ends, and students are free to leave.";
					}
					if (this.StudentManager.RivalEliminated || this.RivalEliminationMethod != RivalEliminationType.None)
					{
						this.Phase++;
						return;
					}
					if (DateGlobals.Weekday == DayOfWeek.Friday)
					{
						this.Phase = 23;
						return;
					}
					this.Phase += 2;
					return;
				}
				else
				{
					if (this.Phase == 12)
					{
						this.Senpai.enabled = false;
						this.Senpai.transform.parent = base.transform;
						this.Senpai.gameObject.SetActive(true);
						this.Senpai.transform.localPosition = new Vector3(0f, 0f, 0f);
						this.Senpai.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						this.Senpai.EmptyHands();
						Physics.SyncTransforms();
						string str2 = "";
						if (this.Yandere.Egg && this.RivalEliminationMethod == RivalEliminationType.None)
						{
							this.RivalEliminationMethod = RivalEliminationType.Murdered;
						}
						if (this.RivalEliminationMethod == RivalEliminationType.None)
						{
							this.Label.text = "Your Senpai feels a growing sense of concern that the school may not be safe.";
						}
						else if (this.RivalEliminationMethod == RivalEliminationType.Murdered || this.RivalEliminationMethod == RivalEliminationType.MurderedWitnessed || this.RivalEliminationMethod == RivalEliminationType.Accident || this.RivalEliminationMethod == RivalEliminationType.SuicideFake)
						{
							if (!this.StudentManager.Eighties)
							{
								this.Senpai.CharacterAnimation.Play("kneelCry_00");
								if (DateGlobals.Weekday != DayOfWeek.Friday)
								{
									str2 = "\nSenpai will stay home from school for one day to mourn her death.";
									GameGlobals.SenpaiMourning = true;
								}
								this.Label.text = "Senpai is absolutely devastated by the death of his childhood friend. His mental stability has been greatly affected." + str2;
							}
							else
							{
								this.Senpai.CharacterAnimation.Play(this.Senpai.BulliedIdleAnim);
								this.Label.text = "Senpai is deeply saddened by the death of his friend.";
							}
						}
						else
						{
							this.Senpai.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
							if (this.RivalEliminationMethod == RivalEliminationType.Arrested)
							{
								this.Senpai.CharacterAnimation["refuse_02"].speed = 0.5f;
								this.Senpai.CharacterAnimation.Play("refuse_02");
								this.Label.text = "Senpai is disgusted to learn that " + this.RivalName + " would actually commit murder. He is deeply disappointed in her.";
							}
							else if (this.RivalEliminationMethod == RivalEliminationType.Befriended || this.RivalEliminationMethod == RivalEliminationType.Matchmade)
							{
								this.Senpai.CharacterAnimation.Play(this.Senpai.BulliedIdleAnim);
								this.Label.text = "Senpai notices that " + this.RivalName + " is distancing herself from him. He feels a little sad about it, but he accepts it.";
							}
							else if (this.RivalEliminationMethod == RivalEliminationType.Expelled)
							{
								this.Senpai.CharacterAnimation.Play("surprisedPose_00");
								this.Label.text = "Senpai is shocked to learn that " + this.RivalName + " has been expelled. He is deeply disappointed in her.";
							}
							else if (this.RivalEliminationMethod == RivalEliminationType.Ruined)
							{
								this.Senpai.CharacterAnimation["refuse_02"].speed = 0.5f;
								this.Senpai.CharacterAnimation.Play("refuse_02");
								this.Label.text = "Senpai is disturbed by the rumors circulating about " + this.RivalName + ". He is deeply disappointed in her.";
							}
							else if (this.RivalEliminationMethod == RivalEliminationType.Rejected)
							{
								this.Senpai.CharacterAnimation.Play(this.Senpai.BulliedIdleAnim);
								this.Label.text = "Senpai feels guilty for turning down " + this.RivalName + "'s feelings, but also he knows that he cannot take back what has been said.";
							}
							else if (this.RivalEliminationMethod == RivalEliminationType.Vanished)
							{
								this.Senpai.CharacterAnimation.Play(this.Senpai.BulliedIdleAnim);
								this.Label.text = "Senpai is concerned about the sudden disappearance of " + this.RivalName + ". His mental stability has been slightly affected.";
							}
						}
						this.Phase++;
						return;
					}
					if (this.Phase == 13)
					{
						this.Senpai.enabled = false;
						this.Senpai.transform.parent = base.transform;
						this.Senpai.gameObject.SetActive(true);
						this.Senpai.transform.localPosition = new Vector3(0f, 0f, 0f);
						this.Senpai.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.Senpai.EmptyHands();
						if (this.StudentManager.RivalEliminated)
						{
							this.Senpai.CharacterAnimation.Play(this.Senpai.BulliedWalkAnim);
						}
						else
						{
							this.Senpai.CharacterAnimation.Play(this.Senpai.WalkAnim);
						}
						this.Yandere.LookAt.enabled = true;
						this.Yandere.MyController.enabled = false;
						this.Yandere.transform.parent = base.transform;
						this.Yandere.transform.localPosition = new Vector3(2.5f, 0f, 2.5f);
						this.Yandere.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.Yandere.CharacterAnimation.Play(this.Yandere.WalkAnim);
						this.Label.text = this.Protagonist + " stalks Senpai until he has returned home, and then returns to her own home.";
						if (GameGlobals.SenpaiMourning)
						{
							this.Senpai.gameObject.SetActive(false);
							this.Yandere.LookAt.enabled = false;
							this.Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
							this.Yandere.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
							this.Label.text = this.Protagonist + " returns home, thinking of Senpai every step of the way.";
						}
						Physics.SyncTransforms();
						this.Phase++;
						return;
					}
					if (this.Phase == 14)
					{
						Debug.Log("We're currently in the End-of-Day sequence, checking to see if the Counselor has to lecture anyone.");
						if (StudentGlobals.GetStudentDying(this.StudentManager.RivalID) || StudentGlobals.GetStudentDead(this.StudentManager.RivalID) || StudentGlobals.GetStudentArrested(this.StudentManager.RivalID))
						{
							this.Phase++;
							this.UpdateScene();
							return;
						}
						Debug.Log("The current rival is not dying, dead, or arrested.");
						if (this.Counselor.LectureID > 0)
						{
							this.Yandere.gameObject.SetActive(false);
							for (int l = 1; l < 101; l++)
							{
								this.StudentManager.DisableStudent(l);
							}
							this.EODCamera.position = new Vector3(-18.5f, 1f, 6.5f);
							this.EODCamera.eulerAngles = new Vector3(0f, -45f, 0f);
							this.EODCamera.Translate(this.EODCamera.transform.forward * 0.3f);
							this.Counselor.Lecturing = true;
							base.enabled = false;
							Debug.Log("The counselor is going to lecture somebody! Exiting End-of-Day sequence.");
							return;
						}
						this.Phase++;
						this.UpdateScene();
						return;
					}
					else if (this.Phase == 15)
					{
						this.EODCamera.localPosition = new Vector3(1f, 1.8f, -2.5f);
						this.EODCamera.localEulerAngles = new Vector3(22.5f, -22.5f, 0f);
						this.TextWindow.SetActive(true);
						if (this.Counselor.MustReturnStolenRing)
						{
							if (!this.StudentManager.Eighties)
							{
								this.GaudyRing.SetActive(true);
							}
							else
							{
								this.EightiesGaudyRing.SetActive(true);
							}
							if (!this.StudentManager.Eighties)
							{
								this.Label.text = "The guidance counselor returns Sakyu's stolen ring to her. Sakyu decides to stop bringing the ring to school.";
								GameGlobals.RingStolen = true;
							}
							else
							{
								this.Label.text = "The guidance counselor returns Himeko's stolen ring to her. Having her ring stolen does not affect Himeko's decision to wear expensive jewelry at school every day.";
							}
							this.Counselor.MustReturnStolenRing = false;
							return;
						}
						if (SchemeGlobals.GetSchemeStage(2) == 3)
						{
							this.GaudyRing.SetActive(true);
							if (!StudentGlobals.GetStudentDying(this.StudentManager.RivalID) && !StudentGlobals.GetStudentDead(this.StudentManager.RivalID) && !StudentGlobals.GetStudentArrested(this.StudentManager.RivalID))
							{
								this.Label.text = this.RivalName + " discovers a ring inside of her book bag. She returns the ring to its owner.";
							}
							else
							{
								this.Label.text = "Sakyu Basu will never recover her stolen ring.";
							}
							SchemeGlobals.SetSchemeStage(2, 100);
							GameGlobals.RingStolen = true;
							return;
						}
						this.Phase++;
						this.UpdateScene();
						return;
					}
					else if (this.Phase == 16)
					{
						if (this.Police.Deaths + PlayerGlobals.Kills > 50)
						{
							this.EODCamera.position = new Vector3(-6f, 0.15f, -49f);
							this.EODCamera.eulerAngles = new Vector3(-22.5f, 22.5f, 0f);
							this.Label.text = string.Concat(new string[]
							{
								"More than half of the school's population is dead. For the safety of the remaining students, the headmaster of Akademi makes the decision to shut down the school. Senpai enrolls in a school far away. ",
								this.Protagonist,
								" will not be able to follow him, and another girl will steal his heart. ",
								this.Protagonist,
								" has permanently lost her chance to be with Senpai."
							});
							this.Heartbroken.NoSnap = true;
							this.GameOver = true;
							return;
						}
						this.Phase++;
						this.UpdateScene();
						return;
					}
					else if (this.Phase == 17)
					{
						Debug.Log("Phase 13 - checking for clubs shutting down.");
						this.ClubLimit = this.ClubArray.Length;
						if (!GameGlobals.Eighties)
						{
							this.ClubLimit--;
						}
						this.ClubClosed = false;
						this.ClubKicked = false;
						this.DistanceToMoveForward = 1.2f;
						Debug.Log("As of right now, ClubID is: " + this.ClubID.ToString());
						Debug.Log("As of right now, ClubLimit is: " + this.ClubLimit.ToString());
						if (this.ClubID < this.ClubLimit)
						{
							Debug.Log("ClubID is less than ClubLimit, so we're checking a club.");
							if (this.StudentManager.Eighties && this.ClubID == 11)
							{
								this.ClubID++;
							}
							if (!ClubGlobals.GetClubClosed(this.ClubArray[this.ClubID]))
							{
								Debug.Log("Right now, we're checking the " + this.ClubNames[this.ClubID].ToString() + ".");
								this.ClubManager.CheckClub(this.ClubArray[this.ClubID]);
								if (this.ClubManager.ClubMembers < 5)
								{
									this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
									this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
									this.EODCamera.Translate(Vector3.forward * this.DistanceToMoveForward, Space.Self);
									ClubGlobals.SetClubClosed(this.ClubArray[this.ClubID], true);
									if (this.ClubID != 11)
									{
										this.Label.text = "The " + this.ClubNames[this.ClubID].ToString() + " no longer has enough members to remain operational. The school forces the club to disband.";
									}
									else if (this.ClubManager.ClubMembers > 0)
									{
										this.Label.text = "The Gaming Club makes the decision to disband.";
									}
									else
									{
										this.Label.text = "The Gaming Club no longer exists.";
									}
									this.ClubClosed = true;
									if (this.Yandere.Club == this.ClubArray[this.ClubID])
									{
										this.Yandere.Club = ClubType.None;
									}
								}
								Debug.Log("Checking if a club leader is missing...");
								if (this.ClubManager.LeaderMissing)
								{
									Debug.Log("A club leader has gone missing!");
									this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
									this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
									this.EODCamera.Translate(Vector3.forward * this.DistanceToMoveForward, Space.Self);
									ClubGlobals.SetClubClosed(this.ClubArray[this.ClubID], true);
									this.Label.text = string.Concat(new string[]
									{
										"The leader of the ",
										this.ClubNames[this.ClubID].ToString(),
										" has gone missing. The ",
										this.ClubNames[this.ClubID].ToString(),
										" cannot operate without its leader. The club disbands."
									});
									this.ClubClosed = true;
									if (this.Yandere.Club == this.ClubArray[this.ClubID])
									{
										this.Yandere.Club = ClubType.None;
									}
								}
								else if (this.ClubManager.LeaderDead)
								{
									this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
									this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
									this.EODCamera.Translate(Vector3.forward * this.DistanceToMoveForward, Space.Self);
									ClubGlobals.SetClubClosed(this.ClubArray[this.ClubID], true);
									this.Label.text = string.Concat(new string[]
									{
										"The leader of the ",
										this.ClubNames[this.ClubID].ToString(),
										" is gone. The ",
										this.ClubNames[this.ClubID].ToString(),
										" cannot operate without its leader. The club disbands."
									});
									this.ClubClosed = true;
									if (this.Yandere.Club == this.ClubArray[this.ClubID])
									{
										this.Yandere.Club = ClubType.None;
									}
								}
								else if (this.ClubManager.LeaderAshamed)
								{
									this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
									this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
									this.EODCamera.Translate(Vector3.forward * this.DistanceToMoveForward, Space.Self);
									ClubGlobals.SetClubClosed(this.ClubArray[this.ClubID], true);
									this.Label.text = "The leader of the " + this.ClubNames[this.ClubID].ToString() + " has unexpectedly disbanded the club without explanation.";
									this.ClubClosed = true;
									this.ClubManager.LeaderAshamed = false;
									if (this.Yandere.Club == this.ClubArray[this.ClubID])
									{
										this.Yandere.Club = ClubType.None;
									}
								}
							}
							if (!ClubGlobals.GetClubClosed(this.ClubArray[this.ClubID]) && !ClubGlobals.GetClubKicked(this.ClubArray[this.ClubID]) && this.Yandere.Club == this.ClubArray[this.ClubID])
							{
								this.ClubManager.CheckGrudge(this.ClubArray[this.ClubID]);
								if (this.ClubManager.LeaderGrudge)
								{
									this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
									this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
									this.EODCamera.Translate(Vector3.forward * this.DistanceToMoveForward, Space.Self);
									this.Label.text = string.Concat(new string[]
									{
										this.Protagonist,
										" receives a message from the president of the ",
										this.ClubNames[this.ClubID].ToString(),
										". ",
										this.Protagonist,
										" is no longer a member of the ",
										this.ClubNames[this.ClubID].ToString(),
										", and is not welcome in the ",
										this.ClubNames[this.ClubID].ToString(),
										" room."
									});
									ClubGlobals.SetClubKicked(this.ClubArray[this.ClubID], true);
									this.Yandere.Club = ClubType.None;
									this.ClubKicked = true;
								}
								else if (this.ClubManager.ClubGrudge)
								{
									this.EODCamera.position = this.ClubManager.ClubVantages[this.ClubID].position;
									this.EODCamera.eulerAngles = this.ClubManager.ClubVantages[this.ClubID].eulerAngles;
									this.EODCamera.Translate(Vector3.forward * this.DistanceToMoveForward, Space.Self);
									this.Label.text = string.Concat(new string[]
									{
										this.Protagonist,
										" receives a message from the president of the ",
										this.ClubNames[this.ClubID].ToString(),
										". There is someone in the ",
										this.ClubNames[this.ClubID].ToString(),
										" who hates and fears ",
										this.Protagonist,
										". ",
										this.Protagonist,
										" is no longer a member of the ",
										this.ClubNames[this.ClubID].ToString(),
										", and is not welcome in the ",
										this.ClubNames[this.ClubID].ToString(),
										" room."
									});
									ClubGlobals.SetClubKicked(this.ClubArray[this.ClubID], true);
									this.Yandere.Club = ClubType.None;
									this.ClubKicked = true;
								}
							}
							if (!this.ClubClosed && !this.ClubKicked)
							{
								this.ClubID++;
								this.UpdateScene();
							}
							this.ClubManager.LeaderAshamed = false;
							return;
						}
						this.Phase++;
						this.UpdateScene();
						return;
					}
					else if (this.Phase == 18)
					{
						if (this.TranqCase.Occupied)
						{
							this.ClosedTranqCase.SetActive(true);
							this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 1f);
							if (this.StudentManager.Eighties)
							{
								this.Protagonist = "Ryoba";
							}
							this.Label.text = this.Protagonist + " waits until midnight, sneaks into school, and returns to the musical instrument case that contains her unconscious victim. She pushes the case back to her house and ties the victim to a chair in her basement.";
							if (this.TranqCase.VictimID == this.StudentManager.RivalID)
							{
								this.RivalEliminationMethod = RivalEliminationType.Vanished;
								GameGlobals.SpecificEliminationID = 12;
								if (!GameGlobals.Debug)
								{
									PlayerPrefs.SetInt("Kidnap", 1);
								}
							}
							this.Phase++;
							return;
						}
						this.Phase++;
						this.UpdateScene();
						return;
					}
					else if (this.Phase == 19)
					{
						if (this.ErectFence)
						{
							this.Fence.SetActive(true);
							this.Label.text = "To prevent any other students from falling off of the school rooftop, the school erects a fence around the roof.";
							SchoolGlobals.RoofFence = true;
							this.ErectFence = false;
							return;
						}
						this.Phase++;
						this.UpdateScene();
						return;
					}
					else if (this.Phase == 20)
					{
						if (!SchoolGlobals.HighSecurity && this.Police.CouncilDeath)
						{
							if (!this.StudentManager.Eighties)
							{
								this.SCP.SetActive(true);
								this.Label.text = "The student council president has ordered the implementation of heightened security precautions. Security cameras and metal detectors are now present at school.";
							}
							else
							{
								this.Headmaster.SetActive(true);
								this.Label.text = "The headmaster has ordered the implementation of heightened security precautions. Security cameras and metal detectors are now present at school.";
							}
							this.Police.CouncilDeath = false;
							return;
						}
						this.Phase++;
						this.UpdateScene();
						return;
					}
					else if (this.Phase == 21)
					{
						Debug.Log("The End-of-Day sequence is now checking the rival's reputation.");
						this.Rival = this.StudentManager.Students[this.StudentManager.RivalID];
						if (this.ArticleID == 2)
						{
							this.StudentManager.StudentReps[this.StudentManager.RivalID] -= 20f * (1f + (float)this.Class.LanguageGrade * 0.2f);
							StudentGlobals.SetStudentReputation(this.StudentManager.RivalID, Mathf.RoundToInt(this.StudentManager.StudentReps[this.StudentManager.RivalID]));
						}
						if (this.Rival != null && this.Rival.Alive && this.StudentManager.StudentReps[this.StudentManager.RivalID] <= -100f)
						{
							Debug.Log("The rival is not null, the rival is alive, and the rival's reputation is below -100.");
							this.Rival.gameObject.SetActive(true);
							this.Rival.transform.parent = base.transform;
							this.Rival.transform.localPosition = new Vector3(0f, 0f, 0f);
							this.Rival.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
							this.Rival.CharacterAnimation.Play(this.Rival.BulliedWalkAnim);
							this.Rival.CharacterAnimation.enabled = true;
							if (this.StudentManager.Eighties)
							{
								this.RivalName = this.EightiesRivalNames[DateGlobals.Week];
							}
							else
							{
								this.RivalName = this.RivalNames[DateGlobals.Week];
							}
							this.Label.text = this.RivalName + " cannot endure the bullying and harassment that she is being subjected to due to her damaged reputation. She chooses to withdraw from Akademi and never return.";
							this.RivalEliminationMethod = RivalEliminationType.Ruined;
							this.StudentManager.RivalEliminated = true;
							GameGlobals.SpecificEliminationID = 4;
							if (this.StudentManager.StudentReps[this.StudentManager.RivalID] <= -150f)
							{
								this.Label.text = this.RivalName + " is absolutely devastated by the unbearable bullying and harassment that she is being subjected to. She silently returns to her home, planning something drastic...";
								this.Rival.CharacterAnimation.Play(this.Rival.BulliedIdleAnim);
								this.RivalEliminationMethod = RivalEliminationType.SuicideBully;
								this.GoToSuicideScene = true;
								GameGlobals.SpecificEliminationID = 19;
								if (!GameGlobals.Debug)
								{
									PlayerPrefs.SetInt("Suicide", 1);
								}
							}
							else
							{
								Debug.Log("Informing the Content Checklist.");
								if (!GameGlobals.Debug)
								{
									PlayerPrefs.SetInt("Bully", 1);
								}
							}
							this.Phase++;
							return;
						}
						this.Phase++;
						this.UpdateScene();
						return;
					}
					else
					{
						if (this.Phase == 22)
						{
							this.Finish();
							return;
						}
						if (this.Phase == 23)
						{
							this.Senpai.enabled = false;
							this.Senpai.Pathfinding.enabled = false;
							this.Senpai.transform.parent = base.transform;
							this.Senpai.gameObject.SetActive(true);
							this.Senpai.transform.localPosition = new Vector3(0f, 0f, 0f);
							this.Senpai.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							this.Senpai.EmptyHands();
							this.Senpai.MyController.enabled = false;
							this.Senpai.CharacterAnimation.enabled = true;
							this.Senpai.CharacterAnimation.CrossFade(this.Senpai.IdleAnim);
							this.Rival.enabled = false;
							this.Rival.Pathfinding.enabled = false;
							this.Rival.transform.parent = base.transform;
							this.Rival.gameObject.SetActive(true);
							this.Rival.transform.localPosition = new Vector3(0f, 0f, 1f);
							this.Rival.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
							this.Rival.EmptyHands();
							this.Rival.MyController.enabled = false;
							this.Rival.CharacterAnimation.enabled = true;
							this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
							this.Rival.CharacterAnimation["f02_shy_00"].weight = 1f;
							this.Rival.CharacterAnimation.Play("f02_shy_00");
							this.Label.text = "After the police investigation ends, " + this.RivalName + " asks Senpai to speak with her under the cherry tree behind the school.";
							this.Phase++;
							return;
						}
						if (this.Phase == 24)
						{
							for (int m = 1; m < 101; m++)
							{
								this.StudentManager.DisableStudent(m);
							}
							this.LoveManager.Suitor = this.Senpai;
							this.LoveManager.Rival = this.Rival;
							this.LoveManager.Rival.CharacterAnimation["f02_shy_00"].weight = 0f;
							this.LoveManager.Suitor.gameObject.SetActive(true);
							this.LoveManager.Rival.gameObject.SetActive(true);
							this.Yandere.gameObject.SetActive(true);
							this.LoveManager.Suitor.transform.parent = null;
							this.LoveManager.Rival.transform.parent = null;
							this.Yandere.gameObject.transform.parent = null;
							this.LoveManager.BeginConfession();
							this.Clock.NightLighting();
							this.Clock.enabled = false;
							base.gameObject.SetActive(false);
							return;
						}
						if (this.Phase == 100)
						{
							this.Yandere.MyController.enabled = false;
							this.Yandere.transform.parent = base.transform;
							this.Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
							this.Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							this.Yandere.CharacterAnimation.Play("f02_handcuffs_00");
							this.Yandere.Handcuffs.SetActive(true);
							this.ArrestingCops.SetActive(true);
							Physics.SyncTransforms();
							this.Label.text = this.Protagonist + " is arrested by the police. She will never have Senpai.";
							this.GameOver = true;
							return;
						}
						if (this.Phase == 101)
						{
							int fingerprintID2 = this.WeaponManager.Weapons[this.WeaponID].FingerprintID;
							StudentScript studentScript = this.StudentManager.Students[fingerprintID2];
							if (studentScript.Alive)
							{
								this.Patsy = this.StudentManager.Students[fingerprintID2];
								this.Patsy.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
								this.Patsy.CharacterAnimation.enabled = true;
								if (this.Patsy.WeaponBag != null)
								{
									this.Patsy.WeaponBag.SetActive(false);
								}
								this.Patsy.EmptyHands();
								this.Patsy.SpeechLines.Stop();
								this.Patsy.Handcuffs.SetActive(true);
								this.Patsy.gameObject.SetActive(true);
								this.Patsy.Ragdoll.Zs.SetActive(false);
								this.Patsy.SmartPhone.SetActive(false);
								this.Patsy.MyController.enabled = false;
								this.Patsy.transform.parent = base.transform;
								this.Patsy.transform.localPosition = new Vector3(0f, 0f, 0f);
								this.Patsy.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
								this.Patsy.ShoeRemoval.enabled = false;
								if (this.StudentManager.Students[fingerprintID2].Male)
								{
									this.StudentManager.Students[fingerprintID2].CharacterAnimation.Play("handcuffs_00");
								}
								else
								{
									this.StudentManager.Students[fingerprintID2].CharacterAnimation.Play("f02_handcuffs_00");
								}
								this.ArrestingCops.SetActive(true);
								if (!studentScript.Tranquil)
								{
									this.Label.text = this.JSON.Students[fingerprintID2].Name + " is arrested by the police.";
									this.StudentsToArrest[fingerprintID2] = true;
									this.Arrests++;
								}
								else
								{
									this.Label.text = this.JSON.Students[fingerprintID2].Name + " is found asleep inside of a musical instrument case. The police assume that she hid herself inside of the box after committing murder, and arrest her.";
									this.StudentsToArrest[fingerprintID2] = true;
									this.ArrestID = fingerprintID2;
									this.TranqCase.Occupied = false;
									this.Arrests++;
								}
								if (this.Patsy.StudentID == this.StudentManager.RivalID)
								{
									this.StudentManager.RivalEliminated = true;
									this.RivalEliminationMethod = RivalEliminationType.Arrested;
								}
							}
							else
							{
								this.ShruggingCops.SetActive(true);
								if (studentScript.Ragdoll.Disposed)
								{
									this.Label.text = this.JSON.Students[fingerprintID2].Name + " is missing. The police cannot perform an arrest.";
									this.DeadPerps++;
								}
								else
								{
									bool flag2 = false;
									this.ID = 0;
									while (this.ID < this.VictimArray.Length)
									{
										if (this.VictimArray[this.ID] == fingerprintID2 && !studentScript.MurderSuicide)
										{
											flag2 = true;
										}
										this.ID++;
									}
									if (!flag2)
									{
										this.Label.text = this.JSON.Students[fingerprintID2].Name + " is dead. The police cannot perform an arrest.";
										this.DeadPerps++;
									}
									else
									{
										this.Label.text = this.JSON.Students[fingerprintID2].Name + "'s fingerprints are on the same weapon that killed them. The police cannot solve this mystery.";
									}
								}
							}
							this.Phase = 3;
							return;
						}
						if (this.Phase == 102)
						{
							this.StudentManager.Students[this.Police.SuicideID];
							if (!this.StudentManager.Students[this.Police.SuicideID].Ragdoll.Disposed)
							{
								this.MurderScene.SetActive(true);
								if (this.Police.SuicideNote)
								{
									this.Label.text = "The police inspect the corpse of a student who appears to have fallen to their death from the school rooftop. The police find a suicide note, but still treat the incident as a potential murder case, and search the school for any other victims.";
								}
								else
								{
									this.Label.text = "The police inspect the corpse of a student who appears to have fallen to their death from the school rooftop. The police treat the incident as a murder case, and search the school for any other victims.";
								}
								if (this.Police.SuicideID == this.StudentManager.RivalID)
								{
									this.RivalEliminationMethod = RivalEliminationType.SuicideFake;
								}
								this.ErectFence = true;
							}
							else
							{
								this.ShruggingCops.SetActive(true);
								this.Label.text = "The police attempt to determine whether or not a student fell to their death from the school rooftop. The police are unable to reach a conclusion.";
							}
							this.ID = 0;
							while (this.ID < this.Police.CorpseList.Length)
							{
								RagdollScript ragdollScript2 = this.Police.CorpseList[this.ID];
								if (ragdollScript2 != null && ragdollScript2.Suicide)
								{
									this.Police.SuicideVictims++;
									if (this.Police.Corpses > 0)
									{
										this.Police.Corpses--;
									}
								}
								this.ID++;
							}
							this.Phase = 2;
							return;
						}
						if (this.Phase == 103)
						{
							this.MurderScene.SetActive(true);
							this.Label.text = "The paramedics attempt to resuscitate the poisoned student, but they are unable to revive her. The police treat the incident as a murder case, and search the school for any other victims.";
							this.ID = 0;
							while (this.ID < this.Police.CorpseList.Length)
							{
								RagdollScript ragdollScript3 = this.Police.CorpseList[this.ID];
								if (ragdollScript3 != null && ragdollScript3.Poisoned && this.Police.Corpses > 0)
								{
									this.Police.Corpses--;
								}
								this.ID++;
							}
							if (this.Corpse.StudentID == this.StudentManager.RivalID)
							{
								GameGlobals.SpecificEliminationID = 15;
								if (!GameGlobals.Debug)
								{
									PlayerPrefs.SetInt("Poison", 1);
								}
							}
							this.Phase = 2;
							return;
						}
						if (this.Phase == 104)
						{
							this.MurderScene.SetActive(true);
							this.Label.text = "The police determine that " + this.Police.DrownedStudentName + " died from drowning. The police treat the death as a possible murder, and search the school for any other victims.";
							this.ID = 0;
							while (this.ID < this.Police.CorpseList.Length)
							{
								RagdollScript ragdollScript4 = this.Police.CorpseList[this.ID];
								if (ragdollScript4 != null)
								{
									if (ragdollScript4.Student.StudentID == this.StudentManager.RivalID)
									{
										Debug.Log("The player drowned the rival.");
										if (this.RivalEliminationMethod == RivalEliminationType.None)
										{
											this.RivalEliminationMethod = RivalEliminationType.Murdered;
										}
										GameGlobals.SpecificEliminationID = 7;
										if (!GameGlobals.Debug)
										{
											PlayerPrefs.SetInt("Drown", 1);
										}
									}
									if (ragdollScript4.Drowned && this.Police.Corpses > 0)
									{
										this.Police.Corpses--;
									}
								}
								this.ID++;
							}
							this.Phase = 2;
							return;
						}
						if (this.Phase == 105)
						{
							this.MurderScene.SetActive(true);
							this.Label.text = "The police determine that " + this.Police.ElectrocutedStudentName + " died from being electrocuted. The police treat the death as a possible murder, and search the school for any other victims.";
							this.ID = 0;
							while (this.ID < this.Police.CorpseList.Length)
							{
								RagdollScript ragdollScript5 = this.Police.CorpseList[this.ID];
								if (ragdollScript5 != null && ragdollScript5.Electrocuted)
								{
									if (ragdollScript5.Student.StudentID == this.StudentManager.RivalID)
									{
										Debug.Log("The game should now be informing the Content Checklist that the player has performed an electrocution.");
										if (!GameGlobals.Debug)
										{
											PlayerPrefs.SetInt("Electrocute", 1);
										}
									}
									if (this.Police.Corpses > 0)
									{
										this.Police.Corpses--;
									}
								}
								this.ID++;
							}
							this.Phase = 2;
							return;
						}
						if (this.Phase == 999)
						{
							this.ScaredCops.SetActive(true);
							this.Yandere.MyController.enabled = false;
							this.Yandere.transform.parent = base.transform;
							this.Yandere.transform.localPosition = new Vector3(0f, 0f, -1f);
							this.Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							Physics.SyncTransforms();
							this.Label.text = "The police witness actual evidence of the supernatural, are absolutely horrified, and run for their lives.";
							if (this.StudentManager.RivalEliminated)
							{
								this.Phase = 12;
								return;
							}
							this.Phase = 13;
						}
					}
				}
			}
		}
	}

	// Token: 0x0600141C RID: 5148 RVA: 0x000C4358 File Offset: 0x000C2558
	private void TeleportYandere()
	{
		this.Yandere.MyController.enabled = false;
		this.Yandere.transform.parent = base.transform;
		this.Yandere.transform.localPosition = new Vector3(0.75f, 0.33333f, -1.9f);
		this.Yandere.transform.localEulerAngles = new Vector3(-22.5f, 157.5f, 0f);
		Physics.SyncTransforms();
	}

	// Token: 0x0600141D RID: 5149 RVA: 0x000C43DC File Offset: 0x000C25DC
	private void Finish()
	{
		Debug.Log("We have reached the end of the End-of-Day sequence.");
		if (this.RivalEliminationMethod == RivalEliminationType.Murdered)
		{
			Debug.Log("The rival died.");
			GameGlobals.RivalEliminationID = 1;
			GameGlobals.NonlethalElimination = false;
			if (this.StudentManager.Students[1].SenpaiWitnessingRivalDie)
			{
				GameGlobals.RivalEliminationID = 2;
			}
		}
		else if (this.RivalEliminationMethod == RivalEliminationType.Arrested)
		{
			Debug.Log("The rival was arrested.");
			GameGlobals.RivalEliminationID = 3;
			GameGlobals.NonlethalElimination = true;
			GameGlobals.SpecificEliminationID = 11;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Frame", 1);
			}
			StudentGlobals.SetStudentArrested(this.StudentManager.RivalID, true);
		}
		else if (this.RivalEliminationMethod == RivalEliminationType.Expelled)
		{
			Debug.Log("The rival was expelled.");
			StudentGlobals.SetStudentExpelled(this.StudentManager.RivalID, true);
			GameGlobals.RivalEliminationID = 5;
			GameGlobals.NonlethalElimination = true;
			GameGlobals.SpecificEliminationID = 9;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Expel", 1);
			}
		}
		else if (this.RivalEliminationMethod == RivalEliminationType.Matchmade)
		{
			Debug.Log("The rival was matchmade.");
			GameGlobals.RivalEliminationID = 6;
			GameGlobals.NonlethalElimination = true;
			GameGlobals.SpecificEliminationID = 13;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Matchmake", 1);
			}
		}
		else if (this.RivalEliminationMethod == RivalEliminationType.Rejected)
		{
			Debug.Log("The rival was rejected by Senpai.");
			GameGlobals.RivalEliminationID = 7;
			GameGlobals.NonlethalElimination = true;
			GameGlobals.SpecificEliminationID = 18;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Reject", 1);
			}
		}
		else if (this.RivalEliminationMethod == RivalEliminationType.Ruined)
		{
			Debug.Log("The rival's reputation has been ruined.");
			GameGlobals.RivalEliminationID = 8;
			GameGlobals.NonlethalElimination = true;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Bully", 1);
			}
		}
		else if (this.RivalEliminationMethod == RivalEliminationType.SuicideBully)
		{
			Debug.Log("The rival was bullied into suicide.");
			GameGlobals.RivalEliminationID = 9;
			GameGlobals.NonlethalElimination = false;
		}
		else if (this.RivalEliminationMethod == RivalEliminationType.SuicideFake)
		{
			Debug.Log("The rival was pushed off the school rooftop, and the player made her death look like an accident.");
			GameGlobals.RivalEliminationID = 10;
			GameGlobals.NonlethalElimination = false;
			GameGlobals.SpecificEliminationID = 17;
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Push", 1);
			}
		}
		else if (this.RivalEliminationMethod == RivalEliminationType.Vanished || this.RivalDismemberedAndIncinerated || this.RivalBuried)
		{
			Debug.Log("The rival ''mysteriously disappeared''.");
			GameGlobals.RivalEliminationID = 11;
			GameGlobals.NonlethalElimination = false;
			this.CheckForNatureOfDeath();
			if (this.TranqCase.VictimID == this.StudentManager.RivalID)
			{
				GameGlobals.NonlethalElimination = true;
			}
		}
		else if (this.RivalEliminationMethod == RivalEliminationType.Accident)
		{
			Debug.Log("The rival was killed in a ''mysterious accident''.");
			GameGlobals.RivalEliminationID = 12;
			GameGlobals.NonlethalElimination = false;
		}
		if (GameGlobals.RivalEliminationID == 0 && this.StudentManager.Students[this.StudentManager.RivalID] != null && !this.StudentManager.Students[this.StudentManager.RivalID].Alive)
		{
			Debug.Log("RivalEliminationID was 0, but the rival is dead. Bug?");
			if (this.StudentManager.Students[this.StudentManager.RivalID].Ragdoll.Hidden || !this.PoliceArrived)
			{
				Debug.Log("The rival ''mysteriously disappeared''.");
				GameGlobals.RivalEliminationID = 11;
				GameGlobals.NonlethalElimination = false;
			}
			this.CheckForNatureOfDeath();
		}
		PlayerGlobals.Reputation = this.Reputation.Reputation;
		ClubGlobals.Club = this.Yandere.Club;
		StudentGlobals.MemorialStudents = 0;
		HomeGlobals.Night = true;
		this.Police.KillStudents();
		if (this.Police.Suspended)
		{
			DateGlobals.PassDays = this.Police.SuspensionLength;
		}
		else
		{
			DateGlobals.PassDays = 1;
		}
		if (this.StudentManager.Students[SchoolGlobals.KidnapVictim] != null && this.StudentManager.Students[SchoolGlobals.KidnapVictim].Ragdoll.enabled)
		{
			SchoolGlobals.KidnapVictim = 0;
		}
		for (int i = 1; i < 11; i++)
		{
			if (this.StudentManager.RivalKilledSelf[i])
			{
				GameGlobals.SetRivalEliminations(i, 10);
				GameGlobals.SetSpecificEliminations(i, 19);
			}
		}
		bool flag = DateGlobals.Weekday != DayOfWeek.Friday && this.StudentManager.SabotageProgress > this.StudentManager.InitialSabotageProgress;
		if (!this.TranqCase.Occupied)
		{
			if (this.GoToSuicideScene)
			{
				SceneManager.LoadScene("SuicideScene");
			}
			else if (flag)
			{
				SceneManager.LoadScene("RivalRejectionProgressScene");
			}
			else
			{
				SceneManager.LoadScene("HomeScene");
			}
		}
		else
		{
			SchoolGlobals.KidnapVictim = this.TranqCase.VictimID;
			StudentGlobals.SetStudentKidnapped(this.TranqCase.VictimID, true);
			StudentGlobals.SetStudentSanity(this.TranqCase.VictimID, 100f);
			if (flag)
			{
				GameGlobals.JustKidnapped = true;
				SceneManager.LoadScene("RivalRejectionProgressScene");
			}
			else
			{
				SceneManager.LoadScene("CalendarScene");
			}
		}
		if (this.Dumpster.StudentToGoMissing > 0)
		{
			this.Dumpster.SetVictimMissing();
		}
		this.ID = 0;
		while (this.ID < this.GardenHoles.Length)
		{
			this.GardenHoles[this.ID].EndOfDayCheck();
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < this.Yandere.Inventory.ShrineCollectibles.Length)
		{
			if (this.Yandere.Inventory.ShrineCollectibles[this.ID])
			{
				PlayerGlobals.SetShrineCollectible(this.ID, true);
			}
			this.ID++;
		}
		this.Incinerator.SetVictimsMissing();
		this.WoodChipper.SetVictimsMissing();
		if (this.FragileTarget > 0)
		{
			StudentGlobals.FragileTarget = this.FragileTarget;
			StudentGlobals.FragileSlave = 5;
		}
		if (this.StudentManager.ReactedToGameLeader)
		{
			SchoolGlobals.ReactedToGameLeader = true;
		}
		if (TaskGlobals.GetTaskStatus(46) == 1)
		{
			TaskGlobals.SetTaskStatus(46, 0);
		}
		if (this.StudentManager.Students[46] != null && this.StudentManager.Students[46].TaskPhase == 5)
		{
			TaskGlobals.SetTaskStatus(46, 3);
			PlayerGlobals.SetStudentFriend(46, true);
			this.NewFriends++;
		}
		if (this.NewFriends > 0)
		{
			PlayerGlobals.Friends += this.NewFriends;
		}
		if (this.Yandere.Alerts > 0)
		{
			PlayerGlobals.Alerts += this.Yandere.Alerts;
		}
		SchoolGlobals.SchoolAtmosphere += (float)this.Arrests * 0.1f;
		if (this.Counselor.ExpelledDelinquents)
		{
			SchoolGlobals.SchoolAtmosphere += 0.25f;
		}
		if (this.Yandere.Inventory.FakeID)
		{
			PlayerGlobals.FakeID = true;
		}
		if (this.RaibaruLoner)
		{
			PlayerGlobals.RaibaruLoner = true;
		}
		if (this.StopMourning)
		{
			GameGlobals.SenpaiMourning = false;
		}
		if (this.StudentManager.EmbarassingSecret)
		{
			SchemeGlobals.SetServicePurchased(4, true);
			SchemeGlobals.EmbarassingSecret = true;
		}
		EventGlobals.LearnedAboutPhotographer = this.LearnedAboutPhotographer;
		EventGlobals.OsanaEvent1 = this.LearnedOsanaInfo1;
		EventGlobals.OsanaEvent2 = this.LearnedOsanaInfo2;
		CollectibleGlobals.MatchmakingGifts = this.MatchmakingGifts;
		CollectibleGlobals.SenpaiGifts = this.SenpaiGifts;
		PlayerGlobals.PantyShots = this.Yandere.Inventory.PantyShots;
		PlayerGlobals.Money = this.Yandere.Inventory.Money;
		ClassGlobals.Biology = this.Class.Biology;
		ClassGlobals.Chemistry = this.Class.Chemistry;
		ClassGlobals.Language = this.Class.Language;
		ClassGlobals.Physical = this.Class.Physical;
		ClassGlobals.Psychology = this.Class.Psychology;
		ClassGlobals.BiologyGrade = this.Class.BiologyGrade;
		ClassGlobals.ChemistryGrade = this.Class.ChemistryGrade;
		ClassGlobals.LanguageGrade = this.Class.LanguageGrade;
		ClassGlobals.PhysicalGrade = this.Class.PhysicalGrade;
		ClassGlobals.PsychologyGrade = this.Class.PsychologyGrade;
		PlayerGlobals.Headset = this.Yandere.Inventory.Headset;
		PlayerGlobals.DirectionalMic = this.Yandere.Inventory.DirectionalMic;
		this.WeaponManager.TrackDumpedWeapons();
		this.StudentManager.CommunalLocker.RivalPhone.StolenPhoneDropoff.SetPhonesHacked();
		this.Yandere.PauseScreen.FavorMenu.ServicesMenu.SaveServicesPurchased();
		this.StudentManager.LoveManager.SaveSuitorInstructions();
		this.StudentManager.TaskManager.SaveTaskStatuses();
		this.StudentManager.SaveCollectibles();
		this.StudentManager.SavePantyshots();
		this.StudentManager.SaveReps();
		if (this.StudentManager.DatingMinigame.DataNeedsSaving)
		{
			this.StudentManager.DatingMinigame.SaveTopicsAndCompliments();
		}
		if (this.StudentManager.DialogueWheel.AdviceWindow.DataNeedsSaving)
		{
			this.StudentManager.DialogueWheel.AdviceWindow.SaveTopicsAndCompliments();
		}
		if (SchemeGlobals.GetSchemeStage(6) == 8)
		{
			SchemeGlobals.SetSchemeStage(6, 9);
			this.Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		this.Yandere.CameraEffects.UpdateBloom(1f);
		this.Yandere.CameraEffects.UpdateBloomKnee(0.5f);
		this.Yandere.CameraEffects.UpdateBloomRadius(4f);
		DatingGlobals.RivalSabotaged = this.StudentManager.SabotageProgress;
		PlayerGlobals.PersonaID = this.Yandere.PersonaID;
		PlayerGlobals.CorpsesDiscovered += this.Police.Corpses;
		ClassGlobals.BonusStudyPoints = this.Class.StudyPoints + this.Class.BonusPoints;
		Debug.Log("Adding " + this.Class.BonusPoints.ToString() + " Bonus Study Points.");
		HomeGlobals.LateForSchool = false;
		PlayerGlobals.ShrineItems += this.ShrineItemsCollected;
		this.Counselor.SaveExcusesUsed();
		this.Counselor.ExpelStudents();
		this.Counselor.SaveCounselorData();
		StudentGlobals.ExpelProgress = this.Counselor.RivalExpelProgress;
		CounselorGlobals.ReportedAlcohol = this.Counselor.ReportedAlcohol;
		CounselorGlobals.ReportedCigarettes = this.Counselor.ReportedCigarettes;
		CounselorGlobals.ReportedCondoms = this.Counselor.ReportedCondoms;
		CounselorGlobals.ReportedTheft = this.Counselor.ReportedTheft;
		CounselorGlobals.ReportedCheating = this.Counselor.ReportedCheating;
		for (int j = 1; j < this.WeaponManager.BroughtWeapons.Length; j++)
		{
			if (this.WeaponManager.BroughtWeapons[j] == null)
			{
				PlayerGlobals.SetCannotBringItem(j, true);
			}
		}
		if (this.Yandere.Inventory.ArrivedWithRatPoison && !this.Yandere.Inventory.RatPoison)
		{
			PlayerGlobals.SetCannotBringItem(4, true);
		}
		if (this.Yandere.Inventory.ArrivedWithSake && !this.Yandere.Inventory.Sake)
		{
			PlayerGlobals.SetCannotBringItem(5, true);
		}
		if (this.Yandere.Inventory.ArrivedWithCigs && !this.Yandere.Inventory.Cigs)
		{
			PlayerGlobals.SetCannotBringItem(6, true);
		}
		if (this.Yandere.Inventory.ArrivedWithCondoms && !this.Yandere.Inventory.Condoms)
		{
			PlayerGlobals.SetCannotBringItem(7, true);
		}
		if (this.Yandere.Inventory.ArrivedWithSedative && !this.Yandere.Inventory.Sedative)
		{
			PlayerGlobals.SetCannotBringItem(9, true);
			PlayerGlobals.BoughtSedative = false;
		}
		if (this.Yandere.Inventory.ArrivedWithPoison && !this.Yandere.Inventory.LethalPoison)
		{
			Debug.Log("The player arrived with poison. The player doesn't have that poison anymore.");
			PlayerGlobals.SetCannotBringItem(11, true);
			PlayerGlobals.BoughtPoison = false;
		}
		if (this.Yandere.Inventory.LethalPoisons > 0)
		{
			Debug.Log("The player is bringing some poison home from school.");
			PlayerGlobals.BoughtPoison = true;
		}
		if (this.Yandere.Inventory.Sedative)
		{
			PlayerGlobals.BoughtSedative = true;
		}
		if (this.Yandere.Inventory.LockPick)
		{
			PlayerGlobals.BoughtLockpick = true;
		}
		if (this.Counselor.ReportedNarcotics)
		{
			PlayerGlobals.BoughtNarcotics = false;
		}
		if (this.ExplosiveDeviceUsed)
		{
			PlayerGlobals.BoughtExplosive = false;
		}
		if (this.Yandere.Inventory.Cigs)
		{
			PlayerGlobals.SetCannotBringItem(6, false);
		}
		if (this.Yandere.Inventory.Sake)
		{
			PlayerGlobals.SetCannotBringItem(5, false);
		}
		if (this.Yandere.Inventory.EmeticPoison || this.Yandere.Inventory.RatPoison)
		{
			PlayerGlobals.SetCannotBringItem(4, false);
		}
		if (this.Yandere.Inventory.Sedative || this.Yandere.Inventory.Tranquilizer)
		{
			PlayerGlobals.BoughtSedative = true;
			PlayerGlobals.SetCannotBringItem(9, false);
		}
		if (this.ArticleID == 1)
		{
			PlayerGlobals.Reputation += 20f * (1f + (float)ClassGlobals.LanguageGrade * 0.2f);
		}
		else if (this.ArticleID == 3)
		{
			SchoolGlobals.SchoolAtmosphere += 20f * (1f + (float)ClassGlobals.LanguageGrade * 0.2f);
		}
		if (GameGlobals.PoliceYesterday)
		{
			PlayerGlobals.PoliceVisits++;
		}
		PlayerGlobals.BloodWitnessed += this.BloodWitnessed;
		PlayerGlobals.WeaponWitnessed += this.WeaponWitnessed;
		this.ClubManager.UpdateQuitClubs();
		this.ArrestStudents();
	}

	// Token: 0x0600141E RID: 5150 RVA: 0x000C50E0 File Offset: 0x000C32E0
	private void DisableThings(StudentScript TargetStudent)
	{
		if (TargetStudent != null)
		{
			TargetStudent.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			TargetStudent.CharacterAnimation.enabled = true;
			TargetStudent.CharacterAnimation.Play(TargetStudent.IdleAnim);
			TargetStudent.EmptyHands();
			TargetStudent.SpeechLines.Stop();
			TargetStudent.Ragdoll.Zs.SetActive(false);
			TargetStudent.SmartPhone.SetActive(false);
			TargetStudent.MyController.enabled = false;
			TargetStudent.ShoeRemoval.enabled = false;
			TargetStudent.enabled = false;
			TargetStudent.gameObject.SetActive(true);
			TargetStudent.transform.parent = base.transform;
			TargetStudent.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x0600141F RID: 5151 RVA: 0x000C51AC File Offset: 0x000C33AC
	private void CheckForNatureOfDeath()
	{
		if (this.StudentManager.Students[this.StudentManager.RivalID] != null)
		{
			RagdollScript ragdoll = this.StudentManager.Students[this.StudentManager.RivalID].Ragdoll;
			if (ragdoll.Student.DeathType == DeathType.Burning)
			{
				GameGlobals.SpecificEliminationID = 5;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Burn", 1);
				}
				Debug.Log("The game knows that she was burned, though.");
				return;
			}
			if (ragdoll.Student.DeathType == DeathType.Electrocution)
			{
				GameGlobals.SpecificEliminationID = 8;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Electrocute", 1);
				}
				Debug.Log("The game knows that she was electrocuted, though.");
				Debug.Log("The game should now be informing the Content Checklist that the player has performed an electrocution.");
				return;
			}
			if (ragdoll.Student.DeathType == DeathType.Weight)
			{
				GameGlobals.SpecificEliminationID = 6;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Crush", 1);
				}
				Debug.Log("The game knows that she was crushed, though.");
				return;
			}
			if (ragdoll.Student.DeathType == DeathType.Drowning)
			{
				if (this.PoolEvent)
				{
					Debug.Log("The player eliminated the rival during a pool event.");
					GameGlobals.SpecificEliminationID = 16;
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Pool", 1);
						return;
					}
				}
				else
				{
					Debug.Log("The game knows that she drowned, though.");
					GameGlobals.SpecificEliminationID = 7;
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Drown", 1);
						return;
					}
				}
			}
			else
			{
				if (ragdoll.Decapitated)
				{
					GameGlobals.SpecificEliminationID = 10;
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Fan", 1);
					}
					Debug.Log("The game knows that she was decapitated, though.");
					return;
				}
				if (ragdoll.Student.DeathType == DeathType.Poison)
				{
					GameGlobals.SpecificEliminationID = 15;
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Poison", 1);
					}
					Debug.Log("The game knows that she was poisoned, though.");
					return;
				}
				if (ragdoll.Student.DeathType == DeathType.Falling)
				{
					GameGlobals.SpecificEliminationID = 17;
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Push", 1);
					}
					Debug.Log("The game knows that she was pushed, though.");
					return;
				}
				if (ragdoll.Student.Hunted)
				{
					GameGlobals.SpecificEliminationID = 14;
					if (!GameGlobals.Debug)
					{
						if (ragdoll.Student.MurderedByFragile)
						{
							PlayerPrefs.SetInt("DrivenToMurder", 1);
						}
						else
						{
							PlayerPrefs.SetInt("MurderSuicide", 1);
						}
					}
					Debug.Log("The game knows that the rival died as part of a murder-suicide, though.");
					return;
				}
				if (ragdoll.Student.DeathType == DeathType.Weapon)
				{
					GameGlobals.SpecificEliminationID = 1;
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("Attack", 1);
					}
					Debug.Log("The game knows that she was attacked, though.");
				}
			}
		}
	}

	// Token: 0x06001420 RID: 5152 RVA: 0x000C5404 File Offset: 0x000C3604
	public void SetFormerRivalDeath(int RivalID, StudentScript Rival)
	{
		Debug.Log("The elimination information for Rival #" + RivalID.ToString() + " is now being updated.");
		if (Rival.DeathType == DeathType.Burning)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 5);
		}
		else if (Rival.DeathType == DeathType.Electrocution)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 8);
		}
		else if (Rival.DeathType == DeathType.Weight)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 6);
		}
		else if (Rival.DeathType == DeathType.Drowning)
		{
			if (this.PoolEvent)
			{
				GameGlobals.SetSpecificEliminations(RivalID, 16);
			}
			else
			{
				GameGlobals.SetSpecificEliminations(RivalID, 7);
			}
		}
		else if (Rival.Ragdoll.Decapitated)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 10);
		}
		else if (Rival.DeathType == DeathType.Poison)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 15);
		}
		else if (Rival.DeathType == DeathType.Falling)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 17);
		}
		else if (Rival.Hunted)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 14);
		}
		else if (Rival.DeathType == DeathType.Weapon)
		{
			GameGlobals.SetSpecificEliminations(RivalID, 1);
		}
		GameGlobals.SetRivalEliminations(RivalID, 14);
	}

	// Token: 0x06001421 RID: 5153 RVA: 0x000C54F8 File Offset: 0x000C36F8
	public void ArrestStudents()
	{
		for (int i = 1; i < 101; i++)
		{
			if (this.StudentsToArrest[i])
			{
				StudentGlobals.SetStudentArrested(i, true);
			}
		}
	}

	// Token: 0x04001E5E RID: 7774
	public SecuritySystemScript SecuritySystem;

	// Token: 0x04001E5F RID: 7775
	public StudentManagerScript StudentManager;

	// Token: 0x04001E60 RID: 7776
	public WeaponManagerScript WeaponManager;

	// Token: 0x04001E61 RID: 7777
	public ClubManagerScript ClubManager;

	// Token: 0x04001E62 RID: 7778
	public HeartbrokenScript Heartbroken;

	// Token: 0x04001E63 RID: 7779
	public IncineratorScript Incinerator;

	// Token: 0x04001E64 RID: 7780
	public LoveManagerScript LoveManager;

	// Token: 0x04001E65 RID: 7781
	public RummageSpotScript RummageSpot;

	// Token: 0x04001E66 RID: 7782
	public VoidGoddessScript VoidGoddess;

	// Token: 0x04001E67 RID: 7783
	public WoodChipperScript WoodChipper;

	// Token: 0x04001E68 RID: 7784
	public ReputationScript Reputation;

	// Token: 0x04001E69 RID: 7785
	public DumpsterLidScript Dumpster;

	// Token: 0x04001E6A RID: 7786
	public CounselorScript Counselor;

	// Token: 0x04001E6B RID: 7787
	public WeaponScript MurderWeapon;

	// Token: 0x04001E6C RID: 7788
	public TranqCaseScript TranqCase;

	// Token: 0x04001E6D RID: 7789
	public YandereScript Yandere;

	// Token: 0x04001E6E RID: 7790
	public RagdollScript Corpse;

	// Token: 0x04001E6F RID: 7791
	public StudentScript Senpai;

	// Token: 0x04001E70 RID: 7792
	public StudentScript Patsy;

	// Token: 0x04001E71 RID: 7793
	public PoliceScript Police;

	// Token: 0x04001E72 RID: 7794
	public Transform EODCamera;

	// Token: 0x04001E73 RID: 7795
	public StudentScript Rival;

	// Token: 0x04001E74 RID: 7796
	public ClassScript Class;

	// Token: 0x04001E75 RID: 7797
	public ClockScript Clock;

	// Token: 0x04001E76 RID: 7798
	public JsonScript JSON;

	// Token: 0x04001E77 RID: 7799
	public GardenHoleScript[] GardenHoles;

	// Token: 0x04001E78 RID: 7800
	public StudentScript[] WitnessList;

	// Token: 0x04001E79 RID: 7801
	public Animation[] CopAnimation;

	// Token: 0x04001E7A RID: 7802
	public GameObject MainCamera;

	// Token: 0x04001E7B RID: 7803
	public UISprite EndOfDayDarkness;

	// Token: 0x04001E7C RID: 7804
	public UILabel Label;

	// Token: 0x04001E7D RID: 7805
	public bool RivalDismemberedAndIncinerated;

	// Token: 0x04001E7E RID: 7806
	public bool RivalBuried;

	// Token: 0x04001E7F RID: 7807
	public bool LearnedAboutPhotographer;

	// Token: 0x04001E80 RID: 7808
	public bool ExplosiveDeviceUsed;

	// Token: 0x04001E81 RID: 7809
	public bool PreviouslyActivated;

	// Token: 0x04001E82 RID: 7810
	public bool LearnedOsanaInfo1;

	// Token: 0x04001E83 RID: 7811
	public bool LearnedOsanaInfo2;

	// Token: 0x04001E84 RID: 7812
	public bool GoToSuicideScene;

	// Token: 0x04001E85 RID: 7813
	public bool PoliceArrived;

	// Token: 0x04001E86 RID: 7814
	public bool RaibaruLoner;

	// Token: 0x04001E87 RID: 7815
	public bool StopMourning;

	// Token: 0x04001E88 RID: 7816
	public bool ClubClosed;

	// Token: 0x04001E89 RID: 7817
	public bool ClubKicked;

	// Token: 0x04001E8A RID: 7818
	public bool ErectFence;

	// Token: 0x04001E8B RID: 7819
	public bool PoolEvent;

	// Token: 0x04001E8C RID: 7820
	public bool GameOver;

	// Token: 0x04001E8D RID: 7821
	public bool Darken;

	// Token: 0x04001E8E RID: 7822
	public float DistanceToMoveForward;

	// Token: 0x04001E8F RID: 7823
	public int ClothingWithRedPaint;

	// Token: 0x04001E90 RID: 7824
	public int ShrineItemsCollected;

	// Token: 0x04001E91 RID: 7825
	public int WeaponWitnessed;

	// Token: 0x04001E92 RID: 7826
	public int BloodWitnessed;

	// Token: 0x04001E93 RID: 7827
	public int FragileTarget;

	// Token: 0x04001E94 RID: 7828
	public int EyeWitnesses;

	// Token: 0x04001E95 RID: 7829
	public int NewFriends;

	// Token: 0x04001E96 RID: 7830
	public int ClubLimit;

	// Token: 0x04001E97 RID: 7831
	public int DeadPerps;

	// Token: 0x04001E98 RID: 7832
	public int Arrests;

	// Token: 0x04001E99 RID: 7833
	public int Corpses;

	// Token: 0x04001E9A RID: 7834
	public int Victims;

	// Token: 0x04001E9B RID: 7835
	public int Weapons;

	// Token: 0x04001E9C RID: 7836
	public int Phase = 1;

	// Token: 0x04001E9D RID: 7837
	public int MatchmakingGifts;

	// Token: 0x04001E9E RID: 7838
	public int SenpaiGifts;

	// Token: 0x04001E9F RID: 7839
	public int ArticleID;

	// Token: 0x04001EA0 RID: 7840
	public int WeaponID;

	// Token: 0x04001EA1 RID: 7841
	public int ArrestID;

	// Token: 0x04001EA2 RID: 7842
	public int ClubID;

	// Token: 0x04001EA3 RID: 7843
	public int ID;

	// Token: 0x04001EA4 RID: 7844
	public string[] ClubNames;

	// Token: 0x04001EA5 RID: 7845
	public int[] VictimArray;

	// Token: 0x04001EA6 RID: 7846
	public ClubType[] ClubArray;

	// Token: 0x04001EA7 RID: 7847
	private SaveFile saveFile;

	// Token: 0x04001EA8 RID: 7848
	public GameObject TextWindow;

	// Token: 0x04001EA9 RID: 7849
	public GameObject Cops;

	// Token: 0x04001EAA RID: 7850
	public GameObject SearchingCop;

	// Token: 0x04001EAB RID: 7851
	public GameObject MurderScene;

	// Token: 0x04001EAC RID: 7852
	public GameObject ShruggingCops;

	// Token: 0x04001EAD RID: 7853
	public GameObject TabletCop;

	// Token: 0x04001EAE RID: 7854
	public GameObject SecuritySystemScene;

	// Token: 0x04001EAF RID: 7855
	public GameObject OpenTranqCase;

	// Token: 0x04001EB0 RID: 7856
	public GameObject ClosedTranqCase;

	// Token: 0x04001EB1 RID: 7857
	public GameObject GaudyRing;

	// Token: 0x04001EB2 RID: 7858
	public GameObject AnswerSheet;

	// Token: 0x04001EB3 RID: 7859
	public GameObject Fence;

	// Token: 0x04001EB4 RID: 7860
	public GameObject SCP;

	// Token: 0x04001EB5 RID: 7861
	public GameObject Headmaster;

	// Token: 0x04001EB6 RID: 7862
	public GameObject ArrestingCops;

	// Token: 0x04001EB7 RID: 7863
	public GameObject Mask;

	// Token: 0x04001EB8 RID: 7864
	public GameObject EyeWitnessScene;

	// Token: 0x04001EB9 RID: 7865
	public GameObject ScaredCops;

	// Token: 0x04001EBA RID: 7866
	public GameObject EightiesGaudyRing;

	// Token: 0x04001EBB RID: 7867
	public StudentScript KidnappedVictim;

	// Token: 0x04001EBC RID: 7868
	public Renderer TabletPortrait;

	// Token: 0x04001EBD RID: 7869
	public Transform CardboardBox;

	// Token: 0x04001EBE RID: 7870
	public RivalEliminationType RivalEliminationMethod;

	// Token: 0x04001EBF RID: 7871
	public Vector3 YandereInitialPosition;

	// Token: 0x04001EC0 RID: 7872
	public Quaternion YandereInitialRotation;

	// Token: 0x04001EC1 RID: 7873
	public bool[] StudentsToArrest;

	// Token: 0x04001EC2 RID: 7874
	public string Protagonist = "Ayano";

	// Token: 0x04001EC3 RID: 7875
	public string RivalName = "";

	// Token: 0x04001EC4 RID: 7876
	public string[] EightiesRivalNames;

	// Token: 0x04001EC5 RID: 7877
	public string[] RivalNames;

	// Token: 0x04001EC6 RID: 7878
	public AudioClip EightiesBGM;
}
