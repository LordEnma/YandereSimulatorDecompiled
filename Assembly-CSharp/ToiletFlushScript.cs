using System;
using UnityEngine;

// Token: 0x0200047A RID: 1146
internal class ToiletFlushScript : MonoBehaviour
{
	// Token: 0x04003FF7 RID: 16375
	[Header("=== Toilet Related ===")]
	public GameObject Toilet;

	// Token: 0x04003FF8 RID: 16376
	private GameObject toilet;

	// Token: 0x04003FF9 RID: 16377
	private static System.Random random = new System.Random();

	// Token: 0x04003FFA RID: 16378
	private StudentManagerScript StudentManager;
}
