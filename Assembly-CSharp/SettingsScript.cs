using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000425 RID: 1061
public class SettingsScript : MonoBehaviour
{
	// Token: 0x06001CA2 RID: 7330 RVA: 0x0014F354 File Offset: 0x0014D554
	private void Start()
	{
		Debug.Log("Does this run? Anywhere? Ever?");
	}

	// Token: 0x06001CA3 RID: 7331 RVA: 0x0014F360 File Offset: 0x0014D560
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

	// Token: 0x06001CA4 RID: 7332 RVA: 0x0014FB9C File Offset: 0x0014DD9C
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

	// Token: 0x06001CA5 RID: 7333 RVA: 0x0014FE04 File Offset: 0x0014E004
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

	// Token: 0x04003301 RID: 13057
	public StudentManagerScript StudentManager;

	// Token: 0x04003302 RID: 13058
	public QualityManagerScript QualityManager;

	// Token: 0x04003303 RID: 13059
	public InputManagerScript InputManager;

	// Token: 0x04003304 RID: 13060
	public PauseScreenScript PauseScreen;

	// Token: 0x04003305 RID: 13061
	public PromptBarScript PromptBar;

	// Token: 0x04003306 RID: 13062
	public UILabel DrawDistanceLabel;

	// Token: 0x04003307 RID: 13063
	public UILabel PostAliasingLabel;

	// Token: 0x04003308 RID: 13064
	public UILabel LowDetailLabel;

	// Token: 0x04003309 RID: 13065
	public UILabel AliasingLabel;

	// Token: 0x0400330A RID: 13066
	public UILabel OutlinesLabel;

	// Token: 0x0400330B RID: 13067
	public UILabel ParticleLabel;

	// Token: 0x0400330C RID: 13068
	public UILabel BloomLabel;

	// Token: 0x0400330D RID: 13069
	public UILabel FogLabel;

	// Token: 0x0400330E RID: 13070
	public UILabel ToggleRunLabel;

	// Token: 0x0400330F RID: 13071
	public UILabel FarAnimsLabel;

	// Token: 0x04003310 RID: 13072
	public UILabel FPSCapLabel;

	// Token: 0x04003311 RID: 13073
	public UILabel SensitivityLabel;

	// Token: 0x04003312 RID: 13074
	public UILabel InvertAxisLabel;

	// Token: 0x04003313 RID: 13075
	public UILabel DisableTutorialsLabel;

	// Token: 0x04003314 RID: 13076
	public UILabel WindowedMode;

	// Token: 0x04003315 RID: 13077
	public UILabel AmbientObscurance;

	// Token: 0x04003316 RID: 13078
	public UILabel ShadowsLabel;

	// Token: 0x04003317 RID: 13079
	public int SelectionLimit = 2;

	// Token: 0x04003318 RID: 13080
	public int Selected = 1;

	// Token: 0x04003319 RID: 13081
	public Transform CloudSystem;

	// Token: 0x0400331A RID: 13082
	public Transform Highlight;

	// Token: 0x0400331B RID: 13083
	public GameObject Background;

	// Token: 0x0400331C RID: 13084
	public GameObject WarningMessage;
}
