using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019CE RID: 6606 RVA: 0x00109088 File Offset: 0x00107288
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

	// Token: 0x060019CF RID: 6607 RVA: 0x001091B2 File Offset: 0x001073B2
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

	// Token: 0x060019D0 RID: 6608 RVA: 0x001091C4 File Offset: 0x001073C4
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

	// Token: 0x04002976 RID: 10614
	public InputManagerScript InputManager;

	// Token: 0x04002977 RID: 10615
	public PauseScreenScript PauseScreen;

	// Token: 0x04002978 RID: 10616
	public PromptBarScript PromptBar;

	// Token: 0x04002979 RID: 10617
	public GameObject AudioMenu;

	// Token: 0x0400297A RID: 10618
	public JukeboxScript Jukebox;

	// Token: 0x0400297B RID: 10619
	public int SelectionLimit = 9;

	// Token: 0x0400297C RID: 10620
	public int Selected;

	// Token: 0x0400297D RID: 10621
	public Transform Highlight;

	// Token: 0x0400297E RID: 10622
	public string path = string.Empty;

	// Token: 0x0400297F RID: 10623
	public AudioClip CustomMusic;
}
