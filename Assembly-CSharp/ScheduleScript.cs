// Decompiled with JetBrains decompiler
// Type: ScheduleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class ScheduleScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public PauseScreenScript PauseScreen;
  public VoidGoddessScript VoidGoddess;
  public GameObject[] EventIcons;
  public UITexture[] Portraits;
  public string[] Descriptions;
  public Transform Highlight;
  public UILabel Description;
  public UILabel Header;
  public DayOfWeek Weekday;
  public int Index;
  public int X = 1;
  public int Y = 1;
  public int LimitX = 1;
  public int LimitY = 1;
  public bool Initialized;

  public void Start()
  {
    if (!this.Initialized)
    {
      if ((UnityEngine.Object) this.VoidGoddess != (UnityEngine.Object) null)
      {
        this.VoidGoddess.Start();
        this.Portraits[1].mainTexture = this.VoidGoddess.Portraits[11].mainTexture;
        this.Portraits[2].mainTexture = this.VoidGoddess.Portraits[1].mainTexture;
        this.Portraits[3].mainTexture = this.VoidGoddess.Portraits[11].mainTexture;
        this.Portraits[4].mainTexture = this.VoidGoddess.Portraits[10].mainTexture;
        this.Portraits[5].mainTexture = this.VoidGoddess.Portraits[11].mainTexture;
        this.Portraits[6].mainTexture = this.VoidGoddess.Portraits[81].mainTexture;
        this.Portraits[7].mainTexture = this.VoidGoddess.Portraits[2].mainTexture;
        this.Portraits[8].mainTexture = this.VoidGoddess.Portraits[3].mainTexture;
        this.Portraits[9].mainTexture = this.VoidGoddess.Portraits[62].mainTexture;
        this.Portraits[10].mainTexture = this.VoidGoddess.Portraits[63].mainTexture;
      }
      this.Initialized = true;
    }
    this.Weekday = DateGlobals.Weekday;
    this.UpdateIcons();
  }

  private void UpdateIcons()
  {
    this.Header.text = this.Weekday.ToString() + " Schedule";
    for (int index = 1; index < this.EventIcons.Length; ++index)
      this.EventIcons[index].SetActive(false);
    this.EventIcons[1].SetActive(true);
    this.Descriptions[1] = "Every morning, Osana and Senpai will have a conversation. By eavesdropping on this conversation, you can learn about an interaction that Osana and Senpai will have later in the day.";
    if (this.Weekday == DayOfWeek.Monday)
    {
      this.EventIcons[7].SetActive(true);
      this.Descriptions[7] = "At lunchtime, Osana will give Senpai a bento. By sabotaging the bento, you can make Senpai dislike Osana.";
    }
    if (this.Weekday == DayOfWeek.Friday)
    {
      this.EventIcons[7].SetActive(true);
      this.Descriptions[7] = "At lunchtime, Osana will share her favorite music with Senpai. By replacing her music tracks with audio that sounds bad out-of-context, you can make Senpai dislike Osana.";
    }
    if (this.Weekday == DayOfWeek.Tuesday)
    {
      this.EventIcons[10].SetActive(true);
      this.Descriptions[10] = "Osana is going to meet up with Senpai and return the book that she borrowed.";
    }
    if (this.Weekday == DayOfWeek.Wednesday)
    {
      this.EventIcons[10].SetActive(true);
      this.Descriptions[10] = "Osana is going to meet up with Senpai and show him a photo she took earlier in the day.";
    }
    if (this.Weekday == DayOfWeek.Thursday)
    {
      this.EventIcons[10].SetActive(true);
      this.Descriptions[10] = "Osana is going to meet up with Senpai and go on a date with him.";
    }
    if (this.Weekday == DayOfWeek.Friday)
    {
      this.EventIcons[10].SetActive(true);
      this.Descriptions[10] = "Osana is going to put a note in Senpai's locker and tell him to meet her under the cherry tree behind the school. Under the cherry tree, Osana is going to confess her love to Senpai.";
    }
    this.EventIcons[12].SetActive(true);
    this.Descriptions[12] = "Every morning, Osana and Raibaru will have a conversation. By eavesdropping on this conversation, you can learn a clue about how to sabotage an interaction that Osana and Senpai will have later in the day.";
    if (this.Weekday == DayOfWeek.Monday)
    {
      this.EventIcons[13].SetActive(true);
      this.Descriptions[13] = "Osana is going to put two bento boxes on her desk. One bento is for her; the other bento is for Senpai. You can put emetic poison into Senpai's bento to make him puke and damage his relationship with Osana. You can also put lethal poison into Osana's bento to kill her, or put emetic poison into her bento to put her into a vulnerable position.";
      this.EventIcons[14].SetActive(true);
      this.Descriptions[14] = "Raibaru is going to ask Osana to talk about what kind of boys she likes. By eavesdropping on this conversation, you can learn the information you'd need in order to make another boy become appealing to Osana.";
      this.EventIcons[15].SetActive(true);
      this.Descriptions[15] = "Osana is going to recieve a distressing phone call. By eavesdropping on this call, you can learn some of the information you'd need in order to put Osana into your debt.";
      this.EventIcons[16].SetActive(true);
      this.Descriptions[16] = "Osana and Raibaru are going to tour the school and visit each of the clubrooms. By eavesdropping on their conversations, you can learn about Osana's likes and dislikes.";
      this.EventIcons[18].SetActive(true);
      this.Descriptions[18] = "Osana and Raibaru are going to have a private discussion on the school rooftop, behind the air vents. By eavesdropping on their conversations, you can learn some of the information you'd need in order to put Osana into your debt.";
    }
    else if (this.Weekday == DayOfWeek.Tuesday)
    {
      this.EventIcons[17].SetActive(true);
      this.Descriptions[17] = "Osana is going to read the book she borrowed from Senpai. When she leaves the book unattended, you will have an opportunity to damage the book.";
    }
    else if (this.Weekday == DayOfWeek.Wednesday)
    {
      this.EventIcons[17].SetActive(true);
      this.Descriptions[17] = "Osana is going to take a photo of a pretty location somewhere in school.";
    }
    else if (this.Weekday == DayOfWeek.Thursday)
    {
      this.EventIcons[13].SetActive(true);
      this.Descriptions[13] = "Osana is going to talk with Raibaru about how hungry she is. This is an indication that this is the one time that Osana is willing to accept food from a stranger.";
      this.EventIcons[17].SetActive(true);
      this.Descriptions[17] = "Osana is going to sunbathe at the school pool.";
      this.EventIcons[19].SetActive(true);
      this.Descriptions[19] = "Osana is going to take a nap on the school rooftop. If you sabotage her phone alarm, you can make her late for her date with Senpai.";
    }
    else if (this.Weekday == DayOfWeek.Friday)
    {
      this.EventIcons[15].SetActive(true);
      this.Descriptions[15] = "Osana is going to create a playlist of songs for Senpai to listen to.";
    }
    if (this.Weekday == DayOfWeek.Friday)
    {
      this.EventIcons[24].SetActive(true);
      this.Descriptions[24] = "Musume is going to have a private conversation with Osana. If you record this conversation, you can edit the recording to make an audio file that sounds bad when it's heard out-of-context.";
    }
    this.EventIcons[31].SetActive(true);
    this.Descriptions[31] = "Sakyu and Inkyu are going to sit down on a bench and have a conversation about the school.";
    this.EventIcons[47].SetActive(true);
    this.Descriptions[47] = "Before eating lunch, Horo and Yaku are going to have a conversation about a popular anime show called ''Magical Girl Pretty Miyuki''.";
    if (this.Weekday != DayOfWeek.Monday)
      return;
    this.EventIcons[49].SetActive(true);
    this.Descriptions[49] = "After performing their cleaning duties, Horo and Yaku are going to have a conversation about a recent conspiracy theory revolving around a video game called ''Yanvania: Senpai of the Night''.";
  }

  private void Update()
  {
    this.PauseScreen.Sideways = true;
    if (this.InputManager.TappedRight)
    {
      ++this.X;
      this.UpdateHighlightPosition();
    }
    else if (this.InputManager.TappedLeft)
    {
      --this.X;
      this.UpdateHighlightPosition();
    }
    if (this.InputManager.TappedUp)
    {
      --this.Y;
      this.UpdateHighlightPosition();
    }
    else if (this.InputManager.TappedDown)
    {
      ++this.Y;
      this.UpdateHighlightPosition();
    }
    if (Input.GetButtonDown("RB"))
    {
      ++this.Weekday;
      if (this.Weekday > DayOfWeek.Friday)
        this.Weekday = DayOfWeek.Monday;
      this.UpdateIcons();
    }
    if (Input.GetButtonDown("LB"))
    {
      --this.Weekday;
      if (this.Weekday < DayOfWeek.Monday)
        this.Weekday = DayOfWeek.Friday;
      this.UpdateIcons();
    }
    if (Input.GetButtonDown("B"))
    {
      this.PauseScreen.PromptBar.ClearButtons();
      this.PauseScreen.PromptBar.Label[0].text = "Accept";
      this.PauseScreen.PromptBar.Label[1].text = "Exit";
      this.PauseScreen.PromptBar.Label[4].text = "Choose";
      this.PauseScreen.PromptBar.Label[5].text = "Choose";
      this.PauseScreen.PromptBar.UpdateButtons();
      this.PauseScreen.MainMenu.SetActive(true);
      this.PauseScreen.Sideways = false;
      this.gameObject.SetActive(false);
    }
    if (Input.GetButtonDown("X"))
    {
      this.PauseScreen.PromptBar.ClearButtons();
      this.PauseScreen.PromptBar.Label[0].text = "Accept";
      this.PauseScreen.PromptBar.Label[1].text = "Exit";
      this.PauseScreen.PromptBar.Label[4].text = "Choose";
      this.PauseScreen.PromptBar.UpdateButtons();
      this.PauseScreen.FavorMenu.SchemesMenu.UpdatePantyCount();
      this.PauseScreen.FavorMenu.SchemesMenu.UpdateSchemeList();
      this.PauseScreen.FavorMenu.SchemesMenu.UpdateSchemeInfo();
      this.PauseScreen.SchemesMenu.gameObject.SetActive(true);
      this.gameObject.SetActive(false);
    }
    if (!Input.GetButtonDown("Y"))
      return;
    this.PauseScreen.Hint.enabled = !this.PauseScreen.Hint.enabled;
    OptionGlobals.HintsOff = !OptionGlobals.HintsOff;
    this.PauseScreen.PromptBar.Label[3].text = this.PauseScreen.Hint.enabled ? "Disable Hints" : "Enable Hints";
    this.PauseScreen.PromptBar.UpdateButtons();
    this.PauseScreen.Hint.gameObject.SetActive(this.PauseScreen.Hint.enabled);
  }

  private void UpdateHighlightPosition()
  {
    if (this.X > this.LimitX)
      this.X = 1;
    else if (this.X < 1)
      this.X = this.LimitX;
    if (this.Y > this.LimitY)
      this.Y = 1;
    else if (this.Y < 1)
      this.Y = this.LimitY;
    this.Index = this.X + (this.Y - 1) * 10;
    this.Description.text = !this.EventIcons[this.Index].activeInHierarchy ? "There are no events occuring between these two students at this time of day." : this.Descriptions[this.Index];
    this.Highlight.localPosition = new Vector3((float) (80 * this.X - 440), (float) (266 + -66 * this.Y), 0.0f);
  }

  public void JumpToEvent(int ID)
  {
    this.Y = 1;
    this.X = ID;
    if (ID > 10)
    {
      this.Y = 2;
      this.X = ID - 10;
    }
    if (ID > 20)
    {
      this.Y = 3;
      this.X = ID - 20;
    }
    if (ID > 30)
    {
      this.Y = 4;
      this.X = ID - 30;
    }
    if (ID > 40)
    {
      this.Y = 5;
      this.X = ID - 40;
    }
    this.UpdateHighlightPosition();
  }
}
