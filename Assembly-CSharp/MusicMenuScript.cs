using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000370 RID: 880
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019BC RID: 6588 RVA: 0x00107FC0 File Offset: 0x001061C0
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

	// Token: 0x060019BD RID: 6589 RVA: 0x001080EA File Offset: 0x001062EA
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

	// Token: 0x060019BE RID: 6590 RVA: 0x001080FC File Offset: 0x001062FC
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

	// Token: 0x04002948 RID: 10568
	public InputManagerScript InputManager;

	// Token: 0x04002949 RID: 10569
	public PauseScreenScript PauseScreen;

	// Token: 0x0400294A RID: 10570
	public PromptBarScript PromptBar;

	// Token: 0x0400294B RID: 10571
	public GameObject AudioMenu;

	// Token: 0x0400294C RID: 10572
	public JukeboxScript Jukebox;

	// Token: 0x0400294D RID: 10573
	public int SelectionLimit = 9;

	// Token: 0x0400294E RID: 10574
	public int Selected;

	// Token: 0x0400294F RID: 10575
	public Transform Highlight;

	// Token: 0x04002950 RID: 10576
	public string path = string.Empty;

	// Token: 0x04002951 RID: 10577
	public AudioClip CustomMusic;
}
