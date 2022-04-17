using System;
using UnityEngine;

// Token: 0x02000351 RID: 849
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour
{
	// Token: 0x06001972 RID: 6514 RVA: 0x000FF768 File Offset: 0x000FD968
	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1f - num / 1.7777778f;
		base.GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
	}

	// Token: 0x0400284B RID: 10315
	private const float KEEP_ASPECT = 1.7777778f;
}
