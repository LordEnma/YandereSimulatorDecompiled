// Decompiled with JetBrains decompiler
// Type: PostCreditsScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class PostCreditsScript : MonoBehaviour
{
  public GameObject LovesickLogo;
  public UITexture Logo;
  public UIPanel SkipPanel;
  public AudioSource Headmaster;
  public AudioSource Jukebox;
  public AudioSource Buzzing;
  public AudioClip CinematicHit;
  public Transform Destination;
  public UISprite SkipCircle;
  public UISprite Darkness;
  public UILabel Subtitle;
  public string[] Lines;
  public float[] Times;
  public float SkipTimer;
  public float Rotation;
  public float Alpha;
  public float Speed;
  public float Timer;
  public bool EndEarly;
  public int SpeechID;
  public int Phase;

  private void Start()
  {
    this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.Subtitle.text = "";
    Time.timeScale = 1f;
    this.Logo.gameObject.SetActive(false);
    this.LovesickLogo.SetActive(false);
  }

  private void Update()
  {
    this.SkipTimer += Time.deltaTime;
    if ((double) this.SkipTimer > 5.0)
      this.SkipPanel.alpha -= Time.deltaTime;
    if (this.EndEarly)
    {
      this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      this.SkipPanel.alpha -= Time.deltaTime;
      this.Headmaster.volume -= Time.deltaTime;
      this.Jukebox.volume -= Time.deltaTime;
      this.Buzzing.volume -= Time.deltaTime;
      this.Darkness.material.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      this.Subtitle.text = "";
      if ((double) this.Alpha == 1.0)
        SceneManager.LoadScene("ThanksForPlayingScene");
    }
    else if (Input.GetButton("X"))
    {
      this.SkipPanel.alpha = 1f;
      this.SkipTimer = 0.0f;
      this.SkipCircle.fillAmount -= Time.deltaTime;
      if ((double) this.SkipCircle.fillAmount == 0.0)
        this.EndEarly = true;
    }
    else
      this.SkipCircle.fillAmount = 1f;
    if (Input.GetKeyDown("="))
      ++Time.timeScale;
    if (Input.GetKeyDown("-"))
      --Time.timeScale;
    this.Speed += Time.deltaTime * (1f / 1000f);
    this.transform.position = Vector3.Lerp(this.transform.position, this.Destination.position, Time.deltaTime * this.Speed);
    this.Rotation = Mathf.Lerp(this.Rotation, -45f, Time.deltaTime * this.Speed);
    this.transform.eulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
    if ((double) this.Headmaster.time > 69.0)
      this.Jukebox.volume -= Time.deltaTime * 0.2f;
    if (this.Phase == 0)
    {
      if (Input.GetKeyDown("space"))
        this.Alpha = 0.0f;
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.2f);
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      if ((double) this.Alpha != 0.0)
        return;
      this.Subtitle.text = this.Lines[this.SpeechID];
      this.Headmaster.Play();
      ++this.SpeechID;
      ++this.Phase;
    }
    else if (this.Phase == 1)
    {
      if (Input.GetKeyDown("space"))
        this.Headmaster.time = 68f;
      this.Headmaster.pitch = Time.timeScale;
      if ((double) this.Headmaster.time < (double) this.Times[this.SpeechID])
        return;
      this.Subtitle.text = this.Lines[this.SpeechID];
      ++this.SpeechID;
      if (this.SpeechID == 16)
      {
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
      }
      else
      {
        if (this.SpeechID != 17)
          return;
        this.Jukebox.clip = this.CinematicHit;
        this.Jukebox.volume = 1f;
        this.Jukebox.Play();
        this.Logo.gameObject.SetActive(true);
        ++this.Phase;
      }
    }
    else
    {
      if (this.Phase != 2)
        return;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 13.0)
        SceneManager.LoadScene("ThanksForPlayingScene");
      else if ((double) this.Timer > 5.0)
        this.Logo.alpha -= Time.deltaTime * 0.2f;
      this.Logo.transform.localScale += new Vector3(Time.deltaTime * 0.02f, Time.deltaTime * 0.02f, Time.deltaTime * 0.02f);
      this.LovesickLogo.transform.localScale += new Vector3(Time.deltaTime * 0.02f, Time.deltaTime * 0.02f, Time.deltaTime * 0.02f);
    }
  }
}
