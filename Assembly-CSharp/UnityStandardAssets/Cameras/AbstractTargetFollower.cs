using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053C RID: 1340
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x06002251 RID: 8785 RVA: 0x001EB724 File Offset: 0x001E9924
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

		// Token: 0x06002252 RID: 8786 RVA: 0x001EB754 File Offset: 0x001E9954
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

		// Token: 0x06002253 RID: 8787 RVA: 0x001EB7A4 File Offset: 0x001E99A4
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

		// Token: 0x06002254 RID: 8788 RVA: 0x001EB7F4 File Offset: 0x001E99F4
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

		// Token: 0x06002255 RID: 8789
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x06002256 RID: 8790 RVA: 0x001EB844 File Offset: 0x001E9A44
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x001EB870 File Offset: 0x001E9A70
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06002258 RID: 8792 RVA: 0x001EB879 File Offset: 0x001E9A79
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004A15 RID: 18965
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004A16 RID: 18966
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004A17 RID: 18967
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004A18 RID: 18968
		protected Rigidbody targetRigidbody;

		// Token: 0x0200068D RID: 1677
		public enum UpdateType
		{
			// Token: 0x04004FED RID: 20461
			FixedUpdate,
			// Token: 0x04004FEE RID: 20462
			LateUpdate,
			// Token: 0x04004FEF RID: 20463
			ManualUpdate
		}
	}
}
