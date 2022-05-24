using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A3 RID: 1443
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004D36 RID: 19766
		public Sprite largeSprite;

		// Token: 0x04004D37 RID: 19767
		public Sprite smallSprite;

		// Token: 0x04004D38 RID: 19768
		public float cookTimeMultiplier = 1f;
	}
}
