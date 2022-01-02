using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000591 RID: 1425
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004BE1 RID: 19425
		public Sprite largeSprite;

		// Token: 0x04004BE2 RID: 19426
		public Sprite smallSprite;

		// Token: 0x04004BE3 RID: 19427
		public float cookTimeMultiplier = 1f;
	}
}
