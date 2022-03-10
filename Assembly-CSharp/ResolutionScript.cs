using System;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x020003D3 RID: 979
public class ResolutionScript : MonoBehaviour
{
	// Token: 0x06001B71 RID: 7025 RVA: 0x001365B8 File Offset: 0x001347B8
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
	}

	// Token: 0x06001B72 RID: 7026 RVA: 0x001366A8 File Offset: 0x001348A8
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

	// Token: 0x06001B73 RID: 7027 RVA: 0x001369D4 File Offset: 0x00134BD4
	private void UpdateRes()
	{
		Screen.SetResolution(this.Widths[this.ResID], this.Heights[this.ResID], Screen.fullScreen);
		this.ResolutionLabel.text = this.Widths[this.ResID].ToString() + " x " + this.Heights[this.ResID].ToString();
	}

	// Token: 0x06001B74 RID: 7028 RVA: 0x00136A48 File Offset: 0x00134C48
	private void UpdateQuality()
	{
		QualitySettings.SetQualityLevel(this.QualityID, true);
		this.QualityLabel.text = (this.Qualities[this.QualityID] ?? "");
		Debug.Log("The quality level is set to: " + QualitySettings.GetQualityLevel().ToString());
	}

	// Token: 0x06001B75 RID: 7029 RVA: 0x00136A9E File Offset: 0x00134C9E
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

	// Token: 0x06001B76 RID: 7030 RVA: 0x00136AC4 File Offset: 0x00134CC4
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
	}

	// Token: 0x04002EF3 RID: 12019
	public InputManagerScript InputManager;

	// Token: 0x04002EF4 RID: 12020
	public PostProcessingProfile Profile;

	// Token: 0x04002EF5 RID: 12021
	public UILabel ResolutionLabel;

	// Token: 0x04002EF6 RID: 12022
	public UILabel FullScreenLabel;

	// Token: 0x04002EF7 RID: 12023
	public UILabel QualityLabel;

	// Token: 0x04002EF8 RID: 12024
	public Transform Highlight;

	// Token: 0x04002EF9 RID: 12025
	public UISprite Darkness;

	// Token: 0x04002EFA RID: 12026
	public float Alpha = 1f;

	// Token: 0x04002EFB RID: 12027
	public bool FullScreen;

	// Token: 0x04002EFC RID: 12028
	public bool FadeOut;

	// Token: 0x04002EFD RID: 12029
	public string[] Qualities;

	// Token: 0x04002EFE RID: 12030
	public int[] Widths;

	// Token: 0x04002EFF RID: 12031
	public int[] Heights;

	// Token: 0x04002F00 RID: 12032
	public int QualityID;

	// Token: 0x04002F01 RID: 12033
	public int ResID = 1;

	// Token: 0x04002F02 RID: 12034
	public int ID = 1;
}
