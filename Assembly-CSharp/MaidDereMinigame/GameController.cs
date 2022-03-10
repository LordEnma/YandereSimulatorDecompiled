using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x0200059C RID: 1436
	public class GameController : MonoBehaviour
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06002464 RID: 9316 RVA: 0x001FBD2A File Offset: 0x001F9F2A
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
		// (get) Token: 0x06002465 RID: 9317 RVA: 0x001FBD48 File Offset: 0x001F9F48
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x06002466 RID: 9318 RVA: 0x001FBD54 File Offset: 0x001F9F54
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

		// Token: 0x06002467 RID: 9319 RVA: 0x001FBD8C File Offset: 0x001F9F8C
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

		// Token: 0x06002468 RID: 9320 RVA: 0x001FBDBE File Offset: 0x001F9FBE
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x06002469 RID: 9321 RVA: 0x001FBDD2 File Offset: 0x001F9FD2
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x0600246A RID: 9322 RVA: 0x001FBE02 File Offset: 0x001FA002
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

		// Token: 0x0600246B RID: 9323 RVA: 0x001FBE26 File Offset: 0x001FA026
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x0600246C RID: 9324 RVA: 0x001FBE68 File Offset: 0x001FA068
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x0600246D RID: 9325 RVA: 0x001FBEB4 File Offset: 0x001FA0B4
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x0600246E RID: 9326 RVA: 0x001FBF30 File Offset: 0x001FA130
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004C50 RID: 19536
		private static GameController instance;

		// Token: 0x04004C51 RID: 19537
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004C52 RID: 19538
		public SceneWrapper scenes;

		// Token: 0x04004C53 RID: 19539
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004C54 RID: 19540
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004C55 RID: 19541
		public SetupVariables easyVariables;

		// Token: 0x04004C56 RID: 19542
		public SetupVariables mediumVariables;

		// Token: 0x04004C57 RID: 19543
		public SetupVariables hardVariables;

		// Token: 0x04004C58 RID: 19544
		private List<float> tips;

		// Token: 0x04004C59 RID: 19545
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C5A RID: 19546
		private int angryCustomers;

		// Token: 0x04004C5B RID: 19547
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004C5C RID: 19548
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004C5D RID: 19549
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C5E RID: 19550
		public static BoolParameterEvent PauseGame;
	}
}
