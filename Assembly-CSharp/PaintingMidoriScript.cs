using System;
using UnityEngine;

// Token: 0x02000393 RID: 915
public class PaintingMidoriScript : MonoBehaviour
{
	// Token: 0x06001A72 RID: 6770 RVA: 0x00119C0C File Offset: 0x00117E0C
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.ID++;
		}
		if (this.ID == 0)
		{
			this.Anim.CrossFade("f02_painting_00");
		}
		else if (this.ID == 1)
		{
			this.Anim.CrossFade("f02_shock_00");
			this.Rotation = Mathf.Lerp(this.Rotation, -180f, Time.deltaTime * 10f);
		}
		else if (this.ID == 2)
		{
			base.transform.position -= new Vector3(Time.deltaTime * 2f, 0f, 0f);
		}
		base.transform.localEulerAngles = new Vector3(0f, this.Rotation, 0f);
	}

	// Token: 0x04002B7E RID: 11134
	public Animation Anim;

	// Token: 0x04002B7F RID: 11135
	public float Rotation;

	// Token: 0x04002B80 RID: 11136
	public int ID;
}
