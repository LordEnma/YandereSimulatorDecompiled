using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000373 RID: 883
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019DC RID: 6620 RVA: 0x0010A0E8 File Offset: 0x001082E8
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

	// Token: 0x060019DD RID: 6621 RVA: 0x0010A212 File Offset: 0x00108412
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

	// Token: 0x060019DE RID: 6622 RVA: 0x0010A224 File Offset: 0x00108424
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

	// Token: 0x040029AB RID: 10667
	public InputManagerScript InputManager;

	// Token: 0x040029AC RID: 10668
	public PauseScreenScript PauseScreen;

	// Token: 0x040029AD RID: 10669
	public PromptBarScript PromptBar;

	// Token: 0x040029AE RID: 10670
	public GameObject AudioMenu;

	// Token: 0x040029AF RID: 10671
	public JukeboxScript Jukebox;

	// Token: 0x040029B0 RID: 10672
	public int SelectionLimit = 9;

	// Token: 0x040029B1 RID: 10673
	public int Selected;

	// Token: 0x040029B2 RID: 10674
	public Transform Highlight;

	// Token: 0x040029B3 RID: 10675
	public string path = string.Empty;

	// Token: 0x040029B4 RID: 10676
	public AudioClip CustomMusic;
}
