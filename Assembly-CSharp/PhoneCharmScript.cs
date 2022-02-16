using System;
using UnityEngine;

// Token: 0x0200039D RID: 925
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001A70 RID: 6768 RVA: 0x0011B185 File Offset: 0x00119385
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
