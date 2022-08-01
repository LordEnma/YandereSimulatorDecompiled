// Decompiled with JetBrains decompiler
// Type: BloodPoolScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BloodPoolScript : MonoBehaviour
{
  public float TargetSize;
  public bool Gasoline;
  public bool Brown;
  public bool Water;
  public bool Blood = true;
  public bool Grow;
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
      if ((double) this.transform.localScale.x > (double) this.TargetSize * 0.990000009536743)
        this.Grow = false;
    }
    if (!this.Water || (double) this.ElectroTimer <= 0.0)
      return;
    this.ElectroTimer = Mathf.MoveTowards(this.ElectroTimer, 0.0f, Time.deltaTime);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!this.Water || (double) this.ElectroTimer != 0.0 || !(other.gameObject.tag == "E"))
      return;
    Object.Instantiate<GameObject>(this.Electricity, this.transform.position, Quaternion.identity);
    this.ElectroTimer = 1f;
    if (!(other.gameObject.name == "CarBattery"))
      return;
    Object.Instantiate<GameObject>(other.gameObject.GetComponent<PickUpScript>().PuddleSparks, this.transform.position, Quaternion.identity);
    other.gameObject.GetComponent<PickUpScript>().Smoke.Play();
    other.gameObject.tag = "Untagged";
  }
}
