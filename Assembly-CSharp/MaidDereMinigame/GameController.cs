using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x0200059A RID: 1434
	public class GameController : MonoBehaviour
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06002455 RID: 9301 RVA: 0x001FA772 File Offset: 0x001F8972
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

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06002456 RID: 9302 RVA: 0x001FA790 File Offset: 0x001F8990
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x06002457 RID: 9303 RVA: 0x001FA79C File Offset: 0x001F899C
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
				SceneManager.LoadScene("CalendarScene");
			}, fadeOut, true));
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x001FA7D4 File Offset: 0x001F89D4
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

		// Token: 0x06002459 RID: 9305 RVA: 0x001FA806 File Offset: 0x001F8A06
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x001FA81A File Offset: 0x001F8A1A
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x001FA84A File Offset: 0x001F8A4A
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

		// Token: 0x0600245C RID: 9308 RVA: 0x001FA86E File Offset: 0x001F8A6E
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x001FA8B0 File Offset: 0x001F8AB0
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x0600245E RID: 9310 RVA: 0x001FA8FC File Offset: 0x001F8AFC
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x0600245F RID: 9311 RVA: 0x001FA978 File Offset: 0x001F8B78
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004C23 RID: 19491
		private static GameController instance;

		// Token: 0x04004C24 RID: 19492
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004C25 RID: 19493
		public SceneWrapper scenes;

		// Token: 0x04004C26 RID: 19494
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004C27 RID: 19495
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004C28 RID: 19496
		public SetupVariables easyVariables;

		// Token: 0x04004C29 RID: 19497
		public SetupVariables mediumVariables;

		// Token: 0x04004C2A RID: 19498
		public SetupVariables hardVariables;

		// Token: 0x04004C2B RID: 19499
		private List<float> tips;

		// Token: 0x04004C2C RID: 19500
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C2D RID: 19501
		private int angryCustomers;

		// Token: 0x04004C2E RID: 19502
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004C2F RID: 19503
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004C30 RID: 19504
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C31 RID: 19505
		public static BoolParameterEvent PauseGame;
	}
}
