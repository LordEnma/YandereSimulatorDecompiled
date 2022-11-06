// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Food
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
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
