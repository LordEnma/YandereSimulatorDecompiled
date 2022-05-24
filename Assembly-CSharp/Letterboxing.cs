using System;
using UnityEngine;

// Token: 0x02000352 RID: 850
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour
{
	// Token: 0x0600197D RID: 6525 RVA: 0x00100678 File Offset: 0x000FE878
	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1f - num / 1.7777778f;
		base.GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
	}

	// Token: 0x0400286C RID: 10348
	private const float KEEP_ASPECT = 1.7777778f;
}
