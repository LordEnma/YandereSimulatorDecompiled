// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.GameStarter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
  public class GameStarter : MonoBehaviour
  {
    public List<Sprite> numbers;
    public SpriteRenderer whiteFadeOutPost;
    public Sprite timeUp;
    public TipPage tipPage;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private int timeToStart = 3;

    private void Awake()
    {
      this.spriteRenderer = this.GetComponent<SpriteRenderer>();
      this.audioSource = this.GetComponent<AudioSource>();
      this.StartCoroutine(this.CountdownToStart());
      GameController.Instance.tipPage = this.tipPage;
      GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
    }

    public void SetGameTime(float gameTime)
    {
      int index = Mathf.CeilToInt(gameTime);
      if ((double) index == 10.0)
        SFXController.PlaySound(SFXController.Sounds.ClockTick);
      if ((double) gameTime > 3.0)
        return;
      switch (index)
      {
        case 1:
        case 2:
        case 3:
          this.spriteRenderer.sprite = this.numbers[index];
          break;
        default:
          this.EndGame();
          break;
      }
    }

    public void EndGame()
    {
      this.StartCoroutine(this.EndGameRoutine());
      SFXController.PlaySound(SFXController.Sounds.GameSuccess);
    }

    private IEnumerator CountdownToStart()
    {
      yield return (object) new WaitForSeconds(GameController.Instance.activeDifficultyVariables.transitionTime);
      SFXController.PlaySound(SFXController.Sounds.Countdown);
      while (this.timeToStart > 0)
      {
        yield return (object) new WaitForSeconds(1f);
        --this.timeToStart;
        this.spriteRenderer.sprite = this.numbers[this.timeToStart];
      }
      yield return (object) new WaitForSeconds(1f);
      GameController.SetPause(false);
      this.spriteRenderer.sprite = (Sprite) null;
    }

    private IEnumerator EndGameRoutine()
    {
      GameController.SetPause(true);
      this.spriteRenderer.sprite = this.timeUp;
      yield return (object) new WaitForSeconds(1f);
      Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
      GameController.TimeUp();
    }

    public void SetAudioPitch(float value) => this.audioSource.pitch = value;
  }
}
