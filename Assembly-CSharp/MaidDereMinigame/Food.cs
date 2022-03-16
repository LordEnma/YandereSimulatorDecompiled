using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059B RID: 1435
	[CreateAssetMenu(fileName = "New Food Item", menuName = "Food")]
	public class Food : ScriptableObject
	{
		// Token: 0x04004CA5 RID: 19621
		public Sprite largeSprite;

		// Token: 0x04004CA6 RID: 19622
		public Sprite smallSprite;

		// Token: 0x04004CA7 RID: 19623
		public float cookTimeMultiplier = 1f;
	}
}
