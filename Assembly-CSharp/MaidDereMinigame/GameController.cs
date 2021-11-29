using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x02000594 RID: 1428
	public class GameController : MonoBehaviour
	{
		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06002424 RID: 9252 RVA: 0x001F616E File Offset: 0x001F436E
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
		// (get) Token: 0x06002425 RID: 9253 RVA: 0x001F618C File Offset: 0x001F438C
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x06002426 RID: 9254 RVA: 0x001F6198 File Offset: 0x001F4398
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

		// Token: 0x06002427 RID: 9255 RVA: 0x001F61D0 File Offset: 0x001F43D0
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

		// Token: 0x06002428 RID: 9256 RVA: 0x001F6202 File Offset: 0x001F4402
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x06002429 RID: 9257 RVA: 0x001F6216 File Offset: 0x001F4416
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x0600242A RID: 9258 RVA: 0x001F6246 File Offset: 0x001F4446
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

		// Token: 0x0600242B RID: 9259 RVA: 0x001F626A File Offset: 0x001F446A
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x0600242C RID: 9260 RVA: 0x001F62AC File Offset: 0x001F44AC
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x0600242D RID: 9261 RVA: 0x001F62F8 File Offset: 0x001F44F8
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x0600242E RID: 9262 RVA: 0x001F6374 File Offset: 0x001F4574
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004BA3 RID: 19363
		private static GameController instance;

		// Token: 0x04004BA4 RID: 19364
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004BA5 RID: 19365
		public SceneWrapper scenes;

		// Token: 0x04004BA6 RID: 19366
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004BA7 RID: 19367
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004BA8 RID: 19368
		public SetupVariables easyVariables;

		// Token: 0x04004BA9 RID: 19369
		public SetupVariables mediumVariables;

		// Token: 0x04004BAA RID: 19370
		public SetupVariables hardVariables;

		// Token: 0x04004BAB RID: 19371
		private List<float> tips;

		// Token: 0x04004BAC RID: 19372
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004BAD RID: 19373
		private int angryCustomers;

		// Token: 0x04004BAE RID: 19374
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004BAF RID: 19375
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004BB0 RID: 19376
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004BB1 RID: 19377
		public static BoolParameterEvent PauseGame;
	}
}
