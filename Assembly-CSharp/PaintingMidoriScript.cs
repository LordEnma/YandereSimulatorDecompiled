using System;
using UnityEngine;

// Token: 0x0200038D RID: 909
public class PaintingMidoriScript : MonoBehaviour
{
	// Token: 0x06001A35 RID: 6709 RVA: 0x001159A4 File Offset: 0x00113BA4
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

	// Token: 0x04002AD6 RID: 10966
	public Animation Anim;

	// Token: 0x04002AD7 RID: 10967
	public float Rotation;

	// Token: 0x04002AD8 RID: 10968
	public int ID;
}
