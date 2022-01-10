using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B3 RID: 1459
	public class AuraFreeCamera : MonoBehaviour
	{
		// Token: 0x060024C4 RID: 9412 RVA: 0x001F9F28 File Offset: 0x001F8128
		private void Start()
		{
			this.m_yaw = base.transform.rotation.eulerAngles.y;
			this.m_pitch = base.transform.rotation.eulerAngles.x;
			Cursor.visible = this.showCursor;
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x001F9F7C File Offset: 0x001F817C
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

		// Token: 0x04004C6D RID: 19565
		public bool freeLookEnabled;

		// Token: 0x04004C6E RID: 19566
		public bool showCursor;

		// Token: 0x04004C6F RID: 19567
		public float lookSpeed = 5f;

		// Token: 0x04004C70 RID: 19568
		public float moveSpeed = 5f;

		// Token: 0x04004C71 RID: 19569
		public float sprintSpeed = 50f;

		// Token: 0x04004C72 RID: 19570
		private float m_yaw;

		// Token: 0x04004C73 RID: 19571
		private float m_pitch;
	}
}
