using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000375 RID: 885
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019F1 RID: 6641 RVA: 0x0010B3FC File Offset: 0x001095FC
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

	// Token: 0x060019F2 RID: 6642 RVA: 0x0010B526 File Offset: 0x00109726
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

	// Token: 0x060019F3 RID: 6643 RVA: 0x0010B538 File Offset: 0x00109738
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

	// Token: 0x040029D8 RID: 10712
	public InputManagerScript InputManager;

	// Token: 0x040029D9 RID: 10713
	public PauseScreenScript PauseScreen;

	// Token: 0x040029DA RID: 10714
	public PromptBarScript PromptBar;

	// Token: 0x040029DB RID: 10715
	public GameObject AudioMenu;

	// Token: 0x040029DC RID: 10716
	public JukeboxScript Jukebox;

	// Token: 0x040029DD RID: 10717
	public int SelectionLimit = 9;

	// Token: 0x040029DE RID: 10718
	public int Selected;

	// Token: 0x040029DF RID: 10719
	public Transform Highlight;

	// Token: 0x040029E0 RID: 10720
	public string path = string.Empty;

	// Token: 0x040029E1 RID: 10721
	public AudioClip CustomMusic;
}
