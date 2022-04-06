using System;
using UnityEngine;

// Token: 0x02000522 RID: 1314
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002191 RID: 8593 RVA: 0x001EE529 File Offset: 0x001EC729
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x06002192 RID: 8594 RVA: 0x001EE544 File Offset: 0x001EC744
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x040049D6 RID: 18902
	public Camera cameraToLookAt;
}
