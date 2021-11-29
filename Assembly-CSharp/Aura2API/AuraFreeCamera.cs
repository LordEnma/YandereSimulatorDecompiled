using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005AF RID: 1455
	public class AuraFreeCamera : MonoBehaviour
	{
		// Token: 0x060024A5 RID: 9381 RVA: 0x001F7864 File Offset: 0x001F5A64
		private void Start()
		{
			this.m_yaw = base.transform.rotation.eulerAngles.y;
			this.m_pitch = base.transform.rotation.eulerAngles.x;
			Cursor.visible = this.showCursor;
		}

		// Token: 0x060024A6 RID: 9382 RVA: 0x001F78B8 File Offset: 0x001F5AB8
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

		// Token: 0x04004C11 RID: 19473
		public bool freeLookEnabled;

		// Token: 0x04004C12 RID: 19474
		public bool showCursor;

		// Token: 0x04004C13 RID: 19475
		public float lookSpeed = 5f;

		// Token: 0x04004C14 RID: 19476
		public float moveSpeed = 5f;

		// Token: 0x04004C15 RID: 19477
		public float sprintSpeed = 50f;

		// Token: 0x04004C16 RID: 19478
		private float m_yaw;

		// Token: 0x04004C17 RID: 19479
		private float m_pitch;
	}
}
