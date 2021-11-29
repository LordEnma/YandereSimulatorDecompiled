using System;
using UnityEngine;

// Token: 0x02000266 RID: 614
public class CreepyArmScript : MonoBehaviour
{
	// Token: 0x060012F6 RID: 4854 RVA: 0x000A779C File Offset: 0x000A599C
	private void Update()
	{
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime * 0.1f, base.transform.position.z);
	}
}
