using System;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class PlayerLook : MonoBehaviour
{
	// Token: 0x0600210D RID: 8461 RVA: 0x001E6607 File Offset: 0x001E4807
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x0600210E RID: 8462 RVA: 0x001E661A File Offset: 0x001E481A
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x0600210F RID: 8463 RVA: 0x001E6622 File Offset: 0x001E4822
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x06002110 RID: 8464 RVA: 0x001E662C File Offset: 0x001E482C
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

	// Token: 0x06002111 RID: 8465 RVA: 0x001E66FC File Offset: 0x001E48FC
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x040048B3 RID: 18611
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x040048B4 RID: 18612
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x040048B5 RID: 18613
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x040048B6 RID: 18614
	[SerializeField]
	private Transform playerBody;

	// Token: 0x040048B7 RID: 18615
	private float xAxisClamp;
}
