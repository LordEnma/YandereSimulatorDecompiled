using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A2 RID: 1442
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004D06 RID: 19718
		public Sprite largeSprite;

		// Token: 0x04004D07 RID: 19719
		public Sprite smallSprite;

		// Token: 0x04004D08 RID: 19720
		public float cookTimeMultiplier = 1f;
	}
}
