using System;
using UnityEngine;

// Token: 0x02000515 RID: 1301
public class LookAtCamera : MonoBehaviour
{
	// Token: 0x06002142 RID: 8514 RVA: 0x001E7FF9 File Offset: 0x001E61F9
	private void Start()
	{
		if (this.cameraToLookAt == null)
		{
			this.cameraToLookAt = Camera.main;
		}
	}

	// Token: 0x06002143 RID: 8515 RVA: 0x001E8014 File Offset: 0x001E6214
	private void Update()
	{
		Vector3 b = new Vector3(0f, this.cameraToLookAt.transform.position.y - base.transform.position.y, 0f);
		base.transform.LookAt(this.cameraToLookAt.transform.position - b);
	}

	// Token: 0x040048F7 RID: 18679
	public Camera cameraToLookAt;
}
