using System;
using UnityEngine;

// Token: 0x0200034D RID: 845
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour
{
	// Token: 0x06001948 RID: 6472 RVA: 0x000FD010 File Offset: 0x000FB210
	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1f - num / 1.7777778f;
		base.GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
	}

	// Token: 0x040027D8 RID: 10200
	private const float KEEP_ASPECT = 1.7777778f;
}
