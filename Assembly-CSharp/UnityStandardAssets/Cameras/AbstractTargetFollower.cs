using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054E RID: 1358
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x060022C8 RID: 8904 RVA: 0x001F68F8 File Offset: 0x001F4AF8
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

		// Token: 0x060022C9 RID: 8905 RVA: 0x001F6928 File Offset: 0x001F4B28
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

		// Token: 0x060022CA RID: 8906 RVA: 0x001F6978 File Offset: 0x001F4B78
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

		// Token: 0x060022CB RID: 8907 RVA: 0x001F69C8 File Offset: 0x001F4BC8
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

		// Token: 0x060022CC RID: 8908
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x060022CD RID: 8909 RVA: 0x001F6A18 File Offset: 0x001F4C18
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x060022CE RID: 8910 RVA: 0x001F6A44 File Offset: 0x001F4C44
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x060022CF RID: 8911 RVA: 0x001F6A4D File Offset: 0x001F4C4D
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004B5E RID: 19294
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004B5F RID: 19295
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004B60 RID: 19296
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004B61 RID: 19297
		protected Rigidbody targetRigidbody;

		// Token: 0x0200069B RID: 1691
		public enum UpdateType
		{
			// Token: 0x04005115 RID: 20757
			FixedUpdate,
			// Token: 0x04005116 RID: 20758
			LateUpdate,
			// Token: 0x04005117 RID: 20759
			ManualUpdate
		}
	}
}
