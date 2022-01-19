using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053F RID: 1343
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x0600225E RID: 8798 RVA: 0x001ECD94 File Offset: 0x001EAF94
		protected virtual void Start()
		{
			if (this.m_AutoTargetPlayer)
			{
				this.FindAndTargetPlayer();
			}
			if (this.m_Target == null)
			{
				return;
			}
			this.targetRigidbody = this.m_Target.GetComponent<Rigidbody>();
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x001ECDC4 File Offset: 0x001EAFC4
		private void FixedUpdate()
		{
			if (this.m_AutoTargetPlayer && (this.m_Target == null || !this.m_Target.gameObject.activeSelf))
			{
				this.FindAndTargetPlayer();
			}
			if (this.m_UpdateType == AbstractTargetFollower.UpdateType.FixedUpdate)
			{
				this.FollowTarget(Time.deltaTime);
			}
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x001ECE14 File Offset: 0x001EB014
		private void LateUpdate()
		{
			if (this.m_AutoTargetPlayer && (this.m_Target == null || !this.m_Target.gameObject.activeSelf))
			{
				this.FindAndTargetPlayer();
			}
			if (this.m_UpdateType == AbstractTargetFollower.UpdateType.LateUpdate)
			{
				this.FollowTarget(Time.deltaTime);
			}
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x001ECE64 File Offset: 0x001EB064
		public void ManualUpdate()
		{
			if (this.m_AutoTargetPlayer && (this.m_Target == null || !this.m_Target.gameObject.activeSelf))
			{
				this.FindAndTargetPlayer();
			}
			if (this.m_UpdateType == AbstractTargetFollower.UpdateType.ManualUpdate)
			{
				this.FollowTarget(Time.deltaTime);
			}
		}

		// Token: 0x06002262 RID: 8802
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x06002263 RID: 8803 RVA: 0x001ECEB4 File Offset: 0x001EB0B4
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x001ECEE0 File Offset: 0x001EB0E0
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06002265 RID: 8805 RVA: 0x001ECEE9 File Offset: 0x001EB0E9
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004A30 RID: 18992
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004A31 RID: 18993
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004A32 RID: 18994
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004A33 RID: 18995
		protected Rigidbody targetRigidbody;

		// Token: 0x02000690 RID: 1680
		public enum UpdateType
		{
			// Token: 0x04005008 RID: 20488
			FixedUpdate,
			// Token: 0x04005009 RID: 20489
			LateUpdate,
			// Token: 0x0400500A RID: 20490
			ManualUpdate
		}
	}
}
