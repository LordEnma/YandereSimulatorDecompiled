using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A0 RID: 1440
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004CD7 RID: 19671
		public Sprite largeSprite;

		// Token: 0x04004CD8 RID: 19672
		public Sprite smallSprite;

		// Token: 0x04004CD9 RID: 19673
		public float cookTimeMultiplier = 1f;
	}
}
