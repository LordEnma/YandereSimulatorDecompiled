// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.FailGame
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
  public class FailGame : MonoBehaviour
  {
    private static FailGame instance;
    public float fadeMultiplier = 2f;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer textRenderer;
    private float targetTransitionTime;
    private float transitionTime;

    public static FailGame Instance
    {
      get
      {
        if ((Object) FailGame.instance == (Object) null)
          FailGame.instance = Object.FindObjectOfType<FailGame>();
        return FailGame.instance;
      }
    }

    private void Awake()
    {
      this.spriteRenderer = this.GetComponent<SpriteRenderer>();
      this.textRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
      this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
    }

    public static void GameFailed()
    {
      FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
      FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
      SFXController.PlaySound(SFXController.Sounds.GameFail);
    }

    private IEnumerator GameFailedRoutine()
    {
      FailGame failGame = this;
      Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
      yield return (object) null;
      failGame.textRenderer.color = Color.white;
      while ((double) failGame.transitionTime < (double) failGame.targetTransitionTime)
      {
        failGame.transitionTime += Time.deltaTime;
        yield return (object) null;
      }
      failGame.transform.GetChild(1).gameObject.SetActive(true);
      while (!Input.anyKeyDown)
        yield return (object) null;
      while ((double) failGame.transitionTime < (double) failGame.targetTransitionTime)
      {
        failGame.transitionTime += Time.deltaTime;
        float a = Mathf.Lerp(0.0f, 1f, failGame.transitionTime / failGame.targetTransitionTime);
        failGame.spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, a);
        yield return (object) null;
      }
      GameController.GoToExitScene(false);
    }

    private IEnumerator SlowPitch()
    {
      GameStarter starter = Object.FindObjectOfType<GameStarter>();
      float timeToZero = 5f;
      while ((double) timeToZero > 0.0)
      {
        starter.SetAudioPitch(Mathf.Lerp(0.0f, 1f, timeToZero / 5f));
        timeToZero -= Time.deltaTime;
        yield return (object) null;
      }
      starter.SetAudioPitch(0.0f);
    }
  }
}
