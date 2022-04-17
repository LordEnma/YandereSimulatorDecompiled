using System;
using UnityEngine;

// Token: 0x020000B1 RID: 177
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/UI/Viewport Camera")]
public class UIViewport : MonoBehaviour
{
	// Token: 0x060008E2 RID: 2274 RVA: 0x00048C78 File Offset: 0x00046E78
	private void Start()
	{
		this.mCam = base.GetComponent<Camera>();
		if (this.sourceCamera == null)
		{
			this.sourceCamera = Camera.main;
		}
	}

	// Token: 0x060008E3 RID: 2275 RVA: 0x00048CA0 File Offset: 0x00046EA0
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

	// Token: 0x040007B1 RID: 1969
	public Camera sourceCamera;

	// Token: 0x040007B2 RID: 1970
	public Transform topLeft;

	// Token: 0x040007B3 RID: 1971
	public Transform bottomRight;

	// Token: 0x040007B4 RID: 1972
	public float fullSize = 1f;

	// Token: 0x040007B5 RID: 1973
	private Camera mCam;
}
