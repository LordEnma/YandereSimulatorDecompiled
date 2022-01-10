using System;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class PlayerLook : MonoBehaviour
{
	// Token: 0x060020F2 RID: 8434 RVA: 0x001E3AE7 File Offset: 0x001E1CE7
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x060020F3 RID: 8435 RVA: 0x001E3AFA File Offset: 0x001E1CFA
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x060020F4 RID: 8436 RVA: 0x001E3B02 File Offset: 0x001E1D02
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x060020F5 RID: 8437 RVA: 0x001E3B0C File Offset: 0x001E1D0C
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

	// Token: 0x060020F6 RID: 8438 RVA: 0x001E3BDC File Offset: 0x001E1DDC
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x0400487F RID: 18559
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x04004880 RID: 18560
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x04004881 RID: 18561
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x04004882 RID: 18562
	[SerializeField]
	private Transform playerBody;

	// Token: 0x04004883 RID: 18563
	private float xAxisClamp;
}
