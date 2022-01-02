using System;
using UnityEngine;

// Token: 0x0200039A RID: 922
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001A5F RID: 6751 RVA: 0x0011A359 File Offset: 0x00118559
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
