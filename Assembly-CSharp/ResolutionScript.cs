using System;
using System.Globalization;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class ResolutionScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public InputDeviceScript InputDevice;

	public PostProcessingProfile Profile;

	public UILabel ResolutionLabel;

	public UILabel FullScreenLabel;

	public UILabel QualityLabel;

	public GameObject DebugMenu;

	public GameObject BGM;

	public AudioClip ConfirmSFX;

	public AudioSource MyAudio;

	public Transform Highlight;

	public UISprite Darkness;

	public float Alpha = 1f;

	public bool FullScreen;

	public bool FadeOut;

	public string[] Qualities;

	public int[] Widths;

	public int[] Heights;

	public int QualityID;

	public int ResID = 1;

	public int Enters;

	public int Qs;

	public int Rs;

	public int Ts;

	public int Zs;

	public int ID = 1;

	private const string FileName = "Settings.txt";

	private const string String1 = "FullScreen=1";

	private const string String2 = "CensorBlood=1";

	private void Start()
	{
		CheckForSettingsFile();
		if (Screen.width < 1280 || Screen.height < 720)
		{
			Screen.SetResolution(1280, 720, FullScreen);
			ResID = 0;
		}
		Darkness.color = new Color(1f, 1f, 1f, 1f);
		Cursor.visible = false;
		Screen.fullScreen = false;
		Screen.SetResolution(Screen.width, Screen.height, FullScreen);
		ResolutionLabel.text = Screen.width + " x " + Screen.height;
		QualityLabel.text = Qualities[QualitySettings.GetQualityLevel()] ?? "";
		if (!FullScreen)
		{
			FullScreenLabel.text = "No";
		}
		else
		{
			FullScreenLabel.text = "Yes";
		}
		Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
		ResetGraphicsToDefault();
	}

	private void Update()
	{
		if (Screen.width < 1280 || Screen.height < 720)
		{
			Screen.SetResolution(1280, 720, fullscreen: false);
			ResolutionLabel.text = Screen.width + " x " + Screen.height;
			ResID = 0;
		}
		if (FadeOut)
		{
			Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime);
			if (Alpha > 0.999f)
			{
				GameGlobals.LastInputType = (int)InputDevice.Type;
				SceneManager.LoadScene("DisclaimerScene");
			}
		}
		else
		{
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime);
		}
		Darkness.alpha = Alpha;
		if (Alpha == 0f)
		{
			if (InputManager.TappedDown)
			{
				ID++;
				UpdateHighlight();
			}
			if (InputManager.TappedUp)
			{
				ID--;
				UpdateHighlight();
			}
			if (ID == 1)
			{
				if (InputManager.TappedRight)
				{
					ResID++;
					if (ResID == Widths.Length)
					{
						ResID = 0;
					}
					UpdateRes();
				}
				else if (InputManager.TappedLeft)
				{
					ResID--;
					if (ResID < 0)
					{
						ResID = Widths.Length - 1;
					}
					UpdateRes();
				}
			}
			else if (ID == 2)
			{
				if (InputManager.TappedRight || InputManager.TappedLeft)
				{
					FullScreen = !FullScreen;
					if (FullScreen)
					{
						FullScreenLabel.text = "Yes";
					}
					else
					{
						FullScreenLabel.text = "No";
					}
					Screen.SetResolution(Screen.width, Screen.height, FullScreen);
					MyAudio.Play();
				}
			}
			else if (ID == 3)
			{
				if (InputManager.TappedRight)
				{
					QualityID++;
					if (QualityID == Qualities.Length)
					{
						QualityID = 0;
					}
					UpdateQuality();
				}
				else if (InputManager.TappedLeft)
				{
					QualityID--;
					if (QualityID < 0)
					{
						QualityID = Qualities.Length - 1;
					}
					UpdateQuality();
				}
			}
			else if (ID == 4 && Input.GetButtonUp(InputNames.Xbox_A))
			{
				Darkness.color = new Color(0f, 0f, 0f, 0f);
				FadeOut = true;
				MyAudio.clip = ConfirmSFX;
				MyAudio.Play();
			}
		}
		Highlight.localPosition = Vector3.Lerp(Highlight.localPosition, new Vector3(-307.5f, 250 - ID * 100, 0f), Time.deltaTime * 10f);
		if (Input.GetKeyDown("r"))
		{
			Rs++;
			if (Rs == 10)
			{
				Debug.Log("Wiping all PlayerPrefs.");
				PlayerPrefs.DeleteAll();
				Screen.SetResolution(1280, 720, fullscreen: false);
				SceneManager.LoadScene("ResolutionScene");
			}
		}
		if (Input.GetButton(InputNames.Xbox_LB) && Input.GetButton(InputNames.Xbox_RB))
		{
			DebugMenu.SetActive(value: true);
			if (Input.GetButton(InputNames.Xbox_A))
			{
				SceneManager.LoadScene("NewTitleScene");
			}
			else if (Input.GetButton(InputNames.Xbox_B))
			{
				SceneManager.LoadScene("StreetScene");
			}
			else if (Input.GetButton(InputNames.Xbox_X))
			{
				SceneManager.LoadScene("PostAmaiScene");
			}
			else if (Input.GetButton(InputNames.Xbox_Y))
			{
				SceneManager.LoadScene("controllerTest");
			}
		}
		else
		{
			DebugMenu.SetActive(value: false);
		}
	}

	private void UpdateRes()
	{
		Screen.SetResolution(Widths[ResID], Heights[ResID], Screen.fullScreen);
		ResolutionLabel.text = Widths[ResID] + " x " + Heights[ResID];
		OptionGlobals.ResolutionID = ResID;
		MyAudio.Play();
	}

	private void UpdateQuality()
	{
		QualitySettings.SetQualityLevel(QualityID, applyExpensiveChanges: true);
		QualityLabel.text = Qualities[QualityID] ?? "";
		MyAudio.Play();
	}

	private void UpdateHighlight()
	{
		if (ID < 1)
		{
			ID = 4;
		}
		else if (ID > 4)
		{
			ID = 1;
		}
		MyAudio.Play();
	}

	private void ResetGraphicsToDefault()
	{
		if (OptionGlobals.SubtitleSize < 1)
		{
			Debug.Log("We are now initializing the OptionGlobals for the first time...probably.");
			OptionGlobals.SubtitleSize = 2;
			OptionGlobals.Sensitivity = 3;
			OptionGlobals.DepthOfField = true;
			OptionGlobals.DisableScanlines = true;
		}
		Profile.fog.enabled = OptionGlobals.Fog;
		Profile.antialiasing.enabled = !OptionGlobals.DisablePostAliasing;
		Profile.ambientOcclusion.enabled = !OptionGlobals.DisableObscurance;
		Profile.depthOfField.enabled = OptionGlobals.DepthOfField;
		Profile.motionBlur.enabled = OptionGlobals.MotionBlur;
		Profile.bloom.enabled = !OptionGlobals.DisableBloom;
		Profile.chromaticAberration.enabled = !OptionGlobals.DisableAbberation;
		Profile.vignette.enabled = !OptionGlobals.DisableVignette;
		if (OptionGlobals.DrawDistance < 10)
		{
			OptionGlobals.DrawDistance = 350;
			OptionGlobals.DrawDistanceLimit = 350;
		}
		GameGlobals.VtuberID = 0;
	}

	private void CheckForSettingsFile()
	{
		string path = Path.Combine(Application.streamingAssetsPath, "Settings.txt");
		if (!File.Exists(path))
		{
			return;
		}
		try
		{
			string text = File.ReadAllText(path);
			if (text.Contains("FullScreen=1"))
			{
				FullScreen = true;
			}
			if (text.Contains("CensorBlood=1"))
			{
				GameGlobals.CensorBlood = true;
			}
		}
		catch (Exception)
		{
		}
	}
}
