using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000545 RID: 1349
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06002276 RID: 8822 RVA: 0x001ED73F File Offset: 0x001EB93F
		// (set) Token: 0x06002277 RID: 8823 RVA: 0x001ED747 File Offset: 0x001EB947
		public bool protecting { get; private set; }

		// Token: 0x06002278 RID: 8824 RVA: 0x001ED750 File Offset: 0x001EB950
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x06002279 RID: 8825 RVA: 0x001ED7B0 File Offset: 0x001EB9B0
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

		// Token: 0x04004A59 RID: 19033
		public float clipMoveTime = 0.05f;

		// Token: 0x04004A5A RID: 19034
		public float returnTime = 0.4f;

		// Token: 0x04004A5B RID: 19035
		public float sphereCastRadius = 0.1f;

		// Token: 0x04004A5C RID: 19036
		public bool visualiseInEditor;

		// Token: 0x04004A5D RID: 19037
		public float closestDistance = 0.5f;

		// Token: 0x04004A5F RID: 19039
		public string dontClipTag = "Player";

		// Token: 0x04004A60 RID: 19040
		private Transform m_Cam;

		// Token: 0x04004A61 RID: 19041
		private Transform m_Pivot;

		// Token: 0x04004A62 RID: 19042
		private float m_OriginalDist;

		// Token: 0x04004A63 RID: 19043
		private float m_MoveVelocity;

		// Token: 0x04004A64 RID: 19044
		private float m_CurrentDist;

		// Token: 0x04004A65 RID: 19045
		private Ray m_Ray;

		// Token: 0x04004A66 RID: 19046
		private RaycastHit[] m_Hits;

		// Token: 0x04004A67 RID: 19047
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x02000691 RID: 1681
		public class RayHitComparer : IComparer
		{
			// Token: 0x06002703 RID: 9987 RVA: 0x001FFCC4 File Offset: 0x001FDEC4
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
