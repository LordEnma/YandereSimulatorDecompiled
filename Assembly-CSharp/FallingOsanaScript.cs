using System;
using UnityEngine;

// Token: 0x020002C8 RID: 712
public class FallingOsanaScript : MonoBehaviour
{
	// Token: 0x060014A4 RID: 5284 RVA: 0x000CA37C File Offset: 0x000C857C
	private void Update()
	{
		if (base.transform.position.y > 0f)
		{
			base.transform.position += new Vector3(0f, -1.0001f, 0f);
		}
		if (base.transform.position.y < 0f)
		{
			base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
			UnityEngine.Object.Instantiate<GameObject>(this.GroundImpact, base.transform.position, Quaternion.identity);
		}
	}

	// Token: 0x0400201B RID: 8219
	public StudentScript Osana;

	// Token: 0x0400201C RID: 8220
	public GameObject GroundImpact;
}
