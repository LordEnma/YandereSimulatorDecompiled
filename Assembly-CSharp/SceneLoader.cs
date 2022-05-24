using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000414 RID: 1044
public class SceneLoader : MonoBehaviour
{
	// Token: 0x06001C7A RID: 7290 RVA: 0x0014DD10 File Offset: 0x0014BF10
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
			int @int = PlayerPrefs.GetInt("SaveSlot");
			YanSave.LoadData("Profile_" + profile.ToString() + "_Slot_" + @int.ToString(), false);
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
			this.LightAnimation.SetActive(false);
			this.LightAnimation1989.SetActive(true);
		}
		if (SchoolGlobals.SchoolAtmosphere < 0.5f || GameGlobals.LoveSick)
		{
			Camera.main.backgroundColor = new Color(0f, 0f, 0f, 1f);
			this.patienceText.color = new Color(1f, 0f, 0f, 1f);
			this.loadingText.color = new Color(1f, 0f, 0f, 1f);
			this.crashText.color = new Color(1f, 0f, 0f, 1f);
			this.KeyboardGraphic.color = new Color(1f, 0f, 0f, 1f);
			this.ControllerLines.color = new Color(1f, 0f, 0f, 1f);
			if (GameGlobals.Eighties)
			{
				this.LightAnimation1989.SetActive(false);
				this.DarkAnimation1989.SetActive(true);
			}
			else
			{
				this.LightAnimation.SetActive(false);
				this.DarkAnimation.SetActive(true);
			}
			for (int i = 1; i < this.ControllerText.Length; i++)
			{
				this.ControllerText[i].color = new Color(1f, 0f, 0f, 1f);
			}
			for (int i = 1; i < this.KeyboardText.Length; i++)
			{
				this.KeyboardText[i].color = new Color(1f, 0f, 0f, 1f);
			}
		}
		if (PlayerGlobals.UsingGamepad)
		{
			this.Keyboard.SetActive(false);
			this.Gamepad.SetActive(true);
		}
		else
		{
			this.Keyboard.SetActive(true);
			this.Gamepad.SetActive(false);
		}
		this.Debugging = false;
	}

	// Token: 0x06001C7B RID: 7291 RVA: 0x0014DFC8 File Offset: 0x0014C1C8
	private void Update()
	{
		if (this.Timer == 1f)
		{
			base.StartCoroutine(this.LoadNewScene());
		}
		this.Timer += 1f;
		if (Input.GetKeyDown("a"))
		{
			if (SchoolGlobals.SchoolAtmosphere > 0f)
			{
				SchoolGlobals.SchoolAtmosphere = 0f;
			}
			else
			{
				SchoolGlobals.SchoolAtmosphere = 1f;
			}
			SceneManager.LoadScene("LoadingScene");
		}
	}

	// Token: 0x06001C7C RID: 7292 RVA: 0x0014E039 File Offset: 0x0014C239
	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x04003269 RID: 12905
	public PostProcessingProfile Profile;

	// Token: 0x0400326A RID: 12906
	[SerializeField]
	private UILabel patienceText;

	// Token: 0x0400326B RID: 12907
	[SerializeField]
	private UILabel loadingText;

	// Token: 0x0400326C RID: 12908
	[SerializeField]
	private UILabel crashText;

	// Token: 0x0400326D RID: 12909
	private float timer;

	// Token: 0x0400326E RID: 12910
	public UILabel[] ControllerText;

	// Token: 0x0400326F RID: 12911
	public UILabel[] KeyboardText;

	// Token: 0x04003270 RID: 12912
	public GameObject LightAnimation;

	// Token: 0x04003271 RID: 12913
	public GameObject DarkAnimation;

	// Token: 0x04003272 RID: 12914
	public GameObject LightAnimation1989;

	// Token: 0x04003273 RID: 12915
	public GameObject DarkAnimation1989;

	// Token: 0x04003274 RID: 12916
	public GameObject Keyboard;

	// Token: 0x04003275 RID: 12917
	public GameObject Gamepad;

	// Token: 0x04003276 RID: 12918
	public UITexture ControllerLines;

	// Token: 0x04003277 RID: 12919
	public UITexture KeyboardGraphic;

	// Token: 0x04003278 RID: 12920
	public bool Debugging;

	// Token: 0x04003279 RID: 12921
	public float Timer;
}
