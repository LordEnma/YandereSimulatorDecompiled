using System;
using UnityEngine;

// Token: 0x02000521 RID: 1313
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002189 RID: 8585 RVA: 0x001EDFF9 File Offset: 0x001EC1F9
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x0600218A RID: 8586 RVA: 0x001EE014 File Offset: 0x001EC214
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x040049D2 RID: 18898
	public Camera cameraToLookAt;
}
