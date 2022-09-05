// Decompiled with JetBrains decompiler
// Type: MusicMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class MusicMenuScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public PauseScreenScript PauseScreen;
  public PromptBarScript PromptBar;
  public GameObject AudioMenu;
  public JukeboxScript Jukebox;
  public int SelectionLimit = 9;
  public int Selected;
  public Transform Highlight;
  public string path = string.Empty;
  public AudioClip CustomMusic;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.C))
    {
      this.AudioMenu.SetActive(true);
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
    if (Input.GetButtonDown("A"))
      this.StartCoroutine(this.DownloadCoroutine());
    if (!Input.GetButtonDown("B"))
      return;
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Accept";
    this.PromptBar.Label[1].text = "Exit";
    this.PromptBar.Label[4].text = "Choose";
    this.PromptBar.UpdateButtons();
    this.PauseScreen.MainMenu.SetActive(true);
    this.PauseScreen.Sideways = false;
    this.PauseScreen.PressedB = true;
    this.gameObject.SetActive(false);
  }

  private IEnumerator DownloadCoroutine()
  {
    WWW CurrentDownload = new WWW("File:///" + Application.streamingAssetsPath + "/Music/track" + this.Selected.ToString() + ".ogg");
    yield return (object) CurrentDownload;
    this.CustomMusic = CurrentDownload.GetAudioClipCompressed();
    this.Jukebox.Custom.clip = this.CustomMusic;
    this.Jukebox.PlayCustom();
  }

  private void UpdateHighlight()
  {
    if (this.Selected < 0)
      this.Selected = this.SelectionLimit;
    else if (this.Selected > this.SelectionLimit)
      this.Selected = 0;
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (365.0 - 80.0 * (double) this.Selected), this.Highlight.localPosition.z);
  }
}
