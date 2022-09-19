// Decompiled with JetBrains decompiler
// Type: JournalistScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using Pathfinding;
using UnityEngine;

public class JournalistScript : MonoBehaviour
{
  public GenericRivalEventScript RivalEvent;
  public ParticleSystem PepperSprayEffect;
  public CharacterController MyController;
  public RagdollScript Corpse;
  public float DistanceToDestination;
  public float DistanceToPlayer;
  public float SpeechTimer;
  public float ThreatTimer;
  public float ChaseTimer;
  public float Timer;
  public Quaternion targetRotation;
  public AudioClip PepperSpraySFX;
  public AudioClip ChaseVoice;
  public Transform[] Destinations;
  public AudioClip[] SpeechClips;
  public AudioClip[] ThreatClips;
  public string[] SpeechLines;
  public string[] ThreatLines;
  public SubtitleScript Subtitle;
  public YandereScript Yandere;
  public GameObject PepperSpray;
  public GameObject Face;
  public Animation MyAnimation;
  public Transform LookTarget;
  public AIPath Pathfinding;
  public float FreezeTimer;
  public float WaitTimer;
  public bool AwareOfMurder;
  public bool Waiting;
  public bool Chasing;
  public bool Freeze;
  public bool Flee;
  public int SpeechID;
  public int ThreatID;
  public Transform Head;
  public LayerMask Mask;

  private void Start()
  {
    if (!GameGlobals.Eighties || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
      this.gameObject.SetActive(false);
    else
      this.Pathfinding.target = this.Destinations[0];
    this.MyAnimation.CrossFade("crossarms_00");
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    this.PepperSpray.SetActive(false);
  }

  private void Update()
  {
    this.DistanceToDestination = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
    this.DistanceToPlayer = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
    if (this.Waiting)
    {
      if ((double) this.DistanceToPlayer < 5.0)
        this.SpeechCheck();
      this.WaitTimer += Time.deltaTime;
      if ((double) this.WaitTimer <= 5.0 || !((Object) this.RivalEvent == (Object) null) && !this.Yandere.Armed)
        return;
      this.Pathfinding.canSearch = true;
      this.Pathfinding.canMove = true;
      this.Waiting = false;
    }
    else if (this.Flee)
    {
      if ((double) this.DistanceToDestination >= 2.2000000476837158)
        return;
      this.Yandere.StudentManager.Police.Show = true;
      this.gameObject.SetActive(false);
    }
    else if (this.Freeze)
    {
      this.MyAnimation.CrossFade("readyToFight_00");
      this.Pathfinding.canSearch = false;
      this.Pathfinding.canMove = false;
      if (this.AwareOfMurder)
        return;
      if ((Object) this.Corpse != (Object) null)
      {
        this.FreezeTimer += Time.deltaTime;
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.Student.Hips.position.x, this.transform.position.y, this.Corpse.Student.Hips.position.z) - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        if ((double) this.FreezeTimer <= 5.0)
          return;
        this.RunAway();
      }
      else
      {
        this.targetRotation = Quaternion.LookRotation(this.Yandere.StudentManager.MindBrokenSlave.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        if (this.Yandere.StudentManager.MindBrokenSlave.Alive)
          return;
        this.RunAway();
      }
    }
    else if (!this.Chasing)
    {
      if ((double) this.Yandere.transform.position.z < -50.0 && this.Yandere.Attacking || this.AwareOfMurder)
      {
        Debug.Log((object) "Journo is aware of murder.");
        this.Yandere.RunSpeed = 0.0f;
        this.AwareOfMurder = true;
        if ((double) this.DistanceToPlayer > 1.0)
        {
          Debug.Log((object) "Journo is runnin'...");
          this.MyAnimation.CrossFade("sprint_00");
          this.transform.LookAt(this.Yandere.transform.position);
          int num = (int) this.MyController.Move(this.transform.forward * Time.deltaTime * 5f);
        }
        else
        {
          Debug.Log((object) "Journo is close enough, he can stop now.");
          this.MyAnimation.CrossFade("readyToFight_00");
          if (!this.Yandere.Attacking)
            this.Chase();
        }
        if ((double) this.DistanceToPlayer < 15.0 && this.CanSeeYandere() || (double) this.DistanceToPlayer < 5.0 && this.AwareOfMurder)
          this.CheckBehavior();
      }
      else
      {
        if ((double) this.Yandere.transform.position.z < -50.0 && (double) this.Yandere.transform.position.z > -75.0)
          this.Pathfinding.target = this.Yandere.transform;
        else if ((Object) this.Pathfinding.target == (Object) this.Yandere.transform)
          this.Pathfinding.target = this.Destinations[0];
        if ((double) this.DistanceToPlayer < 5.0 && this.CanSeeYandere())
        {
          this.MyAnimation.CrossFade("idleTough_00");
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          this.SpeechCheck();
        }
        else if ((double) this.Yandere.transform.position.z < -50.0 && (double) this.DistanceToPlayer < 10.0)
        {
          this.MyAnimation.CrossFade("idleTough_00");
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        }
        else if ((double) this.DistanceToDestination < 1.0)
        {
          this.MyAnimation.CrossFade("leaning_00");
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.targetRotation = Quaternion.LookRotation(this.LookTarget.position - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 5.0)
          {
            if ((Object) this.Pathfinding.target != (Object) this.Destinations[1])
              this.Pathfinding.target = this.Destinations[1];
            else
              this.Pathfinding.target = this.Destinations[2];
            this.Timer = 0.0f;
          }
        }
        else
        {
          this.MyAnimation.CrossFade("walkTough_00");
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
        }
      }
      if ((double) this.DistanceToPlayer < 15.0 && this.CanSeeYandere() || (double) this.DistanceToPlayer < 5.0 && this.AwareOfMurder)
        this.CheckBehavior();
      if (this.Chasing || this.AwareOfMurder)
        return;
      if (this.Yandere.StudentManager.MurderTakingPlace)
      {
        Debug.Log((object) "Journalist acknowledges that a mind-broken slave murder is walking around..");
        if (this.Yandere.StudentManager.MindBrokenSlave.MurderSuicidePhase <= 1 || (double) Vector3.Distance(this.transform.position, this.Yandere.StudentManager.MindBrokenSlave.transform.position) >= 10.0)
          return;
        Debug.Log((object) "A mind-broken murder is taking place within 10 meters of the Journalist!");
        this.Freeze = true;
      }
      else
      {
        if (this.Yandere.StudentManager.Police.Corpses <= 0)
          return;
        for (int index = 0; index < this.Yandere.StudentManager.Police.Corpses; ++index)
        {
          if ((Object) this.Yandere.StudentManager.Police.CorpseList[index] != (Object) null && (double) Vector3.Distance(this.transform.position, this.Yandere.StudentManager.Police.CorpseList[index].transform.position) < 10.0)
          {
            this.Corpse = this.Yandere.StudentManager.Police.CorpseList[index];
            this.Freeze = true;
          }
        }
      }
    }
    else
    {
      this.Yandere.CanMove = false;
      this.targetRotation = Quaternion.LookRotation(this.transform.position - this.Yandere.transform.position);
      this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
      this.ChaseTimer += Time.deltaTime;
      if ((double) this.ChaseTimer > 1.0)
      {
        if ((double) this.DistanceToPlayer > 1.0)
        {
          this.MyAnimation.CrossFade("sprint_00");
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.Pathfinding.speed = 5f;
        }
        else if (this.Yandere.Noticed)
        {
          this.MyAnimation.CrossFade("readyToFight_00");
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.Pathfinding.speed = 0.0f;
          this.enabled = false;
        }
        else
        {
          if (!this.Yandere.Sprayed)
            AudioSource.PlayClipAtPoint(this.PepperSpraySFX, this.transform.position);
          this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          this.Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
          this.Yandere.SprayedByJournalist = true;
          this.Yandere.YandereVision = false;
          this.Yandere.NearSenpai = false;
          this.Yandere.Attacking = false;
          this.Yandere.FollowHips = true;
          this.Yandere.Punching = false;
          this.Yandere.CanMove = false;
          this.Yandere.Sprayed = true;
          this.Yandere.StudentManager.YandereDying = true;
          this.Yandere.StudentManager.StopMoving();
          this.Yandere.Jukebox.Volume = 0.0f;
          this.Yandere.Blur.Size = 1f;
          if (this.Yandere.DelinquentFighting)
            this.Yandere.StudentManager.CombatMinigame.Stop();
          this.MyAnimation.CrossFade("spray_00");
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.Pathfinding.speed = 0.0f;
          this.PepperSpray.SetActive(true);
          if ((double) this.MyAnimation["spray_00"].time <= 0.66666)
            return;
          this.PepperSprayEffect.Play();
          if (this.Yandere.Armed)
            this.Yandere.EquippedWeapon.Drop();
          this.Yandere.EmptyHands();
          this.enabled = false;
        }
      }
      else
      {
        this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
      }
    }
  }

  private void CheckBehavior()
  {
    if (!this.Yandere.CanMove || this.Yandere.Egg || !this.Yandere.Chased && this.Yandere.Chasers <= 0 && (double) this.Yandere.MurderousActionTimer <= 0.0 && (double) this.Yandere.PotentiallyMurderousTimer <= 0.0 && (!this.Yandere.Armed || !this.Yandere.EquippedWeapon.Bloody) && (!this.Yandere.Carrying || this.Yandere.CurrentRagdoll.Concealed) && (!this.Yandere.Dragging || this.Yandere.CurrentRagdoll.Concealed) && ((double) this.Yandere.Bloodiness + (double) this.Yandere.GloveBlood <= 0.0 || this.Yandere.Paint || !this.Yandere.MyProjector.enabled) && (!((Object) this.Yandere.PickUp != (Object) null) || !(bool) (Object) this.Yandere.PickUp.BodyPart || this.Yandere.PickUp.Garbage))
      return;
    this.Chase();
  }

  public bool CanSeeYandere()
  {
    RaycastHit hitInfo;
    return !this.Yandere.Egg && Physics.Linecast(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), out hitInfo, (int) this.Mask) && (Object) hitInfo.collider.gameObject == (Object) this.Yandere.gameObject;
  }

  private void Chase()
  {
    this.Face.name = "RENAMED";
    this.Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
    AudioSource.PlayClipAtPoint(this.ChaseVoice, this.Yandere.MainCamera.transform.position);
    this.Subtitle.CustomText = "I knew it was you!";
    this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
    this.MyAnimation.CrossFade("readyToFight_00");
    if (this.Yandere.Laughing)
      this.Yandere.StopLaughing();
    this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
    this.Yandere.CanMove = false;
    this.Pathfinding.target = this.Yandere.transform;
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    if (this.Yandere.Carrying)
      this.Yandere.EmptyHands();
    this.Waiting = false;
    this.Chasing = true;
  }

  private void RunAway()
  {
    this.Pathfinding.target = this.Yandere.StudentManager.Exit;
    this.MyAnimation.CrossFade("sprint_00");
    this.Pathfinding.canSearch = true;
    this.Pathfinding.canMove = true;
    this.Pathfinding.speed = 5f;
    this.Flee = true;
  }

  private void SpeechCheck()
  {
    if (this.AwareOfMurder)
      return;
    if ((double) this.DistanceToPlayer > 1.0)
    {
      this.SpeechTimer -= Time.deltaTime;
      if ((double) this.SpeechTimer > 0.0 || this.SpeechID >= this.SpeechLines.Length)
        return;
      AudioSource.PlayClipAtPoint(this.SpeechClips[this.SpeechID], this.transform.position);
      if (this.Subtitle.EventSubtitle.text == "" || (double) this.Subtitle.EventSubtitle.transform.localScale.x < 1.0)
      {
        this.Subtitle.CustomText = this.SpeechLines[this.SpeechID];
        this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
      }
      this.SpeechTimer = 5f;
      ++this.SpeechID;
    }
    else
    {
      this.ThreatTimer -= Time.deltaTime;
      if ((double) this.ThreatTimer <= 0.0 && this.ThreatID < this.ThreatLines.Length)
      {
        AudioSource.PlayClipAtPoint(this.ThreatClips[this.ThreatID], this.transform.position);
        if (this.Subtitle.EventSubtitle.text == "" || (double) this.Subtitle.EventSubtitle.transform.localScale.x < 1.0)
        {
          this.Subtitle.PreviousSubtitle = SubtitleType.AcceptFood;
          this.Subtitle.CustomText = this.ThreatLines[this.ThreatID];
          this.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 4f);
        }
        this.ThreatTimer = 5f;
        ++this.ThreatID;
      }
      if (!this.Yandere.Armed)
        return;
      this.Chase();
    }
  }
}
