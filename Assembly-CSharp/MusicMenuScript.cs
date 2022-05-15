using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000375 RID: 885
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019F0 RID: 6640 RVA: 0x0010B1F8 File Offset: 0x001093F8
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

	// Token: 0x060019F1 RID: 6641 RVA: 0x0010B322 File Offset: 0x00109522
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

	// Token: 0x060019F2 RID: 6642 RVA: 0x0010B334 File Offset: 0x00109534
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

	// Token: 0x040029D1 RID: 10705
	public InputManagerScript InputManager;

	// Token: 0x040029D2 RID: 10706
	public PauseScreenScript PauseScreen;

	// Token: 0x040029D3 RID: 10707
	public PromptBarScript PromptBar;

	// Token: 0x040029D4 RID: 10708
	public GameObject AudioMenu;

	// Token: 0x040029D5 RID: 10709
	public JukeboxScript Jukebox;

	// Token: 0x040029D6 RID: 10710
	public int SelectionLimit = 9;

	// Token: 0x040029D7 RID: 10711
	public int Selected;

	// Token: 0x040029D8 RID: 10712
	public Transform Highlight;

	// Token: 0x040029D9 RID: 10713
	public string path = string.Empty;

	// Token: 0x040029DA RID: 10714
	public AudioClip CustomMusic;
}
