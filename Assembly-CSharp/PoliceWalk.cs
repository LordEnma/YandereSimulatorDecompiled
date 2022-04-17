using System;
using UnityEngine;

// Token: 0x020003B2 RID: 946
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001AEC RID: 6892 RVA: 0x00126E18 File Offset: 0x00125018
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
