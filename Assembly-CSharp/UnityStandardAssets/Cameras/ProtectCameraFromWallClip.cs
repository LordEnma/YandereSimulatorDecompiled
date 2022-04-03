using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000551 RID: 1361
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x060022BD RID: 8893 RVA: 0x001F373F File Offset: 0x001F193F
		// (set) Token: 0x060022BE RID: 8894 RVA: 0x001F3747 File Offset: 0x001F1947
		public bool protecting { get; private set; }

		// Token: 0x060022BF RID: 8895 RVA: 0x001F3750 File Offset: 0x001F1950
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x060022C0 RID: 8896 RVA: 0x001F37B0 File Offset: 0x001F19B0
		private void LateUpdate()
		{
			float num = this.m_OriginalDist;
			this.m_Ray.origin = this.m_Pivot.position + this.m_Pivot.forward * this.sphereCastRadius;
			this.m_Ray.direction = -this.m_Pivot.forward;
			Collider[] array = Physics.OverlapSphere(this.m_Ray.origin, this.sphereCastRadius);
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].isTrigger && (!(array[i].attachedRigidbody != null) || !array[i].attachedRigidbody.CompareTag(this.dontClipTag)))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				this.m_Ray.origin = this.m_Ray.origin + this.m_Pivot.forward * this.sphereCastRadius;
				this.m_Hits = Physics.RaycastAll(this.m_Ray, this.m_OriginalDist - this.sphereCastRadius);
			}
			else
			{
				this.m_Hits = Physics.SphereCastAll(this.m_Ray, this.sphereCastRadius, this.m_OriginalDist + this.sphereCastRadius);
			}
			Array.Sort(this.m_Hits, this.m_RayHitComparer);
			float num2 = float.PositiveInfinity;
			for (int j = 0; j < this.m_Hits.Length; j++)
			{
				if (this.m_Hits[j].distance < num2 && !this.m_Hits[j].collider.isTrigger && (!(this.m_Hits[j].collider.attachedRigidbody != null) || !this.m_Hits[j].collider.attachedRigidbody.CompareTag(this.dontClipTag)))
				{
					num2 = this.m_Hits[j].distance;
					num = -this.m_Pivot.InverseTransformPoint(this.m_Hits[j].point).z;
					flag2 = true;
				}
			}
			if (flag2)
			{
				Debug.DrawRay(this.m_Ray.origin, -this.m_Pivot.forward * (num + this.sphereCastRadius), Color.red);
			}
			this.protecting = flag2;
			this.m_CurrentDist = Mathf.SmoothDamp(this.m_CurrentDist, num, ref this.m_MoveVelocity, (this.m_CurrentDist > num) ? this.clipMoveTime : this.returnTime);
			this.m_CurrentDist = Mathf.Clamp(this.m_CurrentDist, this.closestDistance, this.m_OriginalDist);
			this.m_Cam.localPosition = -Vector3.forward * this.m_CurrentDist;
		}

		// Token: 0x04004B34 RID: 19252
		public float clipMoveTime = 0.05f;

		// Token: 0x04004B35 RID: 19253
		public float returnTime = 0.4f;

		// Token: 0x04004B36 RID: 19254
		public float sphereCastRadius = 0.1f;

		// Token: 0x04004B37 RID: 19255
		public bool visualiseInEditor;

		// Token: 0x04004B38 RID: 19256
		public float closestDistance = 0.5f;

		// Token: 0x04004B3A RID: 19258
		public string dontClipTag = "Player";

		// Token: 0x04004B3B RID: 19259
		private Transform m_Cam;

		// Token: 0x04004B3C RID: 19260
		private Transform m_Pivot;

		// Token: 0x04004B3D RID: 19261
		private float m_OriginalDist;

		// Token: 0x04004B3E RID: 19262
		private float m_MoveVelocity;

		// Token: 0x04004B3F RID: 19263
		private float m_CurrentDist;

		// Token: 0x04004B40 RID: 19264
		private Ray m_Ray;

		// Token: 0x04004B41 RID: 19265
		private RaycastHit[] m_Hits;

		// Token: 0x04004B42 RID: 19266
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x02000699 RID: 1689
		public class RayHitComparer : IComparer
		{
			// Token: 0x0600273F RID: 10047 RVA: 0x002057F8 File Offset: 0x002039F8
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
