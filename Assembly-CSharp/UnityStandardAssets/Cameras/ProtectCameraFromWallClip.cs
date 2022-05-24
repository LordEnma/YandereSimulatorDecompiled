using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000554 RID: 1364
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x060022E1 RID: 8929 RVA: 0x001F780B File Offset: 0x001F5A0B
		// (set) Token: 0x060022E2 RID: 8930 RVA: 0x001F7813 File Offset: 0x001F5A13
		public bool protecting { get; private set; }

		// Token: 0x060022E3 RID: 8931 RVA: 0x001F781C File Offset: 0x001F5A1C
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x060022E4 RID: 8932 RVA: 0x001F787C File Offset: 0x001F5A7C
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

		// Token: 0x04004B90 RID: 19344
		public float clipMoveTime = 0.05f;

		// Token: 0x04004B91 RID: 19345
		public float returnTime = 0.4f;

		// Token: 0x04004B92 RID: 19346
		public float sphereCastRadius = 0.1f;

		// Token: 0x04004B93 RID: 19347
		public bool visualiseInEditor;

		// Token: 0x04004B94 RID: 19348
		public float closestDistance = 0.5f;

		// Token: 0x04004B96 RID: 19350
		public string dontClipTag = "Player";

		// Token: 0x04004B97 RID: 19351
		private Transform m_Cam;

		// Token: 0x04004B98 RID: 19352
		private Transform m_Pivot;

		// Token: 0x04004B99 RID: 19353
		private float m_OriginalDist;

		// Token: 0x04004B9A RID: 19354
		private float m_MoveVelocity;

		// Token: 0x04004B9B RID: 19355
		private float m_CurrentDist;

		// Token: 0x04004B9C RID: 19356
		private Ray m_Ray;

		// Token: 0x04004B9D RID: 19357
		private RaycastHit[] m_Hits;

		// Token: 0x04004B9E RID: 19358
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x0200069C RID: 1692
		public class RayHitComparer : IComparer
		{
			// Token: 0x06002763 RID: 10083 RVA: 0x00209A00 File Offset: 0x00207C00
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
