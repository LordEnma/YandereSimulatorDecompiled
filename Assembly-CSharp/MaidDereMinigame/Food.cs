// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Food
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
