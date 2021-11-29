﻿using System;
using System.Collections;
using HighlightingSystem;
using Pathfinding;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x020004C5 RID: 1221
public class YandereScript : MonoBehaviour
{
	// Token: 0x06001FC7 RID: 8135 RVA: 0x001C3574 File Offset: 0x001C1774
	private void Start()
	{
		Application.runInBackground = false;
		this.SenpaiThreshold = 1f - (float)PlayerGlobals.ShrineItems * 0.1f;
		this.PhysicalGrade = ClassGlobals.PhysicalGrade;
		this.SpeedBonus = PlayerGlobals.SpeedBonus;
		this.Club = ClubGlobals.Club;
		this.SanitySmudges.color = new Color(1f, 1f, 1f, 0f);
		this.SpiderLegs.SetActive(GameGlobals.EmptyDemon);
		this.MyRenderer.materials[2].SetFloat("_BlendAmount1", 0f);
		this.SetAnimationLayers();
		this.UpdateNumbness();
		this.RightEyeOrigin = this.RightEye.localPosition;
		this.LeftEyeOrigin = this.LeftEye.localPosition;
		this.CharacterAnimation["f02_yanderePose_00"].weight = 0f;
		this.CharacterAnimation["f02_cameraPose_00"].weight = 0f;
		this.CharacterAnimation["f02_selfie_00"].weight = 0f;
		this.CharacterAnimation["f02_shipGirlSnap_00"].speed = 2f;
		this.CharacterAnimation["f02_gazerSnap_00"].speed = 2f;
		this.CharacterAnimation["f02_performing_00"].speed = 0.9f;
		this.CharacterAnimation["f02_sithAttack_00"].speed = 1.5f;
		this.CharacterAnimation["f02_sithAttack_01"].speed = 1.5f;
		this.CharacterAnimation["f02_sithAttack_02"].speed = 1.5f;
		this.CharacterAnimation["f02_sithAttackHard_00"].speed = 1.5f;
		this.CharacterAnimation["f02_sithAttackHard_01"].speed = 1.5f;
		this.CharacterAnimation["f02_sithAttackHard_02"].speed = 1.5f;
		this.CharacterAnimation["f02_nierRun_00"].speed = 1.5f;
		CameraFilterPack_Colors_Adjust_PreFilters[] components = this.MainCamera.GetComponents<CameraFilterPack_Colors_Adjust_PreFilters>();
		this.YandereFilter = components[0];
		this.SenpaiFilter = components[1];
		this.HollowFilter = components[3];
		this.ResetYandereEffects();
		this.ResetSenpaiEffects();
		this.Sanity = 100f;
		this.Bloodiness = 0f;
		this.EasterEggMenu.transform.localPosition = new Vector3(this.EasterEggMenu.transform.localPosition.x, 0f, this.EasterEggMenu.transform.localPosition.z);
		this.ProgressBar.transform.parent.gameObject.SetActive(false);
		this.Smartphone.transform.parent.gameObject.SetActive(false);
		this.ObstacleDetector.gameObject.SetActive(false);
		this.SithBeam[1].gameObject.SetActive(false);
		this.SithBeam[2].gameObject.SetActive(false);
		this.PunishedAccessories.SetActive(false);
		this.SukebanAccessories.SetActive(false);
		this.FalconShoulderpad.SetActive(false);
		this.CensorSteam[0].SetActive(false);
		this.CensorSteam[1].SetActive(false);
		this.CensorSteam[2].SetActive(false);
		this.CensorSteam[3].SetActive(false);
		this.FloatingShovel.SetActive(false);
		this.BlackEyePatch.SetActive(false);
		this.EasterEggMenu.SetActive(false);
		this.FalconKneepad1.SetActive(false);
		this.FalconKneepad2.SetActive(false);
		this.PunishedScarf.SetActive(false);
		this.FalconBuckle.SetActive(false);
		this.FalconHelmet.SetActive(false);
		this.TornadoDress.SetActive(false);
		this.Stand.Stand.SetActive(false);
		this.TornadoHair.SetActive(false);
		this.MemeGlasses.SetActive(false);
		this.CirnoWings.SetActive(false);
		this.KONGlasses.SetActive(false);
		this.EbolaWings.SetActive(false);
		this.Microphone.SetActive(false);
		this.Poisons[1].SetActive(false);
		this.Poisons[2].SetActive(false);
		this.Poisons[3].SetActive(false);
		this.BladeHair.SetActive(false);
		this.CirnoHair.SetActive(false);
		this.EbolaHair.SetActive(false);
		this.EyepatchL.SetActive(false);
		this.EyepatchR.SetActive(false);
		this.Handcuffs.SetActive(false);
		this.ZipTie[0].SetActive(false);
		this.ZipTie[1].SetActive(false);
		this.Shoes[0].SetActive(false);
		this.Shoes[1].SetActive(false);
		this.Phone.SetActive(false);
		this.Cape.SetActive(false);
		this.HeavySwordParent.gameObject.SetActive(false);
		this.LightSwordParent.gameObject.SetActive(false);
		this.Pod.SetActive(false);
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		GameObject[] array = this.Armor;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
		this.ID = 1;
		while (this.ID < this.Accessories.Length)
		{
			this.Accessories[this.ID].SetActive(false);
			this.ID++;
		}
		array = this.PunishedArm;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
		array = this.GaloAccessories;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
		array = this.Vectors;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
		this.ID = 1;
		while (this.ID < this.CyborgParts.Length)
		{
			this.CyborgParts[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.KLKParts.Length)
		{
			this.KLKParts[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.BanchoAccessories.Length)
		{
			this.BanchoAccessories[this.ID].SetActive(false);
			this.ID++;
		}
		if (PlayerGlobals.PantiesEquipped == 5)
		{
			this.RunSpeed += 1f;
		}
		if (PlayerGlobals.Headset)
		{
			this.Inventory.Headset = true;
		}
		this.UpdateHair();
		this.ClubAccessory();
		this.NoDebug = true;
		if (GameGlobals.Debug)
		{
			this.NoDebug = false;
		}
		if (GameGlobals.BlondeHair)
		{
			this.PonytailRenderer.material.mainTexture = this.BlondePony;
			this.NoPonyRenderer.material.mainTexture = this.BlondePony;
		}
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
		if (GameGlobals.Eighties)
		{
			this.BecomeRyoba();
		}
		this.SetUniform();
		this.HandCamera.gameObject.SetActive(false);
		this.CharacterAnimation.Sample();
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06001FC8 RID: 8136 RVA: 0x001C3D07 File Offset: 0x001C1F07
	// (set) Token: 0x06001FC9 RID: 8137 RVA: 0x001C3D10 File Offset: 0x001C1F10
	public float Sanity
	{
		get
		{
			return this.sanity;
		}
		set
		{
			this.sanity = Mathf.Clamp(value, 0f, 100f);
			if (this.SanityPills)
			{
				this.sanity = 100f;
			}
			if (this.sanity > 66.66666f)
			{
				this.HeartRate.SetHeartRateColour(this.HeartRate.NormalColour);
				this.SanityWarning = false;
			}
			else if (this.sanity > 33.33333f)
			{
				this.HeartRate.SetHeartRateColour(this.HeartRate.MediumColour);
				this.SanityWarning = false;
				if (this.PreviousSanity < 33.33333f)
				{
					this.StudentManager.UpdateStudents(0);
				}
			}
			else
			{
				this.HeartRate.SetHeartRateColour(this.HeartRate.BadColour);
				if (!this.SanityWarning)
				{
					this.NotificationManager.DisplayNotification(NotificationType.Insane);
					this.StudentManager.TutorialWindow.ShowSanityMessage = true;
					this.SanityWarning = true;
				}
			}
			this.HeartRate.BeatsPerMinute = (int)(240f - this.sanity * 1.8f);
			if (!this.Laughing)
			{
				this.Teeth.SetActive(this.SanityWarning);
			}
			if (this.MyRenderer.sharedMesh != this.NudeMesh)
			{
				if (!this.Slender)
				{
					this.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f - this.sanity / 100f);
				}
				else
				{
					this.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
				}
			}
			else
			{
				this.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			}
			this.PreviousSanity = this.sanity;
			this.Hairstyles[2].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, this.Sanity);
		}
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06001FCA RID: 8138 RVA: 0x001C3EDD File Offset: 0x001C20DD
	// (set) Token: 0x06001FCB RID: 8139 RVA: 0x001C3EE8 File Offset: 0x001C20E8
	public float Bloodiness
	{
		get
		{
			return this.bloodiness;
		}
		set
		{
			this.bloodiness = Mathf.Clamp(value, 0f, 100f);
			if (this.Bloodiness > 0f)
			{
				this.StudentManager.TutorialWindow.ShowBloodMessage = true;
			}
			if (!this.BloodyWarning && this.Bloodiness > 0f)
			{
				this.NotificationManager.DisplayNotification(NotificationType.Bloody);
				this.BloodyWarning = true;
				if (this.Schoolwear > 0 && !this.WearingRaincoat)
				{
					this.Police.BloodyClothing++;
					if (!this.ClubAttire)
					{
						if (this.CurrentUniformOrigin == 1)
						{
							this.StudentManager.OriginalUniforms--;
						}
						else
						{
							this.StudentManager.NewUniforms--;
						}
					}
				}
			}
			this.MyProjector.enabled = true;
			this.RedPaint = false;
			if (!GameGlobals.CensorBlood)
			{
				this.MyProjector.material.SetColor("_TintColor", new Color(0.25f, 0.25f, 0.25f, 0.5f));
				if (this.Bloodiness == 100f)
				{
					this.MyProjector.material.mainTexture = this.BloodTextures[5];
				}
				else if (this.Bloodiness >= 80f)
				{
					this.MyProjector.material.mainTexture = this.BloodTextures[4];
				}
				else if (this.Bloodiness >= 60f)
				{
					this.MyProjector.material.mainTexture = this.BloodTextures[3];
				}
				else if (this.Bloodiness >= 40f)
				{
					this.MyProjector.material.mainTexture = this.BloodTextures[2];
				}
				else if (this.Bloodiness >= 20f)
				{
					this.MyProjector.material.mainTexture = this.BloodTextures[1];
				}
				else
				{
					this.MyProjector.enabled = false;
					this.BloodyWarning = false;
				}
			}
			else
			{
				this.MyProjector.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0.5f));
				if (this.Bloodiness == 100f)
				{
					this.MyProjector.material.mainTexture = this.FlowerTextures[5];
				}
				else if (this.Bloodiness >= 80f)
				{
					this.MyProjector.material.mainTexture = this.FlowerTextures[4];
				}
				else if (this.Bloodiness >= 60f)
				{
					this.MyProjector.material.mainTexture = this.FlowerTextures[3];
				}
				else if (this.Bloodiness >= 40f)
				{
					this.MyProjector.material.mainTexture = this.FlowerTextures[2];
				}
				else if (this.Bloodiness >= 20f)
				{
					this.MyProjector.material.mainTexture = this.FlowerTextures[1];
				}
				else
				{
					this.MyProjector.enabled = false;
					this.BloodyWarning = false;
				}
			}
			this.StudentManager.UpdateBooths();
			this.MyLocker.UpdateButtons();
			this.Outline.h.ReinitMaterials();
		}
	}

	// Token: 0x170004C8 RID: 1224
	// (get) Token: 0x06001FCC RID: 8140 RVA: 0x001C4213 File Offset: 0x001C2413
	// (set) Token: 0x06001FCD RID: 8141 RVA: 0x001C4222 File Offset: 0x001C2422
	public WeaponScript EquippedWeapon
	{
		get
		{
			return this.Weapon[this.Equipped];
		}
		set
		{
			this.Weapon[this.Equipped] = value;
		}
	}

	// Token: 0x170004C9 RID: 1225
	// (get) Token: 0x06001FCE RID: 8142 RVA: 0x001C4232 File Offset: 0x001C2432
	public bool Armed
	{
		get
		{
			return this.EquippedWeapon != null;
		}
	}

	// Token: 0x170004CA RID: 1226
	// (get) Token: 0x06001FCF RID: 8143 RVA: 0x001C4240 File Offset: 0x001C2440
	public SanityType SanityType
	{
		get
		{
			if (this.Sanity / 100f > 0.6666667f)
			{
				return SanityType.High;
			}
			if (this.Sanity / 100f > 0.33333334f)
			{
				return SanityType.Medium;
			}
			return SanityType.Low;
		}
	}

	// Token: 0x06001FD0 RID: 8144 RVA: 0x001C426D File Offset: 0x001C246D
	public string GetSanityString(SanityType sanityType)
	{
		if (sanityType == SanityType.High)
		{
			return "High";
		}
		if (sanityType == SanityType.Medium)
		{
			return "Med";
		}
		return "Low";
	}

	// Token: 0x170004CB RID: 1227
	// (get) Token: 0x06001FD1 RID: 8145 RVA: 0x001C4288 File Offset: 0x001C2488
	public Vector3 HeadPosition
	{
		get
		{
			return new Vector3(base.transform.position.x, base.transform.position.y + this.Zoom.Height, base.transform.position.z);
		}
	}

	// Token: 0x06001FD2 RID: 8146 RVA: 0x001C42D8 File Offset: 0x001C24D8
	public void SetAnimationLayers()
	{
		this.CharacterAnimation["f02_yanderePose_00"].layer = 1;
		this.CharacterAnimation.Play("f02_yanderePose_00");
		this.CharacterAnimation["f02_yanderePose_00"].weight = 0f;
		this.CharacterAnimation["f02_shy_00"].layer = 2;
		this.CharacterAnimation.Play("f02_shy_00");
		this.CharacterAnimation["f02_shy_00"].weight = 0f;
		this.CharacterAnimation["f02_singleSaw_00"].layer = 3;
		this.CharacterAnimation.Play("f02_singleSaw_00");
		this.CharacterAnimation["f02_singleSaw_00"].weight = 0f;
		this.CharacterAnimation["f02_fist_00"].layer = 4;
		this.CharacterAnimation.Play("f02_fist_00");
		this.CharacterAnimation["f02_fist_00"].weight = 0f;
		this.CharacterAnimation["f02_mopping_00"].layer = 5;
		this.CharacterAnimation["f02_mopping_00"].speed = 2f;
		this.CharacterAnimation.Play("f02_mopping_00");
		this.CharacterAnimation["f02_mopping_00"].weight = 0f;
		this.CharacterAnimation["f02_carry_00"].layer = 6;
		this.CharacterAnimation.Play("f02_carry_00");
		this.CharacterAnimation["f02_carry_00"].weight = 0f;
		this.CharacterAnimation["f02_mopCarry_00"].layer = 7;
		this.CharacterAnimation.Play("f02_mopCarry_00");
		this.CharacterAnimation["f02_mopCarry_00"].weight = 0f;
		this.CharacterAnimation["f02_bucketCarry_00"].layer = 8;
		this.CharacterAnimation.Play("f02_bucketCarry_00");
		this.CharacterAnimation["f02_bucketCarry_00"].weight = 0f;
		this.CharacterAnimation["f02_cameraPose_00"].layer = 9;
		this.CharacterAnimation.Play("f02_cameraPose_00");
		this.CharacterAnimation["f02_cameraPose_00"].weight = 0f;
		this.CharacterAnimation["f02_grip_00"].layer = 10;
		this.CharacterAnimation.Play("f02_grip_00");
		this.CharacterAnimation["f02_grip_00"].weight = 0f;
		this.CharacterAnimation["f02_holdHead_00"].layer = 11;
		this.CharacterAnimation.Play("f02_holdHead_00");
		this.CharacterAnimation["f02_holdHead_00"].weight = 0f;
		this.CharacterAnimation["f02_holdTorso_00"].layer = 12;
		this.CharacterAnimation.Play("f02_holdTorso_00");
		this.CharacterAnimation["f02_holdTorso_00"].weight = 0f;
		this.CharacterAnimation["f02_carryCan_00"].layer = 13;
		this.CharacterAnimation.Play("f02_carryCan_00");
		this.CharacterAnimation["f02_carryCan_00"].weight = 0f;
		this.CharacterAnimation["f02_leftGrip_00"].layer = 14;
		this.CharacterAnimation.Play("f02_leftGrip_00");
		this.CharacterAnimation["f02_leftGrip_00"].weight = 0f;
		this.CharacterAnimation["f02_carryShoulder_00"].layer = 15;
		this.CharacterAnimation.Play("f02_carryShoulder_00");
		this.CharacterAnimation["f02_carryShoulder_00"].weight = 0f;
		this.CharacterAnimation["f02_carryFlashlight_00"].layer = 16;
		this.CharacterAnimation.Play("f02_carryFlashlight_00");
		this.CharacterAnimation["f02_carryFlashlight_00"].weight = 0f;
		this.CharacterAnimation["f02_carryBox_00"].layer = 17;
		this.CharacterAnimation.Play("f02_carryBox_00");
		this.CharacterAnimation["f02_carryBox_00"].weight = 0f;
		this.CharacterAnimation["f02_holdBook_00"].layer = 18;
		this.CharacterAnimation.Play("f02_holdBook_00");
		this.CharacterAnimation["f02_holdBook_00"].weight = 0f;
		this.CharacterAnimation["f02_holdBook_00"].speed = 0.5f;
		this.CharacterAnimation[this.CreepyIdles[1]].layer = 19;
		this.CharacterAnimation.Play(this.CreepyIdles[1]);
		this.CharacterAnimation[this.CreepyIdles[1]].weight = 0f;
		this.CharacterAnimation[this.CreepyIdles[2]].layer = 20;
		this.CharacterAnimation.Play(this.CreepyIdles[2]);
		this.CharacterAnimation[this.CreepyIdles[2]].weight = 0f;
		this.CharacterAnimation[this.CreepyIdles[3]].layer = 21;
		this.CharacterAnimation.Play(this.CreepyIdles[3]);
		this.CharacterAnimation[this.CreepyIdles[3]].weight = 0f;
		this.CharacterAnimation[this.CreepyIdles[4]].layer = 22;
		this.CharacterAnimation.Play(this.CreepyIdles[4]);
		this.CharacterAnimation[this.CreepyIdles[4]].weight = 0f;
		this.CharacterAnimation[this.CreepyIdles[5]].layer = 23;
		this.CharacterAnimation.Play(this.CreepyIdles[5]);
		this.CharacterAnimation[this.CreepyIdles[5]].weight = 0f;
		this.CharacterAnimation[this.CreepyWalks[1]].layer = 24;
		this.CharacterAnimation.Play(this.CreepyWalks[1]);
		this.CharacterAnimation[this.CreepyWalks[1]].weight = 0f;
		this.CharacterAnimation[this.CreepyWalks[2]].layer = 25;
		this.CharacterAnimation.Play(this.CreepyWalks[2]);
		this.CharacterAnimation[this.CreepyWalks[2]].weight = 0f;
		this.CharacterAnimation[this.CreepyWalks[3]].layer = 26;
		this.CharacterAnimation.Play(this.CreepyWalks[3]);
		this.CharacterAnimation[this.CreepyWalks[3]].weight = 0f;
		this.CharacterAnimation[this.CreepyWalks[4]].layer = 27;
		this.CharacterAnimation.Play(this.CreepyWalks[4]);
		this.CharacterAnimation[this.CreepyWalks[4]].weight = 0f;
		this.CharacterAnimation[this.CreepyWalks[5]].layer = 28;
		this.CharacterAnimation.Play(this.CreepyWalks[5]);
		this.CharacterAnimation[this.CreepyWalks[5]].weight = 0f;
		this.CharacterAnimation["f02_carryDramatic_00"].layer = 29;
		this.CharacterAnimation.Play("f02_carryDramatic_00");
		this.CharacterAnimation["f02_carryDramatic_00"].weight = 0f;
		this.CharacterAnimation["f02_selfie_00"].layer = 30;
		this.CharacterAnimation.Play("f02_selfie_00");
		this.CharacterAnimation["f02_selfie_00"].weight = 0f;
		this.CharacterAnimation["f02_dramaticWriting_00"].layer = 31;
		this.CharacterAnimation.Play("f02_dramaticWriting_00");
		this.CharacterAnimation["f02_dramaticWriting_00"].weight = 0f;
		this.CharacterAnimation["f02_reachForWeapon_00"].layer = 32;
		this.CharacterAnimation.Play("f02_reachForWeapon_00");
		this.CharacterAnimation["f02_reachForWeapon_00"].weight = 0f;
		this.CharacterAnimation["f02_reachForWeapon_00"].speed = 2f;
		this.CharacterAnimation["f02_gutsEye_00"].layer = 33;
		this.CharacterAnimation.Play("f02_gutsEye_00");
		this.CharacterAnimation["f02_gutsEye_00"].weight = 0f;
		this.CharacterAnimation["f02_fingerSnap_00"].layer = 34;
		this.CharacterAnimation.Play("f02_fingerSnap_00");
		this.CharacterAnimation["f02_fingerSnap_00"].weight = 0f;
		this.CharacterAnimation["f02_sadEyebrows_00"].layer = 35;
		this.CharacterAnimation.Play("f02_sadEyebrows_00");
		this.CharacterAnimation["f02_sadEyebrows_00"].weight = 0f;
		this.CharacterAnimation["f02_phonePose_00"].layer = 36;
		this.CharacterAnimation.Play("f02_phonePose_00");
		this.CharacterAnimation["f02_phonePose_00"].weight = 0f;
		this.CharacterAnimation["f02_dipping_00"].speed = 2f;
		this.CharacterAnimation["f02_stripping_00"].speed = 1.5f;
		this.CharacterAnimation["f02_falconIdle_00"].speed = 2f;
		this.CharacterAnimation["f02_carryIdleA_00"].speed = 1.75f;
		this.CharacterAnimation["CyborgNinja_Run_Armed"].speed = 2f;
		this.CharacterAnimation["CyborgNinja_Run_Unarmed"].speed = 2f;
	}

	// Token: 0x06001FD3 RID: 8147 RVA: 0x001C4D6C File Offset: 0x001C2F6C
	private void Update()
	{
		if (!this.StudentManager.Eighties && Input.GetKeyDown(KeyCode.LeftAlt))
		{
			this.CinematicCamera.SetActive(false);
		}
		if (!this.PauseScreen.Show)
		{
			this.UpdateMovement();
			this.UpdatePoisoning();
			if (!this.Laughing)
			{
				this.MyAudio.volume -= Time.deltaTime * 2f;
			}
			else if (this.PickUp != null && !this.PickUp.Clothing)
			{
				this.CharacterAnimation[this.CarryAnims[1]].weight = Mathf.Lerp(this.CharacterAnimation[this.CarryAnims[1]].weight, 1f, Time.deltaTime * 10f);
			}
			if (!this.Mopping)
			{
				this.CharacterAnimation["f02_mopping_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_mopping_00"].weight, 0f, Time.deltaTime * 10f);
			}
			else
			{
				this.CharacterAnimation["f02_mopping_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_mopping_00"].weight, 1f, Time.deltaTime * 10f);
				if (Input.GetButtonUp("A") || Input.GetKeyDown(KeyCode.Escape))
				{
					this.Mopping = false;
				}
			}
			if (this.LaughIntensity == 0f)
			{
				this.ID = 0;
				while (this.ID < this.CarryAnims.Length)
				{
					string name = this.CarryAnims[this.ID];
					if (this.PickUp != null && this.CarryAnimID == this.ID && !this.Mopping && !this.Dipping && !this.Pouring && !this.BucketDropping && !this.Digging && !this.Burying && !this.WritingName)
					{
						this.CharacterAnimation[name].weight = Mathf.Lerp(this.CharacterAnimation[name].weight, 1f, Time.deltaTime * 10f);
					}
					else
					{
						this.CharacterAnimation[name].weight = Mathf.Lerp(this.CharacterAnimation[name].weight, 0f, Time.deltaTime * 10f);
					}
					this.ID++;
				}
			}
			else if (this.Armed)
			{
				this.CharacterAnimation["f02_mopCarry_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_mopCarry_00"].weight, 1f, Time.deltaTime * 10f);
			}
			if (this.Noticed && !this.Attacking && !this.Struggling && !this.Collapse)
			{
				if (this.ShoulderCamera.NoticedTimer < 1f)
				{
					this.CharacterAnimation.CrossFade("f02_scaredIdle_00");
				}
				this.targetRotation = Quaternion.LookRotation(this.Senpai.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				base.transform.localEulerAngles = new Vector3(0f, base.transform.localEulerAngles.y, base.transform.localEulerAngles.z);
				if (Vector3.Distance(base.transform.position, this.Senpai.position) < 1.25f)
				{
					this.MyController.Move(base.transform.forward * (Time.deltaTime * -2f));
				}
			}
			this.UpdateEffects();
			this.UpdateTalking();
			this.UpdateAttacking();
			this.UpdateSlouch();
			if (!this.Noticed)
			{
				this.RightYandereEye.material.color = new Color(this.RightYandereEye.material.color.r, this.RightYandereEye.material.color.g, this.RightYandereEye.material.color.b, 1f - this.Sanity / 100f);
				this.LeftYandereEye.material.color = new Color(this.LeftYandereEye.material.color.r, this.LeftYandereEye.material.color.g, this.LeftYandereEye.material.color.b, 1f - this.Sanity / 100f);
				this.EyeShrink = Mathf.Lerp(this.EyeShrink, 0.5f * (1f - this.Sanity / 100f), Time.deltaTime * 10f);
			}
			this.UpdateTwitch();
			this.UpdateWarnings();
			if (!this.NoDebug)
			{
				this.UpdateDebugFunctionality();
			}
			if (base.transform.position.y < 0f)
			{
				base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
			}
			if (base.transform.position.z < -99.5f)
			{
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, -99.5f);
			}
			base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, 0f);
			return;
		}
		this.MyAudio.volume -= 0.33333334f;
	}

	// Token: 0x06001FD4 RID: 8148 RVA: 0x001C5374 File Offset: 0x001C3574
	private void GoToPKDir(PKDirType pkDir, string sansAnim, Vector3 ragdollLocalPos)
	{
		this.CharacterAnimation.CrossFade(sansAnim);
		this.RagdollPK.transform.localPosition = ragdollLocalPos;
		if (this.PKDir != pkDir)
		{
			AudioSource.PlayClipAtPoint(this.Slam, base.transform.position + Vector3.up);
		}
		this.PKDir = pkDir;
	}

	// Token: 0x06001FD5 RID: 8149 RVA: 0x001C53D0 File Offset: 0x001C35D0
	private void UpdateMovement()
	{
		if (this.CanMove)
		{
			if (!this.ToggleRun)
			{
				this.Running = false;
				if (Input.GetButton("LB"))
				{
					this.Running = true;
				}
			}
			else if (Input.GetButtonDown("LB"))
			{
				this.Running = !this.Running;
			}
			this.MyController.Move(Physics.gravity * Time.deltaTime);
			this.v = Input.GetAxis("Vertical");
			this.h = Input.GetAxis("Horizontal");
			this.FlapSpeed = Mathf.Abs(this.v) + Mathf.Abs(this.h);
			if (this.Selfie)
			{
				this.v = -1f * this.v;
				this.h = -1f * this.h;
			}
			if (this.Frozen)
			{
				this.v = 0f;
				this.h = 0f;
			}
			if (!this.Aiming)
			{
				Vector3 vector = this.MainCamera.transform.TransformDirection(Vector3.forward);
				vector.y = 0f;
				vector = vector.normalized;
				Vector3 a = new Vector3(vector.z, 0f, -vector.x);
				this.targetDirection = this.h * a + this.v * vector;
				if (this.targetDirection != Vector3.zero)
				{
					this.targetRotation = Quaternion.LookRotation(this.targetDirection);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				}
				else
				{
					this.targetRotation = new Quaternion(0f, 0f, 0f, 0f);
				}
				if (this.v != 0f || this.h != 0f)
				{
					if (this.Running && Vector3.Distance(base.transform.position, this.Senpai.position) > 1f)
					{
						if (this.Stance.Current == StanceType.Crouching)
						{
							this.CharacterAnimation.CrossFade(this.CrouchRunAnim);
							this.MyController.Move(base.transform.forward * (this.CrouchRunSpeed + (float)(this.PhysicalGrade + this.SpeedBonus) * 0.25f) * Time.deltaTime);
						}
						else if (!this.Dragging && !this.Mopping)
						{
							this.CharacterAnimation.CrossFade(this.RunAnim);
							this.MyController.Move(base.transform.forward * (this.RunSpeed + (float)(this.PhysicalGrade + this.SpeedBonus) * 0.25f) * Time.deltaTime);
						}
						else if (this.Mopping)
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
							this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime));
						}
						StanceType stanceType = this.Stance.Current;
						if (this.Stance.Current == StanceType.Crawling)
						{
							this.Stance.Current = StanceType.Crouching;
							this.Crouch();
						}
					}
					else if (!this.Dragging)
					{
						if (this.Stance.Current == StanceType.Crawling)
						{
							this.CharacterAnimation.CrossFade(this.CrawlWalkAnim);
							this.MyController.Move(base.transform.forward * (this.CrawlSpeed * Time.deltaTime));
						}
						else if (this.Stance.Current == StanceType.Crouching)
						{
							this.CharacterAnimation[this.CrouchWalkAnim].speed = 1f;
							this.CharacterAnimation.CrossFade(this.CrouchWalkAnim);
							this.MyController.Move(base.transform.forward * (this.CrouchWalkSpeed * Time.deltaTime));
						}
						else
						{
							this.CharacterAnimation.CrossFade(this.WalkAnim);
							if (this.NearSenpai)
							{
								for (int i = 1; i < 6; i++)
								{
									if (i != this.Creepiness)
									{
										this.CharacterAnimation[this.CreepyIdles[i]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[i]].weight, 0f, Time.deltaTime);
										this.CharacterAnimation[this.CreepyWalks[i]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[i]].weight, 0f, Time.deltaTime);
									}
								}
								this.CharacterAnimation[this.CreepyIdles[this.Creepiness]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[this.Creepiness]].weight, 0f, Time.deltaTime);
								this.CharacterAnimation[this.CreepyWalks[this.Creepiness]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[this.Creepiness]].weight, 1f, Time.deltaTime);
							}
							this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime));
						}
					}
					else
					{
						this.CharacterAnimation.CrossFade("f02_dragWalk_01");
						this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime));
					}
				}
				else if (!this.Dragging)
				{
					if (this.Stance.Current == StanceType.Crawling)
					{
						this.CharacterAnimation.CrossFade(this.CrawlIdleAnim);
					}
					else if (this.Stance.Current == StanceType.Crouching)
					{
						this.CharacterAnimation.CrossFade(this.CrouchIdleAnim);
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						if (this.NearSenpai)
						{
							for (int j = 1; j < 6; j++)
							{
								if (j != this.Creepiness)
								{
									this.CharacterAnimation[this.CreepyIdles[j]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[j]].weight, 0f, Time.deltaTime);
									this.CharacterAnimation[this.CreepyWalks[j]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[j]].weight, 0f, Time.deltaTime);
								}
							}
							this.CharacterAnimation[this.CreepyIdles[this.Creepiness]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[this.Creepiness]].weight, 1f, Time.deltaTime);
							this.CharacterAnimation[this.CreepyWalks[this.Creepiness]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[this.Creepiness]].weight, 0f, Time.deltaTime);
						}
					}
				}
				else
				{
					this.CharacterAnimation.CrossFade("f02_dragIdle_02");
				}
			}
			else
			{
				if (this.v != 0f || this.h != 0f)
				{
					if (this.Stance.Current == StanceType.Crawling)
					{
						this.CharacterAnimation.CrossFade(this.CrawlWalkAnim);
						this.MyController.Move(base.transform.forward * (this.CrawlSpeed * Time.deltaTime * this.v));
						this.MyController.Move(base.transform.right * (this.CrawlSpeed * Time.deltaTime * this.h));
					}
					else if (this.Stance.Current == StanceType.Crouching)
					{
						this.CharacterAnimation.CrossFade(this.CrouchWalkAnim);
						this.MyController.Move(base.transform.forward * (this.CrouchWalkSpeed * Time.deltaTime * this.v));
						this.MyController.Move(base.transform.right * (this.CrouchWalkSpeed * Time.deltaTime * this.h));
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
						this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime * this.v));
						this.MyController.Move(base.transform.right * (this.WalkSpeed * Time.deltaTime * this.h));
					}
				}
				else if (this.Stance.Current == StanceType.Crawling)
				{
					this.CharacterAnimation.CrossFade(this.CrawlIdleAnim);
				}
				else if (this.Stance.Current == StanceType.Crouching)
				{
					this.CharacterAnimation.CrossFade(this.CrouchIdleAnim);
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
				}
				if (!this.RPGCamera.invertAxisY)
				{
					this.Bend += Input.GetAxis("Mouse Y") * this.RPGCamera.sensitivity * 72f * Time.deltaTime;
				}
				else
				{
					this.Bend -= Input.GetAxis("Mouse Y") * this.RPGCamera.sensitivity * 72f * Time.deltaTime;
				}
				if (this.Stance.Current == StanceType.Crawling)
				{
					if (this.Bend < 0f)
					{
						this.Bend = 0f;
					}
				}
				else if (this.Stance.Current == StanceType.Crouching)
				{
					if (this.Bend < -45f)
					{
						this.Bend = -45f;
					}
				}
				else if (this.Bend < -85f)
				{
					this.Bend = -85f;
				}
				if (this.Bend > 85f)
				{
					this.Bend = 85f;
				}
				if (!this.RPGCamera.invertAxisX)
				{
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * this.RPGCamera.sensitivity * 72f * Time.deltaTime, base.transform.localEulerAngles.z);
				}
				else
				{
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y - Input.GetAxis("Mouse X") * this.RPGCamera.sensitivity * 72f * Time.deltaTime, base.transform.localEulerAngles.z);
				}
			}
			if (!this.NearSenpai)
			{
				if (!Input.GetButton("A") && !Input.GetButton("B") && !Input.GetButton("X") && !Input.GetButton("Y") && !this.StudentManager.Clock.UpdateBloom && (Input.GetAxis("LT") > 0.5f || Input.GetMouseButton(1)))
				{
					if (this.Inventory.RivalPhone)
					{
						if (Input.GetButtonDown("LB"))
						{
							this.CharacterAnimation["f02_cameraPose_00"].weight = 0f;
							this.CharacterAnimation["f02_selfie_00"].weight = 0f;
							if (!this.RivalPhone)
							{
								this.SmartphoneRenderer.material.mainTexture = this.RivalPhoneTexture;
								this.PhonePromptBar.Label.text = "SWITCH TO YOUR PHONE";
								this.RivalPhone = true;
							}
							else
							{
								this.SmartphoneRenderer.material.mainTexture = this.YanderePhoneTexture;
								this.PhonePromptBar.Label.text = "SWITCH TO STOLEN PHONE";
								this.RivalPhone = false;
							}
						}
					}
					else if (!this.Selfie && Input.GetButtonDown("LB") && !this.StudentManager.Eighties)
					{
						if (!this.AR)
						{
							this.Smartphone.cullingMask |= 1 << LayerMask.NameToLayer("Miyuki");
							this.AR = true;
						}
						else
						{
							this.Smartphone.cullingMask &= ~(1 << LayerMask.NameToLayer("Miyuki"));
							this.AR = false;
						}
					}
					if (Input.GetAxis("LT") > 0.5f)
					{
						this.UsingController = true;
					}
					if (!this.Aiming)
					{
						this.PauseScreen.NewSettings.Profile.depthOfField.enabled = false;
						if (this.CameraEffects.OneCamera)
						{
							this.MainCamera.clearFlags = CameraClearFlags.Color;
							this.MainCamera.farClipPlane = 0.02f;
							this.HandCamera.clearFlags = CameraClearFlags.Color;
						}
						else
						{
							this.MainCamera.clearFlags = CameraClearFlags.Skybox;
							this.MainCamera.farClipPlane = (float)OptionGlobals.DrawDistance;
							this.HandCamera.clearFlags = CameraClearFlags.Depth;
						}
						base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, this.MainCamera.transform.eulerAngles.y, base.transform.eulerAngles.z);
						this.CharacterAnimation.Play(this.IdleAnim);
						if (!this.StudentManager.Eighties)
						{
							this.Smartphone.transform.parent.gameObject.SetActive(true);
							this.Blur.enabled = true;
							if (!this.CinematicCamera.activeInHierarchy)
							{
								this.DisableHairAndAccessories();
							}
							this.HandCamera.gameObject.SetActive(true);
							this.EmptyHands();
							this.PhonePromptBar.Panel.enabled = true;
							this.PhonePromptBar.Show = true;
						}
						else
						{
							this.HandCamera.nearClipPlane = 0.35f;
							this.Smartphone.nearClipPlane = 0.12f;
						}
						this.ShoulderCamera.AimingCamera = true;
						this.YandereVision = false;
						this.Mopping = false;
						this.Selfie = false;
						this.Aiming = true;
						if (this.Inventory.RivalPhone)
						{
							if (!this.RivalPhone)
							{
								this.PhonePromptBar.Label.text = "SWITCH TO STOLEN PHONE";
							}
							else
							{
								this.PhonePromptBar.Label.text = "SWITCH TO YOUR PHONE";
							}
						}
						else
						{
							this.PhonePromptBar.Label.text = "AR GAME ON/OFF";
						}
						Time.timeScale = 1f;
						this.UpdateSelfieStatus();
						this.StudentManager.UpdatePanties(true);
						this.CameraEffects.SmartphoneCamera.depthTextureMode = DepthTextureMode.DepthNormals;
					}
				}
				this.PermitLaugh += Time.deltaTime;
				if (!this.Aiming && !this.Accessories[9].activeInHierarchy && !this.Accessories[16].activeInHierarchy && !this.Pod.activeInHierarchy && this.PermitLaugh > 1f && !this.Chased && !Input.GetButton("A"))
				{
					if (Input.GetButton("RB"))
					{
						if (this.MagicalGirl)
						{
							if (this.Armed && this.EquippedWeapon.WeaponID == 14 && Input.GetButtonDown("RB") && !this.ShootingBeam)
							{
								AudioSource.PlayClipAtPoint(this.LoveLoveBeamVoice, base.transform.position);
								this.CharacterAnimation["f02_LoveLoveBeam_00"].time = 0f;
								this.CharacterAnimation.CrossFade("f02_LoveLoveBeam_00");
								this.ShootingBeam = true;
								this.CanMove = false;
							}
						}
						else if (this.BlackRobe.activeInHierarchy)
						{
							if (Input.GetButtonDown("RB"))
							{
								AudioSource.PlayClipAtPoint(this.SithOn, base.transform.position);
							}
							this.SithTrailEnd1.localPosition = new Vector3(-1f, 0f, 0f);
							this.SithTrailEnd2.localPosition = new Vector3(1f, 0f, 0f);
							this.Beam[0].Play();
							this.Beam[1].Play();
							this.Beam[2].Play();
							this.Beam[3].Play();
							if (Input.GetButtonDown("X"))
							{
								this.CharacterAnimation["f02_sithAttack_00"].time = 0f;
								this.CharacterAnimation.Play("f02_sithAttack_00");
								this.SithBeam[1].Damage = 10f;
								this.SithBeam[2].Damage = 10f;
								this.SithAttacking = true;
								this.CanMove = false;
								this.SithPrefix = "";
								this.AttackPrefix = "sith";
							}
							if (Input.GetButtonDown("Y"))
							{
								this.CharacterAnimation["f02_sithAttackHard_00"].time = 0f;
								this.CharacterAnimation.Play("f02_sithAttackHard_00");
								this.SithBeam[1].Damage = 20f;
								this.SithBeam[2].Damage = 20f;
								this.SithAttacking = true;
								this.CanMove = false;
								this.SithPrefix = "Hard";
								this.AttackPrefix = "sith";
							}
						}
						else if (this.FloppyHat.activeInHierarchy)
						{
							if (Input.GetButtonDown("RB"))
							{
								this.LongFingers = !this.LongFingers;
								if (this.LongFingers)
								{
									AudioSource.PlayClipAtPoint(this.EmptyDemon.MouthOpen, base.transform.position);
								}
								else
								{
									AudioSource.PlayClipAtPoint(this.EmptyDemon.MouthClose, base.transform.position);
								}
							}
						}
						else if (Input.GetButtonDown("RB") && this.SpiderLegs.activeInHierarchy)
						{
							this.SpiderGrow = !this.SpiderGrow;
							if (this.SpiderGrow)
							{
								AudioSource.PlayClipAtPoint(this.EmptyDemon.MouthOpen, base.transform.position);
							}
							else
							{
								AudioSource.PlayClipAtPoint(this.EmptyDemon.MouthClose, base.transform.position);
							}
							this.StudentManager.UpdateStudents(0);
						}
						this.YandereTimer += Time.deltaTime;
						if (this.YandereTimer > 0.5f)
						{
							if (!this.Sans && !this.BlackRobe.activeInHierarchy)
							{
								this.YandereVision = true;
							}
							else if (this.Sans)
							{
								this.SansEyes[0].SetActive(true);
								this.SansEyes[1].SetActive(true);
								this.GlowEffect.Play();
								this.SummonBones = true;
								this.YandereTimer = 0f;
								this.CanMove = false;
							}
						}
					}
					else
					{
						if (this.BlackRobe.activeInHierarchy)
						{
							this.SithTrailEnd1.localPosition = new Vector3(0f, 0f, 0f);
							this.SithTrailEnd2.localPosition = new Vector3(0f, 0f, 0f);
							if (Input.GetButtonUp("RB"))
							{
								AudioSource.PlayClipAtPoint(this.SithOff, base.transform.position);
							}
							this.Beam[0].Stop();
							this.Beam[1].Stop();
							this.Beam[2].Stop();
							this.Beam[3].Stop();
						}
						if (this.YandereVision)
						{
							this.YandereVision = false;
						}
					}
					if (Input.GetButtonUp("RB"))
					{
						if (this.CanCloak && !this.WearingRaincoat)
						{
							this.Invisible = !this.Invisible;
							Debug.Log("Invisibility is: " + this.Invisible.ToString());
							if (this.Invisible)
							{
								this.EightiesPonytailRenderer.material = this.CloakMaterial;
								this.PonytailRenderer.material = this.CloakMaterial;
								this.MyRenderer.materials = this.CloakMaterials;
								this.Outline.h.ReinitMaterials();
								if (!this.StudentManager.Eighties)
								{
									this.Hairstyle = 1;
								}
								else
								{
									this.Hairstyle = 203;
								}
								this.UpdateHair();
							}
							else
							{
								this.PauseScreen.NewSettings.QualityManager.UpdateOutlinesAndRimlight();
								this.SetUniform();
								this.MyRenderer.materials[0].color = Color.white;
								this.MyRenderer.materials[1].color = Color.white;
								this.MyRenderer.materials[2].color = Color.white;
								this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
								this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
								this.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
								this.MyRenderer.materials[0].SetFloat("_Outline", 0.002f);
								this.MyRenderer.materials[1].SetFloat("_Outline", 0.002f);
								this.MyRenderer.materials[2].SetFloat("_Outline", 0.002f);
								this.PonytailRenderer.material.color = new Color(0.25f, 0.25f, 0.25f, 1f);
								this.PonytailRenderer.material.SetFloat("_Outline", 0.002f);
								this.EightiesPonytailRenderer.material.color = new Color(0.25f, 0.25f, 0.25f, 1f);
								this.EightiesPonytailRenderer.material.SetFloat("_Outline", 0.002f);
								if (!this.StudentManager.Eighties)
								{
									this.Hairstyle = 1;
								}
								else
								{
									this.Hairstyle = 203;
								}
								this.UpdateHair();
							}
							this.PantyAttacher.newRenderer.enabled = !this.Invisible;
						}
						if (this.Stance.Current != StanceType.Crouching && this.Stance.Current != StanceType.Crawling)
						{
							if (this.YandereTimer < 0.5f && !this.Dragging && !this.Carrying && !this.Pod.activeInHierarchy && !this.Laughing)
							{
								if (this.Sans)
								{
									this.BlasterStage++;
									if (this.BlasterStage > 5)
									{
										this.BlasterStage = 1;
									}
									GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BlasterSet[this.BlasterStage], base.transform.position, Quaternion.identity);
									gameObject.transform.position = base.transform.position;
									gameObject.transform.rotation = base.transform.rotation;
									AudioSource.PlayClipAtPoint(this.BlasterClip, base.transform.position + Vector3.up);
									this.CharacterAnimation["f02_sansBlaster_00"].time = 0f;
									this.CharacterAnimation.Play("f02_sansBlaster_00");
									this.SansEyes[0].SetActive(true);
									this.SansEyes[1].SetActive(true);
									this.GlowEffect.Play();
									this.Blasting = true;
									this.CanMove = false;
								}
								else if (!this.BlackRobe.activeInHierarchy)
								{
									if (this.Kagune[0].activeInHierarchy)
									{
										if (!this.SwingKagune)
										{
											AudioSource.PlayClipAtPoint(this.KaguneSwoosh, base.transform.position + Vector3.up);
											this.SwingKagune = true;
										}
									}
									else if (this.Gazing || this.Shipgirl)
									{
										if (this.Gazing)
										{
											this.CharacterAnimation["f02_gazerSnap_00"].time = 0f;
											this.CharacterAnimation.CrossFade("f02_gazerSnap_00");
										}
										else
										{
											this.CharacterAnimation["f02_shipGirlSnap_00"].time = 0f;
											this.CharacterAnimation.CrossFade("f02_shipGirlSnap_00");
										}
										this.Snapping = true;
										this.CanMove = false;
									}
									else if (this.WitchMode)
									{
										if (!this.StoppingTime)
										{
											this.CharacterAnimation["f02_summonStand_00"].time = 0f;
											if (this.Freezing)
											{
												AudioSource.PlayClipAtPoint(this.StartShout, base.transform.position);
											}
											else
											{
												AudioSource.PlayClipAtPoint(this.StopShout, base.transform.position);
											}
											this.Freezing = !this.InvertSphere.gameObject.activeInHierarchy;
											this.StoppingTime = true;
											this.CanMove = false;
											this.MyAudio.Stop();
											this.Egg = true;
										}
									}
									else if (this.PickUp != null && this.PickUp.CarryAnimID == 10)
									{
										this.StudentManager.NoteWindow.gameObject.SetActive(true);
										this.StudentManager.NoteWindow.Show = true;
										this.PromptBar.Show = true;
										this.Blur.enabled = true;
										this.CanMove = false;
										Time.timeScale = 0.0001f;
										this.HUD.alpha = 0f;
										this.PromptBar.Label[0].text = "Confirm";
										this.PromptBar.Label[1].text = "Cancel";
										this.PromptBar.Label[4].text = "Select";
										this.PromptBar.UpdateButtons();
									}
									else if (!this.FalconHelmet.activeInHierarchy && !this.Cape.activeInHierarchy && !this.MagicalGirl && !this.FloppyHat.activeInHierarchy)
									{
										if (!this.Xtan)
										{
											if (!this.CirnoHair.activeInHierarchy && !this.TornadoHair.activeInHierarchy && !this.BladeHair.activeInHierarchy)
											{
												this.LaughAnim = "f02_laugh_01";
												this.LaughClip = this.Laugh1;
												this.LaughIntensity += 1f;
												this.MyAudio.clip = this.LaughClip;
												this.MyAudio.time = 0f;
												this.MyAudio.Play();
											}
											this.GiggleLines.Play();
											UnityEngine.Object.Instantiate<GameObject>(this.GiggleDisc, base.transform.position + Vector3.up, Quaternion.identity);
											this.MyAudio.volume = 1f;
											this.LaughTimer = 0.5f;
											this.Laughing = true;
											this.Mopping = false;
											this.CanMove = false;
											this.Teeth.SetActive(false);
										}
										else if (this.LongHair[0].gameObject.activeInHierarchy)
										{
											this.LongHair[0].gameObject.SetActive(false);
											this.BlackEyePatch.SetActive(false);
											this.SlenderHair[0].transform.parent.gameObject.SetActive(true);
											this.SlenderHair[0].SetActive(true);
											this.SlenderHair[1].SetActive(true);
										}
										else
										{
											this.LongHair[0].gameObject.SetActive(true);
											this.BlackEyePatch.SetActive(true);
											this.SlenderHair[0].transform.parent.gameObject.SetActive(true);
											this.SlenderHair[0].SetActive(false);
											this.SlenderHair[1].SetActive(false);
										}
									}
									else if (!this.Punching && !this.FloppyHat.activeInHierarchy)
									{
										if (this.FalconHelmet.activeInHierarchy)
										{
											GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.FalconWindUp);
											gameObject2.transform.parent = this.ItemParent;
											gameObject2.transform.localPosition = Vector3.zero;
											AudioClipPlayer.PlayAttached(this.FalconPunchVoice, this.MainCamera.transform, 5f, 10f);
											this.CharacterAnimation["f02_falconPunch_00"].time = 0f;
											this.CharacterAnimation.Play("f02_falconPunch_00");
											this.FalconSpeed = 0f;
										}
										else
										{
											GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.FalconWindUp);
											gameObject3.transform.parent = this.ItemParent;
											gameObject3.transform.localPosition = Vector3.zero;
											AudioSource.PlayClipAtPoint(this.OnePunchVoices[UnityEngine.Random.Range(0, this.OnePunchVoices.Length)], base.transform.position + Vector3.up);
											this.CharacterAnimation["f02_onePunch_00"].time = 0f;
											this.CharacterAnimation.CrossFade("f02_onePunch_00", 0.15f);
										}
										this.Punching = true;
										this.CanMove = false;
									}
								}
							}
						}
						else
						{
							this.MyAudio.clip = this.Laugh1;
							this.MyAudio.volume = 1f;
							this.MyAudio.time = 0f;
							this.MyAudio.Play();
							this.GiggleLines.Play();
							UnityEngine.Object.Instantiate<GameObject>(this.GiggleDisc, base.transform.position + Vector3.up, Quaternion.identity);
						}
						this.YandereTimer = 0f;
					}
				}
				if (!false)
				{
					if (this.Stance.Current != StanceType.Crouching && this.Stance.Current != StanceType.Crawling)
					{
						if (Input.GetButtonDown("RS"))
						{
							this.CrouchButtonDown = true;
							this.YandereVision = false;
							this.Stance.Current = StanceType.Crouching;
							this.Crouch();
							if (!this.Armed || !this.EquippedWeapon.Concealable)
							{
								this.EmptyHands();
							}
						}
					}
					else
					{
						if (this.Stance.Current == StanceType.Crouching)
						{
							if (Input.GetButton("RS") && !this.CameFromCrouch)
							{
								this.CrawlTimer += Time.deltaTime;
							}
							if (this.CrawlTimer > 0.5f)
							{
								if (!this.Selfie)
								{
									this.EmptyHands();
									this.YandereVision = false;
									this.Stance.Current = StanceType.Crawling;
									this.CrawlTimer = 0f;
									this.Crawl();
								}
							}
							else if (Input.GetButtonUp("RS") && !this.CrouchButtonDown && !this.CameFromCrouch)
							{
								this.Stance.Current = StanceType.Standing;
								this.CrawlTimer = 0f;
								this.Uncrouch();
							}
						}
						else if (Input.GetButtonDown("RS"))
						{
							this.CameFromCrouch = true;
							this.Stance.Current = StanceType.Crouching;
							this.Crouch();
						}
						if (Input.GetButtonUp("RS"))
						{
							this.CrouchButtonDown = false;
							this.CameFromCrouch = false;
							this.CrawlTimer = 0f;
						}
					}
				}
			}
			if (this.Aiming)
			{
				if (!this.StudentManager.Eighties || (this.StudentManager.Eighties && this.Club == ClubType.Photography))
				{
					if (!this.RivalPhone && Input.GetButtonDown("A"))
					{
						this.Selfie = !this.Selfie;
						this.UpdateSelfieStatus();
					}
					if (!this.Selfie)
					{
						if (!this.StudentManager.Eighties)
						{
							this.CharacterAnimation["f02_cameraPose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_cameraPose_00"].weight, 1f, Time.deltaTime * 10f);
							this.CharacterAnimation["f02_selfie_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_selfie_00"].weight, 0f, Time.deltaTime * 10f);
						}
					}
					else
					{
						this.CharacterAnimation["f02_cameraPose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_cameraPose_00"].weight, 0f, Time.deltaTime * 10f);
						this.CharacterAnimation["f02_selfie_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_selfie_00"].weight, 1f, Time.deltaTime * 10f);
						if (Input.GetButtonDown("B"))
						{
							if (!this.SelfieGuide.activeInHierarchy)
							{
								this.SelfieGuide.SetActive(true);
							}
							else
							{
								this.SelfieGuide.SetActive(false);
							}
						}
					}
					if (this.ClubAccessories[7].activeInHierarchy && (Input.GetAxis("DpadY") != 0f || Input.GetAxis("Mouse ScrollWheel") != 0f || Input.GetKey(KeyCode.Tab) || Input.GetKey(KeyCode.LeftShift)))
					{
						if (Input.GetKey(KeyCode.Tab))
						{
							this.Smartphone.fieldOfView -= Time.deltaTime * 100f;
						}
						if (Input.GetKey(KeyCode.LeftShift))
						{
							this.Smartphone.fieldOfView += Time.deltaTime * 100f;
						}
						this.Smartphone.fieldOfView -= Input.GetAxis("DpadY");
						this.Smartphone.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 10f;
						if (this.Smartphone.fieldOfView > 60f)
						{
							this.Smartphone.fieldOfView = 60f;
						}
						if (this.Smartphone.fieldOfView < 30f)
						{
							this.Smartphone.fieldOfView = 30f;
						}
					}
					if (Input.GetAxis("RT") == 1f || Input.GetMouseButtonDown(0) || Input.GetButtonDown("RB"))
					{
						this.FixCamera();
						this.PauseScreen.CorrectingTime = false;
						Time.timeScale = 0.0001f;
						this.CanMove = false;
						this.Shutter.Snap();
					}
				}
				if (Time.timeScale > 0.0001f && ((this.UsingController && Input.GetAxis("LT") < 0.5f) || (!this.UsingController && !Input.GetMouseButton(1))))
				{
					this.StopAiming();
				}
				if (!this.StudentManager.Eighties)
				{
					if (Input.GetKey(KeyCode.LeftAlt))
					{
						if (!this.CinematicCamera.activeInHierarchy)
						{
							if (this.CinematicTimer > 0f)
							{
								this.CinematicCamera.transform.eulerAngles = this.Smartphone.transform.eulerAngles;
								this.CinematicCamera.transform.position = this.Smartphone.transform.position;
								this.CinematicCamera.SetActive(true);
								this.CinematicTimer = 0f;
								this.UpdateHair();
								this.StopAiming();
							}
							this.CinematicTimer += 1f;
						}
					}
					else
					{
						this.CinematicTimer = 0f;
					}
				}
			}
			if (this.Gloved)
			{
				if (!this.Chased && this.Chasers == 0)
				{
					if (this.InputDevice.Type == InputDeviceType.Gamepad)
					{
						if (Input.GetAxis("DpadY") < -0.5f)
						{
							if (this.CharacterAnimation["f02_removeGloves_00"].time == 0f)
							{
								this.GloveTimer += Time.deltaTime;
							}
							if (this.GloveTimer > 0.5f)
							{
								this.CharacterAnimation.CrossFade("f02_removeGloves_00");
								this.Degloving = true;
								this.CanMove = false;
							}
						}
						else
						{
							this.GloveTimer = 0f;
						}
					}
					else if (Input.GetKey(KeyCode.Alpha1))
					{
						if (this.CharacterAnimation["f02_removeGloves_00"].time == 0f)
						{
							this.GloveTimer += Time.deltaTime;
						}
						if (this.GloveTimer > 0.1f)
						{
							this.CharacterAnimation.CrossFade("f02_removeGloves_00");
							this.Degloving = true;
							this.CanMove = false;
						}
					}
					else
					{
						this.GloveTimer = 0f;
					}
				}
				else
				{
					this.GloveTimer = 0f;
				}
			}
			if (this.Weapon[1] != null && this.DropTimer[2] == 0f)
			{
				if (this.InputDevice.Type == InputDeviceType.Gamepad)
				{
					if (Input.GetAxis("DpadX") < -0.5f)
					{
						this.DropWeapon(1);
					}
					else
					{
						this.DropTimer[1] = 0f;
					}
				}
				else if (Input.GetKey(KeyCode.Alpha2))
				{
					this.DropWeapon(1);
				}
				else
				{
					this.DropTimer[1] = 0f;
				}
			}
			if (this.Weapon[2] != null && this.DropTimer[1] == 0f)
			{
				if (this.InputDevice.Type == InputDeviceType.Gamepad)
				{
					if (Input.GetAxis("DpadX") > 0.5f)
					{
						this.DropWeapon(2);
					}
					else
					{
						this.DropTimer[2] = 0f;
					}
				}
				else if (Input.GetKey(KeyCode.Alpha3))
				{
					this.DropWeapon(2);
				}
				else
				{
					this.DropTimer[2] = 0f;
				}
			}
			if (Input.GetButtonDown("LS") || Input.GetKeyDown(KeyCode.T))
			{
				if (this.NewTrail != null)
				{
					UnityEngine.Object.Destroy(this.NewTrail);
				}
				this.NewTrail = UnityEngine.Object.Instantiate<GameObject>(this.Trail, base.transform.position + base.transform.forward * 0.5f + Vector3.up * 0.1f, Quaternion.identity);
				if (SchemeGlobals.CurrentScheme == 0)
				{
					if (this.StudentManager.Tutorial != null && this.StudentManager.Tutorial.isActiveAndEnabled)
					{
						this.NewTrail.GetComponent<AIPath>().target = this.StudentManager.Tutorial.Destination[this.StudentManager.Tutorial.Phase];
					}
					else if (this.StudentManager.Tag.Target == null)
					{
						this.NewTrail.GetComponent<AIPath>().target = this.Homeroom;
					}
					else
					{
						this.NewTrail.GetComponent<AIPath>().target = this.StudentManager.Students[this.StudentManager.TagStudentID].transform;
					}
				}
				else if (this.PauseScreen.Schemes.SchemeDestinations[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme)] != null)
				{
					this.NewTrail.GetComponent<AIPath>().target = this.PauseScreen.Schemes.SchemeDestinations[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme)];
				}
				else
				{
					UnityEngine.Object.Destroy(this.NewTrail);
				}
			}
			if (this.Armed)
			{
				this.ID = 0;
				while (this.ID < this.ArmedAnims.Length)
				{
					string name = this.ArmedAnims[this.ID];
					this.CharacterAnimation[name].weight = Mathf.Lerp(this.CharacterAnimation[name].weight, (this.EquippedWeapon.AnimID == this.ID) ? 1f : 0f, Time.deltaTime * 10f);
					this.ID++;
				}
			}
			else
			{
				this.StopArmedAnim();
			}
			if (this.TheftTimer > 0f)
			{
				this.TheftTimer = Mathf.MoveTowards(this.TheftTimer, 0f, Time.deltaTime);
				if (this.TheftTimer == 0f)
				{
					this.StolenObjectID = 0;
				}
			}
			if (this.WeaponTimer > 0f)
			{
				this.WeaponTimer = Mathf.MoveTowards(this.WeaponTimer, 0f, Time.deltaTime);
			}
			if (this.MurderousActionTimer > 0f)
			{
				this.MurderousActionTimer = Mathf.MoveTowards(this.MurderousActionTimer, 0f, Time.deltaTime);
				if (this.MurderousActionTimer == 0f)
				{
					this.TargetStudent = null;
				}
			}
			if (this.SuspiciousActionTimer > 0f)
			{
				this.SuspiciousActionTimer = Mathf.MoveTowards(this.SuspiciousActionTimer, 0f, Time.deltaTime);
			}
			if (this.Chased)
			{
				this.PreparedForStruggle = true;
				this.CanMove = false;
			}
			if (this.Egg)
			{
				if (this.Eating)
				{
					this.FollowHips = false;
					this.Attacking = false;
					this.CanMove = true;
					this.Eating = false;
					this.EatPhase = 0;
				}
				if (this.Pod.activeInHierarchy)
				{
					if (!this.SithAttacking)
					{
						if (this.LightSword.transform.parent != this.LightSwordParent)
						{
							this.LightSword.transform.parent = this.LightSwordParent;
							this.LightSword.transform.localPosition = new Vector3(0f, 0f, 0f);
							this.LightSword.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							this.LightSwordParticles.Play();
						}
						if (this.HeavySword.transform.parent != this.HeavySwordParent)
						{
							this.HeavySword.transform.parent = this.HeavySwordParent;
							this.HeavySword.transform.localPosition = new Vector3(0f, 0f, 0f);
							this.HeavySword.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
							this.HeavySwordParticles.Play();
						}
					}
					if (Input.GetButtonDown("X"))
					{
						this.LightSword.transform.parent = this.LeftItemParent;
						this.LightSword.transform.localPosition = new Vector3(-0.015f, 0f, 0f);
						this.LightSword.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
						this.LightSword.GetComponent<WeaponTrail>().enabled = true;
						this.LightSword.GetComponent<WeaponTrail>().Start();
						this.CharacterAnimation["f02_nierAttack_00"].time = 0f;
						this.CharacterAnimation.Play("f02_nierAttack_00");
						this.SithAttacking = true;
						this.CanMove = false;
						this.SithBeam[1].Damage = 10f;
						this.NierDamage = 10f;
						this.SithPrefix = "";
						this.AttackPrefix = "nier";
					}
					if (Input.GetButtonDown("Y"))
					{
						this.HeavySword.transform.parent = this.ItemParent;
						this.HeavySword.transform.localPosition = new Vector3(-0.015f, 0f, 0f);
						this.HeavySword.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
						this.HeavySword.GetComponent<WeaponTrail>().enabled = true;
						this.HeavySword.GetComponent<WeaponTrail>().Start();
						this.CharacterAnimation["f02_nierAttackHard_00"].time = 0f;
						this.CharacterAnimation.Play("f02_nierAttackHard_00");
						this.SithAttacking = true;
						this.CanMove = false;
						this.SithBeam[1].Damage = 20f;
						this.NierDamage = 20f;
						this.SithPrefix = "Hard";
						this.AttackPrefix = "nier";
					}
				}
				if (this.WitchMode && Input.GetButtonDown("X") && this.InvertSphere.gameObject.activeInHierarchy)
				{
					this.CharacterAnimation["f02_fingerSnap_00"].time = 0f;
					this.CharacterAnimation.Play("f02_fingerSnap_00");
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.Snapping = true;
					this.CanMove = false;
				}
				if (this.Armor[20].activeInHierarchy && this.Armor[20].transform.parent == this.ItemParent && (Input.GetButtonDown("X") || Input.GetButtonDown("Y")))
				{
					this.CharacterAnimation["f02_nierAttackHard_00"].time = 0f;
					this.CharacterAnimation.Play("f02_nierAttackHard_00");
					this.SithAttacking = true;
					this.CanMove = false;
					this.SithBeam[1].Damage = 20f;
					this.NierDamage = 20f;
					this.SithPrefix = "Hard";
					this.AttackPrefix = "nier";
				}
				if (this.LongFingers && Input.GetButtonDown("X") && !this.Swiping)
				{
					if (this.SwipeID == 1)
					{
						this.SwipeID = 0;
					}
					else
					{
						this.SwipeID++;
					}
					AudioSource.PlayClipAtPoint(this.Swoosh, base.transform.position + Vector3.up);
					this.CharacterAnimation["f02_sithAttack_0" + this.SwipeID.ToString()].time = 0f;
					this.CharacterAnimation.Play("f02_sithAttack_0" + this.SwipeID.ToString());
					this.Swiping = true;
					this.CanMove = false;
				}
				if (this.TitanSword[0].activeInHierarchy)
				{
					this.UpdateODM();
					return;
				}
			}
		}
		else
		{
			if (this.Egg && this.TitanSword[0].activeInHierarchy)
			{
				this.UpdateODM();
			}
			if (this.Chased && !this.Sprayed && !this.Attacking && !this.Dumping && !this.StudentManager.PinningDown && !this.DelinquentFighting && !this.ShoulderCamera.HeartbrokenCamera.activeInHierarchy)
			{
				if (this.Pursuer != null)
				{
					this.targetRotation = Quaternion.LookRotation(this.Pursuer.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
					this.CharacterAnimation.CrossFade("f02_readyToFight_00");
					if (this.Dragging || this.Carrying)
					{
						this.EmptyHands();
					}
				}
				else
				{
					this.PreparedForStruggle = false;
					this.CanMove = true;
					this.Chased = false;
				}
			}
			this.StopArmedAnim();
			if (this.Dumping)
			{
				this.targetRotation = Quaternion.LookRotation(this.Incinerator.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.Incinerator.transform.position + Vector3.right * -2f);
				if (this.DumpTimer == 0f && this.Carrying)
				{
					this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
				}
				this.DumpTimer += Time.deltaTime;
				if (this.DumpTimer > 1f)
				{
					if (this.Ragdoll != null && !this.Ragdoll.GetComponent<RagdollScript>().Dumped)
					{
						this.DumpRagdoll(RagdollDumpType.Incinerator);
					}
					this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
					if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= this.CharacterAnimation["f02_carryDisposeA_00"].length)
					{
						this.Incinerator.Prompt.enabled = true;
						this.Incinerator.Ready = true;
						this.Incinerator.Open = false;
						this.Dragging = false;
						this.Dumping = false;
						this.CanMove = true;
						this.Ragdoll = null;
						this.StopCarrying();
						this.DumpTimer = 0f;
					}
				}
			}
			if (this.Chipping)
			{
				this.targetRotation = Quaternion.LookRotation(this.WoodChipper.gameObject.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.WoodChipper.DumpPoint.position);
				if (this.DumpTimer == 0f && this.Carrying)
				{
					this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
				}
				this.DumpTimer += Time.deltaTime;
				if (this.DumpTimer > 1f)
				{
					if (!this.Ragdoll.GetComponent<RagdollScript>().Dumped)
					{
						this.DumpRagdoll(RagdollDumpType.WoodChipper);
					}
					this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
					if ((double)this.CharacterAnimation["f02_carryDisposeA_00"].time >= 4.5 && this.WoodChipper.Acid && !this.WoodChipper.MyAudio.isPlaying)
					{
						this.WoodChipper.MyAudio.clip = this.WoodChipper.ShredAudio;
						this.WoodChipper.MyAudio.Play();
					}
					if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= this.CharacterAnimation["f02_carryDisposeA_00"].length)
					{
						if (!this.WoodChipper.Acid)
						{
							this.WoodChipper.Prompt.HideButton[0] = false;
						}
						this.WoodChipper.Prompt.HideButton[3] = true;
						this.WoodChipper.Occupied = true;
						this.WoodChipper.Open = false;
						this.Dragging = false;
						this.Chipping = false;
						this.CanMove = true;
						this.Ragdoll = null;
						this.StopCarrying();
						this.DumpTimer = 0f;
					}
				}
			}
			if (this.TranquilHiding)
			{
				this.targetRotation = Quaternion.LookRotation(this.TranqCase.transform.position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.TranqCase.transform.position + Vector3.right * 1.4f);
				if (this.DumpTimer == 0f && this.Carrying)
				{
					this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
				}
				this.DumpTimer += Time.deltaTime;
				if (this.DumpTimer > 1f)
				{
					if (!this.Ragdoll.GetComponent<RagdollScript>().Dumped)
					{
						this.DumpRagdoll(RagdollDumpType.TranqCase);
					}
					this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
					if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= this.CharacterAnimation["f02_carryDisposeA_00"].length)
					{
						this.TranquilHiding = false;
						this.Dragging = false;
						this.Dumping = false;
						this.CanMove = true;
						this.Ragdoll = null;
						this.StopCarrying();
						this.DumpTimer = 0f;
					}
				}
			}
			if (this.Dipping)
			{
				if (this.Bucket != null)
				{
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.Bucket.transform.position.x, base.transform.position.y, this.Bucket.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				}
				this.CharacterAnimation.CrossFade("f02_dipping_00");
				if (this.CharacterAnimation["f02_dipping_00"].time >= this.CharacterAnimation["f02_dipping_00"].length * 0.5f)
				{
					this.Mop.Bleached = true;
					this.Mop.Sparkles.Play();
					if (this.Mop.Bloodiness > 0f)
					{
						if (this.Bucket != null)
						{
							this.Bucket.Bloodiness += this.Mop.Bloodiness / 2f;
							this.Bucket.UpdateAppearance = true;
						}
						this.Mop.Bloodiness = 0f;
						this.Mop.UpdateBlood();
					}
				}
				if (this.CharacterAnimation["f02_dipping_00"].time >= this.CharacterAnimation["f02_dipping_00"].length)
				{
					this.CharacterAnimation["f02_dipping_00"].time = 0f;
					this.Mop.Prompt.enabled = true;
					this.Dipping = false;
					this.CanMove = true;
				}
			}
			if (this.Pouring)
			{
				this.MoveTowardsTarget(this.Stool.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Stool.rotation, 10f * Time.deltaTime);
				string text = "f02_bucketDump" + this.PourHeight + "_00";
				AnimationState animationState = this.CharacterAnimation[text];
				this.CharacterAnimation.CrossFade(text, 0f);
				if (animationState.time >= this.PourTime && !this.PickUp.Bucket.Poured)
				{
					if (this.PickUp.Bucket.Gasoline)
					{
						this.PickUp.Bucket.PourEffect.main.startColor = new Color(1f, 1f, 0f, 0.5f);
						UnityEngine.Object.Instantiate<GameObject>(this.PickUp.Bucket.GasCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * base.transform.forward, Quaternion.identity);
					}
					else if (this.PickUp.Bucket.Bloodiness < 50f)
					{
						this.PickUp.Bucket.PourEffect.main.startColor = new Color(0f, 1f, 1f, 0.5f);
						UnityEngine.Object.Instantiate<GameObject>(this.PickUp.Bucket.WaterCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * base.transform.forward, Quaternion.identity);
					}
					else
					{
						this.PickUp.Bucket.PourEffect.main.startColor = new Color(0.5f, 0f, 0f, 0.5f);
						UnityEngine.Object.Instantiate<GameObject>(this.PickUp.Bucket.BloodCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * base.transform.forward, Quaternion.identity);
					}
					this.PickUp.Bucket.PourEffect.Play();
					this.PickUp.Bucket.Poured = true;
					this.PickUp.Bucket.Empty();
				}
				if (animationState.time >= animationState.length)
				{
					animationState.time = 0f;
					this.PickUp.Bucket.Poured = false;
					this.Pouring = false;
					this.CanMove = true;
				}
			}
			if (this.Laughing)
			{
				if (this.Hairstyles[14].activeInHierarchy)
				{
					this.LaughAnim = "storepower_20";
					this.LaughClip = this.ChargeUp;
				}
				if (this.Stand.Stand.activeInHierarchy)
				{
					this.LaughAnim = "f02_jojoAttack_00";
					this.LaughClip = this.YanYan;
				}
				else if (this.FlameDemonic)
				{
					float axis = Input.GetAxis("Vertical");
					float axis2 = Input.GetAxis("Horizontal");
					Vector3 vector2 = this.MainCamera.transform.TransformDirection(Vector3.forward);
					vector2.y = 0f;
					vector2 = vector2.normalized;
					Vector3 a2 = new Vector3(vector2.z, 0f, -vector2.x);
					Vector3 vector3 = axis2 * a2 + axis * vector2;
					if (vector3 != Vector3.zero)
					{
						this.targetRotation = Quaternion.LookRotation(vector3);
						base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
					}
					this.LaughAnim = "f02_demonAttack_00";
					this.CirnoTimer -= Time.deltaTime;
					if (this.CirnoTimer < 0f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.Fireball, this.RightHand.position, base.transform.rotation).transform.localEulerAngles += new Vector3(UnityEngine.Random.Range(0f, 22.5f), UnityEngine.Random.Range(-22.5f, 22.5f), UnityEngine.Random.Range(-22.5f, 22.5f));
						UnityEngine.Object.Instantiate<GameObject>(this.Fireball, this.LeftHand.position, base.transform.rotation).transform.localEulerAngles += new Vector3(UnityEngine.Random.Range(0f, 22.5f), UnityEngine.Random.Range(-22.5f, 22.5f), UnityEngine.Random.Range(-22.5f, 22.5f));
						this.CirnoTimer = 0.1f;
					}
				}
				else if (this.CirnoHair.activeInHierarchy)
				{
					float axis3 = Input.GetAxis("Vertical");
					float axis4 = Input.GetAxis("Horizontal");
					Vector3 vector4 = this.MainCamera.transform.TransformDirection(Vector3.forward);
					vector4.y = 0f;
					vector4 = vector4.normalized;
					Vector3 a3 = new Vector3(vector4.z, 0f, -vector4.x);
					Vector3 vector5 = axis4 * a3 + axis3 * vector4;
					if (vector5 != Vector3.zero)
					{
						this.targetRotation = Quaternion.LookRotation(vector5);
						base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
					}
					this.LaughAnim = "f02_cirnoAttack_00";
					this.CirnoTimer -= Time.deltaTime;
					if (this.CirnoTimer < 0f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.CirnoIceAttack, base.transform.position + base.transform.up * 1.4f, base.transform.rotation).transform.localEulerAngles += new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
						this.MyAudio.PlayOneShot(this.CirnoIceClip);
						this.CirnoTimer = 0.1f;
					}
				}
				else if (this.TornadoHair.activeInHierarchy)
				{
					this.LaughAnim = "f02_tornadoAttack_00";
					this.CirnoTimer -= Time.deltaTime;
					if (this.CirnoTimer < 0f)
					{
						GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.TornadoAttack, base.transform.forward * 5f + new Vector3(base.transform.position.x + UnityEngine.Random.Range(-5f, 5f), base.transform.position.y, base.transform.position.z + UnityEngine.Random.Range(-5f, 5f)), base.transform.rotation);
						while (Vector3.Distance(base.transform.position, gameObject4.transform.position) < 1f)
						{
							gameObject4.transform.position = base.transform.forward * 5f + new Vector3(base.transform.position.x + UnityEngine.Random.Range(-5f, 5f), base.transform.position.y, base.transform.position.z + UnityEngine.Random.Range(-5f, 5f));
						}
						this.CirnoTimer = 0.1f;
					}
				}
				else if (this.BladeHair.activeInHierarchy)
				{
					this.LaughAnim = "f02_spin_00";
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y + Time.deltaTime * 360f * 2f, base.transform.localEulerAngles.z);
					this.BladeHairCollider1.enabled = true;
					this.BladeHairCollider2.enabled = true;
				}
				else if (this.BanchoActive)
				{
					this.BanchoFlurry.MyCollider.enabled = true;
					this.LaughAnim = "f02_banchoFlurry_00";
				}
				else if (this.MyAudio.clip != this.LaughClip)
				{
					this.MyAudio.clip = this.LaughClip;
					this.MyAudio.time = 0f;
					this.MyAudio.Play();
				}
				this.CharacterAnimation.CrossFade(this.LaughAnim);
				if (Input.GetButtonDown("RB"))
				{
					this.LaughIntensity += 1f;
					if (this.LaughIntensity <= 5f)
					{
						this.LaughAnim = "f02_laugh_01";
						this.LaughClip = this.Laugh1;
						this.LaughTimer = 0.5f;
					}
					else if (this.LaughIntensity <= 10f)
					{
						this.LaughAnim = "f02_laugh_02";
						this.LaughClip = this.Laugh2;
						this.LaughTimer = 1f;
					}
					else if (this.LaughIntensity <= 15f)
					{
						this.LaughAnim = "f02_laugh_03";
						this.LaughClip = this.Laugh3;
						this.LaughTimer = 1.5f;
					}
					else if (this.LaughIntensity <= 20f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
						if (this.StudentManager.Eighties)
						{
							this.LaughAnim = "f02_evilLaugh_00";
						}
						else
						{
							this.LaughAnim = "f02_laugh_04";
						}
						this.LaughClip = this.Laugh4;
						this.LaughTimer = 2f;
						this.LoseGentleEyes();
					}
					else
					{
						UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
						if (this.StudentManager.Eighties)
						{
							this.LaughAnim = "f02_evilLaugh_00";
						}
						else
						{
							this.LaughAnim = "f02_laugh_04";
						}
						this.LaughIntensity = 20f;
						this.LaughTimer = 2f;
					}
				}
				if (this.LaughIntensity > 15f)
				{
					this.Sanity += Time.deltaTime * 10f;
				}
				this.LaughTimer -= Time.deltaTime;
				if (this.LaughTimer <= 0f)
				{
					this.StopLaughing();
				}
			}
			if (this.TimeSkipping)
			{
				this.CharacterAnimation.CrossFade("f02_timeSkip_00");
				this.Sanity += Time.deltaTime * 0.166666f;
			}
			if (this.DumpsterGrabbing)
			{
				if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetKey("right"))
				{
					this.CharacterAnimation.CrossFade((this.DumpsterHandle.Direction == -1f) ? "f02_dumpsterPull_00" : "f02_dumpsterPush_00");
				}
				else if (Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetKey("left"))
				{
					this.CharacterAnimation.CrossFade((this.DumpsterHandle.Direction == -1f) ? "f02_dumpsterPush_00" : "f02_dumpsterPull_00");
				}
				else
				{
					this.CharacterAnimation.CrossFade("f02_dumpsterGrab_00");
				}
			}
			if (this.Stripping)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.StudentManager.YandereStripSpot.rotation, 10f * Time.deltaTime);
				if (this.CharacterAnimation["f02_stripping_00"].time >= this.CharacterAnimation["f02_stripping_00"].length)
				{
					this.Stripping = false;
					this.CanMove = true;
					this.MyLocker.UpdateSchoolwear();
				}
			}
			if (this.Bathing)
			{
				this.MoveTowardsTarget(this.YandereShower.BatheSpot.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.YandereShower.BatheSpot.rotation, 10f * Time.deltaTime);
				this.CharacterAnimation.CrossFade(this.IdleAnim);
				if (this.YandereShower.Timer < 1f)
				{
					this.Bloodiness = 0f;
					this.Bathing = false;
					this.CanMove = true;
				}
			}
			if (this.Degloving)
			{
				this.CharacterAnimation.CrossFade("f02_removeGloves_00");
				if (this.CharacterAnimation["f02_removeGloves_00"].time >= this.CharacterAnimation["f02_removeGloves_00"].length)
				{
					this.Gloves.GetComponent<Rigidbody>().isKinematic = false;
					this.Gloves.transform.parent = null;
					if (this.WearingRaincoat)
					{
						this.RaincoatAttacher.newRenderer.enabled = false;
						this.PantyAttacher.newRenderer.enabled = true;
						this.TheDebugMenuScript.UpdateCensor();
						this.CoatBloodiness = this.Bloodiness;
						this.Bloodiness = this.OriginalBloodiness;
						this.WearingRaincoat = false;
						if (this.StudentManager.Eighties)
						{
							this.Hairstyle = 203;
						}
						else
						{
							this.Hairstyle = 1;
						}
						this.UpdateHair();
					}
					else
					{
						this.GloveAttacher.newRenderer.enabled = false;
					}
					this.Gloves.gameObject.SetActive(true);
					this.StudentManager.GloveID = 0;
					this.Degloving = false;
					this.CanMove = true;
					this.Gloved = false;
					this.Gloves = null;
					this.SetUniform();
					this.GloveBlood = 0;
					Debug.Log("Gloves removed.");
				}
				else if (this.Chased || this.Chasers > 0 || this.Noticed)
				{
					this.Degloving = false;
					this.GloveTimer = 0f;
					if (!this.Noticed)
					{
						this.CanMove = true;
					}
				}
				else if (this.InputDevice.Type == InputDeviceType.Gamepad)
				{
					if (Input.GetAxis("DpadY") > -0.5f)
					{
						this.Degloving = false;
						this.CanMove = true;
						this.GloveTimer = 0f;
					}
				}
				else if (Input.GetKeyUp(KeyCode.Alpha1))
				{
					this.Degloving = false;
					this.CanMove = true;
					this.GloveTimer = 0f;
				}
			}
			if (this.Struggling)
			{
				if (!this.Won && !this.Lost)
				{
					this.CharacterAnimation.CrossFade(this.TargetStudent.Teacher ? "f02_teacherStruggleA_00" : "f02_struggleA_00");
					this.targetRotation = Quaternion.LookRotation(this.TargetStudent.transform.position - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				}
				else if (this.Won)
				{
					if (!this.TargetStudent.Teacher)
					{
						this.CharacterAnimation.CrossFade("f02_struggleWinA_00");
						if (this.CharacterAnimation["f02_struggleWinA_00"].time > this.CharacterAnimation["f02_struggleWinA_00"].length - 1f)
						{
							this.EquippedWeapon.transform.localEulerAngles = Vector3.Lerp(this.EquippedWeapon.transform.localEulerAngles, Vector3.zero, Time.deltaTime * 3.33333f);
						}
					}
					else
					{
						Debug.Log(this.TargetStudent.Name + " is being instructed to perform their ''losing struggle'' animation.");
						this.CharacterAnimation.CrossFade("f02_teacherStruggleWinA_00");
						this.TargetStudent.CharacterAnimation.CrossFade(this.TargetStudent.StruggleWonAnim);
						this.EquippedWeapon.transform.localEulerAngles = Vector3.Lerp(this.EquippedWeapon.transform.localEulerAngles, Vector3.zero, Time.deltaTime);
					}
					if (this.StrugglePhase == 0)
					{
						if ((!this.TargetStudent.Teacher && this.CharacterAnimation["f02_struggleWinA_00"].time > 1.3f) || (this.TargetStudent.Teacher && this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > 0.8f))
						{
							Debug.Log("Yandere-chan just killed " + this.TargetStudent.Name + " as a result of winning a struggling against them.");
							this.TargetStudent.DeathCause = this.EquippedWeapon.WeaponID;
							UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.TargetStudent.Teacher ? this.EquippedWeapon.transform.position : this.TargetStudent.Head.position, Quaternion.identity);
							this.Bloodiness += 20f;
							this.Sanity -= 20f * this.Numbness;
							this.StainWeapon();
							this.StrugglePhase++;
						}
					}
					else if (this.StrugglePhase == 1)
					{
						if (this.TargetStudent.Teacher && this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > 1.3f)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.EquippedWeapon.transform.position, Quaternion.identity);
							this.StrugglePhase++;
						}
					}
					else if (this.StrugglePhase == 2 && this.TargetStudent.Teacher && this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > 2.1f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.EquippedWeapon.transform.position, Quaternion.identity);
						this.StrugglePhase++;
					}
					if ((!this.TargetStudent.Teacher && this.CharacterAnimation["f02_struggleWinA_00"].time > this.CharacterAnimation["f02_struggleWinA_00"].length) || (this.TargetStudent.Teacher && this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > this.CharacterAnimation["f02_teacherStruggleWinA_00"].length))
					{
						this.MyController.radius = 0.2f;
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.ShoulderCamera.Struggle = false;
						this.Struggling = false;
						this.StrugglePhase = 0;
						if (this.TargetStudent == this.Pursuer)
						{
							this.Pursuer = null;
							this.Chased = false;
						}
						this.TargetStudent.BecomeRagdoll();
						this.TargetStudent.DeathType = DeathType.Weapon;
						this.SeenByAuthority = false;
					}
				}
				else if (this.Lost)
				{
					this.CharacterAnimation.CrossFade(this.TargetStudent.Teacher ? "f02_teacherStruggleLoseA_00" : "f02_struggleLoseA_00");
				}
			}
			if (this.ClubActivity)
			{
				if (this.Club == ClubType.Drama)
				{
					this.CharacterAnimation.Play("f02_performing_00");
				}
				else if (this.Club == ClubType.Art)
				{
					this.CharacterAnimation.Play("f02_painting_00");
				}
				else if (this.Club == ClubType.MartialArts)
				{
					this.CharacterAnimation.Play("f02_kick_23");
					if (this.CharacterAnimation["f02_kick_23"].time >= this.CharacterAnimation["f02_kick_23"].length)
					{
						this.CharacterAnimation["f02_kick_23"].time = 0f;
					}
				}
				else if (this.Club == ClubType.Photography)
				{
					this.CharacterAnimation.Play("f02_sit_00");
				}
				else if (this.Club == ClubType.Gaming)
				{
					this.CharacterAnimation.Play("f02_playingGames_00");
				}
			}
			if (this.Possessed)
			{
				this.CharacterAnimation.CrossFade("f02_possessionPose_00");
			}
			if (this.Lifting)
			{
				if (!this.HeavyWeight)
				{
					if (this.CharacterAnimation["f02_carryLiftA_00"].time >= this.CharacterAnimation["f02_carryLiftA_00"].length)
					{
						this.IdleAnim = this.CarryIdleAnim;
						this.WalkAnim = this.CarryWalkAnim;
						this.RunAnim = this.CarryRunAnim;
						this.CanMove = true;
						this.Carrying = true;
						this.Lifting = false;
					}
				}
				else if (this.CharacterAnimation["f02_heavyWeightLift_00"].time >= this.CharacterAnimation["f02_heavyWeightLift_00"].length)
				{
					this.CharacterAnimation[this.CarryAnims[0]].weight = 1f;
					this.IdleAnim = this.HeavyIdleAnim;
					this.WalkAnim = this.HeavyWalkAnim;
					this.RunAnim = this.CarryRunAnim;
					this.CanMove = true;
					this.Lifting = false;
				}
			}
			if (this.Dropping)
			{
				this.targetRotation = Quaternion.LookRotation(this.DropSpot.position + this.DropSpot.forward - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.DropSpot.position);
				if (this.Ragdoll != null && this.CurrentRagdoll == null)
				{
					this.CurrentRagdoll = this.Ragdoll.GetComponent<RagdollScript>();
				}
				if (this.DumpTimer == 0f && this.Carrying)
				{
					this.CurrentRagdoll.CharacterAnimation[this.CurrentRagdoll.DumpedAnim].time = 2.5f;
					this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
				}
				this.DumpTimer += Time.deltaTime;
				if (this.DumpTimer > 1f)
				{
					this.FollowHips = true;
					if (this.Ragdoll != null)
					{
						this.CurrentRagdoll.PelvisRoot.localEulerAngles = new Vector3(this.CurrentRagdoll.PelvisRoot.localEulerAngles.x, 0f, this.CurrentRagdoll.PelvisRoot.localEulerAngles.z);
						this.CurrentRagdoll.PelvisRoot.localPosition = new Vector3(this.CurrentRagdoll.PelvisRoot.localPosition.x, this.CurrentRagdoll.PelvisRoot.localPosition.y, 0f);
					}
					this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(this.Hips.position.x, base.transform.position.y + 1f, this.Hips.position.z), Time.deltaTime * 10f);
					if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= 4.5f)
					{
						this.StopCarrying();
					}
					else
					{
						if (this.CurrentRagdoll.StopAnimation)
						{
							this.CurrentRagdoll.StopAnimation = false;
							this.ID = 0;
							while (this.ID < this.CurrentRagdoll.AllRigidbodies.Length)
							{
								this.CurrentRagdoll.AllRigidbodies[this.ID].isKinematic = true;
								this.ID++;
							}
						}
						this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
						this.CurrentRagdoll.CharacterAnimation.CrossFade(this.CurrentRagdoll.DumpedAnim);
						this.Ragdoll.transform.position = base.transform.position;
						this.Ragdoll.transform.eulerAngles = base.transform.eulerAngles;
					}
					if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= this.CharacterAnimation["f02_carryDisposeA_00"].length)
					{
						this.CameraTarget.localPosition = new Vector3(0f, 1f, 0f);
						this.FollowHips = false;
						this.Dropping = false;
						this.CanMove = true;
						this.DumpTimer = 0f;
					}
				}
			}
			if (this.Dismembering && this.CharacterAnimation["f02_dismember_00"].time >= this.CharacterAnimation["f02_dismember_00"].length)
			{
				this.CameraEffects.UpdateDOF(2f);
				this.Ragdoll.GetComponent<RagdollScript>().Dismember();
				this.RPGCamera.enabled = true;
				this.TargetStudent = null;
				this.Dismembering = false;
				this.CanMove = true;
				this.Ragdoll = null;
			}
			if (this.Shoved)
			{
				if (this.CharacterAnimation["f02_shoveA_01"].time >= this.CharacterAnimation["f02_shoveA_01"].length)
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.Shoved = false;
					if (!this.CannotRecover)
					{
						this.CanMove = true;
					}
				}
				else if (this.CharacterAnimation["f02_shoveA_01"].time < 0.66666f)
				{
					this.MyController.Move(base.transform.forward * -1f * this.ShoveSpeed * Time.deltaTime);
					this.MyController.Move(Physics.gravity * 0.1f);
					if (this.ShoveSpeed > 0f)
					{
						this.ShoveSpeed = Mathf.MoveTowards(this.ShoveSpeed, 0f, Time.deltaTime * 3f);
					}
				}
			}
			if (this.Attacked && this.CharacterAnimation["f02_swingB_00"].time >= this.CharacterAnimation["f02_swingB_00"].length)
			{
				this.ShoulderCamera.HeartbrokenCamera.SetActive(true);
				base.enabled = false;
			}
			if (this.Hiding)
			{
				if (!this.Exiting)
				{
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.HidingSpot.rotation, Time.deltaTime * 10f);
					this.MoveTowardsTarget(this.HidingSpot.position);
					this.CharacterAnimation.CrossFade(this.HideAnim);
					if (Input.GetButtonDown("B"))
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
						this.Exiting = true;
					}
				}
				else
				{
					this.MoveTowardsTarget(this.ExitSpot.position);
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					this.ExitTimer += Time.deltaTime;
					if (this.ExitTimer > 1f || Vector3.Distance(base.transform.position, this.ExitSpot.position) < 0.1f)
					{
						this.MyController.center = new Vector3(this.MyController.center.x, 0.875f, this.MyController.center.z);
						this.MyController.radius = 0.2f;
						this.MyController.height = 1.55f;
						this.ExitTimer = 0f;
						this.Exiting = false;
						this.CanMove = true;
						this.Hiding = false;
					}
				}
			}
			if (this.BucketDropping)
			{
				this.targetRotation = Quaternion.LookRotation(this.DropSpot.position + this.DropSpot.forward - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.DropSpot.position);
				if (this.CharacterAnimation["f02_bucketDrop_00"].time >= this.CharacterAnimation["f02_bucketDrop_00"].length)
				{
					this.MyController.radius = 0.2f;
					this.BucketDropping = false;
					this.CanMove = true;
				}
				else if (this.CharacterAnimation["f02_bucketDrop_00"].time >= 1f && this.PickUp != null)
				{
					GameObjectUtils.SetLayerRecursively(this.PickUp.Bucket.gameObject, 0);
					this.PickUp.Bucket.UpdateAppearance = true;
					this.PickUp.Bucket.Dropped = true;
					this.EmptyHands();
				}
			}
			if (this.Flicking)
			{
				if (this.CharacterAnimation["f02_flickingMatch_00"].time >= this.CharacterAnimation["f02_flickingMatch_00"].length)
				{
					this.PickUp.GetComponent<MatchboxScript>().Prompt.enabled = true;
					this.Arc.SetActive(true);
					this.Flicking = false;
					this.CanMove = true;
				}
				else if (this.CharacterAnimation["f02_flickingMatch_00"].time > 1f && this.Match != null)
				{
					Rigidbody component = this.Match.GetComponent<Rigidbody>();
					component.isKinematic = false;
					component.useGravity = true;
					component.AddRelativeForce(Vector3.right * 250f);
					this.Match.transform.parent = null;
					this.Match = null;
				}
			}
			if (this.Rummaging)
			{
				this.MoveTowardsTarget(this.RummageSpot.Target.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.RummageSpot.Target.rotation, Time.deltaTime * 10f);
				this.RummageTimer += Time.deltaTime;
				this.ProgressBar.transform.localScale = new Vector3(this.RummageTimer / 10f, this.ProgressBar.transform.localScale.y, this.ProgressBar.transform.localScale.z);
				if (this.RummageTimer > 10f)
				{
					this.RummageSpot.GetReward();
					this.ProgressBar.transform.parent.gameObject.SetActive(false);
					this.RummageSpot = null;
					this.Rummaging = false;
					this.RummageTimer = 0f;
					this.CanMove = true;
				}
			}
			if (this.Digging)
			{
				if (this.DigPhase == 1)
				{
					if (this.CharacterAnimation["f02_shovelDig_00"].time >= 1.6666666f)
					{
						this.MyAudio.volume = 1f;
						this.MyAudio.clip = this.Dig;
						this.MyAudio.Play();
						this.DigPhase++;
					}
				}
				else if (this.DigPhase == 2)
				{
					if (this.CharacterAnimation["f02_shovelDig_00"].time >= 3.5f)
					{
						this.MyAudio.volume = 1f;
						this.MyAudio.Play();
						this.DigPhase++;
					}
				}
				else if (this.DigPhase == 3)
				{
					if (this.CharacterAnimation["f02_shovelDig_00"].time >= 5.6666665f)
					{
						this.MyAudio.volume = 1f;
						this.MyAudio.Play();
						this.DigPhase++;
					}
				}
				else if (this.DigPhase == 4 && this.CharacterAnimation["f02_shovelDig_00"].time >= this.CharacterAnimation["f02_shovelDig_00"].length)
				{
					this.EquippedWeapon.gameObject.SetActive(true);
					this.FloatingShovel.SetActive(false);
					this.RPGCamera.enabled = true;
					this.Digging = false;
					this.CanMove = true;
				}
			}
			if (this.Burying)
			{
				if (this.DigPhase == 1)
				{
					if (this.CharacterAnimation["f02_shovelBury_00"].time >= 2.1666667f)
					{
						this.MyAudio.volume = 1f;
						this.MyAudio.clip = this.Dig;
						this.MyAudio.Play();
						this.DigPhase++;
					}
				}
				else if (this.DigPhase == 2)
				{
					if (this.CharacterAnimation["f02_shovelBury_00"].time >= 4.6666665f)
					{
						this.MyAudio.volume = 1f;
						this.MyAudio.Play();
						this.DigPhase++;
					}
				}
				else if (this.CharacterAnimation["f02_shovelBury_00"].time >= this.CharacterAnimation["f02_shovelBury_00"].length)
				{
					this.EquippedWeapon.gameObject.SetActive(true);
					this.FloatingShovel.SetActive(false);
					this.RPGCamera.enabled = true;
					this.Burying = false;
					this.CanMove = true;
				}
			}
			if (this.Pickpocketing && !this.Noticed && this.Caught)
			{
				this.CaughtTimer += Time.deltaTime;
				if (this.CaughtTimer > 1f)
				{
					if (!this.CannotRecover)
					{
						this.CanMove = true;
					}
					this.Pickpocketing = false;
					this.CaughtTimer = 0f;
					this.Caught = false;
				}
			}
			if (this.Sprayed)
			{
				if (this.SprayPhase == 0)
				{
					if ((double)this.CharacterAnimation["f02_sprayed_00"].time > 0.66666)
					{
						this.Blur.enabled = true;
						this.Blur.Size += Time.deltaTime;
					}
					if (this.CharacterAnimation["f02_sprayed_00"].time > 5f)
					{
						this.Police.Darkness.enabled = true;
						this.Police.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Police.Darkness.color.a, 1f, Time.deltaTime));
						if (this.Police.Darkness.color.a == 1f)
						{
							this.SprayTimer += Time.deltaTime;
							if (this.SprayTimer > 1f)
							{
								this.CharacterAnimation.Play("f02_tied_00");
								this.RPGCamera.enabled = false;
								this.ZipTie[0].SetActive(true);
								this.ZipTie[1].SetActive(true);
								this.Blur.enabled = false;
								this.SprayTimer = 0f;
								this.SprayPhase++;
							}
						}
					}
				}
				else if (this.SprayPhase == 1)
				{
					this.Police.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Police.Darkness.color.a, 0f, Time.deltaTime));
					if (this.Police.Darkness.color.a == 0f)
					{
						this.SprayTimer += Time.deltaTime;
						if (this.SprayTimer > 1f)
						{
							this.ShoulderCamera.HeartbrokenCamera.SetActive(true);
							this.HeartCamera.gameObject.SetActive(false);
							this.HUD.alpha = 0f;
							this.SprayPhase++;
						}
					}
				}
			}
			if (this.CleaningWeapon)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Target.rotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.Target.position);
				if (this.CharacterAnimation["f02_cleaningWeapon_00"].time >= this.CharacterAnimation["f02_cleaningWeapon_00"].length)
				{
					this.EquippedWeapon.Blood.enabled = false;
					this.EquippedWeapon.Bloody = false;
					this.EquippedWeapon.SuspicionCheck();
					if (this.Gloved)
					{
						this.EquippedWeapon.FingerprintID = 0;
					}
					this.CleaningWeapon = false;
					this.CanMove = true;
				}
			}
			if (this.CrushingPhone)
			{
				this.CharacterAnimation.CrossFade("f02_phoneCrush_00");
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.PhoneToCrush.transform.position.x, base.transform.position.y, this.PhoneToCrush.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.PhoneToCrush.PhoneCrushingSpot.position);
				if (this.CharacterAnimation["f02_phoneCrush_00"].time >= 0.5f && this.PhoneToCrush.enabled)
				{
					this.PhoneToCrush.transform.localEulerAngles = new Vector3(this.PhoneToCrush.transform.localEulerAngles.x, this.PhoneToCrush.transform.localEulerAngles.y, 0f);
					UnityEngine.Object.Instantiate<GameObject>(this.PhoneToCrush.PhoneSmash, this.PhoneToCrush.transform.position, Quaternion.identity);
					this.Police.PhotoEvidence--;
					this.PhoneToCrush.MyRenderer.material.mainTexture = this.PhoneToCrush.SmashedTexture;
					this.PhoneToCrush.MyMesh.mesh = this.PhoneToCrush.SmashedMesh;
					this.PhoneToCrush.Prompt.Hide();
					this.PhoneToCrush.Prompt.enabled = false;
					this.PhoneToCrush.enabled = false;
				}
				if (this.CharacterAnimation["f02_phoneCrush_00"].time >= this.CharacterAnimation["f02_phoneCrush_00"].length)
				{
					this.CrushingPhone = false;
					this.CanMove = true;
				}
			}
			if (this.SubtleStabbing)
			{
				if (this.CharacterAnimation["f02_subtleStab_00"].time < 0.5f)
				{
					this.CharacterAnimation.CrossFade("f02_subtleStab_00");
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
					this.MoveTowardsTarget(this.TargetStudent.transform.position + this.TargetStudent.transform.forward * -1f);
				}
				else if (this.TargetStudent.Strength > 0)
				{
					this.TargetStudent.Strength = 0;
					this.TargetStudent.Hunter.MurderSuicidePhase = 0;
					this.TargetStudent.Hunter.AttackWillFail = false;
					this.TargetStudent.Hunter.Pathfinding.canMove = true;
					this.TargetStudent.CharacterAnimation["f02_murderSuicide_01"].time = 1.5f;
					this.TargetStudent.Hunter.CharacterAnimation["f02_murderSuicide_00"].time = 1.5f;
					Debug.Log("Making the hunter's attack a success!");
				}
				if (this.CharacterAnimation["f02_subtleStab_00"].time >= this.CharacterAnimation["f02_subtleStab_00"].length)
				{
					this.SubtleStabbing = false;
					this.CanMove = true;
				}
			}
			if (this.SneakingShot)
			{
				if (this.SneakShotTimer == 0f)
				{
					this.CharacterAnimation["f02_sneakShot_01"].speed = 4f;
					this.CharacterAnimation.CrossFade("f02_sneakShot_01");
					if (this.CharacterAnimation["f02_sneakShot_01"].time >= 1f)
					{
						this.SneakShotPhone.SetActive(true);
					}
					if (this.CharacterAnimation["f02_sneakShot_01"].time >= this.CharacterAnimation["f02_sneakShot_01"].length)
					{
						this.SneakShotTimer += Time.deltaTime;
						this.CameraFlash.SetActive(true);
						this.StudentManager.UpdatePanties(true);
						UnityEngine.Object.Instantiate<GameObject>(this.PantyDetector, this.SneakShotPhone.transform.position, base.transform.rotation).GetComponent<PantyDetectorScript>().Yandere = this;
					}
				}
				else
				{
					this.SneakShotTimer += Time.deltaTime;
					if (this.SneakShotTimer > 0.33333f)
					{
						this.CharacterAnimation["f02_sneakShot_02"].speed = 4f;
						this.CharacterAnimation.CrossFade("f02_sneakShot_02");
						if (this.CharacterAnimation["f02_sneakShot_02"].time >= 1.5f)
						{
							this.SneakShotPhone.SetActive(false);
							this.CameraFlash.SetActive(false);
							this.SneakingShot = false;
							this.CanMove = true;
							this.Lewd = false;
							this.SneakShotTimer = 0f;
						}
					}
				}
			}
			if (this.CanMoveTimer > 0f)
			{
				this.CanMoveTimer = Mathf.MoveTowards(this.CanMoveTimer, 0f, Time.deltaTime);
				if (this.CanMoveTimer == 0f)
				{
					this.CanMove = true;
				}
			}
			if (this.Egg)
			{
				if (this.Punching)
				{
					if (this.FalconHelmet.activeInHierarchy)
					{
						if (this.CharacterAnimation["f02_falconPunch_00"].time >= 1f && this.CharacterAnimation["f02_falconPunch_00"].time <= 1.25f)
						{
							this.FalconSpeed = Mathf.MoveTowards(this.FalconSpeed, 2.5f, Time.deltaTime * 2.5f);
						}
						else if (this.CharacterAnimation["f02_falconPunch_00"].time >= 1.25f && this.CharacterAnimation["f02_falconPunch_00"].time <= 1.5f)
						{
							this.FalconSpeed = Mathf.MoveTowards(this.FalconSpeed, 0f, Time.deltaTime * 2.5f);
						}
						if (this.CharacterAnimation["f02_falconPunch_00"].time >= 1f && this.CharacterAnimation["f02_falconPunch_00"].time <= 1.5f)
						{
							if (this.NewFalconPunch == null)
							{
								this.NewFalconPunch = UnityEngine.Object.Instantiate<GameObject>(this.FalconPunch);
								this.NewFalconPunch.transform.parent = this.ItemParent;
								this.NewFalconPunch.transform.localPosition = Vector3.zero;
							}
							this.MyController.Move(base.transform.forward * this.FalconSpeed);
						}
						if (this.CharacterAnimation["f02_falconPunch_00"].time >= this.CharacterAnimation["f02_falconPunch_00"].length)
						{
							this.NewFalconPunch = null;
							this.Punching = false;
							this.CanMove = true;
						}
					}
					else
					{
						if (this.CharacterAnimation["f02_onePunch_00"].time >= 0.833333f && this.CharacterAnimation["f02_onePunch_00"].time <= 1f && this.NewOnePunch == null)
						{
							this.NewOnePunch = UnityEngine.Object.Instantiate<GameObject>(this.OnePunch);
							this.NewOnePunch.transform.parent = this.ItemParent;
							this.NewOnePunch.transform.localPosition = Vector3.zero;
						}
						if (this.CharacterAnimation["f02_onePunch_00"].time >= 2f)
						{
							this.NewOnePunch = null;
							this.Punching = false;
							this.CanMove = true;
						}
					}
				}
				if (this.PK)
				{
					if (Input.GetAxis("Vertical") > 0.5f)
					{
						this.GoToPKDir(PKDirType.Up, "f02_sansUp_00", new Vector3(0f, 3f, 2f));
					}
					else if (Input.GetAxis("Vertical") < -0.5f)
					{
						this.GoToPKDir(PKDirType.Down, "f02_sansDown_00", new Vector3(0f, 0f, 2f));
					}
					else if (Input.GetAxis("Horizontal") > 0.5f)
					{
						this.GoToPKDir(PKDirType.Right, "f02_sansRight_00", new Vector3(1.5f, 1.5f, 2f));
					}
					else if (Input.GetAxis("Horizontal") < -0.5f)
					{
						this.GoToPKDir(PKDirType.Left, "f02_sansLeft_00", new Vector3(-1.5f, 1.5f, 2f));
					}
					else
					{
						this.CharacterAnimation.CrossFade("f02_sansHold_00");
						this.RagdollPK.transform.localPosition = new Vector3(0f, 1.5f, 2f);
						this.PKDir = PKDirType.None;
					}
					if (Input.GetButtonDown("B"))
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = false;
						this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
						this.SansEyes[0].SetActive(false);
						this.SansEyes[1].SetActive(false);
						this.GlowEffect.Stop();
						this.CanMove = true;
						this.PK = false;
					}
				}
				if (this.SummonBones)
				{
					this.CharacterAnimation.CrossFade("f02_sansBones_00");
					if (this.BoneTimer == 0f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.Bone, base.transform.position + base.transform.right * UnityEngine.Random.Range(-2.5f, 2.5f) + base.transform.up * -2f + base.transform.forward * UnityEngine.Random.Range(1f, 6f), Quaternion.identity);
					}
					this.BoneTimer += Time.deltaTime;
					if (this.BoneTimer > 0.1f)
					{
						this.BoneTimer = 0f;
					}
					if (Input.GetButtonUp("RB"))
					{
						this.SansEyes[0].SetActive(false);
						this.SansEyes[1].SetActive(false);
						this.GlowEffect.Stop();
						this.SummonBones = false;
						this.CanMove = true;
					}
					if (this.PK)
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = false;
						this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
						this.SansEyes[0].SetActive(false);
						this.SansEyes[1].SetActive(false);
						this.GlowEffect.Stop();
						this.CanMove = true;
						this.PK = false;
					}
				}
				if (this.Blasting)
				{
					if (this.CharacterAnimation["f02_sansBlaster_00"].time >= this.CharacterAnimation["f02_sansBlaster_00"].length - 0.25f)
					{
						this.SansEyes[0].SetActive(false);
						this.SansEyes[1].SetActive(false);
						this.GlowEffect.Stop();
						this.Blasting = false;
						this.CanMove = true;
					}
					if (this.PK)
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.UpdateButtons();
						this.PromptBar.Show = false;
						this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
						this.SansEyes[0].SetActive(false);
						this.SansEyes[1].SetActive(false);
						this.GlowEffect.Stop();
						this.CanMove = true;
						this.PK = false;
					}
				}
				if (this.SithAttacking)
				{
					if (!this.SithRecovering)
					{
						if (this.SithBeam[1].Damage == 10f || this.NierDamage == 10f)
						{
							if (this.SithAttacks == 0 && this.CharacterAnimation[string.Concat(new string[]
							{
								"f02_",
								this.AttackPrefix,
								"Attack",
								this.SithPrefix,
								"_0",
								this.SithCombo.ToString()
							})].time >= this.SithSpawnTime[this.SithCombo])
							{
								UnityEngine.Object.Instantiate<GameObject>(this.SithHitbox, base.transform.position + base.transform.forward * 1f + base.transform.up, base.transform.rotation);
								this.SithAttacks++;
							}
						}
						else if (this.Pod.activeInHierarchy || this.Armor[20].activeInHierarchy)
						{
							if (this.CharacterAnimation[string.Concat(new string[]
							{
								"f02_",
								this.AttackPrefix,
								"Attack",
								this.SithPrefix,
								"_0",
								this.SithCombo.ToString()
							})].time >= this.SithHardSpawnTime1[this.SithCombo] && this.SithAttacks == 0)
							{
								UnityEngine.Object.Instantiate<GameObject>(this.SithHitbox, base.transform.position + base.transform.forward * 1.5f + base.transform.up, base.transform.rotation).GetComponent<SithBeamScript>().Damage = 20f;
								this.SithAttacks++;
								if (this.SithCombo < 2)
								{
									UnityEngine.Object.Instantiate<GameObject>(this.GroundImpact, base.transform.position + base.transform.forward * 1.5f, base.transform.rotation).transform.localScale = new Vector3(2f, 2f, 2f);
								}
							}
						}
						else if (this.SithAttacks == 0)
						{
							if (this.CharacterAnimation[string.Concat(new string[]
							{
								"f02_",
								this.AttackPrefix,
								"Attack",
								this.SithPrefix,
								"_0",
								this.SithCombo.ToString()
							})].time >= this.SithHardSpawnTime1[this.SithCombo])
							{
								UnityEngine.Object.Instantiate<GameObject>(this.SithHardHitbox, base.transform.position + base.transform.forward * 1f + base.transform.up, base.transform.rotation);
								this.SithAttacks++;
							}
						}
						else if (this.SithAttacks == 1)
						{
							if (this.CharacterAnimation[string.Concat(new string[]
							{
								"f02_",
								this.AttackPrefix,
								"Attack",
								this.SithPrefix,
								"_0",
								this.SithCombo.ToString()
							})].time >= this.SithHardSpawnTime2[this.SithCombo])
							{
								UnityEngine.Object.Instantiate<GameObject>(this.SithHardHitbox, base.transform.position + base.transform.forward * 1f + base.transform.up, base.transform.rotation);
								this.SithAttacks++;
							}
						}
						else if (this.SithAttacks == 2 && this.SithCombo == 1 && this.CharacterAnimation[string.Concat(new string[]
						{
							"f02_",
							this.AttackPrefix,
							"Attack",
							this.SithPrefix,
							"_0",
							this.SithCombo.ToString()
						})].time >= 0.93333334f)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.SithHardHitbox, base.transform.position + base.transform.forward * 1f + base.transform.up, base.transform.rotation);
							this.SithAttacks++;
						}
						this.SithSoundCheck();
						if (this.CharacterAnimation[string.Concat(new string[]
						{
							"f02_",
							this.AttackPrefix,
							"Attack",
							this.SithPrefix,
							"_0",
							this.SithCombo.ToString()
						})].time >= this.CharacterAnimation[string.Concat(new string[]
						{
							"f02_",
							this.AttackPrefix,
							"Attack",
							this.SithPrefix,
							"_0",
							this.SithCombo.ToString()
						})].length)
						{
							if (this.SithCombo < this.SithComboLength)
							{
								this.SithCombo++;
								this.SithSounds = 0;
								this.SithAttacks = 0;
								this.CharacterAnimation.Play(string.Concat(new string[]
								{
									"f02_",
									this.AttackPrefix,
									"Attack",
									this.SithPrefix,
									"_0",
									this.SithCombo.ToString()
								}));
							}
							else
							{
								this.CharacterAnimation.Play(string.Concat(new string[]
								{
									"f02_",
									this.AttackPrefix,
									"Recover",
									this.SithPrefix,
									"_0",
									this.SithCombo.ToString()
								}));
								if (!this.Pod.activeInHierarchy)
								{
									this.CharacterAnimation[string.Concat(new string[]
									{
										"f02_",
										this.AttackPrefix,
										"Recover",
										this.SithPrefix,
										"_0",
										this.SithCombo.ToString()
									})].speed = 2f;
								}
								else
								{
									this.CharacterAnimation[string.Concat(new string[]
									{
										"f02_",
										this.AttackPrefix,
										"Recover",
										this.SithPrefix,
										"_0",
										this.SithCombo.ToString()
									})].speed = 0.5f;
								}
								this.SithRecovering = true;
							}
						}
						else
						{
							if (Input.GetButtonDown("X") && this.SithComboLength < this.SithCombo + 1 && this.SithComboLength < 2)
							{
								this.SithComboLength++;
							}
							if (Input.GetButtonDown("Y") && this.SithComboLength < this.SithCombo + 1 && this.SithComboLength < 2)
							{
								this.SithComboLength++;
							}
						}
					}
					else if (this.CharacterAnimation[string.Concat(new string[]
					{
						"f02_",
						this.AttackPrefix,
						"Recover",
						this.SithPrefix,
						"_0",
						this.SithCombo.ToString()
					})].time >= this.CharacterAnimation[string.Concat(new string[]
					{
						"f02_",
						this.AttackPrefix,
						"Recover",
						this.SithPrefix,
						"_0",
						this.SithCombo.ToString()
					})].length || this.h + this.v != 0f)
					{
						if (this.SithPrefix == "")
						{
							this.LightSwordParticles.Play();
						}
						else
						{
							this.HeavySwordParticles.Play();
						}
						this.HeavySword.GetComponent<WeaponTrail>().enabled = false;
						this.LightSword.GetComponent<WeaponTrail>().enabled = false;
						this.SithRecovering = false;
						this.SithAttacking = false;
						this.SithComboLength = 0;
						this.SithAttacks = 0;
						this.SithSounds = 0;
						this.SithCombo = 0;
						this.CanMove = true;
					}
				}
				if (this.Eating)
				{
					if (Vector3.Distance(base.transform.position, this.TargetStudent.transform.position) > 0.5f)
					{
						base.transform.Translate(Vector3.forward * Time.deltaTime);
					}
					this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					if (this.CharacterAnimation["f02_sixEat_00"].time > this.BloodTimes[this.EatPhase])
					{
						UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.Mouth.position, Quaternion.identity).GetComponent<RandomStabScript>().Biting = true;
						this.Bloodiness += 20f;
						this.EatPhase++;
					}
					if (this.CharacterAnimation["f02_sixEat_00"].time >= this.CharacterAnimation["f02_sixEat_00"].length)
					{
						if (!this.Kagune[0].activeInHierarchy && this.Hunger < 5)
						{
							this.CharacterAnimation["f02_sixRun_00"].speed += 0.1f;
							this.RunSpeed += 1f;
							this.Hunger++;
							if (this.Hunger == 5)
							{
								this.RisingSmoke.SetActive(true);
								this.RunAnim = "f02_sixFastRun_00";
							}
						}
						Debug.Log("Finished eating.");
						this.FollowHips = false;
						this.Attacking = false;
						this.CanMove = true;
						this.Eating = false;
						this.EatPhase = 0;
					}
				}
				if (this.Snapping)
				{
					if (this.SnapPhase == 0)
					{
						if (this.Gazing)
						{
							if (this.CharacterAnimation["f02_gazerSnap_00"].time >= 0.8f)
							{
								AudioSource.PlayClipAtPoint(this.FingerSnap, base.transform.position + Vector3.up);
								this.GazerEyes.ChangeEffect();
								this.SnapPhase++;
							}
						}
						else if (this.WitchMode)
						{
							if (this.CharacterAnimation["f02_fingerSnap_00"].time >= 1f)
							{
								AudioSource.PlayClipAtPoint(this.FingerSnap, base.transform.position + Vector3.up);
								UnityEngine.Object.Instantiate<GameObject>(this.KnifeArray, base.transform.position, base.transform.rotation).GetComponent<KnifeArrayScript>().GlobalKnifeArray = this.GlobalKnifeArray;
								this.SnapPhase++;
							}
						}
						else if (this.ShotsFired < 1)
						{
							if (this.CharacterAnimation["f02_shipGirlSnap_00"].time >= 1f)
							{
								UnityEngine.Object.Instantiate<GameObject>(this.Shell, this.Guns[1].position, base.transform.rotation);
								this.ShotsFired++;
							}
						}
						else if (this.ShotsFired < 2)
						{
							if (this.CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.2f)
							{
								UnityEngine.Object.Instantiate<GameObject>(this.Shell, this.Guns[2].position, base.transform.rotation);
								this.ShotsFired++;
							}
						}
						else if (this.ShotsFired < 3)
						{
							if (this.CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.4f)
							{
								UnityEngine.Object.Instantiate<GameObject>(this.Shell, this.Guns[3].position, base.transform.rotation);
								this.ShotsFired++;
							}
						}
						else if (this.ShotsFired < 4 && this.CharacterAnimation["f02_shipGirlSnap_00"].time >= 1.6f)
						{
							UnityEngine.Object.Instantiate<GameObject>(this.Shell, this.Guns[4].position, base.transform.rotation);
							this.ShotsFired++;
							this.SnapPhase++;
						}
					}
					else if (this.Gazing)
					{
						if (this.CharacterAnimation["f02_gazerSnap_00"].time >= this.CharacterAnimation["f02_gazerSnap_00"].length)
						{
							this.Snapping = false;
							this.CanMove = true;
							this.SnapPhase = 0;
						}
					}
					else if (this.WitchMode)
					{
						if (this.CharacterAnimation["f02_fingerSnap_00"].time >= this.CharacterAnimation["f02_fingerSnap_00"].length)
						{
							this.CharacterAnimation.Stop("f02_fingerSnap_00");
							this.Snapping = false;
							this.CanMove = true;
							this.SnapPhase = 0;
						}
					}
					else if (this.CharacterAnimation["f02_shipGirlSnap_00"].time >= this.CharacterAnimation["f02_shipGirlSnap_00"].length)
					{
						this.Snapping = false;
						this.CanMove = true;
						this.ShotsFired = 0;
						this.SnapPhase = 0;
					}
				}
				if (this.GazeAttacking)
				{
					if (this.TargetStudent != null)
					{
						this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
						base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
					}
					if (this.SnapPhase == 0)
					{
						if (this.CharacterAnimation["f02_gazerPoint_00"].time >= 1f)
						{
							AudioSource.PlayClipAtPoint(this.Zap, base.transform.position + Vector3.up);
							this.GazerEyes.Attack();
							this.SnapPhase++;
						}
					}
					else if (this.CharacterAnimation["f02_gazerPoint_00"].time >= this.CharacterAnimation["f02_gazerPoint_00"].length)
					{
						this.GazerEyes.Attacking = false;
						this.GazeAttacking = false;
						this.CanMove = true;
						this.SnapPhase = 0;
					}
				}
				if (this.Finisher)
				{
					if (this.CharacterAnimation["f02_banchoFinisher_00"].time >= this.CharacterAnimation["f02_banchoFinisher_00"].length)
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Finisher = false;
						this.CanMove = true;
					}
					else if (this.CharacterAnimation["f02_banchoFinisher_00"].time >= 1.6666666f)
					{
						this.BanchoFinisher.MyCollider.enabled = false;
					}
					else if (this.CharacterAnimation["f02_banchoFinisher_00"].time >= 0.8333333f)
					{
						this.BanchoFinisher.MyCollider.enabled = true;
					}
				}
				if (this.ShootingBeam)
				{
					this.CharacterAnimation.CrossFade("f02_LoveLoveBeam_00");
					if (this.CharacterAnimation["f02_LoveLoveBeam_00"].time >= 1.5f && this.BeamPhase == 0)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.LoveLoveBeam, base.transform.position, base.transform.rotation);
						this.BeamPhase++;
					}
					if (this.CharacterAnimation["f02_LoveLoveBeam_00"].time >= this.CharacterAnimation["f02_LoveLoveBeam_00"].length - 1f)
					{
						this.ShootingBeam = false;
						this.YandereTimer = 0f;
						this.CanMove = true;
						this.BeamPhase = 0;
					}
				}
				if (this.WritingName)
				{
					this.CharacterAnimation.CrossFade("f02_dramaticWriting_00");
					if (this.CharacterAnimation["f02_dramaticWriting_00"].time == 0f)
					{
						AudioSource.PlayClipAtPoint(this.DramaticWriting, base.transform.position);
					}
					if (this.CharacterAnimation["f02_dramaticWriting_00"].time >= 5f && this.StudentManager.NoteWindow.TargetStudent > 0)
					{
						this.StudentManager.Students[this.StudentManager.NoteWindow.TargetStudent].Fate = this.StudentManager.NoteWindow.MeetID;
						this.StudentManager.Students[this.StudentManager.NoteWindow.TargetStudent].TimeOfDeath = this.StudentManager.NoteWindow.TimeID;
						this.StudentManager.NoteWindow.TargetStudent = 0;
					}
					if (this.CharacterAnimation["f02_dramaticWriting_00"].time >= this.CharacterAnimation["f02_dramaticWriting_00"].length)
					{
						this.CharacterAnimation[this.CarryAnims[10]].weight = 1f;
						this.CharacterAnimation["f02_dramaticWriting_00"].time = 0f;
						this.CharacterAnimation.Stop("f02_dramaticWriting_00");
						this.WritingName = false;
						this.CanMove = true;
					}
				}
				if (this.StoppingTime)
				{
					this.CharacterAnimation.CrossFade("f02_summonStand_00");
					if (this.CharacterAnimation["f02_summonStand_00"].time >= 1f)
					{
						if (this.Freezing)
						{
							if (!this.InvertSphere.gameObject.activeInHierarchy)
							{
								if (this.MyAudio.clip != this.ClockStop)
								{
									this.MyAudio.clip = this.ClockStop;
									this.MyAudio.volume = 1f;
									this.MyAudio.Play();
								}
								this.InvertSphere.gameObject.SetActive(true);
								this.PlayerOnlyCamera.SetActive(true);
								this.StudentManager.TimeFreeze();
							}
							this.InvertSphere.transform.localScale = Vector3.MoveTowards(this.InvertSphere.transform.localScale, new Vector3(0.2375f, 0.2375f, 0f), Time.deltaTime);
							this.MyAudio.volume = 1f;
							this.Jukebox.Ebola.pitch = Mathf.MoveTowards(this.Jukebox.Ebola.pitch, 0.2f, Time.deltaTime);
						}
						else
						{
							if (this.MyAudio.clip != this.ClockStart)
							{
								this.MyAudio.clip = this.ClockStart;
								this.MyAudio.volume = 1f;
								this.MyAudio.Play();
								this.StudentManager.TimeUnfreeze();
							}
							this.InvertSphere.transform.localScale = Vector3.MoveTowards(this.InvertSphere.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime);
							this.MyAudio.volume = 1f;
							this.Jukebox.Ebola.pitch = Mathf.MoveTowards(this.Jukebox.Ebola.pitch, 1f, Time.deltaTime);
							this.GlobalKnifeArray.ActivateKnives();
						}
					}
					if (this.CharacterAnimation["f02_summonStand_00"].time >= this.CharacterAnimation["f02_summonStand_00"].length)
					{
						this.StoppingTime = false;
						this.CanMove = true;
						this.InvertSphere.gameObject.SetActive(this.Freezing);
						this.PlayerOnlyCamera.SetActive(this.Freezing);
					}
				}
				if (this.Swiping)
				{
					if (this.CharacterAnimation["f02_sithAttack_0" + this.SwipeID.ToString()].time >= this.CharacterAnimation["f02_sithAttack_0" + this.SwipeID.ToString()].length * 0.9f)
					{
						this.Swiping = false;
						this.CanMove = true;
						this.Finisher = false;
						return;
					}
					if (this.CharacterAnimation["f02_sithAttack_0" + this.SwipeID.ToString()].time >= this.CharacterAnimation["f02_sithAttack_0" + this.SwipeID.ToString()].length * 0.25f && !this.Finisher)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.DemonSlash, base.transform.position + base.transform.up + base.transform.forward * 2f, Quaternion.identity);
						this.Finisher = true;
					}
				}
			}
		}
	}

	// Token: 0x06001FD6 RID: 8150 RVA: 0x001CD1FC File Offset: 0x001CB3FC
	private void UpdatePoisoning()
	{
		if (this.Poisoning)
		{
			if (this.PoisonSpot != null)
			{
				this.MoveTowardsTarget(this.PoisonSpot.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.PoisonSpot.rotation, Time.deltaTime * 10f);
			}
			else
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetBento.transform.position.x, base.transform.position.y, this.TargetBento.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.TargetBento.PoisonSpot.position);
			}
			if (this.CharacterAnimation["f02_poisoning_00"].time >= this.CharacterAnimation["f02_poisoning_00"].length)
			{
				this.CharacterAnimation["f02_poisoning_00"].speed = 1f;
				this.Poisons[this.PoisonType].SetActive(false);
				this.PoisonSpot = null;
				this.Poisoning = false;
				this.CanMove = true;
				return;
			}
			if (this.CharacterAnimation["f02_poisoning_00"].time >= 5.25f)
			{
				this.Poisons[this.PoisonType].SetActive(false);
				return;
			}
			if ((double)this.CharacterAnimation["f02_poisoning_00"].time >= 0.75)
			{
				this.Poisons[this.PoisonType].SetActive(true);
			}
		}
	}

	// Token: 0x06001FD7 RID: 8151 RVA: 0x001CD3D8 File Offset: 0x001CB5D8
	private void UpdateEffects()
	{
		if (!this.Attacking && !this.DelinquentFighting && !this.Lost && this.CanMove)
		{
			if (Vector3.Distance(base.transform.position, this.Senpai.position) < this.SenpaiThreshold)
			{
				if (!this.Talking)
				{
					if (!this.NearSenpai && this.StudentManager.Students[1].Pathfinding.speed < 7.5f)
					{
						this.StudentManager.TutorialWindow.ShowSenpaiMessage = true;
						this.NearSenpai = true;
					}
					if (this.Laughing)
					{
						Debug.Log("Yandere-chan was laughing, and is being told to stop laughing because UpdateEffects() was called.");
						this.StopLaughing();
						if (this.Pursuer != null)
						{
							this.CanMove = false;
						}
					}
					this.Stance.Current = StanceType.Standing;
					this.YandereVision = false;
					this.Mopping = false;
					this.Uncrouch();
					this.YandereTimer = 0f;
					this.EmptyHands();
					if (this.Aiming)
					{
						this.StopAiming();
					}
				}
			}
			else
			{
				this.NearSenpai = false;
			}
		}
		if (this.NearSenpai && !this.Noticed)
		{
			this.SenpaiFilter.enabled = true;
			this.SenpaiFilter.FadeFX = Mathf.Lerp(this.SenpaiFilter.FadeFX, 1f, Time.deltaTime * 10f);
			this.SenpaiFade = Mathf.Lerp(this.SenpaiFade, 0f, Time.deltaTime * 10f);
			this.SenpaiTint = 1f - this.SenpaiFade / 100f;
			bool attacking = this.Attacking;
			this.SelectGrayscale.desaturation = Mathf.Lerp(this.SelectGrayscale.desaturation, 0f, Time.deltaTime * 10f);
			this.HeartBeat.volume = this.SenpaiTint;
			this.Sanity += Time.deltaTime * 10f;
			this.SenpaiTimer += Time.deltaTime;
			this.BeatTimer += Time.deltaTime;
			if (this.BeatTimer > 60f / (float)this.HeartRate.BeatsPerMinute)
			{
				GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
				this.VibrationCheck = true;
				this.VibrationTimer = 0.1f;
				this.BeatTimer = 0f;
			}
			if (this.SenpaiTimer > 10f && this.Creepiness < 5)
			{
				this.SenpaiTimer = 0f;
				this.Creepiness++;
			}
		}
		else if (this.SenpaiFade < 99f)
		{
			this.SenpaiFilter.FadeFX = Mathf.Lerp(this.SenpaiFilter.FadeFX, 0f, Time.deltaTime * 10f);
			this.SenpaiFade = Mathf.Lerp(this.SenpaiFade, 100f, Time.deltaTime * 10f);
			this.SenpaiTint = this.SenpaiFade / 100f;
			this.SelectGrayscale.desaturation = Mathf.Lerp(this.SelectGrayscale.desaturation, this.GreyTarget, Time.deltaTime * 10f);
			this.CharacterAnimation["f02_shy_00"].weight = 1f - this.SenpaiTint;
			for (int i = 1; i < 6; i++)
			{
				this.CharacterAnimation[this.CreepyIdles[i]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyIdles[i]].weight, 0f, Time.deltaTime * 10f);
				this.CharacterAnimation[this.CreepyWalks[i]].weight = Mathf.MoveTowards(this.CharacterAnimation[this.CreepyWalks[i]].weight, 0f, Time.deltaTime * 10f);
			}
			this.HeartBeat.volume = 1f - this.SenpaiTint;
		}
		else if (this.SenpaiFade < 100f)
		{
			this.ResetSenpaiEffects();
		}
		if (this.YandereVision)
		{
			if (!this.HighlightingR.enabled)
			{
				this.YandereFilter.enabled = true;
				this.HighlightingR.enabled = true;
				this.HighlightingB.enabled = true;
			}
			if (this.Stance.Current == StanceType.Standing)
			{
				if (this.YandereVisionPanel.alpha == 0f)
				{
					if (!this.StudentManager.Eighties)
					{
						this.Phone.transform.localPosition = new Vector3(-0.02f, -0.005f, 0.03f);
						this.Phone.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
					}
					else
					{
						this.Phone.transform.localPosition = new Vector3(-0.015f, -0.006f, 0.015f);
						this.Phone.transform.localEulerAngles = new Vector3(-90f, -165f, 0f);
					}
					this.RightRedEye.material.color = new Color(1f, 1f, 1f, 1f);
					this.LeftRedEye.material.color = new Color(1f, 1f, 1f, 1f);
					this.RightYandereEye.material.color = new Color(1f, 1f, 1f, 0f);
					this.LeftYandereEye.material.color = new Color(1f, 1f, 1f, 0f);
					if (this.Inventory.SenpaiShots > 0 || this.StudentManager.MissionMode || this.StudentManager.Eighties)
					{
						this.SenpaiShotLabel.text = "Speed Up Time";
					}
					else
					{
						this.SenpaiShotLabel.text = "Speed Up Time (Requires Photo of Senpai)";
					}
				}
				this.YandereVisionPanel.alpha = Mathf.MoveTowards(this.YandereVisionPanel.alpha, 1f, Time.unscaledDeltaTime * 10f);
			}
			else
			{
				this.YandereVisionPanel.alpha = Mathf.MoveTowards(this.YandereVisionPanel.alpha, 0f, Time.unscaledDeltaTime * 10f);
				this.SenpaiGazing = false;
			}
			bool flag = this.Inventory.SenpaiShots > 0 || this.StudentManager.MissionMode || this.StudentManager.Eighties;
			if (this.YandereVisionPanel.alpha == 1f && flag && this.PickUp == null && !this.Armed && !this.Carrying && !this.Dragging)
			{
				this.SenpaiShotLabel.text = "Speed Up Time";
				if (Input.GetButtonDown("A"))
				{
					this.SenpaiGazing = !this.SenpaiGazing;
				}
			}
			else
			{
				if (this.PickUp != null || this.Armed || this.Carrying || this.Dragging)
				{
					this.SenpaiShotLabel.text = "Speed Up Time (Empty Hands First)";
				}
				this.SenpaiGazing = false;
			}
			if (this.SenpaiGazing)
			{
				this.Phone.SetActive(true);
				this.CharacterAnimation["f02_phonePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_phonePose_00"].weight, 1f, Time.unscaledDeltaTime * 10f);
				Time.timeScale = Mathf.Lerp(Time.timeScale, 2f, Time.unscaledDeltaTime * 10f);
			}
			else
			{
				this.Phone.SetActive(false);
				this.CharacterAnimation["f02_phonePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_phonePose_00"].weight, 0f, Time.unscaledDeltaTime * 10f);
				Time.timeScale = Mathf.Lerp(Time.timeScale, 0.5f, Time.unscaledDeltaTime * 10f);
			}
			this.YandereFilter.FadeFX = Mathf.Lerp(this.YandereFilter.FadeFX, 1f, Time.unscaledDeltaTime * 10f);
			this.YandereFade = Mathf.Lerp(this.YandereFade, 0f, Time.unscaledDeltaTime * 10f);
			this.YandereTint = 1f - this.YandereFade / 100f;
			this.CameraEffects.UpdateVignette(this.YandereFilter.FadeFX);
			if (this.StudentManager.Tag.Target != null)
			{
				this.StudentManager.Tag.Sprite.color = new Color(1f, 0f, 0f, Mathf.Lerp(this.StudentManager.Tag.Sprite.color.a, 1f, Time.unscaledDeltaTime * 10f));
			}
			if (this.StudentManager.Students[this.StudentManager.RivalID] != null)
			{
				this.StudentManager.RedString.gameObject.SetActive(true);
			}
			if (this.CanMove && !this.Carrying && !this.Dragging && this.YandereVisionPanel.alpha == 1f && this.SneakShotLabel.alpha == 1f && Input.GetButtonDown("B"))
			{
				this.YandereVision = false;
				this.SneakingShot = true;
				this.CanMove = false;
				this.Lewd = true;
			}
			if (this.Chased)
			{
				this.ResetYandereEffects();
				return;
			}
		}
		else
		{
			if (this.HighlightingR.enabled)
			{
				this.HighlightingR.enabled = false;
				this.HighlightingB.enabled = false;
			}
			if (this.YandereFade < 99f)
			{
				if (!this.Aiming)
				{
					Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.unscaledDeltaTime * 10f);
				}
				this.Phone.SetActive(false);
				this.CharacterAnimation["f02_phonePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_phonePose_00"].weight, 0f, Time.unscaledDeltaTime * 10f);
				this.YandereVisionPanel.alpha = Mathf.Lerp(this.YandereVisionPanel.alpha, 0f, Time.unscaledDeltaTime * 10f);
				this.YandereFilter.FadeFX = Mathf.Lerp(this.YandereFilter.FadeFX, 0f, Time.unscaledDeltaTime * 10f);
				this.YandereFade = Mathf.Lerp(this.YandereFade, 100f, Time.unscaledDeltaTime * 10f);
				this.YandereTint = this.YandereFade / 100f;
				this.CameraEffects.UpdateVignette(1f - this.Sanity * 0.01f);
				this.StudentManager.Tag.Sprite.color = new Color(1f, 0f, 0f, Mathf.Lerp(this.StudentManager.Tag.Sprite.color.a, 0f, Time.unscaledDeltaTime * 10f));
				this.StudentManager.RedString.gameObject.SetActive(false);
				this.RightRedEye.material.color = new Color(this.RightRedEye.material.color.r, this.RightRedEye.material.color.g, this.RightRedEye.material.color.b, 1f - this.YandereFade / 100f);
				this.LeftRedEye.material.color = new Color(this.LeftRedEye.material.color.r, this.LeftRedEye.material.color.g, this.LeftRedEye.material.color.b, 1f - this.YandereFade / 100f);
				this.RightYandereEye.material.color = new Color(this.RightYandereEye.material.color.r, this.YandereFade / 100f, this.YandereFade / 100f, this.RightYandereEye.material.color.a);
				this.LeftYandereEye.material.color = new Color(this.LeftYandereEye.material.color.r, this.YandereFade / 100f, this.YandereFade / 100f, this.LeftYandereEye.material.color.a);
				return;
			}
			if (this.YandereFade < 100f)
			{
				this.ResetYandereEffects();
			}
		}
	}

	// Token: 0x06001FD8 RID: 8152 RVA: 0x001CE0D8 File Offset: 0x001CC2D8
	private void UpdateTalking()
	{
		if (this.Talking)
		{
			if (this.TargetStudent != null)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				if (Vector3.Distance(base.transform.position, this.TargetStudent.transform.position) < 0.75f)
				{
					this.MyController.Move(base.transform.forward * Time.deltaTime * -1f);
					this.CameraEffects.UpdateDOF(Vector3.Distance(base.transform.position, this.TargetStudent.transform.position) + 0.1f);
				}
			}
			if (this.Interaction == YandereInteractionType.Idle)
			{
				if (this.TargetStudent != null && !this.TargetStudent.Counselor)
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
					return;
				}
			}
			else
			{
				if (this.Interaction == YandereInteractionType.Apologizing)
				{
					if (this.TalkTimer == 10f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_00");
						if (this.TargetStudent.Witnessed == StudentWitnessType.Insanity || this.TargetStudent.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity || this.TargetStudent.Witnessed == StudentWitnessType.WeaponAndInsanity || this.TargetStudent.Witnessed == StudentWitnessType.BloodAndInsanity)
						{
							this.Subtitle.UpdateLabel(SubtitleType.InsanityApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.WeaponAndBlood)
						{
							this.Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Weapon)
						{
							this.Subtitle.UpdateLabel(SubtitleType.WeaponApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Blood)
						{
							this.Subtitle.UpdateLabel(SubtitleType.BloodApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Lewd)
						{
							this.Subtitle.UpdateLabel(SubtitleType.LewdApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Accident)
						{
							this.Subtitle.UpdateLabel(SubtitleType.AccidentApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Suspicious)
						{
							this.Subtitle.UpdateLabel(SubtitleType.SuspiciousApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Eavesdropping)
						{
							this.Subtitle.UpdateLabel(SubtitleType.EavesdropApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Theft)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TheftApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Violence)
						{
							this.Subtitle.UpdateLabel(SubtitleType.ViolenceApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Pickpocketing)
						{
							this.Subtitle.UpdateLabel(SubtitleType.PickpocketApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.CleaningItem)
						{
							this.Subtitle.UpdateLabel(SubtitleType.CleaningApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Poisoning)
						{
							this.Subtitle.UpdateLabel(SubtitleType.PoisonApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.HoldingBloodyClothing)
						{
							this.Subtitle.UpdateLabel(SubtitleType.HoldingBloodyClothingApology, 0, 10f);
						}
						else if (this.TargetStudent.Witnessed == StudentWitnessType.Tutorial)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TutorialApology, 0, 10f);
						}
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_00"].time >= this.CharacterAnimation["f02_greet_00"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.Forgiving;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.Compliment)
				{
					if (this.TalkTimer == 5f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						this.Subtitle.CustomText = this.TargetStudent.DialogueWheel.TopicInterface.Statement;
						this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.ReceivingCompliment;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.Gossip)
				{
					if (this.TalkTimer == 5f)
					{
						this.CharacterAnimation.CrossFade("f02_lookdown_00");
						this.Subtitle.CustomText = this.TargetStudent.DialogueWheel.TopicInterface.Statement;
						this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_lookdown_00"].time >= this.CharacterAnimation["f02_lookdown_00"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.Gossiping;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.Bye)
				{
					if (this.TalkTimer == 2f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_00");
						this.Subtitle.UpdateLabel(SubtitleType.PlayerFarewell, 0, 2f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_00"].time >= this.CharacterAnimation["f02_greet_00"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.Bye;
							this.TargetStudent.TalkTimer = 2f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.FollowMe)
				{
					int num = 0;
					if (this.Club == ClubType.Delinquent)
					{
						num++;
					}
					if (this.TalkTimer == 3f)
					{
						if (this.Club == ClubType.Delinquent)
						{
							this.TalkAnim = "f02_delinquentGesture_01";
						}
						else
						{
							this.TalkAnim = "f02_greet_01";
						}
						this.CharacterAnimation.CrossFade(this.TalkAnim);
						this.Subtitle.UpdateLabel(SubtitleType.PlayerFollow, num, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation[this.TalkAnim].time >= this.CharacterAnimation[this.TalkAnim].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.FollowingPlayer;
							this.TargetStudent.TalkTimer = 2f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.GoAway)
				{
					int num2 = 0;
					if (this.Club == ClubType.Delinquent)
					{
						num2++;
					}
					if (this.TalkTimer == 3f)
					{
						if (this.Club == ClubType.Delinquent)
						{
							this.TalkAnim = "f02_delinquentGesture_01";
						}
						else
						{
							this.TalkAnim = "f02_lookdown_00";
						}
						this.CharacterAnimation.CrossFade(this.TalkAnim);
						this.Subtitle.UpdateLabel(SubtitleType.PlayerLeave, num2, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation[this.TalkAnim].time >= this.CharacterAnimation[this.TalkAnim].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.GoingAway;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.DistractThem)
				{
					int num3 = 0;
					if (this.Club == ClubType.Delinquent || this.StudentManager.Eighties)
					{
						num3++;
					}
					if (this.TalkTimer == 3f)
					{
						if (this.Club == ClubType.Delinquent)
						{
							this.TalkAnim = "f02_delinquentGesture_01";
						}
						else
						{
							this.TalkAnim = "f02_lookdown_00";
						}
						this.CharacterAnimation.CrossFade(this.TalkAnim);
						this.Subtitle.UpdateLabel(SubtitleType.PlayerDistract, num3, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation[this.TalkAnim].time >= this.CharacterAnimation[this.TalkAnim].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.DistractingTarget;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.NamingCrush)
				{
					if (this.TalkTimer == 3f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 0, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.NamingCrush;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.ChangingAppearance)
				{
					if (this.TalkTimer == 3f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 2, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.ChangingAppearance;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.Court)
				{
					if (this.TalkTimer == 5f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						if (!this.TargetStudent.Male)
						{
							this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 3, 5f);
						}
						else
						{
							this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 4, 5f);
						}
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.Court;
							this.TargetStudent.TalkTimer = 3f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.Advice)
				{
					if (this.TalkTimer == 5f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 5, 5f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.Advice;
							this.TargetStudent.TalkTimer = 5f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.TaskInquiry)
				{
					if (this.TalkTimer == 3f || this.TalkTimer == 5f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						if (this.TargetStudent.Club == ClubType.Bully)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TaskInquiry, 0, 5f);
						}
						else if (this.TargetStudent.StudentID == 10)
						{
							this.Subtitle.UpdateLabel(SubtitleType.TaskInquiry, 6, 5f);
						}
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							Debug.Log("Telling student to respond to task inquiry.");
							this.TargetStudent.Interaction = StudentInteractionType.TaskInquiry;
							this.TargetStudent.TalkTimer = 10f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.GivingSnack)
				{
					if (this.TalkTimer == 3f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel(SubtitleType.OfferSnack, 0, 3f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.TakingSnack;
							this.TargetStudent.TalkTimer = 5f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.AskingForHelp)
				{
					if (this.TalkTimer == 5f)
					{
						this.CharacterAnimation.CrossFade(this.IdleAnim);
						this.Subtitle.UpdateLabel(SubtitleType.AskForHelp, 0, 5f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.GivingHelp;
							this.TargetStudent.TalkTimer = 4f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
					return;
				}
				if (this.Interaction == YandereInteractionType.SendingToLocker)
				{
					if (this.TalkTimer == 5f)
					{
						this.CharacterAnimation.CrossFade("f02_greet_01");
						this.Subtitle.UpdateLabel(SubtitleType.SendToLocker, 0, 5f);
					}
					else
					{
						if (Input.GetButtonDown("A"))
						{
							this.TalkTimer = 0f;
						}
						if (this.TalkTimer <= 0f)
						{
							this.TargetStudent.Interaction = StudentInteractionType.SentToLocker;
							this.TargetStudent.TalkTimer = 5f;
							this.Interaction = YandereInteractionType.Idle;
						}
					}
					this.TalkTimer -= Time.deltaTime;
				}
			}
		}
	}

	// Token: 0x06001FD9 RID: 8153 RVA: 0x001CF274 File Offset: 0x001CD474
	private void UpdateAttacking()
	{
		if (this.Attacking)
		{
			if (this.TargetStudent != null)
			{
				this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
			}
			if (this.Drown)
			{
				this.MoveTowardsTarget(this.TargetStudent.transform.position + this.TargetStudent.transform.forward * -0.0001f);
				this.CharacterAnimation.CrossFade(this.DrownAnim);
				if (this.CharacterAnimation[this.DrownAnim].time > this.CharacterAnimation[this.DrownAnim].length)
				{
					this.TargetStudent.DeathType = DeathType.Drowning;
					this.Attacking = false;
					if (!this.Noticed)
					{
						this.CanMove = true;
					}
					this.Drown = false;
					this.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * this.Numbness;
					return;
				}
			}
			else if (this.RoofPush)
			{
				this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(this.Hips.position.x, base.transform.position.y + 1f, this.Hips.position.z), Time.deltaTime * 10f);
				this.MoveTowardsTarget(this.TargetStudent.transform.position - this.TargetStudent.transform.forward);
				this.CharacterAnimation.CrossFade("f02_roofPushA_00");
				if (this.CharacterAnimation["f02_roofPushA_00"].time > 4.3333335f)
				{
					if (this.Shoes[0].activeInHierarchy)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.ShoePair, base.transform.position + new Vector3(0f, 0.045f, 0f) + base.transform.forward * 1.6f, Quaternion.identity).transform.eulerAngles = base.transform.eulerAngles;
						this.Shoes[0].SetActive(false);
						this.Shoes[1].SetActive(false);
					}
				}
				else if (this.CharacterAnimation["f02_roofPushA_00"].time > 2.1666667f && this.TargetStudent.Schoolwear == 1 && !this.TargetStudent.ClubAttire && !this.Shoes[0].activeInHierarchy)
				{
					this.TargetStudent.RemoveShoes();
					this.Shoes[0].SetActive(true);
					this.Shoes[1].SetActive(true);
				}
				float num;
				if (this.TargetStudent.Schoolwear == 1 && !this.TargetStudent.ClubAttire)
				{
					num = this.CharacterAnimation["f02_roofPushA_00"].length;
				}
				else
				{
					num = 3.5f;
				}
				if (this.CharacterAnimation["f02_roofPushA_00"].time > num)
				{
					this.CameraTarget.localPosition = new Vector3(0f, 1f, 0f);
					this.TargetStudent.DeathType = DeathType.Falling;
					this.SplashCamera.transform.parent = null;
					this.Attacking = false;
					this.RoofPush = false;
					this.CanMove = true;
					this.Sanity -= 20f * this.Numbness;
				}
				if (Input.GetButtonDown("B"))
				{
					this.SplashCamera.transform.parent = base.transform;
					this.SplashCamera.transform.localPosition = new Vector3(2f, -10.65f, 4.775f);
					this.SplashCamera.transform.localEulerAngles = new Vector3(0f, -135f, 0f);
					this.SplashCamera.Show = true;
					this.SplashCamera.MyCamera.enabled = true;
					return;
				}
			}
			else
			{
				if (this.TargetStudent.Teacher)
				{
					this.CharacterAnimation.CrossFade("f02_teacherCounterA_00");
					if (this.EquippedWeapon != null)
					{
						this.EquippedWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
					}
					this.Character.transform.position = new Vector3(this.Character.transform.position.x, this.TargetStudent.transform.position.y, this.Character.transform.position.z);
					return;
				}
				if (!this.SanityBased)
				{
					if (this.EquippedWeapon.WeaponID == 27)
					{
						Debug.Log("Well, uh, we're killing with a garrote...");
						return;
					}
					if (this.EquippedWeapon.WeaponID == 11)
					{
						this.CharacterAnimation.CrossFade("CyborgNinja_Slash");
						if (this.CharacterAnimation["CyborgNinja_Slash"].time == 0f)
						{
							this.TargetStudent.CharacterAnimation[this.TargetStudent.PhoneAnim].weight = 0f;
							this.EquippedWeapon.gameObject.GetComponent<AudioSource>().Play();
						}
						if (this.CharacterAnimation["CyborgNinja_Slash"].time >= this.CharacterAnimation["CyborgNinja_Slash"].length)
						{
							this.Bloodiness += 20f;
							this.StainWeapon();
							this.CharacterAnimation["CyborgNinja_Slash"].time = 0f;
							this.CharacterAnimation.Stop("CyborgNinja_Slash");
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.Attacking = false;
							if (!this.Noticed)
							{
								this.CanMove = true;
								return;
							}
							this.EquippedWeapon.Drop();
							return;
						}
					}
					else if (this.EquippedWeapon.WeaponID == 7)
					{
						this.CharacterAnimation.CrossFade("f02_buzzSawKill_A_00");
						if (this.CharacterAnimation["f02_buzzSawKill_A_00"].time == 0f)
						{
							this.TargetStudent.CharacterAnimation[this.TargetStudent.PhoneAnim].weight = 0f;
							this.EquippedWeapon.gameObject.GetComponent<AudioSource>().Play();
						}
						if (this.AttackPhase == 1)
						{
							if (this.CharacterAnimation["f02_buzzSawKill_A_00"].time > 0.33333334f)
							{
								this.TargetStudent.LiquidProjector.enabled = true;
								this.EquippedWeapon.Effect();
								this.StainWeapon();
								this.TargetStudent.LiquidProjector.material.mainTexture = this.BloodTextures[1];
								this.Bloodiness += 20f;
								this.AttackPhase++;
							}
						}
						else if (this.AttackPhase < 6 && this.CharacterAnimation["f02_buzzSawKill_A_00"].time > 0.33333334f * (float)this.AttackPhase)
						{
							this.TargetStudent.LiquidProjector.material.mainTexture = this.BloodTextures[this.AttackPhase];
							this.Bloodiness += 20f;
							this.AttackPhase++;
						}
						if (this.CharacterAnimation["f02_buzzSawKill_A_00"].time > this.CharacterAnimation["f02_buzzSawKill_A_00"].length)
						{
							if (this.TargetStudent == this.StudentManager.Reporter)
							{
								this.StudentManager.Reporter = null;
							}
							this.CharacterAnimation["f02_buzzSawKill_A_00"].time = 0f;
							this.CharacterAnimation.Stop("f02_buzzSawKill_A_00");
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.MyController.radius = 0.2f;
							this.Attacking = false;
							this.AttackPhase = 1;
							this.Sanity -= 20f * this.Numbness;
							this.TargetStudent.DeathType = DeathType.Weapon;
							this.TargetStudent.BecomeRagdoll();
							if (!this.Noticed)
							{
								this.CanMove = true;
								return;
							}
							this.EquippedWeapon.Drop();
							return;
						}
					}
					else if (!this.EquippedWeapon.Concealable)
					{
						if (this.AttackPhase == 1)
						{
							this.CharacterAnimation.CrossFade("f02_swingA_00");
							if (this.CharacterAnimation["f02_swingA_00"].time > this.CharacterAnimation["f02_swingA_00"].length * 0.3f)
							{
								if (this.TargetStudent == this.StudentManager.Reporter)
								{
									this.StudentManager.Reporter = null;
								}
								UnityEngine.Object.Destroy(this.TargetStudent.DeathScream);
								this.EquippedWeapon.Effect();
								this.AttackPhase = 2;
								this.Bloodiness += 20f;
								this.StainWeapon();
								this.Sanity -= 20f * this.Numbness;
								return;
							}
						}
						else if (this.CharacterAnimation["f02_swingA_00"].time >= this.CharacterAnimation["f02_swingA_00"].length * 0.9f)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							this.TargetStudent.DeathType = DeathType.Weapon;
							this.TargetStudent.BecomeRagdoll();
							this.MyController.radius = 0.2f;
							this.Attacking = false;
							this.AttackPhase = 1;
							this.AttackTimer = 0f;
							if (!this.Noticed)
							{
								this.CanMove = true;
								return;
							}
							this.EquippedWeapon.Drop();
							return;
						}
					}
					else if (this.AttackPhase == 1)
					{
						this.CharacterAnimation.CrossFade("f02_stab_00");
						if (this.CharacterAnimation["f02_stab_00"].time > this.CharacterAnimation["f02_stab_00"].length * 0.35f)
						{
							this.CharacterAnimation.CrossFade(this.IdleAnim);
							if (this.EquippedWeapon.Flaming)
							{
								this.Egg = true;
								this.TargetStudent.Combust();
							}
							else if (this.CanTranq && !this.TargetStudent.Male && this.TargetStudent.Club != ClubType.Council)
							{
								this.TargetStudent.Tranquil = true;
								this.CanTranq = false;
								this.Follower = null;
								this.Followers--;
							}
							else
							{
								this.TargetStudent.BloodSpray.SetActive(true);
								this.TargetStudent.DeathType = DeathType.Weapon;
								this.Bloodiness += 20f;
							}
							if (this.TargetStudent == this.StudentManager.Reporter)
							{
								this.StudentManager.Reporter = null;
							}
							AudioSource.PlayClipAtPoint(this.Stabs[UnityEngine.Random.Range(0, this.Stabs.Length)], base.transform.position + Vector3.up);
							this.AttackPhase = 2;
							this.Sanity -= 20f * this.Numbness;
							if (this.EquippedWeapon.WeaponID == 8)
							{
								this.TargetStudent.Ragdoll.Sacrifice = true;
								if (GameGlobals.Paranormal)
								{
									this.EquippedWeapon.Effect();
									return;
								}
							}
						}
					}
					else
					{
						this.AttackTimer += Time.deltaTime;
						if (this.AttackTimer > 0.3f)
						{
							if (!this.CanTranq)
							{
								this.StainWeapon();
							}
							this.MyController.radius = 0.2f;
							this.SanityBased = true;
							this.Attacking = false;
							this.AttackPhase = 1;
							this.AttackTimer = 0f;
							if (!this.Noticed)
							{
								this.CanMove = true;
								return;
							}
							this.EquippedWeapon.Drop();
						}
					}
				}
			}
		}
	}

	// Token: 0x06001FDA RID: 8154 RVA: 0x001CFEFC File Offset: 0x001CE0FC
	public void UpdateSlouch()
	{
		if (!this.FloppyHat.activeInHierarchy)
		{
			if (this.CanMove && !this.Attacking && !this.Dragging && this.PickUp == null && !this.Aiming && this.Stance.Current != StanceType.Crawling && !this.Possessed && !this.Carrying && !this.CirnoWings.activeInHierarchy && this.LaughIntensity < 16f)
			{
				this.CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_yanderePose_00"].weight, 1f - this.Sanity / 100f, Time.deltaTime * 10f);
				if (this.Hairstyle == 2 && this.Stance.Current == StanceType.Crouching)
				{
					this.Slouch = Mathf.Lerp(this.Slouch, 0f, Time.deltaTime * 20f);
					return;
				}
				this.Slouch = Mathf.Lerp(this.Slouch, 5f * (1f - this.Sanity / 100f), Time.deltaTime * 10f);
				return;
			}
			else
			{
				this.CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_yanderePose_00"].weight, 0f, Time.deltaTime * 10f);
				this.Slouch = Mathf.Lerp(this.Slouch, 0f, Time.deltaTime * 10f);
			}
		}
	}

	// Token: 0x06001FDB RID: 8155 RVA: 0x001D00B8 File Offset: 0x001CE2B8
	private void UpdateTwitch()
	{
		if (this.Sanity < 100f)
		{
			this.TwitchTimer += Time.deltaTime;
			if (this.TwitchTimer > this.NextTwitch)
			{
				this.Twitch = new Vector3((1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f), (1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f), (1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f));
				this.NextTwitch = UnityEngine.Random.Range(0f, 1f);
				this.TwitchTimer = 0f;
			}
			this.Twitch = Vector3.Lerp(this.Twitch, Vector3.zero, Time.deltaTime * 10f);
		}
	}

	// Token: 0x06001FDC RID: 8156 RVA: 0x001D01AC File Offset: 0x001CE3AC
	private void UpdateWarnings()
	{
		if (this.NearBodies > 0)
		{
			if (!this.CorpseWarning)
			{
				this.NotificationManager.DisplayNotification(NotificationType.Body);
				this.StudentManager.UpdateStudents(0);
				this.CorpseWarning = true;
			}
		}
		else if (this.CorpseWarning)
		{
			this.StudentManager.UpdateStudents(0);
			this.CorpseWarning = false;
		}
		if (this.Eavesdropping)
		{
			if (!this.EavesdropWarning)
			{
				this.NotificationManager.DisplayNotification(NotificationType.Eavesdropping);
				this.EavesdropWarning = true;
			}
		}
		else if (this.EavesdropWarning)
		{
			this.EavesdropWarning = false;
		}
		if (this.ClothingWarning)
		{
			this.ClothingTimer += Time.deltaTime;
			if (this.ClothingTimer > 1f)
			{
				this.ClothingWarning = false;
				this.ClothingTimer = 0f;
			}
		}
	}

	// Token: 0x06001FDD RID: 8157 RVA: 0x001D0274 File Offset: 0x001CE474
	private void UpdateDebugFunctionality()
	{
		if (!this.EasterEggMenu.activeInHierarchy && !this.DebugMenu.activeInHierarchy)
		{
			if (!this.Aiming && this.CanMove && Time.timeScale > 0f && !this.StudentManager.TutorialActive && Input.GetKeyDown(KeyCode.Escape))
			{
				this.PauseScreen.JumpToQuit();
			}
			if (Input.GetKeyDown(KeyCode.P))
			{
				this.CyborgParts[1].SetActive(false);
				this.MemeGlasses.SetActive(false);
				this.KONGlasses.SetActive(false);
				this.EyepatchR.SetActive(false);
				this.EyepatchL.SetActive(false);
				this.EyewearID++;
				if (this.EyewearID == 1)
				{
					this.EyepatchR.SetActive(true);
				}
				else if (this.EyewearID == 2)
				{
					this.EyepatchL.SetActive(true);
				}
				else if (this.EyewearID == 3)
				{
					this.EyepatchR.SetActive(true);
					this.EyepatchL.SetActive(true);
				}
				else if (this.EyewearID == 4)
				{
					this.KONGlasses.SetActive(true);
				}
				else if (this.EyewearID == 5)
				{
					this.MemeGlasses.SetActive(true);
				}
				else if (this.EyewearID == 6)
				{
					if (this.CyborgParts[2].activeInHierarchy)
					{
						this.CyborgParts[1].SetActive(true);
					}
					else
					{
						this.EyewearID = 0;
					}
				}
				else
				{
					this.EyewearID = 0;
				}
			}
			if (Input.GetKeyDown(KeyCode.H))
			{
				if (Input.GetButton("LB"))
				{
					this.Hairstyle += 10;
				}
				else
				{
					this.Hairstyle++;
				}
				this.UpdateHair();
			}
			if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.LeftArrow))
			{
				this.Hairstyle--;
				this.UpdateHair();
			}
			if (Input.GetKeyDown(KeyCode.O) && !this.EasterEggMenu.activeInHierarchy)
			{
				if (this.AccessoryID > 0)
				{
					this.Accessories[this.AccessoryID].SetActive(false);
				}
				if (Input.GetButton("LB"))
				{
					this.AccessoryID += 10;
				}
				else
				{
					this.AccessoryID++;
				}
				this.UpdateAccessory();
			}
			if (Input.GetKey(KeyCode.O) && Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (this.AccessoryID > 0)
				{
					this.Accessories[this.AccessoryID].SetActive(false);
				}
				this.AccessoryID--;
				this.UpdateAccessory();
			}
			if (Input.GetKeyDown("-"))
			{
				if (Time.timeScale < 6f)
				{
					Time.timeScale = 1f;
				}
				else
				{
					Time.timeScale -= 5f;
				}
			}
			if (Input.GetKeyDown("="))
			{
				if (Time.timeScale < 5f)
				{
					Time.timeScale = 5f;
				}
				else
				{
					Time.timeScale += 5f;
					if (Time.timeScale > 25f)
					{
						Time.timeScale = 25f;
					}
				}
			}
			if (Input.GetKey(KeyCode.Period))
			{
				this.BreastSize += Time.deltaTime;
				if (this.BreastSize > 2f)
				{
					this.BreastSize = 2f;
				}
				this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
				this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			}
			if (Input.GetKey(KeyCode.Comma))
			{
				this.BreastSize -= Time.deltaTime;
				if (this.BreastSize < 0.5f)
				{
					this.BreastSize = 0.5f;
				}
				this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
				this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			}
		}
		if (this.CanMove)
		{
			if (!this.Egg || this.EggBypass > 8)
			{
				if (base.transform.position.y < 1000f)
				{
					if (Input.GetKeyDown(KeyCode.Slash))
					{
						Debug.Log("Attempting to summon the easter egg menu.");
						this.DebugMenu.SetActive(false);
						this.EasterEggMenu.SetActive(!this.EasterEggMenu.activeInHierarchy);
					}
					if (this.EasterEggMenu.activeInHierarchy)
					{
						if (Input.GetKeyDown(KeyCode.P))
						{
							this.Punish();
							return;
						}
						if (Input.GetKeyDown(KeyCode.Z))
						{
							this.Slend();
							return;
						}
						if (Input.GetKeyDown(KeyCode.B))
						{
							this.Bancho();
							return;
						}
						if (Input.GetKeyDown(KeyCode.C))
						{
							this.Cirno();
							return;
						}
						if (Input.GetKeyDown(KeyCode.H))
						{
							this.EmptyHands();
							this.Hate();
							return;
						}
						if (Input.GetKeyDown(KeyCode.T))
						{
							this.StudentManager.AttackOnTitan();
							this.AttackOnTitan();
							return;
						}
						if (Input.GetKeyDown(KeyCode.G))
						{
							this.GaloSengen();
							return;
						}
						if (!Input.GetKeyDown(KeyCode.J))
						{
							if (Input.GetKeyDown(KeyCode.K))
							{
								this.EasterEggMenu.SetActive(false);
								this.StudentManager.Kong();
								this.DK = true;
								return;
							}
							if (Input.GetKeyDown(KeyCode.L))
							{
								this.Agent();
								return;
							}
							if (!Input.GetKeyDown(KeyCode.N))
							{
								if (Input.GetKeyDown(KeyCode.S))
								{
									this.EasterEggMenu.SetActive(false);
									this.Egg = true;
									this.StudentManager.Spook();
									return;
								}
								if (Input.GetKeyDown(KeyCode.F))
								{
									this.EasterEggMenu.SetActive(false);
									this.Falcon();
									return;
								}
								if (Input.GetKeyDown(KeyCode.X))
								{
									this.EasterEggMenu.SetActive(false);
									this.X();
									return;
								}
								if (Input.GetKeyDown(KeyCode.O))
								{
									this.EasterEggMenu.SetActive(false);
									this.Punch();
									return;
								}
								if (Input.GetKeyDown(KeyCode.U))
								{
									this.EasterEggMenu.SetActive(false);
									this.BadTime();
									return;
								}
								if (Input.GetKeyDown(KeyCode.Y))
								{
									this.EasterEggMenu.SetActive(false);
									this.CyborgNinja();
									return;
								}
								if (Input.GetKeyDown(KeyCode.E))
								{
									this.EasterEggMenu.SetActive(false);
									this.Ebola();
									return;
								}
								if (Input.GetKeyDown(KeyCode.Q))
								{
									this.EasterEggMenu.SetActive(false);
									this.Samus();
									return;
								}
								if (Input.GetKeyDown(KeyCode.W))
								{
									this.EasterEggMenu.SetActive(false);
									this.Witch();
									return;
								}
								if (Input.GetKeyDown(KeyCode.R))
								{
									this.EasterEggMenu.SetActive(false);
									this.Pose();
									return;
								}
								if (Input.GetKeyDown(KeyCode.V))
								{
									this.EasterEggMenu.SetActive(false);
									this.Vaporwave();
									return;
								}
								if (Input.GetKeyDown(KeyCode.Alpha2))
								{
									this.EasterEggMenu.SetActive(false);
									this.HairBlades();
									return;
								}
								if (Input.GetKeyDown(KeyCode.Alpha7))
								{
									this.EasterEggMenu.SetActive(false);
									this.Tornado();
									return;
								}
								if (Input.GetKeyDown(KeyCode.Alpha8))
								{
									this.EasterEggMenu.SetActive(false);
									this.GenderSwap();
									return;
								}
								if (Input.GetKeyDown(KeyCode.A))
								{
									this.EasterEggMenu.SetActive(false);
									this.HollowMode();
									return;
								}
								if (Input.GetKeyDown(KeyCode.I))
								{
									this.StudentManager.NoGravity = true;
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.D))
								{
									this.EasterEggMenu.SetActive(false);
									this.Sith();
									return;
								}
								if (Input.GetKeyDown(KeyCode.M))
								{
									this.EasterEggMenu.SetActive(false);
									this.Snake();
									return;
								}
								if (Input.GetKeyDown(KeyCode.Alpha1))
								{
									this.EasterEggMenu.SetActive(false);
									this.Gazer();
									return;
								}
								if (Input.GetKeyDown(KeyCode.Alpha3))
								{
									this.StudentManager.SecurityCameras();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.Alpha4))
								{
									this.KLK();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.Alpha6))
								{
									this.EasterEggMenu.SetActive(false);
									this.Six();
									return;
								}
								if (Input.GetKeyDown(KeyCode.F1))
								{
									this.Weather();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.F2))
								{
									this.Horror();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.F3))
								{
									this.LifeNote();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.F4))
								{
									this.Mandere();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.F5))
								{
									this.BlackHoleChan();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.F6))
								{
									this.ElfenLied();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.F7))
								{
									this.Berserk();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.F8))
								{
									this.Nier();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.F9))
								{
									this.Ghoul();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.F10))
								{
									this.CinematicCameraFilters.enabled = true;
									this.CameraFilters.enabled = true;
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.F11))
								{
									this.GarbageMode();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (Input.GetKeyDown(KeyCode.F12))
								{
									this.TallMode();
									this.EasterEggMenu.SetActive(false);
									return;
								}
								if (!Input.GetKeyDown(KeyCode.ScrollLock) && Input.GetKeyDown(KeyCode.Space))
								{
									this.EasterEggMenu.SetActive(false);
									return;
								}
							}
						}
					}
				}
			}
			else if (Input.GetKeyDown(KeyCode.Slash))
			{
				this.EggBypass++;
				return;
			}
		}
		else if (Input.GetKeyDown(KeyCode.Z))
		{
			this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().Censor();
		}
	}

	// Token: 0x06001FDE RID: 8158 RVA: 0x001D0C20 File Offset: 0x001CEE20
	private void LateUpdate()
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
		this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.02f);
		this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.02f);
		this.LeftEye.localScale = new Vector3(1f - this.EyeShrink, 1f - this.EyeShrink, this.LeftEye.localScale.z);
		this.RightEye.localScale = new Vector3(1f - this.EyeShrink, 1f - this.EyeShrink, this.RightEye.localScale.z);
		this.ID = 0;
		while (this.ID < this.Spine.Length)
		{
			Transform transform = this.Spine[this.ID].transform;
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + this.Slouch, transform.localEulerAngles.y, transform.localEulerAngles.z);
			this.ID++;
		}
		if (this.Aiming)
		{
			float num = 1f;
			if (this.Selfie)
			{
				num = -1f;
			}
			Transform transform2 = this.Spine[3].transform;
			transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x - this.Bend * num, transform2.localEulerAngles.y, transform2.localEulerAngles.z);
		}
		float num2 = 1f;
		if (this.Stance.Current == StanceType.Crouching)
		{
			num2 = 3.66666f;
		}
		Transform transform3 = this.Arm[0].transform;
		transform3.localEulerAngles = new Vector3(transform3.localEulerAngles.x, transform3.localEulerAngles.y, transform3.localEulerAngles.z - this.Slouch * (3f + num2));
		Transform transform4 = this.Arm[1].transform;
		transform4.localEulerAngles = new Vector3(transform4.localEulerAngles.x, transform4.localEulerAngles.y, transform4.localEulerAngles.z + this.Slouch * (3f + num2));
		if (!this.Aiming)
		{
			this.Head.localEulerAngles += this.Twitch;
		}
		if (this.Aiming)
		{
			if (this.Stance.Current == StanceType.Crawling)
			{
				if (!this.StudentManager.Eighties)
				{
					this.TargetHeight = -1.4f;
				}
				else
				{
					this.TargetHeight = -2f;
				}
			}
			else if (this.Stance.Current == StanceType.Crouching)
			{
				if (!this.StudentManager.Eighties)
				{
					this.TargetHeight = -0.6f;
				}
				else
				{
					this.TargetHeight = -2f;
				}
			}
			else
			{
				this.TargetHeight = 0f;
			}
			this.Height = Mathf.Lerp(this.Height, this.TargetHeight, Time.deltaTime * 10f);
			this.PelvisRoot.transform.localPosition = new Vector3(this.PelvisRoot.transform.localPosition.x, this.Height, this.PelvisRoot.transform.localPosition.z);
		}
		if (this.Egg)
		{
			if (this.Slender)
			{
				Transform transform5 = this.Leg[0];
				transform5.localScale = new Vector3(transform5.localScale.x, 2f, transform5.localScale.z);
				Transform transform6 = this.Foot[0];
				transform6.localScale = new Vector3(transform6.localScale.x, 0.5f, transform6.localScale.z);
				Transform transform7 = this.Leg[1];
				transform7.localScale = new Vector3(transform7.localScale.x, 2f, transform7.localScale.z);
				Transform transform8 = this.Foot[1];
				transform8.localScale = new Vector3(transform8.localScale.x, 0.5f, transform8.localScale.z);
				Transform transform9 = this.Arm[0];
				transform9.localScale = new Vector3(2f, transform9.localScale.y, transform9.localScale.z);
				Transform transform10 = this.Arm[1];
				transform10.localScale = new Vector3(2f, transform10.localScale.y, transform10.localScale.z);
			}
			if (this.DK)
			{
				this.Arm[0].localScale = new Vector3(2f, 2f, 2f);
				this.Arm[1].localScale = new Vector3(2f, 2f, 2f);
				this.Head.localScale = new Vector3(2f, 2f, 2f);
			}
			if (this.CirnoWings.activeInHierarchy)
			{
				if (this.Running)
				{
					this.FlapSpeed = 5f;
				}
				else if (this.FlapSpeed == 0f)
				{
					this.FlapSpeed = 1f;
				}
				else
				{
					this.FlapSpeed = 3f;
				}
				Transform transform11 = this.CirnoWing[0];
				Transform transform12 = this.CirnoWing[1];
				if (!this.FlapOut)
				{
					this.CirnoRotation += Time.deltaTime * 100f * this.FlapSpeed;
					transform11.localEulerAngles = new Vector3(transform11.localEulerAngles.x, this.CirnoRotation, transform11.localEulerAngles.z);
					transform12.localEulerAngles = new Vector3(transform12.localEulerAngles.x, -this.CirnoRotation, transform12.localEulerAngles.z);
					if (this.CirnoRotation > 15f)
					{
						this.FlapOut = true;
					}
				}
				else
				{
					this.CirnoRotation -= Time.deltaTime * 100f * this.FlapSpeed;
					transform11.localEulerAngles = new Vector3(transform11.localEulerAngles.x, this.CirnoRotation, transform11.localEulerAngles.z);
					transform12.localEulerAngles = new Vector3(transform12.localEulerAngles.x, -this.CirnoRotation, transform12.localEulerAngles.z);
					if (this.CirnoRotation < -15f)
					{
						this.FlapOut = false;
					}
				}
			}
			if (this.BlackHole)
			{
				this.RightLeg.transform.Rotate(-60f, 0f, 0f, Space.Self);
				this.LeftLeg.transform.Rotate(-60f, 0f, 0f, Space.Self);
			}
			if (this.SwingKagune)
			{
				if (!this.ReturnKagune)
				{
					for (int i = 0; i < this.Kagune.Length; i++)
					{
						if (i < 2)
						{
							this.KaguneRotation[i] = new Vector3(Mathf.MoveTowards(this.KaguneRotation[i].x, 15f, Time.deltaTime * 1000f), Mathf.MoveTowards(this.KaguneRotation[i].y, 180f, Time.deltaTime * 1000f), Mathf.MoveTowards(this.KaguneRotation[i].z, 500f, Time.deltaTime * 1000f));
							this.Kagune[i].transform.localEulerAngles = this.KaguneRotation[i];
						}
						else
						{
							this.KaguneRotation[i] = new Vector3(Mathf.MoveTowards(this.KaguneRotation[i].x, 15f, Time.deltaTime * 1000f), Mathf.MoveTowards(this.KaguneRotation[i].y, -180f, Time.deltaTime * 1000f), Mathf.MoveTowards(this.KaguneRotation[i].z, -500f, Time.deltaTime * 1000f));
							this.Kagune[i].transform.localEulerAngles = this.KaguneRotation[i];
						}
					}
					if (this.KagunePhase == 0 && this.KaguneRotation[0].y == 180f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.DemonSlash, base.transform.position + base.transform.up + base.transform.forward, Quaternion.identity);
						this.KagunePhase = 1;
					}
					if (this.KaguneRotation[0] == new Vector3(15f, 180f, 500f))
					{
						this.ReturnKagune = true;
					}
				}
				else
				{
					for (int j = 0; j < this.Kagune.Length; j++)
					{
						if (j == 0)
						{
							this.KaguneRotation[j] = new Vector3(Mathf.Lerp(this.KaguneRotation[j].x, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].y, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].z, 0f, Time.deltaTime * 10f));
						}
						else if (j == 1)
						{
							this.KaguneRotation[j] = new Vector3(Mathf.Lerp(this.KaguneRotation[j].x, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].y, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].z, 0f, Time.deltaTime * 10f));
						}
						else if (j == 2)
						{
							this.KaguneRotation[j] = new Vector3(Mathf.Lerp(this.KaguneRotation[j].x, 22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].y, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].z, 0f, Time.deltaTime * 10f));
						}
						else if (j == 3)
						{
							this.KaguneRotation[j] = new Vector3(Mathf.Lerp(this.KaguneRotation[j].x, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].y, -22.5f, Time.deltaTime * 10f), Mathf.Lerp(this.KaguneRotation[j].z, 0f, Time.deltaTime * 10f));
						}
						this.Kagune[j].transform.localEulerAngles = this.KaguneRotation[j];
					}
					if (Vector3.Distance(this.KaguneRotation[0], new Vector3(22.5f, 22.5f, 0f)) < 10f)
					{
						this.SwingKagune = false;
						this.ReturnKagune = false;
						this.KagunePhase = 0;
					}
				}
			}
			if (this.FloppyHat.activeInHierarchy)
			{
				int k = 0;
				if (this.LongFingers)
				{
					this.CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_yanderePose_00"].weight, 1f, Time.deltaTime * 10f);
					this.FingerLength = Mathf.Lerp(this.FingerLength, 4f, Time.deltaTime * 10f);
					this.Slouch = Mathf.Lerp(this.Slouch, 1f, Time.deltaTime * 10f);
					while (k < this.AllFingers.Length)
					{
						this.AllFingers[k].localScale = new Vector3(this.FingerLength, 1f, 1f);
						k++;
					}
				}
				else
				{
					this.CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_yanderePose_00"].weight, 0f, Time.deltaTime * 10f);
					this.FingerLength = Mathf.Lerp(this.FingerLength, 1f, Time.deltaTime * 10f);
					this.Slouch = Mathf.Lerp(this.Slouch, 0f, Time.deltaTime * 10f);
					while (k < this.AllFingers.Length)
					{
						this.AllFingers[k].localScale = new Vector3(this.FingerLength, 1f, 1f);
						k++;
					}
				}
			}
			if (this.HollowMask.activeInHierarchy)
			{
				if (this.Armed)
				{
					if (!this.Attacking)
					{
						this.RightArmRoll.GetChild(0).localEulerAngles = new Vector3(0f, 0f, 0f);
						if (this.Running)
						{
							this.RightArmRoll.parent.localEulerAngles = new Vector3(0f, 0f, -75f);
							this.RightArmRoll.localEulerAngles = new Vector3(0f, 0f, 0f);
							this.RightArmRoll.GetChild(0).GetChild(1).localEulerAngles = new Vector3(0f, 0f, 0f);
							this.RightArmRoll.GetChild(0).GetChild(1).GetChild(0).localEulerAngles = new Vector3(0f, 90f, 0f);
						}
						else
						{
							this.RightArmRoll.parent.localEulerAngles += new Vector3(0f, 0f, 5f);
							this.RightArmRoll.GetChild(0).GetChild(1).GetChild(0).localEulerAngles = new Vector3(0f, 45f, 0f);
						}
					}
					this.ArmSize = Mathf.Lerp(this.ArmSize, 1f, Time.deltaTime * 10f);
				}
				else
				{
					this.ArmSize = Mathf.Lerp(this.ArmSize, 0f, Time.deltaTime * 10f);
				}
				this.RightArmRoll.parent.localScale = new Vector3(this.ArmSize, this.ArmSize, this.ArmSize);
				this.RightFootprintSpawner.transform.parent.localScale = new Vector3(0f, 0f, 0f);
				this.LeftFootprintSpawner.transform.parent.localScale = new Vector3(0f, 0f, 0f);
				this.LeftArmRoll.parent.localScale = new Vector3(0f, 0f, 0f);
			}
		}
		if (this.SpiderLegs.activeInHierarchy)
		{
			if (this.SpiderGrow)
			{
				if (this.SpiderLegs.transform.localScale.x < 0.49f)
				{
					this.SpiderLegs.transform.localScale = Vector3.Lerp(this.SpiderLegs.transform.localScale, new Vector3(0.5f, 0.5f, 0.5f), Time.deltaTime * 5f);
					SchoolGlobals.SchoolAtmosphere = 1f - this.SpiderLegs.transform.localScale.x;
					this.StudentManager.SetAtmosphere();
				}
			}
			else if (this.SpiderLegs.transform.localScale.x > 0.001f)
			{
				this.SpiderLegs.transform.localScale = Vector3.Lerp(this.SpiderLegs.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 5f);
				SchoolGlobals.SchoolAtmosphere = 1f - this.SpiderLegs.transform.localScale.x;
				this.StudentManager.SetAtmosphere();
			}
		}
		if (this.PickUp != null && this.PickUp.Flashlight)
		{
			this.RightHand.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
		}
		if (this.ReachWeight > 0f)
		{
			this.CharacterAnimation["f02_reachForWeapon_00"].weight = this.ReachWeight;
			this.ReachWeight = Mathf.MoveTowards(this.ReachWeight, 0f, Time.deltaTime * 2f);
			if (this.ReachWeight < 0.01f)
			{
				this.ReachWeight = 0f;
				this.CharacterAnimation["f02_reachForWeapon_00"].weight = 0f;
			}
		}
		if (this.SanitySmudges.color.a > 1f - this.sanity / 100f + 0.0001f || this.SanitySmudges.color.a < 1f - this.sanity / 100f - 0.0001f)
		{
			float num3 = this.SanitySmudges.color.a;
			num3 = Mathf.MoveTowards(num3, 1f - this.sanity / 100f, Time.deltaTime);
			this.SanitySmudges.color = new Color(1f, 1f, 1f, num3);
			this.StudentManager.SelectiveGreyscale.desaturation = 1f - this.StudentManager.Atmosphere + num3;
			if (num3 > 0.66666f)
			{
				float faces = 1f - (1f - num3) / 0.33333f;
				this.StudentManager.SetFaces(faces);
			}
			else
			{
				this.StudentManager.SetFaces(0f);
			}
			float num4 = 100f - num3 * 100f;
			this.SanityLabel.text = num4.ToString("0") + "%";
		}
		if (this.CanMove && this.sanity < 33.333f && !this.NearSenpai)
		{
			this.GiggleTimer += Time.deltaTime * (1f - this.sanity / 33.333f);
			if (this.GiggleTimer > 10f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.GiggleDisc, base.transform.position + Vector3.up, Quaternion.identity);
				AudioSource.PlayClipAtPoint(this.CreepyGiggles[UnityEngine.Random.Range(0, this.CreepyGiggles.Length)], base.transform.position);
				this.InsaneLines.Play();
				this.GiggleTimer = 0f;
			}
		}
		if (this.FightHasBrokenUp)
		{
			this.BreakUpTimer = Mathf.MoveTowards(this.BreakUpTimer, 0f, Time.deltaTime);
			if (this.BreakUpTimer == 0f)
			{
				this.FightHasBrokenUp = false;
				this.SeenByAuthority = false;
			}
		}
	}

	// Token: 0x06001FDF RID: 8159 RVA: 0x001D2070 File Offset: 0x001D0270
	public void StainWeapon()
	{
		if (this.EquippedWeapon != null)
		{
			if (this.TargetStudent != null && this.TargetStudent.StudentID < this.EquippedWeapon.Victims.Length)
			{
				this.EquippedWeapon.Victims[this.TargetStudent.StudentID] = true;
			}
			this.EquippedWeapon.Blood.enabled = true;
			this.EquippedWeapon.MurderWeapon = true;
			if (this.EquippedWeapon.Type == WeaponType.Bat)
			{
				this.NoStainGloves = true;
			}
			if (!this.NoStainGloves)
			{
				if (this.Gloved && !this.Gloves.Blood.enabled)
				{
					this.GloveAttacher.newRenderer.material.mainTexture = this.BloodyGloveTexture;
					this.Gloves.PickUp.Evidence = true;
					this.Gloves.Blood.enabled = true;
					this.GloveBlood = 1;
					this.Police.BloodyClothing++;
				}
				if (this.Mask != null && !this.Mask.Blood.enabled)
				{
					this.Mask.PickUp.Evidence = true;
					this.Mask.Blood.enabled = true;
					this.Police.BloodyClothing++;
				}
			}
			if (!this.EquippedWeapon.Evidence)
			{
				this.EquippedWeapon.Evidence = true;
				this.Police.MurderWeapons++;
			}
		}
	}

	// Token: 0x06001FE0 RID: 8160 RVA: 0x001D2200 File Offset: 0x001D0400
	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 a = target - base.transform.position;
		this.MyController.Move(a * (Time.deltaTime * 10f));
	}

	// Token: 0x06001FE1 RID: 8161 RVA: 0x001D223C File Offset: 0x001D043C
	public void StopAiming()
	{
		this.UpdateAccessory();
		this.UpdateHair();
		this.CharacterAnimation["f02_cameraPose_00"].weight = 0f;
		this.CharacterAnimation["f02_selfie_00"].weight = 0f;
		this.PelvisRoot.transform.localPosition = new Vector3(this.PelvisRoot.transform.localPosition.x, 0f, this.PelvisRoot.transform.localPosition.z);
		this.ShoulderCamera.AimingCamera = false;
		if (!Input.GetButtonDown("Start") && !Input.GetKeyDown(KeyCode.Escape))
		{
			this.FixCamera();
		}
		if (this.ShoulderCamera.Timer == 0f)
		{
			this.RPGCamera.enabled = true;
		}
		if (!OptionGlobals.Fog)
		{
			this.MainCamera.clearFlags = CameraClearFlags.Skybox;
		}
		else
		{
			this.MainCamera.clearFlags = CameraClearFlags.Color;
		}
		this.Smartphone.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		this.Smartphone.targetTexture = this.Shutter.SmartphoneScreen;
		this.Smartphone.transform.parent.gameObject.SetActive(false);
		this.Smartphone.fieldOfView = 60f;
		this.MainCamera.farClipPlane = (float)OptionGlobals.DrawDistance;
		this.MainCamera.nearClipPlane = 0.1f;
		this.Shutter.TargetStudent = 0;
		this.Height = 0f;
		this.Bend = 0f;
		this.HandCamera.gameObject.SetActive(false);
		this.SelfieGuide.SetActive(false);
		this.PhonePromptBar.Show = false;
		this.MainCamera.enabled = true;
		this.UsingController = false;
		this.Aiming = false;
		this.Selfie = false;
		this.Lewd = false;
		this.StudentManager.UpdatePanties(false);
		if (OptionGlobals.DepthOfField)
		{
			this.PauseScreen.NewSettings.Profile.depthOfField.enabled = true;
		}
	}

	// Token: 0x06001FE2 RID: 8162 RVA: 0x001D245C File Offset: 0x001D065C
	public void FixCamera()
	{
		if (!this.SneakingShot)
		{
			this.RPGCamera.enabled = true;
			this.RPGCamera.UpdateRotation();
			this.RPGCamera.mouseSmoothingFactor = 0f;
			this.RPGCamera.GetInput();
			this.RPGCamera.GetDesiredPosition();
			this.RPGCamera.PositionUpdate();
			this.RPGCamera.mouseSmoothingFactor = 0.08f;
		}
		this.Blur.enabled = false;
	}

	// Token: 0x06001FE3 RID: 8163 RVA: 0x001D24D8 File Offset: 0x001D06D8
	public void ResetSenpaiEffects()
	{
		this.SenpaiFilter.enabled = false;
		this.Phone.SetActive(false);
		for (int i = 1; i < 6; i++)
		{
			this.CharacterAnimation[this.CreepyIdles[i]].weight = 0f;
			this.CharacterAnimation[this.CreepyWalks[i]].weight = 0f;
		}
		this.CharacterAnimation["f02_shy_00"].weight = 0f;
		this.HeartBeat.volume = 0f;
		this.SelectGrayscale.desaturation = this.GreyTarget;
		this.SenpaiFade = 100f;
		this.SenpaiTint = 0f;
	}

	// Token: 0x06001FE4 RID: 8164 RVA: 0x001D2594 File Offset: 0x001D0794
	public void ResetYandereEffects()
	{
		this.YandereTimer = 0f;
		this.Phone.SetActive(false);
		this.CharacterAnimation["f02_phonePose_00"].weight = 0f;
		this.YandereVisionPanel.alpha = 0f;
		this.SenpaiGazing = false;
		this.CameraEffects.UpdateVignette(1f - this.Sanity * 0.01f);
		this.YandereFilter.FadeFX = 0f;
		this.YandereFilter.enabled = false;
		Time.timeScale = 1f;
		this.YandereFade = 100f;
		this.StudentManager.Tag.Sprite.color = new Color(1f, 0f, 0f, 0f);
		this.StudentManager.RedString.gameObject.SetActive(false);
		this.RightRedEye.material.color = new Color(1f, 1f, 1f, 0f);
		this.LeftRedEye.material.color = new Color(1f, 1f, 1f, 0f);
		this.RightYandereEye.material.color = new Color(1f, 1f, 1f, 1f);
		this.LeftYandereEye.material.color = new Color(1f, 1f, 1f, 1f);
		this.HighlightingR.enabled = false;
		this.HighlightingB.enabled = false;
	}

	// Token: 0x06001FE5 RID: 8165 RVA: 0x001D2738 File Offset: 0x001D0938
	private void DumpRagdoll(RagdollDumpType Type)
	{
		this.Ragdoll.transform.position = base.transform.position;
		if (Type == RagdollDumpType.Incinerator)
		{
			this.Ragdoll.transform.LookAt(this.Incinerator.transform.position);
			this.Ragdoll.transform.eulerAngles = new Vector3(this.Ragdoll.transform.eulerAngles.x, this.Ragdoll.transform.eulerAngles.y + 180f, this.Ragdoll.transform.eulerAngles.z);
		}
		else if (Type == RagdollDumpType.TranqCase)
		{
			this.Ragdoll.transform.LookAt(this.TranqCase.transform.position);
		}
		else if (Type == RagdollDumpType.WoodChipper)
		{
			this.Ragdoll.transform.LookAt(this.WoodChipper.transform.position);
		}
		RagdollScript component = this.Ragdoll.GetComponent<RagdollScript>();
		component.DumpType = Type;
		component.Dump();
	}

	// Token: 0x06001FE6 RID: 8166 RVA: 0x001D2844 File Offset: 0x001D0A44
	public void Unequip()
	{
		if (this.CanMove || this.Noticed)
		{
			if (this.Equipped < 3)
			{
				this.CharacterAnimation["f02_reachForWeapon_00"].time = 0f;
				this.ReachWeight = 1f;
				if (this.EquippedWeapon != null)
				{
					this.EquippedWeapon.gameObject.SetActive(false);
				}
			}
			else if (this.Weapon[3] != null)
			{
				this.Weapon[3].Drop();
			}
			this.Equipped = 0;
			this.Mopping = false;
			this.StudentManager.UpdateStudents(0);
			this.WeaponManager.UpdateLabels();
			this.WeaponMenu.UpdateSprites();
			this.WeaponWarning = false;
		}
	}

	// Token: 0x06001FE7 RID: 8167 RVA: 0x001D2908 File Offset: 0x001D0B08
	public void DropWeapon(int ID)
	{
		if (!this.Weapon[ID].Undroppable)
		{
			this.DropTimer[ID] += Time.deltaTime;
			if (this.DropTimer[ID] > 0.5f)
			{
				this.Weapon[ID].Drop();
				this.Weapon[ID] = null;
				this.Unequip();
				this.DropTimer[ID] = 0f;
			}
		}
	}

	// Token: 0x06001FE8 RID: 8168 RVA: 0x001D2974 File Offset: 0x001D0B74
	public void EmptyHands()
	{
		if (this.Carrying || this.HeavyWeight)
		{
			this.StopCarrying();
		}
		if (this.Armed)
		{
			this.Unequip();
		}
		if (this.PickUp != null)
		{
			this.PickUp.Drop();
		}
		if (this.Dragging)
		{
			this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
		}
		this.ID = 1;
		while (this.ID < this.Poisons.Length)
		{
			this.Poisons[this.ID].SetActive(false);
			this.ID++;
		}
		this.Mopping = false;
	}

	// Token: 0x06001FE9 RID: 8169 RVA: 0x001D2A18 File Offset: 0x001D0C18
	public void UpdateNumbness()
	{
		this.Numbness = 1f - 0.1f * (float)(this.Class.Numbness + this.Class.NumbnessBonus + this.Class.PsychologyGrade + this.Class.PsychologyBonus);
	}

	// Token: 0x06001FEA RID: 8170 RVA: 0x001D2A68 File Offset: 0x001D0C68
	private void OnTriggerEnter(Collider other)
	{
		if (!this.StudentManager.TutorialActive && other.gameObject.name == "BloodPool(Clone)" && other.transform.localScale.x > 0.3f)
		{
			if (PlayerGlobals.PantiesEquipped == 8)
			{
				this.RightFootprintSpawner.Bloodiness = 5;
				this.LeftFootprintSpawner.Bloodiness = 5;
				return;
			}
			this.RightFootprintSpawner.Bloodiness = 10;
			this.LeftFootprintSpawner.Bloodiness = 10;
		}
	}

	// Token: 0x06001FEB RID: 8171 RVA: 0x001D2AEC File Offset: 0x001D0CEC
	public void UpdateHair()
	{
		if (this.Hairstyle > this.Hairstyles.Length - 1)
		{
			this.Hairstyle = 0;
		}
		if (this.Hairstyle < 0)
		{
			this.Hairstyle = this.Hairstyles.Length - 1;
		}
		this.ID = 1;
		while (this.ID < this.Hairstyles.Length)
		{
			this.Hairstyles[this.ID].SetActive(false);
			this.ID++;
		}
		if (this.Hairstyle > 0)
		{
			this.Hairstyles[this.Hairstyle].SetActive(true);
		}
	}

	// Token: 0x06001FEC RID: 8172 RVA: 0x001D2B84 File Offset: 0x001D0D84
	public void StopLaughing()
	{
		this.BladeHairCollider1.enabled = false;
		this.BladeHairCollider2.enabled = false;
		if (this.Sanity < 33.33333f)
		{
			this.Teeth.SetActive(true);
		}
		this.LaughIntensity = 0f;
		this.Laughing = false;
		this.LaughClip = null;
		this.Twitch = Vector3.zero;
		if (!this.Stand.Stand.activeInHierarchy)
		{
			this.CanMove = true;
		}
		if (this.BanchoActive)
		{
			AudioSource.PlayClipAtPoint(this.BanchoFinalYan, base.transform.position);
			this.CharacterAnimation.CrossFade("f02_banchoFinisher_00");
			this.BanchoFlurry.MyCollider.enabled = false;
			this.Finisher = true;
			this.CanMove = false;
		}
		if (this.StudentManager.Eighties)
		{
			this.RestoreGentleEyes();
		}
	}

	// Token: 0x06001FED RID: 8173 RVA: 0x001D2C60 File Offset: 0x001D0E60
	private void SetUniform()
	{
		if (StudentGlobals.FemaleUniform == 0)
		{
			StudentGlobals.FemaleUniform = 1;
		}
		this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
		if (this.Casual)
		{
			this.TextureToUse = this.UniformTextures[StudentGlobals.FemaleUniform];
		}
		else
		{
			this.TextureToUse = this.CasualTextures[StudentGlobals.FemaleUniform];
		}
		this.MyRenderer.materials[0].mainTexture = this.TextureToUse;
		this.MyRenderer.materials[1].mainTexture = this.TextureToUse;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		base.StartCoroutine(this.ApplyCustomCostume());
	}

	// Token: 0x06001FEE RID: 8174 RVA: 0x001D2D14 File Offset: 0x001D0F14
	private IEnumerator ApplyCustomCostume()
	{
		if (StudentGlobals.FemaleUniform == 1)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomUniform.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		else if (StudentGlobals.FemaleUniform == 2)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLong.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		else if (StudentGlobals.FemaleUniform == 3)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSweater.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		else if (StudentGlobals.FemaleUniform == 4 || StudentGlobals.FemaleUniform == 5)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomBlazer.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		WWW CustomFace = new WWW("file:///" + Application.streamingAssetsPath + "/CustomFace.png");
		yield return CustomFace;
		if (CustomFace.error == null)
		{
			this.MyRenderer.materials[2].mainTexture = CustomFace.texture;
			this.FaceTexture = CustomFace.texture;
		}
		WWW CustomHair = new WWW("file:///" + Application.streamingAssetsPath + "/CustomHair.png");
		yield return CustomHair;
		if (CustomHair.error == null)
		{
			this.PonytailRenderer.material.mainTexture = CustomHair.texture;
			this.PigtailR.material.mainTexture = CustomHair.texture;
			this.PigtailL.material.mainTexture = CustomHair.texture;
		}
		WWW CustomDrills = new WWW("file:///" + Application.streamingAssetsPath + "/CustomDrills.png");
		yield return CustomDrills;
		if (CustomDrills.error == null)
		{
			this.Drills.materials[0].mainTexture = CustomDrills.texture;
			this.Drills.material.mainTexture = CustomDrills.texture;
		}
		WWW CustomSwimsuit = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSwimsuit.png");
		yield return CustomSwimsuit;
		if (CustomSwimsuit.error == null)
		{
			this.SwimsuitTexture = CustomSwimsuit.texture;
		}
		WWW CustomGym = new WWW("file:///" + Application.streamingAssetsPath + "/CustomGym.png");
		yield return CustomGym;
		if (CustomGym.error == null)
		{
			this.GymTexture = CustomGym.texture;
		}
		WWW CustomNude = new WWW("file:///" + Application.streamingAssetsPath + "/CustomNude.png");
		yield return CustomNude;
		if (CustomNude.error == null)
		{
			this.NudeTexture = CustomNude.texture;
		}
		WWW CustomLongHairA = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairA.png");
		yield return CustomDrills;
		WWW CustomLongHairB = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairB.png");
		yield return CustomDrills;
		WWW CustomLongHairC = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairC.png");
		yield return CustomDrills;
		if (CustomLongHairA.error == null && CustomLongHairB.error == null && CustomLongHairC.error == null)
		{
			this.LongHairRenderer.materials[0].mainTexture = CustomLongHairA.texture;
			this.LongHairRenderer.materials[1].mainTexture = CustomLongHairB.texture;
			this.LongHairRenderer.materials[2].mainTexture = CustomLongHairC.texture;
		}
		yield break;
	}

	// Token: 0x06001FEF RID: 8175 RVA: 0x001D2D24 File Offset: 0x001D0F24
	public void WearGloves()
	{
		if (this.Bloodiness > 0f && !this.Gloves.Blood.enabled)
		{
			this.Gloves.PickUp.Evidence = true;
			this.Gloves.Blood.enabled = true;
		}
		if (this.Gloves.Blood.enabled)
		{
			this.GloveBlood = 1;
		}
		this.Gloved = true;
		if (this.WearingRaincoat)
		{
			this.WearRaincoat();
			if (this.RaincoatAttacher.newRenderer != null)
			{
				this.RaincoatAttacher.newRenderer.enabled = true;
			}
			this.OriginalBloodiness = this.Bloodiness;
			this.Bloodiness = this.CoatBloodiness;
			return;
		}
		this.GloveAttacher.newRenderer.enabled = true;
	}

	// Token: 0x06001FF0 RID: 8176 RVA: 0x001D2DF0 File Offset: 0x001D0FF0
	private void AttackOnTitan()
	{
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.TitanFaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.TitanBodyTexture;
		this.MyRenderer.materials[2].mainTexture = this.TitanBodyTexture;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.ODMGear.SetActive(true);
		this.TitanSword[0].SetActive(true);
		this.TitanSword[1].SetActive(true);
		this.IdleAnim = "f02_heroicIdle_00";
		this.WalkAnim = "f02_walkConfident_00";
		this.RunAnim = "f02_sithRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.RunSpeed *= 2f;
		this.MusicCredit.SongLabel.text = "Now Playing: This Is My Choice";
		this.MusicCredit.BandLabel.text = "By: The Kira Justice";
		this.MusicCredit.Panel.enabled = true;
		this.MusicCredit.Slide = true;
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
		this.Outline.h.ReinitMaterials();
	}

	// Token: 0x06001FF1 RID: 8177 RVA: 0x001D2FA4 File Offset: 0x001D11A4
	private void KON()
	{
		this.MyRenderer.sharedMesh = this.Uniforms[4];
		this.MyRenderer.materials[0].mainTexture = this.KONTexture;
		this.MyRenderer.materials[1].mainTexture = this.KONTexture;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.Outline.h.ReinitMaterials();
	}

	// Token: 0x06001FF2 RID: 8178 RVA: 0x001D301C File Offset: 0x001D121C
	private void Punish()
	{
		this.PunishedShader = Shader.Find("Toon/Cutoff");
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
		this.PunishedAccessories.SetActive(true);
		this.PunishedScarf.SetActive(true);
		this.EyepatchL.SetActive(false);
		this.EyepatchR.SetActive(false);
		this.ID = 0;
		while (this.ID < this.PunishedArm.Length)
		{
			this.PunishedArm[this.ID].SetActive(true);
			this.ID++;
		}
		this.MyRenderer.sharedMesh = this.PunishedMesh;
		this.MyRenderer.materials[0].mainTexture = this.PunishedTextures[1];
		this.MyRenderer.materials[1].mainTexture = this.PunishedTextures[1];
		this.MyRenderer.materials[2].mainTexture = this.PunishedTextures[0];
		this.MyRenderer.materials[1].shader = this.PunishedShader;
		this.MyRenderer.materials[1].SetFloat("_Shininess", 1f);
		this.MyRenderer.materials[1].SetFloat("_ShadowThreshold", 0f);
		this.MyRenderer.materials[1].SetFloat("_Cutoff", 0.9f);
		this.MyRenderer.materials[1].color = new Color(1f, 1f, 1f, 1f);
		this.Outline.h.ReinitMaterials();
	}

	// Token: 0x06001FF3 RID: 8179 RVA: 0x001D3208 File Offset: 0x001D1408
	private void Hate()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.HatefulUniform;
		this.MyRenderer.materials[1].mainTexture = this.HatefulUniform;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		RenderSettings.skybox = this.HatefulSkybox;
		this.SelectGrayscale.desaturation = 1f;
		this.HeartRate.gameObject.SetActive(false);
		this.Sanity = 0f;
		this.Hairstyle = 15;
		this.UpdateHair();
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
	}

	// Token: 0x06001FF4 RID: 8180 RVA: 0x001D3314 File Offset: 0x001D1514
	private void Sukeban()
	{
		this.IdleAnim = "f02_idle_00";
		this.SukebanAccessories.SetActive(true);
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[1].mainTexture = this.SukebanBandages;
		this.MyRenderer.materials[0].mainTexture = this.SukebanUniform;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
	}

	// Token: 0x06001FF5 RID: 8181 RVA: 0x001D33A8 File Offset: 0x001D15A8
	private void Bancho()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.BanchoCamera.SetActive(true);
		this.MotionObject.enabled = true;
		this.MotionBlur.enabled = true;
		this.BanchoAccessories[0].SetActive(true);
		this.BanchoAccessories[1].SetActive(true);
		this.BanchoAccessories[2].SetActive(true);
		this.BanchoAccessories[3].SetActive(true);
		this.BanchoAccessories[4].SetActive(true);
		this.BanchoAccessories[5].SetActive(true);
		this.BanchoAccessories[6].SetActive(true);
		this.BanchoAccessories[7].SetActive(true);
		this.BanchoAccessories[8].SetActive(true);
		this.Laugh1 = this.BanchoYanYan;
		this.Laugh2 = this.BanchoYanYan;
		this.Laugh3 = this.BanchoYanYan;
		this.Laugh4 = this.BanchoYanYan;
		this.IdleAnim = "f02_banchoIdle_00";
		this.WalkAnim = "f02_banchoWalk_00";
		this.RunAnim = "f02_banchoSprint_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.RunSpeed *= 2f;
		this.BanchoPants.SetActive(true);
		this.MyRenderer.sharedMesh = this.BanchoMesh;
		this.MyRenderer.materials[0].mainTexture = this.BanchoFace;
		this.MyRenderer.materials[1].mainTexture = this.BanchoBody;
		this.MyRenderer.materials[2].mainTexture = this.BanchoBody;
		this.BanchoActive = true;
		this.TheDebugMenuScript.UpdateCensor();
		this.Character.transform.localPosition = new Vector3(0f, 0.04f, 0f);
		this.Hairstyle = 0;
		this.UpdateHair();
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
	}

	// Token: 0x06001FF6 RID: 8182 RVA: 0x001D35E4 File Offset: 0x001D17E4
	private void Slend()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		RenderSettings.skybox = this.SlenderSkybox;
		this.SelectGrayscale.desaturation = 0.5f;
		this.SelectGrayscale.enabled = true;
		this.EasterEggMenu.SetActive(false);
		this.Slender = true;
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.SlenderHair[0].transform.parent.gameObject.SetActive(true);
		this.SlenderHair[0].SetActive(true);
		this.SlenderHair[1].SetActive(true);
		this.RightYandereEye.gameObject.SetActive(false);
		this.LeftYandereEye.gameObject.SetActive(false);
		this.Character.transform.localPosition = new Vector3(this.Character.transform.localPosition.x, 0.822f, this.Character.transform.localPosition.z);
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.SlenderUniform;
		this.MyRenderer.materials[1].mainTexture = this.SlenderUniform;
		this.MyRenderer.materials[2].mainTexture = this.SlenderSkin;
		this.Sanity = 0f;
	}

	// Token: 0x06001FF7 RID: 8183 RVA: 0x001D3790 File Offset: 0x001D1990
	private void X()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.Xtan = true;
		this.Egg = true;
		this.Hairstyle = 9;
		this.UpdateHair();
		this.BlackEyePatch.SetActive(true);
		this.XSclera.SetActive(true);
		this.XEye.SetActive(true);
		this.Schoolwear = 2;
		this.ChangeSchoolwear();
		this.CanMove = true;
		this.MyRenderer.materials[0].mainTexture = this.XBody;
		this.MyRenderer.materials[1].mainTexture = this.XBody;
		this.MyRenderer.materials[2].mainTexture = this.XFace;
	}

	// Token: 0x06001FF8 RID: 8184 RVA: 0x001D3884 File Offset: 0x001D1A84
	private void GaloSengen()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.IdleAnim = "f02_gruntIdle_00";
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
		this.ID = 0;
		while (this.ID < this.GaloAccessories.Length)
		{
			this.GaloAccessories[this.ID].SetActive(true);
			this.ID++;
		}
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.UniformTextures[1];
		this.MyRenderer.materials[1].mainTexture = this.GaloArms;
		this.MyRenderer.materials[2].mainTexture = this.GaloFace;
		this.Hairstyle = 14;
		this.UpdateHair();
	}

	// Token: 0x06001FF9 RID: 8185 RVA: 0x001D39A0 File Offset: 0x001D1BA0
	public void Jojo()
	{
		this.ShoulderCamera.LastPosition = this.ShoulderCamera.transform.position;
		this.ShoulderCamera.Summoning = true;
		this.RPGCamera.enabled = false;
		AudioSource.PlayClipAtPoint(this.SummonStand, base.transform.position);
		this.IdleAnim = "f02_jojoPose_00";
		this.WalkAnim = "f02_jojoWalk_00";
		this.EasterEggMenu.SetActive(false);
		this.CanMove = false;
		this.Egg = true;
		this.CharacterAnimation.CrossFade("f02_summonStand_00");
		this.Laugh1 = this.YanYan;
		this.Laugh2 = this.YanYan;
		this.Laugh3 = this.YanYan;
		this.Laugh4 = this.YanYan;
	}

	// Token: 0x06001FFA RID: 8186 RVA: 0x001D3A68 File Offset: 0x001D1C68
	private void Agent()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.Uniforms[4];
		this.MyRenderer.materials[0].mainTexture = this.AgentSuit;
		this.MyRenderer.materials[1].mainTexture = this.AgentSuit;
		this.MyRenderer.materials[2].mainTexture = this.AgentFace;
		this.EasterEggMenu.SetActive(false);
		this.Egg = true;
		this.Barcode.SetActive(true);
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	// Token: 0x06001FFB RID: 8187 RVA: 0x001D3B48 File Offset: 0x001D1D48
	private void Cirno()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.Uniforms[3];
		this.MyRenderer.materials[0].mainTexture = this.CirnoUniform;
		this.MyRenderer.materials[1].mainTexture = this.CirnoUniform;
		this.MyRenderer.materials[2].mainTexture = this.CirnoFace;
		this.CirnoWings.SetActive(true);
		this.CirnoHair.SetActive(true);
		this.IdleAnim = "f02_cirnoIdle_00";
		this.WalkAnim = "f02_cirnoWalk_00";
		this.RunAnim = "f02_cirnoRun_00";
		this.EasterEggMenu.SetActive(false);
		this.Stance.Current = StanceType.Standing;
		this.Uncrouch();
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	// Token: 0x06001FFC RID: 8188 RVA: 0x001D3C64 File Offset: 0x001D1E64
	private void Falcon()
	{
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.FalconFace;
		this.MyRenderer.materials[1].mainTexture = this.FalconBody;
		this.MyRenderer.materials[2].mainTexture = this.FalconBody;
		this.FalconShoulderpad.SetActive(true);
		this.FalconKneepad1.SetActive(true);
		this.FalconKneepad2.SetActive(true);
		this.FalconBuckle.SetActive(true);
		this.FalconHelmet.SetActive(true);
		this.CharacterAnimation[this.RunAnim].speed = 5f;
		this.IdleAnim = "f02_falconIdle_00";
		this.RunSpeed *= 5f;
		this.Egg = true;
		this.Hairstyle = 3;
		this.UpdateHair();
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	// Token: 0x06001FFD RID: 8189 RVA: 0x001D3DB8 File Offset: 0x001D1FB8
	private void Punch()
	{
		this.MusicCredit.SongLabel.text = "Now Playing: Unknown Hero";
		this.MusicCredit.BandLabel.text = "By: The Kira Justice";
		this.MusicCredit.Panel.enabled = true;
		this.MusicCredit.Slide = true;
		this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.SaitamaSuit;
		this.MyRenderer.materials[1].mainTexture = this.SaitamaSuit;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		this.EasterEggMenu.SetActive(false);
		this.Barcode.SetActive(false);
		this.Cape.SetActive(true);
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	// Token: 0x06001FFE RID: 8190 RVA: 0x001D3F00 File Offset: 0x001D2100
	private void BadTime()
	{
		this.MyRenderer.sharedMesh = this.Jersey;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.SansFace;
		this.MyRenderer.materials[1].mainTexture = this.SansTexture;
		this.MyRenderer.materials[2].mainTexture = this.SansTexture;
		this.EasterEggMenu.SetActive(false);
		this.IdleAnim = "f02_sansIdle_00";
		this.WalkAnim = "f02_sansWalk_00";
		this.RunAnim = "f02_sansRun_00";
		this.StudentManager.BadTime();
		this.Barcode.SetActive(false);
		this.Sans = true;
		this.Egg = true;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().EasterEggCheck();
	}

	// Token: 0x06001FFF RID: 8191 RVA: 0x001D4028 File Offset: 0x001D2228
	private void CyborgNinja()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.EnergySword.SetActive(true);
		this.IdleAnim = "CyborgNinja_Idle_Unarmed";
		this.RunAnim = "CyborgNinja_Run_Unarmed";
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.CyborgFace;
		this.MyRenderer.materials[1].mainTexture = this.CyborgBody;
		this.MyRenderer.materials[2].mainTexture = this.CyborgBody;
		this.Schoolwear = 0;
		this.ID = 1;
		while (this.ID < this.CyborgParts.Length)
		{
			this.CyborgParts[this.ID].SetActive(true);
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < this.StudentManager.Students.Length)
		{
			StudentScript studentScript = this.StudentManager.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Teacher = false;
			}
			this.ID++;
		}
		this.RunSpeed *= 2f;
		this.EyewearID = 6;
		this.Hairstyle = 45;
		this.UpdateHair();
		this.Ninja = true;
		this.Egg = true;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	// Token: 0x06002000 RID: 8192 RVA: 0x001D41D8 File Offset: 0x001D23D8
	private void Ebola()
	{
		this.StudentManager.Ebola = true;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.IdleAnim = "f02_ebolaIdle_00";
		this.Nude();
		this.MyRenderer.enabled = false;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.EbolaAttacher.SetActive(true);
		this.EbolaWings.SetActive(true);
		this.EbolaHair.SetActive(true);
		this.Egg = true;
	}

	// Token: 0x06002001 RID: 8193 RVA: 0x001D428F File Offset: 0x001D248F
	private void Long()
	{
		this.MyRenderer.sharedMesh = this.LongUniform;
	}

	// Token: 0x06002002 RID: 8194 RVA: 0x001D42A4 File Offset: 0x001D24A4
	private void SwapMesh()
	{
		this.MyRenderer.sharedMesh = this.NewMesh;
		this.MyRenderer.materials[0].mainTexture = this.TextureToUse;
		this.MyRenderer.materials[1].mainTexture = this.NewFace;
		this.MyRenderer.materials[2].mainTexture = this.TextureToUse;
		this.RightYandereEye.gameObject.SetActive(false);
		this.LeftYandereEye.gameObject.SetActive(false);
	}

	// Token: 0x06002003 RID: 8195 RVA: 0x001D432C File Offset: 0x001D252C
	private void Nude()
	{
		Debug.Log("Making Yandere-chan nude.");
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.ID = 0;
		while (this.ID < this.CensorSteam.Length)
		{
			this.ID++;
		}
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
		this.EasterEggMenu.SetActive(false);
		this.ClubAttire = false;
		this.Schoolwear = 0;
		if (this.StudentManager.Eighties)
		{
			for (int i = 0; i < 13; i++)
			{
				this.MyRenderer.SetBlendShapeWeight(i, 0f);
			}
		}
		this.ClubAccessory();
	}

	// Token: 0x06002004 RID: 8196 RVA: 0x001D4468 File Offset: 0x001D2668
	private void Samus()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.SamusFace;
		this.MyRenderer.materials[1].mainTexture = this.SamusBody;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.PonytailRenderer.material.mainTexture = this.SamusFace;
		this.Egg = true;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	// Token: 0x06002005 RID: 8197 RVA: 0x001D4540 File Offset: 0x001D2740
	private void Witch()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.WitchFace;
		this.MyRenderer.materials[1].mainTexture = this.WitchBody;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.IdleAnim = "f02_idleElegant_00";
		this.WalkAnim = "f02_jojoWalk_00";
		this.WitchMode = true;
		this.Egg = true;
		this.Hairstyle = 100;
		this.UpdateHair();
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	// Token: 0x06002006 RID: 8198 RVA: 0x001D462A File Offset: 0x001D282A
	private void Pose()
	{
		if (!this.StudentManager.Pose)
		{
			this.StudentManager.Pose = true;
		}
		else
		{
			this.StudentManager.Pose = false;
		}
		this.StudentManager.UpdateStudents(0);
	}

	// Token: 0x06002007 RID: 8199 RVA: 0x001D465F File Offset: 0x001D285F
	private void HairBlades()
	{
		this.Hairstyle = 0;
		this.UpdateHair();
		this.BladeHair.SetActive(true);
		this.Egg = true;
	}

	// Token: 0x06002008 RID: 8200 RVA: 0x001D4684 File Offset: 0x001D2884
	private void Tornado()
	{
		this.Hairstyle = 0;
		this.UpdateHair();
		this.IdleAnim = "f02_tornadoIdle_00";
		this.WalkAnim = "f02_tornadoWalk_00";
		this.RunAnim = "f02_tornadoRun_00";
		this.TornadoHair.SetActive(true);
		this.TornadoDress.SetActive(true);
		this.RiggedAccessory.SetActive(true);
		this.MyRenderer.sharedMesh = this.NoTorsoMesh;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.Sanity = 100f;
		this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudePanties;
		this.MyRenderer.materials[2].mainTexture = this.NudePanties;
		this.TheDebugMenuScript.UpdateCensor();
		this.Stance.Current = StanceType.Standing;
		this.Egg = true;
	}

	// Token: 0x06002009 RID: 8201 RVA: 0x001D47B0 File Offset: 0x001D29B0
	private void GenderSwap()
	{
		this.Kun.SetActive(true);
		this.KunHair.SetActive(true);
		this.MyRenderer.enabled = false;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.IdleAnim = "idleShort_00";
		this.WalkAnim = "walk_00";
		this.RunAnim = "newSprint_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	// Token: 0x0600200A RID: 8202 RVA: 0x001D487C File Offset: 0x001D2A7C
	private void Mandere()
	{
		this.Man.SetActive(true);
		this.Barcode.SetActive(false);
		this.MyRenderer.enabled = false;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.RightYandereEye.gameObject.SetActive(false);
		this.LeftYandereEye.gameObject.SetActive(false);
		this.IdleAnim = "idleShort_00";
		this.WalkAnim = "walk_00";
		this.RunAnim = "newSprint_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.Hairstyle = 0;
		this.UpdateHair();
	}

	// Token: 0x0600200B RID: 8203 RVA: 0x001D496C File Offset: 0x001D2B6C
	private void BlackHoleChan()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.BlackHoleFace;
		this.MyRenderer.materials[1].mainTexture = this.Black;
		this.MyRenderer.materials[2].mainTexture = this.Black;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.IdleAnim = "f02_gazerIdle_00";
		this.WalkAnim = "f02_gazerWalk_00";
		this.RunAnim = "f02_gazerRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.Hairstyle = 182;
		this.UpdateHair();
		this.BlackHoleEffects.SetActive(true);
		this.BlackHole = true;
		this.Egg = true;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	// Token: 0x0600200C RID: 8204 RVA: 0x001D4AAC File Offset: 0x001D2CAC
	private void ElfenLied()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		GameObject[] vectors = this.Vectors;
		for (int i = 0; i < vectors.Length; i++)
		{
			vectors[i].SetActive(true);
		}
		this.IdleAnim = "f02_sixIdle_00";
		this.WalkAnim = "f02_sixWalk_00";
		this.RunAnim = "f02_sixRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.LucyHelmet.SetActive(true);
		this.Bandages.SetActive(true);
		this.Egg = true;
		this.WalkSpeed = 0.75f;
		this.RunSpeed = 2f;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	// Token: 0x0600200D RID: 8205 RVA: 0x001D4C0C File Offset: 0x001D2E0C
	private void Ghoul()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.GhoulFace;
		this.MyRenderer.materials[1].mainTexture = this.GhoulBody;
		this.MyRenderer.materials[2].mainTexture = this.GhoulBody;
		GameObject[] kagune = this.Kagune;
		for (int i = 0; i < kagune.Length; i++)
		{
			kagune[i].SetActive(true);
		}
		this.IdleAnim = "f02_sixIdle_00";
		this.WalkAnim = "f02_sixWalk_00";
		this.RunAnim = "f02_psychoRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.StudentManager.Six = true;
		this.StudentManager.UpdateStudents(0);
		this.Egg = true;
		this.WalkSpeed = 0.75f;
		this.RunSpeed = 10f;
		this.Hairstyle = 15;
		this.UpdateHair();
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	// Token: 0x0600200E RID: 8206 RVA: 0x001D4D6C File Offset: 0x001D2F6C
	private void Berserk()
	{
		SchoolGlobals.SchoolAtmosphere = 0.5f;
		this.StudentManager.SetAtmosphere();
		GameObject[] armor = this.Armor;
		for (int i = 0; i < armor.Length; i++)
		{
			armor[i].SetActive(true);
		}
		Renderer[] trees = this.StudentManager.Trees;
		for (int i = 0; i < trees.Length; i++)
		{
			trees[i].materials[1] = this.Trans;
		}
		this.SithSpawnTime = this.NierSpawnTime;
		this.SithHardSpawnTime1 = this.NierHardSpawnTime;
		this.SithHardSpawnTime2 = this.NierHardSpawnTime;
		this.SithAudio.clip = this.NierSwoosh;
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.Scarface;
		this.MyRenderer.materials[1].mainTexture = this.Chainmail;
		this.MyRenderer.materials[2].mainTexture = this.Chainmail;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.TheDebugMenuScript.UpdateCensor();
		this.IdleAnim = "f02_heroicIdle_00";
		this.WalkAnim = "f02_walkConfident_00";
		this.RunAnim = "f02_nierRun_00";
		this.CharacterAnimation["f02_nierRun_00"].speed = 1f;
		this.CharacterAnimation["f02_gutsEye_00"].weight = 1f;
		this.RunSpeed = 7.5f;
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.Hairstyle = 188;
		this.UpdateHair();
		this.Egg = true;
	}

	// Token: 0x0600200F RID: 8207 RVA: 0x001D4F24 File Offset: 0x001D3124
	private void Sith()
	{
		this.Hairstyle = 67;
		this.UpdateHair();
		this.SithTrail1.SetActive(true);
		this.SithTrail2.SetActive(true);
		this.IdleAnim = "f02_sithIdle_00";
		this.WalkAnim = "f02_sithWalk_00";
		this.RunAnim = "f02_sithRun_00";
		this.BlackRobe.SetActive(true);
		this.MyRenderer.sharedMesh = this.NoUpperBodyMesh;
		this.MyRenderer.materials[0].mainTexture = this.NudePanties;
		this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudePanties;
		this.Stance.Current = StanceType.Standing;
		this.FollowHips = true;
		this.SithLord = true;
		this.Egg = true;
		this.Police.Clock.CameraEffects.Profile.depthOfField.enabled = false;
		this.TheDebugMenuScript.UpdateCensor();
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.RunSpeed *= 2f;
		this.Zoom.TargetZoom = 0.4f;
	}

	// Token: 0x06002010 RID: 8208 RVA: 0x001D5094 File Offset: 0x001D3294
	private void Snake()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = this.Uniforms[1];
		this.MyRenderer.materials[0].mainTexture = this.SnakeBody;
		this.MyRenderer.materials[1].mainTexture = this.SnakeBody;
		this.MyRenderer.materials[2].mainTexture = this.SnakeFace;
		this.Hairstyle = 161;
		this.UpdateHair();
		this.Medusa = true;
		this.Egg = true;
	}

	// Token: 0x06002011 RID: 8209 RVA: 0x001D5164 File Offset: 0x001D3364
	private void Gazer()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.GazerEyes.gameObject.SetActive(true);
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.GazerFace;
		this.MyRenderer.materials[1].mainTexture = this.GazerBody;
		this.MyRenderer.materials[2].mainTexture = this.GazerBody;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.IdleAnim = "f02_gazerIdle_00";
		this.WalkAnim = "f02_gazerWalk_00";
		this.RunAnim = "f02_gazerRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.Hairstyle = 158;
		this.UpdateHair();
		this.StudentManager.Gaze = true;
		this.StudentManager.UpdateStudents(0);
		this.Gazing = true;
		this.Egg = true;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	// Token: 0x06002012 RID: 8210 RVA: 0x001D52C4 File Offset: 0x001D34C4
	private void Six()
	{
		RenderSettings.skybox = this.HatefulSkybox;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.IdleAnim = "f02_sixIdle_00";
		this.WalkAnim = "f02_sixWalk_00";
		this.RunAnim = "f02_sixRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.SixRaincoat.SetActive(true);
		this.MyRenderer.sharedMesh = this.SixBodyMesh;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.SixFaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		this.TheDebugMenuScript.UpdateCensor();
		SchoolGlobals.SchoolAtmosphere = 0f;
		this.StudentManager.SetAtmosphere();
		this.StudentManager.Six = true;
		this.StudentManager.UpdateStudents(0);
		this.StudentManager.DepowerStudentCouncil();
		this.WalkSpeed = 0.75f;
		this.RunSpeed = 2f;
		this.Hungry = true;
		this.Egg = true;
		this.StudentManager.Students[1].Blind = true;
	}

	// Token: 0x06002013 RID: 8211 RVA: 0x001D5458 File Offset: 0x001D3658
	public void WearRaincoat()
	{
		Debug.Log("Yandere-chan is now firing the WearRaincoat() function.");
		if (!this.StudentManager.Eighties)
		{
			this.Hairstyle = 200;
		}
		else
		{
			this.Hairstyle = 204;
		}
		this.UpdateHair();
		this.RaincoatAttacher.gameObject.SetActive(true);
		this.MyRenderer.sharedMesh = this.HeadAndKnees;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		this.TheDebugMenuScript.UpdateCensor();
	}

	// Token: 0x06002014 RID: 8212 RVA: 0x001D5558 File Offset: 0x001D3758
	private void KLK()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.KLKSword.SetActive(true);
		this.IdleAnim = "f02_heroicIdle_00";
		this.WalkAnim = "f02_walkConfident_00";
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.KLKFace;
		this.MyRenderer.materials[1].mainTexture = this.KLKBody;
		this.MyRenderer.materials[2].mainTexture = this.KLKBody;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.ID = 0;
		while (this.ID < this.KLKParts.Length)
		{
			this.KLKParts[this.ID].SetActive(true);
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < this.StudentManager.Students.Length)
		{
			StudentScript studentScript = this.StudentManager.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Teacher = false;
			}
			this.ID++;
		}
		this.Egg = true;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	// Token: 0x06002015 RID: 8213 RVA: 0x001D56DC File Offset: 0x001D38DC
	public void Miyuki()
	{
		this.MiyukiCostume.SetActive(true);
		this.MiyukiWings.SetActive(true);
		this.IdleAnim = "f02_idleGirly_00";
		this.WalkAnim = "f02_walkGirly_00";
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.MiyukiFace;
		this.MyRenderer.materials[1].mainTexture = this.MiyukiSkin;
		this.MyRenderer.materials[2].mainTexture = this.MiyukiSkin;
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.TheDebugMenuScript.UpdateCensor();
		this.Jukebox.MiyukiMusic();
		this.Hairstyle = 171;
		this.UpdateHair();
		this.MagicalGirl = true;
		this.Egg = true;
	}

	// Token: 0x06002016 RID: 8214 RVA: 0x001D57CC File Offset: 0x001D39CC
	public void AzurLane()
	{
		this.Schoolwear = 2;
		this.ChangeSchoolwear();
		this.PantyAttacher.newRenderer.enabled = false;
		this.IdleAnim = "f02_gazerIdle_00";
		this.WalkAnim = "f02_gazerWalk_00";
		this.RunAnim = "f02_gazerRun_00";
		this.OriginalIdleAnim = this.IdleAnim;
		this.OriginalWalkAnim = this.WalkAnim;
		this.OriginalRunAnim = this.RunAnim;
		this.AzurGuns.SetActive(true);
		this.AzurWater.SetActive(true);
		this.AzurMist.SetActive(true);
		this.Shipgirl = true;
		this.CanMove = true;
		this.Egg = true;
		this.Jukebox.Shipgirl();
	}

	// Token: 0x06002017 RID: 8215 RVA: 0x001D5880 File Offset: 0x001D3A80
	private void GarbageMode()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.sharedMesh = null;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.GarbageBag.SetActive(true);
		this.ID = 1;
		while (this.ID < 101)
		{
			if (this.StudentManager.Students[this.ID] != null && this.StudentManager.Students[this.ID].gameObject.activeInHierarchy)
			{
				this.StudentManager.Students[this.ID].Cosmetic.HairRenderer.gameObject.SetActive(false);
				this.StudentManager.Students[this.ID].MyRenderer.enabled = false;
				this.StudentManager.Students[this.ID].GarbageBag.SetActive(true);
			}
			this.ID++;
		}
	}

	// Token: 0x06002018 RID: 8216 RVA: 0x001D5984 File Offset: 0x001D3B84
	private void TallMode()
	{
		SchoolGlobals.SchoolAtmosphere = 0.5f;
		this.StudentManager.SetAtmosphere();
		this.TallLadyAttacher.SetActive(true);
		this.BlackRose.SetActive(true);
		this.FloppyHat.SetActive(true);
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.sharedMesh = null;
		this.Hairstyle = 201;
		this.UpdateHair();
		this.IdleAnim = "f02_idleGraceful_00";
		this.WalkAnim = "f02_walkGraceful_00";
		this.OriginalIdleAnim = "f02_idleGraceful_00";
		this.OriginalWalkAnim = "f02_walkGraceful_00";
		this.CharacterAnimation["f02_sithAttack_00"].speed = 1f;
		this.CharacterAnimation["f02_sithAttack_01"].speed = 1f;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
		base.transform.localScale = new Vector3(1.27f, 1.27f, 1.27f);
		this.RightBreast.localScale = new Vector3(1.5f, 1.5f, 1.5f);
		this.LeftBreast.localScale = new Vector3(1.5f, 1.5f, 1.5f);
		this.BoobPhysics[0].enabled = true;
		this.BoobPhysics[1].enabled = true;
		this.Egg = true;
	}

	// Token: 0x06002019 RID: 8217 RVA: 0x001D5AF4 File Offset: 0x001D3CF4
	private void HollowMode()
	{
		RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
		RenderSettings.skybox = this.HorrorSkybox;
		SchoolGlobals.SchoolAtmosphere = 0f;
		this.StudentManager.SetAtmosphere();
		this.HollowCloakAttacher.SetActive(true);
		this.HollowSword.SetActive(true);
		this.HollowMask.SetActive(true);
		this.DarkParticles.SetActive(true);
		this.MyRenderer.sharedMesh = this.NoButtMesh;
		this.MyRenderer.materials[0].mainTexture = this.HollowFaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.HollowBodyTexture;
		this.Hairstyle = 0;
		this.UpdateHair();
		this.RunAnim = "f02_nierRun_00";
		this.CharacterAnimation["f02_nierRun_00"].speed = 1f;
		this.RunSpeed = 7.5f;
		this.CharacterAnimation["f02_sithAttack_00"].speed = 1f;
		this.CharacterAnimation["f02_sithAttack_01"].speed = 1f;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
		this.PantyAttacher.newRenderer.enabled = false;
		this.HollowFilter.enabled = true;
		this.Invisible = true;
		this.ID = 1;
		while (this.ID < this.StudentManager.Students.Length)
		{
			StudentScript studentScript = this.StudentManager.Students[this.ID];
			if (studentScript != null)
			{
				studentScript.Teacher = false;
			}
			this.ID++;
		}
		this.Egg = true;
	}

	// Token: 0x0600201A RID: 8218 RVA: 0x001D5CB0 File Offset: 0x001D3EB0
	private void Blacklight()
	{
		this.BlacklightShader.enabled = true;
		this.Hairstyle = 196;
		this.UpdateHair();
		this.IdleAnim = "f02_idleElegant_00";
		this.WalkAnim = "f02_jojoWalk_00";
		this.OriginalIdleAnim = "f02_idleElegant_00";
		this.OriginalWalkAnim = "f02_jojoWalk_00";
		this.BlacklightOutfit.SetActive(true);
		this.MyRenderer.sharedMesh = this.BlacklightBodyMesh;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		this.Egg = true;
	}

	// Token: 0x0600201B RID: 8219 RVA: 0x001D5DBC File Offset: 0x001D3FBC
	public void Weather()
	{
		if (!this.Rain.activeInHierarchy)
		{
			SchoolGlobals.SchoolAtmosphere = 0f;
			this.StudentManager.SetAtmosphere();
			this.Rain.SetActive(true);
			this.Jukebox.Start();
			return;
		}
		this.Hairstyle = 67;
		this.UpdateHair();
		this.RaincoatAttacher.gameObject.SetActive(true);
		this.MyRenderer.sharedMesh = this.SixBodyMesh;
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
		this.TheDebugMenuScript.UpdateCensor();
	}

	// Token: 0x0600201C RID: 8220 RVA: 0x001D5ED0 File Offset: 0x001D40D0
	private void Horror()
	{
		this.Rain.SetActive(false);
		RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
		RenderSettings.skybox = this.HorrorSkybox;
		SchoolGlobals.SchoolAtmosphere = 0f;
		this.StudentManager.SetAtmosphere();
		this.RPGCamera.desiredDistance = 0.33333f;
		this.Zoom.OverShoulder = true;
		this.Zoom.TargetZoom = 0.2f;
		this.PauseScreen.MissionMode.FPS.transform.localPosition = new Vector3(1020f, -465f, 0f);
		this.PauseScreen.MissionMode.Watermark.gameObject.SetActive(false);
		this.PauseScreen.MissionMode.Nemesis.SetActive(true);
		this.StudentManager.Clock.MainLight.color = new Color(0.5f, 0.5f, 0.5f, 1f);
		this.StudentManager.Clock.gameObject.SetActive(false);
		this.StudentManager.Clock.SunFlare.SetActive(false);
		this.StudentManager.Clock.Horror = true;
		this.StudentManager.Students[1].transform.position = new Vector3(0f, 0f, 0f);
		this.StudentManager.Headmaster.gameObject.SetActive(false);
		this.StudentManager.Reputation.gameObject.SetActive(false);
		this.StudentManager.Flashlight.gameObject.SetActive(true);
		this.StudentManager.Flashlight.BePickedUp();
		this.StudentManager.DelinquentRadio.SetActive(false);
		this.StudentManager.CounselorDoor[0].enabled = false;
		this.StudentManager.CounselorDoor[1].enabled = false;
		this.StudentManager.CounselorDoor[0].Prompt.enabled = false;
		this.StudentManager.CounselorDoor[1].Prompt.enabled = false;
		this.StudentManager.Portal.SetActive(false);
		RenderSettings.ambientLight = new Color(0.1f, 0.1f, 0.1f);
		this.ID = 1;
		while (this.ID < 101)
		{
			if (this.StudentManager.Students[this.ID] != null && this.StudentManager.Students[this.ID].gameObject.activeInHierarchy)
			{
				this.StudentManager.DisableStudent(this.ID);
			}
			this.ID++;
		}
		this.Egg = true;
	}

	// Token: 0x0600201D RID: 8221 RVA: 0x001D6198 File Offset: 0x001D4398
	private void LifeNote()
	{
		this.ID = 1;
		while (this.ID < 101)
		{
			StudentGlobals.SetStudentPhotographed(this.ID, true);
			this.ID++;
		}
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.LifeNotebook.transform.position = base.transform.position + base.transform.forward + new Vector3(0f, 2.5f, 0f);
		this.LifeNotebook.GetComponent<Rigidbody>().useGravity = true;
		this.LifeNotebook.GetComponent<Rigidbody>().isKinematic = false;
		this.LifeNotebook.gameObject.SetActive(true);
		this.MyRenderer.sharedMesh = this.YamikoMesh;
		this.MyRenderer.materials[0].mainTexture = this.YamikoSkinTexture;
		this.MyRenderer.materials[1].mainTexture = this.YamikoAccessoryTexture;
		this.MyRenderer.materials[2].mainTexture = this.YamikoFaceTexture;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.Hairstyle = 180;
		this.UpdateHair();
		this.StudentManager.NoteWindow.BecomeLifeNote();
		this.Egg = true;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	// Token: 0x0600201E RID: 8222 RVA: 0x001D6334 File Offset: 0x001D4534
	private void Nier()
	{
		this.NierCostume.SetActive(true);
		this.HeavySwordParent.gameObject.SetActive(true);
		this.LightSwordParent.gameObject.SetActive(true);
		this.HeavySword.GetComponent<WeaponTrail>().Start();
		this.LightSword.GetComponent<WeaponTrail>().Start();
		this.HeavySword.GetComponent<WeaponTrail>().enabled = false;
		this.LightSword.GetComponent<WeaponTrail>().enabled = false;
		this.Pod.SetActive(true);
		this.SithSpawnTime = this.NierSpawnTime;
		this.SithHardSpawnTime1 = this.NierHardSpawnTime;
		this.SithHardSpawnTime2 = this.NierHardSpawnTime;
		this.SithAudio.clip = this.NierSwoosh;
		this.Pod.transform.parent = null;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.sharedMesh = null;
		this.PantyAttacher.newRenderer.enabled = false;
		this.Schoolwear = 0;
		this.Hairstyle = 181;
		this.UpdateHair();
		this.Egg = true;
		this.IdleAnim = "f02_heroicIdle_00";
		this.WalkAnim = "f02_walkGraceful_00";
		this.RunAnim = "f02_nierRun_00";
		this.RunSpeed = 10f;
		this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().UpdateCensor();
	}

	// Token: 0x0600201F RID: 8223 RVA: 0x001D64C0 File Offset: 0x001D46C0
	public void WearChinaDress()
	{
		this.EbolaHair.SetActive(false);
		this.EbolaWings.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
		this.EbolaWings.GetComponent<Renderer>().material.SetColor("_OutlineColor", new Color(0f, 0f, 0f));
		this.Hairstyle = 1;
		this.UpdateHair();
		this.ChinaDress.SetActive(true);
		this.Nude();
		this.PantyAttacher.newRenderer.enabled = true;
	}

	// Token: 0x06002020 RID: 8224 RVA: 0x001D6560 File Offset: 0x001D4760
	private void Vaporwave()
	{
		this.VaporwaveVisuals.ApplyNormalView();
		RenderSettings.skybox = this.VaporwaveSkybox;
		this.PalmTrees.SetActive(true);
		for (int i = 1; i < this.Trees.Length; i++)
		{
			this.Trees[i].SetActive(false);
		}
	}

	// Token: 0x06002021 RID: 8225 RVA: 0x001D65B0 File Offset: 0x001D47B0
	public void ChangeSchoolwear()
	{
		if (this.StudentManager.Eighties)
		{
			this.RestoreGentleEyes();
			this.GymTexture = this.EightiesGymTexture;
		}
		this.PantyAttacher.newRenderer.enabled = false;
		this.RightFootprintSpawner.Bloodiness = 0;
		this.LeftFootprintSpawner.Bloodiness = 0;
		if (this.ClubAttire && this.Bloodiness == 0f)
		{
			this.Schoolwear = this.PreviousSchoolwear;
		}
		this.LabcoatAttacher.RemoveAccessory();
		this.Paint = false;
		this.ID = 0;
		while (this.ID < this.CensorSteam.Length)
		{
			this.CensorSteam[this.ID].SetActive(false);
			this.ID++;
		}
		if (this.Casual)
		{
			this.TextureToUse = this.UniformTextures[StudentGlobals.FemaleUniform];
		}
		else
		{
			this.TextureToUse = this.CasualTextures[StudentGlobals.FemaleUniform];
		}
		if ((this.ClubAttire && this.Bloodiness > 0f) || this.Schoolwear == 0)
		{
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			this.MyRenderer.sharedMesh = this.Towel;
			this.MyRenderer.materials[0].mainTexture = this.TowelTexture;
			this.MyRenderer.materials[1].mainTexture = this.TowelTexture;
			this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
			this.ClubAttire = false;
			this.Schoolwear = 0;
			if (this.StudentManager.Eighties)
			{
				for (int i = 0; i < 13; i++)
				{
					this.MyRenderer.SetBlendShapeWeight(i, 0f);
				}
			}
		}
		else if (this.Schoolwear == 1)
		{
			this.PantyAttacher.newRenderer.enabled = true;
			this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
			if (GameGlobals.CensorPanties)
			{
				Debug.Log("Activating shadows on Yandere-chan.");
				this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
				this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
				this.PantyAttacher.newRenderer.enabled = false;
			}
			this.MyRenderer.materials[0].mainTexture = this.TextureToUse;
			this.MyRenderer.materials[1].mainTexture = this.TextureToUse;
			this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
			base.StartCoroutine(this.ApplyCustomCostume());
		}
		else if (this.Schoolwear == 2)
		{
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
			this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
			this.MyRenderer.materials[1].mainTexture = this.SwimsuitTexture;
			this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		}
		else if (this.Schoolwear == 3)
		{
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
			this.MyRenderer.sharedMesh = this.GymUniform;
			this.MyRenderer.materials[0].mainTexture = this.GymTexture;
			this.MyRenderer.materials[1].mainTexture = this.GymTexture;
			this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		}
		this.CanMove = false;
		this.Outline.h.ReinitMaterials();
		this.ClubAccessory();
	}

	// Token: 0x06002022 RID: 8226 RVA: 0x001D6AB8 File Offset: 0x001D4CB8
	public void ChangeClubwear()
	{
		this.PantyAttacher.newRenderer.enabled = false;
		this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
		this.Paint = false;
		if (!this.ClubAttire)
		{
			this.ClubAttire = true;
			if (this.Club == ClubType.Art)
			{
				this.MyRenderer.sharedMesh = this.ApronMesh;
				this.MyRenderer.materials[0].mainTexture = this.ApronTexture;
				this.MyRenderer.materials[1].mainTexture = this.ApronTexture;
				this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				this.Schoolwear = 4;
				this.Paint = true;
			}
			else if (this.Club == ClubType.MartialArts)
			{
				this.MyRenderer.sharedMesh = this.JudoGiMesh;
				this.MyRenderer.materials[0].mainTexture = this.JudoGiTexture;
				this.MyRenderer.materials[1].mainTexture = this.JudoGiTexture;
				this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				this.Schoolwear = 5;
			}
			else if (this.Club == ClubType.Science)
			{
				this.LabcoatAttacher.enabled = true;
				this.MyRenderer.sharedMesh = this.HeadAndHands;
				if (this.LabcoatAttacher.Initialized)
				{
					this.LabcoatAttacher.AttachAccessory();
				}
				this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
				this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
				this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
				this.Schoolwear = 6;
			}
		}
		else
		{
			this.ChangeSchoolwear();
			this.ClubAttire = false;
		}
		this.MyLocker.UpdateButtons();
	}

	// Token: 0x06002023 RID: 8227 RVA: 0x001D6CEC File Offset: 0x001D4EEC
	public void ClubAccessory()
	{
		this.ID = 0;
		while (this.ID < this.ClubAccessories.Length)
		{
			GameObject gameObject = this.ClubAccessories[this.ID];
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
			this.ID++;
		}
		if (!this.CensorSteam[0].activeInHierarchy && this.Club > ClubType.None && this.ClubAccessories[(int)this.Club] != null)
		{
			this.ClubAccessories[(int)this.Club].SetActive(true);
		}
	}

	// Token: 0x06002024 RID: 8228 RVA: 0x001D6D80 File Offset: 0x001D4F80
	public void StopCarrying()
	{
		this.CurrentRagdoll = null;
		if (this.Ragdoll != null)
		{
			this.Ragdoll.GetComponent<RagdollScript>().Fall();
		}
		this.HeavyWeight = false;
		this.Carrying = false;
		this.IdleAnim = this.OriginalIdleAnim;
		this.WalkAnim = this.OriginalWalkAnim;
		this.RunAnim = this.OriginalRunAnim;
	}

	// Token: 0x06002025 RID: 8229 RVA: 0x001D6DE4 File Offset: 0x001D4FE4
	private void Crouch()
	{
		this.MyController.center = new Vector3(this.MyController.center.x, 0.55f, this.MyController.center.z);
		this.MyController.height = 0.9f;
	}

	// Token: 0x06002026 RID: 8230 RVA: 0x001D6E38 File Offset: 0x001D5038
	private void Crawl()
	{
		this.MyController.center = new Vector3(this.MyController.center.x, 0.25f, this.MyController.center.z);
		this.MyController.height = 0.1f;
	}

	// Token: 0x06002027 RID: 8231 RVA: 0x001D6E8C File Offset: 0x001D508C
	public void Uncrouch()
	{
		this.MyController.center = new Vector3(this.MyController.center.x, 0.875f, this.MyController.center.z);
		this.MyController.height = 1.55f;
	}

	// Token: 0x06002028 RID: 8232 RVA: 0x001D6EE0 File Offset: 0x001D50E0
	private void StopArmedAnim()
	{
		this.ID = 0;
		while (this.ID < this.ArmedAnims.Length)
		{
			string name = this.ArmedAnims[this.ID];
			this.CharacterAnimation[name].weight = Mathf.Lerp(this.CharacterAnimation[name].weight, 0f, Time.deltaTime * 10f);
			this.ID++;
		}
	}

	// Token: 0x06002029 RID: 8233 RVA: 0x001D6F5C File Offset: 0x001D515C
	public void UpdateAccessory()
	{
		if (this.AccessoryGroup != null)
		{
			this.AccessoryGroup.SetPartsActive(false);
		}
		if (this.AccessoryID > this.Accessories.Length - 1)
		{
			this.AccessoryID = 0;
		}
		if (this.AccessoryID < 0)
		{
			this.AccessoryID = this.Accessories.Length - 1;
		}
		if (this.AccessoryID > 0)
		{
			this.Accessories[this.AccessoryID].SetActive(true);
			this.AccessoryGroup = this.Accessories[this.AccessoryID].GetComponent<AccessoryGroupScript>();
			if (this.AccessoryGroup != null)
			{
				this.AccessoryGroup.SetPartsActive(true);
			}
		}
	}

	// Token: 0x0600202A RID: 8234 RVA: 0x001D7004 File Offset: 0x001D5204
	private void DisableHairAndAccessories()
	{
		this.ID = 1;
		while (this.ID < this.Accessories.Length)
		{
			this.Accessories[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < this.Hairstyles.Length)
		{
			this.Hairstyles[this.ID].SetActive(false);
			this.ID++;
		}
	}

	// Token: 0x0600202B RID: 8235 RVA: 0x001D7088 File Offset: 0x001D5288
	public void BullyPhotoCheck()
	{
		Debug.Log("We are now going to perform a bully photo check.");
		for (int i = 1; i < 26; i++)
		{
			if (PlayerGlobals.GetPhoto(i) && PlayerGlobals.GetBullyPhoto(i) > 0)
			{
				Debug.Log("Yandere-chan has a bully photo in her photo gallery!");
				this.BullyPhoto = true;
			}
		}
	}

	// Token: 0x0600202C RID: 8236 RVA: 0x001D70D0 File Offset: 0x001D52D0
	public void UpdatePersona(int NewPersona)
	{
		switch (NewPersona)
		{
		case 0:
			this.Persona = YanderePersonaType.Default;
			return;
		case 1:
			this.Persona = YanderePersonaType.Chill;
			return;
		case 2:
			this.Persona = YanderePersonaType.Confident;
			return;
		case 3:
			this.Persona = YanderePersonaType.Elegant;
			return;
		case 4:
			this.Persona = YanderePersonaType.Girly;
			return;
		case 5:
			this.Persona = YanderePersonaType.Graceful;
			return;
		case 6:
			this.Persona = YanderePersonaType.Haughty;
			return;
		case 7:
			this.Persona = YanderePersonaType.Lively;
			return;
		case 8:
			this.Persona = YanderePersonaType.Scholarly;
			return;
		case 9:
			this.Persona = YanderePersonaType.Shy;
			return;
		case 10:
			this.Persona = YanderePersonaType.Tough;
			return;
		case 11:
			this.Persona = YanderePersonaType.Aggressive;
			return;
		case 12:
			this.Persona = YanderePersonaType.Grunt;
			return;
		default:
			return;
		}
	}

	// Token: 0x0600202D RID: 8237 RVA: 0x001D7184 File Offset: 0x001D5384
	private void SithSoundCheck()
	{
		if (this.SithBeam[1].Damage == 10f || this.NierDamage == 10f)
		{
			if (this.SithSounds == 0 && this.CharacterAnimation[string.Concat(new string[]
			{
				"f02_",
				this.AttackPrefix,
				"Attack",
				this.SithPrefix,
				"_0",
				this.SithCombo.ToString()
			})].time >= this.SithSpawnTime[this.SithCombo] - 0.1f)
			{
				this.SithAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
				this.SithAudio.Play();
				this.SithSounds++;
				return;
			}
		}
		else if (this.SithSounds == 0)
		{
			if (this.CharacterAnimation[string.Concat(new string[]
			{
				"f02_",
				this.AttackPrefix,
				"Attack",
				this.SithPrefix,
				"_0",
				this.SithCombo.ToString()
			})].time >= this.SithHardSpawnTime1[this.SithCombo] - 0.1f)
			{
				this.SithAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
				this.SithAudio.Play();
				this.SithSounds++;
				return;
			}
		}
		else if (this.SithSounds == 1)
		{
			if (this.CharacterAnimation[string.Concat(new string[]
			{
				"f02_",
				this.AttackPrefix,
				"Attack",
				this.SithPrefix,
				"_0",
				this.SithCombo.ToString()
			})].time >= this.SithHardSpawnTime2[this.SithCombo] - 0.1f)
			{
				this.SithAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
				this.SithAudio.Play();
				this.SithSounds++;
				return;
			}
		}
		else if (this.SithSounds == 2 && this.SithCombo == 1 && this.CharacterAnimation[string.Concat(new string[]
		{
			"f02_",
			this.AttackPrefix,
			"Attack",
			this.SithPrefix,
			"_0",
			this.SithCombo.ToString()
		})].time >= 0.8333333f)
		{
			this.SithAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
			this.SithAudio.Play();
			this.SithSounds++;
		}
	}

	// Token: 0x0600202E RID: 8238 RVA: 0x001D745C File Offset: 0x001D565C
	public void UpdateSelfieStatus()
	{
		if (this.Selfie)
		{
			if (this.Stance.Current == StanceType.Crawling)
			{
				this.Stance.Current = StanceType.Crouching;
			}
			this.Smartphone.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			this.UpdateAccessory();
			this.UpdateHair();
			this.HandCamera.gameObject.SetActive(false);
			this.Smartphone.targetTexture = null;
			this.MainCamera.enabled = false;
			this.Smartphone.cullingMask &= ~(1 << LayerMask.NameToLayer("Miyuki"));
			this.AR = false;
			return;
		}
		this.Smartphone.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		this.Smartphone.targetTexture = this.Shutter.SmartphoneScreen;
		this.HandCamera.gameObject.SetActive(true);
		this.SelfieGuide.SetActive(false);
		this.MainCamera.enabled = true;
		if (!this.StudentManager.Eighties)
		{
			this.Blur.enabled = true;
			return;
		}
		this.Blur.enabled = false;
	}

	// Token: 0x0600202F RID: 8239 RVA: 0x001D759A File Offset: 0x001D579A
	private void OnApplicationFocus(bool hasFocus)
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x06002030 RID: 8240 RVA: 0x001D75A2 File Offset: 0x001D57A2
	private void OnApplicationPause(bool pauseStatus)
	{
		Cursor.lockState = CursorLockMode.None;
	}

	// Token: 0x06002031 RID: 8241 RVA: 0x001D75AC File Offset: 0x001D57AC
	private void AddImpact(Vector3 dir, float force)
	{
		dir.Normalize();
		if (dir.y < 0f)
		{
			dir.y = -dir.y;
		}
		this.impact += dir.normalized * force / this.mass;
	}

	// Token: 0x170004CC RID: 1228
	// (get) Token: 0x06002032 RID: 8242 RVA: 0x001D7604 File Offset: 0x001D5804
	public int OnlyGroundLayer
	{
		get
		{
			return 256;
		}
	}

	// Token: 0x06002033 RID: 8243 RVA: 0x001D760C File Offset: 0x001D580C
	private void CheckForGround()
	{
		this.RaycastOrigin = this.Zoom.transform;
		Vector3 vector = this.RaycastOrigin.TransformDirection(Vector3.up * -1f);
		Debug.DrawRay(this.RaycastOrigin.position, vector, Color.green);
		if (Physics.Raycast(this.RaycastOrigin.position, vector, out this.hit, 1.1f, this.OnlyGroundLayer))
		{
			Debug.Log("Yandere-chan landed on the ground.");
			this.impact = Vector3.zero;
			this.Jumping = false;
			this.CanMove = true;
		}
	}

	// Token: 0x06002034 RID: 8244 RVA: 0x001D76A4 File Offset: 0x001D58A4
	private void UpdateODM()
	{
		if (this.Jumping && (this.CharacterAnimation["ODM_Jump"].time > 0.25f || this.CharacterAnimation["ODM_Slash"].time > 0f))
		{
			if (Input.GetButtonDown("X") && (this.CharacterAnimation["ODM_Slash"].time == 0f || this.CharacterAnimation["ODM_Slash"].time >= this.CharacterAnimation["ODM_Slash"].length))
			{
				AudioSource.PlayClipAtPoint(this.Swoosh, base.transform.position + Vector3.up);
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.TitanSlash, base.transform.position, Quaternion.identity);
				gameObject.name = "0";
				gameObject.transform.parent = this.Hips;
				gameObject.transform.localPosition = Vector3.zero;
				this.CharacterAnimation["ODM_Slash"].speed = 20f;
				this.CharacterAnimation["ODM_Slash"].time = 0f;
				this.CharacterAnimation.CrossFade("ODM_Slash", 0.1f);
				base.transform.localScale = new Vector3(base.transform.localScale.x * -1f, 1f, 1f);
			}
			if (this.CharacterAnimation["ODM_Slash"].time >= this.CharacterAnimation["ODM_Slash"].length)
			{
				this.CharacterAnimation["ODM_Jump"].time = this.CharacterAnimation["ODM_Jump"].length;
				this.CharacterAnimation.CrossFade("ODM_Jump");
			}
			this.CheckForGround();
		}
		if (this.CharacterAnimation["ODM_Jump"].time > 0.25f && this.MyController.velocity.y == 0f && base.transform.position.y == 0f)
		{
			this.Jumping = false;
			this.CanMove = true;
		}
		if ((double)this.impact.magnitude > 0.2)
		{
			this.MyController.Move(this.impact * Time.deltaTime);
		}
		this.MyController.Move(Physics.gravity * Time.deltaTime * 2f);
		this.impact = Vector3.Lerp(this.impact, Vector3.zero, Time.deltaTime * this.SlowDownSpeed);
		if (Input.GetButtonDown("A") && base.transform.position.y < 50f)
		{
			AudioSource.PlayClipAtPoint(this.AirBlast, base.transform.position);
			this.v = Input.GetAxis("Vertical");
			this.h = Input.GetAxis("Horizontal");
			Vector3 vector = this.MainCamera.transform.TransformDirection(Vector3.forward);
			vector.y = 0f;
			vector = vector.normalized;
			Vector3 a = new Vector3(vector.z, 0f, -vector.x);
			this.targetDirection = this.h * a + this.v * vector;
			if (this.h + this.v != 0f)
			{
				this.targetRotation = Quaternion.LookRotation(this.targetDirection);
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.targetRotation, 360f);
			}
			this.AddImpact(new Vector3(this.targetDirection.x, 1f, this.targetDirection.z), 100f);
			this.CharacterAnimation["ODM_Jump"].speed = 5f;
			this.CharacterAnimation["ODM_Jump"].time = 0f;
			this.CharacterAnimation.CrossFade("ODM_Jump", 0.1f);
			this.ODMEffect.Play();
			this.CanMove = false;
			this.Jumping = true;
		}
	}

	// Token: 0x06002035 RID: 8245 RVA: 0x001D7B0C File Offset: 0x001D5D0C
	private void BecomeRyoba()
	{
		this.MyRenderer.SetBlendShapeWeight(0, 50f);
		this.MyRenderer.SetBlendShapeWeight(5, 25f);
		this.MyRenderer.SetBlendShapeWeight(9, 0f);
		this.MyRenderer.SetBlendShapeWeight(12, 100f);
		this.OriginalIdleAnim = "f02_ryobaIdle_00";
		this.IdleAnim = "f02_ryobaIdle_00";
		this.OriginalWalkAnim = "f02_walkCouncilGrace_00";
		this.WalkAnim = "f02_walkCouncilGrace_00";
		this.BreastSize = 1.5f;
		this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		this.SneakShotButton.alpha = 0.5f;
		this.SneakShotLabel.alpha = 0f;
		this.Phone = this.PolaroidOfSenpai;
		this.Hairstyle = 203;
		this.UpdateHair();
		this.Laugh1 = this.EightiesLaughs[1];
		this.Laugh2 = this.EightiesLaughs[2];
		this.Laugh3 = this.EightiesLaughs[3];
		this.Laugh4 = this.EightiesLaughs[4];
		this.UniformTextures[6] = this.EightiesUniform;
		this.CasualTextures[6] = this.EightiesCasual;
		this.ModernCamera.localScale = new Vector3(0f, 0f, 0f);
		this.EightiesCamera.SetActive(true);
	}

	// Token: 0x06002036 RID: 8246 RVA: 0x001D7C96 File Offset: 0x001D5E96
	public void LoseGentleEyes()
	{
		this.MyRenderer.SetBlendShapeWeight(0, 0f);
		this.MyRenderer.SetBlendShapeWeight(5, 0f);
		this.MyRenderer.SetBlendShapeWeight(12, 0f);
	}

	// Token: 0x06002037 RID: 8247 RVA: 0x001D7CCC File Offset: 0x001D5ECC
	public void RestoreGentleEyes()
	{
		this.MyRenderer.SetBlendShapeWeight(0, 50f);
		this.MyRenderer.SetBlendShapeWeight(5, 25f);
		this.MyRenderer.SetBlendShapeWeight(12, 100f);
	}

	// Token: 0x04004371 RID: 17265
	public Quaternion targetRotation;

	// Token: 0x04004372 RID: 17266
	private Vector3 targetDirection;

	// Token: 0x04004373 RID: 17267
	private GameObject NewTrail;

	// Token: 0x04004374 RID: 17268
	public int AccessoryID;

	// Token: 0x04004375 RID: 17269
	private int ID;

	// Token: 0x04004376 RID: 17270
	public FootprintSpawnerScript RightFootprintSpawner;

	// Token: 0x04004377 RID: 17271
	public FootprintSpawnerScript LeftFootprintSpawner;

	// Token: 0x04004378 RID: 17272
	public CameraFilterPack_Colors_Adjust_PreFilters YandereFilter;

	// Token: 0x04004379 RID: 17273
	public CameraFilterPack_Colors_Adjust_PreFilters SenpaiFilter;

	// Token: 0x0400437A RID: 17274
	public SelectiveGrayscale SelectGrayscale;

	// Token: 0x0400437B RID: 17275
	public HighlightingRenderer HighlightingR;

	// Token: 0x0400437C RID: 17276
	public HighlightingBlitter HighlightingB;

	// Token: 0x0400437D RID: 17277
	public CameraFilterPack_Blur_GaussianBlur Blur;

	// Token: 0x0400437E RID: 17278
	public NotificationManagerScript NotificationManager;

	// Token: 0x0400437F RID: 17279
	public ObstacleDetectorScript ObstacleDetector;

	// Token: 0x04004380 RID: 17280
	public RiggedAccessoryAttacher GloveAttacher;

	// Token: 0x04004381 RID: 17281
	public RiggedAccessoryAttacher PantyAttacher;

	// Token: 0x04004382 RID: 17282
	public AccessoryGroupScript AccessoryGroup;

	// Token: 0x04004383 RID: 17283
	public DumpsterHandleScript DumpsterHandle;

	// Token: 0x04004384 RID: 17284
	public PhonePromptBarScript PhonePromptBar;

	// Token: 0x04004385 RID: 17285
	public ShoulderCameraScript ShoulderCamera;

	// Token: 0x04004386 RID: 17286
	public StudentManagerScript StudentManager;

	// Token: 0x04004387 RID: 17287
	public AttackManagerScript AttackManager;

	// Token: 0x04004388 RID: 17288
	public CameraEffectsScript CameraEffects;

	// Token: 0x04004389 RID: 17289
	public WeaponManagerScript WeaponManager;

	// Token: 0x0400438A RID: 17290
	public YandereShowerScript YandereShower;

	// Token: 0x0400438B RID: 17291
	public PromptParentScript PromptParent;

	// Token: 0x0400438C RID: 17292
	public SplashCameraScript SplashCamera;

	// Token: 0x0400438D RID: 17293
	public SWP_HeartRateMonitor HeartRate;

	// Token: 0x0400438E RID: 17294
	public GenericBentoScript TargetBento;

	// Token: 0x0400438F RID: 17295
	public LoveManagerScript LoveManager;

	// Token: 0x04004390 RID: 17296
	public StruggleBarScript StruggleBar;

	// Token: 0x04004391 RID: 17297
	public RummageSpotScript RummageSpot;

	// Token: 0x04004392 RID: 17298
	public IncineratorScript Incinerator;

	// Token: 0x04004393 RID: 17299
	public InputDeviceScript InputDevice;

	// Token: 0x04004394 RID: 17300
	public MusicCreditScript MusicCredit;

	// Token: 0x04004395 RID: 17301
	public PauseScreenScript PauseScreen;

	// Token: 0x04004396 RID: 17302
	public SmartphoneScript PhoneToCrush;

	// Token: 0x04004397 RID: 17303
	public WoodChipperScript WoodChipper;

	// Token: 0x04004398 RID: 17304
	public RagdollScript CurrentRagdoll;

	// Token: 0x04004399 RID: 17305
	public StudentScript TargetStudent;

	// Token: 0x0400439A RID: 17306
	public WeaponMenuScript WeaponMenu;

	// Token: 0x0400439B RID: 17307
	public PromptScript NearestPrompt;

	// Token: 0x0400439C RID: 17308
	public UIPanel YandereVisionPanel;

	// Token: 0x0400439D RID: 17309
	public ContainerScript Container;

	// Token: 0x0400439E RID: 17310
	public InventoryScript Inventory;

	// Token: 0x0400439F RID: 17311
	public TallLockerScript MyLocker;

	// Token: 0x040043A0 RID: 17312
	public PromptBarScript PromptBar;

	// Token: 0x040043A1 RID: 17313
	public TranqCaseScript TranqCase;

	// Token: 0x040043A2 RID: 17314
	public UISprite SneakShotButton;

	// Token: 0x040043A3 RID: 17315
	public AlphabetScript Alphabet;

	// Token: 0x040043A4 RID: 17316
	public UILabel SenpaiShotLabel;

	// Token: 0x040043A5 RID: 17317
	public LocationScript Location;

	// Token: 0x040043A6 RID: 17318
	public SubtitleScript Subtitle;

	// Token: 0x040043A7 RID: 17319
	public UITexture SanitySmudges;

	// Token: 0x040043A8 RID: 17320
	public Material CloakMaterial;

	// Token: 0x040043A9 RID: 17321
	public DemonScript EmptyDemon;

	// Token: 0x040043AA RID: 17322
	public StudentScript Follower;

	// Token: 0x040043AB RID: 17323
	public UIPanel DetectionPanel;

	// Token: 0x040043AC RID: 17324
	public UILabel SneakShotLabel;

	// Token: 0x040043AD RID: 17325
	public BookbagScript Bookbag;

	// Token: 0x040043AE RID: 17326
	public JukeboxScript Jukebox;

	// Token: 0x040043AF RID: 17327
	public OutlineScript Outline;

	// Token: 0x040043B0 RID: 17328
	public StudentScript Pursuer;

	// Token: 0x040043B1 RID: 17329
	public ShutterScript Shutter;

	// Token: 0x040043B2 RID: 17330
	public Collider HipCollider;

	// Token: 0x040043B3 RID: 17331
	public UISprite ProgressBar;

	// Token: 0x040043B4 RID: 17332
	public RPG_Camera RPGCamera;

	// Token: 0x040043B5 RID: 17333
	public BucketScript Bucket;

	// Token: 0x040043B6 RID: 17334
	public LookAtTarget LookAt;

	// Token: 0x040043B7 RID: 17335
	public PickUpScript PickUp;

	// Token: 0x040043B8 RID: 17336
	public PoliceScript Police;

	// Token: 0x040043B9 RID: 17337
	public UILabel SanityLabel;

	// Token: 0x040043BA RID: 17338
	public GloveScript Gloves;

	// Token: 0x040043BB RID: 17339
	public ClassScript Class;

	// Token: 0x040043BC RID: 17340
	public Camera UICamera;

	// Token: 0x040043BD RID: 17341
	public UILabel PowerUp;

	// Token: 0x040043BE RID: 17342
	public MaskScript Mask;

	// Token: 0x040043BF RID: 17343
	public MopScript Mop;

	// Token: 0x040043C0 RID: 17344
	public UIPanel HUD;

	// Token: 0x040043C1 RID: 17345
	public CharacterController MyController;

	// Token: 0x040043C2 RID: 17346
	public Transform LeftItemParent;

	// Token: 0x040043C3 RID: 17347
	public Transform BookBagParent;

	// Token: 0x040043C4 RID: 17348
	public Transform DismemberSpot;

	// Token: 0x040043C5 RID: 17349
	public Transform CameraTarget;

	// Token: 0x040043C6 RID: 17350
	public Transform InvertSphere;

	// Token: 0x040043C7 RID: 17351
	public Transform RightArmRoll;

	// Token: 0x040043C8 RID: 17352
	public Transform LeftArmRoll;

	// Token: 0x040043C9 RID: 17353
	public Transform CameraFocus;

	// Token: 0x040043CA RID: 17354
	public Transform RightBreast;

	// Token: 0x040043CB RID: 17355
	public Transform HidingSpot;

	// Token: 0x040043CC RID: 17356
	public Transform ItemParent;

	// Token: 0x040043CD RID: 17357
	public Transform LeftBreast;

	// Token: 0x040043CE RID: 17358
	public Transform LimbParent;

	// Token: 0x040043CF RID: 17359
	public Transform PelvisRoot;

	// Token: 0x040043D0 RID: 17360
	public Transform PoisonSpot;

	// Token: 0x040043D1 RID: 17361
	public Transform CameraPOV;

	// Token: 0x040043D2 RID: 17362
	public Transform RightHand;

	// Token: 0x040043D3 RID: 17363
	public Transform RightKnee;

	// Token: 0x040043D4 RID: 17364
	public Transform RightFoot;

	// Token: 0x040043D5 RID: 17365
	public Transform ExitSpot;

	// Token: 0x040043D6 RID: 17366
	public Transform LeftHand;

	// Token: 0x040043D7 RID: 17367
	public Transform Backpack;

	// Token: 0x040043D8 RID: 17368
	public Transform DropSpot;

	// Token: 0x040043D9 RID: 17369
	public Transform Homeroom;

	// Token: 0x040043DA RID: 17370
	public Transform DigSpot;

	// Token: 0x040043DB RID: 17371
	public Transform Senpai;

	// Token: 0x040043DC RID: 17372
	public Transform Target;

	// Token: 0x040043DD RID: 17373
	public Transform Stool;

	// Token: 0x040043DE RID: 17374
	public Transform Eyes;

	// Token: 0x040043DF RID: 17375
	public Transform Head;

	// Token: 0x040043E0 RID: 17376
	public Transform Hips;

	// Token: 0x040043E1 RID: 17377
	public AudioSource HeartBeat;

	// Token: 0x040043E2 RID: 17378
	public AudioSource MyAudio;

	// Token: 0x040043E3 RID: 17379
	public GameObject[] Accessories;

	// Token: 0x040043E4 RID: 17380
	public GameObject[] Hairstyles;

	// Token: 0x040043E5 RID: 17381
	public GameObject[] Poisons;

	// Token: 0x040043E6 RID: 17382
	public GameObject[] Shoes;

	// Token: 0x040043E7 RID: 17383
	public float[] DropTimer;

	// Token: 0x040043E8 RID: 17384
	public GameObject PolaroidOfSenpai;

	// Token: 0x040043E9 RID: 17385
	public GameObject CinematicCamera;

	// Token: 0x040043EA RID: 17386
	public GameObject FloatingShovel;

	// Token: 0x040043EB RID: 17387
	public GameObject SneakShotPhone;

	// Token: 0x040043EC RID: 17388
	public GameObject EasterEggMenu;

	// Token: 0x040043ED RID: 17389
	public GameObject PantyDetector;

	// Token: 0x040043EE RID: 17390
	public GameObject StolenObject;

	// Token: 0x040043EF RID: 17391
	public GameObject CameraFlash;

	// Token: 0x040043F0 RID: 17392
	public GameObject SelfieGuide;

	// Token: 0x040043F1 RID: 17393
	public GameObject MemeGlasses;

	// Token: 0x040043F2 RID: 17394
	public GameObject GiggleDisc;

	// Token: 0x040043F3 RID: 17395
	public GameObject KONGlasses;

	// Token: 0x040043F4 RID: 17396
	public GameObject Microphone;

	// Token: 0x040043F5 RID: 17397
	public GameObject SpiderLegs;

	// Token: 0x040043F6 RID: 17398
	public GameObject AlarmDisc;

	// Token: 0x040043F7 RID: 17399
	public GameObject Character;

	// Token: 0x040043F8 RID: 17400
	public GameObject DebugMenu;

	// Token: 0x040043F9 RID: 17401
	public GameObject EyepatchL;

	// Token: 0x040043FA RID: 17402
	public GameObject EyepatchR;

	// Token: 0x040043FB RID: 17403
	public GameObject EmptyHusk;

	// Token: 0x040043FC RID: 17404
	public GameObject Handcuffs;

	// Token: 0x040043FD RID: 17405
	public GameObject ShoePair;

	// Token: 0x040043FE RID: 17406
	public GameObject Barcode;

	// Token: 0x040043FF RID: 17407
	public GameObject Headset;

	// Token: 0x04004400 RID: 17408
	public GameObject Ragdoll;

	// Token: 0x04004401 RID: 17409
	public GameObject Hearts;

	// Token: 0x04004402 RID: 17410
	public GameObject Teeth;

	// Token: 0x04004403 RID: 17411
	public GameObject Phone;

	// Token: 0x04004404 RID: 17412
	public GameObject Trail;

	// Token: 0x04004405 RID: 17413
	public GameObject Match;

	// Token: 0x04004406 RID: 17414
	public GameObject Arc;

	// Token: 0x04004407 RID: 17415
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004408 RID: 17416
	public Animation CharacterAnimation;

	// Token: 0x04004409 RID: 17417
	public ParticleSystem GiggleLines;

	// Token: 0x0400440A RID: 17418
	public ParticleSystem InsaneLines;

	// Token: 0x0400440B RID: 17419
	public SpringJoint RagdollDragger;

	// Token: 0x0400440C RID: 17420
	public SpringJoint RagdollPK;

	// Token: 0x0400440D RID: 17421
	public Projector MyProjector;

	// Token: 0x0400440E RID: 17422
	public Camera HeartCamera;

	// Token: 0x0400440F RID: 17423
	public Camera MainCamera;

	// Token: 0x04004410 RID: 17424
	public Camera Smartphone;

	// Token: 0x04004411 RID: 17425
	public Camera HandCamera;

	// Token: 0x04004412 RID: 17426
	public Renderer SmartphoneRenderer;

	// Token: 0x04004413 RID: 17427
	public Renderer LongHairRenderer;

	// Token: 0x04004414 RID: 17428
	public Renderer PonytailRenderer;

	// Token: 0x04004415 RID: 17429
	public Renderer NoPonyRenderer;

	// Token: 0x04004416 RID: 17430
	public Renderer PigtailR;

	// Token: 0x04004417 RID: 17431
	public Renderer PigtailL;

	// Token: 0x04004418 RID: 17432
	public Renderer Drills;

	// Token: 0x04004419 RID: 17433
	public float SuspiciousActionTimer;

	// Token: 0x0400441A RID: 17434
	public float MurderousActionTimer;

	// Token: 0x0400441B RID: 17435
	public float CinematicTimer;

	// Token: 0x0400441C RID: 17436
	public float SneakShotTimer;

	// Token: 0x0400441D RID: 17437
	public float ClothingTimer;

	// Token: 0x0400441E RID: 17438
	public float BreakUpTimer;

	// Token: 0x0400441F RID: 17439
	public float CanMoveTimer;

	// Token: 0x04004420 RID: 17440
	public float RummageTimer;

	// Token: 0x04004421 RID: 17441
	public float YandereTimer;

	// Token: 0x04004422 RID: 17442
	public float AttackTimer;

	// Token: 0x04004423 RID: 17443
	public float CaughtTimer;

	// Token: 0x04004424 RID: 17444
	public float GiggleTimer;

	// Token: 0x04004425 RID: 17445
	public float SenpaiTimer;

	// Token: 0x04004426 RID: 17446
	public float WeaponTimer;

	// Token: 0x04004427 RID: 17447
	public float CrawlTimer;

	// Token: 0x04004428 RID: 17448
	public float GloveTimer;

	// Token: 0x04004429 RID: 17449
	public float LaughTimer;

	// Token: 0x0400442A RID: 17450
	public float SprayTimer;

	// Token: 0x0400442B RID: 17451
	public float TheftTimer;

	// Token: 0x0400442C RID: 17452
	public float BeatTimer;

	// Token: 0x0400442D RID: 17453
	public float BoneTimer;

	// Token: 0x0400442E RID: 17454
	public float DumpTimer;

	// Token: 0x0400442F RID: 17455
	public float ExitTimer;

	// Token: 0x04004430 RID: 17456
	public float TalkTimer;

	// Token: 0x04004431 RID: 17457
	[SerializeField]
	private float bloodiness;

	// Token: 0x04004432 RID: 17458
	public float PreviousSanity = 100f;

	// Token: 0x04004433 RID: 17459
	[SerializeField]
	private float sanity;

	// Token: 0x04004434 RID: 17460
	public float TwitchTimer;

	// Token: 0x04004435 RID: 17461
	public float NextTwitch;

	// Token: 0x04004436 RID: 17462
	public float SenpaiThreshold;

	// Token: 0x04004437 RID: 17463
	public float LaughIntensity;

	// Token: 0x04004438 RID: 17464
	public float TimeSkipHeight;

	// Token: 0x04004439 RID: 17465
	public float PourDistance;

	// Token: 0x0400443A RID: 17466
	public float TargetHeight;

	// Token: 0x0400443B RID: 17467
	public float PermitLaugh;

	// Token: 0x0400443C RID: 17468
	public float ReachWeight;

	// Token: 0x0400443D RID: 17469
	public float BreastSize;

	// Token: 0x0400443E RID: 17470
	public float Numbness;

	// Token: 0x0400443F RID: 17471
	public float PourTime;

	// Token: 0x04004440 RID: 17472
	public float RunSpeed;

	// Token: 0x04004441 RID: 17473
	public float Height;

	// Token: 0x04004442 RID: 17474
	public float Slouch;

	// Token: 0x04004443 RID: 17475
	public float Bend;

	// Token: 0x04004444 RID: 17476
	public float CrouchWalkSpeed;

	// Token: 0x04004445 RID: 17477
	public float CrouchRunSpeed;

	// Token: 0x04004446 RID: 17478
	public float ShoveSpeed = 2f;

	// Token: 0x04004447 RID: 17479
	public float CrawlSpeed;

	// Token: 0x04004448 RID: 17480
	public float FlapSpeed;

	// Token: 0x04004449 RID: 17481
	public float WalkSpeed;

	// Token: 0x0400444A RID: 17482
	public float YandereFade;

	// Token: 0x0400444B RID: 17483
	public float YandereTint;

	// Token: 0x0400444C RID: 17484
	public float SenpaiFade;

	// Token: 0x0400444D RID: 17485
	public float SenpaiTint;

	// Token: 0x0400444E RID: 17486
	public float GreyTarget;

	// Token: 0x0400444F RID: 17487
	public int CurrentUniformOrigin = 1;

	// Token: 0x04004450 RID: 17488
	public int PreviousSchoolwear;

	// Token: 0x04004451 RID: 17489
	public int NearestCorpseID;

	// Token: 0x04004452 RID: 17490
	public int StolenObjectID;

	// Token: 0x04004453 RID: 17491
	public int StrugglePhase;

	// Token: 0x04004454 RID: 17492
	public int PhysicalGrade;

	// Token: 0x04004455 RID: 17493
	public int CarryAnimID;

	// Token: 0x04004456 RID: 17494
	public int AttackPhase;

	// Token: 0x04004457 RID: 17495
	public int Creepiness = 1;

	// Token: 0x04004458 RID: 17496
	public int GloveBlood;

	// Token: 0x04004459 RID: 17497
	public int NearBodies;

	// Token: 0x0400445A RID: 17498
	public int PoisonType;

	// Token: 0x0400445B RID: 17499
	public int Schoolwear;

	// Token: 0x0400445C RID: 17500
	public int SpeedBonus;

	// Token: 0x0400445D RID: 17501
	public int SprayPhase;

	// Token: 0x0400445E RID: 17502
	public int DragState;

	// Token: 0x0400445F RID: 17503
	public int EggBypass;

	// Token: 0x04004460 RID: 17504
	public int EyewearID;

	// Token: 0x04004461 RID: 17505
	public int Followers;

	// Token: 0x04004462 RID: 17506
	public int Hairstyle;

	// Token: 0x04004463 RID: 17507
	public int PersonaID;

	// Token: 0x04004464 RID: 17508
	public int DigPhase;

	// Token: 0x04004465 RID: 17509
	public int Equipped;

	// Token: 0x04004466 RID: 17510
	public int Chasers;

	// Token: 0x04004467 RID: 17511
	public int Costume;

	// Token: 0x04004468 RID: 17512
	public int Alerts;

	// Token: 0x04004469 RID: 17513
	public int Health = 5;

	// Token: 0x0400446A RID: 17514
	public YandereInteractionType Interaction;

	// Token: 0x0400446B RID: 17515
	public YanderePersonaType Persona;

	// Token: 0x0400446C RID: 17516
	public ClubType Club;

	// Token: 0x0400446D RID: 17517
	public bool EavesdropWarning;

	// Token: 0x0400446E RID: 17518
	public bool ClothingWarning;

	// Token: 0x0400446F RID: 17519
	public bool BloodyWarning;

	// Token: 0x04004470 RID: 17520
	public bool CorpseWarning;

	// Token: 0x04004471 RID: 17521
	public bool SanityWarning;

	// Token: 0x04004472 RID: 17522
	public bool WeaponWarning;

	// Token: 0x04004473 RID: 17523
	public bool DelinquentFighting;

	// Token: 0x04004474 RID: 17524
	public bool DumpsterGrabbing;

	// Token: 0x04004475 RID: 17525
	public bool FakingReaction;

	// Token: 0x04004476 RID: 17526
	public bool BucketDropping;

	// Token: 0x04004477 RID: 17527
	public bool CleaningWeapon;

	// Token: 0x04004478 RID: 17528
	public bool SubtleStabbing;

	// Token: 0x04004479 RID: 17529
	public bool TranquilHiding;

	// Token: 0x0400447A RID: 17530
	public bool CrushingPhone;

	// Token: 0x0400447B RID: 17531
	public bool Eavesdropping;

	// Token: 0x0400447C RID: 17532
	public bool Pickpocketing;

	// Token: 0x0400447D RID: 17533
	public bool Dismembering;

	// Token: 0x0400447E RID: 17534
	public bool SenpaiGazing;

	// Token: 0x0400447F RID: 17535
	public bool ShootingBeam;

	// Token: 0x04004480 RID: 17536
	public bool SneakingShot;

	// Token: 0x04004481 RID: 17537
	public bool StoppingTime;

	// Token: 0x04004482 RID: 17538
	public bool TimeSkipping;

	// Token: 0x04004483 RID: 17539
	public bool Cauterizing;

	// Token: 0x04004484 RID: 17540
	public bool HeavyWeight;

	// Token: 0x04004485 RID: 17541
	public bool Trespassing;

	// Token: 0x04004486 RID: 17542
	public bool WritingName;

	// Token: 0x04004487 RID: 17543
	public bool Struggling;

	// Token: 0x04004488 RID: 17544
	public bool Attacking;

	// Token: 0x04004489 RID: 17545
	public bool Degloving;

	// Token: 0x0400448A RID: 17546
	public bool Poisoning;

	// Token: 0x0400448B RID: 17547
	public bool Rummaging;

	// Token: 0x0400448C RID: 17548
	public bool Stripping;

	// Token: 0x0400448D RID: 17549
	public bool Blasting;

	// Token: 0x0400448E RID: 17550
	public bool Carrying;

	// Token: 0x0400448F RID: 17551
	public bool Chipping;

	// Token: 0x04004490 RID: 17552
	public bool Dragging;

	// Token: 0x04004491 RID: 17553
	public bool Dropping;

	// Token: 0x04004492 RID: 17554
	public bool Flicking;

	// Token: 0x04004493 RID: 17555
	public bool Freezing;

	// Token: 0x04004494 RID: 17556
	public bool Laughing;

	// Token: 0x04004495 RID: 17557
	public bool Punching;

	// Token: 0x04004496 RID: 17558
	public bool Throwing;

	// Token: 0x04004497 RID: 17559
	public bool Tripping;

	// Token: 0x04004498 RID: 17560
	public bool Bathing;

	// Token: 0x04004499 RID: 17561
	public bool Burying;

	// Token: 0x0400449A RID: 17562
	public bool Cooking;

	// Token: 0x0400449B RID: 17563
	public bool Digging;

	// Token: 0x0400449C RID: 17564
	public bool Dipping;

	// Token: 0x0400449D RID: 17565
	public bool Dumping;

	// Token: 0x0400449E RID: 17566
	public bool Exiting;

	// Token: 0x0400449F RID: 17567
	public bool Lifting;

	// Token: 0x040044A0 RID: 17568
	public bool Mopping;

	// Token: 0x040044A1 RID: 17569
	public bool Pouring;

	// Token: 0x040044A2 RID: 17570
	public bool Resting;

	// Token: 0x040044A3 RID: 17571
	public bool Running;

	// Token: 0x040044A4 RID: 17572
	public bool Talking;

	// Token: 0x040044A5 RID: 17573
	public bool Testing;

	// Token: 0x040044A6 RID: 17574
	public bool Aiming;

	// Token: 0x040044A7 RID: 17575
	public bool Eating;

	// Token: 0x040044A8 RID: 17576
	public bool Hiding;

	// Token: 0x040044A9 RID: 17577
	public bool Riding;

	// Token: 0x040044AA RID: 17578
	public Stance Stance = new Stance(StanceType.Standing);

	// Token: 0x040044AB RID: 17579
	public bool PreparedForStruggle;

	// Token: 0x040044AC RID: 17580
	public bool SprayedByJournalist;

	// Token: 0x040044AD RID: 17581
	public bool CrouchButtonDown;

	// Token: 0x040044AE RID: 17582
	public bool FightHasBrokenUp;

	// Token: 0x040044AF RID: 17583
	public bool CannotBeSprayed;

	// Token: 0x040044B0 RID: 17584
	public bool UsingController;

	// Token: 0x040044B1 RID: 17585
	public bool SeenByAuthority;

	// Token: 0x040044B2 RID: 17586
	public bool CameFromCrouch;

	// Token: 0x040044B3 RID: 17587
	public bool CannotRecover;

	// Token: 0x040044B4 RID: 17588
	public bool NearMindSlave;

	// Token: 0x040044B5 RID: 17589
	public bool NoStainGloves;

	// Token: 0x040044B6 RID: 17590
	public bool YandereVision;

	// Token: 0x040044B7 RID: 17591
	public bool ClubActivity;

	// Token: 0x040044B8 RID: 17592
	public bool FlameDemonic;

	// Token: 0x040044B9 RID: 17593
	public bool SanityBased;

	// Token: 0x040044BA RID: 17594
	public bool SanityPills;

	// Token: 0x040044BB RID: 17595
	public bool SummonBones;

	// Token: 0x040044BC RID: 17596
	public bool ClubAttire;

	// Token: 0x040044BD RID: 17597
	public bool FollowHips;

	// Token: 0x040044BE RID: 17598
	public bool NearSenpai;

	// Token: 0x040044BF RID: 17599
	public bool RivalPhone;

	// Token: 0x040044C0 RID: 17600
	public bool SpiderGrow;

	// Token: 0x040044C1 RID: 17601
	public bool Invisible;

	// Token: 0x040044C2 RID: 17602
	public bool Possessed;

	// Token: 0x040044C3 RID: 17603
	public bool ToggleRun;

	// Token: 0x040044C4 RID: 17604
	public bool WitchMode;

	// Token: 0x040044C5 RID: 17605
	public bool Attacked;

	// Token: 0x040044C6 RID: 17606
	public bool CanCloak;

	// Token: 0x040044C7 RID: 17607
	public bool CanTranq;

	// Token: 0x040044C8 RID: 17608
	public bool Collapse;

	// Token: 0x040044C9 RID: 17609
	public bool Unmasked;

	// Token: 0x040044CA RID: 17610
	public bool RedPaint;

	// Token: 0x040044CB RID: 17611
	public bool RoofPush;

	// Token: 0x040044CC RID: 17612
	public bool Demonic;

	// Token: 0x040044CD RID: 17613
	public bool FlapOut;

	// Token: 0x040044CE RID: 17614
	public bool NoDebug;

	// Token: 0x040044CF RID: 17615
	public bool Noticed;

	// Token: 0x040044D0 RID: 17616
	public bool InClass;

	// Token: 0x040044D1 RID: 17617
	public bool Slender;

	// Token: 0x040044D2 RID: 17618
	public bool Sprayed;

	// Token: 0x040044D3 RID: 17619
	public bool Caught;

	// Token: 0x040044D4 RID: 17620
	public bool CanMove = true;

	// Token: 0x040044D5 RID: 17621
	public bool Chased;

	// Token: 0x040044D6 RID: 17622
	public bool Frozen;

	// Token: 0x040044D7 RID: 17623
	public bool Gloved;

	// Token: 0x040044D8 RID: 17624
	public bool Selfie;

	// Token: 0x040044D9 RID: 17625
	public bool Shoved;

	// Token: 0x040044DA RID: 17626
	public bool Drown;

	// Token: 0x040044DB RID: 17627
	public bool Xtan;

	// Token: 0x040044DC RID: 17628
	public bool Lewd;

	// Token: 0x040044DD RID: 17629
	public bool Lost;

	// Token: 0x040044DE RID: 17630
	public bool Sans;

	// Token: 0x040044DF RID: 17631
	public bool Egg;

	// Token: 0x040044E0 RID: 17632
	public bool Won;

	// Token: 0x040044E1 RID: 17633
	public bool AR;

	// Token: 0x040044E2 RID: 17634
	public bool DK;

	// Token: 0x040044E3 RID: 17635
	public bool PK;

	// Token: 0x040044E4 RID: 17636
	public Texture[] UniformTextures;

	// Token: 0x040044E5 RID: 17637
	public Texture[] CasualTextures;

	// Token: 0x040044E6 RID: 17638
	public Texture[] FlowerTextures;

	// Token: 0x040044E7 RID: 17639
	public Texture[] BloodTextures;

	// Token: 0x040044E8 RID: 17640
	public AudioClip[] CreepyGiggles;

	// Token: 0x040044E9 RID: 17641
	public AudioClip[] Stabs;

	// Token: 0x040044EA RID: 17642
	public WeaponScript[] Weapon;

	// Token: 0x040044EB RID: 17643
	public GameObject[] ZipTie;

	// Token: 0x040044EC RID: 17644
	public string[] ArmedAnims;

	// Token: 0x040044ED RID: 17645
	public string[] CarryAnims;

	// Token: 0x040044EE RID: 17646
	public Transform[] Spine;

	// Token: 0x040044EF RID: 17647
	public Transform[] Foot;

	// Token: 0x040044F0 RID: 17648
	public Transform[] Hand;

	// Token: 0x040044F1 RID: 17649
	public Transform[] Arm;

	// Token: 0x040044F2 RID: 17650
	public Transform[] Leg;

	// Token: 0x040044F3 RID: 17651
	public Material[] CloakMaterials;

	// Token: 0x040044F4 RID: 17652
	public Mesh[] Uniforms;

	// Token: 0x040044F5 RID: 17653
	public Renderer RightYandereEye;

	// Token: 0x040044F6 RID: 17654
	public Renderer LeftYandereEye;

	// Token: 0x040044F7 RID: 17655
	public Vector3 RightEyeOrigin;

	// Token: 0x040044F8 RID: 17656
	public Vector3 LeftEyeOrigin;

	// Token: 0x040044F9 RID: 17657
	public Renderer RightRedEye;

	// Token: 0x040044FA RID: 17658
	public Renderer LeftRedEye;

	// Token: 0x040044FB RID: 17659
	public Transform RightEye;

	// Token: 0x040044FC RID: 17660
	public Transform LeftEye;

	// Token: 0x040044FD RID: 17661
	public float EyeShrink;

	// Token: 0x040044FE RID: 17662
	public Vector3 Twitch;

	// Token: 0x040044FF RID: 17663
	private AudioClip LaughClip;

	// Token: 0x04004500 RID: 17664
	public string PourHeight = string.Empty;

	// Token: 0x04004501 RID: 17665
	public string DrownAnim = string.Empty;

	// Token: 0x04004502 RID: 17666
	public string LaughAnim = string.Empty;

	// Token: 0x04004503 RID: 17667
	public string HideAnim = string.Empty;

	// Token: 0x04004504 RID: 17668
	public string IdleAnim = string.Empty;

	// Token: 0x04004505 RID: 17669
	public string TalkAnim = string.Empty;

	// Token: 0x04004506 RID: 17670
	public string WalkAnim = string.Empty;

	// Token: 0x04004507 RID: 17671
	public string RunAnim = string.Empty;

	// Token: 0x04004508 RID: 17672
	public string CrouchIdleAnim = string.Empty;

	// Token: 0x04004509 RID: 17673
	public string CrouchWalkAnim = string.Empty;

	// Token: 0x0400450A RID: 17674
	public string CrouchRunAnim = string.Empty;

	// Token: 0x0400450B RID: 17675
	public string CrawlIdleAnim = string.Empty;

	// Token: 0x0400450C RID: 17676
	public string CrawlWalkAnim = string.Empty;

	// Token: 0x0400450D RID: 17677
	public string HeavyIdleAnim = string.Empty;

	// Token: 0x0400450E RID: 17678
	public string HeavyWalkAnim = string.Empty;

	// Token: 0x0400450F RID: 17679
	public string CarryIdleAnim = string.Empty;

	// Token: 0x04004510 RID: 17680
	public string CarryWalkAnim = string.Empty;

	// Token: 0x04004511 RID: 17681
	public string CarryRunAnim = string.Empty;

	// Token: 0x04004512 RID: 17682
	public string[] CreepyIdles;

	// Token: 0x04004513 RID: 17683
	public string[] CreepyWalks;

	// Token: 0x04004514 RID: 17684
	public AudioClip DramaticWriting;

	// Token: 0x04004515 RID: 17685
	public AudioClip ChargeUp;

	// Token: 0x04004516 RID: 17686
	public AudioClip Laugh0;

	// Token: 0x04004517 RID: 17687
	public AudioClip Laugh1;

	// Token: 0x04004518 RID: 17688
	public AudioClip Laugh2;

	// Token: 0x04004519 RID: 17689
	public AudioClip Laugh3;

	// Token: 0x0400451A RID: 17690
	public AudioClip Laugh4;

	// Token: 0x0400451B RID: 17691
	public AudioClip Thud;

	// Token: 0x0400451C RID: 17692
	public AudioClip Dig;

	// Token: 0x0400451D RID: 17693
	public Vector3 PreviousPosition;

	// Token: 0x0400451E RID: 17694
	public string OriginalIdleAnim = string.Empty;

	// Token: 0x0400451F RID: 17695
	public string OriginalWalkAnim = string.Empty;

	// Token: 0x04004520 RID: 17696
	public string OriginalRunAnim = string.Empty;

	// Token: 0x04004521 RID: 17697
	public Texture YanderePhoneTexture;

	// Token: 0x04004522 RID: 17698
	public Texture BloodyGloveTexture;

	// Token: 0x04004523 RID: 17699
	public Texture RivalPhoneTexture;

	// Token: 0x04004524 RID: 17700
	public Texture GloveTexture;

	// Token: 0x04004525 RID: 17701
	public Texture BlondePony;

	// Token: 0x04004526 RID: 17702
	public float VibrationIntensity;

	// Token: 0x04004527 RID: 17703
	public float VibrationTimer;

	// Token: 0x04004528 RID: 17704
	public bool VibrationCheck;

	// Token: 0x04004529 RID: 17705
	public float v;

	// Token: 0x0400452A RID: 17706
	public float h;

	// Token: 0x0400452B RID: 17707
	private int DebugInt;

	// Token: 0x0400452C RID: 17708
	public GameObject CreepyArms;

	// Token: 0x0400452D RID: 17709
	public Texture[] GloveTextures;

	// Token: 0x0400452E RID: 17710
	public float OriginalBloodiness;

	// Token: 0x0400452F RID: 17711
	public float CoatBloodiness;

	// Token: 0x04004530 RID: 17712
	public bool WearingRaincoat;

	// Token: 0x04004531 RID: 17713
	public ParticleSystem ODMEffect;

	// Token: 0x04004532 RID: 17714
	public Texture TitanBodyTexture;

	// Token: 0x04004533 RID: 17715
	public Texture TitanFaceTexture;

	// Token: 0x04004534 RID: 17716
	public GameObject TitanSlash;

	// Token: 0x04004535 RID: 17717
	public GameObject ODMGear;

	// Token: 0x04004536 RID: 17718
	public AudioClip AirBlast;

	// Token: 0x04004537 RID: 17719
	public GameObject[] TitanSword;

	// Token: 0x04004538 RID: 17720
	public Texture KONTexture;

	// Token: 0x04004539 RID: 17721
	public GameObject PunishedAccessories;

	// Token: 0x0400453A RID: 17722
	public GameObject PunishedScarf;

	// Token: 0x0400453B RID: 17723
	public GameObject[] PunishedArm;

	// Token: 0x0400453C RID: 17724
	public Texture[] PunishedTextures;

	// Token: 0x0400453D RID: 17725
	public Shader PunishedShader;

	// Token: 0x0400453E RID: 17726
	public Mesh PunishedMesh;

	// Token: 0x0400453F RID: 17727
	public Material HatefulSkybox;

	// Token: 0x04004540 RID: 17728
	public Texture HatefulUniform;

	// Token: 0x04004541 RID: 17729
	public GameObject SukebanAccessories;

	// Token: 0x04004542 RID: 17730
	public Texture SukebanBandages;

	// Token: 0x04004543 RID: 17731
	public Texture SukebanUniform;

	// Token: 0x04004544 RID: 17732
	public FalconPunchScript BanchoFinisher;

	// Token: 0x04004545 RID: 17733
	public StandPunchScript BanchoFlurry;

	// Token: 0x04004546 RID: 17734
	public GameObject BanchoPants;

	// Token: 0x04004547 RID: 17735
	public Mesh BanchoMesh;

	// Token: 0x04004548 RID: 17736
	public Texture BanchoBody;

	// Token: 0x04004549 RID: 17737
	public Texture BanchoFace;

	// Token: 0x0400454A RID: 17738
	public GameObject[] BanchoAccessories;

	// Token: 0x0400454B RID: 17739
	public bool BanchoActive;

	// Token: 0x0400454C RID: 17740
	public bool Finisher;

	// Token: 0x0400454D RID: 17741
	public AudioClip BanchoYanYan;

	// Token: 0x0400454E RID: 17742
	public AudioClip BanchoFinalYan;

	// Token: 0x0400454F RID: 17743
	public AmplifyMotionObject MotionObject;

	// Token: 0x04004550 RID: 17744
	public AmplifyMotionEffect MotionBlur;

	// Token: 0x04004551 RID: 17745
	public GameObject BanchoCamera;

	// Token: 0x04004552 RID: 17746
	public GameObject[] SlenderHair;

	// Token: 0x04004553 RID: 17747
	public Texture SlenderUniform;

	// Token: 0x04004554 RID: 17748
	public Material SlenderSkybox;

	// Token: 0x04004555 RID: 17749
	public Texture SlenderSkin;

	// Token: 0x04004556 RID: 17750
	public Transform[] LongHair;

	// Token: 0x04004557 RID: 17751
	public GameObject BlackEyePatch;

	// Token: 0x04004558 RID: 17752
	public GameObject XSclera;

	// Token: 0x04004559 RID: 17753
	public GameObject XEye;

	// Token: 0x0400455A RID: 17754
	public Texture XBody;

	// Token: 0x0400455B RID: 17755
	public Texture XFace;

	// Token: 0x0400455C RID: 17756
	public GameObject[] GaloAccessories;

	// Token: 0x0400455D RID: 17757
	public Texture GaloArms;

	// Token: 0x0400455E RID: 17758
	public Texture GaloFace;

	// Token: 0x0400455F RID: 17759
	public AudioClip SummonStand;

	// Token: 0x04004560 RID: 17760
	public StandScript Stand;

	// Token: 0x04004561 RID: 17761
	public AudioClip YanYan;

	// Token: 0x04004562 RID: 17762
	public Texture AgentFace;

	// Token: 0x04004563 RID: 17763
	public Texture AgentSuit;

	// Token: 0x04004564 RID: 17764
	public GameObject CirnoIceAttack;

	// Token: 0x04004565 RID: 17765
	public AudioClip CirnoIceClip;

	// Token: 0x04004566 RID: 17766
	public GameObject CirnoWings;

	// Token: 0x04004567 RID: 17767
	public GameObject CirnoHair;

	// Token: 0x04004568 RID: 17768
	public Texture CirnoUniform;

	// Token: 0x04004569 RID: 17769
	public Texture CirnoFace;

	// Token: 0x0400456A RID: 17770
	public Transform[] CirnoWing;

	// Token: 0x0400456B RID: 17771
	public float CirnoRotation;

	// Token: 0x0400456C RID: 17772
	public float CirnoTimer;

	// Token: 0x0400456D RID: 17773
	public AudioClip FalconPunchVoice;

	// Token: 0x0400456E RID: 17774
	public Texture FalconBody;

	// Token: 0x0400456F RID: 17775
	public Texture FalconFace;

	// Token: 0x04004570 RID: 17776
	public float FalconSpeed;

	// Token: 0x04004571 RID: 17777
	public GameObject NewFalconPunch;

	// Token: 0x04004572 RID: 17778
	public GameObject FalconWindUp;

	// Token: 0x04004573 RID: 17779
	public GameObject FalconPunch;

	// Token: 0x04004574 RID: 17780
	public GameObject FalconShoulderpad;

	// Token: 0x04004575 RID: 17781
	public GameObject FalconKneepad1;

	// Token: 0x04004576 RID: 17782
	public GameObject FalconKneepad2;

	// Token: 0x04004577 RID: 17783
	public GameObject FalconBuckle;

	// Token: 0x04004578 RID: 17784
	public GameObject FalconHelmet;

	// Token: 0x04004579 RID: 17785
	public AudioClip[] OnePunchVoices;

	// Token: 0x0400457A RID: 17786
	public GameObject NewOnePunch;

	// Token: 0x0400457B RID: 17787
	public GameObject OnePunch;

	// Token: 0x0400457C RID: 17788
	public Texture SaitamaSuit;

	// Token: 0x0400457D RID: 17789
	public GameObject Cape;

	// Token: 0x0400457E RID: 17790
	public ParticleSystem GlowEffect;

	// Token: 0x0400457F RID: 17791
	public GameObject[] BlasterSet;

	// Token: 0x04004580 RID: 17792
	public GameObject[] SansEyes;

	// Token: 0x04004581 RID: 17793
	public AudioClip BlasterClip;

	// Token: 0x04004582 RID: 17794
	public Texture SansTexture;

	// Token: 0x04004583 RID: 17795
	public Texture SansFace;

	// Token: 0x04004584 RID: 17796
	public GameObject Bone;

	// Token: 0x04004585 RID: 17797
	public AudioClip Slam;

	// Token: 0x04004586 RID: 17798
	public Mesh Jersey;

	// Token: 0x04004587 RID: 17799
	public int BlasterStage;

	// Token: 0x04004588 RID: 17800
	public PKDirType PKDir;

	// Token: 0x04004589 RID: 17801
	public Texture CyborgBody;

	// Token: 0x0400458A RID: 17802
	public Texture CyborgFace;

	// Token: 0x0400458B RID: 17803
	public GameObject[] CyborgParts;

	// Token: 0x0400458C RID: 17804
	public GameObject EnergySword;

	// Token: 0x0400458D RID: 17805
	public bool Ninja;

	// Token: 0x0400458E RID: 17806
	public GameObject EbolaEffect;

	// Token: 0x0400458F RID: 17807
	public GameObject EbolaWings;

	// Token: 0x04004590 RID: 17808
	public GameObject EbolaHair;

	// Token: 0x04004591 RID: 17809
	public Texture EbolaFace;

	// Token: 0x04004592 RID: 17810
	public Texture EbolaUniform;

	// Token: 0x04004593 RID: 17811
	public GameObject EbolaAttacher;

	// Token: 0x04004594 RID: 17812
	public Mesh LongUniform;

	// Token: 0x04004595 RID: 17813
	public Texture NewFace;

	// Token: 0x04004596 RID: 17814
	public Mesh NewMesh;

	// Token: 0x04004597 RID: 17815
	public GameObject[] CensorSteam;

	// Token: 0x04004598 RID: 17816
	public Texture NudePanties;

	// Token: 0x04004599 RID: 17817
	public Texture NudeTexture;

	// Token: 0x0400459A RID: 17818
	public Mesh NudeMesh;

	// Token: 0x0400459B RID: 17819
	public Texture SamusBody;

	// Token: 0x0400459C RID: 17820
	public Texture SamusFace;

	// Token: 0x0400459D RID: 17821
	public GlobalKnifeArrayScript GlobalKnifeArray;

	// Token: 0x0400459E RID: 17822
	public GameObject PlayerOnlyCamera;

	// Token: 0x0400459F RID: 17823
	public GameObject KnifeArray;

	// Token: 0x040045A0 RID: 17824
	public AudioClip ClockStart;

	// Token: 0x040045A1 RID: 17825
	public AudioClip ClockStop;

	// Token: 0x040045A2 RID: 17826
	public AudioClip ClockTick;

	// Token: 0x040045A3 RID: 17827
	public AudioClip StartShout;

	// Token: 0x040045A4 RID: 17828
	public AudioClip StopShout;

	// Token: 0x040045A5 RID: 17829
	public Texture WitchBody;

	// Token: 0x040045A6 RID: 17830
	public Texture WitchFace;

	// Token: 0x040045A7 RID: 17831
	public Collider BladeHairCollider1;

	// Token: 0x040045A8 RID: 17832
	public Collider BladeHairCollider2;

	// Token: 0x040045A9 RID: 17833
	public GameObject BladeHair;

	// Token: 0x040045AA RID: 17834
	public DebugMenuScript TheDebugMenuScript;

	// Token: 0x040045AB RID: 17835
	public GameObject RiggedAccessory;

	// Token: 0x040045AC RID: 17836
	public GameObject TornadoAttack;

	// Token: 0x040045AD RID: 17837
	public GameObject TornadoDress;

	// Token: 0x040045AE RID: 17838
	public GameObject TornadoHair;

	// Token: 0x040045AF RID: 17839
	public Renderer TornadoRenderer;

	// Token: 0x040045B0 RID: 17840
	public Mesh NoTorsoMesh;

	// Token: 0x040045B1 RID: 17841
	public GameObject KunHair;

	// Token: 0x040045B2 RID: 17842
	public GameObject Kun;

	// Token: 0x040045B3 RID: 17843
	public GameObject Man;

	// Token: 0x040045B4 RID: 17844
	public GameObject BlackHoleEffects;

	// Token: 0x040045B5 RID: 17845
	public Texture BlackHoleFace;

	// Token: 0x040045B6 RID: 17846
	public Texture Black;

	// Token: 0x040045B7 RID: 17847
	public bool BlackHole;

	// Token: 0x040045B8 RID: 17848
	public Transform RightLeg;

	// Token: 0x040045B9 RID: 17849
	public Transform LeftLeg;

	// Token: 0x040045BA RID: 17850
	public GameObject Bandages;

	// Token: 0x040045BB RID: 17851
	public GameObject LucyHelmet;

	// Token: 0x040045BC RID: 17852
	public GameObject[] Vectors;

	// Token: 0x040045BD RID: 17853
	public GameObject[] Kagune;

	// Token: 0x040045BE RID: 17854
	public Texture GhoulFace;

	// Token: 0x040045BF RID: 17855
	public Texture GhoulBody;

	// Token: 0x040045C0 RID: 17856
	public bool ReturnKagune;

	// Token: 0x040045C1 RID: 17857
	public bool SwingKagune;

	// Token: 0x040045C2 RID: 17858
	public Vector3[] KaguneRotation;

	// Token: 0x040045C3 RID: 17859
	public AudioClip KaguneSwoosh;

	// Token: 0x040045C4 RID: 17860
	public GameObject DemonSlash;

	// Token: 0x040045C5 RID: 17861
	public int KagunePhase;

	// Token: 0x040045C6 RID: 17862
	public GameObject[] Armor;

	// Token: 0x040045C7 RID: 17863
	public Texture Chainmail;

	// Token: 0x040045C8 RID: 17864
	public Texture Scarface;

	// Token: 0x040045C9 RID: 17865
	public Material Metal;

	// Token: 0x040045CA RID: 17866
	public Material Trans;

	// Token: 0x040045CB RID: 17867
	public GameObject BlackRobe;

	// Token: 0x040045CC RID: 17868
	public Mesh NoUpperBodyMesh;

	// Token: 0x040045CD RID: 17869
	public ParticleSystem[] Beam;

	// Token: 0x040045CE RID: 17870
	public SithBeamScript[] SithBeam;

	// Token: 0x040045CF RID: 17871
	public bool SithRecovering;

	// Token: 0x040045D0 RID: 17872
	public bool SithAttacking;

	// Token: 0x040045D1 RID: 17873
	public bool SithLord;

	// Token: 0x040045D2 RID: 17874
	public string SithPrefix;

	// Token: 0x040045D3 RID: 17875
	public int SithComboLength;

	// Token: 0x040045D4 RID: 17876
	public int SithAttacks;

	// Token: 0x040045D5 RID: 17877
	public int SithSounds;

	// Token: 0x040045D6 RID: 17878
	public int SithCombo;

	// Token: 0x040045D7 RID: 17879
	public GameObject SithHardHitbox;

	// Token: 0x040045D8 RID: 17880
	public GameObject SithHitbox;

	// Token: 0x040045D9 RID: 17881
	public GameObject SithTrail1;

	// Token: 0x040045DA RID: 17882
	public GameObject SithTrail2;

	// Token: 0x040045DB RID: 17883
	public Transform SithTrailEnd1;

	// Token: 0x040045DC RID: 17884
	public Transform SithTrailEnd2;

	// Token: 0x040045DD RID: 17885
	public ZoomScript Zoom;

	// Token: 0x040045DE RID: 17886
	public AudioClip SithOn;

	// Token: 0x040045DF RID: 17887
	public AudioClip SithOff;

	// Token: 0x040045E0 RID: 17888
	public AudioClip SithSwing;

	// Token: 0x040045E1 RID: 17889
	public AudioClip SithStrike;

	// Token: 0x040045E2 RID: 17890
	public AudioSource SithAudio;

	// Token: 0x040045E3 RID: 17891
	public float[] SithHardSpawnTime1;

	// Token: 0x040045E4 RID: 17892
	public float[] SithHardSpawnTime2;

	// Token: 0x040045E5 RID: 17893
	public float[] SithSpawnTime;

	// Token: 0x040045E6 RID: 17894
	public Texture SnakeFace;

	// Token: 0x040045E7 RID: 17895
	public Texture SnakeBody;

	// Token: 0x040045E8 RID: 17896
	public Texture Stone;

	// Token: 0x040045E9 RID: 17897
	public AudioClip Petrify;

	// Token: 0x040045EA RID: 17898
	public GameObject Pebbles;

	// Token: 0x040045EB RID: 17899
	public bool Medusa;

	// Token: 0x040045EC RID: 17900
	public Texture GazerFace;

	// Token: 0x040045ED RID: 17901
	public Texture GazerBody;

	// Token: 0x040045EE RID: 17902
	public GazerEyesScript GazerEyes;

	// Token: 0x040045EF RID: 17903
	public AudioClip FingerSnap;

	// Token: 0x040045F0 RID: 17904
	public AudioClip Zap;

	// Token: 0x040045F1 RID: 17905
	public bool GazeAttacking;

	// Token: 0x040045F2 RID: 17906
	public bool Snapping;

	// Token: 0x040045F3 RID: 17907
	public bool Gazing;

	// Token: 0x040045F4 RID: 17908
	public int SnapPhase;

	// Token: 0x040045F5 RID: 17909
	public GameObject SixRaincoat;

	// Token: 0x040045F6 RID: 17910
	public GameObject RisingSmoke;

	// Token: 0x040045F7 RID: 17911
	public GameObject DarkHelix;

	// Token: 0x040045F8 RID: 17912
	public Texture SixFaceTexture;

	// Token: 0x040045F9 RID: 17913
	public AudioClip SixTakedown;

	// Token: 0x040045FA RID: 17914
	public Transform SixTarget;

	// Token: 0x040045FB RID: 17915
	public Mesh SixBodyMesh;

	// Token: 0x040045FC RID: 17916
	public Transform Mouth;

	// Token: 0x040045FD RID: 17917
	public int EatPhase;

	// Token: 0x040045FE RID: 17918
	public bool Hungry;

	// Token: 0x040045FF RID: 17919
	public int Hunger;

	// Token: 0x04004600 RID: 17920
	public float[] BloodTimes;

	// Token: 0x04004601 RID: 17921
	public AudioClip[] Snarls;

	// Token: 0x04004602 RID: 17922
	public Mesh HeadAndKnees;

	// Token: 0x04004603 RID: 17923
	public Texture KLKBody;

	// Token: 0x04004604 RID: 17924
	public Texture KLKFace;

	// Token: 0x04004605 RID: 17925
	public GameObject[] KLKParts;

	// Token: 0x04004606 RID: 17926
	public GameObject KLKSword;

	// Token: 0x04004607 RID: 17927
	public AudioClip LoveLoveBeamVoice;

	// Token: 0x04004608 RID: 17928
	public GameObject MiyukiCostume;

	// Token: 0x04004609 RID: 17929
	public GameObject LoveLoveBeam;

	// Token: 0x0400460A RID: 17930
	public GameObject MiyukiWings;

	// Token: 0x0400460B RID: 17931
	public Texture MiyukiSkin;

	// Token: 0x0400460C RID: 17932
	public Texture MiyukiFace;

	// Token: 0x0400460D RID: 17933
	public bool MagicalGirl;

	// Token: 0x0400460E RID: 17934
	public int BeamPhase;

	// Token: 0x0400460F RID: 17935
	public GameObject AzurGuns;

	// Token: 0x04004610 RID: 17936
	public GameObject AzurWater;

	// Token: 0x04004611 RID: 17937
	public GameObject AzurMist;

	// Token: 0x04004612 RID: 17938
	public GameObject Shell;

	// Token: 0x04004613 RID: 17939
	public Transform[] Guns;

	// Token: 0x04004614 RID: 17940
	public int ShotsFired;

	// Token: 0x04004615 RID: 17941
	public bool Shipgirl;

	// Token: 0x04004616 RID: 17942
	public GameObject GarbageBag;

	// Token: 0x04004617 RID: 17943
	public GameObject TallLadyAttacher;

	// Token: 0x04004618 RID: 17944
	public GameObject BlackRose;

	// Token: 0x04004619 RID: 17945
	public GameObject FloppyHat;

	// Token: 0x0400461A RID: 17946
	public AudioClip Swoosh;

	// Token: 0x0400461B RID: 17947
	public DynamicBone[] BoobPhysics;

	// Token: 0x0400461C RID: 17948
	public Transform[] AllFingers;

	// Token: 0x0400461D RID: 17949
	public float FingerLength;

	// Token: 0x0400461E RID: 17950
	public bool LongFingers;

	// Token: 0x0400461F RID: 17951
	public bool Swiping;

	// Token: 0x04004620 RID: 17952
	public int SwipeID;

	// Token: 0x04004621 RID: 17953
	public CameraFilterPack_Colors_Adjust_PreFilters HollowFilter;

	// Token: 0x04004622 RID: 17954
	public GameObject HollowCloakAttacher;

	// Token: 0x04004623 RID: 17955
	public GameObject HollowSword;

	// Token: 0x04004624 RID: 17956
	public GameObject HollowMask;

	// Token: 0x04004625 RID: 17957
	public GameObject DarkParticles;

	// Token: 0x04004626 RID: 17958
	public Texture HollowBodyTexture;

	// Token: 0x04004627 RID: 17959
	public Texture HollowFaceTexture;

	// Token: 0x04004628 RID: 17960
	public Mesh NoButtMesh;

	// Token: 0x04004629 RID: 17961
	public float ArmSize;

	// Token: 0x0400462A RID: 17962
	public BlacklightEffect BlacklightShader;

	// Token: 0x0400462B RID: 17963
	public GameObject BlacklightOutfit;

	// Token: 0x0400462C RID: 17964
	public Mesh BlacklightBodyMesh;

	// Token: 0x0400462D RID: 17965
	public RiggedAccessoryAttacher RaincoatAttacher;

	// Token: 0x0400462E RID: 17966
	public GameObject Rain;

	// Token: 0x0400462F RID: 17967
	public Material HorrorSkybox;

	// Token: 0x04004630 RID: 17968
	public Texture YamikoFaceTexture;

	// Token: 0x04004631 RID: 17969
	public Texture YamikoSkinTexture;

	// Token: 0x04004632 RID: 17970
	public Texture YamikoAccessoryTexture;

	// Token: 0x04004633 RID: 17971
	public GameObject LifeNotebook;

	// Token: 0x04004634 RID: 17972
	public GameObject LifeNotePen;

	// Token: 0x04004635 RID: 17973
	public Mesh YamikoMesh;

	// Token: 0x04004636 RID: 17974
	public GameObject GroundImpact;

	// Token: 0x04004637 RID: 17975
	public GameObject NierCostume;

	// Token: 0x04004638 RID: 17976
	public GameObject HeavySword;

	// Token: 0x04004639 RID: 17977
	public GameObject LightSword;

	// Token: 0x0400463A RID: 17978
	public GameObject Pod;

	// Token: 0x0400463B RID: 17979
	public Transform LightSwordParent;

	// Token: 0x0400463C RID: 17980
	public Transform HeavySwordParent;

	// Token: 0x0400463D RID: 17981
	public ParticleSystem LightSwordParticles;

	// Token: 0x0400463E RID: 17982
	public ParticleSystem HeavySwordParticles;

	// Token: 0x0400463F RID: 17983
	public string AttackPrefix;

	// Token: 0x04004640 RID: 17984
	public float NierDamage;

	// Token: 0x04004641 RID: 17985
	public float[] NierSpawnTime;

	// Token: 0x04004642 RID: 17986
	public float[] NierHardSpawnTime;

	// Token: 0x04004643 RID: 17987
	public AudioClip NierSwoosh;

	// Token: 0x04004644 RID: 17988
	public GameObject ChinaDress;

	// Token: 0x04004645 RID: 17989
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x04004646 RID: 17990
	public Material VaporwaveSkybox;

	// Token: 0x04004647 RID: 17991
	public GameObject PalmTrees;

	// Token: 0x04004648 RID: 17992
	public GameObject[] Trees;

	// Token: 0x04004649 RID: 17993
	public Mesh SchoolSwimsuit;

	// Token: 0x0400464A RID: 17994
	public Mesh GymUniform;

	// Token: 0x0400464B RID: 17995
	public Mesh Towel;

	// Token: 0x0400464C RID: 17996
	public Texture FaceTexture;

	// Token: 0x0400464D RID: 17997
	public Texture SwimsuitTexture;

	// Token: 0x0400464E RID: 17998
	public Texture EightiesGymTexture;

	// Token: 0x0400464F RID: 17999
	public Texture GymTexture;

	// Token: 0x04004650 RID: 18000
	public Texture TextureToUse;

	// Token: 0x04004651 RID: 18001
	public Texture TowelTexture;

	// Token: 0x04004652 RID: 18002
	public bool Casual = true;

	// Token: 0x04004653 RID: 18003
	public Mesh JudoGiMesh;

	// Token: 0x04004654 RID: 18004
	public Texture JudoGiTexture;

	// Token: 0x04004655 RID: 18005
	public Mesh ApronMesh;

	// Token: 0x04004656 RID: 18006
	public Texture ApronTexture;

	// Token: 0x04004657 RID: 18007
	public Mesh LabCoatMesh;

	// Token: 0x04004658 RID: 18008
	public Mesh HeadAndHands;

	// Token: 0x04004659 RID: 18009
	public Texture LabCoatTexture;

	// Token: 0x0400465A RID: 18010
	public RiggedAccessoryAttacher LabcoatAttacher;

	// Token: 0x0400465B RID: 18011
	public bool Paint;

	// Token: 0x0400465C RID: 18012
	public GameObject[] ClubAccessories;

	// Token: 0x0400465D RID: 18013
	public GameObject Fireball;

	// Token: 0x0400465E RID: 18014
	public bool LiftOff;

	// Token: 0x0400465F RID: 18015
	public GameObject LiftOffParticles;

	// Token: 0x04004660 RID: 18016
	public float LiftOffSpeed;

	// Token: 0x04004661 RID: 18017
	public SkinnedMeshUpdater SkinUpdater;

	// Token: 0x04004662 RID: 18018
	public Mesh RivalChanMesh;

	// Token: 0x04004663 RID: 18019
	public Mesh TestMesh;

	// Token: 0x04004664 RID: 18020
	public bool BullyPhoto;

	// Token: 0x04004665 RID: 18021
	public CameraFilterScript CinematicCameraFilters;

	// Token: 0x04004666 RID: 18022
	public CameraFilterScript CameraFilters;

	// Token: 0x04004667 RID: 18023
	public float mass = 3f;

	// Token: 0x04004668 RID: 18024
	public Vector3 impact = Vector3.zero;

	// Token: 0x04004669 RID: 18025
	public RaycastHit hit;

	// Token: 0x0400466A RID: 18026
	public Transform RaycastOrigin;

	// Token: 0x0400466B RID: 18027
	public bool Jumping;

	// Token: 0x0400466C RID: 18028
	public float SlowDownSpeed = 1f;

	// Token: 0x0400466D RID: 18029
	public AudioClip[] EightiesLaughs;

	// Token: 0x0400466E RID: 18030
	public Texture EightiesUniform;

	// Token: 0x0400466F RID: 18031
	public Texture EightiesCasual;

	// Token: 0x04004670 RID: 18032
	public GameObject EightiesCamera;

	// Token: 0x04004671 RID: 18033
	public Transform ModernCamera;

	// Token: 0x04004672 RID: 18034
	public Renderer EightiesPonytailRenderer;
}