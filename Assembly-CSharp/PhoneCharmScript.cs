using System;
using UnityEngine;

// Token: 0x020003A2 RID: 930
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001A9F RID: 6815 RVA: 0x0011E461 File Offset: 0x0011C661
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
