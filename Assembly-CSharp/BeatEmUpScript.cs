// Decompiled with JetBrains decompiler
// Type: BeatEmUpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class BeatEmUpScript : MonoBehaviour
{
  public CharacterController MyController;
  public BeatEmUpEnemyScript[] AllEnemies;
  public PostProcessingProfile Profile;
  public BeatEmUpEnemyScript Enemy;
  public RPG_Camera RPGCamera;
  public AudioClip[] AttackVoices;
  public AudioClip[] PainVoices;
  public Transform EnemyHealthBar;
  public Transform HealthBar;
  public Transform SuperBar;
  public AudioSource MySecondAudio;
  public AudioSource MyAudio;
  public AudioSource Music;
  public AudioClip EightiesTrack;
  public UILabel EnemyNameLabel;
  public UILabel GrowingLabel;
  public UILabel VictoryLabel;
  public UILabel HealthLabel;
  public UILabel SuperLabel;
  public Animation MyAnimation;
  public UIPanel GameplayPanel;
  public UISprite SuperButton;
  public GameObject PauseLabel;
  public GameObject HitEffect;
  public GameObject Hitbox;
  public Transform MainCamera;
  public Transform Ring;
  public Transform RightBreast;
  public Transform LeftBreast;
  public Transform RightFoot;
  public Transform RightHand;
  public Transform LeftHand;
  public AudioClip MusicLoop;
  public AudioClip HitSFX;
  public AudioClip Whoosh;
  public UISprite Darkness;
  public UISprite White;
  public int RollDirection = 1;
  public int AttackLimit;
  public int Difficulty = 1;
  public int AttackID = 1;
  public int Enemies = 2;
  public int TextID = 1;
  public bool HitboxSpawned;
  public bool HitReacting;
  public bool Attacking;
  public bool Defeated;
  public bool Eighties;
  public bool CanMove;
  public bool Rolling;
  public bool Victory;
  public bool Super;
  public bool Combo;
  public bool Heavy;
  public bool Intro;
  public string[] GrowingText;
  public string[] AttackAnim;
  public float[] Damages;
  public float CameraVibrate;
  public float MaxRollSpeed;
  public float CameraSpeed;
  public float IntroTimer;
  public float SuperTimer;
  public float RollSpeed;
  public float RollTimer;
  public float RunSpeed;
  public float MaxHealth;
  public float Health;
  public float SuperMeter;
  public float MaxSuper;
  public string HitReactAnim;
  public string DefeatAnim;
  public string SuperAnim;
  public string IdleAnim;
  public string RollAnim;
  public string RunAnim;
  public Renderer PonytailRenderer;
  public Texture EightiesUniformTexture;
  public Texture BlondeTexture;
  public AudioClip[] DialogueClips;
  public string[] DialogueText;
  public AudioSource Dialogue;
  public UILabel Subtitle;
  public int CutsceneID;
  public bool Cutscene;
  public GameObject IncineratorScene;
  public GameObject StreetScene;
  public SkinnedMeshRenderer MyRenderer;
  public Texture[] UniformTextures;
  public Texture FaceTexture;
  public Mesh[] Uniforms;
  public GameObject RyobaHair;

  private void Start()
  {
    this.Difficulty = GameGlobals.BeatEmUpDifficulty;
    this.MyAnimation[this.AttackAnim[1]].speed = 1f;
    this.MyAnimation[this.AttackAnim[2]].speed = 1f;
    this.MyAnimation[this.AttackAnim[3]].speed = 1f;
    this.MaxHealth -= (float) (this.Difficulty * 20);
    this.Health = this.MaxHealth;
    this.HealthLabel.text = this.Health.ToString() + " / " + this.MaxHealth.ToString();
    this.MainCamera.transform.position = new Vector3(-1f, 0.742f, 3f);
    this.MainCamera.transform.eulerAngles = new Vector3(0.0f, 15f, 0.0f);
    this.SuperLabel.text = this.SuperMeter.ToString() + " / " + this.MaxSuper.ToString();
    this.SuperBar.transform.localScale = new Vector3(0.0f, 1f, 1f);
    this.GrowingLabel.transform.localScale = Vector3.zero;
    this.GrowingLabel.alpha = 0.0f;
    this.GrowingLabel.text = this.GrowingText[1];
    this.GameplayPanel.alpha = 0.0f;
    this.Darkness.alpha = 1f;
    Time.timeScale = 1f;
    for (int index = 1; index < this.AllEnemies.Length; ++index)
    {
      this.AllEnemies[index].DisableWeapon();
      this.AllEnemies[index].Start();
    }
    if (GameGlobals.BlondeHair)
      this.PonytailRenderer.material.mainTexture = this.BlondeTexture;
    if (GameGlobals.Eighties)
    {
      this.FaceTexture = this.RyobaHair.GetComponent<Renderer>().material.mainTexture;
      this.RyobaHair.transform.parent.gameObject.SetActive(true);
      this.PonytailRenderer.gameObject.SetActive(false);
      this.Music.Stop();
      this.Dialogue.clip = this.DialogueClips[this.CutsceneID];
      this.Dialogue.Play();
      this.Subtitle.text = this.DialogueText[this.CutsceneID];
      this.Cutscene = true;
      this.IncineratorScene.SetActive(false);
      this.StreetScene.SetActive(true);
      this.RightBreast.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
      this.LeftBreast.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
      this.Eighties = true;
    }
    else
      this.RyobaHair.transform.parent.gameObject.SetActive(false);
    this.ChangeSchoolwear();
    this.Profile.motionBlur.enabled = false;
    this.UpdateDOF(2f);
  }

  private void ChangeSchoolwear()
  {
    this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
    this.MyRenderer.materials[0].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
    this.MyRenderer.materials[1].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    if (!this.Eighties)
      return;
    this.MyRenderer.materials[0].mainTexture = this.EightiesUniformTexture;
  }

  private void Update()
  {
    if (!this.Victory)
    {
      if (!this.Intro)
      {
        this.GetNearestEnemy();
        this.EnemyHealthBar.localScale = new Vector3(this.Enemy.Health / this.Enemy.MaxHealth, 1f, 1f);
        this.EnemyNameLabel.text = this.Enemy.Name;
      }
      int num1 = (int) this.MyController.Move(Physics.gravity * Time.deltaTime);
      float axis1 = Input.GetAxis("Vertical");
      float axis2 = Input.GetAxis("Horizontal");
      Vector3 vector3_1 = this.MainCamera.TransformDirection(Vector3.forward) with
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
      {
        if (this.CanMove)
          this.transform.rotation = Quaternion.Lerp(this.transform.rotation, b, Time.deltaTime * 10f);
      }
      else
        b = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
      if ((this.CanMove || !this.CanMove && this.Attacking) && Input.GetButtonDown("A"))
      {
        this.Attacking = false;
        this.CanMove = false;
        this.Rolling = true;
        this.RollSpeed = this.MaxRollSpeed;
        if (forward != Vector3.zero)
        {
          this.transform.rotation = Quaternion.LookRotation(forward);
          this.RollDirection = 1;
        }
        else
          this.RollDirection = -1;
        int num2 = (int) this.MyController.Move(this.transform.forward * this.RollSpeed * (float) this.RollDirection * Time.deltaTime);
        this.MyAnimation[this.RollAnim].speed = 0.0f;
        this.MyAnimation[this.RollAnim].time = 0.0f;
        this.MyAnimation.CrossFade(this.RollAnim);
      }
      if (this.CanMove)
      {
        if ((double) axis1 != 0.0 || (double) axis2 != 0.0)
        {
          this.MyAnimation.CrossFade(this.RunAnim);
          int num3 = (int) this.MyController.Move(this.transform.forward * this.RunSpeed * Time.deltaTime);
        }
        else
          this.MyAnimation.CrossFade(this.IdleAnim);
        if (Input.GetButtonDown("X") || Input.GetButtonDown("Y"))
        {
          this.MyAudio.clip = this.AttackVoices[Random.Range(1, this.AttackVoices.Length)];
          this.MyAudio.Play();
          this.MySecondAudio.clip = this.Whoosh;
          this.MySecondAudio.pitch = Random.Range(0.9f, 1.1f);
          this.MySecondAudio.Play();
          this.HitboxSpawned = false;
          this.Attacking = true;
          this.CanMove = false;
          this.Heavy = false;
          this.transform.rotation = Quaternion.LookRotation(this.Enemy.transform.position - this.transform.position);
          if (Input.GetButtonDown("Y"))
            this.Heavy = true;
          if (!this.Heavy)
          {
            this.AttackID = 1;
            this.AttackLimit = 7;
          }
          else
          {
            this.AttackID = 11;
            this.AttackLimit = 14;
          }
          this.MyAnimation[this.AttackAnim[this.AttackID]].time = 0.0f;
          this.MyAnimation.Play(this.AttackAnim[this.AttackID]);
        }
        else if ((double) this.SuperMeter >= 100.0 && Input.GetButtonDown("B"))
        {
          this.MyAudio.clip = this.AttackVoices[Random.Range(1, this.AttackVoices.Length)];
          this.MyAudio.Play();
          this.MySecondAudio.clip = this.Whoosh;
          this.MySecondAudio.pitch = Random.Range(0.9f, 1.1f);
          this.MySecondAudio.Play();
          this.MyController.enabled = false;
          this.HitboxSpawned = false;
          this.CanMove = false;
          this.Super = true;
          this.SuperMeter -= 100f;
          this.SuperLabel.text = this.SuperMeter.ToString() + " / " + this.MaxSuper.ToString();
          this.SuperBar.transform.localScale = new Vector3(this.SuperMeter / this.MaxSuper, 1f, 1f);
          if ((double) this.SuperMeter < 100.0)
            this.SuperButton.alpha = 0.5f;
          this.transform.rotation = Quaternion.LookRotation(this.Enemy.transform.position - this.transform.position);
          this.MyAnimation[this.SuperAnim].time = 0.0f;
          this.MyAnimation.Play(this.SuperAnim);
        }
      }
      else if (this.Rolling)
      {
        this.RollSpeed = this.MaxRollSpeed * (float) (1.0 - (double) this.RollTimer / (double) this.MyAnimation[this.RollAnim].length);
        int num4 = (int) this.MyController.Move(this.transform.forward * this.RollSpeed * (float) this.RollDirection * Time.deltaTime);
        this.RollTimer += Time.deltaTime * 2f;
        this.MyAnimation[this.RollAnim].time = this.RollDirection <= 0 ? this.MyAnimation[this.RollAnim].length - this.RollTimer : this.RollTimer;
        if ((double) this.RollTimer >= (double) this.MyAnimation[this.RollAnim].length)
        {
          this.MyAnimation.CrossFade(this.IdleAnim);
          this.MyAnimation[this.RollAnim].speed = 0.0f;
          this.Rolling = false;
          this.CanMove = true;
          this.RollTimer = 0.0f;
        }
      }
      else if (this.Attacking)
      {
        if ((double) this.MyAnimation[this.AttackAnim[this.AttackID]].time >= (double) this.MyAnimation[this.AttackAnim[this.AttackID]].length)
        {
          this.MyAnimation.CrossFade(this.IdleAnim);
          this.Attacking = false;
          this.CanMove = true;
        }
        else if ((double) this.MyAnimation[this.AttackAnim[this.AttackID]].time >= (double) this.MyAnimation[this.AttackAnim[this.AttackID]].length * 0.5)
        {
          if (this.Combo)
          {
            this.transform.LookAt(this.Ring.position);
            this.MyAudio.clip = this.AttackVoices[Random.Range(1, this.AttackVoices.Length)];
            this.MyAudio.Play();
            this.MySecondAudio.clip = this.Whoosh;
            this.MySecondAudio.pitch = Random.Range(0.9f, 1.1f);
            this.MySecondAudio.Play();
            ++this.AttackID;
            this.MyAnimation[this.AttackAnim[this.AttackID]].time = 0.0f;
            this.MyAnimation.Play(this.AttackAnim[this.AttackID]);
            this.HitboxSpawned = false;
            this.Combo = false;
          }
          else if (this.AttackID < this.AttackLimit)
          {
            if (!this.Heavy && Input.GetButtonDown("X"))
              this.Combo = true;
            else if (this.Heavy && Input.GetButtonDown("Y"))
              this.Combo = true;
          }
        }
        else if (this.AttackID < this.AttackLimit)
        {
          if (!this.Heavy && Input.GetButtonDown("X"))
            this.Combo = true;
          else if (this.Heavy && Input.GetButtonDown("Y"))
            this.Combo = true;
        }
        if (!this.HitboxSpawned)
        {
          if (this.AttackID < 14)
          {
            if ((double) this.MyAnimation[this.AttackAnim[this.AttackID]].time >= (double) this.MyAnimation[this.AttackAnim[this.AttackID]].length * 0.40000000596046448)
            {
              if (!this.Heavy)
              {
                BeatEmUpHitboxScript component = Object.Instantiate<GameObject>(this.Hitbox, this.transform.position + this.transform.forward * 0.45f + new Vector3(0.0f, 1f, 0.0f), this.transform.rotation).GetComponent<BeatEmUpHitboxScript>();
                component.Damage = this.Damages[this.AttackID];
                component.AttackID = this.AttackID;
              }
              else
              {
                BeatEmUpHitboxScript component = Object.Instantiate<GameObject>(this.Hitbox, this.transform.position + this.transform.forward * 0.75f + new Vector3(0.0f, 1f, 0.0f), this.transform.rotation).GetComponent<BeatEmUpHitboxScript>();
                component.Damage = this.Damages[this.AttackID];
                component.Heavy = true;
              }
              this.HitboxSpawned = true;
            }
          }
          else if (this.AttackID == 14 && (double) this.MyAnimation[this.AttackAnim[this.AttackID]].time >= 0.52499997615814209)
          {
            BeatEmUpHitboxScript component = Object.Instantiate<GameObject>(this.Hitbox, this.transform.position + this.transform.forward * 0.75f + new Vector3(0.0f, 1f, 0.0f), this.transform.rotation).GetComponent<BeatEmUpHitboxScript>();
            component.Damage = this.Damages[this.AttackID];
            component.AttackID = this.AttackID;
            component.Heavy = true;
            this.HitboxSpawned = true;
          }
        }
      }
      else if (this.Super)
      {
        this.IntroTimer += Time.deltaTime;
        this.SuperTimer += Time.deltaTime;
        if ((double) this.IntroTimer > 0.10000000149011612)
        {
          this.MyAudio.clip = this.AttackVoices[Random.Range(1, this.AttackVoices.Length)];
          this.MyAudio.Play();
          this.MySecondAudio.clip = this.Whoosh;
          this.MySecondAudio.pitch = Random.Range(0.9f, 1.1f);
          this.MySecondAudio.Play();
          BeatEmUpHitboxScript component = Object.Instantiate<GameObject>(this.Hitbox, this.transform.position + this.transform.forward * 0.45f + new Vector3(0.0f, 1f, 0.0f), this.transform.rotation).GetComponent<BeatEmUpHitboxScript>();
          component.Super = true;
          component.Damage = 5f;
          this.IntroTimer = 0.0f;
        }
        if ((double) this.SuperTimer > 2.0999999046325684)
        {
          this.MyController.enabled = true;
          this.CanMove = true;
          this.Super = false;
          this.IntroTimer = 0.0f;
          this.SuperTimer = 0.0f;
        }
      }
      else if (this.HitReacting)
      {
        if ((double) this.MyAnimation[this.HitReactAnim].time >= (double) this.MyAnimation[this.HitReactAnim].length)
        {
          this.MyAnimation.CrossFade(this.IdleAnim);
          this.HitReacting = false;
          this.CanMove = true;
        }
      }
      else if (this.Intro)
      {
        if (this.Cutscene)
        {
          if (!this.Dialogue.isPlaying || Input.GetButtonDown("A"))
          {
            ++this.CutsceneID;
            if (this.CutsceneID < 3)
            {
              this.Dialogue.clip = this.DialogueClips[this.CutsceneID];
              this.Dialogue.Play();
              this.Subtitle.text = this.DialogueText[this.CutsceneID];
            }
            else
            {
              this.Music.clip = this.EightiesTrack;
              this.Cutscene = false;
              this.Subtitle.text = "";
            }
          }
        }
        else
        {
          this.IntroTimer += Time.deltaTime;
          if ((double) this.IntroTimer > 2.6666600704193115)
          {
            this.CameraSpeed += Time.deltaTime * (0.1f + this.CameraSpeed);
            this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, new Vector3(0.0f, 1.773969f, -7.888118f), Time.deltaTime * this.CameraSpeed);
            this.MainCamera.transform.eulerAngles = Vector3.Lerp(this.MainCamera.transform.eulerAngles, new Vector3(15f, 0.0f, 0.0f), Time.deltaTime * this.CameraSpeed);
            if ((double) this.IntroTimer > 5.0)
            {
              this.GrowingLabel.transform.localScale += new Vector3(5f, 5f, 5f) * Time.deltaTime;
              if ((double) this.GrowingLabel.transform.localScale.x <= 1.0)
                this.GrowingLabel.alpha = Mathf.MoveTowards(this.GrowingLabel.alpha, 1f, Time.deltaTime * 5f);
              else if ((double) this.GrowingLabel.transform.localScale.x >= 2.0)
              {
                this.GrowingLabel.alpha = Mathf.MoveTowards(this.GrowingLabel.alpha, 0.0f, Time.deltaTime * 5f);
                if ((double) this.GrowingLabel.alpha == 0.0)
                {
                  ++this.TextID;
                  if (this.TextID < this.GrowingText.Length)
                  {
                    this.GrowingLabel.text = this.GrowingText[this.TextID];
                    this.GrowingLabel.transform.localScale = Vector3.zero;
                  }
                }
              }
            }
            else if ((double) this.IntroTimer > 4.0)
              this.GameplayPanel.alpha = Mathf.MoveTowards(this.GameplayPanel.alpha, 1f, Time.deltaTime);
            if (!this.Music.isPlaying || (double) this.IntroTimer > 7.5)
            {
              this.GrowingLabel.transform.localScale = Vector3.zero;
              this.GameplayPanel.alpha = 1f;
              if (!this.Eighties)
              {
                this.Music.clip = this.MusicLoop;
                this.Music.Play();
              }
              this.Music.loop = true;
              this.RPGCamera.enabled = true;
              this.CanMove = true;
              this.Intro = false;
              int index = 1;
              while (index < this.AllEnemies.Length)
              {
                if ((Object) this.AllEnemies[index] != (Object) null)
                {
                  this.AllEnemies[index].enabled = true;
                  ++index;
                }
              }
            }
          }
          else if ((double) this.IntroTimer > 1.0)
          {
            if (!this.Music.isPlaying)
            {
              this.CameraSpeed += Time.deltaTime;
              this.Music.Play();
            }
            this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime);
          }
        }
      }
      if (!Input.GetButtonDown("Start"))
        return;
      if ((double) Time.timeScale > 0.0)
      {
        this.PauseLabel.SetActive(true);
        Time.timeScale = 0.0f;
      }
      else
      {
        this.PauseLabel.SetActive(false);
        Time.timeScale = 1f;
      }
    }
    else if (!this.Cutscene)
    {
      this.White.alpha = Mathf.MoveTowards(this.White.alpha, 0.0f, Time.unscaledDeltaTime * 0.5f);
      if ((double) this.White.alpha == 0.0)
      {
        Time.timeScale = Mathf.MoveTowards(Time.timeScale, 1f, Time.unscaledDeltaTime);
        if (this.Defeated)
        {
          this.MyAnimation.CrossFade(this.DefeatAnim);
          this.VictoryLabel.text = "DEFEAT!";
        }
        this.VictoryLabel.transform.localScale = Vector3.Lerp(this.VictoryLabel.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime);
        this.VictoryLabel.alpha = Mathf.Lerp(this.VictoryLabel.alpha, 1f, Time.deltaTime);
        this.IntroTimer += Time.deltaTime;
        if ((double) this.IntroTimer > 5.0)
        {
          this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime * 0.5f);
          this.Music.volume -= Time.deltaTime * 0.5f;
          if ((double) this.Darkness.alpha == 1.0)
          {
            if (GameGlobals.Eighties && !this.Defeated)
            {
              this.Cutscene = true;
              this.Dialogue.clip = this.DialogueClips[this.CutsceneID];
              this.Dialogue.Play();
              this.Subtitle.text = this.DialogueText[this.CutsceneID];
            }
            else
              this.Quit();
          }
        }
      }
      if ((double) this.MyAnimation[this.AttackAnim[this.AttackID]].time < (double) this.MyAnimation[this.AttackAnim[this.AttackID]].length && (double) this.MyAnimation[this.SuperAnim].time < (double) this.MyAnimation[this.SuperAnim].length)
        return;
      this.MyAnimation.CrossFade(this.IdleAnim);
    }
    else
    {
      if (this.Dialogue.isPlaying && !Input.GetButtonDown("A"))
        return;
      ++this.CutsceneID;
      if (this.CutsceneID < this.DialogueClips.Length)
      {
        this.Dialogue.clip = this.DialogueClips[this.CutsceneID];
        this.Dialogue.Play();
        this.Subtitle.text = this.DialogueText[this.CutsceneID];
      }
      else
      {
        GameGlobals.YakuzaPhase = 1;
        this.Quit();
      }
    }
  }

  public void GetNearestEnemy()
  {
    this.Enemy = (BeatEmUpEnemyScript) null;
    int index = 1;
    while (index < this.AllEnemies.Length)
    {
      if ((Object) this.AllEnemies[index] != (Object) null)
      {
        if ((Object) this.Enemy == (Object) null && (double) this.AllEnemies[index].Health > 0.0)
          this.Enemy = this.AllEnemies[index];
        if ((double) this.AllEnemies[index].Health > 0.0 && (double) Vector3.Distance(this.transform.position, this.AllEnemies[index].transform.position) < (double) Vector3.Distance(this.transform.position, this.Enemy.transform.position))
          this.Enemy = this.AllEnemies[index];
        ++index;
      }
    }
    if (!((Object) this.Enemy != (Object) null))
      return;
    this.Ring.transform.position = this.Enemy.transform.position;
  }

  public void VictoryCheck()
  {
    --this.Enemies;
    if (this.Enemies != 0)
      return;
    if (this.Defeated)
      this.MyAnimation.CrossFade(this.DefeatAnim);
    Time.timeScale = 0.1f;
    this.Ring.gameObject.SetActive(false);
    this.HealthLabel.transform.parent.gameObject.SetActive(false);
    this.White.transform.parent.gameObject.SetActive(true);
    this.VictoryLabel.transform.localScale = Vector3.zero;
    this.VictoryLabel.gameObject.SetActive(true);
    this.VictoryLabel.alpha = 0.0f;
    this.IntroTimer = 0.0f;
    this.Victory = true;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (this.Rolling || other.gameObject.layer != 1)
      return;
    BeatEmUpHitboxScript component = other.gameObject.GetComponent<BeatEmUpHitboxScript>();
    if (!component.Enemy)
      return;
    AudioSource.PlayClipAtPoint(this.PainVoices[Random.Range(1, this.PainVoices.Length)], this.MainCamera.position);
    this.MyAudio.clip = this.HitSFX;
    this.MyAudio.pitch = Random.Range(0.9f, 1.1f);
    this.MyAudio.Play();
    Object.Instantiate<GameObject>(this.HitEffect, new Vector3(component.transform.position.x, 1.255f, component.transform.position.z), Quaternion.identity);
    this.Health -= component.Damage;
    this.HealthLabel.text = this.Health.ToString() + " / " + this.MaxHealth.ToString();
    this.HealthBar.localScale = new Vector3(this.Health / this.MaxHealth, 1f, 1f);
    this.Attacking = false;
    this.CanMove = false;
    if ((double) this.Health <= 0.0)
    {
      this.MyAnimation.CrossFade(this.DefeatAnim);
      this.Defeated = true;
      this.Enemies = 1;
      this.VictoryCheck();
    }
    else
    {
      this.MyAnimation[this.HitReactAnim].time = 0.0f;
      this.MyAnimation.CrossFade(this.HitReactAnim);
      this.CameraVibrate = 0.1f;
      this.HitReacting = true;
    }
  }

  private void LateUpdate()
  {
    if (!this.HitReacting)
      return;
    this.CameraVibrate = Mathf.MoveTowards(this.CameraVibrate, 0.0f, Time.deltaTime * 0.2f);
    this.MainCamera.position += new Vector3(Random.Range(this.CameraVibrate * -1f, this.CameraVibrate * 1f), Random.Range(this.CameraVibrate * -1f, this.CameraVibrate * 1f), Random.Range(this.CameraVibrate * -1f, this.CameraVibrate * 1f));
  }

  public void Quit()
  {
    GameGlobals.BeatEmUpSuccess = !this.Defeated;
    foreach (GameObject rootGameObject in SceneManager.GetActiveScene().GetRootGameObjects())
      rootGameObject.SetActive(true);
    SceneManager.UnloadSceneAsync(41);
  }

  private void UpdateDOF(float Focus) => this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
  {
    focusDistance = Focus
  };
}
