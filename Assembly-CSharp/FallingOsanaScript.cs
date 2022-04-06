using System;
using UnityEngine;

// Token: 0x020002C8 RID: 712
public class FallingOsanaScript : MonoBehaviour
{
	// Token: 0x060014A0 RID: 5280 RVA: 0x000C9D08 File Offset: 0x000C7F08
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

	// Token: 0x04002010 RID: 8208
	public StudentScript Osana;

	// Token: 0x04002011 RID: 8209
	public GameObject GroundImpact;
}
