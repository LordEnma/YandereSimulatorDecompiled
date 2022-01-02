using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B1 RID: 1457
	public class AuraFreeCamera : MonoBehaviour
	{
		// Token: 0x060024B9 RID: 9401 RVA: 0x001F9588 File Offset: 0x001F7788
		private void Start()
		{
			this.m_yaw = base.transform.rotation.eulerAngles.y;
			this.m_pitch = base.transform.rotation.eulerAngles.x;
			Cursor.visible = this.showCursor;
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x001F95DC File Offset: 0x001F77DC
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

		// Token: 0x04004C59 RID: 19545
		public bool freeLookEnabled;

		// Token: 0x04004C5A RID: 19546
		public bool showCursor;

		// Token: 0x04004C5B RID: 19547
		public float lookSpeed = 5f;

		// Token: 0x04004C5C RID: 19548
		public float moveSpeed = 5f;

		// Token: 0x04004C5D RID: 19549
		public float sprintSpeed = 50f;

		// Token: 0x04004C5E RID: 19550
		private float m_yaw;

		// Token: 0x04004C5F RID: 19551
		private float m_pitch;
	}
}
