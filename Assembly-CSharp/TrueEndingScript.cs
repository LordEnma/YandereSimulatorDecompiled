// Decompiled with JetBrains decompiler
// Type: TrueEndingScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TrueEndingScript : MonoBehaviour
{
  public GameObject TrueEndingPanel;
  public GameObject TimelinePanel;
  public AudioSource Ambience;
  public AudioSource MyAudio;
  public AudioSource BuildUp;
  public UISprite Darkness;
  public Texture DarkLogo;
  public AudioClip[] Clip;
  public UILabel Subtitle;
  public UITexture Logo;
  public string[] Text;
  public float SpeechTimer;
  public float FadeTimer;
  public float WaitTimer;
  public float Timer;
  public float Intensity;
  public bool FadeOut;
  public bool Shake;
  public int Phase;

  private void Start()
  {
    this.Darkness.alpha = 1f;
    this.Subtitle.text = "";
  }

  private void Update()
  {
    this.Timer += Time.deltaTime;
    this.Ambience.volume = Mathf.MoveTowards(this.Ambience.volume, 0.25f, Time.deltaTime * 0.25f);
    if ((double) this.Timer > 1.0)
    {
      if (!this.FadeOut)
      {
        this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime);
      }
      else
      {
        this.Logo.alpha = Mathf.MoveTowards(this.Logo.alpha, 0.0f, Time.deltaTime * 0.33333f);
        if ((double) this.Logo.alpha == 0.0)
        {
          this.TrueEndingPanel.SetActive(false);
          this.TimelinePanel.SetActive(true);
          this.enabled = false;
        }
      }
      this.WaitTimer += Time.deltaTime;
      if ((double) this.WaitTimer > 1.0)
      {
        if (Input.GetButtonDown("A"))
        {
          this.SpeechTimer = 1f;
          if (this.Phase < 16)
            this.MyAudio.Stop();
        }
        if (!this.MyAudio.isPlaying && (double) this.Darkness.alpha == 0.0)
        {
          this.SpeechTimer += Time.deltaTime;
          if ((double) this.SpeechTimer > 0.5 && this.Phase < this.Clip.Length - 1)
          {
            ++this.Phase;
            this.Subtitle.text = this.Text[this.Phase];
            this.MyAudio.clip = this.Clip[this.Phase];
            this.MyAudio.Play();
            if (this.Phase == this.Clip.Length - 1)
            {
              this.Logo.mainTexture = this.DarkLogo;
              this.Ambience.Stop();
              this.BuildUp.Stop();
              this.Shake = true;
            }
            else if (this.Phase == this.Clip.Length - 2)
              this.BuildUp.Play();
            this.SpeechTimer = 0.0f;
          }
        }
      }
    }
    if (!this.Shake)
      return;
    this.Logo.transform.localPosition = new Vector3(Random.Range(-1f, 1f) * this.Intensity, Random.Range(-1f, 1f) * this.Intensity, Random.Range(-1f, 1f) * this.Intensity);
    this.Intensity = Mathf.MoveTowards(this.Intensity, 0.0f, Time.deltaTime * 100f);
    if ((double) this.Intensity != 0.0)
      return;
    this.FadeTimer += Time.deltaTime;
    if ((double) this.FadeTimer <= 5.0 || this.FadeOut)
      return;
    this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    this.FadeOut = true;
  }
}
