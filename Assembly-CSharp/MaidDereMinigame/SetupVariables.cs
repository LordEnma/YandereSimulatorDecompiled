using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000598 RID: 1432
	[Serializable]
	public class SetupVariables
	{
		// Token: 0x04004BF1 RID: 19441
		[Tooltip("Transition time for white fade between scenes")]
		public float transitionTime = 1f;

		// Token: 0x04004BF2 RID: 19442
		[Tooltip("Base rate at which customers spawn.")]
		public float customerSpawnRate = 5f;

		// Token: 0x04004BF3 RID: 19443
		[Tooltip("Amount of variance on the customer spawn rate. A random value between this and negative this is added to the base spawn rate.")]
		public float customerSpawnVariance = 5f;

		// Token: 0x04004BF4 RID: 19444
		[Tooltip("Speed the player can move.")]
		public float playerMoveSpeed = 2f;

		// Token: 0x04004BF5 RID: 19445
		[Tooltip("Speed the customers can move.")]
		public float customerMoveSpeed = 2f;

		// Token: 0x04004BF6 RID: 19446
		[Tooltip("Patience degradation multiplier. Patience degrades at 1 point per second times this value.")]
		public float customerPatienceDegradation = 5f;

		// Token: 0x04004BF7 RID: 19447
		[Tooltip("Time the customer will show their order. Patience resets after this amount of time.")]
		public float timeSpentOrdering = 2f;

		// Token: 0x04004BF8 RID: 19448
		[Tooltip("Time the customer will stay in their chair eating after receiving their food.")]
		public float timeSpentEatingFood = 5f;

		// Token: 0x04004BF9 RID: 19449
		[Tooltip("Base cooking time for food. This value is multiplied by the dish's individual cooking time multiplier. By default, they are all set to 1.")]
		public float baseCookingTime = 3f;

		// Token: 0x04004BFA RID: 19450
		[Tooltip("Base pay for the minigame.")]
		public float basePay = 100f;

		// Token: 0x04004BFB RID: 19451
		[Tooltip("Base tip multiplier. Tip is customer's remaining patience multiplied by this value.")]
		public float baseTip = 0.1f;

		// Token: 0x04004BFC RID: 19452
		[Tooltip("Time in seconds for the game to last.")]
		public float gameTime = 60f;

		// Token: 0x04004BFD RID: 19453
		[Tooltip("Game will fail if this many customers leave without being served.")]
		public int failQuantity = 5;
	}
}
