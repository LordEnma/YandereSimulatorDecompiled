using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001A8B RID: 6795 RVA: 0x0011D0E1 File Offset: 0x0011B2E1
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
