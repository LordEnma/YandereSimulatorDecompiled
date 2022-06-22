// Decompiled with JetBrains decompiler
// Type: HeadmasterScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HeadmasterScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public HeartbrokenScript Heartbroken;
  public YandereScript Yandere;
  public JukeboxScript Jukebox;
  public AudioClip[] HeadmasterSpeechClips;
  public AudioClip[] HeadmasterThreatClips;
  public AudioClip[] HeadmasterBoxClips;
  public AudioClip HeadmasterRelaxClip;
  public AudioClip HeadmasterAttackClip;
  public AudioClip HeadmasterCrypticClip;
  public AudioClip HeadmasterShockClip;
  public AudioClip HeadmasterPatienceClip;
  public AudioClip HeadmasterCorpseClip;
  public AudioClip HeadmasterWeaponClip;
  public AudioClip[] EightiesHeadmasterSpeechClips;
  public AudioClip[] EightiesHeadmasterThreatClips;
  public AudioClip[] EightiesHeadmasterBoxClips;
  public AudioClip EightiesHeadmasterCrypticClip;
  public AudioClip EightiesHeadmasterCorpseClip;
  public AudioClip Crumple;
  public AudioClip StandUp;
  public AudioClip SitDown;
  public string[] HeadmasterSpeechText = new string[6]
  {
    "",
    "Ahh...! It's...it's you!",
    "No, that would be impossible...you must be...her daughter...",
    "I'll tolerate you in my school, but not in my office.",
    "Leave at once.",
    "There is nothing for you to achieve here. Just. Get. Out."
  };
  public string[] HeadmasterThreatText = new string[6]
  {
    "",
    "Not another step!",
    "You're up to no good! I know it!",
    "I'm not going to let you harm me!",
    "I'll use self-defense if I deem it necessary!",
    "This is your final warning. Get out of here...or else."
  };
  public string[] HeadmasterBoxText = new string[6]
  {
    "",
    "What...in...blazes are you doing?",
    "Are you trying to re-enact something you saw in a video game?",
    "Ugh, do you really think such a stupid ploy is going to work?",
    "I know who you are. It's obvious. You're not fooling anyone.",
    "I don't have time for this tomfoolery. Leave at once!"
  };
  public string[] EightiesHeadmasterSpeechText = new string[6]
  {
    "",
    "...oh! Um...hello there, young lady!",
    "Can I, uh...help you with anything?",
    "You don't really...talk much, do you?",
    "Don't you...have a class to run along to?",
    "Well, I suppose there's no harm in letting you spend a bit of time here..."
  };
  public string[] EightiesHeadmasterThreatText = new string[6]
  {
    "",
    "My my, you're quite comfortable here, aren't you?",
    "Care to...introduce yourself?",
    "Most students...don't really do this sort of thing.",
    "You...really seem to have a lot of free time on your hands.",
    "Well, I suppose you're...technically...not breaking any rules..."
  };
  public string[] EightiesHeadmasterBoxText = new string[6]
  {
    "",
    "...uh.",
    "...why are you...doing that?",
    "Is this what the kids like to do these days?",
    "Is this some sort of new fad that nobody told me about?",
    "Well, I suppose that a small amount of tomfoolery is just...part of youth."
  };
  public string HeadmasterRelaxText = "Hmm...a wise decision.";
  public string HeadmasterAttackText = "You asked for it!";
  public string HeadmasterCrypticText = "Mr. Saikou...the deal is off.";
  public string HeadmasterWeaponText = "How dare you raise a weapon in my office!";
  public string HeadmasterPatienceText = "Enough of this nonsense!";
  public string HeadmasterCorpseText = "You...you murderer!";
  public string EightiesHeadmasterWeaponText = "What are you doing?! Stay back!";
  public string EightiesHeadmasterCrypticText = "Mr. Saikou, you'll never believe what just happened!";
  public string EightiesHeadmasterCorpseText = "You...you killed someone!";
  public UILabel HeadmasterSubtitle;
  public Animation MyAnimation;
  public AudioSource MyAudio;
  public GameObject LightningEffect;
  public GameObject Tazer;
  public Transform TazerEffectTarget;
  public Transform CardboardBox;
  public Transform Chair;
  public Quaternion targetRotation;
  public float PatienceTimer;
  public float ScratchTimer;
  public float SpeechTimer;
  public float ThreatTimer;
  public float MaxDistance = 10f;
  public float MidDistance = 2.8f;
  public float MinDistance = 1.2f;
  public float Distance;
  public int Patience = 10;
  public int ThreatID;
  public int VoiceID;
  public int BoxID;
  public bool PlayedStandSound;
  public bool PlayedSitSound;
  public bool LostPatience;
  public bool Threatened;
  public bool Eighties;
  public bool Relaxing;
  public bool Shooting;
  public bool Aiming;
  public string IdleAnim;
  public RiggedAccessoryAttacher EightiesAttacher;
  public GameObject EightiesPaper;
  public GameObject Trashcan;
  public GameObject Laptop;
  public GameObject Pen;
  public GameObject[] OriginalMesh;
  public Material Transparency;
  public bool LookAtPlayer;
  public bool Initialized;
  public Vector3 LookAtTarget;
  public Transform Default;
  public Transform Head;
  public float LipTimer;
  public float JawRot;
  public Transform Jaw;

  private void Start()
  {
    this.MyAnimation["HeadmasterRaiseTazer"].speed = 2f;
    this.Tazer.SetActive(false);
    this.IdleAnim = "HeadmasterType";
    if (!GameGlobals.Eighties)
      return;
    this.IdleAnim = "HeadmasterDeskWritePingPong";
    this.MyAnimation.CrossFade(this.IdleAnim);
    this.EightiesPaper.SetActive(true);
    this.Trashcan.SetActive(false);
    this.Laptop.SetActive(false);
    this.Pen.SetActive(true);
    this.EightiesAttacher.gameObject.SetActive(true);
    this.OriginalMesh[1].GetComponent<SkinnedMeshRenderer>().material = this.Transparency;
    this.OriginalMesh[2].SetActive(false);
    this.OriginalMesh[3].SetActive(false);
    this.OriginalMesh[4].SetActive(false);
    this.OriginalMesh[5].SetActive(false);
    this.HeadmasterSpeechText = this.EightiesHeadmasterSpeechText;
    this.HeadmasterThreatText = this.EightiesHeadmasterThreatText;
    this.HeadmasterBoxText = this.EightiesHeadmasterBoxText;
    this.HeadmasterWeaponText = this.EightiesHeadmasterCorpseText;
    this.HeadmasterCrypticText = this.EightiesHeadmasterCrypticText;
    this.HeadmasterCorpseText = this.EightiesHeadmasterCorpseText;
    this.HeadmasterSpeechClips = this.EightiesHeadmasterSpeechClips;
    this.HeadmasterThreatClips = this.EightiesHeadmasterThreatClips;
    this.HeadmasterBoxClips = this.EightiesHeadmasterBoxClips;
    this.HeadmasterWeaponClip = this.EightiesHeadmasterCorpseClip;
    this.HeadmasterCorpseClip = this.EightiesHeadmasterCorpseClip;
    this.HeadmasterAttackClip = this.EightiesHeadmasterCorpseClip;
    this.Head = this.Head.parent;
    this.MidDistance = 1.54f;
    this.MinDistance = 0.0001f;
    this.Eighties = true;
  }

  private void Update()
  {
    if ((double) this.Yandere.transform.position.y > (double) this.transform.position.y - 1.0 && (double) this.Yandere.transform.position.y < (double) this.transform.position.y + 1.0 && (double) this.Yandere.transform.position.x < 6.0 && (double) this.Yandere.transform.position.x > -6.0)
    {
      this.Distance = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
      if (this.Shooting)
      {
        this.targetRotation = Quaternion.LookRotation(this.transform.position - this.Yandere.transform.position);
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.AimWeaponAtYandere();
        this.AimBodyAtYandere();
        this.Yandere.CanMove = false;
      }
      else if ((double) this.Distance < (double) this.MinDistance)
      {
        this.AimBodyAtYandere();
        if (this.Yandere.CanMove && !this.Yandere.Egg && !this.Shooting)
          this.Shoot();
      }
      else if ((double) this.Distance < (double) this.MidDistance)
      {
        this.PlayedSitSound = false;
        if (!this.StudentManager.Eighties)
        {
          if (!this.StudentManager.Clock.StopTime)
            this.PatienceTimer -= Time.deltaTime;
          if ((double) this.PatienceTimer < 0.0 && !this.Yandere.Egg)
          {
            this.LostPatience = true;
            this.PatienceTimer = 60f;
            this.Patience = 0;
            this.Shoot();
          }
          if (!this.LostPatience)
          {
            this.LostPatience = true;
            --this.Patience;
            if (this.Patience < 1 && !this.Yandere.Egg && !this.Shooting)
              this.Shoot();
          }
          this.AimBodyAtYandere();
          this.Threatened = true;
          this.AimWeaponAtYandere();
        }
        this.ThreatTimer = Mathf.MoveTowards(this.ThreatTimer, 0.0f, Time.deltaTime);
        if ((double) this.ThreatTimer == 0.0)
        {
          ++this.ThreatID;
          if (this.ThreatID < 6)
          {
            this.HeadmasterSubtitle.text = this.HeadmasterThreatText[this.ThreatID];
            this.MyAudio.clip = this.HeadmasterThreatClips[this.ThreatID];
            this.MyAudio.Play();
            this.ThreatTimer = this.HeadmasterThreatClips[this.ThreatID].length + 1f;
          }
        }
        this.CheckBehavior();
      }
      else if ((double) this.Distance < (double) this.MaxDistance)
      {
        this.PlayedStandSound = false;
        this.LostPatience = false;
        this.targetRotation = Quaternion.LookRotation(new Vector3(0.0f, 8f, 0.0f) - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.Chair.localPosition = Vector3.Lerp(this.Chair.localPosition, new Vector3(this.Chair.localPosition.x, this.Chair.localPosition.y, -4.66666f), Time.deltaTime * 1f);
        this.LookAtPlayer = true;
        if (!this.Threatened)
        {
          if (this.StudentManager.Eighties && (double) this.Yandere.transform.position.z < -32.6333312988281)
          {
            this.MyAnimation.CrossFade(this.IdleAnim, 1f);
            this.LookAtPlayer = false;
          }
          else
            this.MyAnimation.CrossFade("HeadmasterAttention", 1f);
          this.ScratchTimer = 0.0f;
          this.SpeechTimer = Mathf.MoveTowards(this.SpeechTimer, 0.0f, Time.deltaTime);
          if ((double) this.SpeechTimer == 0.0)
          {
            if ((Object) this.CardboardBox.parent != (Object) this.Yandere.Hips && (Object) this.Yandere.Mask == (Object) null)
            {
              ++this.VoiceID;
              if (this.VoiceID < 6)
              {
                this.HeadmasterSubtitle.text = this.HeadmasterSpeechText[this.VoiceID];
                this.MyAudio.clip = this.HeadmasterSpeechClips[this.VoiceID];
                this.MyAudio.Play();
                this.SpeechTimer = this.HeadmasterSpeechClips[this.VoiceID].length + 1f;
              }
            }
            else
            {
              ++this.BoxID;
              if (this.BoxID < 6)
              {
                this.HeadmasterSubtitle.text = this.HeadmasterBoxText[this.BoxID];
                this.MyAudio.clip = this.HeadmasterBoxClips[this.BoxID];
                this.MyAudio.Play();
                this.SpeechTimer = this.HeadmasterBoxClips[this.BoxID].length + 1f;
              }
            }
          }
        }
        else if (!this.Relaxing)
        {
          this.HeadmasterSubtitle.text = this.HeadmasterRelaxText;
          this.MyAudio.clip = this.HeadmasterRelaxClip;
          this.MyAudio.Play();
          this.Relaxing = true;
        }
        else
        {
          if (!this.PlayedSitSound)
          {
            AudioSource.PlayClipAtPoint(this.SitDown, this.transform.position);
            this.PlayedSitSound = true;
          }
          this.MyAnimation.CrossFade("HeadmasterLowerTazer");
          this.Aiming = false;
          if ((double) this.MyAnimation["HeadmasterLowerTazer"].time > 1.33333)
            this.Tazer.SetActive(false);
          if ((double) this.MyAnimation["HeadmasterLowerTazer"].time > (double) this.MyAnimation["HeadmasterLowerTazer"].length)
          {
            this.Threatened = false;
            this.Relaxing = false;
          }
        }
        this.CheckBehavior();
      }
      else
      {
        if (this.LookAtPlayer)
        {
          this.MyAnimation.CrossFade(this.IdleAnim);
          this.LookAtPlayer = false;
          this.Threatened = false;
          this.Relaxing = false;
          this.Aiming = false;
        }
        this.ScratchTimer += Time.deltaTime;
        if ((double) this.ScratchTimer > 10.0)
        {
          this.MyAnimation.CrossFade("HeadmasterScratch");
          if ((double) this.MyAnimation["HeadmasterScratch"].time > (double) this.MyAnimation["HeadmasterScratch"].length)
          {
            this.MyAnimation.CrossFade(this.IdleAnim);
            this.ScratchTimer = 0.0f;
          }
        }
      }
      if (!this.MyAudio.isPlaying)
      {
        this.HeadmasterSubtitle.text = string.Empty;
        if (this.Shooting)
          this.Taze();
      }
      if (!this.Yandere.Attacked || (double) this.Yandere.CharacterAnimation["f02_swingB_00"].time < (double) this.Yandere.CharacterAnimation["f02_swingB_00"].length * 0.850000023841858)
        return;
      this.MyAudio.clip = this.Crumple;
      this.MyAudio.Play();
      this.enabled = false;
    }
    else
      this.HeadmasterSubtitle.text = string.Empty;
  }

  private void LateUpdate()
  {
    if ((double) this.Distance >= (double) this.MaxDistance)
      return;
    this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.LookAtPlayer ? this.Yandere.Head.position : this.Default.position, Time.deltaTime * 10f);
    this.Head.LookAt(this.LookAtTarget);
    if (this.EightiesAttacher.gameObject.activeInHierarchy && !this.Initialized)
    {
      this.EightiesAttacher.newRenderer.SetBlendShapeWeight(11, 100f);
      this.Initialized = true;
    }
    if (this.HeadmasterSubtitle.text != string.Empty)
    {
      this.LipTimer = Mathf.MoveTowards(this.LipTimer, 0.0f, Time.deltaTime);
      if ((double) this.LipTimer == 0.0)
      {
        this.JawRot = Random.Range(30f, 35f);
        this.LipTimer = 0.1f;
      }
      this.Jaw.transform.localEulerAngles = new Vector3(0.0f, 0.0f, this.JawRot);
    }
    else
    {
      if ((double) Time.timeScale <= 0.100000001490116)
        return;
      this.Jaw.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 30f);
    }
  }

  private void AimBodyAtYandere()
  {
    this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, Time.deltaTime * 5f);
    this.Chair.localPosition = Vector3.Lerp(this.Chair.localPosition, new Vector3(this.Chair.localPosition.x, this.Chair.localPosition.y, -5.2f), Time.deltaTime * 1f);
  }

  private void AimWeaponAtYandere()
  {
    if (!this.Aiming)
    {
      Debug.Log((object) "The headmaster is being told to raise his tazer.");
      this.MyAnimation.CrossFade("HeadmasterRaiseTazer");
      if (!this.PlayedStandSound)
      {
        AudioSource.PlayClipAtPoint(this.StandUp, this.transform.position);
        this.PlayedStandSound = true;
      }
      if ((double) this.MyAnimation["HeadmasterRaiseTazer"].time <= 1.166666)
        return;
      this.Tazer.SetActive(true);
      this.Aiming = true;
    }
    else
    {
      Debug.Log((object) "The headmaster is being told to aim his tazer.");
      if ((double) this.MyAnimation["HeadmasterRaiseTazer"].time <= (double) this.MyAnimation["HeadmasterRaiseTazer"].length)
        return;
      this.MyAnimation.CrossFade("HeadmasterAimTazer");
    }
  }

  public void Shoot()
  {
    this.StudentManager.YandereDying = true;
    if (this.StudentManager.Clock.TimeSkip)
      this.StudentManager.Clock.EndTimeSkip();
    this.Yandere.StopAiming();
    this.Yandere.StopLaughing();
    this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
    if (this.Patience < 1)
    {
      this.HeadmasterSubtitle.text = this.HeadmasterPatienceText;
      this.MyAudio.clip = this.HeadmasterPatienceClip;
    }
    else if (this.Yandere.Armed)
    {
      this.HeadmasterSubtitle.text = this.HeadmasterWeaponText;
      this.MyAudio.clip = this.HeadmasterWeaponClip;
    }
    else if (this.Yandere.Carrying || this.Yandere.Dragging || (Object) this.Yandere.PickUp != (Object) null && (bool) (Object) this.Yandere.PickUp.BodyPart)
    {
      this.HeadmasterSubtitle.text = this.HeadmasterCorpseText;
      this.MyAudio.clip = this.HeadmasterCorpseClip;
    }
    else
    {
      this.HeadmasterSubtitle.text = this.HeadmasterAttackText;
      this.MyAudio.clip = this.HeadmasterAttackClip;
    }
    this.StudentManager.StopMoving();
    this.Yandere.EmptyHands();
    this.Yandere.CanMove = false;
    this.Yandere.Stance.Current = StanceType.Standing;
    this.MyAudio.Play();
    this.LookAtPlayer = true;
    this.Shooting = true;
  }

  private void CheckBehavior()
  {
    if (!this.Yandere.CanMove || this.Yandere.Egg)
      return;
    if (this.Yandere.Chased || this.Yandere.Chasers > 0)
    {
      if (this.Shooting)
        return;
      this.Shoot();
    }
    else if (this.Yandere.Armed)
    {
      if (this.Shooting)
        return;
      this.Shoot();
    }
    else
    {
      if (!this.Yandere.Carrying && !this.Yandere.Dragging && (!((Object) this.Yandere.PickUp != (Object) null) || !(bool) (Object) this.Yandere.PickUp.BodyPart) || this.Shooting)
        return;
      this.Shoot();
    }
  }

  public void Taze()
  {
    if (this.Yandere.CanMove)
    {
      this.StudentManager.YandereDying = true;
      this.Yandere.StopAiming();
      this.Yandere.StopLaughing();
      this.StudentManager.StopMoving();
      this.Yandere.EmptyHands();
      this.Yandere.CanMove = false;
    }
    Object.Instantiate<GameObject>(this.LightningEffect, this.TazerEffectTarget.position, Quaternion.identity);
    Object.Instantiate<GameObject>(this.LightningEffect, this.Yandere.Spine[3].position, Quaternion.identity);
    this.MyAudio.clip = this.HeadmasterShockClip;
    this.MyAudio.Play();
    this.Yandere.CharacterAnimation.CrossFade("f02_swingB_00");
    this.Yandere.CharacterAnimation["f02_swingB_00"].time = 0.5f;
    this.Yandere.RPGCamera.enabled = false;
    this.Yandere.FakingReaction = false;
    this.Yandere.Attacked = true;
    this.Heartbroken.Headmaster = true;
    this.Jukebox.Volume = 0.0f;
    this.Shooting = false;
  }
}
