using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DrillScript : MonoBehaviour
{
	// Token: 0x060013CD RID: 5069 RVA: 0x000BBBEA File Offset: 0x000B9DEA
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
