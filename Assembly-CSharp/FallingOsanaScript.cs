using System;
using UnityEngine;

// Token: 0x020002C9 RID: 713
public class FallingOsanaScript : MonoBehaviour
{
	// Token: 0x060014A6 RID: 5286 RVA: 0x000CA644 File Offset: 0x000C8844
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

	// Token: 0x04002022 RID: 8226
	public StudentScript Osana;

	// Token: 0x04002023 RID: 8227
	public GameObject GroundImpact;
}
