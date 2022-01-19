using System;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class PlayerLook : MonoBehaviour
{
	// Token: 0x060020F4 RID: 8436 RVA: 0x001E47B7 File Offset: 0x001E29B7
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x060020F5 RID: 8437 RVA: 0x001E47CA File Offset: 0x001E29CA
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x060020F6 RID: 8438 RVA: 0x001E47D2 File Offset: 0x001E29D2
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x060020F7 RID: 8439 RVA: 0x001E47DC File Offset: 0x001E29DC
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

	// Token: 0x060020F8 RID: 8440 RVA: 0x001E48AC File Offset: 0x001E2AAC
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x04004886 RID: 18566
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x04004887 RID: 18567
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x04004888 RID: 18568
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x04004889 RID: 18569
	[SerializeField]
	private Transform playerBody;

	// Token: 0x0400488A RID: 18570
	private float xAxisClamp;
}
