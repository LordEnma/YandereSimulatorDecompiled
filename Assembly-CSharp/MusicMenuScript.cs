using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000374 RID: 884
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019E6 RID: 6630 RVA: 0x0010A4AC File Offset: 0x001086AC
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

	// Token: 0x060019E7 RID: 6631 RVA: 0x0010A5D6 File Offset: 0x001087D6
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

	// Token: 0x060019E8 RID: 6632 RVA: 0x0010A5E8 File Offset: 0x001087E8
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

	// Token: 0x040029B6 RID: 10678
	public InputManagerScript InputManager;

	// Token: 0x040029B7 RID: 10679
	public PauseScreenScript PauseScreen;

	// Token: 0x040029B8 RID: 10680
	public PromptBarScript PromptBar;

	// Token: 0x040029B9 RID: 10681
	public GameObject AudioMenu;

	// Token: 0x040029BA RID: 10682
	public JukeboxScript Jukebox;

	// Token: 0x040029BB RID: 10683
	public int SelectionLimit = 9;

	// Token: 0x040029BC RID: 10684
	public int Selected;

	// Token: 0x040029BD RID: 10685
	public Transform Highlight;

	// Token: 0x040029BE RID: 10686
	public string path = string.Empty;

	// Token: 0x040029BF RID: 10687
	public AudioClip CustomMusic;
}
