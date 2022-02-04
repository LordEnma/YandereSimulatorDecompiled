using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000545 RID: 1349
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x0600227C RID: 8828 RVA: 0x001EE2F7 File Offset: 0x001EC4F7
		// (set) Token: 0x0600227D RID: 8829 RVA: 0x001EE2FF File Offset: 0x001EC4FF
		public bool protecting { get; private set; }

		// Token: 0x0600227E RID: 8830 RVA: 0x001EE308 File Offset: 0x001EC508
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x0600227F RID: 8831 RVA: 0x001EE368 File Offset: 0x001EC568
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

		// Token: 0x04004A6A RID: 19050
		public float clipMoveTime = 0.05f;

		// Token: 0x04004A6B RID: 19051
		public float returnTime = 0.4f;

		// Token: 0x04004A6C RID: 19052
		public float sphereCastRadius = 0.1f;

		// Token: 0x04004A6D RID: 19053
		public bool visualiseInEditor;

		// Token: 0x04004A6E RID: 19054
		public float closestDistance = 0.5f;

		// Token: 0x04004A70 RID: 19056
		public string dontClipTag = "Player";

		// Token: 0x04004A71 RID: 19057
		private Transform m_Cam;

		// Token: 0x04004A72 RID: 19058
		private Transform m_Pivot;

		// Token: 0x04004A73 RID: 19059
		private float m_OriginalDist;

		// Token: 0x04004A74 RID: 19060
		private float m_MoveVelocity;

		// Token: 0x04004A75 RID: 19061
		private float m_CurrentDist;

		// Token: 0x04004A76 RID: 19062
		private Ray m_Ray;

		// Token: 0x04004A77 RID: 19063
		private RaycastHit[] m_Hits;

		// Token: 0x04004A78 RID: 19064
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x0200068B RID: 1675
		public class RayHitComparer : IComparer
		{
			// Token: 0x060026F5 RID: 9973 RVA: 0x00200198 File Offset: 0x001FE398
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
