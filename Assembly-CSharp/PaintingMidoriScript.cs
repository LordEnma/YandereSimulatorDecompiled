using System;
using UnityEngine;

// Token: 0x0200038C RID: 908
public class PaintingMidoriScript : MonoBehaviour
{
	// Token: 0x06001A2B RID: 6699 RVA: 0x00114E98 File Offset: 0x00113098
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

	// Token: 0x04002AA8 RID: 10920
	public Animation Anim;

	// Token: 0x04002AA9 RID: 10921
	public float Rotation;

	// Token: 0x04002AAA RID: 10922
	public int ID;
}
