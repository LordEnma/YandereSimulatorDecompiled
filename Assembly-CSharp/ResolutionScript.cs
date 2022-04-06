using System;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x020003D8 RID: 984
public class ResolutionScript : MonoBehaviour
{
	// Token: 0x06001B8E RID: 7054 RVA: 0x001380E4 File Offset: 0x001362E4
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

	// Token: 0x06001B8F RID: 7055 RVA: 0x00138238 File Offset: 0x00136438
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

	// Token: 0x06001B90 RID: 7056 RVA: 0x001385CC File Offset: 0x001367CC
	private void UpdateRes()
	{
		Screen.SetResolution(this.Widths[this.ResID], this.Heights[this.ResID], Screen.fullScreen);
		this.ResolutionLabel.text = this.Widths[this.ResID].ToString() + " x " + this.Heights[this.ResID].ToString();
	}

	// Token: 0x06001B91 RID: 7057 RVA: 0x00138640 File Offset: 0x00136840
	private void UpdateQuality()
	{
		QualitySettings.SetQualityLevel(this.QualityID, true);
		this.QualityLabel.text = (this.Qualities[this.QualityID] ?? "");
		Debug.Log("The quality level is set to: " + QualitySettings.GetQualityLevel().ToString());
	}

	// Token: 0x06001B92 RID: 7058 RVA: 0x00138696 File Offset: 0x00136896
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

	// Token: 0x06001B93 RID: 7059 RVA: 0x001386BC File Offset: 0x001368BC
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

	// Token: 0x04002F43 RID: 12099
	public InputManagerScript InputManager;

	// Token: 0x04002F44 RID: 12100
	public PostProcessingProfile Profile;

	// Token: 0x04002F45 RID: 12101
	public UILabel ResolutionLabel;

	// Token: 0x04002F46 RID: 12102
	public UILabel FullScreenLabel;

	// Token: 0x04002F47 RID: 12103
	public UILabel QualityLabel;

	// Token: 0x04002F48 RID: 12104
	public Transform Highlight;

	// Token: 0x04002F49 RID: 12105
	public UISprite Darkness;

	// Token: 0x04002F4A RID: 12106
	public float Alpha = 1f;

	// Token: 0x04002F4B RID: 12107
	public bool FullScreen;

	// Token: 0x04002F4C RID: 12108
	public bool FadeOut;

	// Token: 0x04002F4D RID: 12109
	public string[] Qualities;

	// Token: 0x04002F4E RID: 12110
	public int[] Widths;

	// Token: 0x04002F4F RID: 12111
	public int[] Heights;

	// Token: 0x04002F50 RID: 12112
	public int QualityID;

	// Token: 0x04002F51 RID: 12113
	public int ResID = 1;

	// Token: 0x04002F52 RID: 12114
	public int ID = 1;
}
