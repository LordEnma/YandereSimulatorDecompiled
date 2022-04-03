using System;
using UnityEngine;

// Token: 0x02000391 RID: 913
public class PaintingMidoriScript : MonoBehaviour
{
	// Token: 0x06001A5D RID: 6749 RVA: 0x001186D8 File Offset: 0x001168D8
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

	// Token: 0x04002B51 RID: 11089
	public Animation Anim;

	// Token: 0x04002B52 RID: 11090
	public float Rotation;

	// Token: 0x04002B53 RID: 11091
	public int ID;
}
