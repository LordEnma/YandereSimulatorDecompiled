using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019CE RID: 6606 RVA: 0x00108D20 File Offset: 0x00106F20
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

	// Token: 0x060019CF RID: 6607 RVA: 0x00108E4A File Offset: 0x0010704A
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

	// Token: 0x060019D0 RID: 6608 RVA: 0x00108E5C File Offset: 0x0010705C
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

	// Token: 0x04002960 RID: 10592
	public InputManagerScript InputManager;

	// Token: 0x04002961 RID: 10593
	public PauseScreenScript PauseScreen;

	// Token: 0x04002962 RID: 10594
	public PromptBarScript PromptBar;

	// Token: 0x04002963 RID: 10595
	public GameObject AudioMenu;

	// Token: 0x04002964 RID: 10596
	public JukeboxScript Jukebox;

	// Token: 0x04002965 RID: 10597
	public int SelectionLimit = 9;

	// Token: 0x04002966 RID: 10598
	public int Selected;

	// Token: 0x04002967 RID: 10599
	public Transform Highlight;

	// Token: 0x04002968 RID: 10600
	public string path = string.Empty;

	// Token: 0x04002969 RID: 10601
	public AudioClip CustomMusic;
}
