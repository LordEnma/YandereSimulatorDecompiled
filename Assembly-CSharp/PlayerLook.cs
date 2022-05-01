using System;
using UnityEngine;

// Token: 0x02000505 RID: 1285
public class PlayerLook : MonoBehaviour
{
	// Token: 0x06002153 RID: 8531 RVA: 0x001ECBCF File Offset: 0x001EADCF
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x06002154 RID: 8532 RVA: 0x001ECBE2 File Offset: 0x001EADE2
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x06002155 RID: 8533 RVA: 0x001ECBEA File Offset: 0x001EADEA
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x06002156 RID: 8534 RVA: 0x001ECBF4 File Offset: 0x001EADF4
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

	// Token: 0x06002157 RID: 8535 RVA: 0x001ECCC4 File Offset: 0x001EAEC4
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x0400498D RID: 18829
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x0400498E RID: 18830
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x0400498F RID: 18831
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x04004990 RID: 18832
	[SerializeField]
	private Transform playerBody;

	// Token: 0x04004991 RID: 18833
	private float xAxisClamp;
}
