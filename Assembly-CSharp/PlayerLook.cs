using System;
using UnityEngine;

// Token: 0x020004F2 RID: 1266
public class PlayerLook : MonoBehaviour
{
	// Token: 0x060020D3 RID: 8403 RVA: 0x001E1423 File Offset: 0x001DF623
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x060020D4 RID: 8404 RVA: 0x001E1436 File Offset: 0x001DF636
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x060020D5 RID: 8405 RVA: 0x001E143E File Offset: 0x001DF63E
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x060020D6 RID: 8406 RVA: 0x001E1448 File Offset: 0x001DF648
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

	// Token: 0x060020D7 RID: 8407 RVA: 0x001E1518 File Offset: 0x001DF718
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x04004823 RID: 18467
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x04004824 RID: 18468
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x04004825 RID: 18469
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x04004826 RID: 18470
	[SerializeField]
	private Transform playerBody;

	// Token: 0x04004827 RID: 18471
	private float xAxisClamp;
}
