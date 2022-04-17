using System;
using UnityEngine;

// Token: 0x02000504 RID: 1284
public class PlayerLook : MonoBehaviour
{
	// Token: 0x0600214A RID: 8522 RVA: 0x001EB743 File Offset: 0x001E9943
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x0600214B RID: 8523 RVA: 0x001EB756 File Offset: 0x001E9956
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x0600214C RID: 8524 RVA: 0x001EB75E File Offset: 0x001E995E
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x0600214D RID: 8525 RVA: 0x001EB768 File Offset: 0x001E9968
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

	// Token: 0x0600214E RID: 8526 RVA: 0x001EB838 File Offset: 0x001E9A38
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x04004977 RID: 18807
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x04004978 RID: 18808
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x04004979 RID: 18809
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x0400497A RID: 18810
	[SerializeField]
	private Transform playerBody;

	// Token: 0x0400497B RID: 18811
	private float xAxisClamp;
}
