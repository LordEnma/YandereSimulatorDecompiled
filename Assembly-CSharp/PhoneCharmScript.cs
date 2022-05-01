using System;
using UnityEngine;

// Token: 0x020003A1 RID: 929
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001A99 RID: 6809 RVA: 0x0011DB31 File Offset: 0x0011BD31
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
