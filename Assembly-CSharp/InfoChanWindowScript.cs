using System;
using UnityEngine;

// Token: 0x02000331 RID: 817
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018C9 RID: 6345 RVA: 0x000F4A04 File Offset: 0x000F2C04
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

	// Token: 0x060018CA RID: 6346 RVA: 0x000F4B72 File Offset: 0x000F2D72
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x040025F3 RID: 9715
	public DropsScript DropMenu;

	// Token: 0x040025F4 RID: 9716
	public Transform DropPoint;

	// Token: 0x040025F5 RID: 9717
	public GameObject[] Drops;

	// Token: 0x040025F6 RID: 9718
	public int[] ItemsToDrop;

	// Token: 0x040025F7 RID: 9719
	public int Orders;

	// Token: 0x040025F8 RID: 9720
	public int ID;

	// Token: 0x040025F9 RID: 9721
	public float Rotation;

	// Token: 0x040025FA RID: 9722
	public float Timer;

	// Token: 0x040025FB RID: 9723
	public bool Dropped;

	// Token: 0x040025FC RID: 9724
	public bool Drop;

	// Token: 0x040025FD RID: 9725
	public bool Test;

	// Token: 0x040025FE RID: 9726
	public bool Open = true;
}
