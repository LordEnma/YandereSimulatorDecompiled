using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x0200040D RID: 1037
public class SceneLoader : MonoBehaviour
{
	// Token: 0x06001C49 RID: 7241 RVA: 0x0014A008 File Offset: 0x00148208
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

	// Token: 0x06001C4A RID: 7242 RVA: 0x0014A28D File Offset: 0x0014848D
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

	// Token: 0x06001C4B RID: 7243 RVA: 0x0014A2CA File Offset: 0x001484CA
	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x040031CC RID: 12748
	public PostProcessingProfile Profile;

	// Token: 0x040031CD RID: 12749
	[SerializeField]
	private UILabel patienceText;

	// Token: 0x040031CE RID: 12750
	[SerializeField]
	private UILabel loadingText;

	// Token: 0x040031CF RID: 12751
	[SerializeField]
	private UILabel crashText;

	// Token: 0x040031D0 RID: 12752
	private float timer;

	// Token: 0x040031D1 RID: 12753
	public UILabel[] ControllerText;

	// Token: 0x040031D2 RID: 12754
	public UILabel[] KeyboardText;

	// Token: 0x040031D3 RID: 12755
	public GameObject LightAnimation;

	// Token: 0x040031D4 RID: 12756
	public GameObject DarkAnimation;

	// Token: 0x040031D5 RID: 12757
	public GameObject Keyboard;

	// Token: 0x040031D6 RID: 12758
	public GameObject Gamepad;

	// Token: 0x040031D7 RID: 12759
	public UITexture ControllerLines;

	// Token: 0x040031D8 RID: 12760
	public UITexture KeyboardGraphic;

	// Token: 0x040031D9 RID: 12761
	public bool Debugging;

	// Token: 0x040031DA RID: 12762
	public float Timer;
}
