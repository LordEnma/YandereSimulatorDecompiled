using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DrillScript : MonoBehaviour
{
	// Token: 0x060013C9 RID: 5065 RVA: 0x000BB746 File Offset: 0x000B9946
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
