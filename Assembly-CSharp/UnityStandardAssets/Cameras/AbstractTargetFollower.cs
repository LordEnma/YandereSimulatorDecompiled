using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000541 RID: 1345
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x06002277 RID: 8823 RVA: 0x001EEBE4 File Offset: 0x001ECDE4
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

		// Token: 0x06002278 RID: 8824 RVA: 0x001EEC14 File Offset: 0x001ECE14
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

		// Token: 0x06002279 RID: 8825 RVA: 0x001EEC64 File Offset: 0x001ECE64
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

		// Token: 0x0600227A RID: 8826 RVA: 0x001EECB4 File Offset: 0x001ECEB4
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

		// Token: 0x0600227B RID: 8827
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x0600227C RID: 8828 RVA: 0x001EED04 File Offset: 0x001ECF04
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x0600227D RID: 8829 RVA: 0x001EED30 File Offset: 0x001ECF30
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x0600227E RID: 8830 RVA: 0x001EED39 File Offset: 0x001ECF39
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004A5D RID: 19037
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004A5E RID: 19038
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004A5F RID: 19039
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004A60 RID: 19040
		protected Rigidbody targetRigidbody;

		// Token: 0x0200068E RID: 1678
		public enum UpdateType
		{
			// Token: 0x0400500C RID: 20492
			FixedUpdate,
			// Token: 0x0400500D RID: 20493
			LateUpdate,
			// Token: 0x0400500E RID: 20494
			ManualUpdate
		}
	}
}
