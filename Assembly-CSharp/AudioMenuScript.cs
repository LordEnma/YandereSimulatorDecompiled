using UnityEngine;

public class AudioMenuScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public JukeboxScript Jukebox;

	public UILabel CurrentTrackLabel;

	public UILabel MusicVolumeLabel;

	public UILabel SubtitlesOnOffLabel;

	public UILabel VolumeMessage;

	public UIPanel SubtitlePanel;

	public int SelectionLimit = 5;

	public int Selected = 1;

	public Transform Highlight;

	public GameObject CustomMusicMenu;

	public float ABCVolume;

	public bool ABC;

	private void Start()
	{
		UpdateText();
		ABC = GameGlobals.AlphabetMode;
		if (ABC)
		{
			VolumeMessage.enabled = true;
			Debug.Log(PauseScreen);
			Debug.Log(PauseScreen.Yandere);
			Debug.Log(PauseScreen.Yandere.StudentManager);
			Debug.Log(PauseScreen.Yandere.StudentManager.Alphabet);
			Debug.Log(PauseScreen.Yandere.StudentManager.Alphabet.MusicPlayer);
			ABCVolume = PauseScreen.Yandere.StudentManager.Alphabet.MusicPlayer.volume;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			CustomMusicMenu.SetActive(value: true);
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
		if (Selected == 1)
		{
			if (InputManager.TappedRight)
			{
				Jukebox.StartStopMusic();
				Jukebox.StartStopMusic();
				UpdateText();
			}
			else if (InputManager.TappedLeft)
			{
				Jukebox.BGM -= 2;
				Jukebox.StartStopMusic();
				Jukebox.StartStopMusic();
				UpdateText();
			}
		}
		else if (Selected == 2)
		{
			if (!ABC)
			{
				if (InputManager.TappedRight)
				{
					if (Jukebox.Volume < 1f)
					{
						Jukebox.Volume += 0.05f;
					}
					UpdateText();
				}
				else if (InputManager.TappedLeft)
				{
					if (Jukebox.Volume > 0f)
					{
						Jukebox.Volume -= 0.05f;
					}
					if (Jukebox.Volume < 0.05f)
					{
						Jukebox.Volume = 0f;
					}
					UpdateText();
				}
			}
			else
			{
				if (InputManager.TappedRight)
				{
					if (ABCVolume < 1f)
					{
						ABCVolume += 0.05f;
					}
					UpdateText();
				}
				else if (InputManager.TappedLeft)
				{
					if (ABCVolume > 0f)
					{
						ABCVolume -= 0.05f;
					}
					if (ABCVolume < 0.05f)
					{
						ABCVolume = 0f;
					}
					UpdateText();
				}
				PauseScreen.Yandere.StudentManager.Alphabet.MusicPlayer.volume = ABCVolume;
			}
		}
		else
		{
			_ = Selected;
			_ = 3;
		}
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[4].text = "Choose";
			PromptBar.UpdateButtons();
			PauseScreen.Yandere.Blur.enabled = true;
			PauseScreen.MainMenu.SetActive(value: true);
			PauseScreen.Sideways = false;
			PauseScreen.PressedB = true;
			base.gameObject.SetActive(value: false);
		}
	}

	public void UpdateText()
	{
		if (Jukebox != null)
		{
			CurrentTrackLabel.text = Jukebox.BGM.ToString() ?? "";
			if (!ABC)
			{
				MusicVolumeLabel.text = (Jukebox.Volume * 10f).ToString("F1") ?? "";
			}
			else
			{
				MusicVolumeLabel.text = (ABCVolume * 10f).ToString("F1") ?? "";
			}
			if (SubtitlePanel.alpha == 1f)
			{
				SubtitlesOnOffLabel.text = "On";
			}
			else
			{
				SubtitlesOnOffLabel.text = "Off";
			}
			AudioGlobals.MusicVolume = Jukebox.Volume;
		}
	}

	private void UpdateHighlight()
	{
		if (Selected == 0)
		{
			Selected = SelectionLimit;
		}
		else if (Selected > SelectionLimit)
		{
			Selected = 1;
		}
		Highlight.localPosition = new Vector3(Highlight.localPosition.x, 440f - 60f * (float)Selected, Highlight.localPosition.z);
	}
}
