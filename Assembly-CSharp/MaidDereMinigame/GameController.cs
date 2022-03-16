using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x020005A0 RID: 1440
	public class GameController : MonoBehaviour
	{
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x0600247C RID: 9340 RVA: 0x001FDC92 File Offset: 0x001FBE92
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
		// (get) Token: 0x0600247D RID: 9341 RVA: 0x001FDCB0 File Offset: 0x001FBEB0
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x0600247E RID: 9342 RVA: 0x001FDCBC File Offset: 0x001FBEBC
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

		// Token: 0x0600247F RID: 9343 RVA: 0x001FDCF4 File Offset: 0x001FBEF4
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

		// Token: 0x06002480 RID: 9344 RVA: 0x001FDD26 File Offset: 0x001FBF26
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x06002481 RID: 9345 RVA: 0x001FDD3A File Offset: 0x001FBF3A
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x06002482 RID: 9346 RVA: 0x001FDD6A File Offset: 0x001FBF6A
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

		// Token: 0x06002483 RID: 9347 RVA: 0x001FDD8E File Offset: 0x001FBF8E
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x06002484 RID: 9348 RVA: 0x001FDDD0 File Offset: 0x001FBFD0
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x06002485 RID: 9349 RVA: 0x001FDE1C File Offset: 0x001FC01C
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x06002486 RID: 9350 RVA: 0x001FDE98 File Offset: 0x001FC098
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004CAF RID: 19631
		private static GameController instance;

		// Token: 0x04004CB0 RID: 19632
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004CB1 RID: 19633
		public SceneWrapper scenes;

		// Token: 0x04004CB2 RID: 19634
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004CB3 RID: 19635
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004CB4 RID: 19636
		public SetupVariables easyVariables;

		// Token: 0x04004CB5 RID: 19637
		public SetupVariables mediumVariables;

		// Token: 0x04004CB6 RID: 19638
		public SetupVariables hardVariables;

		// Token: 0x04004CB7 RID: 19639
		private List<float> tips;

		// Token: 0x04004CB8 RID: 19640
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004CB9 RID: 19641
		private int angryCustomers;

		// Token: 0x04004CBA RID: 19642
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004CBB RID: 19643
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004CBC RID: 19644
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004CBD RID: 19645
		public static BoolParameterEvent PauseGame;
	}
}
