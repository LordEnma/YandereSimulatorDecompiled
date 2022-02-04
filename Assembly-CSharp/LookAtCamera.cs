using System;
using UnityEngine;

// Token: 0x02000515 RID: 1301
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002148 RID: 8520 RVA: 0x001E8BB1 File Offset: 0x001E6DB1
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x06002149 RID: 8521 RVA: 0x001E8BCC File Offset: 0x001E6DCC
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x04004908 RID: 18696
	public Camera cameraToLookAt;
}
