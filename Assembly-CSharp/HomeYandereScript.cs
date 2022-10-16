// Decompiled with JetBrains decompiler
// Type: HomeYandereScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeYandereScript : MonoBehaviour
{
  public CharacterController MyController;
  public StudentManagerScript StudentManager;
  public PauseScreenScript PauseScreen;
  public HomeVideoGamesScript HomeVideoGames;
  public HomeCameraScript HomeCamera;
  public UISprite HomeDarkness;
  public Animation CharacterAnimation;
  public GameObject CutsceneYandere;
  public GameObject Controller;
  public GameObject Character;
  public GameObject RyobaHair;
  public GameObject Disc;
  public Renderer LongHairRenderer;
  public Renderer PonytailRenderer;
  public AudioClip MiyukiReaction;
  public AudioClip DiscScratch;
  public AudioSource MyAudio;
  public Texture EightiesSocks;
  public Texture BlondePony;
  public Texture BlondeLong;
  public float WalkSpeed;
  public float RunSpeed;
  public bool CannotAlphabet;
  public bool UpdateFace;
  public bool CanMove;
  public bool Running;
  public bool HidePony;
  public string IdleAnim = "";
  public string WalkAnim = "";
  public string RunAnim = "";
  public int Hairstyle;
  public int VictimID;
  public float Timer;
  public float BreastSize = 1f;
  public Transform BreastR;
  public Transform BreastL;
  private int Kidnap;
  public int AlphabetID;
  public string[] Letter;
  public SkinnedMeshRenderer MyRenderer;
  public Texture[] UniformTextures;
  public Texture FaceTexture;
  public Mesh[] Uniforms;
  public RiggedAccessoryAttacher Pajamas;
  public Texture PajamaTexture;
  public Mesh PajamaMesh;
  public Texture NudeTexture;
  public Mesh NudeMesh;
  public GameObject[] OriginalHairs;
  public GameObject[] VtuberHairs;
  public Texture[] VtuberFaces;
  public Renderer[] Eyes;
  public bool Vtuber;

  public void Start()
  {
    this.VtuberCheck();
    if ((UnityEngine.Object) this.CutsceneYandere != (UnityEngine.Object) null)
      this.CutsceneYandere.GetComponent<Animation>()["f02_midoriTexting_00"].speed = 0.1f;
    if (SceneManager.GetActiveScene().name == "HomeScene")
    {
      if (!YanvaniaGlobals.DraculaDefeated && !HomeGlobals.MiyukiDefeated)
      {
        this.transform.position = Vector3.zero;
        this.transform.eulerAngles = Vector3.zero;
        if (!GameGlobals.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday)
          this.Nude();
        else if (!HomeGlobals.Night)
        {
          if (DateGlobals.Weekday == DayOfWeek.Sunday)
          {
            this.WearPajamas();
          }
          else
          {
            this.ChangeSchoolwear();
            this.StartCoroutine(this.ApplyCustomCostume());
          }
        }
        else
          this.WearPajamas();
      }
      else if (HomeGlobals.StartInBasement)
      {
        HomeGlobals.StartInBasement = false;
        this.transform.position = new Vector3(0.0f, -135f, 0.0f);
        this.transform.eulerAngles = Vector3.zero;
      }
      else if (HomeGlobals.MiyukiDefeated)
      {
        this.transform.position = new Vector3(1f, 0.0f, 0.0f);
        this.transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
        this.CharacterAnimation.Play("f02_discScratch_00");
        this.Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
        this.Controller.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -180f);
        this.HomeCamera.Destination = this.HomeCamera.Destinations[5];
        this.HomeCamera.Target = this.HomeCamera.Targets[5];
        this.Disc.SetActive(true);
        this.WearPajamas();
        this.MyAudio.clip = this.MiyukiReaction;
      }
      else
      {
        this.transform.position = new Vector3(1f, 0.0f, 0.0f);
        this.transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
        this.CharacterAnimation.Play("f02_discScratch_00");
        this.Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
        this.Controller.transform.localEulerAngles = new Vector3(0.0f, 0.0f, -180f);
        this.HomeCamera.Destination = this.HomeCamera.Destinations[5];
        this.HomeCamera.Target = this.HomeCamera.Targets[5];
        this.Disc.SetActive(true);
        this.WearPajamas();
      }
      if (GameGlobals.BlondeHair)
      {
        this.PonytailRenderer.material.mainTexture = this.BlondePony;
        this.LongHairRenderer.material.mainTexture = this.BlondeLong;
      }
    }
    Time.timeScale = 1f;
    this.IdleAnim = "f02_idleShort_00";
    this.WalkAnim = "f02_newWalk_00";
    this.RunAnim = "f02_newSprint_00";
    if (GameGlobals.Eighties)
    {
      this.StudentManager.Eighties = true;
      this.RyobaHair.SetActive(true);
      this.Hairstyle = 0;
      this.UpdateHair();
      this.IdleAnim = "f02_ryobaIdle_00";
      this.WalkAnim = "f02_ryobaWalk_00";
      this.RunAnim = "f02_ryobaRun_00";
      if (DateGlobals.Weekday != DayOfWeek.Sunday)
      {
        if (!this.Pajamas.gameObject.activeInHierarchy && !this.Vtuber)
        {
          this.MyRenderer.SetBlendShapeWeight(0, 50f);
          this.MyRenderer.SetBlendShapeWeight(5, 25f);
          this.MyRenderer.SetBlendShapeWeight(9, 0.0f);
          this.MyRenderer.SetBlendShapeWeight(12, 100f);
          if (!this.Pajamas.gameObject.activeInHierarchy)
            this.ChangeSchoolwear();
        }
        this.MyRenderer.materials[0].mainTexture = this.EightiesSocks;
      }
      this.BreastSize = 1.5f;
      this.BreastR.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
      this.BreastL.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
      if (HomeGlobals.Night)
        this.UpdateFace = true;
    }
    else
    {
      this.PonytailRenderer.transform.parent.gameObject.SetActive(true);
      this.RyobaHair.SetActive(false);
      if (HomeGlobals.Night)
      {
        this.Hairstyle = 2;
        this.UpdateHair();
      }
      else
      {
        this.Hairstyle = 1;
        this.UpdateHair();
      }
    }
    if (DateGlobals.Week != 1 || DateGlobals.Weekday != DayOfWeek.Monday)
      this.CannotAlphabet = true;
    PlayerGlobals.BringingItem = 0;
  }

  private void Update()
  {
    if (this.UpdateFace && (UnityEngine.Object) this.Pajamas.newRenderer != (UnityEngine.Object) null)
    {
      if (!this.Vtuber)
      {
        this.Pajamas.newRenderer.SetBlendShapeWeight(0, 50f);
        this.Pajamas.newRenderer.SetBlendShapeWeight(5, 25f);
        this.Pajamas.newRenderer.SetBlendShapeWeight(9, 0.0f);
        this.Pajamas.newRenderer.SetBlendShapeWeight(12, 100f);
      }
      else
      {
        for (int index = 0; index < 13; ++index)
          this.Pajamas.newRenderer.SetBlendShapeWeight(index, 0.0f);
        this.Pajamas.newRenderer.SetBlendShapeWeight(0, 100f);
        this.Pajamas.newRenderer.SetBlendShapeWeight(9, 100f);
        this.Pajamas.newRenderer.materials[1].mainTexture = this.FaceTexture;
        Debug.Log((object) "Updating pajama mesh with Vtuber face.");
      }
      this.UpdateFace = false;
    }
    if (!this.Disc.activeInHierarchy)
    {
      if (this.CanMove)
      {
        if (!OptionGlobals.ToggleRun)
        {
          this.Running = false;
          if (Input.GetButton("LB"))
            this.Running = true;
        }
        else if (Input.GetButtonDown("LB"))
          this.Running = !this.Running;
        int num1 = (int) this.MyController.Move(Physics.gravity * 0.01f);
        float axis1 = Input.GetAxis("Vertical");
        float axis2 = Input.GetAxis("Horizontal");
        Vector3 vector3_1 = Camera.main.transform.TransformDirection(Vector3.forward) with
        {
          y = 0.0f
        };
        vector3_1 = vector3_1.normalized;
        Vector3 vector3_2 = new Vector3(vector3_1.z, 0.0f, -vector3_1.x);
        Vector3 forward = axis2 * vector3_2 + axis1 * vector3_1;
        if (forward != Vector3.zero)
          this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(forward), Time.deltaTime * 10f);
        if ((double) axis1 != 0.0 || (double) axis2 != 0.0)
        {
          if (this.Running)
          {
            this.CharacterAnimation.CrossFade(this.RunAnim);
            int num2 = (int) this.MyController.Move(this.transform.forward * this.RunSpeed * Time.deltaTime);
          }
          else
          {
            this.CharacterAnimation.CrossFade(this.WalkAnim);
            int num3 = (int) this.MyController.Move(this.transform.forward * this.WalkSpeed * Time.deltaTime);
          }
        }
        else
          this.CharacterAnimation.CrossFade(this.IdleAnim);
      }
      else
        this.CharacterAnimation.CrossFade(this.IdleAnim);
    }
    else if ((double) this.HomeDarkness.color.a == 0.0)
    {
      if ((double) this.Timer == 0.0)
        this.MyAudio.Play();
      else if ((double) this.Timer > (double) this.MyAudio.clip.length + 1.0)
      {
        YanvaniaGlobals.DraculaDefeated = false;
        HomeGlobals.MiyukiDefeated = false;
        this.Disc.SetActive(false);
        this.HomeVideoGames.Quit();
      }
      this.Timer += Time.deltaTime;
    }
    Rigidbody component = this.GetComponent<Rigidbody>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      component.velocity = Vector3.zero;
    if ((double) this.transform.position.y >= -10.0)
      return;
    this.transform.position = new Vector3(this.transform.position.x, -10f, this.transform.position.z);
  }

  private void LateUpdate()
  {
    if (!this.CannotAlphabet && Input.GetKeyDown(this.Letter[this.AlphabetID]))
    {
      ++this.AlphabetID;
      if (this.AlphabetID == this.Letter.Length)
      {
        GameGlobals.AlphabetMode = true;
        StudentGlobals.MemorialStudents = 0;
        for (int studentID = 1; studentID < 101; ++studentID)
        {
          StudentGlobals.SetStudentDead(studentID, false);
          StudentGlobals.SetStudentKidnapped(studentID, false);
          StudentGlobals.SetStudentArrested(studentID, false);
          StudentGlobals.SetStudentExpelled(studentID, false);
        }
        SceneManager.LoadScene("LoadingScene");
      }
    }
    if (!this.CanMove || !Input.GetKeyDown(KeyCode.Escape))
      return;
    this.PauseScreen.QuitLabel.text = "Do you wish to return to the main menu?";
    this.PauseScreen.YesLabel.text = "Yes";
    this.PauseScreen.HomeButton.SetActive(false);
    this.PauseScreen.JumpToQuit();
    this.CanMove = false;
  }

  private void UpdateHair()
  {
    if (this.Hairstyle == 0)
    {
      this.LongHairRenderer.gameObject.SetActive(false);
      this.PonytailRenderer.enabled = false;
    }
    else if (this.Hairstyle == 1)
    {
      this.LongHairRenderer.gameObject.SetActive(false);
      this.PonytailRenderer.enabled = true;
    }
    else
    {
      if (this.Hairstyle != 2)
        return;
      this.LongHairRenderer.gameObject.SetActive(true);
      this.PonytailRenderer.enabled = false;
    }
  }

  private void ChangeSchoolwear()
  {
    this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
    this.MyRenderer.materials[0].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
    this.MyRenderer.materials[1].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    this.StartCoroutine(this.ApplyCustomCostume());
  }

  private void WearPajamas()
  {
    this.Pajamas.gameObject.SetActive(true);
    this.MyRenderer.sharedMesh = (Mesh) null;
    this.MyRenderer.materials[0].mainTexture = this.PajamaTexture;
    this.MyRenderer.materials[1].mainTexture = this.PajamaTexture;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    this.StartCoroutine(this.ApplyCustomFace());
    if (!GameGlobals.Eighties)
      return;
    this.UpdateFace = true;
  }

  private void Nude()
  {
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.NudeTexture;
    this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
    this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
  }

  private IEnumerator ApplyCustomCostume()
  {
    HomeYandereScript homeYandereScript = this;
    WWW CustomUniform;
    switch (StudentGlobals.FemaleUniform)
    {
      case 1:
        CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomUniform.png");
        yield return (object) CustomUniform;
        if (CustomUniform.error == null)
        {
          homeYandereScript.MyRenderer.materials[0].mainTexture = (Texture) CustomUniform.texture;
          homeYandereScript.MyRenderer.materials[1].mainTexture = (Texture) CustomUniform.texture;
        }
        CustomUniform = (WWW) null;
        break;
      case 2:
        CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLong.png");
        yield return (object) CustomUniform;
        if (CustomUniform.error == null)
        {
          homeYandereScript.MyRenderer.materials[0].mainTexture = (Texture) CustomUniform.texture;
          homeYandereScript.MyRenderer.materials[1].mainTexture = (Texture) CustomUniform.texture;
        }
        CustomUniform = (WWW) null;
        break;
      case 3:
        CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSweater.png");
        yield return (object) CustomUniform;
        if (CustomUniform.error == null)
        {
          homeYandereScript.MyRenderer.materials[0].mainTexture = (Texture) CustomUniform.texture;
          homeYandereScript.MyRenderer.materials[1].mainTexture = (Texture) CustomUniform.texture;
        }
        CustomUniform = (WWW) null;
        break;
      case 4:
      case 5:
        CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomBlazer.png");
        yield return (object) CustomUniform;
        if (CustomUniform.error == null)
        {
          homeYandereScript.MyRenderer.materials[0].mainTexture = (Texture) CustomUniform.texture;
          homeYandereScript.MyRenderer.materials[1].mainTexture = (Texture) CustomUniform.texture;
        }
        CustomUniform = (WWW) null;
        break;
    }
    homeYandereScript.StartCoroutine(homeYandereScript.ApplyCustomFace());
  }

  private IEnumerator ApplyCustomFace()
  {
    WWW CustomFace = new WWW("file:///" + Application.streamingAssetsPath + "/CustomFace.png");
    yield return (object) CustomFace;
    if (CustomFace.error == null)
    {
      this.MyRenderer.materials[2].mainTexture = (Texture) CustomFace.texture;
      this.FaceTexture = (Texture) CustomFace.texture;
    }
    WWW CustomHair = new WWW("file:///" + Application.streamingAssetsPath + "/CustomHair.png");
    yield return (object) CustomHair;
    if (CustomHair.error == null)
      this.PonytailRenderer.material.mainTexture = (Texture) CustomHair.texture;
  }

  private void VtuberCheck()
  {
    if (GameGlobals.VtuberID > 0)
    {
      for (int index = 1; index < this.OriginalHairs.Length; ++index)
        this.OriginalHairs[index].transform.localPosition = new Vector3(0.0f, 1f, 0.0f);
      this.VtuberHairs[GameGlobals.VtuberID].SetActive(true);
      for (int index = 0; index < 13; ++index)
        this.MyRenderer.SetBlendShapeWeight(index, 0.0f);
      this.MyRenderer.SetBlendShapeWeight(0, 100f);
      this.MyRenderer.SetBlendShapeWeight(9, 100f);
      this.FaceTexture = this.VtuberFaces[GameGlobals.VtuberID];
      Debug.Log((object) "FaceTexture changed to Vtuber's face texture.");
      this.Eyes[1].material.mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
      this.Eyes[2].material.mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
      this.UpdateFace = true;
      this.Vtuber = true;
    }
    else
      this.VtuberHairs[1].SetActive(false);
  }
}
