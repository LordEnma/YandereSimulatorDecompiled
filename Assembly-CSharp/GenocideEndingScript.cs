// Decompiled with JetBrains decompiler
// Type: GenocideEndingScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class GenocideEndingScript : MonoBehaviour
{
  public UISprite SecondDarkness;
  public UISprite Darkness;
  public AudioSource MyAudio;
  public UISprite SkipCircle;
  public UIPanel SkipPanel;
  public UILabel Subtitle;
  public Animation Senpai;
  public Transform Neck;
  public AudioClip[] EightiesSpeechClip;
  public AudioClip[] SpeechClip;
  public AudioClip OsanaClip;
  public AudioClip Slam;
  public string[] EightiesText;
  public string[] SpeechText;
  public float[] SpeechDelay;
  public float[] SpeechTime;
  public GameObject RIVAL;
  public GameObject ELIMINATED;
  public GameObject SenpaiRopes;
  public GameObject OsanaRopes;
  public GameObject Osana;
  public int SpeechPhase;
  public float SecondAlpha;
  public float FadeSpeed = 0.2f;
  public float TimeLimit;
  public float Alpha;
  public float Delay;
  public float Timer;
  public bool EightiesEnding;
  public bool FadeOut;
  public GameObject[] RivalHair;
  public Font Arial;
  public PostProcessingProfile Profile;

  private void Start()
  {
    this.UpdateDOF(1f);
    Time.timeScale = 1f;
    this.SkipPanel.gameObject.SetActive(false);
    if (GameGlobals.EightiesCutsceneID == 12)
    {
      this.SecondDarkness.color = new Color(0.1f, 0.1f, 0.1f, 0.0f);
      this.Darkness.color = new Color(0.1f, 0.1f, 0.1f, 1f);
      this.SkipPanel.gameObject.SetActive(true);
      this.SkipPanel.alpha = 0.0f;
      Debug.Log((object) "We're here for the end of 1980s Mode.");
      this.SpeechText = this.EightiesText;
      this.Subtitle.text = this.SpeechText[1];
      this.SpeechClip = this.EightiesSpeechClip;
      this.MyAudio.clip = this.SpeechClip[1];
      this.MyAudio.Play();
      this.SpeechPhase = 1;
      this.YellowifyLabel(this.Subtitle);
      this.Senpai["kidnapTorture_01"].speed = 0.1f;
      this.Senpai.Play();
      this.SenpaiRopes.SetActive(true);
      this.OsanaRopes.SetActive(false);
      this.Senpai.transform.parent.gameObject.SetActive(true);
      this.Osana.SetActive(false);
      this.EightiesEnding = true;
      this.FadeSpeed = 0.1f;
    }
    else if (EventGlobals.OsanaConversation)
    {
      Debug.Log((object) "We're here for a Betray cutscene.");
      this.Osana.GetComponent<StudentScript>().CharacterAnimation["f02_kidnapTorture_01"].speed = 0.8f;
      this.Osana.GetComponent<CosmeticScript>().SetFemaleUniform();
      this.SenpaiRopes.SetActive(false);
      this.OsanaRopes.SetActive(true);
      this.Senpai.transform.parent.gameObject.SetActive(false);
      this.Osana.SetActive(true);
      this.SpeechText[10] = "...huh? ...what is this? ...why am I tied to a...chair?! Why are you doing this?! This isn't funny! Lemme go! Lemme go right now!";
      this.Subtitle.text = this.SpeechText[10];
      this.MyAudio.clip = this.OsanaClip;
      this.MyAudio.Play();
      this.SpeechPhase = 10;
      this.TimeLimit = 9f;
      this.Delay = 10f;
      if (!GameGlobals.Eighties)
        return;
      this.RivalHair[0].SetActive(false);
      this.RivalHair[DateGlobals.Week].SetActive(true);
      this.YellowifyLabel(this.Subtitle);
    }
    else
    {
      Debug.Log((object) "We're here for the Genocide Ending.");
      this.Senpai["kidnapTorture_01"].speed = 0.9f;
      this.SenpaiRopes.SetActive(true);
      this.OsanaRopes.SetActive(false);
      this.Senpai.transform.parent.gameObject.SetActive(true);
      this.Osana.SetActive(false);
      GameGlobals.DarkEnding = true;
    }
  }

  private void Update()
  {
    if (!this.EightiesEnding)
    {
      if (this.SpeechPhase > 9)
      {
        this.transform.Translate(Vector3.forward * -0.1f * Time.deltaTime);
        if (this.MyAudio.isPlaying)
        {
          this.Senpai.Play();
          this.Alpha = (double) this.MyAudio.time >= (double) this.TimeLimit ? Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.25f) : Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.25f);
        }
        this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
        if ((double) this.Darkness.color.a == 1.0)
          this.Subtitle.text = "";
      }
      if (this.MyAudio.isPlaying)
        return;
      this.Timer += Time.deltaTime;
      if ((double) this.Delay == 10.0 && (double) this.Timer > 1.0)
      {
        if ((double) this.Timer < 3.0)
        {
          this.RIVAL.SetActive(true);
          this.ELIMINATED.SetActive(true);
        }
        else if ((double) this.Timer < 5.0)
        {
          if (this.ELIMINATED.activeInHierarchy)
          {
            this.ELIMINATED.SetActive(false);
            AudioSource.PlayClipAtPoint(this.Slam, this.transform.position);
          }
        }
        else
        {
          this.SecondAlpha = Mathf.MoveTowards(this.SecondAlpha, 1f, Time.deltaTime * 0.25f);
          this.SecondDarkness.color = new Color(0.0f, 0.0f, 0.0f, this.SecondAlpha);
        }
      }
      if ((double) this.Timer <= (double) this.Delay)
        return;
      ++this.SpeechPhase;
      this.Timer = 0.0f;
      if (this.SpeechPhase < this.SpeechClip.Length)
      {
        this.Subtitle.text = this.SpeechText[this.SpeechPhase];
        this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
        this.Delay = this.SpeechDelay[this.SpeechPhase];
        this.MyAudio.Play();
      }
      else if (!EventGlobals.OsanaConversation)
      {
        SceneManager.LoadScene("CreditsScene");
      }
      else
      {
        DateGlobals.PassDays = 1;
        SceneManager.LoadScene("CalendarScene");
        EventGlobals.OsanaConversation = false;
      }
    }
    else
    {
      this.transform.Translate(Vector3.forward * -0.01f * Time.deltaTime);
      if (!this.FadeOut)
      {
        this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime * this.FadeSpeed);
        if ((double) this.SkipPanel.alpha < 1.0)
          this.SkipPanel.alpha = Mathf.MoveTowards(this.SkipPanel.alpha, 1f, Time.deltaTime);
        else if (Input.GetButton("X"))
        {
          this.SkipCircle.fillAmount += Time.deltaTime;
          if ((double) this.SkipCircle.fillAmount >= 1.0)
          {
            this.FadeOut = true;
            this.FadeSpeed = 1f;
          }
        }
        else
          this.SkipCircle.fillAmount = 0.0f;
      }
      else
      {
        this.SecondDarkness.alpha = Mathf.MoveTowards(this.SecondDarkness.alpha, 1f, Time.deltaTime * this.FadeSpeed);
        if ((double) this.SecondDarkness.alpha == 1.0)
        {
          GameGlobals.DarkEnding = false;
          SceneManager.LoadScene("CreditsScene");
        }
        this.SkipPanel.alpha = Mathf.MoveTowards(this.SkipPanel.alpha, 0.0f, Time.deltaTime);
        if ((double) this.SkipCircle.fillAmount >= 1.0)
          this.MyAudio.volume -= Time.deltaTime;
      }
      if (Input.GetButtonDown("A"))
        this.MyAudio.Stop();
      if (this.MyAudio.isPlaying || this.SpeechPhase >= this.SpeechClip.Length - 1)
        return;
      ++this.SpeechPhase;
      this.Subtitle.text = this.SpeechText[this.SpeechPhase];
      this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
      this.MyAudio.Play();
      if (this.SpeechPhase != this.SpeechClip.Length - 1)
        return;
      this.FadeOut = true;
    }
  }

  private void LateUpdate() => this.Neck.transform.localEulerAngles = new Vector3(0.0f, this.Neck.transform.localEulerAngles.y, this.Neck.transform.localEulerAngles.z);

  public void YellowifyLabel(UILabel Label)
  {
    Label.trueTypeFont = this.Arial;
    Label.applyGradient = false;
    Label.color = new Color(1f, 1f, 0.0f, 1f);
    Label.fontStyle = FontStyle.Bold;
    Label.effectDistance = new Vector2(4f, 4f);
  }

  private void UpdateDOF(float Focus)
  {
    Focus *= (float) (((double) Screen.width / 1280.0 + (double) Screen.height / 720.0) * 0.5);
    this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
    {
      focusDistance = Focus
    };
  }
}
