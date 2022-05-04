using System;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x020003D8 RID: 984
public class ResolutionScript : MonoBehaviour
{
	// Token: 0x06001B96 RID: 7062 RVA: 0x00138B38 File Offset: 0x00136D38
	private void Start()
	{
		if (Screen.width < 1280 || Screen.height < 720)
		{
			Screen.SetResolution(1280, 720, false);
		}
		this.Darkness.color = new Color(1f, 1f, 1f, 1f);
		Cursor.visible = false;
		Screen.fullScreen = false;
		Screen.SetResolution(Screen.width, Screen.height, false);
		this.ResolutionLabel.text = Screen.width.ToString() + " x " + Screen.height.ToString();
		this.QualityLabel.text = (this.Qualities[QualitySettings.GetQualityLevel()] ?? "");
		this.FullScreenLabel.text = "No";
		Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
		this.ResetGraphicsToDefault();
		Debug.Log(string.Concat(new string[]
		{
			"ResolutionScene. GameGlobals.Profile is ",
			GameGlobals.Profile.ToString(),
			". GameGlobals.Eighties is ",
			GameGlobals.Eighties.ToString(),
			"."
		}));
		Debug.Log("ResolutionScene. DepthOfField settings are: " + OptionGlobals.DepthOfField.ToString());
	}

	// Token: 0x06001B97 RID: 7063 RVA: 0x00138C8C File Offset: 0x00136E8C
	private void Update()
	{
		if (Screen.width < 1280 || Screen.height < 720)
		{
			Screen.SetResolution(1280, 720, false);
			this.ResolutionLabel.text = Screen.width.ToString() + " x " + Screen.height.ToString();
		}
		if (this.FadeOut)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
			if (this.Alpha == 1f)
			{
				SceneManager.LoadScene("WelcomeScene");
				Debug.Log("Leaving ResolutionScene, DepthOfField settings are: " + OptionGlobals.DepthOfField.ToString());
				Debug.Log(string.Concat(new string[]
				{
					"Leaving ResolutionScene. GameGlobals.Profile is ",
					GameGlobals.Profile.ToString(),
					". GameGlobals.Eighties is ",
					GameGlobals.Eighties.ToString(),
					"."
				}));
			}
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
		}
		this.Darkness.color = new Color(1f, 1f, 1f, this.Alpha);
		if (this.Alpha == 0f)
		{
			if (this.InputManager.TappedDown)
			{
				this.ID++;
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				this.UpdateHighlight();
			}
			if (this.ID == 1)
			{
				if (this.InputManager.TappedRight)
				{
					this.ResID++;
					if (this.ResID == this.Widths.Length)
					{
						this.ResID = 0;
					}
					this.UpdateRes();
				}
				else if (this.InputManager.TappedLeft)
				{
					this.ResID--;
					if (this.ResID < 0)
					{
						this.ResID = this.Widths.Length - 1;
					}
					this.UpdateRes();
				}
			}
			else if (this.ID == 2)
			{
				if (this.InputManager.TappedRight || this.InputManager.TappedLeft)
				{
					this.FullScreen = !this.FullScreen;
					if (this.FullScreen)
					{
						this.FullScreenLabel.text = "Yes";
					}
					else
					{
						this.FullScreenLabel.text = "No";
					}
					Screen.SetResolution(Screen.width, Screen.height, this.FullScreen);
				}
			}
			else if (this.ID == 3)
			{
				if (this.InputManager.TappedRight)
				{
					this.QualityID++;
					if (this.QualityID == this.Qualities.Length)
					{
						this.QualityID = 0;
					}
					this.UpdateQuality();
				}
				else if (this.InputManager.TappedLeft)
				{
					this.QualityID--;
					if (this.QualityID < 0)
					{
						this.QualityID = this.Qualities.Length - 1;
					}
					this.UpdateQuality();
				}
			}
			else if (this.ID == 4 && Input.GetButtonUp("A"))
			{
				this.FadeOut = true;
			}
		}
		this.Highlight.localPosition = Vector3.Lerp(this.Highlight.localPosition, new Vector3(-307.5f, (float)(250 - this.ID * 100), 0f), Time.deltaTime * 10f);
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			SceneManager.LoadScene("NewTitleScene");
		}
	}

	// Token: 0x06001B98 RID: 7064 RVA: 0x00139020 File Offset: 0x00137220
	private void UpdateRes()
	{
		Screen.SetResolution(this.Widths[this.ResID], this.Heights[this.ResID], Screen.fullScreen);
		this.ResolutionLabel.text = this.Widths[this.ResID].ToString() + " x " + this.Heights[this.ResID].ToString();
	}

	// Token: 0x06001B99 RID: 7065 RVA: 0x00139094 File Offset: 0x00137294
	private void UpdateQuality()
	{
		QualitySettings.SetQualityLevel(this.QualityID, true);
		this.QualityLabel.text = (this.Qualities[this.QualityID] ?? "");
		Debug.Log("The quality level is set to: " + QualitySettings.GetQualityLevel().ToString());
	}

	// Token: 0x06001B9A RID: 7066 RVA: 0x001390EA File Offset: 0x001372EA
	private void UpdateHighlight()
	{
		if (this.ID < 1)
		{
			this.ID = 4;
			return;
		}
		if (this.ID > 4)
		{
			this.ID = 1;
		}
	}

	// Token: 0x06001B9B RID: 7067 RVA: 0x00139110 File Offset: 0x00137310
	private void ResetGraphicsToDefault()
	{
		OptionGlobals.DrawDistance = 350;
		OptionGlobals.DrawDistanceLimit = 350;
		OptionGlobals.DisableStatic = false;
		OptionGlobals.DisableDisplacement = false;
		OptionGlobals.DisableAbberation = false;
		OptionGlobals.DisableVignette = false;
		OptionGlobals.DisableDistortion = false;
		OptionGlobals.DisableNoise = false;
		OptionGlobals.DisableScanlines = true;
		OptionGlobals.OpaqueWindows = false;
		OptionGlobals.MotionBlur = false;
		OptionGlobals.Fog = false;
		GameGlobals.VtuberID = 0;
	}

	// Token: 0x04002F58 RID: 12120
	public InputManagerScript InputManager;

	// Token: 0x04002F59 RID: 12121
	public PostProcessingProfile Profile;

	// Token: 0x04002F5A RID: 12122
	public UILabel ResolutionLabel;

	// Token: 0x04002F5B RID: 12123
	public UILabel FullScreenLabel;

	// Token: 0x04002F5C RID: 12124
	public UILabel QualityLabel;

	// Token: 0x04002F5D RID: 12125
	public Transform Highlight;

	// Token: 0x04002F5E RID: 12126
	public UISprite Darkness;

	// Token: 0x04002F5F RID: 12127
	public float Alpha = 1f;

	// Token: 0x04002F60 RID: 12128
	public bool FullScreen;

	// Token: 0x04002F61 RID: 12129
	public bool FadeOut;

	// Token: 0x04002F62 RID: 12130
	public string[] Qualities;

	// Token: 0x04002F63 RID: 12131
	public int[] Widths;

	// Token: 0x04002F64 RID: 12132
	public int[] Heights;

	// Token: 0x04002F65 RID: 12133
	public int QualityID;

	// Token: 0x04002F66 RID: 12134
	public int ResID = 1;

	// Token: 0x04002F67 RID: 12135
	public int ID = 1;
}
