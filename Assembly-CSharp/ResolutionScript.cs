using System;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x020003D1 RID: 977
public class ResolutionScript : MonoBehaviour
{
	// Token: 0x06001B5F RID: 7007 RVA: 0x00135314 File Offset: 0x00133514
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

	// Token: 0x06001B60 RID: 7008 RVA: 0x00135404 File Offset: 0x00133604
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

	// Token: 0x06001B61 RID: 7009 RVA: 0x00135700 File Offset: 0x00133900
	private void UpdateRes()
	{
		Screen.SetResolution(this.Widths[this.ResID], this.Heights[this.ResID], Screen.fullScreen);
		this.ResolutionLabel.text = this.Widths[this.ResID].ToString() + " x " + this.Heights[this.ResID].ToString();
	}

	// Token: 0x06001B62 RID: 7010 RVA: 0x00135774 File Offset: 0x00133974
	private void UpdateQuality()
	{
		QualitySettings.SetQualityLevel(this.QualityID, true);
		this.QualityLabel.text = (this.Qualities[this.QualityID] ?? "");
		Debug.Log("The quality level is set to: " + QualitySettings.GetQualityLevel().ToString());
	}

	// Token: 0x06001B63 RID: 7011 RVA: 0x001357CA File Offset: 0x001339CA
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

	// Token: 0x06001B64 RID: 7012 RVA: 0x001357F0 File Offset: 0x001339F0
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

	// Token: 0x04002EC7 RID: 11975
	public InputManagerScript InputManager;

	// Token: 0x04002EC8 RID: 11976
	public PostProcessingProfile Profile;

	// Token: 0x04002EC9 RID: 11977
	public UILabel ResolutionLabel;

	// Token: 0x04002ECA RID: 11978
	public UILabel FullScreenLabel;

	// Token: 0x04002ECB RID: 11979
	public UILabel QualityLabel;

	// Token: 0x04002ECC RID: 11980
	public Transform Highlight;

	// Token: 0x04002ECD RID: 11981
	public UISprite Darkness;

	// Token: 0x04002ECE RID: 11982
	public float Alpha = 1f;

	// Token: 0x04002ECF RID: 11983
	public bool FullScreen;

	// Token: 0x04002ED0 RID: 11984
	public bool FadeOut;

	// Token: 0x04002ED1 RID: 11985
	public string[] Qualities;

	// Token: 0x04002ED2 RID: 11986
	public int[] Widths;

	// Token: 0x04002ED3 RID: 11987
	public int[] Heights;

	// Token: 0x04002ED4 RID: 11988
	public int QualityID;

	// Token: 0x04002ED5 RID: 11989
	public int ResID = 1;

	// Token: 0x04002ED6 RID: 11990
	public int ID = 1;
}
