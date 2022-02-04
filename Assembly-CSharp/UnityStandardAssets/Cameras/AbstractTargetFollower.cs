using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053F RID: 1343
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x06002264 RID: 8804 RVA: 0x001ED94C File Offset: 0x001EBB4C
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

		// Token: 0x06002265 RID: 8805 RVA: 0x001ED97C File Offset: 0x001EBB7C
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

		// Token: 0x06002266 RID: 8806 RVA: 0x001ED9CC File Offset: 0x001EBBCC
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

		// Token: 0x06002267 RID: 8807 RVA: 0x001EDA1C File Offset: 0x001EBC1C
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

		// Token: 0x06002268 RID: 8808
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x06002269 RID: 8809 RVA: 0x001EDA6C File Offset: 0x001EBC6C
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x001EDA98 File Offset: 0x001EBC98
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x0600226B RID: 8811 RVA: 0x001EDAA1 File Offset: 0x001EBCA1
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004A41 RID: 19009
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004A42 RID: 19010
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004A43 RID: 19011
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004A44 RID: 19012
		protected Rigidbody targetRigidbody;

		// Token: 0x0200068A RID: 1674
		public enum UpdateType
		{
			// Token: 0x04004FEB RID: 20459
			FixedUpdate,
			// Token: 0x04004FEC RID: 20460
			LateUpdate,
			// Token: 0x04004FED RID: 20461
			ManualUpdate
		}
	}
}
