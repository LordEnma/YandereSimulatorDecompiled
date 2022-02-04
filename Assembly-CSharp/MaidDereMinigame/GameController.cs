using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x02000599 RID: 1433
	public class GameController : MonoBehaviour
	{
		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x0600244B RID: 9291 RVA: 0x001FA0BA File Offset: 0x001F82BA
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

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x0600244C RID: 9292 RVA: 0x001FA0D8 File Offset: 0x001F82D8
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x0600244D RID: 9293 RVA: 0x001FA0E4 File Offset: 0x001F82E4
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

		// Token: 0x0600244E RID: 9294 RVA: 0x001FA11C File Offset: 0x001F831C
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

		// Token: 0x0600244F RID: 9295 RVA: 0x001FA14E File Offset: 0x001F834E
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x06002450 RID: 9296 RVA: 0x001FA162 File Offset: 0x001F8362
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x06002451 RID: 9297 RVA: 0x001FA192 File Offset: 0x001F8392
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

		// Token: 0x06002452 RID: 9298 RVA: 0x001FA1B6 File Offset: 0x001F83B6
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x06002453 RID: 9299 RVA: 0x001FA1F8 File Offset: 0x001F83F8
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x06002454 RID: 9300 RVA: 0x001FA244 File Offset: 0x001F8444
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x06002455 RID: 9301 RVA: 0x001FA2C0 File Offset: 0x001F84C0
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004C17 RID: 19479
		private static GameController instance;

		// Token: 0x04004C18 RID: 19480
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004C19 RID: 19481
		public SceneWrapper scenes;

		// Token: 0x04004C1A RID: 19482
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004C1B RID: 19483
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004C1C RID: 19484
		public SetupVariables easyVariables;

		// Token: 0x04004C1D RID: 19485
		public SetupVariables mediumVariables;

		// Token: 0x04004C1E RID: 19486
		public SetupVariables hardVariables;

		// Token: 0x04004C1F RID: 19487
		private List<float> tips;

		// Token: 0x04004C20 RID: 19488
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C21 RID: 19489
		private int angryCustomers;

		// Token: 0x04004C22 RID: 19490
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004C23 RID: 19491
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004C24 RID: 19492
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C25 RID: 19493
		public static BoolParameterEvent PauseGame;
	}
}
