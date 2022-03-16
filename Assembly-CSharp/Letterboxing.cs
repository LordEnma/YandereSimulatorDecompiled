using System;
using UnityEngine;

// Token: 0x0200034F RID: 847
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour
{
	// Token: 0x06001962 RID: 6498 RVA: 0x000FED48 File Offset: 0x000FCF48
	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1f - num / 1.7777778f;
		base.GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
	}

	// Token: 0x0400282D RID: 10285
	private const float KEEP_ASPECT = 1.7777778f;
}
