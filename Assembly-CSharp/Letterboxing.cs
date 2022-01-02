using System;
using UnityEngine;

// Token: 0x0200034C RID: 844
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour
{
	// Token: 0x06001944 RID: 6468 RVA: 0x000FCCB0 File Offset: 0x000FAEB0
	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1f - num / 1.7777778f;
		base.GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
	}

	// Token: 0x040027D4 RID: 10196
	private const float KEEP_ASPECT = 1.7777778f;
}
