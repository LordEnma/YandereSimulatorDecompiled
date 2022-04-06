using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000374 RID: 884
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019E2 RID: 6626 RVA: 0x0010A1E8 File Offset: 0x001083E8
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

	// Token: 0x060019E3 RID: 6627 RVA: 0x0010A312 File Offset: 0x00108512
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

	// Token: 0x060019E4 RID: 6628 RVA: 0x0010A324 File Offset: 0x00108524
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

	// Token: 0x040029AE RID: 10670
	public InputManagerScript InputManager;

	// Token: 0x040029AF RID: 10671
	public PauseScreenScript PauseScreen;

	// Token: 0x040029B0 RID: 10672
	public PromptBarScript PromptBar;

	// Token: 0x040029B1 RID: 10673
	public GameObject AudioMenu;

	// Token: 0x040029B2 RID: 10674
	public JukeboxScript Jukebox;

	// Token: 0x040029B3 RID: 10675
	public int SelectionLimit = 9;

	// Token: 0x040029B4 RID: 10676
	public int Selected;

	// Token: 0x040029B5 RID: 10677
	public Transform Highlight;

	// Token: 0x040029B6 RID: 10678
	public string path = string.Empty;

	// Token: 0x040029B7 RID: 10679
	public AudioClip CustomMusic;
}
