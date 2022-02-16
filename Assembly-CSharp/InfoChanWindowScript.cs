using System;
using UnityEngine;

// Token: 0x02000332 RID: 818
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018D0 RID: 6352 RVA: 0x000F4BA8 File Offset: 0x000F2DA8
	private void Update()
	{
		if (this.Drop)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, this.Drop ? -90f : 0f, Time.deltaTime * 10f);
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				if ((float)this.Orders > 0f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.Drops[this.ItemsToDrop[this.Orders]], this.DropPoint.position, Quaternion.identity).name = this.DropMenu.DropNames[this.ItemsToDrop[this.Orders]];
					this.Timer = 0f;
					this.Orders--;
				}
				else
				{
					this.Open = false;
					if (this.Timer > 3f)
					{
						base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, 0f, base.transform.localEulerAngles.z);
						this.Drop = false;
					}
				}
			}
		}
		if (this.Test)
		{
			this.DropObject();
		}
	}

	// Token: 0x060018D1 RID: 6353 RVA: 0x000F4D16 File Offset: 0x000F2F16
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x040025F9 RID: 9721
	public DropsScript DropMenu;

	// Token: 0x040025FA RID: 9722
	public Transform DropPoint;

	// Token: 0x040025FB RID: 9723
	public GameObject[] Drops;

	// Token: 0x040025FC RID: 9724
	public int[] ItemsToDrop;

	// Token: 0x040025FD RID: 9725
	public int Orders;

	// Token: 0x040025FE RID: 9726
	public int ID;

	// Token: 0x040025FF RID: 9727
	public float Rotation;

	// Token: 0x04002600 RID: 9728
	public float Timer;

	// Token: 0x04002601 RID: 9729
	public bool Dropped;

	// Token: 0x04002602 RID: 9730
	public bool Drop;

	// Token: 0x04002603 RID: 9731
	public bool Test;

	// Token: 0x04002604 RID: 9732
	public bool Open = true;
}
