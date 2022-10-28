// Decompiled with JetBrains decompiler
// Type: GazerEyesScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GazerEyesScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public YandereScript Yandere;
  public GameObject FemaleBloodyScream;
  public GameObject MaleBloodyScream;
  public GameObject ParticleEffect;
  public GameObject Laser;
  public SkinnedMeshRenderer[] Eyes;
  public float[] BlinkStrength;
  public Texture[] EyeTextures;
  public bool[] Blink;
  public float RandomNumber;
  public float AnimTime;
  public bool Attacking;
  public int Effect;
  public int ID;
  public bool Shinigami;

  private void Start()
  {
    this.GetComponent<Animation>()["Eyeballs_Run"].speed = 0.0f;
    this.GetComponent<Animation>()["Eyeballs_Walk"].speed = 0.0f;
    this.GetComponent<Animation>()["Eyeballs_Idle"].speed = 0.0f;
  }

  private void Update()
  {
    this.StudentManager.UpdateStudents();
    if (!this.Attacking)
    {
      this.AnimTime += Time.deltaTime;
      if ((double) this.AnimTime > 144.0)
        this.AnimTime = 0.0f;
    }
    else
      this.AnimTime = (double) this.AnimTime >= 72.0 ? Mathf.Lerp(this.AnimTime, 144f, (float) ((double) Time.deltaTime * 1.440000057220459 * 5.0)) : Mathf.Lerp(this.AnimTime, 0.0f, (float) ((double) Time.deltaTime * 1.440000057220459 * 5.0));
    this.GetComponent<Animation>()["Eyeballs_Run"].time = this.AnimTime;
    this.GetComponent<Animation>()["Eyeballs_Walk"].time = this.AnimTime;
    this.GetComponent<Animation>()["Eyeballs_Idle"].time = this.AnimTime;
    for (this.ID = 0; this.ID < this.Eyes.Length; ++this.ID)
    {
      if ((double) this.BlinkStrength[this.ID] == 0.0)
        this.RandomNumber = (float) Random.Range(1, 101);
      if ((double) this.RandomNumber == 1.0)
        this.Blink[this.ID] = true;
      if (this.Blink[this.ID])
      {
        this.BlinkStrength[this.ID] = Mathf.MoveTowards(this.BlinkStrength[this.ID], 100f, Time.deltaTime * 1000f);
        this.Eyes[this.ID].SetBlendShapeWeight(0, this.BlinkStrength[this.ID]);
        if ((double) this.BlinkStrength[this.ID] == 100.0)
          this.Blink[this.ID] = false;
      }
      else if ((double) this.BlinkStrength[this.ID] > 0.0)
      {
        this.BlinkStrength[this.ID] = Mathf.MoveTowards(this.BlinkStrength[this.ID], 0.0f, Time.deltaTime * 1000f);
        this.Eyes[this.ID].SetBlendShapeWeight(0, this.BlinkStrength[this.ID]);
      }
    }
    float axis1 = Input.GetAxis("Vertical");
    float axis2 = Input.GetAxis("Horizontal");
    if (!this.Yandere.CanMove)
      return;
    if ((double) axis1 != 0.0 || (double) axis2 != 0.0)
    {
      if (Input.GetButton("LB"))
        this.GetComponent<Animation>().CrossFade("Eyeballs_Run", 1f);
      else
        this.GetComponent<Animation>().CrossFade("Eyeballs_Walk", 1f);
    }
    else
      this.GetComponent<Animation>().CrossFade("Eyeballs_Idle", 1f);
  }

  public void ChangeEffect()
  {
    ++this.Effect;
    if (this.Effect == this.EyeTextures.Length)
      this.Effect = 0;
    for (this.ID = 0; this.ID < this.Eyes.Length; ++this.ID)
    {
      Object.Instantiate<GameObject>(this.ParticleEffect, this.Eyes[this.ID].transform.position, Quaternion.identity);
      this.Eyes[this.ID].material.mainTexture = this.EyeTextures[this.Effect];
    }
  }

  public void Attack()
  {
    if (!this.Shinigami)
    {
      for (this.ID = 0; this.ID < this.Eyes.Length; ++this.ID)
      {
        GameObject gameObject = Object.Instantiate<GameObject>(this.Laser, this.Eyes[this.ID].transform.position, Quaternion.identity);
        gameObject.transform.LookAt(this.Yandere.TargetStudent.Hips.position + new Vector3(0.0f, 0.33333f, 0.0f));
        gameObject.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(this.Eyes[this.ID].transform.position, this.Yandere.TargetStudent.Hips.position + new Vector3(0.0f, 0.33333f, 0.0f)) * 0.5f);
      }
    }
    if (this.Effect == 0)
      this.Yandere.TargetStudent.Combust();
    else if (this.Effect == 1)
      this.ElectrocuteStudent(this.Yandere.TargetStudent);
    else if (this.Effect == 2)
      Object.Instantiate<GameObject>(this.Yandere.FalconPunch, this.Yandere.TargetStudent.transform.position + new Vector3(0.0f, 0.5f, 0.0f) - this.Yandere.transform.forward * 0.5f, Quaternion.identity);
    else if (this.Effect == 3)
    {
      Object.Instantiate<GameObject>(this.Yandere.EbolaEffect, this.Yandere.TargetStudent.transform.position + Vector3.up, Quaternion.identity);
      this.Yandere.TargetStudent.SpawnAlarmDisc();
      this.Yandere.TargetStudent.DeathType = DeathType.Poison;
      this.Yandere.TargetStudent.BecomeRagdoll();
    }
    else if (this.Effect == 4)
    {
      if (this.Yandere.TargetStudent.Male)
        Object.Instantiate<GameObject>(this.MaleBloodyScream, this.Yandere.TargetStudent.transform.position + new Vector3(0.0f, 1f, 0.0f), Quaternion.identity);
      else
        Object.Instantiate<GameObject>(this.FemaleBloodyScream, this.Yandere.TargetStudent.transform.position + new Vector3(0.0f, 1f, 0.0f), Quaternion.identity);
      this.Yandere.TargetStudent.BecomeRagdoll();
      this.Yandere.TargetStudent.Ragdoll.Dismember();
    }
    else
    {
      if (this.Effect != 5)
        return;
      this.Yandere.TargetStudent.TurnToStone();
    }
  }

  public void ElectrocuteStudent(StudentScript Target)
  {
    if (Target.Following)
    {
      Target.Hearts.emission.enabled = false;
      Target.FollowCountdown.gameObject.SetActive(false);
      Target.Yandere.Follower = (StudentScript) null;
      --Target.Yandere.Followers;
      Target.Following = false;
      Target.CurrentDestination = Target.Destinations[Target.Phase];
      Target.Pathfinding.target = Target.Destinations[Target.Phase];
      Target.Pathfinding.speed = 1f;
    }
    if (Target.Distracting)
    {
      if ((Object) Target.DistractionTarget != (Object) null)
        Target.DistractionTarget.TargetedForDistraction = false;
      Target.ResumeDistracting = false;
      Target.Distracting = false;
    }
    if (Target.Vomiting)
    {
      Target.Vomiting = false;
      Target.VomitPhase = 0;
    }
    if (Target.ReturningMisplacedWeapon)
      Target.DropMisplacedWeapon();
    if (Target.Investigating)
      Target.StopInvestigating();
    Target.Pathfinding.canSearch = false;
    Target.Pathfinding.canMove = false;
    Target.Routine = false;
    Target.EmptyHands();
    if ((Object) this.StudentManager.BloodReporter != (Object) null && (Object) this.StudentManager.BloodReporter.MyTeacher == (Object) Target)
      this.StudentManager.BloodReporter.ReturnToNormal();
    if (Target.StudentID == 1)
    {
      Debug.Log((object) (Target.Name + " just ''dodged'' some electricity."));
      Target.CharacterAnimation.CrossFade(Target.DodgeAnim);
      Target.DodgeSpeed = 2f;
      Target.Dodging = true;
    }
    else
    {
      Debug.Log((object) (Target.Name + " was just electrocuted."));
      Target.CharacterAnimation[Target.ElectroAnim].speed = 0.85f;
      Target.CharacterAnimation[Target.ElectroAnim].time = 2f;
      Target.CharacterAnimation.CrossFade(Target.ElectroAnim);
      Target.CharacterAnimation[Target.WetAnim].weight = 0.0f;
      Target.InvestigatingBloodPool = false;
      Target.FocusOnYandere = false;
      Target.EatingSnack = false;
      Target.Electrified = true;
      Target.Fleeing = false;
      Target.Dying = true;
      Target.Shy = false;
      Target.Police.CorpseList[Target.Police.Corpses] = Target.Ragdoll;
      ++Target.Police.Corpses;
      GameObjectUtils.SetLayerRecursively(Target.gameObject, 11);
      Target.MapMarker.gameObject.layer = 10;
      Target.tag = "Blood";
      Target.Ragdoll.ElectrocutionAnimation = true;
      Target.Ragdoll.Disturbing = true;
      Target.MurderSuicidePhase = 100;
      Target.SpawnAlarmDisc();
      GameObject gameObject1 = Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
      gameObject1.transform.parent = Target.BoneSets.RightArm;
      gameObject1.transform.localPosition = Vector3.zero;
      GameObject gameObject2 = Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
      gameObject2.transform.parent = Target.BoneSets.LeftArm;
      gameObject2.transform.localPosition = Vector3.zero;
      GameObject gameObject3 = Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
      gameObject3.transform.parent = Target.BoneSets.RightLeg;
      gameObject3.transform.localPosition = Vector3.zero;
      GameObject gameObject4 = Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
      gameObject4.transform.parent = Target.BoneSets.LeftLeg;
      gameObject4.transform.localPosition = Vector3.zero;
      GameObject gameObject5 = Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
      gameObject5.transform.parent = Target.BoneSets.Head;
      gameObject5.transform.localPosition = Vector3.zero;
      GameObject gameObject6 = Object.Instantiate<GameObject>(this.StudentManager.LightSwitch.Electricity, Target.transform.position, Quaternion.identity);
      gameObject6.transform.parent = Target.Hips;
      gameObject6.transform.localPosition = Vector3.zero;
      AudioSource.PlayClipAtPoint(this.StudentManager.LightSwitch.Flick[2], Target.transform.position + Vector3.up);
      if ((Object) Target.OsanaHairL != (Object) null)
      {
        Target.OsanaHairL.GetComponent<DynamicBone>().enabled = false;
        Target.OsanaHairR.GetComponent<DynamicBone>().enabled = false;
      }
    }
    if ((double) this.Yandere.PotentiallyMurderousTimer <= 0.0)
      return;
    this.Yandere.Sanity -= (PlayerGlobals.PantiesEquipped == 10 ? 10f : 20f) * this.Yandere.Numbness;
  }
}
