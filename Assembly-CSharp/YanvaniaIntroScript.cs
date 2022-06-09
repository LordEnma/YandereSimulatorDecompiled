// Decompiled with JetBrains decompiler
// Type: YanvaniaIntroScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaIntroScript : MonoBehaviour
{
  public YanvaniaZombieSpawnerScript ZombieSpawner;
  public YanvaniaYanmontScript Yanmont;
  public GameObject Jukebox;
  public Transform BlackRight;
  public Transform BlackLeft;
  public UILabel FinalStage;
  public UILabel Heartbreak;
  public UITexture Triangle;
  public float LeaveTime;
  public float Position;
  public float Timer;

  private void Start()
  {
    this.BlackRight.gameObject.SetActive(true);
    this.BlackLeft.gameObject.SetActive(true);
    this.FinalStage.gameObject.SetActive(true);
    this.Heartbreak.gameObject.SetActive(true);
    this.Triangle.gameObject.SetActive(true);
    this.Triangle.transform.localScale = Vector3.zero;
    this.Heartbreak.transform.localPosition = new Vector3(1300f, this.Heartbreak.transform.localPosition.y, this.Heartbreak.transform.localPosition.z);
    this.FinalStage.transform.localPosition = new Vector3(-1300f, this.FinalStage.transform.localPosition.y, this.FinalStage.transform.localPosition.z);
  }

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer > 1.0 && (double) this.Timer < 3.0)
    {
      this.Yanmont.Character.transform.localScale = new Vector3(-1f, this.Yanmont.Character.transform.localScale.y, this.Yanmont.Character.transform.localScale.z);
      if (!this.Jukebox.activeInHierarchy)
        this.Jukebox.SetActive(true);
      this.Triangle.transform.localScale = Vector3.Lerp(this.Triangle.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.Heartbreak.transform.localPosition = new Vector3(Mathf.Lerp(this.Heartbreak.transform.localPosition.x, 0.0f, Time.deltaTime * 10f), this.Heartbreak.transform.localPosition.y, this.Heartbreak.transform.localPosition.z);
      this.FinalStage.transform.localPosition = new Vector3(Mathf.Lerp(this.FinalStage.transform.localPosition.x, 0.0f, Time.deltaTime * 10f), this.FinalStage.transform.localPosition.y, this.FinalStage.transform.localPosition.z);
    }
    else if ((double) this.Timer > 3.0)
    {
      if (!this.Jukebox.activeInHierarchy)
        this.Jukebox.SetActive(true);
      this.Triangle.transform.localEulerAngles = new Vector3(this.Triangle.transform.localEulerAngles.x, this.Triangle.transform.localEulerAngles.y, this.Triangle.transform.localEulerAngles.z + 36f * Time.deltaTime);
      this.Triangle.color = new Color(this.Triangle.color.r, this.Triangle.color.g, this.Triangle.color.b, this.Triangle.color.a - Time.deltaTime);
      this.Heartbreak.color = new Color(this.Heartbreak.color.r, this.Heartbreak.color.g, this.Heartbreak.color.b, this.Heartbreak.color.a - Time.deltaTime);
      this.FinalStage.color = new Color(this.FinalStage.color.r, this.FinalStage.color.g, this.FinalStage.color.b, this.FinalStage.color.a - Time.deltaTime);
    }
    if ((double) this.Timer > 4.0)
      this.Finish();
    if ((double) this.Timer > (double) this.LeaveTime)
    {
      this.Position += (double) this.Position == 0.0 ? Time.deltaTime : this.Position * 0.1f;
      if ((double) this.BlackLeft.localPosition.x > -2100.0)
      {
        this.BlackRight.localPosition = new Vector3(this.BlackRight.localPosition.x + this.Position, this.BlackRight.localPosition.y, this.BlackRight.localPosition.z);
        this.BlackLeft.localPosition = new Vector3(this.BlackLeft.localPosition.x - this.Position, this.BlackLeft.localPosition.y, this.BlackLeft.localPosition.z);
      }
    }
    if (!Input.GetKeyDown(KeyCode.Alpha1))
      return;
    this.Finish();
  }

  private void Finish()
  {
    if (!this.Jukebox.activeInHierarchy)
      this.Jukebox.SetActive(true);
    this.ZombieSpawner.enabled = true;
    this.Yanmont.CanMove = true;
    Object.Destroy((Object) this.gameObject);
  }
}
