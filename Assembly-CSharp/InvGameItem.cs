// Decompiled with JetBrains decompiler
// Type: InvGameItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InvGameItem
{
  [SerializeField]
  private int mBaseItemID;
  public InvGameItem.Quality quality = InvGameItem.Quality.Sturdy;
  public int itemLevel = 1;
  private InvBaseItem mBaseItem;

  public int baseItemID => this.mBaseItemID;

  public InvBaseItem baseItem
  {
    get
    {
      if (this.mBaseItem == null)
        this.mBaseItem = InvDatabase.FindByID(this.baseItemID);
      return this.mBaseItem;
    }
  }

  public string name => this.baseItem == null ? (string) null : this.quality.ToString() + " " + this.baseItem.name;

  public float statMultiplier
  {
    get
    {
      float num = 0.0f;
      switch (this.quality)
      {
        case InvGameItem.Quality.Broken:
          num = 0.0f;
          break;
        case InvGameItem.Quality.Cursed:
          num = -1f;
          break;
        case InvGameItem.Quality.Damaged:
          num = 0.25f;
          break;
        case InvGameItem.Quality.Worn:
          num = 0.9f;
          break;
        case InvGameItem.Quality.Sturdy:
          num = 1f;
          break;
        case InvGameItem.Quality.Polished:
          num = 1.1f;
          break;
        case InvGameItem.Quality.Improved:
          num = 1.25f;
          break;
        case InvGameItem.Quality.Crafted:
          num = 1.5f;
          break;
        case InvGameItem.Quality.Superior:
          num = 1.75f;
          break;
        case InvGameItem.Quality.Enchanted:
          num = 2f;
          break;
        case InvGameItem.Quality.Epic:
          num = 2.5f;
          break;
        case InvGameItem.Quality.Legendary:
          num = 3f;
          break;
      }
      float a = (float) this.itemLevel / 50f;
      return num * Mathf.Lerp(a, a * a, 0.5f);
    }
  }

  public Color color
  {
    get
    {
      Color color = Color.white;
      switch (this.quality)
      {
        case InvGameItem.Quality.Broken:
          color = new Color(0.4f, 0.2f, 0.2f);
          break;
        case InvGameItem.Quality.Cursed:
          color = Color.red;
          break;
        case InvGameItem.Quality.Damaged:
          color = new Color(0.4f, 0.4f, 0.4f);
          break;
        case InvGameItem.Quality.Worn:
          color = new Color(0.7f, 0.7f, 0.7f);
          break;
        case InvGameItem.Quality.Sturdy:
          color = new Color(1f, 1f, 1f);
          break;
        case InvGameItem.Quality.Polished:
          color = NGUIMath.HexToColor(3774856959U);
          break;
        case InvGameItem.Quality.Improved:
          color = NGUIMath.HexToColor(2480359935U);
          break;
        case InvGameItem.Quality.Crafted:
          color = NGUIMath.HexToColor(1325334783U);
          break;
        case InvGameItem.Quality.Superior:
          color = NGUIMath.HexToColor(12255231U);
          break;
        case InvGameItem.Quality.Enchanted:
          color = NGUIMath.HexToColor(1937178111U);
          break;
        case InvGameItem.Quality.Epic:
          color = NGUIMath.HexToColor(2516647935U);
          break;
        case InvGameItem.Quality.Legendary:
          color = NGUIMath.HexToColor(4287627519U);
          break;
      }
      return color;
    }
  }

  public InvGameItem(int id) => this.mBaseItemID = id;

  public InvGameItem(int id, InvBaseItem bi)
  {
    this.mBaseItemID = id;
    this.mBaseItem = bi;
  }

  public List<InvStat> CalculateStats()
  {
    List<InvStat> stats1 = new List<InvStat>();
    if (this.baseItem != null)
    {
      float statMultiplier = this.statMultiplier;
      List<InvStat> stats2 = this.baseItem.stats;
      int index1 = 0;
      for (int count1 = stats2.Count; index1 < count1; ++index1)
      {
        InvStat invStat1 = stats2[index1];
        int num = Mathf.RoundToInt(statMultiplier * (float) invStat1.amount);
        if (num != 0)
        {
          bool flag = false;
          int index2 = 0;
          for (int count2 = stats1.Count; index2 < count2; ++index2)
          {
            InvStat invStat2 = stats1[index2];
            if (invStat2.id == invStat1.id && invStat2.modifier == invStat1.modifier)
            {
              invStat2.amount += num;
              flag = true;
              break;
            }
          }
          if (!flag)
            stats1.Add(new InvStat()
            {
              id = invStat1.id,
              amount = num,
              modifier = invStat1.modifier
            });
        }
      }
      stats1.Sort(new Comparison<InvStat>(InvStat.CompareArmor));
    }
    return stats1;
  }

  public enum Quality
  {
    Broken,
    Cursed,
    Damaged,
    Worn,
    Sturdy,
    Polished,
    Improved,
    Crafted,
    Superior,
    Enchanted,
    Epic,
    Legendary,
    _LastDoNotUse,
  }
}
