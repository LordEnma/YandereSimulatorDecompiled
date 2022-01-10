using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x0200040A RID: 1034
public class SceneLoader : MonoBehaviour
{
	// Token: 0x06001C34 RID: 7220 RVA: 0x001474A8 File Offset: 0x001456A8
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

	// Token: 0x06001C35 RID: 7221 RVA: 0x0014773D File Offset: 0x0014593D
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

	// Token: 0x06001C36 RID: 7222 RVA: 0x0014777A File Offset: 0x0014597A
	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x040031A7 RID: 12711
	public PostProcessingProfile Profile;

	// Token: 0x040031A8 RID: 12712
	[SerializeField]
	private UILabel patienceText;

	// Token: 0x040031A9 RID: 12713
	[SerializeField]
	private UILabel loadingText;

	// Token: 0x040031AA RID: 12714
	[SerializeField]
	private UILabel crashText;

	// Token: 0x040031AB RID: 12715
	private float timer;

	// Token: 0x040031AC RID: 12716
	public UILabel[] ControllerText;

	// Token: 0x040031AD RID: 12717
	public UILabel[] KeyboardText;

	// Token: 0x040031AE RID: 12718
	public GameObject LightAnimation;

	// Token: 0x040031AF RID: 12719
	public GameObject DarkAnimation;

	// Token: 0x040031B0 RID: 12720
	public GameObject Keyboard;

	// Token: 0x040031B1 RID: 12721
	public GameObject Gamepad;

	// Token: 0x040031B2 RID: 12722
	public UITexture ControllerLines;

	// Token: 0x040031B3 RID: 12723
	public UITexture KeyboardGraphic;

	// Token: 0x040031B4 RID: 12724
	public bool Debugging;

	// Token: 0x040031B5 RID: 12725
	public float Timer;
}
