using System;
using UnityEngine;

// Token: 0x02000399 RID: 921
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001A55 RID: 6741 RVA: 0x0011983D File Offset: 0x00117A3D
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
