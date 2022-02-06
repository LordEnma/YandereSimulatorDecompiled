using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000545 RID: 1349
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x0600227F RID: 8831 RVA: 0x001EE4FB File Offset: 0x001EC6FB
		// (set) Token: 0x06002280 RID: 8832 RVA: 0x001EE503 File Offset: 0x001EC703
		public bool protecting { get; private set; }

		// Token: 0x06002281 RID: 8833 RVA: 0x001EE50C File Offset: 0x001EC70C
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x06002282 RID: 8834 RVA: 0x001EE56C File Offset: 0x001EC76C
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

		// Token: 0x04004A6D RID: 19053
		public float clipMoveTime = 0.05f;

		// Token: 0x04004A6E RID: 19054
		public float returnTime = 0.4f;

		// Token: 0x04004A6F RID: 19055
		public float sphereCastRadius = 0.1f;

		// Token: 0x04004A70 RID: 19056
		public bool visualiseInEditor;

		// Token: 0x04004A71 RID: 19057
		public float closestDistance = 0.5f;

		// Token: 0x04004A73 RID: 19059
		public string dontClipTag = "Player";

		// Token: 0x04004A74 RID: 19060
		private Transform m_Cam;

		// Token: 0x04004A75 RID: 19061
		private Transform m_Pivot;

		// Token: 0x04004A76 RID: 19062
		private float m_OriginalDist;

		// Token: 0x04004A77 RID: 19063
		private float m_MoveVelocity;

		// Token: 0x04004A78 RID: 19064
		private float m_CurrentDist;

		// Token: 0x04004A79 RID: 19065
		private Ray m_Ray;

		// Token: 0x04004A7A RID: 19066
		private RaycastHit[] m_Hits;

		// Token: 0x04004A7B RID: 19067
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x0200068B RID: 1675
		public class RayHitComparer : IComparer
		{
			// Token: 0x060026F8 RID: 9976 RVA: 0x0020039C File Offset: 0x001FE59C
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
