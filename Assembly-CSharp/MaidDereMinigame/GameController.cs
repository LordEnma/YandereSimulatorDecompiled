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
		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06002435 RID: 9269 RVA: 0x001F78A2 File Offset: 0x001F5AA2
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

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06002436 RID: 9270 RVA: 0x001F78C0 File Offset: 0x001F5AC0
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x06002437 RID: 9271 RVA: 0x001F78CC File Offset: 0x001F5ACC
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

		// Token: 0x06002438 RID: 9272 RVA: 0x001F7904 File Offset: 0x001F5B04
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

		// Token: 0x06002439 RID: 9273 RVA: 0x001F7936 File Offset: 0x001F5B36
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x0600243A RID: 9274 RVA: 0x001F794A File Offset: 0x001F5B4A
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x0600243B RID: 9275 RVA: 0x001F797A File Offset: 0x001F5B7A
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

		// Token: 0x0600243C RID: 9276 RVA: 0x001F799E File Offset: 0x001F5B9E
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x0600243D RID: 9277 RVA: 0x001F79E0 File Offset: 0x001F5BE0
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x0600243E RID: 9278 RVA: 0x001F7A2C File Offset: 0x001F5C2C
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x0600243F RID: 9279 RVA: 0x001F7AA8 File Offset: 0x001F5CA8
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004BE2 RID: 19426
		private static GameController instance;

		// Token: 0x04004BE3 RID: 19427
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004BE4 RID: 19428
		public SceneWrapper scenes;

		// Token: 0x04004BE5 RID: 19429
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004BE6 RID: 19430
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004BE7 RID: 19431
		public SetupVariables easyVariables;

		// Token: 0x04004BE8 RID: 19432
		public SetupVariables mediumVariables;

		// Token: 0x04004BE9 RID: 19433
		public SetupVariables hardVariables;

		// Token: 0x04004BEA RID: 19434
		private List<float> tips;

		// Token: 0x04004BEB RID: 19435
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004BEC RID: 19436
		private int angryCustomers;

		// Token: 0x04004BED RID: 19437
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004BEE RID: 19438
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004BEF RID: 19439
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004BF0 RID: 19440
		public static BoolParameterEvent PauseGame;
	}
}
