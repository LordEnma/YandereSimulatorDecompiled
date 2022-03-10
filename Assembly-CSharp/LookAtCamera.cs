using System;
using UnityEngine;

// Token: 0x02000518 RID: 1304
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002161 RID: 8545 RVA: 0x001EA821 File Offset: 0x001E8A21
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x06002162 RID: 8546 RVA: 0x001EA83C File Offset: 0x001E8A3C
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x04004941 RID: 18753
	public Camera cameraToLookAt;
}
