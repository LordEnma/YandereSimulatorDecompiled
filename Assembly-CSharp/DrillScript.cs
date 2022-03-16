using System;
using UnityEngine;

// Token: 0x02000290 RID: 656
public class DrillScript : MonoBehaviour
{
	// Token: 0x060013C2 RID: 5058 RVA: 0x000BB3AE File Offset: 0x000B95AE
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
