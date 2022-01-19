using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
internal class ToiletFlushScript : MonoBehaviour
{
	// Token: 0x04003FFE RID: 16382
	[Header("=== Toilet Related ===")]
	public GameObject Toilet;

	// Token: 0x04003FFF RID: 16383
	private GameObject toilet;

	// Token: 0x04004000 RID: 16384
	private static System.Random random = new System.Random();

	// Token: 0x04004001 RID: 16385
	private StudentManagerScript StudentManager;
}
