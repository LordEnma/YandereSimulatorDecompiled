using System;
using UnityEngine;

// Token: 0x02000258 RID: 600
public class ConstantRandomRotation : MonoBehaviour
{
	// Token: 0x060012AB RID: 4779 RVA: 0x00098E1C File Offset: 0x0009701C
	private void Update()
	{
		int num = UnityEngine.Random.Range(0, 360);
		int num2 = UnityEngine.Random.Range(0, 360);
		int num3 = UnityEngine.Random.Range(0, 360);
		base.transform.Rotate((float)num, (float)num2, (float)num3);
	}
}
