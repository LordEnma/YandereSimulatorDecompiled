using System;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001AB4 RID: 6836 RVA: 0x00123768 File Offset: 0x00121968
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
