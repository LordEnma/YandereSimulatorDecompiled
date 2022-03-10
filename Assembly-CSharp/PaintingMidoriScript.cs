using System;
using UnityEngine;

// Token: 0x02000390 RID: 912
public class PaintingMidoriScript : MonoBehaviour
{
	// Token: 0x06001A4D RID: 6733 RVA: 0x00117570 File Offset: 0x00115770
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

	// Token: 0x04002B15 RID: 11029
	public Animation Anim;

	// Token: 0x04002B16 RID: 11030
	public float Rotation;

	// Token: 0x04002B17 RID: 11031
	public int ID;
}
