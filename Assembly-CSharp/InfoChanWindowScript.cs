using System;
using UnityEngine;

// Token: 0x02000330 RID: 816
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018C0 RID: 6336 RVA: 0x000F3CDC File Offset: 0x000F1EDC
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

	// Token: 0x060018C1 RID: 6337 RVA: 0x000F3E4A File Offset: 0x000F204A
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x040025DE RID: 9694
	public DropsScript DropMenu;

	// Token: 0x040025DF RID: 9695
	public Transform DropPoint;

	// Token: 0x040025E0 RID: 9696
	public GameObject[] Drops;

	// Token: 0x040025E1 RID: 9697
	public int[] ItemsToDrop;

	// Token: 0x040025E2 RID: 9698
	public int Orders;

	// Token: 0x040025E3 RID: 9699
	public int ID;

	// Token: 0x040025E4 RID: 9700
	public float Rotation;

	// Token: 0x040025E5 RID: 9701
	public float Timer;

	// Token: 0x040025E6 RID: 9702
	public bool Dropped;

	// Token: 0x040025E7 RID: 9703
	public bool Drop;

	// Token: 0x040025E8 RID: 9704
	public bool Test;

	// Token: 0x040025E9 RID: 9705
	public bool Open = true;
}
