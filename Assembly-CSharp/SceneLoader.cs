using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x0200040D RID: 1037
public class SceneLoader : MonoBehaviour
{
	// Token: 0x06001C4B RID: 7243 RVA: 0x0014A544 File Offset: 0x00148744
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
		if (SchoolGlobals.SchoolAtmosphere < 0.5f || GameGlobals.LoveSick)
		{
			Camera.main.backgroundColor = new Color(0f, 0f, 0f, 1f);
			this.patienceText.color = new Color(1f, 0f, 0f, 1f);
			this.loadingText.color = new Color(1f, 0f, 0f, 1f);
			this.crashText.color = new Color(1f, 0f, 0f, 1f);
			this.KeyboardGraphic.color = new Color(1f, 0f, 0f, 1f);
			this.ControllerLines.color = new Color(1f, 0f, 0f, 1f);
			this.LightAnimation.SetActive(false);
			this.DarkAnimation.SetActive(true);
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
		if (!this.Debugging)
		{
			base.StartCoroutine(this.LoadNewScene());
		}
	}

	// Token: 0x06001C4C RID: 7244 RVA: 0x0014A7C9 File Offset: 0x001489C9
	private void Update()
	{
		if (this.Debugging)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 10f)
			{
				this.Debugging = false;
				base.StartCoroutine(this.LoadNewScene());
			}
		}
	}

	// Token: 0x06001C4D RID: 7245 RVA: 0x0014A806 File Offset: 0x00148A06
	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x040031E2 RID: 12770
	public PostProcessingProfile Profile;

	// Token: 0x040031E3 RID: 12771
	[SerializeField]
	private UILabel patienceText;

	// Token: 0x040031E4 RID: 12772
	[SerializeField]
	private UILabel loadingText;

	// Token: 0x040031E5 RID: 12773
	[SerializeField]
	private UILabel crashText;

	// Token: 0x040031E6 RID: 12774
	private float timer;

	// Token: 0x040031E7 RID: 12775
	public UILabel[] ControllerText;

	// Token: 0x040031E8 RID: 12776
	public UILabel[] KeyboardText;

	// Token: 0x040031E9 RID: 12777
	public GameObject LightAnimation;

	// Token: 0x040031EA RID: 12778
	public GameObject DarkAnimation;

	// Token: 0x040031EB RID: 12779
	public GameObject Keyboard;

	// Token: 0x040031EC RID: 12780
	public GameObject Gamepad;

	// Token: 0x040031ED RID: 12781
	public UITexture ControllerLines;

	// Token: 0x040031EE RID: 12782
	public UITexture KeyboardGraphic;

	// Token: 0x040031EF RID: 12783
	public bool Debugging;

	// Token: 0x040031F0 RID: 12784
	public float Timer;
}
