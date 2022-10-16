// Decompiled with JetBrains decompiler
// Type: YouTubeChatMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
  public string[] Descriptions;
  public Transform Highlight;
  public UILabel DescLabel;
  public YouTubeChat Chat;
  public bool[] Commands;
  public bool Automatic;
  public int Column;
  public int Row;
  public int Pushes;
  public int Frame;
  public int ID;

  public void Start()
  {
    this.UpdateHighlight();
    for (int index = 1; index < 26; ++index)
      this.Checkmarks[index].spriteName = !this.Commands[index] ? "No" : "Yes";
  }

  private void Update()
  {
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
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
    else if (this.Frame == 3)
    {
      this.Chat.youtubeChatPopoutUrl = "";
      this.Chat.youtubeChatPopoutUrl = this.URL.text;
      ++this.Frame;
    }
    else if (this.Frame == 4)
    {
      this.Chat.AssureDriverActivated();
      ++this.Frame;
    }
    else if (this.Frame == 5)
    {
      if (this.Chat.isValidURL)
        this.Chat.UpdateMessagesList(false);
      ++this.Frame;
    }
    if (this.InitializeWindow.activeInHierarchy)
    {
      if (Input.GetButtonDown("A"))
      {
        if ((double) this.PauseScreen.transform.localEulerAngles.z <= 89.0)
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
      if (this.Frame == 6)
      {
        if (this.Chat.isValidURL)
        {
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
        Debug.Log((object) "Updating sprites...or trying to.");
        this.Commands[this.ID] = !this.Commands[this.ID];
        this.CommandChecker.Check[this.ID] = this.Commands[this.ID];
        if (this.Commands[this.ID])
          this.Checkmarks[this.ID].spriteName = "Yes";
        else
          this.Checkmarks[this.ID].spriteName = "No";
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
        this.UpdateHighlight();
      }
      else if (this.PauseScreen.InputManager.TappedRight)
      {
        ++this.Column;
        if (this.Column > 3)
          this.Column = 1;
        this.UpdateHighlight();
      }
      else if (this.PauseScreen.InputManager.TappedDown)
      {
        ++this.Row;
        if (this.Column < 3)
        {
          if (this.Row > 10)
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
        if (this.Column < 3)
        {
          if (this.Row < 1)
            this.Row = 10;
        }
        else if (this.Row < 1)
          this.Row = 5;
        this.UpdateHighlight();
      }
    }
  }

  private void UpdateHighlight()
  {
    if (this.Column == 3 && this.Row > 5)
      this.Row = 5;
    this.Highlight.localPosition = new Vector3((float) ((this.Column - 1) * 150 - 500), 37.5f - (float) (this.Row * 25), 0.0f);
    this.ID = this.Row + (this.Column - 1) * 10;
    this.DescLabel.text = this.Descriptions[this.ID];
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
