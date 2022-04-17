using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000552 RID: 1362
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x060022CC RID: 8908 RVA: 0x001F46CB File Offset: 0x001F28CB
		// (set) Token: 0x060022CD RID: 8909 RVA: 0x001F46D3 File Offset: 0x001F28D3
		public bool protecting { get; private set; }

		// Token: 0x060022CE RID: 8910 RVA: 0x001F46DC File Offset: 0x001F28DC
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x060022CF RID: 8911 RVA: 0x001F473C File Offset: 0x001F293C
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

		// Token: 0x04004B4A RID: 19274
		public float clipMoveTime = 0.05f;

		// Token: 0x04004B4B RID: 19275
		public float returnTime = 0.4f;

		// Token: 0x04004B4C RID: 19276
		public float sphereCastRadius = 0.1f;

		// Token: 0x04004B4D RID: 19277
		public bool visualiseInEditor;

		// Token: 0x04004B4E RID: 19278
		public float closestDistance = 0.5f;

		// Token: 0x04004B50 RID: 19280
		public string dontClipTag = "Player";

		// Token: 0x04004B51 RID: 19281
		private Transform m_Cam;

		// Token: 0x04004B52 RID: 19282
		private Transform m_Pivot;

		// Token: 0x04004B53 RID: 19283
		private float m_OriginalDist;

		// Token: 0x04004B54 RID: 19284
		private float m_MoveVelocity;

		// Token: 0x04004B55 RID: 19285
		private float m_CurrentDist;

		// Token: 0x04004B56 RID: 19286
		private Ray m_Ray;

		// Token: 0x04004B57 RID: 19287
		private RaycastHit[] m_Hits;

		// Token: 0x04004B58 RID: 19288
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x0200069A RID: 1690
		public class RayHitComparer : IComparer
		{
			// Token: 0x0600274E RID: 10062 RVA: 0x00206784 File Offset: 0x00204984
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
