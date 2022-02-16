using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000595 RID: 1429
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004C19 RID: 19481
		public Sprite largeSprite;

		// Token: 0x04004C1A RID: 19482
		public Sprite smallSprite;

		// Token: 0x04004C1B RID: 19483
		public float cookTimeMultiplier = 1f;
	}
}
