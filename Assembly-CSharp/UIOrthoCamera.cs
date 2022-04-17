using System;
using UnityEngine;

// Token: 0x020000A6 RID: 166
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/UI/Orthographic Camera")]
public class UIOrthoCamera : MonoBehaviour
{
	// Token: 0x060007EF RID: 2031 RVA: 0x00042461 File Offset: 0x00040661
	private void Start()
	{
		this.mCam = base.GetComponent<Camera>();
		this.mTrans = base.transform;
		this.mCam.orthographic = true;
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x00042488 File Offset: 0x00040688
	private void Update()
	{
		float num = this.mCam.rect.yMin * (float)Screen.height;
		float num2 = (this.mCam.rect.yMax * (float)Screen.height - num) * 0.5f * this.mTrans.lossyScale.y;
		if (!Mathf.Approximately(this.mCam.orthographicSize, num2))
		{
			this.mCam.orthographicSize = num2;
		}
	}

	// Token: 0x04000720 RID: 1824
	private Camera mCam;

	// Token: 0x04000721 RID: 1825
	private Transform mTrans;
}
