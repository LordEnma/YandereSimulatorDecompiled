using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A1 RID: 1441
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004CED RID: 19693
		public Sprite largeSprite;

		// Token: 0x04004CEE RID: 19694
		public Sprite smallSprite;

		// Token: 0x04004CEF RID: 19695
		public float cookTimeMultiplier = 1f;
	}
}
