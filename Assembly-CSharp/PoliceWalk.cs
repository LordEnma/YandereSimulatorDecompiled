using System;
using UnityEngine;

// Token: 0x020003B2 RID: 946
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001AE8 RID: 6888 RVA: 0x00126A0C File Offset: 0x00124C0C
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
