using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053E RID: 1342
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x0600225C RID: 8796 RVA: 0x001EC0C4 File Offset: 0x001EA2C4
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

		// Token: 0x0600225D RID: 8797 RVA: 0x001EC0F4 File Offset: 0x001EA2F4
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

		// Token: 0x0600225E RID: 8798 RVA: 0x001EC144 File Offset: 0x001EA344
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

		// Token: 0x0600225F RID: 8799 RVA: 0x001EC194 File Offset: 0x001EA394
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

		// Token: 0x06002260 RID: 8800
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x06002261 RID: 8801 RVA: 0x001EC1E4 File Offset: 0x001EA3E4
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x001EC210 File Offset: 0x001EA410
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06002263 RID: 8803 RVA: 0x001EC219 File Offset: 0x001EA419
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004A29 RID: 18985
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004A2A RID: 18986
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004A2B RID: 18987
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004A2C RID: 18988
		protected Rigidbody targetRigidbody;

		// Token: 0x0200068F RID: 1679
		public enum UpdateType
		{
			// Token: 0x04005001 RID: 20481
			FixedUpdate,
			// Token: 0x04005002 RID: 20482
			LateUpdate,
			// Token: 0x04005003 RID: 20483
			ManualUpdate
		}
	}
}
