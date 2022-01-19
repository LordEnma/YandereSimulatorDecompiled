using System;
using UnityEngine;

// Token: 0x0200028E RID: 654
public class DrillScript : MonoBehaviour
{
	// Token: 0x060013B1 RID: 5041 RVA: 0x000BA312 File Offset: 0x000B8512
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
