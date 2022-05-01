using System;
using UnityEngine;

// Token: 0x02000259 RID: 601
public class ConstantRandomRotation : MonoBehaviour
{
	// Token: 0x060012B5 RID: 4789 RVA: 0x00099B8C File Offset: 0x00097D8C
	private void Update()
	{
		int num = UnityEngine.Random.Range(0, 360);
		int num2 = UnityEngine.Random.Range(0, 360);
		int num3 = UnityEngine.Random.Range(0, 360);
		base.transform.Rotate((float)num, (float)num2, (float)num3);
	}
}
