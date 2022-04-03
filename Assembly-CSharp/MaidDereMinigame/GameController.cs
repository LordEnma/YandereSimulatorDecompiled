using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x020005A5 RID: 1445
	public class GameController : MonoBehaviour
	{
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x0600248C RID: 9356 RVA: 0x001FF502 File Offset: 0x001FD702
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
		// (get) Token: 0x0600248D RID: 9357 RVA: 0x001FF520 File Offset: 0x001FD720
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x0600248E RID: 9358 RVA: 0x001FF52C File Offset: 0x001FD72C
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

		// Token: 0x0600248F RID: 9359 RVA: 0x001FF564 File Offset: 0x001FD764
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

		// Token: 0x06002490 RID: 9360 RVA: 0x001FF596 File Offset: 0x001FD796
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x001FF5AA File Offset: 0x001FD7AA
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x001FF5DA File Offset: 0x001FD7DA
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

		// Token: 0x06002493 RID: 9363 RVA: 0x001FF5FE File Offset: 0x001FD7FE
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x06002494 RID: 9364 RVA: 0x001FF640 File Offset: 0x001FD840
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x06002495 RID: 9365 RVA: 0x001FF68C File Offset: 0x001FD88C
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x06002496 RID: 9366 RVA: 0x001FF708 File Offset: 0x001FD908
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004CE1 RID: 19681
		private static GameController instance;

		// Token: 0x04004CE2 RID: 19682
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004CE3 RID: 19683
		public SceneWrapper scenes;

		// Token: 0x04004CE4 RID: 19684
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004CE5 RID: 19685
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004CE6 RID: 19686
		public SetupVariables easyVariables;

		// Token: 0x04004CE7 RID: 19687
		public SetupVariables mediumVariables;

		// Token: 0x04004CE8 RID: 19688
		public SetupVariables hardVariables;

		// Token: 0x04004CE9 RID: 19689
		private List<float> tips;

		// Token: 0x04004CEA RID: 19690
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004CEB RID: 19691
		private int angryCustomers;

		// Token: 0x04004CEC RID: 19692
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004CED RID: 19693
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004CEE RID: 19694
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004CEF RID: 19695
		public static BoolParameterEvent PauseGame;
	}
}
