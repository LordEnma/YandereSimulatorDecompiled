using System;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
public class PlayerLook : MonoBehaviour
{
	// Token: 0x06002104 RID: 8452 RVA: 0x001E5A27 File Offset: 0x001E3C27
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x06002105 RID: 8453 RVA: 0x001E5A3A File Offset: 0x001E3C3A
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x06002106 RID: 8454 RVA: 0x001E5A42 File Offset: 0x001E3C42
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x06002107 RID: 8455 RVA: 0x001E5A4C File Offset: 0x001E3C4C
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

	// Token: 0x06002108 RID: 8456 RVA: 0x001E5B1C File Offset: 0x001E3D1C
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x040048A3 RID: 18595
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x040048A4 RID: 18596
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x040048A5 RID: 18597
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x040048A6 RID: 18598
	[SerializeField]
	private Transform playerBody;

	// Token: 0x040048A7 RID: 18599
	private float xAxisClamp;
}
