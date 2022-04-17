using System;
using UnityEngine;

// Token: 0x02000052 RID: 82
[AddComponentMenu("NGUI/Interaction/Drag-Resize Widget")]
public class UIDragResize : MonoBehaviour
{
	// Token: 0x06000193 RID: 403 RVA: 0x0001695C File Offset: 0x00014B5C
	private void OnDragStart()
	{
		if (this.target != null)
		{
			Vector3[] worldCorners = this.target.worldCorners;
			this.mPlane = new Plane(worldCorners[0], worldCorners[1], worldCorners[3]);
			Ray currentRay = UICamera.currentRay;
			float distance;
			if (this.mPlane.Raycast(currentRay, out distance))
			{
				this.mRayPos = currentRay.GetPoint(distance);
				this.mLocalPos = this.target.cachedTransform.localPosition;
				this.mWidth = this.target.width;
				this.mHeight = this.target.height;
				this.mDragging = true;
			}
		}
	}

	// Token: 0x06000194 RID: 404 RVA: 0x00016A0C File Offset: 0x00014C0C
	private void OnDrag(Vector2 delta)
	{
		if (this.mDragging && this.target != null)
		{
			Ray currentRay = UICamera.currentRay;
			float distance;
			if (this.mPlane.Raycast(currentRay, out distance))
			{
				Transform cachedTransform = this.target.cachedTransform;
				cachedTransform.localPosition = this.mLocalPos;
				this.target.width = this.mWidth;
				this.target.height = this.mHeight;
				Vector3 b = currentRay.GetPoint(distance) - this.mRayPos;
				cachedTransform.position += b;
				Vector3 vector = Quaternion.Inverse(cachedTransform.localRotation) * (cachedTransform.localPosition - this.mLocalPos);
				cachedTransform.localPosition = this.mLocalPos;
				NGUIMath.ResizeWidget(this.target, this.pivot, vector.x, vector.y, this.minWidth, this.minHeight, this.maxWidth, this.maxHeight);
				if (this.updateAnchors)
				{
					this.target.BroadcastMessage("UpdateAnchors");
				}
			}
		}
	}

	// Token: 0x06000195 RID: 405 RVA: 0x00016B2C File Offset: 0x00014D2C
	private void OnDragEnd()
	{
		this.mDragging = false;
	}

	// Token: 0x0400034D RID: 845
	public UIWidget target;

	// Token: 0x0400034E RID: 846
	public UIWidget.Pivot pivot = UIWidget.Pivot.BottomRight;

	// Token: 0x0400034F RID: 847
	public int minWidth = 100;

	// Token: 0x04000350 RID: 848
	public int minHeight = 100;

	// Token: 0x04000351 RID: 849
	public int maxWidth = 100000;

	// Token: 0x04000352 RID: 850
	public int maxHeight = 100000;

	// Token: 0x04000353 RID: 851
	public bool updateAnchors;

	// Token: 0x04000354 RID: 852
	private Plane mPlane;

	// Token: 0x04000355 RID: 853
	private Vector3 mRayPos;

	// Token: 0x04000356 RID: 854
	private Vector3 mLocalPos;

	// Token: 0x04000357 RID: 855
	private int mWidth;

	// Token: 0x04000358 RID: 856
	private int mHeight;

	// Token: 0x04000359 RID: 857
	private bool mDragging;
}
