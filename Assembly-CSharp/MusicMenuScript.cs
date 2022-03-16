using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000372 RID: 882
public class MusicMenuScript : MonoBehaviour
{
	// Token: 0x060019D6 RID: 6614 RVA: 0x00109A2C File Offset: 0x00107C2C
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

	// Token: 0x060019D7 RID: 6615 RVA: 0x00109B56 File Offset: 0x00107D56
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

	// Token: 0x060019D8 RID: 6616 RVA: 0x00109B68 File Offset: 0x00107D68
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

	// Token: 0x04002998 RID: 10648
	public InputManagerScript InputManager;

	// Token: 0x04002999 RID: 10649
	public PauseScreenScript PauseScreen;

	// Token: 0x0400299A RID: 10650
	public PromptBarScript PromptBar;

	// Token: 0x0400299B RID: 10651
	public GameObject AudioMenu;

	// Token: 0x0400299C RID: 10652
	public JukeboxScript Jukebox;

	// Token: 0x0400299D RID: 10653
	public int SelectionLimit = 9;

	// Token: 0x0400299E RID: 10654
	public int Selected;

	// Token: 0x0400299F RID: 10655
	public Transform Highlight;

	// Token: 0x040029A0 RID: 10656
	public string path = string.Empty;

	// Token: 0x040029A1 RID: 10657
	public AudioClip CustomMusic;
}
