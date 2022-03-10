using System;
using UnityEngine;

// Token: 0x02000268 RID: 616
public class CreepyArmScript : MonoBehaviour
{
	// Token: 0x06001302 RID: 4866 RVA: 0x000A8328 File Offset: 0x000A6528
	private void Update()
	{
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime * 0.1f, base.transform.position.z);
	}
}
