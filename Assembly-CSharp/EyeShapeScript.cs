using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
public class EyeShapeScript : MonoBehaviour
{
	// Token: 0x0600146D RID: 5229 RVA: 0x000C6980 File Offset: 0x000C4B80
	private void Start()
	{
		this.PosOffsetX = UnityEngine.Random.Range(-0.002f, 0.002f);
		this.PosOffsetY = UnityEngine.Random.Range(-0.002f, 0.002f);
		this.PosOffsetZ = UnityEngine.Random.Range(-0.002f, 0.002f);
		this.RotOffsetX = UnityEngine.Random.Range(-15f, 15f);
		this.RotOffsetY = UnityEngine.Random.Range(-15f, 15f);
		this.RotOffsetZ = UnityEngine.Random.Range(-15f, 15f);
	}

	// Token: 0x0600146E RID: 5230 RVA: 0x000C6A0C File Offset: 0x000C4C0C
	private void LateUpdate()
	{
		this.eyelid_und1_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.eyelid_und1_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.eyelid_und2_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.eyelid_und2_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.eyelid_und_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.eyelid_und_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.eyerid1_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.eyerid1_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.eyerid2_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.eyerid2_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.eyerid_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.eyerid_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.inner_corner_of_eye_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.inner_corner_of_eye_Reft.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.tail_of_eye_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.tail_of_eye_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.eyelid_und1_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.eyelid_und1_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.eyelid_und2_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.eyelid_und2_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.eyelid_und_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.eyelid_und_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.eyerid1_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.eyerid1_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.eyerid2_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.eyerid2_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.eyerid_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.eyerid_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.inner_corner_of_eye_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.inner_corner_of_eye_Reft.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.tail_of_eye_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.tail_of_eye_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
	}

	// Token: 0x04001F6B RID: 8043
	public Transform eyelid_und1_Left;

	// Token: 0x04001F6C RID: 8044
	public Transform eyelid_und1_Right;

	// Token: 0x04001F6D RID: 8045
	public Transform eyelid_und2_Left;

	// Token: 0x04001F6E RID: 8046
	public Transform eyelid_und2_Right;

	// Token: 0x04001F6F RID: 8047
	public Transform eyelid_und_Left;

	// Token: 0x04001F70 RID: 8048
	public Transform eyelid_und_Right;

	// Token: 0x04001F71 RID: 8049
	public Transform eyerid1_Left;

	// Token: 0x04001F72 RID: 8050
	public Transform eyerid1_Right;

	// Token: 0x04001F73 RID: 8051
	public Transform eyerid2_Left;

	// Token: 0x04001F74 RID: 8052
	public Transform eyerid2_Right;

	// Token: 0x04001F75 RID: 8053
	public Transform eyerid_Left;

	// Token: 0x04001F76 RID: 8054
	public Transform eyerid_Right;

	// Token: 0x04001F77 RID: 8055
	public Transform inner_corner_of_eye_Left;

	// Token: 0x04001F78 RID: 8056
	public Transform inner_corner_of_eye_Reft;

	// Token: 0x04001F79 RID: 8057
	public Transform tail_of_eye_Left;

	// Token: 0x04001F7A RID: 8058
	public Transform tail_of_eye_Right;

	// Token: 0x04001F7B RID: 8059
	public float PosOffsetX;

	// Token: 0x04001F7C RID: 8060
	public float PosOffsetY;

	// Token: 0x04001F7D RID: 8061
	public float PosOffsetZ;

	// Token: 0x04001F7E RID: 8062
	public float RotOffsetX;

	// Token: 0x04001F7F RID: 8063
	public float RotOffsetY;

	// Token: 0x04001F80 RID: 8064
	public float RotOffsetZ;
}
