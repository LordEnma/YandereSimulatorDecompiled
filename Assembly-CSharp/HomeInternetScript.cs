// Decompiled with JetBrains decompiler
// Type: HomeInternetScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Globalization;
using UnityEngine;

public class HomeInternetScript : MonoBehaviour
{
  public StudentInfoMenuScript StudentInfoMenu;
  public InputManagerScript InputManager;
  public PauseScreenScript PauseScreen;
  public PromptBarScript PromptBar;
  public HomeClockScript Clock;
  public HomeYandereScript HomeYandere;
  public HomeCameraScript HomeCamera;
  public HomeWindowScript HomeWindow;
  public UILabel YanderePostLabel;
  public UILabel YancordLabel;
  public UILabel AcceptLabel;
  public UITexture YancordLogo;
  public GameObject InternetPrompts;
  public GameObject NavigationMenu;
  public GameObject OnlineShopping;
  public GameObject SocialMedia;
  public GameObject NewPostText;
  public GameObject ChangeLabel;
  public GameObject ChangeIcon;
  public GameObject WriteLabel;
  public GameObject WriteIcon;
  public GameObject PostLabel;
  public GameObject PostIcon;
  public GameObject BG;
  public Transform MenuHighlight;
  public Transform StudentPost1;
  public Transform StudentPost2;
  public Transform YandereReply;
  public Transform YanderePost;
  public Transform LameReply;
  public Transform NewPost;
  public Transform Menu;
  public Transform[] StudentReplies;
  public UISprite[] Highlights;
  public UILabel[] PostLabels;
  public UILabel[] MenuLabels;
  public string[] Locations;
  public string[] Actions;
  public bool PostSequence;
  public bool WritingPost;
  public bool ShowMenu;
  public bool FadeOut;
  public bool Success;
  public bool Posted;
  public int MenuSelected = 1;
  public int Selected = 1;
  public int ID = 1;
  public int Location;
  public int Student;
  public int Action;
  public float Timer;
  public UITexture StudentPost1Portrait;
  public UITexture StudentPost2Portrait;
  public UITexture LamePostPortrait;
  public Texture CurrentPortrait;
  public UITexture[] Portraits;
  public int Height;
  public Transform Highlight;
  public Transform ItemList;
  public GameObject AreYouSure;
  public AudioSource MyAudio;
  public UILabel MoneyLabel;
  public float Shake;

  private void Awake()
  {
    this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, -180f, this.StudentPost1.localPosition.z);
    this.StudentPost2.localPosition = new Vector3(this.StudentPost2.localPosition.x, -365f, this.StudentPost2.localPosition.z);
    this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, -88f, this.YandereReply.localPosition.z);
    this.YanderePost.localPosition = new Vector3(this.YanderePost.localPosition.x, -2f, this.YanderePost.localPosition.z);
    for (int index = 1; index < 6; ++index)
    {
      Transform studentReply = this.StudentReplies[index];
      studentReply.localPosition = new Vector3(studentReply.localPosition.x, -40f, studentReply.localPosition.z);
    }
    this.LameReply.localPosition = new Vector3(this.LameReply.localPosition.x, -40f, this.LameReply.localPosition.z);
    this.PostLabels[1].text = "";
    this.PostLabels[2].text = "";
    this.PostLabels[3].text = "";
    this.Highlights[1].enabled = false;
    this.Highlights[2].enabled = false;
    this.Highlights[3].enabled = false;
    this.YanderePost.gameObject.SetActive(false);
    this.NavigationMenu.SetActive(true);
    this.ChangeLabel.SetActive(false);
    this.ChangeIcon.SetActive(false);
    this.PostLabel.SetActive(false);
    this.PostIcon.SetActive(false);
    this.OnlineShopping.SetActive(false);
    this.NewPostText.SetActive(false);
    this.BG.SetActive(false);
    if (!SchemeGlobals.EmbarassingSecret || StudentGlobals.GetStudentExposed(11))
    {
      this.WriteLabel.SetActive(false);
      this.WriteIcon.SetActive(false);
    }
    this.GetPortrait(2);
    this.StudentPost1Portrait.mainTexture = this.CurrentPortrait;
    this.GetPortrait(39);
    this.StudentPost2Portrait.mainTexture = this.CurrentPortrait;
    this.GetPortrait(25);
    this.LamePostPortrait.mainTexture = this.CurrentPortrait;
    for (this.ID = 1; this.ID < 6; ++this.ID)
    {
      this.GetPortrait(86 - this.ID);
      this.Portraits[this.ID].mainTexture = this.CurrentPortrait;
    }
    if (DateGlobals.DayPassed)
      return;
    this.YancordLabel.color = new Color(1f, 1f, 1f, 0.2f);
    this.YancordLogo.color = new Color(1f, 1f, 1f, 0.2f);
  }

  private void Update()
  {
    if (this.HomeYandere.CanMove || this.PauseScreen.Show)
      return;
    if (this.NavigationMenu.activeInHierarchy && !this.HomeCamera.CyberstalkWindow.activeInHierarchy)
    {
      if (Input.GetButtonDown("A"))
      {
        this.NavigationMenu.SetActive(false);
        this.SocialMedia.SetActive(true);
      }
      else if (Input.GetButtonDown("X"))
      {
        if (!DateGlobals.DayPassed)
          return;
        this.HomeCamera.HomeDarkness.FadeOut = true;
      }
      else if (Input.GetButtonDown("Y"))
      {
        this.PauseScreen.MainMenu.SetActive(false);
        this.PauseScreen.Panel.enabled = true;
        this.PauseScreen.Sideways = true;
        this.PauseScreen.Show = true;
        this.StudentInfoMenu.gameObject.SetActive(true);
        this.StudentInfoMenu.CyberStalking = true;
        this.StartCoroutine(this.StudentInfoMenu.UpdatePortraits());
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "View Info";
        this.PromptBar.Label[1].text = "Back";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
      }
      else if (Input.GetButtonDown("LB"))
      {
        this.NavigationMenu.SetActive(false);
        this.OnlineShopping.SetActive(true);
        this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", (IFormatProvider) NumberFormatInfo.InvariantInfo);
      }
      else
      {
        if (!Input.GetButtonDown("B"))
          return;
        this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
        this.HomeCamera.Target = this.HomeCamera.Targets[0];
        this.HomeYandere.CanMove = true;
        this.HomeWindow.Show = false;
        this.enabled = false;
      }
    }
    else if (this.SocialMedia.activeInHierarchy)
    {
      this.Menu.localScale = Vector3.Lerp(this.Menu.localScale, this.ShowMenu ? new Vector3(2f, 2f, 2f) : Vector3.zero, Time.deltaTime * 10f);
      if (this.WritingPost)
      {
        this.NewPost.transform.localPosition = Vector3.Lerp(this.NewPost.transform.localPosition, Vector3.zero, Time.deltaTime * 10f);
        this.NewPost.transform.localScale = Vector3.Lerp(this.NewPost.transform.localScale, new Vector3(2.43f, 2.43f, 2.43f), Time.deltaTime * 10f);
        for (int index = 1; index < this.Highlights.Length; ++index)
        {
          UISprite highlight = this.Highlights[index];
          highlight.color = new Color(highlight.color.r, highlight.color.g, highlight.color.b, Mathf.MoveTowards(highlight.color.a, this.FadeOut ? 0.0f : 1f, Time.deltaTime));
        }
        if ((double) this.Highlights[this.Selected].color.a == 1.0)
          this.FadeOut = true;
        else if ((double) this.Highlights[this.Selected].color.a == 0.0)
          this.FadeOut = false;
        if (!this.ShowMenu)
        {
          if (this.InputManager.TappedRight)
          {
            ++this.Selected;
            this.UpdateHighlight();
          }
          if (this.InputManager.TappedLeft)
          {
            --this.Selected;
            this.UpdateHighlight();
          }
        }
        else
        {
          if (this.InputManager.TappedDown)
          {
            ++this.MenuSelected;
            this.UpdateMenuHighlight();
          }
          if (this.InputManager.TappedUp)
          {
            --this.MenuSelected;
            this.UpdateMenuHighlight();
          }
        }
      }
      else
      {
        this.NewPost.transform.localPosition = Vector3.Lerp(this.NewPost.transform.localPosition, new Vector3(175f, -10f, 0.0f), Time.deltaTime * 10f);
        this.NewPost.transform.localScale = Vector3.Lerp(this.NewPost.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      }
      if (!this.PostSequence)
      {
        if (Input.GetButtonDown("A") && this.WriteIcon.activeInHierarchy && !this.Posted)
        {
          if (!this.ShowMenu)
          {
            if (!this.WritingPost)
            {
              this.AcceptLabel.text = "Select";
              this.ChangeLabel.SetActive(true);
              this.ChangeIcon.SetActive(true);
              this.NewPostText.SetActive(true);
              this.BG.SetActive(true);
              this.WritingPost = true;
              this.Selected = 1;
              this.UpdateHighlight();
            }
            else if (this.Selected == 1)
            {
              this.PauseScreen.MainMenu.SetActive(false);
              this.PauseScreen.Panel.enabled = true;
              this.PauseScreen.Sideways = true;
              this.PauseScreen.Show = true;
              this.StudentInfoMenu.gameObject.SetActive(true);
              this.StudentInfoMenu.CyberBullying = true;
              this.StartCoroutine(this.StudentInfoMenu.UpdatePortraits());
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "View Info";
              this.PromptBar.Label[1].text = "Back";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
            }
            else if (this.Selected == 2)
            {
              this.MenuSelected = 1;
              this.UpdateMenuHighlight();
              this.ShowMenu = true;
              for (int index = 1; index < this.MenuLabels.Length; ++index)
                this.MenuLabels[index].text = this.Locations[index];
            }
            else if (this.Selected == 3)
            {
              this.MenuSelected = 1;
              this.UpdateMenuHighlight();
              this.ShowMenu = true;
              for (int index = 1; index < this.MenuLabels.Length; ++index)
                this.MenuLabels[index].text = this.Actions[index];
            }
          }
          else
          {
            if (this.Selected == 2)
            {
              this.Location = this.MenuSelected;
              this.PostLabels[2].text = this.Locations[this.MenuSelected];
              this.ShowMenu = false;
            }
            else if (this.Selected == 3)
            {
              this.Action = this.MenuSelected;
              this.PostLabels[3].text = this.Actions[this.MenuSelected];
              this.ShowMenu = false;
            }
            this.CheckForCompletion();
          }
        }
        if (Input.GetButtonDown("B"))
        {
          if (!this.ShowMenu)
          {
            if (!this.WritingPost)
            {
              this.NavigationMenu.SetActive(true);
              this.SocialMedia.SetActive(false);
            }
            else
            {
              this.AcceptLabel.text = "Write";
              this.ChangeLabel.SetActive(false);
              this.ChangeIcon.SetActive(false);
              this.PostLabel.SetActive(false);
              this.PostIcon.SetActive(false);
              this.ExitPost();
            }
          }
          else
            this.ShowMenu = false;
        }
        if (Input.GetButtonDown("X") && this.PostIcon.activeInHierarchy)
        {
          this.YanderePostLabel.text = "Did you know that " + this.PostLabels[1].text + " used to " + this.PostLabels[2].text + " about " + this.PostLabels[3].text + "?";
          this.ExitPost();
          this.InternetPrompts.SetActive(false);
          this.ChangeLabel.SetActive(false);
          this.ChangeIcon.SetActive(false);
          this.WriteLabel.SetActive(false);
          this.WriteIcon.SetActive(false);
          this.PostLabel.SetActive(false);
          this.PostIcon.SetActive(false);
          this.PostSequence = true;
          this.Posted = true;
          if (this.Student == 11 && this.Location == 10 && this.Action == 10)
            this.Success = true;
        }
        if (Input.GetKeyDown("space"))
        {
          this.WriteLabel.SetActive(true);
          this.WriteIcon.SetActive(true);
        }
      }
      if (!this.PostSequence)
        return;
      if (Input.GetButtonDown("A"))
        this.Timer += 2f;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.0 && (double) this.Timer < 3.0)
      {
        this.YanderePost.gameObject.SetActive(true);
        this.YanderePost.transform.localPosition = new Vector3(this.YanderePost.transform.localPosition.x, Mathf.Lerp(this.YanderePost.transform.localPosition.y, -155f, Time.deltaTime * 10f), this.YanderePost.transform.localPosition.z);
        this.StudentPost1.transform.localPosition = new Vector3(this.StudentPost1.transform.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -365f, Time.deltaTime * 10f), this.StudentPost1.transform.localPosition.z);
        this.StudentPost2.transform.localPosition = new Vector3(this.StudentPost2.transform.localPosition.x, Mathf.Lerp(this.StudentPost2.transform.localPosition.y, -550f, Time.deltaTime * 10f), this.StudentPost2.transform.localPosition.z);
      }
      if (!this.Success)
      {
        if ((double) this.Timer > 3.0 && (double) this.Timer < 5.0)
        {
          this.LameReply.localPosition = new Vector3(this.LameReply.localPosition.x, Mathf.Lerp(this.LameReply.transform.localPosition.y, -88f, Time.deltaTime * 10f), this.LameReply.localPosition.z);
          this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -137f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
          this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -415f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
        }
        if ((double) this.Timer <= 5.0)
          return;
        PlayerGlobals.Reputation -= 5f;
        this.InternetPrompts.SetActive(true);
        this.PostSequence = false;
      }
      else
      {
        if ((double) this.Timer > 3.0 && (double) this.Timer < 5.0)
        {
          Transform studentReply = this.StudentReplies[1];
          studentReply.localPosition = new Vector3(studentReply.localPosition.x, Mathf.Lerp(studentReply.transform.localPosition.y, -88f, Time.deltaTime * 10f), studentReply.localPosition.z);
          this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -137f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
          this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -415f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
        }
        if ((double) this.Timer > 5.0 && (double) this.Timer < 7.0)
        {
          Transform studentReply1 = this.StudentReplies[2];
          studentReply1.localPosition = new Vector3(studentReply1.localPosition.x, Mathf.Lerp(studentReply1.transform.localPosition.y, -88f, Time.deltaTime * 10f), studentReply1.localPosition.z);
          Transform studentReply2 = this.StudentReplies[1];
          studentReply2.localPosition = new Vector3(studentReply2.localPosition.x, Mathf.Lerp(studentReply2.transform.localPosition.y, -136f, Time.deltaTime * 10f), studentReply2.localPosition.z);
          this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -185f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
          this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -465f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
        }
        if ((double) this.Timer > 7.0 && (double) this.Timer < 9.0)
        {
          Transform studentReply3 = this.StudentReplies[3];
          studentReply3.localPosition = new Vector3(studentReply3.localPosition.x, Mathf.Lerp(studentReply3.transform.localPosition.y, -88f, Time.deltaTime * 10f), studentReply3.localPosition.z);
          Transform studentReply4 = this.StudentReplies[2];
          studentReply4.localPosition = new Vector3(studentReply4.localPosition.x, Mathf.Lerp(studentReply4.transform.localPosition.y, -136f, Time.deltaTime * 10f), studentReply4.localPosition.z);
          Transform studentReply5 = this.StudentReplies[1];
          studentReply5.localPosition = new Vector3(studentReply5.localPosition.x, Mathf.Lerp(studentReply5.transform.localPosition.y, -184f, Time.deltaTime * 10f), studentReply5.localPosition.z);
          this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -233f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
          this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -510f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
        }
        if ((double) this.Timer > 9.0 && (double) this.Timer < 11.0)
        {
          Transform studentReply6 = this.StudentReplies[4];
          studentReply6.localPosition = new Vector3(studentReply6.localPosition.x, Mathf.Lerp(studentReply6.transform.localPosition.y, -88f, Time.deltaTime * 10f), studentReply6.localPosition.z);
          Transform studentReply7 = this.StudentReplies[3];
          studentReply7.localPosition = new Vector3(studentReply7.localPosition.x, Mathf.Lerp(studentReply7.transform.localPosition.y, -136f, Time.deltaTime * 10f), studentReply7.localPosition.z);
          Transform studentReply8 = this.StudentReplies[2];
          studentReply8.localPosition = new Vector3(studentReply8.localPosition.x, Mathf.Lerp(studentReply8.transform.localPosition.y, -184f, Time.deltaTime * 10f), studentReply8.localPosition.z);
          Transform studentReply9 = this.StudentReplies[1];
          studentReply9.localPosition = new Vector3(studentReply9.localPosition.x, Mathf.Lerp(studentReply9.transform.localPosition.y, -232f, Time.deltaTime * 10f), studentReply9.localPosition.z);
          this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -281f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
          this.StudentPost1.localPosition = new Vector3(this.StudentPost1.localPosition.x, Mathf.Lerp(this.StudentPost1.transform.localPosition.y, -560f, Time.deltaTime * 10f), this.StudentPost1.localPosition.z);
        }
        if ((double) this.Timer > 11.0 && (double) this.Timer < 13.0)
        {
          Transform studentReply10 = this.StudentReplies[5];
          studentReply10.localPosition = new Vector3(studentReply10.localPosition.x, Mathf.Lerp(studentReply10.transform.localPosition.y, -88f, Time.deltaTime * 10f), studentReply10.localPosition.z);
          Transform studentReply11 = this.StudentReplies[4];
          studentReply11.localPosition = new Vector3(studentReply11.localPosition.x, Mathf.Lerp(studentReply11.transform.localPosition.y, -136f, Time.deltaTime * 10f), studentReply11.localPosition.z);
          Transform studentReply12 = this.StudentReplies[3];
          studentReply12.localPosition = new Vector3(studentReply12.localPosition.x, Mathf.Lerp(studentReply12.transform.localPosition.y, -184f, Time.deltaTime * 10f), studentReply12.localPosition.z);
          Transform studentReply13 = this.StudentReplies[2];
          studentReply13.localPosition = new Vector3(studentReply13.localPosition.x, Mathf.Lerp(studentReply13.transform.localPosition.y, -232f, Time.deltaTime * 10f), studentReply13.localPosition.z);
          Transform studentReply14 = this.StudentReplies[1];
          studentReply14.localPosition = new Vector3(studentReply14.localPosition.x, Mathf.Lerp(studentReply14.transform.localPosition.y, -280f, Time.deltaTime * 10f), studentReply14.localPosition.z);
          this.YandereReply.localPosition = new Vector3(this.YandereReply.localPosition.x, Mathf.Lerp(this.YandereReply.transform.localPosition.y, -329f, Time.deltaTime * 10f), this.YandereReply.localPosition.z);
        }
        if ((double) this.Timer <= 13.0)
          return;
        StudentGlobals.SetStudentExposed(11, true);
        StudentGlobals.UpdateRivalReputation = true;
        Debug.Log((object) "''StudentGlobals.UpdateRivalReputation''' has been set to ''true''.");
        this.InternetPrompts.SetActive(true);
        this.PostSequence = false;
      }
    }
    else
    {
      if (!this.OnlineShopping.activeInHierarchy)
        return;
      if (Input.GetKeyDown("m"))
        PlayerGlobals.Money = 100f;
      if (Input.GetButtonDown("A"))
      {
        if (this.Height == 0 || this.Height > 1)
        {
          if ((double) PlayerGlobals.Money > 33.330001831054688)
          {
            if (!this.AreYouSure.activeInHierarchy)
            {
              this.AreYouSure.SetActive(true);
            }
            else
            {
              this.AreYouSure.SetActive(false);
              GameGlobals.SpareUniform = true;
              PlayerGlobals.Money -= 33.33f;
              this.MyAudio.Play();
              this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", (IFormatProvider) NumberFormatInfo.InvariantInfo);
              this.Clock.UpdateMoneyLabel();
            }
          }
          else
            this.Shake = 10f;
        }
        else if (this.Height == 1)
        {
          if ((double) PlayerGlobals.Money > 8.4899997711181641)
          {
            if (!this.AreYouSure.activeInHierarchy)
            {
              this.AreYouSure.SetActive(true);
            }
            else
            {
              this.AreYouSure.SetActive(false);
              GameGlobals.BlondeHair = true;
              PlayerGlobals.Money -= 8.49f;
              this.MyAudio.Play();
              this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", (IFormatProvider) NumberFormatInfo.InvariantInfo);
              this.Clock.UpdateMoneyLabel();
            }
          }
          else
            this.Shake = 10f;
        }
      }
      this.Shake = Mathf.MoveTowards(this.Shake, 0.0f, Time.deltaTime * 10f);
      this.MoneyLabel.transform.localPosition = new Vector3(570f + UnityEngine.Random.Range(this.Shake * -1f, this.Shake * 1f), 420f + UnityEngine.Random.Range(this.Shake * -1f, this.Shake * 1f), 0.0f);
      if (Input.GetButtonDown("B"))
      {
        if (!this.AreYouSure.activeInHierarchy)
        {
          this.NavigationMenu.SetActive(true);
          this.OnlineShopping.SetActive(false);
        }
        else
          this.AreYouSure.SetActive(false);
      }
      if (!this.AreYouSure.activeInHierarchy)
      {
        if (this.InputManager.TappedDown)
          ++this.Height;
        if (this.InputManager.TappedUp)
          --this.Height;
      }
      if (this.Height < 0)
        this.Height = 0;
      if (this.Height > 4)
        this.Height = 4;
      if (this.Height == 0)
        this.Highlight.localPosition = Vector3.Lerp(this.Highlight.localPosition, new Vector3(this.Highlight.localPosition.x, 130f, this.Highlight.localPosition.z), Time.deltaTime * 10f);
      else if (this.Height > 0)
        this.Highlight.localPosition = Vector3.Lerp(this.Highlight.localPosition, new Vector3(this.Highlight.localPosition.x, -85f, this.Highlight.localPosition.z), Time.deltaTime * 10f);
      if (this.Height < 2)
        this.ItemList.localPosition = Vector3.Lerp(this.ItemList.localPosition, new Vector3(this.ItemList.localPosition.x, 130f, this.ItemList.localPosition.z), Time.deltaTime * 10f);
      else
        this.ItemList.localPosition = Vector3.Lerp(this.ItemList.localPosition, new Vector3(this.ItemList.localPosition.x, (float) (130 + 215 * (this.Height - 1)), this.ItemList.localPosition.z), Time.deltaTime * 10f);
    }
  }

  private void ExitPost()
  {
    this.Highlights[1].enabled = false;
    this.Highlights[2].enabled = false;
    this.Highlights[3].enabled = false;
    this.NewPostText.SetActive(false);
    this.BG.SetActive(false);
    this.PostLabels[1].text = string.Empty;
    this.PostLabels[2].text = string.Empty;
    this.PostLabels[3].text = string.Empty;
    this.WritingPost = false;
  }

  private void UpdateHighlight()
  {
    if (this.Selected > 3)
      this.Selected = 1;
    if (this.Selected < 1)
      this.Selected = 3;
    this.Highlights[1].enabled = false;
    this.Highlights[2].enabled = false;
    this.Highlights[3].enabled = false;
    this.Highlights[this.Selected].enabled = true;
  }

  private void UpdateMenuHighlight()
  {
    if (this.MenuSelected > 10)
      this.MenuSelected = 1;
    if (this.MenuSelected < 1)
      this.MenuSelected = 10;
    this.MenuHighlight.transform.localPosition = new Vector3(this.MenuHighlight.transform.localPosition.x, (float) (220.0 - 40.0 * (double) this.MenuSelected), this.MenuHighlight.transform.localPosition.z);
  }

  private void CheckForCompletion()
  {
    if (!(this.PostLabels[1].text != string.Empty) || !(this.PostLabels[2].text != string.Empty) || !(this.PostLabels[3].text != string.Empty))
      return;
    this.PostLabel.SetActive(true);
    this.PostIcon.SetActive(true);
  }

  private void GetPortrait(int ID) => this.CurrentPortrait = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + ID.ToString() + ".png").texture;
}
