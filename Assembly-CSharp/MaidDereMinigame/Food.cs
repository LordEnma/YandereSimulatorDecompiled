using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000594 RID: 1428
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004BFC RID: 19452
		public Sprite largeSprite;

		// Token: 0x04004BFD RID: 19453
		public Sprite smallSprite;

		// Token: 0x04004BFE RID: 19454
		public float cookTimeMultiplier = 1f;
	}
}
