using System;
using UnityEngine;

// Token: 0x02000506 RID: 1286
public class PlayerLook : MonoBehaviour
{
	// Token: 0x0600215F RID: 8543 RVA: 0x001EE883 File Offset: 0x001ECA83
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x06002160 RID: 8544 RVA: 0x001EE896 File Offset: 0x001ECA96
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x06002161 RID: 8545 RVA: 0x001EE89E File Offset: 0x001ECA9E
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x06002162 RID: 8546 RVA: 0x001EE8A8 File Offset: 0x001ECAA8
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

	// Token: 0x06002163 RID: 8547 RVA: 0x001EE978 File Offset: 0x001ECB78
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x040049BD RID: 18877
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x040049BE RID: 18878
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x040049BF RID: 18879
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x040049C0 RID: 18880
	[SerializeField]
	private Transform playerBody;

	// Token: 0x040049C1 RID: 18881
	private float xAxisClamp;
}
