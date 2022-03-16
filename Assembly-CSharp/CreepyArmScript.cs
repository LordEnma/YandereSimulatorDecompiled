using System;
using UnityEngine;

// Token: 0x02000268 RID: 616
public class CreepyArmScript : MonoBehaviour
{
	// Token: 0x06001305 RID: 4869 RVA: 0x000A87E4 File Offset: 0x000A69E4
	private void Update()
	{
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime * 0.1f, base.transform.position.z);
	}
}
