using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053A RID: 1338
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x0600223D RID: 8765 RVA: 0x001E9A00 File Offset: 0x001E7C00
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

		// Token: 0x0600223E RID: 8766 RVA: 0x001E9A30 File Offset: 0x001E7C30
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

		// Token: 0x0600223F RID: 8767 RVA: 0x001E9A80 File Offset: 0x001E7C80
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

		// Token: 0x06002240 RID: 8768 RVA: 0x001E9AD0 File Offset: 0x001E7CD0
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

		// Token: 0x06002241 RID: 8769
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x06002242 RID: 8770 RVA: 0x001E9B20 File Offset: 0x001E7D20
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x06002243 RID: 8771 RVA: 0x001E9B4C File Offset: 0x001E7D4C
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06002244 RID: 8772 RVA: 0x001E9B55 File Offset: 0x001E7D55
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x040049CD RID: 18893
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x040049CE RID: 18894
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x040049CF RID: 18895
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x040049D0 RID: 18896
		protected Rigidbody targetRigidbody;

		// Token: 0x0200068A RID: 1674
		public enum UpdateType
		{
			// Token: 0x04004F99 RID: 20377
			FixedUpdate,
			// Token: 0x04004F9A RID: 20378
			LateUpdate,
			// Token: 0x04004F9B RID: 20379
			ManualUpdate
		}
	}
}
