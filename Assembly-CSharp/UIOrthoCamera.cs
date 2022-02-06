using System;
using UnityEngine;

// Token: 0x020000A6 RID: 166
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/UI/Orthographic Camera")]
public class UIOrthoCamera : MonoBehaviour
{
	// Token: 0x060007EF RID: 2031 RVA: 0x000422B1 File Offset: 0x000404B1
	private void Start()
	{
		this.mCam = base.GetComponent<Camera>();
		this.mTrans = base.transform;
		this.mCam.orthographic = true;
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x000422D8 File Offset: 0x000404D8
	private void Update()
	{
		float num = this.mCam.rect.yMin * (float)Screen.height;
		float num2 = (this.mCam.rect.yMax * (float)Screen.height - num) * 0.5f * this.mTrans.lossyScale.y;
		if (!Mathf.Approximately(this.mCam.orthographicSize, num2))
		{
			this.mCam.orthographicSize = num2;
		}
	}

	// Token: 0x04000717 RID: 1815
	private Camera mCam;

	// Token: 0x04000718 RID: 1816
	private Transform mTrans;
}
