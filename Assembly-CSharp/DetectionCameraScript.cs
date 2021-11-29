using System;
using UnityEngine;

// Token: 0x0200027F RID: 639
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x0600137A RID: 4986 RVA: 0x000B2D78 File Offset: 0x000B0F78
	private void Update()
	{
		base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}

	// Token: 0x04001C9D RID: 7325
	public Transform YandereChan;
}
