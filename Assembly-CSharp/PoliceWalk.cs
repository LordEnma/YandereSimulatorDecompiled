using System;
using UnityEngine;

// Token: 0x020003B3 RID: 947
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001AF7 RID: 6903 RVA: 0x00128024 File Offset: 0x00126224
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
