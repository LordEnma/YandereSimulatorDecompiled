// Decompiled with JetBrains decompiler
// Type: AudioMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AudioMenuScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public PauseScreenScript PauseScreen;
  public PromptBarScript PromptBar;
  public JukeboxScript Jukebox;
  public UILabel CurrentTrackLabel;
  public UILabel MusicVolumeLabel;
  public UILabel SubtitlesOnOffLabel;
  public UIPanel SubtitlePanel;
  public int SelectionLimit = 5;
  public int Selected = 1;
  public Transform Highlight;
  public GameObject CustomMusicMenu;

  private void Start() => this.UpdateText();

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.C))
    {
      this.CustomMusicMenu.SetActive(true);
      this.gameObject.SetActive(false);
    }
    if (this.InputManager.TappedUp)
    {
      --this.Selected;
      this.UpdateHighlight();
    }
    else if (this.InputManager.TappedDown)
    {
      ++this.Selected;
      this.UpdateHighlight();
    }
    if (this.Selected == 1)
    {
      if (this.InputManager.TappedRight)
      {
        this.Jukebox.StartStopMusic();
        this.Jukebox.StartStopMusic();
        this.UpdateText();
      }
      else if (this.InputManager.TappedLeft)
      {
        this.Jukebox.BGM -= 2;
        this.Jukebox.StartStopMusic();
        this.Jukebox.StartStopMusic();
        this.UpdateText();
      }
    }
    else if (this.Selected == 2)
    {
      if (this.InputManager.TappedRight)
      {
        if ((double) this.Jukebox.Volume < 1.0)
          this.Jukebox.Volume += 0.05f;
        this.UpdateText();
      }
      else if (this.InputManager.TappedLeft)
      {
        if ((double) this.Jukebox.Volume > 0.0)
          this.Jukebox.Volume -= 0.05f;
        if ((double) this.Jukebox.Volume < 0.05000000074505806)
          this.Jukebox.Volume = 0.0f;
        this.UpdateText();
      }
    }
    else
    {
      int selected = this.Selected;
    }
    if (!Input.GetButtonDown("B"))
      return;
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Accept";
    this.PromptBar.Label[1].text = "Exit";
    this.PromptBar.Label[4].text = "Choose";
    this.PromptBar.UpdateButtons();
    this.PauseScreen.Yandere.Blur.enabled = true;
    this.PauseScreen.MainMenu.SetActive(true);
    this.PauseScreen.Sideways = false;
    this.PauseScreen.PressedB = true;
    this.gameObject.SetActive(false);
  }

  public void UpdateText()
  {
    if (!((Object) this.Jukebox != (Object) null))
      return;
    this.CurrentTrackLabel.text = this.Jukebox.BGM.ToString() ?? "";
    this.MusicVolumeLabel.text = (this.Jukebox.Volume * 10f).ToString("F1") ?? "";
    if ((double) this.SubtitlePanel.alpha == 1.0)
      this.SubtitlesOnOffLabel.text = "On";
    else
      this.SubtitlesOnOffLabel.text = "Off";
  }

  private void UpdateHighlight()
  {
    if (this.Selected == 0)
      this.Selected = this.SelectionLimit;
    else if (this.Selected > this.SelectionLimit)
      this.Selected = 1;
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (440.0 - 60.0 * (double) this.Selected), this.Highlight.localPosition.z);
  }
}
