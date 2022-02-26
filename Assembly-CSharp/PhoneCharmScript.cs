using System;
using UnityEngine;

// Token: 0x0200039E RID: 926
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001A79 RID: 6777 RVA: 0x0011BB99 File Offset: 0x00119D99
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
