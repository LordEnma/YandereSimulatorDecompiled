using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x0200040B RID: 1035
public class SceneLoader : MonoBehaviour
{
	// Token: 0x06001C37 RID: 7223 RVA: 0x001490F8 File Offset: 0x001472F8
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

	// Token: 0x06001C38 RID: 7224 RVA: 0x0014937D File Offset: 0x0014757D
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

	// Token: 0x06001C39 RID: 7225 RVA: 0x001493BA File Offset: 0x001475BA
	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x040031B3 RID: 12723
	public PostProcessingProfile Profile;

	// Token: 0x040031B4 RID: 12724
	[SerializeField]
	private UILabel patienceText;

	// Token: 0x040031B5 RID: 12725
	[SerializeField]
	private UILabel loadingText;

	// Token: 0x040031B6 RID: 12726
	[SerializeField]
	private UILabel crashText;

	// Token: 0x040031B7 RID: 12727
	private float timer;

	// Token: 0x040031B8 RID: 12728
	public UILabel[] ControllerText;

	// Token: 0x040031B9 RID: 12729
	public UILabel[] KeyboardText;

	// Token: 0x040031BA RID: 12730
	public GameObject LightAnimation;

	// Token: 0x040031BB RID: 12731
	public GameObject DarkAnimation;

	// Token: 0x040031BC RID: 12732
	public GameObject Keyboard;

	// Token: 0x040031BD RID: 12733
	public GameObject Gamepad;

	// Token: 0x040031BE RID: 12734
	public UITexture ControllerLines;

	// Token: 0x040031BF RID: 12735
	public UITexture KeyboardGraphic;

	// Token: 0x040031C0 RID: 12736
	public bool Debugging;

	// Token: 0x040031C1 RID: 12737
	public float Timer;
}
