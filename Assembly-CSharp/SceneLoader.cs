using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000407 RID: 1031
public class SceneLoader : MonoBehaviour
{
	// Token: 0x06001C23 RID: 7203 RVA: 0x00146478 File Offset: 0x00144678
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

	// Token: 0x06001C24 RID: 7204 RVA: 0x001466E7 File Offset: 0x001448E7
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

	// Token: 0x06001C25 RID: 7205 RVA: 0x00146724 File Offset: 0x00144924
	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x04003170 RID: 12656
	public PostProcessingProfile Profile;

	// Token: 0x04003171 RID: 12657
	[SerializeField]
	private UILabel patienceText;

	// Token: 0x04003172 RID: 12658
	[SerializeField]
	private UILabel loadingText;

	// Token: 0x04003173 RID: 12659
	[SerializeField]
	private UILabel crashText;

	// Token: 0x04003174 RID: 12660
	private float timer;

	// Token: 0x04003175 RID: 12661
	public UILabel[] ControllerText;

	// Token: 0x04003176 RID: 12662
	public UILabel[] KeyboardText;

	// Token: 0x04003177 RID: 12663
	public GameObject LightAnimation;

	// Token: 0x04003178 RID: 12664
	public GameObject DarkAnimation;

	// Token: 0x04003179 RID: 12665
	public GameObject Keyboard;

	// Token: 0x0400317A RID: 12666
	public GameObject Gamepad;

	// Token: 0x0400317B RID: 12667
	public UITexture ControllerLines;

	// Token: 0x0400317C RID: 12668
	public UITexture KeyboardGraphic;

	// Token: 0x0400317D RID: 12669
	public bool Debugging;

	// Token: 0x0400317E RID: 12670
	public float Timer;
}
