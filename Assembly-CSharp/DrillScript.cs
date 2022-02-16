using System;
using UnityEngine;

// Token: 0x0200028F RID: 655
public class DrillScript : MonoBehaviour
{
	// Token: 0x060013B6 RID: 5046 RVA: 0x000BA4EE File Offset: 0x000B86EE
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
