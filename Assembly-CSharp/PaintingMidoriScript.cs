using System;
using UnityEngine;

// Token: 0x02000392 RID: 914
public class PaintingMidoriScript : MonoBehaviour
{
	// Token: 0x06001A6B RID: 6763 RVA: 0x001190E8 File Offset: 0x001172E8
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

	// Token: 0x04002B65 RID: 11109
	public Animation Anim;

	// Token: 0x04002B66 RID: 11110
	public float Rotation;

	// Token: 0x04002B67 RID: 11111
	public int ID;
}
