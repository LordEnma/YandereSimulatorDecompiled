using System;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class PlayerLook : MonoBehaviour
{
	// Token: 0x060020FD RID: 8445 RVA: 0x001E5573 File Offset: 0x001E3773
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x060020FE RID: 8446 RVA: 0x001E5586 File Offset: 0x001E3786
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x060020FF RID: 8447 RVA: 0x001E558E File Offset: 0x001E378E
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x06002100 RID: 8448 RVA: 0x001E5598 File Offset: 0x001E3798
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

	// Token: 0x06002101 RID: 8449 RVA: 0x001E5668 File Offset: 0x001E3868
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x0400489A RID: 18586
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x0400489B RID: 18587
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x0400489C RID: 18588
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x0400489D RID: 18589
	[SerializeField]
	private Transform playerBody;

	// Token: 0x0400489E RID: 18590
	private float xAxisClamp;
}
