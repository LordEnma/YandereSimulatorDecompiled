using System.Collections;
using UnityEngine;

public class MusicMenuScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public GameObject AudioMenu;

	public JukeboxScript Jukebox;

	public int SelectionLimit = 9;

	public int Selected;

	public Transform Highlight;

	public string path = string.Empty;

	public AudioClip CustomMusic;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			AudioMenu.SetActive(value: true);
			base.gameObject.SetActive(value: false);
		}
		if (InputManager.TappedUp)
		{
			Selected--;
			UpdateHighlight();
		}
		else if (InputManager.TappedDown)
		{
			Selected++;
			UpdateHighlight();
		}
		if (Input.GetButtonDown("A"))
		{
			StartCoroutine(DownloadCoroutine());
		}
		if (Input.GetButtonDown("B"))
		{
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[4].text = "Choose";
			PromptBar.UpdateButtons();
			PauseScreen.MainMenu.SetActive(value: true);
			PauseScreen.Sideways = false;
			PauseScreen.PressedB = true;
			base.gameObject.SetActive(value: false);
		}
	}

	private IEnumerator DownloadCoroutine()
	{
		WWW CurrentDownload = new WWW("File:///" + Application.streamingAssetsPath + "/Music/track" + Selected + ".ogg");
		yield return CurrentDownload;
		CustomMusic = CurrentDownload.GetAudioClipCompressed();
		Jukebox.Custom.clip = CustomMusic;
		Jukebox.PlayCustom();
	}

	private void UpdateHighlight()
	{
		if (Selected < 0)
		{
			Selected = SelectionLimit;
		}
		else if (Selected > SelectionLimit)
		{
			Selected = 0;
		}
		Highlight.localPosition = new Vector3(Highlight.localPosition.x, 365f - 80f * (float)Selected, Highlight.localPosition.z);
	}
}
