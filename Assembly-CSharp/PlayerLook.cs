using System;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class PlayerLook : MonoBehaviour
{
	// Token: 0x060020F8 RID: 8440 RVA: 0x001E5057 File Offset: 0x001E3257
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x060020F9 RID: 8441 RVA: 0x001E506A File Offset: 0x001E326A
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x060020FA RID: 8442 RVA: 0x001E5072 File Offset: 0x001E3272
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x060020FB RID: 8443 RVA: 0x001E507C File Offset: 0x001E327C
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

	// Token: 0x060020FC RID: 8444 RVA: 0x001E514C File Offset: 0x001E334C
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x04004891 RID: 18577
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x04004892 RID: 18578
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x04004893 RID: 18579
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x04004894 RID: 18580
	[SerializeField]
	private Transform playerBody;

	// Token: 0x04004895 RID: 18581
	private float xAxisClamp;
}
