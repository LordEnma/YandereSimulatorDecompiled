using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059B RID: 1435
	[Serializable]
	public class SetupVariables
	{
		// Token: 0x04004C20 RID: 19488
		[Tooltip("Transition time for white fade between scenes")]
		public float transitionTime = 1f;

		// Token: 0x04004C21 RID: 19489
		[Tooltip("Base rate at which customers spawn.")]
		public float customerSpawnRate = 5f;

		// Token: 0x04004C22 RID: 19490
		[Tooltip("Amount of variance on the customer spawn rate. A random value between this and negative this is added to the base spawn rate.")]
		public float customerSpawnVariance = 5f;

		// Token: 0x04004C23 RID: 19491
		[Tooltip("Speed the player can move.")]
		public float playerMoveSpeed = 2f;

		// Token: 0x04004C24 RID: 19492
		[Tooltip("Speed the customers can move.")]
		public float customerMoveSpeed = 2f;

		// Token: 0x04004C25 RID: 19493
		[Tooltip("Patience degradation multiplier. Patience degrades at 1 point per second times this value.")]
		public float customerPatienceDegradation = 5f;

		// Token: 0x04004C26 RID: 19494
		[Tooltip("Time the customer will show their order. Patience resets after this amount of time.")]
		public float timeSpentOrdering = 2f;

		// Token: 0x04004C27 RID: 19495
		[Tooltip("Time the customer will stay in their chair eating after receiving their food.")]
		public float timeSpentEatingFood = 5f;

		// Token: 0x04004C28 RID: 19496
		[Tooltip("Base cooking time for food. This value is multiplied by the dish's individual cooking time multiplier. By default, they are all set to 1.")]
		public float baseCookingTime = 3f;

		// Token: 0x04004C29 RID: 19497
		[Tooltip("Base pay for the minigame.")]
		public float basePay = 100f;

		// Token: 0x04004C2A RID: 19498
		[Tooltip("Base tip multiplier. Tip is customer's remaining patience multiplied by this value.")]
		public float baseTip = 0.1f;

		// Token: 0x04004C2B RID: 19499
		[Tooltip("Time in seconds for the game to last.")]
		public float gameTime = 60f;

		// Token: 0x04004C2C RID: 19500
		[Tooltip("Game will fail if this many customers leave without being served.")]
		public int failQuantity = 5;
	}
}
