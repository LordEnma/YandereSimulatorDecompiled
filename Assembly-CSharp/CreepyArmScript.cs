using System;
using UnityEngine;

// Token: 0x02000267 RID: 615
public class CreepyArmScript : MonoBehaviour
{
	// Token: 0x060012FE RID: 4862 RVA: 0x000A8094 File Offset: 0x000A6294
	private void Update()
	{
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime * 0.1f, base.transform.position.z);
	}
}
