using System;
using UnityEngine;

// Token: 0x0200039A RID: 922
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001A5D RID: 6749 RVA: 0x0011A07D File Offset: 0x0011827D
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
