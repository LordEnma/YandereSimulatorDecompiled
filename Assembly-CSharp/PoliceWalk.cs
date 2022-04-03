using System;
using UnityEngine;

// Token: 0x020003B1 RID: 945
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001AE2 RID: 6882 RVA: 0x00126860 File Offset: 0x00124A60
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
