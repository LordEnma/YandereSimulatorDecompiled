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
		// (get) Token: 0x06002445 RID: 9285 RVA: 0x001F9502 File Offset: 0x001F7702
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
		// (get) Token: 0x06002446 RID: 9286 RVA: 0x001F9520 File Offset: 0x001F7720
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x06002447 RID: 9287 RVA: 0x001F952C File Offset: 0x001F772C
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

		// Token: 0x06002448 RID: 9288 RVA: 0x001F9564 File Offset: 0x001F7764
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

		// Token: 0x06002449 RID: 9289 RVA: 0x001F9596 File Offset: 0x001F7796
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x0600244A RID: 9290 RVA: 0x001F95AA File Offset: 0x001F77AA
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x0600244B RID: 9291 RVA: 0x001F95DA File Offset: 0x001F77DA
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

		// Token: 0x0600244C RID: 9292 RVA: 0x001F95FE File Offset: 0x001F77FE
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x0600244D RID: 9293 RVA: 0x001F9640 File Offset: 0x001F7840
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x0600244E RID: 9294 RVA: 0x001F968C File Offset: 0x001F788C
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x0600244F RID: 9295 RVA: 0x001F9708 File Offset: 0x001F7908
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004C06 RID: 19462
		private static GameController instance;

		// Token: 0x04004C07 RID: 19463
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004C08 RID: 19464
		public SceneWrapper scenes;

		// Token: 0x04004C09 RID: 19465
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004C0A RID: 19466
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004C0B RID: 19467
		public SetupVariables easyVariables;

		// Token: 0x04004C0C RID: 19468
		public SetupVariables mediumVariables;

		// Token: 0x04004C0D RID: 19469
		public SetupVariables hardVariables;

		// Token: 0x04004C0E RID: 19470
		private List<float> tips;

		// Token: 0x04004C0F RID: 19471
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C10 RID: 19472
		private int angryCustomers;

		// Token: 0x04004C11 RID: 19473
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004C12 RID: 19474
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004C13 RID: 19475
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C14 RID: 19476
		public static BoolParameterEvent PauseGame;
	}
}
