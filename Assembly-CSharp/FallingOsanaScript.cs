using System;
using UnityEngine;

// Token: 0x020002C7 RID: 711
public class FallingOsanaScript : MonoBehaviour
{
	// Token: 0x06001496 RID: 5270 RVA: 0x000C965C File Offset: 0x000C785C
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

	// Token: 0x04001FFB RID: 8187
	public StudentScript Osana;

	// Token: 0x04001FFC RID: 8188
	public GameObject GroundImpact;
}
