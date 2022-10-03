// Decompiled with JetBrains decompiler
// Type: IncineratorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class IncineratorScript : MonoBehaviour
{
  public YandereScript Yandere;
  public PromptScript Prompt;
  public ClockScript Clock;
  public AudioClip IncineratorActivate;
  public AudioClip IncineratorClose;
  public AudioClip IncineratorOpen;
  public AudioSource FlameSound;
  public AudioSource MyAudio;
  public ParticleSystem Flames;
  public ParticleSystem Smoke;
  public Transform DumpPoint;
  public Transform RightDoor;
  public Transform LeftDoor;
  public GameObject OutOfOrderSign;
  public GameObject Panel;
  public UILabel TimeLabel;
  public UISprite Circle;
  public bool YandereHoldingEvidence;
  public bool ActivateAfterClosing;
  public bool CannotIncinerate;
  public bool Animate;
  public bool Ready;
  public bool Open;
  public int ClothingWithRedPaint;
  public int DestroyedEvidence;
  public int BloodyClothing;
  public int BloodyWeapons;
  public int HiddenCorpses;
  public int MurderWeapons;
  public int BodyParts;
  public int Corpses;
  public int Victims;
  public int Limbs;
  public int ID;
  public float OpenTimer;
  public float Timer;
  public int[] EvidenceList;
  public int[] CorpseList;
  public int[] VictimList;
  public int[] LimbList;
  public int[] ConfirmedDead;

  private void Start()
  {
    this.Panel.SetActive(false);
    this.Prompt.enabled = true;
    if (!GameGlobals.Eighties && DateGlobals.Week == 2)
    {
      this.OutOfOrderSign.SetActive(true);
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      this.enabled = false;
    }
    this.MyAudio = this.GetComponent<AudioSource>();
  }

  private void Update()
  {
    if (this.Animate)
    {
      if (this.Open)
      {
        if ((double) this.RightDoor.transform.localEulerAngles.y == 0.0)
        {
          this.MyAudio.clip = this.IncineratorOpen;
          this.MyAudio.Play();
        }
        this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, Mathf.Lerp(this.RightDoor.transform.localEulerAngles.y, 135f, Time.deltaTime * 5f), this.RightDoor.transform.localEulerAngles.z);
        this.LeftDoor.transform.localEulerAngles = new Vector3(this.LeftDoor.transform.localEulerAngles.x, Mathf.Lerp(this.LeftDoor.transform.localEulerAngles.y, 135f, Time.deltaTime * 5f), this.LeftDoor.transform.localEulerAngles.z);
        if ((double) this.RightDoor.transform.localEulerAngles.y > 134.0)
          this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, 135f, this.RightDoor.transform.localEulerAngles.z);
      }
      else
      {
        this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, Mathf.MoveTowards(this.RightDoor.transform.localEulerAngles.y, 0.0f, Time.deltaTime * 360f), this.RightDoor.transform.localEulerAngles.z);
        this.LeftDoor.transform.localEulerAngles = new Vector3(this.LeftDoor.transform.localEulerAngles.x, Mathf.MoveTowards(this.LeftDoor.transform.localEulerAngles.y, 0.0f, Time.deltaTime * 360f), this.LeftDoor.transform.localEulerAngles.z);
        if ((double) this.RightDoor.transform.localEulerAngles.y < 1.0)
        {
          this.MyAudio.clip = this.IncineratorClose;
          this.MyAudio.Play();
          this.Animate = false;
          this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, 0.0f, this.RightDoor.transform.localEulerAngles.z);
          this.LeftDoor.transform.localEulerAngles = new Vector3(this.LeftDoor.transform.localEulerAngles.x, 0.0f, this.LeftDoor.transform.localEulerAngles.z);
        }
      }
    }
    if ((double) this.OpenTimer > 0.0)
    {
      this.OpenTimer -= Time.deltaTime;
      if ((double) this.OpenTimer <= 1.0)
        this.Open = false;
      if ((double) this.OpenTimer <= 0.0)
        this.Prompt.enabled = true;
    }
    else if (!this.Smoke.isPlaying)
    {
      this.YandereHoldingEvidence = (Object) this.Yandere.Ragdoll != (Object) null;
      if (!this.YandereHoldingEvidence)
        this.YandereHoldingEvidence = (Object) this.Yandere.PickUp != (Object) null && (this.Yandere.PickUp.Evidence || this.Yandere.PickUp.Garbage);
      if (!this.YandereHoldingEvidence)
      {
        if ((Object) this.Yandere.EquippedWeapon != (Object) null)
        {
          if (this.Yandere.EquippedWeapon.Bloody || this.Yandere.EquippedWeapon.MurderWeapon)
            this.YandereHoldingEvidence = true;
        }
        else
          this.YandereHoldingEvidence = false;
      }
      if (!this.YandereHoldingEvidence)
      {
        if (!this.Prompt.HideButton[3])
          this.Prompt.HideButton[3] = true;
      }
      else if (this.Prompt.HideButton[3])
        this.Prompt.HideButton[3] = false;
      if ((this.Yandere.Chased || this.Yandere.Chasers > 0 || !this.YandereHoldingEvidence) && !this.Prompt.HideButton[3])
        this.Prompt.HideButton[3] = true;
      if (this.Ready)
      {
        if (!this.Smoke.isPlaying)
        {
          if (this.CannotIncinerate)
            this.Prompt.HideButton[0] = true;
          if (!this.CannotIncinerate && this.Prompt.HideButton[0])
            this.Prompt.HideButton[0] = false;
        }
        else if (!this.Prompt.HideButton[0])
          this.Prompt.HideButton[0] = true;
      }
    }
    if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
    {
      this.Prompt.Circle[3].fillAmount = 1f;
      Time.timeScale = 1f;
      if ((Object) this.Yandere.Ragdoll != (Object) null)
      {
        if (this.Yandere.Dragging)
        {
          this.Yandere.NotificationManager.CustomText = "Must be carrying, not dragging.";
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
        else
        {
          RagdollScript component = this.Yandere.Ragdoll.GetComponent<RagdollScript>();
          this.Yandere.CharacterAnimation.CrossFade(this.Yandere.Carrying ? "f02_carryIdleA_00" : "f02_dragIdle_00");
          this.Yandere.Incinerator = this;
          this.Yandere.YandereVision = false;
          this.Yandere.CanMove = false;
          this.Yandere.Dumping = true;
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          ++this.Victims;
          this.VictimList[this.Victims] = component.StudentID;
          this.Open = true;
        }
      }
      if ((Object) this.Yandere.PickUp != (Object) null)
      {
        Debug.Log((object) ("The " + this.Yandere.PickUp.gameObject.name + " that Yandere-chan was carrying is now being dumped into the incinerator."));
        if ((Object) this.Yandere.PickUp.BodyPart != (Object) null)
        {
          ++this.Limbs;
          this.LimbList[this.Limbs] = this.Yandere.PickUp.GetComponent<BodyPartScript>().StudentID;
        }
        this.Yandere.PickUp.Incinerator = this;
        this.Yandere.PickUp.Dumped = true;
        this.Yandere.PickUp.Drop();
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.OpenTimer = 2f;
        this.Ready = true;
        this.Open = true;
      }
      WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
      if ((Object) equippedWeapon != (Object) null)
      {
        ++this.DestroyedEvidence;
        this.EvidenceList[this.DestroyedEvidence] = equippedWeapon.WeaponID;
        equippedWeapon.InsideIncinerator = true;
        equippedWeapon.Incinerator = this;
        equippedWeapon.Dumped = true;
        equippedWeapon.Drop();
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.OpenTimer = 2f;
        this.Ready = true;
        this.Open = true;
      }
      this.Animate = true;
    }
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      int num = 0;
      for (this.ID = 1; this.ID < this.Limbs + 1; ++this.ID)
      {
        if (this.LimbList[this.ID] == this.Yandere.StudentManager.RivalID)
        {
          ++num;
          if (num == 6)
          {
            this.Yandere.StudentManager.Police.EndOfDay.RivalDismemberedAndIncinerated = true;
            Debug.Log((object) "The player dismembered and incinerated Osana.");
          }
        }
      }
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Panel.SetActive(true);
      this.Timer = 60f;
      this.MyAudio.clip = this.IncineratorActivate;
      this.MyAudio.Play();
      this.Flames.Play();
      this.Smoke.Play();
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      Debug.Log((object) ("Incinerating " + this.BloodyClothing.ToString() + " bloody clothing."));
      Debug.Log((object) ("Incinerating " + this.BloodyWeapons.ToString() + " bloody weapons."));
      Debug.Log((object) ("Incinerating " + this.MurderWeapons.ToString() + " murder weapons."));
      this.Yandere.Police.IncineratedWeapons += this.BloodyWeapons;
      this.Yandere.Police.BloodyClothing -= this.BloodyClothing;
      this.Yandere.Police.MurderWeapons -= this.MurderWeapons;
      this.Yandere.Police.BloodyWeapons -= this.BloodyWeapons;
      this.Yandere.Police.HiddenCorpses -= this.HiddenCorpses;
      this.Yandere.Police.BodyParts -= this.BodyParts;
      this.Yandere.Police.Corpses -= this.Corpses;
      this.Yandere.Police.RedPaintClothing -= this.ClothingWithRedPaint;
      if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1)
        this.Yandere.Police.MurderScene = false;
      if (this.Yandere.Police.Corpses == 0)
        this.Yandere.Police.MurderScene = false;
      this.BloodyClothing = 0;
      this.HiddenCorpses = 0;
      this.MurderWeapons = 0;
      this.BodyParts = 0;
      this.Corpses = 0;
      for (this.ID = 0; this.ID < 101; ++this.ID)
      {
        if ((Object) this.Yandere.StudentManager.Students[this.CorpseList[this.ID]] != (Object) null)
        {
          this.Yandere.StudentManager.Students[this.CorpseList[this.ID]].Ragdoll.Disposed = true;
          this.ConfirmedDead[this.ID] = this.CorpseList[this.ID];
          if (this.Yandere.StudentManager.Students[this.CorpseList[this.ID]].Ragdoll.Drowned)
            --this.Yandere.Police.DrownVictims;
        }
      }
      if ((Object) this.Yandere.StudentManager.Students[this.Yandere.StudentManager.RivalID] != (Object) null && this.Yandere.StudentManager.Students[this.Yandere.StudentManager.RivalID].Ragdoll.Disposed)
      {
        Debug.Log((object) "Just incinerated the current rival's corpse. Setting EndOfDay.RivalEliminationMethod to ''Vanished''.");
        this.Yandere.StudentManager.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Vanished;
      }
      this.Yandere.StudentManager.UpdateStudents();
      this.Yandere.WeaponManager.IncinerateWeapons();
    }
    if (this.Smoke.isPlaying)
    {
      this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / 60f);
      this.FlameSound.volume += Time.deltaTime;
      this.Circle.fillAmount = (float) (1.0 - (double) this.Timer / 60.0);
      if ((double) this.Timer <= 0.0)
      {
        this.Prompt.HideButton[0] = true;
        this.Prompt.enabled = true;
        this.Panel.SetActive(false);
        this.Ready = false;
        this.Flames.Stop();
        this.Smoke.Stop();
      }
    }
    else
      this.FlameSound.volume -= Time.deltaTime;
    if (!this.Panel.activeInHierarchy)
      return;
    double num1 = (double) Mathf.CeilToInt(this.Timer * 60f);
    this.TimeLabel.text = string.Format("{0:00}:{1:00}", (object) Mathf.Floor((float) (num1 / 60.0)), (object) (float) Mathf.RoundToInt((float) (num1 % 60.0)));
  }

  public void SetVictimsMissing()
  {
    foreach (int studentID in this.ConfirmedDead)
    {
      if (studentID > 0)
      {
        Debug.Log((object) ("Student #" + studentID.ToString() + " was incinerated and is now considered ''missing'."));
        StudentGlobals.SetStudentMissing(studentID, true);
      }
    }
  }

  public void DumpGarbageBag(PickUpScript PickUp)
  {
    Debug.Log((object) "A garbage bag was dumped into the incinerator!");
    ++this.Limbs;
    this.LimbList[this.Limbs] = PickUp.GetComponent<BodyPartScript>().StudentID;
    PickUp.Incinerator = this;
    PickUp.Dumped = true;
    PickUp.Drop();
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.OpenTimer = 2f;
    this.Animate = true;
    this.Ready = true;
    this.Open = true;
  }
}
