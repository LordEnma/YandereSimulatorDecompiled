using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053C RID: 1340
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x0600224E RID: 8782 RVA: 0x001EB134 File Offset: 0x001E9334
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

		// Token: 0x0600224F RID: 8783 RVA: 0x001EB164 File Offset: 0x001E9364
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

		// Token: 0x06002250 RID: 8784 RVA: 0x001EB1B4 File Offset: 0x001E93B4
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

		// Token: 0x06002251 RID: 8785 RVA: 0x001EB204 File Offset: 0x001E9404
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

		// Token: 0x06002252 RID: 8786
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x06002253 RID: 8787 RVA: 0x001EB254 File Offset: 0x001E9454
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x001EB280 File Offset: 0x001E9480
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06002255 RID: 8789 RVA: 0x001EB289 File Offset: 0x001E9489
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004A0C RID: 18956
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004A0D RID: 18957
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004A0E RID: 18958
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004A0F RID: 18959
		protected Rigidbody targetRigidbody;

		// Token: 0x0200068D RID: 1677
		public enum UpdateType
		{
			// Token: 0x04004FE4 RID: 20452
			FixedUpdate,
			// Token: 0x04004FE5 RID: 20453
			LateUpdate,
			// Token: 0x04004FE6 RID: 20454
			ManualUpdate
		}
	}
}
