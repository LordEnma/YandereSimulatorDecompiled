using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000426 RID: 1062
public class SettingsScript : MonoBehaviour
{
	// Token: 0x06001CAD RID: 7341 RVA: 0x0014FF6C File Offset: 0x0014E16C
	private void Start()
	{
		Debug.Log("Does this run? Anywhere? Ever?");
	}

	// Token: 0x06001CAE RID: 7342 RVA: 0x0014FF78 File Offset: 0x0014E178
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

	// Token: 0x06001CAF RID: 7343 RVA: 0x001507B4 File Offset: 0x0014E9B4
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

	// Token: 0x06001CB0 RID: 7344 RVA: 0x00150A1C File Offset: 0x0014EC1C
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

	// Token: 0x0400331B RID: 13083
	public StudentManagerScript StudentManager;

	// Token: 0x0400331C RID: 13084
	public QualityManagerScript QualityManager;

	// Token: 0x0400331D RID: 13085
	public InputManagerScript InputManager;

	// Token: 0x0400331E RID: 13086
	public PauseScreenScript PauseScreen;

	// Token: 0x0400331F RID: 13087
	public PromptBarScript PromptBar;

	// Token: 0x04003320 RID: 13088
	public UILabel DrawDistanceLabel;

	// Token: 0x04003321 RID: 13089
	public UILabel PostAliasingLabel;

	// Token: 0x04003322 RID: 13090
	public UILabel LowDetailLabel;

	// Token: 0x04003323 RID: 13091
	public UILabel AliasingLabel;

	// Token: 0x04003324 RID: 13092
	public UILabel OutlinesLabel;

	// Token: 0x04003325 RID: 13093
	public UILabel ParticleLabel;

	// Token: 0x04003326 RID: 13094
	public UILabel BloomLabel;

	// Token: 0x04003327 RID: 13095
	public UILabel FogLabel;

	// Token: 0x04003328 RID: 13096
	public UILabel ToggleRunLabel;

	// Token: 0x04003329 RID: 13097
	public UILabel FarAnimsLabel;

	// Token: 0x0400332A RID: 13098
	public UILabel FPSCapLabel;

	// Token: 0x0400332B RID: 13099
	public UILabel SensitivityLabel;

	// Token: 0x0400332C RID: 13100
	public UILabel InvertAxisLabel;

	// Token: 0x0400332D RID: 13101
	public UILabel DisableTutorialsLabel;

	// Token: 0x0400332E RID: 13102
	public UILabel WindowedMode;

	// Token: 0x0400332F RID: 13103
	public UILabel AmbientObscurance;

	// Token: 0x04003330 RID: 13104
	public UILabel ShadowsLabel;

	// Token: 0x04003331 RID: 13105
	public int SelectionLimit = 2;

	// Token: 0x04003332 RID: 13106
	public int Selected = 1;

	// Token: 0x04003333 RID: 13107
	public Transform CloudSystem;

	// Token: 0x04003334 RID: 13108
	public Transform Highlight;

	// Token: 0x04003335 RID: 13109
	public GameObject Background;

	// Token: 0x04003336 RID: 13110
	public GameObject WarningMessage;
}
