using System;
using UnityEngine;

// Token: 0x020003A9 RID: 937
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001AAA RID: 6826 RVA: 0x00122BE8 File Offset: 0x00120DE8
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
