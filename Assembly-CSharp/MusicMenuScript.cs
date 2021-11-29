using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200036E RID: 878
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019AE RID: 6574 RVA: 0x00106A40 File Offset: 0x00104C40
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

	// Token: 0x060019AF RID: 6575 RVA: 0x00106B6A File Offset: 0x00104D6A
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

	// Token: 0x060019B0 RID: 6576 RVA: 0x00106B7C File Offset: 0x00104D7C
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

	// Token: 0x0400290F RID: 10511
	public InputManagerScript InputManager;

	// Token: 0x04002910 RID: 10512
	public PauseScreenScript PauseScreen;

	// Token: 0x04002911 RID: 10513
	public PromptBarScript PromptBar;

	// Token: 0x04002912 RID: 10514
	public GameObject AudioMenu;

	// Token: 0x04002913 RID: 10515
	public JukeboxScript Jukebox;

	// Token: 0x04002914 RID: 10516
	public int SelectionLimit = 9;

	// Token: 0x04002915 RID: 10517
	public int Selected;

	// Token: 0x04002916 RID: 10518
	public Transform Highlight;

	// Token: 0x04002917 RID: 10519
	public string path = string.Empty;

	// Token: 0x04002918 RID: 10520
	public AudioClip CustomMusic;
}
