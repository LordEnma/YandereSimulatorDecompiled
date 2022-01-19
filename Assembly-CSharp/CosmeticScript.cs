using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200025E RID: 606
public class CosmeticScript : MonoBehaviour
{
	// Token: 0x060012C3 RID: 4803 RVA: 0x0009C2A8 File Offset: 0x0009A4A8
	public void Start()
	{
		if (this.StudentManager != null)
		{
			this.Eighties = this.StudentManager.Eighties;
		}
		else
		{
			this.Eighties = GameGlobals.Eighties;
		}
		if (this.Eighties && this.Male)
		{
			this.MaleUniformTextures[1] = this.EightiesMaleCasualTexture;
			this.MaleCasualTextures[1] = this.EightiesMaleUniformTexture;
			this.MaleSocksTextures[1] = this.EightiesMaleSocksTexture;
			int i = 66;
			while (i < this.Trunks.Length)
			{
				if (this.Trunks[i] != null)
				{
					this.Trunks[i] = this.Trunks[0];
					i++;
				}
			}
		}
		if (this.Cutscene && EventGlobals.OsanaConversation)
		{
			this.StudentID = 11;
		}
		if (this.RightShoe != null)
		{
			this.RightShoe.SetActive(false);
			this.LeftShoe.SetActive(false);
		}
		this.ColorValue = new Color(1f, 1f, 1f, 1f);
		if (this.JSON == null)
		{
			this.JSON = this.Student.JSON;
		}
		string name = string.Empty;
		if (!this.Initialized)
		{
			this.Accessory = int.Parse(this.JSON.Students[this.StudentID].Accessory);
			this.Hairstyle = int.Parse(this.JSON.Students[this.StudentID].Hairstyle);
			this.Stockings = this.JSON.Students[this.StudentID].Stockings;
			this.BreastSize = this.JSON.Students[this.StudentID].BreastSize;
			this.EyeType = this.JSON.Students[this.StudentID].EyeType;
			this.HairColor = this.JSON.Students[this.StudentID].Color;
			this.EyeColor = this.JSON.Students[this.StudentID].Eyes;
			this.Club = this.JSON.Students[this.StudentID].Club;
			this.Name = this.JSON.Students[this.StudentID].Name;
			if (this.Yandere)
			{
				this.Accessory = 0;
				this.Hairstyle = 1;
				this.Stockings = "Black";
				this.BreastSize = 1f;
				this.HairColor = "White";
				this.EyeColor = "Black";
				this.Club = ClubType.None;
			}
			this.OriginalStockings = this.Stockings;
			this.Initialized = true;
		}
		if (this.Medibang)
		{
			this.Accessory = 0;
			this.Hairstyle = 56;
			this.Stockings = "";
			this.BreastSize = 1f;
			this.EyeType = "";
			this.HairColor = "";
			this.EyeColor = "";
			this.Club = ClubType.Occult;
			this.Name = "Edgy Example Girl";
		}
		if (this.Kidnapped)
		{
			this.Accessory = 0;
			this.EyewearID = 0;
		}
		if (!this.Eighties)
		{
			if (this.StudentID == 11)
			{
				if (DateGlobals.Week > 1 && !this.Kidnapped && !this.Student.Slave)
				{
					this.Hairstyle = 54;
				}
			}
			else if (this.StudentID == 36)
			{
				this.FacialHairstyle = 12;
				this.EyewearID = 8;
				if (this.StudentManager.TaskManager != null && this.StudentManager.TaskManager.TaskStatus[36] == 3)
				{
					Debug.Log("Gema is updating his appearance.");
					this.FacialHairstyle = 0;
					this.EyewearID = 9;
					this.Hairstyle = 49;
					this.Accessory = 0;
				}
			}
			else if (this.StudentID == 51 && ClubGlobals.GetClubClosed(ClubType.LightMusic))
			{
				this.Hairstyle = 51;
			}
		}
		if (this.StudentManager != null && this.StudentManager.EmptyDemon && (this.StudentID == 21 || this.StudentID == 26 || this.StudentID == 31 || this.StudentID == 36 || this.StudentID == 41 || this.StudentID == 46 || this.StudentID == 51 || this.StudentID == 56 || this.StudentID == 61 || this.StudentID == 66 || this.StudentID == 71))
		{
			if (!this.Male)
			{
				this.Hairstyle = 52;
			}
			else
			{
				this.Hairstyle = 53;
			}
			this.FacialHairstyle = 0;
			this.EyewearID = 0;
			this.Accessory = 0;
			this.Stockings = "";
			this.BreastSize = 1f;
			this.Empty = true;
		}
		if (this.Name == "Random")
		{
			this.Randomize = true;
			if (!this.Male)
			{
				name = this.StudentManager.FirstNames[UnityEngine.Random.Range(0, this.StudentManager.FirstNames.Length)] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, this.StudentManager.LastNames.Length)];
				this.JSON.Students[this.StudentID].Name = name;
				this.Student.Name = name;
			}
			else
			{
				name = this.StudentManager.MaleNames[UnityEngine.Random.Range(0, this.StudentManager.MaleNames.Length)] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, this.StudentManager.LastNames.Length)];
				this.JSON.Students[this.StudentID].Name = name;
				this.Student.Name = name;
			}
			if (MissionModeGlobals.MissionMode && MissionModeGlobals.MissionTarget == this.StudentID)
			{
				this.JSON.Students[this.StudentID].Name = MissionModeGlobals.MissionTargetName;
				this.Student.Name = MissionModeGlobals.MissionTargetName;
				name = MissionModeGlobals.MissionTargetName;
			}
		}
		if (this.Randomize)
		{
			this.Teacher = false;
			this.BreastSize = UnityEngine.Random.Range(0.5f, 2f);
			this.Accessory = 0;
			this.Club = ClubType.None;
			if (!this.Male)
			{
				this.Hairstyle = UnityEngine.Random.Range(1, this.FemaleHair.Length);
			}
			else
			{
				this.SkinColor = UnityEngine.Random.Range(0, this.SkinTextures.Length);
				this.Hairstyle = UnityEngine.Random.Range(1, this.MaleHair.Length);
			}
		}
		this.DisableAccessories();
		bool flag = false;
		if (this.StudentManager != null && this.StudentID == this.StudentManager.SuitorID)
		{
			flag = true;
		}
		if (flag && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorEyewear > 0)
		{
			this.Eyewear[StudentGlobals.CustomSuitorEyewear].SetActive(true);
		}
		if (!this.Male)
		{
			this.FemaleUniformID = StudentGlobals.FemaleUniform;
			this.ThickBrows.SetActive(false);
			if (!this.TakingPortrait)
			{
				this.Tongue.SetActive(false);
			}
			foreach (GameObject gameObject in this.PhoneCharms)
			{
				if (gameObject != null)
				{
					gameObject.SetActive(false);
				}
			}
			if (QualitySettings.GetQualityLevel() > 1)
			{
				this.Student.BreastSize = 1f;
				this.BreastSize = 1f;
			}
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.RightWristband.SetActive(false);
			this.LeftWristband.SetActive(false);
			if (!this.Eighties)
			{
				if (this.StudentID == 51)
				{
					this.RightTemple.name = "RENAMED";
					this.LeftTemple.name = "RENAMED";
					this.RightTemple.localScale = new Vector3(0f, 1f, 1f);
					this.LeftTemple.localScale = new Vector3(0f, 1f, 1f);
					if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
					{
						this.SadBrows.SetActive(true);
					}
					else
					{
						this.ThickBrows.SetActive(true);
					}
				}
				else if (this.StudentID == 84 && StudentGlobals.GetStudentDead(81) && StudentGlobals.GetStudentDead(82) && StudentGlobals.GetStudentDead(83) && StudentGlobals.GetStudentDead(85))
				{
					this.Student.Club = ClubType.None;
					this.Club = ClubType.None;
					this.Hairstyle = 53;
				}
			}
			if (this.Club == ClubType.Bully)
			{
				if (!this.Kidnapped)
				{
					this.Student.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.SmartphoneTextures[this.StudentID];
					this.Student.SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0.01f);
					this.Student.SmartPhone.transform.localEulerAngles = new Vector3(0f, -160f, 165f);
				}
				this.RightWristband.GetComponent<Renderer>().material.mainTexture = this.WristwearTextures[this.StudentID];
				this.LeftWristband.GetComponent<Renderer>().material.mainTexture = this.WristwearTextures[this.StudentID];
				this.Bookbag.GetComponent<Renderer>().material.mainTexture = this.BookbagTextures[this.StudentID];
				this.HoodieRenderer.material.mainTexture = this.HoodieTextures[this.StudentID];
				this.Bookbag.GetComponent<MeshFilter>().mesh = this.ModernBookBagMesh;
				if (this.PhoneCharms.Length != 0)
				{
					this.PhoneCharms[this.StudentID].SetActive(true);
				}
				if (this.FemaleUniformID < 2 || this.FemaleUniformID == 3)
				{
					this.RightWristband.SetActive(true);
					this.LeftWristband.SetActive(true);
				}
				this.Bookbag.SetActive(true);
				this.Hoodie.SetActive(true);
				for (int k = 0; k < 10; k++)
				{
					this.Fingernails[k].material.mainTexture = this.GanguroNailTextures[this.StudentID];
				}
				this.Student.GymTexture = this.TanGymTexture;
				this.Student.TowelTexture = this.TanTowelTexture;
			}
			else
			{
				for (int l = 0; l < 10; l++)
				{
					this.Fingernails[l].gameObject.SetActive(false);
				}
				if (this.Club == ClubType.Gardening && !this.TakingPortrait && !this.Kidnapped)
				{
					this.CanRenderer.material.mainTexture = this.CanTextures[this.StudentID];
				}
			}
			if (!this.Kidnapped && SceneManager.GetActiveScene().name == "PortraitScene")
			{
				if (!this.Eighties)
				{
					if (this.StudentID == 2)
					{
						this.CharacterAnimation.Play("succubus_a_idle_twins_01");
						base.transform.position = new Vector3(0.094f, 0f, 0f);
						this.LookCamera = true;
						this.CharacterAnimation["f02_smile_00"].layer = 1;
						this.CharacterAnimation.Play("f02_smile_00");
						this.CharacterAnimation["f02_smile_00"].weight = 1f;
					}
					else if (this.StudentID == 3)
					{
						this.CharacterAnimation.Play("succubus_b_idle_twins_02");
						base.transform.position = new Vector3(-0.322f, 0.04f, 0f);
						this.LookCamera = true;
						this.CharacterAnimation["f02_smile_00"].layer = 1;
						this.CharacterAnimation.Play("f02_smile_00");
						this.CharacterAnimation["f02_smile_00"].weight = 1f;
					}
					else if (this.StudentID == 4)
					{
						this.CharacterAnimation.Play("f02_idleShort_00");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						this.LookCamera = true;
					}
					else if (this.StudentID == 5)
					{
						this.CharacterAnimation[this.Student.ShyAnim].layer = 5;
						this.CharacterAnimation.Play(this.Student.ShyAnim);
						this.CharacterAnimation[this.Student.ShyAnim].weight = 0.5f;
					}
					else if (this.StudentID == 10)
					{
						this.CharacterAnimation.Play("f02_raibaruPortraitPose_00");
					}
					else if (this.StudentID == 11)
					{
						this.CharacterAnimation.Play("f02_rivalPortraitPose_01");
						base.transform.position = new Vector3(-0.045f, 0f, 0f);
					}
					else if (this.StudentID == 24)
					{
						this.CharacterAnimation.Play("f02_idleGirly_00");
						this.CharacterAnimation["f02_idleGirly_00"].time = 1f;
					}
					else if (this.StudentID == 25)
					{
						this.CharacterAnimation.Play("f02_idleGirly_00");
						this.CharacterAnimation["f02_idleGirly_00"].time = 0f;
					}
					else if (this.StudentID == 30)
					{
						this.CharacterAnimation.Play("f02_idleGirly_00");
						this.CharacterAnimation["f02_idleGirly_00"].time = 0f;
					}
					else if (this.StudentID == 34)
					{
						this.CharacterAnimation.Play("f02_idleShort_00");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						this.LookCamera = true;
					}
					else if (this.StudentID == 35)
					{
						this.CharacterAnimation.Play("f02_idleShort_00");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						this.LookCamera = true;
					}
					else if (this.StudentID == 38)
					{
						this.CharacterAnimation.Play("f02_idleGirly_00");
						this.CharacterAnimation["f02_idleGirly_00"].time = 0f;
					}
					else if (this.StudentID == 39)
					{
						this.CharacterAnimation.Play("f02_socialCameraPose_00");
						base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.05f, base.transform.position.z);
					}
					else if (this.StudentID == 40)
					{
						this.CharacterAnimation.Play("f02_idleGirly_00");
						this.CharacterAnimation["f02_idleGirly_00"].time = 1f;
					}
					else if (this.StudentID == 51)
					{
						this.CharacterAnimation.Play("f02_musicPose_00");
						this.Tongue.SetActive(true);
					}
					else if (this.StudentID == 59)
					{
						this.CharacterAnimation.Play("f02_sleuthPortrait_00");
					}
					else if (this.StudentID == 60)
					{
						this.CharacterAnimation.Play("f02_sleuthPortrait_01");
					}
					else if (this.StudentID == 64)
					{
						this.CharacterAnimation.Play("f02_idleShort_00");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						this.LookCamera = true;
					}
					else if (this.StudentID == 65)
					{
						this.CharacterAnimation.Play("f02_idleShort_00");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						this.LookCamera = true;
					}
					else if (this.StudentID == 71)
					{
						this.CharacterAnimation.Play("f02_idleGirly_00");
						this.CharacterAnimation["f02_idleGirly_00"].time = 0f;
					}
					else if (this.StudentID == 72)
					{
						this.CharacterAnimation.Play("f02_idleGirly_00");
						this.CharacterAnimation["f02_idleGirly_00"].time = 0.66666f;
					}
					else if (this.StudentID == 73)
					{
						this.CharacterAnimation.Play("f02_idleGirly_00");
						this.CharacterAnimation["f02_idleGirly_00"].time = 1.33332f;
					}
					else if (this.StudentID == 74)
					{
						this.CharacterAnimation.Play("f02_idleGirly_00");
						this.CharacterAnimation["f02_idleGirly_00"].time = 1.99998f;
					}
					else if (this.StudentID == 75)
					{
						this.CharacterAnimation.Play("f02_idleGirly_00");
						this.CharacterAnimation["f02_idleGirly_00"].time = 2.66664f;
					}
					else if (this.StudentID == 81)
					{
						string str = "Casual";
						this.CharacterAnimation["f02_faceCouncil" + str + "_00"].layer = 1;
						this.CharacterAnimation.Play("f02_faceCouncil" + str + "_00");
						this.CharacterAnimation.Play("f02_socialCameraPose_00");
						base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.05f, base.transform.position.z);
					}
					else if (this.StudentID == 82 || this.StudentID == 52)
					{
						this.CharacterAnimation.Play("f02_galPose_01");
					}
					else if (this.StudentID == 83 || this.StudentID == 53)
					{
						this.CharacterAnimation.Play("f02_galPose_02");
					}
					else if (this.StudentID == 84 || this.StudentID == 54)
					{
						this.CharacterAnimation.Play("f02_galPose_03");
					}
					else if (this.StudentID == 85 || this.StudentID == 55)
					{
						this.CharacterAnimation.Play("f02_galPose_04");
					}
					else if (this.StudentID == 90)
					{
						this.CharacterAnimation.Play("f02_nursePortraitPose_00");
					}
					else if (this.StudentID == 91)
					{
						this.CharacterAnimation.Play("f02_teacherPortraitPose_11");
						base.transform.position = new Vector3(0.0233333f, 0f, 0f);
					}
					else if (this.StudentID == 92)
					{
						this.CharacterAnimation.Play("f02_teacherPortraitPose_12");
						base.transform.position = new Vector3(-0.045f, 0f, 0f);
					}
					else if (this.StudentID == 93)
					{
						this.CharacterAnimation.Play("f02_teacherPortraitPose_21");
					}
					else if (this.StudentID == 94)
					{
						this.CharacterAnimation.Play("f02_teacherPortraitPose_22");
					}
					else if (this.StudentID == 95)
					{
						this.CharacterAnimation.Play("f02_teacherPortraitPose_31");
					}
					else if (this.StudentID == 96)
					{
						this.CharacterAnimation.Play("f02_teacherPortraitPose_32");
					}
					else if (this.StudentID == 97)
					{
						this.CharacterAnimation.Play("f02_coachPortraitPose_00");
						base.transform.position = new Vector3(-0.029f, 0f, 0f);
					}
					else if (this.Club != ClubType.Council)
					{
						this.CharacterAnimation.Play("f02_idleShort_01");
						base.transform.position = new Vector3(0.015f, 0f, 0f);
						this.LookCamera = true;
					}
				}
				else
				{
					base.transform.position = new Vector3(0.015f, 0f, 0f);
					if (this.StudentID == 4)
					{
						this.CharacterAnimation.Play("f02_cutePose_00");
					}
					if (this.StudentID > 10 && this.StudentID < 20)
					{
						base.transform.position = new Vector3(0f, 0f, 0f);
						this.CharacterAnimation.Play("f02_eightiesRivalPose_0" + (this.StudentID - 10).ToString());
					}
					else if (this.StudentID == 20)
					{
						base.transform.position = new Vector3(0f, 0f, 0f);
						this.CharacterAnimation.Play("f02_eightiesRivalPose_10");
					}
					if (this.StudentID > 2 && this.StudentID < 7)
					{
						this.CharacterAnimation["f02_smile_00"].layer = 1;
						this.CharacterAnimation.Play("f02_smile_00");
						this.CharacterAnimation["f02_smile_00"].weight = 1f;
					}
				}
			}
		}
		else
		{
			this.MaleUniformID = StudentGlobals.MaleUniform;
			GameObject[] array = this.GaloAccessories;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].SetActive(false);
			}
			bool flag2 = false;
			if (this.StudentManager != null && this.StudentID == this.StudentManager.SuitorID)
			{
				flag2 = true;
			}
			if (flag2 && StudentGlobals.CustomSuitor)
			{
				if (StudentGlobals.CustomSuitorHair > 0)
				{
					this.Hairstyle = StudentGlobals.CustomSuitorHair;
				}
				if (StudentGlobals.CustomSuitorAccessory > 0)
				{
					this.Accessory = StudentGlobals.CustomSuitorAccessory;
					if (this.Accessory == 1)
					{
						Transform transform = this.MaleAccessories[1].transform;
						transform.localScale = new Vector3(1.066666f, 1f, 1f);
						transform.localPosition = new Vector3(0f, -1.525f, 0.0066666f);
					}
				}
				if (StudentGlobals.CustomSuitorBlack)
				{
					this.HairColor = "SolidBlack";
				}
				if (StudentGlobals.CustomSuitorJewelry > 0)
				{
					array = this.GaloAccessories;
					for (int j = 0; j < array.Length; j++)
					{
						array[j].SetActive(true);
					}
				}
			}
			if (this.StudentManager == null || !this.Eighties)
			{
				this.ThickBrows.SetActive(false);
				if (this.Club == ClubType.Occult)
				{
					this.CharacterAnimation["sadFace_00"].layer = 1;
					this.CharacterAnimation.Play("sadFace_00");
					this.CharacterAnimation["sadFace_00"].weight = 1f;
				}
				if (this.StudentID == 36 || this.StudentID == 66)
				{
					this.CharacterAnimation["toughFace_00"].layer = 1;
					this.CharacterAnimation.Play("toughFace_00");
					this.CharacterAnimation["toughFace_00"].weight = 1f;
					if (this.StudentID == 66)
					{
						this.ThickBrows.SetActive(true);
					}
				}
				if (SceneManager.GetActiveScene().name == "PortraitScene")
				{
					if (this.StudentID == 26)
					{
						this.CharacterAnimation.Play("idleHaughty_00");
					}
					else if (this.StudentID == 36)
					{
						this.CharacterAnimation.Play("slouchIdle_00");
					}
					else if (this.StudentID == 56)
					{
						this.CharacterAnimation.Play("idleConfident_00");
					}
					else if (this.StudentID == 57)
					{
						this.CharacterAnimation.Play("sleuthPortrait_00");
					}
					else if (this.StudentID == 58)
					{
						this.CharacterAnimation.Play("sleuthPortrait_01");
					}
					else if (this.StudentID == 61)
					{
						this.CharacterAnimation.Play("scienceMad_00");
						base.transform.position = new Vector3(0f, 0.1f, 0f);
					}
					else if (this.StudentID == 62)
					{
						this.CharacterAnimation.Play("idleFrown_00");
					}
					else if (this.StudentID == 69)
					{
						this.CharacterAnimation.Play("idleFrown_00");
					}
					else if (this.StudentID == 76)
					{
						this.CharacterAnimation.Play("delinquentPoseB");
					}
					else if (this.StudentID == 77)
					{
						this.CharacterAnimation.Play("delinquentPoseA");
					}
					else if (this.StudentID == 78)
					{
						this.CharacterAnimation.Play("delinquentPoseC");
					}
					else if (this.StudentID == 79)
					{
						this.CharacterAnimation.Play("delinquentPoseD");
					}
					else if (this.StudentID == 80)
					{
						this.CharacterAnimation.Play("delinquentPoseE");
					}
				}
			}
			else if (!this.Student.Posing)
			{
				if (this.Eighties)
				{
					if (this.StudentID == 86)
					{
						this.CharacterAnimation["toughFace_00"].layer = 1;
						this.CharacterAnimation.Play("toughFace_00");
						this.CharacterAnimation["toughFace_00"].weight = 1f;
					}
					if (this.Club == ClubType.Council)
					{
						this.CouncilBrows[this.StudentID - 85].SetActive(true);
					}
					if (this.StudentID == 76)
					{
						this.CharacterAnimation.Play("delinquentPoseB");
					}
					else if (this.StudentID == 77)
					{
						this.CharacterAnimation.Play("delinquentPoseA");
					}
					else if (this.StudentID == 78)
					{
						this.CharacterAnimation.Play("delinquentPoseC");
					}
					else if (this.StudentID == 79)
					{
						this.CharacterAnimation.Play("delinquentPoseD");
					}
					else if (this.StudentID == 80)
					{
						this.CharacterAnimation.Play("delinquentPoseE");
					}
				}
				if (this.Club == ClubType.Delinquent)
				{
					base.transform.position = new Vector3(0.005f, 0.03f, 0f);
				}
				else
				{
					base.transform.position = new Vector3(0.005f, 0f, 0f);
				}
			}
		}
		if (this.Club == ClubType.Teacher)
		{
			this.MyRenderer.sharedMesh = this.TeacherMesh;
			if (!SystemInfo.supportsComputeShaders)
			{
				this.MyRenderer.sharedMesh.ClearBlendShapes();
			}
			this.Teacher = true;
			if (this.Eighties)
			{
				this.Student.EightiesTeacherAttacher.SetActive(true);
				this.Student.MyRenderer.enabled = false;
			}
		}
		else if (this.Club == ClubType.GymTeacher)
		{
			if (!StudentGlobals.GetStudentReplaced(this.StudentID))
			{
				this.CharacterAnimation["f02_smile_00"].layer = 1;
				this.CharacterAnimation.Play("f02_smile_00");
				this.CharacterAnimation["f02_smile_00"].weight = 1f;
				this.RightEyeRenderer.gameObject.SetActive(false);
				this.LeftEyeRenderer.gameObject.SetActive(false);
			}
			this.MyRenderer.sharedMesh = this.CoachMesh;
			this.Teacher = true;
		}
		else if (this.Club == ClubType.Nurse)
		{
			if (!this.Eighties)
			{
				this.MyRenderer.sharedMesh = this.NurseMesh;
			}
			else
			{
				this.MyRenderer.sharedMesh = this.EightiesNurseMesh;
			}
			this.Teacher = true;
		}
		else if (this.Club == ClubType.Council)
		{
			this.Armband.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.285f, 0f));
			this.Armband.SetActive(true);
			string str2 = "";
			if (this.StudentID == 86)
			{
				str2 = "Strict";
			}
			if (this.StudentID == 87)
			{
				str2 = "Casual";
			}
			if (this.StudentID == 88)
			{
				str2 = "Grace";
			}
			if (this.StudentID == 89)
			{
				str2 = "Edgy";
			}
			if (!this.Eighties)
			{
				this.CharacterAnimation["f02_faceCouncil" + str2 + "_00"].layer = 1;
				this.CharacterAnimation.Play("f02_faceCouncil" + str2 + "_00");
				this.CharacterAnimation["f02_idleCouncil" + str2 + "_00"].time = 1f;
				this.CharacterAnimation.Play("f02_idleCouncil" + str2 + "_00");
			}
		}
		if (!ClubGlobals.GetClubClosed(this.Club) && (this.StudentID == 21 || this.StudentID == 26 || this.StudentID == 31 || this.StudentID == 36 || this.StudentID == 41 || this.StudentID == 46 || this.StudentID == 51 || this.StudentID == 56 || this.StudentID == 61 || this.StudentID == 66 || this.StudentID == 71))
		{
			this.Armband.SetActive(true);
			Renderer component = this.Armband.GetComponent<Renderer>();
			if (this.StudentID == 21)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, -0.145f));
			}
			else if (this.StudentID == 26)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.145f));
			}
			else if (this.StudentID == 31)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.57f, 0f));
			}
			else if (this.StudentID == 36)
			{
				if (!this.Eighties)
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, -0.29f));
				}
				else
				{
					component.material.SetTextureOffset("_MainTex", new Vector2(0.57f, -0.435f));
				}
			}
			else if (this.StudentID == 41)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.58f));
			}
			else if (this.StudentID == 46)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.435f));
			}
			else if (this.StudentID == 51)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.57f, -0.29f));
			}
			else if (this.StudentID == 56)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, -0.29f));
			}
			else if (this.StudentID == 61)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
			}
			else if (this.StudentID == 66)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.57f, -0.145f));
			}
			else if (this.StudentID == 71)
			{
				component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, -0.435f));
			}
		}
		if (this.StudentID == 1 && SenpaiGlobals.CustomSenpai)
		{
			if (SenpaiGlobals.SenpaiEyeWear > 0)
			{
				this.Eyewear[SenpaiGlobals.SenpaiEyeWear].SetActive(true);
			}
			this.FacialHairstyle = SenpaiGlobals.SenpaiFacialHair;
			this.HairColor = SenpaiGlobals.SenpaiHairColor;
			this.EyeColor = SenpaiGlobals.SenpaiEyeColor;
			this.Hairstyle = SenpaiGlobals.SenpaiHairStyle;
		}
		if (!this.Male)
		{
			if (!this.Teacher)
			{
				this.FemaleHair[this.Hairstyle].SetActive(true);
				this.HairRenderer = this.FemaleHairRenderers[this.Hairstyle];
				this.SetFemaleUniform();
			}
			else
			{
				this.TeacherHair[this.Hairstyle].SetActive(true);
				this.HairRenderer = this.TeacherHairRenderers[this.Hairstyle];
				if (this.Club == ClubType.Teacher)
				{
					this.MyRenderer.materials[1].mainTexture = this.TeacherBodyTexture;
					this.MyRenderer.materials[2].mainTexture = this.DefaultFaceTexture;
					this.MyRenderer.materials[0].mainTexture = this.TeacherBodyTexture;
				}
				else if (this.Club == ClubType.GymTeacher)
				{
					if (StudentGlobals.GetStudentReplaced(this.StudentID))
					{
						this.MyRenderer.materials[2].mainTexture = this.DefaultFaceTexture;
						this.MyRenderer.materials[0].mainTexture = this.CoachPaleBodyTexture;
						this.MyRenderer.materials[1].mainTexture = this.CoachPaleBodyTexture;
					}
					else
					{
						if (!this.Eighties)
						{
							this.MyRenderer.materials[2].mainTexture = this.CoachFaceTexture;
						}
						else
						{
							this.MyRenderer.materials[2].mainTexture = this.EightiesCoachFaceTexture;
						}
						this.MyRenderer.materials[0].mainTexture = this.CoachBodyTexture;
						this.MyRenderer.materials[1].mainTexture = this.CoachBodyTexture;
					}
				}
				else if (this.Club == ClubType.Nurse)
				{
					if (!this.Eighties)
					{
						this.MyRenderer.materials = this.NurseMaterials;
					}
					else
					{
						this.MyRenderer.materials = this.EightiesNurseMaterials;
					}
				}
			}
		}
		else
		{
			if (this.Hairstyle > 0)
			{
				this.MaleHair[this.Hairstyle].SetActive(true);
				this.HairRenderer = this.MaleHairRenderers[this.Hairstyle];
			}
			if (this.FacialHairstyle > 0)
			{
				this.FacialHair[this.FacialHairstyle].SetActive(true);
				this.FacialHairRenderer = this.FacialHairRenderers[this.FacialHairstyle];
			}
			if (this.EyewearID > 0)
			{
				this.Eyewear[this.EyewearID].SetActive(true);
			}
			this.SetMaleUniform();
		}
		if (!this.Male)
		{
			if (!this.Teacher)
			{
				if (this.FemaleAccessories[this.Accessory] != null)
				{
					this.FemaleAccessories[this.Accessory].SetActive(true);
				}
			}
			else if (this.TeacherAccessories[this.Accessory] != null)
			{
				this.TeacherAccessories[this.Accessory].SetActive(true);
			}
		}
		else if (this.MaleAccessories[this.Accessory] != null)
		{
			this.MaleAccessories[this.Accessory].SetActive(true);
		}
		if (this.StudentManager == null || (!this.Empty && !this.StudentManager.TutorialActive))
		{
			if (this.StudentManager == null || !this.Eighties)
			{
				if ((this.Club < ClubType.Gaming || this.Club == ClubType.Newspaper) && this.ClubAccessories[(int)this.Club] != null && !ClubGlobals.GetClubClosed(this.Club) && this.StudentID != 26)
				{
					this.ClubAccessories[(int)this.Club].SetActive(true);
				}
				if (!this.Eighties && this.StudentID == 36)
				{
					this.ClubAccessories[(int)this.Club].SetActive(true);
				}
				if (this.Club == ClubType.Cooking)
				{
					this.ClubAccessories[(int)this.Club].SetActive(false);
					this.ClubAccessories[(int)this.Club] = this.Kerchiefs[this.StudentID];
					if (!ClubGlobals.GetClubClosed(this.Club) && this.StudentID > 12)
					{
						this.ClubAccessories[(int)this.Club].SetActive(true);
					}
				}
				else if (this.Club == ClubType.Drama)
				{
					this.ClubAccessories[(int)this.Club].SetActive(false);
					this.ClubAccessories[(int)this.Club] = this.Roses[this.StudentID];
					if (!ClubGlobals.GetClubClosed(this.Club))
					{
						this.ClubAccessories[(int)this.Club].SetActive(true);
					}
				}
				else if (this.Club == ClubType.Art)
				{
					this.ClubAccessories[(int)this.Club].GetComponent<MeshFilter>().sharedMesh = this.Berets[this.StudentID];
					if (this.StudentID == 44)
					{
						this.ClubAccessories[(int)this.Club].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						this.ClubAccessories[(int)this.Club].transform.localScale = new Vector3(100f, 100f, 100f);
						this.ClubAccessories[(int)this.Club].transform.localPosition = new Vector3(0f, -1.445f, 0.02f);
					}
				}
				else if (this.Club == ClubType.Science)
				{
					this.ClubAccessories[(int)this.Club].SetActive(false);
					this.ClubAccessories[(int)this.Club] = this.Scanners[this.StudentID];
					if (!ClubGlobals.GetClubClosed(this.Club))
					{
						this.ClubAccessories[(int)this.Club].SetActive(true);
					}
				}
				else if (this.Club == ClubType.LightMusic)
				{
					this.ClubAccessories[(int)this.Club].SetActive(false);
					this.ClubAccessories[(int)this.Club] = this.MusicNotes[this.StudentID - 50];
					if (!ClubGlobals.GetClubClosed(this.Club))
					{
						this.ClubAccessories[(int)this.Club].SetActive(true);
					}
				}
				else if (this.Club == ClubType.Sports)
				{
					this.ClubAccessories[(int)this.Club].SetActive(false);
					this.ClubAccessories[(int)this.Club] = this.Goggles[this.StudentID];
					if (!ClubGlobals.GetClubClosed(this.Club))
					{
						this.ClubAccessories[(int)this.Club].SetActive(true);
					}
				}
				else if (this.Club == ClubType.Gardening)
				{
					this.ClubAccessories[(int)this.Club].SetActive(false);
					this.ClubAccessories[(int)this.Club] = this.Flowers[this.StudentID];
					if (!ClubGlobals.GetClubClosed(this.Club))
					{
						this.ClubAccessories[(int)this.Club].SetActive(true);
					}
				}
				else if (this.Club == ClubType.Gaming)
				{
					if (this.ClubAccessories[(int)this.Club] != null)
					{
						this.ClubAccessories[(int)this.Club].SetActive(false);
					}
					this.ClubAccessories[(int)this.Club] = this.RedCloth[this.StudentID];
					if (!ClubGlobals.GetClubClosed(this.Club) && this.ClubAccessories[(int)this.Club] != null)
					{
						this.ClubAccessories[(int)this.Club].SetActive(true);
					}
				}
			}
			if (!this.Eighties && this.StudentID == 36 && this.StudentManager != null && this.StudentManager.TaskManager != null && this.StudentManager.TaskManager.TaskStatus[36] == 3)
			{
				this.ClubAccessories[(int)this.Club].SetActive(false);
			}
		}
		if (this.StudentID == 11 && !this.TakingPortrait && !this.Cutscene && !this.Kidnapped && SceneManager.GetActiveScene().name == "SchoolScene")
		{
			this.CatGifts[1].SetActive(CollectibleGlobals.GetGiftGiven(1));
			this.CatGifts[2].SetActive(CollectibleGlobals.GetGiftGiven(2));
			this.CatGifts[3].SetActive(CollectibleGlobals.GetGiftGiven(3));
			this.CatGifts[4].SetActive(CollectibleGlobals.GetGiftGiven(4));
		}
		if (!this.Male)
		{
			base.StartCoroutine(this.PutOnStockings());
		}
		if (!this.Randomize)
		{
			if (this.EyeColor != string.Empty)
			{
				if (this.EyeColor == "White")
				{
					this.CorrectColor = new Color(1f, 1f, 1f);
				}
				else if (this.EyeColor == "Black")
				{
					this.CorrectColor = new Color(0.5f, 0.5f, 0.5f);
				}
				else if (this.EyeColor == "Red")
				{
					this.CorrectColor = new Color(1f, 0f, 0f);
				}
				else if (this.EyeColor == "Yellow")
				{
					this.CorrectColor = new Color(1f, 1f, 0f);
				}
				else if (this.EyeColor == "Green")
				{
					this.CorrectColor = new Color(0f, 1f, 0f);
				}
				else if (this.EyeColor == "Cyan")
				{
					this.CorrectColor = new Color(0f, 1f, 1f);
				}
				else if (this.EyeColor == "Blue")
				{
					this.CorrectColor = new Color(0f, 0f, 1f);
				}
				else if (this.EyeColor == "Purple")
				{
					this.CorrectColor = new Color(1f, 0f, 1f);
				}
				else if (this.EyeColor == "Orange")
				{
					this.CorrectColor = new Color(1f, 0.5f, 0f);
				}
				else if (this.EyeColor == "Brown")
				{
					this.CorrectColor = new Color(0.5f, 0.25f, 0f);
				}
				else
				{
					this.CorrectColor = new Color(0f, 0f, 0f);
				}
				if (this.StudentID > 90 && this.StudentID < 97)
				{
					this.CorrectColor.r = this.CorrectColor.r * 0.5f;
					this.CorrectColor.g = this.CorrectColor.g * 0.5f;
					this.CorrectColor.b = this.CorrectColor.b * 0.5f;
				}
				if (this.CorrectColor != new Color(0f, 0f, 0f))
				{
					this.RightEyeRenderer.material.color = this.CorrectColor;
					this.LeftEyeRenderer.material.color = this.CorrectColor;
				}
			}
		}
		else
		{
			float r = UnityEngine.Random.Range(0f, 1f);
			float g = UnityEngine.Random.Range(0f, 1f);
			float b = UnityEngine.Random.Range(0f, 1f);
			this.RightEyeRenderer.material.color = new Color(r, g, b);
			this.LeftEyeRenderer.material.color = new Color(r, g, b);
		}
		if (!this.Randomize)
		{
			if (this.HairColor == "White")
			{
				this.ColorValue = new Color(1f, 1f, 1f);
			}
			else if (this.HairColor == "Black")
			{
				this.ColorValue = new Color(0.5f, 0.5f, 0.5f);
			}
			else if (this.HairColor == "SolidBlack")
			{
				this.ColorValue = new Color(0.0001f, 0.0001f, 0.0001f);
			}
			else if (this.HairColor == "Red")
			{
				this.ColorValue = new Color(1f, 0f, 0f);
			}
			else if (this.HairColor == "Yellow")
			{
				this.ColorValue = new Color(1f, 1f, 0f);
			}
			else if (this.HairColor == "Green")
			{
				this.ColorValue = new Color(0f, 1f, 0f);
			}
			else if (this.HairColor == "Cyan")
			{
				this.ColorValue = new Color(0f, 1f, 1f);
			}
			else if (this.HairColor == "Blue")
			{
				this.ColorValue = new Color(0f, 0f, 1f);
			}
			else if (this.HairColor == "Purple")
			{
				this.ColorValue = new Color(1f, 0f, 1f);
			}
			else if (this.HairColor == "Orange")
			{
				this.ColorValue = new Color(1f, 0.5f, 0f);
			}
			else if (this.HairColor == "Brown")
			{
				this.ColorValue = new Color(0.5f, 0.25f, 0f);
			}
			else
			{
				this.ColorValue = new Color(0f, 0f, 0f);
				this.RightIrisLight.SetActive(false);
				this.LeftIrisLight.SetActive(false);
			}
			if (this.StudentID > 90 && this.StudentID < 97)
			{
				this.ColorValue.r = this.ColorValue.r * 0.5f;
				this.ColorValue.g = this.ColorValue.g * 0.5f;
				this.ColorValue.b = this.ColorValue.b * 0.5f;
			}
			if (this.ColorValue == new Color(0f, 0f, 0f))
			{
				if (this.HairRenderer != null)
				{
					this.RightEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
					this.LeftEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
					if (!this.DoNotChangeFace)
					{
						this.FaceTexture = this.HairRenderer.material.mainTexture;
					}
				}
				if (this.Empty)
				{
					this.FaceTexture = this.GrayFace;
				}
				this.CustomHair = true;
			}
			if (!this.CustomHair)
			{
				if (this.Hairstyle > 0)
				{
					if (GameGlobals.LoveSick)
					{
						this.HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
						if (this.HairRenderer.materials.Length > 1)
						{
							this.HairRenderer.materials[1].color = new Color(0.1f, 0.1f, 0.1f);
						}
					}
					else
					{
						this.HairRenderer.material.color = this.ColorValue;
					}
				}
			}
			else if (GameGlobals.LoveSick)
			{
				this.HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
				if (this.HairRenderer.materials.Length > 1)
				{
					this.HairRenderer.materials[1].color = new Color(0.1f, 0.1f, 0.1f);
				}
			}
			if (!this.Male)
			{
				if (this.StudentID == 25)
				{
					this.FemaleAccessories[6].GetComponent<Renderer>().material.color = new Color(0f, 1f, 1f);
				}
				else if (this.StudentID == 30)
				{
					this.FemaleAccessories[6].GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f);
				}
			}
		}
		else
		{
			this.HairRenderer.material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
		if (!this.Teacher)
		{
			if (this.CustomHair)
			{
				if (!this.Male)
				{
					this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				}
				else if (this.Club == ClubType.Council)
				{
					this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
				}
				else if (this.MaleUniformID == 1)
				{
					this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				}
				else if (this.MaleUniformID < 4)
				{
					this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
				}
			}
		}
		else if (this.Teacher && StudentGlobals.GetStudentReplaced(this.StudentID))
		{
			Color studentColor = StudentGlobals.GetStudentColor(this.StudentID);
			Color studentEyeColor = StudentGlobals.GetStudentEyeColor(this.StudentID);
			this.HairRenderer.material.color = studentColor;
			this.RightEyeRenderer.material.color = studentEyeColor;
			this.LeftEyeRenderer.material.color = studentEyeColor;
		}
		if (this.Male)
		{
			if (this.Accessory == 2)
			{
				this.RightIrisLight.SetActive(false);
				this.LeftIrisLight.SetActive(false);
			}
			if (SceneManager.GetActiveScene().name == "PortraitScene")
			{
				this.Character.transform.localScale = new Vector3(0.93f, 0.93f, 0.93f);
			}
			if (this.FacialHairRenderer != null)
			{
				this.FacialHairRenderer.material.color = this.ColorValue;
				if (this.FacialHairRenderer.materials.Length > 1)
				{
					this.FacialHairRenderer.materials[1].color = this.ColorValue;
				}
			}
		}
		if (!this.Eighties)
		{
			if (this.StudentID != 10)
			{
				if (this.StudentID == 25 || this.StudentID == 30)
				{
					this.FemaleAccessories[6].SetActive(true);
					if ((float)StudentGlobals.GetStudentReputation(this.StudentID) < -33.33333f)
					{
						this.FemaleAccessories[6].SetActive(false);
					}
				}
				else if (this.StudentID == 2)
				{
					if (GameGlobals.RingStolen)
					{
						this.FemaleAccessories[3].SetActive(false);
					}
				}
				else if (this.StudentID == 40)
				{
					if (base.transform.position != Vector3.zero)
					{
						this.RightEyeRenderer.material.mainTexture = this.WaifuEyeTexture;
						this.LeftEyeRenderer.material.mainTexture = this.WaifuEyeTexture;
						this.RightIrisLight.GetComponent<Renderer>().material.mainTexture = this.WaifuIrisTexture;
						this.LeftIrisLight.GetComponent<Renderer>().material.mainTexture = this.WaifuIrisTexture;
						this.RightIrisLight.SetActive(true);
						this.LeftIrisLight.SetActive(true);
						this.RightEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
						this.LeftEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
					}
				}
				else if (this.StudentID == 41)
				{
					this.CharacterAnimation["moodyEyes_00"].layer = 1;
					this.CharacterAnimation.Play("moodyEyes_00");
					this.CharacterAnimation["moodyEyes_00"].weight = 1f;
					this.CharacterAnimation.Play("moodyEyes_00");
				}
				else if (this.StudentID == 51)
				{
					if (!ClubGlobals.GetClubClosed(ClubType.LightMusic))
					{
						this.PunkAccessories[1].SetActive(true);
						this.PunkAccessories[2].SetActive(true);
						this.PunkAccessories[3].SetActive(true);
					}
				}
				else if (this.StudentID == 59)
				{
					this.ClubAccessories[7].transform.localPosition = new Vector3(0f, -1.04f, 0.5f);
					this.ClubAccessories[7].transform.localEulerAngles = new Vector3(-22.5f, 0f, 0f);
				}
				else if (this.StudentID == 60)
				{
					this.FemaleAccessories[13].SetActive(true);
				}
			}
		}
		else if (this.StudentID == 86)
		{
			this.CharacterAnimation["moodyEyes_00"].layer = 1;
			this.CharacterAnimation.Play("moodyEyes_00");
			this.CharacterAnimation["moodyEyes_00"].weight = 1f;
			this.CharacterAnimation.Play("moodyEyes_00");
		}
		if (this.Student != null && this.Student.AoT)
		{
			this.Student.AttackOnTitan();
		}
		if (this.HomeScene)
		{
			this.Student.CharacterAnimation["idle_00"].time = 9f;
			this.Student.CharacterAnimation["idle_00"].speed = 0f;
			this.Hairstyle = 65;
		}
		if (!this.Eighties)
		{
			this.TaskCheck();
		}
		this.TurnOnCheck();
		if (!this.Male && this.StudentID != 90)
		{
			this.EyeTypeCheck();
		}
		if (this.Kidnapped)
		{
			this.WearIndoorShoes();
		}
	}

	// Token: 0x060012C4 RID: 4804 RVA: 0x0009F88C File Offset: 0x0009DA8C
	public void SetMaleUniform()
	{
		if (this.StudentID == 1)
		{
			this.SkinColor = SenpaiGlobals.SenpaiSkinColor;
			this.FaceTexture = this.FaceTextures[this.SkinColor];
		}
		else
		{
			if (this.CustomHair)
			{
				this.FaceTexture = this.FaceTextures[this.SkinColor];
			}
			else
			{
				this.FaceTexture = this.HairRenderer.material.mainTexture;
			}
			bool flag = false;
			if (this.StudentManager != null && this.StudentID == this.StudentManager.SuitorID)
			{
				flag = true;
			}
			if (flag && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorTan)
			{
				this.SkinColor = 6;
				this.DoNotChangeFace = true;
				this.FaceTexture = this.FaceTextures[6];
			}
		}
		this.MyRenderer.sharedMesh = this.MaleUniforms[this.MaleUniformID];
		this.SchoolUniform = this.MaleUniforms[this.MaleUniformID];
		this.UniformTexture = this.MaleUniformTextures[this.MaleUniformID];
		this.CasualTexture = this.MaleCasualTextures[this.MaleUniformID];
		this.SocksTexture = this.MaleSocksTextures[this.MaleUniformID];
		if (this.Club == ClubType.Council)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (this.MaleUniformID == 1)
		{
			this.SkinID = 0;
			this.UniformID = 1;
			this.FaceID = 2;
		}
		else if (this.MaleUniformID == 2 || this.MaleUniformID == 3)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (this.MaleUniformID == 4 || this.MaleUniformID == 5 || this.MaleUniformID == 6)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		if (this.Club == ClubType.Delinquent && this.MaleUniformID < 2)
		{
			this.MyRenderer.sharedMesh = this.DelinquentMesh;
			if (!this.Eighties)
			{
				if (this.StudentID == 76)
				{
					this.UniformTexture = this.EyeTextures[0];
					this.CasualTexture = this.EyeTextures[1];
					this.SocksTexture = this.EyeTextures[2];
				}
				else if (this.StudentID == 77)
				{
					this.UniformTexture = this.CheekTextures[0];
					this.CasualTexture = this.CheekTextures[1];
					this.SocksTexture = this.CheekTextures[2];
				}
				else if (this.StudentID == 78)
				{
					this.UniformTexture = this.ForeheadTextures[0];
					this.CasualTexture = this.ForeheadTextures[1];
					this.SocksTexture = this.ForeheadTextures[2];
				}
				else if (this.StudentID == 79)
				{
					this.UniformTexture = this.MouthTextures[0];
					this.CasualTexture = this.MouthTextures[1];
					this.SocksTexture = this.MouthTextures[2];
				}
				else if (this.StudentID == 80)
				{
					this.UniformTexture = this.NoseTextures[0];
					this.CasualTexture = this.NoseTextures[1];
					this.SocksTexture = this.NoseTextures[2];
				}
			}
			else
			{
				this.UniformTexture = this.EightiesDelinquentUniformTexture;
				this.CasualTexture = this.EightiesDelinquentCasualTexture;
				this.SocksTexture = this.EightiesDelinquentSocksTexture;
			}
		}
		if (!this.Eighties && this.StudentID == 58)
		{
			this.SkinColor = 6;
			this.Student.TowelTexture = this.TanTowelTexture;
			this.Student.SwimsuitTexture = this.TanSwimsuitTexture;
		}
		if (this.Empty)
		{
			this.UniformTexture = this.MaleUniformTextures[7];
			this.CasualTexture = this.MaleCasualTextures[7];
			this.SocksTexture = this.MaleSocksTextures[7];
			this.FaceTexture = this.GrayFace;
			this.SkinColor = 7;
		}
		if (this.Club == ClubType.Council)
		{
			this.MyRenderer.sharedMesh = this.MaleUniforms[4];
			this.SchoolUniform = this.MaleUniforms[4];
			this.UniformTexture = this.MaleUniformTextures[8];
			this.CasualTexture = this.MaleCasualTextures[8];
			this.SocksTexture = this.MaleSocksTextures[8];
			if (this.StudentID == 87)
			{
				this.UniformTexture = this.TanCouncilUniform;
				this.CasualTexture = this.TanCouncilUniform;
				this.SocksTexture = this.TanCouncilUniform;
				this.SkinColor = 8;
			}
		}
		if (!this.Student.Indoors)
		{
			this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[this.SkinColor];
			this.MyRenderer.materials[this.UniformID].mainTexture = this.CasualTexture;
			return;
		}
		this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[this.SkinColor];
		this.MyRenderer.materials[this.UniformID].mainTexture = this.UniformTexture;
	}

	// Token: 0x060012C5 RID: 4805 RVA: 0x0009FD90 File Offset: 0x0009DF90
	public void SetFemaleUniform()
	{
		if (this.Club != ClubType.Council)
		{
			this.MyRenderer.sharedMesh = this.FemaleUniforms[this.FemaleUniformID];
			this.SchoolUniform = this.FemaleUniforms[this.FemaleUniformID];
			if (this.Club == ClubType.Delinquent)
			{
				this.MyRenderer.sharedMesh = this.SukebanMesh;
				this.Masks[this.StudentID].SetActive(true);
			}
			if (this.Club == ClubType.Bully)
			{
				this.UniformTexture = this.GanguroUniformTextures[this.FemaleUniformID];
				this.CasualTexture = this.GanguroCasualTextures[this.FemaleUniformID];
				this.SocksTexture = this.GanguroSocksTextures[this.FemaleUniformID];
			}
			else if (this.StudentID == 10)
			{
				this.UniformTexture = this.ObstacleUniformTextures[this.FemaleUniformID];
				this.CasualTexture = this.ObstacleCasualTextures[this.FemaleUniformID];
				this.SocksTexture = this.ObstacleSocksTextures[this.FemaleUniformID];
			}
			else
			{
				this.UniformTexture = this.FemaleUniformTextures[this.FemaleUniformID];
				this.CasualTexture = this.FemaleCasualTextures[this.FemaleUniformID];
				this.SocksTexture = this.FemaleSocksTextures[this.FemaleUniformID];
			}
			if (!this.Eighties)
			{
				if (this.StudentID == 10)
				{
					this.Student.GymTexture = this.ObstacleGymTexture;
					this.Student.TowelTexture = this.ObstacleTowelTexture;
					this.Student.SwimsuitTexture = this.ObstacleSwimsuitTexture;
				}
				else if (this.StudentID == 11)
				{
					this.Student.SwimsuitTexture = this.OsanaSwimsuitTexture;
				}
			}
		}
		else
		{
			this.RightIrisLight.SetActive(false);
			this.LeftIrisLight.SetActive(false);
			this.MyRenderer.sharedMesh = this.FemaleUniforms[4];
			this.SchoolUniform = this.FemaleUniforms[4];
			this.UniformTexture = this.FemaleUniformTextures[7];
			this.CasualTexture = this.FemaleCasualTextures[7];
			this.SocksTexture = this.FemaleSocksTextures[7];
		}
		if (this.Empty)
		{
			this.UniformTexture = this.FemaleUniformTextures[8];
			this.CasualTexture = this.FemaleCasualTextures[8];
			this.SocksTexture = this.FemaleSocksTextures[8];
		}
		if (!this.Cutscene)
		{
			if (!this.Kidnapped)
			{
				if (!this.Student.Indoors)
				{
					this.MyRenderer.materials[0].mainTexture = this.CasualTexture;
					this.MyRenderer.materials[1].mainTexture = this.CasualTexture;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
					this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
				}
			}
			else
			{
				this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
				this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
			}
		}
		else
		{
			this.UniformTexture = this.FemaleUniformTextures[this.FemaleUniformID];
			this.FaceTexture = this.DefaultFaceTexture;
			this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
			this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
		}
		ClubType club = this.Club;
		if (this.MysteriousObstacle)
		{
			this.FaceTexture = this.BlackBody;
		}
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		if (!this.TakingPortrait && this.Student != null && this.Student.StudentManager != null && GameGlobals.CensorPanties)
		{
			this.CensorPanties();
		}
		if (this.MyStockings != null && base.gameObject.activeInHierarchy)
		{
			base.StartCoroutine(this.PutOnStockings());
		}
	}

	// Token: 0x060012C6 RID: 4806 RVA: 0x000A0164 File Offset: 0x0009E364
	public void CensorPanties()
	{
		if (!this.Student.ClubAttire && this.Student.Schoolwear == 1)
		{
			this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
			return;
		}
		this.RemoveCensor();
	}

	// Token: 0x060012C7 RID: 4807 RVA: 0x000A01CB File Offset: 0x0009E3CB
	public void RemoveCensor()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
	}

	// Token: 0x060012C8 RID: 4808 RVA: 0x000A0208 File Offset: 0x0009E408
	private void TaskCheck()
	{
		if (this.StudentID == 37)
		{
			if (TaskGlobals.GetTaskStatus(37) < 3)
			{
				if (!this.TakingPortrait)
				{
					this.MaleAccessories[1].SetActive(false);
					return;
				}
				this.MaleAccessories[1].SetActive(true);
				return;
			}
		}
		else if (this.StudentID == 11 && this.PhoneCharms.Length != 0)
		{
			if (TaskGlobals.GetTaskStatus(11) < 3)
			{
				this.PhoneCharms[11].SetActive(false);
				return;
			}
			this.PhoneCharms[11].SetActive(true);
		}
	}

	// Token: 0x060012C9 RID: 4809 RVA: 0x000A028C File Offset: 0x0009E48C
	private void TurnOnCheck()
	{
		if (!this.TurnedOn && !this.TakingPortrait && this.Male)
		{
			if (this.Hairstyle == 46 || this.Hairstyle == 48 || this.Hairstyle == 49)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
			else if ((this.Accessory > 1 && this.Accessory < 10) || this.Accessory == 13 || this.Accessory == 17)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
			else if (this.Student.Persona == PersonaType.TeachersPet)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
			else if (this.EyewearID > 0)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
			else if (this.SkinColor == 8)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets++;
			}
		}
		this.TurnedOn = true;
	}

	// Token: 0x060012CA RID: 4810 RVA: 0x000A0440 File Offset: 0x0009E640
	private void DestroyUnneccessaryObjects()
	{
		foreach (GameObject gameObject in this.FemaleAccessories)
		{
			if (gameObject != null && !gameObject.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		foreach (GameObject gameObject2 in this.MaleAccessories)
		{
			if (gameObject2 != null && !gameObject2.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject2);
			}
		}
		foreach (GameObject gameObject3 in this.ClubAccessories)
		{
			if (gameObject3 != null && !gameObject3.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject3);
			}
		}
		foreach (GameObject gameObject4 in this.TeacherAccessories)
		{
			if (gameObject4 != null && !gameObject4.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject4);
			}
		}
		foreach (GameObject gameObject5 in this.TeacherHair)
		{
			if (gameObject5 != null && !gameObject5.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject5);
			}
		}
		foreach (GameObject gameObject6 in this.FemaleHair)
		{
			if (gameObject6 != null && !gameObject6.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject6);
			}
		}
		foreach (GameObject gameObject7 in this.MaleHair)
		{
			if (gameObject7 != null && !gameObject7.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject7);
			}
		}
		foreach (GameObject gameObject8 in this.FacialHair)
		{
			if (gameObject8 != null && !gameObject8.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject8);
			}
		}
		foreach (GameObject gameObject9 in this.Eyewear)
		{
			if (gameObject9 != null && !gameObject9.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject9);
			}
		}
		foreach (GameObject gameObject10 in this.RightStockings)
		{
			if (gameObject10 != null && !gameObject10.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject10);
			}
		}
		foreach (GameObject gameObject11 in this.LeftStockings)
		{
			if (gameObject11 != null && !gameObject11.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(gameObject11);
			}
		}
	}

	// Token: 0x060012CB RID: 4811 RVA: 0x000A0681 File Offset: 0x0009E881
	public IEnumerator PutOnStockings()
	{
		this.RightStockings[0].SetActive(false);
		this.LeftStockings[0].SetActive(false);
		if (this.StudentManager != null && this.StudentManager.TutorialActive)
		{
			this.Stockings = "";
		}
		if (this.Stockings == string.Empty)
		{
			this.MyStockings = null;
		}
		else if (this.Stockings == "Red")
		{
			this.MyStockings = this.RedStockings;
		}
		else if (this.Stockings == "Yellow")
		{
			this.MyStockings = this.YellowStockings;
		}
		else if (this.Stockings == "Green")
		{
			this.MyStockings = this.GreenStockings;
		}
		else if (this.Stockings == "Cyan")
		{
			this.MyStockings = this.CyanStockings;
		}
		else if (this.Stockings == "Blue")
		{
			this.MyStockings = this.BlueStockings;
		}
		else if (this.Stockings == "Purple")
		{
			this.MyStockings = this.PurpleStockings;
		}
		else if (this.Stockings == "ShortGreen")
		{
			this.MyStockings = this.GreenSocks;
		}
		else if (this.Stockings == "ShortRed")
		{
			this.MyStockings = this.RedSocks;
		}
		else if (this.Stockings == "ShortBlue")
		{
			this.MyStockings = this.BlueSocks;
		}
		else if (this.Stockings == "ShortYellow")
		{
			this.MyStockings = this.YellowSocks;
		}
		else if (this.Stockings == "ShortBlack")
		{
			this.MyStockings = this.BlackKneeSocks;
		}
		else if (this.Stockings == "Black")
		{
			this.MyStockings = this.BlackStockings;
		}
		else if (this.Stockings == "Osana")
		{
			this.MyStockings = this.OsanaStockings;
		}
		else if (this.Stockings == "Amai")
		{
			this.MyStockings = this.AmaiStockings;
		}
		else if (this.Stockings == "Kizana")
		{
			this.MyStockings = this.KizanaStockings;
		}
		else if (this.Stockings == "Dafuni")
		{
			this.MyStockings = this.DafuniStockings;
		}
		else if (this.Stockings == "Council1")
		{
			this.MyStockings = this.TurtleStockings;
		}
		else if (this.Stockings == "Council2")
		{
			this.MyStockings = this.TigerStockings;
		}
		else if (this.Stockings == "Council3")
		{
			this.MyStockings = this.BirdStockings;
		}
		else if (this.Stockings == "Council4")
		{
			this.MyStockings = this.DragonStockings;
		}
		else if (this.Stockings == "Music1")
		{
			if (!ClubGlobals.GetClubClosed(ClubType.LightMusic))
			{
				this.MyStockings = this.MusicStockings[1];
			}
		}
		else if (this.Stockings == "Music2")
		{
			this.MyStockings = this.MusicStockings[2];
		}
		else if (this.Stockings == "Music3")
		{
			this.MyStockings = this.MusicStockings[3];
		}
		else if (this.Stockings == "Music4")
		{
			this.MyStockings = this.MusicStockings[4];
		}
		else if (this.Stockings == "Music5")
		{
			this.MyStockings = this.MusicStockings[5];
		}
		else if (this.Stockings == "Custom1")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings1.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[1] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[1];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom2")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings2.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[2] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[2];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom3")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings3.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[3] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[3];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom4")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings4.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[4] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[4];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom5")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings5.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[5] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[5];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom6")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings6.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[6] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[6];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom7")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings7.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[7] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[7];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom8")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings8.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[8] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[8];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom9")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings9.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[9] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[9];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Custom10")
		{
			WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings10.png");
			yield return NewCustomStockings;
			if (NewCustomStockings.error == null)
			{
				this.CustomStockings[10] = NewCustomStockings.texture;
			}
			this.MyStockings = this.CustomStockings[10];
			NewCustomStockings = null;
		}
		else if (this.Stockings == "Rival")
		{
			this.MyStockings = this.EightiesRivalStockings[this.StudentID];
		}
		else if (this.Stockings == "Rival1")
		{
			this.MyStockings = this.EightiesRivalStockings[11];
		}
		else if (this.Stockings == "Rival2")
		{
			this.MyStockings = this.EightiesRivalStockings[12];
		}
		else if (this.Stockings == "Rival3")
		{
			this.MyStockings = this.EightiesRivalStockings[13];
		}
		else if (this.Stockings == "Rival4")
		{
			this.MyStockings = this.EightiesRivalStockings[14];
		}
		else if (this.Stockings == "Rival5")
		{
			this.MyStockings = this.EightiesRivalStockings[15];
		}
		else if (this.Stockings == "Rival6")
		{
			this.MyStockings = this.EightiesRivalStockings[16];
		}
		else if (this.Stockings == "Rival7")
		{
			this.MyStockings = this.EightiesRivalStockings[17];
		}
		else if (this.Stockings == "Rival8")
		{
			this.MyStockings = this.EightiesRivalStockings[18];
		}
		else if (this.Stockings == "Rival9")
		{
			this.MyStockings = this.EightiesRivalStockings[19];
		}
		else if (this.Stockings == "Rival10")
		{
			this.MyStockings = this.EightiesRivalStockings[20];
		}
		else if (this.Stockings == "Loose" && !this.Kidnapped)
		{
			this.MyStockings = null;
			this.RightStockings[0].SetActive(true);
			this.LeftStockings[0].SetActive(true);
		}
		if (this.MyStockings != null)
		{
			this.MyRenderer.materials[0].SetTexture("_OverlayTex", this.MyStockings);
			this.MyRenderer.materials[1].SetTexture("_OverlayTex", this.MyStockings);
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
		}
		else
		{
			this.MyRenderer.materials[0].SetTexture("_OverlayTex", null);
			this.MyRenderer.materials[1].SetTexture("_OverlayTex", null);
			this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
			this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
		}
		yield break;
	}

	// Token: 0x060012CC RID: 4812 RVA: 0x000A0690 File Offset: 0x0009E890
	public void WearIndoorShoes()
	{
		if (!this.Male)
		{
			this.MyRenderer.materials[0].mainTexture = this.CasualTexture;
			this.MyRenderer.materials[1].mainTexture = this.CasualTexture;
			return;
		}
		this.MyRenderer.materials[this.UniformID].mainTexture = this.CasualTexture;
	}

	// Token: 0x060012CD RID: 4813 RVA: 0x000A06F4 File Offset: 0x0009E8F4
	public void WearOutdoorShoes()
	{
		if (!this.Male)
		{
			this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
			this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
			return;
		}
		this.MyRenderer.materials[this.UniformID].mainTexture = this.UniformTexture;
	}

	// Token: 0x060012CE RID: 4814 RVA: 0x000A0758 File Offset: 0x0009E958
	public void EyeTypeCheck()
	{
		int num = 0;
		if (this.EyeType == "Thin")
		{
			this.MyRenderer.SetBlendShapeWeight(8, 100f);
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.StudentManager.Thins++;
			num = this.StudentManager.Thins;
		}
		else if (this.EyeType == "Serious")
		{
			this.MyRenderer.SetBlendShapeWeight(5, 50f);
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.StudentManager.Seriouses++;
			num = this.StudentManager.Seriouses;
		}
		else if (this.EyeType == "Round")
		{
			this.MyRenderer.SetBlendShapeWeight(5, 15f);
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.StudentManager.Rounds++;
			num = this.StudentManager.Rounds;
		}
		else if (this.EyeType == "Sad")
		{
			this.MyRenderer.SetBlendShapeWeight(0, 50f);
			this.MyRenderer.SetBlendShapeWeight(5, 15f);
			this.MyRenderer.SetBlendShapeWeight(6, 50f);
			this.MyRenderer.SetBlendShapeWeight(8, 50f);
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.StudentManager.Sads++;
			num = this.StudentManager.Sads;
		}
		else if (this.EyeType == "Mean")
		{
			this.MyRenderer.SetBlendShapeWeight(10, 100f);
			this.StudentManager.Means++;
			num = this.StudentManager.Means;
		}
		else if (this.EyeType == "Smug")
		{
			this.MyRenderer.SetBlendShapeWeight(0, 50f);
			this.MyRenderer.SetBlendShapeWeight(5, 25f);
			this.StudentManager.Smugs++;
			num = this.StudentManager.Smugs;
		}
		else if (this.EyeType == "Gentle")
		{
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.MyRenderer.SetBlendShapeWeight(12, 100f);
			this.StudentManager.Gentles++;
			num = this.StudentManager.Gentles;
		}
		else if (this.EyeType == "MO")
		{
			this.MyRenderer.SetBlendShapeWeight(8, 50f);
			this.MyRenderer.SetBlendShapeWeight(9, 100f);
			this.MyRenderer.SetBlendShapeWeight(12, 100f);
			this.StudentManager.Gentles++;
			num = this.StudentManager.Gentles;
		}
		else if (this.EyeType == "Rival1")
		{
			this.MyRenderer.SetBlendShapeWeight(8, 5f);
			this.MyRenderer.SetBlendShapeWeight(9, 20f);
			this.MyRenderer.SetBlendShapeWeight(10, 50f);
			this.MyRenderer.SetBlendShapeWeight(11, 50f);
			this.MyRenderer.SetBlendShapeWeight(12, 10f);
			this.StudentManager.Rival1s++;
			num = this.StudentManager.Rival1s;
		}
		if (!this.Modified)
		{
			if ((this.EyeType == "Thin" && this.StudentManager.Thins > 1) || (this.EyeType == "Serious" && this.StudentManager.Seriouses > 1) || (this.EyeType == "Round" && this.StudentManager.Rounds > 1) || (this.EyeType == "Sad" && this.StudentManager.Sads > 1) || (this.EyeType == "Mean" && this.StudentManager.Means > 1) || (this.EyeType == "Smug" && this.StudentManager.Smugs > 1) || (this.EyeType == "Gentle" && this.StudentManager.Gentles > 1))
			{
				this.MyRenderer.SetBlendShapeWeight(8, this.MyRenderer.GetBlendShapeWeight(8) + (float)num);
				this.MyRenderer.SetBlendShapeWeight(9, this.MyRenderer.GetBlendShapeWeight(9) + (float)num);
				this.MyRenderer.SetBlendShapeWeight(10, this.MyRenderer.GetBlendShapeWeight(10) + (float)num);
				this.MyRenderer.SetBlendShapeWeight(12, this.MyRenderer.GetBlendShapeWeight(12) + (float)num);
			}
			this.Modified = true;
		}
	}

	// Token: 0x060012CF RID: 4815 RVA: 0x000A0C60 File Offset: 0x0009EE60
	public void DeactivateBullyAccessories()
	{
		if (this.FemaleUniformID < 2 || this.FemaleUniformID == 3)
		{
			this.RightWristband.SetActive(false);
			this.LeftWristband.SetActive(false);
		}
		this.Bookbag.SetActive(false);
		this.Hoodie.SetActive(false);
	}

	// Token: 0x060012D0 RID: 4816 RVA: 0x000A0CB0 File Offset: 0x0009EEB0
	public void ActivateBullyAccessories()
	{
		if (this.FemaleUniformID < 2 || this.FemaleUniformID == 3)
		{
			this.RightWristband.SetActive(true);
			this.LeftWristband.SetActive(true);
		}
		this.Bookbag.SetActive(true);
		this.Hoodie.SetActive(true);
	}

	// Token: 0x060012D1 RID: 4817 RVA: 0x000A0D00 File Offset: 0x0009EF00
	public void LoadCosmeticSheet(StudentCosmeticSheet mySheet)
	{
		if (this.Male != mySheet.Male)
		{
			return;
		}
		this.Accessory = mySheet.Accessory;
		this.Hairstyle = mySheet.Hairstyle;
		this.Stockings = mySheet.Stockings;
		this.BreastSize = mySheet.BreastSize;
		this.Start();
		this.ColorValue = mySheet.HairColor;
		this.HairRenderer.material.color = this.ColorValue;
		if (mySheet.CustomHair)
		{
			this.RightEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
			this.LeftEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
			this.FaceTexture = this.HairRenderer.material.mainTexture;
			this.LeftIrisLight.SetActive(false);
			this.RightIrisLight.SetActive(false);
			this.CustomHair = true;
		}
		this.CorrectColor = mySheet.EyeColor;
		this.RightEyeRenderer.material.color = this.CorrectColor;
		this.LeftEyeRenderer.material.color = this.CorrectColor;
		this.Student.Schoolwear = mySheet.Schoolwear;
		this.Student.ChangeSchoolwear();
		if (mySheet.Bloody)
		{
			this.Student.LiquidProjector.material.mainTexture = this.Student.BloodTexture;
			this.Student.LiquidProjector.enabled = true;
		}
		if (!this.Male)
		{
			this.Stockings = mySheet.Stockings;
			base.StartCoroutine(this.Student.Cosmetic.PutOnStockings());
			for (int i = 0; i < this.MyRenderer.sharedMesh.blendShapeCount; i++)
			{
				this.MyRenderer.SetBlendShapeWeight(i, mySheet.Blendshapes[i]);
			}
		}
	}

	// Token: 0x060012D2 RID: 4818 RVA: 0x000A0EDC File Offset: 0x0009F0DC
	public StudentCosmeticSheet CosmeticSheet()
	{
		StudentCosmeticSheet studentCosmeticSheet = default(StudentCosmeticSheet);
		studentCosmeticSheet.Blendshapes = new List<float>();
		studentCosmeticSheet.Male = this.Male;
		studentCosmeticSheet.CustomHair = this.CustomHair;
		studentCosmeticSheet.Accessory = this.Accessory;
		studentCosmeticSheet.Hairstyle = this.Hairstyle;
		studentCosmeticSheet.Stockings = this.Stockings;
		studentCosmeticSheet.BreastSize = this.BreastSize;
		studentCosmeticSheet.CustomHair = this.CustomHair;
		studentCosmeticSheet.Schoolwear = this.Student.Schoolwear;
		studentCosmeticSheet.Bloody = (this.Student.LiquidProjector.enabled && this.Student.LiquidProjector.material.mainTexture == this.Student.BloodTexture);
		studentCosmeticSheet.HairColor = this.HairRenderer.material.color;
		studentCosmeticSheet.EyeColor = this.RightEyeRenderer.material.color;
		if (!this.Male)
		{
			for (int i = 0; i < this.MyRenderer.sharedMesh.blendShapeCount; i++)
			{
				studentCosmeticSheet.Blendshapes.Add(this.MyRenderer.GetBlendShapeWeight(i));
			}
		}
		return studentCosmeticSheet;
	}

	// Token: 0x060012D3 RID: 4819 RVA: 0x000A1014 File Offset: 0x0009F214
	public void DisableAccessories()
	{
		foreach (GameObject gameObject in this.FemaleAccessories)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
		foreach (GameObject gameObject2 in this.MaleAccessories)
		{
			if (gameObject2 != null)
			{
				gameObject2.SetActive(false);
			}
		}
		foreach (GameObject gameObject3 in this.ClubAccessories)
		{
			if (gameObject3 != null)
			{
				gameObject3.SetActive(false);
			}
		}
		foreach (GameObject gameObject4 in this.TeacherAccessories)
		{
			if (gameObject4 != null)
			{
				gameObject4.SetActive(false);
			}
		}
		foreach (GameObject gameObject5 in this.TeacherHair)
		{
			if (gameObject5 != null)
			{
				gameObject5.SetActive(false);
			}
		}
		foreach (GameObject gameObject6 in this.FemaleHair)
		{
			if (gameObject6 != null)
			{
				gameObject6.SetActive(false);
			}
		}
		foreach (GameObject gameObject7 in this.MaleHair)
		{
			if (gameObject7 != null)
			{
				gameObject7.SetActive(false);
			}
		}
		foreach (GameObject gameObject8 in this.FacialHair)
		{
			if (gameObject8 != null)
			{
				gameObject8.SetActive(false);
			}
		}
		foreach (GameObject gameObject9 in this.Eyewear)
		{
			if (gameObject9 != null)
			{
				gameObject9.SetActive(false);
			}
		}
		foreach (GameObject gameObject10 in this.RightStockings)
		{
			if (gameObject10 != null)
			{
				gameObject10.SetActive(false);
			}
		}
		foreach (GameObject gameObject11 in this.LeftStockings)
		{
			if (gameObject11 != null)
			{
				gameObject11.SetActive(false);
			}
		}
		foreach (GameObject gameObject12 in this.Scanners)
		{
			if (gameObject12 != null)
			{
				gameObject12.SetActive(false);
			}
		}
		foreach (GameObject gameObject13 in this.Flowers)
		{
			if (gameObject13 != null)
			{
				gameObject13.SetActive(false);
			}
		}
		foreach (GameObject gameObject14 in this.Roses)
		{
			if (gameObject14 != null)
			{
				gameObject14.SetActive(false);
			}
		}
		foreach (GameObject gameObject15 in this.Goggles)
		{
			if (gameObject15 != null)
			{
				gameObject15.SetActive(false);
			}
		}
		foreach (GameObject gameObject16 in this.RedCloth)
		{
			if (gameObject16 != null)
			{
				gameObject16.SetActive(false);
			}
		}
		foreach (GameObject gameObject17 in this.Kerchiefs)
		{
			if (gameObject17 != null)
			{
				gameObject17.SetActive(false);
			}
		}
		foreach (GameObject gameObject18 in this.CatGifts)
		{
			if (gameObject18 != null)
			{
				gameObject18.SetActive(false);
			}
		}
		foreach (GameObject gameObject19 in this.PunkAccessories)
		{
			if (gameObject19 != null)
			{
				gameObject19.SetActive(false);
			}
		}
		foreach (GameObject gameObject20 in this.MusicNotes)
		{
			if (gameObject20 != null)
			{
				gameObject20.SetActive(false);
			}
		}
		foreach (GameObject gameObject21 in this.Masks)
		{
			if (gameObject21 != null)
			{
				gameObject21.SetActive(false);
			}
		}
		foreach (GameObject gameObject22 in this.CouncilBrows)
		{
			if (gameObject22 != null)
			{
				gameObject22.SetActive(false);
			}
		}
	}

	// Token: 0x04001900 RID: 6400
	public StudentManagerScript StudentManager;

	// Token: 0x04001901 RID: 6401
	public TextureManagerScript TextureManager;

	// Token: 0x04001902 RID: 6402
	public SkinnedMeshUpdater SkinUpdater;

	// Token: 0x04001903 RID: 6403
	public LoveManagerScript LoveManager;

	// Token: 0x04001904 RID: 6404
	public Animation CharacterAnimation;

	// Token: 0x04001905 RID: 6405
	public ModelSwapScript ModelSwap;

	// Token: 0x04001906 RID: 6406
	public StudentScript Student;

	// Token: 0x04001907 RID: 6407
	public JsonScript JSON;

	// Token: 0x04001908 RID: 6408
	public GameObject[] TeacherAccessories;

	// Token: 0x04001909 RID: 6409
	public GameObject[] FemaleAccessories;

	// Token: 0x0400190A RID: 6410
	public GameObject[] MaleAccessories;

	// Token: 0x0400190B RID: 6411
	public GameObject[] ClubAccessories;

	// Token: 0x0400190C RID: 6412
	public GameObject[] PunkAccessories;

	// Token: 0x0400190D RID: 6413
	public GameObject[] RightStockings;

	// Token: 0x0400190E RID: 6414
	public GameObject[] LeftStockings;

	// Token: 0x0400190F RID: 6415
	public GameObject[] CouncilBrows;

	// Token: 0x04001910 RID: 6416
	public GameObject[] PhoneCharms;

	// Token: 0x04001911 RID: 6417
	public GameObject[] TeacherHair;

	// Token: 0x04001912 RID: 6418
	public GameObject[] FacialHair;

	// Token: 0x04001913 RID: 6419
	public GameObject[] FemaleHair;

	// Token: 0x04001914 RID: 6420
	public GameObject[] MusicNotes;

	// Token: 0x04001915 RID: 6421
	public GameObject[] Kerchiefs;

	// Token: 0x04001916 RID: 6422
	public GameObject[] CatGifts;

	// Token: 0x04001917 RID: 6423
	public GameObject[] MaleHair;

	// Token: 0x04001918 RID: 6424
	public GameObject[] RedCloth;

	// Token: 0x04001919 RID: 6425
	public GameObject[] Scanners;

	// Token: 0x0400191A RID: 6426
	public GameObject[] Eyewear;

	// Token: 0x0400191B RID: 6427
	public GameObject[] Goggles;

	// Token: 0x0400191C RID: 6428
	public GameObject[] Flowers;

	// Token: 0x0400191D RID: 6429
	public GameObject[] Masks;

	// Token: 0x0400191E RID: 6430
	public GameObject[] Roses;

	// Token: 0x0400191F RID: 6431
	public Renderer[] TeacherHairRenderers;

	// Token: 0x04001920 RID: 6432
	public Renderer[] FacialHairRenderers;

	// Token: 0x04001921 RID: 6433
	public Renderer[] FemaleHairRenderers;

	// Token: 0x04001922 RID: 6434
	public Renderer[] MaleHairRenderers;

	// Token: 0x04001923 RID: 6435
	public Renderer[] Fingernails;

	// Token: 0x04001924 RID: 6436
	public Texture[] GanguroSwimsuitTextures;

	// Token: 0x04001925 RID: 6437
	public Texture[] GanguroUniformTextures;

	// Token: 0x04001926 RID: 6438
	public Texture[] GanguroCasualTextures;

	// Token: 0x04001927 RID: 6439
	public Texture[] GanguroSocksTextures;

	// Token: 0x04001928 RID: 6440
	public Texture[] GanguroNailTextures;

	// Token: 0x04001929 RID: 6441
	public Texture[] ObstacleUniformTextures;

	// Token: 0x0400192A RID: 6442
	public Texture[] ObstacleCasualTextures;

	// Token: 0x0400192B RID: 6443
	public Texture[] ObstacleSocksTextures;

	// Token: 0x0400192C RID: 6444
	public Texture[] OccultUniformTextures;

	// Token: 0x0400192D RID: 6445
	public Texture[] OccultCasualTextures;

	// Token: 0x0400192E RID: 6446
	public Texture[] OccultSocksTextures;

	// Token: 0x0400192F RID: 6447
	public Texture[] FemaleUniformTextures;

	// Token: 0x04001930 RID: 6448
	public Texture[] FemaleCasualTextures;

	// Token: 0x04001931 RID: 6449
	public Texture[] FemaleSocksTextures;

	// Token: 0x04001932 RID: 6450
	public Texture[] MaleUniformTextures;

	// Token: 0x04001933 RID: 6451
	public Texture[] MaleCasualTextures;

	// Token: 0x04001934 RID: 6452
	public Texture[] MaleSocksTextures;

	// Token: 0x04001935 RID: 6453
	public Texture[] SmartphoneTextures;

	// Token: 0x04001936 RID: 6454
	public Texture[] HoodieTextures;

	// Token: 0x04001937 RID: 6455
	public Texture[] FaceTextures;

	// Token: 0x04001938 RID: 6456
	public Texture[] SkinTextures;

	// Token: 0x04001939 RID: 6457
	public Texture[] WristwearTextures;

	// Token: 0x0400193A RID: 6458
	public Texture[] CardiganTextures;

	// Token: 0x0400193B RID: 6459
	public Texture[] BookbagTextures;

	// Token: 0x0400193C RID: 6460
	public Texture[] EyeTextures;

	// Token: 0x0400193D RID: 6461
	public Texture[] CheekTextures;

	// Token: 0x0400193E RID: 6462
	public Texture[] ForeheadTextures;

	// Token: 0x0400193F RID: 6463
	public Texture[] MouthTextures;

	// Token: 0x04001940 RID: 6464
	public Texture[] NoseTextures;

	// Token: 0x04001941 RID: 6465
	public Texture[] ApronTextures;

	// Token: 0x04001942 RID: 6466
	public Texture[] CanTextures;

	// Token: 0x04001943 RID: 6467
	public Texture[] Trunks;

	// Token: 0x04001944 RID: 6468
	public Texture[] MusicStockings;

	// Token: 0x04001945 RID: 6469
	public Mesh[] FemaleUniforms;

	// Token: 0x04001946 RID: 6470
	public Mesh[] MaleUniforms;

	// Token: 0x04001947 RID: 6471
	public Mesh[] Berets;

	// Token: 0x04001948 RID: 6472
	public Color[] BullyColor;

	// Token: 0x04001949 RID: 6473
	public SkinnedMeshRenderer CardiganRenderer;

	// Token: 0x0400194A RID: 6474
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400194B RID: 6475
	public Renderer FacialHairRenderer;

	// Token: 0x0400194C RID: 6476
	public Renderer RightEyeRenderer;

	// Token: 0x0400194D RID: 6477
	public Renderer LeftEyeRenderer;

	// Token: 0x0400194E RID: 6478
	public Renderer HoodieRenderer;

	// Token: 0x0400194F RID: 6479
	public Renderer ScarfRenderer;

	// Token: 0x04001950 RID: 6480
	public Renderer HairRenderer;

	// Token: 0x04001951 RID: 6481
	public Renderer CanRenderer;

	// Token: 0x04001952 RID: 6482
	public Mesh EightiesDelinquentMesh;

	// Token: 0x04001953 RID: 6483
	public Mesh ModernBookBagMesh;

	// Token: 0x04001954 RID: 6484
	public Mesh DelinquentMesh;

	// Token: 0x04001955 RID: 6485
	public Mesh SchoolUniform;

	// Token: 0x04001956 RID: 6486
	public Mesh SukebanMesh;

	// Token: 0x04001957 RID: 6487
	public Texture DefaultFaceTexture;

	// Token: 0x04001958 RID: 6488
	public Texture TeacherBodyTexture;

	// Token: 0x04001959 RID: 6489
	public Texture EightiesCoachFaceTexture;

	// Token: 0x0400195A RID: 6490
	public Texture CoachPaleBodyTexture;

	// Token: 0x0400195B RID: 6491
	public Texture CoachBodyTexture;

	// Token: 0x0400195C RID: 6492
	public Texture CoachFaceTexture;

	// Token: 0x0400195D RID: 6493
	public Texture UniformTexture;

	// Token: 0x0400195E RID: 6494
	public Texture CasualTexture;

	// Token: 0x0400195F RID: 6495
	public Texture SocksTexture;

	// Token: 0x04001960 RID: 6496
	public Texture FaceTexture;

	// Token: 0x04001961 RID: 6497
	public Texture PurpleStockings;

	// Token: 0x04001962 RID: 6498
	public Texture YellowStockings;

	// Token: 0x04001963 RID: 6499
	public Texture BlackStockings;

	// Token: 0x04001964 RID: 6500
	public Texture GreenStockings;

	// Token: 0x04001965 RID: 6501
	public Texture BlueStockings;

	// Token: 0x04001966 RID: 6502
	public Texture CyanStockings;

	// Token: 0x04001967 RID: 6503
	public Texture RedStockings;

	// Token: 0x04001968 RID: 6504
	public Texture YellowSocks;

	// Token: 0x04001969 RID: 6505
	public Texture GreenSocks;

	// Token: 0x0400196A RID: 6506
	public Texture BlueSocks;

	// Token: 0x0400196B RID: 6507
	public Texture RedSocks;

	// Token: 0x0400196C RID: 6508
	public Texture BlackKneeSocks;

	// Token: 0x0400196D RID: 6509
	public Texture KizanaStockings;

	// Token: 0x0400196E RID: 6510
	public Texture OsanaStockings;

	// Token: 0x0400196F RID: 6511
	public Texture AmaiStockings;

	// Token: 0x04001970 RID: 6512
	public Texture DafuniStockings;

	// Token: 0x04001971 RID: 6513
	public Texture TurtleStockings;

	// Token: 0x04001972 RID: 6514
	public Texture TigerStockings;

	// Token: 0x04001973 RID: 6515
	public Texture BirdStockings;

	// Token: 0x04001974 RID: 6516
	public Texture DragonStockings;

	// Token: 0x04001975 RID: 6517
	public Texture[] EightiesRivalStockings;

	// Token: 0x04001976 RID: 6518
	public Texture[] CustomStockings;

	// Token: 0x04001977 RID: 6519
	public Texture MyStockings;

	// Token: 0x04001978 RID: 6520
	public Texture BlackBody;

	// Token: 0x04001979 RID: 6521
	public Texture BlackFace;

	// Token: 0x0400197A RID: 6522
	public Texture GrayFace;

	// Token: 0x0400197B RID: 6523
	public Texture EightiesDelinquentUniformTexture;

	// Token: 0x0400197C RID: 6524
	public Texture EightiesDelinquentCasualTexture;

	// Token: 0x0400197D RID: 6525
	public Texture EightiesDelinquentSocksTexture;

	// Token: 0x0400197E RID: 6526
	public Texture EightiesMaleUniformTexture;

	// Token: 0x0400197F RID: 6527
	public Texture EightiesMaleCasualTexture;

	// Token: 0x04001980 RID: 6528
	public Texture EightiesMaleSocksTexture;

	// Token: 0x04001981 RID: 6529
	public Texture OsanaSwimsuitTexture;

	// Token: 0x04001982 RID: 6530
	public Texture ObstacleSwimsuitTexture;

	// Token: 0x04001983 RID: 6531
	public Texture ObstacleTowelTexture;

	// Token: 0x04001984 RID: 6532
	public Texture ObstacleGymTexture;

	// Token: 0x04001985 RID: 6533
	public Texture TanSwimsuitTexture;

	// Token: 0x04001986 RID: 6534
	public Texture TanTowelTexture;

	// Token: 0x04001987 RID: 6535
	public Texture TanGymTexture;

	// Token: 0x04001988 RID: 6536
	public Texture WaifuIrisTexture;

	// Token: 0x04001989 RID: 6537
	public Texture WaifuEyeTexture;

	// Token: 0x0400198A RID: 6538
	public Texture AmaiApron;

	// Token: 0x0400198B RID: 6539
	public Texture NewspaperArmbandTexture;

	// Token: 0x0400198C RID: 6540
	public Texture TanCouncilUniform;

	// Token: 0x0400198D RID: 6541
	public GameObject RightIrisLight;

	// Token: 0x0400198E RID: 6542
	public GameObject LeftIrisLight;

	// Token: 0x0400198F RID: 6543
	public GameObject RightWristband;

	// Token: 0x04001990 RID: 6544
	public GameObject LeftWristband;

	// Token: 0x04001991 RID: 6545
	public GameObject Cardigan;

	// Token: 0x04001992 RID: 6546
	public GameObject Bookbag;

	// Token: 0x04001993 RID: 6547
	public GameObject ThickBrows;

	// Token: 0x04001994 RID: 6548
	public GameObject Character;

	// Token: 0x04001995 RID: 6549
	public GameObject RightShoe;

	// Token: 0x04001996 RID: 6550
	public GameObject LeftShoe;

	// Token: 0x04001997 RID: 6551
	public GameObject SadBrows;

	// Token: 0x04001998 RID: 6552
	public GameObject Armband;

	// Token: 0x04001999 RID: 6553
	public GameObject Hoodie;

	// Token: 0x0400199A RID: 6554
	public GameObject Tongue;

	// Token: 0x0400199B RID: 6555
	public Transform RightBreast;

	// Token: 0x0400199C RID: 6556
	public Transform LeftBreast;

	// Token: 0x0400199D RID: 6557
	public Transform RightTemple;

	// Token: 0x0400199E RID: 6558
	public Transform LeftTemple;

	// Token: 0x0400199F RID: 6559
	public Transform Head;

	// Token: 0x040019A0 RID: 6560
	public Transform Neck;

	// Token: 0x040019A1 RID: 6561
	public Color CorrectColor;

	// Token: 0x040019A2 RID: 6562
	public Color ColorValue;

	// Token: 0x040019A3 RID: 6563
	public Mesh EightiesNurseMesh;

	// Token: 0x040019A4 RID: 6564
	public Mesh TeacherMesh;

	// Token: 0x040019A5 RID: 6565
	public Mesh CoachMesh;

	// Token: 0x040019A6 RID: 6566
	public Mesh NurseMesh;

	// Token: 0x040019A7 RID: 6567
	public bool MysteriousObstacle;

	// Token: 0x040019A8 RID: 6568
	public bool DoNotChangeFace;

	// Token: 0x040019A9 RID: 6569
	public bool TakingPortrait;

	// Token: 0x040019AA RID: 6570
	public bool Initialized;

	// Token: 0x040019AB RID: 6571
	public bool CustomEyes;

	// Token: 0x040019AC RID: 6572
	public bool CustomHair;

	// Token: 0x040019AD RID: 6573
	public bool LookCamera;

	// Token: 0x040019AE RID: 6574
	public bool HomeScene;

	// Token: 0x040019AF RID: 6575
	public bool Kidnapped;

	// Token: 0x040019B0 RID: 6576
	public bool Randomize;

	// Token: 0x040019B1 RID: 6577
	public bool Cutscene;

	// Token: 0x040019B2 RID: 6578
	public bool Eighties;

	// Token: 0x040019B3 RID: 6579
	public bool Modified;

	// Token: 0x040019B4 RID: 6580
	public bool TurnedOn;

	// Token: 0x040019B5 RID: 6581
	public bool Medibang;

	// Token: 0x040019B6 RID: 6582
	public bool Teacher;

	// Token: 0x040019B7 RID: 6583
	public bool Yandere;

	// Token: 0x040019B8 RID: 6584
	public bool Empty;

	// Token: 0x040019B9 RID: 6585
	public bool Male;

	// Token: 0x040019BA RID: 6586
	public float BreastSize;

	// Token: 0x040019BB RID: 6587
	public string OriginalStockings = string.Empty;

	// Token: 0x040019BC RID: 6588
	public string HairColor = string.Empty;

	// Token: 0x040019BD RID: 6589
	public string Stockings = string.Empty;

	// Token: 0x040019BE RID: 6590
	public string EyeColor = string.Empty;

	// Token: 0x040019BF RID: 6591
	public string EyeType = string.Empty;

	// Token: 0x040019C0 RID: 6592
	public string Name = string.Empty;

	// Token: 0x040019C1 RID: 6593
	public int FacialHairstyle;

	// Token: 0x040019C2 RID: 6594
	public int FemaleUniformID;

	// Token: 0x040019C3 RID: 6595
	public int MaleUniformID;

	// Token: 0x040019C4 RID: 6596
	public int Accessory;

	// Token: 0x040019C5 RID: 6597
	public int Direction;

	// Token: 0x040019C6 RID: 6598
	public int Hairstyle;

	// Token: 0x040019C7 RID: 6599
	public int SkinColor;

	// Token: 0x040019C8 RID: 6600
	public int StudentID;

	// Token: 0x040019C9 RID: 6601
	public int EyewearID;

	// Token: 0x040019CA RID: 6602
	public ClubType Club;

	// Token: 0x040019CB RID: 6603
	public int ID;

	// Token: 0x040019CC RID: 6604
	public GameObject[] GaloAccessories;

	// Token: 0x040019CD RID: 6605
	public Material[] EightiesNurseMaterials;

	// Token: 0x040019CE RID: 6606
	public Material[] NurseMaterials;

	// Token: 0x040019CF RID: 6607
	public GameObject CardiganPrefab;

	// Token: 0x040019D0 RID: 6608
	public int FaceID;

	// Token: 0x040019D1 RID: 6609
	public int SkinID;

	// Token: 0x040019D2 RID: 6610
	public int UniformID;
}
