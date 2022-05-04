using System;
using UnityEngine;

// Token: 0x02000455 RID: 1109
public class StringScript : MonoBehaviour
{
	// Token: 0x06001D6A RID: 7530 RVA: 0x00161FEF File Offset: 0x001601EF
	private void Start()
	{
		if (this.ArrayID == 0)
		{
			this.Target.position = this.Origin.position;
		}
	}

	// Token: 0x06001D6B RID: 7531 RVA: 0x00162010 File Offset: 0x00160210
	private void Update()
	{
		this.String.position = this.Origin.position;
		this.String.LookAt(this.Target);
		this.String.localScale = new Vector3(this.String.localScale.x, this.String.localScale.y, Vector3.Distance(this.Origin.position, this.Target.position) * 0.5f);
	}

	// Token: 0x04003616 RID: 13846
	public Transform Origin;

	// Token: 0x04003617 RID: 13847
	public Transform Target;

	// Token: 0x04003618 RID: 13848
	public Transform String;

	// Token: 0x04003619 RID: 13849
	public int ArrayID;
}
