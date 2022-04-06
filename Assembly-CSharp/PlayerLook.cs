using System;
using UnityEngine;

// Token: 0x02000504 RID: 1284
public class PlayerLook : MonoBehaviour
{
	// Token: 0x06002143 RID: 8515 RVA: 0x001EACE7 File Offset: 0x001E8EE7
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x06002144 RID: 8516 RVA: 0x001EACFA File Offset: 0x001E8EFA
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x06002145 RID: 8517 RVA: 0x001EAD02 File Offset: 0x001E8F02
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x06002146 RID: 8518 RVA: 0x001EAD0C File Offset: 0x001E8F0C
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

	// Token: 0x06002147 RID: 8519 RVA: 0x001EADDC File Offset: 0x001E8FDC
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x04004965 RID: 18789
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x04004966 RID: 18790
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x04004967 RID: 18791
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x04004968 RID: 18792
	[SerializeField]
	private Transform playerBody;

	// Token: 0x04004969 RID: 18793
	private float xAxisClamp;
}
