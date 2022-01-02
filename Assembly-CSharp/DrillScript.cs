using System;
using UnityEngine;

// Token: 0x0200028D RID: 653
public class DrillScript : MonoBehaviour
{
	// Token: 0x060013AE RID: 5038 RVA: 0x000BA20A File Offset: 0x000B840A
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
