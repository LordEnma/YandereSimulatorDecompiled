using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000593 RID: 1427
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004BF5 RID: 19445
		public Sprite largeSprite;

		// Token: 0x04004BF6 RID: 19446
		public Sprite smallSprite;

		// Token: 0x04004BF7 RID: 19447
		public float cookTimeMultiplier = 1f;
	}
}
