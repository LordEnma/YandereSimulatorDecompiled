using System;
using UnityEngine;

// Token: 0x0200025A RID: 602
public class ConstantRandomRotation : MonoBehaviour
{
	// Token: 0x060012B7 RID: 4791 RVA: 0x00099E54 File Offset: 0x00098054
	private void Update()
	{
		int num = UnityEngine.Random.Range(0, 360);
		int num2 = UnityEngine.Random.Range(0, 360);
		int num3 = UnityEngine.Random.Range(0, 360);
		base.transform.Rotate((float)num, (float)num2, (float)num3);
	}
}
