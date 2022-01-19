using System;
using UnityEngine;

// Token: 0x020002C0 RID: 704
public class EyeShapeScript : MonoBehaviour
{
	// Token: 0x06001478 RID: 5240 RVA: 0x000C7718 File Offset: 0x000C5918
	private void Start()
	{
		this.PosOffsetX = UnityEngine.Random.Range(-0.002f, 0.002f);
		this.PosOffsetY = UnityEngine.Random.Range(-0.002f, 0.002f);
		this.PosOffsetZ = UnityEngine.Random.Range(-0.002f, 0.002f);
		this.RotOffsetX = UnityEngine.Random.Range(-15f, 15f);
		this.RotOffsetY = UnityEngine.Random.Range(-15f, 15f);
		this.RotOffsetZ = UnityEngine.Random.Range(-15f, 15f);
	}

	// Token: 0x06001479 RID: 5241 RVA: 0x000C77A4 File Offset: 0x000C59A4
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

	// Token: 0x04001F95 RID: 8085
	public Transform eyelid_und1_Left;

	// Token: 0x04001F96 RID: 8086
	public Transform eyelid_und1_Right;

	// Token: 0x04001F97 RID: 8087
	public Transform eyelid_und2_Left;

	// Token: 0x04001F98 RID: 8088
	public Transform eyelid_und2_Right;

	// Token: 0x04001F99 RID: 8089
	public Transform eyelid_und_Left;

	// Token: 0x04001F9A RID: 8090
	public Transform eyelid_und_Right;

	// Token: 0x04001F9B RID: 8091
	public Transform eyerid1_Left;

	// Token: 0x04001F9C RID: 8092
	public Transform eyerid1_Right;

	// Token: 0x04001F9D RID: 8093
	public Transform eyerid2_Left;

	// Token: 0x04001F9E RID: 8094
	public Transform eyerid2_Right;

	// Token: 0x04001F9F RID: 8095
	public Transform eyerid_Left;

	// Token: 0x04001FA0 RID: 8096
	public Transform eyerid_Right;

	// Token: 0x04001FA1 RID: 8097
	public Transform inner_corner_of_eye_Left;

	// Token: 0x04001FA2 RID: 8098
	public Transform inner_corner_of_eye_Reft;

	// Token: 0x04001FA3 RID: 8099
	public Transform tail_of_eye_Left;

	// Token: 0x04001FA4 RID: 8100
	public Transform tail_of_eye_Right;

	// Token: 0x04001FA5 RID: 8101
	public float PosOffsetX;

	// Token: 0x04001FA6 RID: 8102
	public float PosOffsetY;

	// Token: 0x04001FA7 RID: 8103
	public float PosOffsetZ;

	// Token: 0x04001FA8 RID: 8104
	public float RotOffsetX;

	// Token: 0x04001FA9 RID: 8105
	public float RotOffsetY;

	// Token: 0x04001FAA RID: 8106
	public float RotOffsetZ;
}
