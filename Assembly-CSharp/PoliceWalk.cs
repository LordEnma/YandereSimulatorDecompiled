using System;
using UnityEngine;

// Token: 0x020003B2 RID: 946
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001AF0 RID: 6896 RVA: 0x001273F8 File Offset: 0x001255F8
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
