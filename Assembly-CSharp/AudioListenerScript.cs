using System;
using UnityEngine;

// Token: 0x020000D9 RID: 217
public class AudioListenerScript : MonoBehaviour
{
	// Token: 0x06000A01 RID: 2561 RVA: 0x00056853 File Offset: 0x00054A53
	private void Start()
	{
		this.mainCamera = Camera.main;
	}

	// Token: 0x06000A02 RID: 2562 RVA: 0x00056860 File Offset: 0x00054A60
	private void Update()
	{
		base.transform.position = this.Target.position;
		base.transform.eulerAngles = this.mainCamera.transform.eulerAngles;
	}

	// Token: 0x04000ABB RID: 2747
	public Transform Target;

	// Token: 0x04000ABC RID: 2748
	public Camera mainCamera;
}
