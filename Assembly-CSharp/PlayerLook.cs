using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class PlayerLook : MonoBehaviour
{
	// Token: 0x0600212B RID: 8491 RVA: 0x001E8F47 File Offset: 0x001E7147
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x0600212C RID: 8492 RVA: 0x001E8F5A File Offset: 0x001E715A
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x0600212D RID: 8493 RVA: 0x001E8F62 File Offset: 0x001E7162
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x0600212E RID: 8494 RVA: 0x001E8F6C File Offset: 0x001E716C
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

	// Token: 0x0600212F RID: 8495 RVA: 0x001E903C File Offset: 0x001E723C
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x0400492F RID: 18735
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x04004930 RID: 18736
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x04004931 RID: 18737
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x04004932 RID: 18738
	[SerializeField]
	private Transform playerBody;

	// Token: 0x04004933 RID: 18739
	private float xAxisClamp;
}
