using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000548 RID: 1352
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06002295 RID: 8853 RVA: 0x001EFF67 File Offset: 0x001EE167
		// (set) Token: 0x06002296 RID: 8854 RVA: 0x001EFF6F File Offset: 0x001EE16F
		public bool protecting { get; private set; }

		// Token: 0x06002297 RID: 8855 RVA: 0x001EFF78 File Offset: 0x001EE178
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x06002298 RID: 8856 RVA: 0x001EFFD8 File Offset: 0x001EE1D8
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

		// Token: 0x04004AA3 RID: 19107
		public float clipMoveTime = 0.05f;

		// Token: 0x04004AA4 RID: 19108
		public float returnTime = 0.4f;

		// Token: 0x04004AA5 RID: 19109
		public float sphereCastRadius = 0.1f;

		// Token: 0x04004AA6 RID: 19110
		public bool visualiseInEditor;

		// Token: 0x04004AA7 RID: 19111
		public float closestDistance = 0.5f;

		// Token: 0x04004AA9 RID: 19113
		public string dontClipTag = "Player";

		// Token: 0x04004AAA RID: 19114
		private Transform m_Cam;

		// Token: 0x04004AAB RID: 19115
		private Transform m_Pivot;

		// Token: 0x04004AAC RID: 19116
		private float m_OriginalDist;

		// Token: 0x04004AAD RID: 19117
		private float m_MoveVelocity;

		// Token: 0x04004AAE RID: 19118
		private float m_CurrentDist;

		// Token: 0x04004AAF RID: 19119
		private Ray m_Ray;

		// Token: 0x04004AB0 RID: 19120
		private RaycastHit[] m_Hits;

		// Token: 0x04004AB1 RID: 19121
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x02000690 RID: 1680
		public class RayHitComparer : IComparer
		{
			// Token: 0x06002717 RID: 10007 RVA: 0x00201ED0 File Offset: 0x002000D0
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
