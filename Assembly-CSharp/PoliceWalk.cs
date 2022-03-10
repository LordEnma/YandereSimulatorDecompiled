using System;
using UnityEngine;

// Token: 0x020003AE RID: 942
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001ACF RID: 6863 RVA: 0x001254A8 File Offset: 0x001236A8
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
