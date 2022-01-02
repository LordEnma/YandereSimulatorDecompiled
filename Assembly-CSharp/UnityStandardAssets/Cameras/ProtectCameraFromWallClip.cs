using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000542 RID: 1346
	public class ProtectCameraFromWallClip : MonoBehaviour
	{
		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06002269 RID: 8809 RVA: 0x001EC0CF File Offset: 0x001EA2CF
		// (set) Token: 0x0600226A RID: 8810 RVA: 0x001EC0D7 File Offset: 0x001EA2D7
		public bool protecting { get; private set; }

		// Token: 0x0600226B RID: 8811 RVA: 0x001EC0E0 File Offset: 0x001EA2E0
		private void Start()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
			this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
			this.m_CurrentDist = this.m_OriginalDist;
			this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001EC140 File Offset: 0x001EA340
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

		// Token: 0x04004A3E RID: 19006
		public float clipMoveTime = 0.05f;

		// Token: 0x04004A3F RID: 19007
		public float returnTime = 0.4f;

		// Token: 0x04004A40 RID: 19008
		public float sphereCastRadius = 0.1f;

		// Token: 0x04004A41 RID: 19009
		public bool visualiseInEditor;

		// Token: 0x04004A42 RID: 19010
		public float closestDistance = 0.5f;

		// Token: 0x04004A44 RID: 19012
		public string dontClipTag = "Player";

		// Token: 0x04004A45 RID: 19013
		private Transform m_Cam;

		// Token: 0x04004A46 RID: 19014
		private Transform m_Pivot;

		// Token: 0x04004A47 RID: 19015
		private float m_OriginalDist;

		// Token: 0x04004A48 RID: 19016
		private float m_MoveVelocity;

		// Token: 0x04004A49 RID: 19017
		private float m_CurrentDist;

		// Token: 0x04004A4A RID: 19018
		private Ray m_Ray;

		// Token: 0x04004A4B RID: 19019
		private RaycastHit[] m_Hits;

		// Token: 0x04004A4C RID: 19020
		private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

		// Token: 0x0200068E RID: 1678
		public class RayHitComparer : IComparer
		{
			// Token: 0x060026F6 RID: 9974 RVA: 0x001FE654 File Offset: 0x001FC854
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}
	}
}
