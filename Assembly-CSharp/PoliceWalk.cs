using System;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001AB2 RID: 6834 RVA: 0x0012343C File Offset: 0x0012163C
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
