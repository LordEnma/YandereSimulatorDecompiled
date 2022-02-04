using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000594 RID: 1428
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004C0D RID: 19469
		public Sprite largeSprite;

		// Token: 0x04004C0E RID: 19470
		public Sprite smallSprite;

		// Token: 0x04004C0F RID: 19471
		public float cookTimeMultiplier = 1f;
	}
}
