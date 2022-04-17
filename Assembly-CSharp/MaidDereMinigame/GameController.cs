using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x020005A6 RID: 1446
	public class GameController : MonoBehaviour
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x0600249B RID: 9371 RVA: 0x0020048E File Offset: 0x001FE68E
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
		// (get) Token: 0x0600249C RID: 9372 RVA: 0x002004AC File Offset: 0x001FE6AC
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x0600249D RID: 9373 RVA: 0x002004B8 File Offset: 0x001FE6B8
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

		// Token: 0x0600249E RID: 9374 RVA: 0x002004F0 File Offset: 0x001FE6F0
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

		// Token: 0x0600249F RID: 9375 RVA: 0x00200522 File Offset: 0x001FE722
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x060024A0 RID: 9376 RVA: 0x00200536 File Offset: 0x001FE736
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x00200566 File Offset: 0x001FE766
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

		// Token: 0x060024A2 RID: 9378 RVA: 0x0020058A File Offset: 0x001FE78A
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x060024A3 RID: 9379 RVA: 0x002005CC File Offset: 0x001FE7CC
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x060024A4 RID: 9380 RVA: 0x00200618 File Offset: 0x001FE818
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x060024A5 RID: 9381 RVA: 0x00200694 File Offset: 0x001FE894
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004CF7 RID: 19703
		private static GameController instance;

		// Token: 0x04004CF8 RID: 19704
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004CF9 RID: 19705
		public SceneWrapper scenes;

		// Token: 0x04004CFA RID: 19706
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004CFB RID: 19707
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004CFC RID: 19708
		public SetupVariables easyVariables;

		// Token: 0x04004CFD RID: 19709
		public SetupVariables mediumVariables;

		// Token: 0x04004CFE RID: 19710
		public SetupVariables hardVariables;

		// Token: 0x04004CFF RID: 19711
		private List<float> tips;

		// Token: 0x04004D00 RID: 19712
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D01 RID: 19713
		private int angryCustomers;

		// Token: 0x04004D02 RID: 19714
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004D03 RID: 19715
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004D04 RID: 19716
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004D05 RID: 19717
		public static BoolParameterEvent PauseGame;
	}
}
