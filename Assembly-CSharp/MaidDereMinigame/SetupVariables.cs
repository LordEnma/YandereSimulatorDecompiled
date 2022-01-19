using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059B RID: 1435
	[Serializable]
	public class SetupVariables
	{
		// Token: 0x04004C15 RID: 19477
		[Tooltip("Transition time for white fade between scenes")]
		public float transitionTime = 1f;

		// Token: 0x04004C16 RID: 19478
		[Tooltip("Base rate at which customers spawn.")]
		public float customerSpawnRate = 5f;

		// Token: 0x04004C17 RID: 19479
		[Tooltip("Amount of variance on the customer spawn rate. A random value between this and negative this is added to the base spawn rate.")]
		public float customerSpawnVariance = 5f;

		// Token: 0x04004C18 RID: 19480
		[Tooltip("Speed the player can move.")]
		public float playerMoveSpeed = 2f;

		// Token: 0x04004C19 RID: 19481
		[Tooltip("Speed the customers can move.")]
		public float customerMoveSpeed = 2f;

		// Token: 0x04004C1A RID: 19482
		[Tooltip("Patience degradation multiplier. Patience degrades at 1 point per second times this value.")]
		public float customerPatienceDegradation = 5f;

		// Token: 0x04004C1B RID: 19483
		[Tooltip("Time the customer will show their order. Patience resets after this amount of time.")]
		public float timeSpentOrdering = 2f;

		// Token: 0x04004C1C RID: 19484
		[Tooltip("Time the customer will stay in their chair eating after receiving their food.")]
		public float timeSpentEatingFood = 5f;

		// Token: 0x04004C1D RID: 19485
		[Tooltip("Base cooking time for food. This value is multiplied by the dish's individual cooking time multiplier. By default, they are all set to 1.")]
		public float baseCookingTime = 3f;

		// Token: 0x04004C1E RID: 19486
		[Tooltip("Base pay for the minigame.")]
		public float basePay = 100f;

		// Token: 0x04004C1F RID: 19487
		[Tooltip("Base tip multiplier. Tip is customer's remaining patience multiplied by this value.")]
		public float baseTip = 0.1f;

		// Token: 0x04004C20 RID: 19488
		[Tooltip("Time in seconds for the game to last.")]
		public float gameTime = 60f;

		// Token: 0x04004C21 RID: 19489
		[Tooltip("Game will fail if this many customers leave without being served.")]
		public int failQuantity = 5;
	}
}
