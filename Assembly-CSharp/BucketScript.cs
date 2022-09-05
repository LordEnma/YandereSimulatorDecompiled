// Decompiled with JetBrains decompiler
// Type: BucketScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BucketScript : MonoBehaviour
{
  public PhoneEventScript PhoneEvent;
  public ParticleSystem PourEffect;
  public ParticleSystem Sparkles;
  public YandereScript Yandere;
  public PickUpScript PickUp;
  public PromptScript Prompt;
  public GameObject BrownPaintCollider;
  public GameObject WaterCollider;
  public GameObject BloodCollider;
  public GameObject GasCollider;
  [SerializeField]
  private GameObject BloodSpillEffect;
  [SerializeField]
  private GameObject BrownSpillEffect;
  [SerializeField]
  private GameObject GasSpillEffect;
  [SerializeField]
  private GameObject SpillEffect;
  [SerializeField]
  private GameObject Effect;
  [SerializeField]
  private GameObject[] Dumbbell;
  [SerializeField]
  private Transform[] Positions;
  public Renderer Water;
  public Renderer Blood;
  public Renderer Brown;
  public Renderer Gas;
  public float Bloodiness;
  public float FillSpeed = 1f;
  public float Timer;
  [SerializeField]
  private float Distance;
  [SerializeField]
  private float Rotate;
  public int StudentBloodID;
  public int Dumbbells;
  public bool UpdateAppearance;
  public bool DyedBrown;
  public bool Bleached;
  public bool Dippable;
  public bool Gasoline;
  public bool Dropped;
  public bool Poured;
  public bool Full;
  public bool Trap;
  public bool Fly;
  public AudioClip EmptyBucket;
  public AudioClip FillBucket;
  public AudioClip CrackSkull;

  private void Start()
  {
    this.Water.transform.localPosition = new Vector3(this.Water.transform.localPosition.x, 0.0f, this.Water.transform.localPosition.z);
    this.Water.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
    this.Water.material.color = new Color(this.Water.material.color.r, this.Water.material.color.g, this.Water.material.color.b, 0.0f);
    this.Blood.material.color = new Color(this.Blood.material.color.r, this.Blood.material.color.g, this.Blood.material.color.b, 0.0f);
    this.Gas.transform.localPosition = new Vector3(this.Gas.transform.localPosition.x, 0.0f, this.Gas.transform.localPosition.z);
    this.Gas.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
    this.Gas.material.color = new Color(this.Gas.material.color.r, this.Gas.material.color.g, this.Gas.material.color.b, 0.0f);
    this.Brown.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
    this.Brown.material.color = new Color(this.Brown.material.color.r, this.Brown.material.color.g, this.Brown.material.color.b, 0.0f);
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    this.Yandere.StudentManager.AllBuckets[this.Yandere.StudentManager.BucketID] = this;
    ++this.Yandere.StudentManager.BucketID;
  }

  private void Update()
  {
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    if ((Object) this.PickUp.Clock != (Object) null)
      this.PickUp.Suspicious = this.PickUp.Clock.Period != 5;
    if (this.Yandere.CanMove)
    {
      this.Distance = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
      if ((double) this.Distance < 1.0)
      {
        if ((Object) this.Yandere.Bucket == (Object) null)
        {
          RaycastHit hitInfo;
          if ((double) this.transform.position.y > (double) this.Yandere.transform.position.y - 0.10000000149011612 && (double) this.transform.position.y < (double) this.Yandere.transform.position.y + 0.10000000149011612 && Physics.Linecast(this.transform.position, this.Yandere.transform.position + Vector3.up, out hitInfo) && (Object) hitInfo.collider.gameObject == (Object) this.Yandere.gameObject)
            this.Yandere.Bucket = this;
        }
        else
        {
          RaycastHit hitInfo;
          if (Physics.Linecast(this.transform.position, this.Yandere.transform.position + Vector3.up, out hitInfo) && (Object) hitInfo.collider.gameObject != (Object) this.Yandere.gameObject)
            this.Yandere.Bucket = (BucketScript) null;
          if ((double) this.transform.position.y < (double) this.Yandere.transform.position.y - 0.10000000149011612 || (double) this.transform.position.y > (double) this.Yandere.transform.position.y + 0.10000000149011612)
            this.Yandere.Bucket = (BucketScript) null;
        }
      }
      else if ((Object) this.Yandere.Bucket == (Object) this)
        this.Yandere.Bucket = (BucketScript) null;
    }
    if ((Object) this.Yandere.Bucket == (Object) this && this.Yandere.Dipping)
    {
      this.transform.position = Vector3.Lerp(this.transform.position, this.Yandere.transform.position + this.Yandere.transform.forward * 0.55f, Time.deltaTime * 10f);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z) - this.transform.position), Time.deltaTime * 10f);
    }
    if ((Object) this.Yandere.PickUp != (Object) null)
    {
      if ((Object) this.Yandere.Mop != (Object) null)
      {
        if (!this.Yandere.Chased && this.Yandere.Chasers == 0 && this.Full && !this.Gasoline && this.Bleached && (double) this.Bloodiness < 100.0)
        {
          this.Prompt.Label[3].text = "     Dip";
          this.Dippable = true;
        }
        else
        {
          this.Prompt.Label[3].text = "     Carry";
          this.Dippable = false;
        }
      }
      else if (this.Yandere.PickUp.JerryCan)
      {
        if (!this.Full)
        {
          if (!this.Yandere.PickUp.Empty)
          {
            this.Prompt.Label[0].text = "     Pour Gasoline";
            this.Prompt.HideButton[0] = false;
            flag3 = true;
          }
          else
            this.Prompt.HideButton[0] = true;
        }
        else
          this.Prompt.HideButton[0] = true;
      }
      else if (this.Yandere.PickUp.Bleach)
      {
        if (this.Full && !this.Gasoline && !this.Bleached)
        {
          this.Prompt.Label[0].text = "     Pour Bleach";
          this.Prompt.HideButton[0] = false;
        }
        else
          this.Prompt.HideButton[0] = true;
      }
      else if (this.Yandere.PickUp.BrownPaint)
      {
        if (this.Full && !this.Gasoline && (double) this.Bloodiness == 0.0)
        {
          this.Prompt.Label[0].text = "     Add Brown Paint";
          this.Prompt.HideButton[0] = false;
          flag4 = true;
        }
        else
          this.Prompt.HideButton[0] = true;
      }
      else if (this.Dippable)
      {
        this.Prompt.Label[3].text = "     Carry";
        this.Dippable = false;
      }
      if ((Object) this.Yandere.PickUp == (Object) this.PickUp && this.Full)
        this.Prompt.HideButton[0] = false;
    }
    else
    {
      if (this.Dippable)
      {
        this.Prompt.Label[3].text = "     Carry";
        this.Dippable = false;
      }
      if (this.Yandere.Equipped > 0 && (Object) this.Yandere.EquippedWeapon != (Object) null)
      {
        if (!this.Full)
        {
          if (this.Yandere.EquippedWeapon.WeaponID == 12)
          {
            if (this.Dumbbells < 5)
            {
              this.Prompt.Label[0].text = "     Place Dumbbell";
              this.Prompt.HideButton[0] = false;
              flag1 = true;
            }
            else
              this.Prompt.HideButton[0] = true;
          }
          else
            this.Prompt.HideButton[0] = true;
        }
        else
          this.Prompt.HideButton[0] = true;
      }
      else if (!this.Full)
      {
        if (this.Dumbbells == 0)
        {
          this.Prompt.Label[3].text = "     Carry";
          this.Prompt.HideButton[0] = true;
        }
        else
        {
          this.Prompt.Label[0].text = "     Remove Dumbbell";
          this.Prompt.HideButton[0] = false;
          flag2 = true;
        }
      }
    }
    if ((Object) this.Yandere.Mop != (Object) null && this.Dippable && (double) this.Prompt.Circle[3].fillAmount == 0.0)
    {
      this.Prompt.Circle[3].fillAmount = 1f;
      this.Yandere.Bucket = this;
      this.Yandere.Mop.Dip();
    }
    if (this.Dumbbells > 1)
    {
      if (this.Prompt.Yandere.Class.PhysicalGrade + this.Prompt.Yandere.Class.PhysicalBonus == 0)
      {
        this.Prompt.Label[3].text = "     Physical Stat Too Low";
        this.Prompt.Circle[3].fillAmount = 1f;
      }
      else
        this.Prompt.Label[3].text = "     Carry";
    }
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (flag1)
      {
        ++this.Dumbbells;
        this.Dumbbell[this.Dumbbells] = this.Yandere.EquippedWeapon.gameObject;
        this.Yandere.EmptyHands();
        this.Dumbbell[this.Dumbbells].GetComponent<WeaponScript>().enabled = false;
        this.Dumbbell[this.Dumbbells].GetComponent<PromptScript>().enabled = false;
        this.Dumbbell[this.Dumbbells].GetComponent<PromptScript>().Hide();
        this.Dumbbell[this.Dumbbells].GetComponent<Collider>().enabled = false;
        Rigidbody component = this.Dumbbell[this.Dumbbells].GetComponent<Rigidbody>();
        component.useGravity = false;
        component.isKinematic = true;
        this.Dumbbell[this.Dumbbells].transform.parent = this.transform;
        this.Dumbbell[this.Dumbbells].transform.localPosition = this.Positions[this.Dumbbells].localPosition;
        this.Dumbbell[this.Dumbbells].transform.localEulerAngles = new Vector3(90f, 0.0f, 0.0f);
      }
      else if (flag2)
      {
        this.Yandere.EmptyHands();
        this.Dumbbell[this.Dumbbells].GetComponent<WeaponScript>().enabled = true;
        this.Dumbbell[this.Dumbbells].GetComponent<PromptScript>().enabled = true;
        this.Dumbbell[this.Dumbbells].GetComponent<WeaponScript>().Prompt.Circle[3].fillAmount = 0.0f;
        this.Dumbbell[this.Dumbbells].GetComponent<Rigidbody>().isKinematic = false;
        this.Dumbbell[this.Dumbbells] = (GameObject) null;
        --this.Dumbbells;
        if (this.Dumbbells == 0)
          this.Prompt.Label[3].text = "     Carry";
      }
      else if (flag3)
      {
        this.Gasoline = true;
        this.Fill();
      }
      else if (flag4)
      {
        this.DyedBrown = true;
        this.Fill();
      }
      else if ((Object) this.Yandere.PickUp == (Object) this.PickUp)
      {
        this.Spill();
      }
      else
      {
        this.Sparkles.Play();
        this.Bleached = true;
      }
    }
    if (this.UpdateAppearance)
    {
      if (this.Full)
      {
        if (this.Gasoline)
        {
          this.Gas.transform.localScale = Vector3.Lerp(this.Gas.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f * this.FillSpeed);
          this.Gas.transform.localPosition = new Vector3(this.Gas.transform.localPosition.x, Mathf.Lerp(this.Gas.transform.localPosition.y, 0.2f, Time.deltaTime * 5f * this.FillSpeed), this.Gas.transform.localPosition.z);
          this.Gas.material.color = new Color(this.Gas.material.color.r, this.Gas.material.color.g, this.Gas.material.color.b, Mathf.Lerp(this.Gas.material.color.a, 1f, Time.deltaTime * 5f));
        }
        else if (this.DyedBrown)
        {
          this.Brown.transform.localScale = Vector3.Lerp(this.Brown.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f * this.FillSpeed);
          this.Brown.transform.localPosition = new Vector3(this.Brown.transform.localPosition.x, Mathf.Lerp(this.Brown.transform.localPosition.y, 0.21f, Time.deltaTime * 5f * this.FillSpeed), this.Brown.transform.localPosition.z);
          this.Brown.material.color = new Color(this.Brown.material.color.r, this.Brown.material.color.g, this.Brown.material.color.b, Mathf.Lerp(this.Brown.material.color.a, 1f, Time.deltaTime * 5f));
        }
        else
        {
          this.Water.transform.localScale = Vector3.Lerp(this.Water.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f * this.FillSpeed);
          this.Water.transform.localPosition = new Vector3(this.Water.transform.localPosition.x, Mathf.Lerp(this.Water.transform.localPosition.y, 0.2f, Time.deltaTime * 5f * this.FillSpeed), this.Water.transform.localPosition.z);
          this.Water.material.color = new Color(this.Water.material.color.r, this.Water.material.color.g, this.Water.material.color.b, Mathf.Lerp(this.Water.material.color.a, 1f, Time.deltaTime * 5f));
        }
      }
      else
      {
        this.Water.transform.localScale = Vector3.Lerp(this.Water.transform.localScale, new Vector3(0.9f, 1f, 0.9f), Time.deltaTime * 5f);
        this.Water.transform.localPosition = new Vector3(this.Water.transform.localPosition.x, Mathf.Lerp(this.Water.transform.localPosition.y, 0.0f, Time.deltaTime * 5f), this.Water.transform.localPosition.z);
        this.Water.material.color = new Color(this.Water.material.color.r, this.Water.material.color.g, this.Water.material.color.b, Mathf.Lerp(this.Water.material.color.a, 0.0f, Time.deltaTime * 5f));
        this.Gas.transform.localScale = Vector3.Lerp(this.Gas.transform.localScale, new Vector3(0.9f, 1f, 0.9f), Time.deltaTime * 5f);
        this.Gas.transform.localPosition = new Vector3(this.Gas.transform.localPosition.x, Mathf.Lerp(this.Gas.transform.localPosition.y, 0.0f, Time.deltaTime * 5f), this.Gas.transform.localPosition.z);
        this.Gas.material.color = new Color(this.Gas.material.color.r, this.Gas.material.color.g, this.Gas.material.color.b, Mathf.Lerp(this.Gas.material.color.a, 0.0f, Time.deltaTime * 5f));
        this.Brown.transform.localPosition = new Vector3(this.Brown.transform.localPosition.x, Mathf.Lerp(this.Brown.transform.localPosition.y, 0.0f, Time.deltaTime * 5f), this.Brown.transform.localPosition.z);
        this.Brown.material.color = new Color(this.Brown.material.color.r, this.Brown.material.color.g, this.Brown.material.color.b, Mathf.Lerp(this.Brown.material.color.a, 0.0f, Time.deltaTime * 5f));
      }
      this.Blood.material.color = new Color(this.Blood.material.color.r, this.Blood.material.color.g, this.Blood.material.color.b, Mathf.Lerp(this.Blood.material.color.a, this.Bloodiness / 100f, Time.deltaTime));
      this.Blood.transform.localPosition = new Vector3(this.Blood.transform.localPosition.x, this.Water.transform.localPosition.y + 1f / 1000f, this.Blood.transform.localPosition.z);
      this.Blood.transform.localScale = this.Water.transform.localScale;
      this.Timer = Mathf.MoveTowards(this.Timer, 5f, Time.deltaTime);
      if ((double) this.Timer == 5.0)
      {
        this.UpdateAppearance = false;
        this.Timer = 0.0f;
      }
    }
    if ((Object) this.Yandere.PickUp != (Object) null)
    {
      if ((Object) this.Yandere.PickUp.Bucket == (Object) this)
      {
        this.Prompt.HideButton[3] = true;
        this.Prompt.HideButton[0] = !this.Full;
      }
      else if (!this.Trap)
        this.Prompt.enabled = true;
    }
    else if (!this.Trap)
      this.Prompt.enabled = true;
    if (this.Fly)
    {
      if ((double) this.Rotate < 360.0)
      {
        if ((double) this.Rotate == 0.0)
        {
          if ((double) this.Bloodiness < 50.0)
          {
            if (this.Gasoline)
            {
              this.Effect = Object.Instantiate<GameObject>(this.GasSpillEffect, this.transform.position + this.transform.forward * 0.5f + this.transform.up * 0.5f, this.transform.rotation);
              this.Gasoline = false;
              Debug.Log((object) "Spilled Gas");
            }
            else if (this.DyedBrown)
            {
              this.Effect = Object.Instantiate<GameObject>(this.BrownSpillEffect, this.transform.position + this.transform.forward * 0.5f + this.transform.up * 0.5f, this.transform.rotation);
              this.DyedBrown = false;
              Debug.Log((object) "Spilled Mud");
            }
            else
            {
              this.Effect = Object.Instantiate<GameObject>(this.SpillEffect, this.transform.position + this.transform.forward * 0.5f + this.transform.up * 0.5f, this.transform.rotation);
              Debug.Log((object) "Spilled Water");
            }
          }
          else
          {
            this.Effect = Object.Instantiate<GameObject>(this.BloodSpillEffect, this.transform.position + this.transform.forward * 0.5f + this.transform.up * 0.5f, this.transform.rotation);
            this.Bloodiness = 0.0f;
            Debug.Log((object) "Spilled Blood");
          }
          if (this.Trap)
          {
            this.Effect.transform.LookAt(this.Effect.transform.position - Vector3.up);
          }
          else
          {
            Rigidbody component = this.GetComponent<Rigidbody>();
            component.AddRelativeForce(Vector3.forward * 150f);
            component.AddRelativeForce(Vector3.up * 250f);
            this.transform.Translate(Vector3.forward * 0.5f);
          }
          this.UpdateAppearance = true;
          this.Bloodiness = 0.0f;
          this.Bleached = false;
          this.Gasoline = false;
          this.Sparkles.Stop();
          this.Full = false;
        }
        this.Rotate += Time.deltaTime * 360f;
        this.transform.Rotate(Vector3.right * Time.deltaTime * 360f);
      }
      else
      {
        this.Sparkles.Stop();
        this.Rotate = 0.0f;
        this.Trap = false;
        this.Fly = false;
      }
    }
    if (!this.Dropped || (double) this.transform.position.y >= 0.5)
      return;
    this.gameObject.layer = 15;
    this.Dropped = false;
  }

  public void Empty()
  {
    if (SchemeGlobals.GetSchemeStage(1) == 2)
    {
      SchemeGlobals.SetSchemeStage(1, 1);
      this.Yandere.PauseScreen.Schemes.UpdateInstructions();
    }
    AudioSource.PlayClipAtPoint(this.EmptyBucket, this.transform.position);
    this.UpdateAppearance = true;
    this.StudentBloodID = 0;
    this.Bloodiness = 0.0f;
    this.DyedBrown = false;
    this.Bleached = false;
    this.Gasoline = false;
    this.Sparkles.Stop();
    this.Full = false;
    this.Prompt.HideButton[0] = true;
    this.Prompt.OffsetY[0] = 0.5f;
    this.PickUp.Usable = false;
    this.PickUp.Outline[0].color = new Color(0.0f, 1f, 1f, 1f);
  }

  public void Fill()
  {
    AudioSource.PlayClipAtPoint(this.FillBucket, this.transform.position);
    this.Prompt.Label[0].text = "     Spill";
    this.Prompt.HideButton[0] = false;
    this.Prompt.OffsetY[0] = 0.125f;
    this.Prompt.Carried = true;
    this.Prompt.enabled = true;
    this.PickUp.Usable = true;
    this.UpdateAppearance = true;
    this.Full = true;
  }

  private void OnCollisionEnter(Collision other)
  {
    if (!this.Dropped)
      return;
    StudentScript component1 = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component1 != (Object) null))
      return;
    this.GetComponent<AudioSource>().Play();
    for (; this.Dumbbells > 0; --this.Dumbbells)
    {
      Debug.Log((object) "Setting a Dumbbell's ''isTrigger'' boolean to ''true''...");
      this.Dumbbell[this.Dumbbells].GetComponent<WeaponScript>().enabled = true;
      this.Dumbbell[this.Dumbbells].GetComponent<PromptScript>().enabled = true;
      this.Dumbbell[this.Dumbbells].GetComponent<Collider>().isTrigger = false;
      this.Dumbbell[this.Dumbbells].GetComponent<Collider>().enabled = true;
      Rigidbody component2 = this.Dumbbell[this.Dumbbells].GetComponent<Rigidbody>();
      component2.constraints = RigidbodyConstraints.None;
      component2.isKinematic = false;
      component2.useGravity = true;
      this.Dumbbell[this.Dumbbells].transform.parent = (Transform) null;
      this.Dumbbell[this.Dumbbells] = (GameObject) null;
    }
    component1.DeathType = DeathType.Weight;
    component1.BecomeRagdoll();
    this.Dropped = false;
    GameObjectUtils.SetLayerRecursively(this.gameObject, 15);
    component1.MapMarker.gameObject.layer = 10;
    Debug.Log((object) (component1.Name + "'s ''Alive'' variable is: " + component1.Alive.ToString()));
  }

  public void Spill()
  {
    if (this.Yandere.StudentManager.GardenArea.bounds.Contains(this.Yandere.transform.position) || this.Yandere.StudentManager.NEStairs.bounds.Contains(this.Yandere.transform.position) || this.Yandere.StudentManager.NWStairs.bounds.Contains(this.Yandere.transform.position) || this.Yandere.StudentManager.SEStairs.bounds.Contains(this.Yandere.transform.position) || this.Yandere.StudentManager.SWStairs.bounds.Contains(this.Yandere.transform.position) || this.Yandere.StudentManager.PoolStairs.bounds.Contains(this.Yandere.transform.position))
    {
      this.Yandere.NotificationManager.CustomText = "Not here!";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
    else
    {
      GameObject gameObject = Object.Instantiate<GameObject>(!this.DyedBrown ? ((double) this.Bloodiness <= 50.0 ? (!this.Gasoline ? this.Yandere.StudentManager.WaterCooler.Tripwire.WaterPuddle : this.Yandere.StudentManager.WaterCooler.Tripwire.GasolinePuddle) : this.Yandere.StudentManager.WaterCooler.Tripwire.BloodPuddle) : this.Yandere.StudentManager.WaterCooler.Tripwire.BrownPaintPuddle, this.Yandere.transform.position + this.Yandere.transform.forward * 0.5f + new Vector3(0.0f, 0.0001f, 0.0f), Quaternion.identity);
      gameObject.transform.eulerAngles = new Vector3(90f, 0.0f, 0.0f);
      gameObject.transform.parent = (double) this.Bloodiness <= 50.0 ? this.Yandere.StudentManager.PuddleParent.transform : this.Yandere.StudentManager.BloodParent.transform;
      this.Empty();
      this.Yandere.SuspiciousActionTimer = 1f;
    }
  }
}
