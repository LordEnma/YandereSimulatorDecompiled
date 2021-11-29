using System;
using UnityEngine;

// Token: 0x020000DA RID: 218
public class AudioMenuScript : MonoBehaviour
{
	// Token: 0x06000A04 RID: 2564 RVA: 0x00056347 File Offset: 0x00054547
	private void Start()
	{
		this.UpdateText();
	}

	// Token: 0x06000A05 RID: 2565 RVA: 0x00056350 File Offset: 0x00054550
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			this.CustomMusicMenu.SetActive(true);
			base.gameObject.SetActive(false);
		}
		if (this.InputManager.TappedUp)
		{
			this.Selected--;
			this.UpdateHighlight();
		}
		else if (this.InputManager.TappedDown)
		{
			this.Selected++;
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
				if (this.Jukebox.Volume < 1f)
				{
					this.Jukebox.Volume += 0.05f;
				}
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				if (this.Jukebox.Volume > 0f)
				{
					this.Jukebox.Volume -= 0.05f;
				}
				this.UpdateText();
			}
		}
		else
		{
			int selected = this.Selected;
		}
		if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.Yandere.Blur.enabled = true;
			this.PauseScreen.MainMenu.SetActive(true);
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000A06 RID: 2566 RVA: 0x00056580 File Offset: 0x00054780
	public void UpdateText()
	{
		if (this.Jukebox != null)
		{
			this.CurrentTrackLabel.text = (this.Jukebox.BGM.ToString() ?? "");
			this.MusicVolumeLabel.text = ((this.Jukebox.Volume * 10f).ToString("F1") ?? "");
			if (this.SubtitlePanel.alpha == 1f)
			{
				this.SubtitlesOnOffLabel.text = "On";
				return;
			}
			this.SubtitlesOnOffLabel.text = "Off";
		}
	}

	// Token: 0x06000A07 RID: 2567 RVA: 0x00056628 File Offset: 0x00054828
	private void UpdateHighlight()
	{
		if (this.Selected == 0)
		{
			this.Selected = this.SelectionLimit;
		}
		else if (this.Selected > this.SelectionLimit)
		{
			this.Selected = 1;
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 440f - 60f * (float)this.Selected, this.Highlight.localPosition.z);
	}

	// Token: 0x04000AAF RID: 2735
	public InputManagerScript InputManager;

	// Token: 0x04000AB0 RID: 2736
	public PauseScreenScript PauseScreen;

	// Token: 0x04000AB1 RID: 2737
	public PromptBarScript PromptBar;

	// Token: 0x04000AB2 RID: 2738
	public JukeboxScript Jukebox;

	// Token: 0x04000AB3 RID: 2739
	public UILabel CurrentTrackLabel;

	// Token: 0x04000AB4 RID: 2740
	public UILabel MusicVolumeLabel;

	// Token: 0x04000AB5 RID: 2741
	public UILabel SubtitlesOnOffLabel;

	// Token: 0x04000AB6 RID: 2742
	public UIPanel SubtitlePanel;

	// Token: 0x04000AB7 RID: 2743
	public int SelectionLimit = 5;

	// Token: 0x04000AB8 RID: 2744
	public int Selected = 1;

	// Token: 0x04000AB9 RID: 2745
	public Transform Highlight;

	// Token: 0x04000ABA RID: 2746
	public GameObject CustomMusicMenu;
}
