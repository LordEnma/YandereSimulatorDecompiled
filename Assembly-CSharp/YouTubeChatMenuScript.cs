// Decompiled with JetBrains decompiler
// Type: YouTubeChatMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YouTubeChatMenuScript : MonoBehaviour
{
  public YouTubeCommandTestScript CommandChecker;
  public PauseScreenScript PauseScreen;
  public UILabel InitializationLabel;
  public UILabel ValidURL;
  public UILabel URL;
  public GameObject InitializeWindow;
  public GameObject CommandWindow;
  public GameObject Button;
  public UISprite AutomaticSprite;
  public UISprite ManualSprite;
  public BoxCollider ClickHitbox;
  public UISprite[] Checkmarks;
  public Transform Highlight;
  public YouTubeChat Chat;
  public bool[] Commands;
  public bool Automatic;
  public int Column;
  public int Row;
  public int Pushes;
  public int Frame;
  public int ID;
  public int X;

  private void Update()
  {
    if (this.Frame == 1)
    {
      this.InitializeWindow.SetActive(false);
      this.CommandWindow.SetActive(true);
      this.Chat.gameObject.SetActive(true);
      this.PauseScreen.PromptBar.Label[0].text = "Toggle";
      this.PauseScreen.PromptBar.Label[1].text = "Back";
      this.PauseScreen.PromptBar.Label[4].text = "Scroll";
      this.PauseScreen.PromptBar.UpdateButtons();
      ++this.Frame;
    }
    if (this.Frame == 3)
    {
      this.Chat.youtubeChatPopoutUrl = this.URL.text;
      this.Chat.AssureDriverActivated();
      if (this.Chat.isValidURL)
        this.Chat.UpdateMessagesList(false);
      ++this.Frame;
    }
    if (this.InitializeWindow.activeInHierarchy)
    {
      if (Input.GetButtonDown("A"))
      {
        ++this.Pushes;
        if (this.Pushes != 10)
          return;
        this.InitializationLabel.text = "Now initializing the chat-checking system! Please wait...";
        this.InitializationLabel.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.PauseScreen.PromptBar.ClearButtons();
        this.Button.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ++this.Frame;
      }
      else
      {
        if (!Input.GetButtonDown("B"))
          return;
        this.Exit();
      }
    }
    else
    {
      this.ClickHitbox.size = new Vector3(640f, 64f, Random.RandomRange(1f, 64f));
      if (this.Frame == 4)
      {
        if (this.Chat.isValidURL)
        {
          if (this.Chat.TimeBased)
            this.CommandChecker.CountdownCircle.transform.parent.gameObject.SetActive(true);
          this.ValidURL.text = "Connected to chat! Have fun!";
          this.ValidURL.color = new Color(0.0f, 1f, 0.0f, 1f);
        }
        else
        {
          this.ValidURL.text = "Check URL and try again.";
          this.ValidURL.color = new Color(1f, 0.0f, 0.0f, 1f);
        }
      }
      if (Input.GetButtonDown("A"))
      {
        if (this.Column == 1 && this.Row == 1)
        {
          if (this.Chat.TimeBased)
            this.CommandChecker.CountdownCircle.transform.parent.gameObject.SetActive(true);
          this.CommandChecker.Chat.TimeBased = true;
          this.Automatic = true;
          this.AutomaticSprite.spriteName = "Yes";
          this.ManualSprite.spriteName = "No";
        }
        else if (this.Column == 1 && this.Row == 2)
        {
          if (this.Chat.TimeBased)
            this.CommandChecker.CountdownCircle.transform.parent.gameObject.SetActive(false);
          this.CommandChecker.Chat.TimeBased = false;
          this.Automatic = false;
          this.AutomaticSprite.spriteName = "No";
          this.ManualSprite.spriteName = "Yes";
        }
        else
        {
          Debug.Log((object) "Updating sprites...or trying to.");
          this.Commands[this.ID] = !this.Commands[this.ID];
          this.CommandChecker.Check[this.ID] = this.Commands[this.ID];
          if (this.Commands[this.ID])
            this.Checkmarks[this.ID].spriteName = "Yes";
          else
            this.Checkmarks[this.ID].spriteName = "No";
        }
      }
      else if (Input.GetButtonDown("B"))
        this.Exit();
      else if (Input.GetButtonDown("X"))
      {
        this.ValidURL.text = "Checking URL, please wait...";
        this.ValidURL.color = new Color(1f, 1f, 1f, 1f);
        this.Frame = 3;
      }
      else if (this.PauseScreen.InputManager.TappedLeft)
      {
        --this.Column;
        if (this.Column < 1)
          this.Column = 3;
        if (this.Column == 1 && this.Row > 2)
          this.Row = 2;
        this.UpdateHighlight();
      }
      else if (this.PauseScreen.InputManager.TappedRight)
      {
        ++this.Column;
        if (this.Column > 3)
        {
          this.Column = 1;
          if (this.Row > 2)
            this.Row = 2;
        }
        this.UpdateHighlight();
      }
      else if (this.PauseScreen.InputManager.TappedDown)
      {
        ++this.Row;
        if (this.Column == 1)
        {
          if (this.Row > 2)
            this.Row = 1;
        }
        else if (this.Row > 5)
          this.Row = 1;
        this.UpdateHighlight();
      }
      else
      {
        if (!this.PauseScreen.InputManager.TappedUp)
          return;
        --this.Row;
        if (this.Column == 1)
        {
          if (this.Row < 1)
            this.Row = 2;
        }
        else if (this.Row < 1)
          this.Row = 5;
        this.UpdateHighlight();
      }
    }
  }

  private void UpdateHighlight()
  {
    if (this.Column == 1)
    {
      this.Highlight.localPosition = new Vector3(-500f, (float) (125 - this.Row * 125), 0.0f);
    }
    else
    {
      this.Highlight.localPosition = new Vector3((float) (this.Column * 225 - 525), (float) (50 - this.Row * 50), 0.0f);
      this.ID = this.Row + (this.Column - 2) * 5;
    }
  }

  private void Exit()
  {
    this.PauseScreen.PromptBar.Label[0].text = "Accept";
    this.PauseScreen.MainMenu.SetActive(true);
    this.PauseScreen.Sideways = false;
    this.gameObject.SetActive(false);
    Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = false;
  }
}
