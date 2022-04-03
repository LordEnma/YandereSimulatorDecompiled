using System;
using UnityEngine;

// Token: 0x02000503 RID: 1283
public class PlayerLook : MonoBehaviour
{
	// Token: 0x0600213B RID: 8507 RVA: 0x001EA7B7 File Offset: 0x001E89B7
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x0600213C RID: 8508 RVA: 0x001EA7CA File Offset: 0x001E89CA
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x0600213D RID: 8509 RVA: 0x001EA7D2 File Offset: 0x001E89D2
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x0600213E RID: 8510 RVA: 0x001EA7DC File Offset: 0x001E89DC
	private void CameraRotation()
	{
		float d = Input.GetAxis(this.mouseXInputName) * this.mouseSensitivity * Time.deltaTime;
		float num = Input.GetAxis(this.mouseYInputName) * this.mouseSensitivity * Time.deltaTime;
		this.xAxisClamp += num;
		if (this.xAxisClamp > 90f)
		{
			this.xAxisClamp = 90f;
			num = 0f;
			this.ClampXAxisRotationToValue(270f);
		}
		else if (this.xAxisClamp < -90f)
		{
			this.xAxisClamp = -90f;
			num = 0f;
			this.ClampXAxisRotationToValue(90f);
		}
		base.transform.Rotate(Vector3.left * num);
		this.playerBody.Rotate(Vector3.up * d);
	}

	// Token: 0x0600213F RID: 8511 RVA: 0x001EA8AC File Offset: 0x001E8AAC
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x04004961 RID: 18785
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x04004962 RID: 18786
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x04004963 RID: 18787
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x04004964 RID: 18788
	[SerializeField]
	private Transform playerBody;

	// Token: 0x04004965 RID: 18789
	private float xAxisClamp;
}
