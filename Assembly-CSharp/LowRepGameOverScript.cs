// Decompiled with JetBrains decompiler
// Type: LowRepGameOverScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LowRepGameOverScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public YandereScript Yandere;
  public StudentScript Senpai;
  public Renderer Darkness;
  public Transform SenpaiSpot;
  public Transform MyCamera;
  public Transform[] CameraPosition;
  public GameObject[] GossipGroup;
  public AudioClip[] Giggles;
  public float GiggleTimer;
  public float Timer;
  public int PreviousGiggle;
  public int GigglePhase;
  public int GiggleID;
  public int Phase;

  private void Start()
  {
    this.GossipGroup[1].SetActive(false);
    this.GossipGroup[2].SetActive(false);
    this.GossipGroup[3].SetActive(false);
    this.GossipGroup[4].SetActive(false);
    this.GossipGroup[5].SetActive(false);
    this.Senpai = this.StudentManager.Students[1];
    this.Yandere.transform.parent = this.transform;
    this.Yandere.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    this.Yandere.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.Yandere.CharacterAnimation.Play("f02_LowRepGO_A");
    this.Yandere.LifeNotePen.SetActive(false);
    this.MyCamera.eulerAngles = this.CameraPosition[0].eulerAngles;
    this.MyCamera.position = this.CameraPosition[0].position;
    this.Senpai.Chopsticks[0].SetActive(false);
    this.Senpai.Chopsticks[1].SetActive(false);
    this.Senpai.OccultBook.SetActive(false);
    this.Senpai.SmartPhone.SetActive(false);
    this.Senpai.Scrubber.SetActive(false);
    this.Senpai.Eraser.SetActive(false);
    this.Senpai.Bento.SetActive(false);
    this.Senpai.Pen.SetActive(false);
    this.Senpai.enabled = false;
    this.Senpai.CharacterAnimation.enabled = true;
    this.Senpai.MyController.enabled = false;
    this.Senpai.Pathfinding.enabled = false;
    this.Yandere.CameraEffects.UpdateDOF(1f);
    Time.timeScale = 1f;
  }

  private void Update()
  {
    this.Darkness.material.color = new Color(this.Darkness.material.color.r, this.Darkness.material.color.g, this.Darkness.material.color.b, this.Darkness.material.color.a - Time.deltaTime * 0.5f);
    if (this.Phase == 0)
    {
      if ((double) this.Yandere.CharacterAnimation["f02_LowRepGO_A"].time >= 3.0)
        this.GigglePhase = 1;
      if ((double) this.Yandere.CharacterAnimation["f02_LowRepGO_A"].time >= (double) this.Yandere.CharacterAnimation["f02_LowRepGO_A"].length || Input.GetButtonDown("A"))
      {
        this.MyCamera.eulerAngles = this.CameraPosition[1].eulerAngles;
        this.MyCamera.position = this.CameraPosition[1].position;
        this.GossipGroup[1].SetActive(true);
        this.GigglePhase = 1;
        ++this.Phase;
      }
    }
    else if (this.Phase == 1)
    {
      this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * -0.1f;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 2.0 || Input.GetButtonDown("A"))
      {
        this.MyCamera.eulerAngles = this.CameraPosition[2].eulerAngles;
        this.MyCamera.position = this.CameraPosition[2].position;
        this.Yandere.CharacterAnimation.Play("f02_LowRepGO_B");
        this.GossipGroup[1].SetActive(false);
        ++this.GigglePhase;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 2)
    {
      this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * 0.1f;
      if ((double) this.Yandere.CharacterAnimation["f02_LowRepGO_B"].time >= (double) this.Yandere.CharacterAnimation["f02_LowRepGO_B"].length || Input.GetButtonDown("A"))
      {
        this.MyCamera.eulerAngles = this.CameraPosition[3].eulerAngles;
        this.MyCamera.position = this.CameraPosition[3].position;
        this.GossipGroup[2].SetActive(true);
        ++this.Phase;
      }
    }
    else if (this.Phase == 3)
    {
      this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * -0.1f;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 2.0 || Input.GetButtonDown("A"))
      {
        this.MyCamera.eulerAngles = this.CameraPosition[4].eulerAngles;
        this.MyCamera.position = this.CameraPosition[4].position;
        this.Yandere.CharacterAnimation.Play("f02_LowRepGO_C");
        this.GossipGroup[2].SetActive(false);
        ++this.GigglePhase;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 4)
    {
      this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * 0.1f;
      if ((double) this.Yandere.CharacterAnimation["f02_LowRepGO_C"].time >= (double) this.Yandere.CharacterAnimation["f02_LowRepGO_C"].length || Input.GetButtonDown("A"))
      {
        this.MyCamera.eulerAngles = this.CameraPosition[5].eulerAngles;
        this.MyCamera.position = this.CameraPosition[5].position;
        this.GossipGroup[3].SetActive(true);
        ++this.Phase;
      }
    }
    else if (this.Phase == 5)
    {
      this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * -0.1f;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 2.0 || Input.GetButtonDown("A"))
      {
        this.MyCamera.eulerAngles = this.CameraPosition[6].eulerAngles;
        this.MyCamera.position = this.CameraPosition[6].position;
        this.Yandere.CharacterAnimation.Play("f02_LowRepGO_D");
        this.GossipGroup[3].SetActive(false);
        this.GossipGroup[4].SetActive(true);
        ++this.GigglePhase;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 6)
    {
      this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * 0.1f;
      if ((double) this.Yandere.CharacterAnimation["f02_LowRepGO_D"].time >= (double) this.Yandere.CharacterAnimation["f02_LowRepGO_D"].length || Input.GetButtonDown("A"))
      {
        this.MyCamera.eulerAngles = this.CameraPosition[7].eulerAngles;
        this.MyCamera.position = this.CameraPosition[7].position;
        this.Senpai.CharacterAnimation[this.Senpai.AngryFaceAnim].weight = 1f;
        this.Senpai.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
        this.Senpai.transform.position = this.SenpaiSpot.position;
        this.Senpai.CharacterAnimation.Play(this.Senpai.OriginalIdleAnim);
        Physics.SyncTransforms();
        this.GossipGroup[5].SetActive(true);
        ++this.GigglePhase;
        ++this.Phase;
      }
    }
    else if (this.Phase == 7)
    {
      this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * 0.1f;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 2.0 || Input.GetButtonDown("A"))
      {
        this.Senpai.CharacterAnimation["refuse_01"].speed = 0.5f;
        this.Senpai.CharacterAnimation.Play("refuse_01");
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 8)
    {
      this.MyCamera.position += this.MyCamera.forward * Time.deltaTime * 0.1f;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 2.5 || Input.GetButtonDown("A"))
      {
        this.Yandere.CharacterAnimation.Play("f02_scaredIdle_00");
        this.Yandere.ShoulderCamera.GoingToCounselor = false;
        this.Yandere.ShoulderCamera.OverShoulder = false;
        this.Yandere.ShoulderCamera.enabled = true;
        this.Yandere.ShoulderCamera.Noticed = true;
        this.Yandere.ShoulderCamera.Skip = true;
        this.Yandere.StudentManager.Headmaster.Heartbroken.Exposed = true;
        ++this.GigglePhase;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 9)
      this.Timer += Time.deltaTime;
    this.GiggleTimer += Time.deltaTime;
    if (this.GigglePhase == 1)
    {
      if ((double) this.GiggleTimer <= 2.0)
        return;
      this.Giggle();
      this.GiggleTimer = 0.0f;
    }
    else if (this.GigglePhase == 2)
    {
      if ((double) this.GiggleTimer <= 1.0)
        return;
      this.Giggle();
      this.GiggleTimer = 0.0f;
    }
    else if (this.GigglePhase == 3)
    {
      if ((double) this.GiggleTimer <= 0.5)
        return;
      this.Giggle();
      this.GiggleTimer = 0.0f;
    }
    else if (this.GigglePhase == 4)
    {
      if ((double) this.GiggleTimer <= 0.25)
        return;
      this.Giggle();
      this.GiggleTimer = 0.0f;
    }
    else
    {
      if (this.GigglePhase <= 4 || (double) this.GiggleTimer <= 0.125)
        return;
      this.Giggle();
      this.GiggleTimer = 0.0f;
    }
  }

  private void Giggle()
  {
    this.GiggleID = Random.Range(1, this.Giggles.Length);
    while (this.GiggleID == this.PreviousGiggle)
      this.GiggleID = Random.Range(1, this.Giggles.Length);
    this.PreviousGiggle = this.GiggleID;
    if (this.GigglePhase < 6)
      AudioSource.PlayClipAtPoint(this.Giggles[this.GiggleID], this.MyCamera.transform.position);
    else
      AudioSource.PlayClipAtPoint(this.Giggles[this.GiggleID], this.MyCamera.transform.position + Vector3.up * this.Timer);
  }
}
