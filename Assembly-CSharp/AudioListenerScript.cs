using System;
using UnityEngine;

// Token: 0x020000D9 RID: 217
public class AudioListenerScript : MonoBehaviour
{
	// Token: 0x06000A01 RID: 2561 RVA: 0x00056567 File Offset: 0x00054767
	private void Start()
	{
		this.mainCamera = Camera.main;
	}

	// Token: 0x06000A02 RID: 2562 RVA: 0x00056574 File Offset: 0x00054774
	private void Update()
	{
		base.transform.position = this.Target.position;
		base.transform.eulerAngles = this.mainCamera.transform.eulerAngles;
	}

	// Token: 0x04000AB9 RID: 2745
	public Transform Target;

	// Token: 0x04000ABA RID: 2746
	public Camera mainCamera;
}
