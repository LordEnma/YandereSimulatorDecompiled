using System;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class PlayerLook : MonoBehaviour
{
	// Token: 0x060020FA RID: 8442 RVA: 0x001E536F File Offset: 0x001E356F
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x060020FB RID: 8443 RVA: 0x001E5382 File Offset: 0x001E3582
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x060020FC RID: 8444 RVA: 0x001E538A File Offset: 0x001E358A
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x060020FD RID: 8445 RVA: 0x001E5394 File Offset: 0x001E3594
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

	// Token: 0x060020FE RID: 8446 RVA: 0x001E5464 File Offset: 0x001E3664
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x04004897 RID: 18583
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x04004898 RID: 18584
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x04004899 RID: 18585
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x0400489A RID: 18586
	[SerializeField]
	private Transform playerBody;

	// Token: 0x0400489B RID: 18587
	private float xAxisClamp;
}
