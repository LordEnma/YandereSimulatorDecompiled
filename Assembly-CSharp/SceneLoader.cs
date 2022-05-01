using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000413 RID: 1043
public class SceneLoader : MonoBehaviour
{
	// Token: 0x06001C73 RID: 7283 RVA: 0x0014CDD4 File Offset: 0x0014AFD4
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

	// Token: 0x06001C74 RID: 7284 RVA: 0x0014D08C File Offset: 0x0014B28C
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

	// Token: 0x06001C75 RID: 7285 RVA: 0x0014D0FD File Offset: 0x0014B2FD
	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x0400324C RID: 12876
	public PostProcessingProfile Profile;

	// Token: 0x0400324D RID: 12877
	[SerializeField]
	private UILabel patienceText;

	// Token: 0x0400324E RID: 12878
	[SerializeField]
	private UILabel loadingText;

	// Token: 0x0400324F RID: 12879
	[SerializeField]
	private UILabel crashText;

	// Token: 0x04003250 RID: 12880
	private float timer;

	// Token: 0x04003251 RID: 12881
	public UILabel[] ControllerText;

	// Token: 0x04003252 RID: 12882
	public UILabel[] KeyboardText;

	// Token: 0x04003253 RID: 12883
	public GameObject LightAnimation;

	// Token: 0x04003254 RID: 12884
	public GameObject DarkAnimation;

	// Token: 0x04003255 RID: 12885
	public GameObject LightAnimation1989;

	// Token: 0x04003256 RID: 12886
	public GameObject DarkAnimation1989;

	// Token: 0x04003257 RID: 12887
	public GameObject Keyboard;

	// Token: 0x04003258 RID: 12888
	public GameObject Gamepad;

	// Token: 0x04003259 RID: 12889
	public UITexture ControllerLines;

	// Token: 0x0400325A RID: 12890
	public UITexture KeyboardGraphic;

	// Token: 0x0400325B RID: 12891
	public bool Debugging;

	// Token: 0x0400325C RID: 12892
	public float Timer;
}
