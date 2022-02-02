using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000594 RID: 1428
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004C07 RID: 19463
		public Sprite largeSprite;

		// Token: 0x04004C08 RID: 19464
		public Sprite smallSprite;

		// Token: 0x04004C09 RID: 19465
		public float cookTimeMultiplier = 1f;
	}
}
