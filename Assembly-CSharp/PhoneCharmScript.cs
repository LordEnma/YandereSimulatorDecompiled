using System;
using UnityEngine;

// Token: 0x0200039E RID: 926
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001A7A RID: 6778 RVA: 0x0011BF71 File Offset: 0x0011A171
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
