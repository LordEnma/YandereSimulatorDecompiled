using System;
using UnityEngine;

// Token: 0x02000330 RID: 816
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018C2 RID: 6338 RVA: 0x000F3F90 File Offset: 0x000F2190
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

	// Token: 0x060018C3 RID: 6339 RVA: 0x000F40FE File Offset: 0x000F22FE
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x040025E2 RID: 9698
	public DropsScript DropMenu;

	// Token: 0x040025E3 RID: 9699
	public Transform DropPoint;

	// Token: 0x040025E4 RID: 9700
	public GameObject[] Drops;

	// Token: 0x040025E5 RID: 9701
	public int[] ItemsToDrop;

	// Token: 0x040025E6 RID: 9702
	public int Orders;

	// Token: 0x040025E7 RID: 9703
	public int ID;

	// Token: 0x040025E8 RID: 9704
	public float Rotation;

	// Token: 0x040025E9 RID: 9705
	public float Timer;

	// Token: 0x040025EA RID: 9706
	public bool Dropped;

	// Token: 0x040025EB RID: 9707
	public bool Drop;

	// Token: 0x040025EC RID: 9708
	public bool Test;

	// Token: 0x040025ED RID: 9709
	public bool Open = true;
}
