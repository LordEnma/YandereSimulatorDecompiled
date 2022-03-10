using System;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class PlayerLook : MonoBehaviour
{
	// Token: 0x06002113 RID: 8467 RVA: 0x001E6FDF File Offset: 0x001E51DF
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x06002114 RID: 8468 RVA: 0x001E6FF2 File Offset: 0x001E51F2
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x06002115 RID: 8469 RVA: 0x001E6FFA File Offset: 0x001E51FA
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x06002116 RID: 8470 RVA: 0x001E7004 File Offset: 0x001E5204
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

	// Token: 0x06002117 RID: 8471 RVA: 0x001E70D4 File Offset: 0x001E52D4
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x040048D0 RID: 18640
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x040048D1 RID: 18641
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x040048D2 RID: 18642
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x040048D3 RID: 18643
	[SerializeField]
	private Transform playerBody;

	// Token: 0x040048D4 RID: 18644
	private float xAxisClamp;
}
