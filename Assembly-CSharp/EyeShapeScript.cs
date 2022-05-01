using System;
using UnityEngine;

// Token: 0x020002C3 RID: 707
public class EyeShapeScript : MonoBehaviour
{
	// Token: 0x06001495 RID: 5269 RVA: 0x000C92A4 File Offset: 0x000C74A4
	private void Start()
	{
		this.PosOffsetX = UnityEngine.Random.Range(-0.002f, 0.002f);
		this.PosOffsetY = UnityEngine.Random.Range(-0.002f, 0.002f);
		this.PosOffsetZ = UnityEngine.Random.Range(-0.002f, 0.002f);
		this.RotOffsetX = UnityEngine.Random.Range(-15f, 15f);
		this.RotOffsetY = UnityEngine.Random.Range(-15f, 15f);
		this.RotOffsetZ = UnityEngine.Random.Range(-15f, 15f);
	}

	// Token: 0x06001496 RID: 5270 RVA: 0x000C9330 File Offset: 0x000C7530
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

	// Token: 0x04001FD9 RID: 8153
	public Transform eyelid_und1_Left;

	// Token: 0x04001FDA RID: 8154
	public Transform eyelid_und1_Right;

	// Token: 0x04001FDB RID: 8155
	public Transform eyelid_und2_Left;

	// Token: 0x04001FDC RID: 8156
	public Transform eyelid_und2_Right;

	// Token: 0x04001FDD RID: 8157
	public Transform eyelid_und_Left;

	// Token: 0x04001FDE RID: 8158
	public Transform eyelid_und_Right;

	// Token: 0x04001FDF RID: 8159
	public Transform eyerid1_Left;

	// Token: 0x04001FE0 RID: 8160
	public Transform eyerid1_Right;

	// Token: 0x04001FE1 RID: 8161
	public Transform eyerid2_Left;

	// Token: 0x04001FE2 RID: 8162
	public Transform eyerid2_Right;

	// Token: 0x04001FE3 RID: 8163
	public Transform eyerid_Left;

	// Token: 0x04001FE4 RID: 8164
	public Transform eyerid_Right;

	// Token: 0x04001FE5 RID: 8165
	public Transform inner_corner_of_eye_Left;

	// Token: 0x04001FE6 RID: 8166
	public Transform inner_corner_of_eye_Reft;

	// Token: 0x04001FE7 RID: 8167
	public Transform tail_of_eye_Left;

	// Token: 0x04001FE8 RID: 8168
	public Transform tail_of_eye_Right;

	// Token: 0x04001FE9 RID: 8169
	public float PosOffsetX;

	// Token: 0x04001FEA RID: 8170
	public float PosOffsetY;

	// Token: 0x04001FEB RID: 8171
	public float PosOffsetZ;

	// Token: 0x04001FEC RID: 8172
	public float RotOffsetX;

	// Token: 0x04001FED RID: 8173
	public float RotOffsetY;

	// Token: 0x04001FEE RID: 8174
	public float RotOffsetZ;
}
