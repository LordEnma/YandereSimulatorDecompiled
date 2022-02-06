using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
internal class ToiletFlushScript : MonoBehaviour
{
	// Token: 0x0400400F RID: 16399
	[Header("=== Toilet Related ===")]
	public GameObject Toilet;

	// Token: 0x04004010 RID: 16400
	private GameObject toilet;

	// Token: 0x04004011 RID: 16401
	private static System.Random random = new System.Random();

	// Token: 0x04004012 RID: 16402
	private StudentManagerScript StudentManager;
}
