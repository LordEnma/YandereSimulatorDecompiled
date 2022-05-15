using System;
using UnityEngine;

// Token: 0x020003B3 RID: 947
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001AF6 RID: 6902 RVA: 0x00127DF4 File Offset: 0x00125FF4
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
