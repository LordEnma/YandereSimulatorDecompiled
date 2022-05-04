using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DrillScript : MonoBehaviour
{
	// Token: 0x060013CD RID: 5069 RVA: 0x000BBBB6 File Offset: 0x000B9DB6
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
