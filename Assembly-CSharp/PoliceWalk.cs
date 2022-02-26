using System;
using UnityEngine;

// Token: 0x020003AE RID: 942
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001ACE RID: 6862 RVA: 0x001250D0 File Offset: 0x001232D0
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
