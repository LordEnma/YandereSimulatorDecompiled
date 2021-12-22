using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000408 RID: 1032
public class SceneLoader : MonoBehaviour
{
	// Token: 0x06001C2B RID: 7211 RVA: 0x00146D38 File Offset: 0x00144F38
	private void Start()
	{
		this.Profile.bloom.enabled = true;
		OptionGlobals.DisableBloom = false;
		OptionGlobals.DrawDistance = 350;
		OptionGlobals.DrawDistanceLimit = 350;
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

	// Token: 0x06001C2C RID: 7212 RVA: 0x00146FC3 File Offset: 0x001451C3
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

	// Token: 0x06001C2D RID: 7213 RVA: 0x00147000 File Offset: 0x00145200
	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x0400319A RID: 12698
	public PostProcessingProfile Profile;

	// Token: 0x0400319B RID: 12699
	[SerializeField]
	private UILabel patienceText;

	// Token: 0x0400319C RID: 12700
	[SerializeField]
	private UILabel loadingText;

	// Token: 0x0400319D RID: 12701
	[SerializeField]
	private UILabel crashText;

	// Token: 0x0400319E RID: 12702
	private float timer;

	// Token: 0x0400319F RID: 12703
	public UILabel[] ControllerText;

	// Token: 0x040031A0 RID: 12704
	public UILabel[] KeyboardText;

	// Token: 0x040031A1 RID: 12705
	public GameObject LightAnimation;

	// Token: 0x040031A2 RID: 12706
	public GameObject DarkAnimation;

	// Token: 0x040031A3 RID: 12707
	public GameObject Keyboard;

	// Token: 0x040031A4 RID: 12708
	public GameObject Gamepad;

	// Token: 0x040031A5 RID: 12709
	public UITexture ControllerLines;

	// Token: 0x040031A6 RID: 12710
	public UITexture KeyboardGraphic;

	// Token: 0x040031A7 RID: 12711
	public bool Debugging;

	// Token: 0x040031A8 RID: 12712
	public float Timer;
}
