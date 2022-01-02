using System;
using UnityEngine;

// Token: 0x02000012 RID: 18
public class MGPMPickUpScript : MonoBehaviour
{
	// Token: 0x0600003F RID: 63 RVA: 0x00006C70 File Offset: 0x00004E70
	private void Update()
	{
		base.transform.Translate(Vector3.up * Time.deltaTime * this.Speed * -1f);
		if (base.transform.localPosition.y < -300f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040000F3 RID: 243
	public float Speed;
}
