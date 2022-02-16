using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000546 RID: 1350
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06002286 RID: 8838 RVA: 0x001EE9AF File Offset: 0x001ECBAF
		// (set) Token: 0x06002287 RID: 8839 RVA: 0x001EE9B7 File Offset: 0x001ECBB7
		public bool protecting { get; private set; }

		// Token: 0x06002288 RID: 8840 RVA: 0x001EE9C0 File Offset: 0x001ECBC0
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x06002289 RID: 8841 RVA: 0x001EEA20 File Offset: 0x001ECC20
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

		// Token: 0x04004A76 RID: 19062
		public float clipMoveTime = 0.05f;

		// Token: 0x04004A77 RID: 19063
		public float returnTime = 0.4f;

		// Token: 0x04004A78 RID: 19064
		public float sphereCastRadius = 0.1f;

		// Token: 0x04004A79 RID: 19065
		public bool visualiseInEditor;

		// Token: 0x04004A7A RID: 19066
		public float closestDistance = 0.5f;

		// Token: 0x04004A7C RID: 19068
		public string dontClipTag = "Player";

		// Token: 0x04004A7D RID: 19069
		private Transform m_Cam;

		// Token: 0x04004A7E RID: 19070
		private Transform m_Pivot;

		// Token: 0x04004A7F RID: 19071
		private float m_OriginalDist;

		// Token: 0x04004A80 RID: 19072
		private float m_MoveVelocity;

		// Token: 0x04004A81 RID: 19073
		private float m_CurrentDist;

		// Token: 0x04004A82 RID: 19074
		private Ray m_Ray;

		// Token: 0x04004A83 RID: 19075
		private RaycastHit[] m_Hits;

		// Token: 0x04004A84 RID: 19076
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x0200068C RID: 1676
		public class RayHitComparer : IComparer
		{
			// Token: 0x060026FF RID: 9983 RVA: 0x00200850 File Offset: 0x001FEA50
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
