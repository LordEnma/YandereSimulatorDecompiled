// Decompiled with JetBrains decompiler
// Type: TallLockerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TallLockerScript : MonoBehaviour
{
  public GameObject[] BloodyClubUniform;
  public GameObject[] BloodyUniform;
  public GameObject[] Schoolwear;
  public bool[] Removed;
  public bool[] Bloody;
  public GameObject CleanUniform;
  public GameObject SteamCloud;
  public StudentManagerScript StudentManager;
  public RivalPhoneScript RivalPhone;
  public RingTheftScript Rings;
  public StudentScript Student;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public Transform Hinge;
  public bool RemovingClubAttire;
  public bool DropCleanUniform;
  public bool SteamCountdown;
  public bool YandereLocker;
  public bool Swapping;
  public bool Open;
  public float Rotation;
  public float Timer;
  public int AvailableUniforms = 2;
  public int Phase = 1;

  private void Start()
  {
    this.Prompt.HideButton[1] = true;
    this.Prompt.HideButton[2] = true;
    this.Prompt.HideButton[3] = true;
    if (!GameGlobals.EightiesTutorial)
      return;
    this.Schoolwear[2].SetActive(false);
    this.Bloody[2] = true;
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0 && !this.Yandere.Chased && this.Yandere.Chasers == 0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Open)
      {
        this.Open = true;
        if (this.YandereLocker)
        {
          if (!this.Yandere.ClubAttire || this.Yandere.ClubAttire && (double) this.Yandere.Bloodiness > 0.0)
          {
            if ((double) this.Yandere.Bloodiness == 0.0)
            {
              if (!this.Bloody[1])
                this.Prompt.HideButton[1] = false;
              if (!this.Bloody[2])
                this.Prompt.HideButton[2] = false;
              if (!this.Bloody[3])
                this.Prompt.HideButton[3] = false;
            }
            else if (this.Yandere.Schoolwear > 0)
            {
              if (!this.Yandere.ClubAttire)
                this.Prompt.HideButton[this.Yandere.Schoolwear] = false;
              else
                this.Prompt.HideButton[1] = false;
            }
          }
          else
          {
            this.Prompt.HideButton[1] = true;
            this.Prompt.HideButton[2] = true;
            this.Prompt.HideButton[3] = true;
          }
        }
        this.UpdateSchoolwear();
        this.Prompt.Label[0].text = "     Close";
      }
      else
      {
        this.Open = false;
        this.Prompt.HideButton[1] = true;
        this.Prompt.HideButton[2] = true;
        this.Prompt.HideButton[3] = true;
        this.Prompt.Label[0].text = "     Open";
      }
    }
    if (!this.Open)
    {
      if (this.YandereLocker)
        this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * 10f);
      this.Prompt.HideButton[1] = true;
      this.Prompt.HideButton[2] = true;
      this.Prompt.HideButton[3] = true;
    }
    else
    {
      if (this.YandereLocker)
        this.Rotation = Mathf.Lerp(this.Rotation, -180f, Time.deltaTime * 10f);
      if ((double) this.Prompt.Circle[1].fillAmount == 0.0)
      {
        this.Yandere.EmptyHands();
        if (this.Yandere.ClubAttire)
          this.RemovingClubAttire = true;
        this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
        if (this.Yandere.Schoolwear == 1)
        {
          this.Yandere.Schoolwear = 0;
          if (!this.Removed[1])
          {
            if ((double) this.Yandere.Bloodiness == 0.0 && (double) this.Yandere.OriginalBloodiness == 0.0)
              this.DropCleanUniform = true;
          }
          else
            this.Removed[1] = false;
        }
        else
        {
          this.Yandere.Schoolwear = 1;
          this.Removed[1] = true;
        }
        this.SpawnSteam();
        this.Yandere.CurrentUniformOrigin = 1;
      }
      else if ((double) this.Prompt.Circle[2].fillAmount == 0.0)
      {
        bool flag = false;
        if (this.Yandere.Schoolwear > 0)
        {
          Debug.Log((object) "Checking to see if it's okay for the player to take off clothing.");
          if (this.Yandere.Schoolwear == 2 && (double) this.Yandere.Bloodiness > 0.0)
          {
            this.Yandere.NotificationManager.CustomText = "Take a shower first!";
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
          else
          {
            this.CheckAvailableUniforms();
            if (this.AvailableUniforms > 0)
            {
              flag = true;
            }
            else
            {
              this.Yandere.NotificationManager.CustomText = "Bring a clean uniform here first!";
              this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
            }
          }
        }
        else
          flag = true;
        if (flag)
        {
          this.Yandere.EmptyHands();
          if (this.Yandere.ClubAttire)
            this.RemovingClubAttire = true;
          this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
          if (this.Yandere.Schoolwear == 1 && !this.Removed[1])
            this.DropCleanUniform = true;
          if (this.Yandere.Schoolwear == 2)
          {
            this.Yandere.Schoolwear = 0;
            this.Removed[2] = false;
          }
          else
          {
            this.Yandere.Schoolwear = 2;
            this.Removed[2] = true;
          }
          this.SpawnSteam();
          this.Yandere.CurrentUniformOrigin = 1;
        }
        else
        {
          this.Prompt.Circle[2].fillAmount = 1f;
          Debug.Log((object) "Error Message.");
        }
      }
      else if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
      {
        this.Yandere.EmptyHands();
        if (this.Yandere.ClubAttire)
          this.RemovingClubAttire = true;
        this.Yandere.PreviousSchoolwear = this.Yandere.Schoolwear;
        if (this.Yandere.Schoolwear == 1 && !this.Removed[1])
          this.DropCleanUniform = true;
        if (this.Yandere.Schoolwear == 3)
        {
          this.Yandere.Schoolwear = 0;
          this.Removed[3] = false;
        }
        else
        {
          this.Yandere.Schoolwear = 3;
          this.Removed[3] = true;
        }
        this.SpawnSteam();
        this.Yandere.CurrentUniformOrigin = 1;
      }
    }
    if (this.YandereLocker)
      this.Hinge.localEulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
    if (!this.SteamCountdown)
      return;
    this.Timer += Time.deltaTime;
    if (this.Phase == 1)
    {
      if ((double) this.Timer <= 1.5)
        return;
      if (this.YandereLocker)
      {
        if (this.Yandere.Gloved)
        {
          this.Yandere.Gloves.GetComponent<PickUpScript>().MyRigidbody.isKinematic = false;
          this.Yandere.Gloves.transform.parent = this.Yandere.transform;
          this.Yandere.Gloves.transform.localPosition = new Vector3(0.0f, 1f, -1f);
          this.Yandere.Gloves.transform.parent = (Transform) null;
          this.Yandere.GloveAttacher.newRenderer.enabled = false;
          this.Yandere.Gloves.gameObject.SetActive(true);
          this.Yandere.Gloved = false;
          this.Yandere.Gloves = (GloveScript) null;
          this.Yandere.GloveBlood = 0;
        }
        if ((Object) this.Yandere.Mask != (Object) null)
        {
          this.Yandere.Mask.Drop();
          this.Yandere.WeaponMenu.UpdateSprites();
          this.StudentManager.UpdateStudents();
        }
        if (this.Yandere.WearingRaincoat)
        {
          this.Yandere.RaincoatAttacher.newRenderer.enabled = false;
          this.Yandere.PantyAttacher.newRenderer.enabled = true;
          this.Yandere.TheDebugMenuScript.UpdateCensor();
          this.Yandere.CoatBloodiness = this.Yandere.Bloodiness;
          this.Yandere.Bloodiness = this.Yandere.OriginalBloodiness;
          this.Yandere.WearingRaincoat = false;
          this.Yandere.Hairstyle = this.StudentManager.Eighties ? 203 : 1;
          this.Yandere.UpdateHair();
        }
        this.Yandere.ChangeSchoolwear();
        if ((double) this.Yandere.Bloodiness > 0.0)
        {
          PickUpScript component;
          if (this.RemovingClubAttire)
          {
            component = Object.Instantiate<GameObject>(this.BloodyClubUniform[(int) this.Yandere.Club], this.Yandere.transform.position + Vector3.forward * 0.5f + Vector3.up, Quaternion.identity).GetComponent<PickUpScript>();
            this.StudentManager.ChangingBooths[(int) this.Yandere.Club].CannotChange = true;
            this.StudentManager.ChangingBooths[(int) this.Yandere.Club].CheckYandereClub();
            this.Prompt.HideButton[1] = true;
            this.Prompt.HideButton[2] = true;
            this.Prompt.HideButton[3] = true;
            this.RemovingClubAttire = false;
          }
          else
          {
            component = Object.Instantiate<GameObject>(this.BloodyUniform[this.Yandere.PreviousSchoolwear], this.Yandere.transform.position + Vector3.forward * 0.5f + Vector3.up, Quaternion.identity).GetComponent<PickUpScript>();
            this.Prompt.HideButton[this.Yandere.PreviousSchoolwear] = true;
            this.Bloody[this.Yandere.PreviousSchoolwear] = true;
          }
          if (this.Yandere.RedPaint)
            component.RedPaint = true;
        }
      }
      else if ((Object) this.Student != (Object) null)
      {
        if (this.Student.Schoolwear == 0 && !this.Student.Male)
        {
          Debug.Log((object) "Checking if something needs to appear at this student's locker...");
          if (!this.StudentManager.Eighties)
          {
            if (!this.RivalPhone.gameObject.activeInHierarchy && !this.Yandere.Inventory.RivalPhone)
            {
              Debug.Log((object) (((object) this.Student)?.ToString() + " just left her smartphone in the locker room!"));
              this.RivalPhone.transform.parent = this.StudentManager.StrippingPositions[this.Student.GirlID];
              this.RivalPhone.transform.localPosition = new Vector3(0.1f, 0.92f, 0.2375f);
              this.RivalPhone.transform.localEulerAngles = new Vector3(-80f, 0.0f, 0.0f);
              Physics.SyncTransforms();
              this.RivalPhone.gameObject.SetActive(true);
              this.RivalPhone.StudentID = this.Student.StudentID;
              this.RivalPhone.MyRenderer.material.mainTexture = this.Student.SmartPhone.GetComponent<Renderer>().material.mainTexture;
            }
            if (this.Student.StudentID == 2 && this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory].activeInHierarchy)
            {
              this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory].SetActive(false);
              Debug.Log((object) "Sakyu Basu just left her ring in the locker room!");
              this.Rings.gameObject.SetActive(true);
            }
          }
          else if (this.Student.StudentID == 30)
          {
            Debug.Log((object) "Himedere just left her ring in the locker room!");
            this.Rings.gameObject.SetActive(true);
          }
        }
        this.Student.ChangeSchoolwear();
      }
      this.UpdateSchoolwear();
      ++this.Phase;
    }
    else
    {
      if ((double) this.Timer <= 2.5)
        return;
      if (!this.YandereLocker && (Object) this.Student != (Object) null)
        ++this.Student.BathePhase;
      this.SteamCountdown = false;
      this.Phase = 1;
      this.Timer = 0.0f;
    }
  }

  public void SpawnSteam()
  {
    if ((Object) this.Student != (Object) null)
      Debug.Log((object) (((object) this.Student)?.ToString() + " is changing clothes, with all strings attached."));
    this.SteamCountdown = true;
    if (this.YandereLocker)
    {
      Object.Instantiate<GameObject>(this.SteamCloud, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
      this.Yandere.CharacterAnimation.CrossFade("f02_stripping_00");
      this.Yandere.Stripping = true;
      this.Yandere.CanMove = false;
      this.Timer = 0.0f;
    }
    else
    {
      Object.Instantiate<GameObject>(this.SteamCloud, this.Student.transform.position + Vector3.up * 0.81f, Quaternion.identity).transform.parent = this.Student.transform;
      this.Student.CharacterAnimation.CrossFade(this.Student.StripAnim);
      this.Student.Pathfinding.canSearch = false;
      this.Student.Pathfinding.canMove = false;
      this.Student.Cosmetic.RemoveRings();
    }
  }

  public void SpawnSteamNoSideEffects(StudentScript SteamStudent)
  {
    Debug.Log((object) ("Student #" + SteamStudent.StudentID.ToString() + ", " + SteamStudent.Name + ", is changing clothes, no strings attached."));
    Object.Instantiate<GameObject>(this.SteamCloud, SteamStudent.transform.position + Vector3.up * 0.81f, Quaternion.identity).transform.parent = SteamStudent.transform;
    SteamStudent.CharacterAnimation.CrossFade(SteamStudent.StripAnim);
    SteamStudent.Pathfinding.canSearch = false;
    SteamStudent.Pathfinding.canMove = false;
    SteamStudent.MustChangeClothing = false;
    SteamStudent.Stripping = true;
    SteamStudent.Routine = false;
    SteamStudent.WalkAnim = SteamStudent.OriginalOriginalWalkAnim;
  }

  public void UpdateSchoolwear()
  {
    if (this.DropCleanUniform)
    {
      Object.Instantiate<GameObject>(this.CleanUniform, this.Yandere.transform.position + Vector3.forward * -0.5f + Vector3.up, Quaternion.identity);
      this.DropCleanUniform = false;
    }
    if (!this.Bloody[1])
      this.Schoolwear[1].SetActive(true);
    if (!this.Bloody[2])
      this.Schoolwear[2].SetActive(true);
    if (!this.Bloody[3])
      this.Schoolwear[3].SetActive(true);
    this.Prompt.Label[1].text = "     School Uniform";
    this.Prompt.Label[2].text = "     School Swimsuit";
    this.Prompt.Label[3].text = "     Gym Uniform";
    if (this.YandereLocker)
    {
      if (!this.Yandere.ClubAttire)
      {
        if (this.Yandere.Schoolwear <= 0)
          return;
        this.Prompt.Label[this.Yandere.Schoolwear].text = "     Towel";
        if (!this.Removed[this.Yandere.Schoolwear])
          return;
        this.Schoolwear[this.Yandere.Schoolwear].SetActive(false);
      }
      else
        this.Prompt.Label[1].text = "     Towel";
    }
    else
    {
      if (!((Object) this.Student != (Object) null) || this.Student.Schoolwear <= 0)
        return;
      this.Prompt.HideButton[this.Student.Schoolwear] = true;
      this.Schoolwear[this.Student.Schoolwear].SetActive(false);
      this.Student.Indoors = true;
    }
  }

  public void UpdateButtons()
  {
    if (!this.Yandere.ClubAttire || this.Yandere.ClubAttire && (double) this.Yandere.Bloodiness > 0.0)
    {
      if (!this.Open)
        return;
      if ((double) this.Yandere.Bloodiness > 0.0)
      {
        this.Prompt.HideButton[1] = true;
        this.Prompt.HideButton[2] = true;
        this.Prompt.HideButton[3] = true;
        if (this.Yandere.Schoolwear > 0 && !this.Yandere.ClubAttire)
          this.Prompt.HideButton[this.Yandere.Schoolwear] = false;
        if (!this.Yandere.ClubAttire)
          return;
        Debug.Log((object) "Don't hide Prompt 1!");
        this.Prompt.HideButton[1] = false;
      }
      else
      {
        if (!this.Bloody[1])
          this.Prompt.HideButton[1] = false;
        if (!this.Bloody[2])
          this.Prompt.HideButton[2] = false;
        if (this.Bloody[3])
          return;
        this.Prompt.HideButton[3] = false;
      }
    }
    else
    {
      this.Prompt.HideButton[1] = true;
      this.Prompt.HideButton[2] = true;
      this.Prompt.HideButton[3] = true;
    }
  }

  private void CheckAvailableUniforms()
  {
    this.AvailableUniforms = this.StudentManager.OriginalUniforms;
    Debug.Log((object) (this.AvailableUniforms.ToString() + " of the original uniforms are still clean."));
    Debug.Log((object) ("There are " + this.StudentManager.NewUniforms.ToString() + " new uniforms in school."));
    if (this.StudentManager.NewUniforms <= 0)
      return;
    for (int index = 0; index < this.StudentManager.Uniforms.Length; ++index)
    {
      Transform uniform = this.StudentManager.Uniforms[index];
      if ((Object) uniform != (Object) null && this.StudentManager.LockerRoomArea.bounds.Contains(uniform.position))
      {
        Debug.Log((object) "Cool, there's a uniform in the locker room.");
        if (uniform.GetComponent<FoldedUniformScript>().Clean)
        {
          Debug.Log((object) "AND it's clean!");
          ++this.AvailableUniforms;
        }
        else
          Debug.Log((object) "BUT, it's not clean!");
      }
    }
  }
}
