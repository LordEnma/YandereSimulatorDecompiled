using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B4 RID: 1460
	public class AuraFreeCamera : MonoBehaviour
	{
		// Token: 0x060024C6 RID: 9414 RVA: 0x001FABF8 File Offset: 0x001F8DF8
		private void Start()
		{
			this.m_yaw = base.transform.rotation.eulerAngles.y;
			this.m_pitch = base.transform.rotation.eulerAngles.x;
			Cursor.visible = this.showCursor;
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x001FAC4C File Offset: 0x001F8E4C
		private void Update()
		{
			if (!this.freeLookEnabled)
			{
				return;
			}
			this.m_yaw = (this.m_yaw + this.lookSpeed * Input.GetAxis("Mouse X")) % 360f;
			this.m_pitch = (this.m_pitch - this.lookSpeed * Input.GetAxis("Mouse Y")) % 360f;
			base.transform.rotation = Quaternion.AngleAxis(this.m_yaw, Vector3.up) * Quaternion.AngleAxis(this.m_pitch, Vector3.right);
			float num = Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? this.sprintSpeed : this.moveSpeed);
			float d = num * Input.GetAxis("Vertical");
			float d2 = num * Input.GetAxis("Horizontal");
			float d3 = num * ((Input.GetKey(KeyCode.Q) ? 1f : 0f) - (Input.GetKey(KeyCode.E) ? 1f : 0f));
			base.transform.position += base.transform.forward * d + base.transform.right * d2 + Vector3.up * d3;
		}

		// Token: 0x04004C74 RID: 19572
		public bool freeLookEnabled;

		// Token: 0x04004C75 RID: 19573
		public bool showCursor;

		// Token: 0x04004C76 RID: 19574
		public float lookSpeed = 5f;

		// Token: 0x04004C77 RID: 19575
		public float moveSpeed = 5f;

		// Token: 0x04004C78 RID: 19576
		public float sprintSpeed = 50f;

		// Token: 0x04004C79 RID: 19577
		private float m_yaw;

		// Token: 0x04004C7A RID: 19578
		private float m_pitch;
	}
}
