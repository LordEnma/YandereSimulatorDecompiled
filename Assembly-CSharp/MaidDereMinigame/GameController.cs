using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x02000596 RID: 1430
	public class GameController : MonoBehaviour
	{
		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06002438 RID: 9272 RVA: 0x001F7E92 File Offset: 0x001F6092
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
		// (get) Token: 0x06002439 RID: 9273 RVA: 0x001F7EB0 File Offset: 0x001F60B0
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x0600243A RID: 9274 RVA: 0x001F7EBC File Offset: 0x001F60BC
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

		// Token: 0x0600243B RID: 9275 RVA: 0x001F7EF4 File Offset: 0x001F60F4
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

		// Token: 0x0600243C RID: 9276 RVA: 0x001F7F26 File Offset: 0x001F6126
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x0600243D RID: 9277 RVA: 0x001F7F3A File Offset: 0x001F613A
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x0600243E RID: 9278 RVA: 0x001F7F6A File Offset: 0x001F616A
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

		// Token: 0x0600243F RID: 9279 RVA: 0x001F7F8E File Offset: 0x001F618E
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x06002440 RID: 9280 RVA: 0x001F7FD0 File Offset: 0x001F61D0
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x06002441 RID: 9281 RVA: 0x001F801C File Offset: 0x001F621C
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x06002442 RID: 9282 RVA: 0x001F8098 File Offset: 0x001F6298
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004BEB RID: 19435
		private static GameController instance;

		// Token: 0x04004BEC RID: 19436
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004BED RID: 19437
		public SceneWrapper scenes;

		// Token: 0x04004BEE RID: 19438
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004BEF RID: 19439
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004BF0 RID: 19440
		public SetupVariables easyVariables;

		// Token: 0x04004BF1 RID: 19441
		public SetupVariables mediumVariables;

		// Token: 0x04004BF2 RID: 19442
		public SetupVariables hardVariables;

		// Token: 0x04004BF3 RID: 19443
		private List<float> tips;

		// Token: 0x04004BF4 RID: 19444
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004BF5 RID: 19445
		private int angryCustomers;

		// Token: 0x04004BF6 RID: 19446
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004BF7 RID: 19447
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004BF8 RID: 19448
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004BF9 RID: 19449
		public static BoolParameterEvent PauseGame;
	}
}
