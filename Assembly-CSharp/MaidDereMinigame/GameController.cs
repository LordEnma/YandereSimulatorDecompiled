using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	public class GameController : MonoBehaviour
	{
		private static GameController instance;

		[Reorderable]
		public Sprites numbers;

		public SceneWrapper scenes;

		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		public SetupVariables activeDifficultyVariables;

		public SetupVariables easyVariables;

		public SetupVariables mediumVariables;

		public SetupVariables hardVariables;

		private List<float> tips;

		private SpriteRenderer spriteRenderer;

		private int angryCustomers;

		[HideInInspector]
		public TipPage tipPage;

		[HideInInspector]
		public float totalPayout;

		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		public static BoolParameterEvent PauseGame;

		public static GameController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = UnityEngine.Object.FindObjectOfType<GameController>();
				}
				return instance;
			}
		}

		public static SceneWrapper Scenes
		{
			get
			{
				return Instance.scenes;
			}
		}

		public static void GoToExitScene(bool fadeOut = true)
		{
			Instance.StartCoroutine(Instance.FadeWithAction(delegate
			{
				Debug.Log("Exiting the Maid Minigame.");
				if (Instance.totalPayout > 0f && !GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Maid", 1);
					PlayerPrefs.SetInt("a", 1);
				}
				PlayerGlobals.Money += Instance.totalPayout;
				if (PlayerGlobals.Money > 1000f)
				{
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("RichGirl", 1);
					}
					if (!GameGlobals.Debug)
					{
						PlayerPrefs.SetInt("a", 1);
					}
				}
				if (SceneManager.GetActiveScene().name == "MaidMenuScene")
				{
					SceneManager.LoadScene("StreetScene");
				}
				else
				{
					DateGlobals.PassDays = 1;
					if (DateGlobals.Weekday == DayOfWeek.Sunday)
					{
						Debug.Log("It was Sunday.");
						if (!HomeGlobals.Night)
						{
							Debug.Log("It was daytime.");
							HomeGlobals.Night = true;
							SceneManager.LoadScene("HomeScene");
						}
						else
						{
							Debug.Log("It was nighttime.");
							DateGlobals.ForceSkip = true;
							SceneManager.LoadScene("CalendarScene");
						}
					}
					else
					{
						SceneManager.LoadScene("CalendarScene");
					}
				}
			}, fadeOut, true));
		}

		private void Awake()
		{
			if (Instance != this)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
				return;
			}
			spriteRenderer = GetComponent<SpriteRenderer>();
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		public static void SetPause(bool toPause)
		{
			if (PauseGame != null)
			{
				PauseGame(toPause);
			}
		}

		public void LoadScene(SceneObject scene)
		{
			StartCoroutine(FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}));
		}

		private IEnumerator FadeWithAction(Action PostFadeAction, bool doFadeOut = true, bool destroyGameController = false)
		{
			float timeToFade = 0f;
			if (doFadeOut)
			{
				while (timeToFade <= activeDifficultyVariables.transitionTime)
				{
					spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, timeToFade / activeDifficultyVariables.transitionTime));
					timeToFade += Time.deltaTime;
					yield return null;
				}
				spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				timeToFade = activeDifficultyVariables.transitionTime;
			}
			PostFadeAction();
			if (destroyGameController)
			{
				if (Instance.whiteFadeOutPost != null && doFadeOut)
				{
					Instance.whiteFadeOutPost.color = Color.white;
				}
				UnityEngine.Object.Destroy(Instance.gameObject);
				Camera.main.farClipPlane = 0f;
				instance = null;
			}
			else
			{
				while (timeToFade >= 0f)
				{
					spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, timeToFade / activeDifficultyVariables.transitionTime));
					timeToFade -= Time.deltaTime;
					yield return null;
				}
				spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
			}
		}

		public static void TimeUp()
		{
			SetPause(true);
			Instance.tipPage.Init();
			Instance.tipPage.DisplayTips(Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		public static void AddTip(float tip)
		{
			if (Instance.tips == null)
			{
				Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			Instance.tips.Add(tip);
		}

		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float tip in Instance.tips)
			{
				num += Mathf.Floor(tip * 100f) / 100f;
			}
			return num + Instance.activeDifficultyVariables.basePay;
		}

		public static void AddAngryCustomer()
		{
			Instance.angryCustomers++;
			if (Instance.angryCustomers >= Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				SetPause(true);
			}
		}
	}
}
