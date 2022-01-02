using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000408 RID: 1032
public class SceneLoader : MonoBehaviour
{
	// Token: 0x06001C2D RID: 7213 RVA: 0x00147134 File Offset: 0x00145334
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

	// Token: 0x06001C2E RID: 7214 RVA: 0x001473C9 File Offset: 0x001455C9
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

	// Token: 0x06001C2F RID: 7215 RVA: 0x00147406 File Offset: 0x00145606
	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x040031A1 RID: 12705
	public PostProcessingProfile Profile;

	// Token: 0x040031A2 RID: 12706
	[SerializeField]
	private UILabel patienceText;

	// Token: 0x040031A3 RID: 12707
	[SerializeField]
	private UILabel loadingText;

	// Token: 0x040031A4 RID: 12708
	[SerializeField]
	private UILabel crashText;

	// Token: 0x040031A5 RID: 12709
	private float timer;

	// Token: 0x040031A6 RID: 12710
	public UILabel[] ControllerText;

	// Token: 0x040031A7 RID: 12711
	public UILabel[] KeyboardText;

	// Token: 0x040031A8 RID: 12712
	public GameObject LightAnimation;

	// Token: 0x040031A9 RID: 12713
	public GameObject DarkAnimation;

	// Token: 0x040031AA RID: 12714
	public GameObject Keyboard;

	// Token: 0x040031AB RID: 12715
	public GameObject Gamepad;

	// Token: 0x040031AC RID: 12716
	public UITexture ControllerLines;

	// Token: 0x040031AD RID: 12717
	public UITexture KeyboardGraphic;

	// Token: 0x040031AE RID: 12718
	public bool Debugging;

	// Token: 0x040031AF RID: 12719
	public float Timer;
}
