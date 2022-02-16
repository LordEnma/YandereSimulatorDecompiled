using System;
using UnityEngine;

// Token: 0x02000259 RID: 601
public class ConstantRandomRotation : MonoBehaviour
{
	// Token: 0x060012B2 RID: 4786 RVA: 0x00099094 File Offset: 0x00097294
	private void Update()
	{
		int num = UnityEngine.Random.Range(0, 360);
		int num2 = UnityEngine.Random.Range(0, 360);
		int num3 = UnityEngine.Random.Range(0, 360);
		base.transform.Rotate((float)num, (float)num2, (float)num3);
	}
}
