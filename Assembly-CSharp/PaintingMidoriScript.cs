using System;
using UnityEngine;

// Token: 0x0200038F RID: 911
public class PaintingMidoriScript : MonoBehaviour
{
	// Token: 0x06001A43 RID: 6723 RVA: 0x00116784 File Offset: 0x00114984
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

	// Token: 0x04002AEF RID: 10991
	public Animation Anim;

	// Token: 0x04002AF0 RID: 10992
	public float Rotation;

	// Token: 0x04002AF1 RID: 10993
	public int ID;
}
