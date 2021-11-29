using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058F RID: 1423
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004B99 RID: 19353
		public Sprite largeSprite;

		// Token: 0x04004B9A RID: 19354
		public Sprite smallSprite;

		// Token: 0x04004B9B RID: 19355
		public float cookTimeMultiplier = 1f;
	}
}
