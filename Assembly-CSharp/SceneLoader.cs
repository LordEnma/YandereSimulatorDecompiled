using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000414 RID: 1044
public class SceneLoader : MonoBehaviour
{
	// Token: 0x06001C79 RID: 7289 RVA: 0x0014DA54 File Offset: 0x0014BC54
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

	// Token: 0x06001C7A RID: 7290 RVA: 0x0014DD0C File Offset: 0x0014BF0C
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

	// Token: 0x06001C7B RID: 7291 RVA: 0x0014DD7D File Offset: 0x0014BF7D
	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x04003261 RID: 12897
	public PostProcessingProfile Profile;

	// Token: 0x04003262 RID: 12898
	[SerializeField]
	private UILabel patienceText;

	// Token: 0x04003263 RID: 12899
	[SerializeField]
	private UILabel loadingText;

	// Token: 0x04003264 RID: 12900
	[SerializeField]
	private UILabel crashText;

	// Token: 0x04003265 RID: 12901
	private float timer;

	// Token: 0x04003266 RID: 12902
	public UILabel[] ControllerText;

	// Token: 0x04003267 RID: 12903
	public UILabel[] KeyboardText;

	// Token: 0x04003268 RID: 12904
	public GameObject LightAnimation;

	// Token: 0x04003269 RID: 12905
	public GameObject DarkAnimation;

	// Token: 0x0400326A RID: 12906
	public GameObject LightAnimation1989;

	// Token: 0x0400326B RID: 12907
	public GameObject DarkAnimation1989;

	// Token: 0x0400326C RID: 12908
	public GameObject Keyboard;

	// Token: 0x0400326D RID: 12909
	public GameObject Gamepad;

	// Token: 0x0400326E RID: 12910
	public UITexture ControllerLines;

	// Token: 0x0400326F RID: 12911
	public UITexture KeyboardGraphic;

	// Token: 0x04003270 RID: 12912
	public bool Debugging;

	// Token: 0x04003271 RID: 12913
	public float Timer;
}
