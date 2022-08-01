// Decompiled with JetBrains decompiler
// Type: YanvaniaYanmontScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof (CharacterController))]
public class YanvaniaYanmontScript : MonoBehaviour
{
  private GameObject NewBlood;
  public YanvaniaCameraScript YanvaniaCamera;
  public InputManagerScript InputManager;
  public YanvaniaDraculaScript Dracula;
  public Animation MyAnimation;
  public CharacterController MyController;
  public GameObject BossHealthBar;
  public GameObject LevelUpEffect;
  public GameObject DeathBlood;
  public GameObject Character;
  public GameObject BlackBG;
  public GameObject TextBox;
  public Renderer MyRenderer;
  public Transform TryAgainWindow;
  public Transform HealthBar;
  public Transform EXPBar;
  public Transform Hips;
  public Transform TrailStart;
  public Transform TrailEnd;
  public UITexture Photograph;
  public UILabel LevelLabel;
  public UISprite Darkness;
  public Collider[] SphereCollider;
  public Collider[] WhipCollider;
  public Transform[] WhipChain;
  public AudioClip[] Voices;
  public AudioClip[] Injuries;
  public AudioClip DeathSound;
  public AudioClip LandSound;
  public AudioClip WhipSound;
  public bool Attacking;
  public bool Crouching;
  public bool Dangling;
  public bool EnterCutscene;
  public bool Cutscene;
  public bool CanMove;
  public bool Injured;
  public bool Loose;
  public bool Red;
  public bool SpunUp;
  public bool SpunDown;
  public bool SpunRight;
  public bool SpunLeft;
  public float TargetRotation;
  public float Rotation;
  public float RecoveryTimer;
  public float DeathTimer;
  public float FlashTimer;
  public float IdleTimer;
  public float WhipTimer;
  public float TapTimer;
  public float PreviousY;
  public float MaxHealth = 100f;
  public float Health = 100f;
  public float EXP;
  public int Frames;
  public int Level;
  public int Taps;
  public float walkSpeed = 6f;
  public float runSpeed = 11f;
  public bool limitDiagonalSpeed = true;
  public bool toggleRun;
  public float jumpSpeed = 8f;
  public float gravity = 20f;
  public float fallingDamageThreshold = 10f;
  public bool slideWhenOverSlopeLimit;
  public bool slideOnTaggedObjects;
  public float slideSpeed = 12f;
  public bool airControl;
  public float antiBumpFactor = 0.75f;
  public int antiBunnyHopFactor = 1;
  private Vector3 moveDirection = Vector3.zero;
  public bool grounded;
  private CharacterController controller;
  private Transform myTransform;
  private float speed;
  private RaycastHit hit;
  private float fallStartLevel;
  private bool falling;
  private float slideLimit;
  private float rayDistance;
  private Vector3 contactPoint;
  private bool playerControl;
  private int jumpTimer;
  private float originalThreshold;
  public float inputX;
  public string DeathAnim = "f02_yanvaniaDeath_00";
  public string AttackAnim = "f02_yanvaniaAttack_00";
  public string CrouchAttackAnim = "f02_yanvaniaCrouchAttack_00";
  public string IdleAnim = "f02_yanvaniaIdle_00";
  public string DramaticIdleAnim = "f02_yanvaniaDramaticIdle_00";
  public string JumpAnim = "f02_yanvaniaJump_00";
  public string FallAnim = "f02_yanvaniaFall_00";
  public string CrouchAnim = "f02_yanvaniaCrouch_00";
  public string CrouchPoseAnim = "f02_yanvaniaCrouchPose_00";
  public string WalkAnim = "f02_yanvaniaWalk_00";
  public string RunAnim = "f02_yanvaniaRun_00";
  public string WhipNeutralAnim = "f02_yanvaniaWhip_Neutral";
  public string WhipUpAnim = "f02_yanvaniaWhip_Up";
  public string WhipRightAnim = "f02_yanvaniaWhip_Right";
  public string WhipDownAnim = "f02_yanvaniaWhip_Down";
  public string WhipLeftAnim = "f02_yanvaniaWhip_Left";

  private void Awake()
  {
    this.MyAnimation = this.Character.GetComponent<Animation>();
    this.MyAnimation[this.DeathAnim].speed = 0.25f;
    this.MyAnimation[this.AttackAnim].speed = 2f;
    this.MyAnimation[this.CrouchAttackAnim].speed = 2f;
    this.MyAnimation[this.WalkAnim].speed = 2.5f;
    this.MyAnimation[this.WhipNeutralAnim].speed = 0.0f;
    this.MyAnimation[this.WhipUpAnim].speed = 0.0f;
    this.MyAnimation[this.WhipRightAnim].speed = 0.0f;
    this.MyAnimation[this.WhipDownAnim].speed = 0.0f;
    this.MyAnimation[this.WhipLeftAnim].speed = 0.0f;
    this.MyAnimation[this.CrouchPoseAnim].layer = 1;
    this.MyAnimation.Play(this.CrouchPoseAnim);
    this.MyAnimation[this.CrouchPoseAnim].weight = 0.0f;
    Physics.IgnoreLayerCollision(19, 13, true);
    Physics.IgnoreLayerCollision(19, 19, true);
  }

  private void Start()
  {
    this.WhipChain[0].transform.localScale = Vector3.zero;
    this.MyAnimation.Play(this.IdleAnim);
    this.controller = this.GetComponent<CharacterController>();
    this.myTransform = this.transform;
    this.speed = this.walkSpeed;
    this.rayDistance = this.controller.height * 0.5f + this.controller.radius;
    this.slideLimit = this.controller.slopeLimit - 0.1f;
    this.jumpTimer = this.antiBunnyHopFactor;
    this.originalThreshold = this.fallingDamageThreshold;
  }

  private void FixedUpdate()
  {
    if (this.CanMove)
    {
      if (!this.Injured)
      {
        if (!this.Cutscene)
        {
          if (this.grounded)
          {
            if (!this.Attacking)
            {
              if (!this.Crouching)
                this.inputX = (double) Input.GetAxis("VaniaHorizontal") <= 0.0 ? ((double) Input.GetAxis("VaniaHorizontal") >= 0.0 ? 0.0f : -1f) : 1f;
            }
            else if (this.grounded)
            {
              this.fallingDamageThreshold = 100f;
              this.moveDirection.x = 0.0f;
              this.inputX = 0.0f;
              this.speed = 0.0f;
            }
          }
          else
            this.inputX = (double) Input.GetAxis("VaniaHorizontal") == 0.0 ? Mathf.MoveTowards(this.inputX, 0.0f, Time.deltaTime * 10f) : ((double) Input.GetAxis("VaniaHorizontal") <= 0.0 ? ((double) Input.GetAxis("VaniaHorizontal") >= 0.0 ? 0.0f : -1f) : 1f);
          float num1 = 0.0f;
          float num2 = (double) this.inputX == 0.0 || (double) num1 == 0.0 || !this.limitDiagonalSpeed ? 1f : 0.7071068f;
          if (!this.Attacking)
          {
            if ((double) Input.GetAxis("VaniaHorizontal") < 0.0)
            {
              this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, -90f, this.Character.transform.localEulerAngles.z);
              this.Character.transform.localScale = new Vector3(-1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
            }
            else if ((double) Input.GetAxis("VaniaHorizontal") > 0.0)
            {
              this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, 90f, this.Character.transform.localEulerAngles.z);
              this.Character.transform.localScale = new Vector3(1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
            }
          }
          if (this.grounded)
          {
            if (!this.Attacking && !this.Dangling)
            {
              if ((double) Input.GetAxis("VaniaVertical") < -0.5)
              {
                this.MyController.center = new Vector3(this.MyController.center.x, 0.5f, this.MyController.center.z);
                this.MyController.height = 1f;
                this.Crouching = true;
                this.IdleTimer = 10f;
                this.inputX = 0.0f;
              }
              if (this.Crouching)
              {
                this.MyAnimation.CrossFade(this.CrouchAnim, 0.1f);
                if (!this.Attacking)
                {
                  if (!this.Dangling)
                  {
                    if ((double) Input.GetAxis("VaniaVertical") > -0.5)
                    {
                      this.MyAnimation[this.CrouchPoseAnim].weight = 0.0f;
                      this.MyController.center = new Vector3(this.MyController.center.x, 0.75f, this.MyController.center.z);
                      this.MyController.height = 1.5f;
                      this.Crouching = false;
                    }
                  }
                  else if ((double) Input.GetAxis("VaniaVertical") > -0.5 && Input.GetButton("X"))
                  {
                    this.MyAnimation[this.CrouchPoseAnim].weight = 0.0f;
                    this.MyController.center = new Vector3(this.MyController.center.x, 0.75f, this.MyController.center.z);
                    this.MyController.height = 1.5f;
                    this.Crouching = false;
                  }
                }
              }
              else if ((double) this.inputX == 0.0)
              {
                if ((double) this.IdleTimer > 0.0)
                {
                  this.MyAnimation.CrossFade(this.IdleAnim, 0.1f);
                  this.MyAnimation[this.IdleAnim].speed = this.IdleTimer / 10f;
                }
                else
                  this.MyAnimation.CrossFade(this.DramaticIdleAnim, 1f);
                this.IdleTimer -= Time.deltaTime;
              }
              else
              {
                this.IdleTimer = 10f;
                this.MyAnimation.CrossFade((double) this.speed == (double) this.walkSpeed ? this.WalkAnim : this.RunAnim, 0.1f);
              }
            }
            bool flag = false;
            if (Physics.Raycast(this.myTransform.position, -Vector3.up, out this.hit, this.rayDistance))
            {
              if ((double) Vector3.Angle(this.hit.normal, Vector3.up) > (double) this.slideLimit)
                flag = true;
            }
            else
            {
              Physics.Raycast(this.contactPoint + Vector3.up, -Vector3.up, out this.hit);
              if ((double) Vector3.Angle(this.hit.normal, Vector3.up) > (double) this.slideLimit)
                flag = true;
            }
            if (this.falling)
            {
              this.falling = false;
              if ((double) this.myTransform.position.y < (double) this.fallStartLevel - (double) this.fallingDamageThreshold)
                this.FallingDamageAlert(this.fallStartLevel - this.myTransform.position.y);
              this.fallingDamageThreshold = this.originalThreshold;
            }
            if (!this.toggleRun)
              this.speed = Input.GetKey(KeyCode.LeftShift) ? this.runSpeed : this.walkSpeed;
            if (flag && this.slideWhenOverSlopeLimit || this.slideOnTaggedObjects && this.hit.collider.tag == "Slide")
            {
              Vector3 normal = this.hit.normal;
              this.moveDirection = new Vector3(normal.x, -normal.y, normal.z);
              Vector3.OrthoNormalize(ref normal, ref this.moveDirection);
              this.moveDirection *= this.slideSpeed;
              this.playerControl = false;
            }
            else
            {
              this.moveDirection = new Vector3(this.inputX * num2, -this.antiBumpFactor, num1 * num2);
              this.moveDirection = this.myTransform.TransformDirection(this.moveDirection) * this.speed;
              this.playerControl = true;
            }
            if (!Input.GetButton("VaniaJump"))
              ++this.jumpTimer;
            else if (this.jumpTimer >= this.antiBunnyHopFactor && !this.Attacking)
            {
              this.Crouching = false;
              this.fallingDamageThreshold = 0.0f;
              this.moveDirection.y = this.jumpSpeed;
              this.IdleTimer = 10f;
              this.jumpTimer = 0;
              AudioSource component = this.GetComponent<AudioSource>();
              component.clip = this.Voices[Random.Range(0, this.Voices.Length)];
              component.Play();
            }
          }
          else
          {
            if (!this.Attacking)
              this.MyAnimation.CrossFade((double) this.transform.position.y > (double) this.PreviousY ? this.JumpAnim : this.FallAnim, 0.4f);
            this.PreviousY = this.transform.position.y;
            if (!this.falling)
            {
              this.falling = true;
              this.fallStartLevel = this.myTransform.position.y;
            }
            if (this.airControl && this.playerControl)
            {
              this.moveDirection.x = this.inputX * this.speed * num2;
              this.moveDirection.z = num1 * this.speed * num2;
              this.moveDirection = this.myTransform.TransformDirection(this.moveDirection);
            }
          }
        }
        else
        {
          this.moveDirection.x = 0.0f;
          if (this.grounded)
          {
            if ((double) this.transform.position.x > -34.0)
            {
              this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, -90f, this.Character.transform.localEulerAngles.z);
              this.Character.transform.localScale = new Vector3(1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
              this.transform.position = new Vector3(Mathf.MoveTowards(this.transform.position.x, -34f, Time.deltaTime * this.walkSpeed), this.transform.position.y, this.transform.position.z);
              this.MyAnimation.CrossFade(this.WalkAnim);
            }
            else if ((double) this.transform.position.x < -34.0)
            {
              this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, 90f, this.Character.transform.localEulerAngles.z);
              this.Character.transform.localScale = new Vector3(-1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
              this.transform.position = new Vector3(Mathf.MoveTowards(this.transform.position.x, -34f, Time.deltaTime * this.walkSpeed), this.transform.position.y, this.transform.position.z);
              this.MyAnimation.CrossFade(this.WalkAnim);
            }
            else
            {
              this.MyAnimation.CrossFade(this.DramaticIdleAnim, 1f);
              this.Character.transform.localEulerAngles = new Vector3(this.Character.transform.localEulerAngles.x, -90f, this.Character.transform.localEulerAngles.z);
              this.Character.transform.localScale = new Vector3(1f, this.Character.transform.localScale.y, this.Character.transform.localScale.z);
              this.WhipChain[0].transform.localScale = Vector3.zero;
              this.fallingDamageThreshold = 100f;
              this.TextBox.SetActive(true);
              this.Attacking = false;
              this.enabled = false;
            }
          }
          Physics.SyncTransforms();
        }
      }
      else
      {
        this.MyAnimation.CrossFade("f02_damage_25");
        this.RecoveryTimer += Time.deltaTime;
        if ((double) this.RecoveryTimer > 1.0)
        {
          this.RecoveryTimer = 0.0f;
          this.Injured = false;
        }
      }
      this.moveDirection.y -= this.gravity * Time.deltaTime;
      this.grounded = (this.controller.Move(this.moveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
      if (this.grounded && this.EnterCutscene)
      {
        this.YanvaniaCamera.Cutscene = true;
        this.Cutscene = true;
      }
      if ((this.controller.collisionFlags & CollisionFlags.Above) == CollisionFlags.None || (double) this.moveDirection.y <= 0.0)
        return;
      this.moveDirection.y = 0.0f;
    }
    else
    {
      if ((double) this.Health != 0.0)
        return;
      this.DeathTimer += Time.deltaTime;
      if ((double) this.DeathTimer <= 5.0)
        return;
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime * 0.2f);
      if ((double) this.Darkness.color.a < 1.0)
        return;
      if (this.Darkness.gameObject.activeInHierarchy)
      {
        this.HealthBar.parent.gameObject.SetActive(false);
        this.EXPBar.parent.gameObject.SetActive(false);
        this.Darkness.gameObject.SetActive(false);
        this.BossHealthBar.SetActive(false);
        this.BlackBG.SetActive(true);
      }
      this.TryAgainWindow.transform.localScale = Vector3.Lerp(this.TryAgainWindow.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
    }
  }

  private void Update()
  {
    Animation component1 = this.Character.GetComponent<Animation>();
    if (!this.Injured && this.CanMove && !this.Cutscene)
    {
      if (this.grounded)
      {
        if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
        {
          this.TapTimer = 0.25f;
          ++this.Taps;
        }
        if (this.Taps > 1)
          this.speed = this.runSpeed;
      }
      if ((double) this.inputX == 0.0)
        this.speed = this.walkSpeed;
      this.TapTimer -= Time.deltaTime;
      if ((double) this.TapTimer < 0.0)
        this.Taps = 0;
      if (Input.GetButtonDown("VaniaAttack") && !this.Attacking)
      {
        AudioSource.PlayClipAtPoint(this.WhipSound, this.transform.position);
        AudioSource component2 = this.GetComponent<AudioSource>();
        component2.clip = this.Voices[Random.Range(0, this.Voices.Length)];
        component2.Play();
        this.WhipChain[0].transform.localScale = Vector3.zero;
        this.Attacking = true;
        this.IdleTimer = 10f;
        if (this.Crouching)
        {
          component1[this.CrouchAttackAnim].time = 0.0f;
          component1.Play(this.CrouchAttackAnim);
        }
        else
        {
          component1[this.AttackAnim].time = 0.0f;
          component1.Play(this.AttackAnim);
        }
        if (this.grounded)
        {
          this.moveDirection.x = 0.0f;
          this.inputX = 0.0f;
          this.speed = 0.0f;
        }
      }
      if (this.Attacking)
      {
        if (!this.Dangling)
        {
          this.WhipChain[0].transform.localScale = Vector3.MoveTowards(this.WhipChain[0].transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f);
          this.StraightenWhip();
        }
        else
        {
          this.LoosenWhip();
          if ((double) Input.GetAxis("VaniaHorizontal") > -0.5 && (double) Input.GetAxis("VaniaHorizontal") < 0.5 && (double) Input.GetAxis("VaniaVertical") > -0.5 && (double) Input.GetAxis("VaniaVertical") < 0.5)
          {
            component1.CrossFade(this.WhipNeutralAnim);
            if (this.Crouching)
              component1[this.CrouchPoseAnim].weight = 1f;
            this.SpunUp = false;
            this.SpunDown = false;
            this.SpunRight = false;
            this.SpunLeft = false;
          }
          else
          {
            if ((double) Input.GetAxis("VaniaVertical") > 0.5)
            {
              if (!this.SpunUp)
              {
                AudioClipPlayer.Play2D(this.WhipSound, this.transform.position, Random.Range(0.9f, 1.1f));
                this.StraightenWhip();
                this.TargetRotation = -360f;
                this.Rotation = 0.0f;
                this.SpunUp = true;
              }
              component1.CrossFade(this.WhipUpAnim, 0.1f);
            }
            else
              this.SpunUp = false;
            if ((double) Input.GetAxis("VaniaVertical") < -0.5)
            {
              if (!this.SpunDown)
              {
                AudioClipPlayer.Play2D(this.WhipSound, this.transform.position, Random.Range(0.9f, 1.1f));
                this.StraightenWhip();
                this.TargetRotation = 360f;
                this.Rotation = 0.0f;
                this.SpunDown = true;
              }
              component1.CrossFade(this.WhipDownAnim, 0.1f);
            }
            else
              this.SpunDown = false;
            if ((double) Input.GetAxis("VaniaHorizontal") > 0.5)
            {
              if ((double) this.Character.transform.localScale.x == 1.0)
                this.SpinLeft();
              else
                this.SpinRight();
            }
            else if ((double) this.Character.transform.localScale.x == 1.0)
              this.SpunLeft = false;
            else
              this.SpunRight = false;
            if ((double) Input.GetAxis("VaniaHorizontal") < -0.5)
            {
              if ((double) this.Character.transform.localScale.x == 1.0)
                this.SpinRight();
              else
                this.SpinLeft();
            }
            else if ((double) this.Character.transform.localScale.x == 1.0)
              this.SpunRight = false;
            else
              this.SpunLeft = false;
          }
          this.Rotation = Mathf.MoveTowards(this.Rotation, this.TargetRotation, (float) ((double) Time.deltaTime * 3600.0 * 0.5));
          this.WhipChain[1].transform.localEulerAngles = new Vector3(0.0f, 0.0f, this.Rotation);
          if (!Input.GetButton("VaniaAttack"))
            this.StopAttacking();
        }
      }
      else
      {
        if (this.WhipCollider[1].enabled)
        {
          for (int index = 1; index < this.WhipChain.Length; ++index)
          {
            this.SphereCollider[index].enabled = false;
            this.WhipCollider[index].enabled = false;
          }
        }
        this.WhipChain[0].transform.localScale = Vector3.MoveTowards(this.WhipChain[0].transform.localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      if (!this.Crouching && (double) component1[this.AttackAnim].time >= (double) component1[this.AttackAnim].length || this.Crouching && (double) component1[this.CrouchAttackAnim].time >= (double) component1[this.CrouchAttackAnim].length)
      {
        if (Input.GetButton("VaniaAttack"))
        {
          if (this.Crouching)
            component1[this.CrouchPoseAnim].weight = 1f;
          this.Dangling = true;
        }
        else
          this.StopAttacking();
      }
    }
    if ((double) this.FlashTimer > 0.0)
    {
      this.FlashTimer -= Time.deltaTime;
      if (!this.Red)
      {
        foreach (Material material in this.MyRenderer.materials)
          material.color = new Color(1f, 0.0f, 0.0f, 1f);
        ++this.Frames;
        if (this.Frames == 5)
        {
          this.Frames = 0;
          this.Red = true;
        }
      }
      else
      {
        foreach (Material material in this.MyRenderer.materials)
          material.color = new Color(1f, 1f, 1f, 1f);
        ++this.Frames;
        if (this.Frames == 5)
        {
          this.Frames = 0;
          this.Red = false;
        }
      }
    }
    else
    {
      this.FlashTimer = 0.0f;
      if (this.MyRenderer.materials[0].color != new Color(1f, 1f, 1f, 1f))
      {
        foreach (Material material in this.MyRenderer.materials)
          material.color = new Color(1f, 1f, 1f, 1f);
      }
    }
    this.HealthBar.localScale = new Vector3(this.HealthBar.localScale.x, Mathf.Lerp(this.HealthBar.localScale.y, this.Health / this.MaxHealth, Time.deltaTime * 10f), this.HealthBar.localScale.z);
    if ((double) this.Health > 0.0)
    {
      if ((double) this.EXP >= 100.0)
      {
        ++this.Level;
        if (this.Level >= 99)
        {
          this.Level = 99;
        }
        else
        {
          Object.Instantiate<GameObject>(this.LevelUpEffect, this.LevelLabel.transform.position, Quaternion.identity).transform.parent = this.LevelLabel.transform;
          this.MaxHealth += 20f;
          this.Health = this.MaxHealth;
          this.EXP -= 100f;
        }
        this.LevelLabel.text = this.Level.ToString();
      }
      this.EXPBar.localScale = new Vector3(this.EXPBar.localScale.x, Mathf.Lerp(this.EXPBar.localScale.y, this.EXP / 100f, Time.deltaTime * 10f), this.EXPBar.localScale.z);
    }
    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f);
    if (Input.GetKeyDown(KeyCode.BackQuote))
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      this.transform.position = new Vector3(-31.75f, 6.51f, 0.0f);
      Physics.SyncTransforms();
    }
    if (Input.GetKeyDown(KeyCode.Alpha5))
    {
      this.Level = 5;
      this.LevelLabel.text = this.Level.ToString();
    }
    if (Input.GetKeyDown(KeyCode.Equals))
      Time.timeScale += 10f;
    if (!Input.GetKeyDown(KeyCode.Minus))
      return;
    Time.timeScale -= 10f;
    if ((double) Time.timeScale >= 0.0)
      return;
    Time.timeScale = 1f;
  }

  private void LateUpdate()
  {
  }

  private void OnControllerColliderHit(ControllerColliderHit hit) => this.contactPoint = this.hit.point;

  private void FallingDamageAlert(float fallDistance)
  {
    AudioClipPlayer.Play2D(this.LandSound, this.transform.position, Random.Range(0.9f, 1.1f));
    this.Character.GetComponent<Animation>().Play(this.CrouchAnim);
    this.fallingDamageThreshold = this.originalThreshold;
  }

  private void SpinRight()
  {
    if (!this.SpunRight)
    {
      AudioClipPlayer.Play2D(this.WhipSound, this.transform.position, Random.Range(0.9f, 1.1f));
      this.StraightenWhip();
      this.TargetRotation = 360f;
      this.Rotation = 0.0f;
      this.SpunRight = true;
    }
    this.Character.GetComponent<Animation>().CrossFade(this.WhipRightAnim, 0.1f);
  }

  private void SpinLeft()
  {
    if (!this.SpunLeft)
    {
      AudioClipPlayer.Play2D(this.WhipSound, this.transform.position, Random.Range(0.9f, 1.1f));
      this.StraightenWhip();
      this.TargetRotation = -360f;
      this.Rotation = 0.0f;
      this.SpunLeft = true;
    }
    this.Character.GetComponent<Animation>().CrossFade(this.WhipLeftAnim, 0.1f);
  }

  private void StraightenWhip()
  {
    for (int index = 1; index < this.WhipChain.Length; ++index)
    {
      this.WhipCollider[index].enabled = true;
      this.WhipChain[index].gameObject.GetComponent<Rigidbody>().isKinematic = true;
      Transform transform = this.WhipChain[index].transform;
      transform.localPosition = new Vector3(0.0f, -0.03f, 0.0f);
      transform.localEulerAngles = Vector3.zero;
    }
    this.WhipChain[1].transform.localPosition = new Vector3(0.0f, -0.1f, 0.0f);
    this.WhipTimer = 0.0f;
    this.Loose = false;
  }

  private void LoosenWhip()
  {
    if (this.Loose)
      return;
    this.WhipTimer += Time.deltaTime;
    if ((double) this.WhipTimer <= 0.25)
      return;
    for (int index = 1; index < this.WhipChain.Length; ++index)
    {
      this.WhipChain[index].gameObject.GetComponent<Rigidbody>().isKinematic = false;
      this.SphereCollider[index].enabled = true;
    }
    this.Loose = true;
  }

  private void StopAttacking()
  {
    this.Character.GetComponent<Animation>()[this.CrouchPoseAnim].weight = 0.0f;
    this.TargetRotation = 0.0f;
    this.Rotation = 0.0f;
    this.Attacking = false;
    this.Dangling = false;
    this.SpunUp = false;
    this.SpunDown = false;
    this.SpunRight = false;
    this.SpunLeft = false;
  }

  public void TakeDamage(int Damage)
  {
    if (this.WhipCollider[1].enabled)
    {
      for (int index = 1; index < this.WhipChain.Length; ++index)
      {
        this.SphereCollider[index].enabled = false;
        this.WhipCollider[index].enabled = false;
      }
    }
    AudioSource component1 = this.GetComponent<AudioSource>();
    component1.clip = this.Injuries[Random.Range(0, this.Injuries.Length)];
    component1.Play();
    this.WhipChain[0].transform.localScale = Vector3.zero;
    Animation component2 = this.Character.GetComponent<Animation>();
    component2["f02_damage_25"].time = 0.0f;
    this.fallingDamageThreshold = 100f;
    this.moveDirection.x = 0.0f;
    this.RecoveryTimer = 0.0f;
    this.FlashTimer = 2f;
    this.Injured = true;
    this.StopAttacking();
    this.Health -= (float) Damage;
    if ((double) this.Dracula.Health <= 0.0)
      this.Health = 1f;
    if ((double) this.Dracula.Health <= 0.0 || (double) this.Health > 0.0)
      return;
    if ((Object) this.NewBlood == (Object) null)
    {
      this.MyController.enabled = false;
      this.YanvaniaCamera.StopMusic = true;
      component1.clip = this.DeathSound;
      component1.Play();
      this.NewBlood = Object.Instantiate<GameObject>(this.DeathBlood, this.transform.position, Quaternion.identity);
      this.NewBlood.transform.parent = this.Hips;
      this.NewBlood.transform.localPosition = Vector3.zero;
      component2.CrossFade(this.DeathAnim);
      this.CanMove = false;
    }
    this.Health = 0.0f;
  }
}
