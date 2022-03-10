using System;
using UnityEngine;

// Token: 0x0200034F RID: 847
[RequireComponent(typeof(Camera))]
public class Letterboxing : MonoBehaviour
{
	// Token: 0x0600195B RID: 6491 RVA: 0x000FE58C File Offset: 0x000FC78C
	private void Start()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1f - num / 1.7777778f;
		base.GetComponent<Camera>().rect = new Rect(0f, num2 / 2f, 1f, 1f - num2);
	}

	// Token: 0x04002810 RID: 10256
	private const float KEEP_ASPECT = 1.7777778f;
}
