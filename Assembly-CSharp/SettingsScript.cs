using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public QualityManagerScript QualityManager;

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public UILabel DrawDistanceLabel;

	public UILabel PostAliasingLabel;

	public UILabel LowDetailLabel;

	public UILabel AliasingLabel;

	public UILabel OutlinesLabel;

	public UILabel ParticleLabel;

	public UILabel BloomLabel;

	public UILabel FogLabel;

	public UILabel ToggleRunLabel;

	public UILabel FarAnimsLabel;

	public UILabel FPSCapLabel;

	public UILabel SensitivityLabel;

	public UILabel InvertAxisLabel;

	public UILabel DisableTutorialsLabel;

	public UILabel WindowedMode;

	public UILabel AmbientObscurance;

	public UILabel ShadowsLabel;

	public int SelectionLimit = 2;

	public int Selected = 1;

	public Transform CloudSystem;

	public Transform Highlight;

	public GameObject Background;

	public GameObject WarningMessage;

	private void Start()
	{
		Debug.Log("Does this run? Anywhere? Ever?");
	}

	private void Update()
	{
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
				OptionGlobals.ParticleCount++;
				QualityManager.UpdateParticles();
				UpdateText();
			}
			else if (InputManager.TappedLeft)
			{
				OptionGlobals.ParticleCount--;
				QualityManager.UpdateParticles();
				UpdateText();
			}
		}
		else if (Selected == 2)
		{
			if (InputManager.TappedRight || InputManager.TappedLeft)
			{
				OptionGlobals.DisableOutlines = !OptionGlobals.DisableOutlines;
				UpdateText();
				QualityManager.UpdateOutlines();
			}
		}
		else if (Selected == 3)
		{
			if (InputManager.TappedRight)
			{
				if (QualitySettings.antiAliasing > 0)
				{
					QualitySettings.antiAliasing *= 2;
				}
				else
				{
					QualitySettings.antiAliasing = 2;
				}
				UpdateText();
			}
			else if (InputManager.TappedLeft)
			{
				if (QualitySettings.antiAliasing > 0)
				{
					QualitySettings.antiAliasing /= 2;
				}
				else
				{
					QualitySettings.antiAliasing = 0;
				}
				UpdateText();
			}
		}
		else if (Selected == 4)
		{
			if (InputManager.TappedRight || InputManager.TappedLeft)
			{
				OptionGlobals.DisablePostAliasing = !OptionGlobals.DisablePostAliasing;
				UpdateText();
				QualityManager.UpdatePostAliasing();
			}
		}
		else if (Selected == 5)
		{
			if (InputManager.TappedRight || InputManager.TappedLeft)
			{
				OptionGlobals.DisableBloom = !OptionGlobals.DisableBloom;
				UpdateText();
				QualityManager.UpdateBloom();
			}
		}
		else if (Selected == 6)
		{
			if (InputManager.TappedRight)
			{
				OptionGlobals.LowDetailStudents--;
				QualityManager.UpdateLowDetailStudents();
				UpdateText();
			}
			else if (InputManager.TappedLeft)
			{
				OptionGlobals.LowDetailStudents++;
				QualityManager.UpdateLowDetailStudents();
				UpdateText();
			}
		}
		else if (Selected == 7)
		{
			if (InputManager.TappedRight)
			{
				OptionGlobals.DrawDistance += 10;
				QualityManager.UpdateDrawDistance();
				UpdateText();
			}
			else if (InputManager.TappedLeft)
			{
				OptionGlobals.DrawDistance -= 10;
				QualityManager.UpdateDrawDistance();
				UpdateText();
			}
		}
		else if (Selected == 8)
		{
			if (InputManager.TappedRight || InputManager.TappedLeft)
			{
				OptionGlobals.Fog = !OptionGlobals.Fog;
				UpdateText();
				QualityManager.UpdateFog();
			}
		}
		else if (Selected == 9)
		{
			if (InputManager.TappedRight || InputManager.TappedLeft)
			{
				OptionGlobals.ToggleRun = !OptionGlobals.ToggleRun;
				UpdateText();
				QualityManager.ToggleRun();
			}
		}
		else if (Selected == 10)
		{
			if (InputManager.TappedRight)
			{
				OptionGlobals.DisableFarAnimations++;
				QualityManager.UpdateAnims();
				UpdateText();
			}
			else if (InputManager.TappedLeft)
			{
				OptionGlobals.DisableFarAnimations--;
				QualityManager.UpdateAnims();
				UpdateText();
			}
		}
		else if (Selected == 11)
		{
			if (InputManager.TappedRight)
			{
				OptionGlobals.FPSIndex++;
				QualityManager.UpdateFPSIndex();
			}
			else if (InputManager.TappedLeft)
			{
				OptionGlobals.FPSIndex--;
				QualityManager.UpdateFPSIndex();
			}
			UpdateText();
		}
		else if (Selected == 12)
		{
			if (InputManager.TappedRight)
			{
				if (OptionGlobals.Sensitivity < 10)
				{
					OptionGlobals.Sensitivity++;
				}
			}
			else if (InputManager.TappedLeft && OptionGlobals.Sensitivity > 1)
			{
				OptionGlobals.Sensitivity--;
			}
			if (PauseScreen.RPGCamera != null)
			{
				PauseScreen.RPGCamera.sensitivity = OptionGlobals.Sensitivity;
			}
			UpdateText();
		}
		else if (Selected == 13)
		{
			if (InputManager.TappedRight || InputManager.TappedLeft)
			{
				OptionGlobals.InvertAxisY = !OptionGlobals.InvertAxisY;
				if (PauseScreen.RPGCamera != null)
				{
					PauseScreen.RPGCamera.invertAxisY = OptionGlobals.InvertAxisY;
				}
				UpdateText();
			}
			UpdateText();
		}
		else if (Selected == 14)
		{
			if (InputManager.TappedRight || InputManager.TappedLeft)
			{
				OptionGlobals.TutorialsOff = !OptionGlobals.TutorialsOff;
				if (SceneManager.GetActiveScene().name == "SchoolScene")
				{
					StudentManager.TutorialWindow.enabled = !OptionGlobals.TutorialsOff;
				}
				UpdateText();
			}
			UpdateText();
		}
		else if (Selected == 15)
		{
			if (InputManager.TappedRight || InputManager.TappedLeft)
			{
				Screen.SetResolution(Screen.width, Screen.height, !Screen.fullScreen);
				UpdateText();
			}
			UpdateText();
		}
		else if (Selected == 16)
		{
			if (InputManager.TappedRight || InputManager.TappedLeft)
			{
				OptionGlobals.DisableObscurance = !OptionGlobals.DisableObscurance;
				QualityManager.UpdateObscurance();
				UpdateText();
			}
			UpdateText();
		}
		else if (Selected == 17)
		{
			WarningMessage.SetActive(value: true);
			if (InputManager.TappedRight || InputManager.TappedLeft)
			{
				OptionGlobals.EnableShadows = !OptionGlobals.EnableShadows;
				QualityManager.UpdateShadows();
				UpdateText();
			}
			UpdateText();
		}
		if (Selected != 17)
		{
			WarningMessage.SetActive(value: false);
		}
		if (Input.GetKeyDown("l"))
		{
			OptionGlobals.ParticleCount = 1;
			OptionGlobals.DisableOutlines = true;
			QualitySettings.antiAliasing = 0;
			OptionGlobals.DisablePostAliasing = true;
			OptionGlobals.DisableBloom = true;
			OptionGlobals.LowDetailStudents = 1;
			OptionGlobals.DrawDistance = 50;
			OptionGlobals.EnableShadows = false;
			OptionGlobals.DisableFarAnimations = 1;
			OptionGlobals.RimLight = false;
			OptionGlobals.DepthOfField = false;
			QualityManager.UpdateFog();
			QualityManager.UpdateAnims();
			QualityManager.UpdateBloom();
			QualityManager.UpdateFPSIndex();
			QualityManager.UpdateShadows();
			QualityManager.UpdateParticles();
			QualityManager.UpdatePostAliasing();
			QualityManager.UpdateDrawDistance();
			QualityManager.UpdateLowDetailStudents();
			QualityManager.UpdateOutlines();
			UpdateText();
		}
		if (Input.GetButtonDown("B"))
		{
			WarningMessage.SetActive(value: false);
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[4].text = "Choose";
			PromptBar.UpdateButtons();
			if (PauseScreen.Yandere.Blur != null)
			{
				PauseScreen.Yandere.Blur.enabled = true;
			}
			PauseScreen.MainMenu.SetActive(value: true);
			PauseScreen.Sideways = false;
			PauseScreen.PressedB = true;
			base.gameObject.SetActive(value: false);
		}
	}

	public void UpdateText()
	{
		if (OptionGlobals.ParticleCount == 3)
		{
			ParticleLabel.text = "High";
		}
		else if (OptionGlobals.ParticleCount == 2)
		{
			ParticleLabel.text = "Low";
		}
		else if (OptionGlobals.ParticleCount == 1)
		{
			ParticleLabel.text = "None";
		}
		FPSCapLabel.text = QualityManagerScript.FPSStrings[OptionGlobals.FPSIndex];
		OutlinesLabel.text = (OptionGlobals.DisableOutlines ? "Off" : "On");
		AliasingLabel.text = QualitySettings.antiAliasing + "x";
		PostAliasingLabel.text = (OptionGlobals.DisablePostAliasing ? "Off" : "On");
		BloomLabel.text = (OptionGlobals.DisableBloom ? "Off" : "On");
		LowDetailLabel.text = ((OptionGlobals.LowDetailStudents == 0) ? "Off" : (OptionGlobals.LowDetailStudents * 10 + "m"));
		FarAnimsLabel.text = ((OptionGlobals.DisableFarAnimations == 0) ? "Off" : (OptionGlobals.DisableFarAnimations * 5 + "m"));
		DrawDistanceLabel.text = OptionGlobals.DrawDistance + "m";
		FogLabel.text = (OptionGlobals.Fog ? "On" : "Off");
		ToggleRunLabel.text = (OptionGlobals.ToggleRun ? "Toggle" : "Hold");
		SensitivityLabel.text = OptionGlobals.Sensitivity.ToString() ?? "";
		InvertAxisLabel.text = (OptionGlobals.InvertAxisY ? "Yes" : "No");
		DisableTutorialsLabel.text = (OptionGlobals.TutorialsOff ? "Yes" : "No");
		WindowedMode.text = (Screen.fullScreen ? "No" : "Yes");
		AmbientObscurance.text = (OptionGlobals.DisableObscurance ? "Off" : "On");
		ShadowsLabel.text = (OptionGlobals.EnableShadows ? "Yes" : "No");
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
		Highlight.localPosition = new Vector3(Highlight.localPosition.x, 430f - 50f * (float)Selected, Highlight.localPosition.z);
	}
}
