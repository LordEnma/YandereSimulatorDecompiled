using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000374 RID: 884
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019EA RID: 6634 RVA: 0x0010A978 File Offset: 0x00108B78
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

	// Token: 0x060019EB RID: 6635 RVA: 0x0010AAA2 File Offset: 0x00108CA2
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

	// Token: 0x060019EC RID: 6636 RVA: 0x0010AAB4 File Offset: 0x00108CB4
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

	// Token: 0x040029BF RID: 10687
	public InputManagerScript InputManager;

	// Token: 0x040029C0 RID: 10688
	public PauseScreenScript PauseScreen;

	// Token: 0x040029C1 RID: 10689
	public PromptBarScript PromptBar;

	// Token: 0x040029C2 RID: 10690
	public GameObject AudioMenu;

	// Token: 0x040029C3 RID: 10691
	public JukeboxScript Jukebox;

	// Token: 0x040029C4 RID: 10692
	public int SelectionLimit = 9;

	// Token: 0x040029C5 RID: 10693
	public int Selected;

	// Token: 0x040029C6 RID: 10694
	public Transform Highlight;

	// Token: 0x040029C7 RID: 10695
	public string path = string.Empty;

	// Token: 0x040029C8 RID: 10696
	public AudioClip CustomMusic;
}
