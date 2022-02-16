using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000540 RID: 1344
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x0600226E RID: 8814 RVA: 0x001EE004 File Offset: 0x001EC204
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

		// Token: 0x0600226F RID: 8815 RVA: 0x001EE034 File Offset: 0x001EC234
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

		// Token: 0x06002270 RID: 8816 RVA: 0x001EE084 File Offset: 0x001EC284
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

		// Token: 0x06002271 RID: 8817 RVA: 0x001EE0D4 File Offset: 0x001EC2D4
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

		// Token: 0x06002272 RID: 8818
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x06002273 RID: 8819 RVA: 0x001EE124 File Offset: 0x001EC324
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x06002274 RID: 8820 RVA: 0x001EE150 File Offset: 0x001EC350
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06002275 RID: 8821 RVA: 0x001EE159 File Offset: 0x001EC359
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004A4D RID: 19021
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004A4E RID: 19022
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004A4F RID: 19023
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004A50 RID: 19024
		protected Rigidbody targetRigidbody;

		// Token: 0x0200068B RID: 1675
		public enum UpdateType
		{
			// Token: 0x04004FF7 RID: 20471
			FixedUpdate,
			// Token: 0x04004FF8 RID: 20472
			LateUpdate,
			// Token: 0x04004FF9 RID: 20473
			ManualUpdate
		}
	}
}
