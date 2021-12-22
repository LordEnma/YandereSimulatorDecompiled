using System;
using UnityEngine;

// Token: 0x020002C4 RID: 708
public class FallingOsanaScript : MonoBehaviour
{
	// Token: 0x06001483 RID: 5251 RVA: 0x000C81F4 File Offset: 0x000C63F4
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

	// Token: 0x04001FCD RID: 8141
	public StudentScript Osana;

	// Token: 0x04001FCE RID: 8142
	public GameObject GroundImpact;
}
