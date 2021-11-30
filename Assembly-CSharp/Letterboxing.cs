using System;
using UnityEngine;

// Token: 0x0200034B RID: 843
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour
{
	// Token: 0x0600193B RID: 6459 RVA: 0x000FC1E0 File Offset: 0x000FA3E0
	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1f - num / 1.7777778f;
		base.GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
	}

	// Token: 0x040027AB RID: 10155
	private const float KEEP_ASPECT = 1.7777778f;
}
