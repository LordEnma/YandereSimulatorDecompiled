using System;
using UnityEngine;

// Token: 0x0200028C RID: 652
public class DrillScript : MonoBehaviour
{
	// Token: 0x060013A7 RID: 5031 RVA: 0x000B9A26 File Offset: 0x000B7C26
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
