// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Food
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
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
