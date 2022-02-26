using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000596 RID: 1430
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004C29 RID: 19497
		public Sprite largeSprite;

		// Token: 0x04004C2A RID: 19498
		public Sprite smallSprite;

		// Token: 0x04004C2B RID: 19499
		public float cookTimeMultiplier = 1f;
	}
}
