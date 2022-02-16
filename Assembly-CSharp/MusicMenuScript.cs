using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000371 RID: 881
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019C5 RID: 6597 RVA: 0x001083F0 File Offset: 0x001065F0
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

	// Token: 0x060019C6 RID: 6598 RVA: 0x0010851A File Offset: 0x0010671A
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

	// Token: 0x060019C7 RID: 6599 RVA: 0x0010852C File Offset: 0x0010672C
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

	// Token: 0x04002951 RID: 10577
	public InputManagerScript InputManager;

	// Token: 0x04002952 RID: 10578
	public PauseScreenScript PauseScreen;

	// Token: 0x04002953 RID: 10579
	public PromptBarScript PromptBar;

	// Token: 0x04002954 RID: 10580
	public GameObject AudioMenu;

	// Token: 0x04002955 RID: 10581
	public JukeboxScript Jukebox;

	// Token: 0x04002956 RID: 10582
	public int SelectionLimit = 9;

	// Token: 0x04002957 RID: 10583
	public int Selected;

	// Token: 0x04002958 RID: 10584
	public Transform Highlight;

	// Token: 0x04002959 RID: 10585
	public string path = string.Empty;

	// Token: 0x0400295A RID: 10586
	public AudioClip CustomMusic;
}
