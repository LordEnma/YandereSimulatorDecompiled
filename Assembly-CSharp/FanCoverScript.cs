// Decompiled with JetBrains decompiler
// Type: FanCoverScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FanCoverScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public NoteWindowScript NoteWindow;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public StudentScript Rival;
  public SM_rotateThis Fan;
  public ParticleSystem BloodEffects;
  public Projector BloodProjector;
  public Rigidbody MyRigidbody;
  public Transform MurderSpot;
  public GameObject Explosion;
  public GameObject OfferHelp;
  public GameObject Smoke;
  public AudioClip RivalReaction;
  public AudioSource FanSFX;
  public Texture[] YandereBloodTextures;
  public Texture[] BloodTexture;
  public ParticleSystem[] Particles;
  public bool Reacted;
  public float Timer;
  public int RivalID = 11;
  public int Phase;

  private void Start()
  {
    if (this.StudentManager.Eighties || (Object) this.StudentManager.Students[this.RivalID] == (Object) null)
    {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.enabled = false;
    }
    else
      this.Rival = this.StudentManager.Students[this.RivalID];
  }

  private void Update()
  {
    if ((double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < 2.0)
      this.Prompt.HideButton[0] = !this.Yandere.Armed || this.Yandere.EquippedWeapon.WeaponID != 6 || !this.Rival.Meeting || (double) this.Rival.DistanceToDestination >= 0.10000000149011612 || this.NoteWindow.MeetID != 9;
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Yandere.CharacterAnimation.CrossFade("f02_fanMurderA_00");
      this.Rival.CharacterAnimation.CrossFade("f02_fanMurderB_00");
      this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("fanMurderHair");
      this.Rival.enabled = false;
      this.Yandere.EmptyHands();
      this.Rival.OsanaHair.transform.parent = this.Rival.transform;
      this.Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
      this.Rival.OsanaHair.transform.localPosition = Vector3.zero;
      this.Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
      this.Rival.OsanaHairL.enabled = false;
      this.Rival.OsanaHairR.enabled = false;
      this.Rival.Distracted = true;
      this.Yandere.CanMove = false;
      this.Rival.Meeting = false;
      this.Rival.Blind = true;
      this.FanSFX.enabled = false;
      this.GetComponent<AudioSource>().Play();
      this.transform.localPosition = new Vector3(-1.733f, 0.465f, 0.952f);
      this.transform.localEulerAngles = new Vector3(-90f, 165f, 0.0f);
      Physics.SyncTransforms();
      Rigidbody component = this.GetComponent<Rigidbody>();
      component.isKinematic = false;
      component.useGravity = true;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      ++this.Phase;
      if (GameGlobals.CensorBlood)
      {
        this.YandereBloodTextures = this.Yandere.FlowerTextures;
        this.BloodTexture = this.Yandere.FlowerTextures;
        this.Particles[1].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = this.Yandere.FlowerTextures[1];
        this.Particles[2].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = this.Yandere.FlowerTextures[1];
        this.Particles[3].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = this.Yandere.FlowerTextures[1];
        this.Particles[1].colorOverLifetime.enabled = false;
        this.Particles[2].colorOverLifetime.enabled = false;
        this.Particles[3].colorOverLifetime.enabled = false;
        this.Yandere.Blur.enabled = true;
        this.Yandere.Blur.Size = 1f;
      }
    }
    if (this.Phase <= 0)
      return;
    this.Yandere.Sanity -= Time.deltaTime * (PlayerGlobals.PantiesEquipped == 10 ? 5f : 10f) * this.Yandere.Numbness;
    if (this.Phase == 1)
    {
      this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.MurderSpot.rotation, Time.deltaTime * 10f);
      this.Yandere.MoveTowardsTarget(this.MurderSpot.position);
      if ((double) this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time > 3.5 && !this.Reacted)
      {
        AudioSource.PlayClipAtPoint(this.RivalReaction, this.Rival.transform.position + new Vector3(0.0f, 1f, 0.0f));
        this.Yandere.MurderousActionTimer = 999f;
        this.Reacted = true;
      }
      if ((double) this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time > 5.0)
      {
        this.Rival.LiquidProjector.material.mainTexture = this.Rival.BloodTexture;
        this.Rival.LiquidProjector.enabled = true;
        this.Rival.EyeShrink = 1f;
        this.Yandere.BloodTextures = this.YandereBloodTextures;
        this.Yandere.Bloodiness += 20f;
        if (!this.Yandere.NoStainGloves)
        {
          if (this.Yandere.Gloved && !this.Yandere.Gloves.Blood.enabled)
          {
            this.Yandere.GloveAttacher.newRenderer.material.mainTexture = this.Yandere.BloodyGloveTexture;
            this.Yandere.Gloves.PickUp.Evidence = true;
            this.Yandere.Gloves.Blood.enabled = true;
            this.Yandere.GloveBlood = 1;
            ++this.Yandere.Police.BloodyClothing;
          }
          if ((Object) this.Yandere.Mask != (Object) null && !this.Yandere.Mask.Blood.enabled)
          {
            this.Yandere.Mask.PickUp.Evidence = true;
            this.Yandere.Mask.Blood.enabled = true;
            ++this.Yandere.Police.BloodyClothing;
          }
        }
        this.BloodProjector.gameObject.SetActive(true);
        this.BloodProjector.material.mainTexture = this.BloodTexture[1];
        this.BloodEffects.transform.parent = this.Rival.Head;
        this.BloodEffects.transform.localPosition = new Vector3(0.0f, 0.1f, 0.0f);
        this.BloodEffects.Play();
        ++this.Phase;
      }
      if (!this.Yandere.Blur.enabled)
        return;
      this.Yandere.Blur.Size = Mathf.MoveTowards(this.Yandere.Blur.Size, 10f, Time.deltaTime * 2f);
    }
    else if (this.Phase < 10)
    {
      if (this.Phase < 6)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 1.0)
        {
          ++this.Phase;
          if (this.Phase - 1 < 5)
          {
            this.BloodProjector.material.mainTexture = this.BloodTexture[this.Phase - 1];
            this.Yandere.Bloodiness += 20f;
            this.Timer = 0.0f;
          }
        }
      }
      if ((double) this.Rival.CharacterAnimation["f02_fanMurderB_00"].time < (double) this.Rival.CharacterAnimation["f02_fanMurderB_00"].length)
        return;
      this.BloodProjector.material.mainTexture = this.BloodTexture[5];
      this.Yandere.Bloodiness += 20f;
      this.Rival.Ragdoll.Decapitated = true;
      this.Rival.OsanaHair.SetActive(false);
      this.Rival.DeathType = DeathType.Weapon;
      this.Rival.BecomeRagdoll();
      this.BloodEffects.Stop();
      this.Explosion.SetActive(true);
      this.Smoke.SetActive(true);
      this.Fan.enabled = false;
      this.Phase = 10;
    }
    else if ((double) this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time >= (double) this.Yandere.CharacterAnimation["f02_fanMurderA_00"].length)
    {
      this.Yandere.Blur.Size = Mathf.MoveTowards(this.Yandere.Blur.Size, 0.0f, Time.deltaTime);
      this.Yandere.MurderousActionTimer = 0.0f;
      this.OfferHelp.SetActive(false);
      this.Yandere.CanMove = true;
      this.Yandere.Blur.Size = 0.0f;
      this.enabled = false;
    }
    else
    {
      if ((double) this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time < (double) this.Yandere.CharacterAnimation["f02_fanMurderA_00"].length - 5.0 || !this.Yandere.Blur.enabled)
        return;
      this.Yandere.Blur.Size = Mathf.MoveTowards(this.Yandere.Blur.Size, 0.0f, Time.deltaTime * 2f);
    }
  }
}
