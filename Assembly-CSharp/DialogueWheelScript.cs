// Decompiled with JetBrains decompiler
// Type: DialogueWheelScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DialogueWheelScript : MonoBehaviour
{
  public AppearanceWindowScript AppearanceWindow;
  public PracticeWindowScript PracticeWindow;
  public TopicInterfaceScript TopicInterface;
  public AdviceWindowScript AdviceWindow;
  public ClubManagerScript ClubManager;
  public LoveManagerScript LoveManager;
  public PauseScreenScript PauseScreen;
  public TaskManagerScript TaskManager;
  public ClubWindowScript ClubWindow;
  public NoteLockerScript NoteLocker;
  public ReputationScript Reputation;
  public TaskWindowScript TaskWindow;
  public PromptBarScript PromptBar;
  public JukeboxScript Jukebox;
  public YandereScript Yandere;
  public ClockScript Clock;
  public UIPanel Panel;
  public GameObject SwitchTopicsWindow;
  public GameObject TaskDialogueWindow;
  public GameObject ClubLeaderWindow;
  public GameObject DatingMinigame;
  public GameObject LockerWindow;
  public Transform Interaction;
  public Transform Favors;
  public Transform Club;
  public Transform Love;
  public UISprite TaskIcon;
  public UISprite Impatience;
  public UILabel CenterLabel;
  public UISprite[] Segment;
  public UISprite[] Shadow;
  public string[] Text;
  public UISprite[] FavorSegment;
  public UISprite[] FavorShadow;
  public UISprite[] ClubSegment;
  public UISprite[] ClubShadow;
  public UISprite[] LoveSegment;
  public UISprite[] LoveShadow;
  public string[] FavorText;
  public string[] ClubText;
  public string[] LoveText;
  public int Selected;
  public int Victim;
  public bool AskingFavor;
  public bool Matchmaking;
  public bool ClubLeader;
  public bool Pestered;
  public bool Show;
  public Vector3 PreviousPosition;
  public Vector2 MouseDelta;
  public Color OriginalColor;

  private void Start()
  {
    this.Interaction.localScale = new Vector3(1f, 1f, 1f);
    this.Favors.localScale = Vector3.zero;
    this.Club.localScale = Vector3.zero;
    this.Love.localScale = Vector3.zero;
    this.transform.localScale = Vector3.zero;
    this.OriginalColor = this.CenterLabel.color;
    if (!GameGlobals.Eighties)
      this.LoveText[4] = "(Not Available)";
    else
      this.LoveText[4] = "Advice";
  }

  private void Update()
  {
    if (!this.Show)
    {
      if ((double) this.transform.localScale.x > 0.100000001490116)
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
      else if (this.Panel.enabled)
      {
        this.transform.localScale = Vector3.zero;
        this.Panel.enabled = false;
      }
    }
    else
    {
      if (this.Yandere.PauseScreen.Show)
        this.Yandere.PauseScreen.ExitPhone();
      if (this.ClubLeader)
      {
        this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Club.localScale = Vector3.Lerp(this.Club.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.Love.localScale = Vector3.Lerp(this.Love.localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      else if (this.AskingFavor)
      {
        this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.Club.localScale = Vector3.Lerp(this.Club.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Love.localScale = Vector3.Lerp(this.Love.localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      else if (this.Matchmaking)
      {
        this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Club.localScale = Vector3.Lerp(this.Club.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Love.localScale = Vector3.Lerp(this.Love.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      }
      else
      {
        this.Interaction.localScale = Vector3.Lerp(this.Interaction.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        this.Favors.localScale = Vector3.Lerp(this.Favors.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Club.localScale = Vector3.Lerp(this.Club.localScale, Vector3.zero, Time.deltaTime * 10f);
        this.Love.localScale = Vector3.Lerp(this.Love.localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      this.MouseDelta.x += Input.GetAxis("Mouse X");
      this.MouseDelta.y += Input.GetAxis("Mouse Y");
      if ((double) this.MouseDelta.x > 11.0)
        this.MouseDelta.x = 11f;
      else if ((double) this.MouseDelta.x < -11.0)
        this.MouseDelta.x = -11f;
      if ((double) this.MouseDelta.y > 11.0)
        this.MouseDelta.y = 11f;
      else if ((double) this.MouseDelta.y < -11.0)
        this.MouseDelta.y = -11f;
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (!this.AskingFavor && !this.Matchmaking)
      {
        if ((double) Input.GetAxis("Vertical") < 0.5 && (double) Input.GetAxis("Vertical") > -0.5 && (double) Input.GetAxis("Horizontal") < 0.5 && (double) Input.GetAxis("Horizontal") > -0.5)
          this.Selected = 0;
        if ((double) Input.GetAxis("Vertical") > 0.5 && (double) Input.GetAxis("Horizontal") < 0.5 && (double) Input.GetAxis("Horizontal") > -0.5 || (double) this.MouseDelta.y > 10.0 && (double) this.MouseDelta.x < 10.0 && (double) this.MouseDelta.x > -10.0)
          this.Selected = 1;
        if ((double) Input.GetAxis("Vertical") > 0.0 && (double) Input.GetAxis("Horizontal") > 0.5 || (double) this.MouseDelta.y > 0.0 && (double) this.MouseDelta.x > 10.0)
          this.Selected = 2;
        if ((double) Input.GetAxis("Vertical") < 0.0 && (double) Input.GetAxis("Horizontal") > 0.5 || (double) this.MouseDelta.y < 0.0 && (double) this.MouseDelta.x > 10.0)
          this.Selected = 3;
        if ((double) Input.GetAxis("Vertical") < -0.5 && (double) Input.GetAxis("Horizontal") < 0.5 && (double) Input.GetAxis("Horizontal") > -0.5 || (double) this.MouseDelta.y < -10.0 && (double) this.MouseDelta.x < 10.0 && (double) this.MouseDelta.x > -10.0)
          this.Selected = 4;
        if ((double) Input.GetAxis("Vertical") < 0.0 && (double) Input.GetAxis("Horizontal") < -0.5 || (double) this.MouseDelta.y < 0.0 && (double) this.MouseDelta.x < -10.0)
          this.Selected = 5;
        if ((double) Input.GetAxis("Vertical") > 0.0 && (double) Input.GetAxis("Horizontal") < -0.5 || (double) this.MouseDelta.y > 0.0 && (double) this.MouseDelta.x < -10.0)
          this.Selected = 6;
        this.CenterLabel.text = this.Text[this.Selected];
        this.CenterLabel.color = this.OriginalColor;
        if (!this.ClubLeader)
        {
          if (this.Selected == 5)
          {
            if (this.Yandere.TargetStudent.Friend)
              this.CenterLabel.text = "Love";
          }
          else if (this.Selected == 6 && this.Yandere.Club == ClubType.Delinquent)
          {
            this.CenterLabel.text = "Intimidate";
            this.CenterLabel.color = new Color(1f, 0.0f, 0.0f, 1f);
          }
        }
        else
          this.CenterLabel.text = this.ClubText[this.Selected];
      }
      else
      {
        if ((double) Input.GetAxis("Vertical") < 0.5 && (double) Input.GetAxis("Vertical") > -0.5 && (double) Input.GetAxis("Horizontal") < 0.5 && (double) Input.GetAxis("Horizontal") > -0.5)
          this.Selected = 0;
        if ((double) Input.GetAxis("Vertical") > 0.5 && (double) Input.GetAxis("Horizontal") < 0.5 && (double) Input.GetAxis("Horizontal") > -0.5 || (double) this.MouseDelta.y > 10.0 && (double) this.MouseDelta.x < 10.0 && (double) this.MouseDelta.x > -10.0)
          this.Selected = 1;
        if ((double) Input.GetAxis("Vertical") < 0.5 && (double) Input.GetAxis("Vertical") > -0.5 && (double) Input.GetAxis("Horizontal") > 0.5 || (double) this.MouseDelta.y < 10.0 && (double) this.MouseDelta.y > -10.0 && (double) this.MouseDelta.x > 10.0)
          this.Selected = 2;
        if ((double) Input.GetAxis("Vertical") < -0.5 && (double) Input.GetAxis("Horizontal") < 0.5 && (double) Input.GetAxis("Horizontal") > -0.5 || (double) this.MouseDelta.y < -10.0 && (double) this.MouseDelta.x < 10.0 && (double) this.MouseDelta.x > -10.0)
          this.Selected = 3;
        if ((double) Input.GetAxis("Vertical") < 0.5 && (double) Input.GetAxis("Vertical") > -0.5 && (double) Input.GetAxis("Horizontal") < -0.5 || (double) this.MouseDelta.y < 10.0 && (double) this.MouseDelta.y > -10.0 && (double) this.MouseDelta.x < -10.0)
          this.Selected = 4;
        if (this.Selected < this.FavorText.Length)
          this.CenterLabel.text = this.AskingFavor ? this.FavorText[this.Selected] : this.LoveText[this.Selected];
      }
      if (!this.ClubLeader)
      {
        for (int index = 1; index < 7; ++index)
        {
          Transform transform = this.Segment[index].transform;
          transform.localScale = Vector3.Lerp(transform.localScale, this.Selected == index ? new Vector3(1.3f, 1.3f, 1f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        }
      }
      else
      {
        for (int index = 1; index < 7; ++index)
        {
          Transform transform = this.ClubSegment[index].transform;
          transform.localScale = Vector3.Lerp(transform.localScale, this.Selected == index ? new Vector3(1.3f, 1.3f, 1f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        }
      }
      if (!this.Matchmaking)
      {
        for (int index = 1; index < 5; ++index)
        {
          Transform transform = this.FavorSegment[index].transform;
          transform.localScale = Vector3.Lerp(transform.localScale, this.Selected == index ? new Vector3(1.3f, 1.3f, 1f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        }
      }
      else
      {
        for (int index = 1; index < 5; ++index)
        {
          Transform transform = this.LoveSegment[index].transform;
          transform.localScale = Vector3.Lerp(transform.localScale, this.Selected == index ? new Vector3(1.3f, 1.3f, 1f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        }
      }
      if (Input.GetButtonDown("A"))
      {
        if (this.ClubLeader)
        {
          if (this.Selected != 0 && (double) this.ClubShadow[this.Selected].color.a == 0.0)
          {
            int num = 0;
            if (this.Yandere.TargetStudent.Sleuthing && this.Yandere.TargetStudent.Club == ClubType.Photography)
              num = 5;
            if (this.Selected == 1)
            {
              this.Impatience.fillAmount = 0.0f;
              this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubInfo;
              this.Yandere.TargetStudent.TalkTimer = 100f;
              this.Yandere.TargetStudent.ClubPhase = 1;
              this.Show = false;
            }
            else if (this.Selected == 2)
            {
              this.Impatience.fillAmount = 0.0f;
              this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
              this.Yandere.TargetStudent.TalkTimer = 100f;
              this.Show = false;
              this.ClubManager.CheckGrudge(this.Yandere.TargetStudent.Club);
              this.Yandere.TargetStudent.ClubPhase = !this.ClubManager.QuitClub[(int) this.Yandere.TargetStudent.Club] ? (this.Yandere.Club == ClubType.None ? (!this.ClubManager.ClubGrudge ? 1 : 6) : 5) : 4;
            }
            else if (this.Selected == 3)
            {
              this.Impatience.fillAmount = 0.0f;
              this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
              this.Yandere.TargetStudent.TalkTimer = 100f;
              this.Yandere.TargetStudent.ClubPhase = 1;
              this.Show = false;
            }
            else if (this.Selected == 4)
            {
              this.Impatience.fillAmount = 0.0f;
              this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubBye;
              this.Yandere.TargetStudent.TalkTimer = this.Yandere.Subtitle.ClubFarewellClips[(int) (this.Yandere.TargetStudent.Club + num)].length;
              this.Show = false;
              Debug.Log((object) "This club leader exchange is over.");
            }
            else if (this.Selected == 5)
            {
              this.Impatience.fillAmount = 0.0f;
              this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubActivity;
              this.Yandere.TargetStudent.TalkTimer = 100f;
              this.Yandere.TargetStudent.ClubPhase = (double) this.Clock.HourTime >= 17.0 ? ((double) this.Clock.HourTime <= 17.5 ? 1 : 5) : 4;
              this.Show = false;
            }
            else if (this.Selected == 6)
            {
              this.Impatience.fillAmount = 0.0f;
              this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubPractice;
              this.Yandere.TargetStudent.TalkTimer = 100f;
              this.Yandere.TargetStudent.ClubPhase = 1;
              this.Show = false;
            }
          }
        }
        else if (this.AskingFavor)
        {
          if (this.Selected != 0)
          {
            if (this.Selected < this.FavorShadow.Length && (Object) this.FavorShadow[this.Selected] != (Object) null && (double) this.FavorShadow[this.Selected].color.a == 0.0)
            {
              if (this.Selected == 1)
              {
                this.Impatience.fillAmount = 0.0f;
                this.Yandere.Interaction = YandereInteractionType.FollowMe;
                this.Yandere.TalkTimer = 3f;
                this.Show = false;
              }
              else if (this.Selected == 2)
              {
                this.Impatience.fillAmount = 0.0f;
                this.Yandere.Interaction = YandereInteractionType.GoAway;
                this.Yandere.TalkTimer = 3f;
                this.Show = false;
              }
              else if (this.Selected == 4)
              {
                this.PauseScreen.StudentInfoMenu.Distracting = true;
                this.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
                this.PauseScreen.StudentInfoMenu.Column = 0;
                this.PauseScreen.StudentInfoMenu.Row = 0;
                this.PauseScreen.StudentInfoMenu.UpdateHighlight();
                this.StartCoroutine(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
                this.PauseScreen.MainMenu.SetActive(false);
                this.PauseScreen.Panel.enabled = true;
                this.PauseScreen.Sideways = true;
                this.PauseScreen.Show = true;
                Time.timeScale = 0.0001f;
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[1].text = "Cancel";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
                this.Impatience.fillAmount = 0.0f;
                this.Yandere.Interaction = YandereInteractionType.DistractThem;
                this.Yandere.TalkTimer = 3f;
                this.Show = false;
              }
            }
            if (this.Selected == 3)
              this.AskingFavor = false;
          }
        }
        else if (this.Matchmaking)
        {
          if (this.Selected != 0)
          {
            if (this.Selected < this.LoveShadow.Length && (Object) this.LoveShadow[this.Selected] != (Object) null && (double) this.LoveShadow[this.Selected].color.a == 0.0)
            {
              if (this.Selected == 1)
              {
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[0].text = "Select";
                this.PromptBar.Label[4].text = "Change";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
                this.AppearanceWindow.gameObject.SetActive(true);
                this.AppearanceWindow.Show = true;
                this.Show = false;
              }
              else if (this.Selected == 2)
              {
                this.Impatience.fillAmount = 0.0f;
                this.Yandere.Interaction = YandereInteractionType.Court;
                this.Yandere.TalkTimer = 5f;
                this.Show = false;
              }
              else if (this.Selected == 4)
              {
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[1].text = "Exit";
                this.PromptBar.Label[4].text = "Change";
                this.PromptBar.Label[5].text = "Change";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
                this.AdviceWindow.UpdateText();
                this.AdviceWindow.gameObject.SetActive(true);
                Time.timeScale = 0.0001f;
                this.transform.localScale = Vector3.zero;
                this.Yandere.Subtitle.Label.text = "";
                this.Impatience.fillAmount = 0.0f;
                this.Show = false;
              }
            }
            if (this.Selected == 3)
              this.Matchmaking = false;
          }
        }
        else if (this.Selected != 0 && (double) this.Shadow[this.Selected].color.a == 0.0)
        {
          if (this.Selected == 1)
          {
            this.Impatience.fillAmount = 0.0f;
            this.Yandere.Interaction = YandereInteractionType.Apologizing;
            this.Yandere.TalkTimer = 10f;
            this.Show = false;
          }
          else if (this.Selected == 2)
          {
            Time.timeScale = 0.0001f;
            this.TopicInterface.Socializing = true;
            this.TopicInterface.StudentID = this.Yandere.TargetStudent.StudentID;
            this.TopicInterface.Student = this.Yandere.TargetStudent;
            this.TopicInterface.UpdateOpinions();
            this.TopicInterface.UpdateTopicHighlight();
            this.TopicInterface.gameObject.SetActive(true);
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Speak";
            this.PromptBar.Label[1].text = "Back";
            this.PromptBar.Label[2].text = "Positive/Negative";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
            this.transform.localScale = Vector3.zero;
            this.Impatience.fillAmount = 0.0f;
            this.Show = false;
          }
          else if (this.Selected == 3)
          {
            this.PauseScreen.StudentInfoMenu.Gossiping = true;
            this.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
            this.PauseScreen.StudentInfoMenu.Column = 0;
            this.PauseScreen.StudentInfoMenu.Row = 0;
            this.PauseScreen.StudentInfoMenu.UpdateHighlight();
            this.StartCoroutine(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
            this.PauseScreen.MainMenu.SetActive(false);
            this.PauseScreen.Panel.enabled = true;
            this.PauseScreen.Sideways = true;
            this.PauseScreen.Show = true;
            Time.timeScale = 0.0001f;
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = string.Empty;
            this.PromptBar.Label[1].text = "Cancel";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
            this.Yandere.Subtitle.Label.text = "";
            this.transform.localScale = Vector3.zero;
            this.Impatience.fillAmount = 0.0f;
            this.Show = false;
          }
          else if (this.Selected == 4)
          {
            this.Impatience.fillAmount = 0.0f;
            this.Yandere.Interaction = YandereInteractionType.Bye;
            this.Yandere.TalkTimer = 2f;
            this.Show = false;
          }
          else if (this.Selected == 5)
          {
            if (!this.Yandere.TargetStudent.Friend)
            {
              this.CheckTaskCompletion();
              this.Show = false;
              if (this.Yandere.TargetStudent.TaskPhase == 0)
              {
                bool flag = true;
                if (!this.Yandere.StudentManager.Eighties && this.Yandere.TargetStudent.StudentID == 36 && this.Clock.Period > 1)
                {
                  this.Yandere.NotificationManager.CustomText = "Task only available in morning";
                  this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
                  flag = false;
                  this.Show = true;
                }
                if (flag)
                {
                  this.Impatience.fillAmount = 0.0f;
                  this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
                  this.Yandere.TargetStudent.TalkTimer = 100f;
                  this.Yandere.TargetStudent.TaskPhase = 1;
                }
              }
              else
              {
                this.Impatience.fillAmount = 0.0f;
                this.Yandere.TargetStudent.Interaction = StudentInteractionType.GivingTask;
                this.Yandere.TargetStudent.TalkTimer = 100f;
              }
            }
            else if (this.Yandere.LoveManager.SuitorProgress == 0)
            {
              this.PauseScreen.StudentInfoMenu.MatchMaking = true;
              this.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
              this.PauseScreen.StudentInfoMenu.Column = 0;
              this.PauseScreen.StudentInfoMenu.Row = 0;
              this.PauseScreen.StudentInfoMenu.UpdateHighlight();
              this.StartCoroutine(this.PauseScreen.StudentInfoMenu.UpdatePortraits());
              this.PauseScreen.MainMenu.SetActive(false);
              this.PauseScreen.Panel.enabled = true;
              this.PauseScreen.Sideways = true;
              this.PauseScreen.Show = true;
              Time.timeScale = 0.0001f;
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "View Info";
              this.PromptBar.Label[1].text = "Cancel";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
              this.Impatience.fillAmount = 0.0f;
              this.Yandere.Interaction = YandereInteractionType.NamingCrush;
              this.Yandere.TalkTimer = 3f;
              this.Show = false;
            }
            else
              this.Matchmaking = true;
          }
          else if (this.Selected == 6)
            this.AskingFavor = true;
        }
      }
      else if (Input.GetButtonDown("X"))
      {
        if (this.TaskDialogueWindow.activeInHierarchy)
        {
          this.Impatience.fillAmount = 0.0f;
          this.Yandere.Interaction = YandereInteractionType.TaskInquiry;
          this.Yandere.TalkTimer = 3f;
          this.Show = false;
        }
        else if (this.SwitchTopicsWindow.activeInHierarchy)
        {
          this.ClubLeader = !this.ClubLeader;
          if (!this.ClubLeader)
            this.RestoreMusic();
          this.HideShadows();
        }
      }
      else if (Input.GetButtonDown("B") && this.LockerWindow.activeInHierarchy)
      {
        this.Impatience.fillAmount = 0.0f;
        this.Yandere.Interaction = YandereInteractionType.SendingToLocker;
        this.Yandere.TalkTimer = 5f;
        this.Show = false;
        if (this.Yandere.TargetStudent.StudentID == 11 && SchemeGlobals.GetSchemeStage(6) == 6)
        {
          SchemeGlobals.SetSchemeStage(6, 7);
          this.Yandere.PauseScreen.Schemes.UpdateInstructions();
        }
      }
    }
    this.PreviousPosition = Input.mousePosition;
  }

  public void HideShadows()
  {
    this.Jukebox.Dip = 0.5f;
    int num1 = this.ClubLeader ? 1 : 0;
    this.TaskDialogueWindow.SetActive(false);
    this.ClubLeaderWindow.SetActive(false);
    this.LockerWindow.SetActive(false);
    if (this.ClubLeader && !this.Yandere.TargetStudent.Talk.Fake)
      this.SwitchTopicsWindow.SetActive(true);
    else
      this.SwitchTopicsWindow.SetActive(false);
    if (this.Yandere.TargetStudent.Armband.activeInHierarchy && !this.ClubLeader && this.Yandere.TargetStudent.Club != ClubType.Council)
      this.ClubLeaderWindow.SetActive(true);
    if (this.Yandere.TargetStudent.Indoors && this.NoteLocker.NoteLeft && (Object) this.NoteLocker.Student == (Object) this.Yandere.TargetStudent)
      this.LockerWindow.SetActive(true);
    if (this.Yandere.TargetStudent.Club == ClubType.Bully && this.TaskManager.TaskStatus[36] == 1)
      this.TaskDialogueWindow.SetActive(true);
    if (!this.Yandere.StudentManager.Eighties && this.Yandere.TargetStudent.StudentID == 10 && this.TaskManager.TaskStatus[46] == 1 && this.Clock.Period != 3 && this.Clock.Period != 5)
      this.TaskDialogueWindow.SetActive(true);
    this.TaskIcon.spriteName = this.Yandere.TargetStudent.Friend ? "Heart" : "Task";
    this.Impatience.fillAmount = 0.0f;
    for (int index = 1; index < 7; ++index)
    {
      UISprite uiSprite = this.Shadow[index];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.0f);
    }
    for (int index = 1; index < 5; ++index)
    {
      UISprite uiSprite = this.FavorShadow[index];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.0f);
    }
    for (int index = 1; index < 7; ++index)
    {
      UISprite uiSprite = this.ClubShadow[index];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.0f);
    }
    for (int index = 1; index < 5; ++index)
    {
      UISprite uiSprite = this.LoveShadow[index];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.0f);
    }
    if (!this.Yandere.TargetStudent.Witness || this.Yandere.TargetStudent.Forgave || this.Yandere.TargetStudent.Club == ClubType.Council)
    {
      UISprite uiSprite = this.Shadow[1];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
    if (this.Yandere.TargetStudent.Complimented || this.Yandere.TargetStudent.Club == ClubType.Council)
    {
      UISprite uiSprite = this.Shadow[2];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
    if (this.Yandere.TargetStudent.Gossiped || this.Yandere.TargetStudent.Club == ClubType.Council)
    {
      UISprite uiSprite = this.Shadow[3];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
    if ((double) this.Yandere.Bloodiness > 0.0 || (double) this.Yandere.Sanity < 33.3333282470703 || this.Yandere.TargetStudent.Club == ClubType.Council)
    {
      UISprite uiSprite1 = this.Shadow[3];
      uiSprite1.color = new Color(uiSprite1.color.r, uiSprite1.color.g, uiSprite1.color.b, 0.75f);
      this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
      UISprite uiSprite2 = this.Shadow[6];
      uiSprite2.color = new Color(uiSprite2.color.r, uiSprite2.color.g, uiSprite2.color.b, 0.75f);
    }
    else if ((double) this.Reputation.Reputation < -33.3333282470703)
    {
      UISprite uiSprite = this.Shadow[3];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
    if (!this.Yandere.TargetStudent.Indoors || this.Yandere.TargetStudent.Club == ClubType.Council)
      this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
    else if (!this.Yandere.TargetStudent.Friend)
    {
      bool flag = false;
      if (this.Yandere.StudentManager.Eighties)
      {
        if (this.Yandere.TargetStudent.StudentID != 79)
          flag = true;
        if (flag && this.TaskManager.TaskStatus[this.Yandere.TargetStudent.StudentID] == 1 && this.Yandere.Inventory.FinishedHomework)
          this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      }
      else
      {
        if (this.Yandere.TargetStudent.StudentID != 8 && this.Yandere.TargetStudent.StudentID != 11 && this.Yandere.TargetStudent.StudentID != 25 && this.Yandere.TargetStudent.StudentID != 28 && this.Yandere.TargetStudent.StudentID != 30 && this.Yandere.TargetStudent.StudentID != 36 && this.Yandere.TargetStudent.StudentID != 37 && this.Yandere.TargetStudent.StudentID != 38 && this.Yandere.TargetStudent.StudentID != 52 && this.Yandere.TargetStudent.StudentID != 76 && this.Yandere.TargetStudent.StudentID != 77 && this.Yandere.TargetStudent.StudentID != 78 && this.Yandere.TargetStudent.StudentID != 79 && this.Yandere.TargetStudent.StudentID != 80 && this.Yandere.TargetStudent.StudentID != 81)
          flag = true;
        if (this.Yandere.TargetStudent.StudentID == 6)
        {
          Debug.Log((object) "Speaking to Osana's suitor.");
          flag = false;
        }
        if (this.Yandere.TargetStudent.StudentID == 1 || this.Yandere.TargetStudent.StudentID == 10 || this.Yandere.TargetStudent.StudentID == 41)
        {
          this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
        }
        else
        {
          this.TaskManager.UpdateTaskStatus();
          if (this.Yandere.TargetStudent.TaskPhase > 0 && this.Yandere.TargetStudent.TaskPhase < 5 || this.TaskManager.TaskStatus[this.Yandere.TargetStudent.StudentID] > 0 && this.TaskManager.TaskStatus[this.Yandere.TargetStudent.StudentID] < 5 && this.TaskManager.TaskStatus[this.Yandere.TargetStudent.StudentID] != 2 || this.Yandere.TargetStudent.TaskPhase == 100)
          {
            Debug.Log((object) "Hiding task button.");
            this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
          }
          if (this.Yandere.TargetStudent.TaskPhase == 5)
            this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
          if (this.Yandere.TargetStudent.StudentID == 6)
          {
            if ((Object) this.Yandere.StudentManager.Students[11] == (Object) null)
            {
              Debug.Log((object) "Osana's dead; hiding suitor's Task button.");
              this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
            }
            else
            {
              Debug.Log((object) ("The status of Task #6 is:" + this.TaskManager.TaskStatus[6].ToString()));
              if (this.TaskManager.TaskStatus[6] == 1 && this.Yandere.Inventory.Headset)
              {
                this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                Debug.Log((object) "Player has a headset.");
              }
            }
          }
          else if (this.Yandere.TargetStudent.StudentID == 36)
          {
            if (this.TaskManager.TaskStatus[36] == 0 && (StudentGlobals.GetStudentDead(81) || StudentGlobals.GetStudentDead(82) || StudentGlobals.GetStudentDead(83) || StudentGlobals.GetStudentDead(84) || StudentGlobals.GetStudentDead(85)))
              this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
          }
          else if (this.Yandere.TargetStudent.StudentID == 46 && this.Clock.Period == 3 || this.Yandere.TargetStudent.StudentID == 46 && this.Clock.Period == 5)
          {
            Debug.Log((object) "Hiding Budo's Task button.");
            this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
          }
          else if (this.Yandere.TargetStudent.StudentID == 81)
          {
            if (this.TaskManager.TaskStatus[81] == 0 && StudentGlobals.GetStudentDead(5))
              this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
          }
          else if (this.Yandere.TargetStudent.StudentID == 76)
          {
            if (this.TaskManager.TaskStatus[76] == 1 && (double) this.Yandere.Inventory.Money >= 100.0)
            {
              this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
              Debug.Log((object) "Player has over $100.");
            }
          }
          else if (this.Yandere.TargetStudent.StudentID == 77)
          {
            if (this.TaskManager.TaskStatus[77] == 1 && ((Object) this.Yandere.Weapon[1] != (Object) null && this.Yandere.Weapon[1].WeaponID == 1 && !this.Yandere.Weapon[1].Bloody || (Object) this.Yandere.Weapon[1] != (Object) null && this.Yandere.Weapon[1].WeaponID == 8 && !this.Yandere.Weapon[1].Bloody || (Object) this.Yandere.Weapon[2] != (Object) null && this.Yandere.Weapon[2].WeaponID == 1 && !this.Yandere.Weapon[2].Bloody || (Object) this.Yandere.Weapon[2] != (Object) null && this.Yandere.Weapon[2].WeaponID == 8 && !this.Yandere.Weapon[2].Bloody))
            {
              this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
              Debug.Log((object) "Player has a knife.");
            }
          }
          else if (this.Yandere.TargetStudent.StudentID == 78)
          {
            if (this.TaskManager.TaskStatus[78] == 1 && this.Yandere.Inventory.Sake)
            {
              this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
              Debug.Log((object) "Player has sake.");
            }
          }
          else if (this.Yandere.TargetStudent.StudentID == 79)
          {
            if (this.TaskManager.TaskStatus[79] == 1 && this.Yandere.Inventory.Cigs)
            {
              this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
              Debug.Log((object) "Player has ciggies.");
            }
          }
          else if (this.Yandere.TargetStudent.StudentID == 80 && this.TaskManager.TaskStatus[80] == 1 && (this.Yandere.Inventory.AnswerSheet || this.Yandere.Inventory.DuplicateSheet))
          {
            this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Debug.Log((object) "Player has the answer sheet.");
          }
        }
        if (flag && this.TaskManager.TaskStatus[this.Yandere.TargetStudent.StudentID] == 1 && this.Yandere.Inventory.Book)
        {
          this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
          Debug.Log((object) "The player has a library book.");
        }
      }
    }
    else if (this.Yandere.TargetStudent.StudentID != this.LoveManager.RivalID && this.Yandere.TargetStudent.StudentID != this.LoveManager.SuitorID)
      this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
    else if (!this.Yandere.TargetStudent.Male && this.LoveManager.SuitorProgress == 0)
      this.Shadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
    if (!this.Yandere.TargetStudent.Indoors || this.Yandere.TargetStudent.Club == ClubType.Council)
    {
      UISprite uiSprite = this.Shadow[6];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
    else
    {
      if (!this.Yandere.TargetStudent.Friend)
        this.Shadow[6].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
      if (this.Yandere.TargetStudent.Male && this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 3 || this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 4 || this.Yandere.Club == ClubType.Delinquent)
        this.Shadow[6].color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      if (this.Yandere.TargetStudent.Club == ClubType.Delinquent)
        this.Shadow[6].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
      int currentAction = (int) this.Yandere.TargetStudent.CurrentAction;
    }
    if (this.Yandere.Club == this.Yandere.TargetStudent.Club)
    {
      UISprite uiSprite3 = this.ClubShadow[1];
      uiSprite3.color = new Color(uiSprite3.color.r, uiSprite3.color.g, uiSprite3.color.b, 0.75f);
      UISprite uiSprite4 = this.ClubShadow[2];
      uiSprite4.color = new Color(uiSprite4.color.r, uiSprite4.color.g, uiSprite4.color.b, 0.75f);
    }
    if (this.Yandere.ClubAttire || (Object) this.Yandere.Mask != (Object) null || (Object) this.Yandere.Gloves != (Object) null || (Object) this.Yandere.Container != (Object) null && this.Yandere.Container.CelloCase)
    {
      UISprite uiSprite = this.ClubShadow[3];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
    if (this.Yandere.Club != this.Yandere.TargetStudent.Club)
    {
      UISprite uiSprite5 = this.ClubShadow[2];
      uiSprite5.color = new Color(uiSprite5.color.r, uiSprite5.color.g, uiSprite5.color.b, 0.0f);
      UISprite uiSprite6 = this.ClubShadow[3];
      uiSprite6.color = new Color(uiSprite6.color.r, uiSprite6.color.g, uiSprite6.color.b, 0.75f);
      this.ClubShadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
    }
    if (this.Yandere.StudentManager.MurderTakingPlace)
      this.ClubShadow[5].color = new Color(0.0f, 0.0f, 0.0f, 0.75f);
    if (this.Yandere.TargetStudent.StudentID != 46 && this.Yandere.TargetStudent.StudentID != 51 && this.Yandere.TargetStudent.StudentID != 76 || this.Yandere.Police.Show || this.Clock.Period == 3 || this.Clock.Period == 5)
    {
      UISprite uiSprite = this.ClubShadow[6];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
    if (this.Yandere.TargetStudent.StudentID == 51 || this.Yandere.TargetStudent.StudentID == 76)
    {
      int num2 = 4;
      if (this.Yandere.TargetStudent.StudentID == 51 && (this.Yandere.Club != ClubType.LightMusic || this.PracticeWindow.PlayedRhythmMinigame))
        num2 = 0;
      for (int index = this.Yandere.TargetStudent.StudentID + 1; index < this.Yandere.TargetStudent.StudentID + 5; ++index)
      {
        if ((Object) this.Yandere.StudentManager.Students[index] == (Object) null)
          --num2;
        else if (!this.Yandere.StudentManager.Students[index].gameObject.activeInHierarchy || this.Yandere.StudentManager.Students[index].Investigating || this.Yandere.StudentManager.Students[index].Distracting || this.Yandere.StudentManager.Students[index].Distracted || this.Yandere.StudentManager.Students[index].SentHome || this.Yandere.StudentManager.Students[index].Tranquil || this.Yandere.StudentManager.Students[index].GoAway || !this.Yandere.StudentManager.Students[index].Routine || !this.Yandere.StudentManager.Students[index].Alive)
          --num2;
      }
      if (num2 < 4)
      {
        UISprite uiSprite = this.ClubShadow[6];
        uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
      }
    }
    if (this.Yandere.Followers > 0)
    {
      Debug.Log((object) "Can't do task because of follower.");
      UISprite uiSprite = this.FavorShadow[1];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
    if ((double) this.Yandere.TargetStudent.DistanceToDestination > 2.0)
    {
      UISprite uiSprite = this.FavorShadow[2];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
    if (!this.Yandere.TargetStudent.Male)
    {
      UISprite uiSprite = this.LoveShadow[1];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
    if ((Object) this.DatingMinigame == (Object) null || this.Yandere.TargetStudent.Male && !this.LoveManager.RivalWaiting || this.LoveManager.Courted)
    {
      UISprite uiSprite = this.LoveShadow[2];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
    if (!this.Yandere.StudentManager.Eighties || this.Yandere.TargetStudent.StudentID != this.Yandere.StudentManager.SuitorID)
    {
      UISprite uiSprite = this.LoveShadow[4];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
    if (!this.Yandere.StudentManager.TutorialActive)
      return;
    for (int index = 2; index < 7; ++index)
    {
      UISprite uiSprite = this.Shadow[index];
      uiSprite.color = new Color(uiSprite.color.r, uiSprite.color.g, uiSprite.color.b, 0.75f);
    }
  }

  private void CheckTaskCompletion()
  {
    bool flag = false;
    if (this.Yandere.StudentManager.Eighties)
    {
      if (this.Yandere.TargetStudent.StudentID != 79)
        flag = true;
    }
    else
    {
      if (this.Yandere.TargetStudent.StudentID == 6 && this.TaskManager.TaskStatus[6] == 1)
      {
        if (this.Yandere.Inventory.Headset)
        {
          this.Yandere.TargetStudent.TaskPhase = 5;
          this.Yandere.LoveManager.SuitorProgress = 1;
          DatingGlobals.SuitorProgress = 1;
        }
      }
      else if (this.Yandere.TargetStudent.StudentID == 36 && this.TaskManager.TaskStatus[36] == 1)
      {
        this.Yandere.TargetStudent.UpdateAppearance = true;
        ScheduleBlock scheduleBlock = this.Yandere.TargetStudent.ScheduleBlocks[this.Yandere.TargetStudent.Phase];
        scheduleBlock.destination = "LockerRoom";
        scheduleBlock.action = "UpdateAppearance";
        this.Yandere.TargetStudent.GetDestinations();
        this.Yandere.TargetStudent.TaskPhase = 5;
      }
      else if (this.Yandere.TargetStudent.StudentID == 11 && this.TaskManager.TaskStatus[11] == 2)
      {
        Debug.Log((object) "Setting Osana's phone charm active.");
        this.Yandere.TargetStudent.Cosmetic.PhoneCharms[11].SetActive(true);
      }
      else if (this.Yandere.TargetStudent.StudentID == 76 && this.TaskManager.TaskStatus[76] == 1)
      {
        this.Yandere.TargetStudent.RespectEarned = true;
        this.Yandere.TargetStudent.TaskPhase = 5;
        this.Yandere.Inventory.Money -= 100f;
        this.Yandere.Inventory.UpdateMoney();
      }
      else if (this.Yandere.TargetStudent.StudentID == 77 && this.TaskManager.TaskStatus[77] == 1)
      {
        this.Yandere.TargetStudent.RespectEarned = true;
        this.Yandere.TargetStudent.TaskPhase = 5;
        WeaponScript weaponScript;
        if ((Object) this.Yandere.Weapon[1] != (Object) null && this.Yandere.Weapon[1].WeaponID == 1 || (Object) this.Yandere.Weapon[1] != (Object) null && this.Yandere.Weapon[1].WeaponID == 8)
        {
          weaponScript = this.Yandere.Weapon[1];
          this.Yandere.Weapon[1] = (WeaponScript) null;
        }
        else
        {
          weaponScript = this.Yandere.Weapon[2];
          this.Yandere.Weapon[2] = (WeaponScript) null;
        }
        weaponScript.Drop();
        weaponScript.FingerprintID = 77;
        weaponScript.gameObject.SetActive(false);
        this.Yandere.WeaponManager.UpdateLabels();
        this.Yandere.WeaponMenu.UpdateSprites();
      }
      else if (this.Yandere.TargetStudent.StudentID == 78 && this.TaskManager.TaskStatus[78] == 1)
      {
        this.Yandere.TargetStudent.RespectEarned = true;
        this.Yandere.TargetStudent.TaskPhase = 5;
        this.Yandere.Inventory.Sake = false;
      }
      else if (this.Yandere.TargetStudent.StudentID == 79 && this.TaskManager.TaskStatus[79] == 1)
      {
        this.Yandere.TargetStudent.RespectEarned = true;
        this.Yandere.TargetStudent.TaskPhase = 5;
        this.Yandere.Inventory.Cigs = false;
      }
      else if (this.Yandere.TargetStudent.StudentID == 80 && this.TaskManager.TaskStatus[80] == 1)
      {
        this.Yandere.TargetStudent.RespectEarned = true;
        this.Yandere.TargetStudent.TaskPhase = 5;
        this.Yandere.Inventory.AnswerSheet = false;
      }
      if (this.Yandere.TargetStudent.StudentID != 8 && this.Yandere.TargetStudent.StudentID != 11 && this.Yandere.TargetStudent.StudentID != 25 && this.Yandere.TargetStudent.StudentID != 28 && this.Yandere.TargetStudent.StudentID != 30 && this.Yandere.TargetStudent.StudentID != 36 && this.Yandere.TargetStudent.StudentID != 37 && this.Yandere.TargetStudent.StudentID != 38 && this.Yandere.TargetStudent.StudentID != 47 && this.Yandere.TargetStudent.StudentID != 48 && this.Yandere.TargetStudent.StudentID != 49 && this.Yandere.TargetStudent.StudentID != 50 && this.Yandere.TargetStudent.StudentID != 52 && this.Yandere.TargetStudent.StudentID != 76 && this.Yandere.TargetStudent.StudentID != 77 && this.Yandere.TargetStudent.StudentID != 78 && this.Yandere.TargetStudent.StudentID != 79 && this.Yandere.TargetStudent.StudentID != 80 && this.Yandere.TargetStudent.StudentID != 81)
        flag = true;
    }
    if (flag && this.TaskManager.TaskStatus[this.Yandere.TargetStudent.StudentID] == 1 && (!this.Yandere.StudentManager.Eighties && this.Yandere.Inventory.Book || this.Yandere.StudentManager.Eighties && this.Yandere.Inventory.FinishedHomework))
      this.Yandere.TargetStudent.TaskPhase = 5;
    if (this.Yandere.Club == ClubType.Delinquent)
      this.Text[6] = "Intimidate";
    else
      this.Text[6] = "Ask Favor";
  }

  public void End()
  {
    Debug.Log((object) "The DialogueWheel is calling End() now.");
    if ((Object) this.Yandere.TargetStudent != (Object) null)
    {
      Debug.Log((object) "TargetStudent was not null.");
      if (this.Yandere.TargetStudent.Pestered >= 10)
        this.Yandere.TargetStudent.Ignoring = true;
      if (!this.Pestered)
        this.Yandere.Subtitle.Label.text = string.Empty;
      this.Yandere.TargetStudent.Interaction = StudentInteractionType.Idle;
      this.Yandere.TargetStudent.WaitTimer = 1f;
      if (this.Yandere.TargetStudent.enabled)
      {
        Debug.Log((object) (this.Yandere.TargetStudent.Name + " has just been released from the DialogueWheel."));
        this.Yandere.TargetStudent.CurrentDestination = this.Yandere.TargetStudent.Destinations[this.Yandere.TargetStudent.Phase];
        this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.TargetStudent.Destinations[this.Yandere.TargetStudent.Phase];
        if (this.Yandere.TargetStudent.Actions[this.Yandere.TargetStudent.Phase] == StudentActionType.Clean)
          this.Yandere.TargetStudent.EquipCleaningItems();
        else if (this.Yandere.TargetStudent.Actions[this.Yandere.TargetStudent.Phase] == StudentActionType.Patrol || this.Yandere.TargetStudent.Actions[this.Yandere.TargetStudent.Phase] == StudentActionType.ClubAction && this.Yandere.TargetStudent.Club == ClubType.Gardening)
        {
          this.Yandere.TargetStudent.CurrentDestination = this.Yandere.TargetStudent.StudentManager.Patrols.List[this.Yandere.TargetStudent.StudentID].GetChild(this.Yandere.TargetStudent.PatrolID);
          this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.TargetStudent.CurrentDestination;
        }
        else if (this.Yandere.TargetStudent.Actions[this.Yandere.TargetStudent.Phase] == StudentActionType.Sleuth)
        {
          this.Yandere.TargetStudent.CurrentDestination = this.Yandere.TargetStudent.SleuthTarget;
          this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.TargetStudent.SleuthTarget;
        }
        else if (this.Yandere.TargetStudent.Actions[this.Yandere.TargetStudent.Phase] == StudentActionType.Sunbathe && this.Yandere.TargetStudent.SunbathePhase > 1)
        {
          this.Yandere.TargetStudent.CurrentDestination = this.Yandere.StudentManager.SunbatheSpots[this.Yandere.TargetStudent.StudentID];
          this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.StudentManager.SunbatheSpots[this.Yandere.TargetStudent.StudentID];
        }
      }
      if (this.Yandere.TargetStudent.Persona == PersonaType.PhoneAddict)
      {
        bool flag = false;
        if (this.Yandere.TargetStudent.CurrentAction == StudentActionType.Sunbathe && this.Yandere.TargetStudent.SunbathePhase > 2)
          flag = true;
        if (!this.Yandere.TargetStudent.Scrubber.activeInHierarchy && !flag && !this.Yandere.TargetStudent.Phoneless)
        {
          this.Yandere.TargetStudent.SmartPhone.SetActive(true);
          this.Yandere.TargetStudent.WalkAnim = this.Yandere.TargetStudent.PhoneAnims[1];
        }
        else
          this.Yandere.TargetStudent.SmartPhone.SetActive(false);
      }
      if (this.Yandere.TargetStudent.LostTeacherTrust)
      {
        this.Yandere.TargetStudent.WalkAnim = this.Yandere.TargetStudent.BulliedWalkAnim;
        this.Yandere.TargetStudent.SmartPhone.SetActive(false);
      }
      if (this.Yandere.TargetStudent.EatingSnack)
      {
        this.Yandere.TargetStudent.Scrubber.SetActive(false);
        this.Yandere.TargetStudent.Eraser.SetActive(false);
      }
      if (this.Yandere.TargetStudent.SentToLocker)
      {
        this.Yandere.TargetStudent.CurrentDestination = this.Yandere.TargetStudent.MyLocker;
        this.Yandere.TargetStudent.Pathfinding.target = this.Yandere.TargetStudent.MyLocker;
      }
      if (this.Yandere.TargetStudent.StudentID == 10 && (Object) this.Yandere.TargetStudent.FollowTarget != (Object) null && this.Yandere.TargetStudent.FollowTarget.FocusOnYandere)
      {
        Debug.Log((object) "Osana was stopped, but she should continue walking now.");
        this.Yandere.TargetStudent.FollowTarget.Pathfinding.canSearch = true;
        this.Yandere.TargetStudent.FollowTarget.Pathfinding.canMove = true;
        this.Yandere.TargetStudent.FollowTarget.FocusOnYandere = false;
        this.Yandere.TargetStudent.FollowTarget.Routine = true;
      }
      this.Yandere.TargetStudent.Talk.NegativeResponse = false;
      this.Yandere.ShoulderCamera.OverShoulder = false;
      this.Yandere.TargetStudent.DiscCheck = false;
      this.Yandere.TargetStudent.Waiting = true;
      this.Yandere.TargetStudent = (StudentScript) null;
    }
    this.Yandere.Interaction = YandereInteractionType.Idle;
    this.Yandere.CameraEffects.UpdateDOF(2f);
    this.Yandere.StudentManager.VolumeUp();
    this.RestoreMusic();
    this.Jukebox.Dip = 1f;
    this.AppearanceWindow.gameObject.SetActive(false);
    this.AppearanceWindow.Show = false;
    this.AskingFavor = false;
    this.Matchmaking = false;
    this.ClubLeader = false;
    this.Pestered = false;
    this.Show = false;
    this.PromptBar.ClearButtons();
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = false;
  }

  private void RestoreMusic() => this.Jukebox.ClubTheme.Stop();
}
