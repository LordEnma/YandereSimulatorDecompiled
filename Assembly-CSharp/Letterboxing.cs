using System;
using UnityEngine;

// Token: 0x02000350 RID: 848
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour
{
	// Token: 0x06001968 RID: 6504 RVA: 0x000FF3D4 File Offset: 0x000FD5D4
	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1f - num / 1.7777778f;
		base.GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
	}

	// Token: 0x04002840 RID: 10304
	private const float KEEP_ASPECT = 1.7777778f;
}
