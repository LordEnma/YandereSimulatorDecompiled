using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000546 RID: 1350
	public abstract class AbstractTargetFollower : MonoBehaviour
	{
		// Token: 0x06002295 RID: 8853 RVA: 0x001F1524 File Offset: 0x001EF724
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

		// Token: 0x06002296 RID: 8854 RVA: 0x001F1554 File Offset: 0x001EF754
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

		// Token: 0x06002297 RID: 8855 RVA: 0x001F15A4 File Offset: 0x001EF7A4
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

		// Token: 0x06002298 RID: 8856 RVA: 0x001F15F4 File Offset: 0x001EF7F4
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

		// Token: 0x06002299 RID: 8857
		protected abstract void FollowTarget(float deltaTime);

		// Token: 0x0600229A RID: 8858 RVA: 0x001F1644 File Offset: 0x001EF844
		public void FindAndTargetPlayer()
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
			if (gameObject)
			{
				this.SetTarget(gameObject.transform);
			}
		}

		// Token: 0x0600229B RID: 8859 RVA: 0x001F1670 File Offset: 0x001EF870
		public virtual void SetTarget(Transform newTransform)
		{
			this.m_Target = newTransform;
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x0600229C RID: 8860 RVA: 0x001F1679 File Offset: 0x001EF879
		public Transform Target
		{
			get
			{
				return this.m_Target;
			}
		}

		// Token: 0x04004AD9 RID: 19161
		[SerializeField]
		protected Transform m_Target;

		// Token: 0x04004ADA RID: 19162
		[SerializeField]
		private bool m_AutoTargetPlayer = true;

		// Token: 0x04004ADB RID: 19163
		[SerializeField]
		private AbstractTargetFollower.UpdateType m_UpdateType;

		// Token: 0x04004ADC RID: 19164
		protected Rigidbody targetRigidbody;

		// Token: 0x02000693 RID: 1683
		public enum UpdateType
		{
			// Token: 0x04005088 RID: 20616
			FixedUpdate,
			// Token: 0x04005089 RID: 20617
			LateUpdate,
			// Token: 0x0400508A RID: 20618
			ManualUpdate
		}
	}
}
