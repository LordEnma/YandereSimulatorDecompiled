using System;
using UnityEngine;

// Token: 0x0200039E RID: 926
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001A84 RID: 6788 RVA: 0x0011CA81 File Offset: 0x0011AC81
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
