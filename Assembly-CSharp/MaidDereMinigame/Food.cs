// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Food
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
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
