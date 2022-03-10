using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000597 RID: 1431
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004C46 RID: 19526
		public Sprite largeSprite;

		// Token: 0x04004C47 RID: 19527
		public Sprite smallSprite;

		// Token: 0x04004C48 RID: 19528
		public float cookTimeMultiplier = 1f;
	}
}
