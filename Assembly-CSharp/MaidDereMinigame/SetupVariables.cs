// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.SetupVariables
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace MaidDereMinigame
{
  [Serializable]
  public class SetupVariables
  {
    [Tooltip("Transition time for white fade between scenes")]
    public float transitionTime = 1f;
    [Tooltip("Base rate at which customers spawn.")]
    public float customerSpawnRate = 5f;
    [Tooltip("Amount of variance on the customer spawn rate. A random value between this and negative this is added to the base spawn rate.")]
    public float customerSpawnVariance = 5f;
    [Tooltip("Speed the player can move.")]
    public float playerMoveSpeed = 2f;
    [Tooltip("Speed the customers can move.")]
    public float customerMoveSpeed = 2f;
    [Tooltip("Patience degradation multiplier. Patience degrades at 1 point per second times this value.")]
    public float customerPatienceDegradation = 5f;
    [Tooltip("Time the customer will show their order. Patience resets after this amount of time.")]
    public float timeSpentOrdering = 2f;
    [Tooltip("Time the customer will stay in their chair eating after receiving their food.")]
    public float timeSpentEatingFood = 5f;
    [Tooltip("Base cooking time for food. This value is multiplied by the dish's individual cooking time multiplier. By default, they are all set to 1.")]
    public float baseCookingTime = 3f;
    [Tooltip("Base pay for the minigame.")]
    public float basePay = 100f;
    [Tooltip("Base tip multiplier. Tip is customer's remaining patience multiplied by this value.")]
    public float baseTip = 0.1f;
    [Tooltip("Time in seconds for the game to last.")]
    public float gameTime = 60f;
    [Tooltip("Game will fail if this many customers leave without being served.")]
    public int failQuantity = 5;
  }
}
