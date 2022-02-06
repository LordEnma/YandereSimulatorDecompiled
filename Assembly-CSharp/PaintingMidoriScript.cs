using System;
using UnityEngine;

// Token: 0x0200038E RID: 910
public class PaintingMidoriScript : MonoBehaviour
{
	// Token: 0x06001A3C RID: 6716 RVA: 0x00116460 File Offset: 0x00114660
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

	// Token: 0x04002AE9 RID: 10985
	public Animation Anim;

	// Token: 0x04002AEA RID: 10986
	public float Rotation;

	// Token: 0x04002AEB RID: 10987
	public int ID;
}
