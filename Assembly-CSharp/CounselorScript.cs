// Decompiled with JetBrains decompiler
// Type: CounselorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using XInputDotNetPure;

public class CounselorScript : MonoBehaviour
{
  public CutsceneManagerScript CutsceneManager;
  public StudentManagerScript StudentManager;
  public CounselorDoorScript CounselorDoor;
  public InputManagerScript InputManager;
  public PromptBarScript PromptBar;
  public EndOfDayScript EndOfDay;
  public SubtitleScript Subtitle;
  public SchemesScript Schemes;
  public StudentScript Student;
  public YandereScript Yandere;
  public Animation MyAnimation;
  public AudioSource MyAudio;
  public PromptScript Prompt;
  public GameObject DelinquentRadio;
  public AudioClip[] EightiesCounselorLectureClips;
  public AudioClip[] EightiesCounselorReportClips;
  public AudioClip[] CounselorGreetingClips;
  public AudioClip[] CounselorLectureClips;
  public AudioClip[] CounselorReportClips;
  public AudioClip[] EightiesRivalClips;
  public AudioClip[] RivalClips;
  public AudioClip CounselorFarewellClip;
  public readonly string CounselorFarewellText = "Don't misbehave.";
  public AudioClip CounselorBusyClip;
  public readonly string CounselorBusyText = "I'm sorry, I've got my hands full for the rest of today. I won't be available until tomorrow.";
  public bool MustReturnStolenRing;
  public string RivalName;
  private string[] CounselorGreetingText = new string[3]
  {
    "",
    "What can I help you with?",
    "Can I help you?"
  };
  private string[] CounselorLectureText = new string[9]
  {
    "",
    "May I see your phone for a moment? ...what is THIS?! Would you care to explain why something like this is on your phone?",
    "May I take a look inside your bag? ...this doesn't belong to you, does it?! What are you doing with someone else's property?",
    "I need to take a look in your bag. ...cigarettes?! You have absolutely no excuse to be carrying something like this around!",
    "It has come to my attention that you've been vandalizing the school's property. What, exactly, do you have to say for yourself?",
    "Obviously, we need to have a long talk about the kind of behavior that will not tolerated at this school!",
    "(This line of text doesn't show up outside of the Eighties.)",
    "That's it! I've given you enough second chances. You have repeatedly broken school rules and ignored every warning that I have given you. You have left me with no choice but to permanently expel you!",
    "(This line of text doesn't show up outside of the Eighties.)"
  };
  private string[] EightiesCounselorLectureText = new string[9]
  {
    "",
    "May I see your bag for a moment? ...what is THIS?! Would you care to explain why you brought something like this to school?!",
    "Whatever you do in the privacy of your own home is none of my business. But there is NO reason for you to bring something like THIS to school!",
    "I need to take a look in your bag. ...cigarettes?! You have absolutely no excuse to be carrying something like this around!",
    "May I take a look inside your bag? ...this doesn't belong to you, does it?! What are you doing with someone else's property?",
    "It's absolutely appalling that you honestly believed you were going to get away with cheating! And at THIS institution, of all places!",
    "I can't believe you actually brought illegal narcotics to school with you! How did you even get ahold of something like this?!",
    "That's it! I've given you enough second chances. You have repeatedly broken school rules and ignored every warning that I have given you. You have left me with no choice but to permanently expel you!",
    "Enough! I have no choice but to inform the police immediately. Explain yourself to them, not me."
  };
  private string[] CounselorReportText = new string[7]
  {
    "",
    "That's a very serious accusation. I hope you're not lying to me. Hopefully, it's just a misunderstanding. I'll investigate the matter.",
    "Is that true? I'd hate to think we have a thief here at school. Don't worry - I'll get to the bottom of this.",
    "That's a clear violation of school rules, not to mention completely illegal. If what you're saying is true, she will face serious consequences. I'll confront her about this.",
    "Thank you for bringing this to my attention! I'll have to have a word with her later today...",
    "That's a bold claim. Are you certain? I'll investigate the matter. If she is cheating, I'll catch her in the act.",
    "(This line of text doesn't show up outside of the Eighties.)"
  };
  private string[] EightiesCounselorReportText = new string[7]
  {
    "",
    "That's a very serious accusation. I hope you're not lying to me. Hopefully, it's just a misunderstanding. I'll investigate the matter.",
    "Thank you for bringing this to my attention! I'll have to have a word with her later today...",
    "That's a clear violation of school rules, not to mention completely illegal. If what you're saying is true, she will face serious consequences. I'll confront her about this.",
    "Is that true? I'd hate to think we have a thief here at school. Don't worry - I'll get to the bottom of this.",
    "That's a bold claim. Are you certain? I'll investigate the matter. If she is cheating, I'll catch her in the act.",
    "...are you serious? Illegal narcotics?! If this is true, she'll be expelled immediately, and the police WILL be informed."
  };
  private string[] LectureIntro = new string[8]
  {
    "",
    "The guidance counselor enters your rival's classroom and says that she needs to speak with her...",
    "The guidance counselor enters your rival's classroom and says that she needs to speak with her...",
    "The guidance counselor enters your rival's classroom and says that she needs to speak with her...",
    "The guidance counselor enters your rival's classroom and says that she needs to speak with her...",
    "The guidance counselor enters your rival's classroom and says that she needs to speak with her...",
    "The guidance counselor enters your rival's classroom and says that she needs to speak with her...",
    "The guidance counselor enters your rival's classroom and says that she needs to speak with her..."
  };
  private string[] RivalText = new string[9]
  {
    "",
    "What?! I've never taken any pictures like that! How did this get on my phone?!",
    "No! I'm not the one who did this! I would never steal from anyone!",
    "Huh? I don't smoke! I don't know why something like this was in my bag!",
    "W-wait, I can explain! It's not what you think!",
    "I'm telling the truth! I didn't steal the answer sheet! I don't know why it was in my desk!",
    "(This line of text doesn't show up outside of the Eighties.)",
    "No...! P-please! Don't do this!",
    "(This line of text doesn't show up outside of the Eighties.)"
  };
  private string[] EightiesRivalText = new string[9]
  {
    "",
    "What?! I don't drink! How did this something like this get in my bag?!",
    "No! I've never even seen these things before! I swear!",
    "Huh? I don't smoke! I don't know why something like this was in my bag!",
    "No! I'm not the one who did this! I would never steal from anyone!",
    "I'm telling the truth! I didn't steal the answer sheet! I don't know why it was in my bag!",
    "Wait! I'm being framed! You've got to believe me!",
    "No...! P-please! Don't do this!",
    "No! Please! Don't call the police! I'm begging you!"
  };
  public UILabel[] Labels;
  public Transform CounselorWindow;
  public Transform NarcoticsWindow;
  public Transform Highlight;
  public Transform Chibi;
  public SkinnedMeshRenderer Face;
  public UILabel CounselorSubtitle;
  public UISprite EndOfDayDarkness;
  public UILabel LectureSubtitle;
  public UISprite ExpelProgress;
  public UILabel LectureLabel;
  public bool ShowWindow;
  public bool Lecturing;
  public bool Eighties;
  public bool Busy;
  public int Selected = 1;
  public int LecturePhase = 1;
  public int LectureID = 5;
  public float ExpelTimer;
  public float ChinTimer;
  public float TalkTimer = 1f;
  public float Timer;
  public UITexture ChibiTexture;
  public Texture[] EightiesRivalHeads;
  public Texture[] RivalHeads;
  public int SadMouthID = 1;
  public int MadBrowID = 5;
  public int SadBrowID = 6;
  public int AngryEyesID = 9;
  public int MouthOpenID = 2;
  public int RivalExpelProgress;
  public int CounselorPunishments;
  public int CounselorVisits;
  public int CounselorTape;
  public int BloodVisits;
  public int InsanityVisits;
  public int LewdVisits;
  public int TheftVisits;
  public int TrespassVisits;
  public int WeaponVisits;
  public int BloodBlameUsed;
  public int InsanityBlameUsed;
  public int LewdBlameUsed;
  public int TheftBlameUsed;
  public int TrespassBlameUsed;
  public int WeaponBlameUsed;
  public int ApologiesUsed;
  public int WeaponsBanned;
  public int DelinquentPunishments;
  public bool ReportedAlcohol;
  public bool ReportedCondoms;
  public bool ReportedCigarettes;
  public bool ReportedTheft;
  public bool ReportedCheating;
  public bool ReportedNarcotics;
  public Vector3 LookAtTarget;
  public bool LookAtPlayer;
  public Transform Default;
  public Transform Head;
  public bool Angry;
  public bool Stern;
  public bool Sad;
  public float MouthTarget;
  public float MouthTimer;
  public float TimerLimit;
  public float MouthOpen;
  public float TalkSpeed;
  public float BS_SadMouth;
  public float BS_MadBrow;
  public float BS_SadBrow;
  public float BS_AngryEyes;
  public DetectClickScript[] CounselorOption;
  public InputDeviceScript InputDevice;
  public StudentWitnessType Crime;
  public UITexture GenkaChibi;
  public CameraShake Shake;
  public Texture HappyChibi;
  public Texture AnnoyedChibi;
  public Texture MadChibi;
  public GameObject CounselorOptions;
  public GameObject CounselorBar;
  public GameObject Reticle;
  public GameObject Laptop;
  public GameObject RedPen;
  public Transform CameraTarget;
  public int InterrogationPhase;
  public int Patience;
  public int CrimeID;
  public int Answer;
  public bool MustExpelDelinquents;
  public bool ExpelledDelinquents;
  public bool SilentTreatment;
  public bool Interrogating;
  public bool SentHome;
  public bool Expelled;
  public bool Slammed;
  public AudioSource Rumble;
  public AudioClip EightiesCountdown;
  public AudioClip Countdown;
  public AudioClip Choice;
  public AudioClip Slam;
  public RiggedAccessoryAttacher EightiesAttacher;
  public GameObject[] EightiesMesh;
  public GameObject[] OriginalMesh;
  public GameObject EightiesPaper;
  public Transform PelvisRoot;
  public bool UpdatedFace;
  public AudioClip[] GreetingClips;
  public string[] Greetings;
  public AudioClip[] BloodLectureClips;
  public string[] BloodLectures;
  public AudioClip[] InsanityLectureClips;
  public string[] InsanityLectures;
  public AudioClip[] LewdLectureClips;
  public string[] LewdLectures;
  public AudioClip[] TheftLectureClips;
  public string[] TheftLectures;
  public AudioClip[] TrespassLectureClips;
  public string[] TrespassLectures;
  public AudioClip[] WeaponLectureClips;
  public string[] WeaponLectures;
  public AudioClip[] SilentClips;
  public string[] Silents;
  public AudioClip[] SuspensionClips;
  public string[] Suspensions;
  public AudioClip[] AcceptExcuseClips;
  public string[] AcceptExcuses;
  public AudioClip[] RejectExcuseClips;
  public string[] RejectExcuses;
  public AudioClip[] RejectLieClips;
  public string[] RejectLies;
  public AudioClip[] AcceptBlameClips;
  public string[] AcceptBlames;
  public AudioClip[] RejectApologyClips;
  public string[] RejectApologies;
  public AudioClip[] RejectBlameClips;
  public string[] RejectBlames;
  public AudioClip[] RejectFlirtClips;
  public string[] RejectFlirts;
  public AudioClip[] BadClosingClips;
  public string[] BadClosings;
  public AudioClip[] BlameClosingClips;
  public string[] BlameClosings;
  public AudioClip[] FreeToLeaveClips;
  public string[] FreeToLeaves;
  public AudioClip AcceptApologyClip;
  public string AcceptApology;
  public AudioClip RejectThreatClip;
  public string RejectThreat;
  public AudioClip ExpelDelinquentsClip;
  public string ExpelDelinquents;
  public AudioClip DelinquentsDeadClip;
  public string DelinquentsDead;
  public AudioClip DelinquentsExpelledClip;
  public string DelinquentsExpelled;
  public AudioClip DelinquentsGoneClip;
  public string DelinquentsGone;
  public AudioClip[] ExcuseClips;
  public string[] Excuses;
  public AudioClip[] LieClips;
  public string[] Lies;
  public AudioClip[] DelinquentClips;
  public string[] Delinquents;
  public AudioClip ApologyClip;
  public string Apology;
  public AudioClip FlirtClip;
  public string Flirt;
  public AudioClip ThreatenClip;
  public string Threaten;
  public AudioClip Silence;
  public float VibrationTimer;
  public bool VibrationCheck;
  public UILabel RIVAL;
  public UILabel EXPELLED;
  public int BloodExcuseUsed;
  public int InsanityExcuseUsed;
  public int LewdExcuseUsed;
  public int TheftExcuseUsed;
  public int TrespassExcuseUsed;
  public int WeaponExcuseUsed;
  public AudioClip LongestSilence;

  private void Start()
  {
    this.CounselorPunishments = CounselorGlobals.CounselorPunishments;
    this.CounselorVisits = CounselorGlobals.CounselorVisits;
    this.CounselorTape = CounselorGlobals.CounselorTape;
    this.BloodVisits = CounselorGlobals.BloodVisits;
    this.InsanityVisits = CounselorGlobals.InsanityVisits;
    this.LewdVisits = CounselorGlobals.LewdVisits;
    this.TheftVisits = CounselorGlobals.TheftVisits;
    this.TrespassVisits = CounselorGlobals.TrespassVisits;
    this.WeaponVisits = CounselorGlobals.WeaponVisits;
    this.BloodBlameUsed = CounselorGlobals.BloodBlameUsed;
    this.InsanityBlameUsed = CounselorGlobals.InsanityBlameUsed;
    this.LewdBlameUsed = CounselorGlobals.LewdBlameUsed;
    this.TheftBlameUsed = CounselorGlobals.TheftBlameUsed;
    this.TrespassBlameUsed = CounselorGlobals.TrespassBlameUsed;
    this.WeaponBlameUsed = CounselorGlobals.WeaponBlameUsed;
    this.ApologiesUsed = CounselorGlobals.ApologiesUsed;
    this.WeaponsBanned = CounselorGlobals.WeaponsBanned;
    this.DelinquentPunishments = CounselorGlobals.DelinquentPunishments;
    this.CounselorWindow.localScale = Vector3.zero;
    this.CounselorWindow.gameObject.SetActive(false);
    this.CounselorOptions.SetActive(false);
    this.CounselorBar.SetActive(false);
    this.Reticle.SetActive(false);
    this.RivalExpelProgress = StudentGlobals.ExpelProgress;
    int week = DateGlobals.Week;
    if (week > 10)
    {
      this.gameObject.SetActive(false);
    }
    else
    {
      this.ExpelProgress.color = new Color(this.ExpelProgress.color.r, this.ExpelProgress.color.g, this.ExpelProgress.color.b, 0.0f);
      this.Chibi.localPosition = new Vector3(this.Chibi.localPosition.x, (float) (250.0 + (double) this.RivalExpelProgress * -90.0), this.Chibi.localPosition.z);
      this.LoadExcusesUsed();
      if (!GameGlobals.Eighties)
        return;
      this.Eighties = true;
      this.MyAnimation.Play("f02_deskWritePingPong_00");
      this.Laptop.SetActive(false);
      this.EightiesPaper.SetActive(true);
      this.EightiesAttacher.gameObject.SetActive(true);
      this.OriginalMesh[1].GetComponent<SkinnedMeshRenderer>().enabled = false;
      this.OriginalMesh[2].SetActive(false);
      this.OriginalMesh[3].SetActive(false);
      this.EightiesMesh[1].SetActive(true);
      this.Countdown = this.EightiesCountdown;
      this.Labels[1].text = "Report Alcohol";
      this.Labels[2].text = "Report Condoms";
      this.Labels[3].text = "Report Cigarettes";
      this.Labels[4].text = "Report Theft";
      this.Labels[5].text = "Report Cheating";
      this.Labels[6].text = "Report Narcotics";
      this.CounselorReportText = this.EightiesCounselorReportText;
      this.CounselorReportClips = this.EightiesCounselorReportClips;
      this.CounselorLectureText = this.EightiesCounselorLectureText;
      this.CounselorLectureClips = this.EightiesCounselorLectureClips;
      this.RivalText = this.EightiesRivalText;
      this.RivalClips = this.EightiesRivalClips;
      this.ChibiTexture.mainTexture = this.EightiesRivalHeads[week];
      this.ReportedAlcohol = CounselorGlobals.ReportedAlcohol;
      this.ReportedCigarettes = CounselorGlobals.ReportedCigarettes;
      this.ReportedCondoms = CounselorGlobals.ReportedCondoms;
      this.ReportedTheft = CounselorGlobals.ReportedTheft;
      this.ReportedCheating = CounselorGlobals.ReportedCheating;
      this.SadMouthID = 4;
      this.MadBrowID = 5;
      this.SadBrowID = 3;
      this.AngryEyesID = 2;
      this.MouthOpenID = 9;
      this.transform.position += new Vector3(0.0f, -0.1f, 0.0f);
      this.RedPen.SetActive(true);
    }
  }

  private void Update()
  {
    if (this.LookAtPlayer)
    {
      if ((double) this.TalkTimer < 1.0)
      {
        this.TalkTimer = Mathf.MoveTowards(this.TalkTimer, 1f, Time.deltaTime);
        if ((double) this.TalkTimer == 1.0)
        {
          int index = Random.Range(1, 3);
          this.CounselorSubtitle.text = this.CounselorGreetingText[index];
          this.MyAudio.clip = this.CounselorGreetingClips[index];
          this.MyAudio.Play();
        }
      }
      if (this.InputManager.TappedUp)
      {
        --this.Selected;
        if (!this.Eighties && this.Selected == 6)
          this.Selected = 5;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedDown)
      {
        ++this.Selected;
        if (!this.Eighties && this.Selected == 6)
          this.Selected = 7;
        this.UpdateHighlight();
      }
      if (this.ShowWindow)
      {
        if ((double) this.CounselorDoor.Darkness.color.a == 0.0 && Input.GetButtonDown("A"))
        {
          if (this.Selected == 7)
          {
            if (!this.CounselorDoor.Exit)
            {
              this.CounselorSubtitle.text = this.CounselorFarewellText;
              this.MyAudio.clip = this.CounselorFarewellClip;
              this.MyAudio.Play();
              this.CounselorDoor.FadeOut = true;
              this.CounselorDoor.FadeIn = false;
              this.CounselorDoor.Exit = true;
            }
          }
          else if ((double) this.Labels[this.Selected].color.a == 1.0)
          {
            if (!this.Eighties)
            {
              if (this.Selected == 1)
              {
                SchemeGlobals.SetSchemeStage(1, 9);
                this.Schemes.UpdateInstructions();
              }
              else if (this.Selected == 2)
              {
                SchemeGlobals.SetSchemeStage(2, 7);
                this.Schemes.UpdateInstructions();
              }
              else if (this.Selected == 3)
              {
                SchemeGlobals.SetSchemeStage(3, 5);
                this.Schemes.UpdateInstructions();
              }
              else if (this.Selected == 4)
              {
                SchemeGlobals.SetSchemeStage(4, 8);
                this.Schemes.UpdateInstructions();
              }
              else if (this.Selected == 5)
              {
                SchemeGlobals.SetSchemeStage(5, 10);
                this.Schemes.UpdateInstructions();
              }
            }
            else if (this.Selected == 1)
              this.ReportedAlcohol = true;
            else if (this.Selected == 2)
              this.ReportedCondoms = true;
            else if (this.Selected == 3)
              this.ReportedCigarettes = true;
            else if (this.Selected == 4)
              this.ReportedTheft = true;
            else if (this.Selected == 5)
              this.ReportedCheating = true;
            else if (this.Selected == 6)
              this.ReportedNarcotics = true;
            this.CounselorSubtitle.text = this.CounselorReportText[this.Selected];
            this.MyAudio.clip = this.CounselorReportClips[this.Selected];
            this.MyAudio.Play();
            this.ShowWindow = false;
            this.Angry = true;
            this.CutsceneManager.Scheme = this.Selected;
            this.LectureID = this.Selected;
            this.PromptBar.ClearButtons();
            this.PromptBar.Show = false;
            this.Busy = true;
          }
        }
      }
      else if (!this.Interrogating)
      {
        if (Input.GetButtonDown("A"))
          this.MyAudio.Stop();
        if (!this.MyAudio.isPlaying)
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 0.5)
          {
            this.CounselorDoor.FadeOut = true;
            this.CounselorDoor.Exit = true;
            this.LookAtPlayer = false;
            this.UpdateList();
          }
        }
      }
    }
    if (this.ShowWindow)
      this.CounselorWindow.localScale = Vector3.Lerp(this.CounselorWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
    else if ((double) this.CounselorWindow.localScale.x > 0.100000001490116)
      this.CounselorWindow.localScale = Vector3.Lerp(this.CounselorWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
    else if (this.CounselorWindow.gameObject.activeInHierarchy)
    {
      this.CounselorWindow.localScale = Vector3.zero;
      this.CounselorWindow.gameObject.SetActive(false);
    }
    if (this.Lecturing)
    {
      this.Chibi.localPosition = new Vector3(this.Chibi.localPosition.x, Mathf.Lerp(this.Chibi.localPosition.y, (float) (250.0 + (double) this.RivalExpelProgress * -90.0), Time.deltaTime * 3f), this.Chibi.localPosition.z);
      if (this.LecturePhase == 1)
      {
        this.LectureLabel.text = this.LectureIntro[this.LectureID];
        this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, Mathf.MoveTowards(this.EndOfDayDarkness.color.a, 0.0f, Time.deltaTime));
        if ((double) this.EndOfDayDarkness.color.a == 0.0)
        {
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Continue";
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
          if (Input.GetButtonDown("A"))
          {
            ++this.LecturePhase;
            this.PromptBar.ClearButtons();
            this.PromptBar.Show = false;
          }
        }
      }
      else if (this.LecturePhase == 2)
      {
        this.LectureLabel.color = new Color(this.LectureLabel.color.r, this.LectureLabel.color.g, this.LectureLabel.color.b, Mathf.MoveTowards(this.LectureLabel.color.a, 0.0f, Time.deltaTime));
        if ((double) this.LectureLabel.color.a == 0.0)
        {
          this.EndOfDay.TextWindow.SetActive(false);
          this.EndOfDay.EODCamera.GetComponent<AudioListener>().enabled = true;
          this.LectureSubtitle.text = this.CounselorLectureText[this.LectureID];
          this.MyAudio.clip = this.CounselorLectureClips[this.LectureID];
          this.MyAudio.Play();
          ++this.LecturePhase;
        }
      }
      else if (this.LecturePhase == 3)
      {
        if (!this.MyAudio.isPlaying || Input.GetButtonDown("A"))
        {
          this.LectureSubtitle.text = this.RivalText[this.LectureID];
          this.MyAudio.clip = this.RivalClips[this.LectureID];
          this.MyAudio.Play();
          ++this.LecturePhase;
        }
      }
      else if (this.LecturePhase == 4)
      {
        if (!this.MyAudio.isPlaying || Input.GetButtonDown("A"))
        {
          this.LectureSubtitle.text = string.Empty;
          if (this.RivalExpelProgress < 5)
          {
            ++this.LecturePhase;
          }
          else
          {
            this.LecturePhase = 7;
            this.ExpelTimer = 0.0f;
          }
        }
      }
      else if (this.LecturePhase == 5)
      {
        this.ExpelProgress.color = new Color(this.ExpelProgress.color.r, this.ExpelProgress.color.g, this.ExpelProgress.color.b, Mathf.MoveTowards(this.ExpelProgress.color.a, 1f, Time.deltaTime));
        this.ExpelTimer += Time.deltaTime;
        if ((double) this.ExpelTimer > 2.0)
        {
          if (this.ReportedNarcotics)
          {
            this.EXPELLED.text = "ARRESTED";
            this.RivalExpelProgress = 5;
          }
          else
            ++this.RivalExpelProgress;
          ++this.LecturePhase;
          Debug.Log((object) ("RivalExpelProgress is now: " + this.RivalExpelProgress.ToString()));
        }
      }
      else if (this.LecturePhase == 6)
      {
        this.ExpelTimer += Time.deltaTime;
        if ((double) this.ExpelTimer > 4.0)
          this.LecturePhase += 2;
      }
      else if (this.LecturePhase == 7)
      {
        this.ExpelTimer += Time.deltaTime;
        if ((double) this.ExpelTimer > 1.0)
          this.RIVAL.gameObject.SetActive(true);
        if ((double) this.ExpelTimer > 3.0)
          this.EXPELLED.gameObject.SetActive(true);
        if ((double) this.ExpelTimer > 5.0)
        {
          this.RIVAL.color = new Color(this.RIVAL.color.r, this.RIVAL.color.g, this.RIVAL.color.b, this.RIVAL.color.a - Time.deltaTime);
          this.EXPELLED.color = new Color(this.EXPELLED.color.r, this.EXPELLED.color.g, this.EXPELLED.color.b, this.EXPELLED.color.a - Time.deltaTime);
        }
        if ((double) this.ExpelTimer > 7.0)
        {
          this.RIVAL.gameObject.SetActive(false);
          this.EXPELLED.gameObject.SetActive(false);
          ++this.LecturePhase;
        }
      }
      else if (this.LecturePhase == 8)
      {
        Debug.Log((object) "We are now in Lecture Phase 8. We're deciding whether to return to gameplay or expel the rival.");
        this.ExpelProgress.color = new Color(this.ExpelProgress.color.r, this.ExpelProgress.color.g, this.ExpelProgress.color.b, Mathf.MoveTowards(this.ExpelProgress.color.a, 0.0f, Time.deltaTime));
        this.ExpelTimer += Time.deltaTime;
        if ((double) this.ExpelTimer > 6.0)
        {
          if (this.RivalExpelProgress == 5 && !StudentGlobals.GetStudentExpelled(this.StudentManager.RivalID) && this.EndOfDay.RivalEliminationMethod != RivalEliminationType.Expelled && this.EndOfDay.RivalEliminationMethod != RivalEliminationType.Arrested && this.StudentManager.Police.TranqCase.VictimID != this.StudentManager.RivalID || this.StudentManager.Students[this.StudentManager.RivalID].SentHome)
          {
            Debug.Log((object) "The guidence counselor is now choosing the words she will say when expelling the rival.");
            this.EndOfDayDarkness.color = new Color(this.EndOfDayDarkness.color.r, this.EndOfDayDarkness.color.g, this.EndOfDayDarkness.color.b, 0.0f);
            this.LectureLabel.color = new Color(this.LectureLabel.color.r, this.LectureLabel.color.g, this.LectureLabel.color.b, 0.0f);
            this.LecturePhase = 2;
            this.ExpelTimer = 0.0f;
            if (this.ReportedNarcotics)
            {
              this.LectureID = 8;
              this.EndOfDay.RivalEliminationMethod = RivalEliminationType.Arrested;
              this.StudentManager.RivalEliminated = true;
            }
            else
            {
              this.LectureID = 7;
              this.EndOfDay.RivalEliminationMethod = RivalEliminationType.Expelled;
              this.StudentManager.RivalEliminated = true;
            }
          }
          else
          {
            Debug.Log((object) "The lecture is over. Now, the game decides where to go next.");
            if (!this.EndOfDay.Police.Show)
            {
              this.Lecturing = false;
              if (this.Yandere.StudentManager.Clock.Period > 4 || this.SentHome)
              {
                if (this.SentHome)
                  Debug.Log((object) "We got here after being sent home.");
                else
                  Debug.Log((object) "We got here during Period 5 or 6. We must be at the end of the school day.");
                ++this.EndOfDay.Phase;
                this.EndOfDay.UpdateScene();
              }
              else
              {
                Debug.Log((object) "We got here prior to Period 5. We are leaving the lecture and returning to gameplay.");
                this.StudentManager.Portal.gameObject.GetComponent<PortalScript>().Class.gameObject.SetActive(true);
                this.StudentManager.Portal.gameObject.GetComponent<PortalScript>().ReturningFromLecture = true;
                this.EndOfDay.gameObject.SetActive(false);
                this.EndOfDay.Phase = 1;
                ++this.CutsceneManager.Phase;
                this.Yandere.PauseScreen.Schemes.SchemeManager.enabled = false;
                this.Yandere.MainCamera.gameObject.SetActive(true);
                this.Yandere.gameObject.SetActive(true);
                this.SpawnDelinquents();
                this.StudentManager.ComeBack();
                this.StudentManager.Students[this.StudentManager.RivalID].IdleAnim = this.StudentManager.Students[this.StudentManager.RivalID].BulliedIdleAnim;
                this.StudentManager.Students[this.StudentManager.RivalID].WalkAnim = this.StudentManager.Students[this.StudentManager.RivalID].BulliedWalkAnim;
                if (this.Eighties)
                {
                  if (this.LectureID == 4 && (Object) this.StudentManager.Students[30] != (Object) null)
                  {
                    Debug.Log((object) "Attempting to update Himedere's routine...");
                    this.StudentManager.Students[30].Cosmetic.EnableRings();
                    this.StudentManager.Students[30].Depressed = false;
                  }
                }
                else if (this.LectureID == 2)
                  this.MustReturnStolenRing = true;
                else if (this.LectureID == 6 && this.StudentManager.RivalID == 11 && (Object) this.StudentManager.Students[10] != (Object) null)
                {
                  StudentScript student = this.StudentManager.Students[10];
                  Debug.Log((object) "Osana is gone, so Raibaru's routine has to change.");
                  ScheduleBlock scheduleBlock1 = student.ScheduleBlocks[4];
                  scheduleBlock1.destination = "Mourn";
                  scheduleBlock1.action = "Mourn";
                  ScheduleBlock scheduleBlock2 = student.ScheduleBlocks[5];
                  scheduleBlock2.destination = "Seat";
                  scheduleBlock2.action = "Sit";
                  ScheduleBlock scheduleBlock3 = student.ScheduleBlocks[6];
                  scheduleBlock3.destination = "Locker";
                  scheduleBlock3.action = "Shoes";
                  ScheduleBlock scheduleBlock4 = student.ScheduleBlocks[7];
                  scheduleBlock4.destination = "Exit";
                  scheduleBlock4.action = "Exit";
                  ScheduleBlock scheduleBlock5 = student.ScheduleBlocks[8];
                  scheduleBlock5.destination = "Exit";
                  scheduleBlock5.action = "Exit";
                  ScheduleBlock scheduleBlock6 = student.ScheduleBlocks[9];
                  scheduleBlock6.destination = "Exit";
                  scheduleBlock6.action = "Exit";
                  student.TargetDistance = 0.5f;
                  student.IdleAnim = student.BulliedIdleAnim;
                  student.WalkAnim = student.BulliedWalkAnim;
                  student.OriginalIdleAnim = student.IdleAnim;
                  student.Pathfinding.speed = 1f;
                  student.GetDestinations();
                }
                this.LectureID = 0;
              }
            }
            else
            {
              Debug.Log((object) "The police were present at school, so we're returning to the EndOfDay sequence now.");
              ++this.EndOfDay.Phase;
              this.EndOfDay.UpdateScene();
            }
          }
        }
      }
    }
    if (!this.MyAudio.isPlaying)
      this.CounselorSubtitle.text = string.Empty;
    if (!this.Interrogating)
      return;
    this.UpdateInterrogation();
  }

  public void Talk()
  {
    this.MyAnimation.CrossFade("CounselorComputerAttention", 1f);
    this.ChinTimer = 0.0f;
    this.Yandere.TargetStudent = this.Student;
    this.TalkTimer = 0.0f;
    this.StudentManager.DisablePrompts();
    this.CounselorWindow.gameObject.SetActive(true);
    this.LookAtPlayer = true;
    this.ShowWindow = true;
    this.Yandere.ShoulderCamera.OverShoulder = true;
    this.Yandere.WeaponMenu.KeyboardShow = false;
    this.Yandere.WeaponMenu.Show = false;
    this.Yandere.YandereVision = false;
    this.Yandere.CanMove = false;
    this.Yandere.Talking = true;
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Accept";
    this.PromptBar.Label[4].text = "Choose";
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = true;
    this.transform.position = new Vector3(-28.93333f, 0.0f, 12f);
    this.RedPen.SetActive(false);
    this.UpdateList();
  }

  private void UpdateList()
  {
    for (int index = 1; index < this.Labels.Length; ++index)
    {
      UILabel label = this.Labels[index];
      label.color = new Color(label.color.r, label.color.g, label.color.b, 0.5f);
    }
    if (!((Object) this.StudentManager.Students[this.StudentManager.RivalID] != (Object) null))
      return;
    if (!this.Eighties)
    {
      if (SchemeGlobals.GetSchemeStage(1) == 8)
      {
        UILabel label = this.Labels[1];
        label.color = new Color(label.color.r, label.color.g, label.color.b, 1f);
      }
      if (SchemeGlobals.GetSchemeStage(2) == 6)
      {
        UILabel label = this.Labels[2];
        label.color = new Color(label.color.r, label.color.g, label.color.b, 1f);
      }
      if (SchemeGlobals.GetSchemeStage(3) == 4)
      {
        UILabel label = this.Labels[3];
        label.color = new Color(label.color.r, label.color.g, label.color.b, 1f);
      }
      if (SchemeGlobals.GetSchemeStage(4) == 7)
      {
        UILabel label = this.Labels[4];
        label.color = new Color(label.color.r, label.color.g, label.color.b, 1f);
      }
      if (SchemeGlobals.GetSchemeStage(5) != 9)
        return;
      UILabel label1 = this.Labels[5];
      label1.color = new Color(label1.color.r, label1.color.g, label1.color.b, 1f);
    }
    else
    {
      if (this.ReportedAlcohol)
        this.Labels[1].text = "Already Reported Alcohol";
      if (this.ReportedCondoms)
        this.Labels[2].text = "Already Reported Condoms";
      if (this.ReportedCigarettes)
        this.Labels[3].text = "Already Reported Cigarettes";
      if (this.ReportedTheft)
        this.Labels[4].text = "Already Reported Theft";
      if (this.ReportedCheating)
        this.Labels[5].text = "Already Reported Cheating";
      if (this.StudentManager.RivalBookBag.Alcohol && !this.ReportedAlcohol)
        this.Labels[1].alpha = 1f;
      if (this.StudentManager.RivalBookBag.Condoms && !this.ReportedCondoms)
        this.Labels[2].alpha = 1f;
      if (this.StudentManager.RivalBookBag.Cigarettes && !this.ReportedCigarettes)
        this.Labels[3].alpha = 1f;
      if (this.StudentManager.RivalBookBag.StolenRing && !this.ReportedTheft)
        this.Labels[4].alpha = 1f;
      if (this.StudentManager.RivalBookBag.AnswerSheet && !this.ReportedCheating)
        this.Labels[5].alpha = 1f;
      if (!this.StudentManager.RivalBookBag.Narcotics)
        return;
      this.Labels[6].alpha = 1f;
    }
  }

  private void UpdateHighlight()
  {
    if (this.Selected < 1)
      this.Selected = 7;
    else if (this.Selected > 7)
      this.Selected = 1;
    if (this.Selected == 6)
      this.NarcoticsWindow.gameObject.SetActive(true);
    else
      this.NarcoticsWindow.gameObject.SetActive(false);
    this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, (float) (200.0 - 50.0 * (double) this.Selected), this.Highlight.transform.localPosition.z);
  }

  private void LateUpdate()
  {
    if ((double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) >= 5.0)
      return;
    if (this.Angry)
    {
      this.BS_SadMouth = Mathf.Lerp(this.BS_SadMouth, 100f, Time.deltaTime * 10f);
      this.BS_MadBrow = Mathf.Lerp(this.BS_MadBrow, 100f, Time.deltaTime * 10f);
      this.BS_SadBrow = Mathf.Lerp(this.BS_SadBrow, 0.0f, Time.deltaTime * 10f);
      this.BS_AngryEyes = Mathf.Lerp(this.BS_AngryEyes, 100f, Time.deltaTime * 10f);
    }
    else if (this.Stern)
    {
      this.BS_SadMouth = Mathf.Lerp(this.BS_SadMouth, 0.0f, Time.deltaTime * 10f);
      this.BS_MadBrow = Mathf.Lerp(this.BS_MadBrow, 100f, Time.deltaTime * 10f);
      this.BS_SadBrow = Mathf.Lerp(this.BS_SadBrow, 0.0f, Time.deltaTime * 10f);
      this.BS_AngryEyes = Mathf.Lerp(this.BS_AngryEyes, 0.0f, Time.deltaTime * 10f);
    }
    else if (this.Sad)
    {
      this.BS_SadMouth = Mathf.Lerp(this.BS_SadMouth, 100f, Time.deltaTime * 10f);
      this.BS_MadBrow = Mathf.Lerp(this.BS_MadBrow, 0.0f, Time.deltaTime * 10f);
      this.BS_SadBrow = Mathf.Lerp(this.BS_SadBrow, 100f, Time.deltaTime * 10f);
      this.BS_AngryEyes = Mathf.Lerp(this.BS_AngryEyes, 0.0f, Time.deltaTime * 10f);
    }
    else
    {
      this.BS_SadMouth = Mathf.Lerp(this.BS_SadMouth, 0.0f, Time.deltaTime * 10f);
      this.BS_MadBrow = Mathf.Lerp(this.BS_MadBrow, 0.0f, Time.deltaTime * 10f);
      this.BS_SadBrow = Mathf.Lerp(this.BS_SadBrow, 0.0f, Time.deltaTime * 10f);
      this.BS_AngryEyes = Mathf.Lerp(this.BS_AngryEyes, 0.0f, Time.deltaTime * 10f);
    }
    if (this.EightiesAttacher.gameObject.activeInHierarchy && !this.UpdatedFace)
    {
      this.UpdatedFace = true;
      this.Face = this.PelvisRoot.GetChild(1).GetComponent<SkinnedMeshRenderer>();
    }
    this.Face.SetBlendShapeWeight(this.SadMouthID, this.BS_SadMouth);
    this.Face.SetBlendShapeWeight(this.MadBrowID, this.BS_MadBrow);
    this.Face.SetBlendShapeWeight(this.SadBrowID, this.BS_SadBrow);
    this.Face.SetBlendShapeWeight(this.AngryEyesID, this.BS_AngryEyes);
    if (this.MyAudio.isPlaying)
    {
      if (this.InterrogationPhase != 6)
      {
        this.MouthTimer += Time.deltaTime;
        if ((double) this.MouthTimer > (double) this.TimerLimit)
        {
          this.MouthTarget = Random.Range(0.0f, 100f);
          this.MouthTimer = 0.0f;
        }
        this.MouthOpen = Mathf.Lerp(this.MouthOpen, this.MouthTarget, Time.deltaTime * this.TalkSpeed);
      }
      else
        this.MouthOpen = Mathf.Lerp(this.MouthOpen, 0.0f, Time.deltaTime * this.TalkSpeed);
    }
    else
      this.MouthOpen = Mathf.Lerp(this.MouthOpen, 0.0f, Time.deltaTime * this.TalkSpeed);
    this.Face.SetBlendShapeWeight(this.MouthOpenID, this.MouthOpen);
    this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.LookAtPlayer ? this.Yandere.Head.position : this.Default.position, Time.deltaTime * 2f);
    this.Head.LookAt(this.LookAtTarget);
  }

  public void Quit()
  {
    Debug.Log((object) "CounselorScript has called the Quit() function.");
    if ((Object) this.StudentManager.Students[1] != (Object) null)
      this.Yandere.Senpai = this.StudentManager.Students[1].transform;
    this.Yandere.PauseScreen.Hint.MyPanel.alpha = 1f;
    this.Yandere.DetectionPanel.alpha = 1f;
    this.Yandere.RPGCamera.mouseSpeed = 8f;
    this.Yandere.HUD.alpha = 1f;
    this.Yandere.WeaponTimer = 0.0f;
    this.Yandere.TheftTimer = 0.0f;
    this.Yandere.HeartRate.gameObject.SetActive(true);
    this.Yandere.CannotRecover = false;
    this.Yandere.Noticed = false;
    this.Yandere.Talking = true;
    this.Yandere.ShoulderCamera.GoingToCounselor = false;
    this.Yandere.ShoulderCamera.HUD.SetActive(true);
    this.Yandere.ShoulderCamera.Noticed = false;
    this.Yandere.ShoulderCamera.enabled = true;
    this.Yandere.TargetStudent = this.Student;
    if (!this.Yandere.Jukebox.FullSanity.isPlaying)
    {
      this.Yandere.Jukebox.FullSanity.volume = 0.0f;
      this.Yandere.Jukebox.HalfSanity.volume = 0.0f;
      this.Yandere.Jukebox.NoSanity.volume = 0.0f;
      this.Yandere.Jukebox.FullSanity.Play();
      this.Yandere.Jukebox.HalfSanity.Play();
      this.Yandere.Jukebox.NoSanity.Play();
    }
    this.Yandere.transform.position = new Vector3(-21.5f, 0.0f, 8f);
    this.Yandere.transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
    this.Yandere.ShoulderCamera.OverShoulder = false;
    this.CounselorBar.SetActive(false);
    this.StudentManager.EnablePrompts();
    if (!this.EightiesAttacher.gameObject.activeInHierarchy)
    {
      this.Laptop.SetActive(true);
    }
    else
    {
      this.MyAnimation.CrossFade("f02_deskWritePingPong_00");
      this.transform.position += new Vector3(0.0f, -0.1f, 0.0f);
      this.RedPen.SetActive(true);
    }
    this.LookAtPlayer = false;
    this.ShowWindow = false;
    this.TalkTimer = 1f;
    this.Patience = 0;
    this.Stern = false;
    this.Angry = false;
    this.Sad = false;
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    if (!this.StudentManager.TutorialActive)
      this.StudentManager.ComeBack();
    this.StudentManager.GracePeriod(10f);
    this.StudentManager.Reputation.UpdateRep();
    this.Yandere.CameraEffects.UpdateDOF(2f);
    Physics.SyncTransforms();
  }

  private void UpdateInterrogation()
  {
    if (this.VibrationCheck)
    {
      this.VibrationTimer = Mathf.MoveTowards(this.VibrationTimer, 0.0f, Time.deltaTime);
      if ((double) this.VibrationTimer == 0.0)
      {
        GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
        this.VibrationCheck = false;
      }
    }
    this.Timer += Time.deltaTime;
    if (Input.GetButtonDown("A") && this.InterrogationPhase != 4)
      this.Timer += 20f;
    if (this.InterrogationPhase == 0)
    {
      if ((double) this.Timer > 1.0 || Input.GetButtonDown("A"))
      {
        Debug.Log((object) ("Previous Punishments: " + this.CounselorPunishments.ToString()));
        this.Patience -= this.CounselorPunishments;
        if (this.Patience < -6)
          this.Patience = -6;
        this.GenkaChibi.transform.localPosition = new Vector3(0.0f, (float) (90 * this.Patience), 0.0f);
        this.Yandere.MainCamera.transform.eulerAngles = this.CameraTarget.eulerAngles;
        this.Yandere.MainCamera.transform.position = this.CameraTarget.position;
        this.Yandere.MainCamera.transform.Translate(Vector3.forward * -1f);
        if (this.CounselorVisits < 3)
          ++this.CounselorVisits;
        if (this.CounselorTape == 0)
        {
          this.CounselorOption[4].Label.color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
        }
        else
        {
          this.CounselorOption[4].Label.color = new Color(0.0f, 0.0f, 0.0f, 1f);
          this.CounselorOption[4].Label.text = "Blame Delinquents";
        }
        if ((Object) this.Yandere.Subtitle.CurrentClip != (Object) null)
          Object.Destroy((Object) this.Yandere.Subtitle.CurrentClip);
        this.Yandere.CameraEffects.UpdateDOF(1.1f);
        this.GenkaChibi.mainTexture = this.AnnoyedChibi;
        this.CounselorBar.SetActive(true);
        this.Subtitle.Label.text = "";
        ++this.InterrogationPhase;
        Time.timeScale = 1f;
        this.Timer = 0.0f;
      }
    }
    else if (this.InterrogationPhase == 1)
    {
      UISprite darkness = this.Yandere.Police.Darkness;
      darkness.color = darkness.color - new Color(0.0f, 0.0f, 0.0f, Time.deltaTime);
      this.Yandere.MainCamera.transform.position = Vector3.Lerp(this.Yandere.MainCamera.transform.position, this.CameraTarget.position, (float) ((double) this.Timer * (double) Time.deltaTime * 0.5));
      if ((double) this.Timer > 5.0 || Input.GetButtonDown("A"))
      {
        this.Yandere.MainCamera.transform.position = this.CameraTarget.position;
        this.MyAudio.clip = this.GreetingClips[this.CounselorVisits];
        this.CounselorSubtitle.text = this.Greetings[this.CounselorVisits];
        this.Yandere.Police.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        ++this.InterrogationPhase;
        this.MyAudio.Play();
        this.Timer = 0.0f;
      }
    }
    else if (this.InterrogationPhase == 2)
    {
      if (Input.GetButtonDown("A"))
        this.MyAudio.Stop();
      if ((double) this.Timer > (double) this.MyAudio.clip.length + 0.5)
      {
        if (this.Crime == StudentWitnessType.Blood || this.Crime == StudentWitnessType.BloodAndInsanity)
        {
          this.MyAudio.clip = this.BloodLectureClips[this.BloodVisits];
          this.CounselorSubtitle.text = this.BloodLectures[this.BloodVisits];
          if (this.BloodVisits < 2)
            ++this.BloodVisits;
          this.CrimeID = 1;
        }
        else if (this.Crime == StudentWitnessType.Insanity || this.Crime == StudentWitnessType.CleaningItem || this.Crime == StudentWitnessType.HoldingBloodyClothing || this.Crime == StudentWitnessType.Poisoning)
        {
          this.MyAudio.clip = this.InsanityLectureClips[this.InsanityVisits];
          this.CounselorSubtitle.text = this.InsanityLectures[this.InsanityVisits];
          if (this.InsanityVisits < 2)
            ++this.InsanityVisits;
          this.CrimeID = 2;
        }
        else if (this.Crime == StudentWitnessType.Lewd)
        {
          this.MyAudio.clip = this.LewdLectureClips[this.LewdVisits];
          this.CounselorSubtitle.text = this.LewdLectures[this.LewdVisits];
          if (this.LewdVisits < 2)
            ++this.LewdVisits;
          this.CrimeID = 3;
        }
        else if (this.Crime == StudentWitnessType.Theft || this.Crime == StudentWitnessType.Pickpocketing)
        {
          this.MyAudio.clip = this.TheftLectureClips[this.TheftVisits];
          this.CounselorSubtitle.text = this.TheftLectures[this.TheftVisits];
          if (this.TheftVisits < 2)
            ++this.TheftVisits;
          this.CrimeID = 4;
        }
        else if (this.Crime == StudentWitnessType.Trespassing)
        {
          this.MyAudio.clip = this.TrespassLectureClips[this.TrespassVisits];
          this.CounselorSubtitle.text = this.TrespassLectures[this.TrespassVisits];
          if (this.TrespassVisits < 2)
            ++this.TrespassVisits;
          this.CrimeID = 5;
        }
        else if (this.Crime == StudentWitnessType.Weapon || this.Crime == StudentWitnessType.WeaponAndBlood || this.Crime == StudentWitnessType.WeaponAndInsanity || this.Crime == StudentWitnessType.WeaponAndBloodAndInsanity)
        {
          this.MyAudio.clip = this.WeaponLectureClips[this.WeaponVisits];
          this.CounselorSubtitle.text = this.WeaponLectures[this.WeaponVisits];
          if (this.WeaponVisits < 2)
            ++this.WeaponVisits;
          this.CrimeID = 6;
        }
        ++this.InterrogationPhase;
        this.MyAudio.Play();
        this.Timer = 0.0f;
      }
    }
    else if (this.InterrogationPhase == 3)
    {
      if (Input.GetButtonDown("A"))
        this.MyAudio.Stop();
      if ((double) this.Timer > (double) this.MyAudio.clip.length + 0.5)
      {
        for (int index = 1; index < 7; ++index)
        {
          this.CounselorOption[index].transform.localPosition = this.CounselorOption[index].OriginalPosition;
          this.CounselorOption[index].Sprite.color = this.CounselorOption[index].OriginalColor;
          this.CounselorOption[index].transform.localScale = new Vector3(0.9f, 0.9f, 1f);
          this.CounselorOption[index].gameObject.SetActive(true);
          this.CounselorOption[index].Clicked = false;
        }
        this.Yandere.CharacterAnimation["f02_countdown_00"].speed = 1f;
        this.Yandere.CharacterAnimation.Play("f02_countdown_00");
        this.Yandere.transform.position = new Vector3(-27.818f, 0.0f, 12f);
        this.Yandere.transform.eulerAngles = new Vector3(0.0f, -90f, 0.0f);
        this.Yandere.MainCamera.transform.position = new Vector3(-28f, 1.1f, 12f);
        this.Yandere.MainCamera.transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
        this.Reticle.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.CounselorOptions.SetActive(true);
        this.CounselorBar.SetActive(false);
        this.CounselorSubtitle.text = "";
        this.MyAudio.clip = this.Countdown;
        this.MyAudio.Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        this.Yandere.CameraEffects.UpdateDOF(0.4f);
        ++this.InterrogationPhase;
        this.Timer = 0.0f;
      }
    }
    else if (this.InterrogationPhase == 4)
    {
      this.Yandere.MainCamera.transform.Translate(Vector3.forward * Time.deltaTime * 0.01f);
      this.CounselorOptions.transform.localEulerAngles += new Vector3(0.0f, 0.0f, Time.deltaTime * -36f);
      if (this.InputDevice.Type == InputDeviceType.Gamepad)
      {
        this.Reticle.SetActive(true);
        Cursor.visible = false;
        this.Reticle.transform.localPosition += new Vector3(Input.GetAxis("Horizontal") * 20f, Input.GetAxis("Vertical") * 20f, 0.0f);
        if ((double) this.Reticle.transform.localPosition.x > 975.0)
          this.Reticle.transform.localPosition = new Vector3(975f, this.Reticle.transform.localPosition.y, this.Reticle.transform.localPosition.z);
        if ((double) this.Reticle.transform.localPosition.x < -975.0)
          this.Reticle.transform.localPosition = new Vector3(-975f, this.Reticle.transform.localPosition.y, this.Reticle.transform.localPosition.z);
        if ((double) this.Reticle.transform.localPosition.y > 525.0)
          this.Reticle.transform.localPosition = new Vector3(this.Reticle.transform.localPosition.x, 525f, this.Reticle.transform.localPosition.z);
        if ((double) this.Reticle.transform.localPosition.y < -525.0)
          this.Reticle.transform.localPosition = new Vector3(this.Reticle.transform.localPosition.x, -525f, this.Reticle.transform.localPosition.z);
      }
      else
      {
        Cursor.visible = true;
        this.Reticle.transform.localPosition += new Vector3(Input.GetAxis("Horizontal") * 20f, Input.GetAxis("Vertical") * 20f, 0.0f);
      }
      for (int index1 = 1; index1 < 7; ++index1)
      {
        this.CounselorOption[index1].transform.eulerAngles = new Vector3(this.CounselorOption[index1].transform.eulerAngles.x, this.CounselorOption[index1].transform.eulerAngles.y, 0.0f);
        if (this.CounselorOption[index1].Clicked || this.CounselorOption[index1].Sprite.color != this.CounselorOption[index1].OriginalColor && Input.GetButtonDown("A"))
        {
          for (int index2 = 1; index2 < 7; ++index2)
          {
            if (index2 != index1)
              this.CounselorOption[index2].gameObject.SetActive(false);
          }
          this.Yandere.CharacterAnimation["f02_countdown_00"].time = 10f;
          this.MyAudio.clip = this.Choice;
          this.MyAudio.pitch = 1f;
          this.MyAudio.Play();
          Cursor.lockState = CursorLockMode.Locked;
          Cursor.visible = false;
          this.Reticle.SetActive(false);
          ++this.InterrogationPhase;
          this.Answer = index1;
          this.Timer = 0.0f;
        }
      }
      if ((double) this.Timer > 10.0)
      {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.Reticle.SetActive(false);
        this.SilentTreatment = true;
        ++this.InterrogationPhase;
        this.Timer = 0.0f;
      }
    }
    else if (this.InterrogationPhase == 5)
    {
      int index = 1;
      if (this.SilentTreatment)
      {
        this.CounselorOptions.transform.localScale += new Vector3(Time.deltaTime * 2f, Time.deltaTime * 2f, Time.deltaTime * 2f);
        for (; index < 7; ++index)
          this.CounselorOption[index].transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
      }
      if ((double) this.Timer > 3.0 || Input.GetButtonDown("A"))
      {
        this.CounselorOptions.transform.localScale = new Vector3(1f, 1f, 1f);
        this.CounselorOptions.SetActive(false);
        this.CounselorBar.SetActive(true);
        this.Yandere.CameraEffects.UpdateDOF(1.1f);
        this.Yandere.transform.position = new Vector3(-27.51f, 0.0f, 12f);
        this.Yandere.MainCamera.transform.position = this.CameraTarget.position;
        this.Yandere.MainCamera.transform.eulerAngles = this.CameraTarget.eulerAngles;
        if (this.SilentTreatment)
        {
          this.MyAudio.clip = this.Silence;
          this.CounselorSubtitle.text = "...";
        }
        else if (this.Answer == 1)
        {
          this.MyAudio.clip = this.ExcuseClips[this.CrimeID];
          this.CounselorSubtitle.text = this.Excuses[this.CrimeID];
          if (this.CrimeID == 1)
            ++this.BloodExcuseUsed;
          else if (this.CrimeID == 2)
            ++this.InsanityExcuseUsed;
          else if (this.CrimeID == 3)
            ++this.LewdExcuseUsed;
          else if (this.CrimeID == 4)
            ++this.TheftExcuseUsed;
          else if (this.CrimeID == 5)
            ++this.TrespassExcuseUsed;
          else if (this.CrimeID == 6)
            ++this.WeaponExcuseUsed;
        }
        else if (this.Answer == 2)
        {
          this.MyAudio.clip = this.ApologyClip;
          this.CounselorSubtitle.text = this.Apology;
          ++this.ApologiesUsed;
        }
        else if (this.Answer == 3)
        {
          this.MyAudio.clip = this.LieClips[this.CrimeID];
          this.CounselorSubtitle.text = this.Lies[this.CrimeID];
        }
        else if (this.Answer == 4)
        {
          this.MyAudio.clip = this.DelinquentClips[this.CrimeID];
          this.CounselorSubtitle.text = this.Delinquents[this.CrimeID];
        }
        else if (this.Answer == 5)
        {
          this.MyAudio.clip = this.FlirtClip;
          this.CounselorSubtitle.text = this.Flirt;
        }
        else if (this.Answer == 6)
        {
          this.MyAudio.clip = this.ThreatenClip;
          this.CounselorSubtitle.text = this.Threaten;
        }
        this.Yandere.CharacterAnimation.Play("f02_sit_00");
        ++this.InterrogationPhase;
        this.MyAudio.Play();
        this.Timer = 0.0f;
      }
    }
    else if (this.InterrogationPhase == 6)
    {
      if (this.Answer == 6)
      {
        this.Yandere.Sanity = Mathf.MoveTowards(this.Yandere.Sanity, 0.0f, Time.deltaTime * 7.5f);
        this.Rumble.volume += Time.deltaTime * 0.075f;
      }
      if ((double) this.Timer > (double) this.MyAudio.clip.length + 0.5 || Input.GetButtonDown("A"))
      {
        if (this.SilentTreatment)
        {
          int index = Random.Range(0, 3);
          this.MyAudio.clip = this.SilentClips[index];
          this.CounselorSubtitle.text = this.Silents[index];
          --this.Patience;
        }
        else if (this.Answer == 1)
        {
          if (this.CrimeID == 1)
            Debug.Log((object) "The player's crime is Bloodiness.");
          else if (this.CrimeID == 2)
            Debug.Log((object) "The player's crime is Insanity.");
          else if (this.CrimeID == 3)
            Debug.Log((object) "The player's crime is Lewdness.");
          else if (this.CrimeID == 4)
            Debug.Log((object) "The player's crime is Theft.");
          else if (this.CrimeID == 5)
            Debug.Log((object) "The player's crime is Trespassing.");
          else if (this.CrimeID == 6)
            Debug.Log((object) "The player's crime is Weaponry.");
          Debug.Log((object) "The player has chosen to use an exuse.");
          bool flag = false;
          if (this.CrimeID == 1 && this.BloodExcuseUsed > 1 || this.CrimeID == 2 && this.InsanityExcuseUsed > 1 || this.CrimeID == 3 && this.LewdExcuseUsed > 1 || this.CrimeID == 4 && this.TheftExcuseUsed > 1 || this.CrimeID == 5 && this.TrespassExcuseUsed > 1 || this.CrimeID == 6 && this.WeaponExcuseUsed > 1)
          {
            Debug.Log((object) "Yandere-chan has already used this excuse before.");
            flag = true;
          }
          if (!flag)
          {
            Debug.Log((object) "Yandere-chan's excuse is not invalid!");
            this.MyAudio.clip = this.AcceptExcuseClips[this.CrimeID];
            this.CounselorSubtitle.text = this.AcceptExcuses[this.CrimeID];
            this.MyAnimation.CrossFade("CounselorRelief", 1f);
            this.Stern = false;
            this.Patience = 1;
          }
          else
          {
            Debug.Log((object) "Yandere-chan's excuse has been deemed invalid.");
            int index = Random.Range(0, 3);
            this.MyAudio.clip = this.RejectExcuseClips[index];
            this.CounselorSubtitle.text = this.RejectExcuses[index];
            this.MyAnimation.CrossFade("CounselorAnnoyed");
            this.Angry = true;
            --this.Patience;
          }
        }
        else if (this.Answer == 2)
        {
          if (this.ApologiesUsed == 1)
          {
            this.MyAudio.clip = this.AcceptApologyClip;
            this.CounselorSubtitle.text = this.AcceptApology;
            this.MyAnimation.CrossFade("CounselorRelief", 1f);
            this.Stern = false;
            this.Patience = 1;
          }
          else
          {
            int index = Random.Range(0, 3);
            this.MyAudio.clip = this.RejectApologyClips[index];
            this.CounselorSubtitle.text = this.RejectApologies[index];
            this.MyAnimation.CrossFade("CounselorAnnoyed");
            --this.Patience;
          }
        }
        else if (this.Answer == 3)
        {
          int index = Random.Range(0, 5);
          this.MyAudio.clip = this.RejectLieClips[index];
          this.CounselorSubtitle.text = this.RejectLies[index];
          this.MyAnimation.CrossFade("CounselorAnnoyed");
          this.Angry = true;
          --this.Patience;
        }
        else if (this.Answer == 4)
        {
          bool flag1 = false;
          bool flag2 = false;
          bool flag3 = false;
          int num = 5;
          if (StudentGlobals.GetStudentDead(76) && StudentGlobals.GetStudentDead(77) && StudentGlobals.GetStudentDead(78) && StudentGlobals.GetStudentDead(79) && StudentGlobals.GetStudentDead(80))
            flag3 = true;
          else if (StudentGlobals.GetStudentExpelled(76) && StudentGlobals.GetStudentExpelled(77) && StudentGlobals.GetStudentExpelled(78) && StudentGlobals.GetStudentExpelled(79) && StudentGlobals.GetStudentExpelled(80))
          {
            flag2 = true;
          }
          else
          {
            if ((Object) this.StudentManager.Students[76] == (Object) null)
              --num;
            else if (!this.StudentManager.Students[76].gameObject.activeInHierarchy)
              --num;
            if ((Object) this.StudentManager.Students[77] == (Object) null)
              --num;
            else if (!this.StudentManager.Students[77].gameObject.activeInHierarchy)
              --num;
            if ((Object) this.StudentManager.Students[78] == (Object) null)
              --num;
            else if (!this.StudentManager.Students[78].gameObject.activeInHierarchy)
              --num;
            if ((Object) this.StudentManager.Students[79] == (Object) null)
              --num;
            else if (!this.StudentManager.Students[79].gameObject.activeInHierarchy)
              --num;
            if ((Object) this.StudentManager.Students[80] == (Object) null)
              --num;
            else if (!this.StudentManager.Students[80].gameObject.activeInHierarchy)
              --num;
            if (num == 0)
              flag1 = true;
          }
          bool flag4 = false;
          if (this.CrimeID == 1 && this.BloodBlameUsed > 1 || this.CrimeID == 2 && this.InsanityBlameUsed > 1 || this.CrimeID == 3 && this.LewdBlameUsed > 1 || this.CrimeID == 4 && this.TheftBlameUsed > 1 || this.CrimeID == 5 && this.TrespassBlameUsed > 1 || this.CrimeID == 6 && this.WeaponBlameUsed > 1)
            flag4 = true;
          if (flag3)
          {
            this.MyAudio.clip = this.DelinquentsDeadClip;
            this.CounselorSubtitle.text = this.DelinquentsDead;
            this.MyAnimation.CrossFade("CounselorAnnoyed");
            this.Angry = true;
            --this.Patience;
          }
          else if (flag2)
          {
            this.MyAudio.clip = this.DelinquentsExpelledClip;
            this.CounselorSubtitle.text = this.DelinquentsExpelled;
            this.MyAnimation.CrossFade("CounselorAnnoyed");
            --this.Patience;
          }
          else if (flag1)
          {
            this.MyAudio.clip = this.DelinquentsGoneClip;
            this.CounselorSubtitle.text = this.DelinquentsGone;
            this.MyAnimation.CrossFade("CounselorAnnoyed");
            --this.Patience;
          }
          else if (!flag4)
          {
            if (this.CrimeID == 1)
            {
              Debug.Log((object) "Banning weapons.");
              ++this.WeaponsBanned;
            }
            this.MyAudio.clip = this.AcceptBlameClips[this.CrimeID];
            this.CounselorSubtitle.text = this.AcceptBlames[this.CrimeID];
            this.MyAnimation.CrossFade("CounselorSad", 1f);
            this.Stern = false;
            this.Sad = true;
            this.Patience = 1;
            ++this.DelinquentPunishments;
            if (this.CrimeID == 1)
              ++this.BloodBlameUsed;
            else if (this.CrimeID == 2)
              ++this.InsanityBlameUsed;
            else if (this.CrimeID == 3)
              ++this.LewdBlameUsed;
            else if (this.CrimeID == 4)
              ++this.TheftBlameUsed;
            else if (this.CrimeID == 5)
              ++this.TrespassBlameUsed;
            else if (this.CrimeID == 6)
              ++this.WeaponBlameUsed;
            if (this.DelinquentPunishments > 5)
              this.MustExpelDelinquents = true;
          }
          else
          {
            int index = Random.Range(0, 3);
            this.MyAudio.clip = this.RejectBlameClips[index];
            this.CounselorSubtitle.text = this.RejectBlames[index];
            this.MyAnimation.CrossFade("CounselorAnnoyed");
            --this.Patience;
          }
        }
        else if (this.Answer == 5)
        {
          int index = Random.Range(0, 3);
          this.MyAudio.clip = this.RejectFlirtClips[index];
          this.CounselorSubtitle.text = this.RejectFlirts[index];
          this.MyAnimation.CrossFade("CounselorAnnoyed");
          this.Angry = true;
          --this.Patience;
        }
        else if (this.Answer == 6)
        {
          this.MyAudio.clip = this.RejectThreatClip;
          this.CounselorSubtitle.text = this.RejectThreat;
          this.MyAnimation.CrossFade("CounselorAnnoyed");
          this.InterrogationPhase += 2;
          this.Patience = -6;
          this.Angry = true;
        }
        if (this.Patience < -6)
          this.Patience = -6;
        if (this.Patience == 1)
          this.GenkaChibi.mainTexture = this.HappyChibi;
        else if (this.Patience == -6)
          this.GenkaChibi.mainTexture = this.MadChibi;
        else
          this.GenkaChibi.mainTexture = this.AnnoyedChibi;
        ++this.InterrogationPhase;
        this.MyAudio.Play();
        this.Timer = 0.0f;
      }
    }
    else if (this.InterrogationPhase == 7)
    {
      if ((double) this.Timer > (double) this.MyAudio.clip.length + 0.5 || Input.GetButtonDown("A"))
      {
        if (this.Patience < 0)
        {
          int index = Random.Range(0, 3);
          this.MyAudio.clip = this.BadClosingClips[index];
          this.CounselorSubtitle.text = this.BadClosings[index];
          this.MyAnimation.CrossFade("CounselorArmsCrossed", 1f);
          this.InterrogationPhase += 2;
        }
        else
        {
          if (this.MustExpelDelinquents)
          {
            this.MyAudio.clip = this.ExpelDelinquentsClip;
            this.CounselorSubtitle.text = this.ExpelDelinquents;
            this.MustExpelDelinquents = false;
            this.StudentManager.Students[76].gameObject.SetActive(false);
            this.StudentManager.Students[77].gameObject.SetActive(false);
            this.StudentManager.Students[78].gameObject.SetActive(false);
            this.StudentManager.Students[79].gameObject.SetActive(false);
            this.StudentManager.Students[80].gameObject.SetActive(false);
            this.ExpelledDelinquents = true;
            this.DelinquentRadio.SetActive(false);
          }
          else if (this.Answer == 4)
          {
            this.MyAudio.clip = this.BlameClosingClips[this.CrimeID];
            this.CounselorSubtitle.text = this.BlameClosings[this.CrimeID];
          }
          else
          {
            int index = Random.Range(0, 3);
            this.MyAudio.clip = this.FreeToLeaveClips[index];
            this.CounselorSubtitle.text = this.FreeToLeaves[index];
            this.MyAnimation.CrossFade("CounselorArmsCrossed", 1f);
            this.Stern = true;
          }
          ++this.InterrogationPhase;
        }
        this.MyAudio.Play();
        this.Timer = 0.0f;
      }
    }
    else if (this.InterrogationPhase == 8)
    {
      if ((double) this.Timer > (double) this.MyAudio.clip.length + 0.5 || Input.GetButtonDown("A"))
      {
        this.CounselorDoor.FadeOut = true;
        this.CounselorDoor.Exit = true;
        this.Interrogating = false;
        this.InterrogationPhase = 0;
        this.Timer = 0.0f;
      }
    }
    else if (this.InterrogationPhase == 9)
    {
      if ((double) this.Timer > (double) this.MyAudio.clip.length + 0.5 || Input.GetButtonDown("A"))
      {
        this.MyAnimation.Play("CounselorSlamDesk");
        ++this.InterrogationPhase;
        this.MyAudio.Stop();
        this.Stern = false;
        this.Angry = true;
        this.Timer = 0.0f;
      }
    }
    else if (this.InterrogationPhase == 10)
    {
      if ((double) this.Timer > 0.5)
      {
        if (!this.Slammed)
        {
          GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
          this.VibrationCheck = true;
          this.VibrationTimer = 0.2f;
          AudioSource.PlayClipAtPoint(this.Slam, this.transform.position);
          this.Shake.shakeAmount = 0.1f;
          this.Shake.enabled = true;
          this.Shake.shake = 0.5f;
          this.Slammed = true;
        }
        this.Shake.shakeAmount = Mathf.Lerp(this.Shake.shakeAmount, 0.0f, Time.deltaTime);
      }
      this.Shake.shakeAmount = Mathf.Lerp(this.Shake.shakeAmount, 0.0f, Time.deltaTime * 10f);
      if ((double) this.Timer > 1.5 || Input.GetButtonDown("A"))
      {
        this.MyAudio.clip = this.SuspensionClips[Mathf.Abs(this.Patience)];
        this.CounselorSubtitle.text = this.Suspensions[Mathf.Abs(this.Patience)];
        this.MyAnimation.Play("CounselorSlamIdle");
        this.Shake.enabled = false;
        ++this.InterrogationPhase;
        this.SentHome = true;
        this.MyAudio.Play();
        this.Timer = 0.0f;
      }
    }
    else if (this.InterrogationPhase == 11 && ((double) this.Timer > (double) this.MyAudio.clip.length + 0.5 || Input.GetButtonDown("A")) && !this.Yandere.Police.FadeOut)
    {
      ++this.CounselorPunishments;
      this.Yandere.Police.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.Yandere.Police.SuspensionLength = Mathf.Abs(this.Patience);
      this.Yandere.Police.Darkness.enabled = true;
      this.Yandere.Police.ClubActivity = false;
      this.Yandere.Police.Suspended = true;
      this.Yandere.Police.FadeOut = true;
      this.Yandere.ShoulderCamera.HUD.SetActive(true);
      ++this.InterrogationPhase;
      this.Expelled = true;
      this.Timer = 0.0f;
      this.Yandere.Senpai = this.StudentManager.Students[1].transform;
      this.StudentManager.Reputation.PendingRep -= 10f;
      this.StudentManager.Reputation.UpdateRep();
    }
    if (this.InterrogationPhase <= 6)
      return;
    this.Yandere.Sanity = Mathf.Lerp(this.Yandere.Sanity, 100f, Time.deltaTime);
    this.Rumble.volume = Mathf.Lerp(this.Rumble.volume, 0.0f, Time.deltaTime);
    this.GenkaChibi.transform.localPosition = Vector3.Lerp(this.GenkaChibi.transform.localPosition, new Vector3(0.0f, (float) (90 * this.Patience), 0.0f), Time.deltaTime * 10f);
  }

  public void SaveExcusesUsed()
  {
    CounselorGlobals.BloodExcuseUsed = this.BloodExcuseUsed;
    CounselorGlobals.InsanityExcuseUsed = this.InsanityExcuseUsed;
    CounselorGlobals.LewdExcuseUsed = this.LewdExcuseUsed;
    CounselorGlobals.TheftExcuseUsed = this.TheftExcuseUsed;
    CounselorGlobals.TrespassExcuseUsed = this.TrespassExcuseUsed;
    CounselorGlobals.WeaponExcuseUsed = this.WeaponExcuseUsed;
  }

  public void LoadExcusesUsed()
  {
    this.BloodExcuseUsed = CounselorGlobals.BloodExcuseUsed;
    this.InsanityExcuseUsed = CounselorGlobals.InsanityExcuseUsed;
    this.LewdExcuseUsed = CounselorGlobals.LewdExcuseUsed;
    this.TheftExcuseUsed = CounselorGlobals.TheftExcuseUsed;
    this.TrespassExcuseUsed = CounselorGlobals.TrespassExcuseUsed;
    this.WeaponExcuseUsed = CounselorGlobals.WeaponExcuseUsed;
  }

  public void SaveCounselorData()
  {
    CounselorGlobals.CounselorPunishments = this.CounselorPunishments;
    CounselorGlobals.CounselorVisits = this.CounselorVisits;
    CounselorGlobals.CounselorTape = this.CounselorTape;
    CounselorGlobals.BloodVisits = this.BloodVisits;
    CounselorGlobals.InsanityVisits = this.InsanityVisits;
    CounselorGlobals.LewdVisits = this.LewdVisits;
    CounselorGlobals.TheftVisits = this.TheftVisits;
    CounselorGlobals.TrespassVisits = this.TrespassVisits;
    CounselorGlobals.WeaponVisits = this.WeaponVisits;
    CounselorGlobals.BloodBlameUsed = this.BloodBlameUsed;
    CounselorGlobals.InsanityBlameUsed = this.InsanityBlameUsed;
    CounselorGlobals.LewdBlameUsed = this.LewdBlameUsed;
    CounselorGlobals.TheftBlameUsed = this.TheftBlameUsed;
    CounselorGlobals.TrespassBlameUsed = this.TrespassBlameUsed;
    CounselorGlobals.WeaponBlameUsed = this.WeaponBlameUsed;
    CounselorGlobals.ApologiesUsed = this.ApologiesUsed;
    CounselorGlobals.WeaponsBanned = this.WeaponsBanned;
    CounselorGlobals.DelinquentPunishments = this.DelinquentPunishments;
  }

  public void ExpelStudents()
  {
    if (!this.ExpelledDelinquents)
      return;
    StudentGlobals.SetStudentExpelled(76, true);
    StudentGlobals.SetStudentExpelled(77, true);
    StudentGlobals.SetStudentExpelled(78, true);
    StudentGlobals.SetStudentExpelled(79, true);
    StudentGlobals.SetStudentExpelled(80, true);
  }

  public void SilenceClips(AudioClip[] ClipArray)
  {
    for (int index = 0; index < 11; ++index)
    {
      if (index < ClipArray.Length)
        ClipArray[index] = this.LongestSilence;
    }
  }

  public void SpawnDelinquents()
  {
    for (int index = 1; index < 6; ++index)
    {
      if ((Object) this.StudentManager.Students[75 + index] != (Object) null)
        this.StudentManager.Students[75 + index].Spawned = true;
    }
  }
}
