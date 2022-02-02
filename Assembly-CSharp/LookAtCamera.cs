using System;
using UnityEngine;

// Token: 0x02000515 RID: 1301
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002146 RID: 8518 RVA: 0x001E8899 File Offset: 0x001E6A99
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x06002147 RID: 8519 RVA: 0x001E88B4 File Offset: 0x001E6AB4
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x04004902 RID: 18690
	public Camera cameraToLookAt;
}
