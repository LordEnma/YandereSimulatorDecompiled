using System;
using UnityEngine;

// Token: 0x020003A2 RID: 930
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001AA0 RID: 6816 RVA: 0x0011E691 File Offset: 0x0011C891
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
