using System;
using UnityEngine;

// Token: 0x02000269 RID: 617
public class CreepyArmScript : MonoBehaviour
{
	// Token: 0x0600130C RID: 4876 RVA: 0x000A90EC File Offset: 0x000A72EC
	private void Update()
	{
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime * 0.1f, base.transform.position.z);
	}
}
