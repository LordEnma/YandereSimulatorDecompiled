using System;
using UnityEngine;

// Token: 0x020003AD RID: 941
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001AC5 RID: 6853 RVA: 0x00124690 File Offset: 0x00122890
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
