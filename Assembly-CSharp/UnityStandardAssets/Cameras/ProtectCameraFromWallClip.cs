using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000547 RID: 1351
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x0600228F RID: 8847 RVA: 0x001EF58F File Offset: 0x001ED78F
		// (set) Token: 0x06002290 RID: 8848 RVA: 0x001EF597 File Offset: 0x001ED797
		public bool protecting { get; private set; }

		// Token: 0x06002291 RID: 8849 RVA: 0x001EF5A0 File Offset: 0x001ED7A0
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x06002292 RID: 8850 RVA: 0x001EF600 File Offset: 0x001ED800
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

		// Token: 0x04004A86 RID: 19078
		public float clipMoveTime = 0.05f;

		// Token: 0x04004A87 RID: 19079
		public float returnTime = 0.4f;

		// Token: 0x04004A88 RID: 19080
		public float sphereCastRadius = 0.1f;

		// Token: 0x04004A89 RID: 19081
		public bool visualiseInEditor;

		// Token: 0x04004A8A RID: 19082
		public float closestDistance = 0.5f;

		// Token: 0x04004A8C RID: 19084
		public string dontClipTag = "Player";

		// Token: 0x04004A8D RID: 19085
		private Transform m_Cam;

		// Token: 0x04004A8E RID: 19086
		private Transform m_Pivot;

		// Token: 0x04004A8F RID: 19087
		private float m_OriginalDist;

		// Token: 0x04004A90 RID: 19088
		private float m_MoveVelocity;

		// Token: 0x04004A91 RID: 19089
		private float m_CurrentDist;

		// Token: 0x04004A92 RID: 19090
		private Ray m_Ray;

		// Token: 0x04004A93 RID: 19091
		private RaycastHit[] m_Hits;

		// Token: 0x04004A94 RID: 19092
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x0200068F RID: 1679
		public class RayHitComparer : IComparer
		{
			// Token: 0x06002711 RID: 10001 RVA: 0x002014F8 File Offset: 0x001FF6F8
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
