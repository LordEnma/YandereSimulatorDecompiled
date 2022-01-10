using System;
using UnityEngine;

// Token: 0x02000514 RID: 1300
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002140 RID: 8512 RVA: 0x001E7329 File Offset: 0x001E5529
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x06002141 RID: 8513 RVA: 0x001E7344 File Offset: 0x001E5544
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x040048F0 RID: 18672
	public Camera cameraToLookAt;
}
