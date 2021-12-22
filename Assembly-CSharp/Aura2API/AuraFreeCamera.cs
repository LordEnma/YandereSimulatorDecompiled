using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B1 RID: 1457
	public class AuraFreeCamera : MonoBehaviour
	{
		// Token: 0x060024B6 RID: 9398 RVA: 0x001F8F98 File Offset: 0x001F7198
		private void Start()
		{
			this.m_yaw = base.transform.rotation.eulerAngles.y;
			this.m_pitch = base.transform.rotation.eulerAngles.x;
			Cursor.visible = this.showCursor;
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x001F8FEC File Offset: 0x001F71EC
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

		// Token: 0x04004C50 RID: 19536
		public bool freeLookEnabled;

		// Token: 0x04004C51 RID: 19537
		public bool showCursor;

		// Token: 0x04004C52 RID: 19538
		public float lookSpeed = 5f;

		// Token: 0x04004C53 RID: 19539
		public float moveSpeed = 5f;

		// Token: 0x04004C54 RID: 19540
		public float sprintSpeed = 50f;

		// Token: 0x04004C55 RID: 19541
		private float m_yaw;

		// Token: 0x04004C56 RID: 19542
		private float m_pitch;
	}
}
