// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.TipPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
  public class TipPage : MonoBehaviour
  {
    public TipCard wageCard;
    public TipCard totalCard;
    private List<TipCard> cards;
    private bool stopInteraction;

    public void Init()
    {
      this.cards = new List<TipCard>();
      foreach (Transform transform in this.transform.GetChild(0))
      {
        foreach (Component component in transform)
          this.cards.Add(component.GetComponent<TipCard>());
      }
      this.gameObject.SetActive(false);
    }

    public void DisplayTips(List<float> tips)
    {
      if (tips == null)
        tips = new List<float>();
      this.gameObject.SetActive(true);
      float num = 0.0f;
      for (int index = 0; index < this.cards.Count; ++index)
      {
        if (tips.Count > index)
        {
          this.cards[index].SetTip(tips[index]);
          num += tips[index];
        }
        else
          this.cards[index].SetTip(0.0f);
      }
      float basePay = GameController.Instance.activeDifficultyVariables.basePay;
      GameController.Instance.totalPayout = num + basePay;
      this.wageCard.SetTip(basePay);
      this.totalCard.SetTip(num + basePay);
    }

    private void Update()
    {
      if (this.stopInteraction || !Input.GetButtonDown("A"))
        return;
      GameController.GoToExitScene();
      this.stopInteraction = true;
    }
  }
}
