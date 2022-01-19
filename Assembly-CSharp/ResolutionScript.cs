using System;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x020003D1 RID: 977
public class ResolutionScript : MonoBehaviour
{
	// Token: 0x06001B5C RID: 7004 RVA: 0x00134C34 File Offset: 0x00132E34
	private void Start()
	{
		if (Screen.width < 664 || Screen.height < 664)
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

	// Token: 0x06001B5D RID: 7005 RVA: 0x00134D24 File Offset: 0x00132F24
	private void Update()
	{
		if (Screen.width < 664 || Screen.height < 664)
		{
			Screen.SetResolution(1280, 720, false);
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

	// Token: 0x06001B5E RID: 7006 RVA: 0x00135020 File Offset: 0x00133220
	private void UpdateRes()
	{
		Screen.SetResolution(this.Widths[this.ResID], this.Heights[this.ResID], Screen.fullScreen);
		this.ResolutionLabel.text = this.Widths[this.ResID].ToString() + " x " + this.Heights[this.ResID].ToString();
	}

	// Token: 0x06001B5F RID: 7007 RVA: 0x00135094 File Offset: 0x00133294
	private void UpdateQuality()
	{
		QualitySettings.SetQualityLevel(this.QualityID, true);
		this.QualityLabel.text = (this.Qualities[this.QualityID] ?? "");
		Debug.Log("The quality level is set to: " + QualitySettings.GetQualityLevel().ToString());
	}

	// Token: 0x06001B60 RID: 7008 RVA: 0x001350EA File Offset: 0x001332EA
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

	// Token: 0x06001B61 RID: 7009 RVA: 0x00135110 File Offset: 0x00133310
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

	// Token: 0x04002EBD RID: 11965
	public InputManagerScript InputManager;

	// Token: 0x04002EBE RID: 11966
	public PostProcessingProfile Profile;

	// Token: 0x04002EBF RID: 11967
	public UILabel ResolutionLabel;

	// Token: 0x04002EC0 RID: 11968
	public UILabel FullScreenLabel;

	// Token: 0x04002EC1 RID: 11969
	public UILabel QualityLabel;

	// Token: 0x04002EC2 RID: 11970
	public Transform Highlight;

	// Token: 0x04002EC3 RID: 11971
	public UISprite Darkness;

	// Token: 0x04002EC4 RID: 11972
	public float Alpha = 1f;

	// Token: 0x04002EC5 RID: 11973
	public bool FullScreen;

	// Token: 0x04002EC6 RID: 11974
	public bool FadeOut;

	// Token: 0x04002EC7 RID: 11975
	public string[] Qualities;

	// Token: 0x04002EC8 RID: 11976
	public int[] Widths;

	// Token: 0x04002EC9 RID: 11977
	public int[] Heights;

	// Token: 0x04002ECA RID: 11978
	public int QualityID;

	// Token: 0x04002ECB RID: 11979
	public int ResID = 1;

	// Token: 0x04002ECC RID: 11980
	public int ID = 1;
}
