// Decompiled with JetBrains decompiler
// Type: TutorialScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
  public EightiesEffectEnablerScript EightiesEffectEnabler;
  public StudentManagerScript StudentManager;
  public InputDeviceType PreviousInputDevice;
  public PostProcessingProfile Profile;
  public InputDeviceScript InputDevice;
  public WeaponMenuScript WeaponMenu;
  public PickUpScript GarbageBagBox;
  public PromptScript VictimPrompt;
  public UILabel InstructionLabel;
  public TallLockerScript Locker;
  public PromptScript ExitPortal;
  public DoorScript BathroomDoor;
  public RagdollScript Ragdoll;
  public YandereScript Yandere;
  public Transform BloodParent;
  public UILabel SubtitleLabel;
  public DoorScript FirstDoor;
  public Transform ExitWindow;
  public BucketScript Bucket;
  public AudioSource MyAudio;
  public WeaponScript Knife;
  public Camera MainCamera;
  public ClockScript Clock;
  public UISprite TutorialFadeOut;
  public UISprite ReputationHUD;
  public UISprite SanityHUD;
  public UISprite ClockHUD;
  public UISprite Darkness;
  public UISprite HUD;
  public string[] KeyboardInstructions;
  public string[] GamepadInstructions;
  public string[] Animations;
  public string[] Text;
  public WoodChipperScript[] WoodChipper;
  public PromptScript[] PromptsToDisable;
  public Transform[] Destination;
  public Animation[] Animator;
  public GameObject[] Blocker;
  public AudioSource[] BGM;
  public AudioClip[] Voice;
  public int[] Speaker;
  public AudioClip DramaticPianoNote;
  public AudioClip ReversePianoNote;
  public GameObject PhantomGirlOutline;
  public GameObject HeartbeatCamera;
  public GameObject OutOfOrderSign;
  public GameObject PickUpBlocker;
  public GameObject PauseScreen;
  public GameObject VictimGirl;
  public GameObject Jukebox;
  public GameObject FPSBG;
  public GameObject FPS;
  public bool EightiesEffectsEnabled;
  public bool TransitionToCutscene;
  public bool ReturnToTitleScreen;
  public bool FadeInstructions;
  public bool MovementProgress;
  public bool CameraProgress;
  public bool MusicSynced;
  public bool CanPickUp;
  public bool Cutscene;
  public bool Pause;
  public bool DOF;
  public int CutscenePhase;
  public int Phase;
  public float MusicTimer;
  public float SpawnTimer;
  public float Rotation = 90f;
  public float Timer;
  public float RagdollRotation;
  public Vector3 RightEyeOrigin;
  public Vector3 LeftEyeOrigin;
  public Transform RightArm;
  public Transform RightEye;
  public Transform LeftEye;
  public float EyeShrink;

  private void Start()
  {
    if (!GameGlobals.EightiesTutorial)
    {
      this.gameObject.SetActive(false);
    }
    else
    {
      Debug.Log((object) "The game believes that we are currently in the 1980s Mode tutorial sequence.");
      this.Yandere.NotificationManager.transform.localPosition = new Vector3(0.0f, 100f, 0.0f);
      this.Yandere.RightFootprintSpawner.MyCollider.enabled = false;
      this.Yandere.LeftFootprintSpawner.MyCollider.enabled = false;
      this.MainCamera.clearFlags = CameraClearFlags.Color;
      this.MainCamera.backgroundColor = new Color(1f, 1f, 1f, 1f);
      RenderSettings.fogColor = new Color(1f, 1f, 1f, 1f);
      RenderSettings.fogMode = FogMode.Exponential;
      RenderSettings.fogDensity = 0.1f;
      this.ExitWindow.localScale = new Vector3(0.0f, 0.0f, 0.0f);
      this.Yandere.Incinerator.CannotIncinerate = true;
      this.Yandere.Incinerator.enabled = false;
      this.Yandere.CameraEffects.EnableBloom();
      this.Yandere.HeartCamera.enabled = false;
      this.Yandere.CanMove = false;
      this.RightEyeOrigin = this.RightEye.localPosition;
      this.LeftEyeOrigin = this.LeftEye.localPosition;
      this.PhantomGirlOutline.transform.position = new Vector3(0.0f, 1000f, 0.0f);
      this.PhantomGirlOutline.SetActive(false);
      this.StudentManager.Graffiti[1].transform.parent.gameObject.SetActive(false);
      this.HeartbeatCamera.SetActive(false);
      this.OutOfOrderSign.SetActive(false);
      this.PauseScreen.SetActive(false);
      this.Blocker[1].SetActive(true);
      this.Blocker[2].SetActive(true);
      this.Jukebox.SetActive(false);
      this.FPSBG.SetActive(false);
      this.FPS.SetActive(false);
      this.WoodChipper[0].enabled = false;
      this.WoodChipper[1].enabled = false;
      this.WoodChipper[0].Prompt.Hide();
      this.WoodChipper[1].Prompt.Hide();
      this.WoodChipper[0].BucketPrompt.Hide();
      this.WoodChipper[0].Prompt.enabled = false;
      this.WoodChipper[1].Prompt.enabled = false;
      this.WoodChipper[0].BucketPrompt.enabled = false;
      this.VictimPrompt.Hide();
      this.VictimPrompt.enabled = false;
      this.VictimGirl.SetActive(false);
      this.MainCamera.farClipPlane = 50f;
      this.Yandere.WeaponManager.DisableAllWeapons();
      this.Knife.gameObject.SetActive(true);
      this.Knife.Prompt.enabled = false;
      this.Knife.Prompt.Hide();
      this.InstructionLabel.alpha = 0.0f;
      this.UpdateInstructionText();
      this.Clock.BloomFadeSpeed = 5f;
      this.Clock.StopTime = true;
      this.Clock.BloomWait = 1f;
      this.Knife.Undroppable = true;
      this.SubtitleLabel.text = "";
      this.ReputationHUD.alpha = 0.0f;
      this.SanityHUD.alpha = 0.0f;
      this.ClockHUD.alpha = 0.0f;
      for (int index = 1; index < this.PromptsToDisable.Length; ++index)
      {
        this.PromptsToDisable[index].Hide();
        this.PromptsToDisable[index].enabled = false;
      }
    }
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
      this.TogglePauseScreen();
    if (this.Pause)
    {
      if (Input.GetButtonDown("A"))
      {
        this.EightiesEffectsEnabled = !this.EightiesEffectsEnabled;
        OptionGlobals.DisableStatic = !this.EightiesEffectsEnabled;
        OptionGlobals.DisableDisplacement = !this.EightiesEffectsEnabled;
        OptionGlobals.DisableAbberation = !this.EightiesEffectsEnabled;
        OptionGlobals.DisableVignette = !this.EightiesEffectsEnabled;
        OptionGlobals.DisableDistortion = !this.EightiesEffectsEnabled;
        OptionGlobals.DisableScanlines = true;
        OptionGlobals.DisableNoise = !this.EightiesEffectsEnabled;
        OptionGlobals.DisableTint = !this.EightiesEffectsEnabled;
        this.EightiesEffectEnabler.UpdateEightiesEffects();
        this.TogglePauseScreen();
      }
      else if (Input.GetButtonDown("Y"))
      {
        this.Phase = 54;
        this.TogglePauseScreen();
        Time.timeScale = 5f;
      }
      else if (Input.GetButtonDown("X"))
      {
        this.ReturnToTitleScreen = true;
        this.Phase = 54;
        this.TogglePauseScreen();
        Time.timeScale = 5f;
      }
      else if (Input.GetButtonDown("B"))
        this.TogglePauseScreen();
    }
    if (!this.Clock.UpdateBloom)
    {
      if (!this.Cutscene)
      {
        if (this.Phase > 51 && this.Phase < 54)
          this.ClockHUD.alpha = Mathf.MoveTowards(this.ClockHUD.alpha, 1f, Time.deltaTime);
        else if (this.Phase > 47)
          this.ReputationHUD.alpha = Mathf.MoveTowards(this.ReputationHUD.alpha, 1f, Time.deltaTime);
        else if (this.Phase > 46)
          this.StudentManager.Students[25].Witnessed = StudentWitnessType.Tutorial;
        else if (this.Phase > 45)
        {
          if ((Object) this.StudentManager.Students[2] != (Object) null)
          {
            this.StudentManager.Students[2].Pathfinding.target = this.Destination[47];
            this.StudentManager.Students[2].CurrentDestination = this.Destination[47];
          }
        }
        else if (this.Phase > 44)
          this.SanityHUD.alpha = Mathf.MoveTowards(this.SanityHUD.alpha, 1f, Time.deltaTime);
        else if (this.Phase == 15 && !this.CanPickUp)
        {
          this.StudentManager.Students[2].CharacterAnimation.Play("f02_knifeStealthB_00");
          this.StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].time = this.StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].length;
        }
        if (this.Phase > 53)
          this.BGM[1].volume = Mathf.MoveTowards(this.BGM[1].volume, 0.0f, Time.deltaTime * 0.2f);
        else if (this.Phase > 52)
        {
          this.BGM[1].volume = this.MyAudio.isPlaying ? Mathf.MoveTowards(this.BGM[1].volume, 0.5f, Time.deltaTime * 0.2f) : Mathf.MoveTowards(this.BGM[1].volume, 1f, Time.deltaTime * 0.2f);
          this.BGM[2].volume = Mathf.MoveTowards(this.BGM[2].volume, 0.0f, Time.deltaTime * 0.2f);
        }
        else if (this.Phase > 45)
        {
          this.BGM[2].volume = this.MyAudio.isPlaying ? Mathf.MoveTowards(this.BGM[2].volume, 0.5f, Time.deltaTime * 0.2f) : Mathf.MoveTowards(this.BGM[2].volume, 1f, Time.deltaTime * 0.2f);
          this.BGM[3].volume = Mathf.MoveTowards(this.BGM[3].volume, 0.0f, Time.deltaTime * 0.2f);
        }
        else if (this.Phase > 13)
        {
          this.BGM[2].volume = Mathf.MoveTowards(this.BGM[2].volume, 0.0f, Time.deltaTime * 0.2f);
          this.BGM[3].volume = this.MyAudio.isPlaying ? Mathf.MoveTowards(this.BGM[3].volume, 0.5f, Time.deltaTime * 0.2f) : Mathf.MoveTowards(this.BGM[3].volume, 1f, Time.deltaTime * 0.2f);
        }
        else if (this.Phase > 5)
        {
          this.BGM[1].volume = Mathf.MoveTowards(this.BGM[1].volume, 0.0f, Time.deltaTime * 0.2f);
          this.BGM[2].volume = this.MyAudio.isPlaying ? Mathf.MoveTowards(this.BGM[2].volume, 0.5f, Time.deltaTime * 0.2f) : Mathf.MoveTowards(this.BGM[2].volume, 1f, Time.deltaTime * 0.2f);
        }
        else
          this.BGM[1].volume = this.MyAudio.isPlaying ? Mathf.MoveTowards(this.BGM[1].volume, 0.5f, Time.deltaTime * 0.2f) : Mathf.MoveTowards(this.BGM[1].volume, 1f, Time.deltaTime * 0.2f);
        if (this.Yandere.Laughing)
        {
          RenderSettings.fogColor = new Color((float) (((double) this.Yandere.Sanity - 50.0) / 50.0), (float) (((double) this.Yandere.Sanity - 50.0) / 50.0), (float) (((double) this.Yandere.Sanity - 50.0) / 50.0), 1f);
          this.MainCamera.backgroundColor = RenderSettings.fogColor;
        }
        if (this.FadeInstructions)
        {
          this.InstructionLabel.alpha = Mathf.MoveTowards(this.InstructionLabel.alpha, 0.0f, Time.deltaTime * 2f);
          if ((double) this.InstructionLabel.alpha == 0.0)
          {
            if (!this.TransitionToCutscene)
            {
              this.FadeInstructions = false;
              ++this.Phase;
              this.InstructionLabel.text = this.InputDevice.Type != InputDeviceType.Gamepad ? this.KeyboardInstructions[this.Phase] : this.GamepadInstructions[this.Phase];
            }
            else
              this.Cutscene = true;
          }
        }
        else
        {
          this.InstructionLabel.alpha = Mathf.MoveTowards(this.InstructionLabel.alpha, 1f, Time.deltaTime * 2f);
          if ((double) this.InstructionLabel.alpha == 1.0)
          {
            if (this.Phase == 1)
            {
              float axis1 = Input.GetAxis("Vertical");
              float axis2 = Input.GetAxis("Horizontal");
              float axis3 = Input.GetAxis("Mouse X");
              float axis4 = Input.GetAxis("Mouse Y");
              if (!this.CameraProgress && ((double) axis1 != 0.0 || (double) axis2 != 0.0))
                this.CameraProgress = true;
              if (!this.MovementProgress && ((double) axis3 != 0.0 || (double) axis4 != 0.0))
                this.MovementProgress = true;
              if (this.CameraProgress && this.MovementProgress || (double) this.Yandere.transform.position.z > -50.0)
              {
                if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[3].position) < 1.0)
                  this.Phase += 2;
                this.FadeInstructions = true;
              }
            }
            else if (this.Phase == 2)
            {
              if (Input.GetButtonDown("LS") || Input.GetKeyDown("t") || (double) Vector3.Distance(this.Yandere.transform.position, this.Destination[3].position) < 1.0)
              {
                if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[3].position) < 1.0)
                  ++this.Phase;
                this.FadeInstructions = true;
              }
            }
            else if (this.Phase == 3)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 1.0)
              {
                this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
                this.FadeInstructions = true;
                this.Yandere.Frozen = true;
              }
            }
            else if (this.Phase == 4)
            {
              if (this.FirstDoor.Open)
              {
                this.FadeInstructions = true;
                this.Yandere.Frozen = false;
              }
            }
            else if (this.Phase == 5)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 0.5)
              {
                this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
                this.Knife.Prompt.enabled = true;
                this.FadeInstructions = true;
                this.Yandere.Frozen = true;
              }
            }
            else if (this.Phase == 6)
            {
              if (this.Yandere.Armed || (Object) this.Yandere.Weapon[1] != (Object) null)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 7)
            {
              if (!this.Yandere.Armed)
              {
                this.Blocker[2].SetActive(false);
                this.Blocker[3].SetActive(true);
                this.FadeInstructions = true;
                this.Yandere.Frozen = false;
              }
            }
            else if (this.Phase == 8)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 1.0)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 9)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 0.5)
              {
                this.FadeInstructions = true;
                this.Yandere.Frozen = false;
              }
            }
            else if (this.Phase == 10)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 0.5 && !this.BathroomDoor.Open)
              {
                this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
                this.Yandere.RPGCamera.enabled = false;
                this.TransitionToCutscene = true;
                this.Blocker[4].SetActive(true);
                this.FadeInstructions = true;
                this.Yandere.CanMove = false;
              }
            }
            else if (this.Phase == 11)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 1.0)
              {
                this.VictimPrompt.enabled = true;
                this.FadeInstructions = true;
                this.Yandere.Frozen = true;
              }
            }
            else if (this.Phase == 12)
            {
              if ((double) this.VictimPrompt.Circle[0].fillAmount == 0.0)
              {
                this.VictimPrompt.Hide();
                this.VictimPrompt.enabled = false;
                this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
                this.InstructionLabel.alpha = 0.0f;
                this.FadeInstructions = true;
                this.Yandere.CanMove = false;
                this.Cutscene = true;
                this.Animator[this.Speaker[this.CutscenePhase]].CrossFade(this.Animations[this.CutscenePhase]);
                this.SubtitleLabel.text = this.Text[this.CutscenePhase];
                this.MyAudio.clip = this.Voice[this.CutscenePhase];
                this.MyAudio.Play();
              }
            }
            else if (this.Phase == 13)
            {
              if (this.Yandere.Armed)
              {
                this.WeaponMenu.enabled = false;
                this.WeaponMenu.InstantHide();
                this.VictimPrompt.enabled = true;
                this.VictimPrompt.HideButton[0] = true;
                this.VictimPrompt.HideButton[2] = false;
                this.PickUpBlocker.SetActive(true);
                this.FadeInstructions = true;
              }
            }
            else if (this.Phase == 14)
            {
              if ((double) this.VictimPrompt.Circle[2].fillAmount != 1.0)
              {
                this.VictimPrompt.Hide();
                this.VictimPrompt.enabled = false;
                AudioSource.PlayClipAtPoint(this.ReversePianoNote, this.MainCamera.transform.position);
                this.Yandere.CharacterAnimation.CrossFade("f02_knifeStealthA_00");
                this.Animator[2].CrossFade("f02_knifeStealthB_00");
                this.DOF = this.Profile.depthOfField.enabled;
                this.GarbageBagBox.transform.position = this.GarbageBagBox.OriginalPosition;
                this.Profile.depthOfField.enabled = false;
                this.Yandere.RPGCamera.enabled = false;
                this.PickUpBlocker.SetActive(false);
                this.InstructionLabel.alpha = 0.0f;
                this.WeaponMenu.enabled = true;
                this.FadeInstructions = true;
                this.Yandere.CanMove = false;
                this.Cutscene = true;
              }
            }
            else if (this.Phase == 15)
            {
              if ((Object) this.Yandere.PickUp != (Object) null && this.Yandere.PickUp.GarbageBagBox)
              {
                this.Ragdoll.Prompt.enabled = true;
                this.FadeInstructions = true;
              }
            }
            else if (this.Phase == 16)
            {
              if (this.Ragdoll.Concealed)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 17)
            {
              if ((Object) this.Yandere.PickUp == (Object) null)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 18)
            {
              if ((Object) this.Yandere.PickUp != (Object) null && (Object) this.Yandere.PickUp.Bucket != (Object) null)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 19)
            {
              if ((Object) this.Yandere.PickUp != (Object) null && (Object) this.Yandere.PickUp.Bucket != (Object) null && this.Yandere.PickUp.Bucket.Full)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 20)
            {
              if ((Object) this.Yandere.PickUp == (Object) null)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 21)
            {
              if ((Object) this.Yandere.PickUp != (Object) null && this.Yandere.PickUp.Bleach)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 22)
            {
              if (this.Bucket.Bleached)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 23)
            {
              if ((Object) this.Yandere.PickUp == (Object) null)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 24)
            {
              if ((Object) this.Yandere.PickUp != (Object) null && (Object) this.Yandere.PickUp.Mop != (Object) null)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 25)
            {
              if ((Object) this.Yandere.PickUp != (Object) null && (Object) this.Yandere.PickUp.Mop != (Object) null && this.Yandere.PickUp.Mop.Bleached)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 26)
            {
              if (this.Yandere.YandereVision)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 27)
            {
              if (this.BloodParent.childCount == 0)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 28)
            {
              if ((Object) this.Yandere.PickUp == (Object) null)
              {
                this.Ragdoll.Tutorial = false;
                this.Ragdoll.Prompt.HideButton[3] = false;
                this.Ragdoll.Prompt.HideButton[1] = false;
                this.FadeInstructions = true;
              }
            }
            else if (this.Phase == 29)
            {
              if (this.Yandere.Carrying)
              {
                this.Blocker[1].SetActive(false);
                this.Blocker[3].SetActive(false);
                this.Blocker[4].SetActive(false);
                this.FadeInstructions = true;
              }
            }
            else if (this.Phase == 30)
            {
              if (this.Yandere.Carrying && (double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 0.5)
              {
                this.Yandere.Incinerator.enabled = true;
                this.FadeInstructions = true;
                this.Yandere.Frozen = true;
              }
            }
            else if (this.Phase == 31)
            {
              if (this.Yandere.Dumping)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 32)
            {
              if (this.Yandere.Armed)
              {
                this.Knife.Undroppable = false;
                this.FadeInstructions = true;
              }
            }
            else if (this.Phase == 33)
            {
              if (this.Knife.Dumped)
              {
                this.FadeInstructions = true;
                this.Yandere.Frozen = false;
              }
            }
            else if (this.Phase == 34)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 1.0)
              {
                this.PromptsToDisable[9].enabled = true;
                this.FadeInstructions = true;
              }
            }
            else if (this.Phase == 35)
            {
              if (this.Locker.Open)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 36)
            {
              if (this.Yandere.Schoolwear == 0)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 37)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 0.5)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 38)
            {
              if ((double) this.Yandere.Bloodiness == 0.0)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 39)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 1.0)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 40)
            {
              if (this.Yandere.Schoolwear == 3)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 41)
            {
              if ((Object) this.Yandere.PickUp != (Object) null && this.Yandere.PickUp.Clothing)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 42)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 0.5)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 43)
            {
              if (this.Yandere.Incinerator.BloodyClothing > 0)
              {
                this.Yandere.Incinerator.CannotIncinerate = false;
                this.FadeInstructions = true;
              }
            }
            else if (this.Phase == 44)
            {
              if ((double) this.Yandere.Incinerator.Timer > 0.0)
              {
                this.FadeInstructions = true;
                this.Yandere.Frozen = true;
              }
            }
            else if (this.Phase == 45)
            {
              if (Input.GetButtonDown("A"))
                this.FadeInstructions = true;
            }
            else if (this.Phase == 46)
            {
              if ((double) this.Yandere.Sanity == 100.0)
              {
                if ((Object) this.StudentManager.Students[2] != (Object) null)
                {
                  Object.Destroy((Object) this.StudentManager.Students[2].gameObject);
                  this.StudentManager.Students[2] = (StudentScript) null;
                }
                this.StudentManager.ForceSpawn = true;
                this.StudentManager.SpawnPositions[25] = this.Destination[this.Phase + 1].transform;
                this.StudentManager.SpawnID = 25;
                this.StudentManager.SpawnStudent(25);
                this.StudentManager.Students[25].FocusOnYandere = true;
                this.StudentManager.Students[25].Blind = true;
                this.StudentManager.Students[25].enabled = true;
                this.StudentManager.Students[25].Start();
                this.StudentManager.Students[25].OriginalIdleAnim = "f02_idleShort_01";
                this.StudentManager.Students[25].IdleAnim = "f02_idleShort_01";
                this.StudentManager.Students[25].transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
                this.StudentManager.Students[25].Indoors = true;
                this.StudentManager.Students[25].Spawned = true;
                if ((Object) this.StudentManager.Students[25].ShoeRemoval.Locker == (Object) null)
                  this.StudentManager.Students[25].ShoeRemoval.Start();
                this.StudentManager.Students[25].ShoeRemoval.PutOnShoes();
                this.StudentManager.StayInOneSpot(25);
                this.Blocker[5].SetActive(true);
                this.FadeInstructions = true;
                this.Yandere.Frozen = false;
              }
            }
            else if (this.Phase == 47)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 4.0)
              {
                this.StudentManager.Students[25].Witnessed = StudentWitnessType.Tutorial;
                this.StudentManager.Students[25].Reputation.PendingRep -= 10f;
                this.StudentManager.Students[25].PendingRep = -10f;
                this.StudentManager.Students[25].Witness = true;
                this.StudentManager.Students[25].Alarm = 200f;
                this.Yandere.CameraEffects.Alarm();
                this.TransitionToCutscene = true;
                this.FadeInstructions = true;
                this.Yandere.Frozen = true;
              }
            }
            else if (this.Phase == 48)
            {
              if (Input.GetButtonDown("A"))
              {
                this.FadeInstructions = true;
                this.Yandere.Frozen = false;
              }
            }
            else if (this.Phase == 49)
            {
              if ((double) Vector3.Distance(this.Yandere.transform.position, this.Destination[this.Phase].position) < 1.0)
              {
                this.StudentManager.Students[25].Prompt.HideButton[0] = false;
                this.StudentManager.Students[25].Witness = true;
                this.FadeInstructions = true;
                this.Yandere.Frozen = true;
              }
            }
            else if (this.Phase == 50)
            {
              if (this.Yandere.Talking)
                this.FadeInstructions = true;
            }
            else if (this.Phase == 51)
            {
              if (this.StudentManager.Students[25].Forgave && !this.Yandere.Talking)
              {
                this.StudentManager.Students[25].Reputation.PendingRep = 0.0f;
                this.Yandere.RPGCamera.enabled = false;
                this.MainCamera.transform.position = new Vector3(0.0f, 14f, -38.5666656f);
                this.MainCamera.transform.eulerAngles = Vector3.zero;
                this.StudentManager.Students[25].gameObject.SetActive(false);
                this.Blocker[5].SetActive(false);
                this.MainCamera.clearFlags = CameraClearFlags.Skybox;
                this.MainCamera.farClipPlane = 350f;
                RenderSettings.fog = false;
                this.Clock.PresentTime = 1079f;
                this.FadeInstructions = true;
              }
            }
            else if (this.Phase == 52)
            {
              if (Input.GetButtonDown("A"))
              {
                this.ExitPortal.gameObject.SetActive(true);
                this.Yandere.RPGCamera.enabled = true;
                this.FadeInstructions = true;
                this.Yandere.Frozen = false;
              }
            }
            else if (this.Phase == 53)
            {
              if ((double) this.ExitPortal.Circle[0].fillAmount == 0.0)
              {
                this.InstructionLabel.gameObject.SetActive(false);
                this.Yandere.Frozen = true;
                ++this.Phase;
              }
            }
            else if (this.Phase == 54)
            {
              this.TutorialFadeOut.alpha = Mathf.MoveTowards(this.TutorialFadeOut.alpha, 1f, Time.deltaTime * 0.2f);
              if ((double) this.TutorialFadeOut.alpha == 1.0)
              {
                if (!this.ReturnToTitleScreen)
                {
                  GameGlobals.EightiesTutorial = false;
                  GameGlobals.EightiesCutsceneID = 1;
                  OptionGlobals.Fog = false;
                  SceneManager.LoadScene("EightiesCutsceneScene");
                }
                else
                  SceneManager.LoadScene("NewTitleScene");
              }
            }
          }
        }
      }
      else
      {
        if (this.CutscenePhase == 0)
        {
          this.Yandere.MainCamera.transform.position = new Vector3(25f, 9f, -29f);
          this.Yandere.MainCamera.transform.eulerAngles = new Vector3(0.0f, 75f, 0.0f);
          this.VictimGirl.SetActive(true);
          this.Animator[2].Play("f02_walkShy_00");
          ++this.CutscenePhase;
        }
        else if (this.CutscenePhase == 1)
        {
          this.VictimGirl.transform.position += new Vector3(Time.deltaTime, 0.0f, 0.0f);
          this.Animator[2].CrossFade("f02_walkShy_00");
          if (Input.GetButtonDown("A"))
            this.VictimGirl.transform.position = new Vector3(29.5f, 8f, -28.5f);
          if ((double) this.VictimGirl.transform.position.x >= 29.5)
          {
            this.VictimGirl.transform.position = new Vector3(29.5f, 8f, -28.5f);
            this.SubtitleLabel.text = this.Text[this.CutscenePhase];
            this.MyAudio.clip = this.Voice[this.CutscenePhase];
            this.MyAudio.Play();
            this.Animator[2].CrossFade("f02_idleShy_00");
            ++this.CutscenePhase;
          }
        }
        else if (this.CutscenePhase == 2)
        {
          if (Input.GetButtonDown("A"))
            this.MyAudio.Stop();
          if (!this.MyAudio.isPlaying)
          {
            this.Yandere.RPGCamera.enabled = true;
            this.TransitionToCutscene = false;
            this.SubtitleLabel.text = "";
            this.Yandere.CanMove = true;
            this.Cutscene = false;
            ++this.CutscenePhase;
          }
        }
        else if (this.CutscenePhase < 7)
        {
          if (this.CutscenePhase < 5)
          {
            this.Rotation = Mathf.Lerp(this.Rotation, -90f, Time.deltaTime * 5f);
            this.VictimGirl.transform.localEulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
          }
          else
          {
            this.Rotation = Mathf.Lerp(this.Rotation, 90f, Time.deltaTime * 5f);
            this.VictimGirl.transform.localEulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
          }
          this.Yandere.MoveTowardsTarget(new Vector3(28.5f, 8f, -28.5f));
          this.Yandere.targetRotation = Quaternion.LookRotation(this.VictimGirl.transform.position - this.Yandere.transform.position);
          this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.Yandere.targetRotation, Time.deltaTime * 10f);
          if (Input.GetButtonDown("A"))
            this.MyAudio.Stop();
          if ((double) this.Animator[this.Speaker[this.CutscenePhase]][this.Animations[this.CutscenePhase]].time >= (double) this.Animator[this.Speaker[this.CutscenePhase]][this.Animations[this.CutscenePhase]].length)
          {
            if (this.Speaker[this.CutscenePhase] == 1)
              this.Animator[1].CrossFade(this.Yandere.IdleAnim);
            else if (this.CutscenePhase == 5)
              this.Animator[2].CrossFade("f02_idleShame_00");
            else
              this.Animator[2].CrossFade("f02_idleShy_00");
          }
          if (!this.MyAudio.isPlaying)
          {
            ++this.CutscenePhase;
            if (this.CutscenePhase < 7)
            {
              this.Animator[1].CrossFade(this.Yandere.IdleAnim);
              this.Animator[2].CrossFade("f02_idleShy_00");
              this.Animator[this.Speaker[this.CutscenePhase]].CrossFade(this.Animations[this.CutscenePhase]);
              this.SubtitleLabel.text = this.Text[this.CutscenePhase];
              this.MyAudio.clip = this.Voice[this.CutscenePhase];
              this.MyAudio.Play();
            }
          }
        }
        else if (this.CutscenePhase == 7)
        {
          this.TransitionToCutscene = false;
          this.SubtitleLabel.text = "";
          this.Yandere.CanMove = true;
          this.Cutscene = false;
          ++this.CutscenePhase;
        }
        else if (this.CutscenePhase == 8)
        {
          this.BGM[2].volume = Mathf.MoveTowards(this.BGM[2].volume, 0.0f, Time.deltaTime * 0.2f);
          this.BGM[3].volume = Mathf.MoveTowards(this.BGM[3].volume, 0.0f, Time.deltaTime * 0.2f);
          this.Yandere.MainCamera.transform.position = new Vector3(30f, 9.366666f, -28.5f);
          this.Yandere.MainCamera.transform.eulerAngles = new Vector3(0.0f, -90f, 0.0f);
          this.VictimGirl.transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
          this.VictimGirl.transform.position = new Vector3(29.5f, 8f, -28.5f);
          this.Yandere.transform.position = new Vector3(28.82f, 8f, -28.5f);
          this.Yandere.EquippedWeapon.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
          this.Yandere.CharacterAnimation["f02_knifeStealthA_00"].speed = Mathf.MoveTowards(this.Yandere.CharacterAnimation["f02_knifeStealthA_00"].speed, 0.1f, Time.deltaTime);
          this.Animator[2]["f02_knifeStealthB_00"].speed = Mathf.MoveTowards(this.Animator[2]["f02_knifeStealthB_00"].speed, 0.1f, Time.deltaTime);
          if ((double) this.Yandere.CharacterAnimation["f02_knifeStealthA_00"].time > 0.5)
            this.EyeShrink = Mathf.MoveTowards(this.EyeShrink, 1f, Time.deltaTime);
          if ((double) this.Yandere.CharacterAnimation["f02_knifeStealthA_00"].time > (double) this.Yandere.CharacterAnimation["f02_knifeStealthA_00"].length * 0.47499999403953552)
          {
            this.Yandere.RPGCamera.mouseX = 45f;
            this.Yandere.RPGCamera.mouseY = 45f;
            this.Yandere.RPGCamera.mouseXSmooth = -315f;
            this.Yandere.RPGCamera.mouseYSmooth = -315f;
            this.Yandere.RPGCamera.GetDesiredPosition();
            this.Yandere.RPGCamera.PositionUpdate();
            this.SubtitleLabel.text = this.Text[this.CutscenePhase];
            this.MyAudio.clip = this.Voice[this.CutscenePhase];
            this.MyAudio.Play();
            this.BGM[2].volume = 0.0f;
            this.BGM[3].volume = 0.0f;
            this.Darkness.alpha = 1f;
            ++this.CutscenePhase;
          }
        }
        else if (this.CutscenePhase == 9)
        {
          if ((Object) this.StudentManager.Students[2] == (Object) null)
          {
            this.StudentManager.ForceSpawn = true;
            this.StudentManager.SpawnPositions[2] = this.VictimGirl.transform;
            this.StudentManager.SpawnID = 2;
            this.StudentManager.SpawnStudent(2);
          }
          else if (!this.StudentManager.Students[2].Ragdoll.enabled)
          {
            this.StudentManager.Students[2].CharacterAnimation.Play("f02_knifeStealthB_00");
            this.StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].time = this.StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].length;
            this.StudentManager.Students[2].transform.position = new Vector3(29.9f, 8f, -29.4f);
            this.StudentManager.Students[2].transform.eulerAngles = new Vector3(0.0f, -90f, 0.0f);
            this.StudentManager.Students[2].BecomeRagdoll();
            CosmeticScript cosmetic = this.StudentManager.Students[2].Cosmetic;
            cosmetic.FemaleHair[this.StudentManager.Students[2].Cosmetic.Hairstyle].SetActive(false);
            cosmetic.HairRenderer = this.StudentManager.Students[2].Cosmetic.FemaleHairRenderers[57];
            cosmetic.FemaleHair[57].SetActive(true);
            cosmetic.Hairstyle = 57;
            cosmetic.MyStockings = cosmetic.EightiesRivalStockings[11];
            cosmetic.MyRenderer.materials[0].SetTexture("_OverlayTex", cosmetic.MyStockings);
            cosmetic.MyRenderer.materials[1].SetTexture("_OverlayTex", cosmetic.MyStockings);
            cosmetic.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
            cosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
            this.Ragdoll = this.StudentManager.Students[2].Ragdoll;
            this.Ragdoll.Tutorial = true;
          }
          if ((double) this.MyAudio.time > (double) this.MyAudio.clip.length - 0.20000000298023224 && !this.Yandere.RPGCamera.enabled)
            this.ReturnToGameplay();
          if (!this.MyAudio.isPlaying)
          {
            AudioSource.PlayClipAtPoint(this.DramaticPianoNote, this.MainCamera.transform.position);
            this.MainCamera.backgroundColor = new Color(0.0f, 0.0f, 0.0f, 1f);
            RenderSettings.fogColor = new Color(0.0f, 0.0f, 0.0f, 1f);
            this.BGM[3].volume = 0.5f;
            this.Knife.Blood.enabled = true;
            this.Knife.MurderWeapon = true;
            this.Knife.Bloody = true;
            this.Yandere.Bloodiness += 100f;
            this.Yandere.Sanity -= 50f;
            this.StudentManager.Students[2].CharacterAnimation.enabled = true;
            this.StudentManager.Students[2].CharacterAnimation.Play("f02_knifeStealthB_00");
            this.StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].time = this.StudentManager.Students[2].CharacterAnimation["f02_knifeStealthB_00"].length;
            this.Profile.depthOfField.enabled = this.DOF;
            this.TransitionToCutscene = false;
            this.VictimGirl.SetActive(false);
            this.SubtitleLabel.text = "";
            this.Yandere.Frozen = false;
            this.Yandere.CanMove = true;
            this.Darkness.alpha = 0.0f;
            this.CanPickUp = true;
            this.Cutscene = false;
            ++this.CutscenePhase;
            if (!this.Yandere.RPGCamera.enabled)
              this.ReturnToGameplay();
          }
        }
        else if (this.CutscenePhase == 10 && this.StudentManager.Students[25].Routine)
        {
          this.TransitionToCutscene = false;
          this.Yandere.Frozen = true;
          this.Cutscene = false;
          ++this.CutscenePhase;
        }
        if ((double) this.BGM[1].volume > 0.0)
          this.BGM[1].volume = Mathf.MoveTowards(this.BGM[1].volume, 0.5f, Time.deltaTime);
        else if ((double) this.BGM[2].volume > 0.0)
          this.BGM[2].volume = Mathf.MoveTowards(this.BGM[2].volume, 0.5f, Time.deltaTime);
        else if ((double) this.BGM[3].volume > 0.0)
          this.BGM[3].volume = Mathf.MoveTowards(this.BGM[3].volume, 0.5f, Time.deltaTime);
      }
    }
    else if (!this.MusicSynced)
    {
      this.MusicTimer += Time.deltaTime;
      if ((double) this.MusicTimer > 1.0)
      {
        this.BGM[1].time = 0.0f;
        this.BGM[2].time = 0.0f;
        this.BGM[3].time = 0.0f;
        this.BGM[1].Play();
        this.BGM[2].Play();
        this.BGM[3].Play();
        this.MusicSynced = true;
      }
    }
    else
      this.BGM[1].volume = Mathf.MoveTowards(this.BGM[1].volume, 1f, Time.deltaTime * 0.2f);
    if (this.InputDevice.Type == this.PreviousInputDevice)
      return;
    this.UpdateInstructionText();
  }

  private void UpdateInstructionText()
  {
    this.PreviousInputDevice = this.InputDevice.Type;
    if (this.InputDevice.Type == InputDeviceType.Gamepad)
      this.InstructionLabel.text = this.GamepadInstructions[this.Phase];
    else
      this.InstructionLabel.text = this.KeyboardInstructions[this.Phase];
  }

  private void LateUpdate()
  {
    if ((double) this.EyeShrink > 0.0)
    {
      this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
      this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
      this.LeftEye.localScale = new Vector3((float) (1.0 - (double) this.EyeShrink * 0.5), (float) (1.0 - (double) this.EyeShrink * 0.5), this.LeftEye.localScale.z);
      this.RightEye.localScale = new Vector3((float) (1.0 - (double) this.EyeShrink * 0.5), (float) (1.0 - (double) this.EyeShrink * 0.5), this.RightEye.localScale.z);
    }
    if (this.CutscenePhase != 8)
      return;
    this.RightArm.localEulerAngles += new Vector3(15f, 0.0f, 0.0f);
  }

  public void TogglePauseScreen()
  {
    this.Pause = !this.Pause;
    if (this.Pause)
    {
      Time.timeScale = 0.0f;
      this.ExitWindow.localScale = new Vector3(1f, 1f, 1f);
    }
    else
    {
      Time.timeScale = 1f;
      this.ExitWindow.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    }
  }

  public void ReturnToGameplay()
  {
    Debug.Log((object) "At this exact moment, we are returning to gameplay.");
    CosmeticScript cosmetic = this.StudentManager.Students[2].Cosmetic;
    cosmetic.FaceTexture = cosmetic.HairRenderer.material.mainTexture;
    cosmetic.RightEyeRenderer.material.mainTexture = cosmetic.FaceTexture;
    cosmetic.LeftEyeRenderer.material.mainTexture = cosmetic.FaceTexture;
    this.Yandere.RPGCamera.enabled = true;
  }
}
