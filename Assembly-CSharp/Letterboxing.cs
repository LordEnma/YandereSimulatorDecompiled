using System;
using UnityEngine;

// Token: 0x0200034E RID: 846
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour
{
	// Token: 0x06001952 RID: 6482 RVA: 0x000FD91C File Offset: 0x000FBB1C
	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1f - num / 1.7777778f;
		base.GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
	}

	// Token: 0x040027EB RID: 10219
	private const float KEEP_ASPECT = 1.7777778f;
}
