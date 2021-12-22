using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200036F RID: 879
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019B5 RID: 6581 RVA: 0x001072E0 File Offset: 0x001054E0
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			this.AudioMenu.SetActive(true);
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
		if (Input.GetButtonDown("A"))
		{
			base.StartCoroutine(this.DownloadCoroutine());
		}
		if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.MainMenu.SetActive(true);
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x060019B6 RID: 6582 RVA: 0x0010740A File Offset: 0x0010560A
	private IEnumerator DownloadCoroutine()
	{
		WWW CurrentDownload = new WWW(string.Concat(new string[]
		{
			"File:///",
			Application.streamingAssetsPath,
			"/Music/track",
			this.Selected.ToString(),
			".ogg"
		}));
		yield return CurrentDownload;
		this.CustomMusic = CurrentDownload.GetAudioClipCompressed();
		this.Jukebox.Custom.clip = this.CustomMusic;
		this.Jukebox.PlayCustom();
		yield break;
	}

	// Token: 0x060019B7 RID: 6583 RVA: 0x0010741C File Offset: 0x0010561C
	private void UpdateHighlight()
	{
		if (this.Selected < 0)
		{
			this.Selected = this.SelectionLimit;
		}
		else if (this.Selected > this.SelectionLimit)
		{
			this.Selected = 0;
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 365f - 80f * (float)this.Selected, this.Highlight.localPosition.z);
	}

	// Token: 0x04002934 RID: 10548
	public InputManagerScript InputManager;

	// Token: 0x04002935 RID: 10549
	public PauseScreenScript PauseScreen;

	// Token: 0x04002936 RID: 10550
	public PromptBarScript PromptBar;

	// Token: 0x04002937 RID: 10551
	public GameObject AudioMenu;

	// Token: 0x04002938 RID: 10552
	public JukeboxScript Jukebox;

	// Token: 0x04002939 RID: 10553
	public int SelectionLimit = 9;

	// Token: 0x0400293A RID: 10554
	public int Selected;

	// Token: 0x0400293B RID: 10555
	public Transform Highlight;

	// Token: 0x0400293C RID: 10556
	public string path = string.Empty;

	// Token: 0x0400293D RID: 10557
	public AudioClip CustomMusic;
}
