using System;
using UnityEngine;

// Token: 0x0200038E RID: 910
public class PaintingMidoriScript : MonoBehaviour
{
	// Token: 0x06001A39 RID: 6713 RVA: 0x00115CE0 File Offset: 0x00113EE0
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

	// Token: 0x04002ADC RID: 10972
	public Animation Anim;

	// Token: 0x04002ADD RID: 10973
	public float Rotation;

	// Token: 0x04002ADE RID: 10974
	public int ID;
}
