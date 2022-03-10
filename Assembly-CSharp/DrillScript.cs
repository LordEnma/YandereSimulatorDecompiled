using System;
using UnityEngine;

// Token: 0x02000290 RID: 656
public class DrillScript : MonoBehaviour
{
	// Token: 0x060013BF RID: 5055 RVA: 0x000BAF96 File Offset: 0x000B9196
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
