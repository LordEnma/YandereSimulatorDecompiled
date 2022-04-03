using System;
using UnityEngine;

// Token: 0x02000290 RID: 656
public class DrillScript : MonoBehaviour
{
	// Token: 0x060013C3 RID: 5059 RVA: 0x000BB4BA File Offset: 0x000B96BA
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
