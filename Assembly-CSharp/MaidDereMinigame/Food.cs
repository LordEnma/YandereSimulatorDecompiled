using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000594 RID: 1428
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004C10 RID: 19472
		public Sprite largeSprite;

		// Token: 0x04004C11 RID: 19473
		public Sprite smallSprite;

		// Token: 0x04004C12 RID: 19474
		public float cookTimeMultiplier = 1f;
	}
}
