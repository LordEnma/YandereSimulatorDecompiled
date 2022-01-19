using System;
using UnityEngine;

// Token: 0x02000331 RID: 817
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018C6 RID: 6342 RVA: 0x000F4414 File Offset: 0x000F2614
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

	// Token: 0x060018C7 RID: 6343 RVA: 0x000F4582 File Offset: 0x000F2782
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x040025E9 RID: 9705
	public DropsScript DropMenu;

	// Token: 0x040025EA RID: 9706
	public Transform DropPoint;

	// Token: 0x040025EB RID: 9707
	public GameObject[] Drops;

	// Token: 0x040025EC RID: 9708
	public int[] ItemsToDrop;

	// Token: 0x040025ED RID: 9709
	public int Orders;

	// Token: 0x040025EE RID: 9710
	public int ID;

	// Token: 0x040025EF RID: 9711
	public float Rotation;

	// Token: 0x040025F0 RID: 9712
	public float Timer;

	// Token: 0x040025F1 RID: 9713
	public bool Dropped;

	// Token: 0x040025F2 RID: 9714
	public bool Drop;

	// Token: 0x040025F3 RID: 9715
	public bool Test;

	// Token: 0x040025F4 RID: 9716
	public bool Open = true;
}
