// Decompiled with JetBrains decompiler
// Type: ShoeRemovalScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ShoeRemovalScript : MonoBehaviour
{
  public StudentScript Student;
  public Vector3 RightShoePosition;
  public Vector3 LeftShoePosition;
  public Transform RightCurrentShoe;
  public Transform LeftCurrentShoe;
  public Transform RightCasualShoe;
  public Transform LeftCasualShoe;
  public Transform RightSchoolShoe;
  public Transform LeftSchoolShoe;
  public Transform RightNewShoe;
  public Transform LeftNewShoe;
  public Transform RightFoot;
  public Transform LeftFoot;
  public Transform RightHand;
  public Transform LeftHand;
  public Transform ShoeParent;
  public Transform Locker;
  public GameObject NewPairOfShoes;
  public GameObject Character;
  public string[] LockerAnims;
  public Texture OutdoorShoes;
  public Texture IndoorShoes;
  public Texture TargetShoes;
  public Texture Socks;
  public Renderer MyRenderer;
  public bool RemovingCasual = true;
  public bool Male;
  public int Height;
  public int Phase = 1;
  public float X;
  public float Y;
  public float Z;
  public string RemoveCasualAnim = string.Empty;
  public string RemoveSchoolAnim = string.Empty;
  public string RemovalAnim = string.Empty;

  public void Start()
  {
    if (!((Object) this.Locker == (Object) null))
      return;
    this.GetHeight(this.Student.StudentID);
    this.Locker = this.Student.StudentManager.Lockers.List[this.Student.StudentID];
    GameObject gameObject = Object.Instantiate<GameObject>(this.NewPairOfShoes, this.transform.position, Quaternion.identity);
    gameObject.transform.parent = this.Locker;
    gameObject.transform.localEulerAngles = new Vector3(0.0f, -180f, 0.0f);
    gameObject.transform.localPosition = new Vector3(0.0f, (float) (0.30000001192092896 * (double) this.Height - 0.28999999165534973), this.Male ? 0.04f : 0.05f);
    this.LeftSchoolShoe = gameObject.transform.GetChild(0);
    this.RightSchoolShoe = gameObject.transform.GetChild(1);
    this.RemovalAnim = this.RemoveCasualAnim;
    this.RightCurrentShoe = this.RightCasualShoe;
    this.LeftCurrentShoe = this.LeftCasualShoe;
    this.RightNewShoe = this.RightSchoolShoe;
    this.LeftNewShoe = this.LeftSchoolShoe;
    this.ShoeParent = gameObject.transform;
    this.TargetShoes = this.IndoorShoes;
    this.RightShoePosition = this.RightCurrentShoe.localPosition;
    this.LeftShoePosition = this.LeftCurrentShoe.localPosition;
    this.RightCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
    this.LeftCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
    this.OutdoorShoes = this.Student.Cosmetic.CasualTexture;
    this.IndoorShoes = this.Student.Cosmetic.UniformTexture;
    this.Socks = this.Student.Cosmetic.SocksTexture;
    this.TargetShoes = this.IndoorShoes;
  }

  public void StartChangingShoes()
  {
    if (this.Student.AoT)
      return;
    this.RightCasualShoe.gameObject.SetActive(true);
    this.LeftCasualShoe.gameObject.SetActive(true);
    if (!this.Male)
    {
      this.MyRenderer.materials[0].mainTexture = this.Socks;
      this.MyRenderer.materials[1].mainTexture = this.Socks;
    }
    else
      this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.Socks;
    int num = (Object) this.Student.Follower != (Object) null ? 1 : 0;
  }

  private void Update()
  {
    if (!this.Student.DiscCheck && !this.Student.Dying && !this.Student.InEvent && !this.Student.Alarmed && !this.Student.Splashed && !this.Student.TurnOffRadio)
    {
      if ((Object) this.Student.Destinations[this.Student.Phase] == (Object) null)
        ++this.Student.Phase;
      if ((Object) this.Student.CurrentDestination == (Object) null)
      {
        this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase];
        this.Student.Pathfinding.target = this.Student.CurrentDestination;
      }
      this.Student.MoveTowardsTarget(this.Student.CurrentDestination.position);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Student.CurrentDestination.rotation, 10f * Time.deltaTime);
      this.Student.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
      this.Student.CharacterAnimation.CrossFade(this.RemovalAnim);
      if (this.Phase == 1)
      {
        if ((double) this.Student.CharacterAnimation[this.RemovalAnim].time < 0.83333301544189453)
          return;
        int num = (Object) this.Student.Follower != (Object) null ? 1 : 0;
        if (this.Student.StudentID == this.Student.StudentManager.RivalID && !this.Student.StudentManager.MissionMode && !GameGlobals.AlphabetMode && !GameGlobals.Eighties && DateGlobals.Week == 1)
        {
          Debug.Log((object) ("Apparently, GameGlobals.Eighties is: " + GameGlobals.Eighties.ToString()));
          this.Student.StudentManager.UpdateExteriorStudents();
        }
        this.ShoeParent.parent = this.LeftHand;
        ++this.Phase;
      }
      else if (this.Phase == 2)
      {
        if ((double) this.Student.CharacterAnimation[this.RemovalAnim].time < 1.8333330154418945)
          return;
        this.ShoeParent.parent = this.Locker;
        this.X = this.ShoeParent.localEulerAngles.x;
        this.Y = this.ShoeParent.localEulerAngles.y;
        this.Z = this.ShoeParent.localEulerAngles.z;
        ++this.Phase;
      }
      else if (this.Phase == 3)
      {
        this.X = Mathf.MoveTowards(this.X, 0.0f, Time.deltaTime * 360f);
        this.Y = Mathf.MoveTowards(this.Y, 186.878f, Time.deltaTime * 360f);
        this.Z = Mathf.MoveTowards(this.Z, 0.0f, Time.deltaTime * 360f);
        this.ShoeParent.localEulerAngles = new Vector3(this.X, this.Y, this.Z);
        this.ShoeParent.localPosition = Vector3.MoveTowards(this.ShoeParent.localPosition, new Vector3(0.272f, 0.0f, 0.552f), Time.deltaTime);
        if ((double) this.ShoeParent.localPosition.y != 0.0)
          return;
        this.ShoeParent.localPosition = new Vector3(0.272f, 0.0f, 0.552f);
        this.ShoeParent.localEulerAngles = new Vector3(0.0f, 186.878f, 0.0f);
        ++this.Phase;
      }
      else if (this.Phase == 4)
      {
        if ((double) this.Student.CharacterAnimation[this.RemovalAnim].time < 3.5)
          return;
        this.RightCurrentShoe.parent = (Transform) null;
        this.RightCurrentShoe.position = new Vector3(this.RightCurrentShoe.position.x, 0.05f, this.RightCurrentShoe.position.z);
        this.RightCurrentShoe.localEulerAngles = new Vector3(0.0f, this.RightCurrentShoe.localEulerAngles.y, 0.0f);
        ++this.Phase;
      }
      else if (this.Phase == 5)
      {
        if ((double) this.Student.CharacterAnimation[this.RemovalAnim].time < 4.0)
          return;
        this.LeftCurrentShoe.parent = (Transform) null;
        this.LeftCurrentShoe.position = new Vector3(this.LeftCurrentShoe.position.x, 0.05f, this.LeftCurrentShoe.position.z);
        this.LeftCurrentShoe.localEulerAngles = new Vector3(0.0f, this.LeftCurrentShoe.localEulerAngles.y, 0.0f);
        ++this.Phase;
      }
      else if (this.Phase == 6)
      {
        if ((double) this.Student.CharacterAnimation[this.RemovalAnim].time < 5.5)
          return;
        this.LeftNewShoe.parent = this.LeftFoot;
        this.LeftNewShoe.localPosition = this.LeftShoePosition;
        this.LeftNewShoe.localEulerAngles = Vector3.zero;
        ++this.Phase;
      }
      else if (this.Phase == 7)
      {
        if ((double) this.Student.CharacterAnimation[this.RemovalAnim].time < 6.6666598320007324)
          return;
        if (!this.Student.AoT)
        {
          if (!this.Male)
          {
            this.MyRenderer.materials[0].mainTexture = this.TargetShoes;
            this.MyRenderer.materials[1].mainTexture = this.TargetShoes;
          }
          else
            this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.TargetShoes;
        }
        this.RightNewShoe.parent = this.RightFoot;
        this.RightNewShoe.localPosition = this.RightShoePosition;
        this.RightNewShoe.localEulerAngles = Vector3.zero;
        this.RightNewShoe.gameObject.SetActive(false);
        this.LeftNewShoe.gameObject.SetActive(false);
        ++this.Phase;
      }
      else if (this.Phase == 8)
      {
        if ((double) this.Student.CharacterAnimation[this.RemovalAnim].time < 7.6666660308837891)
          return;
        this.ShoeParent.transform.position = (this.RightCurrentShoe.position - this.LeftCurrentShoe.position) * 0.5f;
        this.RightCurrentShoe.parent = this.ShoeParent;
        this.LeftCurrentShoe.parent = this.ShoeParent;
        this.ShoeParent.parent = this.RightHand;
        ++this.Phase;
      }
      else if (this.Phase == 9)
      {
        if ((double) this.Student.CharacterAnimation[this.RemovalAnim].time < 8.5)
          return;
        this.ShoeParent.parent = this.Locker;
        this.ShoeParent.localPosition = new Vector3(0.0f, (float) (((Object) this.TargetShoes == (Object) this.IndoorShoes ? -0.14000000059604645 : -0.28999999165534973) + 0.30000001192092896 * (double) this.Height), -0.01f);
        this.ShoeParent.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
        this.RightCurrentShoe.localPosition = new Vector3(0.041f, 0.04271515f, 0.0f);
        this.LeftCurrentShoe.localPosition = new Vector3(-0.041f, 0.04271515f, 0.0f);
        this.RightCurrentShoe.localEulerAngles = Vector3.zero;
        this.LeftCurrentShoe.localEulerAngles = Vector3.zero;
        ++this.Phase;
      }
      else
      {
        if (this.Phase != 10 || (double) this.Student.CharacterAnimation[this.RemovalAnim].time < (double) this.Student.CharacterAnimation[this.RemovalAnim].length)
          return;
        this.Student.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
        this.Student.ChangingShoes = false;
        this.Student.Routine = true;
        this.enabled = false;
        int num = (Object) this.Student.Follower != (Object) null ? 1 : 0;
        if (!this.Student.Indoors)
        {
          if (this.Student.Persona == PersonaType.PhoneAddict || this.Student.Sleuthing)
          {
            this.Student.SmartPhone.SetActive(true);
            if (!this.Student.Sleuthing)
              this.Student.WalkAnim = this.Student.PhoneAnims[1];
          }
          this.Student.Indoors = true;
          this.Student.CanTalk = true;
        }
        else
        {
          if ((Object) this.Student.Destinations[this.Student.Phase + 1] != (Object) null)
          {
            this.Student.CurrentDestination = this.Student.Destinations[this.Student.Phase + 1];
            this.Student.Pathfinding.target = this.Student.Destinations[this.Student.Phase + 1];
          }
          else
          {
            this.Student.CurrentDestination = this.Student.StudentManager.Hangouts.List[0];
            this.Student.Pathfinding.target = this.Student.StudentManager.Hangouts.List[0];
          }
          this.Student.CanTalk = false;
          this.Student.Leaving = true;
          ++this.Student.Phase;
          this.enabled = false;
          ++this.Phase;
        }
      }
    }
    else
    {
      this.PutOnShoes();
      this.Student.Routine = false;
    }
  }

  private void LateUpdate()
  {
    if (this.Phase >= 7)
      return;
    this.RightFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
    this.LeftFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
  }

  public void PutOnShoes()
  {
    this.CloseLocker();
    if ((Object) this.ShoeParent == (Object) null)
      this.Start();
    this.ShoeParent.parent = this.LeftHand;
    this.ShoeParent.parent = this.Locker;
    this.ShoeParent.localPosition = new Vector3(0.272f, 0.0f, 0.552f);
    this.ShoeParent.localEulerAngles = new Vector3(0.0f, 186.878f, 0.0f);
    this.RightCurrentShoe.parent = (Transform) null;
    this.RightCurrentShoe.position = new Vector3(this.RightCurrentShoe.position.x, 0.05f, this.RightCurrentShoe.position.z);
    this.RightCurrentShoe.localEulerAngles = new Vector3(0.0f, this.RightCurrentShoe.localEulerAngles.y, 0.0f);
    this.LeftCurrentShoe.parent = (Transform) null;
    this.LeftCurrentShoe.position = new Vector3(this.LeftCurrentShoe.position.x, 0.05f, this.LeftCurrentShoe.position.z);
    this.LeftCurrentShoe.localEulerAngles = new Vector3(0.0f, this.LeftCurrentShoe.localEulerAngles.y, 0.0f);
    this.LeftNewShoe.parent = this.LeftFoot;
    this.LeftNewShoe.localPosition = this.LeftShoePosition;
    this.LeftNewShoe.localEulerAngles = Vector3.zero;
    if (!this.Student.AoT)
    {
      if (!this.Male)
      {
        this.MyRenderer.materials[0].mainTexture = this.TargetShoes;
        this.MyRenderer.materials[1].mainTexture = this.TargetShoes;
      }
      else
        this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.TargetShoes;
    }
    this.RightNewShoe.parent = this.RightFoot;
    this.RightNewShoe.localPosition = this.RightShoePosition;
    this.RightNewShoe.localEulerAngles = Vector3.zero;
    this.RightNewShoe.gameObject.SetActive(false);
    this.LeftNewShoe.gameObject.SetActive(false);
    this.ShoeParent.transform.position = (this.RightCurrentShoe.position - this.LeftCurrentShoe.position) * 0.5f;
    this.RightCurrentShoe.parent = this.ShoeParent;
    this.LeftCurrentShoe.parent = this.ShoeParent;
    this.ShoeParent.parent = this.RightHand;
    this.ShoeParent.parent = this.Locker;
    this.ShoeParent.localPosition = new Vector3(0.0f, (float) (((Object) this.TargetShoes == (Object) this.IndoorShoes ? -0.14000000059604645 : -0.28999999165534973) + 0.30000001192092896 * (double) this.Height), -0.01f);
    this.ShoeParent.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
    this.RightCurrentShoe.localPosition = new Vector3(0.041f, 0.04271515f, 0.0f);
    this.LeftCurrentShoe.localPosition = new Vector3(-0.041f, 0.04271515f, 0.0f);
    this.RightCurrentShoe.localEulerAngles = Vector3.zero;
    this.LeftCurrentShoe.localEulerAngles = Vector3.zero;
    this.Student.Indoors = true;
    this.Student.CanTalk = true;
    this.enabled = false;
    this.Student.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
    this.Student.StopPairing();
    if (this.Student.StudentID != this.Student.StudentManager.RivalID || this.Student.StudentManager.MissionMode || GameGlobals.AlphabetMode || GameGlobals.Eighties || DateGlobals.Week != 1)
      return;
    this.Student.StudentManager.UpdateExteriorStudents();
  }

  public void CloseLocker()
  {
  }

  public void UpdateShoes()
  {
    this.Student.Indoors = true;
    if (this.Student.AoT)
      return;
    if (!this.Male)
    {
      this.MyRenderer.materials[0].mainTexture = this.IndoorShoes;
      this.MyRenderer.materials[1].mainTexture = this.IndoorShoes;
    }
    else
      this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.IndoorShoes;
  }

  public void LeavingSchool()
  {
    if ((Object) this.Locker == (Object) null)
      this.Start();
    this.Student.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    this.OutdoorShoes = this.Student.Cosmetic.CasualTexture;
    this.IndoorShoes = this.Student.Cosmetic.UniformTexture;
    this.Socks = this.Student.Cosmetic.SocksTexture;
    this.RemovalAnim = this.RemoveSchoolAnim;
    if (!this.Student.AoT)
    {
      if (!this.Male)
      {
        this.MyRenderer.materials[0].mainTexture = this.Socks;
        this.MyRenderer.materials[1].mainTexture = this.Socks;
      }
      else
        this.MyRenderer.materials[this.Student.Cosmetic.UniformID].mainTexture = this.Socks;
    }
    this.Student.CharacterAnimation.CrossFade(this.RemovalAnim);
    this.RightNewShoe.gameObject.SetActive(true);
    this.LeftNewShoe.gameObject.SetActive(true);
    this.RightCurrentShoe = this.RightSchoolShoe;
    this.LeftCurrentShoe = this.LeftSchoolShoe;
    this.RightNewShoe = this.RightCasualShoe;
    this.LeftNewShoe = this.LeftCasualShoe;
    this.TargetShoes = this.OutdoorShoes;
    this.Phase = 1;
    this.RightFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
    this.LeftFoot.localScale = new Vector3(0.9f, 1f, 0.9f);
    this.RightCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
    this.LeftCurrentShoe.localScale = new Vector3(1.111113f, 1f, 1.111113f);
  }

  private void GetHeight(int StudentID)
  {
    this.Height = 5;
    this.RemoveCasualAnim += "5_00";
    this.RemoveSchoolAnim += "5_01";
  }
}
