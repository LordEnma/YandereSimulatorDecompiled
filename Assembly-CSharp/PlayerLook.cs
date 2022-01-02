using System;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class PlayerLook : MonoBehaviour
{
	// Token: 0x060020E7 RID: 8423 RVA: 0x001E3147 File Offset: 0x001E1347
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x060020E8 RID: 8424 RVA: 0x001E315A File Offset: 0x001E135A
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x060020E9 RID: 8425 RVA: 0x001E3162 File Offset: 0x001E1362
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x060020EA RID: 8426 RVA: 0x001E316C File Offset: 0x001E136C
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

	// Token: 0x060020EB RID: 8427 RVA: 0x001E323C File Offset: 0x001E143C
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x0400486B RID: 18539
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x0400486C RID: 18540
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x0400486D RID: 18541
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x0400486E RID: 18542
	[SerializeField]
	private Transform playerBody;

	// Token: 0x0400486F RID: 18543
	private float xAxisClamp;
}
