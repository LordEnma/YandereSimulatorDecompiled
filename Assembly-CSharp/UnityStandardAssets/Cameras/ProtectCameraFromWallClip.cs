using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000540 RID: 1344
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06002255 RID: 8789 RVA: 0x001EA3AB File Offset: 0x001E85AB
		// (set) Token: 0x06002256 RID: 8790 RVA: 0x001EA3B3 File Offset: 0x001E85B3
		public bool protecting { get; private set; }

		// Token: 0x06002257 RID: 8791 RVA: 0x001EA3BC File Offset: 0x001E85BC
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x06002258 RID: 8792 RVA: 0x001EA41C File Offset: 0x001E861C
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

		// Token: 0x040049F6 RID: 18934
		public float clipMoveTime = 0.05f;

		// Token: 0x040049F7 RID: 18935
		public float returnTime = 0.4f;

		// Token: 0x040049F8 RID: 18936
		public float sphereCastRadius = 0.1f;

		// Token: 0x040049F9 RID: 18937
		public bool visualiseInEditor;

		// Token: 0x040049FA RID: 18938
		public float closestDistance = 0.5f;

		// Token: 0x040049FC RID: 18940
		public string dontClipTag = "Player";

		// Token: 0x040049FD RID: 18941
		private Transform m_Cam;

		// Token: 0x040049FE RID: 18942
		private Transform m_Pivot;

		// Token: 0x040049FF RID: 18943
		private float m_OriginalDist;

		// Token: 0x04004A00 RID: 18944
		private float m_MoveVelocity;

		// Token: 0x04004A01 RID: 18945
		private float m_CurrentDist;

		// Token: 0x04004A02 RID: 18946
		private Ray m_Ray;

		// Token: 0x04004A03 RID: 18947
		private RaycastHit[] m_Hits;

		// Token: 0x04004A04 RID: 18948
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x0200068B RID: 1675
		public class RayHitComparer : IComparer
		{
			// Token: 0x060026E2 RID: 9954 RVA: 0x001FC90C File Offset: 0x001FAB0C
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
