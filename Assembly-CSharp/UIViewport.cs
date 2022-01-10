using System;
using UnityEngine;

// Token: 0x020000B1 RID: 177
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/UI/Viewport Camera")]
public class UIViewport : MonoBehaviour
{
	// Token: 0x060008E2 RID: 2274 RVA: 0x00048AD0 File Offset: 0x00046CD0
	private void Start()
	{
		this.mCam = base.GetComponent<Camera>();
		if (this.sourceCamera == null)
		{
			this.sourceCamera = Camera.main;
		}
	}

	// Token: 0x060008E3 RID: 2275 RVA: 0x00048AF8 File Offset: 0x00046CF8
	private void LateUpdate()
	{
		if (this.topLeft != null && this.bottomRight != null)
		{
			if (this.topLeft.gameObject.activeInHierarchy)
			{
				Vector3 vector = this.sourceCamera.WorldToScreenPoint(this.topLeft.position);
				Vector3 vector2 = this.sourceCamera.WorldToScreenPoint(this.bottomRight.position);
				Rect rect = new Rect(vector.x / (float)Screen.width, vector2.y / (float)Screen.height, (vector2.x - vector.x) / (float)Screen.width, (vector.y - vector2.y) / (float)Screen.height);
				float num = this.fullSize * rect.height;
				if (rect != this.mCam.rect)
				{
					this.mCam.rect = rect;
				}
				if (this.mCam.orthographicSize != num)
				{
					this.mCam.orthographicSize = num;
				}
				this.mCam.enabled = true;
				return;
			}
			this.mCam.enabled = false;
		}
	}

	// Token: 0x040007A6 RID: 1958
	public Camera sourceCamera;

	// Token: 0x040007A7 RID: 1959
	public Transform topLeft;

	// Token: 0x040007A8 RID: 1960
	public Transform bottomRight;

	// Token: 0x040007A9 RID: 1961
	public float fullSize = 1f;

	// Token: 0x040007AA RID: 1962
	private Camera mCam;
}
