using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054C RID: 1356
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x060022AD RID: 8877 RVA: 0x001F32C4 File Offset: 0x001F14C4
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

		// Token: 0x060022AE RID: 8878 RVA: 0x001F32F4 File Offset: 0x001F14F4
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

		// Token: 0x060022AF RID: 8879 RVA: 0x001F3344 File Offset: 0x001F1544
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

		// Token: 0x060022B0 RID: 8880 RVA: 0x001F3394 File Offset: 0x001F1594
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

		// Token: 0x060022B1 RID: 8881
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x060022B2 RID: 8882 RVA: 0x001F33E4 File Offset: 0x001F15E4
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x001F3410 File Offset: 0x001F1610
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x060022B4 RID: 8884 RVA: 0x001F3419 File Offset: 0x001F1619
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004B0F RID: 19215
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004B10 RID: 19216
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004B11 RID: 19217
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004B12 RID: 19218
		protected Rigidbody targetRigidbody;

		// Token: 0x02000699 RID: 1689
		public enum UpdateType
		{
			// Token: 0x040050BE RID: 20670
			FixedUpdate,
			// Token: 0x040050BF RID: 20671
			LateUpdate,
			// Token: 0x040050C0 RID: 20672
			ManualUpdate
		}
	}
}
