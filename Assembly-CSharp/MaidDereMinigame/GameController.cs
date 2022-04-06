using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x020005A6 RID: 1446
	public class GameController : MonoBehaviour
	{
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06002494 RID: 9364 RVA: 0x001FFA32 File Offset: 0x001FDC32
		public static GameController Instance
		{
			get
			{
				if (GameController.instance == null)
				{
					GameController.instance = UnityEngine.Object.FindObjectOfType<GameController>();
				}
				return GameController.instance;
			}
		}

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06002495 RID: 9365 RVA: 0x001FFA50 File Offset: 0x001FDC50
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x06002496 RID: 9366 RVA: 0x001FFA5C File Offset: 0x001FDC5C
		public static void GoToExitScene(bool fadeOut = true)
		{
			GameController.Instance.StartCoroutine(GameController.Instance.FadeWithAction(delegate
			{
				PlayerGlobals.Money += GameController.Instance.totalPayout;
				if (PlayerGlobals.Money > 1000f)
				{
					PlayerPrefs.SetInt("RichGirl", 1);
				}
				if (SceneManager.GetActiveScene().name == "MaidMenuScene")
				{
					SceneManager.LoadScene("StreetScene");
					return;
				}
				DateGlobals.PassDays = 1;
				DateGlobals.ForceSkip = true;
				SceneManager.LoadScene("CalendarScene");
			}, fadeOut, true));
		}

		// Token: 0x06002497 RID: 9367 RVA: 0x001FFA94 File Offset: 0x001FDC94
		private void Awake()
		{
			if (GameController.Instance != this)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
				return;
			}
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x06002498 RID: 9368 RVA: 0x001FFAC6 File Offset: 0x001FDCC6
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x06002499 RID: 9369 RVA: 0x001FFADA File Offset: 0x001FDCDA
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x0600249A RID: 9370 RVA: 0x001FFB0A File Offset: 0x001FDD0A
		private IEnumerator FadeWithAction(Action PostFadeAction, bool doFadeOut = true, bool destroyGameController = false)
		{
			float timeToFade = 0f;
			if (doFadeOut)
			{
				while (timeToFade <= this.activeDifficultyVariables.transitionTime)
				{
					this.spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, timeToFade / this.activeDifficultyVariables.transitionTime));
					timeToFade += Time.deltaTime;
					yield return null;
				}
				this.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				timeToFade = this.activeDifficultyVariables.transitionTime;
			}
			PostFadeAction();
			if (destroyGameController)
			{
				if (GameController.Instance.whiteFadeOutPost != null && doFadeOut)
				{
					GameController.Instance.whiteFadeOutPost.color = Color.white;
				}
				UnityEngine.Object.Destroy(GameController.Instance.gameObject);
				Camera.main.farClipPlane = 0f;
				GameController.instance = null;
			}
			else
			{
				while (timeToFade >= 0f)
				{
					this.spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, timeToFade / this.activeDifficultyVariables.transitionTime));
					timeToFade -= Time.deltaTime;
					yield return null;
				}
				this.spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
			}
			yield break;
		}

		// Token: 0x0600249B RID: 9371 RVA: 0x001FFB2E File Offset: 0x001FDD2E
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x0600249C RID: 9372 RVA: 0x001FFB70 File Offset: 0x001FDD70
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x0600249D RID: 9373 RVA: 0x001FFBBC File Offset: 0x001FDDBC
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x001FFC38 File Offset: 0x001FDE38
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004CE5 RID: 19685
		private static GameController instance;

		// Token: 0x04004CE6 RID: 19686
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004CE7 RID: 19687
		public SceneWrapper scenes;

		// Token: 0x04004CE8 RID: 19688
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004CE9 RID: 19689
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004CEA RID: 19690
		public SetupVariables easyVariables;

		// Token: 0x04004CEB RID: 19691
		public SetupVariables mediumVariables;

		// Token: 0x04004CEC RID: 19692
		public SetupVariables hardVariables;

		// Token: 0x04004CED RID: 19693
		private List<float> tips;

		// Token: 0x04004CEE RID: 19694
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004CEF RID: 19695
		private int angryCustomers;

		// Token: 0x04004CF0 RID: 19696
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004CF1 RID: 19697
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004CF2 RID: 19698
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004CF3 RID: 19699
		public static BoolParameterEvent PauseGame;
	}
}
