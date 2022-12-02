using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public PostProcessingProfile Profile;

	[SerializeField]
	private UILabel patienceText;

	[SerializeField]
	private UILabel loadingText;

	[SerializeField]
	private UILabel crashText;

	private float timer;

	public UILabel[] ControllerText;

	public UILabel[] KeyboardText;

	public GameObject LightAnimation;

	public GameObject DarkAnimation;

	public GameObject LightAnimation1989;

	public GameObject DarkAnimation1989;

	public GameObject Keyboard;

	public GameObject Gamepad;

	public UITexture ControllerLines;

	public UITexture KeyboardGraphic;

	public bool Debugging;

	public float Timer;

	private void Start()
	{
		if (OptionGlobals.DrawDistanceLimit == 0)
		{
			OptionGlobals.DrawDistance = 350;
			OptionGlobals.DrawDistanceLimit = 350;
		}
		if (PlayerPrefs.GetInt("LoadingSave") == 1)
		{
			int profile = GameGlobals.Profile;
			YanSave.LoadData(string.Concat(str3: PlayerPrefs.GetInt("SaveSlot").ToString(), str0: "Profile_", str1: profile.ToString(), str2: "_Slot_"));
		}
		Application.runInBackground = true;
		Time.timeScale = 1f;
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.PreviousSchoolAtmosphere = 1f;
			SchoolGlobals.SchoolAtmosphere = 1f;
			PlayerGlobals.SetCannotBringItem(4, true);
			PlayerGlobals.SetCannotBringItem(5, true);
			PlayerGlobals.SetCannotBringItem(6, true);
			PlayerGlobals.SetCannotBringItem(7, true);
			PlayerGlobals.Money = 10f;
		}
		if (GameGlobals.Eighties)
		{
			LightAnimation.SetActive(false);
			LightAnimation1989.SetActive(true);
		}
		if (SchoolGlobals.SchoolAtmosphere < 0.5f || GameGlobals.LoveSick)
		{
			Camera.main.backgroundColor = new Color(0f, 0f, 0f, 1f);
			patienceText.color = new Color(1f, 0f, 0f, 1f);
			loadingText.color = new Color(1f, 0f, 0f, 1f);
			crashText.color = new Color(1f, 0f, 0f, 1f);
			KeyboardGraphic.color = new Color(1f, 0f, 0f, 1f);
			ControllerLines.color = new Color(1f, 0f, 0f, 1f);
			if (GameGlobals.Eighties)
			{
				LightAnimation1989.SetActive(false);
				DarkAnimation1989.SetActive(true);
			}
			else
			{
				LightAnimation.SetActive(false);
				DarkAnimation.SetActive(true);
			}
			for (int i = 1; i < ControllerText.Length; i++)
			{
				ControllerText[i].color = new Color(1f, 0f, 0f, 1f);
			}
			for (int i = 1; i < KeyboardText.Length; i++)
			{
				KeyboardText[i].color = new Color(1f, 0f, 0f, 1f);
			}
		}
		if (PlayerGlobals.UsingGamepad)
		{
			Keyboard.SetActive(false);
			Gamepad.SetActive(true);
		}
		else
		{
			Keyboard.SetActive(true);
			Gamepad.SetActive(false);
		}
		Debugging = false;
	}

	private void Update()
	{
		if (Timer == 10f)
		{
			StartCoroutine(LoadNewScene());
		}
		Timer += 1f;
	}

	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
	}
}
