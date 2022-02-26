using System;
using UnityEngine;

// Token: 0x0200034F RID: 847
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour
{
	// Token: 0x0600195B RID: 6491 RVA: 0x000FE24C File Offset: 0x000FC44C
	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1f - num / 1.7777778f;
		base.GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
	}

	// Token: 0x040027FA RID: 10234
	private const float KEEP_ASPECT = 1.7777778f;
}
