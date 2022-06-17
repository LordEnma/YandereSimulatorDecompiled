// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Bubble
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  public class Bubble : MonoBehaviour
  {
    [HideInInspector]
    public Food food;
    public SpriteRenderer foodRenderer;

    private void Awake() => this.foodRenderer.sprite = (Sprite) null;

    private void OnEnable() => GameController.PauseGame += new BoolParameterEvent(this.Pause);

    private void OnDisable() => GameController.PauseGame -= new BoolParameterEvent(this.Pause);

    public void Pause(bool toPause)
    {
      if (toPause)
      {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.foodRenderer.gameObject.SetActive(false);
      }
      else
      {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.foodRenderer.gameObject.SetActive(true);
      }
    }

    public void BubbleReachedMax()
    {
      this.foodRenderer.gameObject.SetActive(true);
      this.foodRenderer.sprite = this.food.largeSprite;
    }

    public void BubbleClosing() => this.foodRenderer.gameObject.SetActive(false);

    public void KillBubble() => Object.Destroy((Object) this.gameObject);
  }
}
