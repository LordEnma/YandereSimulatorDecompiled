using System;
using UnityEngine;

// Token: 0x02000351 RID: 849
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour
{
	// Token: 0x06001976 RID: 6518 RVA: 0x000FFC6C File Offset: 0x000FDE6C
	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1f - num / 1.7777778f;
		base.GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
	}

	// Token: 0x04002854 RID: 10324
	private const float KEEP_ASPECT = 1.7777778f;
}
