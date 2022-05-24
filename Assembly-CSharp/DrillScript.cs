using System;
using UnityEngine;

// Token: 0x02000292 RID: 658
public class DrillScript : MonoBehaviour
{
	// Token: 0x060013CF RID: 5071 RVA: 0x000BBEC2 File Offset: 0x000BA0C2
	private void LateUpdate()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * 3600f);
	}
}
