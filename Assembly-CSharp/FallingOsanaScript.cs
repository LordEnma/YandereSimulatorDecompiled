using System;
using UnityEngine;

// Token: 0x020002C6 RID: 710
public class FallingOsanaScript : MonoBehaviour
{
	// Token: 0x0600148D RID: 5261 RVA: 0x000C8C2C File Offset: 0x000C6E2C
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

	// Token: 0x04001FE3 RID: 8163
	public StudentScript Osana;

	// Token: 0x04001FE4 RID: 8164
	public GameObject GroundImpact;
}
