using System;
using UnityEngine;

// Token: 0x02000390 RID: 912
public class PaintingMidoriScript : MonoBehaviour
{
	// Token: 0x06001A4C RID: 6732 RVA: 0x00117198 File Offset: 0x00115398
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

	// Token: 0x04002AFF RID: 11007
	public Animation Anim;

	// Token: 0x04002B00 RID: 11008
	public float Rotation;

	// Token: 0x04002B01 RID: 11009
	public int ID;
}
