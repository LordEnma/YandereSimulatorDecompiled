// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.GameController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using MaidDereMinigame.Malee;
using System.Collections;
using System.Collections.Generic;
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
        if ((UnityEngine.Object) GameController.instance == (UnityEngine.Object) null)
          GameController.instance = UnityEngine.Object.FindObjectOfType<GameController>();
        return GameController.instance;
      }
    }

    public static SceneWrapper Scenes => GameController.Instance.scenes;

    public static void GoToExitScene(bool fadeOut = true) => GameController.Instance.StartCoroutine(GameController.Instance.FadeWithAction((System.Action) (() =>
    {
      PlayerGlobals.Money += GameController.Instance.totalPayout;
      if ((double) PlayerGlobals.Money > 1000.0)
        PlayerPrefs.SetInt("RichGirl", 1);
      if (SceneManager.GetActiveScene().name == "MaidMenuScene")
      {
        SceneManager.LoadScene("StreetScene");
      }
      else
      {
        DateGlobals.PassDays = 1;
        DateGlobals.ForceSkip = true;
        SceneManager.LoadScene("CalendarScene");
      }
    }), fadeOut, true));

    private void Awake()
    {
      if ((UnityEngine.Object) GameController.Instance != (UnityEngine.Object) this)
      {
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.gameObject);
      }
      else
      {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) this.gameObject);
      }
    }

    public static void SetPause(bool toPause)
    {
      if (GameController.PauseGame == null)
        return;
      GameController.PauseGame(toPause);
    }

    public void LoadScene(SceneObject scene) => this.StartCoroutine(this.FadeWithAction((System.Action) (() => SceneManager.LoadScene("MaidGameScene"))));

    private IEnumerator FadeWithAction(
      System.Action PostFadeAction,
      bool doFadeOut = true,
      bool destroyGameController = false)
    {
      float timeToFade = 0.0f;
      if (doFadeOut)
      {
        while ((double) timeToFade <= (double) this.activeDifficultyVariables.transitionTime)
        {
          this.spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(0.0f, 1f, timeToFade / this.activeDifficultyVariables.transitionTime));
          timeToFade += Time.deltaTime;
          yield return (object) null;
        }
        this.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
      }
      else
        timeToFade = this.activeDifficultyVariables.transitionTime;
      PostFadeAction();
      if (destroyGameController)
      {
        if ((UnityEngine.Object) GameController.Instance.whiteFadeOutPost != (UnityEngine.Object) null & doFadeOut)
          GameController.Instance.whiteFadeOutPost.color = Color.white;
        UnityEngine.Object.Destroy((UnityEngine.Object) GameController.Instance.gameObject);
        Camera.main.farClipPlane = 0.0f;
        GameController.instance = (GameController) null;
      }
      else
      {
        while ((double) timeToFade >= 0.0)
        {
          this.spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(0.0f, 1f, timeToFade / this.activeDifficultyVariables.transitionTime));
          timeToFade -= Time.deltaTime;
          yield return (object) null;
        }
        this.spriteRenderer.color = new Color(1f, 1f, 1f, 0.0f);
      }
    }

    public static void TimeUp()
    {
      GameController.SetPause(true);
      GameController.Instance.tipPage.Init();
      GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
      UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
    }

    public static void AddTip(float tip)
    {
      if (GameController.Instance.tips == null)
        GameController.Instance.tips = new List<float>();
      tip = Mathf.Floor(tip * 100f) / 100f;
      GameController.Instance.tips.Add(tip);
    }

    public static float GetTotalDollars()
    {
      float num = 0.0f;
      foreach (float tip in GameController.Instance.tips)
        num += Mathf.Floor(tip * 100f) / 100f;
      return num + GameController.Instance.activeDifficultyVariables.basePay;
    }

    public static void AddAngryCustomer()
    {
      ++GameController.Instance.angryCustomers;
      if (GameController.Instance.angryCustomers < GameController.Instance.activeDifficultyVariables.failQuantity)
        return;
      FailGame.GameFailed();
      GameController.SetPause(true);
    }
  }
}
