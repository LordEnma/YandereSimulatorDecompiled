// Decompiled with JetBrains decompiler
// Type: CourtroomScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class CourtroomScript : MonoBehaviour
{
  public PostProcessingProfile Profile;
  public EightiesStatsScript Stats;
  public ParticleSystem[] SpeechLines;
  public Transform[] CameraPosition;
  public AudioClip[] ScoreJingles;
  public AudioClip[] Voice;
  public GameObject SkipButton;
  public Transform BalanceBar;
  public Transform RightScale;
  public Transform LeftScale;
  public Transform Scale;
  public AudioSource Jukebox;
  public AudioSource MyAudio;
  public AudioSource Walla;
  public Texture[] RankIcons;
  public UITexture Polaroid;
  public UITexture RankIcon;
  public Animation Yandere;
  public UISprite Darkness;
  public UIPanel RankPanel;
  public UILabel FactLabel;
  public UILabel RankDesc;
  public UILabel Subtitle;
  public int[] EliminationSuspicion;
  public int[] DetailSuspicion;
  public int[] GuiltyPoints;
  public string[] OpeningStatement;
  public string[] Eliminations;
  public string[] RivalNames;
  public string[] Details;
  public string[] Fact;
  public float TargetRotation;
  public float MusicTimer;
  public float Rotation;
  public float Speed;
  public float Timer;
  public bool Innocent;
  public int Innocence;
  public int FactID;
  public int Guilt;
  public int Phase;
  public int Score;
  public int Rank;
  public AudioClip Deaths;
  public AudioClip Disappearances;
  public AudioClip DeathsAndDisappearances;
  public AudioClip SomeDeaths;
  public AudioClip SomeDisappearances;
  public AudioClip GuiltyClip;
  public AudioClip InnocentClip;
  public GameObject OriginalHair;
  public GameObject[] VtuberHairs;
  public Texture[] VtuberFaces;
  public SkinnedMeshRenderer MyRenderer;
  public bool Vtuber;

  private void Start()
  {
    this.Subtitle.text = "";
    this.Polaroid.alpha = 0.0f;
    this.Darkness.alpha = 1f;
    this.RankPanel.alpha = 0.0f;
    GameGlobals.TrueEnding = false;
    this.Scale.localPosition = new Vector3(0.0f, 0.645f, 1f);
    this.transform.position = new Vector3(0.0f, 5f, 15f);
    this.transform.eulerAngles = new Vector3(15f, 180f, 0.0f);
    this.Jukebox.volume = 0.0f;
    this.ResetBloom();
    this.VtuberCheck();
  }

  public void UpdateFactLabels()
  {
    this.Fact[1] = this.RivalNames[1] + " " + this.Eliminations[this.Stats.EliminationIDs[1]];
    this.GuiltyPoints[1] = this.EliminationSuspicion[this.Stats.EliminationIDs[1]];
    this.Fact[2] = this.Details[this.Stats.DetailIDs[1]];
    this.GuiltyPoints[2] = this.DetailSuspicion[this.Stats.DetailIDs[1]];
    this.Fact[3] = this.RivalNames[2] + " " + this.Eliminations[this.Stats.EliminationIDs[2]];
    this.GuiltyPoints[3] = this.EliminationSuspicion[this.Stats.EliminationIDs[2]];
    this.Fact[4] = this.Details[this.Stats.DetailIDs[2]];
    this.GuiltyPoints[4] = this.DetailSuspicion[this.Stats.DetailIDs[2]];
    this.Fact[5] = this.RivalNames[3] + " " + this.Eliminations[this.Stats.EliminationIDs[3]];
    this.GuiltyPoints[5] = this.EliminationSuspicion[this.Stats.EliminationIDs[3]];
    this.Fact[6] = this.Details[this.Stats.DetailIDs[3]];
    this.GuiltyPoints[6] = this.DetailSuspicion[this.Stats.DetailIDs[3]];
    this.Fact[7] = this.RivalNames[4] + " " + this.Eliminations[this.Stats.EliminationIDs[4]];
    this.GuiltyPoints[7] = this.EliminationSuspicion[this.Stats.EliminationIDs[4]];
    this.Fact[8] = this.Details[this.Stats.DetailIDs[4]];
    this.GuiltyPoints[8] = this.DetailSuspicion[this.Stats.DetailIDs[4]];
    this.Fact[9] = this.RivalNames[5] + " " + this.Eliminations[this.Stats.EliminationIDs[5]];
    this.GuiltyPoints[9] = this.EliminationSuspicion[this.Stats.EliminationIDs[5]];
    this.Fact[10] = this.Details[this.Stats.DetailIDs[5]];
    this.GuiltyPoints[10] = this.DetailSuspicion[this.Stats.DetailIDs[5]];
    this.Fact[11] = this.RivalNames[6] + " " + this.Eliminations[this.Stats.EliminationIDs[6]];
    this.GuiltyPoints[11] = this.EliminationSuspicion[this.Stats.EliminationIDs[6]];
    this.Fact[12] = this.Details[this.Stats.DetailIDs[6]];
    this.GuiltyPoints[12] = this.DetailSuspicion[this.Stats.DetailIDs[6]];
    this.Fact[13] = this.RivalNames[7] + " " + this.Eliminations[this.Stats.EliminationIDs[7]];
    this.GuiltyPoints[13] = this.EliminationSuspicion[this.Stats.EliminationIDs[7]];
    this.Fact[14] = this.Details[this.Stats.DetailIDs[7]];
    this.GuiltyPoints[14] = this.DetailSuspicion[this.Stats.DetailIDs[7]];
    this.Fact[15] = this.RivalNames[8] + " " + this.Eliminations[this.Stats.EliminationIDs[8]];
    this.GuiltyPoints[15] = this.EliminationSuspicion[this.Stats.EliminationIDs[8]];
    this.Fact[16] = this.Details[this.Stats.DetailIDs[8]];
    this.GuiltyPoints[16] = this.DetailSuspicion[this.Stats.DetailIDs[8]];
    this.Fact[17] = this.RivalNames[9] + " " + this.Eliminations[this.Stats.EliminationIDs[9]];
    this.GuiltyPoints[17] = this.EliminationSuspicion[this.Stats.EliminationIDs[9]];
    this.Fact[18] = this.Details[this.Stats.DetailIDs[9]];
    this.GuiltyPoints[18] = this.DetailSuspicion[this.Stats.DetailIDs[9]];
    this.Fact[19] = this.RivalNames[10] + " " + this.Eliminations[this.Stats.EliminationIDs[10]];
    this.GuiltyPoints[19] = this.EliminationSuspicion[this.Stats.EliminationIDs[10]];
    this.Fact[20] = this.Details[this.Stats.DetailIDs[10]];
    this.GuiltyPoints[20] = this.DetailSuspicion[this.Stats.DetailIDs[10]];
    this.Fact[21] = "After Sumire's disappearance, the police were called to Akademi a total of " + PlayerGlobals.PoliceVisits.ToString() + " times.";
    this.GuiltyPoints[21] = PlayerGlobals.PoliceVisits;
    this.Fact[22] = "The police discovered a total of " + PlayerGlobals.CorpsesDiscovered.ToString() + " corpses at Akademi.";
    this.GuiltyPoints[22] = PlayerGlobals.CorpsesDiscovered;
    this.Fact[23] = "Ryoba made " + PlayerGlobals.Friends.ToString() + " friends at Akademi.";
    this.GuiltyPoints[23] = PlayerGlobals.Friends * -1;
    this.Fact[24] = "Ryoba's reputation at school is " + Mathf.RoundToInt(PlayerGlobals.Reputation).ToString() + ".";
    this.GuiltyPoints[24] = Mathf.RoundToInt(PlayerGlobals.Reputation) * -1;
    this.Fact[25] = "Ryoba's classmates witnessed her doing something suspicious " + PlayerGlobals.Alerts.ToString() + " times.";
    this.GuiltyPoints[25] = PlayerGlobals.Alerts;
    this.Fact[26] = "Ryoba's classmates witnessed her carrying a dangerous weapon around school " + PlayerGlobals.WeaponWitnessed.ToString() + " times.";
    this.GuiltyPoints[26] = PlayerGlobals.WeaponWitnessed;
    this.Fact[27] = "Ryoba's classmates witnessed her walking around in blood-stained clothing " + PlayerGlobals.BloodWitnessed.ToString() + " times.";
    this.GuiltyPoints[27] = PlayerGlobals.BloodWitnessed;
    this.Fact[28] = this.Stats.Grudges != 0 ? (this.Stats.Grudges != 1 ? this.Stats.Grudges.ToString() + " students testified that they witnessed Ryoba commit murder, but had no evidence." : this.Stats.Grudges.ToString() + " student testified that they witnessed Ryoba commit murder, but had no evidence.") : this.Stats.Grudges.ToString() + " students testified that they witnessed Ryoba commit murder.";
    this.GuiltyPoints[28] = this.Stats.Grudges * 20;
  }

  private void Update()
  {
    if (this.Phase == 0)
    {
      this.Timer += Time.deltaTime;
      this.Speed += Time.deltaTime * 0.2f;
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime * 0.2f);
      this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.0f, 2f, 2f), Time.deltaTime * this.Speed);
      if (Input.GetButtonDown("A"))
        this.Timer = 11f;
      else if (Input.GetButtonDown("X"))
      {
        this.Timer = 0.0f;
        this.Phase = 66;
        this.Darkness.alpha = 0.0f;
        this.transform.position = this.CameraPosition[65].position;
        this.transform.eulerAngles = this.CameraPosition[65].eulerAngles;
      }
      if ((double) this.Timer > 10.0)
      {
        ++this.Phase;
        this.Timer = 0.0f;
        this.Darkness.alpha = 0.0f;
        this.Subtitle.text = this.OpeningStatement[this.Phase];
        this.MyAudio.clip = this.Voice[this.Phase];
        this.MyAudio.Play();
        this.transform.position = this.CameraPosition[this.Phase].position;
        this.transform.eulerAngles = this.CameraPosition[this.Phase].eulerAngles;
      }
    }
    else if (this.Phase < 66)
    {
      if (Input.GetButtonDown("A"))
      {
        ++this.Phase;
        if (this.Phase < 66)
        {
          this.Subtitle.text = this.OpeningStatement[this.Phase];
          this.MyAudio.clip = this.Voice[this.Phase];
          this.MyAudio.Play();
          this.transform.position = this.CameraPosition[this.Phase].position;
          this.transform.eulerAngles = this.CameraPosition[this.Phase].eulerAngles;
        }
        else
          this.Subtitle.text = "";
      }
      else if (Input.GetButtonDown("X"))
      {
        this.Phase = 66;
        this.Subtitle.text = "";
        this.transform.position = this.CameraPosition[65].position;
        this.transform.eulerAngles = this.CameraPosition[65].eulerAngles;
      }
    }
    else if (this.Phase == 66)
    {
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.5f, Time.deltaTime * 0.5f);
      this.Scale.localPosition = Vector3.Lerp(this.Scale.localPosition, new Vector3(0.0f, -0.2f, 1f), Time.deltaTime * 10f);
      if ((double) this.Darkness.alpha == 0.5)
      {
        this.Scale.localPosition = new Vector3(0.0f, -0.2f, 1f);
        if (this.Fact[this.FactID] == "")
          this.Fact[this.FactID] = "Huh? The game could not identify how this character was eliminated. Tell YandereDev about this, and let him know exactly how you eliminated her.";
        this.FactLabel.text = this.Fact[this.FactID];
        this.Guilt += this.GuiltyPoints[this.FactID];
        this.SkipButton.SetActive(false);
        ++this.Phase;
      }
    }
    else if (this.Phase == 67)
    {
      if (Input.GetButtonDown("A"))
      {
        if (this.FactID < this.Fact.Length - 1)
        {
          ++this.FactID;
          if (this.Fact[this.FactID] == "")
            this.Fact[this.FactID] = "Huh? The game could not identify how this character was eliminated. Tell YandereDev about this, and let him know exactly how you eliminated her.";
          this.FactLabel.text = this.Fact[this.FactID];
          if (this.GuiltyPoints[this.FactID] > 0)
            this.Guilt += this.GuiltyPoints[this.FactID];
          else
            this.Innocence -= this.GuiltyPoints[this.FactID];
        }
        else
        {
          this.FactLabel.text = "";
          ++this.Phase;
        }
      }
    }
    else if (this.Phase == 68)
    {
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime * 0.5f);
      this.Scale.localPosition = Vector3.Lerp(this.Scale.localPosition, new Vector3(0.0f, 0.645f, 1f), Time.deltaTime * 10f);
      if ((double) this.Darkness.alpha == 0.0)
      {
        this.Scale.localPosition = new Vector3(0.0f, 0.645f, 1f);
        this.Subtitle.text = "Taking all of the facts into consideration, it is clear beyond any shadow of a doubt...";
        this.MyAudio.clip = this.Voice[66];
        this.MyAudio.Play();
        ++this.Phase;
      }
    }
    else if (this.Phase == 69)
    {
      if (Input.GetButtonDown("A"))
      {
        if (this.Guilt - this.Innocence > 0)
        {
          if (this.Stats.Deaths == 10)
          {
            this.Subtitle.text = "...that Ryoba Aishi is responsible for at least eleven deaths over the past eleven weeks.";
            this.MyAudio.clip = this.Deaths;
          }
          else if (this.Stats.Disappearances == 10)
          {
            this.Subtitle.text = "...that Ryoba Aishi is responsible for at least eleven disappearances over the past eleven weeks.";
            this.MyAudio.clip = this.Disappearances;
          }
          else if (this.Stats.Deaths + this.Stats.Disappearances == 10)
          {
            this.Subtitle.text = "...that Ryoba Aishi is responsible for at least eleven deaths and disappearances over the past eleven weeks.";
            this.MyAudio.clip = this.DeathsAndDisappearances;
          }
          else if (this.Stats.Deaths > 0)
          {
            this.Subtitle.text = "...that Ryoba Aishi is responsible for at least one death over the past eleven weeks.";
            this.MyAudio.clip = this.SomeDeaths;
          }
          else if (this.Stats.Disappearances > 0)
          {
            this.Subtitle.text = "...that Ryoba Aishi is responsible for at least one disappearance over the past eleven weeks.";
            this.MyAudio.clip = this.SomeDisappearances;
          }
          else if (this.Stats.Deaths + this.Stats.Disappearances == 0)
          {
            this.Subtitle.text = "...that Ryoba Aishi is responsible for Sumire Saitozaki's death.";
            this.MyAudio.clip = this.GuiltyClip;
          }
        }
        else
        {
          this.Subtitle.text = "...that Ryoba Aishi is innocent of all charges.";
          this.MyAudio.clip = this.InnocentClip;
          this.Innocent = true;
        }
        this.MyAudio.Play();
        ++this.Phase;
      }
    }
    else if (this.Phase == 70)
    {
      if (Input.GetButtonDown("A"))
      {
        this.Speed = 0.0f;
        this.Subtitle.text = "";
        this.transform.position = this.CameraPosition[15].position;
        this.transform.eulerAngles = this.CameraPosition[15].eulerAngles;
        if (this.Innocent)
        {
          this.Yandere["YandereConfessionRejected"].time = 4.5f;
          this.Yandere.CrossFade("YandereConfessionRejected");
        }
        else
        {
          this.Yandere.transform.position = new Vector3(0.0f, 0.0f, 0.15f);
          this.Yandere.CrossFade("YandereConfessionAccepted");
        }
        this.PopulateRankPanel();
        AudioSource.PlayClipAtPoint(this.ScoreJingles[this.Rank], this.transform.position);
        ++this.Phase;
      }
    }
    else if (this.Phase == 71)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 2.5)
      {
        if (this.Innocent)
          this.Yandere.CrossFade("YandereConfessionRejectedLoop");
        else
          this.Yandere.CrossFade("f02_down_22");
        if ((double) this.Timer > 3.0)
          ++this.Phase;
      }
    }
    else if (this.Phase == 72)
    {
      this.RankPanel.alpha = Mathf.MoveTowards(this.RankPanel.alpha, 1f, Time.deltaTime);
      if ((double) this.RankPanel.alpha == 1.0)
        ++this.Phase;
    }
    else if (this.Phase == 73)
    {
      this.RankIcon.transform.localScale = Vector3.Lerp(this.RankIcon.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if ((double) this.RankIcon.transform.localScale.x > 0.999000012874603)
      {
        this.RankDesc.alpha = Mathf.MoveTowards(this.RankDesc.alpha, 1f, Time.deltaTime);
        if ((double) this.RankDesc.alpha == 1.0 && Input.GetButtonDown("A"))
          ++this.Phase;
      }
    }
    else if (this.Phase == 74)
    {
      this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime);
      if ((double) this.Darkness.alpha == 1.0)
      {
        if (this.Innocent)
        {
          GameGlobals.EightiesCutsceneID = 12;
          SceneManager.LoadScene("EightiesCutsceneScene");
        }
        else
          SceneManager.LoadScene("CreditsScene");
      }
    }
    if (this.Phase < 68)
    {
      this.MusicTimer += Time.deltaTime;
      if ((double) this.MusicTimer > 1.0)
        this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.033333f, Time.deltaTime * 0.01f);
    }
    else
      this.Jukebox.volume = Mathf.MoveTowards(this.Jukebox.volume, 0.0f, Time.deltaTime * 0.1f);
    if (this.Phase > 70)
    {
      this.Speed += Time.deltaTime;
      this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.6666667f, 1.33333f, -1f), Time.deltaTime * this.Speed);
    }
    if (this.Phase == 27 || this.Phase == 47 || this.Phase == 63)
    {
      if ((double) this.Walla.volume == 0.0)
      {
        for (int index = 1; index < this.SpeechLines.Length; ++index)
          this.SpeechLines[index].Play();
      }
      this.Walla.volume = Mathf.MoveTowards(this.Walla.volume, 0.5f, Time.deltaTime * 0.2f);
    }
    else
    {
      if (this.SpeechLines[1].isPlaying)
      {
        for (int index = 1; index < this.SpeechLines.Length; ++index)
          this.SpeechLines[index].Stop();
      }
      this.Walla.volume = Mathf.MoveTowards(this.Walla.volume, 0.0f, Time.deltaTime * 0.2f);
    }
    if (this.Phase == 9 || this.Phase == 10)
    {
      this.Polaroid.transform.localPosition = Vector3.Lerp(this.Polaroid.transform.localPosition, new Vector3(700f, 200f, 0.0f), Time.deltaTime);
      this.Polaroid.alpha = Mathf.MoveTowards(this.Polaroid.alpha, 1f, Time.deltaTime);
    }
    else
    {
      this.Polaroid.transform.localPosition = Vector3.Lerp(this.Polaroid.transform.localPosition, new Vector3(700f, 0.0f, 0.0f), Time.deltaTime);
      this.Polaroid.alpha = Mathf.MoveTowards(this.Polaroid.alpha, 0.0f, Time.deltaTime);
    }
    this.TargetRotation = (float) (this.Guilt - this.Innocence) * 0.25f;
    if ((double) this.TargetRotation > 25.0)
      this.TargetRotation = 25f;
    if ((double) this.TargetRotation < -25.0)
      this.TargetRotation = -25f;
    this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime);
    this.BalanceBar.localEulerAngles = new Vector3(0.0f, 0.0f, this.Rotation);
    this.RightScale.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.LeftScale.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    if (this.transform.position == this.CameraPosition[1].position || this.transform.position == this.CameraPosition[15].position || this.transform.position == this.CameraPosition[65].position || this.Phase > 70)
      this.UpdateDOF(1f);
    else
      this.UpdateDOF(3f);
  }

  public void PopulateRankPanel()
  {
    this.RankIcon.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    this.Score = (this.Guilt - this.Innocence) * -1;
    if (!this.Innocent)
    {
      this.Rank = 0;
      this.RankDesc.text = "You successfully eliminated your rivals, but aroused so much suspicion that you were eventually judged to be guilty of murder.";
    }
    else if (this.Score >= 100)
    {
      this.Rank = 5;
      this.RankDesc.text = "Everyone loves you, and nobody has any reason to suspect that you might be a killer! You are a true yandere!";
      if (this.Stats.EliminationIDs[1] == 18 && this.Stats.EliminationIDs[2] == 5 && this.Stats.EliminationIDs[3] == 6 && this.Stats.EliminationIDs[4] == 15 && this.Stats.EliminationIDs[5] == 7 && this.Stats.EliminationIDs[6] == 8 && this.Stats.EliminationIDs[7] == 9 && this.Stats.EliminationIDs[8] == 4 && this.Stats.EliminationIDs[9] == 13 && this.Stats.EliminationIDs[10] == 2)
      {
        Debug.Log((object) "True ending unlocked!");
        this.Rank = 6;
        GameGlobals.TrueEnding = true;
      }
    }
    else if (this.Score >= 75)
    {
      this.Rank = 4;
      this.RankDesc.text = "Nearly everyone is convinced that you are innocent, but there are still a few people who doubt you.";
    }
    else if (this.Score >= 50)
    {
      this.Rank = 3;
      this.RankDesc.text = "Public opinion is split 50/50 on whether or not you are a killer. Many people will prefer to avoid you.";
    }
    else if (this.Score >= 25)
    {
      this.Rank = 2;
      this.RankDesc.text = "You avoided a guilty verdict, but you've still taken a massive hit to your reputation.";
    }
    else if (this.Score >= 0)
    {
      this.Rank = 1;
      this.RankDesc.text = "You barely managed to avoid a guilty verdict. You will be regarded with suspicion for the rest of your life.";
    }
    this.RankIcon.mainTexture = this.RankIcons[this.Rank];
  }

  private void UpdateDOF(float Value) => this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
  {
    focusDistance = Value,
    aperture = 5.6f
  };

  private void ResetBloom()
  {
    BloomModel.Settings settings = this.Profile.bloom.settings;
    settings.bloom.intensity = 1f;
    settings.bloom.threshold = 1.1f;
    settings.bloom.softKnee = 0.75f;
    settings.bloom.radius = 4f;
    this.Profile.bloom.settings = settings;
  }

  public void VtuberCheck()
  {
    if (GameGlobals.VtuberID > 0)
    {
      this.OriginalHair.SetActive(false);
      this.VtuberHairs[GameGlobals.VtuberID].SetActive(true);
      this.MyRenderer.materials[2].mainTexture = this.VtuberFaces[GameGlobals.VtuberID];
      for (int index = 0; index < 13; ++index)
        this.MyRenderer.SetBlendShapeWeight(index, 0.0f);
      this.MyRenderer.SetBlendShapeWeight(0, 100f);
      this.MyRenderer.SetBlendShapeWeight(9, 100f);
      this.Vtuber = true;
    }
    else
      this.VtuberHairs[1].SetActive(false);
  }
}
