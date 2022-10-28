// Decompiled with JetBrains decompiler
// Type: BloodPoolScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BloodPoolScript : MonoBehaviour
{
  public PowerSwitchScript PowerSwitch;
  public float TargetSize;
  public bool Gasoline;
  public bool Brown;
  public bool Water;
  public bool Blood = true;
  public bool Grow;
  public GameObject NewElectricity;
  public GameObject Electricity;
  public Renderer MyRenderer;
  public Material BloodPool;
  public Material Flower;
  public float ElectroTimer;
  public int StudentBloodID;

  private void Start()
  {
    if (PlayerGlobals.PantiesEquipped == 11 && this.Blood)
      this.TargetSize *= 0.5f;
    if (GameGlobals.CensorBlood)
      this.MyRenderer.material = this.Flower;
    if (GameGlobals.EightiesTutorial)
      this.TargetSize = 1f;
    this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    Vector3 position = this.transform.position;
    if ((double) position.x > 125.0 || (double) position.x < -125.0 || (double) position.z > 200.0 || (double) position.z < -100.0)
      Object.Destroy((Object) this.gameObject);
    if (Application.loadedLevelName == "IntroScene" || Application.loadedLevelName == "NewIntroScene")
      this.MyRenderer.material.SetColor("_TintColor", new Color(0.1f, 0.1f, 0.1f));
    if (this.Blood)
      return;
    this.gameObject.layer = 2;
  }

  private void Update()
  {
    if (this.Grow)
    {
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(this.TargetSize, this.TargetSize, this.TargetSize), Time.deltaTime);
      if ((double) this.transform.localScale.x > (double) this.TargetSize * 0.99000000953674316)
        this.Grow = false;
    }
    if (!this.Water || (double) this.ElectroTimer <= 0.0)
      return;
    this.ElectroTimer = Mathf.MoveTowards(this.ElectroTimer, 0.0f, Time.deltaTime);
    if ((Object) this.PowerSwitch != (Object) null && this.PowerSwitch.On)
      this.ElectroTimer = 0.1f;
    if ((double) this.ElectroTimer != 0.0)
      return;
    Object.Destroy((Object) this.NewElectricity);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!this.Water || (double) this.ElectroTimer != 0.0 || !(other.gameObject.tag == "E"))
      return;
    this.NewElectricity = Object.Instantiate<GameObject>(this.Electricity, this.transform.position, Quaternion.identity);
    this.ElectroTimer = 1f;
    if (other.gameObject.name == "CarBattery")
    {
      Object.Instantiate<GameObject>(other.gameObject.GetComponent<PickUpScript>().PuddleSparks, this.transform.position, Quaternion.identity);
      other.gameObject.GetComponent<PickUpScript>().Smoke.Play();
      other.gameObject.tag = "Untagged";
    }
    if (!((Object) other.gameObject.GetComponent<ElectrifiedPuddleScript>() != (Object) null) || !((Object) other.gameObject.GetComponent<ElectrifiedPuddleScript>().PowerSwitch != (Object) null))
      return;
    this.PowerSwitch = other.gameObject.GetComponent<ElectrifiedPuddleScript>().PowerSwitch;
    this.NewElectricity.GetComponent<SM_destroyThisTimed>().enabled = false;
  }
}
