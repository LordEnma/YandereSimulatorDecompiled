using System;
using UnityEngine;

// Token: 0x020002C5 RID: 709
public class FallingOsanaScript : MonoBehaviour
{
	// Token: 0x06001487 RID: 5255 RVA: 0x000C871C File Offset: 0x000C691C
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

	// Token: 0x04001FD4 RID: 8148
	public StudentScript Osana;

	// Token: 0x04001FD5 RID: 8149
	public GameObject GroundImpact;
}
