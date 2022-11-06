// Decompiled with JetBrains decompiler
// Type: CosmeticScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CosmeticScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public TextureManagerScript TextureManager;
  public SkinnedMeshUpdater SkinUpdater;
  public LoveManagerScript LoveManager;
  public Animation CharacterAnimation;
  public ModelSwapScript ModelSwap;
  public StudentScript Student;
  public JsonScript JSON;
  public GameObject[] TeacherAccessories;
  public GameObject[] FemaleAccessories;
  public GameObject[] MaleAccessories;
  public GameObject[] ClubAccessories;
  public GameObject[] PunkAccessories;
  public GameObject[] RightStockings;
  public GameObject[] LeftStockings;
  public GameObject[] CouncilBrows;
  public GameObject[] PhoneCharms;
  public GameObject[] TeacherHair;
  public GameObject[] FacialHair;
  public GameObject[] FemaleHair;
  public GameObject[] MusicNotes;
  public GameObject[] Kerchiefs;
  public GameObject[] CatGifts;
  public GameObject[] MaleHair;
  public GameObject[] RedCloth;
  public GameObject[] Scanners;
  public GameObject[] Eyewear;
  public GameObject[] Goggles;
  public GameObject[] Flowers;
  public GameObject[] Masks;
  public GameObject[] Rings;
  public GameObject[] Roses;
  public Renderer[] TeacherHairRenderers;
  public Renderer[] FacialHairRenderers;
  public Renderer[] FemaleHairRenderers;
  public Renderer[] MaleHairRenderers;
  public Renderer[] Fingernails;
  public Texture[] GanguroSwimsuitTextures;
  public Texture[] GanguroUniformTextures;
  public Texture[] GanguroCasualTextures;
  public Texture[] GanguroSocksTextures;
  public Texture[] GanguroNailTextures;
  public Texture[] ObstacleUniformTextures;
  public Texture[] ObstacleCasualTextures;
  public Texture[] ObstacleSocksTextures;
  public Texture[] OccultUniformTextures;
  public Texture[] OccultCasualTextures;
  public Texture[] OccultSocksTextures;
  public Texture[] FemaleUniformTextures;
  public Texture[] FemaleCasualTextures;
  public Texture[] FemaleSocksTextures;
  public Texture[] MaleUniformTextures;
  public Texture[] MaleCasualTextures;
  public Texture[] MaleSocksTextures;
  public Texture[] SmartphoneTextures;
  public Texture[] HoodieTextures;
  public Texture[] FaceTextures;
  public Texture[] SkinTextures;
  public Texture[] WristwearTextures;
  public Texture[] CardiganTextures;
  public Texture[] BookbagTextures;
  public Texture[] EyeTextures;
  public Texture[] CheekTextures;
  public Texture[] ForeheadTextures;
  public Texture[] MouthTextures;
  public Texture[] NoseTextures;
  public Texture[] EightiesApronTextures;
  public Texture[] ApronTextures;
  public Texture[] CanTextures;
  public Texture[] Trunks;
  public Texture[] MusicStockings;
  public Mesh[] FemaleUniforms;
  public Mesh[] MaleUniforms;
  public Mesh[] Berets;
  public Color[] BullyColor;
  public SkinnedMeshRenderer CardiganRenderer;
  public SkinnedMeshRenderer MyRenderer;
  public Renderer TurtleEyewearRenderer;
  public Renderer FacialHairRenderer;
  public Renderer RightEyeRenderer;
  public Renderer LeftEyeRenderer;
  public Renderer HoodieRenderer;
  public Renderer ScarfRenderer;
  public Renderer HairRenderer;
  public Renderer CanRenderer;
  public Mesh EightiesDelinquentMesh;
  public Mesh ModernBookBagMesh;
  public Mesh DelinquentMesh;
  public Mesh SchoolUniform;
  public Mesh SukebanMesh;
  public Texture DefaultFaceTexture;
  public Texture TeacherBodyTexture;
  public Texture EightiesCoachFaceTexture;
  public Texture CoachPaleBodyTexture;
  public Texture CoachBodyTexture;
  public Texture CoachFaceTexture;
  public Texture UniformTexture;
  public Texture CasualTexture;
  public Texture SocksTexture;
  public Texture FaceTexture;
  public Texture ShortWhiteSocks;
  public Texture PurpleStockings;
  public Texture YellowStockings;
  public Texture BlackStockings;
  public Texture GreenStockings;
  public Texture BlueStockings;
  public Texture CyanStockings;
  public Texture RedStockings;
  public Texture YellowSocks;
  public Texture GreenSocks;
  public Texture BlueSocks;
  public Texture RedSocks;
  public Texture BlackKneeSocks;
  public Texture KizanaStockings;
  public Texture OsanaStockings;
  public Texture AmaiStockings;
  public Texture DafuniStockings;
  public Texture TurtleStockings;
  public Texture TigerStockings;
  public Texture BirdStockings;
  public Texture DragonStockings;
  public Texture SakyuStockings;
  public Texture InkyuStockings;
  public Texture[] EightiesRivalStockings;
  public Texture[] CustomStockings;
  public Texture MyStockings;
  public Texture BlackBody;
  public Texture BlackFace;
  public Texture GrayFace;
  public Texture EightiesDelinquentUniformTexture;
  public Texture EightiesDelinquentCasualTexture;
  public Texture EightiesDelinquentSocksTexture;
  public Texture EightiesMaleUniformTexture;
  public Texture EightiesMaleCasualTexture;
  public Texture EightiesMaleSocksTexture;
  public Texture OsanaSwimsuitTexture;
  public Texture ObstacleSwimsuitTexture;
  public Texture ObstacleTowelTexture;
  public Texture ObstacleGymTexture;
  public Texture TanSwimsuitTexture;
  public Texture TanTowelTexture;
  public Texture TanGymTexture;
  public Texture WaifuIrisTexture;
  public Texture WaifuEyeTexture;
  public Texture AmaiApron;
  public Texture NewspaperArmbandTexture;
  public Texture TanCouncilUniform;
  public GameObject RightIrisLight;
  public GameObject LeftIrisLight;
  public GameObject RightWristband;
  public GameObject LeftWristband;
  public GameObject Cardigan;
  public GameObject Bookbag;
  public GameObject ThickBrows;
  public GameObject Character;
  public GameObject RightShoe;
  public GameObject LeftShoe;
  public GameObject SadBrows;
  public GameObject Armband;
  public GameObject Hoodie;
  public GameObject Tongue;
  public Transform RightBreast;
  public Transform LeftBreast;
  public Transform RightTemple;
  public Transform LeftTemple;
  public Transform Head;
  public Transform Neck;
  public Color CorrectColor;
  public Color ColorValue;
  public Mesh EightiesNurseMesh;
  public Mesh TeacherMesh;
  public Mesh CoachMesh;
  public Mesh NurseMesh;
  public bool MysteriousObstacle;
  public bool DoNotChangeFace;
  public bool TakingPortrait;
  public bool Initialized;
  public bool CustomEyes;
  public bool CustomHair;
  public bool LookCamera;
  public bool HomeScene;
  public bool Kidnapped;
  public bool Randomize;
  public bool Cutscene;
  public bool Eighties;
  public bool Modified;
  public bool TurnedOn;
  public bool Medibang;
  public bool Teacher;
  public bool Yandere;
  public bool Empty;
  public bool Male;
  public float BreastSize;
  public string OriginalStockings = string.Empty;
  public string HairColor = string.Empty;
  public string Stockings = string.Empty;
  public string EyeColor = string.Empty;
  public string EyeType = string.Empty;
  public string Name = string.Empty;
  public int FacialHairstyle;
  public int FemaleUniformID;
  public int MaleUniformID;
  public int PrisonerID;
  public int Accessory;
  public int Direction;
  public int Hairstyle;
  public int SkinColor;
  public int StudentID;
  public int EyewearID;
  public ClubType Club;
  public int ID;
  public GameObject[] GaloAccessories;
  public Material[] EightiesNurseMaterials;
  public Material[] NurseMaterials;
  public GameObject CardiganPrefab;
  public GameObject BackupOsanaHair;
  public Renderer BackupOsanaHairRenderer;
  public int FaceID;
  public int SkinID;
  public int UniformID;
  public RiggedAccessoryAttacher BurlapSack;
  public bool UpdateSack;

  public void Start()
  {
    if (this.Kidnapped && (Object) this.FemaleHair[20] == (Object) null)
    {
      this.FemaleHair[20] = this.BackupOsanaHair;
      this.FemaleHairRenderers[20] = this.BackupOsanaHairRenderer;
    }
    this.Eighties = !((Object) this.StudentManager != (Object) null) ? GameGlobals.Eighties : this.StudentManager.Eighties;
    if (this.Eighties && this.Male)
    {
      this.MaleUniformTextures[1] = this.EightiesMaleCasualTexture;
      this.MaleCasualTextures[1] = this.EightiesMaleUniformTexture;
      this.MaleSocksTextures[1] = this.EightiesMaleSocksTexture;
      int index = 66;
      while (index < this.Trunks.Length)
      {
        if ((Object) this.Trunks[index] != (Object) null)
        {
          this.Trunks[index] = this.Trunks[0];
          ++index;
        }
      }
    }
    if (this.Cutscene && EventGlobals.OsanaConversation)
      this.StudentID = 11;
    if ((Object) this.RightShoe != (Object) null)
    {
      this.RightShoe.SetActive(false);
      this.LeftShoe.SetActive(false);
    }
    this.ColorValue = new Color(1f, 1f, 1f, 1f);
    if ((Object) this.JSON == (Object) null)
      this.JSON = this.Student.JSON;
    string str1 = string.Empty;
    if (!this.Initialized)
    {
      if ((Object) this.JSON == (Object) null)
        this.JSON = this.StudentManager.JSON;
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
          this.Hairstyle = 54;
      }
      else if (this.StudentID == 36)
      {
        this.FacialHairstyle = 12;
        this.EyewearID = 8;
        if ((Object) this.StudentManager.TaskManager != (Object) null && this.StudentManager.TaskManager.TaskStatus[36] == 3)
        {
          Debug.Log((object) "Gema is updating his appearance.");
          this.FacialHairstyle = 0;
          this.EyewearID = 9;
          this.Hairstyle = 49;
          this.Accessory = 0;
        }
      }
      else if (this.StudentID == 51 && ClubGlobals.GetClubClosed(ClubType.LightMusic))
        this.Hairstyle = 51;
    }
    if ((Object) this.StudentManager != (Object) null && this.StudentManager.EmptyDemon && (this.StudentID == 21 || this.StudentID == 26 || this.StudentID == 31 || this.StudentID == 36 || this.StudentID == 41 || this.StudentID == 46 || this.StudentID == 51 || this.StudentID == 56 || this.StudentID == 61 || this.StudentID == 66 || this.StudentID == 71))
    {
      this.Hairstyle = this.Male ? 53 : 52;
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
        string str2 = this.StudentManager.FirstNames[Random.Range(0, this.StudentManager.FirstNames.Length)] + " " + this.StudentManager.LastNames[Random.Range(0, this.StudentManager.LastNames.Length)];
        this.JSON.Students[this.StudentID].Name = str2;
        this.Student.Name = str2;
      }
      else
      {
        string str3 = this.StudentManager.MaleNames[Random.Range(0, this.StudentManager.MaleNames.Length)] + " " + this.StudentManager.LastNames[Random.Range(0, this.StudentManager.LastNames.Length)];
        this.JSON.Students[this.StudentID].Name = str3;
        this.Student.Name = str3;
      }
      if (MissionModeGlobals.MissionMode && MissionModeGlobals.MissionTarget == this.StudentID)
      {
        this.JSON.Students[this.StudentID].Name = MissionModeGlobals.MissionTargetName;
        this.Student.Name = MissionModeGlobals.MissionTargetName;
        str1 = MissionModeGlobals.MissionTargetName;
      }
    }
    if (this.Randomize && this.StudentID < 90)
    {
      Debug.Log((object) ("The student with ID " + this.StudentID.ToString() + " is selecting a random hair color and skin color."));
      this.BreastSize = Random.Range(0.5f, 2f);
      this.Accessory = 0;
      this.Club = ClubType.None;
      this.Student.Persona = PersonaType.Coward;
      this.Hairstyle = this.Male ? Random.Range(1, this.MaleHair.Length) : Random.Range(1, this.FemaleHair.Length);
    }
    this.DisableAccessories();
    bool flag1 = false;
    if ((Object) this.StudentManager != (Object) null && this.StudentID == this.StudentManager.SuitorID)
      flag1 = true;
    if (flag1 && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorEyewear > 0)
      this.Eyewear[StudentGlobals.CustomSuitorEyewear].SetActive(true);
    Scene activeScene;
    if (!this.Male)
    {
      this.FemaleUniformID = StudentGlobals.FemaleUniform;
      this.ThickBrows.SetActive(false);
      if (!this.TakingPortrait)
        this.Tongue.SetActive(false);
      foreach (GameObject phoneCharm in this.PhoneCharms)
      {
        if ((Object) phoneCharm != (Object) null)
          phoneCharm.SetActive(false);
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
          if (!this.Kidnapped && !this.Student.Slave)
          {
            this.RightTemple.name = "RENAMED";
            this.LeftTemple.name = "RENAMED";
          }
          this.RightTemple.localScale = new Vector3(0.0f, 1f, 1f);
          this.LeftTemple.localScale = new Vector3(0.0f, 1f, 1f);
          if (ClubGlobals.GetClubClosed(ClubType.LightMusic))
            this.SadBrows.SetActive(true);
          else
            this.ThickBrows.SetActive(true);
        }
        else if (this.StudentID == 84 && StudentGlobals.GetStudentDead(81) && StudentGlobals.GetStudentDead(82) && StudentGlobals.GetStudentDead(83) && StudentGlobals.GetStudentDead(85))
        {
          this.Student.Club = ClubType.None;
          this.StudentManager.Bullies = 0;
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
          this.Student.SmartPhone.transform.localEulerAngles = new Vector3(0.0f, -160f, 165f);
          this.Bookbag.GetComponent<MeshFilter>().mesh = this.ModernBookBagMesh;
        }
        this.RightWristband.GetComponent<Renderer>().material.mainTexture = this.WristwearTextures[this.StudentID];
        this.LeftWristband.GetComponent<Renderer>().material.mainTexture = this.WristwearTextures[this.StudentID];
        this.Bookbag.GetComponent<Renderer>().material.mainTexture = this.BookbagTextures[this.StudentID];
        this.HoodieRenderer.material.mainTexture = this.HoodieTextures[this.StudentID];
        if (this.PhoneCharms.Length != 0)
          this.PhoneCharms[this.StudentID].SetActive(true);
        if (this.FemaleUniformID < 2 || this.FemaleUniformID == 3)
        {
          this.RightWristband.SetActive(true);
          this.LeftWristband.SetActive(true);
        }
        this.Bookbag.SetActive(true);
        this.Hoodie.SetActive(true);
        for (int index = 0; index < 10; ++index)
          this.Fingernails[index].material.mainTexture = this.GanguroNailTextures[this.StudentID];
        this.Student.GymTexture = this.TanGymTexture;
        this.Student.TowelTexture = this.TanTowelTexture;
      }
      else
      {
        this.DisableFingernails();
        if (this.Club == ClubType.Gardening && !this.TakingPortrait && !this.Kidnapped)
          this.CanRenderer.material.mainTexture = this.CanTextures[this.StudentID];
      }
      if (!this.Kidnapped)
      {
        activeScene = SceneManager.GetActiveScene();
        if (activeScene.name == "PortraitScene")
        {
          if (!this.Eighties)
          {
            if (this.StudentID == 2)
            {
              this.CharacterAnimation.Play("succubus_a_idle_twins_01");
              this.transform.position = new Vector3(0.094f, 0.0f, 0.0f);
              this.LookCamera = true;
              this.CharacterAnimation["f02_smile_00"].layer = 1;
              this.CharacterAnimation.Play("f02_smile_00");
              this.CharacterAnimation["f02_smile_00"].weight = 1f;
            }
            else if (this.StudentID == 3)
            {
              this.CharacterAnimation.Play("succubus_b_idle_twins_02");
              this.transform.position = new Vector3(-0.322f, 0.04f, 0.0f);
              this.LookCamera = true;
              this.CharacterAnimation["f02_smile_00"].layer = 1;
              this.CharacterAnimation.Play("f02_smile_00");
              this.CharacterAnimation["f02_smile_00"].weight = 1f;
            }
            else if (this.StudentID == 4)
            {
              this.CharacterAnimation.Play("f02_idleShort_00");
              this.transform.position = new Vector3(0.015f, 0.0f, 0.0f);
              this.LookCamera = true;
            }
            else if (this.StudentID == 5)
            {
              this.CharacterAnimation[this.Student.ShyAnim].layer = 5;
              this.CharacterAnimation.Play(this.Student.ShyAnim);
              this.CharacterAnimation[this.Student.ShyAnim].weight = 0.5f;
            }
            else if (this.StudentID == 10)
              this.CharacterAnimation.Play("f02_raibaruPortraitPose_00");
            else if (this.StudentID == 11)
            {
              this.CharacterAnimation.Play("f02_rivalPortraitPose_01");
              this.transform.position = new Vector3(-0.045f, 0.0f, 0.0f);
            }
            else if (this.StudentID == 24)
            {
              this.CharacterAnimation.Play("f02_idleGirly_00");
              this.CharacterAnimation["f02_idleGirly_00"].time = 1f;
            }
            else if (this.StudentID == 25)
            {
              this.CharacterAnimation.Play("f02_idleGirly_00");
              this.CharacterAnimation["f02_idleGirly_00"].time = 0.0f;
            }
            else if (this.StudentID == 30)
            {
              this.CharacterAnimation.Play("f02_idleGirly_00");
              this.CharacterAnimation["f02_idleGirly_00"].time = 0.0f;
            }
            else if (this.StudentID == 34)
            {
              this.CharacterAnimation.Play("f02_idleShort_00");
              this.transform.position = new Vector3(0.015f, 0.0f, 0.0f);
              this.LookCamera = true;
            }
            else if (this.StudentID == 35)
            {
              this.CharacterAnimation.Play("f02_idleShort_00");
              this.transform.position = new Vector3(0.015f, 0.0f, 0.0f);
              this.LookCamera = true;
            }
            else if (this.StudentID == 38)
            {
              this.CharacterAnimation.Play("f02_idleGirly_00");
              this.CharacterAnimation["f02_idleGirly_00"].time = 0.0f;
            }
            else if (this.StudentID == 39)
            {
              this.CharacterAnimation.Play("f02_socialCameraPose_00");
              this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.05f, this.transform.position.z);
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
              this.CharacterAnimation.Play("f02_sleuthPortrait_00");
            else if (this.StudentID == 60)
              this.CharacterAnimation.Play("f02_sleuthPortrait_01");
            else if (this.StudentID == 64)
            {
              this.CharacterAnimation.Play("f02_idleShort_00");
              this.transform.position = new Vector3(0.015f, 0.0f, 0.0f);
              this.LookCamera = true;
            }
            else if (this.StudentID == 65)
            {
              this.CharacterAnimation.Play("f02_idleShort_00");
              this.transform.position = new Vector3(0.015f, 0.0f, 0.0f);
              this.LookCamera = true;
            }
            else if (this.StudentID == 71)
            {
              this.CharacterAnimation.Play("f02_idleGirly_00");
              this.CharacterAnimation["f02_idleGirly_00"].time = 0.0f;
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
              string str4 = "Casual";
              this.CharacterAnimation["f02_faceCouncil" + str4 + "_00"].layer = 1;
              this.CharacterAnimation.Play("f02_faceCouncil" + str4 + "_00");
              this.CharacterAnimation.Play("f02_socialCameraPose_00");
              this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.05f, this.transform.position.z);
            }
            else if (this.StudentID == 82 || this.StudentID == 52)
              this.CharacterAnimation.Play("f02_galPose_01");
            else if (this.StudentID == 83 || this.StudentID == 53)
              this.CharacterAnimation.Play("f02_galPose_02");
            else if (this.StudentID == 84 || this.StudentID == 54)
              this.CharacterAnimation.Play("f02_galPose_03");
            else if (this.StudentID == 85 || this.StudentID == 55)
              this.CharacterAnimation.Play("f02_galPose_04");
            else if (this.StudentID == 90)
              this.CharacterAnimation.Play("f02_nursePortraitPose_00");
            else if (this.StudentID == 91)
            {
              this.CharacterAnimation.Play("f02_teacherPortraitPose_11");
              this.transform.position = new Vector3(0.0233333f, 0.0f, 0.0f);
            }
            else if (this.StudentID == 92)
            {
              this.CharacterAnimation.Play("f02_teacherPortraitPose_12");
              this.transform.position = new Vector3(-0.045f, 0.0f, 0.0f);
            }
            else if (this.StudentID == 93)
              this.CharacterAnimation.Play("f02_teacherPortraitPose_21");
            else if (this.StudentID == 94)
              this.CharacterAnimation.Play("f02_teacherPortraitPose_22");
            else if (this.StudentID == 95)
              this.CharacterAnimation.Play("f02_teacherPortraitPose_31");
            else if (this.StudentID == 96)
              this.CharacterAnimation.Play("f02_teacherPortraitPose_32");
            else if (this.StudentID == 97)
            {
              this.CharacterAnimation.Play("f02_coachPortraitPose_02");
              this.transform.position = new Vector3(-0.029f, 0.0f, 0.0f);
            }
            else if (this.Club != ClubType.Council)
            {
              this.CharacterAnimation.Play("f02_idleShort_01");
              this.transform.position = new Vector3(0.015f, 0.0f, 0.0f);
              this.LookCamera = true;
            }
          }
          else
          {
            this.transform.position = new Vector3(0.015f, 0.0f, 0.0f);
            int studentId = this.StudentID;
            if (this.StudentID > 10 && this.StudentID < 20)
            {
              this.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
              this.CharacterAnimation.Play("f02_eightiesRivalPose_0" + (this.StudentID - 10).ToString());
            }
            else if (this.StudentID == 20)
            {
              this.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
              this.CharacterAnimation.Play("f02_eightiesRivalPose_10");
            }
            else if (this.StudentID == 36)
            {
              this.CharacterAnimation["f02_smile_00"].layer = 1;
              this.CharacterAnimation.Play("f02_smile_00");
              this.CharacterAnimation["f02_smile_00"].weight = 1f;
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
    }
    else
    {
      this.MaleUniformID = StudentGlobals.MaleUniform;
      foreach (GameObject galoAccessory in this.GaloAccessories)
        galoAccessory.SetActive(false);
      bool flag2 = false;
      if ((Object) this.StudentManager != (Object) null && this.StudentID == this.StudentManager.SuitorID)
        flag2 = true;
      if (flag2 && StudentGlobals.CustomSuitor)
      {
        if (StudentGlobals.CustomSuitorHair > 0)
          this.Hairstyle = StudentGlobals.CustomSuitorHair;
        if (StudentGlobals.CustomSuitorAccessory > 0)
        {
          this.Accessory = StudentGlobals.CustomSuitorAccessory;
          if (this.Accessory == 1)
          {
            Transform transform = this.MaleAccessories[1].transform;
            transform.localScale = new Vector3(1.066666f, 1f, 1f);
            transform.localPosition = new Vector3(0.0f, -1.525f, 0.0066666f);
          }
        }
        if (StudentGlobals.CustomSuitorBlack)
          this.HairColor = "SolidBlack";
        if (StudentGlobals.CustomSuitorJewelry > 0)
        {
          foreach (GameObject galoAccessory in this.GaloAccessories)
            galoAccessory.SetActive(true);
        }
      }
      if ((Object) this.StudentManager == (Object) null || !this.Eighties)
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
            this.ThickBrows.SetActive(true);
        }
        activeScene = SceneManager.GetActiveScene();
        if (activeScene.name == "PortraitScene")
        {
          if (this.StudentID == 26)
            this.CharacterAnimation.Play("idleHaughty_00");
          else if (this.StudentID == 36)
            this.CharacterAnimation.Play("slouchIdle_00");
          else if (this.StudentID == 56)
            this.CharacterAnimation.Play("idleConfident_00");
          else if (this.StudentID == 57)
            this.CharacterAnimation.Play("sleuthPortrait_00");
          else if (this.StudentID == 58)
            this.CharacterAnimation.Play("sleuthPortrait_01");
          else if (this.StudentID == 61)
          {
            this.CharacterAnimation.Play("scienceMad_00");
            this.transform.position = new Vector3(0.0f, 0.1f, 0.0f);
          }
          else if (this.StudentID == 62)
            this.CharacterAnimation.Play("idleFrown_00");
          else if (this.StudentID == 69)
            this.CharacterAnimation.Play("idleFrown_00");
          else if (this.StudentID == 76)
            this.CharacterAnimation.Play("delinquentPoseB");
          else if (this.StudentID == 77)
            this.CharacterAnimation.Play("delinquentPoseA");
          else if (this.StudentID == 78)
            this.CharacterAnimation.Play("delinquentPoseC");
          else if (this.StudentID == 79)
            this.CharacterAnimation.Play("delinquentPoseD");
          else if (this.StudentID == 80)
            this.CharacterAnimation.Play("delinquentPoseE");
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
            this.CouncilBrows[this.StudentID - 85].SetActive(true);
          if (this.StudentID == 76)
            this.CharacterAnimation.Play("delinquentPoseB");
          else if (this.StudentID == 77)
            this.CharacterAnimation.Play("delinquentPoseA");
          else if (this.StudentID == 78)
            this.CharacterAnimation.Play("delinquentPoseC");
          else if (this.StudentID == 79)
            this.CharacterAnimation.Play("delinquentPoseD");
          else if (this.StudentID == 80)
            this.CharacterAnimation.Play("delinquentPoseE");
        }
        if (this.Club == ClubType.Delinquent)
          this.transform.position = new Vector3(0.005f, 0.03f, 0.0f);
        else
          this.transform.position = new Vector3(0.005f, 0.0f, 0.0f);
      }
    }
    if (this.Club == ClubType.Teacher)
    {
      this.MyRenderer.sharedMesh = this.TeacherMesh;
      if (!SystemInfo.supportsComputeShaders)
        this.MyRenderer.sharedMesh.ClearBlendShapes();
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
      this.MyRenderer.sharedMesh = this.Eighties ? this.EightiesNurseMesh : this.NurseMesh;
      this.Teacher = true;
    }
    else if (this.Club == ClubType.Council)
    {
      this.Armband.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.285f, 0.0f));
      this.Armband.SetActive(true);
      string str5 = "";
      if (this.StudentID == 86)
        str5 = "Strict";
      if (this.StudentID == 87)
        str5 = "Casual";
      if (this.StudentID == 88)
        str5 = "Grace";
      if (this.StudentID == 89)
        str5 = "Edgy";
      if (!this.Eighties)
      {
        this.CharacterAnimation["f02_faceCouncil" + str5 + "_00"].layer = 1;
        this.CharacterAnimation.Play("f02_faceCouncil" + str5 + "_00");
        this.CharacterAnimation["f02_idleCouncil" + str5 + "_00"].time = 1f;
        this.CharacterAnimation.Play("f02_idleCouncil" + str5 + "_00");
      }
    }
    if (!ClubGlobals.GetClubClosed(this.Club) && (this.StudentID == 21 || this.StudentID == 26 || this.StudentID == 31 || this.StudentID == 36 || this.StudentID == 41 || this.StudentID == 46 || this.StudentID == 51 || this.StudentID == 56 || this.StudentID == 61 || this.StudentID == 66 || this.StudentID == 71))
    {
      if (!this.Kidnapped)
        this.Armband.SetActive(true);
      Renderer component = this.Armband.GetComponent<Renderer>();
      if (this.StudentID == 21)
        component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, -0.145f));
      else if (this.StudentID == 26)
        component.material.SetTextureOffset("_MainTex", new Vector2(0.0f, -0.145f));
      else if (this.StudentID == 31)
        component.material.SetTextureOffset("_MainTex", new Vector2(0.57f, 0.0f));
      else if (this.StudentID == 36)
      {
        if (!this.Eighties)
          component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, -0.29f));
        else
          component.material.SetTextureOffset("_MainTex", new Vector2(0.57f, -0.435f));
      }
      else if (this.StudentID == 41)
        component.material.SetTextureOffset("_MainTex", new Vector2(0.0f, -0.58f));
      else if (this.StudentID == 46)
        component.material.SetTextureOffset("_MainTex", new Vector2(0.0f, -0.435f));
      else if (this.StudentID == 51)
        component.material.SetTextureOffset("_MainTex", new Vector2(0.57f, -0.29f));
      else if (this.StudentID == 56)
        component.material.SetTextureOffset("_MainTex", new Vector2(0.0f, -0.29f));
      else if (this.StudentID == 61)
        component.material.SetTextureOffset("_MainTex", new Vector2(0.0f, 0.0f));
      else if (this.StudentID == 66)
        component.material.SetTextureOffset("_MainTex", new Vector2(0.57f, -0.145f));
      else if (this.StudentID == 71)
        component.material.SetTextureOffset("_MainTex", new Vector2(0.285f, -0.435f));
    }
    if (this.StudentID == 1 && SenpaiGlobals.CustomSenpai)
    {
      if (SenpaiGlobals.SenpaiEyeWear > 0)
        this.Eyewear[SenpaiGlobals.SenpaiEyeWear].SetActive(true);
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
          this.MyRenderer.materials[0].mainTexture = this.DefaultFaceTexture;
          this.MyRenderer.materials[1].mainTexture = this.TeacherBodyTexture;
          this.MyRenderer.materials[2].mainTexture = this.TeacherBodyTexture;
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
              this.MyRenderer.materials[2].mainTexture = this.CoachFaceTexture;
            else
              this.MyRenderer.materials[2].mainTexture = this.EightiesCoachFaceTexture;
            this.MyRenderer.materials[0].mainTexture = this.CoachBodyTexture;
            this.MyRenderer.materials[1].mainTexture = this.CoachBodyTexture;
          }
        }
        else if (this.Club == ClubType.Nurse)
        {
          if (!this.Eighties)
            this.MyRenderer.materials = this.NurseMaterials;
          else
            this.MyRenderer.materials = this.EightiesNurseMaterials;
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
        this.Eyewear[this.EyewearID].SetActive(true);
      this.SetMaleUniform();
    }
    if (!this.Male)
    {
      if (!this.Teacher)
      {
        if ((Object) this.FemaleAccessories[this.Accessory] != (Object) null)
          this.FemaleAccessories[this.Accessory].SetActive(true);
      }
      else if ((Object) this.TeacherAccessories[this.Accessory] != (Object) null && (!this.TakingPortrait || this.Eighties || this.TakingPortrait && this.StudentID < 97))
        this.TeacherAccessories[this.Accessory].SetActive(true);
    }
    else if ((Object) this.MaleAccessories[this.Accessory] != (Object) null)
      this.MaleAccessories[this.Accessory].SetActive(true);
    if (((Object) this.StudentManager == (Object) null || !this.Empty && !this.StudentManager.TutorialActive) && !this.Kidnapped)
    {
      if ((Object) this.StudentManager == (Object) null || !this.Eighties)
      {
        if ((this.Club < ClubType.Gaming || this.Club == ClubType.Newspaper) && (Object) this.ClubAccessories[(int) this.Club] != (Object) null && !ClubGlobals.GetClubClosed(this.Club) && this.StudentID != 26)
          this.ClubAccessories[(int) this.Club].SetActive(true);
        if (!this.Eighties && !this.Randomize && this.StudentID == 36)
          this.ClubAccessories[(int) this.Club].SetActive(true);
        if (this.Club == ClubType.Cooking)
        {
          this.ClubAccessories[(int) this.Club].SetActive(false);
          this.ClubAccessories[(int) this.Club] = this.Kerchiefs[this.StudentID];
          if (!ClubGlobals.GetClubClosed(this.Club) && this.StudentID > 12)
            this.ClubAccessories[(int) this.Club].SetActive(true);
        }
        else if (this.Club == ClubType.Drama)
        {
          this.ClubAccessories[(int) this.Club].SetActive(false);
          this.ClubAccessories[(int) this.Club] = this.Roses[this.StudentID];
          if (!ClubGlobals.GetClubClosed(this.Club))
            this.ClubAccessories[(int) this.Club].SetActive(true);
        }
        else if (this.Club == ClubType.Art)
        {
          this.ClubAccessories[(int) this.Club].GetComponent<MeshFilter>().sharedMesh = this.Berets[this.StudentID];
          if (this.StudentID == 44)
          {
            this.ClubAccessories[(int) this.Club].transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            this.ClubAccessories[(int) this.Club].transform.localScale = new Vector3(100f, 100f, 100f);
            this.ClubAccessories[(int) this.Club].transform.localPosition = new Vector3(0.0f, -1.445f, 0.02f);
          }
        }
        else if (this.Club == ClubType.Science)
        {
          if ((Object) this.ClubAccessories[(int) this.Club] != (Object) null)
            this.ClubAccessories[(int) this.Club].SetActive(false);
          this.ClubAccessories[(int) this.Club] = this.Scanners[this.StudentID];
          if (!ClubGlobals.GetClubClosed(this.Club))
            this.ClubAccessories[(int) this.Club].SetActive(true);
        }
        else if (this.Club == ClubType.LightMusic)
        {
          this.ClubAccessories[(int) this.Club].SetActive(false);
          this.ClubAccessories[(int) this.Club] = this.MusicNotes[this.StudentID - 50];
          if (!ClubGlobals.GetClubClosed(this.Club))
            this.ClubAccessories[(int) this.Club].SetActive(true);
        }
        else if (this.Club == ClubType.Sports)
        {
          this.ClubAccessories[(int) this.Club].SetActive(false);
          this.ClubAccessories[(int) this.Club] = this.Goggles[this.StudentID];
          if (!ClubGlobals.GetClubClosed(this.Club))
            this.ClubAccessories[(int) this.Club].SetActive(true);
        }
        else if (this.Club == ClubType.Gardening)
        {
          this.ClubAccessories[(int) this.Club].SetActive(false);
          this.ClubAccessories[(int) this.Club] = this.Flowers[this.StudentID];
          if (!ClubGlobals.GetClubClosed(this.Club))
            this.ClubAccessories[(int) this.Club].SetActive(true);
        }
        else if (this.Club == ClubType.Gaming)
        {
          if ((Object) this.ClubAccessories[(int) this.Club] != (Object) null)
            this.ClubAccessories[(int) this.Club].SetActive(false);
          this.ClubAccessories[(int) this.Club] = this.RedCloth[this.StudentID];
          if (!ClubGlobals.GetClubClosed(this.Club) && (Object) this.ClubAccessories[(int) this.Club] != (Object) null)
            this.ClubAccessories[(int) this.Club].SetActive(true);
        }
      }
      if (!this.Eighties && this.StudentID == 36 && (Object) this.StudentManager != (Object) null && (Object) this.StudentManager.TaskManager != (Object) null && this.StudentManager.TaskManager.TaskStatus[36] == 3)
        this.ClubAccessories[(int) this.Club].SetActive(false);
    }
    if (this.StudentID == 11 && !this.TakingPortrait && !this.Cutscene && !this.Kidnapped)
    {
      activeScene = SceneManager.GetActiveScene();
      if (activeScene.name == "SchoolScene")
      {
        this.CatGifts[1].SetActive(CollectibleGlobals.GetGiftGiven(1));
        this.CatGifts[2].SetActive(CollectibleGlobals.GetGiftGiven(2));
        this.CatGifts[3].SetActive(CollectibleGlobals.GetGiftGiven(3));
        this.CatGifts[4].SetActive(CollectibleGlobals.GetGiftGiven(4));
      }
    }
    if (!this.Male)
      this.StartCoroutine(this.PutOnStockings());
    if (!this.Randomize)
    {
      if (this.EyeColor != string.Empty)
      {
        this.CorrectColor = !(this.EyeColor == "White") ? (!(this.EyeColor == "Black") ? (!(this.EyeColor == "Red") ? (!(this.EyeColor == "Yellow") ? (!(this.EyeColor == "Green") ? (!(this.EyeColor == "Cyan") ? (!(this.EyeColor == "Blue") ? (!(this.EyeColor == "Purple") ? (!(this.EyeColor == "Orange") ? (!(this.EyeColor == "Brown") ? new Color(0.0f, 0.0f, 0.0f) : new Color(0.5f, 0.25f, 0.0f)) : new Color(1f, 0.5f, 0.0f)) : new Color(1f, 0.0f, 1f)) : new Color(0.0f, 0.0f, 1f)) : new Color(0.0f, 1f, 1f)) : new Color(0.0f, 1f, 0.0f)) : new Color(1f, 1f, 0.0f)) : new Color(1f, 0.0f, 0.0f)) : new Color(0.5f, 0.5f, 0.5f)) : new Color(1f, 1f, 1f);
        if (this.StudentID > 90 && this.StudentID < 97)
        {
          this.CorrectColor.r *= 0.5f;
          this.CorrectColor.g *= 0.5f;
          this.CorrectColor.b *= 0.5f;
        }
        if (this.CorrectColor != new Color(0.0f, 0.0f, 0.0f))
        {
          this.RightEyeRenderer.material.color = this.CorrectColor;
          this.LeftEyeRenderer.material.color = this.CorrectColor;
        }
      }
    }
    else
    {
      float r = Random.Range(0.0f, 1f);
      float g = Random.Range(0.0f, 1f);
      float b = Random.Range(0.0f, 1f);
      this.RightEyeRenderer.material.color = new Color(r, g, b);
      this.LeftEyeRenderer.material.color = new Color(r, g, b);
    }
    if (!this.Randomize)
    {
      if (this.HairColor == "White")
        this.ColorValue = new Color(1f, 1f, 1f);
      else if (this.HairColor == "Black")
        this.ColorValue = new Color(0.5f, 0.5f, 0.5f);
      else if (this.HairColor == "SolidBlack")
        this.ColorValue = new Color(0.0001f, 0.0001f, 0.0001f);
      else if (this.HairColor == "Red")
        this.ColorValue = new Color(1f, 0.0f, 0.0f);
      else if (this.HairColor == "Yellow")
        this.ColorValue = new Color(1f, 1f, 0.0f);
      else if (this.HairColor == "Green")
        this.ColorValue = new Color(0.0f, 1f, 0.0f);
      else if (this.HairColor == "Cyan")
        this.ColorValue = new Color(0.0f, 1f, 1f);
      else if (this.HairColor == "Blue")
        this.ColorValue = new Color(0.0f, 0.0f, 1f);
      else if (this.HairColor == "Purple")
        this.ColorValue = new Color(1f, 0.0f, 1f);
      else if (this.HairColor == "Orange")
        this.ColorValue = new Color(1f, 0.5f, 0.0f);
      else if (this.HairColor == "Brown")
      {
        this.ColorValue = new Color(0.5f, 0.25f, 0.0f);
      }
      else
      {
        this.ColorValue = new Color(0.0f, 0.0f, 0.0f);
        this.RightIrisLight.SetActive(false);
        this.LeftIrisLight.SetActive(false);
      }
      if (this.StudentID > 90 && this.StudentID < 97)
      {
        this.ColorValue.r *= 0.5f;
        this.ColorValue.g *= 0.5f;
        this.ColorValue.b *= 0.5f;
      }
      if (this.ColorValue == new Color(0.0f, 0.0f, 0.0f))
      {
        if ((Object) this.HairRenderer != (Object) null)
        {
          this.RightEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
          this.LeftEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
          if (!this.DoNotChangeFace)
            this.FaceTexture = this.HairRenderer.material.mainTexture;
        }
        if (this.Empty)
          this.FaceTexture = this.GrayFace;
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
              this.HairRenderer.materials[1].color = new Color(0.1f, 0.1f, 0.1f);
          }
          else
            this.HairRenderer.material.color = this.ColorValue;
        }
      }
      else if (GameGlobals.LoveSick)
      {
        this.HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
        if (this.HairRenderer.materials.Length > 1)
          this.HairRenderer.materials[1].color = new Color(0.1f, 0.1f, 0.1f);
      }
      if (!this.Male)
      {
        if (this.StudentID == 25)
          this.FemaleAccessories[6].GetComponent<Renderer>().material.color = new Color(0.0f, 1f, 1f);
        else if (this.StudentID == 30)
          this.FemaleAccessories[6].GetComponent<Renderer>().material.color = new Color(1f, 0.0f, 1f);
      }
    }
    else
      this.HairRenderer.material.color = new Color(Random.Range(0.0f, 1f), Random.Range(0.0f, 1f), Random.Range(0.0f, 1f));
    if (!this.Teacher)
    {
      if (this.CustomHair)
      {
        if (!this.Male)
          this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
        else if (this.Club == ClubType.Council)
          this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
        else if (this.MaleUniformID == 1)
          this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
        else if (this.MaleUniformID < 4)
          this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
        else
          this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
      }
    }
    else if (this.Teacher && StudentGlobals.GetStudentReplaced(this.StudentID))
    {
      Color studentColor = StudentGlobals.GetStudentColor(this.StudentID);
      Color studentEyeColor = StudentGlobals.GetStudentEyeColor(this.StudentID);
      this.Student.OriginalHairR = studentColor.r;
      this.Student.OriginalHairG = studentColor.g;
      this.Student.OriginalHairB = studentColor.b;
      this.Student.OriginalEyeR = studentColor.r;
      this.Student.OriginalEyeG = studentColor.g;
      this.Student.OriginalEyeB = studentColor.b;
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
      activeScene = SceneManager.GetActiveScene();
      if (activeScene.name == "PortraitScene")
        this.Character.transform.localScale = new Vector3(0.93f, 0.93f, 0.93f);
      if ((Object) this.FacialHairRenderer != (Object) null)
      {
        this.FacialHairRenderer.material.color = this.ColorValue;
        if (this.FacialHairRenderer.materials.Length > 1)
          this.FacialHairRenderer.materials[1].color = this.ColorValue;
      }
    }
    if (!this.Eighties)
    {
      if (this.StudentID != 10)
      {
        if (this.StudentID == 25 || this.StudentID == 30)
        {
          this.FemaleAccessories[6].SetActive(true);
          if ((double) StudentGlobals.GetStudentReputation(this.StudentID) < -33.333328247070313)
            this.FemaleAccessories[6].SetActive(false);
        }
        else if (this.StudentID == 2)
        {
          if (GameGlobals.RingStolen)
            this.FemaleAccessories[3].SetActive(false);
        }
        else if (this.StudentID == 40)
        {
          if (this.transform.position != Vector3.zero)
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
          this.ClubAccessories[7].transform.localPosition = new Vector3(0.0f, -1.04f, 0.5f);
          this.ClubAccessories[7].transform.localEulerAngles = new Vector3(-22.5f, 0.0f, 0.0f);
        }
        else if (this.StudentID == 60)
          this.FemaleAccessories[13].SetActive(true);
      }
    }
    else
    {
      if (this.StudentID == 86)
      {
        this.CharacterAnimation["moodyEyes_00"].layer = 1;
        this.CharacterAnimation.Play("moodyEyes_00");
        this.CharacterAnimation["moodyEyes_00"].weight = 1f;
        this.CharacterAnimation.Play("moodyEyes_00");
      }
      if (this.StudentID == 30)
        this.EnableRings();
    }
    if ((Object) this.Student != (Object) null && this.Student.AoT)
      this.Student.AttackOnTitan();
    if (this.HomeScene)
    {
      this.Student.CharacterAnimation["idle_00"].time = 9f;
      this.Student.CharacterAnimation["idle_00"].speed = 0.0f;
      this.Hairstyle = 65;
    }
    if (!this.Eighties)
      this.TaskCheck();
    this.TurnOnCheck();
    if (!this.Male && this.StudentID != 90)
      this.EyeTypeCheck();
    if (!this.Kidnapped && (!this.Student.Slave || this.Student.FragileSlave))
      return;
    this.WearBurlapSack();
  }

  public void SetMaleUniform()
  {
    if (this.StudentID == 1)
    {
      this.SkinColor = SenpaiGlobals.SenpaiSkinColor;
      this.FaceTexture = this.FaceTextures[this.SkinColor];
    }
    else
    {
      this.FaceTexture = !this.CustomHair ? this.HairRenderer.material.mainTexture : this.FaceTextures[this.SkinColor];
      bool flag = false;
      if ((Object) this.StudentManager != (Object) null && this.StudentID == this.StudentManager.SuitorID)
        flag = true;
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
    }
    else
    {
      this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
      this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[this.SkinColor];
      this.MyRenderer.materials[this.UniformID].mainTexture = this.UniformTexture;
    }
  }

  public void SetFemaleUniform()
  {
    if (this.Club != ClubType.Council)
    {
      if (this.FemaleUniformID == 0 && this.Eighties)
        this.FemaleUniformID = 6;
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
          this.Student.SwimsuitTexture = this.OsanaSwimsuitTexture;
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
    int club = (int) this.Club;
    if (this.MysteriousObstacle)
      this.FaceTexture = this.BlackBody;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    if (!this.TakingPortrait && (Object) this.Student != (Object) null && (Object) this.Student.StudentManager != (Object) null && GameGlobals.CensorPanties)
      this.CensorPanties();
    if (!((Object) this.MyStockings != (Object) null) || !this.gameObject.activeInHierarchy)
      return;
    this.StartCoroutine(this.PutOnStockings());
  }

  public void CensorPanties()
  {
    if (!this.Student.ClubAttire && this.Student.Schoolwear == 1)
    {
      this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
    }
    else
      this.RemoveCensor();
  }

  public void RemoveCensor()
  {
    this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0.0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0.0f);
  }

  private void TaskCheck()
  {
    if (this.StudentID == 37)
    {
      if (TaskGlobals.GetTaskStatus(37) >= 3)
        return;
      if (!this.TakingPortrait)
        this.MaleAccessories[1].SetActive(false);
      else
        this.MaleAccessories[1].SetActive(true);
    }
    else
    {
      if (this.StudentID != 11 || this.PhoneCharms.Length == 0)
        return;
      if (TaskGlobals.GetTaskStatus(11) < 3)
        this.PhoneCharms[11].SetActive(false);
      else
        this.PhoneCharms[11].SetActive(true);
    }
  }

  private void TurnOnCheck()
  {
    if (!this.TurnedOn && !this.TakingPortrait && this.Male)
    {
      if (this.Hairstyle == 46 || this.Hairstyle == 48 || this.Hairstyle == 49)
      {
        this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
        ++this.LoveManager.TotalTargets;
      }
      else if (this.Accessory > 1 && this.Accessory < 10 || this.Accessory == 13 || this.Accessory == 17)
      {
        this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
        ++this.LoveManager.TotalTargets;
      }
      else if (this.Student.Persona == PersonaType.TeachersPet)
      {
        this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
        ++this.LoveManager.TotalTargets;
      }
      else if (this.EyewearID > 0)
      {
        this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
        ++this.LoveManager.TotalTargets;
      }
      else if (this.SkinColor == 8)
      {
        this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
        ++this.LoveManager.TotalTargets;
      }
    }
    this.TurnedOn = true;
  }

  private void DestroyUnneccessaryObjects()
  {
    foreach (GameObject femaleAccessory in this.FemaleAccessories)
    {
      if ((Object) femaleAccessory != (Object) null && !femaleAccessory.activeInHierarchy)
        Object.Destroy((Object) femaleAccessory);
    }
    foreach (GameObject maleAccessory in this.MaleAccessories)
    {
      if ((Object) maleAccessory != (Object) null && !maleAccessory.activeInHierarchy)
        Object.Destroy((Object) maleAccessory);
    }
    foreach (GameObject clubAccessory in this.ClubAccessories)
    {
      if ((Object) clubAccessory != (Object) null && !clubAccessory.activeInHierarchy)
        Object.Destroy((Object) clubAccessory);
    }
    foreach (GameObject teacherAccessory in this.TeacherAccessories)
    {
      if ((Object) teacherAccessory != (Object) null && !teacherAccessory.activeInHierarchy)
        Object.Destroy((Object) teacherAccessory);
    }
    foreach (GameObject gameObject in this.TeacherHair)
    {
      if ((Object) gameObject != (Object) null && !gameObject.activeInHierarchy)
        Object.Destroy((Object) gameObject);
    }
    foreach (GameObject gameObject in this.FemaleHair)
    {
      if ((Object) gameObject != (Object) null && !gameObject.activeInHierarchy)
        Object.Destroy((Object) gameObject);
    }
    foreach (GameObject gameObject in this.MaleHair)
    {
      if ((Object) gameObject != (Object) null && !gameObject.activeInHierarchy)
        Object.Destroy((Object) gameObject);
    }
    foreach (GameObject gameObject in this.FacialHair)
    {
      if ((Object) gameObject != (Object) null && !gameObject.activeInHierarchy)
        Object.Destroy((Object) gameObject);
    }
    foreach (GameObject gameObject in this.Eyewear)
    {
      if ((Object) gameObject != (Object) null && !gameObject.activeInHierarchy)
        Object.Destroy((Object) gameObject);
    }
    foreach (GameObject rightStocking in this.RightStockings)
    {
      if ((Object) rightStocking != (Object) null && !rightStocking.activeInHierarchy)
        Object.Destroy((Object) rightStocking);
    }
    foreach (GameObject leftStocking in this.LeftStockings)
    {
      if ((Object) leftStocking != (Object) null && !leftStocking.activeInHierarchy)
        Object.Destroy((Object) leftStocking);
    }
  }

  public IEnumerator PutOnStockings()
  {
    this.RightStockings[0].SetActive(false);
    this.LeftStockings[0].SetActive(false);
    if ((Object) this.StudentManager != (Object) null && this.StudentManager.TutorialActive)
      this.Stockings = "";
    WWW NewCustomStockings;
    if (this.Stockings == string.Empty)
      this.MyStockings = (Texture) null;
    else if (this.Stockings == "Red")
      this.MyStockings = this.RedStockings;
    else if (this.Stockings == "Yellow")
      this.MyStockings = this.YellowStockings;
    else if (this.Stockings == "Green")
      this.MyStockings = this.GreenStockings;
    else if (this.Stockings == "Cyan")
      this.MyStockings = this.CyanStockings;
    else if (this.Stockings == "Blue")
      this.MyStockings = this.BlueStockings;
    else if (this.Stockings == "Purple")
      this.MyStockings = this.PurpleStockings;
    else if (this.Stockings == "ShortGreen")
      this.MyStockings = this.GreenSocks;
    else if (this.Stockings == "ShortRed")
      this.MyStockings = this.RedSocks;
    else if (this.Stockings == "ShortBlue")
      this.MyStockings = this.BlueSocks;
    else if (this.Stockings == "ShortYellow")
      this.MyStockings = this.YellowSocks;
    else if (this.Stockings == "ShortBlack")
      this.MyStockings = this.BlackKneeSocks;
    else if (this.Stockings == "Black")
      this.MyStockings = this.BlackStockings;
    else if (this.Stockings == "Osana")
      this.MyStockings = this.OsanaStockings;
    else if (this.Stockings == "Amai")
      this.MyStockings = this.AmaiStockings;
    else if (this.Stockings == "Kizana")
      this.MyStockings = this.KizanaStockings;
    else if (this.Stockings == "Dafuni")
      this.MyStockings = this.DafuniStockings;
    else if (this.Stockings == "Council1")
      this.MyStockings = this.TurtleStockings;
    else if (this.Stockings == "Council2")
      this.MyStockings = this.TigerStockings;
    else if (this.Stockings == "Council3")
      this.MyStockings = this.BirdStockings;
    else if (this.Stockings == "Council4")
      this.MyStockings = this.DragonStockings;
    else if (this.Stockings == "Music1")
    {
      if (!ClubGlobals.GetClubClosed(ClubType.LightMusic))
        this.MyStockings = this.MusicStockings[1];
    }
    else if (this.Stockings == "Music2")
      this.MyStockings = this.MusicStockings[2];
    else if (this.Stockings == "Music3")
      this.MyStockings = this.MusicStockings[3];
    else if (this.Stockings == "Music4")
      this.MyStockings = this.MusicStockings[4];
    else if (this.Stockings == "Music5")
      this.MyStockings = this.MusicStockings[5];
    else if (this.Stockings == "Sakyu")
      this.MyStockings = this.SakyuStockings;
    else if (this.Stockings == "Inkyu")
      this.MyStockings = this.InkyuStockings;
    else if (this.Stockings == "Socks")
      this.MyStockings = this.ShortWhiteSocks;
    else if (this.Stockings == "Custom1")
    {
      NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings1.png");
      yield return (object) NewCustomStockings;
      if (NewCustomStockings.error == null)
        this.CustomStockings[1] = (Texture) NewCustomStockings.texture;
      this.MyStockings = this.CustomStockings[1];
      NewCustomStockings = (WWW) null;
    }
    else if (this.Stockings == "Custom2")
    {
      NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings2.png");
      yield return (object) NewCustomStockings;
      if (NewCustomStockings.error == null)
        this.CustomStockings[2] = (Texture) NewCustomStockings.texture;
      this.MyStockings = this.CustomStockings[2];
      NewCustomStockings = (WWW) null;
    }
    else if (this.Stockings == "Custom3")
    {
      NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings3.png");
      yield return (object) NewCustomStockings;
      if (NewCustomStockings.error == null)
        this.CustomStockings[3] = (Texture) NewCustomStockings.texture;
      this.MyStockings = this.CustomStockings[3];
      NewCustomStockings = (WWW) null;
    }
    else if (this.Stockings == "Custom4")
    {
      NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings4.png");
      yield return (object) NewCustomStockings;
      if (NewCustomStockings.error == null)
        this.CustomStockings[4] = (Texture) NewCustomStockings.texture;
      this.MyStockings = this.CustomStockings[4];
      NewCustomStockings = (WWW) null;
    }
    else if (this.Stockings == "Custom5")
    {
      NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings5.png");
      yield return (object) NewCustomStockings;
      if (NewCustomStockings.error == null)
        this.CustomStockings[5] = (Texture) NewCustomStockings.texture;
      this.MyStockings = this.CustomStockings[5];
      NewCustomStockings = (WWW) null;
    }
    else if (this.Stockings == "Custom6")
    {
      NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings6.png");
      yield return (object) NewCustomStockings;
      if (NewCustomStockings.error == null)
        this.CustomStockings[6] = (Texture) NewCustomStockings.texture;
      this.MyStockings = this.CustomStockings[6];
      NewCustomStockings = (WWW) null;
    }
    else if (this.Stockings == "Custom7")
    {
      NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings7.png");
      yield return (object) NewCustomStockings;
      if (NewCustomStockings.error == null)
        this.CustomStockings[7] = (Texture) NewCustomStockings.texture;
      this.MyStockings = this.CustomStockings[7];
      NewCustomStockings = (WWW) null;
    }
    else if (this.Stockings == "Custom8")
    {
      NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings8.png");
      yield return (object) NewCustomStockings;
      if (NewCustomStockings.error == null)
        this.CustomStockings[8] = (Texture) NewCustomStockings.texture;
      this.MyStockings = this.CustomStockings[8];
      NewCustomStockings = (WWW) null;
    }
    else if (this.Stockings == "Custom9")
    {
      NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings9.png");
      yield return (object) NewCustomStockings;
      if (NewCustomStockings.error == null)
        this.CustomStockings[9] = (Texture) NewCustomStockings.texture;
      this.MyStockings = this.CustomStockings[9];
      NewCustomStockings = (WWW) null;
    }
    else if (this.Stockings == "Custom10")
    {
      NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings10.png");
      yield return (object) NewCustomStockings;
      if (NewCustomStockings.error == null)
        this.CustomStockings[10] = (Texture) NewCustomStockings.texture;
      this.MyStockings = this.CustomStockings[10];
      NewCustomStockings = (WWW) null;
    }
    else if (this.Stockings == "Rival")
      this.MyStockings = this.EightiesRivalStockings[this.StudentID];
    else if (this.Stockings == "Rival1")
      this.MyStockings = this.EightiesRivalStockings[11];
    else if (this.Stockings == "Rival2")
      this.MyStockings = this.EightiesRivalStockings[12];
    else if (this.Stockings == "Rival3")
      this.MyStockings = this.EightiesRivalStockings[13];
    else if (this.Stockings == "Rival4")
      this.MyStockings = this.EightiesRivalStockings[14];
    else if (this.Stockings == "Rival5")
      this.MyStockings = this.EightiesRivalStockings[15];
    else if (this.Stockings == "Rival6")
      this.MyStockings = this.EightiesRivalStockings[16];
    else if (this.Stockings == "Rival7")
      this.MyStockings = this.EightiesRivalStockings[17];
    else if (this.Stockings == "Rival8")
      this.MyStockings = this.EightiesRivalStockings[18];
    else if (this.Stockings == "Rival9")
      this.MyStockings = this.EightiesRivalStockings[19];
    else if (this.Stockings == "Rival10")
      this.MyStockings = this.EightiesRivalStockings[20];
    else if (this.Stockings == "Loose")
    {
      this.MyStockings = (Texture) null;
      this.RightStockings[0].SetActive(true);
      this.LeftStockings[0].SetActive(true);
    }
    else if (!this.Kidnapped && !this.Teacher && (Object) this.StudentManager.PantyList != (Object) null)
      this.MyStockings = !this.Eighties ? this.StudentManager.PantyList.EightiesPanties[Random.Range(1, this.StudentManager.PantyList.EightiesPanties.Length)] : this.StudentManager.PantyList.ModernPanties[Random.Range(1, this.StudentManager.PantyList.ModernPanties.Length)];
    if ((Object) this.MyStockings != (Object) null)
    {
      this.MyRenderer.materials[0].SetTexture("_OverlayTex", this.MyStockings);
      this.MyRenderer.materials[1].SetTexture("_OverlayTex", this.MyStockings);
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
    }
    else
    {
      this.MyRenderer.materials[0].SetTexture("_OverlayTex", (Texture) null);
      this.MyRenderer.materials[1].SetTexture("_OverlayTex", (Texture) null);
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0.0f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0.0f);
    }
  }

  public void WearIndoorShoes()
  {
    if (!this.Male)
    {
      this.MyRenderer.materials[0].mainTexture = this.CasualTexture;
      this.MyRenderer.materials[1].mainTexture = this.CasualTexture;
    }
    else
      this.MyRenderer.materials[this.UniformID].mainTexture = this.CasualTexture;
  }

  public void WearOutdoorShoes()
  {
    if (!this.Male)
    {
      this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
      this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
    }
    else
      this.MyRenderer.materials[this.UniformID].mainTexture = this.UniformTexture;
  }

  public void EyeTypeCheck()
  {
    int num = 0;
    if (this.EyeType == "Thin")
    {
      this.MyRenderer.SetBlendShapeWeight(8, 100f);
      this.MyRenderer.SetBlendShapeWeight(9, 100f);
      ++this.StudentManager.Thins;
      num = this.StudentManager.Thins;
    }
    else if (this.EyeType == "Serious")
    {
      this.MyRenderer.SetBlendShapeWeight(5, 50f);
      this.MyRenderer.SetBlendShapeWeight(9, 100f);
      ++this.StudentManager.Seriouses;
      num = this.StudentManager.Seriouses;
    }
    else if (this.EyeType == "Round")
    {
      this.MyRenderer.SetBlendShapeWeight(5, 15f);
      this.MyRenderer.SetBlendShapeWeight(9, 100f);
      ++this.StudentManager.Rounds;
      num = this.StudentManager.Rounds;
    }
    else if (this.EyeType == "Sad")
    {
      this.MyRenderer.SetBlendShapeWeight(0, 50f);
      this.MyRenderer.SetBlendShapeWeight(5, 15f);
      this.MyRenderer.SetBlendShapeWeight(6, 50f);
      this.MyRenderer.SetBlendShapeWeight(8, 50f);
      this.MyRenderer.SetBlendShapeWeight(9, 100f);
      ++this.StudentManager.Sads;
      num = this.StudentManager.Sads;
    }
    else if (this.EyeType == "Mean")
    {
      this.MyRenderer.SetBlendShapeWeight(10, 100f);
      ++this.StudentManager.Means;
      num = this.StudentManager.Means;
    }
    else if (this.EyeType == "Smug")
    {
      this.MyRenderer.SetBlendShapeWeight(0, 50f);
      this.MyRenderer.SetBlendShapeWeight(5, 25f);
      ++this.StudentManager.Smugs;
      num = this.StudentManager.Smugs;
    }
    else if (this.EyeType == "Gentle")
    {
      this.MyRenderer.SetBlendShapeWeight(9, 100f);
      this.MyRenderer.SetBlendShapeWeight(12, 100f);
      ++this.StudentManager.Gentles;
      num = this.StudentManager.Gentles;
    }
    else if (this.EyeType == "MO")
    {
      this.MyRenderer.SetBlendShapeWeight(8, 50f);
      this.MyRenderer.SetBlendShapeWeight(9, 100f);
      this.MyRenderer.SetBlendShapeWeight(12, 100f);
      ++this.StudentManager.Gentles;
      num = this.StudentManager.Gentles;
    }
    else if (this.EyeType == "Rival1")
    {
      this.MyRenderer.SetBlendShapeWeight(8, 5f);
      this.MyRenderer.SetBlendShapeWeight(9, 20f);
      this.MyRenderer.SetBlendShapeWeight(10, 50f);
      this.MyRenderer.SetBlendShapeWeight(11, 50f);
      this.MyRenderer.SetBlendShapeWeight(12, 10f);
      ++this.StudentManager.Rival1s;
      num = this.StudentManager.Rival1s;
    }
    else if (this.EyeType == "Eighties1")
    {
      this.MyRenderer.SetBlendShapeWeight(6, 15f);
      this.MyRenderer.SetBlendShapeWeight(8, 5f);
      this.MyRenderer.SetBlendShapeWeight(9, 100f);
      this.MyRenderer.SetBlendShapeWeight(10, 15f);
      this.MyRenderer.SetBlendShapeWeight(12, 100f);
    }
    else if (this.EyeType == "Eighties2")
    {
      this.MyRenderer.SetBlendShapeWeight(1, 15f);
      this.MyRenderer.SetBlendShapeWeight(5, 10f);
      this.MyRenderer.SetBlendShapeWeight(8, 25f);
      this.MyRenderer.SetBlendShapeWeight(9, 100f);
      this.MyRenderer.SetBlendShapeWeight(11, 25f);
      this.MyRenderer.SetBlendShapeWeight(12, 15f);
    }
    else if (this.EyeType == "Eighties3")
    {
      this.MyRenderer.SetBlendShapeWeight(5, 10f);
      this.MyRenderer.SetBlendShapeWeight(6, 75f);
      this.MyRenderer.SetBlendShapeWeight(8, 25f);
      this.MyRenderer.SetBlendShapeWeight(9, 75f);
      this.MyRenderer.SetBlendShapeWeight(11, 15f);
      this.MyRenderer.SetBlendShapeWeight(12, 15f);
    }
    else if (this.EyeType == "Eighties4")
    {
      this.MyRenderer.SetBlendShapeWeight(5, 10f);
      this.MyRenderer.SetBlendShapeWeight(9, 10f);
      this.MyRenderer.SetBlendShapeWeight(10, 25f);
      this.MyRenderer.SetBlendShapeWeight(11, 25f);
      this.MyRenderer.SetBlendShapeWeight(12, 50f);
    }
    else if (this.EyeType == "Eighties5")
    {
      this.MyRenderer.SetBlendShapeWeight(5, 10f);
      this.MyRenderer.SetBlendShapeWeight(6, 20f);
      this.MyRenderer.SetBlendShapeWeight(8, 25f);
      this.MyRenderer.SetBlendShapeWeight(9, 25f);
      this.MyRenderer.SetBlendShapeWeight(10, 15f);
      this.MyRenderer.SetBlendShapeWeight(11, 50f);
      this.MyRenderer.SetBlendShapeWeight(12, 10f);
    }
    else if (this.EyeType == "Eighties6")
    {
      this.MyRenderer.SetBlendShapeWeight(5, 10f);
      this.MyRenderer.SetBlendShapeWeight(8, 15f);
      this.MyRenderer.SetBlendShapeWeight(9, 100f);
      this.MyRenderer.SetBlendShapeWeight(10, 10f);
      this.MyRenderer.SetBlendShapeWeight(12, 25f);
    }
    else if (this.EyeType == "Eighties7")
    {
      this.MyRenderer.SetBlendShapeWeight(0, 20f);
      this.MyRenderer.SetBlendShapeWeight(5, 20f);
      this.MyRenderer.SetBlendShapeWeight(6, 25f);
      this.MyRenderer.SetBlendShapeWeight(8, 35f);
      this.MyRenderer.SetBlendShapeWeight(9, 50f);
      this.MyRenderer.SetBlendShapeWeight(11, 15f);
      this.MyRenderer.SetBlendShapeWeight(12, 25f);
    }
    else if (this.EyeType == "Eighties8")
    {
      this.MyRenderer.SetBlendShapeWeight(5, 10f);
      this.MyRenderer.SetBlendShapeWeight(6, 20f);
      this.MyRenderer.SetBlendShapeWeight(8, 50f);
      this.MyRenderer.SetBlendShapeWeight(9, 40f);
      this.MyRenderer.SetBlendShapeWeight(10, 20f);
      this.MyRenderer.SetBlendShapeWeight(11, 15f);
      this.MyRenderer.SetBlendShapeWeight(12, 10f);
    }
    else if (this.EyeType == "Eighties9")
    {
      this.MyRenderer.SetBlendShapeWeight(5, 10f);
      this.MyRenderer.SetBlendShapeWeight(6, 20f);
      this.MyRenderer.SetBlendShapeWeight(8, 50f);
      this.MyRenderer.SetBlendShapeWeight(9, 40f);
      this.MyRenderer.SetBlendShapeWeight(10, 20f);
      this.MyRenderer.SetBlendShapeWeight(11, 15f);
      this.MyRenderer.SetBlendShapeWeight(12, 10f);
    }
    else if (this.EyeType == "Eighties10")
    {
      this.MyRenderer.SetBlendShapeWeight(1, 10f);
      this.MyRenderer.SetBlendShapeWeight(5, 25f);
      this.MyRenderer.SetBlendShapeWeight(8, 25f);
      this.MyRenderer.SetBlendShapeWeight(9, 75f);
      this.MyRenderer.SetBlendShapeWeight(10, 30f);
      this.MyRenderer.SetBlendShapeWeight(11, 15f);
      this.MyRenderer.SetBlendShapeWeight(12, 25f);
    }
    else if (this.EyeType == "Witness")
    {
      this.MyRenderer.SetBlendShapeWeight(5, 15f);
      this.MyRenderer.SetBlendShapeWeight(6, 25f);
      this.MyRenderer.SetBlendShapeWeight(8, 25f);
      this.MyRenderer.SetBlendShapeWeight(9, 50f);
      this.MyRenderer.SetBlendShapeWeight(10, 5f);
      this.MyRenderer.SetBlendShapeWeight(12, 50f);
    }
    if (this.Modified)
      return;
    if (this.EyeType == "Thin" && this.StudentManager.Thins > 1 || this.EyeType == "Serious" && this.StudentManager.Seriouses > 1 || this.EyeType == "Round" && this.StudentManager.Rounds > 1 || this.EyeType == "Sad" && this.StudentManager.Sads > 1 || this.EyeType == "Mean" && this.StudentManager.Means > 1 || this.EyeType == "Smug" && this.StudentManager.Smugs > 1 || this.EyeType == "Gentle" && this.StudentManager.Gentles > 1)
    {
      this.MyRenderer.SetBlendShapeWeight(8, this.MyRenderer.GetBlendShapeWeight(8) + (float) num);
      this.MyRenderer.SetBlendShapeWeight(9, this.MyRenderer.GetBlendShapeWeight(9) + (float) num);
      this.MyRenderer.SetBlendShapeWeight(10, this.MyRenderer.GetBlendShapeWeight(10) + (float) num);
      this.MyRenderer.SetBlendShapeWeight(12, this.MyRenderer.GetBlendShapeWeight(12) + (float) num);
    }
    this.Modified = true;
  }

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

  public void LoadCosmeticSheet(StudentCosmeticSheet mySheet)
  {
    if (this.Male != mySheet.Male)
      return;
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
    if (this.Male)
      return;
    this.Stockings = mySheet.Stockings;
    this.StartCoroutine(this.Student.Cosmetic.PutOnStockings());
    for (int index = 0; index < this.MyRenderer.sharedMesh.blendShapeCount; ++index)
      this.MyRenderer.SetBlendShapeWeight(index, mySheet.Blendshapes[index]);
  }

  public StudentCosmeticSheet CosmeticSheet()
  {
    StudentCosmeticSheet studentCosmeticSheet = new StudentCosmeticSheet()
    {
      Blendshapes = new List<float>(),
      Male = this.Male,
      CustomHair = this.CustomHair,
      Accessory = this.Accessory,
      Hairstyle = this.Hairstyle,
      Stockings = this.Stockings,
      BreastSize = this.BreastSize
    };
    studentCosmeticSheet.CustomHair = this.CustomHair;
    studentCosmeticSheet.Schoolwear = this.Student.Schoolwear;
    studentCosmeticSheet.Bloody = this.Student.LiquidProjector.enabled && (Object) this.Student.LiquidProjector.material.mainTexture == (Object) this.Student.BloodTexture;
    studentCosmeticSheet.HairColor = this.HairRenderer.material.color;
    studentCosmeticSheet.EyeColor = this.RightEyeRenderer.material.color;
    if (!this.Male)
    {
      for (int index = 0; index < this.MyRenderer.sharedMesh.blendShapeCount; ++index)
        studentCosmeticSheet.Blendshapes.Add(this.MyRenderer.GetBlendShapeWeight(index));
    }
    return studentCosmeticSheet;
  }

  public void DisableAccessories()
  {
    foreach (GameObject femaleAccessory in this.FemaleAccessories)
    {
      if ((Object) femaleAccessory != (Object) null)
        femaleAccessory.SetActive(false);
    }
    foreach (GameObject maleAccessory in this.MaleAccessories)
    {
      if ((Object) maleAccessory != (Object) null)
        maleAccessory.SetActive(false);
    }
    foreach (GameObject clubAccessory in this.ClubAccessories)
    {
      if ((Object) clubAccessory != (Object) null)
        clubAccessory.SetActive(false);
    }
    foreach (GameObject teacherAccessory in this.TeacherAccessories)
    {
      if ((Object) teacherAccessory != (Object) null)
        teacherAccessory.SetActive(false);
    }
    foreach (GameObject gameObject in this.TeacherHair)
    {
      if ((Object) gameObject != (Object) null)
        gameObject.SetActive(false);
    }
    foreach (GameObject gameObject in this.FemaleHair)
    {
      if ((Object) gameObject != (Object) null)
        gameObject.SetActive(false);
    }
    foreach (GameObject gameObject in this.MaleHair)
    {
      if ((Object) gameObject != (Object) null)
        gameObject.SetActive(false);
    }
    foreach (GameObject gameObject in this.FacialHair)
    {
      if ((Object) gameObject != (Object) null)
        gameObject.SetActive(false);
    }
    foreach (GameObject gameObject in this.Eyewear)
    {
      if ((Object) gameObject != (Object) null)
        gameObject.SetActive(false);
    }
    foreach (GameObject rightStocking in this.RightStockings)
    {
      if ((Object) rightStocking != (Object) null)
        rightStocking.SetActive(false);
    }
    foreach (GameObject leftStocking in this.LeftStockings)
    {
      if ((Object) leftStocking != (Object) null)
        leftStocking.SetActive(false);
    }
    foreach (GameObject scanner in this.Scanners)
    {
      if ((Object) scanner != (Object) null)
        scanner.SetActive(false);
    }
    foreach (GameObject flower in this.Flowers)
    {
      if ((Object) flower != (Object) null)
        flower.SetActive(false);
    }
    foreach (GameObject rose in this.Roses)
    {
      if ((Object) rose != (Object) null)
        rose.SetActive(false);
    }
    this.RemoveRings();
    foreach (GameObject goggle in this.Goggles)
    {
      if ((Object) goggle != (Object) null)
        goggle.SetActive(false);
    }
    foreach (GameObject gameObject in this.RedCloth)
    {
      if ((Object) gameObject != (Object) null)
        gameObject.SetActive(false);
    }
    foreach (GameObject kerchief in this.Kerchiefs)
    {
      if ((Object) kerchief != (Object) null)
        kerchief.SetActive(false);
    }
    foreach (GameObject catGift in this.CatGifts)
    {
      if ((Object) catGift != (Object) null)
        catGift.SetActive(false);
    }
    foreach (GameObject punkAccessory in this.PunkAccessories)
    {
      if ((Object) punkAccessory != (Object) null)
        punkAccessory.SetActive(false);
    }
    foreach (GameObject musicNote in this.MusicNotes)
    {
      if ((Object) musicNote != (Object) null)
        musicNote.SetActive(false);
    }
    foreach (GameObject mask in this.Masks)
    {
      if ((Object) mask != (Object) null)
        mask.SetActive(false);
    }
    foreach (GameObject councilBrow in this.CouncilBrows)
    {
      if ((Object) councilBrow != (Object) null)
        councilBrow.SetActive(false);
    }
  }

  public void WearBurlapSack()
  {
    this.MyRenderer.enabled = false;
    this.BurlapSack.enabled = true;
    this.UpdateSack = true;
  }

  public void RemoveRings()
  {
    foreach (GameObject ring in this.Rings)
    {
      if ((Object) ring != (Object) null)
        ring.SetActive(false);
    }
  }

  public void EnableRings()
  {
    foreach (GameObject ring in this.Rings)
    {
      if ((Object) ring != (Object) null)
        ring.SetActive(true);
    }
    if (!((Object) this.StudentManager != (Object) null) || !((Object) this.StudentManager.Yandere != (Object) null) || !this.StudentManager.Yandere.Inventory.Ring)
      return;
    this.Rings[DateGlobals.Week].gameObject.SetActive(false);
  }

  public void Update()
  {
    if (this.UpdateSack)
    {
      this.DisableAccessories();
      this.FemaleHair[this.Hairstyle].SetActive(true);
      this.HairRenderer.enabled = true;
      if (this.Club == ClubType.Bully)
      {
        this.RightStockings[0].SetActive(false);
        this.LeftStockings[0].SetActive(false);
        this.Hoodie.SetActive(false);
        this.DeactivateBullyAccessories();
        this.SkinColor = 1;
      }
      if (!((Object) this.BurlapSack.newRenderer != (Object) null))
        return;
      this.BurlapSack.newRenderer.materials[0].mainTexture = this.SkinTextures[this.SkinColor];
      this.BurlapSack.newRenderer.materials[1].mainTexture = this.HairRenderer.material.mainTexture;
      this.BurlapSack.newRenderer.materials[2].mainTexture = this.BurlapSack.accessoryMaterials[0].mainTexture;
      this.UpdateSack = false;
    }
    else
      this.enabled = false;
  }

  public void DisableFingernails()
  {
    for (int index = 0; index < 10; ++index)
      this.Fingernails[index].gameObject.SetActive(false);
  }
}
