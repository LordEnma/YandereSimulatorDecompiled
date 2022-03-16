using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000421 RID: 1057
public class SettingsScript : MonoBehaviour
{
	// Token: 0x06001C92 RID: 7314 RVA: 0x0014E53C File Offset: 0x0014C73C
	private void Update()
	{
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
		if (this.Selected == 1)
		{
			if (this.InputManager.TappedRight)
			{
				OptionGlobals.ParticleCount++;
				this.QualityManager.UpdateParticles();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				OptionGlobals.ParticleCount--;
				this.QualityManager.UpdateParticles();
				this.UpdateText();
			}
		}
		else if (this.Selected == 2)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.DisableOutlines = !OptionGlobals.DisableOutlines;
				this.UpdateText();
				this.QualityManager.UpdateOutlines();
			}
		}
		else if (this.Selected == 3)
		{
			if (this.InputManager.TappedRight)
			{
				if (QualitySettings.antiAliasing > 0)
				{
					QualitySettings.antiAliasing *= 2;
				}
				else
				{
					QualitySettings.antiAliasing = 2;
				}
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				if (QualitySettings.antiAliasing > 0)
				{
					QualitySettings.antiAliasing /= 2;
				}
				else
				{
					QualitySettings.antiAliasing = 0;
				}
				this.UpdateText();
			}
		}
		else if (this.Selected == 4)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.DisablePostAliasing = !OptionGlobals.DisablePostAliasing;
				this.UpdateText();
				this.QualityManager.UpdatePostAliasing();
			}
		}
		else if (this.Selected == 5)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.DisableBloom = !OptionGlobals.DisableBloom;
				this.UpdateText();
				this.QualityManager.UpdateBloom();
			}
		}
		else if (this.Selected == 6)
		{
			if (this.InputManager.TappedRight)
			{
				OptionGlobals.LowDetailStudents--;
				this.QualityManager.UpdateLowDetailStudents();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				OptionGlobals.LowDetailStudents++;
				this.QualityManager.UpdateLowDetailStudents();
				this.UpdateText();
			}
		}
		else if (this.Selected == 7)
		{
			if (this.InputManager.TappedRight)
			{
				OptionGlobals.DrawDistance += 10;
				this.QualityManager.UpdateDrawDistance();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				OptionGlobals.DrawDistance -= 10;
				this.QualityManager.UpdateDrawDistance();
				this.UpdateText();
			}
		}
		else if (this.Selected == 8)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.Fog = !OptionGlobals.Fog;
				this.UpdateText();
				this.QualityManager.UpdateFog();
			}
		}
		else if (this.Selected == 9)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.ToggleRun = !OptionGlobals.ToggleRun;
				this.UpdateText();
				this.QualityManager.ToggleRun();
			}
		}
		else if (this.Selected == 10)
		{
			if (this.InputManager.TappedRight)
			{
				OptionGlobals.DisableFarAnimations++;
				this.QualityManager.UpdateAnims();
				this.UpdateText();
			}
			else if (this.InputManager.TappedLeft)
			{
				OptionGlobals.DisableFarAnimations--;
				this.QualityManager.UpdateAnims();
				this.UpdateText();
			}
		}
		else if (this.Selected == 11)
		{
			if (this.InputManager.TappedRight)
			{
				OptionGlobals.FPSIndex++;
				this.QualityManager.UpdateFPSIndex();
			}
			else if (this.InputManager.TappedLeft)
			{
				OptionGlobals.FPSIndex--;
				this.QualityManager.UpdateFPSIndex();
			}
			this.UpdateText();
		}
		else if (this.Selected == 12)
		{
			if (this.InputManager.TappedRight)
			{
				if (OptionGlobals.Sensitivity < 10)
				{
					OptionGlobals.Sensitivity++;
				}
			}
			else if (this.InputManager.TappedLeft && OptionGlobals.Sensitivity > 1)
			{
				OptionGlobals.Sensitivity--;
			}
			if (this.PauseScreen.RPGCamera != null)
			{
				this.PauseScreen.RPGCamera.sensitivity = (float)OptionGlobals.Sensitivity;
			}
			this.UpdateText();
		}
		else if (this.Selected == 13)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.InvertAxisY = !OptionGlobals.InvertAxisY;
				if (this.PauseScreen.RPGCamera != null)
				{
					this.PauseScreen.RPGCamera.invertAxisY = OptionGlobals.InvertAxisY;
				}
				this.UpdateText();
			}
			this.UpdateText();
		}
		else if (this.Selected == 14)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.TutorialsOff = !OptionGlobals.TutorialsOff;
				if (SceneManager.GetActiveScene().name == "SchoolScene")
				{
					this.StudentManager.TutorialWindow.enabled = !OptionGlobals.TutorialsOff;
				}
				this.UpdateText();
			}
			this.UpdateText();
		}
		else if (this.Selected == 15)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				Screen.SetResolution(Screen.width, Screen.height, !Screen.fullScreen);
				this.UpdateText();
			}
			this.UpdateText();
		}
		else if (this.Selected == 16)
		{
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.DisableObscurance = !OptionGlobals.DisableObscurance;
				this.QualityManager.UpdateObscurance();
				this.UpdateText();
			}
			this.UpdateText();
		}
		else if (this.Selected == 17)
		{
			this.WarningMessage.SetActive(true);
			if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
			{
				OptionGlobals.EnableShadows = !OptionGlobals.EnableShadows;
				this.QualityManager.UpdateShadows();
				this.UpdateText();
			}
			this.UpdateText();
		}
		if (this.Selected != 17)
		{
			this.WarningMessage.SetActive(false);
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
			this.QualityManager.UpdateFog();
			this.QualityManager.UpdateAnims();
			this.QualityManager.UpdateBloom();
			this.QualityManager.UpdateFPSIndex();
			this.QualityManager.UpdateShadows();
			this.QualityManager.UpdateParticles();
			this.QualityManager.UpdatePostAliasing();
			this.QualityManager.UpdateDrawDistance();
			this.QualityManager.UpdateLowDetailStudents();
			this.QualityManager.UpdateOutlines();
			this.UpdateText();
		}
		if (Input.GetButtonDown("B"))
		{
			this.WarningMessage.SetActive(false);
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			if (this.PauseScreen.Yandere.Blur != null)
			{
				this.PauseScreen.Yandere.Blur.enabled = true;
			}
			this.PauseScreen.MainMenu.SetActive(true);
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001C93 RID: 7315 RVA: 0x0014ED78 File Offset: 0x0014CF78
	public void UpdateText()
	{
		if (OptionGlobals.ParticleCount == 3)
		{
			this.ParticleLabel.text = "High";
		}
		else if (OptionGlobals.ParticleCount == 2)
		{
			this.ParticleLabel.text = "Low";
		}
		else if (OptionGlobals.ParticleCount == 1)
		{
			this.ParticleLabel.text = "None";
		}
		this.FPSCapLabel.text = QualityManagerScript.FPSStrings[OptionGlobals.FPSIndex];
		this.OutlinesLabel.text = (OptionGlobals.DisableOutlines ? "Off" : "On");
		this.AliasingLabel.text = QualitySettings.antiAliasing.ToString() + "x";
		this.PostAliasingLabel.text = (OptionGlobals.DisablePostAliasing ? "Off" : "On");
		this.BloomLabel.text = (OptionGlobals.DisableBloom ? "Off" : "On");
		this.LowDetailLabel.text = ((OptionGlobals.LowDetailStudents == 0) ? "Off" : ((OptionGlobals.LowDetailStudents * 10).ToString() + "m"));
		this.FarAnimsLabel.text = ((OptionGlobals.DisableFarAnimations == 0) ? "Off" : ((OptionGlobals.DisableFarAnimations * 5).ToString() + "m"));
		this.DrawDistanceLabel.text = OptionGlobals.DrawDistance.ToString() + "m";
		this.FogLabel.text = (OptionGlobals.Fog ? "On" : "Off");
		this.ToggleRunLabel.text = (OptionGlobals.ToggleRun ? "Toggle" : "Hold");
		this.SensitivityLabel.text = (OptionGlobals.Sensitivity.ToString() ?? "");
		this.InvertAxisLabel.text = (OptionGlobals.InvertAxisY ? "Yes" : "No");
		this.DisableTutorialsLabel.text = (OptionGlobals.TutorialsOff ? "Yes" : "No");
		this.WindowedMode.text = (Screen.fullScreen ? "No" : "Yes");
		this.AmbientObscurance.text = (OptionGlobals.DisableObscurance ? "Off" : "On");
		this.ShadowsLabel.text = (OptionGlobals.EnableShadows ? "Yes" : "No");
	}

	// Token: 0x06001C94 RID: 7316 RVA: 0x0014EFE0 File Offset: 0x0014D1E0
	private void UpdateHighlight()
	{
		if (this.Selected == 0)
		{
			this.Selected = this.SelectionLimit;
		}
		else if (this.Selected > this.SelectionLimit)
		{
			this.Selected = 1;
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 430f - 50f * (float)this.Selected, this.Highlight.localPosition.z);
	}

	// Token: 0x040032E2 RID: 13026
	public StudentManagerScript StudentManager;

	// Token: 0x040032E3 RID: 13027
	public QualityManagerScript QualityManager;

	// Token: 0x040032E4 RID: 13028
	public InputManagerScript InputManager;

	// Token: 0x040032E5 RID: 13029
	public PauseScreenScript PauseScreen;

	// Token: 0x040032E6 RID: 13030
	public PromptBarScript PromptBar;

	// Token: 0x040032E7 RID: 13031
	public UILabel DrawDistanceLabel;

	// Token: 0x040032E8 RID: 13032
	public UILabel PostAliasingLabel;

	// Token: 0x040032E9 RID: 13033
	public UILabel LowDetailLabel;

	// Token: 0x040032EA RID: 13034
	public UILabel AliasingLabel;

	// Token: 0x040032EB RID: 13035
	public UILabel OutlinesLabel;

	// Token: 0x040032EC RID: 13036
	public UILabel ParticleLabel;

	// Token: 0x040032ED RID: 13037
	public UILabel BloomLabel;

	// Token: 0x040032EE RID: 13038
	public UILabel FogLabel;

	// Token: 0x040032EF RID: 13039
	public UILabel ToggleRunLabel;

	// Token: 0x040032F0 RID: 13040
	public UILabel FarAnimsLabel;

	// Token: 0x040032F1 RID: 13041
	public UILabel FPSCapLabel;

	// Token: 0x040032F2 RID: 13042
	public UILabel SensitivityLabel;

	// Token: 0x040032F3 RID: 13043
	public UILabel InvertAxisLabel;

	// Token: 0x040032F4 RID: 13044
	public UILabel DisableTutorialsLabel;

	// Token: 0x040032F5 RID: 13045
	public UILabel WindowedMode;

	// Token: 0x040032F6 RID: 13046
	public UILabel AmbientObscurance;

	// Token: 0x040032F7 RID: 13047
	public UILabel ShadowsLabel;

	// Token: 0x040032F8 RID: 13048
	public int SelectionLimit = 2;

	// Token: 0x040032F9 RID: 13049
	public int Selected = 1;

	// Token: 0x040032FA RID: 13050
	public Transform CloudSystem;

	// Token: 0x040032FB RID: 13051
	public Transform Highlight;

	// Token: 0x040032FC RID: 13052
	public GameObject Background;

	// Token: 0x040032FD RID: 13053
	public GameObject WarningMessage;
}
