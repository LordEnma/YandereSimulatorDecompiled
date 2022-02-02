using System;
using UnityEngine;

// Token: 0x0200028E RID: 654
public class DrillScript : MonoBehaviour
{
	// Token: 0x060013B2 RID: 5042 RVA: 0x000BA516 File Offset: 0x000B8716
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
