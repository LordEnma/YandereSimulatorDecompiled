using System;
using UnityEngine;

// Token: 0x020002C7 RID: 711
public class FallingOsanaScript : MonoBehaviour
{
	// Token: 0x0600149A RID: 5274 RVA: 0x000C9C00 File Offset: 0x000C7E00
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

	// Token: 0x0400200E RID: 8206
	public StudentScript Osana;

	// Token: 0x0400200F RID: 8207
	public GameObject GroundImpact;
}
