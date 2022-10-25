// Decompiled with JetBrains decompiler
// Type: LifeNoteScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeNoteScript : MonoBehaviour
{
  public UITexture Darkness;
  public UITexture TextWindow;
  public UITexture FinalDarkness;
  public Transform BackgroundArt;
  public TypewriterEffect Typewriter;
  public GameObject Controls;
  public AudioSource MyAudio;
  public AudioClip[] Voices;
  public string[] Lines;
  public int[] Alphas;
  public bool[] Reds;
  public UILabel Label;
  public float Timer;
  public int Frame;
  public int ID;
  public float AutoTimer;
  public float Alpha;
  public string Text;
  public AudioClip[] SFX;
  public bool Spoke;
  public bool Auto;
  public AudioSource SFXAudioSource;
  public AudioSource Jukebox;

  private void Start()
  {
    Application.targetFrameRate = 60;
    this.Label.text = this.Lines[this.ID];
    this.Controls.SetActive(false);
    this.Label.gameObject.SetActive(false);
    this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.BackgroundArt.localPosition = new Vector3(0.0f, -540f, 0.0f);
    this.BackgroundArt.localScale = new Vector3(2.5f, 2.5f, 1f);
    this.TextWindow.color = new Color(1f, 1f, 1f, 0.0f);
  }

  private void Update()
  {
    if (this.Controls.activeInHierarchy)
    {
      if (this.Typewriter.mCurrentOffset == 1)
      {
        if (this.Reds[this.ID])
          this.Label.color = new Color(1f, 0.0f, 0.0f, 1f);
        else
          this.Label.color = new Color(1f, 1f, 1f, 1f);
      }
      if (Input.GetButtonDown("A") || (double) this.AutoTimer > 0.5)
      {
        if (this.ID < this.Lines.Length - 1)
        {
          if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
          {
            this.Typewriter.Finish();
          }
          else
          {
            ++this.ID;
            this.Alpha = (float) this.Alphas[this.ID];
            this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
            this.Typewriter.ResetToBeginning();
            this.Typewriter.mFullText = this.Lines[this.ID];
            this.Label.text = "";
            this.Spoke = false;
            this.Frame = 0;
            if (this.Alphas[this.ID] == 1)
              this.Jukebox.Stop();
            else if (!this.Jukebox.isPlaying)
              this.Jukebox.Play();
            if (this.ID == 17)
            {
              this.SFXAudioSource.clip = this.SFX[1];
              this.SFXAudioSource.Play();
            }
            if (this.ID == 18)
            {
              this.SFXAudioSource.clip = this.SFX[2];
              this.SFXAudioSource.Play();
            }
            if (this.ID > 25)
              this.Typewriter.charsPerSecond = 15;
            this.AutoTimer = 0.0f;
          }
        }
        else if (!this.FinalDarkness.enabled)
        {
          this.FinalDarkness.enabled = true;
          this.Alpha = 0.0f;
        }
      }
      if (!this.Spoke && !this.SFXAudioSource.isPlaying)
      {
        this.MyAudio.clip = this.Voices[this.ID];
        this.MyAudio.Play();
        this.Spoke = true;
      }
      if (this.Auto && this.Typewriter.mCurrentOffset == this.Typewriter.mFullText.Length && !this.SFXAudioSource.isPlaying && !this.MyAudio.isPlaying)
        this.AutoTimer += Time.deltaTime;
      if (this.FinalDarkness.enabled)
      {
        this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.2f);
        this.FinalDarkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
        if ((double) this.Alpha == 1.0)
        {
          if (!GameGlobals.Debug)
          {
            PlayerPrefs.SetInt("LifeNote", 1);
            PlayerPrefs.SetInt("a", 1);
          }
          SceneManager.LoadScene("HomeScene");
        }
      }
    }
    if ((double) this.TextWindow.color.a >= 1.0)
      return;
    if (Input.GetButtonDown("A"))
    {
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.BackgroundArt.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      this.BackgroundArt.localScale = new Vector3(1f, 1f, 1f);
      this.TextWindow.color = new Color(1f, 1f, 1f, 1f);
      this.Label.color = new Color(1f, 1f, 1f, 0.0f);
      this.Label.gameObject.SetActive(true);
      this.Controls.SetActive(true);
      this.Timer = 0.0f;
    }
    this.Timer += Time.deltaTime;
    if ((double) this.Timer > 6.0)
    {
      this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
      this.TextWindow.color = new Color(1f, 1f, 1f, this.Alpha);
      if ((double) this.TextWindow.color.a != 1.0 || this.Typewriter.mActive)
        return;
      this.Label.color = new Color(1f, 1f, 1f, 0.0f);
      this.Label.gameObject.SetActive(true);
      this.Controls.SetActive(true);
      this.Timer = 0.0f;
    }
    else if ((double) this.Timer > 2.0)
    {
      this.BackgroundArt.localScale = Vector3.Lerp(this.BackgroundArt.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * (this.Timer - 2f));
      this.BackgroundArt.localPosition = Vector3.Lerp(this.BackgroundArt.localPosition, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * (this.Timer - 2f));
    }
    else
    {
      if ((double) this.Timer <= 0.0)
        return;
      this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
    }
  }
}
