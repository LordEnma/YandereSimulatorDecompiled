using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054B RID: 1355
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x060022A5 RID: 8869 RVA: 0x001F2D94 File Offset: 0x001F0F94
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

		// Token: 0x060022A6 RID: 8870 RVA: 0x001F2DC4 File Offset: 0x001F0FC4
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

		// Token: 0x060022A7 RID: 8871 RVA: 0x001F2E14 File Offset: 0x001F1014
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

		// Token: 0x060022A8 RID: 8872 RVA: 0x001F2E64 File Offset: 0x001F1064
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

		// Token: 0x060022A9 RID: 8873
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x060022AA RID: 8874 RVA: 0x001F2EB4 File Offset: 0x001F10B4
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x001F2EE0 File Offset: 0x001F10E0
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x060022AC RID: 8876 RVA: 0x001F2EE9 File Offset: 0x001F10E9
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004B0B RID: 19211
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004B0C RID: 19212
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004B0D RID: 19213
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004B0E RID: 19214
		protected Rigidbody targetRigidbody;

		// Token: 0x02000698 RID: 1688
		public enum UpdateType
		{
			// Token: 0x040050BA RID: 20666
			FixedUpdate,
			// Token: 0x040050BB RID: 20667
			LateUpdate,
			// Token: 0x040050BC RID: 20668
			ManualUpdate
		}
	}
}
