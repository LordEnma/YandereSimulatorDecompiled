using System;
using UnityEngine;

// Token: 0x0200039C RID: 924
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001A66 RID: 6758 RVA: 0x0011A6A1 File Offset: 0x001188A1
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
