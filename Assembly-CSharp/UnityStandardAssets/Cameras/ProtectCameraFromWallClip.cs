using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000553 RID: 1363
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x060022D5 RID: 8917 RVA: 0x001F5B57 File Offset: 0x001F3D57
		// (set) Token: 0x060022D6 RID: 8918 RVA: 0x001F5B5F File Offset: 0x001F3D5F
		public bool protecting { get; private set; }

		// Token: 0x060022D7 RID: 8919 RVA: 0x001F5B68 File Offset: 0x001F3D68
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x060022D8 RID: 8920 RVA: 0x001F5BC8 File Offset: 0x001F3DC8
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

		// Token: 0x04004B60 RID: 19296
		public float clipMoveTime = 0.05f;

		// Token: 0x04004B61 RID: 19297
		public float returnTime = 0.4f;

		// Token: 0x04004B62 RID: 19298
		public float sphereCastRadius = 0.1f;

		// Token: 0x04004B63 RID: 19299
		public bool visualiseInEditor;

		// Token: 0x04004B64 RID: 19300
		public float closestDistance = 0.5f;

		// Token: 0x04004B66 RID: 19302
		public string dontClipTag = "Player";

		// Token: 0x04004B67 RID: 19303
		private Transform m_Cam;

		// Token: 0x04004B68 RID: 19304
		private Transform m_Pivot;

		// Token: 0x04004B69 RID: 19305
		private float m_OriginalDist;

		// Token: 0x04004B6A RID: 19306
		private float m_MoveVelocity;

		// Token: 0x04004B6B RID: 19307
		private float m_CurrentDist;

		// Token: 0x04004B6C RID: 19308
		private Ray m_Ray;

		// Token: 0x04004B6D RID: 19309
		private RaycastHit[] m_Hits;

		// Token: 0x04004B6E RID: 19310
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x0200069B RID: 1691
		public class RayHitComparer : IComparer
		{
			// Token: 0x06002757 RID: 10071 RVA: 0x00207D24 File Offset: 0x00205F24
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
