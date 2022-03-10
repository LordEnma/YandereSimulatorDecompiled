using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059E RID: 1438
	[Serializable]
	public class SetupVariables
	{
		// Token: 0x04004C5F RID: 19551
		[Tooltip("Transition time for white fade between scenes")]
		public float transitionTime = 1f;

		// Token: 0x04004C60 RID: 19552
		[Tooltip("Base rate at which customers spawn.")]
		public float customerSpawnRate = 5f;

		// Token: 0x04004C61 RID: 19553
		[Tooltip("Amount of variance on the customer spawn rate. A random value between this and negative this is added to the base spawn rate.")]
		public float customerSpawnVariance = 5f;

		// Token: 0x04004C62 RID: 19554
		[Tooltip("Speed the player can move.")]
		public float playerMoveSpeed = 2f;

		// Token: 0x04004C63 RID: 19555
		[Tooltip("Speed the customers can move.")]
		public float customerMoveSpeed = 2f;

		// Token: 0x04004C64 RID: 19556
		[Tooltip("Patience degradation multiplier. Patience degrades at 1 point per second times this value.")]
		public float customerPatienceDegradation = 5f;

		// Token: 0x04004C65 RID: 19557
		[Tooltip("Time the customer will show their order. Patience resets after this amount of time.")]
		public float timeSpentOrdering = 2f;

		// Token: 0x04004C66 RID: 19558
		[Tooltip("Time the customer will stay in their chair eating after receiving their food.")]
		public float timeSpentEatingFood = 5f;

		// Token: 0x04004C67 RID: 19559
		[Tooltip("Base cooking time for food. This value is multiplied by the dish's individual cooking time multiplier. By default, they are all set to 1.")]
		public float baseCookingTime = 3f;

		// Token: 0x04004C68 RID: 19560
		[Tooltip("Base pay for the minigame.")]
		public float basePay = 100f;

		// Token: 0x04004C69 RID: 19561
		[Tooltip("Base tip multiplier. Tip is customer's remaining patience multiplied by this value.")]
		public float baseTip = 0.1f;

		// Token: 0x04004C6A RID: 19562
		[Tooltip("Time in seconds for the game to last.")]
		public float gameTime = 60f;

		// Token: 0x04004C6B RID: 19563
		[Tooltip("Game will fail if this many customers leave without being served.")]
		public int failQuantity = 5;
	}
}
