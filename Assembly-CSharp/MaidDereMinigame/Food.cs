using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000591 RID: 1425
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004BD8 RID: 19416
		public Sprite largeSprite;

		// Token: 0x04004BD9 RID: 19417
		public Sprite smallSprite;

		// Token: 0x04004BDA RID: 19418
		public float cookTimeMultiplier = 1f;
	}
}
