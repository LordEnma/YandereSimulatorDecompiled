// Decompiled with JetBrains decompiler
// Type: LivingRoomCutsceneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class LivingRoomCutsceneScript : MonoBehaviour
{
  public ColorCorrectionCurves ColorCorrection;
  public CosmeticScript YandereCosmetic;
  public AmbientObscurance Obscurance;
  public RivalDataScript RivalData;
  public Vignetting Vignette;
  public NoiseAndGrain Noise;
  public UISprite SkipCircle;
  public UIPanel SkipPanel;
  public SkinnedMeshRenderer YandereRenderer;
  public Renderer RightEyeRenderer;
  public Renderer LeftEyeRenderer;
  public Transform KettleCameraDestination;
  public Transform KettleCameraOrigin;
  public Transform FriendshipCamera;
  public Transform LivingRoomCamera;
  public Transform CutsceneCamera;
  public Transform AyanoHead;
  public Transform TeaCamera;
  public Transform AyanoEyes;
  public Transform OsanaEyes;
  public UIPanel EliminationPanel;
  public UIPanel Panel;
  public UISprite SubDarknessBG;
  public UISprite SubDarkness;
  public UISprite Darkness;
  public UILabel EightiesLabel;
  public UILabel PrologueLabel;
  public UILabel Subtitle;
  public Vector3 RightEyeOrigin;
  public Vector3 LeftEyeOrigin;
  public AudioClip DramaticBoom;
  public AudioClip RivalProtest;
  public AudioSource Jukebox;
  public AudioSource MyAudio;
  public AudioSource BGM;
  public GameObject WarningLabel;
  public GameObject TeaSteam;
  public GameObject CatStuff;
  public GameObject OfferTea;
  public GameObject Prologue;
  public GameObject Yandere;
  public GameObject TeaSet;
  public GameObject Rival;
  public Transform RightEye;
  public Transform LeftEye;
  public float CutsceneLimit = 167f;
  public float ShakeStrength;
  public float AnimOffset;
  public float ExitTimer;
  public float EyeShrink;
  public float xOffset;
  public float zOffset;
  public float Timer;
  public float Speed;
  public bool WaitingForInput;
  public bool OsanaCutscene;
  public bool DecisionMade;
  public bool FollowCamera;
  public bool BlurVision;
  public bool DruggedTea;
  public bool Eighties;
  public bool NoSkip;
  public bool Fall;
  public float[] CameraIDs;
  public string[] Lines;
  public float[] Times;
  public float BlurSpeed = 1f;
  public int Branch = 1;
  public int Phase = 1;
  public int ID = 1;
  public Texture ZTR;
  public int ZTRID;
  public Renderer PonytailRenderer;
  public Texture BlondePony;
  public GameObject OriginalHair;
  public GameObject[] VtuberHairs;
  public Texture[] VtuberFaces;
  public Texture[] VtuberEyes;
  public Renderer[] Eye;

  private void Start()
  {
    this.VtuberCheck();
    this.SkipPanel.alpha = 0.0f;
    if ((Object) this.BlondePony != (Object) null && GameGlobals.BlondeHair)
      this.PonytailRenderer.material.mainTexture = this.BlondePony;
    this.YandereCosmetic.FemaleUniformID = StudentGlobals.FemaleUniform;
    this.YandereCosmetic.SetFemaleUniform();
    this.YandereCosmetic.RightWristband.SetActive(false);
    this.YandereCosmetic.LeftWristband.SetActive(false);
    this.YandereCosmetic.ThickBrows.SetActive(false);
    for (this.ID = 0; this.ID < this.YandereCosmetic.FemaleHair.Length; ++this.ID)
    {
      GameObject gameObject = this.YandereCosmetic.FemaleHair[this.ID];
      if ((Object) gameObject != (Object) null)
        gameObject.SetActive(false);
    }
    for (this.ID = 0; this.ID < this.YandereCosmetic.TeacherHair.Length; ++this.ID)
    {
      GameObject gameObject = this.YandereCosmetic.TeacherHair[this.ID];
      if ((Object) gameObject != (Object) null)
        gameObject.SetActive(false);
    }
    for (this.ID = 0; this.ID < this.YandereCosmetic.FemaleAccessories.Length; ++this.ID)
    {
      GameObject femaleAccessory = this.YandereCosmetic.FemaleAccessories[this.ID];
      if ((Object) femaleAccessory != (Object) null)
        femaleAccessory.SetActive(false);
    }
    for (this.ID = 0; this.ID < this.YandereCosmetic.TeacherAccessories.Length; ++this.ID)
    {
      GameObject teacherAccessory = this.YandereCosmetic.TeacherAccessories[this.ID];
      if ((Object) teacherAccessory != (Object) null)
        teacherAccessory.SetActive(false);
    }
    for (this.ID = 0; this.ID < this.YandereCosmetic.ClubAccessories.Length; ++this.ID)
    {
      GameObject clubAccessory = this.YandereCosmetic.ClubAccessories[this.ID];
      if ((Object) clubAccessory != (Object) null)
        clubAccessory.SetActive(false);
    }
    foreach (GameObject scanner in this.YandereCosmetic.Scanners)
    {
      if ((Object) scanner != (Object) null)
        scanner.SetActive(false);
    }
    foreach (GameObject flower in this.YandereCosmetic.Flowers)
    {
      if ((Object) flower != (Object) null)
        flower.SetActive(false);
    }
    foreach (GameObject punkAccessory in this.YandereCosmetic.PunkAccessories)
    {
      if ((Object) punkAccessory != (Object) null)
        punkAccessory.SetActive(false);
    }
    foreach (GameObject gameObject in this.YandereCosmetic.RedCloth)
    {
      if ((Object) gameObject != (Object) null)
        gameObject.SetActive(false);
    }
    foreach (GameObject kerchief in this.YandereCosmetic.Kerchiefs)
    {
      if ((Object) kerchief != (Object) null)
        kerchief.SetActive(false);
    }
    for (int index = 0; index < 10; ++index)
      this.YandereCosmetic.Fingernails[index].gameObject.SetActive(false);
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
    this.EliminationPanel.alpha = 0.0f;
    this.Panel.alpha = 1f;
    this.ColorCorrection.saturation = 1f;
    this.Noise.intensityMultiplier = 0.0f;
    this.Obscurance.intensity = 0.0f;
    this.Vignette.enabled = false;
    this.Vignette.intensity = 1f;
    this.Vignette.blur = 1f;
    this.Vignette.chromaticAberration = 1f;
    if (EventGlobals.OsanaConversation)
    {
      this.PrologueLabel.transform.localPosition = new Vector3(0.0f, 125f, 0.0f);
      this.PrologueLabel.text = "Osana is eager to report her stalker to the police.\n\nHowever, she knows that the process could take a long time, so she decides to visit Ayano's house and get her cat back before contacting the police.\n\nThe next morning, Osana arrives at Ayano's house...";
      this.WarningLabel.SetActive(true);
      this.CatStuff.SetActive(true);
      this.OsanaCutscene = true;
      this.Lines = this.RivalData.OsanaIntroLines;
      this.Times = this.RivalData.OsanaIntroTimes;
      this.MyAudio.clip = this.RivalData.OsanaIntro;
      this.BGM.volume = 0.1f;
      if (SchemeGlobals.GetSchemeStage(6) == 9)
        SchemeGlobals.SetSchemeStage(6, 100);
    }
    if (!GameGlobals.Eighties)
      return;
    this.EightiesLabel.gameObject.SetActive(true);
    this.SkipPanel.gameObject.SetActive(false);
    this.PrologueLabel.enabled = false;
    this.WarningLabel.SetActive(false);
    this.Rival.SetActive(false);
    this.Eighties = true;
  }

  private void Update()
  {
    if (this.Phase > 3 && !this.WaitingForInput && (double) this.Timer < 172.0 && !this.NoSkip)
    {
      this.SkipPanel.alpha += Time.deltaTime;
      if (Input.GetButton("X"))
      {
        this.SkipPanel.alpha = 1f;
        this.SkipCircle.fillAmount -= Time.deltaTime;
        if ((double) this.SkipCircle.fillAmount == 0.0)
        {
          this.SkipCircle.fillAmount = 1f;
          if (!this.DecisionMade)
          {
            this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = 43f;
            this.Rival.GetComponent<Animation>()["FriendshipRival"].time = 43f;
            this.Yandere.GetComponent<Animation>()["FriendshipYandere"].speed = 0.0f;
            this.Rival.GetComponent<Animation>()["FriendshipRival"].speed = 0.0f;
            this.FriendshipCamera.gameObject.GetComponent<Animation>().Play();
            this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = 43f;
            this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0.0f;
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
              this.Yandere.GetComponent<Animation>()["FriendshipYandere"].speed = 0.0f;
              this.Rival.GetComponent<Animation>()["FriendshipRival"].speed = 0.0f;
              this.FriendshipCamera.gameObject.GetComponent<Animation>().Play();
              this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = 172f;
              this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0.0f;
              this.CameraIDs = this.RivalData.OsanaBefriendCameraIDs;
              this.Lines = this.RivalData.OsanaBefriendLines;
              this.Times = this.RivalData.OsanaBefriendTimes;
              this.Yandere.gameObject.SetActive(true);
              this.MyAudio.clip = this.RivalData.OsanaBefriend;
              this.MyAudio.Play();
              this.MyAudio.time = 100f;
              this.SkipPanel.alpha = 0.0f;
              this.CutsceneLimit = 172f;
              this.Timer = 172f;
              this.Branch = 2;
              this.Phase = 5;
              this.ID = 37;
            }
            else
            {
              this.Rival.GetComponent<Animation>()["FriendshipRival"].speed = 1f;
              this.transform.parent = this.OsanaEyes;
              this.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
              this.transform.LookAt(this.AyanoEyes);
              this.Vignette.enabled = true;
              this.BlurVision = true;
              this.Yandere.gameObject.SetActive(true);
              this.Yandere.GetComponent<Animation>().Play("f02_evilWitness_00");
              this.Yandere.GetComponent<Animation>()["f02_evilWitness_00"].time = 2f;
              this.Yandere.GetComponent<Animation>()["f02_evilWitness_00"].speed = 0.25f;
              this.transform.parent = this.AyanoEyes;
              this.transform.localPosition = new Vector3(0.0f, 0.0f, 0.5f);
              this.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
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
            this.SkipPanel.alpha = 0.0f;
            this.NoSkip = true;
          }
        }
      }
      else
        this.SkipCircle.fillAmount = 1f;
    }
    if (this.Phase == 1)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.0)
      {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
        if ((double) this.Darkness.color.a == 0.0 && Input.GetButtonDown("A"))
        {
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
    }
    else if (this.Phase == 2)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if ((double) this.Darkness.color.a == 1.0)
      {
        this.Vignette.enabled = true;
        this.Prologue.SetActive(false);
        if (!this.Eighties)
        {
          this.transform.parent = this.LivingRoomCamera;
          this.transform.localPosition = new Vector3(-0.65f, 0.0f, 0.0f);
          this.transform.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
          ++this.Phase;
          if (!this.OsanaCutscene)
            this.BGM.Play();
        }
        else
        {
          this.transform.position = this.TeaCamera.position;
          this.transform.rotation = this.TeaCamera.rotation;
          this.TeaSet.SetActive(true);
          this.Phase = 100;
        }
      }
    }
    else if (this.Phase == 3)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.0)
      {
        this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0.0f, Time.deltaTime);
        if ((double) this.Panel.alpha == 0.0)
        {
          this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = 0.0f;
          this.Rival.GetComponent<Animation>()["FriendshipRival"].time = 0.0f;
          if (this.OsanaCutscene)
          {
            this.Yandere.GetComponent<Animation>()["FriendshipYandere"].speed = 0.0f;
            this.Rival.GetComponent<Animation>()["FriendshipRival"].speed = 0.0f;
          }
          this.LivingRoomCamera.gameObject.GetComponent<Animation>().Play();
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
    }
    else if (this.Phase == 4)
    {
      this.SkipPanel.alpha += Time.deltaTime;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.0 && this.OsanaCutscene && !this.BGM.isPlaying)
        this.BGM.Play();
      if ((double) this.Timer > 10.0)
      {
        this.transform.parent = this.FriendshipCamera;
        this.transform.localPosition = new Vector3(-0.65f, 0.0f, 0.0f);
        this.transform.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
        this.FriendshipCamera.gameObject.GetComponent<Animation>().Play();
        this.MyAudio.Play();
        this.Subtitle.text = this.Lines[0];
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 5)
    {
      if (Input.GetKeyDown(KeyCode.Z))
      {
        this.Timer += 2f;
        this.MyAudio.time += 2f;
        if ((double) this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed > 0.0)
          this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time += 2f;
      }
      this.Timer += Time.deltaTime;
      if ((double) this.Timer < 166.0 && !this.OsanaCutscene)
      {
        this.Yandere.GetComponent<Animation>()["FriendshipYandere"].time = this.MyAudio.time + this.AnimOffset;
        this.Rival.GetComponent<Animation>()["FriendshipRival"].time = this.MyAudio.time + this.AnimOffset;
      }
      if (this.ID < this.Times.Length)
      {
        if ((double) this.MyAudio.time > (double) this.Times[this.ID] || !this.MyAudio.isPlaying)
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
                this.Rival.GetComponent<Animation>()["FriendshipRival"].time = this.MyAudio.time + 67f;
            }
            if (this.ID > 1 && this.Branch > 1)
            {
              if ((double) this.CameraIDs[this.ID] == 0.0)
                this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 1f;
              else if ((double) this.CameraIDs[this.ID] == 1000.0)
              {
                this.Rival.GetComponent<Animation>()["FriendshipRival"].speed = 1f;
                this.transform.parent = this.OsanaEyes;
                this.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                this.transform.LookAt(this.AyanoEyes);
                this.Vignette.enabled = true;
                this.FollowCamera = true;
                this.BlurVision = true;
              }
              else if ((double) this.CameraIDs[this.ID] == 1001.0)
              {
                if (this.FollowCamera)
                {
                  this.Yandere.GetComponent<Animation>().Play("f02_evilWitness_00");
                  this.Yandere.GetComponent<Animation>()["f02_evilWitness_00"].time = 2f;
                  this.Yandere.GetComponent<Animation>()["f02_evilWitness_00"].speed = 0.25f;
                }
                this.transform.parent = this.AyanoEyes;
                this.transform.localPosition = new Vector3(0.0f, 0.0f, 0.5f);
                this.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
                this.FollowCamera = false;
              }
              else if ((double) this.CameraIDs[this.ID] == 1002.0)
              {
                this.Darkness.alpha = 0.0f;
                this.Panel.alpha = 1f;
                this.BlurSpeed = 10f;
                this.Fall = true;
              }
              else
              {
                this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = this.CameraIDs[this.ID];
                this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0.0f;
              }
            }
          }
          this.Subtitle.text = this.Lines[this.ID];
          ++this.ID;
          if (this.ID == 3)
            this.OfferTea.SetActive(false);
        }
      }
      else if (this.OsanaCutscene && this.Branch == 1)
      {
        this.Subtitle.text = "Here's your tea.";
        this.OfferTea.SetActive(true);
        this.Yandere.SetActive(true);
        if (!this.DruggedTea)
        {
          Debug.Log((object) "Transitioning into Befriend branch NOW.");
          this.CameraIDs = this.RivalData.OsanaBefriendCameraIDs;
          this.Lines = this.RivalData.OsanaBefriendLines;
          this.Times = this.RivalData.OsanaBefriendTimes;
          this.MyAudio.clip = this.RivalData.OsanaBefriend;
          this.MyAudio.time = 0.0f;
          this.MyAudio.Play();
          this.CutsceneLimit = 172f;
          this.Branch = 2;
        }
        else
        {
          Debug.Log((object) "Transitioning into Betray branch NOW.");
          this.CameraIDs = this.RivalData.OsanaBetrayCameraIDs;
          this.Lines = this.RivalData.OsanaBetrayLines;
          this.Times = this.RivalData.OsanaBetrayTimes;
          this.MyAudio.clip = this.RivalData.OsanaBetray;
          this.MyAudio.time = 0.0f;
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
              this.transform.parent = (Transform) null;
              this.transform.position = this.KettleCameraOrigin.position;
              this.transform.rotation = this.KettleCameraOrigin.rotation;
              this.TeaSteam.SetActive(true);
            }
            else
            {
              this.Speed += Time.deltaTime * 0.2f;
              this.transform.position = Vector3.Lerp(this.transform.position, this.KettleCameraDestination.position, Time.deltaTime * this.Speed);
            }
          }
          else if (this.ID > 12 && this.ID < 16)
          {
            this.transform.position = new Vector3(-6f, 1f, 3f);
            this.transform.localEulerAngles = new Vector3(0.0f, 90f, 0.0f);
          }
          else if (this.ID > 17 && this.ID < 24 && !this.DecisionMade)
          {
            this.SkipPanel.alpha = Mathf.MoveTowards(this.SkipPanel.alpha, 0.0f, Time.deltaTime);
            if (!this.TeaSet.activeInHierarchy)
            {
              this.WaitingForInput = true;
              this.transform.parent = (Transform) null;
              this.transform.position = this.TeaCamera.position;
              this.transform.rotation = this.TeaCamera.rotation;
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
            this.transform.parent = this.FriendshipCamera;
            this.transform.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
            if (this.ID == 16 && (double) this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time < 44.0)
            {
              this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].time = 44f;
              this.FriendshipCamera.gameObject.GetComponent<Animation>()["FriendshipCameraFlat"].speed = 0.0f;
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
        if ((double) this.MyAudio.time > 54.0)
          this.DecreaseYandereEffects();
        else if ((double) this.MyAudio.time > 42.0)
          this.IncreaseYandereEffects();
      }
      else if (this.Branch == 1)
      {
        if (this.DecisionMade || (double) this.MyAudio.time > 60.0)
          this.DecreaseYandereEffects();
        else if ((double) this.MyAudio.time > 43.0)
          this.IncreaseYandereEffects();
      }
      if ((double) this.Timer > (double) this.CutsceneLimit)
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
        ++this.Phase;
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
          StudentGlobals.SetStudentHealth(30, 100);
          StudentGlobals.SetStudentSanity(30, 100);
          SchoolGlobals.KidnapVictim = 30;
          if (DateGlobals.PassDays < 1)
            DateGlobals.PassDays = 1;
          SceneManager.LoadScene("CalendarScene");
        }
        else
        {
          this.BetrayRival();
          Debug.Log((object) ("EventGlobals.OsanaConversation is currently: " + EventGlobals.OsanaConversation.ToString()));
        }
        HomeGlobals.StartInBasement = true;
      }
    }
    else if (this.Phase == 10)
    {
      this.BGM.volume = 0.0f;
      this.SubDarkness.color = new Color(this.SubDarkness.color.r, this.SubDarkness.color.g, this.SubDarkness.color.b, Mathf.MoveTowards(this.SubDarkness.color.a, 1f, Time.deltaTime * 0.2f));
      if ((double) this.SubDarkness.color.a == 1.0)
      {
        if (DateGlobals.PassDays < 1)
          DateGlobals.PassDays = 1;
        this.BefriendRival();
        EventGlobals.OsanaConversation = false;
        Debug.Log((object) ("EventGlobals.OsanaConversation has been set to: " + EventGlobals.OsanaConversation.ToString()));
      }
    }
    else if (this.Phase == 100)
    {
      if (!this.DecisionMade)
      {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
        if ((double) this.Darkness.color.a == 0.0)
        {
          if (Input.GetButtonDown("A"))
          {
            this.EightiesLabel.text = DateGlobals.Week >= 10 ? "After the massive favor that Ryoba did for Sonoko, she can no longer consider Ryoba to be a murder suspect.\n\nOver a cup of tea, Ryoba describes the deep feelings she has for her Senpai, and explains how heartbroken she would feel if anyone took the boy away from her. She asks Sonoko to stay away from her Senpai.\n\nSonoko states that she must continue to investigate Senpai as a potential murder suspect, but will not attempt to date him.\n\nSonoko is no longer a threat, and the two girls are now the best of friends!" : "Over a cup of tea, Ryoba describes the deep feelings she has for her Senpai, and explains how heartbroken she would feel if anyone took the boy away from her. She asks the girl to stay away from her Senpai.\n\nRyoba's rival cannot bring herself to compete romantically with someone who entered a life-threatening situation to help her out. She agrees to stay away from Ryoba's Senpai.\n\nRyoba's rival is no longer a threat, and the two girls are now the best of friends!";
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
        if ((double) this.Darkness.color.a == 1.0)
        {
          this.Prologue.SetActive(true);
          this.DecisionMade = false;
          ++this.Phase;
        }
      }
    }
    else if (this.Phase == 101)
    {
      if (!this.DecisionMade)
      {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
        if (Input.GetButtonDown("A"))
          this.DecisionMade = true;
      }
      else
      {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
        if ((double) this.Darkness.color.a == 1.0)
        {
          if (this.DruggedTea)
            this.BetrayRival();
          else
            this.BefriendRival();
        }
      }
    }
    if (Input.GetKeyDown(KeyCode.Minus))
      --Time.timeScale;
    if (Input.GetKeyDown(KeyCode.Equals))
      ++Time.timeScale;
    this.MyAudio.pitch = Time.timeScale;
    if (!this.BlurVision)
      return;
    this.BGM.pitch -= Time.deltaTime * 0.05f;
    this.Vignette.intensity += Time.deltaTime * this.BlurSpeed;
    this.Vignette.blur += Time.deltaTime * this.BlurSpeed;
    this.Vignette.chromaticAberration += Time.deltaTime * this.BlurSpeed;
    if (!this.Fall)
      return;
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
    this.transform.localPosition -= new Vector3(0.0f, Time.deltaTime * 0.5f, 0.0f);
    this.transform.localEulerAngles += new Vector3(Time.deltaTime * 180f, Time.deltaTime * 180f, Time.deltaTime * 180f);
    this.BGM.volume -= Time.deltaTime;
    if ((double) this.Darkness.color.a != 1.0)
      return;
    this.ExitTimer += Time.deltaTime;
    if ((double) this.ExitTimer <= 3.0)
      return;
    this.Phase = 7;
  }

  private void LateUpdate()
  {
    if (this.Phase > 2)
    {
      if ((Object) this.transform.parent != (Object) null)
      {
        if (this.OsanaCutscene)
        {
          if ((double) this.FriendshipCamera.position.z > 2.4000000953674316)
            this.transform.localPosition = new Vector3((float) ((double) this.ShakeStrength * (double) Random.Range(-1f, 1f) - 1.3999999761581421), this.ShakeStrength * Random.Range(-1f, 1f), this.ShakeStrength * Random.Range(-1f, 1f));
          else if (this.Branch != 3)
            this.transform.localPosition = new Vector3((float) ((double) this.ShakeStrength * (double) Random.Range(-1f, 1f) - 0.64999997615814209), this.ShakeStrength * Random.Range(-1f, 1f), this.ShakeStrength * Random.Range(-1f, 1f));
        }
        else
          this.transform.localPosition = new Vector3((float) ((double) this.ShakeStrength * (double) Random.Range(-1f, 1f) - 0.64999997615814209), this.ShakeStrength * Random.Range(-1f, 1f), this.ShakeStrength * Random.Range(-1f, 1f));
      }
      this.CutsceneCamera.position = new Vector3(this.CutsceneCamera.position.x + this.xOffset, this.CutsceneCamera.position.y, this.CutsceneCamera.position.z + this.zOffset);
      this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
      this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
      this.LeftEye.localScale = new Vector3((float) (1.0 - (double) this.EyeShrink * 0.5), (float) (1.0 - (double) this.EyeShrink * 0.5), this.LeftEye.localScale.z);
      this.RightEye.localScale = new Vector3((float) (1.0 - (double) this.EyeShrink * 0.5), (float) (1.0 - (double) this.EyeShrink * 0.5), this.RightEye.localScale.z);
    }
    if (!this.FollowCamera)
      return;
    this.AyanoHead.transform.LookAt(this.transform.position);
  }

  private void IncreaseYandereEffects()
  {
    if (!this.Jukebox.isPlaying)
      this.Jukebox.Play();
    this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.1f, Time.deltaTime * 0.1f);
    this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, 5f, (float) ((double) Time.deltaTime * 4.0 / 10.0));
    this.Vignette.blur = this.Vignette.intensity;
    this.Vignette.chromaticAberration = this.Vignette.intensity;
    this.ColorCorrection.saturation = Mathf.MoveTowards(this.ColorCorrection.saturation, 0.0f, Time.deltaTime / 10f);
    this.Noise.intensityMultiplier = Mathf.MoveTowards(this.Noise.intensityMultiplier, 3f, (float) ((double) Time.deltaTime * 3.0 / 10.0));
    this.Obscurance.intensity = Mathf.MoveTowards(this.Obscurance.intensity, 3f, (float) ((double) Time.deltaTime * 3.0 / 10.0));
    if (!this.OsanaCutscene)
      this.ShakeStrength = Mathf.MoveTowards(this.ShakeStrength, 0.01f, (float) ((double) Time.deltaTime * 0.0099999997764825821 / 10.0));
    this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, 0.9f, Time.deltaTime);
    if ((double) this.MyAudio.time <= 45.0)
      return;
    if ((double) this.MyAudio.time > 54.0)
    {
      this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 0.0f, Time.deltaTime);
    }
    else
    {
      if (this.OsanaCutscene)
        return;
      this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 1f, Time.deltaTime);
      if (!Input.GetButtonDown("X"))
        return;
      this.MyAudio.clip = this.RivalProtest;
      this.MyAudio.volume = 1f;
      this.MyAudio.Play();
      this.Jukebox.gameObject.SetActive(false);
      this.BGM.gameObject.SetActive(false);
      this.Subtitle.text = "Wait, what are you doing?! That's not funny! Stop! Let me go! ...n...NO!!!";
      this.SubDarknessBG.color = new Color(this.SubDarknessBG.color.r, this.SubDarknessBG.color.g, this.SubDarknessBG.color.b, 1f);
      ++this.Phase;
    }
  }

  private void DecreaseYandereEffects()
  {
    this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.0f, Time.deltaTime / 5f);
    this.MyAudio.volume = Mathf.MoveTowards(this.MyAudio.volume, 1f, (float) ((double) Time.deltaTime * 0.10000000149011612 / 5.0));
    this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, 1f, (float) ((double) Time.deltaTime * 4.0 / 5.0));
    this.Vignette.blur = this.Vignette.intensity;
    this.Vignette.chromaticAberration = this.Vignette.intensity;
    this.ColorCorrection.saturation = Mathf.MoveTowards(this.ColorCorrection.saturation, 1f, Time.deltaTime / 5f);
    this.Noise.intensityMultiplier = Mathf.MoveTowards(this.Noise.intensityMultiplier, 0.0f, (float) ((double) Time.deltaTime * 3.0 / 5.0));
    this.Obscurance.intensity = Mathf.MoveTowards(this.Obscurance.intensity, 0.0f, (float) ((double) Time.deltaTime * 3.0 / 5.0));
    this.ShakeStrength = Mathf.MoveTowards(this.ShakeStrength, 0.0f, (float) ((double) Time.deltaTime * 0.0099999997764825821 / 5.0));
    this.EliminationPanel.alpha = Mathf.MoveTowards(this.EliminationPanel.alpha, 0.0f, Time.deltaTime);
    this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, 0.0f, Time.deltaTime);
  }

  private void BetrayRival()
  {
    StudentGlobals.SetStudentKidnapped(10 + DateGlobals.Week, true);
    StudentGlobals.SetStudentHealth(10 + DateGlobals.Week, 100);
    StudentGlobals.SetStudentSanity(10 + DateGlobals.Week, 100);
    int num = 10 + DateGlobals.Week;
    Debug.Log((object) ("The player had " + StudentGlobals.Prisoners.ToString() + " prisoners in their basement before betraying their rival."));
    ++StudentGlobals.Prisoners;
    switch (StudentGlobals.Prisoners)
    {
      case 1:
        StudentGlobals.Prisoner1 = num;
        break;
      case 2:
        StudentGlobals.Prisoner2 = num;
        break;
      case 3:
        StudentGlobals.Prisoner3 = num;
        break;
      case 4:
        StudentGlobals.Prisoner4 = num;
        break;
      case 5:
        StudentGlobals.Prisoner5 = num;
        break;
      case 6:
        StudentGlobals.Prisoner6 = num;
        break;
      case 7:
        StudentGlobals.Prisoner7 = num;
        break;
      case 8:
        StudentGlobals.Prisoner8 = num;
        break;
      case 9:
        StudentGlobals.Prisoner9 = num;
        break;
      case 10:
        StudentGlobals.Prisoner10 = num;
        break;
    }
    Debug.Log((object) ("Now that we have betrayed the rival, there should be " + StudentGlobals.Prisoners.ToString() + " prisoners in the basement, and the rival should be Prisoner #" + StudentGlobals.Prisoners.ToString()));
    EventGlobals.OsanaConversation = true;
    SceneManager.LoadScene("GenocideScene");
    GameGlobals.RivalEliminationID = 11;
    GameGlobals.NonlethalElimination = true;
    GameGlobals.SpecificEliminationID = 3;
    if (!GameGlobals.Debug)
      PlayerPrefs.SetInt("Betray", 1);
    if (GameGlobals.Debug)
      return;
    PlayerPrefs.SetInt("a", 1);
  }

  private void BefriendRival()
  {
    SceneManager.LoadScene("CalendarScene");
    GameGlobals.RivalEliminationID = 4;
    GameGlobals.NonlethalElimination = true;
    GameGlobals.SpecificEliminationID = 2;
    if (!GameGlobals.Debug)
      PlayerPrefs.SetInt("Befriend", 1);
    if (GameGlobals.Debug)
      return;
    PlayerPrefs.SetInt("a", 1);
  }

  private void VtuberCheck()
  {
    if (GameGlobals.VtuberID > 0)
    {
      this.OriginalHair.transform.position = new Vector3(0.0f, 100f, 0.0f);
      this.YandereCosmetic.FaceTexture = this.VtuberFaces[GameGlobals.VtuberID];
      this.YandereCosmetic.DefaultFaceTexture = this.VtuberFaces[GameGlobals.VtuberID];
      this.YandereCosmetic.FemaleHairRenderers[1].material.mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
      this.RightEyeRenderer.material.mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
      this.LeftEyeRenderer.material.mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
      this.RightEyeRenderer.material.color = Color.white;
      this.LeftEyeRenderer.material.color = Color.white;
      for (this.ID = 0; this.ID < 13; ++this.ID)
        this.YandereRenderer.SetBlendShapeWeight(this.ID, 0.0f);
      this.YandereRenderer.SetBlendShapeWeight(9, 100f);
    }
    else
    {
      for (int index = 1; index < this.VtuberHairs.Length; ++index)
        this.VtuberHairs[index].SetActive(false);
    }
  }
}
