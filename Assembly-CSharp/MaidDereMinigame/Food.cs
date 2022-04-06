using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A1 RID: 1441
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004CDB RID: 19675
		public Sprite largeSprite;

		// Token: 0x04004CDC RID: 19676
		public Sprite smallSprite;

		// Token: 0x04004CDD RID: 19677
		public float cookTimeMultiplier = 1f;
	}
}
