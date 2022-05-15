using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A3 RID: 1443
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004D2D RID: 19757
		public Sprite largeSprite;

		// Token: 0x04004D2E RID: 19758
		public Sprite smallSprite;

		// Token: 0x04004D2F RID: 19759
		public float cookTimeMultiplier = 1f;
	}
}
