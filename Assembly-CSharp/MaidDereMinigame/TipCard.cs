// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.TipCard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using MaidDereMinigame.Malee;
using System;
using System.Globalization;
using System.Threading;
using UnityEngine;

namespace MaidDereMinigame
{
  public class TipCard : MonoBehaviour
  {
    [Reorderable]
    public SpriteRenderers digits;
    public SpriteRenderer dollarSign;

    public void SetTip(float tip)
    {
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
      if ((double) tip == 0.0)
        this.gameObject.SetActive(false);
      string str1 = string.Format("{0:#.00}", (object) tip).Replace(".", "");
      string str2 = "";
      for (int index = str1.Length - 1; index >= 0; --index)
        str2 += str1[index].ToString();
      for (int index = 0; index < str2.Length; ++index)
      {
        int result = -1;
        if (int.TryParse(str2[index].ToString(), NumberStyles.Float, (IFormatProvider) NumberFormatInfo.InvariantInfo, out result))
          this.digits[index].sprite = GameController.Instance.numbers[result];
        else
          Debug.LogError((object) "There was an issue while parsing the value in TipCard.SetTip");
      }
      if (str2.Length <= 3)
      {
        this.digits[3].sprite = GameController.Instance.numbers[10];
        this.dollarSign.gameObject.SetActive(false);
      }
      if (str2.Length > 4 || this.digits.Count <= 4)
        return;
      this.digits[4].sprite = GameController.Instance.numbers[10];
      this.dollarSign.gameObject.SetActive(false);
      if (str2.Length >= 4)
        return;
      this.digits[3].sprite = GameController.Instance.numbers[10];
      this.digits[4].gameObject.SetActive(false);
    }
  }
}
