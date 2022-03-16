using System;
using UnityEngine;

// Token: 0x020003AE RID: 942
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001AD9 RID: 6873 RVA: 0x00126168 File Offset: 0x00124368
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
