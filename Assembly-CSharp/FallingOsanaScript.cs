using System;
using UnityEngine;

// Token: 0x020002C3 RID: 707
public class FallingOsanaScript : MonoBehaviour
{
	// Token: 0x0600147C RID: 5244 RVA: 0x000C7A58 File Offset: 0x000C5C58
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

	// Token: 0x04001FAD RID: 8109
	public StudentScript Osana;

	// Token: 0x04001FAE RID: 8110
	public GameObject GroundImpact;
}
