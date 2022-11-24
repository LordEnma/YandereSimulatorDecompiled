// Decompiled with JetBrains decompiler
// Type: StalkerYandereScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using Bayat.SaveSystem;
using HighlightingSystem;
using System;
using UnityEngine;
using UnityEngine.PostProcessing;

public class StalkerYandereScript : MonoBehaviour
{
  public StalkerPromptScript StalkerDoorPrompt;
  public UniformSetterScript UniformSetter;
  public CharacterController MyController;
  public PostProcessingProfile Profile;
  public AutoSaveManager SaveManager;
  public UILabel InstructionLabel;
  public StalkerScript Stalker;
  public ArcScript Arc;
  public Transform TrellisClimbSpot;
  public Transform CameraTarget;
  public Transform ObjectTarget;
  public Transform RightHand;
  public Transform EntryPOV;
  public Transform RightArm;
  public Transform Object;
  public Transform Hips;
  public Renderer PonytailRenderer;
  public GameObject GroundImpact;
  public Animation MyAnimation;
  public RPG_Camera RPGCamera;
  public AudioSource Jukebox;
  public Camera MainCamera;
  public bool Struggling;
  public bool Climbing;
  public bool Running;
  public bool Invisible;
  public bool Eighties;
  public bool InDesert;
  public bool CanMove;
  public bool Chased;
  public bool Hidden;
  public bool Street;
  public Stance Stance = new Stance(StanceType.Standing);
  public string IdleAnim;
  public string WalkAnim;
  public string RunAnim;
  public string CrouchIdleAnim;
  public string CrouchWalkAnim;
  public string CrouchRunAnim;
  public float WalkSpeed;
  public float RunSpeed;
  public float CrouchWalkSpeed;
  public float CrouchRunSpeed;
  public float Intensity = 0.45f;
  public int InstructionPhase = 1;
  public int ClimbPhase;
  public int Pebbles;
  public int Frame;
  public SkinnedMeshRenderer MyRenderer;
  public GameObject ClothingAttacher;
  public GameObject EightiesAttacher;
  public GameObject RyobaHair;
  public Material Transparent;
  public Texture BlondePony;
  public Mesh HeadOnlyMesh;
  public Transform BreastL;
  public Transform BreastR;
  public AudioSource MyAudio;
  public GameObject Pebble;
  public bool UpdateBlendshapes;
  public bool LethalPoison;
  public bool Initialized;
  public bool Sedative;
  public bool Asylum;
  public bool Cigs;
  private int UpdateFrame;
  public CameraFilterPack_Colors_Adjust_PreFilters YandereFilter;
  public HighlightingRenderer HighlightingR;
  public HighlightingBlitter HighlightingB;
  public GameObject ThrowButton;
  public GameObject PebbleIcon;
  public GameObject AimButton;
  public UILabel PebbleLabel;
  public GameObject[] OriginalHairs;
  public GameObject[] VtuberHairs;
  public Texture[] VtuberFaces;
  public bool UpdateTextures;
  public bool Vtuber;

  public void Start()
  {
    if ((UnityEngine.Object) this.BlondePony != (UnityEngine.Object) null && GameGlobals.BlondeHair)
      this.PonytailRenderer.material.mainTexture = this.BlondePony;
    if (GameGlobals.Eighties)
      this.Eighties = true;
    else if ((UnityEngine.Object) this.RyobaHair != (UnityEngine.Object) null)
      this.RyobaHair.SetActive(false);
    if (GameGlobals.Eighties && (UnityEngine.Object) this.EightiesAttacher != (UnityEngine.Object) null)
    {
      if (HomeGlobals.Night || DateGlobals.Weekday != DayOfWeek.Sunday || DateGlobals.Weekday != DayOfWeek.Saturday)
      {
        this.EightiesAttacher.SetActive(true);
      }
      else
      {
        Debug.Log((object) "Daytime or weekend. Staying in school uniform.");
        this.UniformSetter.enabled = true;
      }
      this.MyRenderer.sharedMesh = this.HeadOnlyMesh;
      this.PonytailRenderer.gameObject.SetActive(false);
      this.RyobaHair.SetActive(true);
      this.MyRenderer.SetBlendShapeWeight(0, 50f);
      this.MyRenderer.SetBlendShapeWeight(5, 25f);
      this.MyRenderer.SetBlendShapeWeight(8, 0.0f);
      this.MyRenderer.SetBlendShapeWeight(12, 100f);
      this.IdleAnim = "f02_ryobaIdle_00";
      this.WalkAnim = "f02_ryobaWalk_00";
      this.RunAnim = "f02_ryobaRun_00";
      this.MyRenderer.materials[0].mainTexture = this.MyRenderer.materials[2].mainTexture;
      this.Eighties = true;
      if (this.Street)
      {
        this.BreastL.transform.localScale = new Vector3(1f, 1f, 1f);
        this.BreastR.transform.localScale = new Vector3(1f, 1f, 1f);
      }
    }
    else
    {
      if (!this.Asylum)
      {
        this.BreastL.transform.localScale = new Vector3(1f, 1f, 1f);
        this.BreastR.transform.localScale = new Vector3(1f, 1f, 1f);
      }
      if ((UnityEngine.Object) this.ClothingAttacher != (UnityEngine.Object) null && !this.Initialized)
      {
        if (HomeGlobals.Night || DateGlobals.Weekday != DayOfWeek.Sunday || DateGlobals.Weekday != DayOfWeek.Saturday)
        {
          this.ClothingAttacher.SetActive(true);
          this.MyRenderer.gameObject.SetActive(false);
        }
        else
        {
          Debug.Log((object) "Daytime or weekend. Staying in school uniform.");
          this.UniformSetter.Ryoba = false;
          this.UniformSetter.enabled = true;
        }
        this.Initialized = true;
      }
      this.UpdatePebbles();
    }
    this.VtuberCheck();
  }

  private void Update()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    if (this.UpdateTextures)
    {
      if (this.UpdateFrame == 1)
      {
        Debug.Log((object) "Attempting to update textures...");
        if ((UnityEngine.Object) this.ClothingAttacher != (UnityEngine.Object) null && (UnityEngine.Object) this.ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != (UnityEngine.Object) null)
        {
          Debug.Log((object) "ClothingAttacher was not null.");
          this.MyRenderer = this.ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
          this.MyRenderer.materials[1].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
        }
        else
        {
          Debug.Log((object) "ClothingAttacher was null.");
          for (int index = 0; index < 13; ++index)
            this.MyRenderer.SetBlendShapeWeight(index, 0.0f);
          this.MyRenderer.SetBlendShapeWeight(0, 100f);
          this.MyRenderer.SetBlendShapeWeight(9, 100f);
          if (this.Eighties && this.Street)
          {
            this.MyRenderer.materials[0].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
            this.MyRenderer.materials[1].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
            this.MyRenderer.materials[2].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
          }
        }
        this.UpdateTextures = false;
      }
      ++this.UpdateFrame;
    }
    if (this.UpdateBlendshapes)
    {
      Debug.Log((object) "Setting Ryoba Blendshapes 2");
      this.MyRenderer = this.EightiesAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
      this.MyRenderer.SetBlendShapeWeight(0, 50f);
      this.MyRenderer.SetBlendShapeWeight(5, 25f);
      this.MyRenderer.SetBlendShapeWeight(8, 0.0f);
      this.MyRenderer.SetBlendShapeWeight(12, 100f);
      this.UpdateBlendshapes = false;
    }
    if (Input.GetKeyDown("m") && (UnityEngine.Object) this.Jukebox != (UnityEngine.Object) null)
    {
      if (this.Jukebox.isPlaying)
        this.Jukebox.Stop();
      else
        this.Jukebox.Play();
    }
    if (this.CanMove)
    {
      if ((UnityEngine.Object) this.InstructionLabel != (UnityEngine.Object) null)
        this.InstructionLabel.alpha = Mathf.MoveTowards(this.InstructionLabel.alpha, 1f, Time.deltaTime);
      if ((UnityEngine.Object) this.CameraTarget != (UnityEngine.Object) null)
        this.CameraTarget.localPosition = new Vector3(0.0f, (float) (1.0 + ((double) this.RPGCamera.distanceMax - (double) this.RPGCamera.distance) * 0.20000000298023224), 0.0f);
      if (this.InDesert && (double) this.transform.position.y < 13.699999809265137)
      {
        UnityEngine.Object.Instantiate<GameObject>(this.GroundImpact, this.transform.position + new Vector3(0.0f, 0.1f, 0.0f), Quaternion.identity);
        this.InDesert = false;
      }
      this.UpdateMovement();
      if (this.Pebbles > 0)
      {
        if (!this.Arc.gameObject.activeInHierarchy)
          this.Arc.Timer = 1f;
        this.Arc.gameObject.SetActive(Input.GetButton("X"));
        if (this.Arc.gameObject.activeInHierarchy)
        {
          this.ThrowButton.SetActive(true);
          this.AimButton.SetActive(false);
          if (Input.GetButtonDown("A"))
          {
            this.MyAudio.Play();
            Rigidbody component = UnityEngine.Object.Instantiate<GameObject>(this.Pebble, this.Arc.transform.position, this.transform.rotation).GetComponent<Rigidbody>();
            component.isKinematic = false;
            component.useGravity = true;
            component.AddRelativeForce(Vector3.up * 250f);
            component.AddRelativeForce(Vector3.forward * 250f);
            --this.Pebbles;
            this.UpdatePebbles();
            if (this.Pebbles < 1)
              this.Arc.gameObject.SetActive(false);
          }
        }
        else
        {
          this.ThrowButton.SetActive(false);
          this.AimButton.SetActive(true);
        }
      }
    }
    else
    {
      if ((UnityEngine.Object) this.InstructionLabel != (UnityEngine.Object) null)
        this.InstructionLabel.alpha = Mathf.MoveTowards(this.InstructionLabel.alpha, 0.0f, Time.deltaTime);
      if ((UnityEngine.Object) this.CameraTarget != (UnityEngine.Object) null)
      {
        if (this.Climbing)
        {
          if (this.ClimbPhase == 1)
          {
            this.CameraTarget.position = (double) this.MyAnimation["f02_climbTrellis_00"].time >= (double) this.MyAnimation["f02_climbTrellis_00"].length - 1.0 ? Vector3.MoveTowards(this.CameraTarget.position, new Vector3(-9.5f, 5f, -2.5f), Time.deltaTime) : Vector3.MoveTowards(this.CameraTarget.position, this.Hips.position + new Vector3(0.0f, 0.103729f, 0.003539f), Time.deltaTime);
            this.MoveTowardsTarget(this.TrellisClimbSpot.position);
            this.SpinTowardsTarget(this.TrellisClimbSpot.rotation);
            if ((double) this.MyAnimation["f02_climbTrellis_00"].time > 7.5)
            {
              this.RPGCamera.transform.position = this.EntryPOV.position;
              this.RPGCamera.transform.eulerAngles = this.EntryPOV.eulerAngles;
              this.RPGCamera.enabled = false;
              RenderSettings.ambientIntensity = 8f;
              ++this.ClimbPhase;
            }
          }
          else
          {
            this.RPGCamera.transform.position = this.EntryPOV.position;
            this.RPGCamera.transform.eulerAngles = this.EntryPOV.eulerAngles;
            if ((double) this.MyAnimation["f02_climbTrellis_00"].time > 11.0)
              this.transform.position = Vector3.MoveTowards(this.transform.position, this.TrellisClimbSpot.position + new Vector3(0.4f, 0.0f, 0.0f), Time.deltaTime * 0.5f);
          }
          if ((double) this.MyAnimation["f02_climbTrellis_00"].time > (double) this.MyAnimation["f02_climbTrellis_00"].length)
          {
            this.MyAnimation.Play("f02_idleShort_00");
            this.transform.position = new Vector3(-9.1f, 4f, -2.5f);
            this.CameraTarget.position = this.transform.position + new Vector3(0.0f, 1f, 0.0f);
            this.RPGCamera.enabled = true;
            this.Climbing = false;
            this.CanMove = true;
            Physics.SyncTransforms();
          }
        }
        else if (this.Chased)
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(this.Stalker.transform.position - this.transform.position), 10f * Time.deltaTime);
      }
    }
    if ((UnityEngine.Object) this.YandereFilter != (UnityEngine.Object) null)
      this.UpdateYandereVision();
    if (this.Street && (double) this.transform.position.x < -16.0)
      this.transform.position = new Vector3(-16f, 0.0f, this.transform.position.z);
    if ((UnityEngine.Object) this.Profile != (UnityEngine.Object) null)
    {
      if (this.Stance.Current == StanceType.Crouching && this.Hidden)
      {
        if ((double) this.Intensity != 1.0)
        {
          this.Intensity = Mathf.MoveTowards(this.Intensity, 1f, Time.deltaTime);
          this.UpdateVignette();
        }
      }
      else if ((double) this.Intensity != 0.44999998807907104)
      {
        this.Intensity = Mathf.MoveTowards(this.Intensity, 0.45f, Time.deltaTime);
        this.UpdateVignette();
      }
    }
    if (!((UnityEngine.Object) this.InstructionLabel != (UnityEngine.Object) null))
      return;
    if (this.InstructionPhase == 1)
    {
      if ((double) this.transform.position.z >= 11.0 || (double) this.transform.position.z <= -11.0 || (double) this.transform.position.x <= -11.0 || (double) this.transform.position.x >= 11.0)
        return;
      this.InstructionLabel.text = "Find the stalker's room on the first floor of the house.";
      ++this.InstructionPhase;
    }
    else if (this.InstructionPhase == 2)
    {
      if (!this.StalkerDoorPrompt.OpenDoor)
        return;
      this.InstructionLabel.text = "Pick up the pet carrier.";
      ++this.InstructionPhase;
    }
    else
    {
      if (this.InstructionPhase != 3 || !((UnityEngine.Object) this.Object != (UnityEngine.Object) null))
        return;
      this.InstructionLabel.text = "Exit the house.";
      ++this.InstructionPhase;
    }
  }

  private void UpdateMovement()
  {
    if (!OptionGlobals.ToggleRun)
    {
      this.Running = false;
      if (Input.GetButton("LB"))
        this.Running = true;
    }
    else if (Input.GetButtonDown("LB"))
      this.Running = !this.Running;
    int num1 = (int) this.MyController.Move(Physics.gravity * Time.deltaTime);
    float axis1 = Input.GetAxis("Vertical");
    float axis2 = Input.GetAxis("Horizontal");
    Vector3 vector3_1 = this.MainCamera.transform.TransformDirection(Vector3.forward) with
    {
      y = 0.0f
    };
    vector3_1 = vector3_1.normalized;
    Vector3 vector3_2 = new Vector3(vector3_1.z, 0.0f, -vector3_1.x);
    Vector3 forward = axis2 * vector3_2 + axis1 * vector3_1;
    Quaternion b = Quaternion.identity;
    if (forward != Vector3.zero)
      b = Quaternion.LookRotation(forward);
    if (forward != Vector3.zero)
      this.transform.rotation = Quaternion.Lerp(this.transform.rotation, b, Time.deltaTime * 10f);
    else
      b = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    if (!this.Street)
    {
      if (this.Stance.Current == StanceType.Standing)
      {
        if (Input.GetButtonDown("RS"))
        {
          this.Stance.Current = StanceType.Crouching;
          this.MyController.center = new Vector3(0.0f, 0.5f, 0.0f);
          this.MyController.height = 1f;
        }
      }
      else if (Input.GetButtonDown("RS"))
      {
        this.Stance.Current = StanceType.Standing;
        this.MyController.center = new Vector3(0.0f, 0.75f, 0.0f);
        this.MyController.height = 1.5f;
      }
    }
    if ((double) axis1 != 0.0 || (double) axis2 != 0.0)
    {
      if (this.Running)
      {
        if (this.Stance.Current == StanceType.Crouching)
        {
          this.MyAnimation.CrossFade(this.CrouchRunAnim);
          int num2 = (int) this.MyController.Move(this.transform.forward * this.CrouchRunSpeed * Time.deltaTime);
        }
        else
        {
          this.MyAnimation.CrossFade(this.RunAnim);
          int num3 = (int) this.MyController.Move(this.transform.forward * this.RunSpeed * Time.deltaTime);
        }
      }
      else if (this.Stance.Current == StanceType.Crouching)
      {
        this.MyAnimation.CrossFade(this.CrouchWalkAnim);
        int num4 = (int) this.MyController.Move(this.transform.forward * (this.CrouchWalkSpeed * Time.deltaTime));
      }
      else
      {
        this.MyAnimation.CrossFade(this.WalkAnim);
        int num5 = (int) this.MyController.Move(this.transform.forward * (this.WalkSpeed * Time.deltaTime));
      }
    }
    else if (this.Stance.Current == StanceType.Crouching)
      this.MyAnimation.CrossFade(this.CrouchIdleAnim);
    else
      this.MyAnimation.CrossFade(this.IdleAnim);
  }

  private void LateUpdate()
  {
    if (!((UnityEngine.Object) this.Object != (UnityEngine.Object) null))
      return;
    if ((UnityEngine.Object) this.RightArm != (UnityEngine.Object) null)
      this.RightArm.localEulerAngles = new Vector3(this.RightArm.localEulerAngles.x, this.RightArm.localEulerAngles.y + 15f, this.RightArm.localEulerAngles.z);
    this.Object.LookAt(this.ObjectTarget);
  }

  private void MoveTowardsTarget(Vector3 target)
  {
    int num = (int) this.MyController.Move((target - this.transform.position) * (Time.deltaTime * 10f));
  }

  private void SpinTowardsTarget(Quaternion target) => this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * 10f);

  public void UpdateVignette() => this.Profile.vignette.settings = this.Profile.vignette.settings with
  {
    color = new Color(0.0f, 0.0f, 0.0f, 1f),
    intensity = this.Intensity,
    smoothness = 0.2f,
    roundness = 1f
  };

  public void BeginStruggle()
  {
    this.MyAnimation.CrossFade("f02_struggleA_00");
    this.Struggling = true;
    this.Object.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    this.Object.gameObject.GetComponent<Rigidbody>().useGravity = true;
    this.Object.gameObject.GetComponent<Collider>().isTrigger = false;
    this.Object.parent = (Transform) null;
    this.Object = (Transform) null;
  }

  public void UpdateYandereVision()
  {
    if (this.CanMove & Input.GetButton("RB"))
    {
      if ((double) this.YandereFilter.FadeFX >= 1.0)
        return;
      if (!this.HighlightingR.enabled)
      {
        this.YandereFilter.enabled = true;
        this.HighlightingR.enabled = true;
        this.HighlightingB.enabled = true;
      }
      Time.timeScale = Mathf.Lerp(Time.timeScale, 0.5f, Time.unscaledDeltaTime * 10f);
      this.YandereFilter.FadeFX = Mathf.Lerp(this.YandereFilter.FadeFX, 1f, Time.unscaledDeltaTime * 10f);
      if ((double) this.YandereFilter.FadeFX != 1.0)
        return;
      Time.timeScale = 0.5f;
    }
    else
    {
      if ((double) this.YandereFilter.FadeFX <= 0.0)
        return;
      if (this.HighlightingR.enabled)
      {
        this.HighlightingR.enabled = false;
        this.HighlightingB.enabled = false;
      }
      Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.unscaledDeltaTime * 10f);
      this.YandereFilter.FadeFX = Mathf.Lerp(this.YandereFilter.FadeFX, 0.0f, Time.unscaledDeltaTime * 10f);
      if ((double) this.YandereFilter.FadeFX != 0.0)
        return;
      Time.timeScale = 1f;
    }
  }

  private void ResetYandereEffects()
  {
    this.HighlightingR.enabled = false;
    this.HighlightingB.enabled = false;
    this.YandereFilter.enabled = true;
    this.YandereFilter.FadeFX = 0.0f;
    Time.timeScale = 1f;
    this.Intensity = 0.0f;
    this.UpdateVignette();
  }

  public void UpdatePebbles()
  {
    if (!((UnityEngine.Object) this.PebbleIcon != (UnityEngine.Object) null))
      return;
    if (this.Pebbles == 0)
    {
      this.PebbleIcon.SetActive(false);
    }
    else
    {
      this.PebbleIcon.SetActive(true);
      this.PebbleLabel.text = "PEBBLES: " + this.Pebbles.ToString();
    }
  }

  public void VtuberCheck()
  {
    if (GameGlobals.VtuberID > 0)
    {
      for (int index = 1; index < this.OriginalHairs.Length; ++index)
        this.OriginalHairs[index].transform.localPosition = new Vector3(0.0f, 100f, 0.0f);
      this.VtuberHairs[GameGlobals.VtuberID].SetActive(true);
      if ((UnityEngine.Object) this.ClothingAttacher != (UnityEngine.Object) null && (UnityEngine.Object) this.ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer != (UnityEngine.Object) null)
      {
        this.MyRenderer = this.ClothingAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer;
        this.MyRenderer.materials[1].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
      }
      else
      {
        this.MyRenderer.materials[2].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
        for (int index = 0; index < 13; ++index)
          this.MyRenderer.SetBlendShapeWeight(index, 0.0f);
        this.MyRenderer.SetBlendShapeWeight(0, 100f);
        this.MyRenderer.SetBlendShapeWeight(9, 100f);
      }
      this.UpdateTextures = true;
      this.Vtuber = true;
    }
    else
      this.VtuberHairs[1].SetActive(false);
  }
}
