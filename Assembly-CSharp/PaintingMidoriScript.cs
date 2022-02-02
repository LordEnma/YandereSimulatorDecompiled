using System;
using UnityEngine;

// Token: 0x0200038E RID: 910
public class PaintingMidoriScript : MonoBehaviour
{
	// Token: 0x06001A3A RID: 6714 RVA: 0x0011628C File Offset: 0x0011448C
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

	// Token: 0x04002AE5 RID: 10981
	public Animation Anim;

	// Token: 0x04002AE6 RID: 10982
	public float Rotation;

	// Token: 0x04002AE7 RID: 10983
	public int ID;
}
