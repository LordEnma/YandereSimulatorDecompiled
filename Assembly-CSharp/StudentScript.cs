using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000463 RID: 1123
public class StudentScript : MonoBehaviour
{
	// Token: 0x170004AA RID: 1194
	// (get) Token: 0x06001E0F RID: 7695 RVA: 0x00172565 File Offset: 0x00170765
	public bool Alive
	{
		get
		{
			return this.DeathType == DeathType.None;
		}
	}

	// Token: 0x06001E10 RID: 7696 RVA: 0x00172570 File Offset: 0x00170770
	public void Start()
	{
		this.CounterAnim = "f02_teacherCounterB_00";
		if (!this.Started)
		{
			this.CharacterAnimation = this.Character.GetComponent<Animation>();
			this.MyBento = this.Bento.GetComponent<GenericBentoScript>();
			this.Pathfinding.repathRate += (float)this.StudentID * 0.01f;
			this.OriginalIdleAnim = this.IdleAnim;
			this.OriginalLeanAnim = this.LeanAnim;
			this.Friend = PlayerGlobals.GetStudentFriend(this.StudentID);
			if (!this.StudentManager.LoveSick && SchoolAtmosphere.Type == SchoolAtmosphereType.Low && (this.Club <= ClubType.Gaming || this.Club == ClubType.Newspaper))
			{
				this.IdleAnim = this.ParanoidAnim;
			}
			if (ClubGlobals.Club == ClubType.Occult)
			{
				this.Perception = 0.5f;
			}
			this.Hearts.emission.enabled = false;
			this.Prompt.OwnerType = PromptOwnerType.Person;
			this.Paranoia = 2f - SchoolGlobals.SchoolAtmosphere;
			this.VisionDistance = ((PlayerGlobals.PantiesEquipped == 4) ? 5f : 10f) * this.Paranoia;
			if (this.Yandere != null && this.Yandere.DetectionPanel != null)
			{
				this.SpawnDetectionMarker();
			}
			StudentJson studentJson = this.JSON.Students[this.StudentID];
			this.ScheduleBlocks = studentJson.ScheduleBlocks;
			this.Persona = studentJson.Persona;
			this.Class = studentJson.Class;
			this.Crush = studentJson.Crush;
			this.Club = studentJson.Club;
			this.BreastSize = studentJson.BreastSize;
			this.Strength = studentJson.Strength;
			this.Hairstyle = studentJson.Hairstyle;
			this.Accessory = studentJson.Accessory;
			this.Name = studentJson.Name;
			this.OriginalClub = this.Club;
			if (StudentGlobals.GetStudentBroken(this.StudentID))
			{
				this.Cosmetic.RightEyeRenderer.gameObject.SetActive(false);
				this.Cosmetic.LeftEyeRenderer.gameObject.SetActive(false);
				this.Cosmetic.RightIrisLight.SetActive(false);
				this.Cosmetic.LeftIrisLight.SetActive(false);
				this.RightEmptyEye.SetActive(true);
				this.LeftEmptyEye.SetActive(true);
				this.Traumatized = true;
				this.Shy = true;
				this.Persona = PersonaType.Coward;
			}
			if (this.Name == "Random")
			{
				this.Persona = (PersonaType)UnityEngine.Random.Range(1, 8);
				if (this.Persona == PersonaType.Lovestruck)
				{
					this.Persona = PersonaType.PhoneAddict;
				}
				studentJson.Persona = this.Persona;
				if (this.Persona == PersonaType.Heroic)
				{
					this.Strength = UnityEngine.Random.Range(1, 5);
					studentJson.Strength = this.Strength;
				}
			}
			this.Seat = this.StudentManager.Seats[this.Class].List[studentJson.Seat];
			base.gameObject.name = string.Concat(new string[]
			{
				"Student_",
				this.StudentID.ToString(),
				" (",
				this.Name,
				")"
			});
			this.OriginalPersona = this.Persona;
			if (this.StudentID == 81 && StudentGlobals.GetStudentBroken(81))
			{
				this.Persona = PersonaType.Coward;
			}
			if (this.Persona == PersonaType.Loner || this.Persona == PersonaType.Coward || this.Persona == PersonaType.Fragile)
			{
				this.CameraAnims = this.CowardAnims;
			}
			else if (this.Persona == PersonaType.TeachersPet || this.Persona == PersonaType.Heroic || this.Persona == PersonaType.Strict)
			{
				this.CameraAnims = this.HeroAnims;
			}
			else if (this.Persona == PersonaType.Evil || this.Persona == PersonaType.Spiteful || this.Persona == PersonaType.Violent)
			{
				this.CameraAnims = this.EvilAnims;
			}
			else if (this.Persona == PersonaType.SocialButterfly || this.Persona == PersonaType.Lovestruck || this.Persona == PersonaType.PhoneAddict || this.Persona == PersonaType.Sleuth)
			{
				this.CameraAnims = this.SocialAnims;
			}
			if (ClubGlobals.GetClubClosed(this.Club))
			{
				this.Club = ClubType.None;
			}
			this.Yandere = this.StudentManager.Yandere;
			this.DialogueWheel = this.StudentManager.DialogueWheel;
			this.ClubManager = this.StudentManager.ClubManager;
			this.Reputation = this.StudentManager.Reputation;
			this.Subtitle = this.Yandere.Subtitle;
			this.Police = this.StudentManager.Police;
			this.Clock = this.StudentManager.Clock;
			this.CameraEffects = this.Yandere.MainCamera.GetComponent<CameraEffectsScript>();
			this.RightEyeOrigin = this.RightEye.localPosition;
			this.LeftEyeOrigin = this.LeftEye.localPosition;
			this.Bento.GetComponent<GenericBentoScript>().StudentID = this.StudentID;
			this.DisableProps();
			this.OriginalOriginalSprintAnim = this.SprintAnim;
			this.OriginalOriginalWalkAnim = this.WalkAnim;
			this.OriginalSprintAnim = this.SprintAnim;
			this.OriginalWalkAnim = this.WalkAnim;
			if (this.Persona == PersonaType.Evil)
			{
				this.ScaredAnim = this.EvilWitnessAnim;
			}
			if (this.Persona == PersonaType.PhoneAddict)
			{
				this.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
				this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
				this.Countdown.Speed = 0.1f;
				this.SprintAnim = this.PhoneAnims[2];
				this.PatrolAnim = this.PhoneAnims[3];
			}
			if (this.Club == ClubType.Bully)
			{
				this.SkirtCollider.transform.localPosition = new Vector3(0f, 0.055f, 0f);
				if (!StudentGlobals.GetStudentBroken(this.StudentID))
				{
					this.IdleAnim = this.PhoneAnims[0];
					this.BullyID = this.StudentID - 80;
				}
			}
			this.SetSplashes(false);
			if (!this.Male)
			{
				this.DisableFemaleProps();
			}
			else
			{
				this.DisableMaleProps();
			}
			if (this.Rival)
			{
				this.MapMarker.gameObject.SetActive(true);
			}
			if (!this.StudentManager.Eighties)
			{
				if (this.StudentID == 1)
				{
					this.MapMarker.gameObject.SetActive(true);
					if (DateGlobals.Week == 2)
					{
						ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
						scheduleBlock.destination = "Patrol";
						scheduleBlock.action = "Patrol";
						ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[7];
						scheduleBlock2.destination = "Patrol";
						scheduleBlock2.action = "Patrol";
					}
				}
				else if (this.StudentID == 2)
				{
					if (StudentGlobals.GetStudentDead(3) || StudentGlobals.GetStudentKidnapped(3) || this.StudentManager.Students[3] == null || (this.StudentManager.Students[3] != null && this.StudentManager.Students[3].Slave))
					{
						ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[2];
						scheduleBlock3.destination = "Mourn";
						scheduleBlock3.action = "Mourn";
						ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[7];
						scheduleBlock4.destination = "Mourn";
						scheduleBlock4.action = "Mourn";
						this.IdleAnim = this.BulliedIdleAnim;
						this.WalkAnim = this.BulliedWalkAnim;
					}
					this.PatrolAnim = this.SearchPatrolAnim;
				}
				else if (this.StudentID == 3)
				{
					if (StudentGlobals.GetStudentDead(2) || StudentGlobals.GetStudentKidnapped(2) || this.StudentManager.Students[2] == null || (this.StudentManager.Students[2] != null && this.StudentManager.Students[2].Slave))
					{
						ScheduleBlock scheduleBlock5 = this.ScheduleBlocks[2];
						scheduleBlock5.destination = "Mourn";
						scheduleBlock5.action = "Mourn";
						ScheduleBlock scheduleBlock6 = this.ScheduleBlocks[7];
						scheduleBlock6.destination = "Mourn";
						scheduleBlock6.action = "Mourn";
						this.IdleAnim = this.BulliedIdleAnim;
						this.WalkAnim = this.BulliedWalkAnim;
					}
					this.PatrolAnim = this.SearchPatrolAnim;
				}
				else if (this.StudentID == 4)
				{
					this.IdleAnim = "f02_idleShort_00";
					this.WalkAnim = "f02_newWalk_00";
				}
				else if (this.StudentID == 5)
				{
					this.LongSkirt = true;
					if (!this.StudentManager.TakingPortraits)
					{
						this.Shy = true;
					}
				}
				else if (this.StudentID == 6)
				{
					this.RelaxAnim = "crossarms_00";
					this.CameraAnims = this.HeroAnims;
					this.Curious = true;
					this.Crush = 11;
					if (this.StudentManager.Students[11] == null)
					{
						this.Curious = false;
					}
				}
				else if (this.StudentID == 7)
				{
					this.RunAnim = "runFeminine_00";
					this.SprintAnim = "runFeminine_00";
					this.RelaxAnim = "infirmaryRest_00";
					this.OriginalSprintAnim = this.SprintAnim;
					this.Cosmetic.Start();
					if (!GameGlobals.AlphabetMode && !this.StudentManager.MissionMode)
					{
						base.gameObject.SetActive(false);
					}
				}
				else if (this.StudentID == 8)
				{
					this.IdleAnim = this.BulliedIdleAnim;
					this.WalkAnim = this.BulliedWalkAnim;
				}
				else if (this.StudentID == 9)
				{
					this.IdleAnim = "idleScholarly_00";
					this.WalkAnim = "walkScholarly_00";
					this.CameraAnims = this.HeroAnims;
				}
				else if (this.StudentID == 10)
				{
					this.Reflexes = true;
					if (GameGlobals.AlphabetMode || this.StudentManager.MissionMode)
					{
						this.OriginalPersona = PersonaType.Heroic;
						this.Persona = PersonaType.Heroic;
						this.Reflexes = false;
						this.Strength = 5;
					}
					else
					{
						this.LovestruckTarget = 11;
					}
					if (this.StudentManager.Students[11] != null && DatingGlobals.SuitorProgress < 2 && (float)StudentGlobals.GetStudentReputation(10) > -33.33333f && StudentGlobals.StudentSlave != 11 && !GameGlobals.AlphabetMode && !this.StudentManager.MissionMode)
					{
						this.StudentManager.Patrols.List[this.StudentID].parent = this.StudentManager.Students[11].transform;
						this.StudentManager.Patrols.List[this.StudentID].localEulerAngles = new Vector3(0f, 0f, 0f);
						this.StudentManager.Patrols.List[this.StudentID].localPosition = new Vector3(0f, 0f, 0f);
						this.VomitPhase = -1;
						this.Indoors = true;
						this.Spawned = true;
						this.Calm = true;
						if (this.ShoeRemoval.Locker == null)
						{
							this.ShoeRemoval.Start();
						}
						this.ShoeRemoval.PutOnShoes();
						this.FollowTarget = this.StudentManager.Students[11];
						this.FollowTarget.Follower = this;
						this.IdleAnim = "f02_idleGirly_00";
						this.WalkAnim = "f02_walkGirly_00";
						this.PatrolAnim = "f02_stretch_00";
						this.OriginalIdleAnim = this.IdleAnim;
					}
					else
					{
						Debug.Log("Due to the circumstances, we're changing Raibaru's destinations.");
						if (this.StudentManager.Students[11] == null || StudentGlobals.StudentSlave == 11 || GameGlobals.AlphabetMode || this.StudentManager.MissionMode)
						{
							this.RaibaruOsanaDeathScheduleChanges();
						}
						else if ((float)StudentGlobals.GetStudentReputation(10) <= -33.33333f)
						{
							ScheduleBlock scheduleBlock7 = this.ScheduleBlocks[2];
							scheduleBlock7.destination = "Seat";
							scheduleBlock7.action = "Sit";
							scheduleBlock7.time = 8f;
							ScheduleBlock scheduleBlock8 = this.ScheduleBlocks[4];
							scheduleBlock8.destination = "Seat";
							scheduleBlock8.action = "Sit";
							this.IdleAnim = this.BulliedIdleAnim;
							this.WalkAnim = this.BulliedWalkAnim;
							this.OriginalIdleAnim = this.IdleAnim;
						}
						else if (DatingGlobals.SuitorProgress == 2)
						{
							ScheduleBlock scheduleBlock9 = this.ScheduleBlocks[2];
							scheduleBlock9.destination = "Peek";
							scheduleBlock9.action = "Peek";
							scheduleBlock9.time = 8f;
							ScheduleBlock scheduleBlock10 = this.ScheduleBlocks[4];
							scheduleBlock10.destination = "LunchSpot";
							scheduleBlock10.action = "Eat";
						}
						this.RaibaruStopsFollowingOsana();
						this.TargetDistance = 0.5f;
					}
					this.PhotoPatience = 0f;
					this.OriginalWalkAnim = this.WalkAnim;
					this.CharacterAnimation["f02_nervousLeftRight_00"].speed = 0.5f;
				}
				else if (this.StudentID == 11)
				{
					this.SmartPhone.transform.localPosition = new Vector3(-0.0075f, -0.0025f, -0.0075f);
					this.SmartPhone.transform.localEulerAngles = new Vector3(5f, -150f, 170f);
					this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.OsanaPhoneTexture;
					this.IdleAnim = "f02_tsunIdle_00";
					this.WalkAnim = "f02_tsunWalk_00";
					this.TaskAnims[0] = "f02_Task33_Line0";
					this.TaskAnims[1] = "f02_Task33_Line1";
					this.TaskAnims[2] = "f02_Task33_Line2";
					this.TaskAnims[3] = "f02_Task33_Line3";
					this.TaskAnims[4] = "f02_Task33_Line4";
					this.TaskAnims[5] = "f02_Task33_Line5";
					this.LovestruckTarget = 1;
					this.PhotoPatience = 0f;
					if (this.StudentManager.Students[10] == null)
					{
						Debug.Log("Raibaru has been killed/arrested/vanished, so Osana's schedule has changed.");
						ScheduleBlock scheduleBlock11 = this.ScheduleBlocks[2];
						scheduleBlock11.destination = "Mourn";
						scheduleBlock11.action = "Mourn";
						ScheduleBlock scheduleBlock12 = this.ScheduleBlocks[7];
						scheduleBlock12.destination = "Mourn";
						scheduleBlock12.action = "Mourn";
						this.IdleAnim = this.BulliedIdleAnim;
						this.WalkAnim = this.BulliedWalkAnim;
					}
					else if (PlayerGlobals.RaibaruLoner || GameGlobals.AlphabetMode || this.StudentManager.MissionMode)
					{
						Debug.Log("Raibaru has become a loner, so Osana's schedule has changed.");
						ScheduleBlock scheduleBlock13 = this.ScheduleBlocks[2];
						scheduleBlock13.destination = "Patrol";
						scheduleBlock13.action = "Patrol";
						ScheduleBlock scheduleBlock14 = this.ScheduleBlocks[7];
						scheduleBlock14.destination = "Patrol";
						scheduleBlock14.action = "Patrol";
						this.PatrolAnim = "f02_pondering_00";
					}
					this.OriginalWalkAnim = this.WalkAnim;
				}
				else if (this.StudentID == 12)
				{
					this.IdleAnim = "f02_idleGirly_00";
					this.WalkAnim = "f02_walkGirly_00";
					this.Distracted = true;
					this.CanTalk = false;
				}
				else if (this.StudentID == 24 && this.StudentID == 25)
				{
					this.IdleAnim = "f02_idleGirly_00";
					this.WalkAnim = "f02_walkGirly_00";
				}
				else if (this.StudentID == 26)
				{
					this.IdleAnim = "idleHaughty_00";
					this.WalkAnim = "walkHaughty_00";
				}
				else if (this.StudentID == 28 || this.StudentID == 30)
				{
					if (this.StudentID == 30)
					{
						this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.KokonaPhoneTexture;
					}
				}
				else if (this.StudentID == 31)
				{
					this.IdleAnim = this.BulliedIdleAnim;
					this.WalkAnim = this.BulliedWalkAnim;
				}
				else if (this.StudentID == 34 || this.StudentID == 35)
				{
					this.IdleAnim = "f02_idleShort_00";
					this.WalkAnim = "f02_newWalk_00";
					if (this.Paranoia > 1.66666f)
					{
						this.IdleAnim = this.ParanoidAnim;
						this.WalkAnim = this.ParanoidWalkAnim;
					}
				}
				else if (this.StudentID == 36)
				{
					if (TaskGlobals.GetTaskStatus(36) < 3)
					{
						this.IdleAnim = "slouchIdle_00";
						this.WalkAnim = "slouchWalk_00";
						this.ClubAnim = "slouchGaming_00";
					}
					else
					{
						this.IdleAnim = "properIdle_00";
						this.WalkAnim = "properWalk_00";
						this.ClubAnim = "properGaming_00";
					}
					if (this.Paranoia > 1.66666f)
					{
						this.IdleAnim = this.ParanoidAnim;
						this.WalkAnim = this.ParanoidWalkAnim;
					}
					if (this.StudentManager.MissionMode)
					{
						Debug.Log("Changing Gema's routine for Mission Mode.");
						ScheduleBlock scheduleBlock15 = this.ScheduleBlocks[4];
						scheduleBlock15.destination = "LunchSpot";
						scheduleBlock15.action = "Eat";
					}
				}
				else if (this.StudentID == 39)
				{
					this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.MidoriPhoneTexture;
					this.PatrolAnim = "f02_midoriTexting_00";
				}
				else if (this.StudentID == 51)
				{
					this.IdleAnim = "f02_idleConfident_01";
					this.WalkAnim = "f02_walkConfident_01";
					if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
					{
						this.IdleAnim = this.BulliedIdleAnim;
						this.WalkAnim = this.BulliedWalkAnim;
						this.CameraAnims = this.CowardAnims;
						this.Persona = PersonaType.Loner;
						if (!SchoolGlobals.RoofFence)
						{
							ScheduleBlock scheduleBlock16 = this.ScheduleBlocks[2];
							scheduleBlock16.destination = "Sulk";
							scheduleBlock16.action = "Sulk";
							ScheduleBlock scheduleBlock17 = this.ScheduleBlocks[4];
							scheduleBlock17.destination = "Sulk";
							scheduleBlock17.action = "Sulk";
							ScheduleBlock scheduleBlock18 = this.ScheduleBlocks[7];
							scheduleBlock18.destination = "Sulk";
							scheduleBlock18.action = "Sulk";
							ScheduleBlock scheduleBlock19 = this.ScheduleBlocks[8];
							scheduleBlock19.destination = "Sulk";
							scheduleBlock19.action = "Sulk";
						}
						else
						{
							ScheduleBlock scheduleBlock20 = this.ScheduleBlocks[2];
							scheduleBlock20.destination = "Seat";
							scheduleBlock20.action = "Sit";
							ScheduleBlock scheduleBlock21 = this.ScheduleBlocks[4];
							scheduleBlock21.destination = "Seat";
							scheduleBlock21.action = "Sit";
							ScheduleBlock scheduleBlock22 = this.ScheduleBlocks[7];
							scheduleBlock22.destination = "Seat";
							scheduleBlock22.action = "Sit";
							ScheduleBlock scheduleBlock23 = this.ScheduleBlocks[8];
							scheduleBlock23.destination = "Seat";
							scheduleBlock23.action = "Sit";
						}
					}
					if (this.StudentManager.MissionMode)
					{
						Debug.Log("Changing Miyuji's routine for Mission Mode.");
						ScheduleBlock scheduleBlock24 = this.ScheduleBlocks[4];
						scheduleBlock24.destination = "LunchSpot";
						scheduleBlock24.action = "Eat";
					}
				}
				else if (this.StudentID == 56)
				{
					this.IdleAnim = "idleConfident_00";
					this.WalkAnim = "walkConfident_00";
					this.SleuthID = 1;
				}
				else if (this.StudentID == 57)
				{
					this.IdleAnim = "idleChill_01";
					this.WalkAnim = "walkChill_01";
					this.SleuthID = 20;
				}
				else if (this.StudentID == 58)
				{
					this.IdleAnim = "idleChill_00";
					this.WalkAnim = "walkChill_00";
					this.SleuthID = 40;
				}
				else if (this.StudentID == 59)
				{
					this.IdleAnim = "f02_idleGraceful_00";
					this.WalkAnim = "f02_walkGraceful_00";
					this.SleuthID = 60;
				}
				else if (this.StudentID == 60)
				{
					this.IdleAnim = "f02_idleScholarly_00";
					this.WalkAnim = "f02_walkScholarly_00";
					this.CameraAnims = this.HeroAnims;
					this.SleuthID = 80;
				}
				else if (this.StudentID == 61)
				{
					this.IdleAnim = "scienceIdle_00";
					this.WalkAnim = "scienceWalk_00";
					this.OriginalWalkAnim = "scienceWalk_00";
				}
				else if (this.StudentID == 62)
				{
					this.IdleAnim = "idleFrown_00";
					this.WalkAnim = "walkFrown_00";
					if (this.Paranoia > 1.66666f)
					{
						this.IdleAnim = this.ParanoidAnim;
						this.WalkAnim = this.ParanoidWalkAnim;
					}
				}
				else if (this.StudentID == 64 || this.StudentID == 65)
				{
					this.IdleAnim = "f02_idleShort_00";
					this.WalkAnim = "f02_newWalk_00";
					if (this.Paranoia > 1.66666f)
					{
						this.IdleAnim = this.ParanoidAnim;
						this.WalkAnim = this.ParanoidWalkAnim;
					}
				}
				else if (this.StudentID == 66)
				{
					this.IdleAnim = "pose_03";
					this.OriginalWalkAnim = "walkConfident_00";
					this.WalkAnim = "walkConfident_00";
					this.ClubThreshold = 100f;
				}
				else if (this.StudentID == 69)
				{
					this.IdleAnim = "idleFrown_00";
					this.WalkAnim = "walkFrown_00";
					if (this.Paranoia > 1.66666f)
					{
						this.IdleAnim = this.ParanoidAnim;
						this.WalkAnim = this.ParanoidWalkAnim;
					}
				}
				else if (this.StudentID == 71)
				{
					this.IdleAnim = "f02_idleGirly_00";
					this.WalkAnim = "f02_walkGirly_00";
					if (!this.PickPocket.gameObject.transform.parent.gameObject.activeInHierarchy)
					{
						this.PickPocket.gameObject.transform.parent.gameObject.SetActive(true);
					}
				}
				if ((this.StudentID == 6 || this.StudentID == 11) && DatingGlobals.SuitorProgress == 2)
				{
					this.Partner = ((this.StudentID == 11) ? this.StudentManager.Students[6] : this.StudentManager.Students[11]);
					ScheduleBlock scheduleBlock25 = this.ScheduleBlocks[2];
					scheduleBlock25.destination = "Cuddle";
					scheduleBlock25.action = "Cuddle";
					ScheduleBlock scheduleBlock26 = this.ScheduleBlocks[4];
					scheduleBlock26.destination = "Cuddle";
					scheduleBlock26.action = "Cuddle";
					ScheduleBlock scheduleBlock27 = this.ScheduleBlocks[6];
					scheduleBlock27.destination = "Locker";
					scheduleBlock27.action = "Shoes";
					ScheduleBlock scheduleBlock28 = this.ScheduleBlocks[7];
					scheduleBlock28.destination = "Exit";
					scheduleBlock28.action = "Exit";
				}
			}
			else
			{
				this.BookRenderer.material.mainTexture = this.RedBookTexture;
				this.Phoneless = true;
				if (!this.Male)
				{
					this.PatrolAnim = "f02_thinking_00";
				}
				if (this.Rival)
				{
					if (this.StudentID > 10 && this.StudentID < 21)
					{
						ScheduleBlock scheduleBlock29 = this.ScheduleBlocks[2];
						scheduleBlock29.destination = "Seat";
						scheduleBlock29.action = "PlaceBag";
					}
					this.BookBag.SetActive(true);
					this.LovestruckTarget = 1;
				}
				if (this.StudentID == 11)
				{
					this.IdleAnim = "f02_idleGirly_00";
					this.WalkAnim = "f02_walkGirly_00";
					if (!this.Rival)
					{
						this.Persona = PersonaType.LandlineUser;
					}
				}
				else if (this.StudentID == 12)
				{
					this.IdleAnim = "f02_idleConfident_01";
					this.WalkAnim = "f02_walkConfident_01";
					this.PyroUrge = true;
					if (!this.Rival)
					{
						this.Persona = PersonaType.LandlineUser;
					}
				}
				else if (this.StudentID == 13)
				{
					this.IdleAnim = "f02_idleShy_00";
					this.WalkAnim = "f02_walkShy_00";
					if (!this.Rival)
					{
						this.Persona = PersonaType.Coward;
					}
				}
				else if (this.StudentID == 14)
				{
					this.IdleAnim = "f02_idleLively_00";
					this.WalkAnim = "f02_walkLively_00";
					this.ClubAnim = "f02_stretch_00";
					if (!this.Rival)
					{
						this.Persona = PersonaType.Heroic;
					}
				}
				else if (this.StudentID == 15)
				{
					this.IdleAnim = "f02_idleHaughty_00";
					this.WalkAnim = "f02_walkHaughty_00";
					if (!this.Rival)
					{
						this.Persona = PersonaType.Loner;
					}
				}
				else if (this.StudentID == 16)
				{
					this.IdleAnim = "f02_idleGirly_00";
					this.WalkAnim = "f02_walkGirly_00";
					this.ClubAnim = "f02_vocalSingA_00";
					if (DateGlobals.Week != 6)
					{
						ScheduleBlock scheduleBlock30 = this.ScheduleBlocks[2];
						scheduleBlock30.destination = "Lyrics";
						scheduleBlock30.action = "Lyrics";
						ScheduleBlock scheduleBlock31 = this.ScheduleBlocks[7];
						scheduleBlock31.destination = "Lyrics";
						scheduleBlock31.action = "Lyrics";
					}
					if (!this.Rival)
					{
						this.Persona = PersonaType.LandlineUser;
					}
				}
				else if (this.StudentID == 17 || this.StudentID == 18)
				{
					this.IdleAnim = "f02_idleCouncilGrace_00";
					this.WalkAnim = "f02_walkCouncilGrace_00";
					this.CharacterAnimation["f02_smile_00"].layer = 1;
					this.CharacterAnimation.Play("f02_smile_00");
					this.CharacterAnimation["f02_smile_00"].weight = 1f;
					if (!this.Rival)
					{
						this.Persona = PersonaType.TeachersPet;
					}
				}
				else if (this.StudentID == 19)
				{
					this.IdleAnim = "f02_idleElegant_00";
					this.WalkAnim = "f02_walkElegant_00";
					this.OriginalWalkAnim = "f02_walkElegant_00";
					this.OriginalOriginalWalkAnim = "f02_walkElegant_00";
					this.ClubAnim = this.GravureAnims[0];
					if (!this.Rival)
					{
						this.Persona = PersonaType.LandlineUser;
					}
				}
				else if (this.StudentID == 20)
				{
					this.IdleAnim = "f02_idleConfident_00";
					this.WalkAnim = "f02_walkConfident_00";
					if (!this.Rival)
					{
						this.Persona = PersonaType.Heroic;
					}
				}
				else if (this.StudentID == 66)
				{
					this.ClubThreshold = 100f;
				}
				if (this.StudentID > 10 && this.StudentID < 21)
				{
					this.OriginalPersona = this.Persona;
				}
				if (this.Male && this.Club == ClubType.Delinquent)
				{
					this.CharacterAnimation[this.WalkAnim].speed += 0.01f * (float)(this.StudentID - 76);
				}
				if (this.StudentID == 20)
				{
					this.GuardID = 1;
				}
				else
				{
					this.GuardID = 20;
				}
			}
			this.OriginalWalkAnim = this.WalkAnim;
			if (StudentGlobals.GetStudentGrudge(this.StudentID))
			{
				if (this.Persona != PersonaType.Coward && this.Persona != PersonaType.Evil && this.Club != ClubType.Delinquent)
				{
					this.CameraAnims = this.EvilAnims;
					this.Reputation.PendingRep -= 10f;
					this.PendingRep -= 10f;
					this.ID = 0;
					while (this.ID < this.Outlines.Length)
					{
						if (this.Outlines[this.ID] != null)
						{
							this.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
						}
						this.ID++;
					}
				}
				this.Grudge = true;
				this.CameraAnims = this.EvilAnims;
			}
			if (this.Rival)
			{
				this.ID = 0;
				while (this.ID < this.Outlines.Length)
				{
					if (this.Outlines[this.ID] != null)
					{
						this.Outlines[this.ID].color = new Color(10f, 0f, 0f, 1f);
					}
					this.ID++;
				}
			}
			if (this.Persona == PersonaType.Sleuth)
			{
				if (SchoolGlobals.SchoolAtmosphere <= 0.8f || this.Grudge)
				{
					this.BecomeSleuth();
				}
				else if (SchoolGlobals.SchoolAtmosphere <= 0.9f)
				{
					this.WalkAnim = this.ParanoidWalkAnim;
					this.CameraAnims = this.HeroAnims;
				}
			}
			if (!this.Slave)
			{
				if (this.StudentManager.Bullies > 1)
				{
					if (this.StudentID == 81 || this.StudentID == 83 || this.StudentID == 85)
					{
						if (this.Persona != PersonaType.Coward)
						{
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							this.Paired = true;
							this.CharacterAnimation["f02_walkTalk_00"].time += (float)(this.StudentID - 81);
							this.WalkAnim = "f02_walkTalk_00";
							this.SpeechLines.Play();
						}
					}
					else if (this.StudentID == 82 || this.StudentID == 84)
					{
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Paired = true;
						this.CharacterAnimation["f02_walkTalk_01"].time += (float)(this.StudentID - 81);
						this.WalkAnim = "f02_walkTalk_01";
						this.SpeechLines.Play();
					}
				}
				if (this.Club == ClubType.Delinquent)
				{
					if (this.Friend)
					{
						this.RespectEarned = true;
					}
					if (CounselorGlobals.WeaponsBanned == 0)
					{
						this.MyWeapon = this.Yandere.WeaponManager.DelinquentWeapons[this.StudentID - 75];
						this.MyWeapon.transform.parent = this.WeaponBagParent;
						this.MyWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						this.MyWeapon.transform.localPosition = new Vector3(0f, 0f, 0f);
						this.MyWeapon.FingerprintID = this.StudentID;
						this.MyWeapon.MyCollider.enabled = false;
						this.WeaponBag.SetActive(true);
					}
					else
					{
						this.OriginalPersona = PersonaType.Heroic;
						this.Persona = PersonaType.Heroic;
					}
					string str = "";
					if (!this.Male)
					{
						str = "f02_";
					}
					this.ScaredAnim = "delinquentCombatIdle_00";
					this.LeanAnim = "delinquentConcern_00";
					this.ShoveAnim = str + "pushTough_00";
					this.WalkAnim = str + "walkTough_00";
					this.IdleAnim = str + "idleTough_00";
					this.SpeechLines = this.DelinquentSpeechLines;
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.Paired = true;
					if (this.Male)
					{
						this.TaskAnims[0] = str + "delinquentTalk_04";
						this.TaskAnims[1] = str + "delinquentTalk_01";
						this.TaskAnims[2] = str + "delinquentTalk_02";
						this.TaskAnims[3] = str + "delinquentTalk_03";
						this.TaskAnims[4] = str + "delinquentTalk_00";
						this.TaskAnims[5] = str + "delinquentTalk_03";
					}
				}
			}
			else
			{
				this.Club = ClubType.None;
			}
			if (this.Rival)
			{
				this.RivalPrefix = "Rival ";
				if (DateGlobals.Weekday == DayOfWeek.Friday)
				{
					this.ScheduleBlocks[7].time = 17f;
				}
			}
			if (!this.Teacher && this.Name != "Random")
			{
				this.StudentManager.CleaningManager.GetRole(this.StudentID);
				this.CleaningSpot = this.StudentManager.CleaningManager.Spot;
				this.CleaningRole = this.StudentManager.CleaningManager.Role;
			}
			if (this.Club == ClubType.Cooking)
			{
				this.SleuthID = (this.StudentID - 21) * 20;
				this.ClubAnim = this.PrepareFoodAnim;
				if (this.StudentID > 12)
				{
					this.ClubMemberID = this.StudentID - 20;
					this.MyPlate = this.StudentManager.Plates[this.ClubMemberID];
					this.OriginalPlatePosition = this.MyPlate.position;
					this.OriginalPlateRotation = this.MyPlate.rotation;
				}
				if (!this.StudentManager.EmptyDemon && !this.StudentManager.TutorialActive)
				{
					this.ApronAttacher.enabled = true;
				}
			}
			else if (this.Club == ClubType.Drama)
			{
				if (this.StudentID == 26)
				{
					this.ClubAnim = "teaching_00";
				}
				else if (this.StudentID == 27 || this.StudentID == 28)
				{
					this.ClubAnim = "sit_00";
				}
				else if (this.StudentID == 29 || this.StudentID == 30)
				{
					this.ClubAnim = "f02_sit_00";
				}
				this.OriginalClubAnim = this.ClubAnim;
			}
			else if (this.Club == ClubType.Occult)
			{
				this.PatrolAnim = this.ThinkAnim;
				this.CharacterAnimation[this.PatrolAnim].speed = 0.2f;
			}
			else if (this.Club == ClubType.Gaming)
			{
				this.MiyukiGameScreen.SetActive(true);
				this.ClubMemberID = this.StudentID - 35;
				if (this.StudentID > 36)
				{
					this.ClubAnim = this.GameAnim;
				}
				this.ActivityAnim = this.GameAnim;
			}
			else if (this.Club == ClubType.Art)
			{
				this.ChangingBooth = this.StudentManager.ChangingBooths[4];
				this.ActivityAnim = this.PaintAnim;
				this.Attacher.ArtClub = true;
				this.ClubAnim = this.PaintAnim;
				this.DressCode = true;
				if (DateGlobals.Weekday == DayOfWeek.Friday)
				{
					ScheduleBlock scheduleBlock32 = this.ScheduleBlocks[7];
					scheduleBlock32.destination = "Paint";
					scheduleBlock32.action = "Paint";
				}
				this.ClubMemberID = this.StudentID - 40;
				this.Painting = this.StudentManager.FridayPaintings[this.ClubMemberID];
				this.GetDestinations();
			}
			else if (this.Club == ClubType.LightMusic)
			{
				this.ClubMemberID = this.StudentID - 50;
				this.InstrumentBag[this.ClubMemberID].SetActive(true);
				if (this.StudentID == 51)
				{
					this.ClubAnim = "f02_practiceGuitar_01";
				}
				else if (this.StudentID == 52 || this.StudentID == 53)
				{
					this.ClubAnim = "f02_practiceGuitar_00";
				}
				else if (this.StudentID == 54)
				{
					this.ClubAnim = "f02_practiceDrums_00";
					this.Instruments[4] = this.StudentManager.DrumSet;
					if (this.StudentManager.Eighties)
					{
						this.InstrumentBag[this.ClubMemberID].GetComponent<Renderer>().enabled = false;
						this.Instruments[this.ClubMemberID].GetComponent<Renderer>().enabled = false;
					}
				}
				else if (this.StudentID == 55)
				{
					this.ClubAnim = "f02_practiceKeytar_00";
				}
				if (this.StudentManager.Eighties && this.StudentManager.Students[16] != null && DateGlobals.Week == 6)
				{
					this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().enabled = false;
					this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().volume = 0f;
					if (this.StudentID == 52)
					{
						this.ClubAnim = "f02_guitarPlayA_00";
					}
					else if (this.StudentID == 53)
					{
						this.ClubAnim = "f02_guitarPlayB_00";
					}
					else if (this.StudentID == 54)
					{
						this.ClubAnim = "f02_drumsPlay_00";
					}
					else if (this.StudentID == 55)
					{
						this.ClubAnim = "f02_keysPlay_00";
					}
				}
			}
			else if (this.Club == ClubType.MartialArts)
			{
				this.ChangingBooth = this.StudentManager.ChangingBooths[6];
				this.DressCode = true;
				if (this.StudentID == 46)
				{
					this.IdleAnim = "pose_03";
					this.ClubAnim = "pose_03";
					this.ActivityAnim = this.IdleAnim;
				}
				else if (this.StudentID == 47)
				{
					this.GetNewAnimation = true;
					this.ClubAnim = "idle_20";
					this.ActivityAnim = "kick_24";
				}
				else if (this.StudentID == 48)
				{
					this.ClubAnim = "sit_04";
					this.ActivityAnim = "kick_24";
				}
				else if (this.StudentID == 49)
				{
					this.GetNewAnimation = true;
					this.ClubAnim = "f02_idle_20";
					this.ActivityAnim = "f02_kick_23";
				}
				else if (this.StudentID == 50)
				{
					this.ClubAnim = "f02_sit_05";
					this.ActivityAnim = "f02_kick_23";
				}
				this.ClubMemberID = this.StudentID - 45;
			}
			else if (this.Club == ClubType.Science)
			{
				if (!this.StudentManager.Eighties)
				{
					this.ChangingBooth = this.StudentManager.ChangingBooths[8];
					this.Attacher.ScienceClub = true;
					this.DressCode = true;
					if (this.StudentID == 61)
					{
						this.ClubAnim = "scienceMad_00";
					}
					else if (this.StudentID == 62)
					{
						this.ClubAnim = "scienceTablet_00";
					}
					else if (this.StudentID == 63)
					{
						this.ClubAnim = "scienceChemistry_00";
					}
					else if (this.StudentID == 64)
					{
						this.ClubAnim = "f02_scienceLeg_00";
					}
					else if (this.StudentID == 65)
					{
						this.ClubAnim = "f02_scienceConsole_00";
					}
				}
				else if (this.Male)
				{
					this.ClubAnim = "scienceChemistry_00";
				}
				else
				{
					this.ClubAnim = "f02_scienceChemistry_00";
				}
				this.ClubMemberID = this.StudentID - 60;
			}
			else if (this.Club == ClubType.Sports)
			{
				if (this.Male)
				{
					this.ChangingBooth = this.StudentManager.ChangingBooths[9];
					this.ClubAnim = "stretch_00";
				}
				else
				{
					this.ChangingBooth = this.StudentManager.ChangingBooths[10];
					this.ClubAnim = "f02_stretch_00";
				}
				this.DressCode = true;
				this.ClubMemberID = this.StudentID - 65;
			}
			else if (this.Club == ClubType.Gardening)
			{
				if (!this.StudentManager.Eighties)
				{
					if (this.StudentID == 71)
					{
						this.PatrolAnim = "f02_thinking_00";
						this.ClubAnim = "f02_thinking_00";
						this.CharacterAnimation[this.PatrolAnim].speed = 0.9f;
					}
					else
					{
						this.ClubAnim = "f02_waterPlant_00";
						this.WateringCan.SetActive(true);
					}
				}
				else
				{
					if (this.Male)
					{
						this.PatrolAnim = "thinking_00";
						this.ClubAnim = "thinking_00";
					}
					else
					{
						this.PatrolAnim = "f02_thinking_00";
						this.ClubAnim = "f02_thinking_00";
					}
					this.CharacterAnimation[this.PatrolAnim].speed = 0.9f;
				}
			}
			else if (this.Club == ClubType.Newspaper)
			{
				if (this.StudentID == 36)
				{
					this.ClubAnim = "thinking_00";
				}
				else if (this.Male)
				{
					this.PatrolAnim = "thinking_00";
					this.ClubAnim = "onComputer_00";
				}
				else
				{
					this.PatrolAnim = "f02_thinking_00";
					this.ClubAnim = "f02_onComputer_00";
				}
				this.OriginalClubAnim = this.ClubAnim;
			}
			if (this.OriginalClub != ClubType.Gaming)
			{
				this.Miyuki.gameObject.SetActive(false);
			}
			if (this.Cosmetic.Hairstyle == 20)
			{
				this.IdleAnim = "f02_tsunIdle_00";
			}
			this.GetDestinations();
			this.OriginalActions = new StudentActionType[this.Actions.Length];
			Array.Copy(this.Actions, this.OriginalActions, this.Actions.Length);
			if (this.AoT)
			{
				this.AttackOnTitan();
			}
			if (this.Slave)
			{
				this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
				this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
				this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
				this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
				this.IdleAnim = this.BrokenAnim;
				this.WalkAnim = this.BrokenWalkAnim;
				this.RightEmptyEye.SetActive(true);
				this.LeftEmptyEye.SetActive(true);
				this.SmartPhone.SetActive(false);
				this.Distracted = true;
				this.Indoors = true;
				this.Safe = false;
				this.Shy = false;
				this.ID = 0;
				while (this.ID < this.ScheduleBlocks.Length)
				{
					this.ScheduleBlocks[this.ID].time = 0f;
					this.ID++;
				}
				if (this.FragileSlave)
				{
					this.HuntTarget = this.StudentManager.Students[StudentGlobals.FragileTarget];
				}
				else
				{
					SchoolGlobals.KidnapVictim = 0;
				}
			}
			if (this.Spooky)
			{
				this.Spook();
			}
			this.Prompt.HideButton[0] = true;
			this.Prompt.HideButton[2] = true;
			this.ID = 0;
			while (this.ID < this.Ragdoll.AllRigidbodies.Length)
			{
				this.Ragdoll.AllRigidbodies[this.ID].isKinematic = true;
				this.Ragdoll.AllColliders[this.ID].enabled = false;
				this.ID++;
			}
			this.Ragdoll.AllColliders[10].enabled = true;
			if (this.StudentID == 1)
			{
				this.Yandere.Senpai = base.transform;
				this.Yandere.LookAt.target = this.Head;
				this.ID = 0;
				while (this.ID < this.Outlines.Length)
				{
					if (this.Outlines[this.ID] != null)
					{
						this.Outlines[this.ID].enabled = true;
						this.Outlines[this.ID].color = new Color(1f, 0f, 1f);
					}
					this.ID++;
				}
				this.Prompt.ButtonActive[0] = false;
				this.Prompt.ButtonActive[1] = false;
				this.Prompt.ButtonActive[2] = false;
				this.Prompt.ButtonActive[3] = false;
				if (this.StudentManager.MissionMode || GameGlobals.SenpaiMourning)
				{
					base.transform.position = Vector3.zero;
					base.gameObject.SetActive(false);
				}
			}
			else if (!StudentGlobals.GetStudentPhotographed(this.StudentID) && !this.Rival)
			{
				this.ID = 0;
				while (this.ID < this.Outlines.Length)
				{
					if (this.Outlines[this.ID] != null)
					{
						this.Outlines[this.ID].enabled = false;
						this.Outlines[this.ID].color = new Color(0f, 1f, 0f);
					}
					this.ID++;
				}
			}
			this.PickRandomAnim();
			this.PickRandomSleuthAnim();
			Renderer component = this.Armband.GetComponent<Renderer>();
			if (this.Club != ClubType.None && (this.StudentID == 21 || this.StudentID == 26 || this.StudentID == 31 || this.StudentID == 36 || this.StudentID == 41 || this.StudentID == 46 || this.StudentID == 51 || this.StudentID == 56 || this.StudentID == 61 || this.StudentID == 66 || this.StudentID == 71))
			{
				this.Armband.SetActive(true);
				this.ClubLeader = true;
				if (this.StudentManager.EmptyDemon)
				{
					this.IdleAnim = this.OriginalIdleAnim;
					this.WalkAnim = this.OriginalOriginalWalkAnim;
					this.OriginalPersona = PersonaType.Evil;
					this.Persona = PersonaType.Evil;
					this.ScaredAnim = this.EvilWitnessAnim;
				}
			}
			if (!this.Teacher)
			{
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.Destinations[this.Phase];
			}
			else
			{
				this.Indoors = true;
			}
			if (this.StudentID == 1 || this.StudentID == 4 || this.StudentID == 5 || this.StudentID == 11)
			{
				this.BookRenderer.material.mainTexture = this.RedBookTexture;
			}
			this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			if ((this.StudentManager.MissionMode && this.StudentID == MissionModeGlobals.MissionTarget) || this.Rival)
			{
				this.ID = 0;
				while (this.ID < this.Outlines.Length)
				{
					if (this.Outlines[this.ID] != null)
					{
						this.Outlines[this.ID].enabled = true;
						this.Outlines[this.ID].color = new Color(1f, 0f, 0f);
					}
					this.ID++;
				}
			}
			UnityEngine.Object.Destroy(this.MyRigidbody);
			this.Started = true;
			if (this.Club == ClubType.Council)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, 0f));
				this.Armband.SetActive(true);
				this.Indoors = true;
				this.Spawned = true;
				if (this.ShoeRemoval.Locker == null)
				{
					this.ShoeRemoval.Start();
				}
				this.ShoeRemoval.PutOnShoes();
				if (this.StudentID == 86)
				{
					this.Suffix = "Strict";
				}
				else if (this.StudentID == 87)
				{
					this.Suffix = "Casual";
				}
				else if (this.StudentID == 88)
				{
					this.Suffix = "Grace";
				}
				else if (this.StudentID == 89)
				{
					this.Suffix = "Edgy";
				}
				if (!this.StudentManager.Eighties)
				{
					this.IdleAnim = "f02_idleCouncil" + this.Suffix + "_00";
					this.WalkAnim = "f02_walkCouncil" + this.Suffix + "_00";
					this.ShoveAnim = "f02_pushCouncil" + this.Suffix + "_00";
					this.PatrolAnim = "f02_scanCouncil" + this.Suffix + "_00";
					this.RelaxAnim = "f02_relaxCouncil" + this.Suffix + "_00";
					this.SprayAnim = "f02_sprayCouncil" + this.Suffix + "_00";
					this.BreakUpAnim = "f02_stopCouncil" + this.Suffix + "_00";
					this.PickUpAnim = "f02_teacherPickUp_00";
				}
				else
				{
					this.BreakUpAnim = "delinquentTalk_03";
					this.GuardAnim = this.ReadyToFightAnim;
					this.RelaxAnim = "sit_00";
					if (this.StudentID == 89)
					{
						this.RelaxAnim = "crossarms_00";
					}
				}
				this.ScaredAnim = this.ReadyToFightAnim;
				this.ParanoidAnim = this.GuardAnim;
				this.CameraAnims[1] = this.IdleAnim;
				this.CameraAnims[2] = this.IdleAnim;
				this.CameraAnims[3] = this.IdleAnim;
				this.ClubMemberID = this.StudentID - 85;
				this.VisionDistance *= 2f;
			}
			if (!this.StudentManager.NoClubMeeting && this.Armband.activeInHierarchy && this.Clock.Weekday == 5)
			{
				if (this.StudentID < 86)
				{
					ScheduleBlock scheduleBlock33 = this.ScheduleBlocks[6];
					scheduleBlock33.destination = "Meeting";
					scheduleBlock33.action = "Meeting";
				}
				else
				{
					ScheduleBlock scheduleBlock34 = this.ScheduleBlocks[5];
					scheduleBlock34.destination = "Meeting";
					scheduleBlock34.action = "Meeting";
				}
				this.GetDestinations();
			}
			if (this.StudentID == 81 && StudentGlobals.GetStudentBroken(81))
			{
				this.Destinations[2] = this.StudentManager.BrokenSpot;
				this.Destinations[4] = this.StudentManager.BrokenSpot;
				this.Actions[2] = StudentActionType.Shamed;
				this.Actions[4] = StudentActionType.Shamed;
			}
		}
		this.UpdateAnimLayers();
		if (!this.Male)
		{
			if (this.StudentID == 40)
			{
				this.LongHair[0] = this.LongHair[2];
			}
			if (this.StudentID != 55 && this.StudentID != 40)
			{
				this.LongHair[0] = null;
				this.LongHair[1] = null;
				this.LongHair[2] = null;
			}
		}
		this.OriginalScheduleBlocks = new ScheduleBlock[this.ScheduleBlocks.Length];
		Array.Copy(this.ScheduleBlocks, this.OriginalScheduleBlocks, this.ScheduleBlocks.Length);
		this.CharacterAnimation.Sample();
	}

	// Token: 0x06001E11 RID: 7697 RVA: 0x001754F8 File Offset: 0x001736F8
	private float GetPerceptionPercent(float distance)
	{
		float num = Mathf.Clamp01(distance / this.VisionDistance);
		return 1f - num * num;
	}

	// Token: 0x170004AB RID: 1195
	// (get) Token: 0x06001E12 RID: 7698 RVA: 0x0017551C File Offset: 0x0017371C
	private SubtitleType LostPhoneSubtitleType
	{
		get
		{
			if (this.RivalPrefix == string.Empty)
			{
				return SubtitleType.LostPhone;
			}
			if (this.RivalPrefix == "Rival ")
			{
				return SubtitleType.RivalLostPhone;
			}
			throw new NotImplementedException("\"" + this.RivalPrefix + "\" case not implemented.");
		}
	}

	// Token: 0x170004AC RID: 1196
	// (get) Token: 0x06001E13 RID: 7699 RVA: 0x00175570 File Offset: 0x00173770
	private SubtitleType PickpocketSubtitleType
	{
		get
		{
			Debug.Log("This is where the game determines what pickpocket subtitle to use.");
			if (this.Male)
			{
				this.Subtitle.CustomText = "Hey! Are you trying to take my keys? Knock it off!";
				return SubtitleType.Custom;
			}
			if (this.RivalPrefix == string.Empty)
			{
				return SubtitleType.PickpocketReaction;
			}
			if (this.RivalPrefix == "Rival ")
			{
				return SubtitleType.RivalPickpocketReaction;
			}
			throw new NotImplementedException("\"" + this.RivalPrefix + "\" case not implemented.");
		}
	}

	// Token: 0x170004AD RID: 1197
	// (get) Token: 0x06001E14 RID: 7700 RVA: 0x001755EC File Offset: 0x001737EC
	private SubtitleType SplashSubtitleType
	{
		get
		{
			if (this.RivalPrefix == string.Empty)
			{
				if (!this.Male)
				{
					return SubtitleType.SplashReaction;
				}
				return SubtitleType.SplashReactionMale;
			}
			else
			{
				if (this.RivalPrefix == "Rival ")
				{
					return SubtitleType.RivalSplashReaction;
				}
				throw new NotImplementedException("\"" + this.RivalPrefix + "\" case not implemented.");
			}
		}
	}

	// Token: 0x170004AE RID: 1198
	// (get) Token: 0x06001E15 RID: 7701 RVA: 0x00175654 File Offset: 0x00173854
	public SubtitleType TaskLineResponseType
	{
		get
		{
			if (this.StudentManager.Eighties && this.StudentID != 79)
			{
				return SubtitleType.TaskGenericEightiesLine;
			}
			if (this.StudentID == 6)
			{
				return SubtitleType.Task6Line;
			}
			if (this.StudentID == 8)
			{
				return SubtitleType.Task8Line;
			}
			if (this.StudentID == 11)
			{
				return SubtitleType.Task11Line;
			}
			if (this.StudentID == 13)
			{
				return SubtitleType.Task13Line;
			}
			if (this.StudentID == 14)
			{
				return SubtitleType.Task14Line;
			}
			if (this.StudentID == 15)
			{
				return SubtitleType.Task15Line;
			}
			if (this.StudentID == 25)
			{
				return SubtitleType.Task25Line;
			}
			if (this.StudentID == 28)
			{
				return SubtitleType.Task28Line;
			}
			if (this.StudentID == 30)
			{
				return SubtitleType.Task30Line;
			}
			if (this.StudentID == 36)
			{
				return SubtitleType.Task36Line;
			}
			if (this.StudentID == 37)
			{
				return SubtitleType.Task37Line;
			}
			if (this.StudentID == 38)
			{
				return SubtitleType.Task38Line;
			}
			if (this.StudentID == 46)
			{
				return SubtitleType.Task46Line;
			}
			if (this.StudentID == 47)
			{
				return SubtitleType.Task47Line;
			}
			if (this.StudentID == 48)
			{
				return SubtitleType.Task48Line;
			}
			if (this.StudentID == 49)
			{
				return SubtitleType.Task49Line;
			}
			if (this.StudentID == 50)
			{
				return SubtitleType.Task50Line;
			}
			if (this.StudentID == 52)
			{
				return SubtitleType.Task52Line;
			}
			if (this.StudentID == 76)
			{
				return SubtitleType.Task76Line;
			}
			if (this.StudentID == 77)
			{
				return SubtitleType.Task77Line;
			}
			if (this.StudentID == 78)
			{
				return SubtitleType.Task78Line;
			}
			if (this.StudentID == 79)
			{
				return SubtitleType.Task79Line;
			}
			if (this.StudentID == 80)
			{
				return SubtitleType.Task80Line;
			}
			if (this.StudentID == 81)
			{
				return SubtitleType.Task81Line;
			}
			return SubtitleType.TaskGenericLine;
		}
	}

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06001E16 RID: 7702 RVA: 0x00175804 File Offset: 0x00173A04
	public SubtitleType ClubInfoResponseType
	{
		get
		{
			if (this.StudentManager.EmptyDemon)
			{
				return SubtitleType.ClubPlaceholderInfo;
			}
			if (this.Club == ClubType.Cooking)
			{
				return SubtitleType.ClubCookingInfo;
			}
			if (this.Club == ClubType.Drama)
			{
				return SubtitleType.ClubDramaInfo;
			}
			if (this.Club == ClubType.Occult)
			{
				return SubtitleType.ClubOccultInfo;
			}
			if (this.Club == ClubType.Art)
			{
				return SubtitleType.ClubArtInfo;
			}
			if (this.Club == ClubType.LightMusic)
			{
				return SubtitleType.ClubLightMusicInfo;
			}
			if (this.Club == ClubType.MartialArts)
			{
				return SubtitleType.ClubMartialArtsInfo;
			}
			if (this.Club == ClubType.Photography)
			{
				if (this.Sleuthing)
				{
					return SubtitleType.ClubPhotoInfoDark;
				}
				return SubtitleType.ClubPhotoInfoLight;
			}
			else
			{
				if (this.Club == ClubType.Science)
				{
					return SubtitleType.ClubScienceInfo;
				}
				if (this.Club == ClubType.Sports)
				{
					return SubtitleType.ClubSportsInfo;
				}
				if (this.Club == ClubType.Gardening)
				{
					return SubtitleType.ClubGardenInfo;
				}
				if (this.Club == ClubType.Gaming)
				{
					return SubtitleType.ClubGamingInfo;
				}
				if (this.Club == ClubType.Delinquent)
				{
					return SubtitleType.ClubDelinquentInfo;
				}
				if (this.Club == ClubType.Newspaper)
				{
					return SubtitleType.ClubNewspaperInfo;
				}
				return SubtitleType.ClubPlaceholderInfo;
			}
		}
	}

	// Token: 0x06001E17 RID: 7703 RVA: 0x001758D0 File Offset: 0x00173AD0
	private bool PointIsInFOV(Vector3 point)
	{
		Vector3 position = this.Eyes.transform.position;
		Vector3 to = point - position;
		float num = 90f;
		return Vector3.Angle(this.Head.transform.forward, to) <= num;
	}

	// Token: 0x06001E18 RID: 7704 RVA: 0x00175918 File Offset: 0x00173B18
	public bool SeenByYandere()
	{
		Debug.Log("A ''SeenByYandere'' check is occuring.");
		Debug.DrawLine(this.Yandere.transform.position + new Vector3(0f, 1f, 0f), base.transform.position + new Vector3(0f, 1f, 0f), Color.red);
		RaycastHit raycastHit;
		if (Physics.Linecast(this.Yandere.transform.position + new Vector3(0f, 1f, 0f), base.transform.position + new Vector3(0f, 1f, 0f), out raycastHit, this.YandereCheckMask))
		{
			Debug.Log("Yandere-chan's raycast hit: " + raycastHit.collider.gameObject.name);
			if (raycastHit.collider.gameObject == this.Head.gameObject || raycastHit.collider.gameObject == base.gameObject)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001E19 RID: 7705 RVA: 0x00175A44 File Offset: 0x00173C44
	public bool CanSeeObject(GameObject obj, Vector3 targetPoint, int[] layers, int mask)
	{
		Vector3 position = this.Eyes.transform.position;
		Vector3 vector = targetPoint - position;
		if (this.PointIsInFOV(targetPoint))
		{
			float num = this.VisionDistance * this.VisionDistance;
			if (vector.sqrMagnitude <= num)
			{
				Debug.DrawLine(position, targetPoint, Color.green);
				RaycastHit raycastHit;
				if (Physics.Linecast(position, targetPoint, out raycastHit, mask))
				{
					foreach (int num2 in layers)
					{
						if (raycastHit.collider.gameObject.layer == num2)
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06001E1A RID: 7706 RVA: 0x00175AE0 File Offset: 0x00173CE0
	public bool CanSeeObject(GameObject obj, Vector3 targetPoint)
	{
		if (!this.Blind)
		{
			Debug.DrawLine(this.Eyes.position, targetPoint, Color.green);
			Vector3 position = this.Eyes.transform.position;
			Vector3 vector = targetPoint - position;
			float num = this.VisionDistance * this.VisionDistance;
			bool flag = this.PointIsInFOV(targetPoint);
			bool flag2 = vector.sqrMagnitude <= num;
			RaycastHit raycastHit;
			if (flag && flag2 && Physics.Linecast(position, targetPoint, out raycastHit, this.Mask) && raycastHit.collider.gameObject == obj)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001E1B RID: 7707 RVA: 0x00175B7B File Offset: 0x00173D7B
	public bool CanSeeObject(GameObject obj)
	{
		return this.CanSeeObject(obj, obj.transform.position);
	}

	// Token: 0x06001E1C RID: 7708 RVA: 0x00175B90 File Offset: 0x00173D90
	private void Update()
	{
		if (!this.Stop)
		{
			this.DistanceToPlayer = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
			this.UpdateRoutine();
			this.UpdateDetectionMarker();
			if (this.Dying)
			{
				this.UpdateDying();
				if (this.Burning)
				{
					this.UpdateBurning();
				}
			}
			else
			{
				if (this.DistanceToPlayer <= 2f)
				{
					this.UpdateTalkInput();
				}
				this.UpdateVision();
				if (this.Pushed)
				{
					this.UpdatePushed();
				}
				else if (this.Drowned)
				{
					this.UpdateDrowned();
				}
				else if (this.WitnessedMurder)
				{
					this.UpdateWitnessedMurder();
				}
				else if (this.Alarmed)
				{
					this.UpdateAlarmed();
				}
				else if (this.TurnOffRadio)
				{
					this.UpdateTurningOffRadio();
				}
				else if (this.Confessing)
				{
					this.UpdateConfessing();
				}
				else if (this.Vomiting)
				{
					this.UpdateVomiting();
				}
				else if (this.Splashed)
				{
					this.UpdateSplashed();
				}
			}
			this.UpdateMisc();
			return;
		}
		this.UpdateStop();
	}

	// Token: 0x06001E1D RID: 7709 RVA: 0x00175CA4 File Offset: 0x00173EA4
	private void UpdateStop()
	{
		if (this.StudentManager.Pose)
		{
			this.DistanceToPlayer = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Pose();
			}
		}
		else if (!this.ClubActivity)
		{
			if (!this.Yandere.Talking)
			{
				if (this.Yandere.Sprayed)
				{
					this.CharacterAnimation.CrossFade(this.ScaredAnim);
				}
				if (this.Yandere.Noticed || this.StudentManager.YandereDying)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 1f)
					{
						this.MyController.Move(base.transform.forward * (Time.deltaTime * -1f));
					}
				}
			}
		}
		else if (this.Police.Darkness.color.a < 1f)
		{
			if (this.Club == ClubType.Cooking)
			{
				this.CharacterAnimation[this.SocialSitAnim].layer = 99;
				this.CharacterAnimation.Play(this.SocialSitAnim);
				this.CharacterAnimation[this.SocialSitAnim].weight = 1f;
				this.SmartPhone.SetActive(false);
				this.SpeechLines.Play();
				this.CharacterAnimation.CrossFade(this.RandomAnim);
				if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
				{
					this.PickRandomAnim();
				}
			}
			else if (this.Club == ClubType.MartialArts)
			{
				this.CharacterAnimation.Play(this.ActivityAnim);
				AudioSource component = base.GetComponent<AudioSource>();
				if (!this.Male)
				{
					if (this.CharacterAnimation["f02_kick_23"].time > 1f)
					{
						if (!this.PlayingAudio)
						{
							component.clip = this.FemaleAttacks[UnityEngine.Random.Range(0, this.FemaleAttacks.Length)];
							component.Play();
							this.PlayingAudio = true;
						}
						if (this.CharacterAnimation["f02_kick_23"].time >= this.CharacterAnimation["f02_kick_23"].length)
						{
							this.CharacterAnimation["f02_kick_23"].time = 0f;
							this.PlayingAudio = false;
						}
					}
				}
				else if (this.CharacterAnimation["kick_24"].time > 1f)
				{
					if (!this.PlayingAudio)
					{
						component.clip = this.MaleAttacks[UnityEngine.Random.Range(0, this.MaleAttacks.Length)];
						component.Play();
						this.PlayingAudio = true;
					}
					if (this.CharacterAnimation["kick_24"].time >= this.CharacterAnimation["kick_24"].length)
					{
						this.CharacterAnimation["kick_24"].time = 0f;
						this.PlayingAudio = false;
					}
				}
			}
			else if (this.Club == ClubType.Drama)
			{
				this.Stop = false;
			}
			else if (this.Club == ClubType.Photography)
			{
				this.CharacterAnimation.CrossFade(this.RandomSleuthAnim);
				if (this.CharacterAnimation[this.RandomSleuthAnim].time >= this.CharacterAnimation[this.RandomSleuthAnim].length)
				{
					this.PickRandomSleuthAnim();
				}
			}
			else if (this.Club == ClubType.Art)
			{
				this.CharacterAnimation.Play(this.ActivityAnim);
				this.Paintbrush.SetActive(true);
				this.Palette.SetActive(true);
			}
			else if (this.Club == ClubType.Science)
			{
				this.CharacterAnimation.Play(this.ClubAnim);
				if (!this.StudentManager.Eighties)
				{
					if (this.StudentID == 62)
					{
						this.ScienceProps[0].SetActive(true);
					}
					else if (this.StudentID == 63)
					{
						this.ScienceProps[1].SetActive(true);
						this.ScienceProps[2].SetActive(true);
					}
					else if (this.StudentID == 64)
					{
						this.ScienceProps[0].SetActive(true);
					}
				}
				else
				{
					if (!this.Male && !this.ScienceProps[1].activeInHierarchy)
					{
						Debug.Log("Supposedly straightening skirt.");
						this.CharacterAnimation.Play("f02_straightenSkirt_00");
					}
					this.ScienceProps[1].SetActive(true);
					this.ScienceProps[2].SetActive(true);
				}
			}
			else if (this.Club == ClubType.Sports)
			{
				this.Stop = false;
			}
			else if (this.Club == ClubType.Gardening)
			{
				this.CharacterAnimation.Play(this.ClubAnim);
				this.Stop = false;
			}
			else if (this.Club == ClubType.Gaming)
			{
				this.CharacterAnimation.CrossFade(this.ClubAnim);
			}
		}
		this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime);
		this.UpdateDetectionMarker();
	}

	// Token: 0x06001E1E RID: 7710 RVA: 0x00176290 File Offset: 0x00174490
	private void UpdateRoutine()
	{
		if (this.Routine)
		{
			this.IgnoreFoodTimer -= Time.deltaTime;
			if (this.CurrentDestination != null)
			{
				this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
			}
			if (this.StalkerFleeing)
			{
				if (this.Actions[this.Phase] == StudentActionType.Stalk && this.DistanceToPlayer > 10f)
				{
					this.Pathfinding.target = this.Yandere.transform;
					this.CurrentDestination = this.Yandere.transform;
					this.StalkerFleeing = false;
					this.Pathfinding.speed = this.WalkSpeed;
				}
			}
			else if (this.Actions[this.Phase] == StudentActionType.Stalk)
			{
				this.TargetDistance = 10f;
				if (this.DistanceToPlayer > 20f)
				{
					this.Pathfinding.speed = 4f;
				}
				else if (this.DistanceToPlayer < 10f)
				{
					this.Pathfinding.speed = this.WalkSpeed;
				}
			}
			if (!this.Indoors)
			{
				if (this.Hurry && !this.Tripped && this.StudentID == 7 && base.transform.position.z > -50.5f && base.transform.position.x < 6f)
				{
					this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.CharacterAnimation.CrossFade("trip_00");
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.Tripping = true;
					this.Routine = false;
					if (this.Clock.Day == 2 && !this.BountyCollider.activeInHierarchy)
					{
						this.BountyCollider.transform.localPosition = new Vector3(0f, 0f, 0.25f);
						this.BountyCollider.GetComponent<BoxCollider>().center = new Vector3(0f, 0.12f, 0f);
						this.BountyCollider.GetComponent<BoxCollider>().size = new Vector3(0.78f, 0.24f, 1.9f);
						this.BountyCollider.SetActive(true);
					}
				}
				if (this.Paired)
				{
					if (base.transform.position.z < -50f)
					{
						if (base.transform.localEulerAngles != Vector3.zero)
						{
							base.transform.localEulerAngles = Vector3.zero;
						}
						this.MyController.Move(base.transform.forward * Time.deltaTime);
						if (this.StudentID == 81 && !this.StudentManager.Eighties)
						{
							this.MusumeTimer += Time.deltaTime;
							if (this.MusumeTimer > 5f)
							{
								this.MusumeTimer = 0f;
								this.MusumeRight = !this.MusumeRight;
								this.WalkAnim = (this.MusumeRight ? "f02_walkTalk_00" : "f02_walkTalk_01");
							}
						}
					}
					else
					{
						if (this.Persona == PersonaType.PhoneAddict)
						{
							this.SpeechLines.Stop();
							this.SmartPhone.SetActive(true);
						}
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.StopPairing();
					}
				}
				if (this.Phase == 0)
				{
					if (this.DistanceToDestination < 1f)
					{
						this.CurrentDestination = this.MyLocker;
						this.Pathfinding.target = this.MyLocker;
						this.Phase++;
					}
				}
				else if (this.DistanceToDestination < 0.5f && !this.ShoeRemoval.enabled)
				{
					if (this.Shy)
					{
						this.CharacterAnimation[this.ShyAnim].weight = 0.5f;
					}
					this.SmartPhone.SetActive(false);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.ShoeRemoval.StartChangingShoes();
					this.ShoeRemoval.enabled = true;
					this.ChangingShoes = true;
					this.CanTalk = false;
					this.Routine = false;
				}
			}
			else if (this.Phase < this.ScheduleBlocks.Length - 1 && this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time && !this.InEvent && !this.Meeting && this.ClubActivityPhase < 16 && !this.Ragdoll.Zs.activeInHierarchy)
			{
				this.SimpleForgetAboutBloodPool();
				this.MyRenderer.updateWhenOffscreen = false;
				this.SprintAnim = this.OriginalSprintAnim;
				if (this.Headache)
				{
					this.SprintAnim = this.OriginalSprintAnim;
					this.WalkAnim = this.OriginalWalkAnim;
				}
				if (this.Vomiting)
				{
					this.StopVomitting();
				}
				this.Pushable = false;
				this.Headache = false;
				this.Sedated = false;
				this.Hurry = false;
				if (this.Schoolwear == 1)
				{
					this.SunbathePhase = 0;
				}
				this.Phase++;
				this.BountyCollider.SetActive(false);
				if (this.Drownable)
				{
					this.Drownable = false;
					this.StudentManager.UpdateMe(this.StudentID);
				}
				if (this.Schoolwear > 1 && this.Destinations[this.Phase] == this.MyLocker)
				{
					this.Phase++;
					if (this.Rival && DateGlobals.Weekday == DayOfWeek.Friday)
					{
						this.Phase--;
					}
				}
				if (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes && this.Schoolwear == 2)
				{
					this.MustChangeClothing = true;
					this.ChangeClothingPhase = 0;
				}
				if (this.Actions[this.Phase] == StudentActionType.Graffiti && !this.StudentManager.Bully)
				{
					ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
					scheduleBlock.destination = "Patrol";
					scheduleBlock.action = "Patrol";
					this.GetDestinations();
				}
				if (!this.StudentManager.ReactedToGameLeader && this.Actions[this.Phase] == StudentActionType.Bully && !this.StudentManager.Bully)
				{
					ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[4];
					scheduleBlock2.destination = "Sunbathe";
					scheduleBlock2.action = "Sunbathe";
					this.GetDestinations();
				}
				if (this.Sedated)
				{
					this.SprintAnim = this.OriginalSprintAnim;
					this.Sedated = false;
				}
				this.CurrentAction = this.Actions[this.Phase];
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.Destinations[this.Phase];
				if (this.Rival && DateGlobals.Weekday == DayOfWeek.Friday && !this.InCouple)
				{
					if (this.Rival && DateGlobals.Weekday == DayOfWeek.Friday)
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
					}
					if ((this.StudentManager.LoveManager.ConfessToSuitor || GameGlobals.RivalEliminationID != 4) && this.Actions[this.Phase] == StudentActionType.ChangeShoes)
					{
						Debug.Log("The rival's current action is ''ChangingShoes''.");
						if (this.StudentManager.LoveManager.ConfessToSuitor)
						{
							this.CurrentDestination = this.StudentManager.SuitorLocker;
							this.Pathfinding.target = this.StudentManager.SuitorLocker;
						}
						else
						{
							this.CurrentDestination = this.StudentManager.SenpaiLocker;
							this.Pathfinding.target = this.StudentManager.SenpaiLocker;
						}
						this.Yandere.PauseScreen.Hint.Show = true;
						this.Yandere.PauseScreen.Hint.QuickID = 10;
						this.Confessing = true;
						this.Distracted = true;
						this.Routine = false;
						this.CanTalk = false;
					}
				}
				if (this.CurrentDestination != null)
				{
					this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
				}
				if (this.Bento != null && this.Bento.activeInHierarchy)
				{
					this.Bento.SetActive(false);
					this.Chopsticks[0].SetActive(false);
					this.Chopsticks[1].SetActive(false);
				}
				if (this.Male)
				{
					this.Cosmetic.MyRenderer.materials[this.Cosmetic.FaceID].SetFloat("_BlendAmount", 0f);
					this.PinkSeifuku.SetActive(false);
				}
				else
				{
					this.HorudaCollider.gameObject.SetActive(false);
				}
				this.BountyCollider.SetActive(false);
				if (this.StudentID == 81)
				{
					this.Cigarette.SetActive(false);
					this.Lighter.SetActive(false);
				}
				if (!this.Paired)
				{
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
				}
				if (this.Persona != PersonaType.PhoneAddict && !this.Sleuthing)
				{
					this.SmartPhone.SetActive(false);
				}
				else if (!this.Slave && !this.Phoneless)
				{
					this.IdleAnim = this.PhoneAnims[0];
					this.SmartPhone.SetActive(true);
				}
				this.Paintbrush.SetActive(false);
				this.Sketchbook.SetActive(false);
				this.Palette.SetActive(false);
				this.Pencil.SetActive(false);
				this.OccultBook.SetActive(false);
				this.Scrubber.SetActive(false);
				this.Eraser.SetActive(false);
				this.Pen.SetActive(false);
				foreach (GameObject gameObject in this.ScienceProps)
				{
					if (gameObject != null)
					{
						gameObject.SetActive(false);
					}
				}
				foreach (GameObject gameObject2 in this.Fingerfood)
				{
					if (gameObject2 != null)
					{
						gameObject2.SetActive(false);
					}
				}
				this.SpeechLines.Stop();
				this.GoAway = false;
				this.ReadPhase = 0;
				if (!this.ReturningFromSave)
				{
					this.PatrolID = 0;
				}
				if (this.Phase == this.PhaseFromSave)
				{
					if (this.StudentManager.Patrols.List[this.StudentID] != null && this.Destinations[this.Phase] == this.StudentManager.Patrols.List[this.StudentID].GetChild(0))
					{
						this.Destinations[this.Phase] = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
						this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
						this.Pathfinding.target = this.CurrentDestination;
					}
					this.ReturningFromSave = false;
				}
				if (this.Actions[this.Phase] == StudentActionType.Clean)
				{
					if (this.StudentID == 11)
					{
						this.FollowTargetDestination.localPosition = new Vector3(0f, 0f, -1f);
					}
					this.EquipCleaningItems();
				}
				else
				{
					if (this.StudentID == 11)
					{
						this.FollowTargetDestination.localPosition = new Vector3(0f, 0f, 0f);
					}
					if (!this.Slave && !this.Phoneless)
					{
						if (this.Persona == PersonaType.PhoneAddict)
						{
							this.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
							this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
							this.WalkAnim = this.PhoneAnims[1];
						}
						else if (this.Sleuthing)
						{
							this.WalkAnim = this.SleuthWalkAnim;
						}
					}
				}
				if (this.Actions[this.Phase] == StudentActionType.Sleuth && this.StudentManager.SleuthPhase == 3)
				{
					this.GetSleuthTarget();
				}
				if (this.Actions[this.Phase] == StudentActionType.Stalk)
				{
					this.TargetDistance = 10f;
				}
				else if (this.Actions[this.Phase] == StudentActionType.Follow)
				{
					this.TargetDistance = 0.5f;
					if (this.FollowTarget != null && !this.FollowTarget.Alive && !this.WitnessedCorpse)
					{
						this.FollowTarget.FollowTargetDestination.localPosition = new Vector3(0f, 0f, 0f);
						this.TargetDistance = 1f;
					}
				}
				else if (this.Actions[this.Phase] != StudentActionType.SitAndEatBento)
				{
					this.TargetDistance = 0.5f;
				}
				if (this.Club == ClubType.Gardening && this.StudentID != 71 && this.Actions[this.Phase] == StudentActionType.ClubAction)
				{
					if (!this.StudentManager.Eighties)
					{
						if (this.WateringCan.transform.parent != this.Hips)
						{
							this.WateringCan.transform.parent = this.Hips;
							this.WateringCan.transform.localPosition = new Vector3(0f, 0.0135f, -0.184f);
							this.WateringCan.transform.localEulerAngles = new Vector3(0f, 90f, 30f);
						}
						if (this.Clock.Period == 6 && this.StudentManager.Patrols.List[this.StudentID] != this.StudentManager.GardeningPatrols[this.StudentID - 71])
						{
							this.StudentManager.Patrols.List[this.StudentID] = this.StudentManager.GardeningPatrols[this.StudentID - 71];
							this.ClubAnim = "f02_waterPlantLow_00";
							this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
							this.Pathfinding.target = this.CurrentDestination;
						}
					}
					else if (this.Clock.Period == 6 && this.StudentManager.Patrols.List[this.StudentID] != this.StudentManager.GardeningPatrols[this.StudentID - 71])
					{
						this.StudentManager.Patrols.List[this.StudentID] = this.StudentManager.GardeningPatrols[this.StudentID - 71];
						this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
						this.Pathfinding.target = this.CurrentDestination;
					}
				}
				if (this.Club == ClubType.LightMusic)
				{
					if (this.StudentID == 51)
					{
						if (this.InstrumentBag[this.ClubMemberID].transform.parent == null)
						{
							this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
							this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
							this.Instruments[this.ClubMemberID].transform.parent = null;
							if (!this.StudentManager.Eighties)
							{
								this.Instruments[this.ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
								this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
							}
							else
							{
								this.Instruments[this.ClubMemberID].transform.position = new Vector3(2.105f, 4.5f, 25.5f);
								this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
							}
						}
						else
						{
							this.Instruments[this.ClubMemberID].SetActive(false);
						}
					}
					else
					{
						this.Instruments[this.ClubMemberID].SetActive(false);
					}
					this.Drumsticks[0].SetActive(false);
					this.Drumsticks[1].SetActive(false);
					this.AirGuitar.Stop();
				}
				if (!this.StudentManager.Eighties && this.Phase == 8 && this.StudentID == 36)
				{
					this.StudentManager.Clubs.List[this.StudentID].position = this.StudentManager.Clubs.List[71].position;
					this.StudentManager.Clubs.List[this.StudentID].rotation = this.StudentManager.Clubs.List[71].rotation;
					this.ClubAnim = this.GameAnim;
				}
				if (this.MyPlate != null && this.MyPlate.parent == this.RightHand)
				{
					this.CurrentDestination = this.StudentManager.Clubs.List[this.StudentID];
					this.Pathfinding.target = this.StudentManager.Clubs.List[this.StudentID];
				}
				if (this.Persona == PersonaType.Sleuth)
				{
					if (this.Male)
					{
						this.SmartPhone.transform.localPosition = new Vector3(0.06f, -0.02f, -0.02f);
					}
					else
					{
						this.SmartPhone.transform.localPosition = new Vector3(0.033333f, -0.015f, -0.015f);
					}
					if (!this.StudentManager.Eighties)
					{
						this.SmartPhone.transform.localEulerAngles = new Vector3(12.5f, 120f, 180f);
					}
					else
					{
						this.SmartPhone.transform.localEulerAngles = new Vector3(22.5f, 22.5f, 150f);
					}
				}
				if (this.Character.transform.localPosition.y == -0.25f)
				{
					Debug.Log("Swimming club special case was reached.");
					this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.ID].GetChild(this.ClubActivityPhase - 2);
					this.CurrentDestination = this.StudentManager.Clubs.List[this.ID].GetChild(this.ClubActivityPhase - 2);
					this.Pathfinding.target = this.StudentManager.Clubs.List[this.ID].GetChild(this.ClubActivityPhase - 2);
				}
				if (this.Actions[this.Phase] == StudentActionType.Sunbathe && this.SunbathePhase > 1)
				{
					this.CurrentDestination = this.StudentManager.SunbatheSpots[this.StudentID];
					this.Pathfinding.target = this.StudentManager.SunbatheSpots[this.StudentID];
				}
				if (this.StudentID == 10 && this.FollowTarget != null && !this.FollowTarget.Alive && this.StudentManager.LastKnownOsana.position != Vector3.zero)
				{
					this.Pathfinding.target = this.StudentManager.LastKnownOsana;
					this.CurrentDestination = this.StudentManager.LastKnownOsana;
				}
				if (this.Phoneless)
				{
					this.SmartPhone.SetActive(false);
				}
				if (this.Rival)
				{
					if (this.CurrentAction == StudentActionType.Clean)
					{
						this.StudentManager.RivalBookBag.gameObject.SetActive(false);
						this.StudentManager.RivalBookBag.Prompt.Hide();
						this.StudentManager.RivalBookBag.Prompt.enabled = false;
						if (this.StudentManager.Eighties)
						{
							this.BookBag.SetActive(true);
						}
					}
					else if (this.Clock.Period == 4 && this.CurrentAction == StudentActionType.Read && !this.StudentManager.RivalBookBag.BorrowedBook)
					{
						ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[this.Phase];
						scheduleBlock3.destination = "Search Patrol";
						scheduleBlock3.action = "Search Patrol";
						this.GetDestinations();
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
					}
				}
				if (!this.Teacher && this.Club != ClubType.Delinquent && this.Club != ClubType.Sports)
				{
					if (this.Clock.Period == 2 || this.Clock.Period == 4)
					{
						if (this.ClubActivityPhase < 16)
						{
							this.Pathfinding.speed = 4f;
						}
					}
					else
					{
						this.Pathfinding.speed = this.WalkSpeed;
					}
					if (!this.StudentManager.Eighties)
					{
						if (this.StudentManager.ConvoManager.Week != 0 && (this.StudentID == 25 || this.StudentID == 30 || this.StudentID == 24 || this.StudentID == 27))
						{
							this.Hurry = true;
							this.Pathfinding.speed = 4f;
						}
					}
					else if (this.Rival && this.Schoolwear != 1)
					{
						this.Hurry = true;
						this.Pathfinding.speed = 4f;
					}
				}
				if (this.Infatuated && this.Actions[this.Phase] == StudentActionType.Socializing)
				{
					if (base.transform.position.y > this.CurrentDestination.position.y + 1f || base.transform.position.y < this.CurrentDestination.position.y - 1f)
					{
						this.TargetDistance = 2f;
					}
					else
					{
						Debug.Log("This is the exact moment an infatuated character is deciding their TargetDistance.");
						if (this.StudentManager.Students[this.StudentManager.RivalID] != null && this.StudentManager.Students[this.StudentManager.RivalID].Meeting)
						{
							Debug.Log("Rival is meeting someone, so TargetDistance is far away.");
							this.TargetDistance = 10f;
						}
						else
						{
							Debug.Log("Rival is NOT meeting someone, so TargetDistance is nearby.");
							this.TargetDistance = 5f;
						}
					}
				}
				this.CharacterAnimation[this.SitAnim].weight = 0f;
				this.CharacterAnimation[this.SocialSitAnim].weight = 0f;
			}
			if (this.MeetTime > 0f && !this.InEvent && this.Clock.HourTime > this.MeetTime)
			{
				Debug.Log(this.Name + " acknowledges that it is time to go to a MeetSpot to have a Meeting.");
				if (this.Follower != null)
				{
					ScheduleBlock scheduleBlock4 = this.Follower.ScheduleBlocks[this.Follower.Phase];
					scheduleBlock4.destination = "Follow";
					scheduleBlock4.action = "Follow";
					this.Follower.Actions[this.Follower.Phase] = StudentActionType.Follow;
					this.CurrentAction = StudentActionType.Follow;
					this.Follower.GetDestinations();
					this.Follower.CurrentDestination = this.Follower.Destinations[this.Follower.Phase];
					this.Follower.Pathfinding.target = this.Follower.Destinations[this.Follower.Phase];
				}
				this.CurrentDestination = this.MeetSpot;
				this.Pathfinding.target = this.MeetSpot;
				this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Pathfinding.speed = 4f;
				this.SpeechLines.Stop();
				this.EmptyHands();
				this.Meeting = true;
				this.MeetTime = 0f;
				if (this.Rival)
				{
					this.StudentManager.UpdateInfatuatedTargetDistances();
				}
			}
			if (this.DistanceToDestination > this.TargetDistance)
			{
				if (this.Actions[this.Phase] == StudentActionType.Sleuth)
				{
					if (!this.SmartPhone.activeInHierarchy)
					{
						this.SmartPhone.SetActive(true);
						this.SpeechLines.Stop();
					}
					if (this.CurrentDestination == null)
					{
						this.GetSleuthTarget();
					}
					else
					{
						this.LockerRoomCheckTimer += Time.deltaTime;
						if (this.LockerRoomCheckTimer > 5f)
						{
							this.LockerRoomCheckTimer = 0f;
							if (this.StudentManager.LockerRoomArea.bounds.Contains(this.CurrentDestination.position) || this.StudentManager.MaleLockerRoomArea.bounds.Contains(this.CurrentDestination.position))
							{
								this.GetSleuthTarget();
							}
						}
					}
				}
				else if (this.Actions[this.Phase] == StudentActionType.Stalk && this.StudentManager.LockerRoomArea.bounds.Contains(this.Yandere.transform.position))
				{
					if (Vector3.Distance(base.transform.position, this.StudentManager.FleeSpots[0].position) > 10f)
					{
						this.Pathfinding.target = this.StudentManager.FleeSpots[0];
						this.CurrentDestination = this.StudentManager.FleeSpots[0];
					}
					else
					{
						this.Pathfinding.target = this.StudentManager.FleeSpots[1];
						this.CurrentDestination = this.StudentManager.FleeSpots[1];
					}
					this.Pathfinding.speed = 4f;
					this.StalkerFleeing = true;
				}
				if (this.StudentID == 10)
				{
					if (this.Actions[this.Phase] == StudentActionType.Follow)
					{
						this.Obstacle.enabled = false;
						if (this.FollowTarget != null)
						{
							if (this.FollowTarget.Wet && this.FollowTarget.DistanceToDestination < 5f)
							{
								this.TargetDistance = 4f;
							}
							else if (this.FollowTarget.CurrentAction == StudentActionType.SearchPatrol)
							{
								this.TargetDistance = 1f;
							}
							else
							{
								this.TargetDistance = 0.5f;
								if (this.FollowTarget != null && !this.FollowTarget.Alive && !this.WitnessedCorpse)
								{
									this.TargetDistance = 1f;
								}
							}
						}
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						if (this.DistanceToDestination > 2f)
						{
							this.Pathfinding.speed = 5f;
							this.SpeechLines.Stop();
						}
						else
						{
							this.Pathfinding.speed = this.WalkSpeed;
							this.SpeechLines.Stop();
						}
					}
					else if (this.Actions[this.Phase] == StudentActionType.Sketch && this.FollowTarget.Attacked)
					{
						this.AwareOfMurder = true;
						this.Alarm = 200f;
					}
				}
				if (this.CuriosityPhase == 1 && this.Actions[this.Phase] == StudentActionType.Relax && this.StudentManager.Students[this.Crush].Private)
				{
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.CurrentDestination = this.Destinations[this.Phase];
					this.TargetDistance = 0.5f;
					this.CuriosityTimer = 0f;
					this.CuriosityPhase--;
				}
				if (this.Actions[this.Phase] != StudentActionType.Follow || (this.Actions[this.Phase] == StudentActionType.Follow && this.DistanceToDestination > this.TargetDistance + 0.1f))
				{
					if (((this.Clock.Period == 1 && this.Clock.HourTime > 8.483334f) || (this.Clock.Period == 3 && this.Clock.HourTime > 13.483334f)) && !this.Teacher)
					{
						this.Pathfinding.speed = 4f;
					}
					if (!this.InEvent && !this.Meeting && !this.GoAway)
					{
						if (this.DressCode)
						{
							if (this.Actions[this.Phase] == StudentActionType.ClubAction)
							{
								if (!this.ClubAttire)
								{
									if (!this.ChangingBooth.Occupied)
									{
										this.CurrentDestination = this.ChangingBooth.transform;
										this.Pathfinding.target = this.ChangingBooth.transform;
									}
									else
									{
										this.CurrentDestination = this.ChangingBooth.WaitSpots[this.ClubMemberID];
										this.Pathfinding.target = this.ChangingBooth.WaitSpots[this.ClubMemberID];
									}
								}
								else if (this.Indoors && !this.GoAway)
								{
									this.CurrentDestination = this.Destinations[this.Phase];
									this.Pathfinding.target = this.Destinations[this.Phase];
									this.DistanceToDestination = 100f;
								}
							}
							else if (this.ClubAttire)
							{
								this.TargetDistance = 1f;
								if (!this.ChangingBooth.Occupied)
								{
									this.CurrentDestination = this.ChangingBooth.transform;
									this.Pathfinding.target = this.ChangingBooth.transform;
								}
								else
								{
									this.CurrentDestination = this.ChangingBooth.WaitSpots[this.ClubMemberID];
									this.Pathfinding.target = this.ChangingBooth.WaitSpots[this.ClubMemberID];
								}
							}
							else if (this.Indoors && this.Actions[this.Phase] != StudentActionType.Clean && this.Actions[this.Phase] != StudentActionType.Sketch && this.Actions[this.Phase] != StudentActionType.Relax)
							{
								this.CurrentDestination = this.Destinations[this.Phase];
								this.Pathfinding.target = this.Destinations[this.Phase];
							}
						}
						else if (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes && this.Schoolwear > 1 && !this.SchoolwearUnavailable)
						{
							this.CurrentDestination = this.StudentManager.StrippingPositions[this.GirlID];
							this.Pathfinding.target = this.StudentManager.StrippingPositions[this.GirlID];
						}
					}
					if (!this.Pathfinding.canMove)
					{
						if (!this.Spawned)
						{
							base.transform.position = this.StudentManager.SpawnPositions[this.StudentID].position;
							this.Spawned = true;
							if (this.StudentID == 10 && this.StudentManager.Students[11] == null && !this.StudentManager.Eighties)
							{
								Debug.Log("Raibaru runs this code.");
								base.transform.position = new Vector3(-4f, 0f, -96f);
								Physics.SyncTransforms();
							}
						}
						if (!this.Paired && !this.Alarmed)
						{
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
							this.Obstacle.enabled = false;
						}
					}
					if (!this.InEvent)
					{
						if (this.Pathfinding.speed > 0f)
						{
							if (this.Pathfinding.speed == this.WalkSpeed)
							{
								if (!this.CharacterAnimation.IsPlaying(this.WalkAnim))
								{
									if (this.Persona == PersonaType.PhoneAddict && this.Actions[this.Phase] == StudentActionType.Clean)
									{
										this.CharacterAnimation.CrossFade(this.OriginalWalkAnim);
									}
									else
									{
										this.CharacterAnimation.CrossFade(this.WalkAnim);
									}
								}
							}
							else if (!this.Dying)
							{
								this.CharacterAnimation.CrossFade(this.SprintAnim);
							}
						}
					}
					else if (this.StudentID == 10 && this.InEvent && this.CurrentAction == StudentActionType.Socializing)
					{
						if (!this.Hurry)
						{
							this.Pathfinding.speed = this.WalkSpeed;
						}
						else
						{
							this.Pathfinding.speed = 4f;
						}
						if (this.Pathfinding.speed == this.WalkSpeed)
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.SprintAnim);
						}
						this.CheckForEndRaibaruEvent();
					}
					if (this.Club == ClubType.Occult && this.Actions[this.Phase] != StudentActionType.ClubAction)
					{
						this.OccultBook.SetActive(false);
					}
					if (!this.Meeting && !this.GoAway && !this.InEvent)
					{
						if (this.Actions[this.Phase] == StudentActionType.Clean)
						{
							if (this.SmartPhone.activeInHierarchy)
							{
								this.SmartPhone.SetActive(false);
							}
							if (this.CurrentDestination != this.CleaningSpot.GetChild(this.CleanID))
							{
								this.CurrentDestination = this.CleaningSpot.GetChild(this.CleanID);
								this.Pathfinding.target = this.CurrentDestination;
							}
						}
						if (this.Actions[this.Phase] == StudentActionType.Patrol && this.CurrentDestination != this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID))
						{
							this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
							this.Pathfinding.target = this.CurrentDestination;
						}
					}
				}
				if (this.Meeting)
				{
					if (this.BakeSale)
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
						this.Pathfinding.speed = this.WalkSpeed;
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.SprintAnim);
						this.Pathfinding.speed = 4f;
					}
				}
				if (this.CuriosityPhase == 1 && this.CurrentAction == StudentActionType.Relax && this.StudentManager.LockerRoomArea.bounds.Contains(this.StudentManager.Students[this.Crush].transform.position))
				{
					Debug.Log("This code is called when a student is stalking their crush and their crush is in the shower room.");
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.CurrentDestination = this.Destinations[this.Phase];
					this.TargetDistance = 0.5f;
					this.CuriosityTimer = 0f;
					this.CuriosityPhase--;
				}
				if (this.Infatuated && this.Actions[this.Phase] == StudentActionType.Socializing)
				{
					if (base.transform.position.y > this.CurrentDestination.position.y + 1f || base.transform.position.y < this.CurrentDestination.position.y - 1f)
					{
						this.TargetDistance = 2f;
					}
					else if (this.StudentManager.Students[this.StudentManager.RivalID].Meeting || this.StudentManager.Students[this.StudentManager.RivalID].InEvent)
					{
						this.TargetDistance = 10f;
					}
					else
					{
						this.TargetDistance = 5f;
					}
					if (this.StudentManager.LockerRoomArea.bounds.Contains(this.CurrentDestination.position))
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						return;
					}
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					return;
				}
			}
			else
			{
				if (this.StudentID == 10 && this.InEvent && this.CurrentAction != StudentActionType.Follow)
				{
					this.SpeechLines.Play();
					this.CharacterAnimation.CrossFade(this.RandomAnim);
					if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
					{
						this.PickRandomAnim();
					}
					this.CheckForEndRaibaruEvent();
				}
				if (this.CurrentDestination != null)
				{
					bool flag = false;
					if ((this.Actions[this.Phase] == StudentActionType.Sleuth && this.StudentManager.SleuthPhase == 3 && !this.Meeting) || (this.Actions[this.Phase] == StudentActionType.Stalk || (this.Actions[this.Phase] == StudentActionType.Relax && this.CuriosityPhase == 1)) || (this.Actions[this.Phase] == StudentActionType.Guard && !this.Meeting) || (this.CurrentAction == StudentActionType.Follow && this.FollowTarget != null && this.FollowTarget.CurrentAction == StudentActionType.SearchPatrol))
					{
						if (this.CurrentAction == StudentActionType.Follow && this.FollowTarget != null && this.FollowTarget.CurrentAction == StudentActionType.SearchPatrol)
						{
							Debug.Log("Raibaru knows that she should Stop Early...");
						}
						this.TargetDistance = 2f;
						flag = true;
					}
					else if (this.Actions[this.Phase] == StudentActionType.Socializing && this.Infatuated)
					{
						if (base.transform.position.y > this.CurrentDestination.position.y + 1f || base.transform.position.y < this.CurrentDestination.position.y - 1f)
						{
							this.TargetDistance = 2f;
						}
						else
						{
							this.TargetDistance = 5f;
						}
						flag = true;
					}
					if (this.Actions[this.Phase] == StudentActionType.Follow)
					{
						if (this.FollowTarget != null)
						{
							if (!this.ManualRotation)
							{
								this.targetRotation = Quaternion.LookRotation(this.FollowTarget.transform.position - base.transform.position);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
							}
							if (this.FollowTarget.Attacked && this.FollowTarget.Alive && !this.FollowTarget.Tranquil)
							{
								Debug.Log("Raibaru should be aware that Osana is being attacked.");
								this.AwareOfMurder = true;
								this.Alarm = 200f;
							}
						}
					}
					else if (!flag)
					{
						this.MoveTowardsTarget(this.CurrentDestination.position);
						if (Quaternion.Angle(base.transform.rotation, this.CurrentDestination.rotation) > 1f && !this.StopRotating)
						{
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, 10f * Time.deltaTime);
						}
					}
					else
					{
						if (this.Infatuated)
						{
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Students[19].transform.position.x, base.transform.position.y, this.StudentManager.Students[19].transform.position.z) - base.transform.position);
							StudentScript studentScript = this.StudentManager.Students[19];
							if (studentScript != null && (!studentScript.gameObject.activeInHierarchy || !studentScript.enabled))
							{
								this.BoyCannotFindGravureModel();
							}
						}
						else if (this.Actions[this.Phase] == StudentActionType.Sleuth || this.Actions[this.Phase] == StudentActionType.Stalk)
						{
							this.targetRotation = Quaternion.LookRotation(this.SleuthTarget.position - base.transform.position);
						}
						else if (this.Actions[this.Phase] == StudentActionType.Guard)
						{
							this.targetRotation = Quaternion.LookRotation(base.transform.position - new Vector3(this.CurrentDestination.position.x, base.transform.position.y, this.CurrentDestination.position.z));
						}
						else if (this.Crush > 0)
						{
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Students[this.Crush].transform.position.x, base.transform.position.y, this.StudentManager.Students[this.Crush].transform.position.z) - base.transform.position);
						}
						float num = Quaternion.Angle(base.transform.rotation, this.targetRotation);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
						if (num > 1f)
						{
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
						}
					}
					if (!this.Hurry)
					{
						this.Pathfinding.speed = this.WalkSpeed;
					}
					else
					{
						this.Pathfinding.speed = 4f;
					}
				}
				if (this.Pathfinding.canMove)
				{
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					if (this.Actions[this.Phase] != StudentActionType.Clean)
					{
						this.Obstacle.enabled = true;
					}
				}
				if (!this.InEvent && !this.Meeting && this.DressCode)
				{
					if (this.Actions[this.Phase] == StudentActionType.ClubAction)
					{
						if (!this.ClubAttire)
						{
							if (!this.ChangingBooth.Occupied)
							{
								if (this.CurrentDestination == this.ChangingBooth.transform)
								{
									this.ChangingBooth.Occupied = true;
									this.ChangingBooth.Student = this;
									this.ChangingBooth.CheckYandereClub();
									this.Obstacle.enabled = false;
								}
								this.CurrentDestination = this.ChangingBooth.transform;
								this.Pathfinding.target = this.ChangingBooth.transform;
							}
							else
							{
								this.CharacterAnimation.CrossFade(this.IdleAnim);
							}
						}
						else if (!this.GoAway)
						{
							this.CurrentDestination = this.Destinations[this.Phase];
							this.Pathfinding.target = this.Destinations[this.Phase];
						}
					}
					else if (this.ClubAttire)
					{
						if (!this.ChangingBooth.Occupied)
						{
							if (this.CurrentDestination == this.ChangingBooth.transform)
							{
								this.ChangingBooth.Occupied = true;
								this.ChangingBooth.Student = this;
								this.ChangingBooth.CheckYandereClub();
							}
							this.CurrentDestination = this.ChangingBooth.transform;
							this.Pathfinding.target = this.ChangingBooth.transform;
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
					}
					else if (this.Actions[this.Phase] != StudentActionType.Clean)
					{
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
					}
				}
				if (!this.InEvent)
				{
					if (!this.Meeting)
					{
						if (!this.GoAway)
						{
							if (this.Actions[this.Phase] == StudentActionType.AtLocker)
							{
								this.CharacterAnimation.CrossFade(this.IdleAnim);
								this.Pathfinding.canSearch = false;
								this.Pathfinding.canMove = false;
								return;
							}
							if (this.Actions[this.Phase] == StudentActionType.Socializing || (this.Actions[this.Phase] == StudentActionType.Follow && this.FollowTarget != null && this.FollowTarget.Actions[this.Phase] != StudentActionType.Clean && this.FollowTargetDistance < 1f && !this.FollowTarget.Alone && !this.FollowTarget.InEvent && !this.FollowTarget.Talking && !this.FollowTarget.Meeting && !this.FollowTarget.Confessing && this.FollowTarget.DistanceToDestination < 1f))
							{
								if (this.FollowTarget != null)
								{
									if (this.FollowTarget.Indoors && this.FollowTarget.CurrentAction != StudentActionType.SearchPatrol)
									{
										this.FollowTarget.FollowTargetDestination.localPosition = new Vector3(0f, 0f, 1f);
										this.MoveTowardsTarget(this.CurrentDestination.position);
									}
									else
									{
										this.FollowTarget.FollowTargetDestination.localPosition = new Vector3(0f, 0f, 0f);
									}
								}
								if (this.MyPlate != null && this.MyPlate.parent == this.RightHand)
								{
									this.MyPlate.parent = null;
									this.MyPlate.position = this.OriginalPlatePosition;
									this.MyPlate.rotation = this.OriginalPlateRotation;
									this.IdleAnim = this.OriginalIdleAnim;
									this.WalkAnim = this.OriginalWalkAnim;
									this.LeanAnim = this.OriginalLeanAnim;
									this.ResumeDistracting = false;
									this.Distracting = false;
									this.Distracted = false;
									this.CanTalk = true;
								}
								if (this.Paranoia > 1.66666f && !this.StudentManager.LoveSick && this.Club != ClubType.Delinquent)
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
								}
								else
								{
									this.StudentManager.ConvoManager.CheckMe(this.StudentID);
									if (this.Club == ClubType.Delinquent)
									{
										if (this.Alone)
										{
											if (!this.Phoneless && this.TrueAlone)
											{
												if (!this.SmartPhone.activeInHierarchy)
												{
													this.CharacterAnimation.CrossFade("delinquentTexting_00");
													this.SmartPhone.SetActive(true);
													this.SpeechLines.Stop();
												}
											}
											else
											{
												this.CharacterAnimation.CrossFade(this.IdleAnim);
												this.SpeechLines.Stop();
											}
										}
										else
										{
											if (!this.InEvent)
											{
												if (!this.Grudge)
												{
													if (!this.SpeechLines.isPlaying)
													{
														this.SmartPhone.SetActive(false);
														this.SpeechLines.Play();
													}
												}
												else
												{
													this.SmartPhone.SetActive(false);
												}
											}
											this.CharacterAnimation.CrossFade(this.RandomAnim);
											if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
											{
												this.PickRandomAnim();
											}
										}
									}
									else if (this.Alone)
									{
										if (!this.Male)
										{
											if (!this.Phoneless)
											{
												this.CharacterAnimation.CrossFade("f02_standTexting_00");
												this.SmartPhone.SetActive(true);
												this.SpeechLines.Stop();
											}
											else
											{
												this.CharacterAnimation.CrossFade(this.PatrolAnim);
												this.SpeechLines.Stop();
											}
										}
										else if (!this.Phoneless)
										{
											if (this.StudentID == 36)
											{
												this.CharacterAnimation.CrossFade(this.ClubAnim);
											}
											else if (this.StudentID == 66)
											{
												this.CharacterAnimation.CrossFade("delinquentTexting_00");
											}
											else
											{
												this.CharacterAnimation.CrossFade("standTexting_00");
											}
											if (!this.SmartPhone.activeInHierarchy && !this.Shy)
											{
												if (this.StudentID == 36)
												{
													this.SmartPhone.transform.localPosition = new Vector3(0.0566666f, -0.02f, 0f);
													this.SmartPhone.transform.localEulerAngles = new Vector3(10f, 115f, 180f);
												}
												else
												{
													this.SmartPhone.transform.localPosition = new Vector3(0.015f, 0.01f, 0.025f);
													this.SmartPhone.transform.localEulerAngles = new Vector3(10f, -160f, 165f);
												}
												this.SmartPhone.SetActive(true);
												this.SpeechLines.Stop();
											}
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.PatrolAnim);
											this.SpeechLines.Stop();
										}
									}
									else if ((this.FollowTarget != null && !this.FollowTarget.gameObject.activeInHierarchy) || (this.FollowTarget != null && !this.FollowTarget.enabled))
									{
										this.RaibaruCannotFindOsana();
									}
									else
									{
										if (!this.InEvent)
										{
											if (!this.Grudge)
											{
												if (!this.SpeechLines.isPlaying)
												{
													this.SmartPhone.SetActive(false);
													this.SpeechLines.Play();
												}
											}
											else
											{
												this.SmartPhone.SetActive(false);
											}
										}
										if (this.Club != ClubType.Photography)
										{
											this.CharacterAnimation.CrossFade(this.RandomAnim);
											if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
											{
												this.PickRandomAnim();
											}
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.RandomSleuthAnim);
											if (this.CharacterAnimation[this.RandomSleuthAnim].time >= this.CharacterAnimation[this.RandomSleuthAnim].length)
											{
												this.PickRandomSleuthAnim();
											}
										}
									}
								}
								if (this.PyroUrge)
								{
									this.PyroTimer += Time.deltaTime;
									if (this.PyroTimer > 60f)
									{
										this.SpeechLines.Stop();
										ScheduleBlock scheduleBlock5 = this.ScheduleBlocks[this.Phase];
										scheduleBlock5.destination = "LightFire";
										scheduleBlock5.action = "LightFire";
										this.GetDestinations();
										this.Pathfinding.target = this.Destinations[this.Phase];
										this.CurrentDestination = this.Destinations[this.Phase];
										this.PyroPhase = 1;
										this.PyroTimer = 0f;
										return;
									}
								}
							}
							else if (this.Actions[this.Phase] == StudentActionType.Gossip)
							{
								if (this.StudentID == 82 && this.Clock.Day == 5)
								{
									this.BountyCollider.SetActive(true);
								}
								if (this.Paranoia > 1.66666f && !this.StudentManager.LoveSick)
								{
									this.CharacterAnimation.CrossFade(this.IdleAnim);
									return;
								}
								this.StudentManager.ConvoManager.CheckMe(this.StudentID);
								if (this.Alone)
								{
									if (!this.Shy)
									{
										this.CharacterAnimation.CrossFade("f02_standTexting_00");
										if (!this.SmartPhone.activeInHierarchy)
										{
											this.SmartPhone.SetActive(true);
											this.SpeechLines.Stop();
											return;
										}
									}
								}
								else
								{
									if (!this.SpeechLines.isPlaying)
									{
										this.SmartPhone.SetActive(false);
										this.SpeechLines.Play();
									}
									this.CharacterAnimation.CrossFade(this.RandomGossipAnim);
									if (this.CharacterAnimation[this.RandomGossipAnim].time >= this.CharacterAnimation[this.RandomGossipAnim].length)
									{
										this.PickRandomGossipAnim();
										return;
									}
								}
							}
							else
							{
								if (this.Actions[this.Phase] == StudentActionType.Gaming)
								{
									this.CharacterAnimation.CrossFade(this.GameAnim);
									return;
								}
								if (this.Actions[this.Phase] == StudentActionType.Shamed)
								{
									this.CharacterAnimation.CrossFade(this.SadSitAnim);
									return;
								}
								if (this.Actions[this.Phase] == StudentActionType.Slave)
								{
									this.CharacterAnimation.CrossFade(this.BrokenSitAnim);
									if (this.FragileSlave)
									{
										if (this.HuntTarget == null)
										{
											this.HuntTarget = this;
											this.GoCommitMurder();
											return;
										}
										if (this.HuntTarget.Indoors)
										{
											this.GoCommitMurder();
											return;
										}
									}
								}
								else if (this.Actions[this.Phase] == StudentActionType.Relax)
								{
									if (this.CuriosityPhase == 0)
									{
										this.CharacterAnimation.CrossFade(this.RelaxAnim);
										if (this.Curious)
										{
											this.CuriosityTimer += Time.deltaTime;
											if (this.CuriosityTimer > 30f)
											{
												if (!this.StudentManager.Students[this.Crush].Private && !this.StudentManager.Students[this.Crush].Wet && !this.StudentManager.LockerRoomArea.bounds.Contains(this.StudentManager.Students[this.Crush].transform.position))
												{
													this.Pathfinding.target = this.StudentManager.Students[this.Crush].transform;
													this.CurrentDestination = this.StudentManager.Students[this.Crush].transform;
													this.TargetDistance = 5f;
													this.CuriosityTimer = 0f;
													this.CuriosityPhase++;
													return;
												}
												this.CuriosityTimer = 0f;
												return;
											}
										}
									}
									else
									{
										if (this.Pathfinding.target != this.StudentManager.Students[this.Crush].transform)
										{
											this.Pathfinding.target = this.StudentManager.Students[this.Crush].transform;
											this.CurrentDestination = this.StudentManager.Students[this.Crush].transform;
										}
										if ((!this.StudentManager.Students[this.Crush].Alive && this.StudentManager.Students[this.Crush].Ragdoll.Concealed) || (!this.StudentManager.Students[this.Crush].Alive && this.StudentManager.Students[this.Crush].Ragdoll.Disposed) || !this.StudentManager.Students[this.Crush].gameObject.activeInHierarchy)
										{
											this.CharacterAnimation.CrossFade("lookLeftRightConfused_00");
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.LeanAnim);
										}
										this.CuriosityTimer += Time.deltaTime;
										if (this.CuriosityTimer > 10f || this.StudentManager.Students[this.Crush].Private || this.StudentManager.Students[this.Crush].Wet)
										{
											this.Pathfinding.target = this.Destinations[this.Phase];
											this.CurrentDestination = this.Destinations[this.Phase];
											this.TargetDistance = 0.5f;
											this.CuriosityTimer = 0f;
											this.CuriosityPhase--;
											if ((!this.StudentManager.Students[this.Crush].Alive && this.StudentManager.Students[this.Crush].Ragdoll.Concealed) || (!this.StudentManager.Students[this.Crush].Alive && this.StudentManager.Students[this.Crush].Ragdoll.Disposed) || !this.StudentManager.Students[this.Crush].gameObject.activeInHierarchy)
											{
												this.Curious = false;
												return;
											}
										}
									}
								}
								else if (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes)
								{
									if (this.Follower != null && this.Follower.Actions[this.Phase] != StudentActionType.SitAndTakeNotes && this.Clock.HourTime < 15.5f)
									{
										this.Follower.GoToClass();
									}
									if (this.MyPlate != null && this.MyPlate.parent == this.RightHand)
									{
										this.MyPlate.parent = null;
										this.MyPlate.position = this.OriginalPlatePosition;
										this.MyPlate.rotation = this.OriginalPlateRotation;
										this.CurrentDestination = this.Destinations[this.Phase];
										this.Pathfinding.target = this.Destinations[this.Phase];
										this.IdleAnim = this.OriginalIdleAnim;
										this.WalkAnim = this.OriginalWalkAnim;
										this.LeanAnim = this.OriginalLeanAnim;
										this.ResumeDistracting = false;
										this.Distracting = false;
										this.Distracted = false;
										this.CanTalk = true;
									}
									if (this.MustChangeClothing)
									{
										if (this.ChangeClothingPhase == 0)
										{
											UnityEngine.Object.Instantiate<GameObject>(this.StudentManager.CommunalLocker.SteamCloud, base.transform.position + Vector3.up * 0.81f, Quaternion.identity);
											this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
											this.ChangeClothingPhase++;
											return;
										}
										if (this.ChangeClothingPhase == 1)
										{
											this.CharacterAnimation.CrossFade(this.StripAnim);
											this.Pathfinding.canSearch = false;
											this.Pathfinding.canMove = false;
											if (this.CharacterAnimation[this.StripAnim].time >= 1.5f)
											{
												if (this.Schoolwear != 1)
												{
													this.Schoolwear = 1;
													this.ChangeSchoolwear();
													this.WalkAnim = this.OriginalWalkAnim;
												}
												if (this.CharacterAnimation[this.StripAnim].time >= this.CharacterAnimation[this.StripAnim].length)
												{
													this.Pathfinding.target = this.Seat;
													this.CurrentDestination = this.Seat;
													this.ChangeClothingPhase++;
													this.MustChangeClothing = false;
													return;
												}
											}
										}
									}
									else
									{
										if (this.Bullied)
										{
											if (this.SmartPhone.activeInHierarchy)
											{
												this.SmartPhone.SetActive(false);
											}
											this.CharacterAnimation.CrossFade(this.SadDeskSitAnim, 1f);
											return;
										}
										if (this.Phoneless && this.StudentManager.CommunalLocker.RivalPhone.gameObject.activeInHierarchy && !this.EndSearch && this.Yandere.CanMove)
										{
											if (this.Rival)
											{
												this.LewdPhotos = this.StudentManager.CommunalLocker.RivalPhone.LewdPhotos;
												if (DateGlobals.Weekday == DayOfWeek.Monday)
												{
													SchemeGlobals.SetSchemeStage(1, 8);
													this.Yandere.PauseScreen.Schemes.UpdateInstructions();
												}
											}
											this.CharacterAnimation.CrossFade(this.DiscoverPhoneAnim);
											this.Subtitle.UpdateLabel(this.LostPhoneSubtitleType, 2, 5f);
											this.Phoneless = false;
											this.EndSearch = true;
											this.Routine = false;
										}
										if (!this.EndSearch)
										{
											if (this.Clock.Period != 2 && this.Clock.Period != 4)
											{
												if (this.DressCode && this.ClubAttire)
												{
													this.CharacterAnimation.CrossFade(this.IdleAnim);
													return;
												}
												if ((double)Vector3.Distance(base.transform.position, this.Seat.position) < 0.5)
												{
													if ((this.StudentID == 1 && this.StudentManager.Gift.activeInHierarchy) || (this.StudentID == 1 && this.StudentManager.Note.activeInHierarchy))
													{
														this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
														this.CharacterAnimation.CrossFade(this.InspectBloodAnim);
														if (this.CharacterAnimation[this.InspectBloodAnim].time >= this.CharacterAnimation[this.InspectBloodAnim].length)
														{
															this.StudentManager.Gift.SetActive(false);
															this.StudentManager.Note.SetActive(false);
															return;
														}
													}
													else
													{
														if (this.Phoneless)
														{
															this.CharacterAnimation.CrossFade(this.ConfusedSitAnim);
															return;
														}
														if (this.Club == ClubType.Delinquent)
														{
															this.CharacterAnimation.CrossFade("delinquentSit_00");
															return;
														}
														if (!this.StudentManager.Eighties)
														{
															if (!this.SmartPhone.activeInHierarchy)
															{
																if (this.Male)
																{
																	this.SmartPhone.transform.localPosition = new Vector3(0.025f, 0.0025f, 0.025f);
																	this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 180f);
																}
																else
																{
																	this.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.01f, 0.01f);
																	this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
																}
																this.SmartPhone.SetActive(true);
															}
															this.CharacterAnimation.CrossFade(this.DeskTextAnim);
															return;
														}
														if (this.SmartPhone.activeInHierarchy)
														{
															this.SmartPhone.SetActive(false);
														}
														this.CharacterAnimation.CrossFade(this.ConfusedSitAnim);
														return;
													}
												}
											}
											else if (this.StudentManager.Teachers[this.Class].SpeechLines.isPlaying && !this.StudentManager.Teachers[this.Class].Alarmed)
											{
												if (this.DressCode && this.ClubAttire)
												{
													this.CharacterAnimation.CrossFade(this.IdleAnim);
													return;
												}
												if (!this.Depressed && !this.Pen.activeInHierarchy)
												{
													this.Pen.SetActive(true);
												}
												if (this.SmartPhone.activeInHierarchy)
												{
													this.SmartPhone.SetActive(false);
												}
												if (this.MyPaper == null)
												{
													if (base.transform.position.x < 0f)
													{
														this.MyPaper = UnityEngine.Object.Instantiate<GameObject>(this.Paper, this.Seat.position + new Vector3(-0.4f, 0.772f, 0f), Quaternion.identity);
													}
													else
													{
														this.MyPaper = UnityEngine.Object.Instantiate<GameObject>(this.Paper, this.Seat.position + new Vector3(0.4f, 0.772f, 0f), Quaternion.identity);
													}
													this.MyPaper.transform.eulerAngles = new Vector3(0f, 0f, -90f);
													this.MyPaper.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
													this.MyPaper.transform.parent = this.StudentManager.Papers;
												}
												this.CharacterAnimation.CrossFade(this.SitAnim);
												return;
											}
											else
											{
												if (this.Club != ClubType.Delinquent)
												{
													this.CharacterAnimation.CrossFade(this.ConfusedSitAnim);
													return;
												}
												this.CharacterAnimation.CrossFade("delinquentSit_00");
												return;
											}
										}
									}
								}
								else if (this.Actions[this.Phase] == StudentActionType.Peek)
								{
									this.CharacterAnimation.CrossFade(this.PeekAnim);
									if (this.Male)
									{
										this.Cosmetic.MyRenderer.materials[this.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
										return;
									}
								}
								else if (this.Actions[this.Phase] == StudentActionType.ClubAction)
								{
									if (this.DressCode && !this.ClubAttire)
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
									}
									else
									{
										if (this.StudentID == 47 || this.StudentID == 49)
										{
											if (this.GetNewAnimation)
											{
												this.StudentManager.ConvoManager.MartialArtsCheck();
											}
											if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
											{
												this.GetNewAnimation = true;
											}
										}
										if (this.Club != ClubType.Occult)
										{
											this.CharacterAnimation.CrossFade(this.ClubAnim);
										}
									}
									if (this.Club == ClubType.Cooking)
									{
										if (this.ClubActivityPhase != 0)
										{
											this.GetFoodTarget();
											return;
										}
										if (this.ClubTimer == 0f)
										{
											this.MyPlate.parent = null;
											this.MyPlate.gameObject.SetActive(true);
											this.MyPlate.position = this.OriginalPlatePosition;
											this.MyPlate.rotation = this.OriginalPlateRotation;
										}
										this.ClubTimer += Time.deltaTime;
										if (this.ClubTimer > 60f)
										{
											this.MyPlate.parent = this.RightHand;
											this.MyPlate.localPosition = new Vector3(0.02f, -0.02f, -0.15f);
											this.MyPlate.localEulerAngles = new Vector3(-5f, -90f, 172.5f);
											this.IdleAnim = this.PlateIdleAnim;
											this.WalkAnim = this.PlateWalkAnim;
											this.LeanAnim = this.PlateIdleAnim;
											this.GetFoodTarget();
											this.ClubTimer = 0f;
											this.ClubActivityPhase++;
											return;
										}
									}
									else if (this.Club == ClubType.Drama)
									{
										this.StudentManager.DramaTimer += Time.deltaTime;
										if (this.StudentManager.DramaPhase == 1)
										{
											this.StudentManager.ConvoManager.CheckMe(this.StudentID);
											if (this.Alone)
											{
												if (this.Phoneless)
												{
													this.CharacterAnimation.CrossFade("f02_sit_01");
												}
												else
												{
													if (this.Male)
													{
														this.CharacterAnimation.CrossFade("standTexting_00");
													}
													else
													{
														this.CharacterAnimation.CrossFade("f02_standTexting_00");
													}
													if (!this.SmartPhone.activeInHierarchy)
													{
														this.SmartPhone.transform.localPosition = new Vector3(0.02f, 0.01f, 0.03f);
														this.SmartPhone.transform.localEulerAngles = new Vector3(5f, -160f, 180f);
														this.SmartPhone.SetActive(true);
														this.SpeechLines.Stop();
													}
												}
											}
											else if (this.StudentID == 26 && !this.SpeechLines.isPlaying)
											{
												this.SmartPhone.SetActive(false);
												this.SpeechLines.Play();
											}
											if (this.StudentManager.DramaTimer > 100f)
											{
												this.StudentManager.DramaTimer = 0f;
												this.StudentManager.UpdateDrama();
												return;
											}
										}
										else if (this.StudentManager.DramaPhase == 2)
										{
											if (this.StudentManager.DramaTimer > 300f)
											{
												this.StudentManager.DramaTimer = 0f;
												this.StudentManager.UpdateDrama();
												return;
											}
										}
										else if (this.StudentManager.DramaPhase == 3)
										{
											this.SpeechLines.Play();
											this.CharacterAnimation.CrossFade(this.RandomAnim);
											if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
											{
												this.PickRandomAnim();
											}
											if (this.StudentManager.DramaTimer > 100f)
											{
												this.StudentManager.DramaTimer = 0f;
												this.StudentManager.UpdateDrama();
												return;
											}
										}
									}
									else if (this.Club == ClubType.Occult)
									{
										if (this.ReadPhase == 0)
										{
											this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
											this.CharacterAnimation.CrossFade(this.BookSitAnim);
											if (this.CharacterAnimation[this.BookSitAnim].time > this.CharacterAnimation[this.BookSitAnim].length)
											{
												this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
												this.CharacterAnimation.CrossFade(this.BookReadAnim);
												this.ReadPhase++;
												return;
											}
											if (this.CharacterAnimation[this.BookSitAnim].time > 1f)
											{
												this.OccultBook.SetActive(true);
												return;
											}
										}
									}
									else if (this.Club == ClubType.Art)
									{
										if (this.ClubAttire && !this.Paintbrush.activeInHierarchy && (double)Vector3.Distance(base.transform.position, this.CurrentDestination.position) < 0.5)
										{
											this.Paintbrush.SetActive(true);
											this.Palette.SetActive(true);
											return;
										}
									}
									else if (this.Club == ClubType.LightMusic)
									{
										if ((double)this.Clock.HourTime < 16.9)
										{
											this.Instruments[this.ClubMemberID].SetActive(true);
											this.CharacterAnimation.CrossFade(this.ClubAnim);
											if (this.StudentID == 51)
											{
												if (this.InstrumentBag[this.ClubMemberID].transform.parent != null)
												{
													this.InstrumentBag[this.ClubMemberID].transform.parent = null;
													if (!this.StudentManager.Eighties)
													{
														this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(0.5f, 4.5f, 22.45666f);
														this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
													}
													else
													{
														this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(2.06f, 4.5f, 26.5f);
														this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
													}
												}
												if (this.Instruments[this.ClubMemberID].transform.parent == null)
												{
													this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Play();
													this.Instruments[this.ClubMemberID].transform.parent = base.transform;
													this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.340493f, 0.653502f, -0.286104f);
													this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-13.6139f, 16.16775f, 72.5293f);
													return;
												}
											}
											else if (this.StudentID == 54 && !this.Drumsticks[0].activeInHierarchy)
											{
												this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Play();
												this.Drumsticks[0].SetActive(true);
												this.Drumsticks[1].SetActive(true);
												return;
											}
										}
										else if (this.StudentID == 51)
										{
											this.InstrumentBag[this.ClubMemberID].transform.parent;
											if (!this.StudentManager.Eighties)
											{
												this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(0.5f, 4.5f, 22.45666f);
												this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
											}
											else
											{
												this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(2.06f, 4.5f, 26.5f);
												this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
											}
											this.InstrumentBag[this.ClubMemberID].transform.parent = null;
											if (!this.StudentManager.PracticeMusic.isPlaying)
											{
												this.CharacterAnimation.CrossFade("f02_vocalIdle_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 114.5f)
											{
												this.CharacterAnimation.CrossFade("f02_vocalCelebrate_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 104f)
											{
												this.CharacterAnimation.CrossFade("f02_vocalWait_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 32f)
											{
												this.CharacterAnimation.CrossFade("f02_vocalSingB_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 24f)
											{
												this.CharacterAnimation.CrossFade("f02_vocalSingB_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 17f)
											{
												this.CharacterAnimation.CrossFade("f02_vocalSingB_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 14f)
											{
												this.CharacterAnimation.CrossFade("f02_vocalWait_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 8f)
											{
												this.CharacterAnimation.CrossFade("f02_vocalSingA_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 0f)
											{
												this.CharacterAnimation.CrossFade("f02_vocalWait_00");
												return;
											}
										}
										else if (this.StudentID == 52)
										{
											if (!this.Instruments[this.ClubMemberID].activeInHierarchy)
											{
												this.Instruments[this.ClubMemberID].SetActive(true);
												this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
												this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
												this.Instruments[this.ClubMemberID].transform.parent = this.Spine;
												this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
												this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
												this.InstrumentBag[this.ClubMemberID].transform.parent = null;
												this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 25f);
												this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
											}
											if (!this.StudentManager.PracticeMusic.isPlaying)
											{
												this.CharacterAnimation.CrossFade("f02_guitarIdle_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 114.5f)
											{
												this.CharacterAnimation.CrossFade("f02_guitarCelebrate_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 112f)
											{
												this.CharacterAnimation.CrossFade("f02_guitarWait_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 64f)
											{
												this.CharacterAnimation.CrossFade("f02_guitarPlayA_01");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 8f)
											{
												this.CharacterAnimation.CrossFade("f02_guitarPlayA_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 0f)
											{
												this.CharacterAnimation.CrossFade("f02_guitarWait_00");
												return;
											}
										}
										else if (this.StudentID == 53)
										{
											if (!this.Instruments[this.ClubMemberID].activeInHierarchy)
											{
												this.Instruments[this.ClubMemberID].SetActive(true);
												this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
												this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
												this.Instruments[this.ClubMemberID].transform.parent = this.Spine;
												this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
												this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
												this.InstrumentBag[this.ClubMemberID].transform.parent = null;
												this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 26f);
												this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
											}
											if (!this.StudentManager.PracticeMusic.isPlaying)
											{
												this.CharacterAnimation.CrossFade("f02_guitarIdle_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 114.5f)
											{
												this.CharacterAnimation.CrossFade("f02_guitarCelebrate_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 112f)
											{
												this.CharacterAnimation.CrossFade("f02_guitarWait_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 88f)
											{
												this.CharacterAnimation.CrossFade("f02_guitarPlayA_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 80f)
											{
												this.CharacterAnimation.CrossFade("f02_guitarWait_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 64f)
											{
												this.CharacterAnimation.CrossFade("f02_guitarPlayB_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 0f)
											{
												this.CharacterAnimation.CrossFade("f02_guitarPlaySlowA_01");
												return;
											}
										}
										else if (this.StudentID == 54)
										{
											if (this.InstrumentBag[this.ClubMemberID].transform.parent != null)
											{
												this.InstrumentBag[this.ClubMemberID].transform.parent = null;
												this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 23f);
												this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
											}
											this.Drumsticks[0].SetActive(true);
											this.Drumsticks[1].SetActive(true);
											if (!this.StudentManager.PracticeMusic.isPlaying)
											{
												this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 114.5f)
											{
												this.CharacterAnimation.CrossFade("f02_drumsCelebrate_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 108f)
											{
												this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 96f)
											{
												this.CharacterAnimation.CrossFade("f02_drumsPlaySlow_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 80f)
											{
												this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 38f)
											{
												this.CharacterAnimation.CrossFade("f02_drumsPlay_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 46f)
											{
												this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 16f)
											{
												this.CharacterAnimation.CrossFade("f02_drumsPlay_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 0f)
											{
												this.CharacterAnimation.CrossFade("f02_drumsIdle_00");
												return;
											}
										}
										else if (this.StudentID == 55)
										{
											if (this.InstrumentBag[this.ClubMemberID].transform.parent != null)
											{
												this.InstrumentBag[this.ClubMemberID].transform.parent = null;
												this.InstrumentBag[this.ClubMemberID].transform.position = new Vector3(5.5825f, 4.01f, 24f);
												this.InstrumentBag[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
											}
											if (!this.StudentManager.PracticeMusic.isPlaying)
											{
												this.CharacterAnimation.CrossFade("f02_keysIdle_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 114.5f)
											{
												this.CharacterAnimation.CrossFade("f02_keysCelebrate_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 80f)
											{
												this.CharacterAnimation.CrossFade("f02_keysWait_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 24f)
											{
												this.CharacterAnimation.CrossFade("f02_keysPlay_00");
												return;
											}
											if (this.StudentManager.PracticeMusic.time > 0f)
											{
												this.CharacterAnimation.CrossFade("f02_keysWait_00");
												return;
											}
										}
									}
									else if (this.Club == ClubType.Science)
									{
										if ((!this.ClubAttire || this.GoAway) && (!this.StudentManager.Eighties || this.GoAway))
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
											return;
										}
										if (this.SciencePhase == 0)
										{
											this.CharacterAnimation.CrossFade(this.ClubAnim);
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.RummageAnim);
										}
										if ((double)Vector3.Distance(base.transform.position, this.CurrentDestination.position) < 0.5)
										{
											if (this.SciencePhase == 0)
											{
												if (!this.StudentManager.Eighties)
												{
													if (this.StudentID == 62)
													{
														this.ScienceProps[0].SetActive(true);
													}
													else if (this.StudentID == 63)
													{
														this.ScienceProps[1].SetActive(true);
														this.ScienceProps[2].SetActive(true);
													}
													else if (this.StudentID == 64)
													{
														this.ScienceProps[0].SetActive(true);
													}
												}
												else
												{
													if (!this.Male && !this.ScienceProps[1].activeInHierarchy)
													{
														this.CharacterAnimation.Play("f02_straightenSkirt_00");
													}
													this.ScienceProps[1].SetActive(true);
													this.ScienceProps[2].SetActive(true);
												}
											}
											if (this.StudentID > 61)
											{
												this.ClubTimer += Time.deltaTime;
												if (this.ClubTimer > 60f)
												{
													this.ClubTimer = 0f;
													this.SciencePhase++;
													if (this.SciencePhase == 1)
													{
														this.ClubTimer = 50f;
														this.Destinations[this.Phase] = this.StudentManager.SupplySpots[this.StudentID - 61];
														this.CurrentDestination = this.StudentManager.SupplySpots[this.StudentID - 61];
														this.Pathfinding.target = this.StudentManager.SupplySpots[this.StudentID - 61];
														foreach (GameObject gameObject3 in this.ScienceProps)
														{
															if (gameObject3 != null)
															{
																gameObject3.SetActive(false);
															}
														}
														return;
													}
													this.SciencePhase = 0;
													this.ClubTimer = 0f;
													this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID];
													this.CurrentDestination = this.StudentManager.Clubs.List[this.StudentID];
													this.Pathfinding.target = this.StudentManager.Clubs.List[this.StudentID];
													return;
												}
											}
										}
									}
									else if (this.Club == ClubType.Sports)
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										if (this.ClubActivityPhase == 0)
										{
											if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
											{
												string str = "";
												if (!this.Male)
												{
													str = "f02_";
												}
												this.ClubActivityPhase++;
												this.ClubAnim = str + "stretch_01";
												this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
												return;
											}
										}
										else if (this.ClubActivityPhase == 1)
										{
											if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
											{
												string str2 = "";
												if (!this.Male)
												{
													str2 = "f02_";
												}
												this.ClubActivityPhase++;
												this.ClubAnim = str2 + "stretch_02";
												this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
												return;
											}
										}
										else if (this.ClubActivityPhase == 2)
										{
											if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
											{
												bool male = this.Male;
												this.Hurry = true;
												this.ClubActivityPhase++;
												this.CharacterAnimation[this.ClubAnim].time = 0f;
												this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
												return;
											}
										}
										else if (this.ClubActivityPhase < 14)
										{
											if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
											{
												this.ClubActivityPhase++;
												this.CharacterAnimation[this.ClubAnim].time = 0f;
												this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
												return;
											}
										}
										else if (this.ClubActivityPhase == 14)
										{
											if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
											{
												this.WalkAnim = this.OriginalWalkAnim;
												string str3 = "";
												if (!this.Male)
												{
													str3 = "f02_";
												}
												this.Hurry = false;
												this.ClubActivityPhase = 0;
												this.ClubAnim = str3 + "stretch_00";
												this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
												return;
											}
										}
										else if (this.ClubActivityPhase == 15)
										{
											if (this.CharacterAnimation[this.ClubAnim].time >= 1f && this.MyController.radius > 0f)
											{
												this.MyRenderer.updateWhenOffscreen = true;
												this.Obstacle.enabled = false;
												this.MyController.radius = 0f;
												this.Distracted = true;
											}
											if (!this.StudentManager.Eighties && this.CharacterAnimation[this.ClubAnim].time >= 2f)
											{
												float value = this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) + Time.deltaTime * 200f;
												this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, value);
											}
											if (this.CharacterAnimation[this.ClubAnim].time >= 5f)
											{
												this.ClubActivityPhase++;
												return;
											}
										}
										else if (this.ClubActivityPhase == 16)
										{
											if ((double)this.CharacterAnimation[this.ClubAnim].time >= 6.1)
											{
												if (!this.StudentManager.Eighties)
												{
													this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 100f);
													this.Cosmetic.MaleHair[this.Cosmetic.Hairstyle].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 100f);
												}
												GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.BigWaterSplash, this.RightHand.transform.position, Quaternion.identity);
												gameObject4.transform.eulerAngles = new Vector3(-90f, gameObject4.transform.eulerAngles.y, gameObject4.transform.eulerAngles.z);
												this.SetSplashes(true);
												this.ClubActivityPhase++;
												return;
											}
										}
										else if (this.ClubActivityPhase == 17)
										{
											if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
											{
												this.WalkAnim = "poolSwim_00";
												this.ClubAnim = "poolSwim_00";
												this.ClubActivityPhase++;
												this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase - 2);
												base.transform.position = this.Hips.transform.position;
												this.Character.transform.localPosition = new Vector3(0f, -0.25f, 0f);
												Physics.SyncTransforms();
												this.CharacterAnimation.Play(this.WalkAnim);
												return;
											}
										}
										else
										{
											if (this.ClubActivityPhase == 18)
											{
												this.ClubActivityPhase++;
												this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase - 2);
												this.DistanceToDestination = 100f;
												return;
											}
											if (this.ClubActivityPhase == 19)
											{
												this.ClubAnim = "poolExit_00";
												if (this.CharacterAnimation[this.ClubAnim].time >= 0.1f)
												{
													this.SetSplashes(false);
												}
												if (!this.StudentManager.Eighties && this.CharacterAnimation[this.ClubAnim].time >= 4.66666f)
												{
													float value2 = this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) - Time.deltaTime * 200f;
													this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, value2);
												}
												if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
												{
													this.ClubActivityPhase = 15;
													this.ClubAnim = "poolDive_00";
													this.MyController.radius = 0.1f;
													this.WalkAnim = this.OriginalWalkAnim;
													this.MyRenderer.updateWhenOffscreen = false;
													this.Character.transform.localPosition = new Vector3(0f, 0f, 0f);
													this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
													if (!this.StudentManager.Eighties)
													{
														this.Cosmetic.Goggles[this.StudentID].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0f);
													}
													base.transform.position = new Vector3(this.Hips.position.x, 4f, this.Hips.position.z);
													Physics.SyncTransforms();
													this.CharacterAnimation.Play(this.IdleAnim);
													this.Distracted = false;
													if (this.Clock.Period == 2 || this.Clock.Period == 4)
													{
														this.Pathfinding.speed = 4f;
														return;
													}
												}
											}
										}
									}
									else if (this.Club == ClubType.Gardening)
									{
										if (!this.StudentManager.Eighties && this.WateringCan.transform.parent != this.RightHand)
										{
											this.WateringCan.transform.parent = this.RightHand;
											this.WateringCan.transform.localPosition = new Vector3(0.14f, -0.15f, -0.05f);
											this.WateringCan.transform.localEulerAngles = new Vector3(10f, 15f, 45f);
										}
										this.PatrolTimer += Time.deltaTime * this.CharacterAnimation[this.PatrolAnim].speed;
										if (this.PatrolTimer >= this.CharacterAnimation[this.ClubAnim].length)
										{
											this.PatrolID++;
											if (this.PatrolID == this.StudentManager.Patrols.List[this.StudentID].childCount)
											{
												this.PatrolID = 0;
											}
											this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
											this.Pathfinding.target = this.CurrentDestination;
											this.PatrolTimer = 0f;
											if (!this.StudentManager.Eighties)
											{
												this.WateringCan.transform.parent = this.Hips;
												this.WateringCan.transform.localPosition = new Vector3(0f, 0.0135f, -0.184f);
												this.WateringCan.transform.localEulerAngles = new Vector3(0f, 90f, 30f);
												return;
											}
										}
									}
									else if (this.Club == ClubType.Gaming)
									{
										if (this.Phase < 8)
										{
											if (this.StudentID == 36 && !this.SmartPhone.activeInHierarchy)
											{
												this.SmartPhone.SetActive(true);
												this.SmartPhone.transform.localPosition = new Vector3(0.0566666f, -0.02f, 0f);
												this.SmartPhone.transform.localEulerAngles = new Vector3(10f, 115f, 180f);
												return;
											}
										}
										else
										{
											if (!this.ClubManager.GameScreens[this.ClubMemberID].activeInHierarchy)
											{
												this.ClubManager.GameScreens[this.ClubMemberID].SetActive(true);
												this.MyController.radius = 0.2f;
											}
											if (this.SmartPhone.activeInHierarchy)
											{
												this.SmartPhone.SetActive(false);
												return;
											}
										}
									}
									else if (this.Club == ClubType.Newspaper && this.StudentID > 36)
									{
										this.ClubTimer += Time.deltaTime;
										if (this.ClubTimer > 30f)
										{
											if (this.CurrentDestination.position.y > 0f)
											{
												this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(0);
												this.Pathfinding.target = this.CurrentDestination;
												this.ClubAnim = this.PatrolAnim;
											}
											else
											{
												this.CurrentDestination = this.StudentManager.Clubs.List[this.StudentID];
												this.Pathfinding.target = this.CurrentDestination;
												this.ClubAnim = this.OriginalClubAnim;
											}
											this.ClubTimer = 0f;
											return;
										}
									}
								}
								else if (this.Actions[this.Phase] == StudentActionType.SitAndSocialize)
								{
									if (this.Paranoia > 1.66666f)
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
										return;
									}
									this.StudentManager.ConvoManager.CheckMe(this.StudentID);
									if (this.Alone)
									{
										if (!this.Male)
										{
											this.CharacterAnimation.CrossFade("f02_standTexting_00");
										}
										else
										{
											this.CharacterAnimation.CrossFade("standTexting_00");
										}
										if (!this.SmartPhone.activeInHierarchy)
										{
											this.SmartPhone.SetActive(true);
											this.SpeechLines.Stop();
										}
									}
									else
									{
										if (!this.InEvent && !this.SpeechLines.isPlaying)
										{
											this.SmartPhone.SetActive(false);
											this.SpeechLines.Play();
										}
										if (this.Club != ClubType.Photography)
										{
											this.CharacterAnimation.CrossFade(this.RandomAnim);
											if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
											{
												this.PickRandomAnim();
											}
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.RandomSleuthAnim);
											if (this.CharacterAnimation[this.RandomSleuthAnim].time >= this.CharacterAnimation[this.RandomSleuthAnim].length)
											{
												this.PickRandomSleuthAnim();
											}
										}
									}
									if (this.StudentID == 56 && this.Clock.Day == 3)
									{
										this.BountyCollider.SetActive(true);
										return;
									}
								}
								else if (this.Actions[this.Phase] == StudentActionType.SitAndEatBento)
								{
									if (!this.DiscCheck && this.Alarm < 100f)
									{
										if (!this.Ragdoll.Poisoned && (!this.Bento.activeInHierarchy || this.Bento.transform.parent == null))
										{
											this.SmartPhone.SetActive(false);
											if (!this.Male)
											{
												this.Bento.transform.parent = this.LeftItemParent;
												this.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
												this.Bento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
											}
											else
											{
												this.Bento.transform.parent = this.LeftItemParent;
												this.Bento.transform.localPosition = new Vector3(-0.05f, -0.085f, 0f);
												this.Bento.transform.localEulerAngles = new Vector3(-3.2f, -24.4f, -94f);
											}
											this.Chopsticks[0].SetActive(true);
											this.Chopsticks[1].SetActive(true);
											this.Bento.SetActive(true);
											this.Lid.SetActive(false);
											this.MyBento.Prompt.Hide();
											this.MyBento.Prompt.enabled = false;
											if (this.MyBento.Tampered)
											{
												if (this.MyBento.Emetic)
												{
													this.Emetic = true;
												}
												else if (this.MyBento.Lethal)
												{
													this.Lethal = true;
												}
												else if (this.MyBento.Tranquil)
												{
													this.Sedated = true;
												}
												else if (this.MyBento.Headache)
												{
													Debug.Log(this.Name + "'s bento contains headache medicine.");
													this.Headache = true;
												}
												this.Distracted = true;
												this.Alarm = 0f;
												this.UpdateDetectionMarker();
											}
										}
										if (!this.Emetic && !this.Lethal && !this.Sedated && !this.Headache)
										{
											this.CharacterAnimation.CrossFade(this.EatAnim);
											if (this.FollowTarget != null && ((this.FollowTarget.CurrentAction != StudentActionType.SitAndEatBento && !this.FollowTarget.Dying) || this.Clock.HourTime > 13.375f))
											{
												if (this.FollowTarget.Alive)
												{
													Debug.Log("Osana is no longer eating, so Raibaru is now following Osana.");
													this.CharacterAnimation.CrossFade(this.WalkAnim);
													this.EmptyHands();
													this.Pathfinding.canSearch = true;
													this.Pathfinding.canMove = true;
													ScheduleBlock scheduleBlock6 = this.ScheduleBlocks[4];
													scheduleBlock6.destination = "Follow";
													scheduleBlock6.action = "Follow";
													ScheduleBlock scheduleBlock7 = this.ScheduleBlocks[5];
													scheduleBlock7.destination = "Follow";
													scheduleBlock7.action = "Follow";
													this.GetDestinations();
													this.Pathfinding.target = this.FollowTarget.transform;
													this.CurrentDestination = this.FollowTarget.transform;
													return;
												}
												this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 5, 10f);
												this.RaibaruOsanaDeathScheduleChanges();
												this.RaibaruStopsFollowingOsana();
												this.GetDestinations();
												this.CurrentDestination = this.Destinations[this.Phase];
												this.Pathfinding.target = this.Destinations[this.Phase];
												return;
											}
										}
										else if (this.Emetic)
										{
											if (!this.Private)
											{
												this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
												this.CharacterAnimation.CrossFade(this.EmeticAnim);
												this.Distracted = true;
												this.Private = true;
												this.CanTalk = false;
											}
											if (this.CharacterAnimation[this.EmeticAnim].time >= 16f)
											{
												if (this.StudentID == 10)
												{
													if (this.VomitPhase < 0)
													{
														this.Subtitle.UpdateLabel(SubtitleType.ObstaclePoisonReaction, 0, 9f);
														this.VomitPhase++;
													}
												}
												else if (this.StudentID == 11 && this.Follower != null)
												{
													this.StudentManager.LastKnownOsana.position = base.transform.position;
												}
											}
											if (this.CharacterAnimation[this.EmeticAnim].time >= this.CharacterAnimation[this.EmeticAnim].length)
											{
												Debug.Log(this.Name + " has ingested emetic poison, and should be going to a toilet.");
												this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
												if (this.Male)
												{
													this.WalkAnim = "stomachPainWalk_00";
													this.StudentManager.GetMaleVomitSpot(this);
													this.Pathfinding.target = this.StudentManager.MaleVomitSpot;
													this.CurrentDestination = this.StudentManager.MaleVomitSpot;
												}
												else
												{
													this.WalkAnim = "f02_stomachPainWalk_00";
													this.StudentManager.GetFemaleVomitSpot(this);
													this.Pathfinding.target = this.StudentManager.FemaleVomitSpot;
													this.CurrentDestination = this.StudentManager.FemaleVomitSpot;
												}
												if (this.StudentID == 10)
												{
													this.Pathfinding.target = this.StudentManager.AltFemaleVomitSpot;
													this.CurrentDestination = this.StudentManager.AltFemaleVomitSpot;
													this.VomitDoor = this.StudentManager.AltFemaleVomitDoor;
												}
												this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
												this.CharacterAnimation.CrossFade(this.WalkAnim);
												this.DistanceToDestination = 100f;
												this.Pathfinding.canSearch = true;
												this.Pathfinding.canMove = true;
												this.Pathfinding.speed = 2f;
												this.MyBento.Tampered = false;
												this.Vomiting = true;
												this.Routine = false;
												this.Chopsticks[0].SetActive(false);
												this.Chopsticks[1].SetActive(false);
												this.Bento.SetActive(false);
												return;
											}
										}
										else if (this.Lethal)
										{
											if (!this.Private)
											{
												AudioSource component = base.GetComponent<AudioSource>();
												component.clip = this.PoisonDeathClip;
												component.Play();
												if (this.Male)
												{
													this.CharacterAnimation.CrossFade("poisonDeath_00");
													this.PoisonDeathAnim = "poisonDeath_00";
												}
												else
												{
													this.CharacterAnimation.CrossFade("f02_poisonDeath_00");
													this.PoisonDeathAnim = "f02_poisonDeath_00";
													this.Distracted = true;
												}
												this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
												this.MyRenderer.updateWhenOffscreen = true;
												this.Ragdoll.Poisoned = true;
												this.Private = true;
												this.Prompt.Hide();
												this.Prompt.enabled = false;
											}
											else if (this.StudentID == 11 && this.StudentManager.Students[1] != null && !this.StudentManager.Students[1].SenpaiWitnessingRivalDie && Vector3.Distance(base.transform.position, this.StudentManager.Students[1].transform.position) < 2f)
											{
												Debug.Log("Setting ''SenpaiWitnessingRivalDie'' to true.");
												this.StudentManager.Students[1].CharacterAnimation.CrossFade("witnessPoisoning_00");
												this.StudentManager.Students[1].CurrentDestination = this.StudentManager.LunchSpots.List[1];
												this.StudentManager.Students[1].Pathfinding.target = this.StudentManager.LunchSpots.List[1];
												this.StudentManager.Students[1].MyRenderer.updateWhenOffscreen = true;
												this.StudentManager.Students[1].SenpaiWitnessingRivalDie = true;
												this.StudentManager.Students[1].Distracted = true;
												this.StudentManager.Students[1].Routine = false;
											}
											if (!this.Distracted && this.CharacterAnimation[this.PoisonDeathAnim].time >= 2.5f)
											{
												this.Distracted = true;
											}
											if (this.CharacterAnimation[this.PoisonDeathAnim].time >= 17.5f && this.Bento.activeInHierarchy)
											{
												this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
												this.Police.Corpses++;
												GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
												this.MapMarker.gameObject.layer = 10;
												base.tag = "Blood";
												this.Ragdoll.ChokingAnimation = true;
												this.Ragdoll.Disturbing = true;
												this.Ragdoll.Choking = true;
												this.Dying = true;
												this.MurderSuicidePhase = 100;
												this.SpawnAlarmDisc();
												Debug.Log(this.Name + " just spawned an 'AlarmDisc'.");
												this.Chopsticks[0].SetActive(false);
												this.Chopsticks[1].SetActive(false);
												this.Bento.SetActive(false);
											}
											if (this.CharacterAnimation[this.PoisonDeathAnim].time >= this.CharacterAnimation[this.PoisonDeathAnim].length)
											{
												this.BecomeRagdoll();
												this.DeathType = DeathType.Poison;
												this.Ragdoll.Choking = false;
												if (this.StudentManager.Students[1].SenpaiWitnessingRivalDie)
												{
													this.Ragdoll.Prompt.Hide();
													this.Ragdoll.Prompt.enabled = false;
													return;
												}
											}
										}
										else if (this.Sedated)
										{
											if (!this.Private)
											{
												this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
												this.CharacterAnimation.CrossFade(this.HeadacheAnim);
												this.CanTalk = false;
												this.Private = true;
											}
											if (this.CharacterAnimation[this.HeadacheAnim].time >= this.CharacterAnimation[this.HeadacheAnim].length)
											{
												this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
												if (this.Male)
												{
													this.SprintAnim = "headacheWalk_00";
													this.RelaxAnim = "infirmaryRest_00";
												}
												else
												{
													this.SprintAnim = "f02_headacheWalk_00";
													this.RelaxAnim = "f02_infirmaryRest_00";
												}
												this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
												this.CharacterAnimation.CrossFade(this.SprintAnim);
												this.DistanceToDestination = 100f;
												this.Pathfinding.canSearch = true;
												this.Pathfinding.canMove = true;
												this.Pathfinding.speed = 2f;
												this.MyBento.Tampered = false;
												this.Distracted = true;
												this.Private = true;
												this.Sleepy = true;
												ScheduleBlock scheduleBlock8 = this.ScheduleBlocks[4];
												scheduleBlock8.destination = "InfirmaryBed";
												scheduleBlock8.action = "Relax";
												this.Oversleep();
												this.GetDestinations();
												this.CurrentDestination = this.Destinations[this.Phase];
												this.Pathfinding.target = this.Destinations[this.Phase];
												this.Chopsticks[0].SetActive(false);
												this.Chopsticks[1].SetActive(false);
												this.Bento.SetActive(false);
												return;
											}
										}
										else if (this.Headache)
										{
											if (!this.Private)
											{
												this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
												this.CharacterAnimation.CrossFade(this.HeadacheAnim);
												this.CanTalk = false;
												this.Private = true;
											}
											if (this.CharacterAnimation[this.HeadacheAnim].time >= this.CharacterAnimation[this.HeadacheAnim].length)
											{
												this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
												if (this.Male)
												{
													this.SprintAnim = "headacheWalk_00";
													this.IdleAnim = "headacheIdle_00";
												}
												else
												{
													this.SprintAnim = "f02_headacheWalk_00";
													this.IdleAnim = "f02_headacheIdle_00";
												}
												this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
												this.CharacterAnimation.CrossFade(this.SprintAnim);
												this.DistanceToDestination = 100f;
												this.Pathfinding.canSearch = true;
												this.Pathfinding.canMove = true;
												this.Pathfinding.speed = 2f;
												this.MyBento.Tampered = false;
												this.SeekingMedicine = true;
												this.Routine = false;
												this.Private = true;
												this.Chopsticks[0].SetActive(false);
												this.Chopsticks[1].SetActive(false);
												this.Bento.SetActive(false);
												return;
											}
										}
									}
								}
								else if (this.Actions[this.Phase] == StudentActionType.ChangeShoes)
								{
									if (this.MeetTime != 0f)
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
										return;
									}
									if ((this.StudentID == 1 && !this.StudentManager.LoveManager.ConfessToSuitor && this.StudentManager.LoveManager.LeftNote) || (this.StudentID == this.StudentManager.LoveManager.SuitorID && this.StudentManager.LoveManager.ConfessToSuitor && this.StudentManager.LoveManager.LeftNote))
									{
										this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
										this.CharacterAnimation.CrossFade("keepNote_00");
										this.Pathfinding.canSearch = false;
										this.Pathfinding.canMove = false;
										this.Confessing = true;
										this.CanTalk = false;
										this.Routine = false;
										return;
									}
									this.SmartPhone.SetActive(false);
									this.Pathfinding.canSearch = false;
									this.Pathfinding.canMove = false;
									this.ShoeRemoval.enabled = true;
									this.CanTalk = false;
									this.Routine = false;
									this.ShoeRemoval.LeavingSchool();
									return;
								}
								else
								{
									if (this.Actions[this.Phase] == StudentActionType.GradePapers)
									{
										this.CharacterAnimation.CrossFade("f02_deskWrite");
										this.GradingPaper.Writing = true;
										this.Obstacle.enabled = true;
										this.Pen.SetActive(true);
										return;
									}
									if (this.Actions[this.Phase] == StudentActionType.Patrol)
									{
										if (this.PatrolAnim == "")
										{
											this.PatrolAnim = this.IdleAnim;
										}
										if (this.StudentID == 1 && this.ExtraBento && this.CurrentDestination == this.StudentManager.Patrols.List[this.StudentID].GetChild(0))
										{
											this.StudentManager.MondayBento.SetActive(true);
											this.ExtraBento = false;
											if (this.Infatuated)
											{
												Debug.Log("Senpai is now changing his routine to go stalk the gravure idol.");
												this.StudentManager.FollowGravureIdol(1);
												this.CurrentDestination = this.StudentManager.Students[19].transform;
												this.Pathfinding.target = this.StudentManager.Students[19].transform;
											}
										}
										this.PatrolTimer += Time.deltaTime * this.CharacterAnimation[this.PatrolAnim].speed;
										if (this.StudentManager.Eighties && this.StudentID == 13)
										{
											if (this.PatrolID == 0)
											{
												this.PatrolAnim = this.BookReadAnim;
												this.OccultBook.SetActive(true);
											}
											else
											{
												this.PatrolAnim = this.ThinkAnim;
											}
										}
										if (this.StudentID == 1)
										{
											if (this.PatrolID == 0)
											{
												if (this.StudentManager.Gift.activeInHierarchy || this.StudentManager.Note.activeInHierarchy)
												{
													this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
													this.CharacterAnimation.CrossFade(this.InspectBloodAnim);
													if (this.CharacterAnimation[this.InspectBloodAnim].time >= this.CharacterAnimation[this.InspectBloodAnim].length)
													{
														this.StudentManager.Gift.SetActive(false);
														this.StudentManager.Note.SetActive(false);
													}
												}
												else
												{
													this.CharacterAnimation.CrossFade(this.PatrolAnim);
												}
											}
											else
											{
												this.CharacterAnimation.CrossFade(this.PatrolAnim);
											}
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.PatrolAnim);
										}
										if (this.PatrolTimer >= this.CharacterAnimation[this.PatrolAnim].length)
										{
											this.PatrolID++;
											if (this.PatrolID == this.StudentManager.Patrols.List[this.StudentID].childCount)
											{
												this.PatrolID = 0;
											}
											this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
											this.Pathfinding.target = this.CurrentDestination;
											this.OccultBook.SetActive(false);
											this.PatrolTimer = 0f;
										}
										if (this.Restless)
										{
											this.SewTimer += Time.deltaTime;
											if (this.SewTimer > 20f)
											{
												this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
												ScheduleBlock scheduleBlock9 = this.ScheduleBlocks[this.Phase];
												scheduleBlock9.destination = "Sketch";
												scheduleBlock9.action = "Sketch";
												this.GetDestinations();
												this.CurrentDestination = this.SketchPosition;
												this.Pathfinding.target = this.SketchPosition;
												this.SewTimer = 0f;
												return;
											}
										}
									}
									else if (this.Actions[this.Phase] == StudentActionType.Read)
									{
										if (this.ReadPhase == 0)
										{
											if (this.StudentID == 5)
											{
												this.HorudaCollider.gameObject.SetActive(true);
											}
											this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
											this.CharacterAnimation.CrossFade(this.BookSitAnim);
											if (this.CharacterAnimation[this.BookSitAnim].time > this.CharacterAnimation[this.BookSitAnim].length)
											{
												this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
												this.CharacterAnimation.CrossFade(this.BookReadAnim);
												this.ReadPhase++;
												return;
											}
											if (this.CharacterAnimation[this.BookSitAnim].time > 1f)
											{
												this.OccultBook.SetActive(true);
												return;
											}
										}
									}
									else if (this.Actions[this.Phase] == StudentActionType.Texting)
									{
										this.CharacterAnimation.CrossFade("f02_midoriTexting_00");
										if (this.SmartPhone.transform.localPosition.x != 0.02f)
										{
											this.SmartPhone.transform.localPosition = new Vector3(0.02f, -0.0075f, 0f);
											this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, -164f);
										}
										if (!this.SmartPhone.activeInHierarchy && base.transform.position.y > 11f)
										{
											this.SmartPhone.SetActive(true);
											return;
										}
									}
									else
									{
										if (this.Actions[this.Phase] == StudentActionType.Mourn)
										{
											this.CharacterAnimation.CrossFade("f02_brokenSit_00");
											return;
										}
										if (this.Actions[this.Phase] == StudentActionType.Cuddle)
										{
											if (Vector3.Distance(base.transform.position, this.Partner.transform.position) < 1f && this.Partner.Routine)
											{
												ParticleSystem.EmissionModule emission = this.Hearts.emission;
												if (!emission.enabled)
												{
													this.Hearts.Play();
													emission.enabled = true;
													if (!this.Male)
													{
														this.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
													}
													else
													{
														this.Cosmetic.MyRenderer.materials[this.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
													}
												}
												this.CharacterAnimation.CrossFade(this.CuddleAnim);
												return;
											}
											this.CharacterAnimation.CrossFade(this.IdleAnim);
											return;
										}
										else if (this.Actions[this.Phase] == StudentActionType.Teaching)
										{
											if (this.Clock.Period != 2 && this.Clock.Period != 4)
											{
												this.CharacterAnimation.CrossFade("f02_teacherPodium_00");
												return;
											}
											if (!this.SpeechLines.isPlaying)
											{
												this.SpeechLines.Play();
											}
											this.CharacterAnimation.CrossFade(this.TeachAnim);
											return;
										}
										else if (this.Actions[this.Phase] == StudentActionType.SearchPatrol)
										{
											if (this.PatrolID == 0 && this.StudentManager.CommunalLocker.RivalPhone.gameObject.activeInHierarchy && !this.EndSearch)
											{
												if (this.Rival)
												{
													this.LewdPhotos = this.StudentManager.CommunalLocker.RivalPhone.LewdPhotos;
													if (DateGlobals.Weekday == DayOfWeek.Monday)
													{
														SchemeGlobals.SetSchemeStage(1, 8);
														this.Yandere.PauseScreen.Schemes.UpdateInstructions();
													}
												}
												this.CharacterAnimation.CrossFade(this.DiscoverPhoneAnim);
												this.Subtitle.UpdateLabel(this.LostPhoneSubtitleType, 2, 5f);
												this.Phoneless = false;
												this.EndSearch = true;
												this.Routine = false;
											}
											if (!this.EndSearch)
											{
												this.PatrolTimer += Time.deltaTime * this.CharacterAnimation[this.PatrolAnim].speed;
												this.CharacterAnimation.CrossFade(this.SearchPatrolAnim);
												if (this.PatrolTimer >= this.CharacterAnimation[this.SearchPatrolAnim].length)
												{
													this.PatrolID++;
													if (this.PatrolID == this.StudentManager.SearchPatrols.List[this.Class].childCount)
													{
														this.PatrolID = 0;
													}
													this.CurrentDestination = this.StudentManager.SearchPatrols.List[this.Class].GetChild(this.PatrolID);
													this.Pathfinding.target = this.CurrentDestination;
													this.DistanceToDestination = 100f;
													this.PatrolTimer = 0f;
													return;
												}
											}
										}
										else
										{
											if (this.Actions[this.Phase] == StudentActionType.Wait)
											{
												this.CharacterAnimation.CrossFade(this.IdleAnim);
												return;
											}
											if (this.Actions[this.Phase] == StudentActionType.LightCig)
											{
												if (!this.Cigarette.active)
												{
													this.WaitAnim = "f02_smokeAttempt_00";
													this.SmartPhone.SetActive(false);
													this.Cigarette.SetActive(true);
													this.Lighter.SetActive(true);
												}
												this.CharacterAnimation.CrossFade(this.WaitAnim);
												return;
											}
											if (this.Actions[this.Phase] == StudentActionType.Random)
											{
												this.CurrentDestination.transform.position = this.StudentManager.PossibleRandomSpots[UnityEngine.Random.Range(1, 11)].position;
												return;
											}
											if (this.Actions[this.Phase] == StudentActionType.Clean)
											{
												this.CleanTimer += Time.deltaTime;
												if (this.CleaningRole == 5)
												{
													if (this.CleanID == 0)
													{
														this.CharacterAnimation.CrossFade(this.CleanAnims[1]);
													}
													else
													{
														if (!this.StudentManager.RoofFenceUp)
														{
															this.Prompt.Label[0].text = "     Push";
															this.Prompt.HideButton[0] = false;
															this.Pushable = true;
														}
														this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
														if ((double)this.CleanTimer >= 1.166666 && (double)this.CleanTimer <= 6.166666 && !this.ChalkDust.isPlaying)
														{
															this.ChalkDust.Play();
														}
													}
												}
												else if (this.CleaningRole == 4)
												{
													this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
													if (!this.Drownable)
													{
														this.Drownable = true;
														this.StudentManager.UpdateMe(this.StudentID);
													}
												}
												else
												{
													this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
												}
												if (this.CleanTimer >= this.CharacterAnimation[this.CleanAnims[this.CleaningRole]].length)
												{
													this.CleanID++;
													if (this.CleanID == this.CleaningSpot.childCount)
													{
														this.CleanID = 0;
													}
													this.CurrentDestination = this.CleaningSpot.GetChild(this.CleanID);
													this.Pathfinding.target = this.CurrentDestination;
													this.DistanceToDestination = 100f;
													this.CleanTimer = 0f;
													if (this.Pushable)
													{
														this.Prompt.Label[0].text = "     Talk";
														this.Pushable = false;
													}
													if (this.Drownable)
													{
														this.Drownable = false;
														this.StudentManager.UpdateMe(this.StudentID);
														return;
													}
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Graffiti)
											{
												if (this.KilledMood)
												{
													this.Subtitle.UpdateLabel(SubtitleType.KilledMood, 0, 5f);
													this.GraffitiPhase = 4;
													this.KilledMood = false;
												}
												if (this.GraffitiPhase == 0)
												{
													AudioSource.PlayClipAtPoint(this.BullyGiggles[UnityEngine.Random.Range(0, this.BullyGiggles.Length)], this.Head.position);
													this.CharacterAnimation.CrossFade("f02_bullyDesk_00");
													this.SmartPhone.SetActive(false);
													this.GraffitiPhase++;
													return;
												}
												if (this.GraffitiPhase == 1)
												{
													if (this.CharacterAnimation["f02_bullyDesk_00"].time >= 8f)
													{
														this.StudentManager.Graffiti[this.BullyID].SetActive(true);
														this.GraffitiPhase++;
														return;
													}
												}
												else if (this.GraffitiPhase == 2)
												{
													if (this.CharacterAnimation["f02_bullyDesk_00"].time >= 9.66666f)
													{
														AudioSource.PlayClipAtPoint(this.BullyGiggles[UnityEngine.Random.Range(0, this.BullyGiggles.Length)], this.Head.position);
														this.GraffitiPhase++;
														return;
													}
												}
												else if (this.GraffitiPhase == 3)
												{
													if (this.CharacterAnimation["f02_bullyDesk_00"].time >= this.CharacterAnimation["f02_bullyDesk_00"].length)
													{
														this.GraffitiPhase++;
														return;
													}
												}
												else if (this.GraffitiPhase == 4)
												{
													this.DistanceToDestination = 100f;
													ScheduleBlock scheduleBlock10 = this.ScheduleBlocks[2];
													scheduleBlock10.destination = "Patrol";
													scheduleBlock10.action = "Patrol";
													this.GetDestinations();
													if (!this.StudentManager.Eighties)
													{
														if (this.StudentID == 82)
														{
															this.StudentManager.UpdateWeek1Hangout(82);
														}
														else if (this.StudentID == 83)
														{
															this.StudentManager.UpdateWeek1Hangout(83);
														}
													}
													this.CurrentDestination = this.Destinations[this.Phase];
													this.Pathfinding.target = this.Destinations[this.Phase];
													this.SmartPhone.SetActive(true);
													return;
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Bully)
											{
												this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
												if (!(this.StudentManager.Students[this.StudentManager.VictimID] != null))
												{
													this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
													this.DistanceToDestination = 100f;
													ScheduleBlock scheduleBlock11 = this.ScheduleBlocks[4];
													scheduleBlock11.destination = "Patrol";
													scheduleBlock11.action = "Patrol";
													this.GetDestinations();
													this.CurrentDestination = this.Destinations[this.Phase];
													this.Pathfinding.target = this.Destinations[this.Phase];
													this.SmartPhone.SetActive(true);
													return;
												}
												if (this.StudentManager.Students[this.StudentManager.VictimID].Distracted || this.StudentManager.Students[this.StudentManager.VictimID].Tranquil)
												{
													this.StudentManager.NoBully[this.BullyID] = true;
													this.KilledMood = true;
												}
												if (this.KilledMood)
												{
													this.Subtitle.UpdateLabel(SubtitleType.KilledMood, 0, 5f);
													this.BullyPhase = 4;
													this.KilledMood = false;
													this.BullyDust.Stop();
												}
												if (this.StudentManager.Students[81] == null)
												{
													ScheduleBlock scheduleBlock12 = this.ScheduleBlocks[4];
													scheduleBlock12.destination = "Patrol";
													scheduleBlock12.action = "Patrol";
													this.GetDestinations();
													this.CurrentDestination = this.Destinations[this.Phase];
													this.Pathfinding.target = this.Destinations[this.Phase];
													return;
												}
												this.SmartPhone.SetActive(false);
												if (this.BullyID == 1)
												{
													if (this.BullyPhase == 0)
													{
														this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
														this.Scrubber.SetActive(true);
														this.Eraser.SetActive(true);
														this.StudentManager.Students[this.StudentManager.VictimID].CharacterAnimation.CrossFade(this.StudentManager.Students[this.StudentManager.VictimID].BullyVictimAnim);
														this.StudentManager.Students[this.StudentManager.VictimID].Routine = false;
														this.CharacterAnimation.CrossFade("f02_bullyEraser_00");
														this.BullyPhase++;
														return;
													}
													if (this.BullyPhase == 1)
													{
														if (this.CharacterAnimation["f02_bullyEraser_00"].time >= 0.833333f)
														{
															this.BullyDust.Play();
															this.BullyPhase++;
															return;
														}
													}
													else if (this.BullyPhase == 2)
													{
														if (this.CharacterAnimation["f02_bullyEraser_00"].time >= this.CharacterAnimation["f02_bullyEraser_00"].length)
														{
															AudioSource.PlayClipAtPoint(this.BullyLaughs[this.BullyID], this.Head.position);
															this.CharacterAnimation.CrossFade("f02_bullyLaugh_00");
															this.Scrubber.SetActive(false);
															this.Eraser.SetActive(false);
															this.BullyPhase++;
															return;
														}
													}
													else if (this.BullyPhase == 3)
													{
														if (this.CharacterAnimation["f02_bullyLaugh_00"].time >= this.CharacterAnimation["f02_bullyLaugh_00"].length)
														{
															this.BullyPhase++;
															return;
														}
													}
													else if (this.BullyPhase == 4)
													{
														this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
														this.StudentManager.Students[this.StudentManager.VictimID].Routine = true;
														ScheduleBlock scheduleBlock13 = this.ScheduleBlocks[4];
														scheduleBlock13.destination = "Patrol";
														scheduleBlock13.action = "Patrol";
														this.GetDestinations();
														if (!this.StudentManager.Eighties)
														{
															if (this.StudentID == 82)
															{
																this.StudentManager.UpdateLunchtimeHangout(82);
															}
															else if (this.StudentID == 83)
															{
																this.StudentManager.UpdateLunchtimeHangout(83);
															}
														}
														this.CurrentDestination = this.Destinations[this.Phase];
														this.Pathfinding.target = this.Destinations[this.Phase];
														this.SmartPhone.SetActive(true);
														this.Scrubber.SetActive(false);
														this.Eraser.SetActive(false);
														return;
													}
												}
												else
												{
													if (this.StudentManager.Students[81].BullyPhase < 2)
													{
														if (this.GiggleTimer == 0f)
														{
															AudioSource.PlayClipAtPoint(this.BullyGiggles[UnityEngine.Random.Range(0, this.BullyGiggles.Length)], this.Head.position);
															this.GiggleTimer = 5f;
														}
														this.GiggleTimer = Mathf.MoveTowards(this.GiggleTimer, 0f, Time.deltaTime);
														this.CharacterAnimation.CrossFade("f02_bullyGiggle_00");
													}
													else if (this.StudentManager.Students[81].BullyPhase < 4)
													{
														if (this.LaughTimer == 0f)
														{
															AudioSource.PlayClipAtPoint(this.BullyLaughs[this.BullyID], this.Head.position);
															this.LaughTimer = 5f;
														}
														this.LaughTimer = Mathf.MoveTowards(this.LaughTimer, 0f, Time.deltaTime);
														this.CharacterAnimation.CrossFade("f02_bullyLaugh_00");
													}
													if (this.CharacterAnimation["f02_bullyLaugh_00"].time >= this.CharacterAnimation["f02_bullyLaugh_00"].length || this.StudentManager.Students[81].BullyPhase == 4 || this.BullyPhase == 4)
													{
														this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
														this.DistanceToDestination = 100f;
														ScheduleBlock scheduleBlock14 = this.ScheduleBlocks[4];
														scheduleBlock14.destination = "Patrol";
														scheduleBlock14.action = "Patrol";
														this.GetDestinations();
														this.CurrentDestination = this.Destinations[this.Phase];
														this.Pathfinding.target = this.Destinations[this.Phase];
														this.SmartPhone.SetActive(true);
														return;
													}
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Follow)
											{
												if (!(this.FollowTarget != null))
												{
													this.CharacterAnimation.CrossFade(this.IdleAnim);
													return;
												}
												if (this.FollowTarget.Routine && !this.FollowTarget.InEvent && this.FollowTarget.CurrentAction == StudentActionType.Clean && this.FollowTarget.DistanceToDestination < 1f)
												{
													this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
													this.Scrubber.SetActive(true);
													return;
												}
												if (this.FollowTarget.Routine && !this.FollowTarget.InEvent && !this.FollowTarget.Meeting && this.FollowTarget.gameObject.activeInHierarchy && this.FollowTarget.CurrentAction == StudentActionType.Socializing && this.FollowTarget.DistanceToDestination < 1f)
												{
													if (this.FollowTarget.Alone || this.FollowTarget.Meeting)
													{
														this.CharacterAnimation.CrossFade(this.IdleAnim);
														this.SpeechLines.Stop();
														return;
													}
													this.Scrubber.SetActive(false);
													this.SpeechLines.Play();
													this.CharacterAnimation.CrossFade(this.RandomAnim);
													if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
													{
														this.PickRandomAnim();
														return;
													}
												}
												else
												{
													if (this.FollowTarget.CurrentAction == StudentActionType.SitAndTakeNotes && this.FollowTarget.Routine && !this.FollowTarget.InEvent && this.FollowTarget.DistanceToDestination < 1f && !this.FollowTarget.Meeting && this.Clock.HourTime < 15.5f)
													{
														Debug.Log("Raibaru just changed her destination to class.");
														this.GoToClass();
														return;
													}
													if (this.FollowTarget.Routine && !this.FollowTarget.InEvent && this.FollowTarget.CurrentAction == StudentActionType.SitAndEatBento && this.FollowTarget.DistanceToDestination < 1f)
													{
														Debug.Log("Raibaru just changed her destination to lunch.");
														ScheduleBlock scheduleBlock15 = this.ScheduleBlocks[this.Phase];
														scheduleBlock15.destination = "LunchSpot";
														scheduleBlock15.action = "SitAndEatBento";
														this.Actions[this.Phase] = StudentActionType.SitAndEatBento;
														this.CurrentAction = StudentActionType.SitAndEatBento;
														this.GetDestinations();
														this.CurrentDestination = this.Destinations[this.Phase];
														this.Pathfinding.target = this.Destinations[this.Phase];
														return;
													}
													if (this.FollowTarget.Routine && !this.FollowTarget.InEvent && this.FollowTarget.Phase == 8 && this.FollowTarget.DistanceToDestination < 1f)
													{
														Debug.Log("Raibaru just changed her destination to the lockers.");
														ScheduleBlock scheduleBlock16 = this.ScheduleBlocks[this.Phase];
														scheduleBlock16.destination = "Locker";
														scheduleBlock16.action = "Shoes";
														this.Actions[this.Phase] = StudentActionType.ChangeShoes;
														this.CurrentAction = StudentActionType.ChangeShoes;
														this.GetDestinations();
														this.CurrentDestination = this.Destinations[this.Phase];
														this.Pathfinding.target = this.Destinations[this.Phase];
														return;
													}
													if (this.StudentManager.LoveManager.RivalWaiting && this.FollowTarget.transform.position.x > 40f && this.FollowTarget.DistanceToDestination < 1f)
													{
														this.CurrentDestination = this.StudentManager.LoveManager.FriendWaitSpot;
														this.Pathfinding.target = this.StudentManager.LoveManager.FriendWaitSpot;
														this.CharacterAnimation.CrossFade(this.IdleAnim);
														return;
													}
													if (this.FollowTarget.ConfessPhase == 5)
													{
														Debug.Log("Raibaru just changed her action to Sketch and her destination to Paint.");
														ScheduleBlock scheduleBlock17 = this.ScheduleBlocks[this.Phase];
														scheduleBlock17.destination = "Paint";
														scheduleBlock17.action = "Sketch";
														scheduleBlock17.time = 99f;
														this.GetDestinations();
														this.CurrentDestination = this.Destinations[this.Phase];
														this.Pathfinding.target = this.Destinations[this.Phase];
														this.TargetDistance = 1f;
														this.MyController.radius = 0.1f;
														return;
													}
													this.CharacterAnimation.CrossFade(this.IdleAnim);
													this.SpeechLines.Stop();
													if (this.SlideIn)
													{
														this.MoveTowardsTarget(this.CurrentDestination.position);
													}
													if (!this.FollowTarget.gameObject.activeInHierarchy || !this.FollowTarget.enabled)
													{
														this.RaibaruCannotFindOsana();
														return;
													}
													this.CharacterAnimation.CrossFade(this.IdleAnim);
													return;
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Sulk)
											{
												if (this.StudentID == 51)
												{
													this.CharacterAnimation.CrossFade("f02_railingSulk_0" + this.SulkPhase.ToString(), 1f);
													this.SulkTimer += Time.deltaTime;
													if (this.SulkTimer > 7.66666f)
													{
														this.SulkTimer = 0f;
														this.SulkPhase++;
														if (this.SulkPhase == 3)
														{
															this.SulkPhase = 0;
															return;
														}
													}
												}
												else
												{
													this.CharacterAnimation.CrossFade(this.SulkAnim);
													if (this.StudentID == 76 && this.Clock.Day == 4)
													{
														this.BountyCollider.SetActive(true);
														return;
													}
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Sleuth)
											{
												if (this.StudentManager.SleuthPhase != 3)
												{
													this.StudentManager.ConvoManager.CheckMe(this.StudentID);
													if (this.Alone)
													{
														if (this.Male)
														{
															this.CharacterAnimation.CrossFade("standTexting_00");
														}
														else
														{
															this.CharacterAnimation.CrossFade("f02_standTexting_00");
														}
														if (this.Male)
														{
															this.SmartPhone.transform.localPosition = new Vector3(0.025f, 0.0025f, 0.025f);
															this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 180f);
														}
														else
														{
															this.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.01f, 0.01f);
															this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
														}
														this.SmartPhone.SetActive(true);
														this.SpeechLines.Stop();
														return;
													}
													if (!this.SpeechLines.isPlaying)
													{
														this.SmartPhone.SetActive(false);
														this.SpeechLines.Play();
													}
													this.CharacterAnimation.CrossFade(this.RandomSleuthAnim, 1f);
													if (this.CharacterAnimation[this.RandomSleuthAnim].time >= this.CharacterAnimation[this.RandomSleuthAnim].length)
													{
														this.PickRandomSleuthAnim();
													}
													this.StudentManager.SleuthTimer += Time.deltaTime;
													if (this.StudentManager.SleuthTimer > 100f)
													{
														this.StudentManager.SleuthTimer = 0f;
														this.StudentManager.UpdateSleuths();
														return;
													}
												}
												else
												{
													this.CharacterAnimation.CrossFade(this.SleuthScanAnim);
													if (this.CharacterAnimation[this.SleuthScanAnim].time >= this.CharacterAnimation[this.SleuthScanAnim].length)
													{
														this.GetSleuthTarget();
														return;
													}
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Stalk)
											{
												this.CharacterAnimation.CrossFade(this.SleuthIdleAnim);
												if (this.DistanceToPlayer < 5f || this.StudentManager.LockerRoomArea.bounds.Contains(this.Yandere.transform.position))
												{
													if (Vector3.Distance(base.transform.position, this.StudentManager.FleeSpots[0].position) > 10f)
													{
														this.Pathfinding.target = this.StudentManager.FleeSpots[0];
														this.CurrentDestination = this.StudentManager.FleeSpots[0];
													}
													else
													{
														this.Pathfinding.target = this.StudentManager.FleeSpots[1];
														this.CurrentDestination = this.StudentManager.FleeSpots[1];
													}
													this.Pathfinding.speed = 4f;
													this.StalkerFleeing = true;
													return;
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Sketch)
											{
												this.CharacterAnimation.CrossFade(this.SketchAnim);
												this.Sketchbook.SetActive(true);
												this.Pencil.SetActive(true);
												if (this.Restless)
												{
													this.SewTimer += Time.deltaTime;
													if (this.SewTimer > 20f)
													{
														this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
														ScheduleBlock scheduleBlock18 = this.ScheduleBlocks[this.Phase];
														scheduleBlock18.destination = "Patrol";
														scheduleBlock18.action = "Patrol";
														this.GetDestinations();
														this.EmptyHands();
														this.PatrolID = 1;
														this.PatrolTimer = 0f;
														this.CharacterAnimation[this.PatrolAnim].time = 0f;
														this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
														this.Pathfinding.target = this.CurrentDestination;
														this.SewTimer = 0f;
														return;
													}
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Sunbathe)
											{
												if (this.SunbathePhase == 0)
												{
													this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
													this.StudentManager.CommunalLocker.Open = true;
													this.StudentManager.CommunalLocker.SpawnSteamNoSideEffects(this);
													this.MustChangeClothing = true;
													this.ChangeClothingPhase++;
													this.SunbathePhase++;
													return;
												}
												if (this.SunbathePhase == 1)
												{
													this.CharacterAnimation.CrossFade(this.StripAnim);
													this.Pathfinding.canSearch = false;
													this.Pathfinding.canMove = false;
													if (this.CharacterAnimation[this.StripAnim].time >= 1.5f)
													{
														if (this.Schoolwear != 2)
														{
															this.Schoolwear = 2;
															this.ChangeSchoolwear();
														}
														if (this.CharacterAnimation[this.StripAnim].time > this.CharacterAnimation[this.StripAnim].length)
														{
															this.Pathfinding.canSearch = true;
															this.Pathfinding.canMove = true;
															this.Stripping = false;
															if (!this.StudentManager.CommunalLocker.SteamCountdown)
															{
																this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
																this.Destinations[this.Phase] = this.StudentManager.SunbatheSpots[this.StudentID];
																this.Pathfinding.target = this.StudentManager.SunbatheSpots[this.StudentID];
																this.CurrentDestination = this.StudentManager.SunbatheSpots[this.StudentID];
																this.StudentManager.CommunalLocker.Student = null;
																this.SunbathePhase++;
																return;
															}
														}
													}
												}
												else if (this.SunbathePhase == 2)
												{
													if (this.Rival && this.StudentManager.PoolClosed)
													{
														this.Subtitle.CustomText = "I can't believe anyone would let a stupid sign stop them from sunbathing...";
														this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
													}
													this.MyRenderer.updateWhenOffscreen = true;
													this.CharacterAnimation.CrossFade("f02_sunbatheStart_00");
													this.SmartPhone.SetActive(false);
													if (this.CharacterAnimation["f02_sunbatheStart_00"].time >= this.CharacterAnimation["f02_sunbatheStart_00"].length)
													{
														this.MyController.radius = 0f;
														this.SunbathePhase++;
														return;
													}
												}
												else if (this.SunbathePhase == 3)
												{
													if (this.Sleepy)
													{
														this.CharacterAnimation.CrossFade("f02_sunbatheSleep_00");
														this.Ragdoll.Zs.SetActive(true);
														this.Blind = true;
														return;
													}
													this.CharacterAnimation.CrossFade("f02_sunbatheLoop_00");
													return;
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Shock)
											{
												if (this.StudentManager.Students[36] == null)
												{
													this.Phase++;
													return;
												}
												if (this.StudentManager.Students[36].Routine && this.StudentManager.Students[36].DistanceToDestination < 1f)
												{
													if (!this.StudentManager.GamingDoor.Open)
													{
														this.StudentManager.GamingDoor.OpenDoor();
													}
													ParticleSystem.EmissionModule emission2 = this.Hearts.emission;
													if (this.SmartPhone.activeInHierarchy)
													{
														this.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
														this.SmartPhone.SetActive(false);
														this.MyController.radius = 0f;
														emission2.rateOverTime = 5f;
														emission2.enabled = true;
														this.Hearts.Play();
													}
													this.CharacterAnimation.CrossFade("f02_peeking_0" + (this.StudentID - 80).ToString());
													return;
												}
												this.CharacterAnimation.CrossFade(this.PatrolAnim);
												if (!this.SmartPhone.activeInHierarchy)
												{
													this.SmartPhone.SetActive(true);
													this.MyController.radius = 0.1f;
													if (this.BullyID == 2)
													{
														this.MyController.Move(base.transform.right * 1f * Time.timeScale * 0.2f);
														return;
													}
													if (this.BullyID == 3)
													{
														this.MyController.Move(base.transform.right * -1f * Time.timeScale * 0.2f);
														return;
													}
													if (this.BullyID == 4)
													{
														this.MyController.Move(base.transform.right * 1f * Time.timeScale * 0.2f);
														return;
													}
													if (this.BullyID == 5)
													{
														this.MyController.Move(base.transform.right * -1f * Time.timeScale * 0.2f);
														return;
													}
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Miyuki)
											{
												if (!this.StudentManager.MiyukiEnemy.Enemy.activeInHierarchy)
												{
													this.CharacterAnimation.CrossFade(this.VictoryAnim);
													this.BountyCollider.SetActive(false);
													return;
												}
												if (this.StudentID == 37 && this.Clock.Day == 1)
												{
													this.BountyCollider.SetActive(true);
												}
												this.CharacterAnimation.CrossFade(this.MiyukiAnim);
												this.MiyukiTimer += Time.deltaTime;
												if (this.MiyukiTimer > 1f)
												{
													this.MiyukiTimer = 0f;
													this.Miyuki.Shoot();
													return;
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Meeting)
											{
												if (this.StudentID == 36)
												{
													this.CharacterAnimation.CrossFade(this.PeekAnim);
													return;
												}
												this.StudentManager.Meeting = true;
												if (this.StudentManager.Speaker == this.StudentID)
												{
													if (!this.SpeechLines.isPlaying)
													{
														this.CharacterAnimation.CrossFade(this.RandomAnim);
														this.SpeechLines.Play();
														return;
													}
												}
												else
												{
													this.CharacterAnimation.CrossFade(this.IdleAnim);
													if (this.SpeechLines.isPlaying)
													{
														this.SpeechLines.Stop();
														return;
													}
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Lyrics)
											{
												this.LyricsTimer += Time.deltaTime;
												if (this.LyricsPhase == 0)
												{
													this.CharacterAnimation.CrossFade("f02_writingLyrics_00");
													if (!this.Pencil.activeInHierarchy)
													{
														this.Pencil.SetActive(true);
													}
													if (this.LyricsTimer > 18f)
													{
														this.StudentManager.LyricsSpot.position = this.StudentManager.AirGuitarSpot.position;
														this.StudentManager.LyricsSpot.eulerAngles = this.StudentManager.AirGuitarSpot.eulerAngles;
														this.Pencil.SetActive(false);
														this.LyricsPhase = 1;
														this.LyricsTimer = 0f;
														return;
													}
												}
												else
												{
													this.CharacterAnimation.CrossFade("f02_airGuitar_00");
													if (!this.AirGuitar.isPlaying)
													{
														this.AirGuitar.Play();
													}
													if (this.LyricsTimer > 18f)
													{
														this.StudentManager.LyricsSpot.position = this.StudentManager.OriginalLyricsSpot.position;
														this.StudentManager.LyricsSpot.eulerAngles = this.StudentManager.OriginalLyricsSpot.eulerAngles;
														this.AirGuitar.Stop();
														this.LyricsPhase = 0;
														this.LyricsTimer = 0f;
														return;
													}
												}
											}
											else if (this.Actions[this.Phase] == StudentActionType.Sew)
											{
												this.CharacterAnimation.CrossFade("sewing_00");
												this.PinkSeifuku.SetActive(true);
												if (this.SewTimer < 10f && this.StudentManager.TaskManager.TaskStatus[8] == 3)
												{
													this.SewTimer += Time.deltaTime;
													if (this.SewTimer > 10f)
													{
														UnityEngine.Object.Instantiate<GameObject>(this.Yandere.PauseScreen.DropsMenu.GetComponent<DropsScript>().InfoChanWindow.Drops[1], new Vector3(28.289f, 0.7718928f, 5.196f), Quaternion.identity);
														return;
													}
												}
											}
											else
											{
												if (this.Actions[this.Phase] == StudentActionType.Paint)
												{
													this.Painting.material.color += new Color(0f, 0f, 0f, Time.deltaTime * 0.00066666f);
													this.CharacterAnimation.CrossFade(this.PaintAnim);
													this.Paintbrush.SetActive(true);
													this.Palette.SetActive(true);
													return;
												}
												if (this.Actions[this.Phase] == StudentActionType.UpdateAppearance)
												{
													Debug.Log("We have reached the ''UpdateAppearance'' code.");
													this.UpdateGemaAppearance();
													return;
												}
												if (this.Actions[this.Phase] == StudentActionType.PlaceBag)
												{
													this.PlaceBag();
													return;
												}
												if (this.Actions[this.Phase] == StudentActionType.Sleep)
												{
													this.CharacterAnimation.CrossFade("f02_infirmaryRest_00");
													return;
												}
												if (this.Actions[this.Phase] == StudentActionType.LightFire)
												{
													if (this.PyroPhase == 1)
													{
														this.CharacterAnimation.CrossFade("f02_waterPlant_00");
														if (this.DistanceToPlayer < 5f && this.Yandere.transform.position.x < base.transform.position.x)
														{
															this.Subtitle.CustomText = "...oh...I didn't realize someone was here...I'll just...be going, now...";
															this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
															this.PyroPhase = 4;
															return;
														}
														if (this.CharacterAnimation["f02_waterPlant_00"].time > this.CharacterAnimation["f02_waterPlant_00"].length)
														{
															this.StudentManager.PyroFlames.Play();
															this.StudentManager.PyroFlameSounds[1].Play();
															this.StudentManager.PyroFlameSounds[2].Play();
															this.PyroPhase++;
															return;
														}
													}
													else if (this.PyroPhase == 2)
													{
														if (this.PyroTimer == 0f && this.DistanceToPlayer < 5f)
														{
															this.Subtitle.CustomText = "...hehe...it's always just as spellbinding as the first time...";
															this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
														}
														this.CharacterAnimation.CrossFade("f02_inspectLoop_00");
														this.PyroTimer += Time.deltaTime;
														if (this.PyroTimer > 60f || this.Yandere.transform.position.x < base.transform.position.x)
														{
															if (this.DistanceToPlayer < 5f)
															{
																if (this.PyroTimer < 60f)
																{
																	this.Subtitle.UpdateLabel(SubtitleType.AcceptFood, 0, 0f);
																	this.Subtitle.CustomText = "...um...oh, my! Who started this fire? How dangerous! I'd better put it out...";
																	this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
																}
																else
																{
																	this.Subtitle.CustomText = "...well, that's enough for now...";
																	this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
																}
															}
															this.StudentManager.PyroWateringCan.parent = this.RightHand;
															this.StudentManager.PyroWateringCan.localPosition = new Vector3(0.14f, -0.15f, -0.05f);
															this.StudentManager.PyroWateringCan.localEulerAngles = new Vector3(10f, 15f, 45f);
															this.PyroPhase++;
															return;
														}
													}
													else if (this.PyroPhase == 3)
													{
														this.CharacterAnimation.CrossFade("f02_waterPlant_00");
														if (this.CharacterAnimation["f02_waterPlant_00"].time > this.CharacterAnimation["f02_waterPlant_00"].length)
														{
															this.WillCombust = true;
															this.PyroPhase++;
															return;
														}
													}
													else if (this.PyroPhase == 4)
													{
														this.StudentManager.PyroWateringCan.parent = null;
														this.StudentManager.PyroWateringCan.localPosition = new Vector3(-41f, 0f, 52.5f);
														this.StudentManager.PyroWateringCan.localEulerAngles = new Vector3(0f, -90f, 0f);
														if (this.StudentManager.GasInWateringCan && this.WillCombust)
														{
															this.Combust();
															return;
														}
														this.StudentManager.PyroFlames.Stop();
														this.StudentManager.PyroFlameSounds[1].Stop();
														this.StudentManager.PyroFlameSounds[2].Stop();
														ScheduleBlock scheduleBlock19 = this.ScheduleBlocks[this.Phase];
														scheduleBlock19.destination = "Hangout";
														scheduleBlock19.action = "Socialize";
														this.GetDestinations();
														this.Pathfinding.target = this.Destinations[this.Phase];
														this.CurrentDestination = this.Destinations[this.Phase];
														this.PyroPhase = 1;
														this.PyroTimer = 0f;
														return;
													}
												}
												else if (this.Actions[this.Phase] == StudentActionType.Jog)
												{
													this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
													if (this.Schoolwear == 1)
													{
														if (this.SunbathePhase == 0)
														{
															this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
															this.StudentManager.CommunalLocker.Open = true;
															this.StudentManager.CommunalLocker.SpawnSteamNoSideEffects(this);
															this.MustChangeClothing = true;
															this.ChangeClothingPhase++;
															this.SunbathePhase++;
															return;
														}
														if (this.SunbathePhase == 1)
														{
															this.CharacterAnimation.CrossFade(this.StripAnim);
															this.Pathfinding.canSearch = false;
															this.Pathfinding.canMove = false;
															if (this.CharacterAnimation[this.StripAnim].time >= 1.5f)
															{
																if (this.Schoolwear != 3)
																{
																	this.Schoolwear = 3;
																	this.ChangeSchoolwear();
																}
																if (this.CharacterAnimation[this.StripAnim].time > this.CharacterAnimation[this.StripAnim].length)
																{
																	this.Pathfinding.canSearch = true;
																	this.Pathfinding.canMove = true;
																	this.Stripping = false;
																	if (!this.StudentManager.CommunalLocker.SteamCountdown)
																	{
																		this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
																		this.Destinations[this.Phase] = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
																		this.Pathfinding.target = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
																		this.CurrentDestination = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
																		this.StudentManager.CommunalLocker.Student = null;
																		this.SunbathePhase++;
																		return;
																	}
																}
															}
														}
													}
													else
													{
														this.CharacterAnimation.CrossFade(this.ClubAnim);
														if (this.ClubActivityPhase == 0)
														{
															if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
															{
																string str4 = "";
																if (!this.Male)
																{
																	str4 = "f02_";
																}
																this.ClubActivityPhase++;
																this.ClubAnim = str4 + "stretch_01";
																this.Destinations[this.Phase] = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
																return;
															}
														}
														else if (this.ClubActivityPhase == 1)
														{
															if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
															{
																string str5 = "";
																if (!this.Male)
																{
																	str5 = "f02_";
																}
																this.ClubActivityPhase++;
																this.ClubAnim = str5 + "stretch_02";
																this.Destinations[this.Phase] = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
																return;
															}
														}
														else if (this.ClubActivityPhase == 2)
														{
															if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
															{
																string str6 = "";
																if (!this.Male)
																{
																	str6 = "f02_";
																}
																this.WalkAnim = str6 + "trackJog_00";
																this.Hurry = true;
																this.ClubActivityPhase++;
																this.CharacterAnimation[this.ClubAnim].time = 0f;
																this.Destinations[this.Phase] = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
																this.CurrentDestination = this.Destinations[this.Phase];
																this.Pathfinding.target = this.CurrentDestination;
																this.Pathfinding.speed = 4f;
																return;
															}
														}
														else if (this.ClubActivityPhase < 14)
														{
															if (this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
															{
																this.ClubActivityPhase++;
																this.CharacterAnimation[this.ClubAnim].time = 0f;
																this.Destinations[this.Phase] = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
																this.CurrentDestination = this.Destinations[this.Phase];
																this.Pathfinding.target = this.CurrentDestination;
																return;
															}
														}
														else if (this.ClubActivityPhase == 14 && this.CharacterAnimation[this.ClubAnim].time >= this.CharacterAnimation[this.ClubAnim].length)
														{
															this.WalkAnim = this.OriginalWalkAnim;
															this.Hurry = false;
															this.ClubActivityPhase = 0;
															if (this.Male)
															{
																this.ClubAnim = "stretch_00";
															}
															else
															{
																this.ClubAnim = "f02_stretch_00";
															}
															this.Destinations[this.Phase] = this.StudentManager.Clubs.List[66].GetChild(this.ClubActivityPhase);
															this.CurrentDestination = this.Destinations[this.Phase];
															this.Pathfinding.target = this.CurrentDestination;
															return;
														}
													}
												}
												else if (this.Actions[this.Phase] == StudentActionType.PrepareFood)
												{
													if (!this.MyBento.gameObject.activeInHierarchy)
													{
														this.MyBento.Lid.SetActive(false);
														this.MyBento.Prompt.enabled = true;
														this.MyBento.transform.parent = null;
														this.MyBento.gameObject.SetActive(true);
														this.MyBento.transform.position = this.StudentManager.FoodTrays[this.StudentID].position;
														this.MyBento.transform.eulerAngles = this.StudentManager.FoodTrays[this.StudentID].eulerAngles;
													}
													this.CharacterAnimation.CrossFade(this.PrepareFoodAnim);
													this.ClubTimer += Time.deltaTime;
													if (this.ClubTimer > 60f)
													{
														this.MyBento.transform.parent = this.LeftItemParent;
														this.MyBento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
														this.MyBento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
														this.MyBento.gameObject.SetActive(false);
														this.MyBento.Prompt.enabled = false;
														this.MyBento.Prompt.Hide();
														ScheduleBlock scheduleBlock20 = this.ScheduleBlocks[this.Phase];
														scheduleBlock20.destination = "LunchSpot";
														scheduleBlock20.action = "Eat";
														this.GetDestinations();
														this.Pathfinding.target = this.Destinations[this.Phase];
														this.CurrentDestination = this.Destinations[this.Phase];
														return;
													}
												}
												else if (this.Actions[this.Phase] == StudentActionType.Perform)
												{
													this.CharacterAnimation.CrossFade(this.ClubAnim);
													if (this.StudentID == 52)
													{
														if (!this.Instruments[this.ClubMemberID].activeInHierarchy)
														{
															this.Instruments[this.ClubMemberID].SetActive(true);
															this.Instruments[this.ClubMemberID].transform.parent = this.Spine;
															this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
															this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
															return;
														}
													}
													else if (this.StudentID == 53)
													{
														if (!this.Instruments[this.ClubMemberID].activeInHierarchy)
														{
															this.Instruments[this.ClubMemberID].SetActive(true);
															this.Instruments[this.ClubMemberID].transform.parent = this.Spine;
															this.Instruments[this.ClubMemberID].transform.localPosition = new Vector3(0.275f, -0.16f, 0.095f);
															this.Instruments[this.ClubMemberID].transform.localEulerAngles = new Vector3(-22.5f, 30f, 60f);
															return;
														}
													}
													else if (this.StudentID == 54)
													{
														this.Drumsticks[0].SetActive(true);
														this.Drumsticks[1].SetActive(true);
														return;
													}
												}
												else if (this.Actions[this.Phase] == StudentActionType.PhotoShoot)
												{
													if (!(this.StudentManager.Students[19] != null))
													{
														this.CharacterAnimation.CrossFade(this.ThinkAnim);
														return;
													}
													if (this.StudentManager.Students[19].ClubTimer > 0f && this.StudentManager.Students[19].DistanceToDestination < 1f)
													{
														this.CharacterAnimation.CrossFade(this.IdleAnim);
														return;
													}
													this.CharacterAnimation.CrossFade(this.ThinkAnim);
													return;
												}
												else if (this.Actions[this.Phase] == StudentActionType.GravurePose)
												{
													if (!this.Hurry)
													{
														if (this.SunbathePhase < 2)
														{
															if (this.SunbathePhase == 0)
															{
																this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
																this.StudentManager.CommunalLocker.Open = true;
																this.StudentManager.CommunalLocker.SpawnSteamNoSideEffects(this);
																this.MustChangeClothing = true;
																this.ChangeClothingPhase++;
																this.SunbathePhase++;
																return;
															}
															if (this.SunbathePhase == 1)
															{
																this.CharacterAnimation.CrossFade(this.StripAnim);
																this.Pathfinding.canSearch = false;
																this.Pathfinding.canMove = false;
																if (this.CharacterAnimation[this.StripAnim].time >= 1.5f)
																{
																	this.WearBikini();
																	if (this.CharacterAnimation[this.StripAnim].time > this.CharacterAnimation[this.StripAnim].length)
																	{
																		this.Pathfinding.canSearch = true;
																		this.Pathfinding.canMove = true;
																		this.Stripping = false;
																		if (!this.StudentManager.CommunalLocker.SteamCountdown)
																		{
																			this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
																			this.Destinations[this.Phase] = this.StudentManager.Hangouts.List[19];
																			this.Pathfinding.target = this.StudentManager.Hangouts.List[19];
																			this.CurrentDestination = this.StudentManager.Hangouts.List[19];
																			this.StudentManager.CommunalLocker.Student = null;
																			this.SunbathePhase++;
																			return;
																		}
																	}
																}
															}
														}
														else
														{
															this.CharacterAnimation.CrossFade(this.ClubAnim);
															this.ClubTimer += Time.deltaTime;
															if (this.ClubTimer > 5f)
															{
																this.ClubPhase++;
																if (this.ClubPhase == this.GravureAnims.Length - 1)
																{
																	this.ClubPhase = 0;
																}
																this.ClubAnim = this.GravureAnims[this.ClubPhase];
																this.ClubTimer = 0f;
																return;
															}
														}
													}
												}
												else if (this.Actions[this.Phase] == StudentActionType.Guard)
												{
													this.CharacterAnimation.CrossFade(this.IdleAnim);
													return;
												}
											}
										}
									}
								}
							}
						}
						else
						{
							this.CurrentDestination = this.StudentManager.GoAwaySpots.List[this.StudentID];
							this.Pathfinding.target = this.StudentManager.GoAwaySpots.List[this.StudentID];
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.GoAwayTimer += Time.deltaTime;
							if (this.GoAwayTimer > 10f)
							{
								this.CurrentDestination = this.Destinations[this.Phase];
								this.Pathfinding.target = this.Destinations[this.Phase];
								this.GoAwayTimer = 0f;
								this.GoAway = false;
								return;
							}
						}
					}
					else
					{
						if (this.MeetTimer == 0f)
						{
							if (this.Yandere.Bloodiness + (float)this.Yandere.GloveBlood == 0f && (double)this.Yandere.Sanity >= 66.66666 && (this.CurrentDestination == this.StudentManager.MeetSpots.List[8] || this.CurrentDestination == this.StudentManager.MeetSpots.List[9] || this.CurrentDestination == this.StudentManager.MeetSpots.List[10]))
							{
								if (this.StudentManager.Eighties && this.StudentID == this.StudentManager.RivalID)
								{
									if (this.StudentManager.EightiesOfferHelp != null)
									{
										this.StudentManager.EightiesOfferHelp.UpdateLocation();
										this.StudentManager.EightiesOfferHelp.enabled = true;
										this.StudentManager.EightiesOfferHelp.Prompt.enabled = true;
									}
								}
								else if (this.StudentID == 11)
								{
									this.StudentManager.OsanaOfferHelp.UpdateLocation();
									this.StudentManager.OsanaOfferHelp.enabled = true;
									this.StudentManager.OsanaOfferHelp.Prompt.enabled = true;
								}
								else if (this.StudentID == 5)
								{
									this.Yandere.BullyPhotoCheck();
									if (this.Yandere.BullyPhoto)
									{
										this.StudentManager.FragileOfferHelp.gameObject.SetActive(true);
										this.StudentManager.FragileOfferHelp.UpdateLocation();
										this.StudentManager.FragileOfferHelp.enabled = true;
										this.StudentManager.FragileOfferHelp.Prompt.enabled = true;
									}
								}
							}
							if (!SchoolGlobals.RoofFence && base.transform.position.y > 11f)
							{
								this.Prompt.Label[0].text = "     Push";
								this.Prompt.HideButton[0] = false;
								this.Pushable = true;
							}
							if (this.CurrentDestination == this.StudentManager.FountainSpot)
							{
								Debug.Log(this.Name + " is now drownable.");
								this.Drownable = true;
								this.StudentManager.UpdateMe(this.StudentID);
							}
						}
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.MeetTimer += Time.deltaTime;
						if (this.Follower != null)
						{
							this.FollowTargetDestination.localPosition = new Vector3(0f, 0f, 0f);
						}
						if (this.BakeSale)
						{
							this.MeetTimer += Time.deltaTime * 11f;
						}
						if (this.MeetTimer > 60f)
						{
							if (!this.BakeSale)
							{
								if (!this.Male)
								{
									this.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 4, 3f);
								}
								else if (this.StudentID == 28)
								{
									this.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 6, 3f);
								}
								else
								{
									this.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 4, 3f);
								}
							}
							Debug.Log(this.Name + " has been waiting for 60 seconds.");
							while (this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time)
							{
								this.Phase++;
							}
							this.CurrentDestination = this.Destinations[this.Phase];
							this.Pathfinding.target = this.Destinations[this.Phase];
							if (this.Follower != null)
							{
								this.Follower.CurrentDestination = this.Follower.FollowTarget.transform;
								this.Follower.Pathfinding.target = this.Follower.FollowTarget.transform;
								this.FollowTargetDestination.localPosition = new Vector3(0f, 0f, 0f);
							}
							this.StopMeeting();
							return;
						}
					}
				}
			}
		}
		else
		{
			if (this.CurrentDestination != null)
			{
				this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
			}
			if (this.Fleeing && !this.Dying && !this.Spraying)
			{
				if (!this.PinningDown)
				{
					if (this.Persona == PersonaType.Dangerous)
					{
						this.Yandere.Pursuer = this;
						Debug.Log("This student council member is running to intercept Yandere-chan.");
						if (this.Yandere.Laughing)
						{
							this.Yandere.StopLaughing();
							this.Yandere.Chased = true;
							this.Yandere.CanMove = false;
						}
						if (this.StudentManager.CombatMinigame.Path > 3 && this.StudentManager.CombatMinigame.Path < 7)
						{
							this.ReturnToRoutine();
						}
					}
					if (this.Pathfinding.target != null)
					{
						this.DistanceToDestination = Vector3.Distance(base.transform.position, this.Pathfinding.target.position);
					}
					if (this.AlarmTimer > 0f)
					{
						this.AlarmTimer = Mathf.MoveTowards(this.AlarmTimer, 0f, Time.deltaTime);
						if (this.StudentID == 1)
						{
							Debug.Log("Senpai entered his scared animation.");
						}
						this.CharacterAnimation.CrossFade(this.ScaredAnim);
						if (this.AlarmTimer == 0f)
						{
							this.WalkBack = false;
							this.Alarmed = false;
						}
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						if (this.WitnessedMurder)
						{
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
						}
						else if (this.WitnessedCorpse)
						{
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - base.transform.position);
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
						}
					}
					else
					{
						if (this.Persona == PersonaType.TeachersPet && this.WitnessedMurder && this.ReportPhase == 0 && this.StudentManager.Reporter == null && !this.Police.Called)
						{
							Debug.Log(this.Name + " is setting their teacher as their destination at the beginning of Flee protocol.");
							this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
							this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
							this.StudentManager.Reporter = this;
							this.ReportingMurder = true;
							this.DetermineCorpseLocation();
						}
						if (base.transform.position.y < -10f)
						{
							if (!this.StudentManager.Jammed)
							{
								if (this.Persona == PersonaType.PhoneAddict && this.WitnessedMurder)
								{
									this.PhoneAddictGameOver();
								}
								else
								{
									this.Police.Called = true;
									this.Police.Show = true;
								}
							}
							base.transform.position = new Vector3(base.transform.position.x, -100f, base.transform.position.z);
							base.gameObject.SetActive(false);
						}
						if (base.transform.position.y < -11f)
						{
							if (this.Persona != PersonaType.Coward && this.Persona != PersonaType.Evil && this.Persona != PersonaType.Fragile && this.OriginalPersona != PersonaType.Evil)
							{
								this.Police.Witnesses--;
								if (!this.StudentManager.Jammed)
								{
									this.Police.Show = true;
									if (this.Countdown.gameObject.activeInHierarchy)
									{
										this.PhoneAddictGameOver();
									}
								}
							}
							base.transform.position = new Vector3(base.transform.position.x, -100f, base.transform.position.z);
							base.gameObject.SetActive(false);
						}
						if (base.transform.position.z < -99f)
						{
							this.Prompt.Hide();
							this.Prompt.enabled = false;
							this.Safe = true;
						}
						if (this.DistanceToDestination > this.TargetDistance)
						{
							if (!this.Phoneless)
							{
								this.CharacterAnimation.CrossFade(this.SprintAnim);
							}
							else
							{
								this.CharacterAnimation.CrossFade(this.OriginalSprintAnim);
							}
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
							if (this.Yandere.Chased && this.Yandere.Pursuer == this)
							{
								this.Pathfinding.repathRate = 0f;
								this.Pathfinding.speed = 5f;
								this.ChaseTimer += Time.deltaTime;
								if (this.ChaseTimer > 10f)
								{
									base.transform.position = this.Yandere.transform.position + this.Yandere.transform.forward * 0.999f;
									base.transform.LookAt(this.Yandere.transform.position);
									Physics.SyncTransforms();
								}
							}
							else
							{
								this.Pathfinding.speed = 4f;
							}
							if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless && !this.CrimeReported)
							{
								if (this.Countdown.Sprite.fillAmount == 0f)
								{
									this.Countdown.Sprite.fillAmount = 1f;
									this.CrimeReported = true;
									if (this.WitnessedMurder && !this.Countdown.MaskedPhoto)
									{
										this.PhoneAddictGameOver();
									}
									else
									{
										if (this.StudentManager.ChaseCamera == this.ChaseCamera)
										{
											this.StudentManager.ChaseCamera = null;
										}
										this.SprintAnim = this.OriginalSprintAnim;
										this.Countdown.gameObject.SetActive(false);
										this.ChaseCamera.SetActive(false);
										if (!this.StudentManager.Jammed)
										{
											this.Police.Called = true;
											this.Police.Show = true;
										}
									}
								}
								else
								{
									this.SprintAnim = this.PhoneAnims[2];
									if (!this.StudentManager.Eighties && this.StudentManager.ChaseCamera == null)
									{
										this.StudentManager.ChaseCamera = this.ChaseCamera;
										this.ChaseCamera.SetActive(true);
									}
								}
							}
						}
						else
						{
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							if (!this.Halt)
							{
								if (this.StudentID > 1)
								{
									this.MoveTowardsTarget(this.Pathfinding.target.position);
									if (!this.Teacher && !this.FocusOnYandere)
									{
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
									}
								}
							}
							else
							{
								if (this.Spraying)
								{
									this.CharacterAnimation.CrossFade(this.SprayAnim);
								}
								if (this.Persona == PersonaType.TeachersPet)
								{
									this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Teachers[this.Class].transform.position.x, base.transform.position.y, this.StudentManager.Teachers[this.Class].transform.position.z) - base.transform.position);
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
								}
								else if (this.Persona == PersonaType.Dangerous && !this.BreakingUpFight)
								{
									this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
								}
							}
							if (this.Persona == PersonaType.TeachersPet)
							{
								if (this.ReportingMurder || this.ReportingBlood)
								{
									if (this.StudentManager.Teachers[this.Class].Alarmed && this.ReportPhase < 100)
									{
										if (this.Club == ClubType.Council)
										{
											this.Pathfinding.target = this.StudentManager.CorpseLocation;
											this.CurrentDestination = this.StudentManager.CorpseLocation;
										}
										else
										{
											if (this.PetDestination == null)
											{
												this.PetDestination = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, this.Seat.position + this.Seat.forward * -0.5f, Quaternion.identity).transform;
											}
											this.Pathfinding.target = this.PetDestination;
											this.CurrentDestination = this.PetDestination;
										}
										this.ReportPhase = 3;
									}
									if (this.ReportPhase == 0)
									{
										Debug.Log(this.Name + ", currently acting as a Teacher's Pet, is talking to a teacher.");
										if (this.MyTeacher == null)
										{
											this.MyTeacher = this.StudentManager.Teachers[this.Class];
										}
										if (!this.MyTeacher.Alive)
										{
											this.Persona = PersonaType.Loner;
											this.PersonaReaction();
										}
										else
										{
											this.Subtitle.Speaker = this;
											this.CharacterAnimation.CrossFade(this.ScaredAnim);
											if (this.WitnessedMurder)
											{
												this.Subtitle.UpdateLabel(SubtitleType.PetMurderReport, 2, 3f);
											}
											else if (this.WitnessedCorpse)
											{
												if (this.Club == ClubType.Council)
												{
													this.Subtitle.CustomText = "";
													this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 0f);
													if (this.StudentID == 86)
													{
														this.Subtitle.UpdateLabel(SubtitleType.StrictReport, 2, 5f);
													}
													else if (this.StudentID == 87)
													{
														this.Subtitle.UpdateLabel(SubtitleType.CasualReport, 2, 5f);
													}
													else if (this.StudentID == 88)
													{
														this.Subtitle.UpdateLabel(SubtitleType.GraceReport, 2, 5f);
													}
													else if (this.StudentID == 89)
													{
														this.Subtitle.UpdateLabel(SubtitleType.EdgyReport, 2, 5f);
													}
												}
												else
												{
													this.Subtitle.UpdateLabel(SubtitleType.PetCorpseReport, 2, 3f);
												}
											}
											else if (this.WitnessedLimb)
											{
												this.Subtitle.UpdateLabel(SubtitleType.PetLimbReport, 2, 3f);
											}
											else if (this.WitnessedBloodyWeapon)
											{
												this.Subtitle.UpdateLabel(SubtitleType.PetBloodyWeaponReport, 2, 3f);
											}
											else if (this.WitnessedBloodPool)
											{
												this.Subtitle.UpdateLabel(SubtitleType.PetBloodReport, 2, 3f);
											}
											else if (this.WitnessedWeapon)
											{
												this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReport, 2, 3f);
											}
											this.MyTeacher = this.StudentManager.Teachers[this.Class];
											this.MyTeacher.CurrentDestination = this.MyTeacher.transform;
											this.MyTeacher.Pathfinding.target = this.MyTeacher.transform;
											this.MyTeacher.Pathfinding.canSearch = false;
											this.MyTeacher.Pathfinding.canMove = false;
											this.MyTeacher.CharacterAnimation.CrossFade(this.MyTeacher.IdleAnim);
											this.MyTeacher.ListeningToReport = true;
											this.MyTeacher.Routine = false;
											if (this.StudentManager.Teachers[this.Class].Investigating)
											{
												this.StudentManager.Teachers[this.Class].StopInvestigating();
											}
											this.Halt = true;
											this.ReportPhase++;
										}
									}
									else if (this.ReportPhase == 1)
									{
										this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
										this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
										if (this.WitnessedBloodPool || (this.WitnessedWeapon && !this.WitnessedBloodyWeapon))
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
										}
										else if (this.WitnessedMurder || this.WitnessedCorpse || this.WitnessedLimb || this.WitnessedBloodyWeapon)
										{
											this.CharacterAnimation.CrossFade(this.ScaredAnim);
										}
										this.StudentManager.Teachers[this.Class].targetRotation = Quaternion.LookRotation(base.transform.position - this.StudentManager.Teachers[this.Class].transform.position);
										this.StudentManager.Teachers[this.Class].transform.rotation = Quaternion.Slerp(this.StudentManager.Teachers[this.Class].transform.rotation, this.StudentManager.Teachers[this.Class].targetRotation, 10f * Time.deltaTime);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 3f)
										{
											base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
											this.StudentManager.Teachers[this.Class].ListeningToReport = false;
											this.StudentManager.Teachers[this.Class].MyReporter = this;
											this.StudentManager.Teachers[this.Class].Routine = false;
											this.StudentManager.Teachers[this.Class].Fleeing = true;
											this.ReportTimer = 0f;
											this.ReportPhase++;
										}
									}
									else if (this.ReportPhase == 2)
									{
										this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
										this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
										if (this.WitnessedBloodPool || (this.WitnessedWeapon && !this.WitnessedBloodyWeapon))
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
										}
										else if (this.WitnessedMurder || this.WitnessedCorpse || this.WitnessedLimb || this.WitnessedBloodyWeapon)
										{
											this.CharacterAnimation.CrossFade(this.ScaredAnim);
										}
									}
									else if (this.ReportPhase == 3)
									{
										this.Pathfinding.target = base.transform;
										this.CurrentDestination = base.transform;
										if (this.WitnessedBloodPool || (this.WitnessedWeapon && !this.WitnessedBloodyWeapon))
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
										}
										else if (this.WitnessedMurder || this.WitnessedCorpse || this.WitnessedLimb || this.WitnessedBloodyWeapon)
										{
											this.CharacterAnimation.CrossFade(this.ParanoidAnim);
										}
									}
									else if (this.ReportPhase < 100)
									{
										this.CharacterAnimation.CrossFade(this.ParanoidAnim);
									}
									else
									{
										if (this.Pathfinding.target != base.transform)
										{
											Debug.Log("This character just set their destination to themself.");
											if (this.Club == ClubType.Council)
											{
												Debug.Log("The reporter was a student council member.");
												if (this.StudentID == 86)
												{
													this.Subtitle.UpdateLabel(SubtitleType.StrictReport, 3, 5f);
												}
												else if (this.StudentID == 87)
												{
													this.Subtitle.UpdateLabel(SubtitleType.CasualReport, 3, 5f);
												}
												else if (this.StudentID == 88)
												{
													this.Subtitle.UpdateLabel(SubtitleType.GraceReport, 3, 5f);
												}
												else if (this.StudentID == 89)
												{
													this.Subtitle.UpdateLabel(SubtitleType.EdgyReport, 3, 5f);
												}
											}
											else
											{
												this.Subtitle.UpdateLabel(SubtitleType.PrankReaction, 1, 5f);
											}
										}
										this.Pathfinding.target = base.transform;
										this.CurrentDestination = base.transform;
										this.CharacterAnimation.CrossFade(this.ScaredAnim);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 5f)
										{
											this.ReturnToNormal();
										}
									}
								}
								else if (this.Club == ClubType.Council)
								{
									this.CharacterAnimation.CrossFade(this.GuardAnim);
									this.Persona = PersonaType.Dangerous;
									this.Guarding = true;
									this.Fleeing = false;
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ParanoidAnim);
									this.ReportPhase = 100;
									this.Fleeing = false;
									this.Persona = this.OriginalPersona;
									this.IgnoringPettyActions = true;
									this.Guarding = true;
								}
							}
							else if (this.Persona == PersonaType.Heroic)
							{
								if (this.Yandere.Attacking || (this.Yandere.Struggling && this.Yandere.StruggleBar.Student != this))
								{
									this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
									this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
									this.Pathfinding.canSearch = false;
									this.Pathfinding.canMove = false;
								}
								else if (!this.Yandere.Attacking && !this.StudentManager.PinningDown && !this.Yandere.Shoved)
								{
									if (this.StudentID > 1)
									{
										if (!this.Yandere.Struggling && this.Yandere.ShoulderCamera.Timer == 0f)
										{
											this.BeginStruggle();
										}
										if (!this.Teacher)
										{
											this.CharacterAnimation[this.StruggleAnim].time = this.Yandere.CharacterAnimation["f02_struggleA_00"].time;
										}
										else
										{
											this.CharacterAnimation[this.StruggleAnim].time = this.Yandere.CharacterAnimation["f02_teacherStruggleA_00"].time;
										}
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Yandere.transform.rotation, 10f * Time.deltaTime);
										this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.425f);
										if (!this.Yandere.Armed || !this.Yandere.EquippedWeapon.Concealable)
										{
											this.Yandere.StruggleBar.HeroWins();
										}
										if (this.Lost)
										{
											this.CharacterAnimation.CrossFade(this.StruggleWonAnim);
											if (this.CharacterAnimation[this.StruggleWonAnim].time > 1f)
											{
												this.EyeShrink = 1f;
											}
											if (this.CharacterAnimation[this.StruggleWonAnim].time >= this.CharacterAnimation[this.StruggleWonAnim].length)
											{
											}
										}
										else if (this.Won)
										{
											this.CharacterAnimation.CrossFade(this.StruggleLostAnim);
										}
									}
									else if (this.Yandere.Mask != null)
									{
										this.Yandere.EmptyHands();
										this.Pathfinding.canSearch = false;
										this.Pathfinding.canMove = false;
										this.TargetDistance = 1f;
										this.Yandere.CharacterAnimation.CrossFade("f02_unmasking_00");
										this.CharacterAnimation.CrossFade("unmasking_00");
										this.Yandere.CanMove = false;
										this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
										base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
										this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 1f);
										if (this.CharacterAnimation["unmasking_00"].time == 0f)
										{
											this.Yandere.ShoulderCamera.YandereNo();
											this.Yandere.Jukebox.GameOver();
										}
										if (this.CharacterAnimation["unmasking_00"].time >= 0.66666f && this.Yandere.Mask.transform.parent != this.LeftHand)
										{
											this.Yandere.CanMove = true;
											this.Yandere.EmptyHands();
											this.Yandere.CanMove = false;
											this.Yandere.Mask.transform.parent = this.LeftHand;
											this.Yandere.Mask.transform.localPosition = new Vector3(-0.1f, -0.05f, 0f);
											this.Yandere.Mask.transform.localEulerAngles = new Vector3(-90f, 90f, 0f);
											this.Yandere.Mask.transform.localScale = new Vector3(1f, 1f, 1f);
										}
										if (this.CharacterAnimation["unmasking_00"].time >= this.CharacterAnimation["unmasking_00"].length)
										{
											this.Yandere.Unmasked = true;
											this.Yandere.ShoulderCamera.GameOver();
											this.Yandere.Mask.Drop();
										}
									}
								}
							}
							else if (this.Persona == PersonaType.Coward || this.Persona == PersonaType.Fragile)
							{
								this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
								this.CharacterAnimation.CrossFade(this.CowardAnim);
								this.ReactionTimer += Time.deltaTime;
								if (this.ReactionTimer > 5f)
								{
									this.CurrentDestination = this.StudentManager.Exit;
									this.Pathfinding.target = this.StudentManager.Exit;
								}
							}
							else if (this.Persona == PersonaType.Evil)
							{
								this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
								this.CharacterAnimation.CrossFade(this.EvilAnim);
								this.ReactionTimer += Time.deltaTime;
								if (this.ReactionTimer > 5f)
								{
									this.CurrentDestination = this.StudentManager.Exit;
									this.Pathfinding.target = this.StudentManager.Exit;
								}
							}
							else if (this.Persona == PersonaType.SocialButterfly)
							{
								if (this.ReportPhase < 4)
								{
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
								}
								if (this.ReportPhase == 1)
								{
									if (!this.SmartPhone.activeInHierarchy)
									{
										if (this.StudentManager.Reporter == null && !this.Police.Called)
										{
											this.CharacterAnimation.CrossFade(this.SocialReportAnim);
											this.Subtitle.UpdateLabel(SubtitleType.SocialReport, 1, 5f);
											this.StudentManager.Reporter = this;
											this.SmartPhone.SetActive(true);
											this.SmartPhone.transform.localPosition = new Vector3(-0.015f, -0.01f, 0f);
											this.SmartPhone.transform.localEulerAngles = new Vector3(0f, -170f, 165f);
										}
										else
										{
											this.ReportTimer = 5f;
										}
									}
									this.ReportTimer += Time.deltaTime;
									if (this.ReportTimer > 5f)
									{
										if (this.StudentManager.Reporter == this && !this.StudentManager.Jammed)
										{
											this.Police.Called = true;
											this.Police.Show = true;
										}
										this.CharacterAnimation.CrossFade(this.ParanoidAnim);
										this.SmartPhone.SetActive(false);
										this.ReportPhase++;
										this.Halt = false;
									}
								}
								else if (this.ReportPhase == 2)
								{
									if (this.WitnessedMurder && (!this.SawMask || (this.SawMask && this.Yandere.Mask != null)))
									{
										this.LookForYandere();
									}
								}
								else if (this.ReportPhase == 3)
								{
									this.CharacterAnimation.CrossFade(this.SocialFearAnim);
									this.Subtitle.UpdateLabel(SubtitleType.SocialFear, 1, 5f);
									this.SpawnAlarmDisc();
									this.ReportPhase++;
									this.Halt = true;
								}
								else if (this.ReportPhase == 4)
								{
									this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
									if (this.Yandere.Attacking)
									{
										this.LookForYandere();
									}
								}
								else if (this.ReportPhase == 5)
								{
									this.CharacterAnimation.CrossFade(this.SocialTerrorAnim);
									this.Subtitle.UpdateLabel(SubtitleType.SocialTerror, 1, 5f);
									this.VisionDistance = 0f;
									this.SpawnAlarmDisc();
									this.ReportPhase++;
								}
							}
							else if (this.Persona == PersonaType.Lovestruck)
							{
								if (this.ReportPhase < 3 && this.StudentManager.Students[this.LovestruckTarget].Fleeing)
								{
									Debug.Log("Lovestruck Target is fleeing, so destination is being set to Exit.");
									this.Pathfinding.target = this.StudentManager.Exit;
									this.CurrentDestination = this.StudentManager.Exit;
									this.ReportPhase = 3;
								}
								if (this.ReportPhase == 1)
								{
									if (!this.StudentManager.Students[this.LovestruckTarget].gameObject.activeInHierarchy)
									{
										this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 5, 10f);
										this.Pathfinding.target = this.StudentManager.Exit;
										this.CurrentDestination = this.StudentManager.Exit;
										this.Pathfinding.enabled = true;
										this.ReportPhase = 3;
									}
									else if (!this.StudentManager.Students[this.LovestruckTarget].Alive)
									{
										this.CurrentDestination = this.Corpse.Student.Hips;
										this.Pathfinding.target = this.Corpse.Student.Hips;
										this.SpecialRivalDeathReaction = true;
										this.WitnessRivalDiePhase = 1;
										this.Fleeing = false;
										this.Routine = false;
										this.TargetDistance = 0.5f;
									}
									else if (this.StudentManager.Students[this.LovestruckTarget].Routine)
									{
										if (this.StudentManager.Students[this.LovestruckTarget].Male)
										{
											this.StudentManager.Students[this.LovestruckTarget].CharacterAnimation.CrossFade("surprised_00");
										}
										else
										{
											this.StudentManager.Students[this.LovestruckTarget].CharacterAnimation.CrossFade("f02_surprised_00");
										}
										this.StudentManager.Students[this.LovestruckTarget].EmptyHands();
										this.CharacterAnimation.CrossFade(this.ScaredAnim);
										this.StudentManager.Students[this.LovestruckTarget].Pathfinding.canSearch = false;
										this.StudentManager.Students[this.LovestruckTarget].Pathfinding.canMove = false;
										this.StudentManager.Students[this.LovestruckTarget].Pathfinding.enabled = false;
										this.StudentManager.Students[this.LovestruckTarget].Investigating = false;
										this.StudentManager.Students[this.LovestruckTarget].CheckingNote = false;
										this.StudentManager.Students[this.LovestruckTarget].Meeting = false;
										this.StudentManager.Students[this.LovestruckTarget].AwareOfCorpse = true;
										this.StudentManager.Students[this.LovestruckTarget].Routine = false;
										this.StudentManager.Students[this.LovestruckTarget].Blind = true;
										this.Pathfinding.enabled = false;
										if (this.WitnessedMurder && !this.SawMask)
										{
											this.Yandere.Jukebox.gameObject.active = false;
											this.Yandere.MainCamera.enabled = false;
											this.Yandere.RPGCamera.enabled = false;
											this.Yandere.Jukebox.Volume = 0f;
											this.Yandere.CanMove = false;
											this.StudentManager.LovestruckCamera.transform.parent = base.transform;
											this.StudentManager.LovestruckCamera.transform.localPosition = new Vector3(1f, 1f, -1f);
											this.StudentManager.LovestruckCamera.transform.localEulerAngles = new Vector3(0f, -30f, 0f);
											this.StudentManager.LovestruckCamera.active = true;
										}
										if (this.WitnessedMurder && !this.SawMask)
										{
											this.Subtitle.UpdateLabel(SubtitleType.LovestruckMurderReport, 0, 5f);
										}
										else if (this.LovestruckTarget == 1)
										{
											this.Subtitle.UpdateLabel(SubtitleType.LovestruckCorpseReport, 0, 5f);
										}
										else
										{
											this.Subtitle.UpdateLabel(SubtitleType.LovestruckCorpseReport, 1, 5f);
										}
										this.ReportPhase++;
									}
									else
									{
										this.CharacterAnimation.CrossFade(this.ScaredAnim);
									}
								}
								else if (this.ReportPhase == 2)
								{
									this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Students[this.LovestruckTarget].transform.position.x, base.transform.position.y, this.StudentManager.Students[this.LovestruckTarget].transform.position.z) - base.transform.position);
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
									this.targetRotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, this.StudentManager.Students[this.LovestruckTarget].transform.position.y, base.transform.position.z) - this.StudentManager.Students[this.LovestruckTarget].transform.position);
									this.StudentManager.Students[this.LovestruckTarget].transform.rotation = Quaternion.Slerp(this.StudentManager.Students[this.LovestruckTarget].transform.rotation, this.targetRotation, 10f * Time.deltaTime);
									this.ReportTimer += Time.deltaTime;
									if (this.ReportTimer > 5f)
									{
										if (this.WitnessedMurder && !this.SawMask)
										{
											this.Yandere.ShoulderCamera.HeartbrokenCamera.SetActive(true);
											this.Yandere.Police.EndOfDay.Heartbroken.Exposed = true;
											this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_down_22");
											this.Yandere.Collapse = true;
											this.StudentManager.StopMoving();
											this.ReportPhase++;
										}
										else
										{
											Debug.Log("Both reporter and Lovestruck Target should be heading to the Exit.");
											this.StudentManager.Students[this.LovestruckTarget].Pathfinding.target = this.StudentManager.Exit;
											this.StudentManager.Students[this.LovestruckTarget].CurrentDestination = this.StudentManager.Exit;
											this.StudentManager.Students[this.LovestruckTarget].CharacterAnimation.CrossFade(this.StudentManager.Students[this.LovestruckTarget].SprintAnim);
											this.StudentManager.Students[this.LovestruckTarget].Pathfinding.canSearch = true;
											this.StudentManager.Students[this.LovestruckTarget].Pathfinding.canMove = true;
											this.StudentManager.Students[this.LovestruckTarget].Pathfinding.enabled = true;
											this.StudentManager.Students[this.LovestruckTarget].Pathfinding.speed = 4f;
											this.Pathfinding.target = this.StudentManager.Exit;
											this.CurrentDestination = this.StudentManager.Exit;
											this.Pathfinding.enabled = true;
											this.ReportPhase++;
										}
									}
								}
							}
							else if (this.Persona == PersonaType.Dangerous)
							{
								if (!this.Yandere.Attacking && !this.StudentManager.PinningDown && !this.Yandere.Struggling && !this.Yandere.Noticed && !this.Yandere.Invisible)
								{
									this.Spray();
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
								}
							}
							else if (this.Persona == PersonaType.Protective)
							{
								if (!this.Yandere.Dumping && !this.Yandere.Attacking)
								{
									Debug.Log("A protective student is taking down Yandere-chan.");
									if (this.Yandere.Aiming)
									{
										this.Yandere.StopAiming();
									}
									this.Yandere.Mopping = false;
									this.Yandere.EmptyHands();
									this.Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
									this.Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 4, 0f);
									this.AttackReaction();
									this.CharacterAnimation["f02_moCounterB_00"].time = 6f;
									this.Yandere.CharacterAnimation["f02_moCounterA_00"].time = 6f;
									this.Yandere.ShoulderCamera.ObstacleCounter = true;
									this.Yandere.ShoulderCamera.Timer = 6f;
									this.Police.Show = false;
									this.Yandere.CameraEffects.MurderWitnessed();
									this.Yandere.Jukebox.GameOver();
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
								}
							}
							else if (this.Persona == PersonaType.Violent)
							{
								if (!this.Yandere.Attacking && !this.Yandere.Struggling && !this.Yandere.Dumping && !this.Yandere.SneakingShot && !this.StudentManager.PinningDown && !this.RespectEarned)
								{
									if (!this.Yandere.DelinquentFighting)
									{
										Debug.Log(this.Name + " is supposed to begin the combat minigame now.");
										this.SmartPhone.SetActive(false);
										this.Threatened = true;
										this.Fleeing = false;
										this.Alarmed = true;
										this.NoTalk = false;
										this.Patience = 0;
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
								}
							}
							else if (this.Persona == PersonaType.Strict)
							{
								if (!this.WitnessedMurder)
								{
									if (this.ReportPhase == 0)
									{
										if (this.MyReporter.WitnessedMurder || this.MyReporter.WitnessedCorpse)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 0, 3f);
											this.InvestigatingPossibleDeath = true;
										}
										else if (this.MyReporter.WitnessedLimb)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 2, 3f);
										}
										else if (this.MyReporter.WitnessedBloodyWeapon)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 3, 3f);
										}
										else if (this.MyReporter.WitnessedBloodPool)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 1, 3f);
										}
										else if (this.MyReporter.WitnessedWeapon)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 4, 3f);
										}
										this.ReportPhase++;
									}
									else if (this.ReportPhase == 1)
									{
										this.CharacterAnimation.CrossFade(this.IdleAnim);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 3f)
										{
											base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
											StudentScript studentScript2 = null;
											if (this.MyReporter.WitnessedMurder || this.MyReporter.WitnessedCorpse)
											{
												studentScript2 = this.StudentManager.Reporter;
											}
											else if (this.MyReporter.WitnessedBloodPool || this.MyReporter.WitnessedLimb || this.MyReporter.WitnessedWeapon)
											{
												studentScript2 = this.StudentManager.BloodReporter;
											}
											if (this.MyReporter.WitnessedLimb)
											{
												this.InvestigatingPossibleLimb = true;
											}
											if (this.MyReporter.WitnessedBloodPool)
											{
												this.InvestigatingPossibleBlood = true;
											}
											if (!studentScript2.Teacher)
											{
												if (this.MyReporter.WitnessedMurder || this.MyReporter.WitnessedCorpse)
												{
													this.StudentManager.Reporter.CurrentDestination = this.StudentManager.CorpseLocation;
													this.StudentManager.Reporter.Pathfinding.target = this.StudentManager.CorpseLocation;
													this.CurrentDestination = this.StudentManager.CorpseLocation;
													this.Pathfinding.target = this.StudentManager.CorpseLocation;
													this.StudentManager.Reporter.TargetDistance = 2f;
												}
												else if (this.MyReporter.WitnessedBloodPool || this.MyReporter.WitnessedLimb || this.MyReporter.WitnessedWeapon)
												{
													this.StudentManager.BloodReporter.CurrentDestination = this.StudentManager.BloodLocation;
													this.StudentManager.BloodReporter.Pathfinding.target = this.StudentManager.BloodLocation;
													this.CurrentDestination = this.StudentManager.BloodLocation;
													this.Pathfinding.target = this.StudentManager.BloodLocation;
													this.StudentManager.BloodReporter.TargetDistance = 2f;
												}
											}
											this.TargetDistance = 1f;
											this.ReportTimer = 0f;
											this.ReportPhase++;
										}
									}
									else if (this.ReportPhase == 2)
									{
										if (this.WitnessedCorpse)
										{
											Debug.Log("A teacher has just witnessed a corpse while on their way to investigate a student's report of a corpse.");
											this.DetermineCorpseLocation();
											if (!this.Corpse.Poisoned)
											{
												this.Subtitle.Speaker = this;
												this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 1, 5f);
											}
											else
											{
												this.Subtitle.Speaker = this;
												this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 2, 2f);
											}
											this.ReportPhase++;
										}
										else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
										{
											Debug.Log("A teacher has just witnessed an alarming object while on their way to investigate a student's report - a " + this.BloodPool.name);
											this.DetermineBloodLocation();
											if (!this.VerballyReacted)
											{
												if (this.WitnessedLimb)
												{
													this.Subtitle.Speaker = this;
													this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 4, 5f);
												}
												else if (this.WitnessedBloodPool || this.WitnessedBloodyWeapon)
												{
													this.Subtitle.Speaker = this;
													this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 3, 5f);
												}
												else if (this.WitnessedWeapon)
												{
													this.Subtitle.Speaker = this;
													this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 5, 5f);
												}
											}
											PromptScript component2 = this.BloodPool.GetComponent<PromptScript>();
											if (component2 != null)
											{
												Debug.Log("Disabling an object's prompt.");
												component2.Hide();
												component2.enabled = false;
												this.TargetDistance = 1.5f;
											}
											this.ReportPhase++;
										}
										else
										{
											this.CharacterAnimation.CrossFade(this.GuardAnim);
											if (this.BloodPool == null && this.StudentManager.Police.BloodParent.childCount > 0 && !this.InvestigatingPossibleLimb)
											{
												this.UpdateVisibleBlood();
											}
											this.ReportTimer += Time.deltaTime;
											if (this.ReportTimer > 5f)
											{
												this.Subtitle.UpdateLabel(SubtitleType.TeacherPrankReaction, 1, 7f);
												this.ReportPhase = 98;
												this.ReportTimer = 0f;
											}
										}
									}
									else if (this.ReportPhase == 3)
									{
										if (this.WitnessedCorpse)
										{
											this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - base.transform.position);
											base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
											this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
											this.CharacterAnimation.CrossFade(this.InspectAnim);
										}
										else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
										{
											if (this.BloodPool != null)
											{
												this.targetRotation = Quaternion.LookRotation(new Vector3(this.BloodPool.transform.position.x, base.transform.position.y, this.BloodPool.transform.position.z) - base.transform.position);
											}
											base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
											this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
											this.CharacterAnimation[this.InspectBloodAnim].speed = 0.66666f;
											this.CharacterAnimation.CrossFade(this.InspectBloodAnim);
										}
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 6f)
										{
											this.ReportTimer = 0f;
											if (this.WitnessedWeapon && !this.WitnessedBloodyWeapon)
											{
												this.ReportPhase = 7;
											}
											else
											{
												this.ReportPhase++;
											}
										}
									}
									else if (this.ReportPhase == 4)
									{
										if (this.WitnessedCorpse)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherPoliceReport, 0, 5f);
										}
										else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
										{
											this.Subtitle.Speaker = this;
											this.Subtitle.UpdateLabel(SubtitleType.TeacherPoliceReport, 1, 5f);
										}
										if (!this.StudentManager.Eighties)
										{
											this.SmartPhone.transform.localPosition = new Vector3(-0.01f, -0.005f, -0.02f);
											this.SmartPhone.transform.localEulerAngles = new Vector3(-10f, -145f, 170f);
										}
										else
										{
											this.SmartPhone.transform.localPosition = new Vector3(0f, -0.022f, 0f);
											this.SmartPhone.transform.localEulerAngles = new Vector3(90f, 45f, 0f);
											this.SmartPhone.transform.localScale = new Vector3(66.66666f, 66.66666f, 66.66666f);
										}
										this.SmartPhone.SetActive(true);
										this.ReportPhase++;
									}
									else if (this.ReportPhase == 5)
									{
										this.CharacterAnimation.CrossFade(this.CallAnim);
										this.ReportTimer += Time.deltaTime;
										if (this.ReportTimer >= 5f)
										{
											this.CharacterAnimation.CrossFade(this.GuardAnim);
											this.SmartPhone.SetActive(false);
											this.WitnessedBloodyWeapon = false;
											this.WitnessedBloodPool = false;
											this.WitnessedSomething = false;
											this.WitnessedWeapon = false;
											this.WitnessedLimb = false;
											this.IgnoringPettyActions = true;
											if (!this.StudentManager.Jammed)
											{
												this.Police.Called = true;
												this.Police.Show = true;
											}
											this.ReportTimer = 0f;
											this.Guarding = true;
											this.Alarmed = false;
											this.Fleeing = false;
											this.Reacted = false;
											this.ReportPhase++;
											if (this.MyReporter != null && this.MyReporter.ReportingBlood)
											{
												Debug.Log("The blood reporter has just been instructed to stop following the teacher.");
												this.MyReporter.ReportPhase++;
											}
										}
									}
									else if (this.ReportPhase != 6)
									{
										if (this.ReportPhase == 7)
										{
											Debug.Log("Telling reporter to go back to their normal routine.");
											if (this.StudentManager.BloodReporter != this)
											{
												this.StudentManager.BloodReporter = null;
											}
											this.StudentManager.UpdateStudents(0);
											if (this.MyReporter != null)
											{
												this.MyReporter.CurrentDestination = this.MyReporter.Destinations[this.MyReporter.Phase];
												this.MyReporter.Pathfinding.target = this.MyReporter.Destinations[this.MyReporter.Phase];
												this.MyReporter.Pathfinding.speed = 1f;
												this.MyReporter.ReportTimer = 0f;
												this.MyReporter.AlarmTimer = 0f;
												this.MyReporter.TargetDistance = 1f;
												this.MyReporter.ReportPhase = 0;
												this.MyReporter.WitnessedSomething = false;
												this.MyReporter.WitnessedWeapon = false;
												this.MyReporter.Distracted = false;
												this.MyReporter.Reacted = false;
												this.MyReporter.Alarmed = false;
												this.MyReporter.Fleeing = false;
												this.MyReporter.Routine = true;
												this.MyReporter.Halt = false;
												this.MyReporter.Persona = this.OriginalPersona;
												if (this.MyReporter.Club == ClubType.Council)
												{
													this.MyReporter.Persona = PersonaType.Dangerous;
												}
												this.ID = 0;
												while (this.ID < this.MyReporter.Outlines.Length)
												{
													if (this.MyReporter.Outlines[this.ID] != null)
													{
														this.MyReporter.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
													}
													this.ID++;
												}
											}
											this.BloodPool.GetComponent<WeaponScript>().Prompt.enabled = false;
											this.BloodPool.GetComponent<WeaponScript>().Prompt.Hide();
											this.BloodPool.GetComponent<WeaponScript>().enabled = false;
											this.ReportPhase++;
										}
										else if (this.ReportPhase == 8)
										{
											this.CharacterAnimation.CrossFade("f02_teacherPickUp_00");
											if (this.CharacterAnimation["f02_teacherPickUp_00"].time >= 0.33333f)
											{
												this.Handkerchief.SetActive(true);
											}
											if (this.CharacterAnimation["f02_teacherPickUp_00"].time >= 2f)
											{
												this.BloodPool.parent = this.RightHand;
												this.BloodPool.localPosition = new Vector3(0f, 0f, 0f);
												this.BloodPool.localEulerAngles = new Vector3(0f, 0f, 0f);
												this.BloodPool.GetComponent<WeaponScript>().Returner = this;
											}
											if (this.CharacterAnimation["f02_teacherPickUp_00"].time >= this.CharacterAnimation["f02_teacherPickUp_00"].length)
											{
												this.CurrentDestination = this.StudentManager.WeaponBoxSpot;
												this.Pathfinding.target = this.StudentManager.WeaponBoxSpot;
												this.Pathfinding.speed = this.WalkSpeed;
												this.Hurry = false;
												this.ReportPhase++;
											}
										}
										else if (this.ReportPhase == 9)
										{
											this.StudentManager.BloodLocation.position = Vector3.zero;
											this.BloodPool.parent = null;
											this.BloodPool.position = this.StudentManager.WeaponBoxSpot.parent.position + new Vector3(0f, 1f, 0f);
											this.BloodPool.eulerAngles = new Vector3(0f, 90f, 0f);
											this.BloodPool.GetComponent<WeaponScript>().Prompt.enabled = true;
											this.BloodPool.GetComponent<WeaponScript>().Returner = null;
											this.BloodPool.GetComponent<WeaponScript>().enabled = true;
											this.BloodPool.GetComponent<WeaponScript>().Drop();
											this.BloodPool = null;
											this.CharacterAnimation.CrossFade(this.RunAnim);
											this.CurrentDestination = this.Destinations[this.Phase];
											this.Pathfinding.target = this.Destinations[this.Phase];
											this.Handkerchief.SetActive(false);
											this.StopInvestigating();
											this.Pathfinding.canSearch = true;
											this.Pathfinding.canMove = true;
											this.Pathfinding.speed = this.WalkSpeed;
											this.WitnessedSomething = false;
											this.VerballyReacted = false;
											this.WitnessedWeapon = false;
											this.YandereInnocent = false;
											this.ReportingBlood = false;
											this.Distracted = false;
											this.Alarmed = false;
											this.Fleeing = false;
											this.Routine = true;
											this.Halt = false;
											this.ReportTimer = 0f;
											this.ReportPhase = 0;
										}
										else if (this.ReportPhase == 98)
										{
											this.CharacterAnimation.CrossFade(this.IdleAnim);
											this.targetRotation = Quaternion.LookRotation(this.MyReporter.transform.position - base.transform.position);
											base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
											this.ReportTimer += Time.deltaTime;
											if (this.ReportTimer > 7f)
											{
												this.ReportPhase++;
											}
										}
										else if (this.ReportPhase == 99)
										{
											this.CharacterAnimation.CrossFade(this.RunAnim);
											this.CurrentDestination = this.Destinations[this.Phase];
											this.Pathfinding.target = this.Destinations[this.Phase];
											this.Pathfinding.canSearch = true;
											this.Pathfinding.canMove = true;
											this.MyReporter.Persona = PersonaType.TeachersPet;
											this.MyReporter.ReportPhase = 100;
											this.MyReporter.Fleeing = true;
											this.ReportTimer = 0f;
											this.ReportPhase = 0;
											this.InvestigatingPossibleBlood = false;
											this.InvestigatingPossibleDeath = false;
											this.InvestigatingPossibleLimb = false;
											this.Alarmed = false;
											this.Fleeing = false;
											this.Routine = true;
										}
									}
								}
								else if (!this.Yandere.Dumping && !this.Yandere.Attacking)
								{
									if ((this.Yandere.Armed && this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus > 0 && this.Yandere.EquippedWeapon.Type == WeaponType.Knife) || (this.Yandere.Club == ClubType.MartialArts && this.Yandere.Armed && this.Yandere.EquippedWeapon.Type == WeaponType.Knife))
									{
										Debug.Log("Yandere-chan is in a state that allows her to enter struggles with teachers, so this teacher is changing into the ''Heroic'' Persona to have a struggle.");
										this.Persona = PersonaType.Heroic;
									}
									else
									{
										Debug.Log("A teacher is taking down Yandere-chan.");
										if (this.Yandere.Aiming)
										{
											this.Yandere.StopAiming();
										}
										this.Yandere.Mopping = false;
										this.Yandere.EmptyHands();
										this.AttackReaction();
										this.CharacterAnimation[this.CounterAnim].time = 5f;
										this.Yandere.CharacterAnimation["f02_teacherCounterA_00"].time = 5f;
										this.Yandere.ShoulderCamera.Timer = 5f;
										this.Yandere.ShoulderCamera.Phase = 3;
										this.Police.Show = false;
										this.Yandere.CameraEffects.MurderWitnessed();
										this.Yandere.Jukebox.GameOver();
									}
								}
								else
								{
									this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
								}
							}
							else if (this.Persona == PersonaType.LandlineUser)
							{
								if (this.ReportPhase == 1)
								{
									if (this.StudentManager.Reporter == null && !this.Police.Called)
									{
										this.Subtitle.UpdateLabel(SubtitleType.SocialReport, 1, 5f);
										this.CharacterAnimation.CrossFade(this.LandLineAnim);
										this.StudentManager.Reporter = this;
										this.SpawnAlarmDisc();
										this.ReportPhase++;
									}
									else
									{
										this.CharacterAnimation.CrossFade(this.ParanoidAnim);
										this.ReportPhase += 2;
										this.Halt = true;
									}
								}
								else if (this.ReportPhase == 2)
								{
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
									this.StudentManager.LandLinePhone.SetBlendShapeWeight(1, this.ReportTimer * 200f);
									this.ReportTimer += Time.deltaTime;
									if (this.ReportTimer > 5f)
									{
										if (this.StudentManager.Reporter == this)
										{
											this.StudentManager.LandLinePhone.SetBlendShapeWeight(1, 0f);
											this.Police.Called = true;
											this.Police.Show = true;
										}
										UnityEngine.Object.Instantiate<GameObject>(this.EnterGuardStateCollider, base.transform.position, Quaternion.identity);
										this.CharacterAnimation.CrossFade(this.ParanoidAnim);
										this.ReportPhase++;
									}
								}
								else if (this.ReportPhase == 3)
								{
									if (this.WitnessedMurder && (!this.SawMask || (this.SawMask && this.Yandere.Mask != null)))
									{
										this.LookForYandere();
									}
								}
								else if (this.ReportPhase == 4)
								{
									this.CharacterAnimation.CrossFade(this.SocialFearAnim);
									this.Subtitle.UpdateLabel(SubtitleType.SocialFear, 1, 5f);
									this.SpawnAlarmDisc();
									this.ReportPhase++;
									this.Halt = true;
								}
								else if (this.ReportPhase == 5)
								{
									this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
									if (this.Yandere.Attacking)
									{
										this.LookForYandere();
									}
								}
								else if (this.ReportPhase == 6)
								{
									this.CharacterAnimation.CrossFade(this.SocialTerrorAnim);
									this.Subtitle.UpdateLabel(SubtitleType.SocialTerror, 1, 5f);
									this.VisionDistance = 0f;
									this.SpawnAlarmDisc();
									this.ReportPhase++;
								}
							}
						}
						if (this.Persona == PersonaType.Strict && this.BloodPool != null && this.BloodPool.parent == this.Yandere.RightHand)
						{
							Debug.Log("Yandere-chan picked up the weapon that the teacher was investigating!");
							this.WitnessedBloodyWeapon = false;
							this.WitnessedBloodPool = false;
							this.WitnessedSomething = false;
							this.WitnessedCorpse = false;
							this.WitnessedMurder = false;
							this.WitnessedWeapon = false;
							this.WitnessedLimb = false;
							this.YandereVisible = true;
							this.ReportTimer = 0f;
							this.BloodPool = null;
							this.ReportPhase = 0;
							this.Alarmed = false;
							this.Fleeing = false;
							this.Routine = true;
							this.Reacted = false;
							this.AlarmTimer = 0f;
							this.Alarm = 200f;
							this.BecomeAlarmed();
						}
					}
				}
				else if (this.PinPhase == 0)
				{
					if (this.DistanceToDestination < 1f)
					{
						if (this.Pathfinding.canSearch)
						{
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
						}
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
						this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
						this.MoveTowardsTarget(this.CurrentDestination.position);
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.SprintAnim);
						if (!this.Pathfinding.canSearch)
						{
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
						}
					}
				}
				else
				{
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
					this.MoveTowardsTarget(this.CurrentDestination.position);
				}
			}
			if (this.Following && !this.Waiting)
			{
				this.DistanceToDestination = Vector3.Distance(base.transform.position, this.Pathfinding.target.position);
				if (this.DistanceToDestination > 2f)
				{
					this.CharacterAnimation.CrossFade(this.RunAnim);
					this.Pathfinding.speed = 4f;
					this.Obstacle.enabled = false;
				}
				else if (this.DistanceToDestination > 1f)
				{
					this.CharacterAnimation.CrossFade(this.OriginalWalkAnim);
					this.Pathfinding.canMove = true;
					this.Obstacle.enabled = false;
					this.Pathfinding.speed = this.WalkSpeed;
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.Pathfinding.canMove = false;
					this.Obstacle.enabled = true;
				}
				if (this.Phase < this.ScheduleBlocks.Length && (this.FollowCountdown.Sprite.fillAmount == 0f || this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time || this.StudentManager.LockerRoomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.WestBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.EastBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.IncineratorArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.HeadmasterArea.bounds.Contains(this.Yandere.transform.position)))
				{
					if (this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time)
					{
						this.Phase++;
					}
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.Hearts.emission.enabled = false;
					this.FollowCountdown.gameObject.SetActive(false);
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Yandere.Follower = null;
					this.Yandere.Followers--;
					this.Following = false;
					this.Routine = true;
					this.Pathfinding.speed = this.WalkSpeed;
					if (this.StudentManager.LockerRoomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.WestBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.EastBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.IncineratorArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.HeadmasterArea.bounds.Contains(this.Yandere.transform.position))
					{
						this.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 1, 3f);
					}
					else
					{
						this.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
					}
					this.Prompt.Label[0].text = "     Talk";
				}
			}
			if (this.Wet)
			{
				if (this.DistanceToDestination < this.TargetDistance)
				{
					if (!this.Splashed)
					{
						if (!this.InDarkness)
						{
							if (this.BathePhase == 1)
							{
								this.CharacterAnimation[this.WetAnim].weight = 0f;
								this.StudentManager.CommunalLocker.Open = true;
								this.StudentManager.CommunalLocker.Student = this;
								this.StudentManager.CommunalLocker.SpawnSteam();
								this.Pathfinding.speed = this.WalkSpeed;
								this.Schoolwear = 0;
								this.BathePhase++;
							}
							else if (this.BathePhase == 2)
							{
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
								this.MoveTowardsTarget(this.CurrentDestination.position);
								if (this.Club == ClubType.Cooking && this.ApronAttacher.newRenderer.enabled)
								{
									this.ApronAttacher.newRenderer.enabled = false;
								}
							}
							else if (this.BathePhase == 3)
							{
								this.StudentManager.CommunalLocker.Open = false;
								this.CharacterAnimation.CrossFade(this.WalkAnim);
								if (!this.BatheFast)
								{
									if (!this.Male)
									{
										this.CurrentDestination = this.StudentManager.FemaleBatheSpot;
										this.Pathfinding.target = this.StudentManager.FemaleBatheSpot;
									}
									else
									{
										this.CurrentDestination = this.StudentManager.MaleBatheSpot;
										this.Pathfinding.target = this.StudentManager.MaleBatheSpot;
									}
								}
								else if (!this.Male)
								{
									this.CurrentDestination = this.StudentManager.FastBatheSpot;
									this.Pathfinding.target = this.StudentManager.FastBatheSpot;
								}
								else
								{
									this.CurrentDestination = this.StudentManager.MaleBatheSpot;
									this.Pathfinding.target = this.StudentManager.MaleBatheSpot;
								}
								this.Pathfinding.canSearch = true;
								this.Pathfinding.canMove = true;
								this.BathePhase++;
							}
							else if (this.BathePhase == 4)
							{
								this.StudentManager.OpenValue = Mathf.Lerp(this.StudentManager.OpenValue, 0f, Time.deltaTime * 10f);
								this.StudentManager.FemaleShowerCurtain.SetBlendShapeWeight(0, this.StudentManager.OpenValue);
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
								this.MoveTowardsTarget(this.CurrentDestination.position);
								this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
								this.CharacterAnimation.CrossFade(this.BathingAnim);
								if (this.CharacterAnimation[this.BathingAnim].time >= this.CharacterAnimation[this.BathingAnim].length)
								{
									this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
									this.StudentManager.OpenCurtain = true;
									this.LiquidProjector.enabled = false;
									this.Bloody = false;
									this.BathePhase++;
									this.Gas = false;
									this.GoChange();
									this.UnWet();
								}
							}
							else if (this.BathePhase == 5)
							{
								this.StudentManager.CommunalLocker.Open = true;
								this.StudentManager.CommunalLocker.Student = this;
								this.StudentManager.CommunalLocker.SpawnSteam();
								this.Schoolwear = (this.InEvent ? 1 : 3);
								this.BathePhase++;
							}
							else if (this.BathePhase == 6)
							{
								base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
								this.MoveTowardsTarget(this.CurrentDestination.position);
								if (this.Club == ClubType.Cooking && !this.ApronAttacher.newRenderer.enabled)
								{
									this.ApronAttacher.newRenderer.enabled = true;
									Debug.Log("We are being told to re-enable this apron attacher...");
								}
							}
							else if (this.BathePhase == 7)
							{
								if (!this.Yandere.Inventory.Ring)
								{
									this.StudentManager.CommunalLocker.Rings.gameObject.SetActive(false);
								}
								if (this.StudentManager.CommunalLocker.RivalPhone.Stolen && this.Yandere.Inventory.RivalPhoneID == this.StudentID)
								{
									this.CharacterAnimation.CrossFade("f02_losingPhone_00");
									this.Subtitle.UpdateLabel(this.LostPhoneSubtitleType, 1, 5f);
									this.RealizePhoneIsMissing();
									this.Phoneless = true;
									this.BatheTimer = 6f;
									this.BathePhase++;
								}
								else
								{
									this.StudentManager.CommunalLocker.RivalPhone.gameObject.SetActive(false);
									this.BathePhase++;
								}
							}
							else if (this.BathePhase == 8)
							{
								if (this.BatheTimer == 0f)
								{
									this.BathePhase++;
								}
								else
								{
									this.BatheTimer = Mathf.MoveTowards(this.BatheTimer, 0f, Time.deltaTime);
								}
							}
							else if (this.BathePhase == 9)
							{
								if ((this.StudentManager.Eighties && this.StudentID == 30 && this.StudentManager.CommunalLocker.Rings.Stolen) || (!this.StudentManager.Eighties && this.StudentID == 2 && this.StudentManager.CommunalLocker.Rings.Stolen))
								{
									this.CharacterAnimation.CrossFade("f02_losingPhone_00");
									if (this.StudentManager.Eighties)
									{
										this.Subtitle.CustomText = "Huh? One of my rings is missing...did someone steal it?!";
									}
									else
									{
										this.Subtitle.CustomText = "Huh? My ring is missing...did someone take it?";
									}
									this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
									this.Depressed = true;
									this.BatheTimer = 6f;
									this.BathePhase++;
								}
								else
								{
									if (!this.StudentManager.Eighties && this.StudentID == 2)
									{
										this.Cosmetic.FemaleAccessories[this.Cosmetic.Accessory].SetActive(true);
									}
									else if (this.StudentManager.Eighties && this.StudentID == 30)
									{
										this.Cosmetic.EnableRings();
									}
									this.BathePhase++;
								}
							}
							else if (this.BathePhase == 10)
							{
								if (this.BatheTimer == 0f)
								{
									this.BathePhase++;
								}
								else
								{
									this.BatheTimer = Mathf.MoveTowards(this.BatheTimer, 0f, Time.deltaTime);
								}
							}
							else if (this.BathePhase == 11)
							{
								if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
								{
									this.SmartPhone.SetActive(true);
								}
								else
								{
									this.WalkAnim = this.OriginalOriginalWalkAnim;
									this.RunAnim = this.OriginalSprintAnim;
									this.IdleAnim = this.OriginalIdleAnim;
								}
								this.StudentManager.CommunalLocker.Student = null;
								this.StudentManager.CommunalLocker.Open = false;
								if (this.Phase == 1)
								{
									this.Phase++;
								}
								this.CurrentDestination = this.Destinations[this.Phase];
								this.Pathfinding.target = this.Destinations[this.Phase];
								this.Pathfinding.canSearch = true;
								this.Pathfinding.canMove = true;
								this.DistanceToDestination = 100f;
								this.Routine = true;
								this.Wet = false;
								if (this.FleeWhenClean)
								{
									this.CurrentDestination = this.StudentManager.Exit;
									this.Pathfinding.target = this.StudentManager.Exit;
									this.TargetDistance = 0f;
									this.Routine = false;
									this.Fleeing = true;
								}
								else
								{
									this.Hurry = false;
								}
								if (this.Phoneless)
								{
									this.SprintAnim = this.OriginalOriginalSprintAnim;
									this.RunAnim = this.OriginalOriginalSprintAnim;
									this.Pathfinding.speed = 4f;
									this.Hurry = true;
								}
								if (this.CurrentAction == StudentActionType.PhotoShoot || this.CurrentAction == StudentActionType.GravurePose)
								{
									this.Hurry = false;
								}
							}
						}
						else if (this.BathePhase == -1)
						{
							this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
							this.Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 2, 5f);
							this.CharacterAnimation.CrossFade("f02_electrocution_00");
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							this.Distracted = true;
							this.BathePhase++;
						}
						else if (this.BathePhase == 0)
						{
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
							this.MoveTowardsTarget(this.CurrentDestination.position);
							if (this.CharacterAnimation["f02_electrocution_00"].time > 2f && this.CharacterAnimation["f02_electrocution_00"].time < 5.9500003f)
							{
								if (!this.LightSwitch.Panel.useGravity)
								{
									if (!this.Bloody)
									{
										this.Subtitle.Speaker = this;
										this.Subtitle.UpdateLabel(this.SplashSubtitleType, 2, 5f);
									}
									else
									{
										this.Subtitle.Speaker = this;
										this.Subtitle.UpdateLabel(this.SplashSubtitleType, 4, 5f);
									}
									this.CurrentDestination = this.StudentManager.StrippingPositions[this.GirlID];
									this.Pathfinding.target = this.StudentManager.StrippingPositions[this.GirlID];
									this.Pathfinding.canSearch = true;
									this.Pathfinding.canMove = true;
									this.Pathfinding.speed = 4f;
									this.CharacterAnimation.CrossFade(this.WalkAnim);
									this.BathePhase++;
									this.LightSwitch.Prompt.Label[0].text = "     Turn Off";
									this.LightSwitch.BathroomLight.SetActive(true);
									this.LightSwitch.GetComponent<AudioSource>().clip = this.LightSwitch.Flick[0];
									this.LightSwitch.GetComponent<AudioSource>().Play();
									this.InDarkness = false;
								}
								else
								{
									if (!this.LightSwitch.Flicker)
									{
										this.CharacterAnimation["f02_electrocution_00"].speed = 0.85f;
										GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.LightSwitch.Electricity, base.transform.position, Quaternion.identity);
										gameObject5.transform.parent = this.Bones[1].transform;
										gameObject5.transform.localPosition = Vector3.zero;
										this.Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 3, 0f);
										this.LightSwitch.GetComponent<AudioSource>().clip = this.LightSwitch.Flick[2];
										this.LightSwitch.Flicker = true;
										this.LightSwitch.GetComponent<AudioSource>().Play();
										this.EyeShrink = 1f;
										this.ElectroSteam[0].SetActive(true);
										this.ElectroSteam[1].SetActive(true);
										this.ElectroSteam[2].SetActive(true);
										this.ElectroSteam[3].SetActive(true);
									}
									this.RightDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
									this.LeftDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
									this.ElectroTimer += Time.deltaTime;
									if (this.ElectroTimer > 0.1f)
									{
										this.ElectroTimer = 0f;
										if (this.MyRenderer.enabled)
										{
											this.Spook();
										}
										else
										{
											this.Unspook();
										}
									}
								}
							}
							else if (this.CharacterAnimation["f02_electrocution_00"].time > 5.9500003f && this.CharacterAnimation["f02_electrocution_00"].time < this.CharacterAnimation["f02_electrocution_00"].length)
							{
								if (this.LightSwitch.Flicker)
								{
									this.CharacterAnimation["f02_electrocution_00"].speed = 1f;
									this.Prompt.Label[0].text = "     Turn Off";
									this.LightSwitch.BathroomLight.SetActive(true);
									this.RightDrill.localEulerAngles = new Vector3(0f, 0f, 68.30447f);
									this.LeftDrill.localEulerAngles = new Vector3(0f, -180f, -159.417f);
									this.LightSwitch.Flicker = false;
									this.Unspook();
									this.UnWet();
								}
							}
							else if (this.CharacterAnimation["f02_electrocution_00"].time >= this.CharacterAnimation["f02_electrocution_00"].length)
							{
								this.Police.ElectrocutedStudentName = this.Name;
								this.Police.ElectroScene = true;
								this.Electrocuted = true;
								this.BecomeRagdoll();
								this.DeathType = DeathType.Electrocution;
							}
						}
					}
				}
				else if (this.Pathfinding.canMove)
				{
					if (this.BathePhase == 1 || this.FleeWhenClean)
					{
						if (!this.NotActuallyWet)
						{
							this.CharacterAnimation[this.WetAnim].weight = 1f;
							this.CharacterAnimation.Play(this.WetAnim);
							this.Pathfinding.speed = 4f;
							if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
							{
								this.CharacterAnimation.CrossFade(this.OriginalSprintAnim);
							}
							else
							{
								this.CharacterAnimation.CrossFade(this.SprintAnim);
							}
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
						}
					}
					else
					{
						if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
						{
							this.CharacterAnimation.CrossFade(this.OriginalWalkAnim);
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
						}
						this.Pathfinding.speed = this.WalkSpeed;
					}
				}
			}
			if (this.Distracting)
			{
				if (this.DistractionTarget == null)
				{
					this.Distracting = false;
				}
				else if (this.DistractionTarget.Dying)
				{
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.DistractionTarget.TargetedForDistraction = false;
					this.DistractionTarget.Distracted = false;
					this.DistractionTarget.EmptyHands();
					this.Pathfinding.speed = this.WalkSpeed;
					this.Distracting = false;
					this.Distracted = false;
					this.CanTalk = true;
					this.Routine = true;
				}
				else
				{
					if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.ClubActivityPhase > 0 && this.DistractionTarget.InEvent)
					{
						this.GetFoodTarget();
					}
					if (this.DistanceToDestination < 5f || this.DistractionTarget.Leaving)
					{
						if (this.DistractionTarget.HelpOffered || this.DistractionTarget.InEvent || this.DistractionTarget.Talking || this.DistractionTarget.Following || this.DistractionTarget.TurnOffRadio || this.DistractionTarget.Splashed || this.DistractionTarget.Shoving || this.DistractionTarget.Spraying || this.DistractionTarget.FocusOnYandere || this.DistractionTarget.ShoeRemoval.enabled || this.DistractionTarget.Posing || this.DistractionTarget.ClubActivityPhase >= 16 || !this.DistractionTarget.enabled || this.DistractionTarget.Alarmed || this.DistractionTarget.Fleeing || this.DistractionTarget.Wet || this.DistractionTarget.EatingSnack || this.DistractionTarget.MyBento.Tampered || this.DistractionTarget.Meeting || this.DistractionTarget.InvestigatingBloodPool || this.DistractionTarget.ReturningMisplacedWeapon || this.StudentManager.LockerRoomArea.bounds.Contains(this.DistractionTarget.transform.position) || this.StudentManager.MaleLockerRoomArea.bounds.Contains(this.DistractionTarget.transform.position) || this.StudentManager.WestBathroomArea.bounds.Contains(this.DistractionTarget.transform.position) || this.StudentManager.EastBathroomArea.bounds.Contains(this.DistractionTarget.transform.position) || this.StudentManager.HeadmasterArea.bounds.Contains(this.DistractionTarget.transform.position) || (this.DistractionTarget.Actions[this.DistractionTarget.Phase] == StudentActionType.Bully && this.DistractionTarget.DistanceToDestination < 1f) || this.DistractionTarget.Leaving || this.DistractionTarget.CameraReacting)
						{
							this.CurrentDestination = this.Destinations[this.Phase];
							this.Pathfinding.target = this.Destinations[this.Phase];
							this.DistractionTarget.TargetedForDistraction = false;
							this.Distracting = false;
							this.Distracted = false;
							this.SpeechLines.Stop();
							this.CanTalk = true;
							this.Routine = true;
							this.Pathfinding.speed = this.WalkSpeed;
							if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
							{
								this.GetFoodTarget();
							}
						}
						else if (this.DistanceToDestination < this.TargetDistance)
						{
							if (!this.DistractionTarget.Distracted)
							{
								if (this.StudentID > 1 && this.DistractionTarget.StudentID > 1 && this.Persona != PersonaType.Fragile && this.DistractionTarget.Persona != PersonaType.Fragile && ((this.Club != ClubType.Bully && this.DistractionTarget.Club == ClubType.Bully) || (this.Club == ClubType.Bully && this.DistractionTarget.Club != ClubType.Bully)))
								{
									this.BullyPhotoCollider.SetActive(true);
								}
								if (this.DistractionTarget.Investigating)
								{
									this.DistractionTarget.StopInvestigating();
								}
								this.StudentManager.UpdateStudents(this.DistractionTarget.StudentID);
								this.DistractionTarget.Pathfinding.canSearch = false;
								this.DistractionTarget.Pathfinding.canMove = false;
								this.DistractionTarget.OccultBook.SetActive(false);
								this.DistractionTarget.SmartPhone.SetActive(false);
								this.DistractionTarget.Distraction = base.transform;
								this.DistractionTarget.CameraReacting = false;
								this.DistractionTarget.Pathfinding.speed = 0f;
								this.DistractionTarget.Pen.SetActive(false);
								this.DistractionTarget.Drownable = false;
								this.DistractionTarget.Distracted = true;
								this.DistractionTarget.Pushable = false;
								this.DistractionTarget.Routine = false;
								this.DistractionTarget.CanTalk = false;
								this.DistractionTarget.ReadPhase = 0;
								this.DistractionTarget.SpeechLines.Stop();
								this.DistractionTarget.ChalkDust.Stop();
								this.DistractionTarget.CleanTimer = 0f;
								this.DistractionTarget.EmptyHands();
								this.DistractionTarget.Distractor = this;
								this.Pathfinding.speed = 0f;
								this.Distracted = true;
							}
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.DistractionTarget.transform.position.x, base.transform.position.y, this.DistractionTarget.transform.position.z) - base.transform.position);
							base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
							if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
							{
								this.CharacterAnimation.CrossFade(this.IdleAnim);
							}
							else
							{
								this.DistractionTarget.SpeechLines.Play();
								this.SpeechLines.Play();
								this.CharacterAnimation.CrossFade(this.RandomAnim);
								if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
								{
									this.PickRandomAnim();
								}
							}
							this.DistractTimer -= Time.deltaTime;
							if (this.DistractTimer <= 0f)
							{
								if (this.SunbathePhase == 0)
								{
									this.CurrentDestination = this.Destinations[this.Phase];
									this.Pathfinding.target = this.Destinations[this.Phase];
								}
								else
								{
									this.CurrentDestination = this.StudentManager.SunbatheSpots[this.StudentID];
									this.Pathfinding.target = this.StudentManager.SunbatheSpots[this.StudentID];
									Debug.Log("This sunbathing student should be returning to their sunbathing spot now.");
								}
								this.DistractionTarget.TargetedForDistraction = false;
								this.DistractionTarget.Pathfinding.canSearch = true;
								this.DistractionTarget.Pathfinding.canMove = true;
								this.DistractionTarget.Pathfinding.speed = 1f;
								this.DistractionTarget.Octodog.SetActive(false);
								this.DistractionTarget.Distraction = null;
								this.DistractionTarget.Distracted = false;
								this.DistractionTarget.CanTalk = true;
								this.DistractionTarget.Routine = true;
								this.DistractionTarget.EquipCleaningItems();
								this.DistractionTarget.EatingSnack = false;
								this.Private = false;
								this.DistractionTarget.CurrentDestination = this.DistractionTarget.Destinations[this.Phase];
								this.DistractionTarget.Pathfinding.target = this.DistractionTarget.Destinations[this.Phase];
								if (this.DistractionTarget.Persona == PersonaType.PhoneAddict)
								{
									this.DistractionTarget.SmartPhone.SetActive(true);
								}
								this.DistractionTarget.Distractor = null;
								this.DistractionTarget.SpeechLines.Stop();
								this.SpeechLines.Stop();
								this.BullyPhotoCollider.SetActive(false);
								this.Pathfinding.speed = this.WalkSpeed;
								this.Distracting = false;
								this.Distracted = false;
								this.CanTalk = true;
								this.Routine = true;
								if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
								{
									this.GetFoodTarget();
								}
								if (this.StudentID == this.StudentManager.SuitorID && this.StudentManager.DatingMinigame.SuitorAndRivalTalking)
								{
									Debug.Log("Fire ''CalculateLove()''");
									this.StudentManager.LoveManager.Courted = true;
									this.DialogueWheel.AdviceWindow.CalculateLove();
									this.StudentManager.DatingMinigame.SuitorAndRivalTalking = false;
								}
							}
						}
						else if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
						}
						else if (this.Pathfinding.speed == this.WalkSpeed)
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.SprintAnim);
						}
					}
					else if (this.Actions[this.Phase] == StudentActionType.ClubAction && this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						if (this.Phase < this.ScheduleBlocks.Length - 1 && this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time)
						{
							this.Routine = true;
						}
					}
					else if (this.Pathfinding.speed == this.WalkSpeed)
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.SprintAnim);
					}
				}
			}
			if (this.Hunting)
			{
				if (this.HuntTarget != null)
				{
					if (this.HuntTarget.Prompt.enabled && !this.HuntTarget.FightingSlave)
					{
						this.HuntTarget.Prompt.Hide();
						this.HuntTarget.Prompt.enabled = false;
					}
					this.Pathfinding.target = this.HuntTarget.transform;
					this.CurrentDestination = this.HuntTarget.transform;
					if (this.HuntTarget.Alive && !this.HuntTarget.Tranquil && !this.HuntTarget.PinningDown)
					{
						if (this.DistanceToDestination > this.TargetDistance)
						{
							if (this.MurderSuicidePhase == 0)
							{
								if (this.CharacterAnimation["f02_brokenStandUp_00"].time >= this.CharacterAnimation["f02_brokenStandUp_00"].length)
								{
									this.MurderSuicidePhase++;
									this.Pathfinding.canSearch = true;
									this.Pathfinding.canMove = true;
									this.CharacterAnimation.CrossFade(this.WalkAnim);
									this.Pathfinding.speed = 1.15f;
								}
							}
							else if (this.MurderSuicidePhase > 1)
							{
								this.CharacterAnimation.CrossFade(this.WalkAnim);
								this.HuntTarget.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.01f);
							}
							if (this.HuntTarget.Dying || this.HuntTarget.Struggling || this.HuntTarget.Ragdoll.enabled || (this.HuntTarget.Hunter != null && this.HuntTarget.Hunter != this))
							{
								this.Hunting = false;
								this.Suicide = true;
							}
						}
						else if (this.HuntTarget.ClubActivityPhase >= 16)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						else if (!this.NEStairs.bounds.Contains(base.transform.position) && !this.NWStairs.bounds.Contains(base.transform.position) && !this.SEStairs.bounds.Contains(base.transform.position) && !this.SWStairs.bounds.Contains(base.transform.position) && !this.NEStairs.bounds.Contains(this.HuntTarget.transform.position) && !this.NWStairs.bounds.Contains(this.HuntTarget.transform.position) && !this.SEStairs.bounds.Contains(this.HuntTarget.transform.position) && !this.SWStairs.bounds.Contains(this.HuntTarget.transform.position))
						{
							if (this.Pathfinding.canMove)
							{
								Debug.Log("Slave is attacking target!");
								if (this.HuntTarget.Strength == 9 && this.StudentID != 11)
								{
									this.AttackWillFail = true;
								}
								if (!this.AttackWillFail)
								{
									this.CharacterAnimation.CrossFade("f02_murderSuicide_00");
								}
								else
								{
									this.CharacterAnimation.CrossFade("f02_brokenAttackFailA_00");
									this.CharacterAnimation[this.WetAnim].weight = 0f;
									this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
									this.Police.Corpses++;
									GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
									this.MapMarker.gameObject.layer = 10;
									base.tag = "Blood";
									this.Ragdoll.MurderSuicideAnimation = true;
									this.Ragdoll.Disturbing = true;
									this.Dying = true;
									this.HipCollider.enabled = true;
									this.HipCollider.radius = 1f;
									this.MurderSuicidePhase = 9;
								}
								this.Pathfinding.canSearch = false;
								this.Pathfinding.canMove = false;
								this.Broken.Subtitle.text = string.Empty;
								this.MyController.radius = 0f;
								this.Broken.Done = true;
								if (!this.AttackWillFail)
								{
									AudioSource.PlayClipAtPoint(this.MurderSuicideSounds, base.transform.position + new Vector3(0f, 1f, 0f));
									AudioSource component3 = base.GetComponent<AudioSource>();
									component3.clip = this.MurderSuicideKiller;
									component3.Play();
								}
								if (this.HuntTarget.Shoving)
								{
									this.Yandere.CannotRecover = false;
								}
								if (this.StudentManager.CombatMinigame.Delinquent == this.HuntTarget)
								{
									this.StudentManager.CombatMinigame.Stop();
									this.StudentManager.CombatMinigame.ReleaseYandere();
								}
								if (!this.AttackWillFail)
								{
									this.HuntTarget.HipCollider.enabled = true;
									this.HuntTarget.HipCollider.radius = 1f;
									this.HuntTarget.DetectionMarker.Tex.enabled = false;
								}
								this.HuntTarget.CharacterAnimation[this.HuntTarget.WetAnim].weight = 0f;
								this.HuntTarget.TargetedForDistraction = false;
								this.HuntTarget.Pathfinding.canSearch = false;
								this.HuntTarget.Pathfinding.canMove = false;
								this.HuntTarget.WitnessCamera.Show = false;
								this.HuntTarget.CameraReacting = false;
								this.HuntTarget.Investigating = false;
								this.HuntTarget.Distracting = false;
								this.HuntTarget.Splashed = false;
								this.HuntTarget.Alarmed = false;
								this.HuntTarget.Burning = false;
								this.HuntTarget.Fleeing = false;
								this.HuntTarget.Routine = false;
								this.HuntTarget.Shoving = false;
								this.HuntTarget.Tripped = false;
								this.HuntTarget.Wet = false;
								this.HuntTarget.Blind = true;
								this.HuntTarget.Hunter = this;
								this.HuntTarget.Prompt.Hide();
								this.HuntTarget.Prompt.enabled = false;
								if (this.Yandere.Pursuer == this.HuntTarget)
								{
									this.Yandere.Chased = false;
									this.Yandere.Pursuer = null;
								}
								if (!this.AttackWillFail)
								{
									if (!this.HuntTarget.Male)
									{
										this.HuntTarget.CharacterAnimation.CrossFade("f02_murderSuicide_01");
									}
									else
									{
										this.HuntTarget.CharacterAnimation.CrossFade("murderSuicide_01");
									}
									this.HuntTarget.CharacterAnimation[this.HuntTarget.WetAnim].weight = 0f;
									this.HuntTarget.Subtitle.UpdateLabel(SubtitleType.Dying, 0, 1f);
									this.HuntTarget.GetComponent<AudioSource>().clip = this.HuntTarget.MurderSuicideVictim;
									this.HuntTarget.GetComponent<AudioSource>().Play();
									this.Police.CorpseList[this.Police.Corpses] = this.HuntTarget.Ragdoll;
									this.Police.Corpses++;
									GameObjectUtils.SetLayerRecursively(this.HuntTarget.gameObject, 11);
									this.MapMarker.gameObject.layer = 10;
									this.HuntTarget.tag = "Blood";
									this.HuntTarget.Ragdoll.MurderSuicideAnimation = true;
									this.HuntTarget.Ragdoll.Disturbing = true;
									this.HuntTarget.Dying = true;
									this.HuntTarget.MurderSuicidePhase = 100;
								}
								else
								{
									this.HuntTarget.CharacterAnimation.CrossFade("f02_brokenAttackFailB_00");
									this.HuntTarget.FightingSlave = true;
									this.HuntTarget.Distracted = true;
									this.HuntTarget.Blind = false;
									this.MyWeapon.transform.parent = this.ItemParent;
									this.MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
									this.MyWeapon.transform.localPosition = Vector3.zero;
									this.MyWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
									this.StudentManager.UpdateMe(this.HuntTarget.StudentID);
								}
								this.HuntTarget.MyController.radius = 0f;
								this.HuntTarget.SpeechLines.Stop();
								this.HuntTarget.EyeShrink = 1f;
								this.HuntTarget.SpawnAlarmDisc();
								if (this.HuntTarget.Following)
								{
									this.Yandere.Follower = null;
									this.Yandere.Followers--;
									this.Hearts.emission.enabled = false;
									this.HuntTarget.FollowCountdown.gameObject.SetActive(false);
									this.HuntTarget.Following = false;
								}
								this.OriginalYPosition = this.HuntTarget.transform.position.y;
								if (this.MurderSuicidePhase == 0)
								{
									this.MurderSuicidePhase++;
								}
							}
							else
							{
								if (this.Dying)
								{
									this.Yandere.NearMindSlave = (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 5f);
								}
								if (this.MurderSuicidePhase == 0 && this.CharacterAnimation["f02_brokenStandUp_00"].time >= this.CharacterAnimation["f02_brokenStandUp_00"].length)
								{
									this.Pathfinding.canSearch = true;
									this.Pathfinding.canMove = true;
								}
								if (this.MurderSuicidePhase > 0)
								{
									if (!this.AttackWillFail)
									{
										this.HuntTarget.targetRotation = Quaternion.LookRotation(this.HuntTarget.transform.position - base.transform.position);
										this.HuntTarget.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.01f);
									}
									else
									{
										this.HuntTarget.targetRotation = Quaternion.LookRotation(base.transform.position - this.HuntTarget.transform.position);
										this.HuntTarget.MoveTowardsTarget(base.transform.position + base.transform.forward * 1f);
									}
									this.HuntTarget.transform.rotation = Quaternion.Slerp(this.HuntTarget.transform.rotation, this.HuntTarget.targetRotation, Time.deltaTime * 10f);
									this.HuntTarget.transform.position = new Vector3(this.HuntTarget.transform.position.x, this.OriginalYPosition, this.HuntTarget.transform.position.z);
									this.targetRotation = Quaternion.LookRotation(this.HuntTarget.transform.position - base.transform.position);
									base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
								}
								if (this.MurderSuicidePhase == 1)
								{
									if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 2.4f)
									{
										this.MyWeapon.transform.parent = this.ItemParent;
										this.MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
										this.MyWeapon.transform.localPosition = Vector3.zero;
										this.MyWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
										this.MurderSuicidePhase++;
									}
								}
								else if (this.MurderSuicidePhase == 2)
								{
									if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 3.3f)
									{
										GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.Ragdoll.BloodPoolSpawner.BloodPool, base.transform.position + base.transform.up * 0.012f + base.transform.forward, Quaternion.identity);
										gameObject6.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
										gameObject6.transform.parent = this.Police.BloodParent;
										this.MyWeapon.Victims[this.HuntTarget.StudentID] = true;
										this.MyWeapon.Blood.enabled = true;
										if (!this.MyWeapon.Evidence)
										{
											this.MyWeapon.MurderWeapon = true;
											this.MyWeapon.Evidence = true;
											this.Police.MurderWeapons++;
										}
										UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
										this.KnifeDown = true;
										this.LiquidProjector.material.mainTexture = this.BloodTexture;
										this.LiquidProjector.gameObject.SetActive(true);
										this.LiquidProjector.enabled = true;
										this.HuntTarget.LiquidProjector.material.mainTexture = this.HuntTarget.BloodTexture;
										this.HuntTarget.LiquidProjector.gameObject.SetActive(true);
										this.HuntTarget.LiquidProjector.enabled = true;
										this.MurderSuicidePhase++;
									}
								}
								else if (this.MurderSuicidePhase == 3)
								{
									if (!this.KnifeDown)
									{
										if (this.MyWeapon.transform.position.y < base.transform.position.y + 0.33333334f)
										{
											UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
											this.KnifeDown = true;
											Debug.Log("Stab!");
										}
									}
									else if (this.MyWeapon.transform.position.y > base.transform.position.y + 0.33333334f)
									{
										this.KnifeDown = false;
									}
									if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 16.666666f)
									{
										Debug.Log("Released knife!");
										this.MyWeapon.transform.parent = null;
										this.MurderSuicidePhase++;
									}
								}
								else if (this.MurderSuicidePhase == 4)
								{
									if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 18.9f)
									{
										Debug.Log("Yanked out knife!");
										UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
										this.MyWeapon.transform.parent = this.ItemParent;
										this.MyWeapon.transform.localPosition = Vector3.zero;
										this.MyWeapon.transform.localEulerAngles = Vector3.zero;
										this.MurderSuicidePhase++;
									}
								}
								else if (this.MurderSuicidePhase == 5)
								{
									if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 26.166666f)
									{
										Debug.Log("Stabbed neck!");
										UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
										this.MyWeapon.Victims[this.StudentID] = true;
										this.MurderSuicidePhase++;
									}
								}
								else if (this.MurderSuicidePhase == 6)
								{
									if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 30.5f)
									{
										Debug.Log("BLOOD FOUNTAIN!");
										this.BloodFountain.Play();
										this.MurderSuicidePhase++;
									}
								}
								else if (this.MurderSuicidePhase == 7)
								{
									if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 31.5f)
									{
										this.BloodSprayCollider.SetActive(true);
										this.MurderSuicidePhase++;
									}
								}
								else if (this.MurderSuicidePhase == 8)
								{
									if (this.CharacterAnimation["f02_murderSuicide_00"].time >= this.CharacterAnimation["f02_murderSuicide_00"].length)
									{
										this.Yandere.NearMindSlave = false;
										this.MyWeapon.transform.parent = null;
										this.MyWeapon.Drop();
										this.MyWeapon = null;
										this.StudentManager.StopHesitating();
										this.HuntTarget.HipCollider.radius = 0.5f;
										this.HuntTarget.BecomeRagdoll();
										this.HuntTarget.MurderedByStudent = true;
										this.HuntTarget.Ragdoll.Disturbing = false;
										this.HuntTarget.Ragdoll.MurderSuicide = true;
										this.HuntTarget.DeathType = DeathType.Weapon;
										if (this.FragileSlave)
										{
											this.HuntTarget.MurderedByFragile = true;
											this.HuntTarget.Hunted = true;
										}
										if (this.HuntTarget.Follower != null)
										{
											Debug.Log("This mind-broken slave just killed someone who had a follower.");
											if (this.HuntTarget.Follower.WitnessedMindBrokenMurder)
											{
												Debug.Log("The follower's ''Corpse'' variable is being set to: " + this.HuntTarget.Ragdoll.Student.Name);
												this.HuntTarget.Follower.Corpse = this.HuntTarget.Ragdoll;
											}
										}
										if (this.BloodSprayCollider != null)
										{
											this.BloodSprayCollider.SetActive(false);
										}
										this.BecomeRagdoll();
										this.DeathType = DeathType.Weapon;
										this.StudentManager.MurderTakingPlace = false;
										this.Ragdoll.MurderSuicide = true;
										this.MurderSuicide = true;
										this.Broken.HairPhysics[0].enabled = true;
										this.Broken.HairPhysics[1].enabled = true;
										this.Broken.enabled = false;
										this.Hunting = false;
										if (this.StudentID > 10 && this.StudentID < 21)
										{
											Debug.Log("A former rival killed herself as a mind-broken slave. StudentManager will be informed.");
											this.StudentManager.UpdateRivalEliminationDetails(this.StudentID);
										}
									}
								}
								else if (this.MurderSuicidePhase == 9)
								{
									this.CharacterAnimation.CrossFade("f02_brokenAttackFailA_00");
									if (this.CharacterAnimation["f02_brokenAttackFailA_00"].time >= this.CharacterAnimation["f02_brokenAttackFailA_00"].length)
									{
										this.Yandere.NearMindSlave = false;
										this.MurderSuicidePhase = 1;
										this.Hunting = false;
										this.Suicide = true;
										this.HuntTarget.MyController.radius = 0.1f;
										this.HuntTarget.Distracted = false;
										this.HuntTarget.Routine = true;
										if (this.StudentID > 10 && this.StudentID < 21)
										{
											Debug.Log("A former rival killed herself as a mind-broken slave. StudentManager will be informed.");
											this.StudentManager.UpdateRivalEliminationDetails(this.StudentID);
										}
									}
								}
							}
						}
					}
					else
					{
						this.Hunting = false;
						this.Suicide = true;
					}
				}
				else
				{
					this.Hunting = false;
					this.Suicide = true;
				}
			}
			if (this.Suicide)
			{
				if (this.MurderSuicidePhase == 0)
				{
					if (this.CharacterAnimation["f02_brokenStandUp_00"].time >= this.CharacterAnimation["f02_brokenStandUp_00"].length)
					{
						this.MurderSuicidePhase++;
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Pathfinding.speed = 0f;
						this.CharacterAnimation.CrossFade("f02_suicide_00");
					}
				}
				else if (this.MurderSuicidePhase == 1)
				{
					if (this.Pathfinding.speed > 0f)
					{
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Pathfinding.speed = 0f;
						this.CharacterAnimation.CrossFade("f02_suicide_00");
					}
					if (this.CharacterAnimation["f02_suicide_00"].time >= 0.73333335f)
					{
						this.MyWeapon.transform.parent = this.ItemParent;
						this.MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
						this.MyWeapon.transform.localPosition = Vector3.zero;
						this.MyWeapon.transform.localEulerAngles = Vector3.zero;
						this.Broken.Subtitle.text = string.Empty;
						this.Broken.Done = true;
						this.MurderSuicidePhase++;
					}
				}
				else if (this.MurderSuicidePhase == 2)
				{
					if (this.CharacterAnimation["f02_suicide_00"].time >= 4.1666665f)
					{
						Debug.Log("Stabbed neck!");
						UnityEngine.Object.Instantiate<GameObject>(this.StabBloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
						this.MyWeapon.Victims[this.StudentID] = true;
						this.MyWeapon.Blood.enabled = true;
						if (!this.MyWeapon.Evidence)
						{
							this.MyWeapon.Evidence = true;
							this.Police.MurderWeapons++;
						}
						this.MurderSuicidePhase++;
					}
				}
				else if (this.MurderSuicidePhase == 3)
				{
					if (this.CharacterAnimation["f02_suicide_00"].time >= 6.1666665f)
					{
						Debug.Log("BLOOD FOUNTAIN!");
						this.BloodFountain.gameObject.GetComponent<AudioSource>().Play();
						this.BloodFountain.Play();
						this.MurderSuicidePhase++;
					}
				}
				else if (this.MurderSuicidePhase == 4)
				{
					if (this.CharacterAnimation["f02_suicide_00"].time >= 7f)
					{
						this.Ragdoll.BloodPoolSpawner.SpawnPool(base.transform);
						this.BloodSprayCollider.SetActive(true);
						this.MurderSuicidePhase++;
					}
				}
				else if (this.MurderSuicidePhase == 5 && this.CharacterAnimation["f02_suicide_00"].time >= this.CharacterAnimation["f02_suicide_00"].length)
				{
					this.MyWeapon.transform.parent = null;
					this.MyWeapon.Drop();
					this.MyWeapon = null;
					this.StudentManager.StopHesitating();
					if (this.BloodSprayCollider != null)
					{
						this.BloodSprayCollider.SetActive(false);
					}
					this.BecomeRagdoll();
					this.DeathType = DeathType.Weapon;
					this.Broken.HairPhysics[0].enabled = true;
					this.Broken.HairPhysics[1].enabled = true;
					this.Broken.enabled = false;
				}
			}
			if (this.CameraReacting)
			{
				this.PhotoPatience = Mathf.MoveTowards(this.PhotoPatience, 0f, Time.deltaTime);
				this.Prompt.Circle[0].fillAmount = 1f;
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				if (!this.Yandere.ClubAccessories[7].activeInHierarchy || this.Club == ClubType.Delinquent)
				{
					if (this.CameraReactPhase == 1)
					{
						if (this.CharacterAnimation[this.CameraAnims[1]].time >= this.CharacterAnimation[this.CameraAnims[1]].length)
						{
							this.CharacterAnimation.CrossFade(this.CameraAnims[2]);
							this.CameraReactPhase = 2;
							this.CameraPoseTimer = 1f;
						}
					}
					else if (this.CameraReactPhase == 2)
					{
						this.CameraPoseTimer -= Time.deltaTime;
						if (this.CameraPoseTimer <= 0f)
						{
							this.CharacterAnimation.CrossFade(this.CameraAnims[3]);
							this.CameraReactPhase = 3;
						}
					}
					else if (this.CameraReactPhase == 3)
					{
						if (this.CameraPoseTimer == 1f)
						{
							this.CharacterAnimation.CrossFade(this.CameraAnims[2]);
							this.CameraReactPhase = 2;
						}
						if (this.CharacterAnimation[this.CameraAnims[3]].time >= this.CharacterAnimation[this.CameraAnims[3]].length)
						{
							if (!this.Phoneless && (this.Persona == PersonaType.PhoneAddict || this.Sleuthing))
							{
								this.SmartPhone.SetActive(true);
							}
							if (!this.Male && this.Cigarette.activeInHierarchy)
							{
								this.SmartPhone.SetActive(false);
							}
							this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
							this.Obstacle.enabled = false;
							this.CameraReacting = false;
							this.Routine = true;
							this.ReadPhase = 0;
							if (this.Actions[this.Phase] == StudentActionType.Clean)
							{
								this.Scrubber.SetActive(true);
								if (this.CleaningRole == 5)
								{
									this.Eraser.SetActive(true);
								}
							}
						}
					}
				}
				else if (this.Yandere.Shutter.TargetStudent != this.StudentID)
				{
					this.CameraPoseTimer = Mathf.MoveTowards(this.CameraPoseTimer, 0f, Time.deltaTime);
					if (this.CameraPoseTimer == 0f)
					{
						if (!this.Phoneless && (this.Persona == PersonaType.PhoneAddict || this.Sleuthing))
						{
							this.SmartPhone.SetActive(true);
						}
						this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
						this.Obstacle.enabled = false;
						this.CameraReacting = false;
						this.Routine = true;
						this.ReadPhase = 0;
						if (this.Actions[this.Phase] == StudentActionType.Clean)
						{
							this.Scrubber.SetActive(true);
							if (this.CleaningRole == 5)
							{
								this.Eraser.SetActive(true);
							}
						}
					}
				}
				else
				{
					this.CameraPoseTimer = 1f;
				}
				if (this.InEvent)
				{
					this.CameraReacting = false;
					this.ReadPhase = 0;
				}
			}
			if (this.Investigating)
			{
				if (!this.YandereInnocent && this.InvestigationPhase < 100 && this.CanSeeObject(this.Yandere.gameObject, new Vector3(this.Yandere.HeadPosition.x, this.Yandere.transform.position.y + this.Yandere.Zoom.Height, this.Yandere.HeadPosition.z)))
				{
					if (Vector3.Distance(this.Yandere.transform.position, this.Giggle.transform.position) > 2.5f)
					{
						this.YandereInnocent = true;
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.InvestigationPhase = 100;
						this.InvestigationTimer = 0f;
					}
				}
				if (this.InvestigationPhase == 0)
				{
					if (this.InvestigationTimer < 5f)
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						if ((this.Persona == PersonaType.Heroic && this.HeardScream) || this.Persona == PersonaType.Protective)
						{
							this.InvestigationTimer += Time.deltaTime * 5f;
						}
						else
						{
							this.InvestigationTimer += Time.deltaTime;
						}
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.Giggle.transform.position.x, base.transform.position.y, this.Giggle.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					}
					else
					{
						this.Pathfinding.target = this.Giggle.transform;
						this.CurrentDestination = this.Giggle.transform;
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						if ((this.Persona == PersonaType.Heroic && this.HeardScream) || this.Persona == PersonaType.Protective)
						{
							this.CharacterAnimation.CrossFade(this.SprintAnim);
							this.Pathfinding.speed = 4f;
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
							this.Pathfinding.speed = this.WalkSpeed;
						}
						this.InvestigationPhase++;
					}
				}
				else if (this.InvestigationPhase == 1)
				{
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					if (this.DistanceToDestination > 1f)
					{
						if ((this.Persona == PersonaType.Heroic && this.HeardScream) || this.Persona == PersonaType.Protective)
						{
							this.CharacterAnimation.CrossFade(this.SprintAnim);
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
						}
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.InvestigationPhase++;
					}
				}
				else if (this.InvestigationPhase == 2)
				{
					if (this.Persona == PersonaType.Protective)
					{
						this.InvestigationTimer += Time.deltaTime * 2.5f;
					}
					else
					{
						this.InvestigationTimer += Time.deltaTime;
					}
					if (this.InvestigationTimer > 10f)
					{
						Debug.Log("This character has investigated for 10 seconds, and is done investigating now.");
						this.StopInvestigating();
					}
				}
				else if (this.InvestigationPhase == 100)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.InvestigationTimer += Time.deltaTime;
					if (this.InvestigationTimer > 2f)
					{
						Debug.Log("This character was in InvestigationPhase 100.");
						this.StopInvestigating();
					}
				}
			}
			if (this.EndSearch)
			{
				this.MoveTowardsTarget(this.Pathfinding.target.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
				this.PatrolTimer += Time.deltaTime * this.CharacterAnimation[this.PatrolAnim].speed;
				if (this.PatrolTimer > 5f)
				{
					ScheduleBlock scheduleBlock21 = this.ScheduleBlocks[2];
					scheduleBlock21.destination = "Hangout";
					scheduleBlock21.action = "Hangout";
					if (this.Club == ClubType.Cooking || this.Club == ClubType.MartialArts)
					{
						scheduleBlock21.destination = "Club";
						scheduleBlock21.action = "Club";
					}
					ScheduleBlock scheduleBlock22 = this.ScheduleBlocks[4];
					scheduleBlock22.destination = "LunchSpot";
					scheduleBlock22.action = "Eat";
					ScheduleBlock scheduleBlock23 = this.ScheduleBlocks[7];
					scheduleBlock23.destination = "Hangout";
					scheduleBlock23.action = "Hangout";
					this.GetDestinations();
					Array.Copy(this.OriginalActions, this.Actions, this.OriginalActions.Length);
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.CurrentAction = this.Actions[this.Phase];
					this.DistanceToDestination = 100f;
					Debug.Log(this.Name + " has just reacquired their phone.");
					this.EndSearch = false;
					this.Phoneless = false;
					this.Routine = true;
					this.SprintAnim = this.OriginalSprintAnim;
					this.RunAnim = this.OriginalSprintAnim;
					this.WalkAnim = this.OriginalWalkAnim;
					if (this.Persona == PersonaType.PhoneAddict)
					{
						this.Yandere.TargetStudent.WalkAnim = this.PhoneAnims[1];
					}
					this.Pathfinding.speed = this.WalkSpeed;
					this.Hurry = false;
					this.StudentManager.CommunalLocker.RivalPhone.ReturnToOrigin();
					if (this.Follower != null)
					{
						this.Follower.TargetDistance = 0.5f;
					}
				}
			}
			if (this.Shoving)
			{
				if (this.SprayTimer > 0f)
				{
					this.SprayTimer = Mathf.MoveTowards(this.SprayTimer, 0f, Time.deltaTime);
				}
				this.CharacterAnimation.CrossFade(this.ShoveAnim);
				if (this.CharacterAnimation[this.ShoveAnim].time > this.CharacterAnimation[this.ShoveAnim].length)
				{
					if ((this.Club != ClubType.Council && this.Persona != PersonaType.Violent) || this.RespectEarned)
					{
						this.Patience = 999;
					}
					if (this.Patience > 0)
					{
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Distracted = false;
						this.Shoving = false;
						this.Routine = true;
						this.Paired = false;
					}
					else if (this.Club == ClubType.Council)
					{
						this.Shoving = false;
						this.Spray();
					}
					else
					{
						this.SpawnAlarmDisc();
						this.SmartPhone.SetActive(false);
						this.Distracted = true;
						this.Threatened = true;
						this.Shoving = false;
						this.Alarmed = true;
					}
				}
			}
			if (this.Spraying)
			{
				this.CharacterAnimation.CrossFade(this.SprayAnim);
				this.Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
				this.Yandere.Attacking = false;
				if ((double)this.CharacterAnimation[this.SprayAnim].time > 0.66666)
				{
					if (this.Yandere.Armed)
					{
						this.Yandere.EquippedWeapon.Drop();
					}
					this.Yandere.EmptyHands();
					this.PepperSprayEffect.Play();
					this.Spraying = false;
					base.enabled = false;
				}
			}
			if (this.SentHome)
			{
				if (this.SentHomePhase == 0)
				{
					if (this.Shy)
					{
						this.CharacterAnimation[this.ShyAnim].weight = 0f;
					}
					this.CharacterAnimation.CrossFade(this.SentHomeAnim);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.SentHomePhase++;
					if (this.SmartPhone.activeInHierarchy)
					{
						this.CharacterAnimation[this.SentHomeAnim].time = 1.5f;
						this.SentHomePhase++;
					}
				}
				else if (this.SentHomePhase == 1)
				{
					if (this.CharacterAnimation[this.SentHomeAnim].time > 0.66666f)
					{
						this.SmartPhone.SetActive(true);
						this.SentHomePhase++;
					}
				}
				else if (this.SentHomePhase == 2 && this.CharacterAnimation[this.SentHomeAnim].time > this.CharacterAnimation[this.SentHomeAnim].length)
				{
					this.SprintAnim = this.OriginalSprintAnim;
					this.CharacterAnimation.CrossFade(this.SprintAnim);
					this.CurrentDestination = this.StudentManager.Exit;
					this.Pathfinding.target = this.StudentManager.Exit;
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.SmartPhone.SetActive(false);
					this.Pathfinding.speed = 4f;
					this.SentHomePhase++;
				}
			}
			if (this.DramaticReaction)
			{
				this.DramaticCamera.transform.Translate(Vector3.forward * Time.deltaTime * 0.01f);
				if (this.DramaticPhase == 0)
				{
					this.DramaticCamera.rect = new Rect(0f, Mathf.Lerp(this.DramaticCamera.rect.y, 0.25f, Time.deltaTime * 10f), 1f, Mathf.Lerp(this.DramaticCamera.rect.height, 0.5f, Time.deltaTime * 10f));
					this.DramaticTimer += Time.deltaTime;
					if (this.DramaticTimer > 1f)
					{
						this.DramaticTimer = 0f;
						this.DramaticPhase++;
					}
				}
				else if (this.DramaticPhase == 1)
				{
					this.DramaticCamera.rect = new Rect(0f, Mathf.Lerp(this.DramaticCamera.rect.y, 0.5f, Time.deltaTime * 10f), 1f, Mathf.Lerp(this.DramaticCamera.rect.height, 0f, Time.deltaTime * 10f));
					this.DramaticTimer += Time.deltaTime;
					if (this.DramaticCamera.rect.height < 0.01f || this.DramaticTimer > 0.5f)
					{
						Debug.Log("Disabling Dramatic Camera.");
						this.DramaticCamera.gameObject.SetActive(false);
						this.AttackReaction();
						this.DramaticPhase++;
					}
				}
			}
			if (this.HitReacting && this.CharacterAnimation[this.SithReactAnim].time >= this.CharacterAnimation[this.SithReactAnim].length)
			{
				this.Persona = PersonaType.SocialButterfly;
				this.PersonaReaction();
				this.HitReacting = false;
			}
			if (this.Eaten)
			{
				if (this.Yandere.Eating)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				}
				if (this.CharacterAnimation[this.EatVictimAnim].time >= this.CharacterAnimation[this.EatVictimAnim].length)
				{
					this.BecomeRagdoll();
				}
			}
			if (this.Electrified)
			{
				this.CharacterAnimation.CrossFade(this.ElectroAnim);
				if (this.CharacterAnimation[this.ElectroAnim].time >= this.CharacterAnimation[this.ElectroAnim].length)
				{
					this.Electrocuted = true;
					this.BecomeRagdoll();
					this.DeathType = DeathType.Electrocution;
					if (this.OsanaHairL != null)
					{
						this.OsanaHairL.GetComponent<DynamicBone>().enabled = true;
						this.OsanaHairR.GetComponent<DynamicBone>().enabled = true;
						this.OsanaHairL.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
						this.OsanaHairR.transform.localEulerAngles = new Vector3(0f, -90f, 180f);
					}
				}
				else if (this.CharacterAnimation[this.ElectroAnim].time < 6f && this.OsanaHairL != null)
				{
					this.OsanaHairL.transform.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
					this.OsanaHairR.transform.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
				}
			}
			if (this.BreakingUpFight)
			{
				this.targetRotation = this.Yandere.transform.rotation * Quaternion.Euler(0f, 90f, 0f);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.5f);
				if (this.StudentID == 87 && this.CandyBar != null)
				{
					if (this.CharacterAnimation[this.BreakUpAnim].time >= 4f)
					{
						this.CandyBar.SetActive(false);
					}
					else if ((double)this.CharacterAnimation[this.BreakUpAnim].time >= 0.16666666666)
					{
						this.CandyBar.SetActive(true);
					}
				}
				if (this.CharacterAnimation[this.BreakUpAnim].time != 0f && this.CharacterAnimation[this.BreakUpAnim].time >= this.CharacterAnimation[this.BreakUpAnim].length)
				{
					this.ReturnToRoutine();
				}
			}
			if (this.Tripping)
			{
				this.MoveTowardsTarget(new Vector3(0f, 0f, base.transform.position.z));
				this.CharacterAnimation.CrossFade("trip_00");
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
				if (this.CharacterAnimation["trip_00"].time >= 0.5f && this.CharacterAnimation["trip_00"].time <= 5.5f && this.StudentManager.Gate.Crushing)
				{
					this.BecomeRagdoll();
					this.DeathType = DeathType.Weight;
					this.Ragdoll.Decapitated = true;
					UnityEngine.Object.Instantiate<GameObject>(this.SquishyBloodEffect, this.Head.position, Quaternion.identity);
				}
				if (this.CharacterAnimation["trip_00"].time >= this.CharacterAnimation["trip_00"].length)
				{
					this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Distracted = true;
					this.Tripping = false;
					this.Routine = true;
					this.Tripped = true;
					this.BountyCollider.SetActive(true);
				}
			}
			if (this.SeekingMedicine)
			{
				if (this.StudentManager.Students[90] == null)
				{
					if (this.SeekMedicinePhase < 5)
					{
						this.SeekMedicinePhase = 5;
					}
				}
				else if ((!this.StudentManager.Students[90].gameObject.activeInHierarchy || this.StudentManager.Students[90].Dying) && this.SeekMedicinePhase < 5)
				{
					this.SeekMedicinePhase = 5;
				}
				if (this.SeekMedicinePhase == 0)
				{
					this.CurrentDestination = this.StudentManager.Students[90].transform;
					this.Pathfinding.target = this.StudentManager.Students[90].transform;
					this.SeekMedicinePhase++;
				}
				else if (this.SeekMedicinePhase == 1)
				{
					this.CharacterAnimation.CrossFade(this.SprintAnim);
					if (this.DistanceToDestination < 1f)
					{
						StudentScript studentScript3 = this.StudentManager.Students[90];
						if (studentScript3.Investigating)
						{
							studentScript3.StopInvestigating();
						}
						this.StudentManager.UpdateStudents(studentScript3.StudentID);
						studentScript3.Pathfinding.canSearch = false;
						studentScript3.Pathfinding.canMove = false;
						studentScript3.RetreivingMedicine = true;
						studentScript3.Pathfinding.speed = 0f;
						studentScript3.CameraReacting = false;
						studentScript3.TargetStudent = this;
						studentScript3.Routine = false;
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Pathfinding.speed = 0f;
						this.Subtitle.UpdateLabel(SubtitleType.RequestMedicine, 0, 5f);
						this.SeekMedicinePhase++;
					}
				}
				else if (this.SeekMedicinePhase == 2)
				{
					StudentScript studentScript4 = this.StudentManager.Students[90];
					this.targetRotation = Quaternion.LookRotation(new Vector3(studentScript4.transform.position.x, base.transform.position.y, studentScript4.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.MedicineTimer += Time.deltaTime;
					if (this.MedicineTimer > 5f)
					{
						this.SeekMedicinePhase++;
						this.MedicineTimer = 0f;
						studentScript4.Pathfinding.canSearch = true;
						studentScript4.Pathfinding.canMove = true;
						studentScript4.RetrieveMedicinePhase++;
					}
				}
				else if (this.SeekMedicinePhase != 3)
				{
					if (this.SeekMedicinePhase == 4)
					{
						StudentScript studentScript5 = this.StudentManager.Students[90];
						this.targetRotation = Quaternion.LookRotation(new Vector3(studentScript5.transform.position.x, base.transform.position.y, studentScript5.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					}
					else if (this.SeekMedicinePhase == 5)
					{
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						ScheduleBlock scheduleBlock24 = this.ScheduleBlocks[this.Phase];
						scheduleBlock24.destination = "InfirmarySeat";
						scheduleBlock24.action = "Relax";
						this.GetDestinations();
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
						this.Pathfinding.speed = 2f;
						this.RelaxAnim = this.HeadacheSitAnim;
						this.SeekingMedicine = false;
						this.Routine = true;
					}
				}
			}
			if (this.RetreivingMedicine)
			{
				if (this.RetrieveMedicinePhase == 0)
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				}
				else if (this.RetrieveMedicinePhase == 1)
				{
					this.CharacterAnimation.CrossFade(this.WalkAnim);
					this.CurrentDestination = this.StudentManager.MedicineCabinet;
					this.Pathfinding.target = this.StudentManager.MedicineCabinet;
					this.Pathfinding.speed = this.WalkSpeed;
					this.RetrieveMedicinePhase++;
				}
				else if (this.RetrieveMedicinePhase == 2)
				{
					if (this.DistanceToDestination < 1f)
					{
						this.StudentManager.CabinetDoor.Locked = false;
						this.StudentManager.CabinetDoor.Open = true;
						this.StudentManager.CabinetDoor.Timer = 0f;
						this.CurrentDestination = this.TargetStudent.transform;
						this.Pathfinding.target = this.TargetStudent.transform;
						this.RetrieveMedicinePhase++;
					}
				}
				else if (this.RetrieveMedicinePhase == 3)
				{
					if (this.DistanceToDestination < 1f)
					{
						this.CurrentDestination = this.TargetStudent.transform;
						this.Pathfinding.target = this.TargetStudent.transform;
						this.RetrieveMedicinePhase++;
					}
				}
				else if (this.RetrieveMedicinePhase == 4)
				{
					if (this.DistanceToDestination < 1f)
					{
						this.CharacterAnimation.CrossFade("f02_giveItem_00");
						if (this.TargetStudent.Male)
						{
							this.TargetStudent.CharacterAnimation.CrossFade("eatItem_00");
						}
						else
						{
							this.TargetStudent.CharacterAnimation.CrossFade("f02_eatItem_00");
						}
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.TargetStudent.SeekMedicinePhase++;
						this.RetrieveMedicinePhase++;
					}
				}
				else if (this.RetrieveMedicinePhase == 5)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					this.MedicineTimer += Time.deltaTime;
					if (this.MedicineTimer > 3f)
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
						this.CurrentDestination = this.StudentManager.MedicineCabinet;
						this.Pathfinding.target = this.StudentManager.MedicineCabinet;
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.TargetStudent.SeekMedicinePhase++;
						this.RetrieveMedicinePhase++;
					}
				}
				else if (this.RetrieveMedicinePhase == 6 && this.DistanceToDestination < 1f)
				{
					this.StudentManager.CabinetDoor.Locked = true;
					this.StudentManager.CabinetDoor.Open = false;
					this.StudentManager.CabinetDoor.Timer = 0f;
					this.RetreivingMedicine = false;
					this.Routine = true;
				}
			}
			if (this.EatingSnack)
			{
				if (this.SnackPhase == 0)
				{
					this.CharacterAnimation.CrossFade(this.EatChipsAnim);
					this.SmartPhone.SetActive(false);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.SnackTimer += Time.deltaTime;
					if (this.SnackTimer > 10f)
					{
						UnityEngine.Object.Destroy(this.BagOfChips);
						bool flag2 = false;
						if (!this.StudentManager.Eighties && this.StudentID == 11)
						{
							flag2 = true;
						}
						if (!flag2)
						{
							this.StudentManager.GetNearestFountain(this);
							if (this.Persona == PersonaType.Protective)
							{
								this.Pathfinding.speed = 4f;
							}
							this.Pathfinding.target = this.DrinkingFountain.DrinkPosition;
							this.CurrentDestination = this.DrinkingFountain.DrinkPosition;
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
							this.SnackTimer = 0f;
						}
						this.SnackPhase++;
					}
				}
				else if (this.SnackPhase == 1)
				{
					if (this.Pathfinding.speed < 4f)
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.RunAnim);
					}
					if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
					{
						this.SmartPhone.SetActive(true);
					}
					if (this.DistanceToDestination < 1f)
					{
						this.SmartPhone.SetActive(false);
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.SnackPhase++;
					}
				}
				else if (this.SnackPhase == 2)
				{
					this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.CharacterAnimation.CrossFade(this.DrinkFountainAnim);
					this.MoveTowardsTarget(this.DrinkingFountain.DrinkPosition.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.DrinkingFountain.DrinkPosition.rotation, 10f * Time.deltaTime);
					if (this.CharacterAnimation[this.DrinkFountainAnim].time >= this.CharacterAnimation[this.DrinkFountainAnim].length)
					{
						this.StopDrinking();
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
					}
					else if (this.CharacterAnimation[this.DrinkFountainAnim].time > 0.5f && this.CharacterAnimation[this.DrinkFountainAnim].time < 1.5f)
					{
						if (!this.DrinkingFountain.Sabotaged)
						{
							this.DrinkingFountain.WaterStream.Play();
						}
						else
						{
							this.StopDrinking();
							UnityEngine.Object.Instantiate<GameObject>(this.DrinkingFountain.WaterCollider, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
							this.DrinkingFountain.WaterBlast.Play();
						}
					}
				}
			}
			if (this.Dodging)
			{
				if (this.CharacterAnimation[this.DodgeAnim].time >= this.CharacterAnimation[this.DodgeAnim].length)
				{
					this.Dodging = false;
					if (!this.TurnOffRadio)
					{
						this.Routine = true;
					}
					else
					{
						Debug.Log("Hey. You. Walk.");
						this.CharacterAnimation.CrossFade(this.WalkAnim);
					}
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					if (this.GasWarned)
					{
						this.Yandere.Subtitle.UpdateLabel(SubtitleType.GasWarning, 2, 5f);
						this.GasWarned = false;
					}
				}
				else if (this.CharacterAnimation[this.DodgeAnim].time < 0.66666f)
				{
					this.MyController.Move(base.transform.forward * -1f * this.DodgeSpeed * Time.deltaTime);
					this.MyController.Move(Physics.gravity * 0.1f);
					if (this.DodgeSpeed > 0f)
					{
						this.DodgeSpeed = Mathf.MoveTowards(this.DodgeSpeed, 0f, Time.deltaTime * 3f);
					}
				}
			}
			if (!this.Guarding && this.InvestigatingBloodPool)
			{
				if (this.BloodPool != null)
				{
					if (Vector3.Distance(base.transform.position, new Vector3(this.BloodPool.position.x, base.transform.position.y, this.BloodPool.position.z)) < 1f)
					{
						this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						this.CharacterAnimation[this.InspectBloodAnim].speed = 1f;
						this.CharacterAnimation.CrossFade(this.InspectBloodAnim);
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Distracted = true;
						if (this.CharacterAnimation[this.InspectBloodAnim].time >= this.CharacterAnimation[this.InspectBloodAnim].length || this.Persona == PersonaType.Strict)
						{
							bool flag3 = false;
							if (this.Club == ClubType.Cooking && this.CurrentAction == StudentActionType.ClubAction)
							{
								flag3 = true;
							}
							if (this.WitnessedWeapon)
							{
								bool flag4 = false;
								if (!this.Teacher && this.BloodPool.GetComponent<WeaponScript>().Metal && this.StudentManager.MetalDetectors)
								{
									flag4 = true;
								}
								if (!this.WitnessedBloodyWeapon && this.StudentID > 1 && !flag4 && this.CurrentAction != StudentActionType.SitAndTakeNotes && this.Indoors && !flag3 && this.Club != ClubType.Delinquent && !this.BloodPool.GetComponent<WeaponScript>().Dangerous && this.BloodPool.GetComponent<WeaponScript>().Returner == null && this.BloodPool.GetComponent<WeaponScript>().Origin != null)
								{
									Debug.Log(this.Name + " has picked up a weapon with intent to return it to its original location.");
									this.CharacterAnimation[this.PickUpAnim].time = 0f;
									this.BloodPool.GetComponent<WeaponScript>().Prompt.Hide();
									this.BloodPool.GetComponent<WeaponScript>().Prompt.enabled = false;
									this.BloodPool.GetComponent<WeaponScript>().enabled = false;
									this.BloodPool.GetComponent<WeaponScript>().Returner = this;
									if (this.StudentID == 41 && !this.StudentManager.Eighties)
									{
										this.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
									}
									else
									{
										this.Subtitle.UpdateLabel(SubtitleType.ReturningWeapon, 0, 5f);
									}
									this.ReturningMisplacedWeapon = true;
									this.ReportingBlood = false;
									this.Distracted = false;
									this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
									this.Yandere.WeaponManager.ReturnWeaponID = this.BloodPool.GetComponent<WeaponScript>().GlobalID;
									this.Yandere.WeaponManager.ReturnStudentID = this.StudentID;
								}
							}
							this.InvestigatingBloodPool = false;
							this.WitnessCooldownTimer = 5f;
							if (this.WitnessedLimb)
							{
								this.SpawnAlarmDisc();
							}
							if (!this.ReturningMisplacedWeapon)
							{
								if (this.StudentManager.BloodReporter == this && this.WitnessedWeapon && !this.BloodPool.GetComponent<WeaponScript>().Dangerous)
								{
									this.StudentManager.BloodReporter = null;
								}
								if (this.StudentManager.BloodReporter == this && this.StudentID > 1)
								{
									if (this.Persona != PersonaType.Strict && this.Persona != PersonaType.Violent)
									{
										Debug.Log(this.Name + " has changed from their original Persona into a Teacher's Pet.");
										this.Persona = PersonaType.TeachersPet;
									}
									this.PersonaReaction();
								}
								else
								{
									this.Distracted = false;
									if (this.WitnessedWeapon && !this.WitnessedBloodyWeapon)
									{
										this.StopInvestigating();
										this.CurrentDestination = this.Destinations[this.Phase];
										this.Pathfinding.target = this.Destinations[this.Phase];
										this.LastSuspiciousObject2 = this.LastSuspiciousObject;
										this.LastSuspiciousObject = this.BloodPool;
										this.Pathfinding.canSearch = true;
										this.Pathfinding.canMove = true;
										this.Pathfinding.speed = this.WalkSpeed;
										if (this.StudentID == 41 && !this.StudentManager.Eighties)
										{
											this.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
										}
										else if (this.Club == ClubType.Delinquent)
										{
											this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 2, 3f);
										}
										else if (this.BloodPool.GetComponent<WeaponScript>().Dangerous)
										{
											this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 0, 3f);
										}
										else
										{
											this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 1, 3f);
										}
										this.WitnessedSomething = false;
										this.WitnessedWeapon = false;
										this.Routine = true;
										this.BloodPool = null;
										if (this.StudentManager.BloodReporter == this)
										{
											if (this.Persona != PersonaType.Strict && this.Persona != PersonaType.Violent)
											{
												Debug.Log(this.Name + " has changed from their original Persona into a Teacher's Pet.");
												this.Persona = PersonaType.TeachersPet;
											}
											this.PersonaReaction();
										}
									}
									else
									{
										Debug.Log(this.Name + " just found something scary on the ground and is going to react to it now.");
										if (this.Persona != PersonaType.Strict && this.Persona != PersonaType.Violent)
										{
											Debug.Log(this.Name + " has changed from their original Persona into a Teacher's Pet.");
											this.Persona = PersonaType.TeachersPet;
										}
										this.PersonaReaction();
									}
								}
								this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
							}
						}
					}
					else if (this.Persona == PersonaType.Strict)
					{
						if (this.WitnessedWeapon && this.BloodPool.GetComponent<WeaponScript>().Returner)
						{
							this.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
							this.CurrentDestination = this.Destinations[this.Phase];
							this.Pathfinding.target = this.Destinations[this.Phase];
							this.InvestigatingBloodPool = false;
							this.WitnessedBloodyWeapon = false;
							this.WitnessedBloodPool = false;
							this.WitnessedSomething = false;
							this.WitnessedWeapon = false;
							this.Distracted = false;
							this.Routine = true;
							this.BloodPool = null;
							this.WitnessCooldownTimer = 5f;
						}
						else if (this.BloodPool.parent == this.Yandere.RightHand || !this.BloodPool.gameObject.activeInHierarchy)
						{
							Debug.Log("Yandere-chan just picked up the weapon that was being investigated.");
							this.InvestigatingBloodPool = false;
							this.WitnessedBloodyWeapon = false;
							this.WitnessedBloodPool = false;
							this.WitnessedSomething = false;
							this.WitnessedWeapon = false;
							this.Distracted = false;
							this.Routine = true;
							if (this.BloodPool.GetComponent<WeaponScript>() != null && this.BloodPool.GetComponent<WeaponScript>().Suspicious)
							{
								this.WitnessCooldownTimer = 5f;
								this.AlarmTimer = 0f;
								this.Alarm = 200f;
							}
							this.BloodPool = null;
						}
					}
					else if (this.BloodPool == null || (this.WitnessedWeapon && this.BloodPool.parent != null) || (this.WitnessedBloodPool && this.BloodPool.parent == this.Yandere.RightHand) || (this.WitnessedWeapon && this.BloodPool.GetComponent<WeaponScript>().Returner))
					{
						this.ForgetAboutBloodPool();
					}
				}
				else
				{
					this.ForgetAboutBloodPool();
				}
			}
			if (this.ReturningMisplacedWeapon)
			{
				if (this.ReturningMisplacedWeaponPhase == 0)
				{
					this.CharacterAnimation.CrossFade(this.PickUpAnim);
					if ((this.Club == ClubType.Council || this.Teacher) && this.CharacterAnimation[this.PickUpAnim].time >= 0.33333f)
					{
						this.Handkerchief.SetActive(true);
					}
					if (this.CharacterAnimation[this.PickUpAnim].time >= 2f)
					{
						this.BloodPool.parent = this.RightHand;
						this.BloodPool.localPosition = new Vector3(0f, 0f, 0f);
						this.BloodPool.localEulerAngles = new Vector3(0f, 0f, 0f);
						if (this.Club != ClubType.Council && !this.Teacher)
						{
							this.BloodPool.GetComponent<WeaponScript>().FingerprintID = this.StudentID;
						}
					}
					if (this.CharacterAnimation[this.PickUpAnim].time >= this.CharacterAnimation[this.PickUpAnim].length)
					{
						this.CurrentDestination = this.BloodPool.GetComponent<WeaponScript>().Origin;
						this.Pathfinding.target = this.BloodPool.GetComponent<WeaponScript>().Origin;
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Pathfinding.speed = this.WalkSpeed;
						this.Hurry = false;
						this.ReturningMisplacedWeaponPhase++;
					}
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.WalkAnim);
					if (this.DistanceToDestination < 1.1f)
					{
						this.ReturnMisplacedWeapon();
					}
				}
			}
			if (this.SentToLocker && !this.CheckingNote)
			{
				this.CharacterAnimation.CrossFade(this.RunAnim);
			}
			if (this.Stripping)
			{
				this.CharacterAnimation.CrossFade(this.StripAnim);
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
				if (this.CharacterAnimation[this.StripAnim].time >= 1.5f)
				{
					if (this.Schoolwear != 1)
					{
						this.Schoolwear = 1;
						this.ChangeSchoolwear();
						this.WalkAnim = this.OriginalWalkAnim;
					}
					if (this.CharacterAnimation[this.StripAnim].time > this.CharacterAnimation[this.StripAnim].length)
					{
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Stripping = false;
						this.Routine = true;
					}
				}
			}
			if (this.SenpaiWitnessingRivalDie)
			{
				this.Fleeing = false;
				if (this.DistanceToDestination < 1f)
				{
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
				}
				if (this.WitnessRivalDiePhase == 0)
				{
					this.CharacterAnimation.CrossFade("witnessPoisoning_00");
					this.MoveTowardsTarget(this.CurrentDestination.position);
					this.Chopsticks[0].SetActive(true);
					this.Chopsticks[1].SetActive(true);
					this.Bento.SetActive(true);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, 10f * Time.deltaTime);
					if (this.CharacterAnimation["witnessPoisoning_00"].time >= 18.5f && this.Bento.activeInHierarchy)
					{
						this.Chopsticks[0].SetActive(false);
						this.Chopsticks[1].SetActive(false);
						this.Bento.SetActive(false);
						this.WitnessRivalDiePhase++;
					}
				}
				else if (this.WitnessRivalDiePhase == 1)
				{
					if (this.CharacterAnimation["witnessPoisoning_00"].time >= 22.5f)
					{
						this.Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 0, 8f);
						this.WitnessRivalDiePhase++;
					}
				}
				else if (this.WitnessRivalDiePhase == 2)
				{
					if (this.CharacterAnimation["witnessPoisoning_00"].time >= this.CharacterAnimation["witnessPoisoning_00"].length)
					{
						base.transform.position = new Vector3(this.Hips.position.x, base.transform.position.y, this.Hips.position.z);
						Physics.SyncTransforms();
						this.CharacterAnimation.Play("senpaiRivalCorpseReaction_00");
						this.TargetDistance = 1.5f;
						this.WitnessRivalDiePhase++;
						this.RivalDeathTimer = 0f;
					}
				}
				else if (this.WitnessRivalDiePhase == 3)
				{
					this.TargetDistance = 1.5f;
					if (this.DistanceToDestination <= this.TargetDistance)
					{
						this.CharacterAnimation.Play("senpaiRivalCorpseReaction_00");
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						if (this.WitnessedCorpse)
						{
							base.transform.LookAt(this.StudentManager.Students[this.StudentManager.RivalID].Head.position);
							base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y - 90f, 0f);
						}
					}
					if (this.RivalDeathTimer == 0f)
					{
						this.Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 2, 15f);
					}
					this.RivalDeathTimer += Time.deltaTime;
					if (this.CharacterAnimation["senpaiRivalCorpseReaction_00"].time >= this.CharacterAnimation["senpaiRivalCorpseReaction_00"].length)
					{
						if (!this.Phoneless)
						{
							this.Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 3, 15f);
							this.CharacterAnimation.CrossFade("kneelPhone_00");
							this.SmartPhone.SetActive(true);
						}
						this.WitnessRivalDiePhase++;
						this.RivalDeathTimer = 0f;
					}
				}
				else if (this.WitnessRivalDiePhase == 4)
				{
					this.CharacterAnimation.CrossFade("kneelPhone_00");
					this.RivalDeathTimer += Time.deltaTime;
					if (this.Phoneless)
					{
						this.RivalDeathTimer += 100f;
					}
					if (this.RivalDeathTimer > this.Subtitle.SenpaiRivalDeathReactionClips[3].length)
					{
						this.Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 4, 10f);
						this.CharacterAnimation.CrossFade("senpaiRivalCorpseCry_00");
						this.SmartPhone.SetActive(false);
						this.WitnessRivalDiePhase++;
						if (!this.StudentManager.Jammed && !this.Phoneless)
						{
							this.Police.Called = true;
							this.Police.Show = true;
						}
					}
				}
			}
			if (this.SpecialRivalDeathReaction)
			{
				if (this.WitnessRivalDiePhase == 1)
				{
					if (this.DistanceToDestination <= 1f)
					{
						this.CharacterAnimation.CrossFade("f02_friendCorpseReaction_00");
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						if (this.StudentID == this.StudentManager.ObstacleID)
						{
							base.transform.LookAt(this.StudentManager.Students[11].Head.position);
						}
						else
						{
							base.transform.LookAt(this.StudentManager.Students[10].Head.position);
						}
						base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y - 90f, 0f);
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.RunAnim);
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Pathfinding.speed = 4f;
					}
					if (this.RivalDeathTimer == 0f)
					{
						this.Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
						if (this.StudentID == this.StudentManager.ObstacleID)
						{
							this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 2, 15f);
						}
						else
						{
							this.Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 2, 15f);
						}
					}
					this.RivalDeathTimer += Time.deltaTime;
					if (this.CharacterAnimation["f02_friendCorpseReaction_00"].time >= this.CharacterAnimation["f02_friendCorpseReaction_00"].length)
					{
						if (this.StudentID == this.StudentManager.ObstacleID)
						{
							this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 3, 10f);
						}
						else
						{
							this.Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 3, 10f);
						}
						this.CharacterAnimation.CrossFade("f02_kneelPhone_00");
						this.SmartPhone.SetActive(true);
						this.WitnessRivalDiePhase++;
						this.RivalDeathTimer = 0f;
					}
				}
				else if (this.WitnessRivalDiePhase == 2)
				{
					this.RivalDeathTimer += Time.deltaTime;
					if (this.RivalDeathTimer > this.Subtitle.OsanaObstacleDeathReactionClips[3].length)
					{
						if (this.StudentID == this.StudentManager.ObstacleID)
						{
							this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 4, 10f);
						}
						else
						{
							this.Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 4, 10f);
						}
						this.CharacterAnimation.CrossFade("f02_friendCorpseCry_00");
						this.SmartPhone.SetActive(false);
						this.WitnessRivalDiePhase++;
						if (!this.StudentManager.Jammed)
						{
							this.Police.Called = true;
							this.Police.Show = true;
						}
					}
				}
			}
			if (this.SolvingPuzzle)
			{
				this.PuzzleTimer += Time.deltaTime;
				this.CharacterAnimation.CrossFade(this.PuzzleAnim);
				this.PuzzleCube.transform.Rotate(new Vector3(360f, 360f, 360f), Time.deltaTime * 100f);
				if (this.PuzzleTimer > 30f)
				{
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.PuzzleTimer = 0f;
					this.Routine = true;
					this.DropPuzzle();
				}
			}
			if (this.GoAway)
			{
				this.GoAwayTimer += Time.deltaTime;
				if (this.GoAwayTimer > 10f)
				{
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.GoAwayTimer = 0f;
					this.GoAway = false;
					this.Routine = true;
				}
			}
			if (this.TakingOutTrash)
			{
				if (this.TrashPhase == 0)
				{
					this.CurrentDestination = this.TrashDestination;
					this.Pathfinding.target = this.TrashDestination;
					this.EmptyHands();
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.CharacterAnimation.CrossFade(this.WalkAnim);
					this.TrashPhase++;
				}
				else if (this.TrashPhase == 1)
				{
					if (this.DistanceToDestination < 1f)
					{
						this.TrashDestination.parent = this.ItemParent;
						this.TrashDestination.localEulerAngles = new Vector3(90f, 0f, 0f);
						this.TrashDestination.localPosition = new Vector3(0f, 0.05f, -0.45f);
						this.CurrentDestination = this.Yandere.Incinerator.transform;
						this.Pathfinding.target = this.Yandere.Incinerator.transform;
						this.TrashPhase++;
					}
				}
				else if (this.TrashPhase == 2 && this.DistanceToDestination < 2.5f)
				{
					this.Yandere.Incinerator.DumpGarbageBag(this.TrashDestination.GetComponent<PickUpScript>());
					this.TakingOutTrash = false;
					this.Routine = true;
				}
			}
			if (this.FocusOnYandere)
			{
				this.CharacterAnimation.CrossFade(this.IdleAnim);
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				Debug.Log(this.Name + " is running the FocusOnYandere code.");
			}
		}
	}

	// Token: 0x06001E1F RID: 7711 RVA: 0x0018BC44 File Offset: 0x00189E44
	private void UpdateVisibleCorpses()
	{
		this.VisibleCorpses.Clear();
		this.ID = 0;
		while (this.ID < this.Police.Corpses)
		{
			RagdollScript ragdollScript = this.Police.CorpseList[this.ID];
			if (ragdollScript != null && !ragdollScript.Hidden && !ragdollScript.Concealed)
			{
				Collider collider = ragdollScript.AllColliders[0];
				bool flag = false;
				if (collider.transform.position.y < base.transform.position.y + 4f)
				{
					flag = true;
				}
				if (flag && this.CanSeeObject(collider.gameObject, collider.transform.position, this.CorpseLayers, this.Mask))
				{
					this.VisibleCorpses.Add(ragdollScript.StudentID);
					this.Corpse = ragdollScript;
					if (this.Club == ClubType.Delinquent && this.Corpse.Student.Club == ClubType.Bully)
					{
						this.ScaredAnim = this.EvilWitnessAnim;
						this.Persona = PersonaType.Evil;
					}
					if (this.Persona == PersonaType.TeachersPet && this.StudentManager.Reporter == null && !this.Police.Called)
					{
						this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
						this.StudentManager.CorpseLocation.LookAt(base.transform.position);
						this.StudentManager.CorpseLocation.Translate(this.StudentManager.CorpseLocation.forward * -1f);
						this.StudentManager.LowerCorpsePosition();
						this.StudentManager.Reporter = this;
						this.ReportingMurder = true;
						this.DetermineCorpseLocation();
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Pathfinding.speed = 0f;
						this.Fleeing = false;
					}
				}
			}
			this.ID++;
		}
	}

	// Token: 0x06001E20 RID: 7712 RVA: 0x0018BE64 File Offset: 0x0018A064
	private void UpdateVisibleBlood()
	{
		this.ID = 0;
		while (this.ID < this.StudentManager.Blood.Length && this.BloodPool == null)
		{
			Collider collider = this.StudentManager.Blood[this.ID];
			if (collider != null && Vector3.Distance(base.transform.position, collider.transform.position) < this.VisionDistance && this.CanSeeObject(collider.gameObject, collider.transform.position))
			{
				this.BloodPool = collider.transform;
				this.WitnessedBloodPool = true;
				if (this.Club != ClubType.Delinquent && this.StudentManager.BloodReporter == null && !this.Police.Called && !this.LostTeacherTrust)
				{
					this.StudentManager.BloodLocation.position = this.BloodPool.position;
					this.StudentManager.BloodLocation.LookAt(new Vector3(base.transform.position.x, this.StudentManager.BloodLocation.position.y, base.transform.position.z));
					this.StudentManager.BloodLocation.Translate(this.StudentManager.BloodLocation.forward * -1f);
					this.StudentManager.LowerBloodPosition();
					this.StudentManager.BloodReporter = this;
					this.ReportingBlood = true;
					this.DetermineBloodLocation();
				}
			}
			this.ID++;
		}
	}

	// Token: 0x06001E21 RID: 7713 RVA: 0x0018C01C File Offset: 0x0018A21C
	private void UpdateVisibleLimbs()
	{
		this.ID = 0;
		while (this.ID < this.StudentManager.Limbs.Length && this.BloodPool == null)
		{
			Collider collider = this.StudentManager.Limbs[this.ID];
			if (collider != null && this.CanSeeObject(collider.gameObject, collider.transform.position))
			{
				this.BloodPool = collider.transform;
				this.WitnessedLimb = true;
				if (this.Club != ClubType.Delinquent && this.StudentManager.BloodReporter == null && !this.Police.Called && !this.LostTeacherTrust)
				{
					this.StudentManager.BloodLocation.position = this.BloodPool.position;
					this.StudentManager.BloodLocation.LookAt(new Vector3(base.transform.position.x, this.StudentManager.BloodLocation.position.y, base.transform.position.z));
					this.StudentManager.BloodLocation.Translate(this.StudentManager.BloodLocation.forward * -1f);
					this.StudentManager.LowerBloodPosition();
					this.StudentManager.BloodReporter = this;
					this.ReportingBlood = true;
					this.DetermineBloodLocation();
				}
			}
			this.ID++;
		}
	}

	// Token: 0x06001E22 RID: 7714 RVA: 0x0018C1AC File Offset: 0x0018A3AC
	private void UpdateVisibleWeapons()
	{
		this.ID = 0;
		while (this.ID < this.Yandere.WeaponManager.Weapons.Length)
		{
			if (this.Yandere.WeaponManager.Weapons[this.ID] != null && (this.Yandere.WeaponManager.Weapons[this.ID].Blood.enabled || (this.Yandere.WeaponManager.Weapons[this.ID].Misplaced && this.Yandere.WeaponManager.Weapons[this.ID].transform.parent == null)))
			{
				if (!(this.BloodPool == null))
				{
					break;
				}
				if (this.Yandere.WeaponManager.Weapons[this.ID].transform != this.LastSuspiciousObject && this.Yandere.WeaponManager.Weapons[this.ID].transform != this.LastSuspiciousObject2 && this.Yandere.WeaponManager.Weapons[this.ID].enabled)
				{
					Collider myCollider = this.Yandere.WeaponManager.Weapons[this.ID].MyCollider;
					if (myCollider != null && this.CanSeeObject(myCollider.gameObject, myCollider.transform.position))
					{
						if (!this.StudentManager.Eighties && this.StudentID == 48 && this.Yandere.WeaponManager.Weapons[this.ID].WeaponID == 12)
						{
							Debug.Log(this.Name + " could have reacted to a dropped dumbbell, but isn't going to.");
							return;
						}
						Debug.Log(this.Name + " has seen a dropped weapon on the ground.");
						this.CheckForBento();
						this.BloodPool = myCollider.transform;
						if (this.Yandere.WeaponManager.Weapons[this.ID].Blood.enabled)
						{
							this.WitnessedBloodyWeapon = true;
						}
						this.WitnessedWeapon = true;
						if (this.Club != ClubType.Delinquent && this.StudentManager.BloodReporter == null && !this.Police.Called && !this.LostTeacherTrust)
						{
							this.StudentManager.BloodLocation.position = this.BloodPool.position;
							this.StudentManager.BloodLocation.LookAt(new Vector3(base.transform.position.x, this.StudentManager.BloodLocation.position.y, base.transform.position.z));
							this.StudentManager.BloodLocation.Translate(this.StudentManager.BloodLocation.forward * -1f);
							this.StudentManager.LowerBloodPosition();
							this.StudentManager.BloodReporter = this;
							this.ReportingBlood = true;
							this.BeforeReturnAnim = this.WalkAnim;
							this.WalkAnim = this.OriginalWalkAnim;
							this.WasHurrying = this.Hurry;
							this.DetermineBloodLocation();
						}
					}
				}
			}
			this.ID++;
		}
	}

	// Token: 0x06001E23 RID: 7715 RVA: 0x0018C50C File Offset: 0x0018A70C
	private void UpdateVision()
	{
		bool flag = false;
		if (this.Distracted)
		{
			flag = true;
			if (this.AmnesiaTimer > 0f)
			{
				this.AmnesiaTimer = Mathf.MoveTowards(this.AmnesiaTimer, 0f, Time.deltaTime);
				if (this.AmnesiaTimer == 0f)
				{
					this.Distracted = false;
				}
			}
		}
		if (!flag)
		{
			bool flag2 = true;
			if (this.Yandere.Pursuer == null && this.Yandere.Pursuer == this)
			{
				flag2 = false;
			}
			if (this.WitnessedMurder || this.CheckingNote || this.Shoving || this.Slave || this.Struggling || !flag2 || this.Drownable || this.Fighting)
			{
				this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
				return;
			}
			if (this.Police.Corpses > 0)
			{
				if (!this.Blind && !this.AwareOfCorpse)
				{
					this.UpdateVisibleCorpses();
				}
				if (this.VisibleCorpses.Count > 0)
				{
					if (!this.WitnessedCorpse)
					{
						Debug.Log(this.Name + " discovered a corpse.");
						this.Police.StudentFoundCorpse = true;
						this.SawCorpseThisFrame = true;
						if (this.Club == ClubType.Delinquent && this.Corpse.Student.Club == ClubType.Bully)
						{
							this.FoundEnemyCorpse = true;
						}
						if (this.Persona == PersonaType.Sleuth)
						{
							if (this.Sleuthing)
							{
								this.Persona = PersonaType.PhoneAddict;
								this.SmartPhone.SetActive(true);
							}
							else if (this.StudentManager.Eighties)
							{
								this.Persona = PersonaType.LandlineUser;
							}
							else
							{
								this.Persona = PersonaType.SocialButterfly;
							}
						}
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						if (!this.Male)
						{
							this.CharacterAnimation["f02_smile_00"].weight = 0f;
						}
						this.AlarmTimer = 0f;
						this.Alarm = 200f;
						this.LastKnownCorpse = this.Corpse.AllColliders[0].transform.position;
						this.WitnessedBloodyWeapon = false;
						this.WitnessedBloodPool = false;
						this.WitnessedSomething = false;
						this.WitnessedWeapon = false;
						this.WitnessedCorpse = true;
						this.WitnessedLimb = false;
						this.Yandere.NotificationManager.CustomText = this.Name + " found a corpse!";
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						this.SummonWitnessCamera();
						if (this.ReturningMisplacedWeapon)
						{
							this.DropMisplacedWeapon();
						}
						if (this.StudentManager.BloodReporter == this)
						{
							this.StudentManager.BloodReporter = null;
							this.ReportingBlood = false;
							this.Fleeing = false;
						}
						if (this.Distracting || this.ResumeDistracting)
						{
							Debug.Log(this.Name + " should be forgetting about ''Distracting'' right now.");
							if (this.DistractionTarget != null)
							{
								this.DistractionTarget.TargetedForDistraction = false;
							}
							this.ResumeDistracting = false;
							this.Distracting = false;
						}
						this.InvestigatingBloodPool = false;
						this.Investigating = false;
						this.EatingSnack = false;
						this.Threatened = false;
						this.SentHome = false;
						this.Routine = false;
						this.CheckingNote = false;
						this.SentToLocker = false;
						this.Meeting = false;
						this.MeetTimer = 0f;
						if (this.Persona == PersonaType.Spiteful && ((this.Bullied && this.Corpse.Student.Club == ClubType.Bully) || this.Corpse.Student.Bullied))
						{
							this.ScaredAnim = this.EvilWitnessAnim;
							this.Persona = PersonaType.Evil;
						}
						this.ForgetRadio();
						if (this.Wet)
						{
							this.Persona = PersonaType.Loner;
						}
						if (this.Corpse.Disturbing)
						{
							if (this.Corpse.BurningAnimation)
							{
								this.WalkBackTimer = 5f;
								this.WalkBack = true;
								this.Hesitation = 0.5f;
							}
							if (this.Corpse.MurderSuicideAnimation)
							{
								this.WitnessedMindBrokenMurder = true;
								this.WalkBackTimer = 5f;
								this.WalkBack = true;
								this.Hesitation = 1f;
							}
							if (this.Corpse.ChokingAnimation)
							{
								this.WalkBackTimer = 0f;
								this.WalkBack = true;
								this.Hesitation = 0.6f;
							}
							if (this.Corpse.ElectrocutionAnimation)
							{
								this.WalkBackTimer = 0f;
								this.WalkBack = true;
								this.Hesitation = 0.5f;
							}
						}
						if (this.Corpse.Student.Electrified)
						{
							Debug.Log(this.Name + " is witnessing a person being electrocuted.");
							Vector3 headPosition = this.Yandere.HeadPosition;
							if (this.CanSeeObject(this.Yandere.gameObject, headPosition))
							{
								Debug.Log("Yandere-chan is in the vicinity.");
								if (this.Yandere.PotentiallyMurderousTimer > 0f)
								{
									Debug.Log("Yandere-chan just threw a car battery, which means she just deliberately killed someone!");
									this.WitnessMurder();
								}
							}
						}
						if (this.Corpse.Student.Burning)
						{
							Debug.Log(this.Name + " is witnessing a person burn to death.");
							Vector3 headPosition2 = this.Yandere.HeadPosition;
							if (this.CanSeeObject(this.Yandere.gameObject, headPosition2))
							{
								Debug.Log("Yandere-chan is in the vicinity.");
								if (this.Yandere.PotentiallyMurderousTimer > 0f)
								{
									Debug.Log("Yandere-chan just ran into the victim while holding a flame, which means she just deliberately killed someone!");
									this.WitnessMurder();
								}
							}
						}
						this.StudentManager.UpdateMe(this.StudentID);
						if (!this.Teacher)
						{
							this.SpawnAlarmDisc();
						}
						else
						{
							this.AlarmTimer = 3f;
						}
						ParticleSystem.EmissionModule emission = this.Hearts.emission;
						if (this.Talking)
						{
							this.DialogueWheel.End();
							emission.enabled = false;
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
							this.Obstacle.enabled = false;
							this.Talk.enabled = false;
							this.Talking = false;
							this.Waiting = false;
							this.StudentManager.EnablePrompts();
						}
						if (this.Following)
						{
							emission.enabled = false;
							this.FollowCountdown.gameObject.SetActive(false);
							this.Yandere.Follower = null;
							this.Yandere.Followers--;
							this.Following = false;
						}
					}
					if (this.Corpse.Dragged || this.Corpse.Dumped)
					{
						if (this.Teacher)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, UnityEngine.Random.Range(1, 3), 3f);
						}
						if (!this.Yandere.Egg)
						{
							this.WitnessMurder();
						}
					}
				}
			}
			if (this.VisibleCorpses.Count == 0 && !this.WitnessedCorpse)
			{
				if (this.WitnessCooldownTimer > 0f)
				{
					this.WitnessCooldownTimer = Mathf.MoveTowards(this.WitnessCooldownTimer, 0f, Time.deltaTime);
				}
				else if ((this.StudentID == this.StudentManager.CurrentID || (this.Persona == PersonaType.Strict && this.Fleeing)) && !this.Wet && !this.Guarding && !this.IgnoreBlood && !this.InvestigatingPossibleDeath && !this.Spraying && !this.Emetic && !this.Threatened && !this.Sedated && !this.Headache && !this.SentHome && !this.Slave && !this.Talking && !this.Confessing && !this.SentToLocker && !this.Meeting)
				{
					if (this.BloodPool == null && this.StudentManager.Police.LimbParent.childCount > 0)
					{
						this.UpdateVisibleLimbs();
					}
					if (this.BloodPool == null && (this.Police.BloodyWeapons > 0 || this.Yandere.WeaponManager.MisplacedWeapons > 0) && !this.InvestigatingPossibleLimb && !this.TakingOutTrash && !this.Alarmed && !this.InEvent && !this.InvestigatingPossibleBlood && !this.ChangingShoes && this.Persona != PersonaType.Violent && (this.MyPlate == null || (this.MyPlate != null && this.MyPlate.parent != this.RightHand)))
					{
						this.UpdateVisibleWeapons();
					}
					if (this.BloodPool == null)
					{
						if (this.StudentManager.Police.BloodParent.childCount > 0 && !this.InvestigatingPossibleLimb)
						{
							this.UpdateVisibleBlood();
						}
					}
					else if (!this.WitnessedSomething)
					{
						Debug.Log(this.Name + " saw something suspicious on the ground.");
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						if (!this.Male)
						{
							this.CharacterAnimation["f02_smile_00"].weight = 0f;
						}
						this.AlarmTimer = 0f;
						this.Alarm = 200f;
						this.LastKnownBlood = this.BloodPool.transform.position;
						this.NotAlarmedByYandereChan = true;
						this.WitnessedSomething = true;
						this.Investigating = false;
						this.EatingSnack = false;
						this.Threatened = false;
						this.SentHome = false;
						this.Routine = false;
						this.ForgetRadio();
						this.StudentManager.UpdateMe(this.StudentID);
						if (this.Teacher)
						{
							this.AlarmTimer = 3f;
						}
						ParticleSystem.EmissionModule emission2 = this.Hearts.emission;
						if (this.Talking)
						{
							this.DialogueWheel.End();
							emission2.enabled = false;
							this.Pathfinding.canSearch = true;
							this.Pathfinding.canMove = true;
							this.Obstacle.enabled = false;
							this.Talk.enabled = false;
							this.Talking = false;
							this.Waiting = false;
							this.StudentManager.EnablePrompts();
						}
						if (this.Following)
						{
							emission2.enabled = false;
							this.FollowCountdown.gameObject.SetActive(false);
							this.Yandere.Follower = null;
							this.Yandere.Followers--;
							this.Following = false;
						}
					}
				}
			}
			this.PreviousAlarm = this.Alarm;
			if (this.DistanceToPlayer < this.VisionDistance - this.ChameleonBonus)
			{
				if (!this.Talking && !this.Spraying && !this.SentHome && !this.Slave)
				{
					if (!this.Yandere.Noticed && !this.Yandere.Invisible)
					{
						bool flag3 = false;
						if (this.Guarding || this.Fleeing || this.InvestigatingBloodPool)
						{
							flag3 = true;
						}
						if ((this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious) || (this.Yandere.Armed && this.Yandere.EquippedWeapon.Bloody) || (this.StudentID > 1 && this.Yandere.PickUp != null && this.Yandere.PickUp.Suspicious) || (this.StudentID > 1 && this.Yandere.PickUp != null && this.Yandere.PickUp.CleaningProduct && this.Clock.Period != 5) || (this.Yandere.Bloodiness + (float)this.Yandere.GloveBlood > 0f && !this.Yandere.Paint) || (this.Yandere.Sanity < 33.333f || this.Yandere.Pickpocketing || this.Yandere.Attacking || this.Yandere.Cauterizing || this.Yandere.Struggling || (this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed)) || (this.Yandere.Dragging && this.Yandere.CurrentRagdoll.Concealed && this.Clock.Period != 5) || (!this.IgnoringPettyActions && this.Yandere.Lewd) || (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Carrying && this.Yandere.CurrentRagdoll.Concealed && this.Clock.Period != 5) || (this.Yandere.Medusa || this.Yandere.Poisoning || this.Yandere.Pickpocketing || this.Yandere.WeaponTimer > 0f || this.Yandere.WearingRaincoat || this.Yandere.MurderousActionTimer > 0f || (!this.IgnoringPettyActions && this.Yandere.Schoolwear == 2 && this.Yandere.transform.position.z < 30f)) || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null && !this.Yandere.PickUp.Garbage) || (!this.IgnoringPettyActions && this.Yandere.SuspiciousActionTimer > 0f) || (!this.IgnoringPettyActions && this.Yandere.Laughing && this.Yandere.LaughIntensity > 15f) || (!this.IgnoringPettyActions && this.Yandere.Stance.Current == StanceType.Crouching) || (!this.IgnoringPettyActions && this.Yandere.Stance.Current == StanceType.Crawling) || (this.Yandere.Trespassing || (this.Private && this.Yandere.Eavesdropping)) || (this.Teacher && !this.WitnessedCorpse && this.Yandere.Trespassing) || (this.Teacher && !this.IgnoringPettyActions && this.Yandere.Rummaging) || (!this.IgnoringPettyActions && this.Yandere.TheftTimer > 0f) || (this.StudentID == 1 && this.Yandere.NearSenpai && !this.Yandere.Talking) || (this.Yandere.Eavesdropping && this.Private) || (!this.IgnoringPettyActions && !this.StudentManager.CombatMinigame.Practice && this.Yandere.DelinquentFighting && this.StudentID != 10 && this.StudentManager.CombatMinigame.Path < 4 && !this.StudentManager.CombatMinigame.Practice && !this.Yandere.SeenByAuthority) || (flag3 && this.Yandere.PickUp != null && this.Yandere.PickUp.Mop != null && this.Yandere.PickUp.Mop.Bloodiness > 0f) || (flag3 && this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null && !this.Yandere.PickUp.Garbage) || (this.Yandere.PickUp != null && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence))
						{
							bool flag4 = false;
							if (this.Yandere.transform.position.y < base.transform.position.y + 4f)
							{
								flag4 = true;
							}
							Vector3 headPosition3 = this.Yandere.HeadPosition;
							if ((flag4 && this.CanSeeObject(this.Yandere.gameObject, headPosition3)) || this.AwareOfMurder)
							{
								this.YandereVisible = true;
								if (this.Yandere.Attacking || this.Yandere.Cauterizing || this.Yandere.Struggling || (this.WitnessedCorpse && this.Yandere.NearBodies > 0 && this.Yandere.Bloodiness + (float)this.Yandere.GloveBlood > 0f && !this.Yandere.Paint) || (this.WitnessedCorpse && this.Yandere.NearBodies > 0 && this.Yandere.Armed) || (this.WitnessedCorpse && this.Yandere.NearBodies > 0 && this.Yandere.Sanity < 66.66666f) || (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.MurderousActionTimer > 0f || (this.Guarding && this.Yandere.Bloodiness + (float)this.Yandere.GloveBlood > 0f && !this.Yandere.Paint)) || (this.Guarding && this.Yandere.Armed) || (this.Guarding && this.Yandere.Sanity < 66.66666f) || (!this.IgnoringPettyActions && !this.StudentManager.CombatMinigame.Practice && this.Club == ClubType.Council && this.Yandere.DelinquentFighting && this.StudentManager.CombatMinigame.Path < 4 && !this.Yandere.SeenByAuthority) || (!this.StudentManager.CombatMinigame.Practice && this.Teacher && this.Yandere.DelinquentFighting && this.StudentManager.CombatMinigame.Path < 4 && !this.Yandere.SeenByAuthority) || (flag3 && this.Yandere.PickUp != null && this.Yandere.PickUp.Mop != null && this.Yandere.PickUp.Mop.Bloodiness > 0f) || (flag3 && this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null && !this.Yandere.PickUp.Garbage) || (this.Yandere.PickUp != null && this.Teacher && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence) || (this.StudentManager.Atmosphere < 0.33333f && this.Yandere.Bloodiness + (float)this.Yandere.GloveBlood > 0f && this.Yandere.Armed))
								{
									Debug.Log(this.Name + " is aware that Yandere-chan is misbehaving.");
									if (this.Yandere.Hungry || !this.Yandere.Egg)
									{
										Debug.Log(this.Name + " has just witnessed a murder!");
										if (this.Yandere.PickUp != null)
										{
											if (flag3)
											{
												if (this.Yandere.PickUp.Mop != null)
												{
													if (this.Yandere.PickUp.Mop.Bloodiness > 0f)
													{
														Debug.Log("This character witnessed Yandere-chan trying to cover up a crime.");
														this.WitnessedCoverUp = true;
													}
												}
												else if (this.Yandere.PickUp.BodyPart != null && !this.Yandere.PickUp.Garbage)
												{
													Debug.Log("This character witnessed Yandere-chan trying to cover up a crime.");
													this.WitnessedCoverUp = true;
												}
											}
											if (this.Teacher && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence)
											{
												Debug.Log("This character witnessed Yandere-chan trying to cover up a crime.");
												this.WitnessedCoverUp = true;
											}
										}
										if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
										{
											Debug.Log(this.Name + ", a Phone Addict, is deciding what to do.");
											this.Countdown.gameObject.SetActive(false);
											this.Countdown.Sprite.fillAmount = 1f;
											this.WitnessedMurder = false;
											this.Fleeing = false;
											if (this.CrimeReported)
											{
												Debug.Log(this.Name + "'s ''CrimeReported'' was ''true'', but we're seeing it to ''false''.");
												this.CrimeReported = false;
											}
										}
										if (!this.Yandere.DelinquentFighting)
										{
											this.NoBreakUp = true;
										}
										else if (this.Teacher || this.Club == ClubType.Council)
										{
											this.Yandere.SeenByAuthority = true;
										}
										this.WitnessMurder();
									}
								}
								else if (!this.Fleeing && (!this.Alarmed || this.CanStillNotice))
								{
									if (this.Yandere.Rummaging || this.Yandere.TheftTimer > 0f)
									{
										this.Alarm = 200f;
									}
									if (this.Yandere.WeaponTimer > 0f)
									{
										this.Alarm = 200f;
									}
									if (this.IgnoreTimer == 0f || this.CanStillNotice)
									{
										if (this.Teacher)
										{
											this.StudentManager.TutorialWindow.ShowTeacherMessage = true;
										}
										int num = 1;
										if (this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious && (this.Yandere.EquippedWeapon.Type == WeaponType.Bat || this.Yandere.EquippedWeapon.Type == WeaponType.Katana || this.Yandere.EquippedWeapon.Type == WeaponType.Saw || this.Yandere.EquippedWeapon.Type == WeaponType.Weight))
										{
											num = 5;
										}
										if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
										{
											this.Alarm += Time.deltaTime * (100f / this.DistanceToPlayer) * this.Paranoia * this.Perception * (float)num;
											if (this.Yandere.SneakingShot)
											{
												this.Alarm += Time.deltaTime * (100f / this.DistanceToPlayer) * this.Paranoia * this.Perception * (float)num * 2f;
											}
											if (this.Yandere.SuspiciousActionTimer > 0f)
											{
												this.Alarm += Time.deltaTime * (100f / this.DistanceToPlayer) * this.Paranoia * this.Perception * (float)num * 9f;
											}
										}
										else
										{
											this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
										}
										if (this.StudentID == 1 && this.Yandere.TimeSkipping)
										{
											this.Clock.EndTimeSkip();
										}
									}
								}
							}
							else
							{
								this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
							}
						}
						else
						{
							this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
						}
					}
					else
					{
						this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
					}
				}
				else
				{
					this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
				}
			}
			else
			{
				this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
			}
			if (this.PreviousAlarm > this.Alarm && this.Alarm < 100f)
			{
				this.YandereVisible = false;
			}
			if (this.Teacher && !this.Yandere.Medusa && this.Yandere.Egg)
			{
				this.Alarm = 0f;
			}
			if (this.Alarm > 100f)
			{
				this.BecomeAlarmed();
				return;
			}
		}
		else if (this.Distraction != null)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Distraction.position.x, base.transform.position.y, this.Distraction.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			if (this.Distractor != null)
			{
				if (this.Distractor.Club == ClubType.Cooking && this.Distractor.ClubActivityPhase > 0 && this.Distractor.Actions[this.Distractor.Phase] == StudentActionType.ClubAction)
				{
					this.CharacterAnimation.CrossFade(this.PlateEatAnim);
					if ((double)this.CharacterAnimation[this.PlateEatAnim].time > 6.83333)
					{
						this.Fingerfood[this.Distractor.StudentID - 20].SetActive(false);
						return;
					}
					if ((double)this.CharacterAnimation[this.PlateEatAnim].time > 2.66666)
					{
						this.Fingerfood[this.Distractor.StudentID - 20].SetActive(true);
						return;
					}
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.RandomAnim);
					if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length)
					{
						this.PickRandomAnim();
					}
				}
			}
		}
	}

	// Token: 0x06001E24 RID: 7716 RVA: 0x0018DFF0 File Offset: 0x0018C1F0
	public void BecomeAlarmed()
	{
		Debug.Log(this.Name + " just called the BecomeAlarmed() function.");
		if (this.Yandere.Medusa && this.YandereVisible)
		{
			this.TurnToStone();
			return;
		}
		if (this.Investigating && !this.HeardScream)
		{
			Debug.Log(this.Name + " was investigating prior to being alarmed, so they are now ending their investigation.");
			this.StopInvestigating();
		}
		if (!this.Alarmed || this.DiscCheck)
		{
			Debug.Log(this.Name + " has become alarmed by something.");
			bool flag = false;
			if (this.CurrentAction == StudentActionType.Sunbathe && this.SunbathePhase > 2)
			{
				this.SunbathePhase = 2;
				flag = true;
			}
			if (this.ReturningMisplacedWeapon)
			{
				this.DropMisplacedWeapon();
				this.ReturnToRoutineAfter = true;
			}
			if (this.DistractionTarget != null)
			{
				this.DistractionTarget.TargetedForDistraction = false;
			}
			if (this.SolvingPuzzle)
			{
				this.DropPuzzle();
			}
			this.CharacterAnimation.CrossFade(this.IdleAnim);
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.CameraReacting = false;
			this.CanStillNotice = false;
			this.Distracting = false;
			this.Distracted = false;
			this.DiscCheck = false;
			this.Reacted = false;
			this.Routine = false;
			this.Alarmed = true;
			this.PuzzleTimer = 0f;
			this.ReadPhase = 0;
			if (!this.Male)
			{
				this.HorudaCollider.gameObject.SetActive(false);
			}
			this.BountyCollider.SetActive(false);
			if (this.YandereVisible && this.Yandere.Mask == null)
			{
				this.Witness = true;
			}
			this.EmptyHands();
			if ((this.Persona == PersonaType.PhoneAddict && !this.Phoneless && !flag) || this.Persona == PersonaType.Sleuth || this.StudentID == 20)
			{
				this.SmartPhone.SetActive(true);
			}
			if (this.Club == ClubType.Cooking && this.Actions[this.Phase] == StudentActionType.ClubAction && this.ClubActivityPhase == 1 && !this.WitnessedCorpse)
			{
				Debug.Log("The game believes that " + this.Name + " did not witness a corpse; ''ResumeDistracting'' is being set to ''true''.");
				this.ResumeDistracting = true;
				this.MyPlate.gameObject.SetActive(true);
			}
			if (this.TakingOutTrash && !this.WitnessedCorpse)
			{
				this.ResumeTakingOutTrash = true;
			}
			this.SpeechLines.Stop();
			this.StopPairing();
			if (this.Witnessed != StudentWitnessType.Weapon && this.Witnessed != StudentWitnessType.Eavesdropping)
			{
				this.PreviouslyWitnessed = this.Witnessed;
			}
			if (this.DistanceToDestination < 5f && (this.Actions[this.Phase] == StudentActionType.Graffiti || this.Actions[this.Phase] == StudentActionType.Bully))
			{
				this.StudentManager.NoBully[this.BullyID] = true;
				this.KilledMood = true;
			}
			if (this.WitnessedCorpse && !this.WitnessedMurder)
			{
				this.Witnessed = StudentWitnessType.Corpse;
				this.EyeShrink = 0.9f;
			}
			else if (this.WitnessedLimb)
			{
				this.Witnessed = StudentWitnessType.SeveredLimb;
			}
			else if (this.WitnessedBloodyWeapon)
			{
				this.Witnessed = StudentWitnessType.BloodyWeapon;
			}
			else if (this.WitnessedBloodPool)
			{
				this.Witnessed = StudentWitnessType.BloodPool;
			}
			else if (this.WitnessedWeapon)
			{
				this.Witnessed = StudentWitnessType.DroppedWeapon;
			}
			else if (this.StudentManager.TutorialActive)
			{
				this.Witnessed = StudentWitnessType.Tutorial;
			}
			if (this.SawCorpseThisFrame)
			{
				this.YandereVisible = false;
			}
			if (this.TemporarilyBlind)
			{
				this.YandereVisible = false;
			}
			if (this.YandereVisible && !this.NotAlarmedByYandereChan)
			{
				if ((!this.Injured && this.Persona == PersonaType.Violent && this.Yandere.Armed && !this.WitnessedCorpse && !this.RespectEarned) || (this.Persona == PersonaType.Violent && this.Yandere.DelinquentFighting))
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentWeaponReaction, 0, 3f);
					this.ThreatDistance = this.DistanceToPlayer;
					this.CheerTimer = UnityEngine.Random.Range(1f, 2f);
					this.SmartPhone.SetActive(false);
					this.Threatened = true;
					this.ThreatPhase = 1;
					this.ForgetGiggle();
				}
				Debug.Log(this.Name + " saw Yandere-chan doing something bad.");
				this.FocusOnYandere = true;
				if (this.StudentID > 1)
				{
					this.Yandere.Alerts++;
				}
				if (this.Yandere.Attacking || this.Yandere.Struggling || (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart && !this.Yandere.PickUp.Garbage))
				{
					if (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed)
					{
						this.Corpse = this.Yandere.CurrentRagdoll;
					}
					if (!this.Yandere.Egg)
					{
						this.WitnessMurder();
					}
				}
				else if (this.Witnessed != StudentWitnessType.Corpse)
				{
					this.DetermineWhatWasWitnessed();
				}
				if (this.Teacher && this.WitnessedCorpse)
				{
					this.Concern = 1;
				}
				if (this.StudentID == 1 && this.Yandere.Mask == null && !this.Yandere.Egg)
				{
					if (this.Concern == 5)
					{
						Debug.Log("Senpai noticed stalking or lewdness.");
						this.SenpaiNoticed();
						if (this.Witnessed == StudentWitnessType.Stalking || this.Witnessed == StudentWitnessType.Lewd)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.CharacterAnimation[this.AngryFaceAnim].weight = 1f;
						}
						else
						{
							Debug.Log("Senpai entered his scared animation.");
							this.CharacterAnimation.CrossFade(this.ScaredAnim);
							this.CharacterAnimation["scaredFace_00"].weight = 1f;
						}
						this.CameraEffects.MurderWitnessed();
					}
					else
					{
						this.CharacterAnimation.CrossFade("suspicious_00");
						this.CameraEffects.Alarm();
					}
				}
				else if (!this.Teacher)
				{
					this.CameraEffects.Alarm();
				}
				else
				{
					Debug.Log("A teacher has just witnessed Yandere-chan doing something bad.");
					if (!this.Fleeing)
					{
						if (this.Concern < 5)
						{
							this.CameraEffects.Alarm();
						}
						else if (!this.Yandere.Struggling && !this.StudentManager.PinningDown)
						{
							this.SenpaiNoticed();
							this.CameraEffects.MurderWitnessed();
						}
					}
					else
					{
						this.PersonaReaction();
						this.AlarmTimer = 0f;
						if (this.Concern < 5)
						{
							this.CameraEffects.Alarm();
						}
						else
						{
							this.CameraEffects.MurderWitnessed();
						}
					}
				}
				if (!this.Teacher && this.Club != ClubType.Delinquent && this.Witnessed == this.PreviouslyWitnessed)
				{
					this.RepeatReaction = true;
				}
				if (this.Yandere.Mask == null)
				{
					this.RepDeduction = 0f;
					this.CalculateReputationPenalty();
					if (this.RepDeduction >= 0f)
					{
						this.RepLoss -= this.RepDeduction;
					}
					this.Reputation.PendingRep -= this.RepLoss * this.Paranoia;
					this.PendingRep -= this.RepLoss * this.Paranoia;
				}
				if (this.ToiletEvent != null && this.ToiletEvent.EventDay == DayOfWeek.Monday)
				{
					this.ToiletEvent.EndEvent();
				}
			}
			else if (!this.WitnessedCorpse)
			{
				if (this.Yandere.Caught)
				{
					if (this.Yandere.Mask == null)
					{
						if (this.Yandere.Pickpocketing)
						{
							this.Witnessed = StudentWitnessType.Pickpocketing;
							this.RepLoss += 10f;
						}
						else
						{
							this.Witnessed = StudentWitnessType.Theft;
						}
						this.RepDeduction = 0f;
						this.CalculateReputationPenalty();
						if (this.RepDeduction >= 0f)
						{
							this.RepLoss -= this.RepDeduction;
						}
						this.Reputation.PendingRep -= this.RepLoss * this.Paranoia;
						this.PendingRep -= this.RepLoss * this.Paranoia;
					}
				}
				else if (this.WitnessedLimb)
				{
					this.Witnessed = StudentWitnessType.SeveredLimb;
				}
				else if (this.WitnessedBloodyWeapon)
				{
					this.Witnessed = StudentWitnessType.BloodyWeapon;
				}
				else if (this.WitnessedBloodPool)
				{
					this.Witnessed = StudentWitnessType.BloodPool;
				}
				else if (this.WitnessedWeapon)
				{
					this.Witnessed = StudentWitnessType.DroppedWeapon;
				}
				else
				{
					Debug.Log(this.Name + " was alarmed by something, but didn't see what it was.");
					this.Witnessed = StudentWitnessType.None;
					this.DiscCheck = true;
					this.Witness = false;
				}
			}
			else
			{
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
			}
		}
		this.NotAlarmedByYandereChan = false;
		this.SawCorpseThisFrame = false;
	}

	// Token: 0x06001E25 RID: 7717 RVA: 0x0018E904 File Offset: 0x0018CB04
	private void UpdateDetectionMarker()
	{
		if (this.Alarm < 0f)
		{
			this.Alarm = 0f;
			if (this.Club == ClubType.Council && !this.Yandere.Noticed)
			{
				this.CanStillNotice = true;
			}
		}
		if (this.DetectionMarker != null)
		{
			if (this.Alarm > 0f)
			{
				if (!this.DetectionMarker.Tex.enabled)
				{
					this.DetectionMarker.Tex.enabled = true;
				}
				this.DetectionMarker.Tex.transform.localScale = new Vector3(this.DetectionMarker.Tex.transform.localScale.x, (this.Alarm <= 100f) ? (this.Alarm / 100f) : 1f, this.DetectionMarker.Tex.transform.localScale.z);
				this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, this.Alarm / 100f);
				return;
			}
			if (this.DetectionMarker.Tex.color.a != 0f)
			{
				this.DetectionMarker.Tex.enabled = false;
				this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0f);
				return;
			}
		}
		else
		{
			this.SpawnDetectionMarker();
		}
	}

	// Token: 0x06001E26 RID: 7718 RVA: 0x0018EAE8 File Offset: 0x0018CCE8
	private void UpdateTalkInput()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (!this.StudentManager.EmptyDemon && (this.Alarm > 0f || this.AlarmTimer > 0f || this.Yandere.Armed || this.Yandere.Shoved || this.Waiting || this.InEvent || this.SentHome || this.Threatened || this.Guarding || (this.Distracted && !this.Drownable) || this.StudentID == 1 || this.Yandere.YandereVision) && ((!this.Slave && !this.BadTime && !this.Yandere.Gazing && !this.FightingSlave) || this.Yandere.YandereVision))
			{
				if (this.InEvent)
				{
					string str = "She";
					if (this.Male)
					{
						str = "He";
					}
					this.Yandere.NotificationManager.CustomText = str + " is busy with an event right now!";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else if (this.Guarding)
				{
					string str2 = "She";
					if (this.Male)
					{
						str2 = "He";
					}
					this.Yandere.NotificationManager.CustomText = str2 + " is too scared to talk right now!";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				this.Prompt.Circle[0].fillAmount = 1f;
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				bool flag = false;
				if (this.StudentID < 86 && this.Armband.activeInHierarchy && (this.Actions[this.Phase] == StudentActionType.ClubAction || this.Actions[this.Phase] == StudentActionType.SitAndSocialize || this.Actions[this.Phase] == StudentActionType.Socializing || this.Actions[this.Phase] == StudentActionType.Sleuth || this.Actions[this.Phase] == StudentActionType.Lyrics || this.Actions[this.Phase] == StudentActionType.Patrol || this.Actions[this.Phase] == StudentActionType.SitAndEatBento) && (this.DistanceToDestination < 1f || (base.transform.position.y > this.StudentManager.ClubZones[(int)this.Club].position.y - 2.5f && base.transform.position.y < this.StudentManager.ClubZones[(int)this.Club].position.y + 2.5f && Vector3.Distance(base.transform.position, this.StudentManager.ClubZones[(int)this.Club].position) < this.ClubThreshold) || Vector3.Distance(base.transform.position, this.StudentManager.DramaSpots[1].position) < 12f))
				{
					flag = true;
					this.Warned = false;
				}
				bool flag2 = this.StudentManager.Students[76] != null && this.StudentManager.Students[76].Friend;
				bool flag3 = this.StudentManager.Students[77] != null && this.StudentManager.Students[77].Friend;
				bool flag4 = this.StudentManager.Students[78] != null && this.StudentManager.Students[78].Friend;
				bool flag5 = this.StudentManager.Students[79] != null && this.StudentManager.Students[79].Friend;
				bool flag6 = this.StudentManager.Students[80] != null && this.StudentManager.Students[80].Friend;
				if (this.StudentID == 76 && GameGlobals.BlondeHair && this.Reputation.Reputation < -33.33333f && this.Yandere.Persona == YanderePersonaType.Tough && flag2 && flag3 && flag4 && flag5 && flag6)
				{
					flag = true;
					this.Warned = false;
				}
				bool flag7 = false;
				if (this.Yandere.PickUp != null && this.Yandere.PickUp.Salty && !this.Indoors)
				{
					flag7 = true;
				}
				if (this.StudentManager.Pose)
				{
					this.MyController.enabled = false;
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.Stop = true;
					this.Pose();
				}
				else if (this.BadTime)
				{
					this.Yandere.EmptyHands();
					this.BecomeRagdoll();
					this.Yandere.RagdollPK.connectedBody = this.Ragdoll.AllRigidbodies[5];
					this.Yandere.RagdollPK.connectedAnchor = this.Ragdoll.LimbAnchor[4];
					this.DialogueWheel.PromptBar.ClearButtons();
					this.DialogueWheel.PromptBar.Label[1].text = "Back";
					this.DialogueWheel.PromptBar.UpdateButtons();
					this.DialogueWheel.PromptBar.Show = true;
					this.Yandere.Ragdoll = this.Ragdoll.gameObject;
					this.Yandere.SansEyes[0].SetActive(true);
					this.Yandere.SansEyes[1].SetActive(true);
					this.Yandere.GlowEffect.Play();
					this.Yandere.CanMove = false;
					this.Yandere.PK = true;
					this.DeathType = DeathType.EasterEgg;
				}
				else if (this.StudentManager.Six)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity).GetComponent<AlarmDiscScript>().Originator = this;
					AudioSource.PlayClipAtPoint(this.Yandere.SixTakedown, base.transform.position);
					AudioSource.PlayClipAtPoint(this.Yandere.Snarls[UnityEngine.Random.Range(0, this.Yandere.Snarls.Length)], base.transform.position);
					this.Yandere.CharacterAnimation.CrossFade("f02_sixEat_00");
					this.Yandere.TargetStudent = this;
					this.Yandere.FollowHips = true;
					this.Yandere.Attacking = true;
					this.Yandere.CanMove = false;
					this.Yandere.Eating = true;
					this.CharacterAnimation.CrossFade(this.EatVictimAnim);
					this.CharacterAnimation[this.WetAnim].weight = 0f;
					this.Pathfinding.enabled = false;
					this.Routine = false;
					this.Dying = true;
					this.Eaten = true;
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, base.transform.position, Quaternion.identity);
					this.Yandere.SixTarget = gameObject.transform;
					this.Yandere.SixTarget.LookAt(this.Yandere.transform.position);
					this.Yandere.SixTarget.Translate(this.Yandere.SixTarget.forward);
				}
				else if (this.Yandere.SpiderGrow)
				{
					if (!this.Eaten && !this.Cosmetic.Empty)
					{
						AudioSource.PlayClipAtPoint(this.Yandere.SixTakedown, base.transform.position);
						AudioSource.PlayClipAtPoint(this.Yandere.Snarls[UnityEngine.Random.Range(0, this.Yandere.Snarls.Length)], base.transform.position);
						GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.Yandere.EmptyHusk, base.transform.position + base.transform.forward * 0.5f, Quaternion.identity);
						gameObject2.GetComponent<EmptyHuskScript>().TargetStudent = this;
						gameObject2.transform.LookAt(base.transform.position);
						this.CharacterAnimation.CrossFade(this.EatVictimAnim);
						this.CharacterAnimation[this.WetAnim].weight = 0f;
						this.Pathfinding.enabled = false;
						this.Distracted = false;
						this.Routine = false;
						this.Dying = true;
						this.Eaten = true;
						if (this.Investigating)
						{
							this.StopInvestigating();
						}
						if (this.Following)
						{
							this.FollowCountdown.gameObject.SetActive(false);
							this.Yandere.Follower = null;
							this.Yandere.Followers--;
							this.Following = false;
						}
						UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, base.transform.position, Quaternion.identity);
					}
				}
				else if (this.StudentManager.Gaze)
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_gazerPoint_00");
					this.Yandere.GazerEyes.Attacking = true;
					this.Yandere.TargetStudent = this;
					this.Yandere.GazeAttacking = true;
					this.Yandere.CanMove = false;
					this.Routine = false;
				}
				else if (this.Slave)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					this.Yandere.TargetStudent = this;
					this.Yandere.PauseScreen.StudentInfoMenu.Targeting = true;
					this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
					this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
					this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
					this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
					base.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
					this.Yandere.PauseScreen.MainMenu.SetActive(false);
					this.Yandere.PauseScreen.Panel.enabled = true;
					this.Yandere.PauseScreen.Sideways = true;
					this.Yandere.PauseScreen.Show = true;
					Time.timeScale = 0.0001f;
					this.Yandere.PromptBar.ClearButtons();
					this.Yandere.PromptBar.Label[1].text = "Cancel";
					this.Yandere.PromptBar.UpdateButtons();
					this.Yandere.PromptBar.Show = true;
				}
				else if (this.FightingSlave)
				{
					this.Yandere.CharacterAnimation.CrossFade("f02_subtleStab_00");
					this.Yandere.SubtleStabbing = true;
					this.Yandere.TargetStudent = this;
					this.Yandere.CanMove = false;
				}
				else if (this.Following)
				{
					this.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
					this.Prompt.Label[0].text = "     Talk";
					this.Prompt.Circle[0].fillAmount = 1f;
					this.Hearts.emission.enabled = false;
					this.FollowCountdown.gameObject.SetActive(false);
					this.Yandere.Follower = null;
					this.Yandere.Followers--;
					this.Following = false;
					this.Routine = true;
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = this.WalkSpeed;
				}
				else if (this.Pushable)
				{
					this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					if (!this.Male)
					{
						this.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 5, 3f);
					}
					else
					{
						this.Subtitle.UpdateLabel(SubtitleType.NoteReactionMale, 5, 3f);
					}
					this.Prompt.Label[0].text = "     Talk";
					this.Prompt.Circle[0].fillAmount = 1f;
					this.Yandere.TargetStudent = this;
					this.Yandere.Attacking = true;
					this.Yandere.RoofPush = true;
					this.Yandere.CanMove = false;
					this.Yandere.EmptyHands();
					this.EmptyHands();
					this.Distracted = true;
					this.Routine = false;
					this.Pushed = true;
					this.CharacterAnimation.CrossFade(this.PushedAnim);
					this.RemoveOfferHelpPrompt();
				}
				else if (this.Clock.Period == 2 || this.Clock.Period == 4 || (this.StudentID < 90 && this.CurrentDestination == this.Seat))
				{
					Debug.Log("This character won't talk because Class is in session, or because their destination is ''seat''.");
					if (this.Club != ClubType.Delinquent)
					{
						this.Subtitle.UpdateLabel(SubtitleType.ClassApology, 0, 3f);
					}
					else
					{
						this.Subtitle.UpdateLabel(SubtitleType.DelinquentAnnoy, UnityEngine.Random.Range(0, this.Subtitle.DelinquentAnnoyClips.Length), 3f);
					}
					this.Prompt.Circle[0].fillAmount = 1f;
				}
				else if (this.InEvent || !this.CanTalk || this.GoAway || this.Fleeing || (this.Meeting && !this.Drownable) || this.Wet || this.TurnOffRadio || this.InvestigatingBloodPool || (this.MyPlate != null && this.MyPlate.parent == this.RightHand) || flag7 || this.ReturningMisplacedWeapon || this.Actions[this.Phase] == StudentActionType.Bully || this.Actions[this.Phase] == StudentActionType.Graffiti || (this.CanTakeSnack && this.IgnoreFoodTimer > 0f) || (!this.StudentManager.Eighties && this.StudentID == 12))
				{
					if (!this.StudentManager.Eighties && this.StudentID == 10 && TaskGlobals.GetTaskStatus(46) == 1 && !this.NoMentor && (this.Clock.Period == 3 || this.Clock.Period == 5))
					{
						this.Yandere.NotificationManager.CustomText = "Martial Arts Club is not training now";
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					this.Subtitle.UpdateLabel(SubtitleType.EventApology, 1, 3f);
					this.Prompt.Circle[0].fillAmount = 1f;
					this.StudentManager.UpdateMe(this.StudentID);
				}
				else if (this.Clock.Period == 3 && this.BusyAtLunch)
				{
					this.Subtitle.UpdateLabel(SubtitleType.SadApology, 1, 3f);
					this.Prompt.Circle[0].fillAmount = 1f;
				}
				else if (this.Warned)
				{
					Debug.Log("This character refuses to speak to Yandere-chan because of a grudge.");
					this.Subtitle.UpdateLabel(SubtitleType.GrudgeRefusal, 0, 3f);
					this.Prompt.Circle[0].fillAmount = 1f;
					if (!this.Male)
					{
						this.CharacterAnimation["f02_smile_00"].weight = 0f;
					}
				}
				else if (this.Ignoring)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PhotoAnnoyance, 0, 3f);
					this.Prompt.Circle[0].fillAmount = 1f;
				}
				else if (this.Yandere.PickUp != null && this.Yandere.PickUp.PuzzleCube)
				{
					if (this.Investigating)
					{
						this.StopInvestigating();
					}
					this.EmptyHands();
					this.Prompt.Circle[0].fillAmount = 1f;
					this.PuzzleCube = this.Yandere.PickUp;
					this.Yandere.EmptyHands();
					this.PuzzleCube.enabled = false;
					this.PuzzleCube.Prompt.Hide();
					this.PuzzleCube.Prompt.enabled = false;
					this.PuzzleCube.MyRigidbody.useGravity = false;
					this.PuzzleCube.MyRigidbody.isKinematic = true;
					this.PuzzleCube.gameObject.transform.parent = this.RightHand;
					this.PuzzleCube.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
					this.PuzzleCube.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					if (this.Male)
					{
						this.PuzzleCube.gameObject.transform.localPosition = new Vector3(0f, -0.0466666f, 0f);
						this.PuzzleCube.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
					}
					else
					{
						this.PuzzleCube.gameObject.transform.localPosition = new Vector3(0f, -0.0266666f, 0f);
						this.PuzzleCube.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
					}
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.SolvingPuzzle = true;
					this.Distracted = true;
					this.Routine = false;
				}
				else
				{
					bool flag8 = false;
					if (this.Yandere.Bloodiness + (float)this.Yandere.GloveBlood > 0f && !this.Yandere.Paint)
					{
						flag8 = true;
					}
					if (!this.Witness && flag8)
					{
						this.Prompt.Circle[0].fillAmount = 1f;
						this.YandereVisible = true;
						this.Alarm = 200f;
					}
					else
					{
						this.SpeechLines.Stop();
						this.Yandere.TargetStudent = this;
						if (!this.Grudge)
						{
							if (!this.Yandere.StudentManager.TutorialActive)
							{
								this.ClubManager.CheckGrudge(this.Club);
							}
							if (ClubGlobals.GetClubKicked(this.Club) && flag)
							{
								this.Interaction = StudentInteractionType.ClubGrudge;
								this.TalkTimer = 5f;
								this.Warned = true;
							}
							else if (this.Yandere.Club == this.Club && flag && this.ClubManager.ClubGrudge)
							{
								this.Interaction = StudentInteractionType.ClubKick;
								ClubGlobals.SetClubKicked(this.Club, true);
								this.TalkTimer = 5f;
								this.Warned = true;
							}
							else if (this.CanBeFed)
							{
								this.Interaction = StudentInteractionType.Feeding;
								this.TalkTimer = 10f;
							}
							else if (this.CanTakeSnack)
							{
								this.Yandere.Interaction = YandereInteractionType.GivingSnack;
								this.Yandere.TalkTimer = 3f;
								this.Interaction = StudentInteractionType.Idle;
							}
							else if (this.CanGiveHelp)
							{
								this.Yandere.Interaction = YandereInteractionType.AskingForHelp;
								this.Yandere.TalkTimer = 5f;
								this.Interaction = StudentInteractionType.Idle;
							}
							else if (!this.StudentManager.Eighties && this.StudentID == 10 && this.StudentManager.TaskManager.TaskStatus[46] == 1 && this.Yandere.PickUp == null)
							{
								if (this.FollowTarget != null)
								{
									this.StudentManager.LastKnownOsana.position = this.FollowTarget.transform.position;
								}
								this.Interaction = StudentInteractionType.Idle;
								this.Yandere.Interaction = YandereInteractionType.TaskInquiry;
								this.Yandere.TalkTimer = 5f;
							}
							else if (this.StudentID > 89 && this.StudentManager.CanSelfReport)
							{
								this.StudentManager.Reputation.UpdateRep();
								this.Police.SelfReported = true;
								this.StudentManager.Reputation.Portal.EndDay();
							}
							else if (this.StudentID == 79 && this.DistanceToDestination < 1f && this.Actions[this.Phase] == StudentActionType.Wait)
							{
								this.Interaction = StudentInteractionType.WaitingForBeatEmUpResult;
							}
							else
							{
								this.DistanceToDestination = Vector3.Distance(base.transform.position, this.Destinations[this.Phase].position);
								if (this.Sleuthing && this.SleuthTarget != null)
								{
									this.DistanceToDestination = Vector3.Distance(base.transform.position, this.SleuthTarget.position);
								}
								if (flag)
								{
									Debug.Log("This character is able to discuss club leader stuff right now.");
									int num;
									if (this.Club == ClubType.Photography && this.Sleuthing)
									{
										num = 5;
									}
									else
									{
										num = 0;
									}
									if (this.StudentManager.EmptyDemon)
									{
										num = (int)(this.Club * (ClubType)(-1));
									}
									this.Subtitle.UpdateLabel(SubtitleType.ClubGreeting, (int)(this.Club + num), 4f);
									this.DialogueWheel.ClubLeader = true;
								}
								else
								{
									this.Subtitle.UpdateLabel(SubtitleType.Greeting, 0, 3f);
								}
								if (this.Club != ClubType.Council && this.Club != ClubType.Delinquent && ((this.Male && this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 0) || this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 4))
								{
									ParticleSystem.EmissionModule emission = this.Hearts.emission;
									emission.rateOverTime = (float)(this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus);
									emission.enabled = true;
									this.Hearts.Play();
								}
								this.StudentManager.DisablePrompts();
								this.StudentManager.VolumeDown();
								this.DialogueWheel.HideShadows();
								this.DialogueWheel.Show = true;
								this.DialogueWheel.Panel.enabled = true;
								this.TalkTimer = 0f;
							}
						}
						else if (flag)
						{
							this.Interaction = StudentInteractionType.ClubUnwelcome;
							this.TalkTimer = 5f;
							this.Warned = true;
						}
						else
						{
							this.Interaction = StudentInteractionType.PersonalGrudge;
							this.TalkTimer = 5f;
							this.Warned = true;
						}
						this.Yandere.ShoulderCamera.OverShoulder = true;
						this.Pathfinding.canSearch = false;
						this.Pathfinding.canMove = false;
						this.Obstacle.enabled = true;
						this.Giggle = null;
						this.Yandere.WeaponMenu.KeyboardShow = false;
						this.Yandere.WeaponMenu.Show = false;
						this.Yandere.YandereVision = false;
						this.Yandere.CanMove = false;
						this.Yandere.Talking = true;
						this.Investigating = false;
						this.Talk.enabled = true;
						this.Reacted = false;
						this.Routine = false;
						this.Talking = true;
						this.TargetDistance = 0.5f;
						this.CuriosityPhase = 0;
						this.ReadPhase = 0;
						this.EmptyHands();
						bool flag9 = false;
						if (this.CurrentAction == StudentActionType.Sunbathe && this.SunbathePhase > 2)
						{
							this.SunbathePhase = 2;
							flag9 = true;
						}
						if (this.Phoneless)
						{
							this.SmartPhone.SetActive(false);
						}
						else if (this.Sleuthing)
						{
							if (!this.Scrubber.activeInHierarchy)
							{
								this.SmartPhone.SetActive(true);
							}
							else
							{
								this.SmartPhone.SetActive(false);
							}
						}
						else if (this.Persona != PersonaType.PhoneAddict)
						{
							this.SmartPhone.SetActive(false);
						}
						else if (!this.Scrubber.activeInHierarchy && !flag9)
						{
							this.SmartPhone.SetActive(true);
						}
						this.ChalkDust.Stop();
						this.StopPairing();
					}
				}
			}
		}
		if (this.Prompt.Circle[2].fillAmount == 0f || (this.Yandere.Sanity < 33.33333f && this.Yandere.CanMove && !this.Prompt.HideButton[2] && this.Prompt.InSight && this.Club != ClubType.Council && !this.Struggling && !this.Chasing && this.DistanceToPlayer < 1.4f && this.SeenByYandere() && this.StudentID > 1))
		{
			if (!this.Yandere.Armed && this.Drownable)
			{
				Debug.Log("Just began to drown someone.");
				if (this.VomitDoor != null)
				{
					this.VomitDoor.Prompt.enabled = true;
					this.VomitDoor.enabled = true;
				}
				this.Yandere.EmptyHands();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Prompt.Circle[2].fillAmount = 1f;
				this.VomitEmitter.gameObject.SetActive(false);
				this.Police.DrownedStudentName = this.Name;
				this.MyController.enabled = false;
				this.VomitEmitter.gameObject.SetActive(false);
				this.SmartPhone.SetActive(false);
				this.Police.DrownVictims++;
				this.Distracted = true;
				this.Routine = false;
				this.Drowned = true;
				if (this.Male)
				{
					this.Subtitle.UpdateLabel(SubtitleType.DrownReaction, 1, 3f);
				}
				else
				{
					this.Subtitle.UpdateLabel(SubtitleType.DrownReaction, 0, 3f);
				}
				this.Yandere.TargetStudent = this;
				this.Yandere.Attacking = true;
				this.Yandere.CanMove = false;
				this.Yandere.Drown = true;
				this.Yandere.DrownAnim = "f02_fountainDrownA_00";
				if (this.Male)
				{
					if (Vector3.Distance(base.transform.position, this.StudentManager.transform.position) < 5f)
					{
						this.DrownAnim = "fountainDrown_00_B";
					}
					else
					{
						this.DrownAnim = "toiletDrown_00_B";
					}
				}
				else if (Vector3.Distance(base.transform.position, this.StudentManager.transform.position) < 5f)
				{
					this.DrownAnim = "f02_fountainDrownB_00";
				}
				else
				{
					this.DrownAnim = "f02_toiletDrownB_00";
				}
				this.CharacterAnimation.CrossFade(this.DrownAnim);
				return;
			}
			float f = Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position);
			this.Yandere.AttackManager.Stealth = (Mathf.Abs(f) <= 45f);
			bool flag10 = false;
			if (this.Yandere.AttackManager.Stealth && (this.Yandere.EquippedWeapon.Type == WeaponType.Bat || this.Yandere.EquippedWeapon.Type == WeaponType.Weight))
			{
				flag10 = true;
			}
			Debug.Log("Before attacking, # of OriginalUniforms was: " + this.StudentManager.OriginalUniforms.ToString() + " and # of NewUniforms was: " + this.StudentManager.NewUniforms.ToString());
			if (flag10 || this.StudentManager.OriginalUniforms + this.StudentManager.NewUniforms > 1)
			{
				if (this.ClubActivityPhase < 16)
				{
					bool flag11 = false;
					if (this.Club == ClubType.Delinquent && !this.Injured && !this.Yandere.AttackManager.Stealth && !this.RespectEarned && !this.SolvingPuzzle)
					{
						Debug.Log(this.Name + " knows that Yandere-chan is tyring to attack them.");
						flag11 = true;
						this.Fleeing = false;
						this.Patience = 1;
						this.Shove();
						this.SpawnAlarmDisc();
					}
					if (this.Yandere.AttackManager.Stealth)
					{
						this.SpawnSmallAlarmDisc();
					}
					if (!flag11 && !this.Yandere.NearSenpai && !this.Yandere.Attacking && this.Yandere.Stance.Current != StanceType.Crouching)
					{
						if (this.Yandere.EquippedWeapon.Flaming || this.Yandere.CyborgParts[1].activeInHierarchy)
						{
							this.Yandere.SanityBased = false;
						}
						if (this.Strength == 9 && !this.Emetic && !this.Lethal && !this.Sedated && !this.Headache)
						{
							if (!this.Yandere.AttackManager.Stealth)
							{
								this.CharacterAnimation.CrossFade("f02_dramaticFrontal_00");
							}
							else
							{
								this.CharacterAnimation.CrossFade("f02_dramaticStealth_00");
							}
							this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
							this.Yandere.CanMove = false;
							this.DramaticCamera.enabled = true;
							this.DramaticCamera.rect = new Rect(0f, 0.5f, 1f, 0f);
							this.DramaticCamera.gameObject.SetActive(true);
							this.DramaticCamera.gameObject.GetComponent<AudioSource>().Play();
							this.DramaticReaction = true;
							this.Pathfinding.canSearch = false;
							this.Pathfinding.canMove = false;
							this.Routine = false;
							return;
						}
						if (this.Yandere.EquippedWeapon.WeaponID != 27 || (this.Yandere.EquippedWeapon.WeaponID == 27 && this.Yandere.AttackManager.Stealth))
						{
							this.AttackReaction();
							return;
						}
						Debug.Log("Can't frontal attack with garrote.");
						return;
					}
				}
			}
			else if (!this.Yandere.ClothingWarning)
			{
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Clothing);
				this.StudentManager.TutorialWindow.ShowClothingMessage = true;
				this.Yandere.ClothingWarning = true;
			}
		}
	}

	// Token: 0x06001E27 RID: 7719 RVA: 0x001909B4 File Offset: 0x0018EBB4
	private void UpdateDying()
	{
		this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
		if (this.Attacked)
		{
			if (!this.Teacher)
			{
				if (this.Strength == 9 && !this.Emetic && !this.Lethal && !this.Sedated && !this.Headache)
				{
					if (!this.StudentManager.Stop)
					{
						this.StudentManager.StopMoving();
						this.Yandere.RPGCamera.enabled = false;
						this.SmartPhone.SetActive(false);
						this.Police.Show = false;
					}
					this.CharacterAnimation.CrossFade("f02_moCounterB_00");
					if (!this.WitnessedMurder && this.CharacterAnimation["f02_moLipSync_00"].weight == 0f)
					{
						this.CharacterAnimation["f02_moLipSync_00"].weight = 1f;
						this.CharacterAnimation["f02_moLipSync_00"].time = 0f;
						this.CharacterAnimation.Play("f02_moLipSync_00");
					}
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
					this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
					return;
				}
				this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
				if (this.Alive && !this.Tranquil)
				{
					if (this.Yandere.SanityBased)
					{
						this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * this.Yandere.AttackManager.Distance);
						if (!this.Yandere.AttackManager.Stealth)
						{
							this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
						}
						else
						{
							this.targetRotation = Quaternion.LookRotation(base.transform.position - new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z));
						}
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
						return;
					}
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
					if (this.Yandere.EquippedWeapon.WeaponID == 11)
					{
						this.CharacterAnimation.CrossFade(this.CyborgDeathAnim);
						this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
						if (this.CharacterAnimation[this.CyborgDeathAnim].time >= this.CharacterAnimation[this.CyborgDeathAnim].length - 0.25f && this.Yandere.EquippedWeapon.WeaponID == 11)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.BloodyScream, base.transform.position + Vector3.up, Quaternion.identity);
							this.DeathType = DeathType.EasterEgg;
							this.BecomeRagdoll();
							this.Ragdoll.Dismember();
							return;
						}
					}
					else
					{
						if (this.Yandere.EquippedWeapon.WeaponID == 7)
						{
							this.CharacterAnimation.CrossFade(this.BuzzSawDeathAnim);
							this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
							return;
						}
						if (!this.Yandere.EquippedWeapon.Concealable)
						{
							this.CharacterAnimation.CrossFade(this.SwingDeathAnim);
							this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
							return;
						}
						this.CharacterAnimation.CrossFade(this.DefendAnim);
						this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.1f);
						return;
					}
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.DeathAnim);
					if (this.CharacterAnimation[this.DeathAnim].time < 1f)
					{
						base.transform.Translate(Vector3.back * Time.deltaTime);
						return;
					}
					this.BecomeRagdoll();
					return;
				}
			}
			else
			{
				if (!this.StudentManager.Stop)
				{
					this.StudentManager.StopMoving();
					this.Yandere.Laughing = false;
					this.Yandere.Dipping = false;
					this.Yandere.RPGCamera.enabled = false;
					this.SmartPhone.SetActive(false);
					this.Police.Show = false;
				}
				this.CharacterAnimation.CrossFade(this.CounterAnim);
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
		}
	}

	// Token: 0x06001E28 RID: 7720 RVA: 0x0019111C File Offset: 0x0018F31C
	private void UpdatePushed()
	{
		this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
		this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
		if (this.CharacterAnimation[this.PushedAnim].time >= this.CharacterAnimation[this.PushedAnim].length)
		{
			this.BecomeRagdoll();
		}
	}

	// Token: 0x06001E29 RID: 7721 RVA: 0x001911A4 File Offset: 0x0018F3A4
	private void UpdateDrowned()
	{
		this.SplashTimer += Time.deltaTime;
		if (this.SplashTimer > 3f && this.SplashTimer < 100f)
		{
			this.DrowningSplashes.Play();
			this.SplashTimer += 100f;
		}
		this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
		this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
		if (this.CharacterAnimation[this.DrownAnim].time >= this.CharacterAnimation[this.DrownAnim].length)
		{
			this.BecomeRagdoll();
		}
	}

	// Token: 0x06001E2A RID: 7722 RVA: 0x00191274 File Offset: 0x0018F474
	private void UpdateWitnessedMurder()
	{
		if (this.Threatened)
		{
			this.UpdateAlarmed();
			return;
		}
		if (!this.Fleeing && !this.Shoving)
		{
			if (this.StudentID > 1 && this.Persona != PersonaType.Evil)
			{
				this.EyeShrink += Time.deltaTime * 0.2f;
			}
			if (this.Yandere.TargetStudent != null && this.LovedOneIsTargeted(this.Yandere.TargetStudent.StudentID))
			{
				this.Strength = 5;
				this.Persona = PersonaType.Heroic;
				this.SmartPhone.SetActive(false);
				this.SprintAnim = this.OriginalSprintAnim;
			}
			if ((this.Club != ClubType.Delinquent || (this.Club == ClubType.Delinquent && this.Injured)) && this.Yandere.TargetStudent == null && this.LovedOneIsTargeted(this.Yandere.NearestCorpseID))
			{
				this.Strength = 5;
				if (this.Injured)
				{
					this.Strength = 1;
				}
				this.Persona = PersonaType.Heroic;
			}
			if (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null && this.Yandere.PickUp.BodyPart.Type == 1 && this.LovedOneIsTargeted(this.Yandere.PickUp.BodyPart.StudentID))
			{
				this.Strength = 5;
				this.Persona = PersonaType.Heroic;
				this.SmartPhone.SetActive(false);
				this.SprintAnim = this.OriginalSprintAnim;
			}
			if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
			{
				if (!this.Attacked)
				{
					this.PhoneAddictCameraUpdate();
				}
			}
			else
			{
				this.CharacterAnimation.CrossFade(this.ScaredAnim);
			}
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.position.x, base.transform.position.y, this.Yandere.Hips.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			if (!this.Yandere.Struggling)
			{
				if (this.Persona != PersonaType.Heroic && this.Persona != PersonaType.Dangerous && this.Persona != PersonaType.Violent)
				{
					this.AlarmTimer += Time.deltaTime * (float)this.MurdersWitnessed;
					if (this.Urgent && this.Yandere.CanMove)
					{
						if (this.StudentID == 1)
						{
							this.SenpaiNoticed();
						}
						this.AlarmTimer += 5f;
					}
				}
				else
				{
					this.AlarmTimer += Time.deltaTime * ((float)this.MurdersWitnessed * 5f);
				}
			}
			else if (this.Yandere.Won)
			{
				this.Urgent = true;
			}
			if (this.AlarmTimer > 5f)
			{
				this.PersonaReaction();
				this.AlarmTimer = 0f;
				return;
			}
			if (this.AlarmTimer > 1f && !this.Reacted)
			{
				if (this.StudentID > 1 || this.Yandere.Mask != null)
				{
					if (this.StudentID == 1)
					{
						Debug.Log("Senpai saw a mask.");
						this.Persona = PersonaType.Heroic;
						this.PersonaReaction();
					}
					if (!this.Teacher)
					{
						if (this.Persona != PersonaType.Evil)
						{
							if (this.Club == ClubType.Delinquent)
							{
								this.SmartPhone.SetActive(false);
							}
							else if (!this.StudentManager.Eighties && this.StudentID == 10)
							{
								Debug.Log("This is the exact moment that Raibaru witnesses Yandere-chan commit murder.");
								this.Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 1, 3f);
								this.Yandere.Chasers++;
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.MurderReaction, 1, 3f);
							}
						}
					}
					else if (this.WitnessedCoverUp)
					{
						this.Subtitle.UpdateLabel(SubtitleType.TeacherCoverUpHostile, 1, 5f);
					}
					else
					{
						this.DetermineWhatWasWitnessed();
						this.DetermineTeacherSubtitle();
					}
				}
				else
				{
					Debug.Log("Senpai witnessed murder, and entered a specific murder reaction animation.");
					this.MurderReaction = UnityEngine.Random.Range(1, 6);
					this.CharacterAnimation.CrossFade("senpaiMurderReaction_0" + this.MurderReaction.ToString());
					this.GameOverCause = GameOverType.Murder;
					if (!this.Yandere.Egg)
					{
						this.SenpaiNoticed();
					}
					this.CharacterAnimation["scaredFace_00"].weight = 0f;
					this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
					this.Yandere.ShoulderCamera.enabled = true;
					this.Yandere.ShoulderCamera.Noticed = true;
					this.Yandere.RPGCamera.enabled = false;
					this.Stop = true;
				}
				this.Reacted = true;
			}
		}
	}

	// Token: 0x06001E2B RID: 7723 RVA: 0x00191780 File Offset: 0x0018F980
	private void UpdateAlarmed()
	{
		if (!this.Threatened)
		{
			if (this.Yandere.Medusa && this.YandereVisible)
			{
				this.TurnToStone();
				return;
			}
			if (this.Persona != PersonaType.PhoneAddict && !this.Sleuthing)
			{
				this.SmartPhone.SetActive(false);
			}
			this.OccultBook.SetActive(false);
			this.Pen.SetActive(false);
			this.SpeechLines.Stop();
			this.ReadPhase = 0;
			if (this.WitnessedCorpse)
			{
				if (!this.WalkBack)
				{
					int studentID = this.StudentID;
					if (this.Persona != PersonaType.PhoneAddict)
					{
						this.CharacterAnimation.CrossFade(this.ScaredAnim);
					}
					else if (!this.Phoneless && !this.Attacked)
					{
						this.PhoneAddictCameraUpdate();
					}
				}
				else
				{
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.MyController.Move(base.transform.forward * (-0.5f * Time.deltaTime));
					this.CharacterAnimation.CrossFade(this.WalkBackAnim);
					this.WalkBackTimer -= Time.deltaTime;
					if (this.WalkBackTimer <= 0f)
					{
						this.WalkBack = false;
					}
				}
			}
			else if (this.StudentID > 1)
			{
				if (this.Witness)
				{
					this.CharacterAnimation.CrossFade(this.LeanAnim);
				}
				else
				{
					if (!this.Investigating)
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					if (this.FocusOnYandere)
					{
						if (this.DistanceToPlayer < 1f && !this.Injured && (this.Club == ClubType.Council || (this.Club == ClubType.Delinquent && !this.Injured)))
						{
							this.AlarmTimer = 0f;
							this.ThreatTimer += Time.deltaTime;
							if (this.ThreatTimer > 5f && !this.Yandere.Struggling && !this.Yandere.DelinquentFighting && this.Prompt.InSight)
							{
								this.ThreatTimer = 0f;
								this.Shove();
							}
						}
						this.DistractionSpot = new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z);
					}
				}
			}
			else
			{
				this.CharacterAnimation.CrossFade(this.LeanAnim);
			}
			if (this.WitnessedMurder)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			}
			else if (this.WitnessedCorpse)
			{
				if (this.Corpse != null && this.Corpse.AllColliders[0] != null)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				}
			}
			else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
			{
				if (this.BloodPool != null)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.BloodPool.transform.position.x, base.transform.position.y, this.BloodPool.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				}
			}
			else if (!this.Investigating && !this.FocusOnYandere && this.DiscCheck)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.DistractionSpot.x, base.transform.position.y, this.DistractionSpot.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			}
			if (!this.Fleeing && !this.Yandere.DelinquentFighting)
			{
				this.AlarmTimer += Time.deltaTime * (1f - this.Hesitation);
			}
			if (!this.CanStillNotice)
			{
				this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia) * 5f;
			}
			if (this.AlarmTimer < 5f && this.BloodPool != null && this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition) && this.BloodPool.parent == this.Yandere.RightHand)
			{
				this.ForgetAboutBloodPool();
			}
			if (this.AlarmTimer > 5f)
			{
				this.EndAlarm();
			}
			else if (this.AlarmTimer > 1f && !this.Reacted)
			{
				if (this.Teacher)
				{
					if (!this.WitnessedCorpse)
					{
						Debug.Log("A teacher's subtitle is now being determined.");
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						switch (this.Witnessed)
						{
						case StudentWitnessType.Blood:
							this.Subtitle.UpdateLabel(SubtitleType.TeacherBloodReaction, 1, 6f);
							this.GameOverCause = GameOverType.Blood;
							break;
						case StudentWitnessType.BloodAndInsanity:
						case StudentWitnessType.Insanity:
						case StudentWitnessType.CleaningItem:
						case StudentWitnessType.Poisoning:
						case StudentWitnessType.WeaponAndBloodAndInsanity:
						case StudentWitnessType.WeaponAndInsanity:
							this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
							this.GameOverCause = GameOverType.Insanity;
							break;
						case StudentWitnessType.Lewd:
							this.Subtitle.UpdateLabel(SubtitleType.TeacherLewdReaction, 1, 6f);
							this.GameOverCause = GameOverType.Lewd;
							break;
						case StudentWitnessType.Pickpocketing:
						case StudentWitnessType.Theft:
							this.Subtitle.UpdateLabel(SubtitleType.TeacherTheftReaction, 1, 6f);
							break;
						case StudentWitnessType.Trespassing:
							this.Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, this.Concern, 5f);
							break;
						case StudentWitnessType.Violence:
							Debug.Log("A teacher witnessed violence.");
							this.Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, 1, 6f);
							this.GameOverCause = GameOverType.Violence;
							this.Concern = 5;
							break;
						case StudentWitnessType.Weapon:
						case StudentWitnessType.WeaponAndBlood:
							this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponReaction, 1, 6f);
							this.GameOverCause = GameOverType.Weapon;
							break;
						}
						if (this.Club == ClubType.Council)
						{
							UnityEngine.Object.Destroy(this.Subtitle.CurrentClip);
							this.Subtitle.UpdateLabel(SubtitleType.CouncilToCounselor, this.ClubMemberID, 6f);
						}
						if (this.BloodPool != null)
						{
							Debug.Log("The teacher was alarmed because she saw something weird on the ground - a " + this.BloodPool.name);
							UnityEngine.Object.Destroy(this.Subtitle.CurrentClip);
							this.Subtitle.UpdateLabel(SubtitleType.BloodPoolReaction, 2, 5f);
							PromptScript component = this.BloodPool.GetComponent<PromptScript>();
							if (component != null)
							{
								Debug.Log("Disabling a bloody object's prompt because a teacher is heading for it.");
								component.Hide();
								component.enabled = false;
							}
						}
					}
					else
					{
						Debug.Log("A teacher found a corpse.");
						this.Concern = 1;
						this.DetermineWhatWasWitnessed();
						this.DetermineTeacherSubtitle();
						if (this.WitnessedMurder)
						{
							this.MurdersWitnessed++;
							if (!this.Yandere.Chased)
							{
								Debug.Log("A teacher has reached ChaseYandere() through UpdateAlarm().");
								this.ChaseYandere();
							}
						}
					}
					if (!this.Guarding && !this.Chasing && ((this.YandereVisible && this.Concern == 5) || this.Yandere.Noticed))
					{
						Debug.Log("Yandere-chan is getting sent to the guidance counselor.");
						if (this.Witnessed == StudentWitnessType.Theft && this.Yandere.StolenObject != null)
						{
							this.Yandere.StolenObject.SetActive(true);
							this.Yandere.StolenObject = null;
							this.Yandere.Inventory.IDCard = false;
						}
						this.StudentManager.CombatMinigame.Stop();
						this.CharacterAnimation[this.AngryFaceAnim].weight = 1f;
						this.Yandere.ShoulderCamera.enabled = true;
						this.Yandere.ShoulderCamera.Noticed = true;
						this.Yandere.RPGCamera.enabled = false;
						this.Stop = true;
					}
				}
				else if (this.StudentID > 1 || this.Yandere.Mask != null)
				{
					if (this.StudentID == 41 && !this.StudentManager.Eighties)
					{
						this.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
					}
					else if (this.RepeatReaction)
					{
						if (!this.StudentManager.Eighties && this.StudentID == 48 && this.TaskPhase == 4 && this.Yandere.Armed && this.Yandere.EquippedWeapon.WeaponID == 12)
						{
							this.Subtitle.CustomText = "Is that dumbbell for me? Drop it over here!";
							this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
						}
						else
						{
							this.Subtitle.UpdateLabel(SubtitleType.RepeatReaction, 1, 3f);
							this.RepeatReaction = false;
						}
					}
					else if (this.Club != ClubType.Delinquent)
					{
						if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodAndInsanityReaction, 1, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
						{
							this.Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodReaction, 1, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.WeaponAndInsanityReaction, 1, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.BloodAndInsanityReaction, 1, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.Weapon)
						{
							this.Subtitle.StudentID = this.StudentID;
							this.Subtitle.UpdateLabel(SubtitleType.WeaponReaction, this.WeaponWitnessed, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.Blood)
						{
							if (!this.Bloody)
							{
								this.Subtitle.UpdateLabel(SubtitleType.BloodReaction, 1, 3f);
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.WetBloodReaction, 1, 3f);
								this.Witnessed = StudentWitnessType.None;
								this.Witness = false;
							}
						}
						else if (this.Witnessed == StudentWitnessType.Insanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.InsanityReaction, 1, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.Lewd)
						{
							this.Subtitle.UpdateLabel(SubtitleType.LewdReaction, 1, 3f);
						}
						else if (this.Witnessed == StudentWitnessType.CleaningItem)
						{
							this.Subtitle.UpdateLabel(SubtitleType.SuspiciousReaction, 0, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.Suspicious)
						{
							this.Subtitle.UpdateLabel(SubtitleType.SuspiciousReaction, 1, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.Corpse)
						{
							Debug.Log(this.Name + " is currently reacting to the corpse of " + this.Corpse.Student.Name + " and is deciding what subtitle to use.");
							if (this.StudentID == this.StudentManager.ObstacleID && this.Corpse.Student.Rival)
							{
								this.Subtitle.Speaker = this;
								this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 1, 5f);
								Debug.Log("Raibaru is reacting to Osana's corpse with a unique subtitle.");
							}
							else if (this.StudentID == 11 && this.Corpse.StudentID == this.StudentManager.ObstacleID)
							{
								this.Subtitle.Speaker = this;
								this.Subtitle.UpdateLabel(SubtitleType.OsanaObstacleDeathReaction, 1, 5f);
								Debug.Log("Osana is reacting to Raibaru's corpse with a unique subtitle.");
							}
							else if (this.Club == ClubType.Council)
							{
								if (this.StudentID == 86)
								{
									this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 1, 5f);
								}
								else if (this.StudentID == 87)
								{
									this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 2, 5f);
								}
								else if (this.StudentID == 88)
								{
									this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 3, 5f);
								}
								else if (this.StudentID == 89)
								{
									this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 4, 5f);
								}
							}
							else if (this.Persona == PersonaType.Evil)
							{
								this.Subtitle.UpdateLabel(SubtitleType.EvilCorpseReaction, 1, 5f);
							}
							else if (!this.Corpse.Choking)
							{
								this.Subtitle.UpdateLabel(SubtitleType.CorpseReaction, 0, 5f);
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.CorpseReaction, 1, 5f);
							}
						}
						else if (this.Witnessed == StudentWitnessType.Interruption)
						{
							if (this.StudentID == 11)
							{
								this.Subtitle.UpdateLabel(SubtitleType.InterruptionReaction, 1, 5f);
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.InterruptionReaction, 2, 5f);
							}
						}
						else if (this.Witnessed == StudentWitnessType.Eavesdropping)
						{
							if (this.Rival)
							{
								this.Subtitle.UpdateLabel(SubtitleType.RivalEavesdropReaction, 0, 9f);
								this.Hesitation = 0.6f;
							}
							else if (this.StudentID == 10)
							{
								this.Subtitle.UpdateLabel(SubtitleType.RivalEavesdropReaction, 1, 9f);
								this.Hesitation = 0.6f;
							}
							else if (this.EventInterrupted)
							{
								this.Subtitle.UpdateLabel(SubtitleType.EventEavesdropReaction, 1, 5f);
								this.EventInterrupted = false;
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.EavesdropReaction, 1, 5f);
							}
						}
						else if (this.Witnessed == StudentWitnessType.Pickpocketing)
						{
							this.Subtitle.UpdateLabel(this.PickpocketSubtitleType, 1, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.Violence)
						{
							this.Subtitle.UpdateLabel(SubtitleType.ViolenceReaction, 5, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.Poisoning)
						{
							if (this.Yandere.TargetBento != null)
							{
								if (this.Yandere.TargetBento.StudentID != this.StudentID)
								{
									this.Subtitle.UpdateLabel(SubtitleType.PoisonReaction, 1, 5f);
								}
								else
								{
									this.Subtitle.UpdateLabel(SubtitleType.PoisonReaction, 2, 5f);
									this.Phase++;
									this.Pathfinding.target = this.Destinations[this.Phase];
									this.CurrentDestination = this.Destinations[this.Phase];
								}
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.PoisonReaction, 1, 5f);
							}
						}
						else if (this.Witnessed == StudentWitnessType.SeveredLimb)
						{
							this.Subtitle.UpdateLabel(SubtitleType.LimbReaction, 0, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.BloodyWeapon)
						{
							this.Subtitle.UpdateLabel(SubtitleType.BloodyWeaponReaction, 0, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.DroppedWeapon)
						{
							this.Subtitle.UpdateLabel(SubtitleType.BloodyWeaponReaction, 0, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.BloodPool)
						{
							this.Subtitle.UpdateLabel(SubtitleType.BloodPoolReaction, 0, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.HoldingBloodyClothing)
						{
							this.Subtitle.UpdateLabel(SubtitleType.HoldingBloodyClothingReaction, 0, 5f);
						}
						else if (this.Witnessed == StudentWitnessType.Theft)
						{
							if (this.StudentID == 2 && this.RingReact)
							{
								this.Subtitle.UpdateLabel(SubtitleType.TheftReaction, 1, 5f);
							}
							else
							{
								this.Subtitle.UpdateLabel(SubtitleType.TheftReaction, 0, 5f);
							}
						}
						else if (this.Witnessed == StudentWitnessType.Tutorial)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TutorialReaction, 0, 10f);
						}
						else if (this.Club == ClubType.Council)
						{
							this.Subtitle.UpdateLabel(SubtitleType.HmmReaction, this.ClubMemberID, 3f);
							this.TemporarilyBlind = false;
						}
						else
						{
							this.Subtitle.UpdateLabel(SubtitleType.HmmReaction, 0, 3f);
						}
					}
					else if (this.Witnessed == StudentWitnessType.None)
					{
						this.Subtitle.Speaker = this;
						this.Subtitle.UpdateLabel(SubtitleType.DelinquentHmm, 0, 5f);
					}
					else if (this.Witnessed == StudentWitnessType.Corpse)
					{
						if (this.FoundEnemyCorpse)
						{
							this.Subtitle.UpdateLabel(SubtitleType.EvilDelinquentCorpseReaction, 1, 5f);
						}
						else if (this.Corpse.Student.Club == ClubType.Delinquent)
						{
							this.Subtitle.Speaker = this;
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentFriendCorpseReaction, 1, 5f);
							this.FoundFriendCorpse = true;
						}
						else
						{
							this.Subtitle.Speaker = this;
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentCorpseReaction, 1, 5f);
						}
					}
					else if (this.Witnessed == StudentWitnessType.Weapon && !this.Injured)
					{
						this.Subtitle.Speaker = this;
						this.Subtitle.UpdateLabel(SubtitleType.DelinquentWeaponReaction, 0, 3f);
					}
					else
					{
						this.Subtitle.Speaker = this;
						if (this.WitnessedLimb || this.WitnessedWeapon || this.WitnessedBloodPool || this.WitnessedBloodyWeapon)
						{
							this.Subtitle.UpdateLabel(SubtitleType.LimbReaction, 0, 5f);
						}
						else
						{
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentReaction, 0, 5f);
							Debug.Log("A delinquent is reacting to Yandere-chan's behavior.");
						}
					}
				}
				else
				{
					Debug.Log("We are now determining what Senpai saw...");
					if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
					{
						this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
						this.GameOverCause = GameOverType.Insanity;
					}
					else if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
					{
						this.CharacterAnimation.CrossFade("senpaiWeaponReaction_00");
						this.GameOverCause = GameOverType.Weapon;
					}
					else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
					{
						this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
						this.GameOverCause = GameOverType.Insanity;
					}
					else if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
					{
						this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
						this.GameOverCause = GameOverType.Insanity;
					}
					else if (this.Witnessed == StudentWitnessType.Weapon)
					{
						this.CharacterAnimation.CrossFade("senpaiWeaponReaction_00");
						this.GameOverCause = GameOverType.Weapon;
					}
					else if (this.Witnessed == StudentWitnessType.Blood)
					{
						this.CharacterAnimation.CrossFade("senpaiBloodReaction_00");
						this.GameOverCause = GameOverType.Blood;
					}
					else if (this.Witnessed == StudentWitnessType.Insanity)
					{
						this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
						this.GameOverCause = GameOverType.Insanity;
					}
					else if (this.Witnessed == StudentWitnessType.Lewd)
					{
						this.CharacterAnimation.CrossFade("senpaiLewdReaction_00");
						this.GameOverCause = GameOverType.Lewd;
					}
					else if (this.Witnessed == StudentWitnessType.Stalking)
					{
						if (this.Concern < 5)
						{
							this.Subtitle.UpdateLabel(SubtitleType.SenpaiStalkingReaction, this.Concern, 4.5f);
						}
						else
						{
							this.CharacterAnimation.CrossFade("senpaiCreepyReaction_00");
							this.GameOverCause = GameOverType.Stalking;
						}
						this.Witnessed = StudentWitnessType.None;
					}
					else if (this.Witnessed == StudentWitnessType.Corpse)
					{
						if (this.Corpse.Student.Rival)
						{
							this.Subtitle.Speaker = this;
							this.Subtitle.UpdateLabel(SubtitleType.SenpaiRivalDeathReaction, 1, 5f);
							Debug.Log("Senpai is reacting to Osana's corpse with a unique subtitle.");
						}
						else
						{
							this.Subtitle.UpdateLabel(SubtitleType.SenpaiCorpseReaction, 1, 5f);
						}
					}
					else if (this.Witnessed == StudentWitnessType.Violence)
					{
						this.CharacterAnimation.CrossFade("senpaiFightReaction_00");
						this.GameOverCause = GameOverType.Violence;
						this.Concern = 5;
					}
					if (this.Concern == 5)
					{
						this.CharacterAnimation["scaredFace_00"].weight = 0f;
						this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
						this.Yandere.ShoulderCamera.enabled = true;
						this.Yandere.ShoulderCamera.Noticed = true;
						this.Yandere.RPGCamera.enabled = false;
						this.Stop = true;
					}
				}
				this.Reacted = true;
			}
			if (this.Club == ClubType.Council && this.DistanceToPlayer < 1.1f && !this.Yandere.Invisible && (this.Yandere.Armed || (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed)) && this.Prompt.InSight)
			{
				if (this.Yandere.Armed && !this.Yandere.EquippedWeapon.Suspicious && !this.WitnessedMurder)
				{
					this.Shove();
					return;
				}
				this.Spray();
				return;
			}
		}
		else
		{
			this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
			if (this.StudentManager.CombatMinigame.Delinquent == null || this.StudentManager.CombatMinigame.Delinquent == this)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
			}
			else
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.CombatMinigame.Midpoint.position.x, base.transform.position.y, this.StudentManager.CombatMinigame.Midpoint.position.z) - base.transform.position);
			}
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			if (this.Yandere.DelinquentFighting && this.StudentManager.CombatMinigame.Delinquent != this)
			{
				if (this.StudentManager.CombatMinigame.Path >= 4)
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim, 5f);
					this.NoTalk = true;
					return;
				}
				if (this.DistanceToPlayer < 1f)
				{
					this.MyController.Move(base.transform.forward * Time.deltaTime * -1f);
				}
				if (Vector3.Distance(base.transform.position, this.StudentManager.CombatMinigame.Delinquent.transform.position) < 1f)
				{
					this.MyController.Move(base.transform.forward * Time.deltaTime * -1f);
				}
				if (this.Yandere.enabled)
				{
					this.CheerTimer = Mathf.MoveTowards(this.CheerTimer, 0f, Time.deltaTime);
					if (this.CheerTimer == 0f)
					{
						this.Subtitle.Speaker = this;
						this.Subtitle.UpdateLabel(SubtitleType.DelinquentCheer, 0, 5f);
						this.CheerTimer = UnityEngine.Random.Range(2f, 3f);
					}
				}
				this.CharacterAnimation.CrossFade(this.RandomCheerAnim);
				if (this.CharacterAnimation[this.RandomCheerAnim].time >= this.CharacterAnimation[this.RandomCheerAnim].length)
				{
					this.RandomCheerAnim = this.CheerAnims[UnityEngine.Random.Range(0, this.CheerAnims.Length)];
				}
				this.ThreatPhase = 3;
				this.ThreatTimer = 0f;
				if (this.WitnessedMurder)
				{
					this.Injured = true;
					return;
				}
			}
			else if (!this.Injured)
			{
				if (this.DistanceToPlayer > 5f + this.ThreatDistance && this.ThreatPhase < 4)
				{
					this.ThreatPhase = 3;
					this.ThreatTimer = 0f;
				}
				if (!this.Yandere.Shoved && !this.Yandere.Dumping && !this.Yandere.SneakingShot)
				{
					if (this.DistanceToPlayer > 1f && this.Patience > 0)
					{
						if (this.ThreatPhase == 1)
						{
							this.CharacterAnimation.CrossFade("delinquentShock_00");
							if (this.CharacterAnimation["delinquentShock_00"].time >= this.CharacterAnimation["delinquentShock_00"].length)
							{
								this.Subtitle.Speaker = this;
								this.Subtitle.UpdateLabel(SubtitleType.DelinquentThreatened, 0, 3f);
								this.CharacterAnimation.CrossFade("delinquentCombatIdle_00");
								this.ThreatTimer = 5f;
								this.ThreatPhase++;
								return;
							}
						}
						else if (this.ThreatPhase == 2)
						{
							this.ThreatTimer -= Time.deltaTime;
							if (this.ThreatTimer < 0f)
							{
								this.Subtitle.Speaker = this;
								this.Subtitle.UpdateLabel(SubtitleType.DelinquentTaunt, 0, 5f);
								this.ThreatTimer = 5f;
								this.ThreatPhase++;
								return;
							}
						}
						else if (this.ThreatPhase == 3)
						{
							this.ThreatTimer -= Time.deltaTime;
							if (this.ThreatTimer < 0f)
							{
								if (!this.NoTalk)
								{
									this.Subtitle.Speaker = this;
									this.Subtitle.UpdateLabel(SubtitleType.DelinquentCalm, 0, 5f);
								}
								this.CharacterAnimation.CrossFade(this.IdleAnim, 5f);
								this.ThreatTimer = 5f;
								this.ThreatPhase++;
								return;
							}
						}
						else if (this.ThreatPhase == 4)
						{
							this.ThreatTimer -= Time.deltaTime;
							if (this.ThreatTimer < 0f)
							{
								if (this.CurrentDestination != this.Destinations[this.Phase])
								{
									this.StopInvestigating();
								}
								this.Distracted = false;
								this.Threatened = false;
								this.Alarmed = false;
								this.Routine = true;
								this.NoTalk = false;
								this.IgnoreTimer = 5f;
								this.AlarmTimer = 0f;
								return;
							}
						}
					}
					else if (!this.NoTalk)
					{
						Debug.Log("The combat minigame is now beginning.");
						string str = "";
						if (!this.Male)
						{
							str = "Female_";
						}
						if (this.StudentID == 46)
						{
							this.CharacterAnimation.CrossFade("delinquentDrawWeapon_00");
						}
						if (this.StudentManager.CombatMinigame.Delinquent == null)
						{
							this.Yandere.CharacterAnimation.CrossFade("Yandere_CombatIdle");
							if (this.MyWeapon.transform.parent != this.ItemParent)
							{
								string str2 = "The game is trying to tell ";
								StudentScript delinquent = this.StudentManager.CombatMinigame.Delinquent;
								Debug.Log(str2 + ((delinquent != null) ? delinquent.ToString() : null) + "to draw out a weapon.");
								this.CharacterAnimation.CrossFade(str + "delinquentDrawWeapon_00");
							}
							else
							{
								this.CharacterAnimation.CrossFade("delinquentCombatIdle_00");
							}
							if ((this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed))
							{
								this.Yandere.EmptyHands();
							}
							if (this.Yandere.Pickpocketing)
							{
								this.Yandere.Caught = true;
								this.PickPocket.PickpocketMinigame.End();
							}
							this.Yandere.StopLaughing();
							this.Yandere.StopAiming();
							this.Yandere.Unequip();
							if (this.Yandere.YandereVision)
							{
								this.Yandere.YandereVision = false;
								this.Yandere.ResetYandereEffects();
							}
							if (this.Yandere.PickUp != null)
							{
								this.Yandere.EmptyHands();
							}
							this.Yandere.DelinquentFighting = true;
							this.Yandere.NearSenpai = false;
							this.Yandere.Degloving = false;
							this.Yandere.CanMove = false;
							this.Yandere.GloveTimer = 0f;
							this.Distracted = true;
							this.Fighting = true;
							this.ThreatTimer = 0f;
							this.StudentManager.CombatMinigame.Delinquent = this;
							this.StudentManager.CombatMinigame.enabled = true;
							this.StudentManager.CombatMinigame.StartCombat();
							this.SpeechLines.Stop();
							this.SpawnAlarmDisc();
							if (this.WitnessedMurder || this.WitnessedCorpse)
							{
								this.Subtitle.Speaker = this;
								this.Subtitle.UpdateLabel(SubtitleType.DelinquentAvenge, 0, 5f);
							}
							else if (!this.StudentManager.CombatMinigame.Practice)
							{
								this.Subtitle.Speaker = this;
								this.Subtitle.UpdateLabel(SubtitleType.DelinquentFight, 0, 5f);
							}
						}
						this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
						if (this.CharacterAnimation[str + "delinquentDrawWeapon_00"].time >= 0.5f)
						{
							this.MyWeapon.transform.parent = this.ItemParent;
							this.MyWeapon.transform.localEulerAngles = new Vector3(0f, 15f, 0f);
							this.MyWeapon.transform.localPosition = new Vector3(0.01f, 0f, 0f);
						}
						if (this.CharacterAnimation[str + "delinquentDrawWeapon_00"].time >= this.CharacterAnimation[str + "delinquentDrawWeapon_00"].length)
						{
							this.Threatened = false;
							this.Alarmed = false;
							base.enabled = false;
							return;
						}
					}
					else
					{
						this.ThreatTimer -= Time.deltaTime;
						if (this.ThreatTimer < 0f)
						{
							if (this.CurrentDestination != this.Destinations[this.Phase])
							{
								this.StopInvestigating();
							}
							this.Distracted = false;
							this.Threatened = false;
							this.Alarmed = false;
							this.Routine = true;
							this.NoTalk = false;
							this.IgnoreTimer = 5f;
							this.AlarmTimer = 0f;
							return;
						}
					}
				}
			}
			else
			{
				this.ThreatTimer += Time.deltaTime;
				if (this.ThreatTimer > 5f)
				{
					this.DistanceToDestination = 100f;
					if (this.Yandere.CanMove)
					{
						if (!this.WitnessedMurder && !this.WitnessedCorpse)
						{
							this.Distracted = false;
							this.Threatened = false;
							this.EndAlarm();
							return;
						}
						this.Threatened = false;
						this.Alarmed = false;
						this.Injured = false;
						this.PersonaReaction();
					}
				}
			}
		}
	}

	// Token: 0x06001E2C RID: 7724 RVA: 0x00193840 File Offset: 0x00191A40
	private void UpdateBurning()
	{
		if (this.DistanceToPlayer < 1f && !this.Yandere.Shoved && !this.Yandere.Egg)
		{
			if (this.Yandere.PickUp != null && this.Yandere.PickUp.OpenFlame)
			{
				this.Yandere.PotentiallyMurderousTimer = 1f;
			}
			this.PushYandereAway();
		}
		if (this.BurnTarget != Vector3.zero)
		{
			this.MoveTowardsTarget(this.BurnTarget);
		}
		if (this.CharacterAnimation[this.BurningAnim].time > this.CharacterAnimation[this.BurningAnim].length)
		{
			this.DeathType = DeathType.Burning;
			this.BecomeRagdoll();
		}
	}

	// Token: 0x06001E2D RID: 7725 RVA: 0x00193908 File Offset: 0x00191B08
	private void UpdateSplashed()
	{
		this.CharacterAnimation.CrossFade(this.SplashedAnim);
		if (this.Yandere.Tripping)
		{
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
		}
		this.SplashTimer += Time.deltaTime;
		if (this.SplashTimer > 2f && this.SplashPhase == 1)
		{
			if (this.Gas)
			{
				this.Subtitle.Speaker = this;
				this.Subtitle.UpdateLabel(this.SplashSubtitleType, 5, 5f);
			}
			else if (this.DyedBrown)
			{
				this.Subtitle.Speaker = this;
				this.Subtitle.UpdateLabel(this.SplashSubtitleType, 7, 5f);
			}
			else if (this.Bloody)
			{
				this.Subtitle.Speaker = this;
				this.Subtitle.UpdateLabel(this.SplashSubtitleType, 3, 5f);
			}
			else
			{
				this.Subtitle.Speaker = this;
				this.Subtitle.UpdateLabel(this.SplashSubtitleType, 1, 5f);
			}
			this.CharacterAnimation[this.SplashedAnim].speed = 0.5f;
			this.SplashPhase++;
		}
		if (this.SplashTimer > 12f && this.SplashPhase == 2)
		{
			if (this.LightSwitch == null)
			{
				if (this.Gas)
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(this.SplashSubtitleType, 6, 5f);
				}
				else if (this.Bloody)
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(this.SplashSubtitleType, 4, 5f);
				}
				else
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(this.SplashSubtitleType, 2, 5f);
				}
				this.SplashPhase++;
				if (!this.Male)
				{
					this.CurrentDestination = this.StudentManager.StrippingPositions[this.GirlID];
					this.Pathfinding.target = this.StudentManager.StrippingPositions[this.GirlID];
				}
				else
				{
					this.CurrentDestination = this.StudentManager.MaleStripSpot;
					this.Pathfinding.target = this.StudentManager.MaleStripSpot;
				}
			}
			else if (!this.LightSwitch.BathroomLight.activeInHierarchy)
			{
				if (this.LightSwitch.Panel.useGravity)
				{
					this.LightSwitch.Prompt.Hide();
					this.LightSwitch.Prompt.enabled = false;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
				this.Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 1, 5f);
				this.CurrentDestination = this.LightSwitch.ElectrocutionSpot;
				this.Pathfinding.target = this.LightSwitch.ElectrocutionSpot;
				this.Pathfinding.speed = this.WalkSpeed;
				this.BathePhase = -1;
				this.InDarkness = true;
			}
			else
			{
				if (!this.Bloody)
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(this.SplashSubtitleType, 2, 5f);
				}
				else
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(this.SplashSubtitleType, 4, 5f);
				}
				this.SplashPhase++;
				this.CurrentDestination = this.StudentManager.StrippingPositions[this.GirlID];
				this.Pathfinding.target = this.StudentManager.StrippingPositions[this.GirlID];
			}
			Debug.Log("Student is now running towards the locker room.");
			this.CharacterAnimation[this.WetAnim].weight = 1f;
			this.Pathfinding.canSearch = true;
			this.Pathfinding.canMove = true;
			this.Splashed = false;
		}
	}

	// Token: 0x06001E2E RID: 7726 RVA: 0x00193D84 File Offset: 0x00191F84
	private void UpdateTurningOffRadio()
	{
		if (this.Radio.On || (this.RadioPhase == 3 && this.Radio.transform.parent == null))
		{
			if (this.RadioPhase == 1)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, base.transform.position.y, this.Radio.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				this.RadioTimer += Time.deltaTime;
				if (this.RadioTimer > 3f)
				{
					if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
					{
						this.SmartPhone.SetActive(true);
					}
					if (this.Persona == PersonaType.Protective)
					{
						this.CharacterAnimation.CrossFade(this.RunAnim);
						this.Pathfinding.speed = 4f;
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
					}
					this.CurrentDestination = this.Radio.transform;
					this.Pathfinding.target = this.Radio.transform;
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.RadioTimer = 0f;
					this.RadioPhase++;
					return;
				}
			}
			else if (this.RadioPhase == 2)
			{
				if (Vector3.Distance(base.transform.position, new Vector3(this.Radio.transform.position.x, base.transform.position.y, this.Radio.transform.position.z)) < 0.5f)
				{
					this.CharacterAnimation.CrossFade(this.RadioAnim);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.SmartPhone.SetActive(false);
					this.RadioPhase++;
					return;
				}
			}
			else if (this.RadioPhase == 3)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, base.transform.position.y, this.Radio.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				this.RadioTimer += Time.deltaTime;
				if (this.RadioTimer > 4f)
				{
					if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
					{
						this.SmartPhone.SetActive(true);
					}
					this.CurrentDestination = this.Destinations[this.Phase];
					this.Pathfinding.target = this.Destinations[this.Phase];
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.ForgetRadio();
					return;
				}
				if (this.RadioTimer > 2f)
				{
					this.Radio.Victim = null;
					this.Radio.TurnOff();
					return;
				}
			}
		}
		else
		{
			if (this.RadioPhase < 100)
			{
				this.CharacterAnimation.CrossFade(this.IdleAnim);
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
				this.RadioPhase = 100;
				this.RadioTimer = 0f;
			}
			this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, base.transform.position.y, this.Radio.transform.position.z) - base.transform.position);
			this.RadioTimer += Time.deltaTime;
			if (this.RadioTimer > 1f || this.Radio.transform.parent != null)
			{
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.Destinations[this.Phase];
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.ForgetRadio();
			}
		}
	}

	// Token: 0x06001E2F RID: 7727 RVA: 0x00194238 File Offset: 0x00192438
	private void UpdateVomiting()
	{
		if (this.VomitPhase != 0 && this.VomitPhase != 4)
		{
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
			this.MoveTowardsTarget(this.CurrentDestination.position);
		}
		if (this.VomitPhase == 0)
		{
			if (this.DistanceToDestination < 0.5f)
			{
				if (!this.Yandere.Armed && this.Yandere.PickUp == null)
				{
					this.Drownable = true;
					this.StudentManager.UpdateMe(this.StudentID);
				}
				if (this.VomitDoor != null)
				{
					this.VomitDoor.Prompt.enabled = false;
					this.VomitDoor.Prompt.Hide();
					this.VomitDoor.enabled = false;
				}
				this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.CharacterAnimation.CrossFade(this.VomitAnim);
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
				this.VomitPhase++;
				return;
			}
		}
		else if (this.VomitPhase == 1)
		{
			if (this.CharacterAnimation[this.VomitAnim].time > 1f)
			{
				this.VomitEmitter.gameObject.SetActive(true);
				this.VomitPhase++;
				return;
			}
		}
		else if (this.VomitPhase == 2)
		{
			if (this.CharacterAnimation[this.VomitAnim].time > 13f)
			{
				this.VomitEmitter.gameObject.SetActive(false);
				this.VomitPhase++;
				return;
			}
		}
		else if (this.VomitPhase == 3)
		{
			if (this.CharacterAnimation[this.VomitAnim].time >= this.CharacterAnimation[this.VomitAnim].length)
			{
				this.Drownable = false;
				this.StudentManager.UpdateMe(this.StudentID);
				this.WalkAnim = this.OriginalWalkAnim;
				this.CharacterAnimation.CrossFade(this.WalkAnim);
				if (this.Male)
				{
					this.StudentManager.GetMaleWashSpot(this);
					this.Pathfinding.target = this.StudentManager.MaleWashSpot;
					this.CurrentDestination = this.StudentManager.MaleWashSpot;
				}
				else
				{
					this.StudentManager.GetFemaleWashSpot(this);
					this.Pathfinding.target = this.StudentManager.FemaleWashSpot;
					this.CurrentDestination = this.StudentManager.FemaleWashSpot;
				}
				if (this.VomitDoor != null)
				{
					this.VomitDoor.Prompt.enabled = true;
					this.VomitDoor.enabled = true;
				}
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Pathfinding.speed = this.WalkSpeed;
				this.DistanceToDestination = 100f;
				this.VomitPhase++;
				return;
			}
		}
		else if (this.VomitPhase == 4)
		{
			if (this.DistanceToDestination < 0.5f)
			{
				this.CharacterAnimation.CrossFade(this.WashFaceAnim);
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
				this.VomitPhase++;
				return;
			}
		}
		else if (this.VomitPhase == 5 && this.CharacterAnimation[this.WashFaceAnim].time > this.CharacterAnimation[this.WashFaceAnim].length)
		{
			this.StopVomitting();
			ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase + 1];
			scheduleBlock.destination = "Seat";
			scheduleBlock.action = "Sit";
			this.GetDestinations();
			this.Phase++;
			this.Pathfinding.target = this.Destinations[this.Phase];
			this.CurrentDestination = this.Destinations[this.Phase];
			this.CurrentAction = StudentActionType.SitAndTakeNotes;
			this.DistanceToDestination = 100f;
		}
	}

	// Token: 0x06001E30 RID: 7728 RVA: 0x00194654 File Offset: 0x00192854
	private void StopVomitting()
	{
		this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.VomitEmitter.gameObject.SetActive(false);
		this.Prompt.Label[0].text = "     Talk";
		this.Pathfinding.canSearch = true;
		this.Pathfinding.canMove = true;
		this.Distracted = false;
		this.Drownable = false;
		this.Vomiting = false;
		this.Private = false;
		this.CanTalk = true;
		this.Routine = true;
		this.Emetic = false;
		this.VomitPhase = 0;
		this.StudentManager.UpdateMe(this.StudentID);
		this.WalkAnim = this.OriginalWalkAnim;
	}

	// Token: 0x06001E31 RID: 7729 RVA: 0x00194704 File Offset: 0x00192904
	private void UpdateConfessing()
	{
		if (!this.Male)
		{
			if (this.ConfessPhase == 1)
			{
				if (this.DistanceToDestination < 0.5f)
				{
					this.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
					this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.CharacterAnimation.CrossFade("f02_insertNote_00");
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.Note.SetActive(true);
					this.ConfessPhase++;
					return;
				}
			}
			else if (this.ConfessPhase == 2)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.CurrentDestination.position);
				if (this.CharacterAnimation["f02_insertNote_00"].time >= 9f)
				{
					this.Note.SetActive(false);
					this.ConfessPhase++;
					return;
				}
			}
			else if (this.ConfessPhase == 3)
			{
				if (this.CharacterAnimation["f02_insertNote_00"].time >= this.CharacterAnimation["f02_insertNote_00"].length)
				{
					this.CurrentDestination = this.StudentManager.RivalConfessionSpot;
					this.Pathfinding.target = this.StudentManager.RivalConfessionSpot;
					this.Pathfinding.canSearch = true;
					this.Pathfinding.canMove = true;
					this.Pathfinding.speed = 4f;
					this.StudentManager.LoveManager.LeftNote = true;
					this.CharacterAnimation.CrossFade(this.SprintAnim);
					this.ConfessPhase++;
					return;
				}
			}
			else if (this.ConfessPhase == 4)
			{
				if (this.DistanceToDestination < 0.5f)
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.ConfessPhase++;
					return;
				}
			}
			else if (this.ConfessPhase == 5)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
				this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 1f, Time.deltaTime);
				this.MoveTowardsTarget(this.CurrentDestination.position);
				return;
			}
		}
		else if (this.ConfessPhase == 1)
		{
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
			this.MoveTowardsTarget(this.CurrentDestination.position);
			if (this.CharacterAnimation["keepNote_00"].time > 14f)
			{
				this.Note.SetActive(false);
			}
			else if ((double)this.CharacterAnimation["keepNote_00"].time > 4.5)
			{
				this.Note.SetActive(true);
			}
			if (this.CharacterAnimation["keepNote_00"].time >= this.CharacterAnimation["keepNote_00"].length)
			{
				this.CurrentDestination = this.StudentManager.SuitorConfessionSpot;
				this.Pathfinding.target = this.StudentManager.SuitorConfessionSpot;
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Pathfinding.speed = 4f;
				this.Note.SetActive(false);
				this.CharacterAnimation.CrossFade(this.SprintAnim);
				this.ConfessPhase++;
				return;
			}
		}
		else if (this.ConfessPhase == 2)
		{
			if (this.DistanceToDestination < 0.5f)
			{
				this.CharacterAnimation.CrossFade("exhausted_00");
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
				this.ConfessPhase++;
				return;
			}
		}
		else if (this.ConfessPhase == 3)
		{
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
			this.MoveTowardsTarget(this.CurrentDestination.position);
		}
	}

	// Token: 0x06001E32 RID: 7730 RVA: 0x00194BB0 File Offset: 0x00192DB0
	private void UpdateMisc()
	{
		if (this.IgnoreTimer > 0f)
		{
			this.IgnoreTimer = Mathf.MoveTowards(this.IgnoreTimer, 0f, Time.deltaTime);
		}
		if (!this.Fleeing)
		{
			if (base.transform.position.z < -100f)
			{
				if (base.transform.position.y < -10f && this.StudentID > 1)
				{
					base.gameObject.SetActive(false);
					return;
				}
			}
			else
			{
				if (base.transform.position.y < -0.1f)
				{
					base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
				}
				if (!this.Dying && !this.Distracted && !this.WalkBack && !this.Waiting && !this.Guarding && !this.WitnessedMurder && !this.WitnessedCorpse && !this.Blind && !this.SentHome && !this.TurnOffRadio && !this.Wet && !this.InvestigatingBloodPool && !this.ReturningMisplacedWeapon && !this.Yandere.Egg && !this.StudentManager.Pose && !this.ShoeRemoval.enabled && !this.Drownable)
				{
					if (this.StudentManager.MissionMode && (double)this.DistanceToPlayer < 0.5)
					{
						Debug.Log("This student cannot be interacted with right now.");
						this.Yandere.Shutter.FaceStudent = this;
						this.Yandere.Shutter.Penalize();
					}
					if (this.Club == ClubType.Council && !this.WitnessedSomething)
					{
						if (this.DistanceToPlayer < 5f)
						{
							if (this.DistanceToPlayer < 2f)
							{
								this.StudentManager.TutorialWindow.ShowCouncilMessage = true;
							}
							if (Mathf.Abs(Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position)) <= 45f && this.Yandere.Stance.Current != StanceType.Crouching && this.Yandere.Stance.Current != StanceType.Crawling && this.Yandere.CanMove && (this.Yandere.h != 0f || this.Yandere.v != 0f) && (this.Yandere.Running || this.DistanceToPlayer < 2f))
							{
								if (this.Investigating)
								{
									this.StopInvestigating();
								}
								Debug.Log(this.Name + " was alarmed because Yandere-chan was running nearby.");
								this.DistractionSpot = this.Yandere.transform.position;
								this.Alarm = 200f;
								this.TemporarilyBlind = true;
								this.FocusOnYandere = true;
								this.Routine = false;
								this.Pathfinding.canSearch = false;
								this.Pathfinding.canMove = false;
							}
						}
						if (this.DistanceToPlayer < 1.1f && !this.Yandere.Invisible && Mathf.Abs(Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position)) > 45f && (this.Yandere.Armed || (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed)) && this.Prompt.InSight)
						{
							if (this.Yandere.Armed && !this.Yandere.EquippedWeapon.Suspicious && !this.WitnessedMurder)
							{
								this.Shove();
							}
							else
							{
								this.Spray();
							}
						}
					}
					if (((this.Club == ClubType.Council && !this.Spraying) || (this.Club == ClubType.Delinquent && !this.Injured && !this.RespectEarned && !this.Vomiting && !this.Emetic && !this.Headache && !this.Sedated && !this.Lethal)) && (double)this.DistanceToPlayer < 0.5 && this.Yandere.CanMove && (this.Yandere.h != 0f || this.Yandere.v != 0f))
					{
						if (this.Club == ClubType.Delinquent)
						{
							this.Subtitle.Speaker = this;
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentShove, 0, 3f);
						}
						this.Shove();
						return;
					}
				}
			}
		}
		else if (this.Club == ClubType.Council && this.DistanceToPlayer < 1.1f && !this.Yandere.Invisible && Mathf.Abs(Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position)) > 45f && (this.Yandere.Armed || (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed)) && this.Prompt.InSight)
		{
			if (this.Yandere.Armed && !this.Yandere.EquippedWeapon.Suspicious && !this.WitnessedMurder)
			{
				this.Shove();
				return;
			}
			this.Spray();
		}
	}

	// Token: 0x06001E33 RID: 7731 RVA: 0x001951E8 File Offset: 0x001933E8
	private void LateUpdate()
	{
		if (this.StudentManager.DisableFarAnims && this.DistanceToPlayer >= (float)this.StudentManager.FarAnimThreshold && this.CharacterAnimation.cullingType != AnimationCullingType.AlwaysAnimate && !this.WitnessCamera.Show)
		{
			this.CharacterAnimation.enabled = false;
		}
		else
		{
			this.CharacterAnimation.enabled = true;
		}
		if (this.EyeShrink > 0f)
		{
			if (this.EyeShrink > 1f)
			{
				this.EyeShrink = 1f;
			}
			this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
			this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
			this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
			this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
			this.PreviousEyeShrink = this.EyeShrink;
		}
		if (!this.Male)
		{
			if (this.Shy)
			{
				if (this.Routine)
				{
					if ((this.Phase == 2 && this.DistanceToDestination < 1f) || (this.Phase == 4 && this.DistanceToDestination < 1f) || (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes && this.DistanceToDestination < 1f) || (this.Actions[this.Phase] == StudentActionType.Clean && this.DistanceToDestination < 1f) || (this.Actions[this.Phase] == StudentActionType.Read && this.DistanceToDestination < 1f))
					{
						this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 0f, Time.deltaTime);
					}
					else
					{
						this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 1f, Time.deltaTime);
					}
				}
				else if (!this.Headache)
				{
					this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 0f, Time.deltaTime);
				}
			}
			if (!this.BoobsResized)
			{
				this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
				this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
				if (!this.Cosmetic.CustomEyes)
				{
					this.RightBreast.gameObject.name = "RightBreastRENAMED";
					this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
				}
				this.BoobsResized = true;
			}
			if (this.Following)
			{
				if (this.Gush)
				{
					this.Neck.LookAt(this.GushTarget);
				}
				else
				{
					this.Neck.LookAt(this.DefaultTarget);
				}
			}
			if (this.StudentManager.Egg && this.SecurityCamera.activeInHierarchy)
			{
				this.Head.localScale = new Vector3(0f, 0f, 0f);
			}
			if (!this.Slave && this.Club == ClubType.Bully)
			{
				for (int i = 0; i < 4; i++)
				{
					if (this.Skirt[i] != null)
					{
						Transform transform = this.Skirt[i].transform;
						transform.localScale = new Vector3(transform.localScale.x, 0.6666667f, transform.localScale.z);
					}
				}
			}
			if (this.LongHair[0] != null && this.MyBento.gameObject.activeInHierarchy && this.MyBento.transform.parent != null)
			{
				this.LongHair[0].eulerAngles = new Vector3(this.Spine.eulerAngles.x, this.Spine.eulerAngles.y, this.Spine.eulerAngles.z);
				this.LongHair[0].RotateAround(this.LongHair[0].position, base.transform.right, 180f);
				if (this.LongHair[1] != null)
				{
					this.LongHair[1].eulerAngles = new Vector3(this.Spine.eulerAngles.x, this.Spine.eulerAngles.y, this.Spine.eulerAngles.z);
					this.LongHair[1].RotateAround(this.LongHair[1].position, base.transform.right, 180f);
				}
			}
		}
		if (this.Club == ClubType.Photography || this.ClubActivity || this.Actions[this.Phase] == StudentActionType.Meeting)
		{
			if (this.Routine && !this.InEvent && !this.Meeting && !this.GoAway)
			{
				if (!this.StudentManager.Eighties)
				{
					if ((this.DistanceToDestination < this.TargetDistance && this.Actions[this.Phase] == StudentActionType.SitAndSocialize) || (this.DistanceToDestination < this.TargetDistance && this.StudentID != 36 && this.Actions[this.Phase] == StudentActionType.Meeting) || (this.DistanceToDestination < this.TargetDistance && this.Actions[this.Phase] == StudentActionType.Sleuth && this.StudentManager.SleuthPhase != 2 && this.StudentManager.SleuthPhase != 3) || (this.Club == ClubType.Photography && this.ClubActivity))
					{
						this.BlendIntoSittingAnim();
					}
					else
					{
						this.BlendOutOfSittingAnim();
					}
				}
				else if (this.DistanceToDestination < this.TargetDistance && this.StudentID != 36 && this.CurrentAction == StudentActionType.Meeting)
				{
					this.BlendIntoSittingAnim();
				}
				else
				{
					this.BlendOutOfSittingAnim();
				}
			}
			else
			{
				this.BlendOutOfSittingAnim();
			}
		}
		if (this.DK)
		{
			this.Arm[0].localScale = new Vector3(2f, 2f, 2f);
			this.Arm[1].localScale = new Vector3(2f, 2f, 2f);
			this.Head.localScale = new Vector3(2f, 2f, 2f);
		}
		if (this.Fate > 0 && this.Clock.HourTime > this.TimeOfDeath)
		{
			this.Yandere.TargetStudent = this;
			this.StudentManager.Shinigami.Effect = this.Fate - 1;
			this.StudentManager.Shinigami.Attack();
			this.Yandere.TargetStudent = null;
			this.Fate = 0;
		}
		if (this.Yandere.BlackHole && this.DistanceToPlayer < 2.5f)
		{
			if (this.DeathScream != null)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.DeathScream, base.transform.position + Vector3.up, Quaternion.identity);
			}
			this.BlackHoleEffect[0].enabled = true;
			this.BlackHoleEffect[1].enabled = true;
			this.BlackHoleEffect[2].enabled = true;
			this.CharacterAnimation[this.WetAnim].weight = 0f;
			this.DeathType = DeathType.EasterEgg;
			this.CharacterAnimation.Stop();
			this.Suck.enabled = true;
			this.BecomeRagdoll();
			this.Dying = true;
		}
		if (this.CameraReacting && (this.StudentManager.NEStairs.bounds.Contains(base.transform.position) || this.StudentManager.NWStairs.bounds.Contains(base.transform.position) || this.StudentManager.SEStairs.bounds.Contains(base.transform.position) || this.StudentManager.SWStairs.bounds.Contains(base.transform.position)) && this.Spine != null)
		{
			this.Spine.LookAt(this.Yandere.Spine[0]);
			this.Head.LookAt(this.Yandere.Head);
		}
		if (this.DistanceToPlayer < 0.5f && !this.CameraReacting && !this.Struggling && !this.Yandere.Attacking && !this.Distracted && !this.Posing && this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition))
		{
			this.PersonalSpaceTimer += Time.deltaTime;
			if (this.PersonalSpaceTimer > 4f)
			{
				this.Yandere.Shutter.FaceStudent = this;
				this.Yandere.Shutter.Penalize();
			}
		}
	}

	// Token: 0x06001E34 RID: 7732 RVA: 0x00195BCC File Offset: 0x00193DCC
	public void CalculateReputationPenalty()
	{
		if ((this.Male && this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 2) || this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 4)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		if (PlayerGlobals.Reputation < -33.33333f)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		if (PlayerGlobals.Reputation > 33.33333f)
		{
			this.RepDeduction -= this.RepLoss * 0.2f;
		}
		if (this.Friend)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		if (PlayerGlobals.PantiesEquipped == 1)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		if (this.Yandere.Class.SocialBonus > 0)
		{
			this.RepDeduction += this.RepLoss * 0.2f;
		}
		this.ChameleonCheck();
		if (this.Chameleon)
		{
			Debug.Log("Chopping reputation loss in half!");
			this.RepLoss *= 0.5f;
		}
		if (this.Yandere.Persona == YanderePersonaType.Aggressive)
		{
			this.RepLoss *= 2f;
		}
		if (this.Club == ClubType.Bully)
		{
			this.RepLoss *= 2f;
		}
		if (this.Club == ClubType.Delinquent)
		{
			this.RepDeduction = 0f;
			this.RepLoss = 0f;
		}
	}

	// Token: 0x06001E35 RID: 7733 RVA: 0x00195D84 File Offset: 0x00193F84
	public void MoveTowardsTarget(Vector3 target)
	{
		if (Time.timeScale > 0.0001f && this.MyController.enabled)
		{
			Vector3 a = target - base.transform.position;
			if (a.sqrMagnitude > 1E-06f)
			{
				this.MyController.Move(a * (Time.deltaTime * 5f / Time.timeScale));
			}
		}
	}

	// Token: 0x06001E36 RID: 7734 RVA: 0x00195DED File Offset: 0x00193FED
	private void LookTowardsTarget(Vector3 target)
	{
		float timeScale = Time.timeScale;
	}

	// Token: 0x06001E37 RID: 7735 RVA: 0x00195DFC File Offset: 0x00193FFC
	public void AttackReaction()
	{
		Debug.Log(this.Name + " is being attacked.");
		if (this.SolvingPuzzle)
		{
			this.DropPuzzle();
		}
		if (this.HorudaCollider != null)
		{
			this.HorudaCollider.gameObject.SetActive(false);
		}
		this.BountyCollider.SetActive(false);
		if (this.PhotoEvidence)
		{
			this.SmartPhone.GetComponent<SmartphoneScript>().enabled = true;
			this.SmartPhone.GetComponent<PromptScript>().enabled = true;
			this.SmartPhone.GetComponent<Rigidbody>().useGravity = true;
			this.SmartPhone.GetComponent<Collider>().enabled = true;
			this.SmartPhone.transform.parent = null;
			this.SmartPhone.layer = 15;
		}
		else
		{
			this.SmartPhone.SetActive(false);
		}
		if (!this.WitnessedMurder)
		{
			float f = Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position);
			this.Yandere.AttackManager.Stealth = (Mathf.Abs(f) <= 45f);
		}
		if (this.ReturningMisplacedWeapon)
		{
			Debug.Log(this.Name + " was in the process of returning a weapon when they were attacked.");
			this.DropMisplacedWeapon();
		}
		if (this.BloodPool != null)
		{
			Debug.Log(this.Name + "'s BloodPool was not null.");
			if (this.BloodPool.GetComponent<WeaponScript>() != null && this.BloodPool.GetComponent<WeaponScript>().Returner == this)
			{
				this.BloodPool.GetComponent<WeaponScript>().Returner = null;
				this.BloodPool.GetComponent<WeaponScript>().Drop();
				this.BloodPool.GetComponent<WeaponScript>().enabled = true;
				this.BloodPool = null;
			}
		}
		if (this.Yandere.Armed && this.Yandere.EquippedWeapon.WeaponID == 27)
		{
			this.StudentManager.TranqDetector.GarroteAttack();
		}
		if (!this.Male)
		{
			if (this.Club != ClubType.Council)
			{
				this.StudentManager.TranqDetector.TranqCheck();
			}
			this.CharacterAnimation["f02_smile_00"].weight = 0f;
			this.SmartPhone.SetActive(false);
			if (this.CharacterAnimation[this.ShyAnim] != null)
			{
				this.CharacterAnimation[this.ShyAnim].weight = 0f;
			}
			this.Shy = false;
		}
		this.WitnessCamera.Show = false;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Yandere.CharacterAnimation["f02_idleShort_00"].time = 0f;
		this.Yandere.CharacterAnimation["f02_swingA_00"].time = 0f;
		this.CharacterAnimation[this.WetAnim].weight = 0f;
		this.Yandere.HipCollider.enabled = true;
		this.Yandere.TargetStudent = this;
		this.Yandere.YandereVision = false;
		this.Yandere.Attacking = true;
		this.Yandere.CanMove = false;
		if (this.Yandere.Equipped > 0 && this.Yandere.EquippedWeapon.AnimID == 2)
		{
			this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[2]].weight = 0f;
		}
		if (this.DetectionMarker != null)
		{
			this.DetectionMarker.Tex.enabled = false;
		}
		this.EmptyHands();
		this.DropPlate();
		this.MyController.radius = 0f;
		if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
		{
			this.Countdown.gameObject.SetActive(false);
			this.ChaseCamera.SetActive(false);
			if (this.StudentManager.ChaseCamera == this.ChaseCamera)
			{
				this.StudentManager.ChaseCamera = null;
			}
		}
		this.VomitEmitter.gameObject.SetActive(false);
		this.InvestigatingBloodPool = false;
		this.SeekingMedicine = false;
		this.Investigating = false;
		this.Pen.SetActive(false);
		this.EatingSnack = false;
		this.SpeechLines.Stop();
		this.Attacked = true;
		this.Alarmed = false;
		this.Fleeing = false;
		this.Routine = false;
		this.ReadPhase = 0;
		this.Dying = true;
		this.Wet = false;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		if (this.Following)
		{
			Debug.Log("Yandere-chan's follower is being set to ''null''.");
			this.Hearts.emission.enabled = false;
			this.FollowCountdown.gameObject.SetActive(false);
			this.Yandere.Follower = null;
			this.Yandere.Followers--;
			this.Following = false;
		}
		if (this.Distracting || (this.DistractionTarget != null && this.DistractionTarget.Distracted))
		{
			Debug.Log(string.Concat(new string[]
			{
				"At the time of being attacked, ",
				this.Name,
				" was distracting ",
				this.DistractionTarget.Name,
				"."
			}));
			this.DistractionTarget.TargetedForDistraction = false;
			this.DistractionTarget.Octodog.SetActive(false);
			this.DistractionTarget.Distracted = false;
			this.Distracting = false;
		}
		if (this.Teacher)
		{
			if ((this.Yandere.Armed && this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus > 0 && this.Yandere.EquippedWeapon.Type == WeaponType.Knife) || (this.Yandere.Club == ClubType.MartialArts && this.Yandere.Armed && this.Yandere.EquippedWeapon.Type == WeaponType.Knife))
			{
				Debug.Log(this.Name + " has called the ''BeginStruggle'' function.");
				this.Pathfinding.target = this.Yandere.transform;
				this.CurrentDestination = this.Yandere.transform;
				this.Yandere.Attacking = false;
				this.Attacked = false;
				this.Fleeing = true;
				this.Dying = false;
				this.Persona = PersonaType.Heroic;
				this.BeginStruggle();
			}
			else
			{
				Debug.Log(this.Name + " just countered Yandere-chan.");
				this.Yandere.HeartRate.gameObject.SetActive(false);
				this.Yandere.ShoulderCamera.Counter = true;
				this.Yandere.ShoulderCamera.OverShoulder = false;
				this.Yandere.RPGCamera.enabled = false;
				this.Yandere.Senpai = base.transform;
				this.Yandere.Attacking = true;
				this.Yandere.CanMove = false;
				this.Yandere.Talking = false;
				this.Yandere.Noticed = true;
				this.Yandere.HUD.alpha = 0f;
			}
		}
		else if (this.Strength == 9 && !this.Emetic && !this.Lethal && !this.Sedated && !this.Headache)
		{
			if (!this.WitnessedMurder)
			{
				this.Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 3, 11f);
			}
			this.Yandere.CharacterAnimation.CrossFade("f02_moCounterA_00");
			this.Yandere.HeartRate.gameObject.SetActive(false);
			this.Yandere.ShoulderCamera.ObstacleCounter = true;
			this.Yandere.ShoulderCamera.OverShoulder = false;
			this.Yandere.RPGCamera.enabled = false;
			this.Yandere.Senpai = base.transform;
			this.Yandere.Attacking = true;
			this.Yandere.CanMove = false;
			this.Yandere.Talking = false;
			this.Yandere.Noticed = true;
			this.Yandere.HUD.alpha = 0f;
		}
		else
		{
			if (!this.Yandere.AttackManager.Stealth)
			{
				this.Subtitle.UpdateLabel(SubtitleType.Dying, 0, 1f);
				this.SpawnAlarmDisc();
			}
			if (this.Yandere.SanityBased)
			{
				this.Yandere.AttackManager.Attack(this.Character, this.Yandere.EquippedWeapon);
			}
		}
		if (this.StudentManager.Reporter == this)
		{
			this.StudentManager.Reporter = null;
			if (this.ReportPhase == 0)
			{
				Debug.Log("A reporter died before being able to report a corpse. Corpse position reset.");
				this.StudentManager.CorpseLocation.position = Vector3.zero;
			}
		}
		if (this.Club == ClubType.Delinquent && this.MyWeapon != null && this.MyWeapon.transform.parent == this.ItemParent)
		{
			this.MyWeapon.transform.parent = null;
			this.MyWeapon.MyCollider.enabled = true;
			this.MyWeapon.Prompt.enabled = true;
			Rigidbody component = this.MyWeapon.GetComponent<Rigidbody>();
			component.constraints = RigidbodyConstraints.None;
			component.isKinematic = false;
			component.useGravity = true;
		}
		if (this.PhotoEvidence)
		{
			this.CameraFlash.SetActive(false);
			this.SmartPhone.SetActive(true);
		}
		if (this.BloodPool != null)
		{
			WeaponScript component2 = this.BloodPool.GetComponent<WeaponScript>();
			if (component2 != null && component2.Returner == this)
			{
				component2.Returner = null;
			}
		}
	}

	// Token: 0x06001E38 RID: 7736 RVA: 0x001967D0 File Offset: 0x001949D0
	public void DropPlate()
	{
		if (this.MyPlate != null)
		{
			if (this.MyPlate.parent == this.RightHand)
			{
				this.MyPlate.GetComponent<Rigidbody>().isKinematic = false;
				this.MyPlate.GetComponent<Rigidbody>().useGravity = true;
				this.MyPlate.GetComponent<Collider>().enabled = true;
				this.MyPlate.parent = null;
				this.MyPlate.gameObject.SetActive(true);
			}
			if (this.Distracting)
			{
				this.DistractionTarget.TargetedForDistraction = false;
				this.Distracting = false;
				this.IdleAnim = this.OriginalIdleAnim;
				this.WalkAnim = this.OriginalWalkAnim;
			}
		}
	}

	// Token: 0x06001E39 RID: 7737 RVA: 0x0019688C File Offset: 0x00194A8C
	public void SenpaiNoticed()
	{
		Debug.Log("The ''SenpaiNoticed'' function has been called.");
		if (this.Yandere.Shutter.Snapping)
		{
			this.Yandere.Shutter.ResumeGameplay();
			this.Yandere.StopAiming();
		}
		this.Yandere.Stance.Current = StanceType.Standing;
		this.Yandere.CrawlTimer = 0f;
		this.Yandere.Uncrouch();
		this.Yandere.Noticed = true;
		if (this.WeaponToTakeAway != null && this.Teacher && !this.Yandere.Attacking)
		{
			Debug.Log("Taking away Yandere-chan's weapon.");
			if (this.Yandere.EquippedWeapon.WeaponID == 23)
			{
				this.WeaponToTakeAway.transform.parent = null;
				this.WeaponToTakeAway.transform.position = this.WeaponToTakeAway.GetComponent<WeaponScript>().StartingPosition;
				this.WeaponToTakeAway.transform.eulerAngles = this.WeaponToTakeAway.GetComponent<WeaponScript>().StartingRotation;
				this.WeaponToTakeAway.GetComponent<WeaponScript>().Prompt.enabled = true;
				this.WeaponToTakeAway.GetComponent<WeaponScript>().enabled = true;
				this.WeaponToTakeAway.GetComponent<WeaponScript>().Drop();
				this.WeaponToTakeAway.GetComponent<WeaponScript>().MyRigidbody.useGravity = false;
				this.WeaponToTakeAway.GetComponent<WeaponScript>().MyRigidbody.isKinematic = true;
			}
			else
			{
				this.Yandere.EquippedWeapon.Drop();
				this.WeaponToTakeAway.transform.position = this.StudentManager.WeaponBoxSpot.parent.position + new Vector3(0f, 1f, 0f);
				this.WeaponToTakeAway.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			}
		}
		if (this.Yandere.StolenObjectID == 1)
		{
			Debug.Log("Yandere-chan was spotted stealing cigarettes.");
			this.Yandere.Inventory.Cigs = false;
		}
		this.WeaponToTakeAway = null;
		if (!this.Yandere.Attacking)
		{
			this.Yandere.EmptyHands();
		}
		this.Yandere.Senpai = base.transform;
		if (this.Yandere.Aiming)
		{
			this.Yandere.StopAiming();
		}
		this.Yandere.PauseScreen.Hint.MyPanel.alpha = 0f;
		this.Yandere.DetectionPanel.alpha = 0f;
		this.Yandere.RPGCamera.mouseSpeed = 0f;
		this.Yandere.LaughIntensity = 0f;
		this.Yandere.HUD.alpha = 0f;
		this.Yandere.EyeShrink = 0f;
		this.Yandere.Sanity = 100f;
		this.Yandere.ProgressBar.transform.parent.gameObject.SetActive(false);
		this.Yandere.HeartRate.gameObject.SetActive(false);
		this.Yandere.Stance.Current = StanceType.Standing;
		this.Yandere.SneakShotPhone.SetActive(false);
		this.Yandere.ShoulderCamera.OverShoulder = false;
		this.Yandere.DelinquentFighting = false;
		this.Yandere.FakingReaction = false;
		this.Yandere.YandereVision = false;
		this.Yandere.CannotRecover = true;
		this.Yandere.SneakingShot = false;
		this.Yandere.Police.Show = false;
		this.Yandere.Poisoning = false;
		this.Yandere.Rummaging = false;
		this.Yandere.Laughing = false;
		this.Yandere.CanMove = false;
		this.Yandere.Dipping = false;
		this.Yandere.Mopping = false;
		this.Yandere.Talking = false;
		this.Yandere.Hiding = false;
		this.Yandere.Lewd = false;
		this.Yandere.Jukebox.GameOver();
		this.StudentManager.GameOverIminent = true;
		this.StudentManager.StopMoving();
		if (this.Teacher || this.StudentID == 1)
		{
			if (this.Club != ClubType.Council)
			{
				this.IdleAnim = this.OriginalIdleAnim;
			}
			if (this.Giggle != null)
			{
				this.ForgetGiggle();
			}
			this.AlarmTimer = 0f;
			this.GoAway = false;
			base.enabled = true;
			this.Stop = false;
		}
		if (this.StudentID == 1)
		{
			this.StudentManager.FountainAudio[0].Stop();
			this.StudentManager.FountainAudio[1].Stop();
		}
		if (this.StudentManager.Eighties)
		{
			this.Yandere.LoseGentleEyes();
		}
	}

	// Token: 0x06001E3A RID: 7738 RVA: 0x00196D68 File Offset: 0x00194F68
	private void WitnessMurder()
	{
		Debug.Log(this.Name + " just realized that Yandere-chan is responsible for a murder!");
		this.Yandere.Alerts++;
		if (this.Corpse == null)
		{
			this.Corpse = this.Yandere.CurrentRagdoll;
		}
		this.RespectEarned = false;
		if ((this.Fleeing && this.WitnessedBloodPool) || this.ReportPhase == 2)
		{
			this.WitnessedBloodyWeapon = false;
			this.WitnessedBloodPool = false;
			this.WitnessedSomething = false;
			this.WitnessedWeapon = false;
			this.WitnessedLimb = false;
			this.Fleeing = false;
			this.ReportPhase = 0;
		}
		this.CharacterAnimation[this.ScaredAnim].time = 0f;
		this.CameraFlash.SetActive(false);
		if (!this.Male)
		{
			this.CharacterAnimation["f02_smile_00"].weight = 0f;
			this.WateringCan.SetActive(false);
		}
		if (this.MyPlate != null && this.MyPlate.parent == this.RightHand)
		{
			this.MyPlate.GetComponent<Rigidbody>().isKinematic = false;
			this.MyPlate.GetComponent<Rigidbody>().useGravity = true;
			this.MyPlate.GetComponent<Collider>().enabled = true;
			this.MyPlate.parent = null;
		}
		this.EmptyHands();
		this.MurdersWitnessed++;
		this.SpeechLines.Stop();
		this.WitnessedBloodyWeapon = false;
		this.WitnessedBloodPool = false;
		this.WitnessedSomething = false;
		this.WitnessedWeapon = false;
		this.WitnessedLimb = false;
		if (this.ReturningMisplacedWeapon)
		{
			this.DropMisplacedWeapon();
		}
		this.SpecialRivalDeathReaction = false;
		this.SenpaiWitnessingRivalDie = false;
		this.ReturningMisplacedWeapon = false;
		this.InvestigatingBloodPool = false;
		this.CameraReacting = false;
		this.FocusOnYandere = false;
		this.TakingOutTrash = false;
		this.WitnessedMurder = true;
		this.Investigating = false;
		this.Distracting = false;
		this.EatingSnack = false;
		this.Threatened = false;
		this.Distracted = false;
		this.Reacted = false;
		this.Routine = false;
		this.Alarmed = true;
		this.NoTalk = false;
		this.Wet = false;
		if (this.OriginalPersona != PersonaType.Violent && this.Persona != this.OriginalPersona)
		{
			Debug.Log(this.Name + " is reverting back into their original Persona.");
			this.Persona = this.OriginalPersona;
			this.SwitchBack = false;
			if (this.Persona == PersonaType.Heroic || this.Persona == PersonaType.Dangerous)
			{
				this.PersonaReaction();
			}
		}
		if (this.Persona == PersonaType.Spiteful && this.Yandere.TargetStudent != null)
		{
			Debug.Log("A Spiteful student witnessed a murder.");
			if ((this.Bullied && this.Yandere.TargetStudent.Club == ClubType.Bully) || this.Yandere.TargetStudent.Bullied)
			{
				this.ScaredAnim = this.EvilWitnessAnim;
				this.Persona = PersonaType.Evil;
			}
		}
		if (this.Club == ClubType.Delinquent)
		{
			Debug.Log("A Delinquent witnessed a murder.");
			if (this.Yandere.TargetStudent != null && this.Yandere.TargetStudent.Club == ClubType.Bully)
			{
				this.ScaredAnim = this.EvilWitnessAnim;
				this.Persona = PersonaType.Evil;
			}
			if (((this.Yandere.Lifting && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Dragging && !this.Yandere.CurrentRagdoll.Concealed)) && this.Yandere.CurrentRagdoll.Student.Club == ClubType.Bully)
			{
				this.ScaredAnim = this.EvilWitnessAnim;
				this.Persona = PersonaType.Evil;
			}
		}
		if (this.Persona == PersonaType.Sleuth)
		{
			Debug.Log("A Sleuth is witnessing a murder.");
			if (this.Yandere.Attacking || this.Yandere.Struggling || (this.Yandere.Carrying && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Lifting && !this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart))
			{
				if (!this.Sleuthing)
				{
					Debug.Log("A Sleuth is changing their Persona.");
					if (this.StudentID == 56)
					{
						this.Persona = PersonaType.Heroic;
					}
					else if (this.StudentManager.Eighties)
					{
						this.Persona = PersonaType.LandlineUser;
					}
					else
					{
						this.Persona = PersonaType.SocialButterfly;
					}
				}
				else if (this.StudentManager.Eighties)
				{
					this.Persona = PersonaType.LandlineUser;
				}
				else
				{
					this.Persona = PersonaType.SocialButterfly;
				}
			}
		}
		if (this.Persona == PersonaType.Heroic)
		{
			this.Yandere.Pursuer = this;
		}
		if (this.StudentID > 1 || this.Yandere.Mask != null)
		{
			this.ID = 0;
			while (this.ID < this.Outlines.Length)
			{
				if (this.Outlines[this.ID] != null)
				{
					this.Outlines[this.ID].color = new Color(1f, 0f, 0f, 1f);
					this.Outlines[this.ID].enabled = true;
				}
				this.ID++;
			}
			this.SummonWitnessCamera();
			this.CameraEffects.MurderWitnessed();
			this.Witnessed = StudentWitnessType.Murder;
			if (this.Persona != PersonaType.Evil)
			{
				this.Police.Witnesses++;
			}
			if (this.Teacher)
			{
				this.StudentManager.Reporter = this;
			}
			if (this.Talking)
			{
				this.DialogueWheel.End();
				this.Hearts.emission.enabled = false;
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Obstacle.enabled = false;
				this.Talk.enabled = false;
				this.Talking = false;
				this.Waiting = false;
				this.StudentManager.EnablePrompts();
			}
			if (this.Prompt.Label[0] != null && !this.StudentManager.EmptyDemon)
			{
				this.Prompt.Label[0].text = "     Talk";
				this.Prompt.HideButton[0] = true;
			}
		}
		else
		{
			if (!this.Yandere.Attacking && !this.Yandere.Struggling && !this.Yandere.Egg)
			{
				this.SenpaiNoticed();
			}
			this.Fleeing = false;
			this.EyeShrink = 0f;
			this.Yandere.Noticed = true;
			this.Yandere.Talking = false;
			this.CameraEffects.MurderWitnessed();
			this.Yandere.ShoulderCamera.OverShoulder = false;
			this.CharacterAnimation.CrossFade(this.ScaredAnim);
			this.CharacterAnimation["scaredFace_00"].weight = 1f;
			if (this.StudentID == 1)
			{
				Debug.Log("Senpai entered his scared animation.");
			}
		}
		if (this.Persona == PersonaType.TeachersPet && this.StudentManager.Reporter == null && !this.Police.Called)
		{
			this.StudentManager.CorpseLocation.position = this.Yandere.transform.position;
			this.StudentManager.LowerCorpsePosition();
			this.StudentManager.Reporter = this;
			this.ReportingMurder = true;
		}
		if (this.Following)
		{
			this.Hearts.emission.enabled = false;
			this.FollowCountdown.gameObject.SetActive(false);
			this.Yandere.Follower = null;
			this.Yandere.Followers--;
			this.Following = false;
		}
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		if (!this.Phoneless && (this.Persona == PersonaType.PhoneAddict || this.Sleuthing))
		{
			this.SmartPhone.SetActive(true);
		}
		if (this.SmartPhone.activeInHierarchy)
		{
			if (this.Persona != PersonaType.Heroic && this.Persona != PersonaType.Dangerous && this.Persona != PersonaType.Evil && this.Persona != PersonaType.Violent && this.Persona != PersonaType.Coward && !this.Teacher)
			{
				this.Persona = PersonaType.PhoneAddict;
				if (!this.Sleuthing)
				{
					this.SprintAnim = this.PhoneAnims[2];
				}
				else
				{
					this.SprintAnim = this.SleuthReportAnim;
				}
			}
			else
			{
				this.SmartPhone.SetActive(false);
			}
		}
		this.StopPairing();
		if (this.Persona != PersonaType.Heroic)
		{
			this.AlarmTimer = 0f;
			this.Alarm = 0f;
		}
		if (this.Teacher)
		{
			if (!this.Yandere.Chased)
			{
				Debug.Log("A teacher has reached ChaseYandere through WitnessMurder.");
				this.ChaseYandere();
			}
		}
		else
		{
			this.SpawnAlarmDisc();
		}
		if (!this.PinDownWitness && this.Persona != PersonaType.Evil)
		{
			this.StudentManager.Witnesses++;
			this.StudentManager.WitnessList[this.StudentManager.Witnesses] = this;
			this.StudentManager.PinDownCheck();
			this.PinDownWitness = true;
		}
		if (this.Persona == PersonaType.Violent)
		{
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
		}
		if (this.Yandere.Mask == null)
		{
			this.SawMask = false;
			if (this.Persona != PersonaType.Evil)
			{
				this.Grudge = true;
			}
		}
		else
		{
			this.SawMask = true;
		}
		this.StudentManager.UpdateMe(this.StudentID);
	}

	// Token: 0x06001E3B RID: 7739 RVA: 0x00197710 File Offset: 0x00195910
	public void DropMisplacedWeapon()
	{
		this.WitnessedWeapon = false;
		this.InvestigatingBloodPool = false;
		this.ReturningMisplacedWeaponPhase = 0;
		this.ReturningMisplacedWeapon = false;
		this.BloodPool.GetComponent<WeaponScript>().Returner = null;
		this.BloodPool.GetComponent<WeaponScript>().Drop();
		this.BloodPool.GetComponent<WeaponScript>().enabled = true;
		this.BloodPool = null;
		this.WalkAnim = this.BeforeReturnAnim;
	}

	// Token: 0x06001E3C RID: 7740 RVA: 0x00197780 File Offset: 0x00195980
	private void ChaseYandere()
	{
		Debug.Log(this.Name + " has begun to chase Yandere-chan.");
		this.CurrentDestination = this.Yandere.transform;
		this.Pathfinding.target = this.Yandere.transform;
		this.Pathfinding.speed = 5f;
		if (this.Yandere.Pursuer == null)
		{
			this.Yandere.Pursuer = this;
		}
		this.TargetDistance = 1f;
		this.AlarmTimer = 0f;
		this.Chasing = false;
		this.Fleeing = false;
		this.StudentManager.UpdateStudents(0);
	}

	// Token: 0x06001E3D RID: 7741 RVA: 0x00197828 File Offset: 0x00195A28
	private void PersonaReaction()
	{
		if (this.Persona == PersonaType.Sleuth)
		{
			if (this.Sleuthing)
			{
				if (!this.Phoneless)
				{
					this.Persona = PersonaType.PhoneAddict;
					this.SmartPhone.SetActive(true);
				}
				else
				{
					this.Persona = PersonaType.Loner;
				}
			}
			else if (this.StudentManager.Eighties)
			{
				this.Persona = PersonaType.LandlineUser;
			}
			else if (!this.Phoneless)
			{
				this.Persona = PersonaType.SocialButterfly;
			}
			else
			{
				this.Persona = PersonaType.Loner;
			}
		}
		if ((this.Persona == PersonaType.PhoneAddict && this.Phoneless) || (this.Persona == PersonaType.SocialButterfly && this.Phoneless))
		{
			this.Persona = PersonaType.Loner;
		}
		if (!this.Indoors && this.WitnessedMurder && !this.Rival)
		{
			Debug.Log(this.Name + "'s current Persona is: " + this.Persona.ToString());
			if ((this.Persona != PersonaType.Evil && this.Persona != PersonaType.Heroic && this.Persona != PersonaType.Coward && this.Persona != PersonaType.PhoneAddict && this.Persona != PersonaType.Protective && this.Persona != PersonaType.Violent) || this.Injured)
			{
				Debug.Log(this.Name + " is switching to the Loner Persona.");
				this.Persona = PersonaType.Loner;
			}
		}
		if (!this.WitnessedMurder)
		{
			if (this.Persona == PersonaType.Heroic)
			{
				this.SwitchBack = true;
				this.Persona = ((this.Corpse != null) ? PersonaType.TeachersPet : PersonaType.Loner);
			}
			else if (this.Persona == PersonaType.Coward || this.Persona == PersonaType.Evil || this.Persona == PersonaType.Fragile)
			{
				this.Persona = PersonaType.Loner;
			}
			else if (this.Persona == PersonaType.Protective)
			{
				Debug.Log("Raibaru witnessed the corpse of " + this.Corpse.Student.Name + ", and is now switching to the Lovestruck Persona.");
				this.Persona = PersonaType.Lovestruck;
			}
		}
		if (this.Persona == PersonaType.Loner || this.Persona == PersonaType.Spiteful)
		{
			Debug.Log(this.Name + " is looking in the Loner/Spiteful section of PersonaReaction() to decide what to do next.");
			if (this.Club == ClubType.Delinquent)
			{
				Debug.Log("A delinquent turned into a loner, and now he is fleeing.");
				if (this.Injured)
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentInjuredFlee, 1, 3f);
				}
				else if (this.FoundFriendCorpse)
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentFriendFlee, 1, 3f);
				}
				else if (this.FoundEnemyCorpse)
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentEnemyFlee, 1, 3f);
				}
				else
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentFlee, 1, 3f);
				}
			}
			else if (this.WitnessedMurder)
			{
				this.Subtitle.UpdateLabel(SubtitleType.LonerMurderReaction, 1, 3f);
			}
			else
			{
				this.Subtitle.UpdateLabel(SubtitleType.LonerCorpseReaction, 1, 3f);
			}
			if (this.Schoolwear > 0)
			{
				if (!this.Bloody)
				{
					this.Pathfinding.target = this.StudentManager.Exit;
					this.TargetDistance = 0f;
					this.Routine = false;
					this.Fleeing = true;
				}
				else
				{
					this.FleeWhenClean = true;
					this.TargetDistance = 1f;
					this.BatheFast = true;
				}
			}
			else
			{
				this.FleeWhenClean = true;
				if (!this.Bloody)
				{
					this.BathePhase = 5;
					this.GoChange();
				}
				else
				{
					this.CurrentDestination = this.StudentManager.FastBatheSpot;
					this.Pathfinding.target = this.StudentManager.FastBatheSpot;
					this.TargetDistance = 1f;
					this.BatheFast = true;
				}
			}
			if (this.Corpse != null && this.StudentID == 1 && this.Corpse.Student.Rival)
			{
				this.CurrentDestination = this.Corpse.Student.Hips;
				this.Pathfinding.target = this.Corpse.Student.Hips;
				this.SenpaiWitnessingRivalDie = true;
				this.IgnoringPettyActions = true;
				this.DistanceToDestination = 1f;
				this.WitnessRivalDiePhase = 3;
				this.Routine = false;
				this.TargetDistance = 0.5f;
			}
		}
		else if (this.Persona == PersonaType.TeachersPet)
		{
			if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
			{
				if (this.StudentManager.BloodReporter == null)
				{
					if (this.Club != ClubType.Delinquent && !this.Police.Called && !this.LostTeacherTrust)
					{
						this.StudentManager.BloodLocation.position = this.BloodPool.transform.position;
						this.StudentManager.LowerBloodPosition();
						Debug.Log(this.Name + " has become a ''blood reporter''.");
						this.StudentManager.BloodReporter = this;
						this.ReportingBlood = true;
						this.DetermineBloodLocation();
					}
					else
					{
						this.ReportingBlood = false;
					}
				}
			}
			else if (this.StudentManager.Reporter == null && !this.Police.Called && this.StudentManager.CorpseLocation != null)
			{
				this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
				this.StudentManager.LowerCorpsePosition();
				Debug.Log(this.Name + " has become a ''reporter''.");
				this.StudentManager.Reporter = this;
				this.ReportingMurder = true;
				this.IgnoringPettyActions = true;
				this.DetermineCorpseLocation();
			}
			if (this.StudentManager.Reporter == this)
			{
				Debug.Log(this.Name + " is running to a teacher to report murder.");
				this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
				this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
				this.TargetDistance = 2f;
				if (this.Club == ClubType.Council)
				{
					if (this.StudentID == 86)
					{
						this.Subtitle.UpdateLabel(SubtitleType.StrictReport, 1, 5f);
					}
					else if (this.StudentID == 87)
					{
						this.Subtitle.UpdateLabel(SubtitleType.CasualReport, 1, 5f);
					}
					else if (this.StudentID == 88)
					{
						this.Subtitle.UpdateLabel(SubtitleType.GraceReport, 1, 5f);
					}
					else if (this.StudentID == 89)
					{
						this.Subtitle.UpdateLabel(SubtitleType.EdgyReport, 1, 5f);
					}
				}
				else if (this.WitnessedMurder)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetMurderReport, 1, 3f);
				}
				else if (this.WitnessedCorpse)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetCorpseReport, 1, 3f);
				}
			}
			else if (this.StudentManager.BloodReporter == this)
			{
				Debug.Log(this.Name + " is running to a teacher to report something.");
				this.DropPlate();
				this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
				this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
				this.TargetDistance = 2f;
				if (this.WitnessedLimb)
				{
					this.Subtitle.UpdateLabel(SubtitleType.LimbReaction, 1, 3f);
				}
				else if (this.WitnessedBloodyWeapon)
				{
					this.Subtitle.UpdateLabel(SubtitleType.BloodyWeaponReaction, 1, 3f);
				}
				else if (this.WitnessedBloodPool)
				{
					this.Subtitle.UpdateLabel(SubtitleType.BloodPoolReaction, 1, 3f);
				}
				else if (this.WitnessedWeapon)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReport, 1, 3f);
				}
			}
			else
			{
				Debug.Log(this.Name + " found something scary, and is now deciding what to do next.");
				if (this.Club == ClubType.Council)
				{
					if (this.WitnessedCorpse)
					{
						if (this.StudentManager.CorpseLocation.position == Vector3.zero)
						{
							this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
							this.AssignCorpseGuardLocations();
						}
						if (this.StudentID == 86)
						{
							this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[1];
						}
						else if (this.StudentID == 87)
						{
							this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[2];
						}
						else if (this.StudentID == 88)
						{
							this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[3];
						}
						else if (this.StudentID == 89)
						{
							this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[4];
						}
						this.CurrentDestination = this.Pathfinding.target;
					}
					else
					{
						Debug.Log("A student council member is being told to travel to ''BloodGuardLocation''.");
						if (this.StudentManager.BloodLocation.position == Vector3.zero)
						{
							this.StudentManager.BloodLocation.position = this.BloodPool.transform.position;
							this.AssignBloodGuardLocations();
						}
						if (this.StudentManager.BloodGuardLocation[1].position == Vector3.zero)
						{
							this.AssignBloodGuardLocations();
						}
						if (this.StudentID == 86)
						{
							this.Pathfinding.target = this.StudentManager.BloodGuardLocation[1];
						}
						else if (this.StudentID == 87)
						{
							this.Pathfinding.target = this.StudentManager.BloodGuardLocation[2];
						}
						else if (this.StudentID == 88)
						{
							this.Pathfinding.target = this.StudentManager.BloodGuardLocation[3];
						}
						else if (this.StudentID == 89)
						{
							this.Pathfinding.target = this.StudentManager.BloodGuardLocation[4];
						}
						this.CurrentDestination = this.Pathfinding.target;
						this.Guarding = true;
					}
				}
				else
				{
					Debug.Log(this.Name + " is going to run and hide in their classroom.");
					this.PetDestination = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, this.Seat.position + this.Seat.forward * -0.5f, Quaternion.identity).transform;
					this.Pathfinding.target = this.PetDestination;
					this.CurrentDestination = this.PetDestination;
					if (this.Distracting)
					{
						if (this.DistractionTarget != null)
						{
							this.DistractionTarget.TargetedForDistraction = false;
						}
						this.ResumeDistracting = false;
						this.Distracting = false;
					}
					this.DropPlate();
				}
				if (this.WitnessedMurder)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetMurderReaction, 1, 3f);
				}
				else if (this.WitnessedCorpse)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetCorpseReaction, 1, 3f);
				}
				else if (this.WitnessedLimb)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetLimbReaction, 1, 3f);
				}
				else if (this.WitnessedBloodyWeapon)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetBloodyWeaponReaction, 1, 3f);
				}
				else if (this.WitnessedBloodPool)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetBloodReaction, 1, 3f);
				}
				else if (this.WitnessedWeapon)
				{
					this.Subtitle.UpdateLabel(SubtitleType.PetWeaponReaction, 1, 3f);
				}
				this.TargetDistance = 1f;
				this.ReportingMurder = false;
				this.ReportingBlood = false;
			}
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == PersonaType.Heroic || this.Persona == PersonaType.Protective)
		{
			if (!this.Yandere.Chased)
			{
				this.StudentManager.PinDownCheck();
				if (!this.StudentManager.PinningDown)
				{
					Debug.Log(this.Name + "'s ''Flee'' was set to ''true'' because Hero persona reaction was called.");
					if (this.Persona == PersonaType.Protective)
					{
						this.Subtitle.UpdateLabel(SubtitleType.ObstacleMurderReaction, 2, 3f);
					}
					else if (this.Persona != PersonaType.Violent)
					{
						this.Subtitle.UpdateLabel(SubtitleType.HeroMurderReaction, 3, 3f);
					}
					else if (this.Defeats > 0)
					{
						this.Subtitle.Speaker = this;
						this.Subtitle.UpdateLabel(SubtitleType.DelinquentResume, 3, 3f);
					}
					else
					{
						this.Subtitle.Speaker = this;
						this.Subtitle.UpdateLabel(SubtitleType.DelinquentMurderReaction, 3, 3f);
					}
					this.Pathfinding.target = this.Yandere.transform;
					this.Pathfinding.speed = 5f;
					this.Yandere.Pursuer = this;
					this.Yandere.Chased = true;
					this.TargetDistance = 1f;
					this.StudentManager.UpdateStudents(0);
					this.Routine = false;
					this.Fleeing = true;
				}
			}
		}
		else if (this.Persona == PersonaType.Coward || this.Persona == PersonaType.Fragile)
		{
			Debug.Log("This character just set their destination to themself.");
			this.CurrentDestination = base.transform;
			this.Pathfinding.target = base.transform;
			this.Subtitle.UpdateLabel(SubtitleType.CowardMurderReaction, 1, 5f);
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == PersonaType.Evil)
		{
			Debug.Log("This character just set their destination to themself.");
			this.CurrentDestination = base.transform;
			this.Pathfinding.target = base.transform;
			this.Subtitle.UpdateLabel(SubtitleType.EvilMurderReaction, 1, 5f);
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == PersonaType.SocialButterfly)
		{
			Debug.Log("A social butterfly is calling PersonaReaction().");
			this.StudentManager.HidingSpots.List[this.StudentID].position = this.StudentManager.PopulationManager.GetCrowdedLocation();
			this.CurrentDestination = this.StudentManager.HidingSpots.List[this.StudentID];
			this.Pathfinding.target = this.StudentManager.HidingSpots.List[this.StudentID];
			this.Subtitle.UpdateLabel(SubtitleType.SocialDeathReaction, 1, 5f);
			this.TargetDistance = 2f;
			this.ReportPhase = 1;
			this.Routine = false;
			this.Fleeing = true;
			this.Halt = true;
		}
		else if (this.Persona == PersonaType.Lovestruck)
		{
			Debug.Log(this.Name + " is now calling the the Lovestruck Persona code.");
			if (this.Corpse != null)
			{
				Debug.Log(this.Name + " witnessed the corpse of: " + this.Corpse.Student.Name);
			}
			bool flag = false;
			if (!this.WitnessedMurder && this.Corpse != null && (this.Corpse.Student.Rival || this.Corpse.StudentID == this.StudentManager.ObstacleID))
			{
				flag = true;
			}
			if (flag)
			{
				Debug.Log(this.Name + " is going to have a special reaction to the corpse of " + this.Corpse.Student.Name);
				this.CurrentDestination = this.Corpse.Student.Hips;
				this.Pathfinding.target = this.Corpse.Student.Hips;
				this.SpecialRivalDeathReaction = true;
				this.IgnoringPettyActions = true;
				this.WitnessRivalDiePhase = 1;
				this.Routine = false;
				this.TargetDistance = 0.5f;
			}
			else
			{
				if (!this.StudentManager.Students[this.LovestruckTarget].WitnessedMurder)
				{
					Debug.Log(this.Name + "'s new destination should be " + this.StudentManager.Students[this.LovestruckTarget].Name);
					this.CurrentDestination = this.StudentManager.Students[this.LovestruckTarget].transform;
					this.Pathfinding.target = this.StudentManager.Students[this.LovestruckTarget].transform;
					this.StudentManager.Students[this.LovestruckTarget].TargetedForDistraction = true;
					this.TargetDistance = 1f;
					this.ReportPhase = 1;
				}
				else
				{
					Debug.Log(this.Name + "'s new destination should be the exit of the school.");
					this.CurrentDestination = this.StudentManager.Exit;
					this.Pathfinding.target = this.StudentManager.Exit;
					this.TargetDistance = 0f;
					this.ReportPhase = 3;
				}
				if (this.LovestruckTarget == 1)
				{
					this.Subtitle.UpdateLabel(SubtitleType.LovestruckDeathReaction, 0, 5f);
				}
				else
				{
					this.Subtitle.UpdateLabel(SubtitleType.LovestruckDeathReaction, 1, 5f);
				}
				this.DistanceToDestination = 100f;
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.Routine = false;
				this.Fleeing = true;
				this.Halt = true;
			}
		}
		else if (this.Persona == PersonaType.Dangerous)
		{
			if (this.WitnessedMurder)
			{
				if (!this.Yandere.DelinquentFighting)
				{
					this.Subtitle.UpdateLabel(SubtitleType.Chasing, this.ClubMemberID, 5f);
				}
				this.Pathfinding.target = this.Yandere.transform;
				this.Pathfinding.speed = 5f;
				this.Yandere.Chased = true;
				this.TargetDistance = 1f;
				this.StudentManager.UpdateStudents(0);
				this.Routine = false;
				this.Fleeing = true;
				this.Halt = true;
			}
			else
			{
				Debug.Log("A student council member has transformed into a Teacher's Pet.");
				this.Persona = PersonaType.TeachersPet;
				this.PersonaReaction();
			}
		}
		else if (this.Persona == PersonaType.PhoneAddict)
		{
			Debug.Log(this.Name + " is executing the Phone Addict Persona code.");
			this.CurrentDestination = this.StudentManager.Exit;
			this.Pathfinding.target = this.StudentManager.Exit;
			if (!this.StudentManager.Eighties)
			{
				this.Countdown.gameObject.SetActive(true);
				if (this.StudentManager.ChaseCamera == null)
				{
					this.StudentManager.ChaseCamera = this.ChaseCamera;
					this.ChaseCamera.SetActive(true);
				}
			}
			this.Routine = false;
			this.Fleeing = true;
		}
		else if (this.Persona == PersonaType.Violent)
		{
			Debug.Log(this.Name + ", a delinquent, is currently in the ''Violent'' part of PersonaReaction()");
			if (this.WitnessedMurder)
			{
				if (!this.Yandere.Chased)
				{
					this.StudentManager.PinDownCheck();
					if (!this.StudentManager.PinningDown)
					{
						Debug.Log(this.Name + " began fleeing because Violent persona reaction was called.");
						if (this.Defeats > 0)
						{
							this.Subtitle.Speaker = this;
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentResume, 3, 3f);
						}
						else
						{
							this.Subtitle.Speaker = this;
							this.Subtitle.UpdateLabel(SubtitleType.DelinquentMurderReaction, 3, 3f);
						}
						this.Pathfinding.target = this.Yandere.transform;
						this.Pathfinding.canSearch = true;
						this.Pathfinding.canMove = true;
						this.Pathfinding.speed = 5f;
						this.Yandere.Pursuer = this;
						this.Yandere.Chased = true;
						this.TargetDistance = 1f;
						this.StudentManager.UpdateStudents(0);
						this.Routine = false;
						this.Fleeing = true;
					}
				}
			}
			else
			{
				Debug.Log("A delinquent has reached the ''Flee'' protocol.");
				if (this.FoundFriendCorpse)
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentFriendFlee, 1, 3f);
				}
				else
				{
					this.Subtitle.Speaker = this;
					this.Subtitle.UpdateLabel(SubtitleType.DelinquentFlee, 1, 3f);
				}
				this.Pathfinding.target = this.StudentManager.Exit;
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				this.TargetDistance = 0f;
				this.Routine = false;
				this.Fleeing = true;
			}
		}
		else if (this.Persona == PersonaType.Strict)
		{
			if (this.Yandere.Pursuer == this)
			{
				Debug.Log("This teacher is now pursuing Yandere-chan.");
			}
			if (this.WitnessedMurder)
			{
				if (this.Yandere.Pursuer == this)
				{
					Debug.Log("A teacher is now reacting to the sight of murder.");
					this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 3, 3f);
					this.Pathfinding.target = this.Yandere.transform;
					this.Pathfinding.speed = 5f;
					this.Yandere.Chased = true;
					this.TargetDistance = 1f;
					this.StudentManager.UpdateStudents(0);
					base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
					this.Routine = false;
					this.Fleeing = true;
				}
				else if (!this.Yandere.Chased)
				{
					if (this.Yandere.FightHasBrokenUp)
					{
						Debug.Log("This teacher is returning to normal after witnessing a SC member break up a fight.");
						this.WitnessedMurder = false;
						this.PinDownWitness = false;
						this.Alarmed = false;
						this.Reacted = false;
						this.Routine = true;
						this.Grudge = false;
						this.AlarmTimer = 0f;
						this.PreviousEyeShrink = 0f;
						this.EyeShrink = 0f;
						this.PreviousAlarm = 0f;
						this.MurdersWitnessed = 0;
						this.Concern = 0;
						this.Witnessed = StudentWitnessType.None;
						this.GameOverCause = GameOverType.None;
						this.CurrentDestination = this.Destinations[this.Phase];
						this.Pathfinding.target = this.Destinations[this.Phase];
					}
					else
					{
						Debug.Log("A teacher has reached ChaseYandere through PersonaReaction.");
						this.ChaseYandere();
					}
				}
			}
			else if (this.WitnessedCorpse)
			{
				Debug.Log("A teacher is now reacting to the sight of a corpse.");
				if (this.ReportPhase == 0)
				{
					this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseReaction, 1, 3f);
				}
				this.Pathfinding.target = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z), Quaternion.identity).transform;
				this.Pathfinding.target.position = Vector3.MoveTowards(this.Pathfinding.target.position, base.transform.position, 1.5f);
				this.TargetDistance = 1f;
				this.ReportPhase = 2;
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
				this.IgnoringPettyActions = true;
				this.Routine = false;
				this.Fleeing = true;
			}
			else
			{
				Debug.Log("A teacher is now reacting to the sight of a severed limb, blood pool, or weapon.");
				if (this.ReportPhase == 0)
				{
					if (this.WitnessedBloodPool || this.WitnessedBloodyWeapon)
					{
						this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 3, 3f);
					}
					else if (this.WitnessedLimb)
					{
						this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 4, 3f);
					}
					else if (this.WitnessedWeapon)
					{
						this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 5, 3f);
					}
				}
				this.TargetDistance = 1f;
				this.ReportPhase = 2;
				this.VerballyReacted = true;
				this.Routine = false;
				this.Fleeing = true;
				this.Halt = true;
			}
		}
		else if (this.Persona == PersonaType.LandlineUser)
		{
			Debug.Log("A Snitch is calling PersonaReaction().");
			this.CurrentDestination = this.StudentManager.LandLineSpot;
			this.Pathfinding.target = this.StudentManager.LandLineSpot;
			this.Subtitle.UpdateLabel(SubtitleType.SocialDeathReaction, 1, 5f);
			this.TargetDistance = 1f;
			this.ReportPhase = 1;
			this.Routine = false;
			this.Fleeing = true;
		}
		if (this.StudentID == 41 && !this.StudentManager.Eighties)
		{
			this.Subtitle.UpdateLabel(SubtitleType.Impatience, 6, 5f);
		}
		Debug.Log(this.Name + " has finished calling PersonaReaction(). As of now, they are a: " + this.Persona.ToString() + ".");
		if (this.WitnessedCorpse)
		{
			Debug.Log(this.Name + " witnessed a corpse...");
			if (this.Distracting)
			{
				Debug.Log("...so ''Distracting'' is being set to false.");
				if (this.DistractionTarget != null)
				{
					this.DistractionTarget.TargetedForDistraction = false;
				}
				this.ResumeDistracting = false;
				this.Distracting = false;
			}
		}
		this.Alarm = 0f;
		this.UpdateDetectionMarker();
	}

	// Token: 0x06001E3E RID: 7742 RVA: 0x00199170 File Offset: 0x00197370
	private void BeginStruggle()
	{
		Debug.Log(this.Name + " has begun a struggle with Yandere-chan.");
		if (this.Yandere.Dragging)
		{
			this.Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
		}
		if (this.Yandere.Armed)
		{
			this.Yandere.EquippedWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
		}
		this.Yandere.StruggleBar.Strength = (float)this.Strength;
		this.Yandere.StruggleBar.Struggling = true;
		this.Yandere.StruggleBar.Student = this;
		this.Yandere.StruggleBar.gameObject.SetActive(true);
		this.CharacterAnimation.CrossFade(this.StruggleAnim);
		this.Yandere.ShoulderCamera.LastPosition = this.Yandere.ShoulderCamera.transform.position;
		this.Yandere.ShoulderCamera.Struggle = true;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Obstacle.enabled = true;
		this.Struggling = true;
		this.DiscCheck = false;
		this.Alarmed = false;
		this.Halt = true;
		if (!this.Teacher)
		{
			this.Yandere.CharacterAnimation["f02_struggleA_00"].time = 0f;
		}
		else
		{
			this.Yandere.CharacterAnimation["f02_teacherStruggleA_00"].time = 0f;
			base.transform.localScale = new Vector3(1f, 1f, 1f);
		}
		if (this.Yandere.Aiming)
		{
			this.Yandere.StopAiming();
		}
		this.Yandere.StopLaughing();
		this.Yandere.TargetStudent = this;
		this.Yandere.YandereVision = false;
		this.Yandere.NearSenpai = false;
		this.Yandere.Struggling = true;
		this.Yandere.CanMove = false;
		if (this.Yandere.DelinquentFighting)
		{
			this.StudentManager.CombatMinigame.Stop();
		}
		this.Yandere.EmptyHands();
		this.Yandere.RPGCamera.enabled = false;
		this.MyController.radius = 0f;
		this.TargetDistance = 100f;
		this.AlarmTimer = 0f;
		this.SpawnAlarmDisc();
	}

	// Token: 0x06001E3F RID: 7743 RVA: 0x001993EC File Offset: 0x001975EC
	public void GetDestinations()
	{
		if (!this.Teacher)
		{
			this.MyLocker = this.StudentManager.LockerPositions[this.StudentID];
		}
		if (this.Slave)
		{
			foreach (ScheduleBlock scheduleBlock in this.ScheduleBlocks)
			{
				scheduleBlock.destination = "Slave";
				scheduleBlock.action = "Slave";
			}
		}
		this.ID = 1;
		while (this.ID < this.JSON.Students[this.StudentID].ScheduleBlocks.Length)
		{
			ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[this.ID];
			if (scheduleBlock2.destination == "Locker")
			{
				this.Destinations[this.ID] = this.MyLocker;
			}
			else if (scheduleBlock2.destination == "Seat")
			{
				this.Destinations[this.ID] = this.Seat;
			}
			else if (scheduleBlock2.destination == "SocialSeat")
			{
				this.Destinations[this.ID] = this.StudentManager.SocialSeats[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Podium")
			{
				this.Destinations[this.ID] = this.StudentManager.Podiums.List[this.Class];
			}
			else if (scheduleBlock2.destination == "Exit")
			{
				this.Destinations[this.ID] = this.StudentManager.Hangouts.List[0];
			}
			else if (scheduleBlock2.destination == "Hangout")
			{
				this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Week1Hangout")
			{
				this.Destinations[this.ID] = this.StudentManager.Week1Hangouts.List[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Week2Hangout")
			{
				this.Destinations[this.ID] = this.StudentManager.Week2Hangouts.List[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Stairway")
			{
				this.Destinations[this.ID] = this.StudentManager.Stairways.List[this.StudentID];
			}
			else if (scheduleBlock2.destination == "LunchSpot")
			{
				this.Destinations[this.ID] = this.StudentManager.LunchSpots.List[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Slave")
			{
				if (!this.FragileSlave)
				{
					this.Destinations[this.ID] = this.StudentManager.SlaveSpot;
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.FragileSlaveSpot;
				}
			}
			else if (scheduleBlock2.destination == "Patrol")
			{
				this.Destinations[this.ID] = this.StudentManager.Patrols.List[this.StudentID].GetChild(0);
				if ((this.OriginalClub == ClubType.Gardening || this.OriginalClub == ClubType.Occult) && this.Club == ClubType.None)
				{
					Debug.Log("This student's club disbanded, so their destination has been set to ''Hangout''.");
					this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
				}
			}
			else if (scheduleBlock2.destination == "Search Patrol")
			{
				this.StudentManager.SearchPatrols.List[this.Class].GetChild(0).position = this.Seat.position + this.Seat.forward;
				this.StudentManager.SearchPatrols.List[this.Class].GetChild(0).LookAt(this.Seat);
				this.StudentManager.StolenPhoneSpot.transform.position = this.Seat.position + this.Seat.forward * 0.4f;
				this.StudentManager.StolenPhoneSpot.transform.position += Vector3.up;
				this.StudentManager.StolenPhoneSpot.gameObject.SetActive(true);
				this.Destinations[this.ID] = this.StudentManager.SearchPatrols.List[this.Class].GetChild(0);
			}
			else if (scheduleBlock2.destination == "Graffiti")
			{
				this.Destinations[this.ID] = this.StudentManager.GraffitiSpots[this.BullyID];
			}
			else if (scheduleBlock2.destination == "Bully")
			{
				this.Destinations[this.ID] = this.StudentManager.BullySpots[this.BullyID];
			}
			else if (scheduleBlock2.destination == "Mourn")
			{
				this.Destinations[this.ID] = this.StudentManager.MournSpots[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Clean")
			{
				this.Destinations[this.ID] = this.CleaningSpot.GetChild(0);
			}
			else if (scheduleBlock2.destination == "ShameSpot")
			{
				this.Destinations[this.ID] = this.StudentManager.ShameSpot;
			}
			else if (scheduleBlock2.destination == "Follow")
			{
				if (this.FollowTarget != null)
				{
					this.Destinations[this.ID] = this.FollowTarget.FollowTargetDestination;
				}
			}
			else if (scheduleBlock2.destination == "Cuddle")
			{
				if (!this.Male)
				{
					this.Destinations[this.ID] = this.StudentManager.FemaleCoupleSpots[this.CoupleID];
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.MaleCoupleSpots[this.CoupleID];
				}
			}
			else if (scheduleBlock2.destination == "Peek")
			{
				if (!this.Male)
				{
					this.Destinations[this.ID] = this.StudentManager.FemaleStalkSpot;
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.MaleStalkSpot;
				}
			}
			else if (scheduleBlock2.destination == "Club")
			{
				if (this.Club > ClubType.None)
				{
					if (this.Club == ClubType.Sports)
					{
						this.Destinations[this.ID] = this.StudentManager.Clubs.List[this.StudentID].GetChild(0);
					}
					else
					{
						this.Destinations[this.ID] = this.StudentManager.Clubs.List[this.StudentID];
					}
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
				}
			}
			else if (scheduleBlock2.destination == "Sulk")
			{
				this.Destinations[this.ID] = this.StudentManager.SulkSpots[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Sleuth")
			{
				this.Destinations[this.ID] = this.SleuthTarget;
			}
			else if (scheduleBlock2.destination == "Stalk")
			{
				this.Destinations[this.ID] = this.StalkTarget;
			}
			else if (scheduleBlock2.destination == "Sunbathe")
			{
				this.Destinations[this.ID] = this.StudentManager.StrippingPositions[this.GirlID];
			}
			else if (scheduleBlock2.destination == "Shock")
			{
				this.Destinations[this.ID] = this.StudentManager.ShockedSpots[this.StudentID - 80];
			}
			else if (scheduleBlock2.destination == "Miyuki")
			{
				this.ClubMemberID = this.StudentID - 35;
				this.Destinations[this.ID] = this.StudentManager.MiyukiSpots[this.ClubMemberID].transform;
			}
			else if (scheduleBlock2.destination == "Practice")
			{
				if (this.Club > ClubType.None)
				{
					this.Destinations[this.ID] = this.StudentManager.PracticeSpots[this.ClubMemberID];
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
				}
			}
			else if (scheduleBlock2.destination == "Lyrics")
			{
				this.Destinations[this.ID] = this.StudentManager.LyricsSpot;
			}
			else if (scheduleBlock2.destination == "Meeting")
			{
				this.Destinations[this.ID] = this.StudentManager.MeetingSpots[this.StudentID].transform;
			}
			else if (scheduleBlock2.destination == "InfirmaryBed")
			{
				if (this.Male)
				{
					this.Destinations[this.ID] = this.StudentManager.MaleRestSpots[this.StudentManager.SedatedStudents];
					this.StudentManager.SedatedStudents++;
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.FemaleRestSpots[this.StudentManager.SedatedStudents];
					this.StudentManager.SedatedStudents++;
				}
			}
			else if (scheduleBlock2.destination == "InfirmarySeat")
			{
				this.Destinations[this.ID] = this.StudentManager.InfirmarySeat;
			}
			else if (scheduleBlock2.destination == "Paint")
			{
				this.Destinations[this.ID] = this.StudentManager.FridaySpots[this.StudentID];
			}
			else if (scheduleBlock2.destination == "LockerRoom")
			{
				this.Destinations[this.ID] = this.StudentManager.MaleLockerRoomChangingSpot;
			}
			else if (scheduleBlock2.destination == "LunchWitnessPosition")
			{
				this.Destinations[this.ID] = this.StudentManager.LunchWitnessPositions.List[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Wait")
			{
				this.Destinations[this.ID] = this.StudentManager.WaitSpots[this.StudentID];
			}
			else if (scheduleBlock2.destination == "SleepSpot")
			{
				this.Destinations[this.ID] = this.StudentManager.SleepSpot;
			}
			else if (scheduleBlock2.destination == "LightFire")
			{
				this.Destinations[this.ID] = this.StudentManager.PyroSpot;
			}
			else if (scheduleBlock2.destination == "EightiesSpot")
			{
				this.Destinations[this.ID] = this.StudentManager.EightiesSpots.List[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Perform")
			{
				this.Destinations[this.ID] = this.StudentManager.PerformSpots[this.StudentID];
			}
			else if (scheduleBlock2.destination == "PhotoShoot")
			{
				this.Destinations[this.ID] = this.StudentManager.PhotoShootSpots[this.StudentID];
			}
			else if (scheduleBlock2.destination == "Guard")
			{
				if (this.StudentID == 20)
				{
					this.Destinations[this.ID] = this.StudentManager.Students[1].transform;
				}
				else
				{
					this.Destinations[this.ID] = this.StudentManager.RivalGuardSpots[this.StudentID].transform;
				}
			}
			else if (scheduleBlock2.destination == "Random")
			{
				this.Destinations[this.ID] = this.StudentManager.RandomSpots[this.StudentID];
			}
			if (scheduleBlock2.action == "Stand")
			{
				this.Actions[this.ID] = StudentActionType.AtLocker;
			}
			else if (scheduleBlock2.action == "Socialize")
			{
				this.Actions[this.ID] = StudentActionType.Socializing;
			}
			else if (scheduleBlock2.action == "Game")
			{
				this.Actions[this.ID] = StudentActionType.Gaming;
			}
			else if (scheduleBlock2.action == "Slave")
			{
				this.Actions[this.ID] = StudentActionType.Slave;
			}
			else if (scheduleBlock2.action == "Relax")
			{
				this.Actions[this.ID] = StudentActionType.Relax;
			}
			else if (scheduleBlock2.action == "Sit")
			{
				this.Actions[this.ID] = StudentActionType.SitAndTakeNotes;
			}
			else if (scheduleBlock2.action == "Peek")
			{
				this.Actions[this.ID] = StudentActionType.Peek;
			}
			else if (scheduleBlock2.action == "SocialSit")
			{
				this.Actions[this.ID] = StudentActionType.SitAndSocialize;
				if (this.Persona == PersonaType.Sleuth && this.Club == ClubType.None)
				{
					this.Actions[this.ID] = StudentActionType.Socializing;
				}
			}
			else if (scheduleBlock2.action == "Eat")
			{
				this.Actions[this.ID] = StudentActionType.SitAndEatBento;
			}
			else if (scheduleBlock2.action == "Shoes")
			{
				this.Actions[this.ID] = StudentActionType.ChangeShoes;
			}
			else if (scheduleBlock2.action == "Grade")
			{
				this.Actions[this.ID] = StudentActionType.GradePapers;
			}
			else if (scheduleBlock2.action == "Patrol")
			{
				this.Actions[this.ID] = StudentActionType.Patrol;
				if (this.OriginalClub == ClubType.Occult && this.Club == ClubType.None)
				{
					Debug.Log("This student's club disbanded, so their action has been set to ''Socialize''.");
					this.Actions[this.ID] = StudentActionType.Socializing;
				}
			}
			else if (scheduleBlock2.action == "Search Patrol")
			{
				this.Actions[this.ID] = StudentActionType.SearchPatrol;
			}
			else if (scheduleBlock2.action == "Gossip")
			{
				this.Actions[this.ID] = StudentActionType.Gossip;
			}
			else if (scheduleBlock2.action == "Graffiti")
			{
				this.Actions[this.ID] = StudentActionType.Graffiti;
			}
			else if (scheduleBlock2.action == "Bully")
			{
				this.Actions[this.ID] = StudentActionType.Bully;
			}
			else if (scheduleBlock2.action == "Read")
			{
				this.Actions[this.ID] = StudentActionType.Read;
			}
			else if (scheduleBlock2.action == "Text")
			{
				this.Actions[this.ID] = StudentActionType.Texting;
			}
			else if (scheduleBlock2.action == "Mourn")
			{
				this.Actions[this.ID] = StudentActionType.Mourn;
			}
			else if (scheduleBlock2.action == "Cuddle")
			{
				this.Actions[this.ID] = StudentActionType.Cuddle;
			}
			else if (scheduleBlock2.action == "Teach")
			{
				this.Actions[this.ID] = StudentActionType.Teaching;
			}
			else if (scheduleBlock2.action == "Wait")
			{
				this.Actions[this.ID] = StudentActionType.Wait;
			}
			else if (scheduleBlock2.action == "Clean")
			{
				this.Actions[this.ID] = StudentActionType.Clean;
			}
			else if (scheduleBlock2.action == "Shamed")
			{
				this.Actions[this.ID] = StudentActionType.Shamed;
			}
			else if (scheduleBlock2.action == "Follow")
			{
				this.Actions[this.ID] = StudentActionType.Follow;
			}
			else if (scheduleBlock2.action == "Sulk")
			{
				this.Actions[this.ID] = StudentActionType.Sulk;
			}
			else if (scheduleBlock2.action == "Sleuth")
			{
				this.Actions[this.ID] = StudentActionType.Sleuth;
			}
			else if (scheduleBlock2.action == "Stalk")
			{
				this.Actions[this.ID] = StudentActionType.Stalk;
			}
			else if (scheduleBlock2.action == "Sketch")
			{
				this.Actions[this.ID] = StudentActionType.Sketch;
			}
			else if (scheduleBlock2.action == "Sunbathe")
			{
				this.Actions[this.ID] = StudentActionType.Sunbathe;
			}
			else if (scheduleBlock2.action == "Shock")
			{
				this.Actions[this.ID] = StudentActionType.Shock;
			}
			else if (scheduleBlock2.action == "Miyuki")
			{
				this.Actions[this.ID] = StudentActionType.Miyuki;
			}
			else if (scheduleBlock2.action == "Meeting")
			{
				this.Actions[this.ID] = StudentActionType.Meeting;
			}
			else if (scheduleBlock2.action == "Lyrics")
			{
				this.Actions[this.ID] = StudentActionType.Lyrics;
			}
			else if (scheduleBlock2.action == "Practice")
			{
				this.Actions[this.ID] = StudentActionType.Practice;
			}
			else if (scheduleBlock2.action == "Sew")
			{
				this.Actions[this.ID] = StudentActionType.Sew;
			}
			else if (scheduleBlock2.action == "Paint")
			{
				this.Actions[this.ID] = StudentActionType.Paint;
			}
			else if (scheduleBlock2.action == "UpdateAppearance")
			{
				this.Actions[this.ID] = StudentActionType.UpdateAppearance;
			}
			else if (scheduleBlock2.action == "LightCig")
			{
				this.Actions[this.ID] = StudentActionType.LightCig;
			}
			else if (scheduleBlock2.action == "PlaceBag")
			{
				this.Actions[this.ID] = StudentActionType.PlaceBag;
			}
			else if (scheduleBlock2.action == "Sleep")
			{
				this.Actions[this.ID] = StudentActionType.Sleep;
			}
			else if (scheduleBlock2.action == "LightFire")
			{
				this.Actions[this.ID] = StudentActionType.LightFire;
			}
			else if (scheduleBlock2.action == "Jog")
			{
				this.Actions[this.ID] = StudentActionType.Jog;
			}
			else if (scheduleBlock2.action == "PrepareFood")
			{
				this.Actions[this.ID] = StudentActionType.PrepareFood;
			}
			else if (scheduleBlock2.action == "Perform")
			{
				this.Actions[this.ID] = StudentActionType.Perform;
			}
			else if (scheduleBlock2.action == "PhotoShoot")
			{
				this.Actions[this.ID] = StudentActionType.PhotoShoot;
			}
			else if (scheduleBlock2.action == "GravurePose")
			{
				this.Actions[this.ID] = StudentActionType.GravurePose;
			}
			else if (scheduleBlock2.action == "Guard")
			{
				this.Actions[this.ID] = StudentActionType.Guard;
			}
			else if (scheduleBlock2.action == "Random")
			{
				this.Actions[this.ID] = StudentActionType.Random;
			}
			else if (scheduleBlock2.action == "Club")
			{
				if (this.Club > ClubType.None)
				{
					this.Actions[this.ID] = StudentActionType.ClubAction;
				}
				else if (this.OriginalClub == ClubType.Art)
				{
					this.Actions[this.ID] = StudentActionType.Sketch;
				}
				else
				{
					this.Actions[this.ID] = StudentActionType.Socializing;
				}
			}
			this.ID++;
		}
	}

	// Token: 0x06001E40 RID: 7744 RVA: 0x0019A888 File Offset: 0x00198A88
	private void UpdateOutlines()
	{
		Debug.Log("Turning " + this.Name + "'s outlines orange.");
		this.ID = 0;
		while (this.ID < this.Outlines.Length)
		{
			if (this.Outlines[this.ID] != null)
			{
				this.Outlines[this.ID].color = new Color(1f, 0.5f, 0f, 1f);
				this.Outlines[this.ID].enabled = true;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.RiggedAccessoryOutlines.Length)
		{
			if (this.RiggedAccessoryOutlines[this.ID] != null)
			{
				this.RiggedAccessoryOutlines[this.ID].color = new Color(1f, 0.5f, 0f, 1f);
				this.RiggedAccessoryOutlines[this.ID].enabled = this.Outlines[0].enabled;
			}
			this.ID++;
		}
	}

	// Token: 0x06001E41 RID: 7745 RVA: 0x0019A9B0 File Offset: 0x00198BB0
	public void AddOutlineToHair()
	{
		if (this.Cosmetic.HairRenderer != null)
		{
			if (this.Cosmetic.HairRenderer.GetComponent<OutlineScript>() == null)
			{
				this.Cosmetic.HairRenderer.gameObject.AddComponent<OutlineScript>();
			}
			this.Outlines[1] = this.Cosmetic.HairRenderer.gameObject.GetComponent<OutlineScript>();
			if (this.Outlines[1].h == null)
			{
				this.Outlines[1].Awake();
			}
			this.Outlines[1].color = this.Outlines[0].color;
			this.Outlines[1].enabled = this.Outlines[0].enabled;
			this.Outlines[1].h.enabled = this.Outlines[1].enabled;
		}
		if (this.Teacher && this.StudentManager.Eighties && this.EightiesTeacherAttacher != null && this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != null)
		{
			if (this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.gameObject.GetComponent<OutlineScript>() == null)
			{
				this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.gameObject.AddComponent<OutlineScript>();
			}
			this.MyRenderer = this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
			this.Outlines[0] = this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.gameObject.GetComponent<OutlineScript>();
			this.Outlines[0].color = this.Outlines[1].color;
			if (this.Outlines[0].h == null)
			{
				this.Outlines[0].Awake();
			}
		}
	}

	// Token: 0x06001E42 RID: 7746 RVA: 0x0019AB8C File Offset: 0x00198D8C
	public void PickRandomAnim()
	{
		if (this.Grudge)
		{
			this.RandomAnim = this.BulliedIdleAnim;
			return;
		}
		if (this.Club != ClubType.Delinquent)
		{
			this.RandomAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
			return;
		}
		this.RandomAnim = this.DelinquentAnims[UnityEngine.Random.Range(0, this.DelinquentAnims.Length)];
	}

	// Token: 0x06001E43 RID: 7747 RVA: 0x0019ABF0 File Offset: 0x00198DF0
	private void PickRandomGossipAnim()
	{
		if (this.Grudge)
		{
			this.RandomAnim = this.BulliedIdleAnim;
			return;
		}
		this.RandomGossipAnim = this.GossipAnims[UnityEngine.Random.Range(0, this.GossipAnims.Length)];
		if (this.Actions[this.Phase] == StudentActionType.Gossip && this.DistanceToPlayer < 3f)
		{
			if (!ConversationGlobals.GetTopicDiscovered(19))
			{
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
				ConversationGlobals.SetTopicDiscovered(19, true);
			}
			if (!ConversationGlobals.GetTopicLearnedByStudent(19, this.StudentID))
			{
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(19, this.StudentID, true);
			}
		}
	}

	// Token: 0x06001E44 RID: 7748 RVA: 0x0019AC9C File Offset: 0x00198E9C
	private void PickRandomSleuthAnim()
	{
		if (!this.Sleuthing)
		{
			this.RandomSleuthAnim = this.SleuthAnims[UnityEngine.Random.Range(0, 3)];
			return;
		}
		this.RandomSleuthAnim = this.SleuthAnims[UnityEngine.Random.Range(3, 6)];
	}

	// Token: 0x06001E45 RID: 7749 RVA: 0x0019ACD0 File Offset: 0x00198ED0
	private void BecomeTeacher()
	{
		base.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
		this.StudentManager.Teachers[this.Class] = this;
		if (this.Class != 1)
		{
			this.GradingPaper = this.StudentManager.FacultyDesks[this.Class];
			if (this.StudentID == 94 && this.StudentManager.Eighties && this.StudentManager.Week > 1)
			{
				this.GradingPaper.enabled = false;
				this.GradingPaper = this.StudentManager.FacultyDesks[1];
			}
			this.GradingPaper.LeftHand = this.LeftHand.parent;
			this.GradingPaper.Character = this.Character;
			this.GradingPaper.Teacher = this;
			this.SkirtCollider.gameObject.SetActive(false);
			this.LowPoly.MyMesh = this.LowPoly.TeacherMesh;
			this.PantyCollider.enabled = false;
		}
		if (this.Class > 1)
		{
			this.VisionDistance = 12f * this.Paranoia;
			base.name = "Teacher_" + this.Class.ToString() + "_" + this.Name;
			this.OriginalIdleAnim = "f02_idleShort_00";
			this.IdleAnim = "f02_idleShort_00";
		}
		else if (this.Class == 1)
		{
			this.VisionDistance = 12f * this.Paranoia;
			this.PatrolAnim = "f02_idle_00";
			base.name = "Nurse_" + this.Name;
		}
		else
		{
			this.VisionDistance = 16f * this.Paranoia;
			this.PatrolAnim = "f02_stretch_00";
			base.name = "Coach_" + this.Name;
			this.OriginalIdleAnim = "f02_tsunIdle_00";
			this.IdleAnim = "f02_tsunIdle_00";
		}
		this.StruggleAnim = "f02_teacherStruggleB_00";
		this.StruggleWonAnim = "f02_teacherStruggleWinB_00";
		this.StruggleLostAnim = "f02_teacherStruggleLoseB_00";
		this.OriginallyTeacher = true;
		this.Spawned = true;
		this.Teacher = true;
		if (this.StudentID > 89 && this.StudentID < 98 && this.StudentManager.Eighties)
		{
			this.SmartPhone = this.EightiesPhone;
			if (this.StudentID != 97 && this.StudentID != 90)
			{
				this.EightiesTeacherAttacher.SetActive(true);
				this.MyRenderer.enabled = false;
			}
		}
		this.SmartPhone.SetActive(false);
		base.gameObject.tag = "Untagged";
	}

	// Token: 0x06001E46 RID: 7750 RVA: 0x0019AF6C File Offset: 0x0019916C
	public void RemoveShoes()
	{
		if (!this.Male)
		{
			this.MyRenderer.materials[0].mainTexture = this.Cosmetic.SocksTexture;
			this.MyRenderer.materials[1].mainTexture = this.Cosmetic.SocksTexture;
			return;
		}
		this.MyRenderer.materials[this.Cosmetic.UniformID].mainTexture = this.Cosmetic.SocksTexture;
	}

	// Token: 0x06001E47 RID: 7751 RVA: 0x0019AFE4 File Offset: 0x001991E4
	public void BecomeRagdoll()
	{
		if (this.BloodPool != null)
		{
			PromptScript component = this.BloodPool.GetComponent<PromptScript>();
			if (component != null)
			{
				Debug.Log("Re-enabling an object's prompt.");
				component.enabled = true;
			}
		}
		if (this.FollowTarget != null)
		{
			this.FollowTarget.Follower = null;
		}
		this.Meeting = false;
		if (this.Rival)
		{
			this.StudentManager.RivalEliminated = true;
			if (this.Follower != null && this.Follower.FollowTarget != null && this.StudentManager.LastKnownOsana.position == Vector3.zero)
			{
				this.StudentManager.LastKnownOsana.position = base.transform.position;
				this.Follower.Destinations[this.Follower.Phase] = this.StudentManager.LastKnownOsana;
				if (this.Follower.CurrentDestination == this.Follower.FollowTarget)
				{
					this.Follower.Pathfinding.target = this.StudentManager.LastKnownOsana;
					this.Follower.CurrentDestination = this.StudentManager.LastKnownOsana;
				}
			}
		}
		if (this.BikiniAttacher != null && this.BikiniAttacher.newRenderer != null)
		{
			this.BikiniAttacher.newRenderer.updateWhenOffscreen = true;
		}
		if (this.EightiesTeacherAttacher != null && this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != null)
		{
			this.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.updateWhenOffscreen = true;
		}
		if (this.LabcoatAttacher.newRenderer != null)
		{
			this.LabcoatAttacher.newRenderer.updateWhenOffscreen = true;
		}
		if (this.ApronAttacher.newRenderer != null)
		{
			this.ApronAttacher.newRenderer.updateWhenOffscreen = true;
		}
		if (this.Attacher.newRenderer != null)
		{
			this.Attacher.newRenderer.updateWhenOffscreen = true;
		}
		if (this.DrinkingFountain != null)
		{
			this.DrinkingFountain.Occupied = false;
		}
		if (!this.Ragdoll.enabled)
		{
			this.EmptyHands();
			if (this.Broken != null)
			{
				this.Broken.enabled = false;
				this.Broken.MyAudio.Stop();
			}
			if (this.Club == ClubType.Delinquent && this.MyWeapon != null)
			{
				this.MyWeapon.transform.parent = null;
				this.MyWeapon.MyCollider.enabled = true;
				this.MyWeapon.Prompt.enabled = true;
				Rigidbody component2 = this.MyWeapon.GetComponent<Rigidbody>();
				component2.constraints = RigidbodyConstraints.None;
				component2.isKinematic = false;
				component2.useGravity = true;
				this.MyWeapon = null;
			}
			if (this.StudentManager.ChaseCamera == this.ChaseCamera)
			{
				this.StudentManager.ChaseCamera = null;
			}
			this.Countdown.gameObject.SetActive(false);
			this.ChaseCamera.SetActive(false);
			if (this.Club == ClubType.Council)
			{
				this.Police.CouncilDeath = true;
			}
			if (this.WillChase)
			{
				this.Yandere.Chasers--;
			}
			ParticleSystem.EmissionModule emission = this.Hearts.emission;
			if (this.Following)
			{
				emission.enabled = false;
				this.FollowCountdown.gameObject.SetActive(false);
				this.Yandere.Follower = null;
				this.Yandere.Followers--;
				this.Following = false;
			}
			if (this == this.StudentManager.Reporter)
			{
				this.StudentManager.Reporter = null;
			}
			if (this.Pushed)
			{
				this.Police.SuicideStudent = base.gameObject;
				this.Police.SuicideID = this.StudentID;
				this.Police.SuicideScene = true;
				this.Ragdoll.Suicide = true;
				this.Police.Suicide = true;
			}
			if (!this.Tranquil)
			{
				StudentGlobals.SetStudentDying(this.StudentID, true);
				if (!this.Ragdoll.Burning && !this.Ragdoll.Disturbing)
				{
					if (this.Police == null)
					{
						this.Police = this.StudentManager.Police;
					}
					if (this.Police.Corpses < 0)
					{
						this.Police.Corpses = 0;
					}
					if (this.Police.Corpses < this.Police.CorpseList.Length)
					{
						this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
					}
					this.Police.Corpses++;
				}
			}
			if (!this.Male)
			{
				this.LiquidProjector.ignoreLayers = -2049;
				this.RightHandCollider.enabled = false;
				this.LeftHandCollider.enabled = false;
				this.PantyCollider.enabled = false;
				this.SkirtCollider.gameObject.SetActive(false);
			}
			this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			this.Ragdoll.AllColliders[10].isTrigger = false;
			this.NotFaceCollider.enabled = false;
			this.FaceCollider.enabled = false;
			this.MyController.enabled = false;
			emission.enabled = false;
			this.SpeechLines.Stop();
			if (this.MyRenderer.enabled)
			{
				this.MyRenderer.updateWhenOffscreen = true;
			}
			AIDestinationSetter component3 = base.GetComponent<AIDestinationSetter>();
			if (component3 != null)
			{
				component3.enabled = false;
			}
			this.Pathfinding.enabled = false;
			this.HipCollider.enabled = true;
			base.enabled = false;
			this.UnWet();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			this.Ragdoll.CharacterAnimation = this.CharacterAnimation;
			this.Ragdoll.DetectionMarker = this.DetectionMarker;
			this.Ragdoll.RightEyeOrigin = this.RightEyeOrigin;
			this.Ragdoll.LeftEyeOrigin = this.LeftEyeOrigin;
			this.Ragdoll.Electrocuted = this.Electrocuted;
			this.Ragdoll.NeckSnapped = this.NeckSnapped;
			this.Ragdoll.BreastSize = this.BreastSize;
			this.Ragdoll.EyeShrink = this.EyeShrink;
			this.Ragdoll.StudentID = this.StudentID;
			this.Ragdoll.Tranquil = this.Tranquil;
			this.Ragdoll.Burning = this.Burning;
			this.Ragdoll.Drowned = this.Drowned;
			this.Ragdoll.Yandere = this.Yandere;
			this.Ragdoll.Police = this.Police;
			this.Ragdoll.Pushed = this.Pushed;
			this.Ragdoll.Male = this.Male;
			if (!this.Tranquil)
			{
				this.Police.Deaths++;
			}
			if (!this.NoRagdoll)
			{
				this.Ragdoll.enabled = true;
			}
			if (this.Reputation == null)
			{
				this.Reputation = this.StudentManager.Reputation;
			}
			this.Reputation.PendingRep -= this.PendingRep;
			if (this.WitnessedMurder && this.Persona != PersonaType.Evil)
			{
				this.Police.Witnesses--;
			}
			this.UpdateOutlines();
			if (this.DetectionMarker != null)
			{
				this.DetectionMarker.Tex.enabled = false;
			}
			GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
			this.MapMarker.gameObject.layer = 10;
			base.tag = "Blood";
			this.LowPoly.transform.parent = this.Hips;
			this.LowPoly.transform.localPosition = new Vector3(0f, -1f, 0f);
			this.LowPoly.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		}
		if (this.SmartPhone.transform.parent == this.ItemParent)
		{
			this.SmartPhone.SetActive(false);
		}
	}

	// Token: 0x06001E48 RID: 7752 RVA: 0x0019B84C File Offset: 0x00199A4C
	public void GetWet()
	{
		if ((SchemeGlobals.GetSchemeStage(1) == 3 && this.Rival) || SchemeGlobals.GetSchemeStage(2) == 3 || this.StudentID == 2)
		{
			Debug.Log("A scheme-related character was just splashed with water.");
			SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) + 1);
			this.Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		this.TargetDistance = 1f;
		this.FocusOnYandere = false;
		this.BeenSplashed = true;
		this.BatheFast = true;
		this.LiquidProjector.gameObject.SetActive(true);
		this.LiquidProjector.enabled = true;
		this.Emetic = false;
		this.Sedated = false;
		this.Headache = false;
		this.Vomiting = false;
		this.DressCode = false;
		this.Reacted = false;
		this.Alarmed = false;
		if (this.Gas)
		{
			this.LiquidProjector.material.mainTexture = this.GasTexture;
		}
		else if (this.Bloody)
		{
			this.LiquidProjector.material.mainTexture = this.BloodTexture;
		}
		else if (this.DyedBrown)
		{
			this.LiquidProjector.material.mainTexture = this.BrownTexture;
		}
		else
		{
			this.LiquidProjector.material.mainTexture = this.WaterTexture;
		}
		this.ID = 0;
		while (this.ID < this.LiquidEmitters.Length)
		{
			ParticleSystem particleSystem = this.LiquidEmitters[this.ID];
			particleSystem.gameObject.SetActive(true);
			ParticleSystem.MainModule main = particleSystem.main;
			if (this.Gas)
			{
				main.startColor = new Color(1f, 1f, 0f, 1f);
			}
			else if (this.Bloody)
			{
				main.startColor = new Color(1f, 0f, 0f, 1f);
			}
			else if (this.DyedBrown)
			{
				main.startColor = new Color(0.5f, 0.25f, 0f, 1f);
			}
			else
			{
				main.startColor = new Color(0f, 1f, 1f, 1f);
			}
			this.ID++;
		}
		if (!this.Slave)
		{
			this.CharacterAnimation[this.SplashedAnim].speed = 1f;
			this.CharacterAnimation.CrossFade(this.SplashedAnim);
			this.Subtitle.UpdateLabel(this.SplashSubtitleType, 0, 1f);
			this.SpeechLines.Stop();
			this.Hearts.Stop();
			this.StopMeeting();
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.SplashTimer = 0f;
			this.SplashPhase = 1;
			this.BathePhase = 1;
			this.ForgetRadio();
			if (this.Distracting)
			{
				this.DistractionTarget.TargetedForDistraction = false;
				this.DistractionTarget.Octodog.SetActive(false);
				this.DistractionTarget.Distracted = false;
				this.Distracting = false;
				this.CanTalk = true;
			}
			if (this.Investigating)
			{
				this.Investigating = false;
			}
			this.SchoolwearUnavailable = true;
			this.SentToLocker = false;
			this.Distracted = true;
			this.Splashed = true;
			this.Routine = false;
			this.GoAway = false;
			this.Wet = true;
			if (this.Following)
			{
				this.FollowCountdown.gameObject.SetActive(false);
				this.Yandere.Follower = null;
				this.Yandere.Followers--;
				this.Following = false;
			}
			this.SpawnAlarmDisc();
			if (this.Club == ClubType.Cooking)
			{
				this.IdleAnim = this.OriginalIdleAnim;
				this.WalkAnim = this.OriginalWalkAnim;
				this.LeanAnim = this.OriginalLeanAnim;
				this.ClubActivityPhase = 0;
				this.ClubTimer = 0f;
			}
			if (this.ReturningMisplacedWeapon)
			{
				this.DropMisplacedWeapon();
			}
			this.EmptyHands();
		}
		this.Alarm = 0f;
		this.UpdateDetectionMarker();
	}

	// Token: 0x06001E49 RID: 7753 RVA: 0x0019BC60 File Offset: 0x00199E60
	public void UnWet()
	{
		this.ID = 0;
		while (this.ID < this.LiquidEmitters.Length)
		{
			this.LiquidEmitters[this.ID].gameObject.SetActive(false);
			this.ID++;
		}
	}

	// Token: 0x06001E4A RID: 7754 RVA: 0x0019BCAC File Offset: 0x00199EAC
	public void SetSplashes(bool Bool)
	{
		this.ID = 0;
		while (this.ID < this.SplashEmitters.Length)
		{
			this.SplashEmitters[this.ID].gameObject.SetActive(Bool);
			this.ID++;
		}
	}

	// Token: 0x06001E4B RID: 7755 RVA: 0x0019BCF8 File Offset: 0x00199EF8
	public void StopMeeting()
	{
		Debug.Log(this.Name + " has called the StopMeeting() function.");
		this.Prompt.Label[0].text = "     Talk";
		this.Pathfinding.canSearch = true;
		this.Pathfinding.canMove = true;
		this.DistanceToDestination = 100f;
		this.Drownable = false;
		this.BakeSale = false;
		this.Pushable = false;
		this.Meeting = false;
		this.CanTalk = true;
		this.StudentManager.UpdateMe(this.StudentID);
		this.MeetTimer = 0f;
		this.RemoveOfferHelpPrompt();
		if (this.Rival)
		{
			this.StudentManager.UpdateInfatuatedTargetDistances();
		}
	}

	// Token: 0x06001E4C RID: 7756 RVA: 0x0019BDAC File Offset: 0x00199FAC
	public void RemoveOfferHelpPrompt()
	{
		OfferHelpScript offerHelpScript = null;
		if (this.StudentManager.Eighties && this.StudentID == this.StudentManager.RivalID)
		{
			offerHelpScript = this.StudentManager.EightiesOfferHelp;
			this.StudentManager.LoveManager.RivalWaiting = false;
		}
		else if (this.StudentID == 11)
		{
			offerHelpScript = this.StudentManager.OsanaOfferHelp;
			this.StudentManager.LoveManager.RivalWaiting = false;
		}
		else if (this.StudentID == 30)
		{
			offerHelpScript = this.StudentManager.OfferHelp;
			this.StudentManager.LoveManager.RivalWaiting = false;
		}
		else if (this.StudentID == 5)
		{
			offerHelpScript = this.StudentManager.FragileOfferHelp;
		}
		if (offerHelpScript != null)
		{
			offerHelpScript.transform.position = Vector3.zero;
			offerHelpScript.enabled = false;
			offerHelpScript.Prompt.Hide();
			offerHelpScript.Prompt.enabled = false;
		}
	}

	// Token: 0x06001E4D RID: 7757 RVA: 0x0019BE98 File Offset: 0x0019A098
	public void Combust()
	{
		this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
		this.Police.Corpses++;
		GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
		this.MapMarker.gameObject.layer = 10;
		base.tag = "Blood";
		this.Dying = true;
		this.SpawnAlarmDisc();
		this.Character.GetComponent<Animation>().CrossFade(this.BurningAnim);
		this.CharacterAnimation[this.WetAnim].weight = 0f;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Ragdoll.BurningAnimation = true;
		this.Ragdoll.Disturbing = true;
		this.Ragdoll.Burning = true;
		this.WitnessedCorpse = false;
		this.Investigating = false;
		this.EatingSnack = false;
		this.DiscCheck = false;
		this.WalkBack = false;
		this.Alarmed = false;
		this.CanTalk = false;
		this.Fleeing = false;
		this.Routine = false;
		this.Reacted = false;
		this.Burning = true;
		this.Wet = false;
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.BurningClip;
		component.Play();
		this.LiquidProjector.enabled = false;
		this.UnWet();
		if (this.Following)
		{
			this.FollowCountdown.gameObject.SetActive(false);
			this.Yandere.Follower = null;
			this.Yandere.Followers--;
			this.Following = false;
		}
		this.ID = 0;
		while (this.ID < this.FireEmitters.Length)
		{
			this.FireEmitters[this.ID].gameObject.SetActive(true);
			this.ID++;
		}
		if (this.Attacked)
		{
			this.BurnTarget = this.Yandere.transform.position + this.Yandere.transform.forward;
			this.Attacked = false;
		}
	}

	// Token: 0x06001E4E RID: 7758 RVA: 0x0019C0B0 File Offset: 0x0019A2B0
	public void JojoReact()
	{
		UnityEngine.Object.Instantiate<GameObject>(this.JojoHitEffect, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
		if (!this.Dying)
		{
			this.Dying = true;
			this.SpawnAlarmDisc();
			this.CharacterAnimation.CrossFade(this.JojoReactAnim);
			this.CharacterAnimation[this.WetAnim].weight = 0f;
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
			this.WitnessedCorpse = false;
			this.Investigating = false;
			this.EatingSnack = false;
			this.DiscCheck = false;
			this.WalkBack = false;
			this.Alarmed = false;
			this.CanTalk = false;
			this.Fleeing = false;
			this.Routine = false;
			this.Reacted = false;
			this.Wet = false;
			base.GetComponent<AudioSource>().Play();
			if (this.Following)
			{
				this.FollowCountdown.gameObject.SetActive(false);
				this.Yandere.Follower = null;
				this.Yandere.Followers--;
				this.Following = false;
			}
		}
	}

	// Token: 0x06001E4F RID: 7759 RVA: 0x0019C1E8 File Offset: 0x0019A3E8
	private void Nude()
	{
		if (!this.Male)
		{
			this.PantyCollider.enabled = false;
			this.SkirtCollider.gameObject.SetActive(false);
		}
		if (!this.Male)
		{
			this.MyRenderer.sharedMesh = this.TowelMesh;
			if (this.Club == ClubType.Bully)
			{
				this.Cosmetic.DeactivateBullyAccessories();
			}
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[0].mainTexture = this.TowelTexture;
			this.MyRenderer.materials[1].mainTexture = this.TowelTexture;
			this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
			this.Cosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		}
		else
		{
			this.MyRenderer.sharedMesh = this.BaldNudeMesh;
			this.MyRenderer.materials[0].mainTexture = this.NudeTexture;
			this.MyRenderer.materials[1].mainTexture = null;
			this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTextures[this.SkinColor];
		}
		this.Cosmetic.RemoveCensor();
		if (!this.AoT)
		{
			if (this.Male)
			{
				this.ID = 0;
				while (this.ID < this.CensorSteam.Length)
				{
					this.CensorSteam[this.ID].SetActive(true);
					this.ID++;
				}
			}
		}
		else if (!this.Male)
		{
			this.MyRenderer.sharedMesh = this.BaldNudeMesh;
			this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTexture;
			this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
			this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		}
		else
		{
			this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTextures[this.SkinColor];
		}
		if (this.Club == ClubType.Cooking)
		{
			this.ApronAttacher.newRenderer.gameObject.SetActive(false);
			Debug.Log("We were told to disable this apron attacher...");
		}
	}

	// Token: 0x06001E50 RID: 7760 RVA: 0x0019C44C File Offset: 0x0019A64C
	public void ChangeSchoolwear()
	{
		this.ID = 0;
		while (this.ID < this.CensorSteam.Length)
		{
			this.CensorSteam[this.ID].SetActive(false);
			this.ID++;
		}
		if (this.Attacher.gameObject.activeInHierarchy)
		{
			this.Attacher.RemoveAccessory();
		}
		if (this.LabcoatAttacher.enabled)
		{
			UnityEngine.Object.Destroy(this.LabcoatAttacher.newRenderer);
			this.LabcoatAttacher.enabled = false;
		}
		if (!this.Male && this.BikiniAttacher.enabled)
		{
			UnityEngine.Object.Destroy(this.BikiniAttacher.newRenderer);
			this.BikiniAttacher.enabled = false;
			this.MyRenderer.enabled = true;
		}
		if (this.Schoolwear == 0)
		{
			this.Nude();
		}
		else if (this.Schoolwear == 1)
		{
			if (!this.Male)
			{
				this.Cosmetic.SetFemaleUniform();
				this.SkirtCollider.gameObject.SetActive(true);
				if (this.PantyCollider != null)
				{
					this.PantyCollider.enabled = true;
				}
				if (this.Club == ClubType.Bully)
				{
					this.Cosmetic.RightWristband.SetActive(true);
					this.Cosmetic.LeftWristband.SetActive(true);
					this.Cosmetic.Bookbag.SetActive(true);
					this.Cosmetic.Hoodie.SetActive(true);
				}
			}
			else
			{
				this.Cosmetic.SetMaleUniform();
			}
		}
		else if (this.Schoolwear == 2)
		{
			if (this.Club == ClubType.Sports)
			{
				this.MyRenderer.sharedMesh = this.SwimmingTrunks;
				this.MyRenderer.SetBlendShapeWeight(0, (float)(20 * (6 - this.ClubMemberID)));
				this.MyRenderer.SetBlendShapeWeight(1, (float)(20 * (6 - this.ClubMemberID)));
				this.MyRenderer.materials[0].mainTexture = this.Cosmetic.Trunks[this.StudentID];
				this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
				this.MyRenderer.materials[2].mainTexture = this.Cosmetic.Trunks[this.StudentID];
			}
			else
			{
				this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
				if (!this.Male)
				{
					if (this.Club == ClubType.Bully)
					{
						this.MyRenderer.materials[0].mainTexture = this.Cosmetic.GanguroSwimsuitTextures[this.BullyID];
						this.MyRenderer.materials[1].mainTexture = this.Cosmetic.GanguroSwimsuitTextures[this.BullyID];
						this.Cosmetic.RightWristband.SetActive(false);
						this.Cosmetic.LeftWristband.SetActive(false);
						this.Cosmetic.Bookbag.SetActive(false);
						this.Cosmetic.Hoodie.SetActive(false);
					}
					else
					{
						this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
						this.MyRenderer.materials[1].mainTexture = this.SwimsuitTexture;
					}
					this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
					this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
					this.MyRenderer.materials[2].mainTexture = this.SwimsuitTexture;
				}
			}
		}
		else if (this.Schoolwear == 3)
		{
			this.MyRenderer.sharedMesh = this.GymUniform;
			if (this.StudentManager.Eighties)
			{
				this.GymTexture = this.EightiesGymTexture;
				Debug.Log("Setting the GymTexture to the EightiesGymTexture.");
			}
			else
			{
				Debug.Log("Not setting the GymTexture to the EightiesGymTexture.");
			}
			if (!this.Male)
			{
				this.MyRenderer.materials[0].mainTexture = this.GymTexture;
				this.MyRenderer.materials[1].mainTexture = this.GymTexture;
				this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
				if (this.Club == ClubType.Bully)
				{
					this.Cosmetic.ActivateBullyAccessories();
				}
			}
			else
			{
				this.MyRenderer.materials[0].mainTexture = this.GymTexture;
				this.MyRenderer.materials[2].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinColor];
				this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
			}
		}
		if (!this.Male)
		{
			this.Cosmetic.Stockings = ((this.Schoolwear == 1) ? this.Cosmetic.OriginalStockings : string.Empty);
			base.StartCoroutine(this.Cosmetic.PutOnStockings());
			if (GameGlobals.CensorPanties)
			{
				this.Cosmetic.CensorPanties();
			}
		}
		while (this.ID < this.Outlines.Length)
		{
			if (this.Outlines[this.ID] != null && this.Outlines[this.ID].h != null)
			{
				this.Outlines[this.ID].h.ReinitMaterials();
			}
			this.ID++;
		}
		if (this.Club == ClubType.Cooking)
		{
			this.ApronAttacher.newRenderer.gameObject.SetActive(true);
		}
		this.WalkAnim = this.OriginalWalkAnim;
	}

	// Token: 0x06001E51 RID: 7761 RVA: 0x0019C9F8 File Offset: 0x0019ABF8
	public void AttackOnTitan()
	{
		this.CharacterAnimation.CrossFade(this.WalkAnim);
		this.Nape.enabled = true;
		this.Blind = true;
		this.Hurry = true;
		this.AoT = true;
		this.TargetDistance = 5f;
		this.SprintAnim = this.WalkAnim;
		this.RunAnim = this.WalkAnim;
		this.MyController.center = new Vector3(this.MyController.center.x, 0.0825f, this.MyController.center.z);
		this.MyController.radius = 0.015f;
		this.MyController.height = 0.15f;
		if (!this.Male)
		{
			this.Cosmetic.FaceTexture = this.TitanFaceTexture;
		}
		else
		{
			this.Cosmetic.FaceTextures[this.SkinColor] = this.TitanFaceTexture;
		}
		this.NudeTexture = this.TitanBodyTexture;
		this.Nude();
		this.ID = 0;
		while (this.ID < this.Outlines.Length)
		{
			if (this.Outlines[this.ID] != null)
			{
				OutlineScript outlineScript = this.Outlines[this.ID];
				if (outlineScript.h == null)
				{
					outlineScript.Awake();
				}
				outlineScript.h.ReinitMaterials();
			}
			this.ID++;
		}
		if (!this.Male && !this.Teacher)
		{
			this.PantyCollider.enabled = false;
			this.SkirtCollider.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001E52 RID: 7762 RVA: 0x0019CB8C File Offset: 0x0019AD8C
	public void Spook()
	{
		if (!this.Male)
		{
			this.RightEye.gameObject.SetActive(false);
			this.LeftEye.gameObject.SetActive(false);
			this.MyRenderer.enabled = false;
			this.ID = 0;
			while (this.ID < this.Bones.Length)
			{
				this.Bones[this.ID].SetActive(true);
				this.ID++;
			}
		}
	}

	// Token: 0x06001E53 RID: 7763 RVA: 0x0019CC0C File Offset: 0x0019AE0C
	private void Unspook()
	{
		this.MyRenderer.enabled = true;
		this.ID = 0;
		while (this.ID < this.Bones.Length)
		{
			this.Bones[this.ID].SetActive(false);
			this.ID++;
		}
	}

	// Token: 0x06001E54 RID: 7764 RVA: 0x0019CC60 File Offset: 0x0019AE60
	private void GoChange()
	{
		if (!this.Male)
		{
			this.CurrentDestination = this.StudentManager.StrippingPositions[this.GirlID];
			this.Pathfinding.target = this.StudentManager.StrippingPositions[this.GirlID];
		}
		else
		{
			this.CurrentDestination = this.StudentManager.MaleStripSpot;
			this.Pathfinding.target = this.StudentManager.MaleStripSpot;
		}
		this.Pathfinding.canSearch = true;
		this.Pathfinding.canMove = true;
		this.Distracted = false;
	}

	// Token: 0x06001E55 RID: 7765 RVA: 0x0019CCF4 File Offset: 0x0019AEF4
	public void SpawnAlarmDisc()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity);
		gameObject.GetComponent<AlarmDiscScript>().Male = this.Male;
		gameObject.GetComponent<AlarmDiscScript>().Originator = this;
		if (this.Splashed)
		{
			gameObject.GetComponent<AlarmDiscScript>().Shocking = true;
			gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
		}
		if (this.Struggling || this.Shoving || this.MurderSuicidePhase == 100 || this.StudentManager.CombatMinigame.Delinquent == this)
		{
			gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
		}
		if (this.Club == ClubType.Delinquent)
		{
			gameObject.GetComponent<AlarmDiscScript>().Delinquent = true;
		}
		if (this.Dying && this.Yandere.Equipped > 0 && this.Yandere.EquippedWeapon.WeaponID == 7)
		{
			gameObject.GetComponent<AlarmDiscScript>().Long = true;
		}
	}

	// Token: 0x06001E56 RID: 7766 RVA: 0x0019CDF0 File Offset: 0x0019AFF0
	public void SpawnSmallAlarmDisc()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity);
		gameObject.transform.localScale = new Vector3(100f, 1f, 100f);
		gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
	}

	// Token: 0x06001E57 RID: 7767 RVA: 0x0019CE4C File Offset: 0x0019B04C
	public void ChangeClubwear()
	{
		if (!this.ClubAttire)
		{
			this.Cosmetic.RemoveCensor();
			this.DistanceToDestination = 100f;
			this.ClubAttire = true;
			if (this.Club == ClubType.Art)
			{
				if (!this.Attacher.gameObject.activeInHierarchy)
				{
					this.Attacher.gameObject.SetActive(true);
				}
				else
				{
					this.Attacher.Start();
				}
			}
			else if (this.Club == ClubType.MartialArts)
			{
				this.MyRenderer.sharedMesh = this.JudoGiMesh;
				if (!this.Male)
				{
					this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTexture;
					this.MyRenderer.materials[1].mainTexture = this.JudoGiTexture;
					this.MyRenderer.materials[2].mainTexture = this.JudoGiTexture;
					this.SkirtCollider.gameObject.SetActive(false);
					this.PantyCollider.enabled = false;
					this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.JudoGiTexture;
					this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
					this.MyRenderer.materials[2].mainTexture = this.JudoGiTexture;
				}
			}
			else if (this.Club == ClubType.Science)
			{
				this.WearLabCoat();
			}
			else if (this.Club == ClubType.Sports)
			{
				if (this.Clock.Period < 3 || this.StudentManager.PoolClosed)
				{
					if (this.StudentManager.Eighties)
					{
						this.GymTexture = this.EightiesGymTexture;
					}
					this.MyRenderer.sharedMesh = this.GymUniform;
					if (this.Male)
					{
						this.MyRenderer.materials[0].mainTexture = this.GymTexture;
						this.MyRenderer.materials[2].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinID];
						this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
					}
					else
					{
						this.MyRenderer.materials[0].mainTexture = this.GymTexture;
						this.MyRenderer.materials[1].mainTexture = this.GymTexture;
						this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
					}
					if (this.Armband != null)
					{
						this.Armband.transform.localPosition = new Vector3(-0.1f, 0f, -0.005f);
						Physics.SyncTransforms();
					}
				}
				else
				{
					if (this.Armband != null)
					{
						this.Armband.transform.localPosition = new Vector3(-0.1f, -0.01f, 0f);
						Physics.SyncTransforms();
					}
					this.MyRenderer.sharedMesh = this.SwimmingTrunks;
					if (this.Male)
					{
						this.MyRenderer.sharedMesh = this.SwimmingTrunks;
						this.MyRenderer.SetBlendShapeWeight(0, (float)(20 * (6 - this.ClubMemberID)));
						this.MyRenderer.materials[0].mainTexture = this.Cosmetic.Trunks[this.StudentID];
						this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
						this.MyRenderer.materials[2].mainTexture = this.Cosmetic.Trunks[this.StudentID];
					}
					else
					{
						this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
						if (!this.Male)
						{
							this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
							this.MyRenderer.materials[1].mainTexture = this.SwimsuitTexture;
							this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
						}
					}
					this.ClubAnim = "poolDive_00";
					this.ClubActivityPhase = 15;
					this.Destinations[this.Phase] = this.StudentManager.Clubs.List[this.StudentID].GetChild(this.ClubActivityPhase);
				}
			}
			if (this.StudentID == 46)
			{
				this.Armband.transform.localPosition = new Vector3(this.Armband.transform.localPosition.x, this.Armband.transform.localPosition.y, 0.01f);
				this.Armband.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
				return;
			}
		}
		else
		{
			this.ClubAttire = false;
			if (this.Club == ClubType.Art)
			{
				this.Attacher.RemoveAccessory();
				return;
			}
			if (this.Club == ClubType.Science)
			{
				this.WearLabCoat();
				return;
			}
			this.ChangeSchoolwear();
			if (this.StudentID == 46)
			{
				this.Armband.transform.localPosition = new Vector3(-0.1f, 0f, 0f);
				this.Armband.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
				return;
			}
			if (this.StudentID == 47)
			{
				this.StudentManager.ConvoManager.Confirmed = false;
				this.ClubAnim = "idle_20";
				return;
			}
			if (this.StudentID == 49)
			{
				this.StudentManager.ConvoManager.Confirmed = false;
				this.ClubAnim = "f02_idle_20";
			}
		}
	}

	// Token: 0x06001E58 RID: 7768 RVA: 0x0019D3F8 File Offset: 0x0019B5F8
	private void WearLabCoat()
	{
		if (this.LabcoatAttacher.enabled)
		{
			if (!this.Male)
			{
				this.RightBreast.gameObject.name = "RightBreastRENAMED";
				this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
				this.SkirtCollider.gameObject.SetActive(true);
				this.PantyCollider.enabled = true;
			}
			UnityEngine.Object.Destroy(this.LabcoatAttacher.newRenderer);
			this.LabcoatAttacher.enabled = false;
			this.ChangeSchoolwear();
			return;
		}
		this.MyRenderer.sharedMesh = this.HeadAndHands;
		this.LabcoatAttacher.enabled = true;
		if (!this.Male)
		{
			this.RightBreast.gameObject.name = "RightBreastRENAMED";
			this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
		}
		if (this.LabcoatAttacher.Initialized)
		{
			this.LabcoatAttacher.AttachAccessory();
		}
		if (!this.Male)
		{
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTexture;
			this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
			this.MyRenderer.materials[2].mainTexture = null;
			this.Cosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			this.SkirtCollider.gameObject.SetActive(false);
			this.PantyCollider.enabled = false;
			return;
		}
		this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTextures[this.SkinColor];
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
	}

	// Token: 0x06001E59 RID: 7769 RVA: 0x0019D5F0 File Offset: 0x0019B7F0
	public void WearBikini()
	{
		if (!this.BikiniAttacher.enabled)
		{
			this.BikiniAttacher.enabled = true;
			this.MyRenderer.enabled = false;
			this.RightBreast.gameObject.name = "RightBreastRENAMED";
			this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
			if (this.BikiniAttacher.Initialized)
			{
				this.BikiniAttacher.AttachAccessory();
			}
			this.Cosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			this.SkirtCollider.gameObject.SetActive(false);
			this.PantyCollider.enabled = false;
			return;
		}
		this.MyRenderer.enabled = true;
		this.RightBreast.gameObject.name = "RightBreastRENAMED";
		this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
		this.SkirtCollider.gameObject.SetActive(true);
		this.PantyCollider.enabled = true;
		UnityEngine.Object.Destroy(this.BikiniAttacher.newRenderer);
		this.BikiniAttacher.enabled = false;
		this.ChangeSchoolwear();
	}

	// Token: 0x06001E5A RID: 7770 RVA: 0x0019D71C File Offset: 0x0019B91C
	public void AttachRiggedAccessory()
	{
		this.RiggedAccessory.GetComponent<RiggedAccessoryAttacher>().ID = this.StudentID;
		if (this.Cosmetic.Accessory > 0)
		{
			this.Cosmetic.FemaleAccessories[this.Cosmetic.Accessory].SetActive(false);
		}
		if (this.StudentID == 26)
		{
			this.MyRenderer.sharedMesh = this.NoArmsNoTorso;
		}
		this.RiggedAccessory.SetActive(true);
	}

	// Token: 0x06001E5B RID: 7771 RVA: 0x0019D794 File Offset: 0x0019B994
	public void CameraReact()
	{
		this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		this.Pathfinding.canSearch = false;
		this.Pathfinding.canMove = false;
		this.Obstacle.enabled = true;
		this.CameraReacting = true;
		this.CameraReactPhase = 1;
		this.SpeechLines.Stop();
		this.Routine = false;
		this.StopPairing();
		if (!this.Sleuthing)
		{
			this.SmartPhone.SetActive(false);
		}
		this.OccultBook.SetActive(false);
		this.Scrubber.SetActive(false);
		this.Eraser.SetActive(false);
		this.Pen.SetActive(false);
		this.Pencil.SetActive(false);
		this.Sketchbook.SetActive(false);
		if (this.Club == ClubType.Gardening)
		{
			if (!this.StudentManager.Eighties)
			{
				this.WateringCan.transform.parent = this.Hips;
				this.WateringCan.transform.localPosition = new Vector3(0f, 0.0135f, -0.184f);
				this.WateringCan.transform.localEulerAngles = new Vector3(0f, 90f, 30f);
			}
		}
		else if (this.Club == ClubType.LightMusic)
		{
			if (this.StudentID == 51)
			{
				if (this.InstrumentBag[this.ClubMemberID].transform.parent == null)
				{
					this.Instruments[this.ClubMemberID].transform.parent = null;
					if (!this.StudentManager.Eighties)
					{
						this.Instruments[this.ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
						this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
					}
					else
					{
						this.Instruments[this.ClubMemberID].transform.position = new Vector3(2.105f, 4.5f, 25.5f);
						this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
					}
					this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
					this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
				}
				else
				{
					this.Instruments[this.ClubMemberID].SetActive(false);
				}
			}
			else
			{
				this.Instruments[this.ClubMemberID].SetActive(false);
			}
			this.Drumsticks[0].SetActive(false);
			this.Drumsticks[1].SetActive(false);
		}
		foreach (GameObject gameObject in this.ScienceProps)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
		foreach (GameObject gameObject2 in this.Fingerfood)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
		}
		if (!this.Yandere.ClubAccessories[7].activeInHierarchy || this.Club == ClubType.Delinquent)
		{
			this.CharacterAnimation.CrossFade(this.CameraAnims[1]);
		}
		else
		{
			if (this.Club == ClubType.Bully)
			{
				this.SmartPhone.SetActive(true);
			}
			this.CharacterAnimation.CrossFade(this.IdleAnim);
		}
		this.EmptyHands();
	}

	// Token: 0x06001E5C RID: 7772 RVA: 0x0019DB05 File Offset: 0x0019BD05
	private void LookForYandere()
	{
		if (!this.Yandere.Chased && this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition))
		{
			this.ReportPhase++;
		}
	}

	// Token: 0x06001E5D RID: 7773 RVA: 0x0019DB40 File Offset: 0x0019BD40
	public void UpdatePerception()
	{
		if ((this.Yandere != null && this.Yandere.Club == ClubType.Occult) || (this.Yandere != null && this.Yandere.Class.StealthBonus > 0))
		{
			this.Perception = 0.5f;
		}
		else
		{
			this.Perception = 1f;
		}
		this.ChameleonCheck();
		if (this.Chameleon)
		{
			this.Perception *= 0.5f;
		}
	}

	// Token: 0x06001E5E RID: 7774 RVA: 0x0019DBC4 File Offset: 0x0019BDC4
	public void StopInvestigating()
	{
		Debug.Log(this.Name + " was investigating something, but has stopped.");
		this.Giggle = null;
		if (!this.Sleuthing)
		{
			this.CurrentDestination = this.Destinations[this.Phase];
			this.Pathfinding.target = this.Destinations[this.Phase];
			if (this.Actions[this.Phase] == StudentActionType.Sunbathe && this.SunbathePhase > 1)
			{
				this.CurrentDestination = this.StudentManager.SunbatheSpots[this.StudentID];
				this.Pathfinding.target = this.StudentManager.SunbatheSpots[this.StudentID];
			}
		}
		else
		{
			this.CurrentDestination = this.SleuthTarget;
			this.Pathfinding.target = this.SleuthTarget;
		}
		this.InvestigationTimer = 0f;
		this.InvestigationPhase = 0;
		if (!this.Hurry)
		{
			this.Pathfinding.speed = this.WalkSpeed;
		}
		else
		{
			Debug.Log("Sprinting because Hurry is true and investigation has ended.");
			this.Pathfinding.speed = 4f;
		}
		if (this.CurrentAction == StudentActionType.Clean)
		{
			this.SmartPhone.SetActive(false);
			this.Scrubber.SetActive(true);
			if (this.CleaningRole == 5)
			{
				this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
				this.Eraser.SetActive(true);
			}
		}
		this.YandereInnocent = false;
		this.Investigating = false;
		this.EatingSnack = false;
		this.HeardScream = false;
		this.DiscCheck = false;
		this.Routine = true;
	}

	// Token: 0x06001E5F RID: 7775 RVA: 0x0019DD60 File Offset: 0x0019BF60
	public void ForgetGiggle()
	{
		Debug.Log("For some reason, " + this.Name + " was just told to ForgetGiggle() and stop investigating.");
		this.Giggle = null;
		this.InvestigationTimer = 0f;
		this.InvestigationPhase = 0;
		this.YandereInnocent = false;
		this.Investigating = false;
		this.DiscCheck = false;
	}

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06001E60 RID: 7776 RVA: 0x0019DDB5 File Offset: 0x0019BFB5
	public bool InCouple
	{
		get
		{
			return this.CoupleID > 0;
		}
	}

	// Token: 0x06001E61 RID: 7777 RVA: 0x0019DDC0 File Offset: 0x0019BFC0
	private bool LovedOneIsTargeted(int yandereTargetID)
	{
		bool flag = this.StudentID == this.StudentManager.SuitorID && yandereTargetID == this.StudentManager.RivalID;
		if (!this.StudentManager.Eighties)
		{
			bool flag2 = this.InCouple && this.PartnerID == yandereTargetID;
			bool flag3 = this.StudentID == 3 && yandereTargetID == 2;
			bool flag4 = this.StudentID == 2 && yandereTargetID == 3;
			bool flag5 = this.StudentID == 38 && yandereTargetID == 37;
			bool flag6 = this.StudentID == 37 && yandereTargetID == 38;
			bool flag7 = this.StudentID == 30 && yandereTargetID == 25;
			bool flag8 = this.StudentID == 25 && yandereTargetID == 30;
			bool flag9 = this.StudentID == 28 && yandereTargetID == 30;
			bool flag10 = false;
			bool flag11 = this.StudentID > 55 && this.StudentID < 61 && yandereTargetID > 55 && yandereTargetID < 61;
			if (this.Injured)
			{
				flag10 = (this.Club == ClubType.Delinquent && this.StudentManager.Students[yandereTargetID].Club == ClubType.Delinquent);
			}
			return flag2 || flag3 || flag4 || flag5 || flag6 || flag7 || flag8 || flag9 || flag10 || flag11 || flag;
		}
		bool flag12 = this.Male && yandereTargetID == 19;
		return flag || flag12;
	}

	// Token: 0x06001E62 RID: 7778 RVA: 0x0019DF28 File Offset: 0x0019C128
	private void Pose()
	{
		this.StudentManager.PoseMode.ChoosingAction = true;
		this.StudentManager.PoseMode.Panel.enabled = true;
		this.StudentManager.PoseMode.Student = this;
		this.StudentManager.PoseMode.UpdateLabels();
		this.StudentManager.PoseMode.Show = true;
		this.DialogueWheel.PromptBar.ClearButtons();
		this.DialogueWheel.PromptBar.Label[0].text = "Confirm";
		this.DialogueWheel.PromptBar.Label[1].text = "Back";
		this.DialogueWheel.PromptBar.Label[4].text = "Change";
		this.DialogueWheel.PromptBar.Label[5].text = "Increase/Decrease";
		this.DialogueWheel.PromptBar.UpdateButtons();
		this.DialogueWheel.PromptBar.Show = true;
		this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
		this.Yandere.CanMove = false;
		this.Posing = true;
	}

	// Token: 0x06001E63 RID: 7779 RVA: 0x0019E064 File Offset: 0x0019C264
	public void DisableEffects()
	{
		this.LiquidProjector.enabled = false;
		this.ElectroSteam[0].SetActive(false);
		this.ElectroSteam[1].SetActive(false);
		this.ElectroSteam[2].SetActive(false);
		this.ElectroSteam[3].SetActive(false);
		this.CensorSteam[0].SetActive(false);
		this.CensorSteam[1].SetActive(false);
		this.CensorSteam[2].SetActive(false);
		this.CensorSteam[3].SetActive(false);
		ParticleSystem[] array = this.LiquidEmitters;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(false);
		}
		array = this.FireEmitters;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(false);
		}
		this.ID = 0;
		while (this.ID < this.Bones.Length)
		{
			if (this.Bones[this.ID] != null)
			{
				this.Bones[this.ID].SetActive(false);
			}
			this.ID++;
		}
		if (this.Persona != PersonaType.PhoneAddict)
		{
			this.SmartPhone.SetActive(false);
		}
		this.Note.SetActive(false);
		if (!this.Slave)
		{
			UnityEngine.Object.Destroy(this.Broken);
		}
	}

	// Token: 0x06001E64 RID: 7780 RVA: 0x0019E1B8 File Offset: 0x0019C3B8
	public void DetermineSenpaiReaction()
	{
		Debug.Log("We are now determining Senpai's reaction to Yandere-chan's behavior.");
		if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
			return;
		}
		if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiWeaponReaction, 1, 4.5f);
			return;
		}
		if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
			return;
		}
		if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
			return;
		}
		if (this.Witnessed == StudentWitnessType.Weapon)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiWeaponReaction, 1, 4.5f);
			return;
		}
		if (this.Witnessed == StudentWitnessType.Blood)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiBloodReaction, 1, 4.5f);
			return;
		}
		if (this.Witnessed == StudentWitnessType.Insanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
			return;
		}
		if (this.Witnessed == StudentWitnessType.Lewd)
		{
			Debug.Log("Senpai is supposed to choose the ''Lewd'' reaction now.");
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiLewdReaction, 1, 4.5f);
			return;
		}
		if (this.GameOverCause == GameOverType.Stalking)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiStalkingReaction, this.Concern, 4.5f);
			return;
		}
		if (this.GameOverCause == GameOverType.Murder)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiMurderReaction, this.MurderReaction, 4.5f);
			return;
		}
		if (this.GameOverCause == GameOverType.Violence)
		{
			this.Subtitle.UpdateLabel(SubtitleType.SenpaiViolenceReaction, 1, 4.5f);
		}
	}

	// Token: 0x06001E65 RID: 7781 RVA: 0x0019E348 File Offset: 0x0019C548
	public void ForgetRadio()
	{
		bool flag = false;
		if (this.CurrentAction == StudentActionType.Sunbathe && this.SunbathePhase > 2)
		{
			this.SunbathePhase = 2;
			flag = true;
		}
		if ((this.Persona == PersonaType.PhoneAddict && !this.Phoneless && !flag) || this.Persona == PersonaType.Sleuth || this.StudentID == 20)
		{
			this.SmartPhone.SetActive(true);
		}
		this.TurnOffRadio = false;
		this.RadioTimer = 0f;
		this.RadioPhase = 1;
		this.Routine = true;
		this.Radio = null;
	}

	// Token: 0x06001E66 RID: 7782 RVA: 0x0019E3D0 File Offset: 0x0019C5D0
	public void RealizePhoneIsMissing()
	{
		this.Phoneless = true;
		ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
		scheduleBlock.destination = "Search Patrol";
		scheduleBlock.action = "Search Patrol";
		ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[4];
		scheduleBlock2.destination = "Search Patrol";
		scheduleBlock2.action = "Search Patrol";
		ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[7];
		scheduleBlock3.destination = "Search Patrol";
		scheduleBlock3.action = "Search Patrol";
		this.GetDestinations();
	}

	// Token: 0x06001E67 RID: 7783 RVA: 0x0019E444 File Offset: 0x0019C644
	public void TeleportToDestination()
	{
		this.GetDestinations();
		int phase = this.Phase;
		if (this.Phase < this.ScheduleBlocks.Length && this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time)
		{
			this.Phase++;
			if (this.Actions[this.Phase] == StudentActionType.Patrol)
			{
				this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
				this.Pathfinding.target = this.CurrentDestination;
			}
			else
			{
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.Destinations[this.Phase];
			}
			base.transform.position = this.CurrentDestination.position;
		}
	}

	// Token: 0x06001E68 RID: 7784 RVA: 0x0019E530 File Offset: 0x0019C730
	public void AltTeleportToDestination()
	{
		if (this.Club != ClubType.Council)
		{
			this.Phase++;
			if (this.Club == ClubType.Bully)
			{
				ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
				scheduleBlock.destination = "Patrol";
				scheduleBlock.action = "Patrol";
			}
			this.GetDestinations();
			this.CurrentAction = this.Actions[this.Phase];
			if (this.CurrentAction == StudentActionType.Patrol)
			{
				this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
				this.Pathfinding.target = this.CurrentDestination;
				base.transform.position = this.CurrentDestination.position;
				return;
			}
			if (this.Destinations[this.Phase] != null)
			{
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.Destinations[this.Phase];
				base.transform.position = this.CurrentDestination.position;
			}
		}
	}

	// Token: 0x06001E69 RID: 7785 RVA: 0x0019E648 File Offset: 0x0019C848
	public void GoCommitMurder()
	{
		Debug.Log("A mind-broken slave has just been instructed to go kill somebody.");
		this.StudentManager.MurderTakingPlace = true;
		this.StudentManager.MindBrokenSlave = this;
		this.StudentManager.UpdateTeachers();
		if (!this.FragileSlave)
		{
			this.Yandere.EquippedWeapon.transform.parent = this.HipCollider.transform;
			this.Yandere.EquippedWeapon.transform.localPosition = Vector3.zero;
			this.Yandere.EquippedWeapon.transform.localScale = Vector3.zero;
			this.MyWeapon = this.Yandere.EquippedWeapon;
			this.MyWeapon.FingerprintID = this.StudentID;
			this.Yandere.EquippedWeapon = null;
			this.Yandere.Equipped = 0;
			this.StudentManager.UpdateStudents(0);
			this.Yandere.WeaponManager.UpdateLabels();
			this.Yandere.WeaponMenu.UpdateSprites();
			this.Yandere.WeaponWarning = false;
		}
		else
		{
			this.StudentManager.FragileWeapon.transform.parent = this.HipCollider.transform;
			this.StudentManager.FragileWeapon.transform.localPosition = Vector3.zero;
			this.StudentManager.FragileWeapon.transform.localScale = Vector3.zero;
			this.MyWeapon = this.StudentManager.FragileWeapon;
			this.MyWeapon.FingerprintID = this.StudentID;
			this.MyWeapon.MyCollider.enabled = false;
		}
		this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		this.CharacterAnimation.CrossFade("f02_brokenStandUp_00");
		if (this.HuntTarget != this)
		{
			this.DistanceToDestination = 100f;
			this.Broken.Hunting = true;
			this.TargetDistance = 1f;
			this.Routine = false;
			this.Hunting = true;
		}
		else
		{
			this.Broken.Done = true;
			this.Routine = false;
			this.Suicide = true;
		}
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	// Token: 0x06001E6A RID: 7786 RVA: 0x0019E86C File Offset: 0x0019CA6C
	public void Shove()
	{
		if (!this.Yandere.Shoved && !this.Dying && !this.Yandere.Egg && !this.Yandere.Lifting && !this.Yandere.SneakingShot && !this.ShoeRemoval.enabled && !this.Yandere.Talking && !this.SentToLocker)
		{
			this.ForgetRadio();
			base.GetComponent<AudioSource>();
			if (this.StudentID == 86)
			{
				this.Subtitle.UpdateLabel(SubtitleType.Shoving, 1, 5f);
			}
			else if (this.StudentID == 87)
			{
				this.Subtitle.UpdateLabel(SubtitleType.Shoving, 2, 5f);
			}
			else if (this.StudentID == 88)
			{
				this.Subtitle.UpdateLabel(SubtitleType.Shoving, 3, 5f);
			}
			else if (this.StudentID == 89)
			{
				this.Subtitle.UpdateLabel(SubtitleType.Shoving, 4, 5f);
			}
			if (this.Yandere.Aiming)
			{
				this.Yandere.StopAiming();
			}
			if (this.Yandere.Laughing)
			{
				this.Yandere.StopLaughing();
			}
			if (this.Yandere.Stance.Current != StanceType.Standing)
			{
				this.Yandere.Stance.Current = StanceType.Standing;
				this.Yandere.CrawlTimer = 0f;
				this.Yandere.Uncrouch();
			}
			base.transform.rotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
			this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
			this.CharacterAnimation[this.ShoveAnim].time = 0f;
			this.CharacterAnimation.CrossFade(this.ShoveAnim);
			this.FocusOnYandere = false;
			this.Investigating = false;
			this.Distracted = true;
			this.Alarmed = false;
			this.Routine = false;
			this.Shoving = true;
			this.NoTalk = false;
			this.Patience--;
			if (this.StudentManager.BloodReporter == this)
			{
				this.StudentManager.BloodReporter = null;
				this.ReportingBlood = false;
			}
			if (this.WitnessedBloodPool && this.Club == ClubType.Delinquent)
			{
				this.StudentManager.CombatMinigame.ExitSchoolWhenDone = true;
			}
			this.WitnessedBloodyWeapon = false;
			this.WitnessedBloodPool = false;
			this.WitnessedSomething = false;
			this.WitnessedMurder = false;
			this.WitnessedWeapon = false;
			this.WitnessedLimb = false;
			this.BloodPool = null;
			if (this.Club != ClubType.Council && this.Persona != PersonaType.Violent)
			{
				this.Patience = 999;
			}
			if (this.Patience < 1)
			{
				this.Yandere.CannotRecover = true;
			}
			if (this.ReturningMisplacedWeapon)
			{
				this.DropMisplacedWeapon();
			}
			this.Yandere.CharacterAnimation["f02_shoveA_01"].time = 0f;
			this.Yandere.CharacterAnimation.CrossFade("f02_shoveA_01");
			this.Yandere.YandereVision = false;
			this.Yandere.NearSenpai = false;
			this.Yandere.Degloving = false;
			this.Yandere.Flicking = false;
			this.Yandere.Punching = false;
			this.Yandere.CanMove = false;
			this.Yandere.Shoved = true;
			this.Yandere.EmptyHands();
			this.Yandere.GloveTimer = 0f;
			this.Yandere.h = 0f;
			this.Yandere.v = 0f;
			this.Yandere.ShoveSpeed = 2f;
			if (this.Distraction != null)
			{
				this.TargetedForDistraction = false;
				this.Pathfinding.speed = this.WalkSpeed;
				this.SpeechLines.Stop();
				this.Distraction = null;
				this.CanTalk = true;
			}
			if (this.Actions[this.Phase] != StudentActionType.Patrol)
			{
				this.CurrentDestination = this.Destinations[this.Phase];
				this.Pathfinding.target = this.CurrentDestination;
			}
			this.Pathfinding.canSearch = false;
			this.Pathfinding.canMove = false;
		}
	}

	// Token: 0x06001E6B RID: 7787 RVA: 0x0019ED50 File Offset: 0x0019CF50
	public void PushYandereAway()
	{
		if (this.Yandere.Aiming)
		{
			this.Yandere.StopAiming();
		}
		if (this.Yandere.Laughing)
		{
			this.Yandere.StopLaughing();
		}
		this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
		this.Yandere.CharacterAnimation["f02_shoveA_01"].time = 0f;
		this.Yandere.CharacterAnimation.CrossFade("f02_shoveA_01");
		this.Yandere.YandereVision = false;
		this.Yandere.NearSenpai = false;
		this.Yandere.Degloving = false;
		this.Yandere.Flicking = false;
		this.Yandere.Punching = false;
		this.Yandere.CanMove = false;
		this.Yandere.Shoved = true;
		this.Yandere.EmptyHands();
		this.Yandere.GloveTimer = 0f;
		this.Yandere.h = 0f;
		this.Yandere.v = 0f;
		this.Yandere.ShoveSpeed = 2f;
	}

	// Token: 0x06001E6C RID: 7788 RVA: 0x0019EED0 File Offset: 0x0019D0D0
	public void Spray()
	{
		Debug.Log(this.Name + " is trying to Spray Yandere-chan!");
		if (this.Yandere.Attacking)
		{
			this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
			return;
		}
		Debug.Log("1");
		bool flag = false;
		if (this.Yandere.DelinquentFighting && !this.NoBreakUp && !this.StudentManager.CombatMinigame.Delinquent.WitnessedMurder)
		{
			flag = true;
		}
		if (!flag)
		{
			Debug.Log("2");
			if (!this.Yandere.Sprayed && !this.Dying && !this.Blind && !this.Yandere.Egg && !this.Yandere.Dumping && !this.Yandere.Bathing && !this.Yandere.Noticed && !this.Yandere.CannotBeSprayed)
			{
				Debug.Log("3");
				if (this.SprayTimer > 0f)
				{
					this.SprayTimer = Mathf.MoveTowards(this.SprayTimer, 0f, Time.deltaTime);
				}
				else
				{
					AudioSource.PlayClipAtPoint(this.PepperSpraySFX, base.transform.position);
					if (this.StudentID == 86)
					{
						this.Subtitle.UpdateLabel(SubtitleType.Spraying, 1, 5f);
					}
					else if (this.StudentID == 87)
					{
						this.Subtitle.UpdateLabel(SubtitleType.Spraying, 2, 5f);
					}
					else if (this.StudentID == 88)
					{
						this.Subtitle.UpdateLabel(SubtitleType.Spraying, 3, 5f);
					}
					else if (this.StudentID == 89)
					{
						this.Subtitle.UpdateLabel(SubtitleType.Spraying, 4, 5f);
					}
					if (this.Yandere.Aiming)
					{
						this.Yandere.StopAiming();
					}
					if (this.Yandere.Laughing)
					{
						this.Yandere.StopLaughing();
					}
					base.transform.rotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
					this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
					Debug.Log("This is the exact moment that the character is being told to perform a spraying animation.");
					this.CharacterAnimation.CrossFade(this.SprayAnim);
					this.PepperSpray.SetActive(true);
					this.FocusOnYandere = false;
					this.Distracted = true;
					this.Spraying = true;
					this.Alarmed = false;
					this.Routine = false;
					this.Fleeing = true;
					this.Blind = true;
					this.Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
					this.Yandere.YandereVision = false;
					this.Yandere.NearSenpai = false;
					this.Yandere.Attacking = false;
					this.Yandere.FollowHips = true;
					this.Yandere.Punching = false;
					this.Yandere.CanMove = false;
					this.Yandere.Sprayed = true;
					this.Pathfinding.canSearch = false;
					this.Pathfinding.canMove = false;
					this.StudentManager.YandereDying = true;
					this.StudentManager.StopMoving();
					this.Yandere.Blur.Size = 1f;
					this.Yandere.Jukebox.Volume = 0f;
					if (this.Yandere.DelinquentFighting)
					{
						this.StudentManager.CombatMinigame.Stop();
					}
					this.DetectionMarker.gameObject.SetActive(false);
				}
			}
			else if (!this.Yandere.Sprayed)
			{
				this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
				if (this.Yandere.Egg)
				{
					this.Yandere.CanMove = true;
					this.Yandere.Chased = false;
					this.Yandere.Chasers = 0;
					this.BecomeRagdoll();
				}
			}
		}
		else
		{
			Debug.Log("A student council member is breaking up the fight.");
			if (this.StudentManager.CombatMinigame.Delinquent.Male)
			{
				this.StudentManager.CombatMinigame.Delinquent.CharacterAnimation.Play("stopFighting_00");
				this.StudentManager.CombatMinigame.StopFightingAnim = "stopFighting_00";
			}
			else
			{
				this.StudentManager.CombatMinigame.Delinquent.CharacterAnimation.Play("f02_stopFighting_00");
				this.StudentManager.CombatMinigame.StopFightingAnim = "f02_stopFighting_00";
			}
			this.Yandere.CharacterAnimation.Play("f02_stopFighting_00");
			this.Yandere.FightHasBrokenUp = true;
			this.Yandere.BreakUpTimer = 10f;
			this.StudentManager.CombatMinigame.Path = 7;
			this.StudentManager.Portal.SetActive(true);
			if (!this.BreakingUpFight && this.Club == ClubType.Council)
			{
				this.Subtitle.UpdateLabel(SubtitleType.BreakingUp, this.ClubMemberID, 5f);
			}
			this.CharacterAnimation.Play(this.BreakUpAnim);
			this.BreakingUpFight = true;
			this.SprayTimer = 1f;
		}
		this.StudentManager.CombatMinigame.DisablePrompts();
		this.StudentManager.CombatMinigame.MyVocals.Stop();
		this.StudentManager.CombatMinigame.MyAudio.Stop();
		Time.timeScale = 1f;
	}

	// Token: 0x06001E6D RID: 7789 RVA: 0x0019F4D0 File Offset: 0x0019D6D0
	private void DetermineCorpseLocation()
	{
		Debug.Log(this.Name + " has called the DetermineCorpseLocation() function.");
		if (this.StudentManager.Reporter == null)
		{
			this.StudentManager.Reporter = this;
		}
		if (this.Teacher)
		{
			this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
			this.StudentManager.CorpseLocation.LookAt(new Vector3(base.transform.position.x, this.StudentManager.CorpseLocation.position.y, base.transform.position.z));
			this.StudentManager.CorpseLocation.Translate(this.StudentManager.CorpseLocation.forward);
			this.StudentManager.LowerCorpsePosition();
		}
		this.Pathfinding.target = this.StudentManager.CorpseLocation;
		this.CurrentDestination = this.StudentManager.CorpseLocation;
		this.AssignCorpseGuardLocations();
	}

	// Token: 0x06001E6E RID: 7790 RVA: 0x0019F5E8 File Offset: 0x0019D7E8
	private void DetermineBloodLocation()
	{
		if (this.StudentManager.BloodReporter == null)
		{
			this.StudentManager.BloodReporter = this;
		}
		if (this.Teacher)
		{
			this.StudentManager.BloodLocation.position = this.BloodPool.transform.position;
			this.StudentManager.BloodLocation.LookAt(new Vector3(base.transform.position.x, this.StudentManager.BloodLocation.position.y, base.transform.position.z));
			this.StudentManager.BloodLocation.Translate(this.StudentManager.BloodLocation.forward);
			this.StudentManager.LowerBloodPosition();
		}
	}

	// Token: 0x06001E6F RID: 7791 RVA: 0x0019F6B4 File Offset: 0x0019D8B4
	private void AssignCorpseGuardLocations()
	{
		this.StudentManager.CorpseGuardLocation[1].position = this.StudentManager.CorpseLocation.position + new Vector3(0f, 0f, 1f);
		this.LookAway(this.StudentManager.CorpseGuardLocation[1], this.StudentManager.CorpseLocation);
		this.StudentManager.CorpseGuardLocation[2].position = this.StudentManager.CorpseLocation.position + new Vector3(1f, 0f, 0f);
		this.LookAway(this.StudentManager.CorpseGuardLocation[2], this.StudentManager.CorpseLocation);
		this.StudentManager.CorpseGuardLocation[3].position = this.StudentManager.CorpseLocation.position + new Vector3(0f, 0f, -1f);
		this.LookAway(this.StudentManager.CorpseGuardLocation[3], this.StudentManager.CorpseLocation);
		this.StudentManager.CorpseGuardLocation[4].position = this.StudentManager.CorpseLocation.position + new Vector3(-1f, 0f, 0f);
		this.LookAway(this.StudentManager.CorpseGuardLocation[4], this.StudentManager.CorpseLocation);
	}

	// Token: 0x06001E70 RID: 7792 RVA: 0x0019F828 File Offset: 0x0019DA28
	private void AssignBloodGuardLocations()
	{
		this.StudentManager.BloodGuardLocation[1].position = this.StudentManager.BloodLocation.position + new Vector3(0f, 0f, 1f);
		this.LookAway(this.StudentManager.BloodGuardLocation[1], this.StudentManager.BloodLocation);
		this.StudentManager.BloodGuardLocation[2].position = this.StudentManager.BloodLocation.position + new Vector3(1f, 0f, 0f);
		this.LookAway(this.StudentManager.BloodGuardLocation[2], this.StudentManager.BloodLocation);
		this.StudentManager.BloodGuardLocation[3].position = this.StudentManager.BloodLocation.position + new Vector3(0f, 0f, -1f);
		this.LookAway(this.StudentManager.BloodGuardLocation[3], this.StudentManager.BloodLocation);
		this.StudentManager.BloodGuardLocation[4].position = this.StudentManager.BloodLocation.position + new Vector3(-1f, 0f, 0f);
		this.LookAway(this.StudentManager.BloodGuardLocation[4], this.StudentManager.BloodLocation);
	}

	// Token: 0x06001E71 RID: 7793 RVA: 0x0019F99C File Offset: 0x0019DB9C
	private void AssignTeacherGuardLocations()
	{
		this.StudentManager.TeacherGuardLocation[1].position = this.StudentManager.CorpseLocation.position + new Vector3(0.75f, 0f, 0.75f);
		this.LookAway(this.StudentManager.TeacherGuardLocation[1], this.StudentManager.CorpseLocation);
		this.StudentManager.TeacherGuardLocation[2].position = this.StudentManager.CorpseLocation.position + new Vector3(0.75f, 0f, -0.75f);
		this.LookAway(this.StudentManager.TeacherGuardLocation[2], this.StudentManager.CorpseLocation);
		this.StudentManager.TeacherGuardLocation[3].position = this.StudentManager.CorpseLocation.position + new Vector3(-0.75f, 0f, -0.75f);
		this.LookAway(this.StudentManager.TeacherGuardLocation[3], this.StudentManager.CorpseLocation);
		this.StudentManager.TeacherGuardLocation[4].position = this.StudentManager.CorpseLocation.position + new Vector3(-0.75f, 0f, 0.75f);
		this.LookAway(this.StudentManager.TeacherGuardLocation[4], this.StudentManager.CorpseLocation);
		this.StudentManager.TeacherGuardLocation[5].position = this.StudentManager.CorpseLocation.position + new Vector3(0f, 0f, 0.5f);
		this.LookAway(this.StudentManager.TeacherGuardLocation[5], this.StudentManager.CorpseLocation);
		this.StudentManager.TeacherGuardLocation[6].position = this.StudentManager.CorpseLocation.position + new Vector3(0f, 0f, -0.5f);
		this.LookAway(this.StudentManager.TeacherGuardLocation[6], this.StudentManager.CorpseLocation);
	}

	// Token: 0x06001E72 RID: 7794 RVA: 0x0019FBC0 File Offset: 0x0019DDC0
	private void LookAway(Transform T1, Transform T2)
	{
		T1.LookAt(T2);
		float y = T1.eulerAngles.y + 180f;
		T1.eulerAngles = new Vector3(T1.eulerAngles.x, y, T1.eulerAngles.z);
	}

	// Token: 0x06001E73 RID: 7795 RVA: 0x0019FC08 File Offset: 0x0019DE08
	public void TurnToStone()
	{
		this.Cosmetic.RightEyeRenderer.material.mainTexture = this.Yandere.Stone;
		this.Cosmetic.LeftEyeRenderer.material.mainTexture = this.Yandere.Stone;
		this.Cosmetic.HairRenderer.material.mainTexture = this.Yandere.Stone;
		if (this.Cosmetic.HairRenderer.materials.Length > 1)
		{
			this.Cosmetic.HairRenderer.materials[1].mainTexture = this.Yandere.Stone;
		}
		this.Cosmetic.RightEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
		this.Cosmetic.LeftEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
		this.Cosmetic.HairRenderer.material.color = new Color(1f, 1f, 1f, 1f);
		this.MyRenderer.materials[0].mainTexture = this.Yandere.Stone;
		this.MyRenderer.materials[1].mainTexture = this.Yandere.Stone;
		this.MyRenderer.materials[2].mainTexture = this.Yandere.Stone;
		if (this.Teacher && this.Cosmetic.TeacherAccessories[8].activeInHierarchy)
		{
			this.MyRenderer.materials[3].mainTexture = this.Yandere.Stone;
		}
		if (this.PickPocket != null)
		{
			this.PickPocket.enabled = false;
			this.PickPocket.Prompt.Hide();
			this.PickPocket.Prompt.enabled = false;
		}
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		UnityEngine.Object.Destroy(this.DetectionMarker.gameObject);
		AudioSource.PlayClipAtPoint(this.Yandere.Petrify, base.transform.position + new Vector3(0f, 1f, 0f));
		UnityEngine.Object.Instantiate<GameObject>(this.Yandere.Pebbles, this.Hips.position, Quaternion.identity);
		this.Pathfinding.enabled = false;
		this.ShoeRemoval.enabled = false;
		this.CharacterAnimation.Stop();
		this.Prompt.enabled = false;
		this.SpeechLines.Stop();
		this.Prompt.Hide();
		base.enabled = false;
	}

	// Token: 0x06001E74 RID: 7796 RVA: 0x0019FEEC File Offset: 0x0019E0EC
	public void StopPairing()
	{
		if (this.Actions[this.Phase] != StudentActionType.Clean && this.Persona == PersonaType.PhoneAddict && !this.Phoneless && !this.LostTeacherTrust)
		{
			this.WalkAnim = this.PhoneAnims[1];
		}
		this.Spawned = true;
		this.Paired = false;
	}

	// Token: 0x06001E75 RID: 7797 RVA: 0x0019FF40 File Offset: 0x0019E140
	public void ChameleonCheck()
	{
		this.ChameleonBonus = 0f;
		this.Chameleon = false;
		if (this.Yandere != null && ((this.Yandere.Persona == YanderePersonaType.Scholarly && this.Persona == PersonaType.TeachersPet) || (this.Yandere.Persona == YanderePersonaType.Scholarly && this.Club == ClubType.Science) || (this.Yandere.Persona == YanderePersonaType.Scholarly && this.Club == ClubType.Art) || (this.Yandere.Persona == YanderePersonaType.Chill && this.Persona == PersonaType.SocialButterfly) || (this.Yandere.Persona == YanderePersonaType.Chill && this.Club == ClubType.Photography) || (this.Yandere.Persona == YanderePersonaType.Chill && this.Club == ClubType.Gaming) || (this.Yandere.Persona == YanderePersonaType.Confident && this.Persona == PersonaType.Heroic) || (this.Yandere.Persona == YanderePersonaType.Confident && this.Club == ClubType.MartialArts) || (this.Yandere.Persona == YanderePersonaType.Elegant && this.Club == ClubType.Drama) || (this.Yandere.Persona == YanderePersonaType.Girly && this.Persona == PersonaType.SocialButterfly) || (this.Yandere.Persona == YanderePersonaType.Girly && this.Club == ClubType.Cooking) || (this.Yandere.Persona == YanderePersonaType.Graceful && this.Club == ClubType.Gardening) || (this.Yandere.Persona == YanderePersonaType.Haughty && this.Club == ClubType.Bully) || (this.Yandere.Persona == YanderePersonaType.Lively && this.Persona == PersonaType.SocialButterfly) || (this.Yandere.Persona == YanderePersonaType.Lively && this.Club == ClubType.LightMusic) || (this.Yandere.Persona == YanderePersonaType.Lively && this.Club == ClubType.Sports) || (this.Yandere.Persona == YanderePersonaType.Shy && this.Persona == PersonaType.Loner) || (this.Yandere.Persona == YanderePersonaType.Shy && this.Club == ClubType.Occult) || (this.Yandere.Persona == YanderePersonaType.Tough && this.Persona == PersonaType.Spiteful) || (this.Yandere.Persona == YanderePersonaType.Tough && this.Club == ClubType.Delinquent)))
		{
			Debug.Log("Chameleon is true!");
			this.ChameleonBonus = this.VisionDistance * 0.5f;
			this.Chameleon = true;
		}
	}

	// Token: 0x06001E76 RID: 7798 RVA: 0x001A0194 File Offset: 0x0019E394
	private void PhoneAddictGameOver()
	{
		if (!this.Yandere.Lost)
		{
			this.Yandere.CharacterAnimation.CrossFade("f02_down_22");
			this.Yandere.ShoulderCamera.HeartbrokenCamera.SetActive(true);
			this.Yandere.RPGCamera.enabled = false;
			this.Yandere.Jukebox.GameOver();
			this.Yandere.enabled = false;
			this.Yandere.EmptyHands();
			this.Countdown.gameObject.SetActive(false);
			this.ChaseCamera.SetActive(false);
			this.Police.Heartbroken.Exposed = true;
			this.StudentManager.StopMoving();
			this.Fleeing = false;
		}
	}

	// Token: 0x06001E77 RID: 7799 RVA: 0x001A0254 File Offset: 0x0019E454
	private void EndAlarm()
	{
		Debug.Log(this.Name + " has stopped being alarmed.");
		if (this.ReturnToRoutineAfter)
		{
			this.CurrentDestination = this.Destinations[this.Phase];
			this.Pathfinding.target = this.Destinations[this.Phase];
			this.ReturnToRoutineAfter = false;
		}
		this.Pathfinding.canSearch = true;
		this.Pathfinding.canMove = true;
		if (this.StudentID == 1 || this.Teacher)
		{
			this.IgnoreTimer = 0.0001f;
		}
		else
		{
			this.IgnoreTimer = 5f;
		}
		if (this.Persona == PersonaType.PhoneAddict && !this.Phoneless)
		{
			this.SmartPhone.SetActive(true);
		}
		this.FocusOnYandere = false;
		this.DiscCheck = false;
		this.Alarmed = false;
		this.Reacted = false;
		this.Hesitation = 0f;
		this.AlarmTimer = 0f;
		if (this.WitnessedCorpse)
		{
			this.PersonaReaction();
		}
		else if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
		{
			Debug.Log(this.Name + " will now investigate a suspicious object on the ground...");
			if (this.Following)
			{
				this.Hearts.emission.enabled = false;
				this.FollowCountdown.gameObject.SetActive(false);
				this.Yandere.Follower = null;
				this.Yandere.Followers--;
				this.Following = false;
			}
			this.CharacterAnimation.CrossFade(this.WalkAnim);
			this.CurrentDestination = this.BloodPool;
			this.Pathfinding.target = this.BloodPool;
			this.Pathfinding.canSearch = true;
			this.Pathfinding.canMove = true;
			this.Pathfinding.speed = this.WalkSpeed;
			this.InvestigatingBloodPool = true;
			this.Routine = false;
			this.IgnoreTimer = 0.0001f;
		}
		else if (!this.Following && !this.Wet && !this.Investigating)
		{
			this.Routine = true;
		}
		if (this.ResumeDistracting)
		{
			this.CharacterAnimation.CrossFade(this.WalkAnim);
			this.Distracting = true;
			this.Routine = false;
		}
		if (this.ResumeTakingOutTrash)
		{
			Debug.Log("This character was told to resume taking out the trash.");
			this.CharacterAnimation.CrossFade(this.WalkAnim);
			this.TakingOutTrash = true;
			this.Routine = false;
		}
		if (this.CurrentAction == StudentActionType.Clean)
		{
			this.SmartPhone.SetActive(false);
			this.Scrubber.SetActive(true);
			if (this.CleaningRole == 5)
			{
				this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
				this.Eraser.SetActive(true);
			}
		}
		if (this.TurnOffRadio)
		{
			this.Routine = false;
		}
	}

	// Token: 0x06001E78 RID: 7800 RVA: 0x001A0530 File Offset: 0x0019E730
	public void GetSleuthTarget()
	{
		this.TargetDistance = 2f;
		this.SleuthID++;
		if (this.SleuthID < 98)
		{
			if (this.StudentManager.Students[this.SleuthID] == null)
			{
				this.GetSleuthTarget();
				return;
			}
			if (!this.StudentManager.Students[this.SleuthID].gameObject.activeInHierarchy)
			{
				this.GetSleuthTarget();
				return;
			}
			if ((this.CurrentDestination != null && this.StudentManager.LockerRoomArea.bounds.Contains(this.CurrentDestination.position)) || (this.CurrentDestination != null && this.StudentManager.MaleLockerRoomArea.bounds.Contains(this.CurrentDestination.position)))
			{
				this.GetSleuthTarget();
				return;
			}
			this.SleuthTarget = this.StudentManager.Students[this.SleuthID].transform;
			this.Pathfinding.target = this.SleuthTarget;
			this.CurrentDestination = this.SleuthTarget;
			return;
		}
		else
		{
			if (this.SleuthID != 98)
			{
				this.SleuthID = 0;
				this.GetSleuthTarget();
				return;
			}
			if (this.Yandere.Club == ClubType.Photography)
			{
				this.SleuthID = 0;
				this.GetSleuthTarget();
				return;
			}
			this.SleuthTarget = this.Yandere.transform;
			this.Pathfinding.target = this.SleuthTarget;
			this.CurrentDestination = this.SleuthTarget;
			return;
		}
	}

	// Token: 0x06001E79 RID: 7801 RVA: 0x001A06B4 File Offset: 0x0019E8B4
	public void GetFoodTarget()
	{
		this.Attempts++;
		if (this.Attempts >= 100)
		{
			this.Phase++;
			return;
		}
		this.SleuthID++;
		if (this.SleuthID >= 90)
		{
			this.SleuthID = 0;
			this.GetFoodTarget();
			return;
		}
		if (this.SleuthID == this.StudentID)
		{
			this.GetFoodTarget();
			return;
		}
		if (this.StudentManager.Students[this.SleuthID] == null)
		{
			this.GetFoodTarget();
			return;
		}
		if (!this.StudentManager.Students[this.SleuthID].gameObject.activeInHierarchy)
		{
			this.GetFoodTarget();
			return;
		}
		if (this.StudentManager.Students[this.SleuthID].CurrentAction == StudentActionType.SitAndEatBento || this.StudentManager.Students[this.SleuthID].CurrentAction == StudentActionType.AtLocker || this.StudentManager.Students[this.SleuthID].CurrentDestination == this.StudentManager.Exit || this.StudentManager.Students[this.SleuthID].Club == ClubType.Cooking || this.StudentManager.Students[this.SleuthID].Club == ClubType.Delinquent || this.StudentManager.Students[this.SleuthID].Club == ClubType.Sports || this.StudentManager.Students[this.SleuthID].TargetedForDistraction || this.StudentManager.Students[this.SleuthID].ClubActivityPhase >= 16 || this.StudentManager.Students[this.SleuthID].InEvent || !this.StudentManager.Students[this.SleuthID].Routine || this.StudentManager.Students[this.SleuthID].Posing || this.StudentManager.Students[this.SleuthID].Slave || this.StudentManager.Students[this.SleuthID].Wet || this.StudentManager.Students[this.SleuthID].Sedated || (this.StudentManager.Students[this.SleuthID].Club == ClubType.LightMusic && this.StudentManager.PracticeMusic.isPlaying))
		{
			this.GetFoodTarget();
			return;
		}
		this.CharacterAnimation.CrossFade(this.WalkAnim);
		this.DistractionTarget = this.StudentManager.Students[this.SleuthID];
		this.DistractionTarget.TargetedForDistraction = true;
		this.SleuthTarget = this.StudentManager.Students[this.SleuthID].transform;
		this.Pathfinding.target = this.SleuthTarget;
		this.CurrentDestination = this.SleuthTarget;
		this.TargetDistance = 0.75f;
		this.DistractTimer = 8f;
		this.Distracting = true;
		this.CanTalk = false;
		this.Routine = false;
		this.Attempts = 0;
	}

	// Token: 0x06001E7A RID: 7802 RVA: 0x001A09D8 File Offset: 0x0019EBD8
	private void PhoneAddictCameraUpdate()
	{
		if (this.SmartPhone.transform.parent != null)
		{
			this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			if (!this.StudentManager.Eighties)
			{
				this.SmartPhone.transform.localPosition = new Vector3(0f, 0.005f, -0.01f);
				this.SmartPhone.transform.localEulerAngles = new Vector3(7.33333f, -154f, 173.66666f);
			}
			else
			{
				this.SmartPhone.transform.localPosition = new Vector3(0.085f, -0.0015f, 0.003f);
				this.SmartPhone.transform.localEulerAngles = new Vector3(-10f, 30f, 165f);
			}
			this.SmartPhone.SetActive(true);
			if (this.Sleuthing)
			{
				if (this.AlarmTimer < 2f)
				{
					this.AlarmTimer = 2f;
					this.ScaredAnim = this.SleuthReactAnim;
					this.SprintAnim = this.SleuthReportAnim;
					this.CharacterAnimation.CrossFade(this.ScaredAnim);
				}
				if (!this.CameraFlash.activeInHierarchy && this.CharacterAnimation[this.ScaredAnim].time > 2f)
				{
					this.CameraFlash.SetActive(true);
					if (this.Yandere.Mask != null)
					{
						this.Countdown.MaskedPhoto = true;
						return;
					}
				}
			}
			else
			{
				this.ScaredAnim = this.PhoneAnims[4];
				this.CharacterAnimation.CrossFade(this.ScaredAnim);
				if (!this.CameraFlash.activeInHierarchy && (double)this.CharacterAnimation[this.ScaredAnim].time > 3.66666)
				{
					this.CameraFlash.SetActive(true);
					if (this.Yandere.Mask != null)
					{
						this.Countdown.MaskedPhoto = true;
						return;
					}
					if (this.Grudge)
					{
						this.Police.PhotoEvidence++;
						this.PhotoEvidence = true;
					}
				}
			}
		}
	}

	// Token: 0x06001E7B RID: 7803 RVA: 0x001A0C00 File Offset: 0x0019EE00
	private void ReturnToRoutine()
	{
		if (this.Actions[this.Phase] == StudentActionType.Patrol)
		{
			this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
			this.Pathfinding.target = this.CurrentDestination;
		}
		else
		{
			this.CurrentDestination = this.Destinations[this.Phase];
			this.Pathfinding.target = this.Destinations[this.Phase];
		}
		this.UpdateOutlines();
		this.BreakingUpFight = false;
		this.WitnessedMurder = false;
		this.Prompt.enabled = true;
		this.Alarmed = false;
		this.Fleeing = false;
		this.Routine = true;
		this.Grudge = false;
		this.Pathfinding.speed = this.WalkSpeed;
	}

	// Token: 0x06001E7C RID: 7804 RVA: 0x001A0CD4 File Offset: 0x0019EED4
	public void EmptyHands()
	{
		bool flag = false;
		if ((this.SentHome && this.SmartPhone.activeInHierarchy) || this.PhotoEvidence || (this.Persona == PersonaType.PhoneAddict && !this.Dying && !this.Wet))
		{
			flag = true;
		}
		if (this.MyPlate != null && this.MyPlate.parent != null)
		{
			if (this.WitnessedMurder || this.WitnessedCorpse)
			{
				this.DropPlate();
			}
			else
			{
				this.MyPlate.gameObject.SetActive(false);
			}
		}
		if (this.Club == ClubType.Gardening && !this.StudentManager.Eighties)
		{
			this.WateringCan.transform.parent = this.Hips;
			this.WateringCan.transform.localPosition = new Vector3(0f, 0.0135f, -0.184f);
			this.WateringCan.transform.localEulerAngles = new Vector3(0f, 90f, 30f);
		}
		if (this.Club == ClubType.LightMusic)
		{
			if (this.StudentID == 51)
			{
				if (this.InstrumentBag[this.ClubMemberID].transform.parent == null)
				{
					this.Instruments[this.ClubMemberID].transform.parent = null;
					if (!this.StudentManager.Eighties)
					{
						this.Instruments[this.ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
						this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
					}
					else
					{
						this.Instruments[this.ClubMemberID].transform.position = new Vector3(2.105f, 4.5f, 25.5f);
						this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
					}
					this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
					this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
				}
				else
				{
					this.Instruments[this.ClubMemberID].SetActive(false);
				}
			}
			else
			{
				this.Instruments[this.ClubMemberID].SetActive(false);
			}
			this.Drumsticks[0].SetActive(false);
			this.Drumsticks[1].SetActive(false);
			this.AirGuitar.Stop();
		}
		if (!this.Male)
		{
			this.Handkerchief.SetActive(false);
			this.Cigarette.SetActive(false);
			this.Lighter.SetActive(false);
		}
		else
		{
			this.PinkSeifuku.SetActive(false);
		}
		if (!flag)
		{
			this.SmartPhone.SetActive(false);
		}
		if (this.BagOfChips != null)
		{
			this.BagOfChips.SetActive(false);
		}
		this.Chopsticks[0].SetActive(false);
		this.Chopsticks[1].SetActive(false);
		this.Sketchbook.SetActive(false);
		this.OccultBook.SetActive(false);
		this.Paintbrush.SetActive(false);
		this.EventBook.SetActive(false);
		this.Scrubber.SetActive(false);
		this.Octodog.SetActive(false);
		this.Palette.SetActive(false);
		this.Eraser.SetActive(false);
		this.Pencil.SetActive(false);
		this.Pen.SetActive(false);
		if (this.Bento.transform.parent != null)
		{
			this.Bento.SetActive(false);
		}
		foreach (GameObject gameObject in this.ScienceProps)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
		foreach (GameObject gameObject2 in this.Fingerfood)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
		}
	}

	// Token: 0x06001E7D RID: 7805 RVA: 0x001A10DC File Offset: 0x0019F2DC
	public void UpdateAnimLayers()
	{
		this.CharacterAnimation[this.LeanAnim].speed += (float)this.StudentID * 0.01f;
		this.CharacterAnimation[this.ConfusedSitAnim].speed += (float)this.StudentID * 0.01f;
		this.CharacterAnimation[this.WalkAnim].time = UnityEngine.Random.Range(0f, this.CharacterAnimation[this.WalkAnim].length);
		this.CharacterAnimation[this.WetAnim].layer = 9;
		this.CharacterAnimation.Play(this.WetAnim);
		this.CharacterAnimation[this.WetAnim].weight = 0f;
		if (!this.Male)
		{
			this.CharacterAnimation[this.StripAnim].speed = 1.5f;
			this.CharacterAnimation[this.GameAnim].speed = 2f;
			this.CharacterAnimation["f02_moLipSync_00"].layer = 9;
			this.CharacterAnimation.Play("f02_moLipSync_00");
			this.CharacterAnimation["f02_moLipSync_00"].weight = 0f;
			this.CharacterAnimation["f02_topHalfTexting_00"].layer = 8;
			this.CharacterAnimation.Play("f02_topHalfTexting_00");
			this.CharacterAnimation["f02_topHalfTexting_00"].weight = 0f;
			this.CharacterAnimation[this.CarryAnim].layer = 7;
			this.CharacterAnimation.Play(this.CarryAnim);
			this.CharacterAnimation[this.CarryAnim].weight = 0f;
			this.CharacterAnimation[this.SocialSitAnim].layer = 6;
			this.CharacterAnimation.Play(this.SocialSitAnim);
			this.CharacterAnimation[this.SocialSitAnim].weight = 0f;
			this.CharacterAnimation[this.ShyAnim].layer = 5;
			this.CharacterAnimation.Play(this.ShyAnim);
			this.CharacterAnimation[this.ShyAnim].weight = 0f;
			this.CharacterAnimation[this.FistAnim].layer = 4;
			this.CharacterAnimation[this.FistAnim].weight = 0f;
			this.CharacterAnimation[this.BentoAnim].layer = 3;
			this.CharacterAnimation.Play(this.BentoAnim);
			this.CharacterAnimation[this.BentoAnim].weight = 0f;
			this.CharacterAnimation[this.AngryFaceAnim].layer = 2;
			this.CharacterAnimation.Play(this.AngryFaceAnim);
			this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
			this.CharacterAnimation["f02_wetIdle_00"].speed = 1.25f;
			this.CharacterAnimation["f02_sleuthScan_00"].speed = 1.4f;
		}
		else
		{
			this.CharacterAnimation[this.ConfusedSitAnim].speed *= -1f;
			this.CharacterAnimation[this.ToughFaceAnim].layer = 7;
			this.CharacterAnimation.Play(this.ToughFaceAnim);
			this.CharacterAnimation[this.ToughFaceAnim].weight = 0f;
			this.CharacterAnimation[this.SocialSitAnim].layer = 6;
			this.CharacterAnimation.Play(this.SocialSitAnim);
			this.CharacterAnimation[this.SocialSitAnim].weight = 0f;
			this.CharacterAnimation[this.CarryShoulderAnim].layer = 5;
			this.CharacterAnimation.Play(this.CarryShoulderAnim);
			this.CharacterAnimation[this.CarryShoulderAnim].weight = 0f;
			this.CharacterAnimation["scaredFace_00"].layer = 4;
			this.CharacterAnimation.Play("scaredFace_00");
			this.CharacterAnimation["scaredFace_00"].weight = 0f;
			this.CharacterAnimation[this.SadFaceAnim].layer = 3;
			this.CharacterAnimation.Play(this.SadFaceAnim);
			this.CharacterAnimation[this.SadFaceAnim].weight = 0f;
			this.CharacterAnimation[this.AngryFaceAnim].layer = 2;
			this.CharacterAnimation.Play(this.AngryFaceAnim);
			this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
			this.CharacterAnimation["sleuthScan_00"].speed = 1.4f;
		}
		if (this.Persona == PersonaType.Sleuth)
		{
			this.CharacterAnimation[this.WalkAnim].time = UnityEngine.Random.Range(0f, this.CharacterAnimation[this.WalkAnim].length);
		}
		if (this.Club == ClubType.Bully)
		{
			if (!StudentGlobals.GetStudentBroken(this.StudentID) && this.BullyID > 1)
			{
				this.CharacterAnimation["f02_bullyLaugh_00"].speed = 0.9f + (float)this.BullyID * 0.1f;
			}
		}
		else if (this.Club == ClubType.Delinquent)
		{
			this.CharacterAnimation[this.WalkAnim].time = UnityEngine.Random.Range(0f, this.CharacterAnimation[this.WalkAnim].length);
			this.CharacterAnimation[this.LeanAnim].speed = 0.5f;
		}
		else if (this.Club == ClubType.Council)
		{
			if (!this.StudentManager.Eighties)
			{
				this.CharacterAnimation["f02_faceCouncil" + this.Suffix + "_00"].layer = 10;
				this.CharacterAnimation.Play("f02_faceCouncil" + this.Suffix + "_00");
			}
		}
		else if (this.Club == ClubType.Gaming)
		{
			this.CharacterAnimation[this.VictoryAnim].speed -= 0.1f * (float)(this.StudentID - 36);
			this.CharacterAnimation[this.VictoryAnim].speed = 0.866666f;
		}
		else if (this.Club == ClubType.Cooking && this.ClubActivityPhase > 0)
		{
			this.WalkAnim = this.PlateWalkAnim;
		}
		if (!this.StudentManager.Eighties)
		{
			if (this.StudentID == 36)
			{
				this.CharacterAnimation[this.ToughFaceAnim].weight = 1f;
				return;
			}
			if (this.StudentID == 66)
			{
				this.CharacterAnimation[this.ToughFaceAnim].weight = 1f;
			}
		}
	}

	// Token: 0x06001E7E RID: 7806 RVA: 0x001A1830 File Offset: 0x0019FA30
	private void SpawnDetectionMarker()
	{
		this.DetectionMarker = UnityEngine.Object.Instantiate<GameObject>(this.Marker, this.Yandere.DetectionPanel.transform.position, Quaternion.identity).GetComponent<DetectionMarkerScript>();
		if (this.StudentID == 1)
		{
			this.DetectionMarker.GetComponent<DetectionMarkerScript>().Tex.color = new Color(1f, 0f, 0f, 0f);
		}
		this.DetectionMarker.transform.parent = this.Yandere.DetectionPanel.transform;
		this.DetectionMarker.Target = base.transform;
	}

	// Token: 0x06001E7F RID: 7807 RVA: 0x001A18D8 File Offset: 0x0019FAD8
	public void EquipCleaningItems()
	{
		if (this.CurrentAction == StudentActionType.Clean)
		{
			if (!this.Phoneless && (this.Persona == PersonaType.PhoneAddict || this.Persona == PersonaType.Sleuth))
			{
				this.WalkAnim = this.OriginalWalkAnim;
			}
			this.SmartPhone.SetActive(false);
			this.Scrubber.SetActive(true);
			if (this.CleaningRole == 5)
			{
				this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
				this.Eraser.SetActive(true);
			}
			if (this.StudentID == 9 || this.StudentID == 60)
			{
				this.WalkAnim = this.OriginalOriginalWalkAnim;
			}
		}
	}

	// Token: 0x06001E80 RID: 7808 RVA: 0x001A1994 File Offset: 0x0019FB94
	public void DetermineWhatWasWitnessed()
	{
		if (this.Witnessed == StudentWitnessType.Murder)
		{
			Debug.Log("No need to go through the entire chain. We already know that this character witnessed murder.");
			this.Concern = 5;
		}
		else if (this.YandereVisible)
		{
			bool flag = false;
			if (this.Yandere.Bloodiness + (float)this.Yandere.GloveBlood > 0f && !this.Yandere.Paint)
			{
				flag = true;
			}
			bool flag2 = this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious;
			bool flag3 = this.Yandere.PickUp != null && this.Yandere.PickUp.Suspicious;
			bool flag4 = this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null;
			bool flag5 = this.Yandere.PickUp != null && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence;
			bool flag6 = false;
			if (!this.StudentManager.Eighties && this.StudentID == 48 && this.TaskPhase == 4 && this.Yandere.Armed && this.Yandere.EquippedWeapon.WeaponID == 12)
			{
				flag2 = false;
				flag6 = true;
			}
			int concern = this.Concern;
			if (flag2)
			{
				this.WeaponToTakeAway = this.Yandere.EquippedWeapon;
			}
			if (this.Yandere.Rummaging || this.Yandere.TheftTimer > 0f)
			{
				this.Witnessed = StudentWitnessType.Theft;
				this.Concern = 5;
			}
			else if (this.Yandere.Pickpocketing || this.Yandere.Caught)
			{
				Debug.Log("Saw Yandere-chan pickpocketing.");
				this.Witnessed = StudentWitnessType.Pickpocketing;
				this.Concern = 5;
				this.Yandere.StudentManager.PickpocketMinigame.Failure = true;
				this.Yandere.StudentManager.PickpocketMinigame.End();
				this.Yandere.Caught = true;
				if (this.Teacher)
				{
					this.Witnessed = StudentWitnessType.Theft;
				}
			}
			else if (flag2 && flag && this.Yandere.Sanity < 33.333f)
			{
				this.Police.EndOfDay.WeaponWitnessed++;
				this.Police.EndOfDay.BloodWitnessed++;
				this.Witnessed = StudentWitnessType.WeaponAndBloodAndInsanity;
				this.RepLoss = 30f;
				this.Concern = 5;
			}
			else if (flag2 && this.Yandere.Sanity < 33.333f)
			{
				this.Police.EndOfDay.WeaponWitnessed++;
				this.Witnessed = StudentWitnessType.WeaponAndInsanity;
				this.RepLoss = 20f;
				this.Concern = 5;
			}
			else if (flag && this.Yandere.Sanity < 33.333f)
			{
				this.Police.EndOfDay.BloodWitnessed++;
				this.Witnessed = StudentWitnessType.BloodAndInsanity;
				this.RepLoss = 20f;
				this.Concern = 5;
			}
			else if (flag2 && flag)
			{
				this.Police.EndOfDay.WeaponWitnessed++;
				this.Police.EndOfDay.BloodWitnessed++;
				this.Witnessed = StudentWitnessType.WeaponAndBlood;
				this.RepLoss = 20f;
				this.Concern = 5;
			}
			else if (flag2)
			{
				this.Police.EndOfDay.WeaponWitnessed++;
				this.WeaponWitnessed = this.Yandere.EquippedWeapon.WeaponID;
				this.Witnessed = StudentWitnessType.Weapon;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (flag3)
			{
				if (this.Yandere.PickUp.CleaningProduct)
				{
					if (this.StudentID == 1)
					{
						this.Witnessed = StudentWitnessType.Lewd;
					}
					else
					{
						this.Witnessed = StudentWitnessType.CleaningItem;
					}
				}
				else if (this.Teacher || this.Club == ClubType.Council)
				{
					this.Witnessed = StudentWitnessType.Insanity;
				}
				else
				{
					this.Witnessed = StudentWitnessType.Suspicious;
				}
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (flag)
			{
				this.Police.EndOfDay.BloodWitnessed++;
				this.Witnessed = StudentWitnessType.Blood;
				if (!this.Bloody)
				{
					this.RepLoss = 10f;
					this.Concern = 5;
				}
				else
				{
					this.RepLoss = 0f;
					this.Concern = 0;
				}
			}
			else if (this.Yandere.Sanity < 33.333f)
			{
				this.Witnessed = StudentWitnessType.Insanity;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (this.Yandere.Lewd)
			{
				this.Witnessed = StudentWitnessType.Lewd;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if ((this.Yandere.Laughing && this.Yandere.LaughIntensity > 15f) || (this.StudentID > 1 && this.Yandere.Stance.Current == StanceType.Crouching) || (this.Yandere.Stance.Current == StanceType.Crawling || this.Yandere.SuspiciousActionTimer > 0f || this.Yandere.WearingRaincoat || (this.Yandere.Carrying && this.Yandere.CurrentRagdoll.Concealed)) || (this.Yandere.Dragging && this.Yandere.CurrentRagdoll.Concealed) || (this.Yandere.Schoolwear == 2 && this.Yandere.transform.position.z < 30f))
			{
				if (this.StudentID == 1 && !this.Yandere.Laughing && this.Yandere.Sanity > 33f)
				{
					this.Witnessed = StudentWitnessType.Lewd;
				}
				else
				{
					this.Witnessed = StudentWitnessType.Insanity;
				}
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (this.Yandere.Poisoning)
			{
				this.Witnessed = StudentWitnessType.Poisoning;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (this.Yandere.Trespassing && this.StudentID > 1)
			{
				this.Witnessed = (this.Private ? StudentWitnessType.Interruption : StudentWitnessType.Trespassing);
				this.Witness = false;
				if (!this.Teacher)
				{
					this.RepLoss = 10f;
				}
				this.Concern++;
			}
			else if (this.Yandere.NearSenpai || (this.StudentID == 1 && this.Yandere.Stance.Current == StanceType.Crouching))
			{
				this.Witnessed = StudentWitnessType.Stalking;
				this.Concern++;
			}
			else if (this.Yandere.Eavesdropping)
			{
				if (this.StudentID == 1)
				{
					this.Witnessed = StudentWitnessType.Stalking;
					this.Concern++;
				}
				else
				{
					if (this.InEvent)
					{
						this.EventInterrupted = true;
					}
					this.Witnessed = StudentWitnessType.Eavesdropping;
					this.RepLoss = 10f;
					this.Concern = 5;
				}
			}
			else if (this.Yandere.Aiming)
			{
				this.Witnessed = StudentWitnessType.Stalking;
				this.Concern++;
			}
			else if (this.Yandere.DelinquentFighting)
			{
				this.Witnessed = StudentWitnessType.Violence;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (this.Yandere.PickUp != null && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence)
			{
				Debug.Log("Saw Yandere-chan with bloody clothing.");
				this.Witnessed = StudentWitnessType.HoldingBloodyClothing;
				this.RepLoss = 10f;
				this.Concern = 5;
			}
			else if (flag4 || flag5)
			{
				this.Witnessed = StudentWitnessType.CoverUp;
			}
			else if (flag6)
			{
				this.Subtitle.CustomText = "Is that dumbbell for me? Drop it over here!";
				this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
			}
			if ((this.StudentID == 1 || this.Club == ClubType.Council) && this.Witnessed == StudentWitnessType.Insanity && (this.Yandere.Stance.Current == StanceType.Crouching || this.Yandere.Stance.Current == StanceType.Crawling))
			{
				this.Witnessed = StudentWitnessType.Stalking;
				this.Concern = concern;
				this.Concern++;
			}
		}
		else
		{
			Debug.Log(this.Name + " is reacting to something other than Yandere-chan.");
			if (this.WitnessedLimb)
			{
				this.Witnessed = StudentWitnessType.SeveredLimb;
			}
			else if (this.WitnessedBloodyWeapon)
			{
				this.Witnessed = StudentWitnessType.BloodyWeapon;
			}
			else if (this.WitnessedBloodPool)
			{
				this.Witnessed = StudentWitnessType.BloodPool;
			}
			else if (this.WitnessedWeapon)
			{
				this.Witnessed = StudentWitnessType.DroppedWeapon;
			}
			else if (this.WitnessedCorpse)
			{
				this.Witnessed = StudentWitnessType.Corpse;
			}
			else
			{
				Debug.Log(this.Name + " was alarmed by something, but didn't see what it was...");
				this.Witnessed = StudentWitnessType.None;
				this.DiscCheck = true;
				this.Witness = false;
			}
		}
		if (this.Concern == 5 && this.Club == ClubType.Council && this.Yandere.Pursuer == null)
		{
			Debug.Log("A member of the student council is being transformed into a teacher.");
			this.Teacher = true;
		}
		if (this.StudentID > 1 && this.Witnessed != StudentWitnessType.None)
		{
			this.ID = 0;
			while (this.ID < this.Outlines.Length)
			{
				if (this.Outlines[this.ID] != null)
				{
					this.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
				}
				this.ID++;
			}
			this.ID = 0;
			while (this.ID < this.RiggedAccessoryOutlines.Length)
			{
				if (this.RiggedAccessoryOutlines[this.ID] != null)
				{
					this.RiggedAccessoryOutlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
					this.RiggedAccessoryOutlines[this.ID].enabled = this.Outlines[0].enabled;
				}
				this.ID++;
			}
		}
	}

	// Token: 0x06001E81 RID: 7809 RVA: 0x001A2400 File Offset: 0x001A0600
	public void DetermineTeacherSubtitle()
	{
		Debug.Log("We are now determining what line of dialogue the teacher should say.");
		if (this.Club == ClubType.Council)
		{
			this.Subtitle.UpdateLabel(SubtitleType.CouncilToCounselor, this.ClubMemberID, 5f);
			return;
		}
		if (this.Guarding)
		{
			if (this.Yandere.Bloodiness + (float)this.Yandere.GloveBlood > 0f && !this.Yandere.Paint)
			{
				this.Witnessed = StudentWitnessType.Blood;
			}
			else if (this.Yandere.Armed)
			{
				this.Witnessed = StudentWitnessType.Weapon;
			}
			else if (this.Yandere.Sanity < 66.66666f)
			{
				this.Witnessed = StudentWitnessType.Insanity;
			}
		}
		if (this.Witnessed == StudentWitnessType.Murder)
		{
			if (this.WitnessedMindBrokenMurder)
			{
				this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 4, 6f);
			}
			else
			{
				this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 1, 6f);
			}
			this.GameOverCause = GameOverType.Murder;
			this.WitnessedMurder = true;
			return;
		}
		if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
			this.GameOverCause = GameOverType.Insanity;
			this.WitnessedMurder = true;
			return;
		}
		if (this.Witnessed == StudentWitnessType.WeaponAndBlood)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponHostile, 1, 6f);
			this.GameOverCause = GameOverType.Weapon;
			this.WitnessedMurder = true;
			return;
		}
		if (this.Witnessed == StudentWitnessType.WeaponAndInsanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
			this.GameOverCause = GameOverType.Insanity;
			this.WitnessedMurder = true;
			return;
		}
		if (this.Witnessed == StudentWitnessType.BloodAndInsanity)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
			this.GameOverCause = GameOverType.Insanity;
			this.WitnessedMurder = true;
			return;
		}
		if (this.Witnessed == StudentWitnessType.Weapon)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponHostile, 1, 6f);
			this.GameOverCause = GameOverType.Weapon;
			this.WitnessedMurder = true;
			return;
		}
		if (this.Witnessed == StudentWitnessType.Blood)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherBloodHostile, 1, 6f);
			this.GameOverCause = GameOverType.Blood;
			this.WitnessedMurder = true;
			return;
		}
		if (this.Witnessed == StudentWitnessType.Insanity || this.Witnessed == StudentWitnessType.Poisoning)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
			this.GameOverCause = GameOverType.Insanity;
			this.WitnessedMurder = true;
			return;
		}
		if (this.Witnessed == StudentWitnessType.Lewd)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherLewdReaction, 1, 6f);
			this.GameOverCause = GameOverType.Lewd;
			return;
		}
		if (this.Witnessed == StudentWitnessType.Trespassing)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, this.Concern, 5f);
			return;
		}
		if (this.Witnessed == StudentWitnessType.Corpse)
		{
			Debug.Log("A teacher just discovered a corpse.");
			this.DetermineCorpseLocation();
			this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseReaction, 1, 3f);
			this.Police.Called = true;
			return;
		}
		if (this.Witnessed == StudentWitnessType.CoverUp)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherCoverUpHostile, 1, 6f);
			this.GameOverCause = GameOverType.Blood;
			this.WitnessedMurder = true;
			return;
		}
		if (this.Witnessed == StudentWitnessType.CleaningItem)
		{
			this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
			this.GameOverCause = GameOverType.Insanity;
		}
	}

	// Token: 0x06001E82 RID: 7810 RVA: 0x001A2728 File Offset: 0x001A0928
	public void ReturnMisplacedWeapon()
	{
		Debug.Log(this.Name + " has returned a misplaced weapon.");
		this.StopInvestigating();
		if (this.StudentManager.BloodReporter == this)
		{
			this.StudentManager.BloodReporter = null;
		}
		this.BloodPool.parent = null;
		this.BloodPool.position = this.BloodPool.GetComponent<WeaponScript>().StartingPosition;
		this.BloodPool.eulerAngles = this.BloodPool.GetComponent<WeaponScript>().StartingRotation;
		this.BloodPool.GetComponent<WeaponScript>().Prompt.enabled = true;
		this.BloodPool.GetComponent<WeaponScript>().enabled = true;
		this.BloodPool.GetComponent<WeaponScript>().Drop();
		this.BloodPool.GetComponent<WeaponScript>().MyRigidbody.useGravity = false;
		this.BloodPool.GetComponent<WeaponScript>().MyRigidbody.isKinematic = true;
		this.BloodPool.GetComponent<WeaponScript>().Returner = null;
		this.BloodPool = null;
		this.CurrentDestination = this.Destinations[this.Phase];
		this.Pathfinding.target = this.Destinations[this.Phase];
		if (this.CurrentAction == StudentActionType.Sunbathe && this.SunbathePhase > 1)
		{
			Debug.Log(this.Name + " was sunbathing at the time.");
			this.CurrentDestination = this.StudentManager.SunbatheSpots[this.StudentID];
			this.Pathfinding.target = this.StudentManager.SunbatheSpots[this.StudentID];
		}
		if (this.Club == ClubType.Council || this.Teacher)
		{
			this.Handkerchief.SetActive(false);
		}
		this.Pathfinding.speed = this.WalkSpeed;
		this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.ReturningMisplacedWeapon = false;
		this.WitnessedSomething = false;
		this.VerballyReacted = false;
		this.WitnessedWeapon = false;
		this.YandereInnocent = false;
		this.ReportingBlood = false;
		this.Distracted = false;
		this.Routine = true;
		this.ReturningMisplacedWeaponPhase = 0;
		this.WitnessCooldownTimer = 0f;
		this.Yandere.WeaponManager.ReturnWeaponID = -1;
		this.Yandere.WeaponManager.ReturnStudentID = -1;
		if (this.BeforeReturnAnim == "")
		{
			this.BeforeReturnAnim = this.OriginalWalkAnim;
		}
		this.WalkAnim = this.BeforeReturnAnim;
		this.Hurry = this.WasHurrying;
		Debug.Log(this.Name + "'s WalkAnim is now: " + this.WalkAnim);
	}

	// Token: 0x06001E83 RID: 7811 RVA: 0x001A29AC File Offset: 0x001A0BAC
	public void StopMusic()
	{
		if (this.StudentID == 51)
		{
			if (this.InstrumentBag[this.ClubMemberID].transform.parent == null)
			{
				this.Instruments[this.ClubMemberID].transform.parent = null;
				if (!this.StudentManager.Eighties)
				{
					this.Instruments[this.ClubMemberID].transform.position = new Vector3(-0.5f, 4.5f, 22.45666f);
					this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, 0f, 0f);
				}
				else
				{
					this.Instruments[this.ClubMemberID].transform.position = new Vector3(2.105f, 4.5f, 25.5f);
					this.Instruments[this.ClubMemberID].transform.eulerAngles = new Vector3(-15f, -90f, 0f);
				}
				this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().playOnAwake = false;
				this.Instruments[this.ClubMemberID].GetComponent<AudioSource>().Stop();
			}
			else
			{
				this.Instruments[this.ClubMemberID].SetActive(false);
			}
		}
		else
		{
			this.Instruments[this.ClubMemberID].SetActive(false);
		}
		this.Drumsticks[0].SetActive(false);
		this.Drumsticks[1].SetActive(false);
	}

	// Token: 0x06001E84 RID: 7812 RVA: 0x001A2B30 File Offset: 0x001A0D30
	public void DropPuzzle()
	{
		this.PuzzleCube.enabled = true;
		this.PuzzleCube.Drop();
		this.SolvingPuzzle = false;
		this.Distracted = false;
		this.PuzzleTimer = 0f;
	}

	// Token: 0x06001E85 RID: 7813 RVA: 0x001A2B64 File Offset: 0x001A0D64
	public void ReturnToNormal()
	{
		Debug.Log(this.Name + " has been instructed to forget everything and return to normal.");
		if (this.StudentManager.Reporter == this)
		{
			this.StudentManager.CorpseLocation.position = Vector3.zero;
			this.StudentManager.Reporter = null;
		}
		else if (this.StudentManager.BloodReporter == this)
		{
			this.StudentManager.BloodLocation.position = Vector3.zero;
			this.StudentManager.BloodReporter = null;
		}
		if (this.Yandere.Pursuer == this)
		{
			this.Yandere.Pursuer = null;
			this.Yandere.PreparedForStruggle = false;
		}
		this.StudentManager.UpdateStudents(0);
		this.CurrentDestination = this.Destinations[this.Phase];
		this.Pathfinding.target = this.Destinations[this.Phase];
		this.Pathfinding.canSearch = true;
		this.Pathfinding.canMove = true;
		this.Pathfinding.speed = this.WalkSpeed;
		this.TargetDistance = 1f;
		this.ReportPhase = 0;
		this.ReportTimer = 0f;
		this.AlarmTimer = 0f;
		this.AmnesiaTimer = 10f;
		this.RandomAnim = this.BulliedIdleAnim;
		this.IdleAnim = this.BulliedIdleAnim;
		this.WalkAnim = this.BulliedWalkAnim;
		if (this.WitnessedBloodPool || this.WitnessedLimb || this.WitnessedWeapon)
		{
			this.Persona = this.OriginalPersona;
		}
		this.BloodPool = null;
		this.WitnessedBloodyWeapon = false;
		this.WitnessedBloodPool = false;
		this.WitnessedSomething = false;
		this.WitnessedCorpse = false;
		this.WitnessedMurder = false;
		this.WitnessedWeapon = false;
		this.WitnessedLimb = false;
		this.SmartPhone.SetActive(false);
		this.LostTeacherTrust = true;
		this.ReportingMurder = false;
		this.ReportingBlood = false;
		this.PinDownWitness = false;
		this.Distracted = true;
		this.Reacted = false;
		this.Alarmed = false;
		this.Fleeing = false;
		this.Routine = true;
		this.Halt = false;
		if (this.Club == ClubType.Council)
		{
			this.Persona = PersonaType.Dangerous;
		}
		this.ID = 0;
		while (this.ID < this.Outlines.Length)
		{
			if (this.Outlines[this.ID] != null)
			{
				this.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
			}
			this.ID++;
		}
	}

	// Token: 0x06001E86 RID: 7814 RVA: 0x001A2DF8 File Offset: 0x001A0FF8
	public void ForgetAboutBloodPool()
	{
		Debug.Log(this.Name + " was told to ForgetAboutBloodPool()");
		this.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
		if (this.Club == ClubType.Cooking && this.CurrentAction == StudentActionType.ClubAction && this.MyPlate != null && this.MyPlate.parent == this.RightHand)
		{
			this.GetFoodTarget();
		}
		else
		{
			this.CurrentDestination = this.Destinations[this.Phase];
			this.Pathfinding.target = this.Destinations[this.Phase];
		}
		this.InvestigatingBloodPool = false;
		this.WitnessedBloodyWeapon = false;
		this.WitnessedBloodPool = false;
		this.WitnessedSomething = false;
		this.WitnessedWeapon = false;
		this.Distracted = false;
		if (!this.Shoving)
		{
			this.Routine = true;
		}
		this.WitnessCooldownTimer = 5f;
		if (this.BloodPool != null && this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition) && this.BloodPool.parent == this.Yandere.RightHand)
		{
			this.YandereVisible = true;
			this.ReportTimer = 0f;
			this.ReportPhase = 0;
			this.Alarmed = false;
			this.Fleeing = false;
			this.Reacted = false;
			if (this.BloodPool.GetComponent<WeaponScript>() != null && this.BloodPool.GetComponent<WeaponScript>().Suspicious)
			{
				this.WitnessCooldownTimer = 5f;
				this.AlarmTimer = 0f;
				this.Alarm = 200f;
				this.BecomeAlarmed();
			}
		}
		if (this.BeforeReturnAnim != "")
		{
			this.WalkAnim = this.BeforeReturnAnim;
		}
		this.BloodPool = null;
	}

	// Token: 0x06001E87 RID: 7815 RVA: 0x001A2FCD File Offset: 0x001A11CD
	private void SimpleForgetAboutBloodPool()
	{
		this.InvestigatingBloodPool = false;
		this.WitnessedBloodyWeapon = false;
		this.WitnessedBloodPool = false;
		this.WitnessedSomething = false;
		this.WitnessedWeapon = false;
		this.Distracted = false;
	}

	// Token: 0x06001E88 RID: 7816 RVA: 0x001A2FFC File Offset: 0x001A11FC
	private void SummonWitnessCamera()
	{
		this.WitnessCamera.transform.parent = this.WitnessPOV;
		this.WitnessCamera.transform.localPosition = Vector3.zero;
		this.WitnessCamera.transform.localEulerAngles = Vector3.zero;
		this.WitnessCamera.MyCamera.enabled = true;
		this.WitnessCamera.Show = true;
	}

	// Token: 0x06001E89 RID: 7817 RVA: 0x001A3066 File Offset: 0x001A1266
	public void SilentlyForgetBloodPool()
	{
		Debug.Log(this.Name + " was told to SilentlyForgetBloodPool()");
		this.InvestigatingBloodPool = false;
		this.WitnessedBloodyWeapon = false;
		this.WitnessedBloodPool = false;
		this.WitnessedSomething = false;
		this.WitnessedWeapon = false;
	}

	// Token: 0x06001E8A RID: 7818 RVA: 0x001A30A0 File Offset: 0x001A12A0
	private void CheckForEndRaibaruEvent()
	{
		if (this.StudentManager.Students[46] == null || this.StudentManager.Students[46].Phase > this.Phase)
		{
			Debug.Log("This code should only be allowed to run if Raibaru just finished mentoring the Martial Arts Club...");
			if (this.FollowTarget != null)
			{
				if (this.FollowTarget.Alive)
				{
					this.Destinations[this.Phase] = this.FollowTarget.transform;
					this.Pathfinding.target = this.FollowTarget.transform;
					this.CurrentDestination = this.FollowTarget.transform;
				}
				else
				{
					this.Destinations[this.Phase] = this.StudentManager.LastKnownOsana;
					this.Pathfinding.target = this.StudentManager.LastKnownOsana;
					this.CurrentDestination = this.StudentManager.LastKnownOsana;
				}
				this.FollowTarget.Follower = this;
				this.Actions[this.Phase] = StudentActionType.Follow;
				this.CurrentAction = StudentActionType.Follow;
			}
			else
			{
				this.Destinations[this.Phase] = this.StudentManager.MournSpots[this.StudentID];
				this.Pathfinding.target = this.StudentManager.MournSpots[this.StudentID];
				this.CurrentDestination = this.StudentManager.MournSpots[this.StudentID];
				this.Actions[this.Phase] = StudentActionType.Mourn;
				this.CurrentAction = StudentActionType.Mourn;
			}
			this.SpeechLines.Stop();
			this.InEvent = false;
			this.NoMentor = true;
			this.Routine = true;
		}
	}

	// Token: 0x06001E8B RID: 7819 RVA: 0x001A323C File Offset: 0x001A143C
	private void RaibaruOsanaDeathScheduleChanges()
	{
		ScheduleBlock scheduleBlock = this.ScheduleBlocks[1];
		scheduleBlock.destination = "Mourn";
		scheduleBlock.action = "Mourn";
		ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[2];
		scheduleBlock2.destination = "Mourn";
		scheduleBlock2.action = "Mourn";
		ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[4];
		scheduleBlock3.destination = "LunchSpot";
		scheduleBlock3.action = "Eat";
		this.Persona = PersonaType.Heroic;
		this.IdleAnim = this.BulliedIdleAnim;
		this.WalkAnim = this.BulliedWalkAnim;
		this.OriginalIdleAnim = this.IdleAnim;
	}

	// Token: 0x06001E8C RID: 7820 RVA: 0x001A32CC File Offset: 0x001A14CC
	private void RaibaruStopsFollowingOsana()
	{
		ScheduleBlock scheduleBlock = this.ScheduleBlocks[3];
		scheduleBlock.destination = "Seat";
		scheduleBlock.action = "Sit";
		ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[5];
		scheduleBlock2.destination = "Seat";
		scheduleBlock2.action = "Sit";
		ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[6];
		scheduleBlock3.destination = "Locker";
		scheduleBlock3.action = "Shoes";
		ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[7];
		scheduleBlock4.destination = "Exit";
		scheduleBlock4.action = "Exit";
		ScheduleBlock scheduleBlock5 = this.ScheduleBlocks[8];
		scheduleBlock5.destination = "Exit";
		scheduleBlock5.action = "Exit";
		ScheduleBlock scheduleBlock6 = this.ScheduleBlocks[9];
		scheduleBlock6.destination = "Exit";
		scheduleBlock6.action = "Exit";
	}

	// Token: 0x06001E8D RID: 7821 RVA: 0x001A3388 File Offset: 0x001A1588
	private void BoyStopsFollowingGravureModel()
	{
		ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
		scheduleBlock.destination = "Seat";
		scheduleBlock.action = "Sit";
		ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[4];
		scheduleBlock2.destination = "LunchSpot";
		scheduleBlock2.action = "Eat";
		ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[6];
		scheduleBlock3.destination = "Locker";
		scheduleBlock3.action = "Locker";
		ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[7];
		scheduleBlock4.destination = "Exit";
		scheduleBlock4.action = "Exit";
	}

	// Token: 0x06001E8E RID: 7822 RVA: 0x001A340C File Offset: 0x001A160C
	public void StopDrinking()
	{
		this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.DrinkingFountain.Occupied = false;
		this.EquipCleaningItems();
		this.EatingSnack = false;
		this.Private = false;
		this.Routine = true;
		this.StudentManager.UpdateMe(this.StudentID);
	}

	// Token: 0x06001E8F RID: 7823 RVA: 0x001A3460 File Offset: 0x001A1660
	public void GoToClass()
	{
		ScheduleBlock scheduleBlock = this.ScheduleBlocks[this.Phase];
		scheduleBlock.destination = "Seat";
		scheduleBlock.action = "SitAndTakeNotes";
		this.Actions[this.Phase] = StudentActionType.SitAndTakeNotes;
		this.CurrentAction = StudentActionType.SitAndTakeNotes;
		this.GetDestinations();
		this.CurrentDestination = this.Destinations[this.Phase];
		this.Pathfinding.target = this.Destinations[this.Phase];
	}

	// Token: 0x06001E90 RID: 7824 RVA: 0x001A34D8 File Offset: 0x001A16D8
	public void RaibaruCannotFindOsana()
	{
		this.SpeechLines.Stop();
		this.CharacterAnimation.CrossFade(this.ParanoidAnim);
		this.SnackTimer += Time.deltaTime;
		if (this.SnackTimer > 5f)
		{
			this.Subtitle.UpdateLabel(SubtitleType.RaibaruRivalDeathReaction, 5, 10f);
			this.RaibaruOsanaDeathScheduleChanges();
			this.RaibaruStopsFollowingOsana();
			this.GetDestinations();
			this.CurrentDestination = this.Destinations[this.Phase];
			this.Pathfinding.target = this.Destinations[this.Phase];
			this.SnackTimer = 0f;
		}
	}

	// Token: 0x06001E91 RID: 7825 RVA: 0x001A3580 File Offset: 0x001A1780
	public void BoyCannotFindGravureModel()
	{
		Debug.Log("A boy cannot find the gravure model he's supposed to be following.");
		this.CharacterAnimation.CrossFade(this.ParanoidAnim);
		this.SnackTimer += Time.deltaTime;
		if (this.SnackTimer > 5f)
		{
			Debug.Log("The boy has decided to give up on following the gravure model.");
			this.BoyStopsFollowingGravureModel();
			this.GetDestinations();
			this.CurrentDestination = this.Destinations[this.Phase];
			this.Pathfinding.target = this.Destinations[this.Phase];
			this.SnackTimer = 0f;
		}
	}

	// Token: 0x06001E92 RID: 7826 RVA: 0x001A3614 File Offset: 0x001A1814
	public void DisableProps()
	{
		this.RandomCheerAnim = this.CheerAnims[UnityEngine.Random.Range(0, this.CheerAnims.Length)];
		this.HealthBar.transform.parent.gameObject.SetActive(false);
		this.FollowCountdown.gameObject.SetActive(false);
		this.VomitEmitter.gameObject.SetActive(false);
		this.ChaseCamera.gameObject.SetActive(false);
		this.Countdown.gameObject.SetActive(false);
		this.MiyukiGameScreen.SetActive(false);
		this.Chopsticks[0].SetActive(false);
		this.Chopsticks[1].SetActive(false);
		this.Handkerchief.SetActive(false);
		this.PepperSpray.SetActive(false);
		this.RetroCamera.SetActive(false);
		this.Sketchbook.SetActive(false);
		this.SmartPhone.SetActive(false);
		this.OccultBook.SetActive(false);
		this.Paintbrush.SetActive(false);
		this.EventBook.SetActive(false);
		this.Handcuffs.SetActive(false);
		this.WeaponBag.SetActive(false);
		this.Scrubber.SetActive(false);
		this.Armband.SetActive(false);
		this.Octodog.SetActive(false);
		this.Palette.SetActive(false);
		this.Eraser.SetActive(false);
		this.Pencil.SetActive(false);
		this.Bento.SetActive(false);
		this.Pen.SetActive(false);
		this.SpeechLines.Stop();
		foreach (GameObject gameObject in this.ScienceProps)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
		foreach (GameObject gameObject2 in this.Fingerfood)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
		}
	}

	// Token: 0x06001E93 RID: 7827 RVA: 0x001A37F8 File Offset: 0x001A19F8
	public void DisableFemaleProps()
	{
		this.SkirtOrigins[0] = this.Skirt[0].transform.localPosition;
		this.SkirtOrigins[1] = this.Skirt[1].transform.localPosition;
		this.SkirtOrigins[2] = this.Skirt[2].transform.localPosition;
		this.SkirtOrigins[3] = this.Skirt[3].transform.localPosition;
		this.InstrumentBag[1].SetActive(false);
		this.InstrumentBag[2].SetActive(false);
		this.InstrumentBag[3].SetActive(false);
		this.InstrumentBag[4].SetActive(false);
		this.InstrumentBag[5].SetActive(false);
		this.PickRandomGossipAnim();
		this.DramaticCamera.gameObject.SetActive(false);
		this.MapMarker.gameObject.SetActive(false);
		this.EightiesPhone.SetActive(false);
		this.AnimatedBook.SetActive(false);
		this.Handkerchief.SetActive(false);
		this.WateringCan.SetActive(false);
		this.Sketchbook.SetActive(false);
		this.Cigarette.SetActive(false);
		this.CandyBar.SetActive(false);
		this.Lighter.SetActive(false);
		foreach (GameObject gameObject in this.Instruments)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
		this.Drumsticks[0].SetActive(false);
		this.Drumsticks[1].SetActive(false);
		if (this.Club >= ClubType.Teacher)
		{
			this.BecomeTeacher();
		}
		if (GameGlobals.CensorPanties && !this.Teacher)
		{
			this.Cosmetic.CensorPanties();
		}
		this.DisableEffects();
	}

	// Token: 0x06001E94 RID: 7828 RVA: 0x001A39C0 File Offset: 0x001A1BC0
	public void DisableMaleProps()
	{
		this.MapMarker.gameObject.SetActive(false);
		this.DelinquentSpeechLines.Stop();
		this.PinkSeifuku.SetActive(false);
		this.Earpiece.SetActive(false);
		ParticleSystem[] liquidEmitters = this.LiquidEmitters;
		for (int i = 0; i < liquidEmitters.Length; i++)
		{
			liquidEmitters[i].gameObject.SetActive(false);
		}
	}

	// Token: 0x06001E95 RID: 7829 RVA: 0x001A3A24 File Offset: 0x001A1C24
	public void TriggerBeatEmUpMinigame()
	{
		GameGlobals.BeatEmUpDifficulty = 1;
		SceneManager.LoadScene("BeatEmUpScene", LoadSceneMode.Additive);
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			rootGameObjects[i].SetActive(false);
		}
	}

	// Token: 0x06001E96 RID: 7830 RVA: 0x001A3A68 File Offset: 0x001A1C68
	public void PlaceBag()
	{
		if (this.Seat.position.x < 0f)
		{
			this.StudentManager.RivalBookBag.transform.position = this.Seat.position + new Vector3(-0.33333f, 0.342f, 0.3585f);
			this.StudentManager.RivalBookBag.transform.eulerAngles = new Vector3(0f, 0f, 0f);
		}
		else
		{
			this.StudentManager.RivalBookBag.transform.position = this.Seat.position + new Vector3(0.33333f, 0.342f, -0.3585f);
			this.StudentManager.RivalBookBag.transform.eulerAngles = new Vector3(0f, 180f, 0f);
		}
		this.StudentManager.RivalBookBag.gameObject.SetActive(true);
		this.StudentManager.RivalBookBag.Prompt.enabled = true;
		this.StudentManager.RivalBookBag.Rival = this;
		this.BookBag.SetActive(false);
		if (this.GiftBox)
		{
			this.StudentManager.WednesdayGiftBox.SetActive(true);
			if (base.transform.position.x < 0f)
			{
				this.StudentManager.WednesdayGiftBox.transform.position = this.Seat.position + new Vector3(-0.4f, 1.02f, 0f);
			}
			else
			{
				this.StudentManager.WednesdayGiftBox.transform.position = this.Seat.position + new Vector3(0.4f, 1.02f, 0f);
			}
			this.GiftBox = false;
		}
		if (this.VisitSenpaiDesk)
		{
			if (this.CurrentDestination == this.StudentManager.Students[1].Seat)
			{
				this.StudentManager.FridayTestNotes.SetActive(true);
				this.VisitSenpaiDesk = false;
			}
			this.Destinations[this.Phase] = this.StudentManager.Students[1].Seat;
			this.CurrentDestination = this.StudentManager.Students[1].Seat;
			this.Pathfinding.target = this.StudentManager.Students[1].Seat;
			return;
		}
		if (this.Bullied)
		{
			ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
			scheduleBlock.destination = "ShameSpot";
			scheduleBlock.action = "Shamed";
			scheduleBlock.time = 8f;
		}
		else if (this.StudentID == 11 || this.StudentID == 12)
		{
			ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[2];
			scheduleBlock2.destination = "Hangout";
			scheduleBlock2.action = "Socialize";
		}
		else if (this.StudentID == 13)
		{
			ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[2];
			scheduleBlock3.destination = "Patrol";
			scheduleBlock3.action = "Patrol";
		}
		else if (this.StudentID == 14)
		{
			ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[2];
			scheduleBlock4.destination = "Sunbathe";
			scheduleBlock4.action = "Jog";
		}
		else if (this.StudentID == 15)
		{
			ScheduleBlock scheduleBlock5 = this.ScheduleBlocks[2];
			scheduleBlock5.destination = "Sunbathe";
			scheduleBlock5.action = "Sunbathe";
		}
		else if (this.StudentID == 16)
		{
			ScheduleBlock scheduleBlock6 = this.ScheduleBlocks[2];
			scheduleBlock6.destination = "Perform";
			scheduleBlock6.action = "Perform";
		}
		else if (this.StudentID == 17)
		{
			ScheduleBlock scheduleBlock7 = this.ScheduleBlocks[2];
			scheduleBlock7.destination = "Hangout";
			scheduleBlock7.action = "Read";
		}
		else if (this.StudentID == 18)
		{
			ScheduleBlock scheduleBlock8 = this.ScheduleBlocks[2];
			scheduleBlock8.destination = "Hangout";
			scheduleBlock8.action = "Socialize";
		}
		else if (this.StudentID == 19)
		{
			ScheduleBlock scheduleBlock9 = this.ScheduleBlocks[2];
			scheduleBlock9.destination = "Sunbathe";
			scheduleBlock9.action = "GravurePose";
		}
		else if (this.StudentID == 20)
		{
			ScheduleBlock scheduleBlock10 = this.ScheduleBlocks[2];
			scheduleBlock10.destination = "Guard";
			scheduleBlock10.action = "Guard";
			this.TargetDistance = 1f;
		}
		this.GetDestinations();
		this.CurrentDestination = this.Destinations[this.Phase];
		this.Pathfinding.target = this.Destinations[this.Phase];
		this.CurrentAction = this.Actions[this.Phase];
	}

	// Token: 0x06001E97 RID: 7831 RVA: 0x001A3EF0 File Offset: 0x001A20F0
	public void BecomeSleuth()
	{
		if (this.Club == ClubType.Newspaper)
		{
			Debug.Log(string.Concat(new string[]
			{
				"Newspaper Club Member Student # ",
				this.StudentID.ToString(),
				" - ",
				this.Name,
				" - is being turned into a Sleuth."
			}));
		}
		else if (this.Club == ClubType.Photography)
		{
			Debug.Log(string.Concat(new string[]
			{
				"Photography Club Member Student # ",
				this.StudentID.ToString(),
				" - ",
				this.Name,
				" - is being turned into a Sleuth."
			}));
		}
		else if (this.Club == ClubType.None)
		{
			Debug.Log(string.Concat(new string[]
			{
				"Clubless Student # ",
				this.StudentID.ToString(),
				" - ",
				this.Name,
				" - is being turned into a Sleuth."
			}));
		}
		if (this.StudentManager.Eighties)
		{
			this.CameraFlash = this.RetroCameraFlash;
			this.SmartPhone = this.RetroCamera;
		}
		this.Indoors = true;
		this.Spawned = true;
		if (this.ShoeRemoval.Locker == null)
		{
			this.ShoeRemoval.Start();
		}
		this.ShoeRemoval.PutOnShoes();
		if (this.StudentID != 20)
		{
			this.SprintAnim = this.SleuthSprintAnim;
			this.IdleAnim = this.SleuthIdleAnim;
			this.WalkAnim = this.SleuthWalkAnim;
		}
		this.CameraAnims = this.HeroAnims;
		this.SmartPhone.SetActive(true);
		this.Countdown.Speed = 0.075f;
		this.Sleuthing = true;
		if (this.Male)
		{
			this.SmartPhone.transform.localPosition = new Vector3(0.06f, -0.02f, -0.02f);
		}
		else
		{
			this.SmartPhone.transform.localPosition = new Vector3(0.033333f, -0.015f, -0.015f);
		}
		if (!this.StudentManager.Eighties)
		{
			this.SmartPhone.transform.localEulerAngles = new Vector3(12.5f, 120f, 180f);
		}
		else
		{
			this.SmartPhone.transform.localEulerAngles = new Vector3(22.5f, 22.5f, 150f);
			this.Phoneless = false;
		}
		if (this.StudentID != 20 && this.StudentID != 36)
		{
			if (this.Club == ClubType.None || this.Club == ClubType.Newspaper)
			{
				this.StudentManager.SleuthPhase = 3;
				this.SleuthID = this.StudentID;
				this.GetSleuthTarget();
			}
			else
			{
				this.SleuthTarget = this.StudentManager.Clubs.List[this.StudentID];
			}
			if (!this.Grudge)
			{
				ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
				scheduleBlock.destination = "Sleuth";
				scheduleBlock.action = "Sleuth";
				if (!this.StudentManager.MissionMode)
				{
					ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[4];
					scheduleBlock2.destination = "Sleuth";
					scheduleBlock2.action = "Sleuth";
				}
				ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[7];
				scheduleBlock3.destination = "Sleuth";
				scheduleBlock3.action = "Sleuth";
			}
			else
			{
				this.StalkTarget = this.Yandere.transform;
				this.SleuthTarget = this.Yandere.transform;
				ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[2];
				scheduleBlock4.destination = "Stalk";
				scheduleBlock4.action = "Stalk";
				ScheduleBlock scheduleBlock5 = this.ScheduleBlocks[4];
				scheduleBlock5.destination = "Stalk";
				scheduleBlock5.action = "Stalk";
				ScheduleBlock scheduleBlock6 = this.ScheduleBlocks[7];
				scheduleBlock6.destination = "Stalk";
				scheduleBlock6.action = "Stalk";
			}
		}
		if (this.SleuthID < 1)
		{
			this.SleuthID = 1;
		}
	}

	// Token: 0x06001E98 RID: 7832 RVA: 0x001A42A8 File Offset: 0x001A24A8
	public void CheckForBento()
	{
		if (this.Bento.activeInHierarchy && this.StudentID > 1 && this.Bento.transform.parent != null)
		{
			GenericBentoScript component = this.Bento.GetComponent<GenericBentoScript>();
			component.enabled = true;
			component.Prompt.enabled = true;
			this.Bento.SetActive(true);
			this.Bento.transform.parent = base.transform;
			if (this.Male)
			{
				this.Bento.transform.localPosition = new Vector3(0f, 0.4266666f, -0.075f);
			}
			else
			{
				this.Bento.transform.localPosition = new Vector3(0f, 0.461f, -0.075f);
			}
			this.Bento.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			this.Bento.transform.parent = null;
		}
	}

	// Token: 0x06001E99 RID: 7833 RVA: 0x001A43B4 File Offset: 0x001A25B4
	public void BlendIntoSittingAnim()
	{
		if (this.CharacterAnimation[this.SocialSitAnim].weight != 1f)
		{
			this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 1f, Time.deltaTime * 10f);
			if ((double)this.CharacterAnimation[this.SocialSitAnim].weight > 0.99)
			{
				this.CharacterAnimation[this.SocialSitAnim].weight = 1f;
			}
		}
	}

	// Token: 0x06001E9A RID: 7834 RVA: 0x001A445C File Offset: 0x001A265C
	public void BlendOutOfSittingAnim()
	{
		if (this.CharacterAnimation[this.SocialSitAnim].weight != 0f)
		{
			this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 0f, Time.deltaTime * 10f);
			if ((double)this.CharacterAnimation[this.SocialSitAnim].weight < 0.01)
			{
				this.CharacterAnimation[this.SocialSitAnim].weight = 0f;
			}
		}
	}

	// Token: 0x06001E9B RID: 7835 RVA: 0x001A4504 File Offset: 0x001A2704
	public void Oversleep()
	{
		if (this.StudentID != 15 && this.ScheduleBlocks.Length == 10)
		{
			ScheduleBlock scheduleBlock = this.ScheduleBlocks[6];
			scheduleBlock.destination = "SleepSpot";
			scheduleBlock.action = "Sleep";
			scheduleBlock.time = 99999f;
			ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[7];
			scheduleBlock2.destination = "SleepSpot";
			scheduleBlock2.action = "Sleep";
			scheduleBlock2.time = 99999f;
			ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[8];
			scheduleBlock3.destination = "SleepSpot";
			scheduleBlock3.action = "Sleep";
			scheduleBlock3.time = 99999f;
			ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[9];
			scheduleBlock4.destination = "SleepSpot";
			scheduleBlock4.action = "Sleep";
			scheduleBlock4.time = 99999f;
		}
	}

	// Token: 0x06001E9C RID: 7836 RVA: 0x001A45D0 File Offset: 0x001A27D0
	public void UpdateGemaAppearance()
	{
		this.Cosmetic.FacialHairstyle = 0;
		this.Cosmetic.EyewearID = 9;
		this.Cosmetic.Hairstyle = 49;
		this.Cosmetic.Accessory = 0;
		this.Cosmetic.Start();
		this.IdleAnim = "properIdle_00";
		this.WalkAnim = "properWalk_00";
		this.ClubAnim = "properGaming_00";
		ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
		scheduleBlock.destination = "Club";
		scheduleBlock.action = "Club";
		this.GetDestinations();
		this.CurrentDestination = this.Destinations[this.Phase];
		this.Pathfinding.target = this.Destinations[this.Phase];
		this.StudentManager.ReactedToGameLeader = true;
		for (int i = 1; i < 6; i++)
		{
			ScheduleBlock scheduleBlock2 = this.StudentManager.Students[80 + i].ScheduleBlocks[4];
			scheduleBlock2.destination = "Shock";
			scheduleBlock2.action = "Shock";
			this.StudentManager.Students[80 + i].GetDestinations();
		}
	}

	// Token: 0x0400390C RID: 14604
	public Quaternion targetRotation;

	// Token: 0x0400390D RID: 14605
	public Quaternion OriginalRotation;

	// Token: 0x0400390E RID: 14606
	public Quaternion OriginalPlateRotation;

	// Token: 0x0400390F RID: 14607
	public SelectiveGrayscale ChaseSelectiveGrayscale;

	// Token: 0x04003910 RID: 14608
	public YanSaveIdentifier BloodSpawnerIdentifier;

	// Token: 0x04003911 RID: 14609
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04003912 RID: 14610
	public DetectionMarkerScript DetectionMarker;

	// Token: 0x04003913 RID: 14611
	public ChemistScannerScript ChemistScanner;

	// Token: 0x04003914 RID: 14612
	public StudentManagerScript StudentManager;

	// Token: 0x04003915 RID: 14613
	public CameraEffectsScript CameraEffects;

	// Token: 0x04003916 RID: 14614
	public ChangingBoothScript ChangingBooth;

	// Token: 0x04003917 RID: 14615
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04003918 RID: 14616
	public WitnessCameraScript WitnessCamera;

	// Token: 0x04003919 RID: 14617
	public YanSaveIdentifier HipsIdentifier;

	// Token: 0x0400391A RID: 14618
	public StudentScript DistractionTarget;

	// Token: 0x0400391B RID: 14619
	public CookingEventScript CookingEvent;

	// Token: 0x0400391C RID: 14620
	public EventManagerScript EventManager;

	// Token: 0x0400391D RID: 14621
	public GradingPaperScript GradingPaper;

	// Token: 0x0400391E RID: 14622
	public CountdownScript FollowCountdown;

	// Token: 0x0400391F RID: 14623
	public ClubManagerScript ClubManager;

	// Token: 0x04003920 RID: 14624
	public LightSwitchScript LightSwitch;

	// Token: 0x04003921 RID: 14625
	public MovingEventScript MovingEvent;

	// Token: 0x04003922 RID: 14626
	public ShoeRemovalScript ShoeRemoval;

	// Token: 0x04003923 RID: 14627
	public SnapStudentScript SnapStudent;

	// Token: 0x04003924 RID: 14628
	public StruggleBarScript StruggleBar;

	// Token: 0x04003925 RID: 14629
	public ToiletEventScript ToiletEvent;

	// Token: 0x04003926 RID: 14630
	public WeaponScript WeaponToTakeAway;

	// Token: 0x04003927 RID: 14631
	public DynamicGridObstacle Obstacle;

	// Token: 0x04003928 RID: 14632
	public PhoneEventScript PhoneEvent;

	// Token: 0x04003929 RID: 14633
	public PickpocketScript PickPocket;

	// Token: 0x0400392A RID: 14634
	public ReputationScript Reputation;

	// Token: 0x0400392B RID: 14635
	public StudentScript TargetStudent;

	// Token: 0x0400392C RID: 14636
	public GenericBentoScript MyBento;

	// Token: 0x0400392D RID: 14637
	public StudentScript FollowTarget;

	// Token: 0x0400392E RID: 14638
	public CountdownScript Countdown;

	// Token: 0x0400392F RID: 14639
	public Renderer SmartPhoneScreen;

	// Token: 0x04003930 RID: 14640
	public YanSaveIdentifier YanSave;

	// Token: 0x04003931 RID: 14641
	public StudentScript Distractor;

	// Token: 0x04003932 RID: 14642
	public StudentScript HuntTarget;

	// Token: 0x04003933 RID: 14643
	public StudentScript MyReporter;

	// Token: 0x04003934 RID: 14644
	public StudentScript MyTeacher;

	// Token: 0x04003935 RID: 14645
	public BoneSetsScript BoneSets;

	// Token: 0x04003936 RID: 14646
	public CosmeticScript Cosmetic;

	// Token: 0x04003937 RID: 14647
	public PickUpScript PuzzleCube;

	// Token: 0x04003938 RID: 14648
	public SaveLoadScript SaveLoad;

	// Token: 0x04003939 RID: 14649
	public SubtitleScript Subtitle;

	// Token: 0x0400393A RID: 14650
	public StudentScript Follower;

	// Token: 0x0400393B RID: 14651
	public DynamicBone OsanaHairL;

	// Token: 0x0400393C RID: 14652
	public DynamicBone OsanaHairR;

	// Token: 0x0400393D RID: 14653
	public ARMiyukiScript Miyuki;

	// Token: 0x0400393E RID: 14654
	public WeaponScript MyWeapon;

	// Token: 0x0400393F RID: 14655
	public StudentScript Partner;

	// Token: 0x04003940 RID: 14656
	public RagdollScript Ragdoll;

	// Token: 0x04003941 RID: 14657
	public YandereScript Yandere;

	// Token: 0x04003942 RID: 14658
	public Camera DramaticCamera;

	// Token: 0x04003943 RID: 14659
	public RagdollScript Corpse;

	// Token: 0x04003944 RID: 14660
	public StudentScript Hunter;

	// Token: 0x04003945 RID: 14661
	public DoorScript VomitDoor;

	// Token: 0x04003946 RID: 14662
	public BrokenScript Broken;

	// Token: 0x04003947 RID: 14663
	public PoliceScript Police;

	// Token: 0x04003948 RID: 14664
	public PromptScript Prompt;

	// Token: 0x04003949 RID: 14665
	public AIPath Pathfinding;

	// Token: 0x0400394A RID: 14666
	public TalkingScript Talk;

	// Token: 0x0400394B RID: 14667
	public CheerScript Cheer;

	// Token: 0x0400394C RID: 14668
	public ClockScript Clock;

	// Token: 0x0400394D RID: 14669
	public RadioScript Radio;

	// Token: 0x0400394E RID: 14670
	public Renderer Painting;

	// Token: 0x0400394F RID: 14671
	public JsonScript JSON;

	// Token: 0x04003950 RID: 14672
	public NapeScript Nape;

	// Token: 0x04003951 RID: 14673
	public SuckScript Suck;

	// Token: 0x04003952 RID: 14674
	public Renderer Tears;

	// Token: 0x04003953 RID: 14675
	public Rigidbody MyRigidbody;

	// Token: 0x04003954 RID: 14676
	public Collider HorudaCollider;

	// Token: 0x04003955 RID: 14677
	public Collider NapeCollider;

	// Token: 0x04003956 RID: 14678
	public Collider MyCollider;

	// Token: 0x04003957 RID: 14679
	public CharacterController MyController;

	// Token: 0x04003958 RID: 14680
	public Animation CharacterAnimation;

	// Token: 0x04003959 RID: 14681
	public Projector LiquidProjector;

	// Token: 0x0400395A RID: 14682
	public float VisionFOV;

	// Token: 0x0400395B RID: 14683
	public float VisionDistance;

	// Token: 0x0400395C RID: 14684
	public ParticleSystem DelinquentSpeechLines;

	// Token: 0x0400395D RID: 14685
	public ParticleSystem PepperSprayEffect;

	// Token: 0x0400395E RID: 14686
	public ParticleSystem DrowningSplashes;

	// Token: 0x0400395F RID: 14687
	public ParticleSystem BloodFountain;

	// Token: 0x04003960 RID: 14688
	public ParticleSystem VomitEmitter;

	// Token: 0x04003961 RID: 14689
	public ParticleSystem SpeechLines;

	// Token: 0x04003962 RID: 14690
	public ParticleSystem BullyDust;

	// Token: 0x04003963 RID: 14691
	public ParticleSystem ChalkDust;

	// Token: 0x04003964 RID: 14692
	public ParticleSystem Hearts;

	// Token: 0x04003965 RID: 14693
	public Texture KokonaPhoneTexture;

	// Token: 0x04003966 RID: 14694
	public Texture MidoriPhoneTexture;

	// Token: 0x04003967 RID: 14695
	public Texture OsanaPhoneTexture;

	// Token: 0x04003968 RID: 14696
	public Texture RedBookTexture;

	// Token: 0x04003969 RID: 14697
	public Texture BloodTexture;

	// Token: 0x0400396A RID: 14698
	public Texture BrownTexture;

	// Token: 0x0400396B RID: 14699
	public Texture WaterTexture;

	// Token: 0x0400396C RID: 14700
	public Texture GasTexture;

	// Token: 0x0400396D RID: 14701
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400396E RID: 14702
	public Renderer BookRenderer;

	// Token: 0x0400396F RID: 14703
	public Transform FollowTargetDestination;

	// Token: 0x04003970 RID: 14704
	public Transform LastSuspiciousObject2;

	// Token: 0x04003971 RID: 14705
	public Transform LastSuspiciousObject;

	// Token: 0x04003972 RID: 14706
	public Transform CurrentDestination;

	// Token: 0x04003973 RID: 14707
	public Transform LeftMiddleFinger;

	// Token: 0x04003974 RID: 14708
	public Transform TrashDestination;

	// Token: 0x04003975 RID: 14709
	public Transform WeaponBagParent;

	// Token: 0x04003976 RID: 14710
	public Transform LeftItemParent;

	// Token: 0x04003977 RID: 14711
	public Transform PetDestination;

	// Token: 0x04003978 RID: 14712
	public Transform SketchPosition;

	// Token: 0x04003979 RID: 14713
	public Transform CleaningSpot;

	// Token: 0x0400397A RID: 14714
	public Transform SleuthTarget;

	// Token: 0x0400397B RID: 14715
	public Transform Distraction;

	// Token: 0x0400397C RID: 14716
	public Transform StalkTarget;

	// Token: 0x0400397D RID: 14717
	public Transform ItemParent;

	// Token: 0x0400397E RID: 14718
	public Transform WitnessPOV;

	// Token: 0x0400397F RID: 14719
	public Transform RightDrill;

	// Token: 0x04003980 RID: 14720
	public Transform BloodPool;

	// Token: 0x04003981 RID: 14721
	public Transform LeftDrill;

	// Token: 0x04003982 RID: 14722
	public Transform LeftPinky;

	// Token: 0x04003983 RID: 14723
	public Transform MapMarker;

	// Token: 0x04003984 RID: 14724
	public Transform RightHand;

	// Token: 0x04003985 RID: 14725
	public Transform LeftHand;

	// Token: 0x04003986 RID: 14726
	public Transform MeetSpot;

	// Token: 0x04003987 RID: 14727
	public Transform MyLocker;

	// Token: 0x04003988 RID: 14728
	public Transform MyPlate;

	// Token: 0x04003989 RID: 14729
	public Transform Spine;

	// Token: 0x0400398A RID: 14730
	public Transform Eyes;

	// Token: 0x0400398B RID: 14731
	public Transform Head;

	// Token: 0x0400398C RID: 14732
	public Transform Hips;

	// Token: 0x0400398D RID: 14733
	public Transform Neck;

	// Token: 0x0400398E RID: 14734
	public Transform Seat;

	// Token: 0x0400398F RID: 14735
	public Transform LipL;

	// Token: 0x04003990 RID: 14736
	public Transform LipR;

	// Token: 0x04003991 RID: 14737
	public Transform Jaw;

	// Token: 0x04003992 RID: 14738
	public ParticleSystem[] LiquidEmitters;

	// Token: 0x04003993 RID: 14739
	public ParticleSystem[] SplashEmitters;

	// Token: 0x04003994 RID: 14740
	public ParticleSystem[] FireEmitters;

	// Token: 0x04003995 RID: 14741
	public ScheduleBlock[] ScheduleBlocks;

	// Token: 0x04003996 RID: 14742
	public ScheduleBlock[] OriginalScheduleBlocks;

	// Token: 0x04003997 RID: 14743
	public Transform[] Destinations;

	// Token: 0x04003998 RID: 14744
	public Transform[] LongHair;

	// Token: 0x04003999 RID: 14745
	public Transform[] Skirt;

	// Token: 0x0400399A RID: 14746
	public Transform[] Arm;

	// Token: 0x0400399B RID: 14747
	public DynamicBone[] BlackHoleEffect;

	// Token: 0x0400399C RID: 14748
	public OutlineScript[] Outlines;

	// Token: 0x0400399D RID: 14749
	public GameObject[] InstrumentBag;

	// Token: 0x0400399E RID: 14750
	public GameObject[] ScienceProps;

	// Token: 0x0400399F RID: 14751
	public GameObject[] Instruments;

	// Token: 0x040039A0 RID: 14752
	public GameObject[] Chopsticks;

	// Token: 0x040039A1 RID: 14753
	public GameObject[] Drumsticks;

	// Token: 0x040039A2 RID: 14754
	public GameObject[] Fingerfood;

	// Token: 0x040039A3 RID: 14755
	public GameObject[] Bones;

	// Token: 0x040039A4 RID: 14756
	public string[] DelinquentAnims;

	// Token: 0x040039A5 RID: 14757
	public string[] AnimationNames;

	// Token: 0x040039A6 RID: 14758
	public string[] GravureAnims;

	// Token: 0x040039A7 RID: 14759
	public string[] GossipAnims;

	// Token: 0x040039A8 RID: 14760
	public string[] SleuthAnims;

	// Token: 0x040039A9 RID: 14761
	public string[] CheerAnims;

	// Token: 0x040039AA RID: 14762
	[SerializeField]
	private List<int> VisibleCorpses = new List<int>();

	// Token: 0x040039AB RID: 14763
	[SerializeField]
	private int[] CorpseLayers = new int[]
	{
		11,
		14
	};

	// Token: 0x040039AC RID: 14764
	[SerializeField]
	private LayerMask YandereCheckMask;

	// Token: 0x040039AD RID: 14765
	[SerializeField]
	private LayerMask Mask;

	// Token: 0x040039AE RID: 14766
	public StudentActionType CurrentAction;

	// Token: 0x040039AF RID: 14767
	public StudentActionType[] Actions;

	// Token: 0x040039B0 RID: 14768
	public StudentActionType[] OriginalActions;

	// Token: 0x040039B1 RID: 14769
	public AudioClip MurderSuicideKiller;

	// Token: 0x040039B2 RID: 14770
	public AudioClip MurderSuicideVictim;

	// Token: 0x040039B3 RID: 14771
	public AudioClip MurderSuicideSounds;

	// Token: 0x040039B4 RID: 14772
	public AudioClip PoisonDeathClip;

	// Token: 0x040039B5 RID: 14773
	public AudioClip PepperSpraySFX;

	// Token: 0x040039B6 RID: 14774
	public AudioClip BurningClip;

	// Token: 0x040039B7 RID: 14775
	public AudioSource AirGuitar;

	// Token: 0x040039B8 RID: 14776
	public AudioClip[] FemaleAttacks;

	// Token: 0x040039B9 RID: 14777
	public AudioClip[] BullyGiggles;

	// Token: 0x040039BA RID: 14778
	public AudioClip[] BullyLaughs;

	// Token: 0x040039BB RID: 14779
	public AudioClip[] MaleAttacks;

	// Token: 0x040039BC RID: 14780
	public SphereCollider HipCollider;

	// Token: 0x040039BD RID: 14781
	public Collider RightHandCollider;

	// Token: 0x040039BE RID: 14782
	public Collider LeftHandCollider;

	// Token: 0x040039BF RID: 14783
	public Collider NotFaceCollider;

	// Token: 0x040039C0 RID: 14784
	public Collider PantyCollider;

	// Token: 0x040039C1 RID: 14785
	public Collider SkirtCollider;

	// Token: 0x040039C2 RID: 14786
	public Collider FaceCollider;

	// Token: 0x040039C3 RID: 14787
	public Collider NEStairs;

	// Token: 0x040039C4 RID: 14788
	public Collider NWStairs;

	// Token: 0x040039C5 RID: 14789
	public Collider SEStairs;

	// Token: 0x040039C6 RID: 14790
	public Collider SWStairs;

	// Token: 0x040039C7 RID: 14791
	public GameObject EightiesTeacherAttacher;

	// Token: 0x040039C8 RID: 14792
	public GameObject EnterGuardStateCollider;

	// Token: 0x040039C9 RID: 14793
	public GameObject BloodSprayCollider;

	// Token: 0x040039CA RID: 14794
	public GameObject BullyPhotoCollider;

	// Token: 0x040039CB RID: 14795
	public GameObject SquishyBloodEffect;

	// Token: 0x040039CC RID: 14796
	public GameObject WhiteQuestionMark;

	// Token: 0x040039CD RID: 14797
	public GameObject MiyukiGameScreen;

	// Token: 0x040039CE RID: 14798
	public GameObject RetroCameraFlash;

	// Token: 0x040039CF RID: 14799
	public GameObject EmptyGameObject;

	// Token: 0x040039D0 RID: 14800
	public GameObject StabBloodEffect;

	// Token: 0x040039D1 RID: 14801
	public GameObject BountyCollider;

	// Token: 0x040039D2 RID: 14802
	public GameObject BigWaterSplash;

	// Token: 0x040039D3 RID: 14803
	public GameObject SecurityCamera;

	// Token: 0x040039D4 RID: 14804
	public GameObject RightEmptyEye;

	// Token: 0x040039D5 RID: 14805
	public GameObject LeftEmptyEye;

	// Token: 0x040039D6 RID: 14806
	public GameObject AnimatedBook;

	// Token: 0x040039D7 RID: 14807
	public GameObject BloodyScream;

	// Token: 0x040039D8 RID: 14808
	public GameObject EdgyAttacher;

	// Token: 0x040039D9 RID: 14809
	public GameObject Handkerchief;

	// Token: 0x040039DA RID: 14810
	public GameObject BloodEffect;

	// Token: 0x040039DB RID: 14811
	public GameObject CameraFlash;

	// Token: 0x040039DC RID: 14812
	public GameObject ChaseCamera;

	// Token: 0x040039DD RID: 14813
	public GameObject DeathScream;

	// Token: 0x040039DE RID: 14814
	public GameObject PepperSpray;

	// Token: 0x040039DF RID: 14815
	public GameObject PinkSeifuku;

	// Token: 0x040039E0 RID: 14816
	public GameObject RetroCamera;

	// Token: 0x040039E1 RID: 14817
	public GameObject WateringCan;

	// Token: 0x040039E2 RID: 14818
	public GameObject BagOfChips;

	// Token: 0x040039E3 RID: 14819
	public GameObject BloodSpray;

	// Token: 0x040039E4 RID: 14820
	public GameObject GarbageBag;

	// Token: 0x040039E5 RID: 14821
	public GameObject Sketchbook;

	// Token: 0x040039E6 RID: 14822
	public GameObject SmartPhone;

	// Token: 0x040039E7 RID: 14823
	public GameObject OccultBook;

	// Token: 0x040039E8 RID: 14824
	public GameObject Paintbrush;

	// Token: 0x040039E9 RID: 14825
	public GameObject AlarmDisc;

	// Token: 0x040039EA RID: 14826
	public GameObject Character;

	// Token: 0x040039EB RID: 14827
	public GameObject Cigarette;

	// Token: 0x040039EC RID: 14828
	public GameObject EventBook;

	// Token: 0x040039ED RID: 14829
	public GameObject Handcuffs;

	// Token: 0x040039EE RID: 14830
	public GameObject HealthBar;

	// Token: 0x040039EF RID: 14831
	public GameObject OsanaHair;

	// Token: 0x040039F0 RID: 14832
	public GameObject WeaponBag;

	// Token: 0x040039F1 RID: 14833
	public GameObject CandyBar;

	// Token: 0x040039F2 RID: 14834
	public GameObject Earpiece;

	// Token: 0x040039F3 RID: 14835
	public GameObject Scrubber;

	// Token: 0x040039F4 RID: 14836
	public GameObject Armband;

	// Token: 0x040039F5 RID: 14837
	public GameObject BookBag;

	// Token: 0x040039F6 RID: 14838
	public GameObject Lighter;

	// Token: 0x040039F7 RID: 14839
	public GameObject MyPaper;

	// Token: 0x040039F8 RID: 14840
	public GameObject Octodog;

	// Token: 0x040039F9 RID: 14841
	public GameObject Palette;

	// Token: 0x040039FA RID: 14842
	public GameObject Eraser;

	// Token: 0x040039FB RID: 14843
	public GameObject Giggle;

	// Token: 0x040039FC RID: 14844
	public GameObject Marker;

	// Token: 0x040039FD RID: 14845
	public GameObject Pencil;

	// Token: 0x040039FE RID: 14846
	public GameObject Weapon;

	// Token: 0x040039FF RID: 14847
	public GameObject Bento;

	// Token: 0x04003A00 RID: 14848
	public GameObject Paper;

	// Token: 0x04003A01 RID: 14849
	public GameObject Note;

	// Token: 0x04003A02 RID: 14850
	public GameObject Pen;

	// Token: 0x04003A03 RID: 14851
	public GameObject Lid;

	// Token: 0x04003A04 RID: 14852
	public bool InvestigatingPossibleBlood;

	// Token: 0x04003A05 RID: 14853
	public bool InvestigatingPossibleDeath;

	// Token: 0x04003A06 RID: 14854
	public bool InvestigatingPossibleLimb;

	// Token: 0x04003A07 RID: 14855
	public bool SpecialRivalDeathReaction;

	// Token: 0x04003A08 RID: 14856
	public bool WitnessedMindBrokenMurder;

	// Token: 0x04003A09 RID: 14857
	public bool ReturningMisplacedWeapon;

	// Token: 0x04003A0A RID: 14858
	public bool SenpaiWitnessingRivalDie;

	// Token: 0x04003A0B RID: 14859
	public bool TargetedForDistraction;

	// Token: 0x04003A0C RID: 14860
	public bool SchoolwearUnavailable;

	// Token: 0x04003A0D RID: 14861
	public bool WitnessedBloodyWeapon;

	// Token: 0x04003A0E RID: 14862
	public bool IgnoringPettyActions;

	// Token: 0x04003A0F RID: 14863
	public bool ReturnToRoutineAfter;

	// Token: 0x04003A10 RID: 14864
	public bool ActivateIncinerator;

	// Token: 0x04003A11 RID: 14865
	public bool MustChangeClothing;

	// Token: 0x04003A12 RID: 14866
	public bool SawCorpseThisFrame;

	// Token: 0x04003A13 RID: 14867
	public bool WitnessedBloodPool;

	// Token: 0x04003A14 RID: 14868
	public bool WitnessedSomething;

	// Token: 0x04003A15 RID: 14869
	public bool FoundFriendCorpse;

	// Token: 0x04003A16 RID: 14870
	public bool MurderedByFragile;

	// Token: 0x04003A17 RID: 14871
	public bool MurderedByStudent;

	// Token: 0x04003A18 RID: 14872
	public bool OriginallyTeacher;

	// Token: 0x04003A19 RID: 14873
	public bool ReturningFromSave;

	// Token: 0x04003A1A RID: 14874
	public bool DramaticReaction;

	// Token: 0x04003A1B RID: 14875
	public bool EventInterrupted;

	// Token: 0x04003A1C RID: 14876
	public bool FoundEnemyCorpse;

	// Token: 0x04003A1D RID: 14877
	public bool ImmuneToLaughter;

	// Token: 0x04003A1E RID: 14878
	public bool LostTeacherTrust;

	// Token: 0x04003A1F RID: 14879
	public bool TemporarilyBlind;

	// Token: 0x04003A20 RID: 14880
	public bool WitnessedCoverUp;

	// Token: 0x04003A21 RID: 14881
	public bool WitnessedCorpse;

	// Token: 0x04003A22 RID: 14882
	public bool WitnessedMurder;

	// Token: 0x04003A23 RID: 14883
	public bool WitnessedWeapon;

	// Token: 0x04003A24 RID: 14884
	public bool VerballyReacted;

	// Token: 0x04003A25 RID: 14885
	public bool VisitSenpaiDesk;

	// Token: 0x04003A26 RID: 14886
	public bool YandereInnocent;

	// Token: 0x04003A27 RID: 14887
	public bool GetNewAnimation = true;

	// Token: 0x04003A28 RID: 14888
	public bool AttackWillFail;

	// Token: 0x04003A29 RID: 14889
	public bool CanStillNotice;

	// Token: 0x04003A2A RID: 14890
	public bool FocusOnYandere;

	// Token: 0x04003A2B RID: 14891
	public bool ManualRotation;

	// Token: 0x04003A2C RID: 14892
	public bool NotActuallyWet;

	// Token: 0x04003A2D RID: 14893
	public bool PinDownWitness;

	// Token: 0x04003A2E RID: 14894
	public bool RepeatReaction;

	// Token: 0x04003A2F RID: 14895
	public bool StalkerFleeing;

	// Token: 0x04003A30 RID: 14896
	public bool YandereVisible;

	// Token: 0x04003A31 RID: 14897
	public bool AwareOfCorpse;

	// Token: 0x04003A32 RID: 14898
	public bool AwareOfMurder;

	// Token: 0x04003A33 RID: 14899
	public bool CrimeReported;

	// Token: 0x04003A34 RID: 14900
	public bool FleeWhenClean;

	// Token: 0x04003A35 RID: 14901
	public bool MurderSuicide;

	// Token: 0x04003A36 RID: 14902
	public bool PhotoEvidence;

	// Token: 0x04003A37 RID: 14903
	public bool RespectEarned;

	// Token: 0x04003A38 RID: 14904
	public bool WitnessedLimb;

	// Token: 0x04003A39 RID: 14905
	public bool BeenSplashed;

	// Token: 0x04003A3A RID: 14906
	public bool BoobsResized;

	// Token: 0x04003A3B RID: 14907
	public bool CanTakeSnack;

	// Token: 0x04003A3C RID: 14908
	public bool CheckingNote;

	// Token: 0x04003A3D RID: 14909
	public bool ClubActivity;

	// Token: 0x04003A3E RID: 14910
	public bool Complimented;

	// Token: 0x04003A3F RID: 14911
	public bool Electrocuted;

	// Token: 0x04003A40 RID: 14912
	public bool FragileSlave;

	// Token: 0x04003A41 RID: 14913
	public bool HoldingHands;

	// Token: 0x04003A42 RID: 14914
	public bool PlayingAudio;

	// Token: 0x04003A43 RID: 14915
	public bool StopRotating;

	// Token: 0x04003A44 RID: 14916
	public bool SawFriendDie;

	// Token: 0x04003A45 RID: 14917
	public bool SentToLocker;

	// Token: 0x04003A46 RID: 14918
	public bool TurnOffRadio;

	// Token: 0x04003A47 RID: 14919
	public bool BusyAtLunch;

	// Token: 0x04003A48 RID: 14920
	public bool CanGiveHelp;

	// Token: 0x04003A49 RID: 14921
	public bool Electrified;

	// Token: 0x04003A4A RID: 14922
	public bool HeardScream;

	// Token: 0x04003A4B RID: 14923
	public bool HelpOffered;

	// Token: 0x04003A4C RID: 14924
	public bool IgnoreBlood;

	// Token: 0x04003A4D RID: 14925
	public bool MusumeRight;

	// Token: 0x04003A4E RID: 14926
	public bool NeckSnapped;

	// Token: 0x04003A4F RID: 14927
	public bool UpdateSkirt;

	// Token: 0x04003A50 RID: 14928
	public bool Traumatized;

	// Token: 0x04003A51 RID: 14929
	public bool WillCombust;

	// Token: 0x04003A52 RID: 14930
	public bool ClubAttire;

	// Token: 0x04003A53 RID: 14931
	public bool ClubLeader;

	// Token: 0x04003A54 RID: 14932
	public bool Confessing;

	// Token: 0x04003A55 RID: 14933
	public bool Distracted;

	// Token: 0x04003A56 RID: 14934
	public bool ExtraBento;

	// Token: 0x04003A57 RID: 14935
	public bool KilledMood;

	// Token: 0x04003A58 RID: 14936
	public bool InDarkness;

	// Token: 0x04003A59 RID: 14937
	public bool Infatuated;

	// Token: 0x04003A5A RID: 14938
	public bool LewdPhotos;

	// Token: 0x04003A5B RID: 14939
	public bool SwitchBack;

	// Token: 0x04003A5C RID: 14940
	public bool Threatened;

	// Token: 0x04003A5D RID: 14941
	public bool BatheFast;

	// Token: 0x04003A5E RID: 14942
	public bool Counselor;

	// Token: 0x04003A5F RID: 14943
	public bool Depressed;

	// Token: 0x04003A60 RID: 14944
	public bool DiscCheck;

	// Token: 0x04003A61 RID: 14945
	public bool DressCode;

	// Token: 0x04003A62 RID: 14946
	public bool Drownable;

	// Token: 0x04003A63 RID: 14947
	public bool DyedBrown;

	// Token: 0x04003A64 RID: 14948
	public bool EndSearch;

	// Token: 0x04003A65 RID: 14949
	public bool GasWarned;

	// Token: 0x04003A66 RID: 14950
	public bool KnifeDown;

	// Token: 0x04003A67 RID: 14951
	public bool LongSkirt;

	// Token: 0x04003A68 RID: 14952
	public bool NoBreakUp;

	// Token: 0x04003A69 RID: 14953
	public bool NoRagdoll;

	// Token: 0x04003A6A RID: 14954
	public bool Phoneless;

	// Token: 0x04003A6B RID: 14955
	public bool RingReact;

	// Token: 0x04003A6C RID: 14956
	public bool TrueAlone;

	// Token: 0x04003A6D RID: 14957
	public bool WillChase;

	// Token: 0x04003A6E RID: 14958
	public bool Attacked;

	// Token: 0x04003A6F RID: 14959
	public bool BakeSale;

	// Token: 0x04003A70 RID: 14960
	public bool CanBeFed;

	// Token: 0x04003A71 RID: 14961
	public bool Headache;

	// Token: 0x04003A72 RID: 14962
	public bool Gossiped;

	// Token: 0x04003A73 RID: 14963
	public bool Pushable;

	// Token: 0x04003A74 RID: 14964
	public bool PyroUrge;

	// Token: 0x04003A75 RID: 14965
	public bool Reflexes;

	// Token: 0x04003A76 RID: 14966
	public bool Replaced;

	// Token: 0x04003A77 RID: 14967
	public bool Restless;

	// Token: 0x04003A78 RID: 14968
	public bool SentHome;

	// Token: 0x04003A79 RID: 14969
	public bool Splashed;

	// Token: 0x04003A7A RID: 14970
	public bool Tranquil;

	// Token: 0x04003A7B RID: 14971
	public bool WalkBack;

	// Token: 0x04003A7C RID: 14972
	public bool Alarmed;

	// Token: 0x04003A7D RID: 14973
	public bool BadTime;

	// Token: 0x04003A7E RID: 14974
	public bool Bullied;

	// Token: 0x04003A7F RID: 14975
	public bool Drowned;

	// Token: 0x04003A80 RID: 14976
	public bool Forgave;

	// Token: 0x04003A81 RID: 14977
	public bool GiftBox;

	// Token: 0x04003A82 RID: 14978
	public bool Indoors;

	// Token: 0x04003A83 RID: 14979
	public bool InEvent;

	// Token: 0x04003A84 RID: 14980
	public bool Injured;

	// Token: 0x04003A85 RID: 14981
	public bool Nemesis;

	// Token: 0x04003A86 RID: 14982
	public bool Private;

	// Token: 0x04003A87 RID: 14983
	public bool Reacted;

	// Token: 0x04003A88 RID: 14984
	public bool Removed;

	// Token: 0x04003A89 RID: 14985
	public bool SawMask;

	// Token: 0x04003A8A RID: 14986
	public bool Sedated;

	// Token: 0x04003A8B RID: 14987
	public bool SlideIn;

	// Token: 0x04003A8C RID: 14988
	public bool Spawned;

	// Token: 0x04003A8D RID: 14989
	public bool Started;

	// Token: 0x04003A8E RID: 14990
	public bool Suicide;

	// Token: 0x04003A8F RID: 14991
	public bool Teacher;

	// Token: 0x04003A90 RID: 14992
	public bool Tripped;

	// Token: 0x04003A91 RID: 14993
	public bool Witness;

	// Token: 0x04003A92 RID: 14994
	public bool Bloody;

	// Token: 0x04003A93 RID: 14995
	public bool CanTalk = true;

	// Token: 0x04003A94 RID: 14996
	public bool Emetic;

	// Token: 0x04003A95 RID: 14997
	public bool Lethal;

	// Token: 0x04003A96 RID: 14998
	public bool Routine = true;

	// Token: 0x04003A97 RID: 14999
	public bool Friend;

	// Token: 0x04003A98 RID: 15000
	public bool GoAway;

	// Token: 0x04003A99 RID: 15001
	public bool Grudge;

	// Token: 0x04003A9A RID: 15002
	public bool Hungry;

	// Token: 0x04003A9B RID: 15003
	public bool Hunted;

	// Token: 0x04003A9C RID: 15004
	public bool NoTalk;

	// Token: 0x04003A9D RID: 15005
	public bool Paired;

	// Token: 0x04003A9E RID: 15006
	public bool Pushed;

	// Token: 0x04003A9F RID: 15007
	public bool Sleepy;

	// Token: 0x04003AA0 RID: 15008
	public bool Urgent;

	// Token: 0x04003AA1 RID: 15009
	public bool Warned;

	// Token: 0x04003AA2 RID: 15010
	public bool Alone;

	// Token: 0x04003AA3 RID: 15011
	public bool Blind;

	// Token: 0x04003AA4 RID: 15012
	public bool Eaten;

	// Token: 0x04003AA5 RID: 15013
	public bool Hurry;

	// Token: 0x04003AA6 RID: 15014
	public bool Rival;

	// Token: 0x04003AA7 RID: 15015
	public bool Slave;

	// Token: 0x04003AA8 RID: 15016
	public bool Calm;

	// Token: 0x04003AA9 RID: 15017
	public bool Halt;

	// Token: 0x04003AAA RID: 15018
	public bool Lost;

	// Token: 0x04003AAB RID: 15019
	public bool Male;

	// Token: 0x04003AAC RID: 15020
	public bool Rose;

	// Token: 0x04003AAD RID: 15021
	public bool Safe;

	// Token: 0x04003AAE RID: 15022
	public bool Stop;

	// Token: 0x04003AAF RID: 15023
	public bool AoT;

	// Token: 0x04003AB0 RID: 15024
	public bool Fed;

	// Token: 0x04003AB1 RID: 15025
	public bool Gas;

	// Token: 0x04003AB2 RID: 15026
	public bool Shy;

	// Token: 0x04003AB3 RID: 15027
	public bool Wet;

	// Token: 0x04003AB4 RID: 15028
	public bool Won;

	// Token: 0x04003AB5 RID: 15029
	public bool DK;

	// Token: 0x04003AB6 RID: 15030
	public bool NotAlarmedByYandereChan;

	// Token: 0x04003AB7 RID: 15031
	public bool InvestigatingBloodPool;

	// Token: 0x04003AB8 RID: 15032
	public bool ResumeTakingOutTrash;

	// Token: 0x04003AB9 RID: 15033
	public bool RetreivingMedicine;

	// Token: 0x04003ABA RID: 15034
	public bool ListeningToReport;

	// Token: 0x04003ABB RID: 15035
	public bool ResumeDistracting;

	// Token: 0x04003ABC RID: 15036
	public bool UpdateAppearance;

	// Token: 0x04003ABD RID: 15037
	public bool BreakingUpFight;

	// Token: 0x04003ABE RID: 15038
	public bool SeekingMedicine;

	// Token: 0x04003ABF RID: 15039
	public bool ReportingMurder;

	// Token: 0x04003AC0 RID: 15040
	public bool CameraReacting;

	// Token: 0x04003AC1 RID: 15041
	public bool UsingRigidbody;

	// Token: 0x04003AC2 RID: 15042
	public bool ReportingBlood;

	// Token: 0x04003AC3 RID: 15043
	public bool TakingOutTrash;

	// Token: 0x04003AC4 RID: 15044
	public bool FightingSlave;

	// Token: 0x04003AC5 RID: 15045
	public bool Investigating;

	// Token: 0x04003AC6 RID: 15046
	public bool SolvingPuzzle;

	// Token: 0x04003AC7 RID: 15047
	public bool ChangingShoes;

	// Token: 0x04003AC8 RID: 15048
	public bool Distracting;

	// Token: 0x04003AC9 RID: 15049
	public bool EatingSnack;

	// Token: 0x04003ACA RID: 15050
	public bool HitReacting;

	// Token: 0x04003ACB RID: 15051
	public bool PinningDown;

	// Token: 0x04003ACC RID: 15052
	public bool WasHurrying;

	// Token: 0x04003ACD RID: 15053
	public bool Struggling;

	// Token: 0x04003ACE RID: 15054
	public bool Following;

	// Token: 0x04003ACF RID: 15055
	public bool Sleuthing;

	// Token: 0x04003AD0 RID: 15056
	public bool Stripping;

	// Token: 0x04003AD1 RID: 15057
	public bool Fighting;

	// Token: 0x04003AD2 RID: 15058
	public bool Guarding;

	// Token: 0x04003AD3 RID: 15059
	public bool Ignoring;

	// Token: 0x04003AD4 RID: 15060
	public bool Spraying;

	// Token: 0x04003AD5 RID: 15061
	public bool Tripping;

	// Token: 0x04003AD6 RID: 15062
	public bool Vomiting;

	// Token: 0x04003AD7 RID: 15063
	public bool Burning;

	// Token: 0x04003AD8 RID: 15064
	public bool Chasing;

	// Token: 0x04003AD9 RID: 15065
	public bool Curious;

	// Token: 0x04003ADA RID: 15066
	public bool Fleeing;

	// Token: 0x04003ADB RID: 15067
	public bool Hunting;

	// Token: 0x04003ADC RID: 15068
	public bool Leaving;

	// Token: 0x04003ADD RID: 15069
	public bool Meeting;

	// Token: 0x04003ADE RID: 15070
	public bool Shoving;

	// Token: 0x04003ADF RID: 15071
	public bool Talking;

	// Token: 0x04003AE0 RID: 15072
	public bool Waiting;

	// Token: 0x04003AE1 RID: 15073
	public bool Dodging;

	// Token: 0x04003AE2 RID: 15074
	public bool Posing;

	// Token: 0x04003AE3 RID: 15075
	public bool Dying;

	// Token: 0x04003AE4 RID: 15076
	public float DistanceToDestination;

	// Token: 0x04003AE5 RID: 15077
	public float FollowTargetDistance;

	// Token: 0x04003AE6 RID: 15078
	public float DistanceToPlayer;

	// Token: 0x04003AE7 RID: 15079
	public float TargetDistance;

	// Token: 0x04003AE8 RID: 15080
	public float ThreatDistance;

	// Token: 0x04003AE9 RID: 15081
	public float LockerRoomCheckTimer;

	// Token: 0x04003AEA RID: 15082
	public float WitnessCooldownTimer;

	// Token: 0x04003AEB RID: 15083
	public float InvestigationTimer;

	// Token: 0x04003AEC RID: 15084
	public float PersonalSpaceTimer;

	// Token: 0x04003AED RID: 15085
	public float CameraPoseTimer;

	// Token: 0x04003AEE RID: 15086
	public float IgnoreFoodTimer;

	// Token: 0x04003AEF RID: 15087
	public float RivalDeathTimer;

	// Token: 0x04003AF0 RID: 15088
	public float CuriosityTimer;

	// Token: 0x04003AF1 RID: 15089
	public float DistractTimer;

	// Token: 0x04003AF2 RID: 15090
	public float DramaticTimer;

	// Token: 0x04003AF3 RID: 15091
	public float MedicineTimer;

	// Token: 0x04003AF4 RID: 15092
	public float ReactionTimer;

	// Token: 0x04003AF5 RID: 15093
	public float WalkBackTimer;

	// Token: 0x04003AF6 RID: 15094
	public float AmnesiaTimer;

	// Token: 0x04003AF7 RID: 15095
	public float ElectroTimer;

	// Token: 0x04003AF8 RID: 15096
	public float PuzzleTimer;

	// Token: 0x04003AF9 RID: 15097
	public float GiggleTimer;

	// Token: 0x04003AFA RID: 15098
	public float GoAwayTimer;

	// Token: 0x04003AFB RID: 15099
	public float IgnoreTimer;

	// Token: 0x04003AFC RID: 15100
	public float LyricsTimer;

	// Token: 0x04003AFD RID: 15101
	public float MiyukiTimer;

	// Token: 0x04003AFE RID: 15102
	public float MusumeTimer;

	// Token: 0x04003AFF RID: 15103
	public float PatrolTimer;

	// Token: 0x04003B00 RID: 15104
	public float ReportTimer;

	// Token: 0x04003B01 RID: 15105
	public float SplashTimer;

	// Token: 0x04003B02 RID: 15106
	public float ThreatTimer;

	// Token: 0x04003B03 RID: 15107
	public float UpdateTimer;

	// Token: 0x04003B04 RID: 15108
	public float AlarmTimer;

	// Token: 0x04003B05 RID: 15109
	public float BatheTimer;

	// Token: 0x04003B06 RID: 15110
	public float ChaseTimer;

	// Token: 0x04003B07 RID: 15111
	public float CheerTimer;

	// Token: 0x04003B08 RID: 15112
	public float CleanTimer;

	// Token: 0x04003B09 RID: 15113
	public float LaughTimer;

	// Token: 0x04003B0A RID: 15114
	public float RadioTimer;

	// Token: 0x04003B0B RID: 15115
	public float SnackTimer;

	// Token: 0x04003B0C RID: 15116
	public float SprayTimer;

	// Token: 0x04003B0D RID: 15117
	public float StuckTimer;

	// Token: 0x04003B0E RID: 15118
	public float ClubTimer;

	// Token: 0x04003B0F RID: 15119
	public float MeetTimer;

	// Token: 0x04003B10 RID: 15120
	public float PyroTimer;

	// Token: 0x04003B11 RID: 15121
	public float SulkTimer;

	// Token: 0x04003B12 RID: 15122
	public float TalkTimer;

	// Token: 0x04003B13 RID: 15123
	public float WaitTimer;

	// Token: 0x04003B14 RID: 15124
	public float SewTimer;

	// Token: 0x04003B15 RID: 15125
	public float OriginalYPosition;

	// Token: 0x04003B16 RID: 15126
	public float PreviousEyeShrink;

	// Token: 0x04003B17 RID: 15127
	public float PhotoPatience;

	// Token: 0x04003B18 RID: 15128
	public float PreviousAlarm;

	// Token: 0x04003B19 RID: 15129
	public float ClubThreshold = 6f;

	// Token: 0x04003B1A RID: 15130
	public float RepDeduction;

	// Token: 0x04003B1B RID: 15131
	public float RepRecovery;

	// Token: 0x04003B1C RID: 15132
	public float BreastSize;

	// Token: 0x04003B1D RID: 15133
	public float DodgeSpeed = 2f;

	// Token: 0x04003B1E RID: 15134
	public float Hesitation;

	// Token: 0x04003B1F RID: 15135
	public float PendingRep;

	// Token: 0x04003B20 RID: 15136
	public float Perception = 1f;

	// Token: 0x04003B21 RID: 15137
	public float EyeShrink;

	// Token: 0x04003B22 RID: 15138
	public float WalkSpeed = 1f;

	// Token: 0x04003B23 RID: 15139
	public float MeetTime;

	// Token: 0x04003B24 RID: 15140
	public float Paranoia;

	// Token: 0x04003B25 RID: 15141
	public float RepLoss;

	// Token: 0x04003B26 RID: 15142
	public float Health = 100f;

	// Token: 0x04003B27 RID: 15143
	public float Alarm;

	// Token: 0x04003B28 RID: 15144
	public int ReturningMisplacedWeaponPhase;

	// Token: 0x04003B29 RID: 15145
	public int RetrieveMedicinePhase;

	// Token: 0x04003B2A RID: 15146
	public int WitnessRivalDiePhase;

	// Token: 0x04003B2B RID: 15147
	public int ChangeClothingPhase;

	// Token: 0x04003B2C RID: 15148
	public int InvestigationPhase;

	// Token: 0x04003B2D RID: 15149
	public int MurderSuicidePhase;

	// Token: 0x04003B2E RID: 15150
	public int ClubActivityPhase;

	// Token: 0x04003B2F RID: 15151
	public int SeekMedicinePhase;

	// Token: 0x04003B30 RID: 15152
	public int CameraReactPhase;

	// Token: 0x04003B31 RID: 15153
	public int CuriosityPhase;

	// Token: 0x04003B32 RID: 15154
	public int DramaticPhase;

	// Token: 0x04003B33 RID: 15155
	public int GraffitiPhase;

	// Token: 0x04003B34 RID: 15156
	public int SentHomePhase;

	// Token: 0x04003B35 RID: 15157
	public int SunbathePhase;

	// Token: 0x04003B36 RID: 15158
	public int ConfessPhase = 1;

	// Token: 0x04003B37 RID: 15159
	public int SciencePhase;

	// Token: 0x04003B38 RID: 15160
	public int LyricsPhase;

	// Token: 0x04003B39 RID: 15161
	public int ReportPhase;

	// Token: 0x04003B3A RID: 15162
	public int SplashPhase;

	// Token: 0x04003B3B RID: 15163
	public int ThreatPhase = 1;

	// Token: 0x04003B3C RID: 15164
	public int BathePhase;

	// Token: 0x04003B3D RID: 15165
	public int BullyPhase;

	// Token: 0x04003B3E RID: 15166
	public int RadioPhase = 1;

	// Token: 0x04003B3F RID: 15167
	public int SnackPhase;

	// Token: 0x04003B40 RID: 15168
	public int TrashPhase;

	// Token: 0x04003B41 RID: 15169
	public int VomitPhase;

	// Token: 0x04003B42 RID: 15170
	public int ClubPhase;

	// Token: 0x04003B43 RID: 15171
	public int PyroPhase;

	// Token: 0x04003B44 RID: 15172
	public int SulkPhase;

	// Token: 0x04003B45 RID: 15173
	public int TaskPhase;

	// Token: 0x04003B46 RID: 15174
	public int ReadPhase;

	// Token: 0x04003B47 RID: 15175
	public int PinPhase;

	// Token: 0x04003B48 RID: 15176
	public int Phase;

	// Token: 0x04003B49 RID: 15177
	public PersonaType OriginalPersona;

	// Token: 0x04003B4A RID: 15178
	public StudentInteractionType Interaction;

	// Token: 0x04003B4B RID: 15179
	public int BloodPoolsSpawned;

	// Token: 0x04003B4C RID: 15180
	public int LovestruckTarget;

	// Token: 0x04003B4D RID: 15181
	public int MurdersWitnessed;

	// Token: 0x04003B4E RID: 15182
	public int WeaponWitnessed;

	// Token: 0x04003B4F RID: 15183
	public int MurderReaction;

	// Token: 0x04003B50 RID: 15184
	public int PhaseFromSave;

	// Token: 0x04003B51 RID: 15185
	public int CleaningRole;

	// Token: 0x04003B52 RID: 15186
	public int StruggleWait;

	// Token: 0x04003B53 RID: 15187
	public int TimesAnnoyed;

	// Token: 0x04003B54 RID: 15188
	public int GossipBonus;

	// Token: 0x04003B55 RID: 15189
	public int DeathCause;

	// Token: 0x04003B56 RID: 15190
	public int Schoolwear;

	// Token: 0x04003B57 RID: 15191
	public int SkinColor = 3;

	// Token: 0x04003B58 RID: 15192
	public int Attempts;

	// Token: 0x04003B59 RID: 15193
	public int Patience = 5;

	// Token: 0x04003B5A RID: 15194
	public int Pestered;

	// Token: 0x04003B5B RID: 15195
	public int RepBonus;

	// Token: 0x04003B5C RID: 15196
	public int Strength;

	// Token: 0x04003B5D RID: 15197
	public int Concern;

	// Token: 0x04003B5E RID: 15198
	public int Defeats;

	// Token: 0x04003B5F RID: 15199
	public int Crush;

	// Token: 0x04003B60 RID: 15200
	public StudentWitnessType PreviouslyWitnessed;

	// Token: 0x04003B61 RID: 15201
	public StudentWitnessType Witnessed;

	// Token: 0x04003B62 RID: 15202
	public GameOverType GameOverCause;

	// Token: 0x04003B63 RID: 15203
	public DeathType DeathType;

	// Token: 0x04003B64 RID: 15204
	public string CurrentAnim = string.Empty;

	// Token: 0x04003B65 RID: 15205
	public string RivalPrefix = string.Empty;

	// Token: 0x04003B66 RID: 15206
	public string RandomAnim = string.Empty;

	// Token: 0x04003B67 RID: 15207
	public string Accessory = string.Empty;

	// Token: 0x04003B68 RID: 15208
	public string Hairstyle = string.Empty;

	// Token: 0x04003B69 RID: 15209
	public string Suffix = string.Empty;

	// Token: 0x04003B6A RID: 15210
	public string Name = string.Empty;

	// Token: 0x04003B6B RID: 15211
	public string OriginalOriginalWalkAnim = string.Empty;

	// Token: 0x04003B6C RID: 15212
	public string OriginalOriginalSprintAnim = string.Empty;

	// Token: 0x04003B6D RID: 15213
	public string OriginalIdleAnim = string.Empty;

	// Token: 0x04003B6E RID: 15214
	public string OriginalWalkAnim = string.Empty;

	// Token: 0x04003B6F RID: 15215
	public string OriginalSprintAnim = string.Empty;

	// Token: 0x04003B70 RID: 15216
	public string OriginalLeanAnim = string.Empty;

	// Token: 0x04003B71 RID: 15217
	public string WalkAnim = string.Empty;

	// Token: 0x04003B72 RID: 15218
	public string RunAnim = string.Empty;

	// Token: 0x04003B73 RID: 15219
	public string SprintAnim = string.Empty;

	// Token: 0x04003B74 RID: 15220
	public string IdleAnim = string.Empty;

	// Token: 0x04003B75 RID: 15221
	public string Nod1Anim = string.Empty;

	// Token: 0x04003B76 RID: 15222
	public string Nod2Anim = string.Empty;

	// Token: 0x04003B77 RID: 15223
	public string DefendAnim = string.Empty;

	// Token: 0x04003B78 RID: 15224
	public string DeathAnim = string.Empty;

	// Token: 0x04003B79 RID: 15225
	public string ScaredAnim = string.Empty;

	// Token: 0x04003B7A RID: 15226
	public string EvilWitnessAnim = string.Empty;

	// Token: 0x04003B7B RID: 15227
	public string LookDownAnim = string.Empty;

	// Token: 0x04003B7C RID: 15228
	public string PhoneAnim = string.Empty;

	// Token: 0x04003B7D RID: 15229
	public string AngryFaceAnim = string.Empty;

	// Token: 0x04003B7E RID: 15230
	public string ToughFaceAnim = string.Empty;

	// Token: 0x04003B7F RID: 15231
	public string InspectAnim = string.Empty;

	// Token: 0x04003B80 RID: 15232
	public string GuardAnim = string.Empty;

	// Token: 0x04003B81 RID: 15233
	public string CallAnim = string.Empty;

	// Token: 0x04003B82 RID: 15234
	public string CounterAnim = string.Empty;

	// Token: 0x04003B83 RID: 15235
	public string PushedAnim = string.Empty;

	// Token: 0x04003B84 RID: 15236
	public string GameAnim = string.Empty;

	// Token: 0x04003B85 RID: 15237
	public string BentoAnim = string.Empty;

	// Token: 0x04003B86 RID: 15238
	public string EatAnim = string.Empty;

	// Token: 0x04003B87 RID: 15239
	public string DrownAnim = string.Empty;

	// Token: 0x04003B88 RID: 15240
	public string WetAnim = string.Empty;

	// Token: 0x04003B89 RID: 15241
	public string SplashedAnim = string.Empty;

	// Token: 0x04003B8A RID: 15242
	public string StripAnim = string.Empty;

	// Token: 0x04003B8B RID: 15243
	public string ParanoidAnim = string.Empty;

	// Token: 0x04003B8C RID: 15244
	public string GossipAnim = string.Empty;

	// Token: 0x04003B8D RID: 15245
	public string SadSitAnim = string.Empty;

	// Token: 0x04003B8E RID: 15246
	public string BrokenAnim = string.Empty;

	// Token: 0x04003B8F RID: 15247
	public string BrokenSitAnim = string.Empty;

	// Token: 0x04003B90 RID: 15248
	public string BrokenWalkAnim = string.Empty;

	// Token: 0x04003B91 RID: 15249
	public string FistAnim = string.Empty;

	// Token: 0x04003B92 RID: 15250
	public string AttackAnim = string.Empty;

	// Token: 0x04003B93 RID: 15251
	public string SuicideAnim = string.Empty;

	// Token: 0x04003B94 RID: 15252
	public string RelaxAnim = string.Empty;

	// Token: 0x04003B95 RID: 15253
	public string SitAnim = string.Empty;

	// Token: 0x04003B96 RID: 15254
	public string ShyAnim = string.Empty;

	// Token: 0x04003B97 RID: 15255
	public string PeekAnim = string.Empty;

	// Token: 0x04003B98 RID: 15256
	public string ClubAnim = string.Empty;

	// Token: 0x04003B99 RID: 15257
	public string StruggleAnim = string.Empty;

	// Token: 0x04003B9A RID: 15258
	public string StruggleWonAnim = string.Empty;

	// Token: 0x04003B9B RID: 15259
	public string StruggleLostAnim = string.Empty;

	// Token: 0x04003B9C RID: 15260
	public string SocialSitAnim = string.Empty;

	// Token: 0x04003B9D RID: 15261
	public string CarryAnim = string.Empty;

	// Token: 0x04003B9E RID: 15262
	public string ActivityAnim = string.Empty;

	// Token: 0x04003B9F RID: 15263
	public string GrudgeAnim = string.Empty;

	// Token: 0x04003BA0 RID: 15264
	public string SadFaceAnim = string.Empty;

	// Token: 0x04003BA1 RID: 15265
	public string CowardAnim = string.Empty;

	// Token: 0x04003BA2 RID: 15266
	public string EvilAnim = string.Empty;

	// Token: 0x04003BA3 RID: 15267
	public string SocialReportAnim = string.Empty;

	// Token: 0x04003BA4 RID: 15268
	public string SocialFearAnim = string.Empty;

	// Token: 0x04003BA5 RID: 15269
	public string SocialTerrorAnim = string.Empty;

	// Token: 0x04003BA6 RID: 15270
	public string BuzzSawDeathAnim = string.Empty;

	// Token: 0x04003BA7 RID: 15271
	public string SwingDeathAnim = string.Empty;

	// Token: 0x04003BA8 RID: 15272
	public string CyborgDeathAnim = string.Empty;

	// Token: 0x04003BA9 RID: 15273
	public string WalkBackAnim = string.Empty;

	// Token: 0x04003BAA RID: 15274
	public string PatrolAnim = string.Empty;

	// Token: 0x04003BAB RID: 15275
	public string RadioAnim = string.Empty;

	// Token: 0x04003BAC RID: 15276
	public string BookSitAnim = string.Empty;

	// Token: 0x04003BAD RID: 15277
	public string BookReadAnim = string.Empty;

	// Token: 0x04003BAE RID: 15278
	public string LovedOneAnim = string.Empty;

	// Token: 0x04003BAF RID: 15279
	public string CuddleAnim = string.Empty;

	// Token: 0x04003BB0 RID: 15280
	public string VomitAnim = string.Empty;

	// Token: 0x04003BB1 RID: 15281
	public string WashFaceAnim = string.Empty;

	// Token: 0x04003BB2 RID: 15282
	public string EmeticAnim = string.Empty;

	// Token: 0x04003BB3 RID: 15283
	public string BurningAnim = string.Empty;

	// Token: 0x04003BB4 RID: 15284
	public string JojoReactAnim = string.Empty;

	// Token: 0x04003BB5 RID: 15285
	public string TeachAnim = string.Empty;

	// Token: 0x04003BB6 RID: 15286
	public string LeanAnim = string.Empty;

	// Token: 0x04003BB7 RID: 15287
	public string DeskTextAnim = string.Empty;

	// Token: 0x04003BB8 RID: 15288
	public string CarryShoulderAnim = string.Empty;

	// Token: 0x04003BB9 RID: 15289
	public string ReadyToFightAnim = string.Empty;

	// Token: 0x04003BBA RID: 15290
	public string SearchPatrolAnim = string.Empty;

	// Token: 0x04003BBB RID: 15291
	public string DiscoverPhoneAnim = string.Empty;

	// Token: 0x04003BBC RID: 15292
	public string WaitAnim = string.Empty;

	// Token: 0x04003BBD RID: 15293
	public string ShoveAnim = string.Empty;

	// Token: 0x04003BBE RID: 15294
	public string SprayAnim = string.Empty;

	// Token: 0x04003BBF RID: 15295
	public string SithReactAnim = string.Empty;

	// Token: 0x04003BC0 RID: 15296
	public string EatVictimAnim = string.Empty;

	// Token: 0x04003BC1 RID: 15297
	public string RandomGossipAnim = string.Empty;

	// Token: 0x04003BC2 RID: 15298
	public string CuteAnim = string.Empty;

	// Token: 0x04003BC3 RID: 15299
	public string BulliedIdleAnim = string.Empty;

	// Token: 0x04003BC4 RID: 15300
	public string BulliedWalkAnim = string.Empty;

	// Token: 0x04003BC5 RID: 15301
	public string BullyVictimAnim = string.Empty;

	// Token: 0x04003BC6 RID: 15302
	public string SadDeskSitAnim = string.Empty;

	// Token: 0x04003BC7 RID: 15303
	public string ConfusedSitAnim = string.Empty;

	// Token: 0x04003BC8 RID: 15304
	public string SentHomeAnim = string.Empty;

	// Token: 0x04003BC9 RID: 15305
	public string RandomCheerAnim = string.Empty;

	// Token: 0x04003BCA RID: 15306
	public string ParanoidWalkAnim = string.Empty;

	// Token: 0x04003BCB RID: 15307
	public string SleuthIdleAnim = string.Empty;

	// Token: 0x04003BCC RID: 15308
	public string SleuthWalkAnim = string.Empty;

	// Token: 0x04003BCD RID: 15309
	public string SleuthCalmAnim = string.Empty;

	// Token: 0x04003BCE RID: 15310
	public string SleuthScanAnim = string.Empty;

	// Token: 0x04003BCF RID: 15311
	public string SleuthReactAnim = string.Empty;

	// Token: 0x04003BD0 RID: 15312
	public string SleuthSprintAnim = string.Empty;

	// Token: 0x04003BD1 RID: 15313
	public string SleuthReportAnim = string.Empty;

	// Token: 0x04003BD2 RID: 15314
	public string RandomSleuthAnim = string.Empty;

	// Token: 0x04003BD3 RID: 15315
	public string BreakUpAnim = string.Empty;

	// Token: 0x04003BD4 RID: 15316
	public string PaintAnim = string.Empty;

	// Token: 0x04003BD5 RID: 15317
	public string SketchAnim = string.Empty;

	// Token: 0x04003BD6 RID: 15318
	public string RummageAnim = string.Empty;

	// Token: 0x04003BD7 RID: 15319
	public string ThinkAnim = string.Empty;

	// Token: 0x04003BD8 RID: 15320
	public string ActAnim = string.Empty;

	// Token: 0x04003BD9 RID: 15321
	public string OriginalClubAnim = string.Empty;

	// Token: 0x04003BDA RID: 15322
	public string MiyukiAnim = string.Empty;

	// Token: 0x04003BDB RID: 15323
	public string VictoryAnim = string.Empty;

	// Token: 0x04003BDC RID: 15324
	public string PlateIdleAnim = string.Empty;

	// Token: 0x04003BDD RID: 15325
	public string PlateWalkAnim = string.Empty;

	// Token: 0x04003BDE RID: 15326
	public string PlateEatAnim = string.Empty;

	// Token: 0x04003BDF RID: 15327
	public string PrepareFoodAnim = string.Empty;

	// Token: 0x04003BE0 RID: 15328
	public string PoisonDeathAnim = string.Empty;

	// Token: 0x04003BE1 RID: 15329
	public string HeadacheAnim = string.Empty;

	// Token: 0x04003BE2 RID: 15330
	public string HeadacheSitAnim = string.Empty;

	// Token: 0x04003BE3 RID: 15331
	public string ElectroAnim = string.Empty;

	// Token: 0x04003BE4 RID: 15332
	public string EatChipsAnim = string.Empty;

	// Token: 0x04003BE5 RID: 15333
	public string DrinkFountainAnim = string.Empty;

	// Token: 0x04003BE6 RID: 15334
	public string PullBoxCutterAnim = string.Empty;

	// Token: 0x04003BE7 RID: 15335
	public string TossNoteAnim = string.Empty;

	// Token: 0x04003BE8 RID: 15336
	public string KeepNoteAnim = string.Empty;

	// Token: 0x04003BE9 RID: 15337
	public string BathingAnim = string.Empty;

	// Token: 0x04003BEA RID: 15338
	public string DodgeAnim = string.Empty;

	// Token: 0x04003BEB RID: 15339
	public string InspectBloodAnim = string.Empty;

	// Token: 0x04003BEC RID: 15340
	public string PickUpAnim = string.Empty;

	// Token: 0x04003BED RID: 15341
	public string PuzzleAnim = string.Empty;

	// Token: 0x04003BEE RID: 15342
	public string LandLineAnim = string.Empty;

	// Token: 0x04003BEF RID: 15343
	public string SulkAnim = string.Empty;

	// Token: 0x04003BF0 RID: 15344
	public string BeforeReturnAnim = string.Empty;

	// Token: 0x04003BF1 RID: 15345
	public string[] CleanAnims;

	// Token: 0x04003BF2 RID: 15346
	public string[] CameraAnims;

	// Token: 0x04003BF3 RID: 15347
	public string[] SocialAnims;

	// Token: 0x04003BF4 RID: 15348
	public string[] CowardAnims;

	// Token: 0x04003BF5 RID: 15349
	public string[] EvilAnims;

	// Token: 0x04003BF6 RID: 15350
	public string[] HeroAnims;

	// Token: 0x04003BF7 RID: 15351
	public string[] TaskAnims;

	// Token: 0x04003BF8 RID: 15352
	public string[] PhoneAnims;

	// Token: 0x04003BF9 RID: 15353
	public int ClubMemberID;

	// Token: 0x04003BFA RID: 15354
	public int StudentID;

	// Token: 0x04003BFB RID: 15355
	public int PatrolID;

	// Token: 0x04003BFC RID: 15356
	public int SleuthID;

	// Token: 0x04003BFD RID: 15357
	public int BullyID;

	// Token: 0x04003BFE RID: 15358
	public int CleanID;

	// Token: 0x04003BFF RID: 15359
	public int GuardID;

	// Token: 0x04003C00 RID: 15360
	public int GirlID;

	// Token: 0x04003C01 RID: 15361
	public int Class;

	// Token: 0x04003C02 RID: 15362
	public int ID;

	// Token: 0x04003C03 RID: 15363
	public PersonaType Persona;

	// Token: 0x04003C04 RID: 15364
	public ClubType OriginalClub;

	// Token: 0x04003C05 RID: 15365
	public ClubType Club;

	// Token: 0x04003C06 RID: 15366
	public Vector3 OriginalPlatePosition;

	// Token: 0x04003C07 RID: 15367
	public Vector3 OriginalPosition;

	// Token: 0x04003C08 RID: 15368
	public Vector3 LastKnownCorpse;

	// Token: 0x04003C09 RID: 15369
	public Vector3 DistractionSpot;

	// Token: 0x04003C0A RID: 15370
	public Vector3 LastKnownBlood;

	// Token: 0x04003C0B RID: 15371
	public Vector3 RightEyeOrigin;

	// Token: 0x04003C0C RID: 15372
	public Vector3 LeftEyeOrigin;

	// Token: 0x04003C0D RID: 15373
	public Vector3 PreviousSkirt;

	// Token: 0x04003C0E RID: 15374
	public Vector3 LastPosition;

	// Token: 0x04003C0F RID: 15375
	public Vector3 BurnTarget;

	// Token: 0x04003C10 RID: 15376
	public Transform RightBreast;

	// Token: 0x04003C11 RID: 15377
	public Transform LeftBreast;

	// Token: 0x04003C12 RID: 15378
	public Transform RightEye;

	// Token: 0x04003C13 RID: 15379
	public Transform LeftEye;

	// Token: 0x04003C14 RID: 15380
	public int Frame;

	// Token: 0x04003C15 RID: 15381
	private float MaxSpeed = 10f;

	// Token: 0x04003C16 RID: 15382
	private const string RIVAL_PREFIX = "Rival ";

	// Token: 0x04003C17 RID: 15383
	public Vector3[] SkirtPositions;

	// Token: 0x04003C18 RID: 15384
	public Vector3[] SkirtRotations;

	// Token: 0x04003C19 RID: 15385
	public Vector3[] SkirtOrigins;

	// Token: 0x04003C1A RID: 15386
	public Transform DefaultTarget;

	// Token: 0x04003C1B RID: 15387
	public Transform GushTarget;

	// Token: 0x04003C1C RID: 15388
	public bool Gush;

	// Token: 0x04003C1D RID: 15389
	public float LookSpeed = 2f;

	// Token: 0x04003C1E RID: 15390
	public float TimeOfDeath;

	// Token: 0x04003C1F RID: 15391
	public int Fate;

	// Token: 0x04003C20 RID: 15392
	public LowPolyStudentScript LowPoly;

	// Token: 0x04003C21 RID: 15393
	public GameObject EightiesPhone;

	// Token: 0x04003C22 RID: 15394
	public GameObject JojoHitEffect;

	// Token: 0x04003C23 RID: 15395
	public GameObject[] ElectroSteam;

	// Token: 0x04003C24 RID: 15396
	public GameObject[] CensorSteam;

	// Token: 0x04003C25 RID: 15397
	public Texture NudeTexture;

	// Token: 0x04003C26 RID: 15398
	public Mesh BaldNudeMesh;

	// Token: 0x04003C27 RID: 15399
	public Mesh NudeMesh;

	// Token: 0x04003C28 RID: 15400
	public Texture TowelTexture;

	// Token: 0x04003C29 RID: 15401
	public Mesh TowelMesh;

	// Token: 0x04003C2A RID: 15402
	public Mesh SwimmingTrunks;

	// Token: 0x04003C2B RID: 15403
	public Mesh SchoolSwimsuit;

	// Token: 0x04003C2C RID: 15404
	public Mesh GymUniform;

	// Token: 0x04003C2D RID: 15405
	public Texture GyaruSwimsuitTexture;

	// Token: 0x04003C2E RID: 15406
	public Texture EightiesGymTexture;

	// Token: 0x04003C2F RID: 15407
	public Texture SwimsuitTexture;

	// Token: 0x04003C30 RID: 15408
	public Texture UniformTexture;

	// Token: 0x04003C31 RID: 15409
	public Texture GymTexture;

	// Token: 0x04003C32 RID: 15410
	public Texture TitanBodyTexture;

	// Token: 0x04003C33 RID: 15411
	public Texture TitanFaceTexture;

	// Token: 0x04003C34 RID: 15412
	public bool Spooky;

	// Token: 0x04003C35 RID: 15413
	public Mesh JudoGiMesh;

	// Token: 0x04003C36 RID: 15414
	public Texture JudoGiTexture;

	// Token: 0x04003C37 RID: 15415
	public RiggedAccessoryAttacher Attacher;

	// Token: 0x04003C38 RID: 15416
	public Mesh NoArmsNoTorso;

	// Token: 0x04003C39 RID: 15417
	public GameObject RiggedAccessory;

	// Token: 0x04003C3A RID: 15418
	public int CoupleID;

	// Token: 0x04003C3B RID: 15419
	public int PartnerID;

	// Token: 0x04003C3C RID: 15420
	public float ChameleonBonus;

	// Token: 0x04003C3D RID: 15421
	public bool Chameleon;

	// Token: 0x04003C3E RID: 15422
	public RiggedAccessoryAttacher LabcoatAttacher;

	// Token: 0x04003C3F RID: 15423
	public RiggedAccessoryAttacher BikiniAttacher;

	// Token: 0x04003C40 RID: 15424
	public RiggedAccessoryAttacher ApronAttacher;

	// Token: 0x04003C41 RID: 15425
	public Mesh HeadAndHands;

	// Token: 0x04003C42 RID: 15426
	private bool NoMentor;

	// Token: 0x04003C43 RID: 15427
	public OutlineScript[] RiggedAccessoryOutlines;

	// Token: 0x04003C44 RID: 15428
	public int RiggedAccessoryOutlineID;

	// Token: 0x04003C45 RID: 15429
	public float SavePositionX;

	// Token: 0x04003C46 RID: 15430
	public float SavePositionY;

	// Token: 0x04003C47 RID: 15431
	public float SavePositionZ;
}
