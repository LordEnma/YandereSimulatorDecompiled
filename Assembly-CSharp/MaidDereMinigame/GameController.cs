using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x020005A7 RID: 1447
	public class GameController : MonoBehaviour
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x060024A4 RID: 9380 RVA: 0x0020196A File Offset: 0x001FFB6A
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

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x060024A5 RID: 9381 RVA: 0x00201988 File Offset: 0x001FFB88
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x060024A6 RID: 9382 RVA: 0x00201994 File Offset: 0x001FFB94
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

		// Token: 0x060024A7 RID: 9383 RVA: 0x002019CC File Offset: 0x001FFBCC
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

		// Token: 0x060024A8 RID: 9384 RVA: 0x002019FE File Offset: 0x001FFBFE
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x060024A9 RID: 9385 RVA: 0x00201A12 File Offset: 0x001FFC12
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x060024AA RID: 9386 RVA: 0x00201A42 File Offset: 0x001FFC42
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

		// Token: 0x060024AB RID: 9387 RVA: 0x00201A66 File Offset: 0x001FFC66
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x060024AC RID: 9388 RVA: 0x00201AA8 File Offset: 0x001FFCA8
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x00201AF4 File Offset: 0x001FFCF4
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x060024AE RID: 9390 RVA: 0x00201B70 File Offset: 0x001FFD70
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004D10 RID: 19728
		private static GameController instance;

		// Token: 0x04004D11 RID: 19729
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004D12 RID: 19730
		public SceneWrapper scenes;

		// Token: 0x04004D13 RID: 19731
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004D14 RID: 19732
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004D15 RID: 19733
		public SetupVariables easyVariables;

		// Token: 0x04004D16 RID: 19734
		public SetupVariables mediumVariables;

		// Token: 0x04004D17 RID: 19735
		public SetupVariables hardVariables;

		// Token: 0x04004D18 RID: 19736
		private List<float> tips;

		// Token: 0x04004D19 RID: 19737
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D1A RID: 19738
		private int angryCustomers;

		// Token: 0x04004D1B RID: 19739
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004D1C RID: 19740
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004D1D RID: 19741
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004D1E RID: 19742
		public static BoolParameterEvent PauseGame;
	}
}
