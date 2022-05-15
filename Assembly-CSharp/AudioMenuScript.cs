using System;
using UnityEngine;

// Token: 0x020000DA RID: 218
public class AudioMenuScript : MonoBehaviour
{
	// Token: 0x06000A04 RID: 2564 RVA: 0x0005689B File Offset: 0x00054A9B
	private void Start()
	{
		this.UpdateText();
	}

	// Token: 0x06000A05 RID: 2565 RVA: 0x000568A4 File Offset: 0x00054AA4
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

	// Token: 0x06000A06 RID: 2566 RVA: 0x00056AD4 File Offset: 0x00054CD4
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

	// Token: 0x06000A07 RID: 2567 RVA: 0x00056B7C File Offset: 0x00054D7C
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

	// Token: 0x04000ABD RID: 2749
	public InputManagerScript InputManager;

	// Token: 0x04000ABE RID: 2750
	public PauseScreenScript PauseScreen;

	// Token: 0x04000ABF RID: 2751
	public PromptBarScript PromptBar;

	// Token: 0x04000AC0 RID: 2752
	public JukeboxScript Jukebox;

	// Token: 0x04000AC1 RID: 2753
	public UILabel CurrentTrackLabel;

	// Token: 0x04000AC2 RID: 2754
	public UILabel MusicVolumeLabel;

	// Token: 0x04000AC3 RID: 2755
	public UILabel SubtitlesOnOffLabel;

	// Token: 0x04000AC4 RID: 2756
	public UIPanel SubtitlePanel;

	// Token: 0x04000AC5 RID: 2757
	public int SelectionLimit = 5;

	// Token: 0x04000AC6 RID: 2758
	public int Selected = 1;

	// Token: 0x04000AC7 RID: 2759
	public Transform Highlight;

	// Token: 0x04000AC8 RID: 2760
	public GameObject CustomMusicMenu;
}
