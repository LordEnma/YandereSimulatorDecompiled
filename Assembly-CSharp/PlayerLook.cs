using System;
using UnityEngine;

// Token: 0x02000506 RID: 1286
public class PlayerLook : MonoBehaviour
{
	// Token: 0x0600215E RID: 8542 RVA: 0x001EE31B File Offset: 0x001EC51B
	private void Awake()
	{
		this.LockCursor();
		this.xAxisClamp = 0f;
	}

	// Token: 0x0600215F RID: 8543 RVA: 0x001EE32E File Offset: 0x001EC52E
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x06002160 RID: 8544 RVA: 0x001EE336 File Offset: 0x001EC536
	private void Update()
	{
		this.CameraRotation();
	}

	// Token: 0x06002161 RID: 8545 RVA: 0x001EE340 File Offset: 0x001EC540
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

	// Token: 0x06002162 RID: 8546 RVA: 0x001EE410 File Offset: 0x001EC610
	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.x = value;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x040049B4 RID: 18868
	[SerializeField]
	private string mouseXInputName;

	// Token: 0x040049B5 RID: 18869
	[SerializeField]
	private string mouseYInputName;

	// Token: 0x040049B6 RID: 18870
	[SerializeField]
	private float mouseSensitivity;

	// Token: 0x040049B7 RID: 18871
	[SerializeField]
	private Transform playerBody;

	// Token: 0x040049B8 RID: 18872
	private float xAxisClamp;
}
