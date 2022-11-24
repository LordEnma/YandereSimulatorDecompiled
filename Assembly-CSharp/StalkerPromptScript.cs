// Decompiled with JetBrains decompiler
// Type: StalkerPromptScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class StalkerPromptScript : MonoBehaviour
{
  public StalkerPromptScript ExitPrompt;
  public FamilyVoiceScript FatherVoice;
  public StalkerYandereScript Yandere;
  public SmoothLookAtScript Cat;
  public StalkerScript Stalker;
  public GameObject DomesticDispute;
  public GameObject StairBlocker;
  public GameObject CatPrompt;
  public GameObject FrontDoor;
  public GameObject Button;
  public GameObject Father;
  public GameObject Mother;
  public GameObject Lights;
  public GameObject Fire;
  public UILabel BagsToBurnLabel;
  public UILabel Label;
  public Transform KitchenDoor;
  public Transform CatCage;
  public Transform Door;
  public AudioSource FireAudio;
  public AudioSource MyAudio;
  public AudioClip SwingOpen;
  public AudioClip PowerDown;
  public UISprite MySprite;
  public Renderer Darkness;
  public bool ServedPurpose;
  public bool Eighties;
  public bool OpenDoor;
  public bool FadeOut;
  public bool Open;
  public float TargetRotation = 5.5f;
  public float MaximumDistance = 5f;
  public float MinimumDistance = 2f;
  public float Rotation;
  public float Alpha;
  public float Speed;
  public int BagsToBurn;
  public int BagID;
  public int ID;

  private void Start()
  {
    this.Eighties = GameGlobals.Eighties;
    if (!this.Eighties)
      return;
    if (this.ID == 1)
    {
      if (this.BagID <= DateGlobals.Week)
        return;
      this.gameObject.SetActive(false);
    }
    else
    {
      if (this.ID != 5)
        return;
      this.BagsToBurn = DateGlobals.Week;
      this.BagsToBurnLabel.text = "BAGS TO BURN: " + this.BagsToBurn.ToString();
      this.gameObject.SetActive(false);
    }
  }

  private void Update()
  {
    this.transform.LookAt(this.Yandere.MainCamera.transform);
    if ((double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < (double) this.MaximumDistance)
    {
      this.Alpha = this.ServedPurpose ? Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime) : ((double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) >= (double) this.MinimumDistance ? Mathf.MoveTowards(this.Alpha, 0.5f, Time.deltaTime) : Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime));
      if ((double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < (double) this.MinimumDistance && !this.ServedPurpose && Input.GetButtonDown("A"))
      {
        if (!this.Eighties)
        {
          if (this.ID == 1)
          {
            this.Yandere.MyAnimation.CrossFade("f02_climbTrellis_00");
            this.CatPrompt.SetActive(true);
            this.Yandere.Climbing = true;
            this.Yandere.CanMove = false;
            Object.Destroy((Object) this.gameObject);
            Object.Destroy((Object) this.MySprite);
          }
          else if (this.ID == 2)
          {
            this.CatPrompt.SetActive(true);
            this.Stalker.enabled = true;
            this.ServedPurpose = true;
            this.OpenDoor = true;
            this.MyAudio.Play();
          }
          else if (this.ID == 3)
          {
            this.BeginCarryingCat();
            this.Door.transform.localEulerAngles = Vector3.zero;
            this.KitchenDoor.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
            this.Father.SetActive(false);
            this.Mother.SetActive(false);
            this.DomesticDispute.SetActive(true);
            this.StairBlocker.SetActive(true);
            this.FrontDoor.SetActive(true);
            this.Cat.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            this.Cat.enabled = false;
            this.MyAudio.Play();
            this.gameObject.SetActive(false);
            Object.Destroy((Object) this.MySprite);
            this.Stalker.Limit = 10;
          }
          else if (this.ID == 4)
          {
            this.CatCage.gameObject.SetActive(true);
            this.ServedPurpose = true;
            this.OpenDoor = true;
            this.MyAudio.Play();
          }
          else if (this.ID == 5)
          {
            this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
            this.Yandere.CanMove = false;
            this.ServedPurpose = true;
            this.OpenDoor = true;
            this.MyAudio.Play();
          }
          else if (this.ID == 6)
          {
            if (!this.Open)
            {
              this.MyAudio.clip = this.SwingOpen;
              this.MyAudio.Play();
              this.Label.text = "Sabotage";
              this.Open = true;
            }
            else
            {
              this.FatherVoice.MyAnimation.CrossFade("walkConfident_00");
              this.FatherVoice.Investigating = true;
              AudioSource.PlayClipAtPoint(this.PowerDown, Camera.main.transform.position);
              this.Lights.SetActive(false);
              this.ServedPurpose = true;
            }
          }
        }
        else if (this.ID == 1)
        {
          this.ExitPrompt.CountBags();
          this.Fire.SetActive(true);
          this.ServedPurpose = true;
          this.MyAudio.Play();
        }
        else if (this.ID == 2)
        {
          this.Yandere.Pebbles = 10;
          this.Yandere.UpdatePebbles();
          this.MyAudio.Play();
        }
        else if (this.ID == 3)
        {
          if (this.Yandere.CanMove)
          {
            this.Door.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            this.Yandere.transform.localScale = new Vector3(0.0f, 1f, 0.0f);
            this.Yandere.Invisible = true;
            this.Yandere.CanMove = false;
            this.Label.text = "Exit";
            this.MyAudio.clip = this.PowerDown;
          }
          else
          {
            this.Door.transform.localEulerAngles = new Vector3(0.0f, 135f, 0.0f);
            this.Yandere.transform.localScale = new Vector3(1f, 1f, 1f);
            this.Yandere.Invisible = false;
            this.Yandere.CanMove = true;
            this.Label.text = "Hide";
            this.MyAudio.clip = this.SwingOpen;
          }
          this.MyAudio.Play();
        }
        else if (this.ID == 4)
        {
          AudioSource.PlayClipAtPoint(this.PowerDown, Camera.main.transform.position);
          if (this.BagID == 1)
            this.Yandere.LethalPoison = true;
          else if (this.BagID == 2)
            this.Yandere.Sedative = true;
          else if (this.BagID == 3)
            this.Yandere.Cigs = true;
          this.transform.parent.parent.gameObject.SetActive(false);
        }
        else if (this.ID == 5)
        {
          this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
          this.BagsToBurnLabel.gameObject.SetActive(false);
          this.Yandere.CanMove = false;
          this.ServedPurpose = true;
          this.FadeOut = true;
          this.MyAudio.Play();
        }
      }
    }
    else
    {
      if (!this.Eighties && (this.ID == 1 || this.ID == 6) && (double) this.Yandere.transform.position.x > -11.0 && (double) this.Yandere.transform.position.x < 11.0 && (double) this.Yandere.transform.position.z > -11.0 && (double) this.Yandere.transform.position.z < 11.0)
      {
        if (this.ID == 1)
          this.CatPrompt.SetActive(true);
        this.ServedPurpose = true;
      }
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime);
    }
    if ((Object) this.Label != (Object) null && (Object) this.Door != (Object) null && !this.Eighties)
    {
      if (this.Open)
        this.Door.transform.localEulerAngles = Vector3.Lerp(this.Door.transform.localEulerAngles, new Vector3(this.Door.transform.localEulerAngles.x, 180f, this.Door.transform.localEulerAngles.z), Time.deltaTime * 10f);
      else
        this.Door.transform.localEulerAngles = Vector3.Lerp(this.Door.transform.localEulerAngles, new Vector3(this.Door.transform.localEulerAngles.x, 0.0f, this.Door.transform.localEulerAngles.z), Time.deltaTime * 10f);
    }
    if (this.OpenDoor)
    {
      this.Speed += Time.deltaTime * 0.1f;
      this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * this.Speed);
      this.Door.transform.localEulerAngles = new Vector3(this.Door.transform.localEulerAngles.x, this.Rotation, this.Door.transform.localEulerAngles.z);
      if (this.ID == 5)
      {
        this.Darkness.material.color = new Color(0.0f, 0.0f, 0.0f, this.Darkness.material.color.a + Time.deltaTime * 0.33333f);
        if ((double) this.Darkness.material.color.a >= 1.0)
        {
          EventGlobals.OsanaConversation = true;
          SceneManager.LoadScene("PhoneScene");
        }
      }
    }
    if (this.FadeOut)
    {
      this.Darkness.material.color = new Color(0.0f, 0.0f, 0.0f, this.Darkness.material.color.a + Time.deltaTime * 0.33333f);
      this.MyAudio.volume -= Time.deltaTime;
      if ((double) this.Darkness.material.color.a >= 1.0)
      {
        if (this.Yandere.LethalPoison)
          PlayerGlobals.BoughtPoison = true;
        if (this.Yandere.Sedative)
          PlayerGlobals.BoughtSedative = true;
        if (this.Yandere.Cigs)
          PlayerGlobals.SetCannotBringItem(6, false);
        SceneManager.LoadScene("LivingRoomScene");
      }
    }
    if ((Object) this.FireAudio != (Object) null)
      this.FireAudio.volume = (double) this.Yandere.transform.position.y >= 1.0 ? 1f : 0.0f;
    this.MySprite.color = new Color(1f, 1f, 1f, this.Alpha);
  }

  public void BeginCarryingCat()
  {
    this.Yandere.MyAnimation["f02_grip_00"].layer = 1;
    this.Yandere.MyAnimation.Play("f02_grip_00");
    this.Yandere.Object = this.CatCage;
    this.CatCage.parent = this.Yandere.RightHand;
    this.CatCage.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.CatCage.localPosition = new Vector3(0.075f, -0.025f, 0.0125f);
    this.CatCage.GetComponent<Rigidbody>().isKinematic = true;
    this.CatCage.GetComponent<Rigidbody>().useGravity = false;
    this.CatCage.GetComponent<Collider>().isTrigger = true;
  }

  public void CountBags()
  {
    --this.BagsToBurn;
    if (this.BagsToBurn == 0)
    {
      this.BagsToBurnLabel.text = "EXIT THE BUILDING FROM THE WINDOW YOU CAME IN FROM!";
      this.gameObject.SetActive(true);
    }
    else
      this.BagsToBurnLabel.text = "BAGS TO BURN: " + this.BagsToBurn.ToString();
  }
}
