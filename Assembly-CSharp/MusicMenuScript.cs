using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000370 RID: 880
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019BB RID: 6587 RVA: 0x00107ACC File Offset: 0x00105CCC
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

	// Token: 0x060019BC RID: 6588 RVA: 0x00107BF6 File Offset: 0x00105DF6
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

	// Token: 0x060019BD RID: 6589 RVA: 0x00107C08 File Offset: 0x00105E08
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

	// Token: 0x04002941 RID: 10561
	public InputManagerScript InputManager;

	// Token: 0x04002942 RID: 10562
	public PauseScreenScript PauseScreen;

	// Token: 0x04002943 RID: 10563
	public PromptBarScript PromptBar;

	// Token: 0x04002944 RID: 10564
	public GameObject AudioMenu;

	// Token: 0x04002945 RID: 10565
	public JukeboxScript Jukebox;

	// Token: 0x04002946 RID: 10566
	public int SelectionLimit = 9;

	// Token: 0x04002947 RID: 10567
	public int Selected;

	// Token: 0x04002948 RID: 10568
	public Transform Highlight;

	// Token: 0x04002949 RID: 10569
	public string path = string.Empty;

	// Token: 0x0400294A RID: 10570
	public AudioClip CustomMusic;
}
