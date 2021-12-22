using System;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class PlayerLook : MonoBehaviour
{
	// Token: 0x060020E4 RID: 8420 RVA: 0x001E2B57 File Offset: 0x001E0D57
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x060020E5 RID: 8421 RVA: 0x001E2B6A File Offset: 0x001E0D6A
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x060020E6 RID: 8422 RVA: 0x001E2B72 File Offset: 0x001E0D72
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x060020E7 RID: 8423 RVA: 0x001E2B7C File Offset: 0x001E0D7C
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

	// Token: 0x060020E8 RID: 8424 RVA: 0x001E2C4C File Offset: 0x001E0E4C
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x04004862 RID: 18530
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x04004863 RID: 18531
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x04004864 RID: 18532
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x04004865 RID: 18533
	[SerializeField]
	private Transform playerBody;

	// Token: 0x04004866 RID: 18534
	private float xAxisClamp;
}
