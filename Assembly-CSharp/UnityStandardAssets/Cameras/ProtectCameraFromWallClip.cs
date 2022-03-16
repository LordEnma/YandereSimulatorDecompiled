using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054C RID: 1356
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x060022AD RID: 8877 RVA: 0x001F1ECF File Offset: 0x001F00CF
		// (set) Token: 0x060022AE RID: 8878 RVA: 0x001F1ED7 File Offset: 0x001F00D7
		public bool protecting { get; private set; }

		// Token: 0x060022AF RID: 8879 RVA: 0x001F1EE0 File Offset: 0x001F00E0
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x060022B0 RID: 8880 RVA: 0x001F1F40 File Offset: 0x001F0140
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

		// Token: 0x04004B02 RID: 19202
		public float clipMoveTime = 0.05f;

		// Token: 0x04004B03 RID: 19203
		public float returnTime = 0.4f;

		// Token: 0x04004B04 RID: 19204
		public float sphereCastRadius = 0.1f;

		// Token: 0x04004B05 RID: 19205
		public bool visualiseInEditor;

		// Token: 0x04004B06 RID: 19206
		public float closestDistance = 0.5f;

		// Token: 0x04004B08 RID: 19208
		public string dontClipTag = "Player";

		// Token: 0x04004B09 RID: 19209
		private Transform m_Cam;

		// Token: 0x04004B0A RID: 19210
		private Transform m_Pivot;

		// Token: 0x04004B0B RID: 19211
		private float m_OriginalDist;

		// Token: 0x04004B0C RID: 19212
		private float m_MoveVelocity;

		// Token: 0x04004B0D RID: 19213
		private float m_CurrentDist;

		// Token: 0x04004B0E RID: 19214
		private Ray m_Ray;

		// Token: 0x04004B0F RID: 19215
		private RaycastHit[] m_Hits;

		// Token: 0x04004B10 RID: 19216
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x02000694 RID: 1684
		public class RayHitComparer : IComparer
		{
			// Token: 0x0600272F RID: 10031 RVA: 0x00203E38 File Offset: 0x00202038
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
