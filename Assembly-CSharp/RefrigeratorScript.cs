// Decompiled with JetBrains decompiler
// Type: RefrigeratorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RefrigeratorScript : MonoBehaviour
{
  public CookingEventScript CookingEvent;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public PickUpScript PlatePickUp;
  public PromptScript PlatePrompt;
  public Collider PlateCollider;
  public GameObject[] Octodogs;
  public GameObject Refrigerator;
  public GameObject Octodog;
  public GameObject Sausage;
  public Transform CookingSpot;
  public Transform CookingClub;
  public Transform JarLid;
  public Transform Knife;
  public Transform Jar;
  public bool Empty;
  public int EventPhase;
  public float Rotation;

  private void Start()
  {
    if (!this.Empty)
      return;
    this.enabled = false;
    this.Prompt.enabled = false;
    this.Prompt.Hide();
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
      {
        this.CookingEvent.EventCheck = false;
        this.Yandere.EmptyHands();
        this.Yandere.CanMove = false;
        this.Yandere.Cooking = true;
      }
    }
    if (!this.Yandere.Cooking)
      return;
    this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, Quaternion.LookRotation(new Vector3(this.Octodogs[1].transform.position.x, this.Yandere.transform.position.y, this.Octodogs[1].transform.position.z) - this.Yandere.transform.position), Time.deltaTime * 10f);
    this.Yandere.MoveTowardsTarget(this.CookingSpot.position);
    if (this.EventPhase == 0)
    {
      this.Yandere.Character.GetComponent<Animation>().Play("f02_prepareFood_00");
      this.Octodog.transform.parent = this.Yandere.RightHand;
      this.Octodog.transform.localPosition = new Vector3(0.0129f, -0.02475f, 0.0316f);
      this.Octodog.transform.localEulerAngles = new Vector3(-90f, 0.0f, 0.0f);
      this.Sausage.transform.parent = this.Yandere.RightHand;
      this.Sausage.transform.localPosition = new Vector3(0.013f, -0.038f, 0.015f);
      this.Sausage.transform.localEulerAngles = Vector3.zero;
      ++this.EventPhase;
    }
    else if (this.EventPhase == 1)
    {
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].time <= 1.0)
        return;
      ++this.EventPhase;
    }
    else if (this.EventPhase == 2)
    {
      this.Refrigerator.GetComponent<Animation>().Play("FridgeOpen");
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].time <= 3.0)
        return;
      this.Jar.parent = this.Yandere.RightHand;
      this.Jar.localPosition = new Vector3(0.0f, -0.0333333351f, -0.14f);
      this.Jar.localEulerAngles = new Vector3(90f, 0.0f, 0.0f);
      ++this.EventPhase;
    }
    else if (this.EventPhase == 3)
    {
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].time <= 5.0)
        return;
      this.JarLid.transform.parent = this.Yandere.LeftHand;
      this.JarLid.localPosition = new Vector3(0.0333333351f, 0.0f, 0.0f);
      this.JarLid.localEulerAngles = Vector3.zero;
      ++this.EventPhase;
    }
    else if (this.EventPhase == 4)
    {
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].time <= 6.0)
        return;
      this.JarLid.parent = this.CookingClub;
      this.JarLid.localPosition = new Vector3(0.334585f, 1f, -0.2528915f);
      this.JarLid.localEulerAngles = new Vector3(0.0f, 30f, 0.0f);
      this.Jar.parent = this.CookingClub;
      this.Jar.localPosition = new Vector3(0.29559f, 1f, 0.2029152f);
      this.Jar.localEulerAngles = new Vector3(0.0f, -150f, 0.0f);
      ++this.EventPhase;
    }
    else if (this.EventPhase == 5)
    {
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].time <= 7.0)
        return;
      this.Knife.GetComponent<WeaponScript>().FingerprintID = 100;
      this.Knife.parent = this.Yandere.LeftHand;
      this.Knife.localPosition = new Vector3(0.0f, -0.01f, 0.0f);
      this.Knife.localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
      ++this.EventPhase;
    }
    else if (this.EventPhase == 6)
    {
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].time < (double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].length)
        return;
      this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_cutFood_00");
      this.Sausage.SetActive(true);
      ++this.EventPhase;
    }
    else if (this.EventPhase == 7)
    {
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_cutFood_00"].time <= 2.6666600704193115)
        return;
      this.Octodog.SetActive(true);
      this.Sausage.SetActive(false);
      ++this.EventPhase;
    }
    else if (this.EventPhase == 8)
    {
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_cutFood_00"].time > 3.0)
      {
        this.Rotation = Mathf.MoveTowards(this.Rotation, 90f, Time.deltaTime * 360f);
        this.Octodog.transform.localEulerAngles = new Vector3(this.Rotation, this.Octodog.transform.localEulerAngles.y, this.Octodog.transform.localEulerAngles.z);
        this.Octodog.transform.localPosition = new Vector3(this.Octodog.transform.localPosition.x, this.Octodog.transform.localPosition.y, Mathf.MoveTowards(this.Octodog.transform.localPosition.z, 0.012f, Time.deltaTime));
      }
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_cutFood_00"].time <= 6.0)
        return;
      this.Octodog.SetActive(false);
      for (int index = 1; index < this.Octodogs.Length; ++index)
        this.Octodogs[index].SetActive(true);
      ++this.EventPhase;
    }
    else if (this.EventPhase == 9)
    {
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_cutFood_00"].time < (double) this.Yandere.Character.GetComponent<Animation>()["f02_cutFood_00"].length)
        return;
      this.Yandere.Character.GetComponent<Animation>().Play("f02_prepareFood_00");
      this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].time = this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].length;
      this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].speed = -1f;
      ++this.EventPhase;
    }
    else if (this.EventPhase == 10)
    {
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].time >= (double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].length - 1.0)
        return;
      this.Knife.parent = this.CookingClub;
      this.Knife.localPosition = new Vector3(0.197f, 1.1903f, -0.333333343f);
      this.Knife.localEulerAngles = new Vector3(45f, -90f, -90f);
      ++this.EventPhase;
    }
    else if (this.EventPhase == 11)
    {
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].time >= (double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].length - 2.0)
        return;
      this.JarLid.parent = this.Yandere.LeftHand;
      this.JarLid.localPosition = new Vector3(0.0333333351f, 0.0f, 0.0f);
      this.JarLid.localEulerAngles = Vector3.zero;
      this.Jar.parent = this.Yandere.RightHand;
      this.Jar.localPosition = new Vector3(0.0f, -0.0333333351f, -0.14f);
      this.Jar.localEulerAngles = new Vector3(90f, 0.0f, 0.0f);
      ++this.EventPhase;
    }
    else if (this.EventPhase == 12)
    {
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].time >= (double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].length - 3.0)
        return;
      this.JarLid.parent = this.Jar;
      this.JarLid.localPosition = new Vector3(0.0f, 0.175f, 0.0f);
      this.JarLid.localEulerAngles = Vector3.zero;
      this.Refrigerator.GetComponent<Animation>().Play("FridgeOpen");
      this.Refrigerator.GetComponent<Animation>()["FridgeOpen"].time = this.Refrigerator.GetComponent<Animation>()["FridgeOpen"].length;
      this.Refrigerator.GetComponent<Animation>()["FridgeOpen"].speed = -1f;
      ++this.EventPhase;
    }
    else if (this.EventPhase == 13)
    {
      if ((double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].time >= (double) this.Yandere.Character.GetComponent<Animation>()["f02_prepareFood_00"].length - 5.0)
        return;
      this.Jar.parent = this.CookingClub;
      this.Jar.localPosition = new Vector3(0.1f, 0.941f, 0.75f);
      this.Jar.localEulerAngles = new Vector3(0.0f, 90f, 0.0f);
      ++this.EventPhase;
    }
    else
    {
      if (this.EventPhase != 14 || (double) this.Yandere.CharacterAnimation["f02_prepareFood_00"].time > 0.0)
        return;
      this.PlateCollider.enabled = true;
      this.PlatePickUp.enabled = true;
      this.PlatePrompt.enabled = true;
      this.Yandere.Cooking = false;
      this.Yandere.CanMove = true;
      this.Empty = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.enabled = false;
    }
  }
}
