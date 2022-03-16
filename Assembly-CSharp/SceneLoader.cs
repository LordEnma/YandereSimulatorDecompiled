using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x0200040E RID: 1038
public class SceneLoader : MonoBehaviour
{
	// Token: 0x06001C58 RID: 7256 RVA: 0x0014B3E8 File Offset: 0x001495E8
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

	// Token: 0x06001C59 RID: 7257 RVA: 0x0014B66D File Offset: 0x0014986D
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

	// Token: 0x06001C5A RID: 7258 RVA: 0x0014B6AA File Offset: 0x001498AA
	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x04003216 RID: 12822
	public PostProcessingProfile Profile;

	// Token: 0x04003217 RID: 12823
	[SerializeField]
	private UILabel patienceText;

	// Token: 0x04003218 RID: 12824
	[SerializeField]
	private UILabel loadingText;

	// Token: 0x04003219 RID: 12825
	[SerializeField]
	private UILabel crashText;

	// Token: 0x0400321A RID: 12826
	private float timer;

	// Token: 0x0400321B RID: 12827
	public UILabel[] ControllerText;

	// Token: 0x0400321C RID: 12828
	public UILabel[] KeyboardText;

	// Token: 0x0400321D RID: 12829
	public GameObject LightAnimation;

	// Token: 0x0400321E RID: 12830
	public GameObject DarkAnimation;

	// Token: 0x0400321F RID: 12831
	public GameObject Keyboard;

	// Token: 0x04003220 RID: 12832
	public GameObject Gamepad;

	// Token: 0x04003221 RID: 12833
	public UITexture ControllerLines;

	// Token: 0x04003222 RID: 12834
	public UITexture KeyboardGraphic;

	// Token: 0x04003223 RID: 12835
	public bool Debugging;

	// Token: 0x04003224 RID: 12836
	public float Timer;
}
