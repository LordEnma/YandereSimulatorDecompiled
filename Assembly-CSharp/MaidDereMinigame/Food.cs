// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Food
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  [CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
  public class Food : ScriptableObject
  {
    public Sprite largeSprite;
    public Sprite smallSprite;
    public float cookTimeMultiplier = 1f;
  }
}
