using System;
using UnityEngine;

// Token: 0x020002C4 RID: 708
public class FallingOsanaScript : MonoBehaviour
{
	// Token: 0x06001483 RID: 5251 RVA: 0x000C843C File Offset: 0x000C663C
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

	// Token: 0x04001FD0 RID: 8144
	public StudentScript Osana;

	// Token: 0x04001FD1 RID: 8145
	public GameObject GroundImpact;
}
