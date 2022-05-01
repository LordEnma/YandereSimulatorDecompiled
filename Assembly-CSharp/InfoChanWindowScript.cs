using System;
using UnityEngine;

// Token: 0x02000335 RID: 821
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018F3 RID: 6387 RVA: 0x000F6D78 File Offset: 0x000F4F78
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

	// Token: 0x060018F4 RID: 6388 RVA: 0x000F6EE6 File Offset: 0x000F50E6
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x0400265A RID: 9818
	public DropsScript DropMenu;

	// Token: 0x0400265B RID: 9819
	public Transform DropPoint;

	// Token: 0x0400265C RID: 9820
	public GameObject[] Drops;

	// Token: 0x0400265D RID: 9821
	public int[] ItemsToDrop;

	// Token: 0x0400265E RID: 9822
	public int Orders;

	// Token: 0x0400265F RID: 9823
	public int ID;

	// Token: 0x04002660 RID: 9824
	public float Rotation;

	// Token: 0x04002661 RID: 9825
	public float Timer;

	// Token: 0x04002662 RID: 9826
	public bool Dropped;

	// Token: 0x04002663 RID: 9827
	public bool Drop;

	// Token: 0x04002664 RID: 9828
	public bool Test;

	// Token: 0x04002665 RID: 9829
	public bool Open = true;
}
