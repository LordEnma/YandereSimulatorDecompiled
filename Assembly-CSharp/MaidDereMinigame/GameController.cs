using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x020005A8 RID: 1448
	public class GameController : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x060024B0 RID: 9392 RVA: 0x0020361E File Offset: 0x0020181E
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

		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x060024B1 RID: 9393 RVA: 0x0020363C File Offset: 0x0020183C
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x00203648 File Offset: 0x00201848
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

		// Token: 0x060024B3 RID: 9395 RVA: 0x00203680 File Offset: 0x00201880
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

		// Token: 0x060024B4 RID: 9396 RVA: 0x002036B2 File Offset: 0x002018B2
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x060024B5 RID: 9397 RVA: 0x002036C6 File Offset: 0x002018C6
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x002036F6 File Offset: 0x002018F6
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

		// Token: 0x060024B7 RID: 9399 RVA: 0x0020371A File Offset: 0x0020191A
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x060024B8 RID: 9400 RVA: 0x0020375C File Offset: 0x0020195C
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x002037A8 File Offset: 0x002019A8
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x00203824 File Offset: 0x00201A24
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004D40 RID: 19776
		private static GameController instance;

		// Token: 0x04004D41 RID: 19777
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004D42 RID: 19778
		public SceneWrapper scenes;

		// Token: 0x04004D43 RID: 19779
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004D44 RID: 19780
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004D45 RID: 19781
		public SetupVariables easyVariables;

		// Token: 0x04004D46 RID: 19782
		public SetupVariables mediumVariables;

		// Token: 0x04004D47 RID: 19783
		public SetupVariables hardVariables;

		// Token: 0x04004D48 RID: 19784
		private List<float> tips;

		// Token: 0x04004D49 RID: 19785
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D4A RID: 19786
		private int angryCustomers;

		// Token: 0x04004D4B RID: 19787
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004D4C RID: 19788
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004D4D RID: 19789
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004D4E RID: 19790
		public static BoolParameterEvent PauseGame;
	}
}
