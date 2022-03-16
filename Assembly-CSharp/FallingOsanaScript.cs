using System;
using UnityEngine;

// Token: 0x020002C7 RID: 711
public class FallingOsanaScript : MonoBehaviour
{
	// Token: 0x06001499 RID: 5273 RVA: 0x000C9ACC File Offset: 0x000C7CCC
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

	// Token: 0x0400200B RID: 8203
	public StudentScript Osana;

	// Token: 0x0400200C RID: 8204
	public GameObject GroundImpact;
}
