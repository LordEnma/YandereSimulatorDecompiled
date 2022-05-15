using System;
using UnityEngine;

// Token: 0x02000393 RID: 915
public class PaintingMidoriScript : MonoBehaviour
{
	// Token: 0x06001A71 RID: 6769 RVA: 0x001199DC File Offset: 0x00117BDC
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

	// Token: 0x04002B77 RID: 11127
	public Animation Anim;

	// Token: 0x04002B78 RID: 11128
	public float Rotation;

	// Token: 0x04002B79 RID: 11129
	public int ID;
}
