﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000275 RID: 629
public class DebugMenuScript : MonoBehaviour
{
	// Token: 0x06001352 RID: 4946 RVA: 0x000AE078 File Offset: 0x000AC278
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 0f, base.transform.localPosition.z);
		this.MissionModeWindow.SetActive(false);
		this.Window.SetActive(false);
		this.MissionMode = true;
		this.NoDebug = true;
	}

	// Token: 0x06001353 RID: 4947 RVA: 0x000AE0E0 File Offset: 0x000AC2E0
	private void Update()
	{
		if (!this.MissionMode && !this.NoDebug)
		{
			if (!this.Yandere.InClass && !this.Yandere.Chased && this.Yandere.Chasers == 0 && this.Yandere.CanMove)
			{
				if (Input.GetKeyDown(KeyCode.Backslash) && this.Yandere.transform.position.y < 100f)
				{
					this.EasterEggWindow.SetActive(false);
					this.Window.SetActive(!this.Window.activeInHierarchy);
				}
			}
			else if (this.Window.activeInHierarchy)
			{
				this.Window.SetActive(false);
			}
			if (this.Window.activeInHierarchy)
			{
				if (Input.GetKeyDown(KeyCode.F1))
				{
					StudentGlobals.FemaleUniform = 1;
					StudentGlobals.MaleUniform = 1;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F2))
				{
					StudentGlobals.FemaleUniform = 2;
					StudentGlobals.MaleUniform = 2;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F3))
				{
					StudentGlobals.FemaleUniform = 3;
					StudentGlobals.MaleUniform = 3;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F4))
				{
					StudentGlobals.FemaleUniform = 4;
					StudentGlobals.MaleUniform = 4;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F5))
				{
					StudentGlobals.FemaleUniform = 5;
					StudentGlobals.MaleUniform = 5;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F6))
				{
					StudentGlobals.FemaleUniform = 6;
					StudentGlobals.MaleUniform = 6;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F7))
				{
					this.ID = 1;
					while (this.ID < 8)
					{
						this.StudentManager.DrinkingFountains[this.ID].PowerSwitch.PowerOutlet.SabotagedOutlet.SetActive(true);
						this.StudentManager.DrinkingFountains[this.ID].Puddle.SetActive(true);
						this.ID++;
					}
					this.Window.SetActive(false);
				}
				else if (Input.GetKeyDown(KeyCode.F8))
				{
					GameGlobals.CensorBlood = !GameGlobals.CensorBlood;
					this.WeaponManager.ChangeBloodTexture();
					this.Yandere.Bloodiness += 0f;
					this.Window.SetActive(false);
				}
				else if (Input.GetKeyDown(KeyCode.F9))
				{
					GameGlobals.CensorKillingAnims = !GameGlobals.CensorKillingAnims;
					this.Yandere.AttackManager.Censor = !this.Yandere.AttackManager.Censor;
					this.Window.SetActive(false);
				}
				else if (Input.GetKeyDown(KeyCode.F10))
				{
					this.StudentManager.Students[21].Attempts = 101;
					this.StudentManager.Students[22].Attempts = 101;
					this.StudentManager.Students[23].Attempts = 101;
					this.StudentManager.Students[24].Attempts = 101;
					this.StudentManager.Students[25].Attempts = 101;
					this.Window.SetActive(false);
				}
				else if (Input.GetKeyDown(KeyCode.F11))
				{
					DatingGlobals.RivalSabotaged = 5;
					DateGlobals.Weekday = DayOfWeek.Friday;
					SceneManager.LoadScene("LoadingScene");
				}
				else if (!Input.GetKeyDown(KeyCode.F12))
				{
					if (Input.GetKeyDown(KeyCode.Alpha1))
					{
						DateGlobals.Weekday = DayOfWeek.Monday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha2))
					{
						DateGlobals.Weekday = DayOfWeek.Tuesday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha3))
					{
						DateGlobals.Weekday = DayOfWeek.Wednesday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha4))
					{
						DateGlobals.Weekday = DayOfWeek.Thursday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha5))
					{
						DateGlobals.Weekday = DayOfWeek.Friday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Alpha6))
					{
						this.Yandere.transform.position = this.TeleportSpot[1].position;
						if (this.Yandere.Followers > 0)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Alpha7))
					{
						this.Yandere.transform.position = this.TeleportSpot[2].position + new Vector3(0.75f, 0f, 0f);
						if (this.Yandere.Followers > 0)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Alpha8))
					{
						this.Yandere.transform.position = this.TeleportSpot[3].position;
						if (this.Yandere.Followers > 0)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Alpha9))
					{
						this.Yandere.transform.position = this.TeleportSpot[4].position;
						if (this.Yandere.Followers > 0)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						StudentScript studentScript = this.StudentManager.Students[39];
						if (studentScript != null)
						{
							studentScript.ShoeRemoval.Start();
							studentScript.ShoeRemoval.PutOnShoes();
							studentScript.Phase = 2;
							studentScript.ScheduleBlocks[2].action = "Stand";
							studentScript.GetDestinations();
							studentScript.CurrentDestination = this.MidoriSpot;
							studentScript.Pathfinding.target = this.MidoriSpot;
							studentScript.transform.position = this.MidoriSpot.position;
						}
						this.Window.SetActive(false);
						Physics.SyncTransforms();
					}
					else if (Input.GetKeyDown(KeyCode.Alpha0))
					{
						this.Yandere.transform.position = this.TeleportSpot[11].position;
						if (this.Yandere.Followers > 0)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						this.Window.SetActive(false);
						Physics.SyncTransforms();
					}
					else if (Input.GetKeyDown(KeyCode.A))
					{
						if (SchoolAtmosphere.Type == SchoolAtmosphereType.High)
						{
							SchoolGlobals.SchoolAtmosphere = 0.5f;
						}
						else if (SchoolAtmosphere.Type == SchoolAtmosphereType.Medium)
						{
							SchoolGlobals.SchoolAtmosphere = 0f;
						}
						else
						{
							SchoolGlobals.SchoolAtmosphere = 1f;
						}
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.C))
					{
						this.ID = 1;
						while (this.ID < 11)
						{
							CollectibleGlobals.SetTapeCollected(this.ID, true);
							this.StudentManager.TapesCollected[this.ID] = true;
							this.ID++;
						}
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.D))
					{
						this.ID = 0;
						while (this.ID < 5)
						{
							StudentScript studentScript2 = this.StudentManager.Students[76 + this.ID];
							if (studentScript2 != null)
							{
								if (studentScript2.Phase < 2)
								{
									studentScript2.ShoeRemoval.Start();
									studentScript2.ShoeRemoval.PutOnShoes();
									studentScript2.Phase = 2;
									studentScript2.CurrentDestination = studentScript2.Destinations[2];
									studentScript2.Pathfinding.target = studentScript2.Destinations[2];
								}
								studentScript2.transform.position = studentScript2.Destinations[2].position;
							}
							this.ID++;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
						CounselorGlobals.CounselorTape = 1;
						CounselorGlobals.DelinquentPunishments = 5;
					}
					else if (Input.GetKeyDown(KeyCode.F))
					{
						this.GreenScreen.SetActive(true);
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.G))
					{
						StudentScript studentScript3 = this.StudentManager.Students[this.RooftopStudent];
						if (this.Clock.HourTime < 15f)
						{
							PlayerGlobals.SetStudentFriend(this.RooftopStudent, true);
							this.StudentManager.Students[this.RooftopStudent].Friend = true;
							this.Yandere.transform.position = this.RooftopSpot.position + new Vector3(1f, 0f, 0f);
							this.WeaponManager.Weapons[6].transform.position = this.Yandere.transform.position + new Vector3(0f, 0f, 1.915f);
							if (studentScript3 != null)
							{
								this.StudentManager.OsanaOfferHelp.UpdateLocation();
								this.StudentManager.OsanaOfferHelp.enabled = true;
								this.StudentManager.NoteWindow.MeetID = 9;
								if (!studentScript3.Indoors)
								{
									if (studentScript3.ShoeRemoval.Locker == null)
									{
										studentScript3.ShoeRemoval.Start();
									}
									studentScript3.ShoeRemoval.PutOnShoes();
								}
								studentScript3.CharacterAnimation.Play(studentScript3.IdleAnim);
								studentScript3.transform.position = this.RooftopSpot.position;
								studentScript3.transform.rotation = this.RooftopSpot.rotation;
								studentScript3.Prompt.Label[0].text = "     Push";
								studentScript3.CurrentDestination = this.RooftopSpot;
								studentScript3.Pathfinding.target = this.RooftopSpot;
								studentScript3.Pathfinding.canSearch = false;
								studentScript3.Pathfinding.canMove = false;
								studentScript3.SpeechLines.Stop();
								studentScript3.Pushable = true;
								studentScript3.Routine = false;
								studentScript3.Meeting = true;
								studentScript3.MeetTime = 0f;
							}
							if (this.Clock.HourTime < 7.1f)
							{
								this.Clock.PresentTime = 426f;
							}
						}
						else
						{
							this.Clock.PresentTime = 960f;
							studentScript3.transform.position = this.Lockers.position;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.K))
					{
						SchoolGlobals.KidnapVictim = this.KidnappedVictim;
						StudentGlobals.StudentSlave = this.KidnappedVictim;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.L))
					{
						DatingGlobals.Affection = 100f;
						DateGlobals.Weekday = DayOfWeek.Friday;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.M))
					{
						PlayerGlobals.Money = 100f;
						this.Yandere.Inventory.Money = 100f;
						this.Yandere.Inventory.UpdateMoney();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.O))
					{
						this.Yandere.Inventory.RivalPhone = true;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.P))
					{
						this.ID = 2;
						while (this.ID < 93)
						{
							StudentScript studentScript4 = this.StudentManager.Students[this.ID];
							if (studentScript4 != null)
							{
								studentScript4.Patience = 999;
								studentScript4.Pestered = -999;
								studentScript4.Ignoring = false;
							}
							this.ID++;
						}
						this.Yandere.Inventory.PantyShots += 20;
						PlayerGlobals.PantyShots += 20;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Q))
					{
						this.Censor();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.R))
					{
						Debug.Log("Attempting to update reputation.");
						if (PlayerGlobals.Reputation == -100f)
						{
							PlayerGlobals.Reputation = -66.66666f;
						}
						else if (PlayerGlobals.Reputation == -66.66666f)
						{
							PlayerGlobals.Reputation = 0f;
						}
						else if (PlayerGlobals.Reputation == 0f)
						{
							PlayerGlobals.Reputation = 66.66666f;
						}
						else if (PlayerGlobals.Reputation == 66.66666f)
						{
							PlayerGlobals.Reputation = 100f;
						}
						else if (PlayerGlobals.Reputation == 100f)
						{
							PlayerGlobals.Reputation = -100f;
						}
						else
						{
							PlayerGlobals.Reputation = 0f;
						}
						this.Reputation.PreviousRep = 999f;
						this.Reputation.PendingRep = PlayerGlobals.Reputation;
						this.Reputation.UpdateRep();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.S))
					{
						this.Yandere.Class.PhysicalGrade = 5;
						this.Yandere.Class.Seduction = 5;
						this.StudentManager.Police.UpdateCorpses();
						this.ID = 1;
						while (this.ID < 101)
						{
							StudentGlobals.SetStudentPhotographed(this.ID, true);
							if (this.StudentManager.Students[this.ID] != null)
							{
								this.StudentManager.Students[this.ID].Friend = true;
							}
							this.ID++;
						}
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.T))
					{
						this.Zoom.OverShoulder = !this.Zoom.OverShoulder;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.U))
					{
						PlayerGlobals.SetStudentFriend(this.StudentManager.SuitorID, true);
						PlayerGlobals.SetStudentFriend(this.StudentManager.RivalID, true);
						this.StudentManager.Students[this.StudentManager.SuitorID].Friend = true;
						this.StudentManager.Students[this.StudentManager.RivalID].Friend = true;
						this.ID = 1;
						while (this.ID < 26)
						{
							ConversationGlobals.SetTopicLearnedByStudent(this.ID, this.StudentManager.RivalID, true);
							ConversationGlobals.SetTopicDiscovered(this.ID, true);
							this.ID++;
						}
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Z))
					{
						this.Yandere.Police.Invalid = true;
						if (Input.GetKey(KeyCode.LeftShift))
						{
							this.ID = 2;
							while (this.ID < 93)
							{
								this.StudentManager.Students[this.ID] != null;
								this.ID++;
							}
						}
						else
						{
							this.ID = 2;
							while (this.ID < 101)
							{
								StudentScript studentScript5 = this.StudentManager.Students[this.ID];
								if (studentScript5 != null)
								{
									studentScript5.SpawnAlarmDisc();
									studentScript5.BecomeRagdoll();
									studentScript5.Ragdoll.Dismember();
									studentScript5.DeathType = DeathType.EasterEgg;
								}
								this.ID++;
							}
						}
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.X))
					{
						TaskGlobals.SetTaskStatus(36, 3);
						SchoolGlobals.ReactedToGameLeader = false;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Backspace))
					{
						Time.timeScale = 1f;
						this.Clock.PresentTime = 1079f;
						this.Clock.HourTime = this.Clock.PresentTime / 60f;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.BackQuote))
					{
						bool debug = GameGlobals.Debug;
						bool eighties = GameGlobals.Eighties;
						Globals.DeleteAll();
						GameGlobals.Debug = debug;
						GameGlobals.Eighties = eighties;
						StudentGlobals.FemaleUniform = 6;
						StudentGlobals.MaleUniform = 6;
						for (int i = 1; i < 101; i++)
						{
							StudentGlobals.SetStudentPhotographed(i, true);
						}
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.Space))
					{
						this.Yandere.transform.position = this.TeleportSpot[5].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						for (int j = 46; j < 51; j++)
						{
							if (this.StudentManager.Students[j] != null)
							{
								this.StudentManager.Students[j].transform.position = this.TeleportSpot[5].position;
								if (!this.StudentManager.Students[j].Indoors)
								{
									if (this.StudentManager.Students[j].ShoeRemoval.Locker == null)
									{
										this.StudentManager.Students[j].ShoeRemoval.Start();
									}
									this.StudentManager.Students[j].ShoeRemoval.PutOnShoes();
								}
							}
						}
						this.Clock.PresentTime = 1015f;
						this.Clock.HourTime = this.Clock.PresentTime / 60f;
						this.Window.SetActive(false);
						this.OsanaEvent1.enabled = false;
						this.OsanaEvent2.enabled = false;
						this.OsanaEvent3.enabled = false;
						Physics.SyncTransforms();
					}
					else if (Input.GetKeyDown(KeyCode.LeftAlt))
					{
						this.Turtle.SpawnWeapons();
						this.Yandere.transform.position = this.TeleportSpot[6].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						this.Clock.PresentTime = 425f;
						this.Clock.HourTime = this.Clock.PresentTime / 60f;
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.LeftControl))
					{
						this.Yandere.transform.position = this.TeleportSpot[7].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.RightControl))
					{
						this.Yandere.transform.position = this.TeleportSpot[8].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Equals))
					{
						this.Clock.PresentTime += 10f;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Return))
					{
						this.Yandere.transform.eulerAngles = this.TeleportSpot[10].eulerAngles;
						this.Yandere.transform.position = this.TeleportSpot[10].position;
						if (this.Yandere.Follower != null)
						{
							this.Yandere.Follower.transform.position = this.Yandere.transform.position;
						}
						this.StudentManager.Students[1].ShoeRemoval.Start();
						this.StudentManager.Students[1].ShoeRemoval.PutOnShoes();
						this.StudentManager.Students[1].transform.position = new Vector3(0f, 12.1f, -25f);
						this.StudentManager.Students[1].Alarmed = true;
						this.StudentManager.Students[11].Lethal = true;
						this.StudentManager.Students[11].ShoeRemoval.Start();
						this.StudentManager.Students[11].ShoeRemoval.PutOnShoes();
						this.StudentManager.Students[11].transform.position = new Vector3(0f, 12.1f, -25f);
						this.Clock.PresentTime = 780f;
						this.Clock.HourTime = this.Clock.PresentTime / 60f;
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.B))
					{
						this.Yandere.Inventory.Headset = true;
						this.StudentManager.LoveManager.SuitorProgress = 1;
						DatingGlobals.SuitorProgress = 1;
						PlayerGlobals.SetStudentFriend(6, true);
						PlayerGlobals.SetStudentFriend(11, true);
						this.StudentManager.Students[6].Friend = true;
						this.StudentManager.Students[11].Friend = true;
						for (int k = 0; k < 11; k++)
						{
							DatingGlobals.SetComplimentGiven(k, false);
						}
						this.ID = 1;
						while (this.ID < 26)
						{
							ConversationGlobals.SetTopicLearnedByStudent(this.ID, 11, true);
							ConversationGlobals.SetTopicDiscovered(this.ID, true);
							this.ID++;
						}
						StudentScript studentScript6 = this.StudentManager.Students[11];
						if (studentScript6 != null)
						{
							studentScript6.ShoeRemoval.Start();
							studentScript6.ShoeRemoval.PutOnShoes();
							studentScript6.CanTalk = true;
							studentScript6.Phase = 2;
							studentScript6.Pestered = 0;
							studentScript6.Patience = 999;
							studentScript6.Ignoring = false;
							studentScript6.CurrentDestination = studentScript6.Destinations[2];
							studentScript6.Pathfinding.target = studentScript6.Destinations[2];
							studentScript6.transform.position = studentScript6.Destinations[2].position;
						}
						StudentScript studentScript7 = this.StudentManager.Students[6];
						if (studentScript7 != null)
						{
							studentScript7.ShoeRemoval.Start();
							studentScript7.ShoeRemoval.PutOnShoes();
							studentScript7.Phase = 2;
							studentScript7.Pestered = 0;
							studentScript7.Patience = 999;
							studentScript7.Ignoring = false;
							studentScript7.CurrentDestination = studentScript7.Destinations[2];
							studentScript7.Pathfinding.target = studentScript7.Destinations[2];
							studentScript7.transform.position = studentScript7.Destinations[2].position;
						}
						StudentScript studentScript8 = this.StudentManager.Students[10];
						if (studentScript7 != null)
						{
							studentScript7.transform.position = studentScript6.transform.position;
						}
						CollectibleGlobals.SetGiftPurchased(6, true);
						CollectibleGlobals.SetGiftPurchased(7, true);
						CollectibleGlobals.SetGiftPurchased(8, true);
						CollectibleGlobals.SetGiftPurchased(9, true);
						Physics.SyncTransforms();
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.Pause))
					{
						this.Clock.StopTime = !this.Clock.StopTime;
						this.Window.SetActive(false);
					}
					else if (Input.GetKeyDown(KeyCode.W))
					{
						DateGlobals.Week++;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.H))
					{
						StudentGlobals.FragileSlave = 5;
						StudentGlobals.FragileTarget = 10;
						SchoolGlobals.KidnapVictim = this.KidnappedVictim;
						StudentGlobals.StudentSlave = this.KidnappedVictim;
						SceneManager.LoadScene("LoadingScene");
					}
					else if (Input.GetKeyDown(KeyCode.I))
					{
						this.StudentManager.Students[3].BecomeRagdoll();
						this.WeaponManager.Weapons[1].Blood.enabled = true;
						this.WeaponManager.Weapons[1].FingerprintID = 2;
						this.WeaponManager.Weapons[1].Victims[3] = true;
						this.StudentManager.Students[5].BecomeRagdoll();
						this.WeaponManager.Weapons[2].Blood.enabled = true;
						this.WeaponManager.Weapons[2].FingerprintID = 4;
						this.WeaponManager.Weapons[2].Victims[5] = true;
					}
					else if (!Input.GetKeyDown(KeyCode.J) && !Input.GetKeyDown(KeyCode.V) && Input.GetKeyDown(KeyCode.N))
					{
						this.ElectrocutionKit[0].transform.position = this.Yandere.transform.position;
						this.ElectrocutionKit[1].transform.position = this.Yandere.transform.position;
						this.ElectrocutionKit[2].transform.position = this.Yandere.transform.position;
						this.ElectrocutionKit[3].transform.position = this.Yandere.transform.position;
						this.ElectrocutionKit[3].SetActive(true);
					}
				}
				if (Input.GetKeyDown(KeyCode.Tab))
				{
					DatingGlobals.SuitorProgress = 2;
					SceneManager.LoadScene("LoadingScene");
				}
				if (Input.GetKeyDown(KeyCode.CapsLock))
				{
					this.StudentManager.LoveManager.ConfessToSuitor = true;
				}
			}
			else
			{
				if (Input.GetKey(KeyCode.BackQuote))
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						this.ID = 0;
						while (this.ID < this.StudentManager.NPCsTotal)
						{
							if (StudentGlobals.GetStudentDying(this.ID))
							{
								StudentGlobals.SetStudentDying(this.ID, false);
							}
							this.ID++;
						}
						SceneManager.LoadScene("LoadingScene");
					}
				}
				if (Input.GetKeyUp(KeyCode.BackQuote))
				{
					this.Timer = 0f;
				}
			}
			if (this.TryNextFrame)
			{
				this.UpdateCensor();
			}
		}
		else
		{
			Input.GetKeyDown(KeyCode.Backslash);
		}
		if (this.WaitingForNumber)
		{
			if (Input.GetKey("1"))
			{
				Debug.Log("Going to class should trigger panty shot lecture.");
				if (!this.StudentManager.Eighties)
				{
					SchemeGlobals.SetSchemeStage(1, 100);
				}
				StudentGlobals.ExpelProgress = 0;
				this.Counselor.CutsceneManager.Scheme = 1;
				this.Counselor.LectureID = 1;
				this.WaitingForNumber = false;
				return;
			}
			if (Input.GetKey("2"))
			{
				Debug.Log("Going to class should trigger theft lecture.");
				if (!this.StudentManager.Eighties)
				{
					SchemeGlobals.SetSchemeStage(2, 100);
				}
				StudentGlobals.ExpelProgress = 1;
				this.Counselor.CutsceneManager.Scheme = 2;
				this.Counselor.LectureID = 2;
				this.WaitingForNumber = false;
				return;
			}
			if (Input.GetKey("3"))
			{
				Debug.Log("Going to class should trigger contraband lecture.");
				if (!this.StudentManager.Eighties)
				{
					SchemeGlobals.SetSchemeStage(3, 100);
				}
				StudentGlobals.ExpelProgress = 2;
				this.Counselor.CutsceneManager.Scheme = 3;
				this.Counselor.LectureID = 3;
				this.WaitingForNumber = false;
				return;
			}
			if (Input.GetKey("4"))
			{
				Debug.Log("Going to class should trigger Vandalism lecture.");
				if (!this.StudentManager.Eighties)
				{
					SchemeGlobals.SetSchemeStage(4, 100);
				}
				StudentGlobals.ExpelProgress = 3;
				this.Counselor.CutsceneManager.Scheme = 4;
				this.Counselor.LectureID = 4;
				this.WaitingForNumber = false;
				return;
			}
			if (Input.GetKey("5"))
			{
				Debug.Log("Going to class at lunchtime should get your rival expelled!");
				if (!this.StudentManager.Eighties)
				{
					SchemeGlobals.SetSchemeStage(5, 100);
				}
				StudentGlobals.ExpelProgress = 4;
				this.Counselor.CutsceneManager.Scheme = 5;
				this.Counselor.LectureID = 5;
				this.WaitingForNumber = false;
			}
		}
	}

	// Token: 0x06001354 RID: 4948 RVA: 0x000AFD34 File Offset: 0x000ADF34
	public void Censor()
	{
		if (GameGlobals.CensorPanties)
		{
			if (this.Yandere.Schoolwear == 1)
			{
				if (!this.Yandere.Sans && !this.Yandere.SithLord && !this.Yandere.BanchoActive)
				{
					if (!this.Yandere.FlameDemonic && !this.Yandere.TornadoHair.activeInHierarchy)
					{
						this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
						this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
						this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
						this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
						if (this.Yandere.PantyAttacher.newRenderer != null)
						{
							this.Yandere.PantyAttacher.newRenderer.enabled = false;
						}
					}
					else
					{
						Debug.Log("This block of code activated a shadow.");
						this.Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", this.PantyCensorTexture);
						this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
						this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
						this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
					}
				}
				else
				{
					this.Yandere.PantyAttacher.newRenderer.enabled = false;
				}
			}
			if (this.Yandere.MiyukiCostume.activeInHierarchy || this.Yandere.Rain.activeInHierarchy)
			{
				this.Yandere.PantyAttacher.newRenderer.enabled = false;
				this.Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", this.PantyCensorTexture);
				this.Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", this.PantyCensorTexture);
				this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
				this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
				this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 1f);
			}
			if (this.Yandere.NierCostume.activeInHierarchy || this.Yandere.MyRenderer.sharedMesh == this.Yandere.NudeMesh || this.Yandere.MyRenderer.sharedMesh == this.Yandere.SchoolSwimsuit || this.Yandere.WearingRaincoat)
			{
				this.EasterEggCheck();
			}
			this.StudentManager.CensorStudents();
			return;
		}
		Debug.Log("The censor is OFF.");
		this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
		this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
		this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
		if (this.Yandere.MyRenderer.sharedMesh != this.Yandere.NudeMesh && this.Yandere.MyRenderer.sharedMesh != this.Yandere.SchoolSwimsuit)
		{
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
			this.Yandere.PantyAttacher.newRenderer.enabled = true;
			if (this.Yandere.MyRenderer.sharedMesh == this.Yandere.Uniforms[2])
			{
				Debug.Log("Long-sleeved school uniform. Changing which variable get set to 0.");
				this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			}
			this.EasterEggCheck();
		}
		else
		{
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.Yandere.PantyAttacher.newRenderer.enabled = false;
			this.EasterEggCheck();
		}
		if (this.Yandere.MiyukiCostume.activeInHierarchy)
		{
			this.Yandere.PantyAttacher.newRenderer.enabled = false;
		}
		this.StudentManager.CensorStudents();
	}

	// Token: 0x06001355 RID: 4949 RVA: 0x000B0264 File Offset: 0x000AE464
	public void EasterEggCheck()
	{
		Debug.Log("Checking for easter eggs.");
		if (this.Yandere.BanchoActive || this.Yandere.Sans || this.Yandere.RaincoatAttacher.gameObject.activeInHierarchy || this.Yandere.KLKSword.activeInHierarchy || this.Yandere.Gazing || this.Yandere.Ninja || this.Yandere.ClubAttire || this.Yandere.LifeNotebook.activeInHierarchy || this.Yandere.FalconHelmet.activeInHierarchy || this.Yandere.WearingRaincoat || this.Yandere.MyRenderer.sharedMesh == this.Yandere.NudeMesh || this.Yandere.MyRenderer.sharedMesh == this.Yandere.SchoolSwimsuit)
		{
			Debug.Log("A pants-wearing easter egg is active, so we're going to disable all shadows and panties.");
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
			this.Yandere.PantyAttacher.newRenderer.enabled = false;
		}
		if (this.Yandere.FlameDemonic || this.Yandere.TornadoHair.activeInHierarchy)
		{
			Debug.Log("This other block of code activated a shadow.");
			this.Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", this.PantyCensorTexture);
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
			this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
		}
		if (this.Yandere.NierCostume.activeInHierarchy)
		{
			Debug.Log("Nier costume special case.");
			this.Yandere.PantyAttacher.newRenderer.enabled = false;
			SkinnedMeshRenderer newRenderer = this.Yandere.NierCostume.GetComponent<RiggedAccessoryAttacher>().newRenderer;
			if (newRenderer == null)
			{
				this.TryNextFrame = true;
				return;
			}
			this.TryNextFrame = false;
			if (GameGlobals.CensorPanties)
			{
				newRenderer.materials[0].SetFloat("_BlendAmount", 1f);
				newRenderer.materials[1].SetFloat("_BlendAmount", 1f);
				newRenderer.materials[2].SetFloat("_BlendAmount", 1f);
				newRenderer.materials[3].SetFloat("_BlendAmount", 1f);
				return;
			}
			newRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			newRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			newRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			newRenderer.materials[3].SetFloat("_BlendAmount", 0f);
		}
	}

	// Token: 0x06001356 RID: 4950 RVA: 0x000B068C File Offset: 0x000AE88C
	public void UpdateCensor()
	{
		this.Censor();
		this.Censor();
	}

	// Token: 0x06001357 RID: 4951 RVA: 0x000B069C File Offset: 0x000AE89C
	public void DebugTest()
	{
		if (this.DebugInt == 0)
		{
			StudentScript studentScript = this.StudentManager.Students[39];
			studentScript.ShoeRemoval.Start();
			studentScript.ShoeRemoval.PutOnShoes();
			studentScript.Phase = 2;
			studentScript.ScheduleBlocks[2].action = "Stand";
			studentScript.GetDestinations();
			studentScript.CurrentDestination = this.MidoriSpot;
			studentScript.Pathfinding.target = this.MidoriSpot;
			studentScript.transform.position = this.Yandere.transform.position;
			Physics.SyncTransforms();
		}
		else if (this.DebugInt == 1)
		{
			this.Knife.transform.position = this.Yandere.transform.position + new Vector3(-1f, 1f, 0f);
			this.Knife.GetComponent<Rigidbody>().isKinematic = false;
			this.Knife.GetComponent<Rigidbody>().useGravity = true;
		}
		else if (this.DebugInt == 2)
		{
			this.Mop.transform.position = this.Yandere.transform.position + new Vector3(1f, 1f, 0f);
			this.Mop.GetComponent<Rigidbody>().isKinematic = false;
			this.Mop.GetComponent<Rigidbody>().useGravity = true;
		}
		this.DebugInt++;
	}

	// Token: 0x04001BEA RID: 7146
	public FakeStudentSpawnerScript FakeStudentSpawner;

	// Token: 0x04001BEB RID: 7147
	public DelinquentManagerScript DelinquentManager;

	// Token: 0x04001BEC RID: 7148
	public StudentManagerScript StudentManager;

	// Token: 0x04001BED RID: 7149
	public CameraEffectsScript CameraEffects;

	// Token: 0x04001BEE RID: 7150
	public WeaponManagerScript WeaponManager;

	// Token: 0x04001BEF RID: 7151
	public ReputationScript Reputation;

	// Token: 0x04001BF0 RID: 7152
	public CounselorScript Counselor;

	// Token: 0x04001BF1 RID: 7153
	public DebugConsole DebugConsole;

	// Token: 0x04001BF2 RID: 7154
	public YandereScript Yandere;

	// Token: 0x04001BF3 RID: 7155
	public BentoScript Bento;

	// Token: 0x04001BF4 RID: 7156
	public ClockScript Clock;

	// Token: 0x04001BF5 RID: 7157
	public PrayScript Turtle;

	// Token: 0x04001BF6 RID: 7158
	public ZoomScript Zoom;

	// Token: 0x04001BF7 RID: 7159
	public AstarPath Astar;

	// Token: 0x04001BF8 RID: 7160
	public OsanaFridayBeforeClassEvent1Script OsanaEvent1;

	// Token: 0x04001BF9 RID: 7161
	public OsanaFridayBeforeClassEvent2Script OsanaEvent2;

	// Token: 0x04001BFA RID: 7162
	public OsanaFridayLunchEventScript OsanaEvent3;

	// Token: 0x04001BFB RID: 7163
	public GameObject EasterEggWindow;

	// Token: 0x04001BFC RID: 7164
	public GameObject SacrificialArm;

	// Token: 0x04001BFD RID: 7165
	public GameObject DebugPoisons;

	// Token: 0x04001BFE RID: 7166
	public GameObject CircularSaw;

	// Token: 0x04001BFF RID: 7167
	public GameObject GreenScreen;

	// Token: 0x04001C00 RID: 7168
	public GameObject Knife;

	// Token: 0x04001C01 RID: 7169
	public Transform[] TeleportSpot;

	// Token: 0x04001C02 RID: 7170
	public Transform RooftopSpot;

	// Token: 0x04001C03 RID: 7171
	public Transform MidoriSpot;

	// Token: 0x04001C04 RID: 7172
	public Transform Lockers;

	// Token: 0x04001C05 RID: 7173
	public GameObject MissionModeWindow;

	// Token: 0x04001C06 RID: 7174
	public GameObject Window;

	// Token: 0x04001C07 RID: 7175
	public GameObject[] ElectrocutionKit;

	// Token: 0x04001C08 RID: 7176
	public bool WaitingForNumber;

	// Token: 0x04001C09 RID: 7177
	public bool TryNextFrame;

	// Token: 0x04001C0A RID: 7178
	public bool MissionMode;

	// Token: 0x04001C0B RID: 7179
	public bool NoDebug;

	// Token: 0x04001C0C RID: 7180
	public int KidnappedVictim = 11;

	// Token: 0x04001C0D RID: 7181
	public int RooftopStudent = 7;

	// Token: 0x04001C0E RID: 7182
	public int DebugInputs;

	// Token: 0x04001C0F RID: 7183
	public float Timer;

	// Token: 0x04001C10 RID: 7184
	public int ID;

	// Token: 0x04001C11 RID: 7185
	public Texture PantyCensorTexture;

	// Token: 0x04001C12 RID: 7186
	private int DebugInt;

	// Token: 0x04001C13 RID: 7187
	public GameObject Mop;
}
