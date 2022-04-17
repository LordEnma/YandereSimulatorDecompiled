using System;
using UnityEngine;

// Token: 0x020000D9 RID: 217
public class AudioListenerScript : MonoBehaviour
{
	// Token: 0x06000A01 RID: 2561 RVA: 0x0005661F File Offset: 0x0005481F
	private void Start()
	{
		this.mainCamera = Camera.main;
	}

	// Token: 0x06000A02 RID: 2562 RVA: 0x0005662C File Offset: 0x0005482C
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
