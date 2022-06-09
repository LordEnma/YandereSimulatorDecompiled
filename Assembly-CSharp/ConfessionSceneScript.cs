// Decompiled with JetBrains decompiler
// Type: ConfessionSceneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ConfessionSceneScript : MonoBehaviour
{
  public Transform[] CameraDestinations;
  public StudentManagerScript StudentManager;
  public LoveManagerScript LoveManager;
  public PromptBarScript PromptBar;
  public JukeboxScript Jukebox;
  public YandereScript Yandere;
  public ClockScript Clock;
  public Bloom BloomEffect;
  public StudentScript Suitor;
  public StudentScript Rival;
  public ParticleSystem MythBlossoms;
  public GameObject HeartBeatCamera;
  public GameObject ConfessionBG;
  public Transform MainCamera;
  public Transform RivalSpot;
  public Transform KissSpot;
  public string[] Text;
  public GameObject[] Letters;
  public UISprite Darkness;
  public UILabel Label;
  public UIPanel Panel;
  public AudioSource MyAudio;
  public AudioSource Jingle;
  public AudioClip EightiesConfessionMusic;
  public bool MoveSuitor;
  public bool ShowLabel;
  public bool Kissing;
  public int TextPhase = 1;
  public int LetterID = 1;
  public int Phase = 1;
  public float LetterTimer = 0.1f;
  public float Speed;
  public float Timer;

  private void Start()
  {
    Time.timeScale = 1f;
    if (!this.StudentManager.Eighties)
      return;
    this.MyAudio.clip = this.EightiesConfessionMusic;
  }

  private void Update()
  {
    if (this.Phase == 1)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0.0f, Time.deltaTime);
      this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0.0f, Time.deltaTime);
      if ((double) this.Darkness.color.a == 1.0)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 1.0)
        {
          this.Yandere.CameraEffects.UpdateBloom(1f);
          this.Yandere.CameraEffects.UpdateThreshold(1f);
          this.Yandere.CameraEffects.UpdateBloomKnee(1f);
          this.Yandere.CameraEffects.UpdateBloomRadius(7f);
          this.Suitor = this.StudentManager.Students[this.LoveManager.SuitorID];
          this.Rival = this.StudentManager.Students[this.LoveManager.RivalID];
          this.Rival.transform.position = this.RivalSpot.position;
          this.Rival.transform.eulerAngles = this.RivalSpot.eulerAngles;
          this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
          this.Suitor.transform.eulerAngles = this.StudentManager.SuitorConfessionSpot.eulerAngles;
          this.Suitor.transform.position = this.StudentManager.SuitorConfessionSpot.position;
          this.Suitor.CharacterAnimation.Play(this.Suitor.IdleAnim);
          this.Suitor.EmptyHands();
          this.MythBlossoms.emission.rateOverTime = (ParticleSystem.MinMaxCurve) 100f;
          this.HeartBeatCamera.SetActive(false);
          this.GetComponent<AudioSource>().Play();
          this.MainCamera.position = this.CameraDestinations[1].position;
          this.MainCamera.eulerAngles = this.CameraDestinations[1].eulerAngles;
          this.Timer = 0.0f;
          ++this.Phase;
        }
      }
    }
    else if (this.Phase == 2)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
      if ((double) this.Darkness.color.a == 0.0)
      {
        if (!this.ShowLabel)
        {
          this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, 0.0f, Time.deltaTime));
          if ((double) this.Label.color.a == 0.0)
          {
            if (this.TextPhase < 5)
            {
              this.MainCamera.position = this.CameraDestinations[this.TextPhase].position;
              this.MainCamera.eulerAngles = this.CameraDestinations[this.TextPhase].eulerAngles;
              if (this.TextPhase == 4 && !this.Kissing)
              {
                ParticleSystem.EmissionModule emission1 = this.Suitor.Hearts.emission with
                {
                  enabled = true,
                  rateOverTime = (ParticleSystem.MinMaxCurve) 10f
                };
                this.Suitor.Hearts.Play();
                ParticleSystem.EmissionModule emission2 = this.Rival.Hearts.emission with
                {
                  enabled = true,
                  rateOverTime = (ParticleSystem.MinMaxCurve) 10f
                };
                this.Rival.Hearts.Play();
                this.Suitor.Character.transform.localScale = new Vector3(1f, 1f, 1f);
                this.Suitor.CharacterAnimation.Play("kiss_00");
                this.Suitor.transform.position = this.KissSpot.position;
                this.Rival.CharacterAnimation[this.Rival.ShyAnim].weight = 0.0f;
                this.Rival.CharacterAnimation.Play("f02_kiss_00");
                this.Kissing = true;
              }
              this.Label.text = this.Text[this.TextPhase];
              this.ShowLabel = true;
            }
            else
            {
              this.Jingle.Play();
              ++this.Phase;
            }
          }
        }
        else
        {
          this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, 1f, Time.deltaTime));
          if ((double) this.Label.color.a == 1.0)
          {
            if (!this.PromptBar.Show)
            {
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Continue";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
            }
            if (Input.GetButtonDown("A"))
            {
              ++this.TextPhase;
              this.ShowLabel = false;
            }
          }
        }
      }
    }
    else if (this.Phase == 3)
    {
      this.LetterTimer += Time.deltaTime;
      if ((double) this.LetterTimer > 0.100000001490116 && this.LetterID < this.Letters.Length)
      {
        this.Letters[this.LetterID].SetActive(true);
        this.LetterTimer = 0.0f;
        ++this.LetterID;
      }
      if ((double) this.LetterTimer > 5.0)
        ++this.Phase;
    }
    else if (this.Phase == 4)
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if ((double) this.Darkness.color.a == 1.0)
      {
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 1.0)
        {
          DatingGlobals.SuitorProgress = 2;
          this.StudentManager.RivalEliminated = true;
          this.Yandere.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Matchmade;
          this.Suitor.Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
          this.PromptBar.ClearButtons();
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = false;
          this.ConfessionBG.SetActive(false);
          this.Yandere.FixCamera();
          ++this.Phase;
        }
      }
    }
    else
    {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0.0f, Time.deltaTime));
      this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 1f, Time.deltaTime);
      if ((double) this.Darkness.color.a == 0.0)
      {
        this.StudentManager.ComeBack();
        this.Suitor.enabled = false;
        this.Suitor.Prompt.enabled = false;
        this.Suitor.Pathfinding.canMove = false;
        this.Suitor.Pathfinding.canSearch = false;
        this.Rival.enabled = false;
        this.Rival.Prompt.enabled = false;
        this.Rival.Pathfinding.canMove = false;
        this.Rival.Pathfinding.canSearch = false;
        this.Yandere.RPGCamera.enabled = true;
        this.Yandere.CanMove = true;
        this.HeartBeatCamera.SetActive(true);
        this.MythBlossoms.emission.rateOverTime = (ParticleSystem.MinMaxCurve) 20f;
        this.Clock.Police.gameObject.SetActive(true);
        this.Clock.StopTime = false;
        this.enabled = false;
        this.Suitor.PartnerID = this.LoveManager.RivalID;
        this.Rival.PartnerID = this.LoveManager.SuitorID;
        this.Suitor.CharacterAnimation.CrossFade("holdHandsLoop_00");
        this.Rival.CharacterAnimation.CrossFade("f02_holdHandsLoop_00");
      }
    }
    if (this.Kissing)
    {
      if ((double) this.Suitor.CharacterAnimation["kiss_00"].time >= (double) this.Suitor.CharacterAnimation["kiss_00"].length * 0.666660010814667)
        this.Suitor.Character.transform.localScale = Vector3.Lerp(this.Suitor.Character.transform.localScale, new Vector3(0.94f, 0.94f, 0.94f), Time.deltaTime);
      if ((double) this.Suitor.CharacterAnimation["kiss_00"].time < (double) this.Suitor.CharacterAnimation["kiss_00"].length)
        return;
      this.Rival.CharacterAnimation.CrossFade("f02_introHoldHands_00");
      this.Suitor.CharacterAnimation.CrossFade("introHoldHands_00");
      this.Kissing = false;
      this.MoveSuitor = true;
    }
    else
    {
      if (!((Object) this.Suitor != (Object) null))
        return;
      this.Suitor.gameObject.SetActive(true);
      this.Suitor.Character.transform.localScale = Vector3.Lerp(this.Suitor.Character.transform.localScale, new Vector3(0.94f, 0.94f, 0.94f), Time.deltaTime);
      if (!this.MoveSuitor)
        return;
      this.Speed += Time.deltaTime;
      this.Suitor.Character.transform.position = Vector3.Lerp(this.Suitor.Character.transform.position, new Vector3(0.0f, 6.6f, 119.2f), Time.deltaTime * this.Speed);
    }
  }
}
