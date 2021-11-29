using System;
using UnityEngine;

// Token: 0x0200032F RID: 815
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018B9 RID: 6329 RVA: 0x000F34EC File Offset: 0x000F16EC
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

	// Token: 0x060018BA RID: 6330 RVA: 0x000F365A File Offset: 0x000F185A
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x040025BE RID: 9662
	public DropsScript DropMenu;

	// Token: 0x040025BF RID: 9663
	public Transform DropPoint;

	// Token: 0x040025C0 RID: 9664
	public GameObject[] Drops;

	// Token: 0x040025C1 RID: 9665
	public int[] ItemsToDrop;

	// Token: 0x040025C2 RID: 9666
	public int Orders;

	// Token: 0x040025C3 RID: 9667
	public int ID;

	// Token: 0x040025C4 RID: 9668
	public float Rotation;

	// Token: 0x040025C5 RID: 9669
	public float Timer;

	// Token: 0x040025C6 RID: 9670
	public bool Dropped;

	// Token: 0x040025C7 RID: 9671
	public bool Drop;

	// Token: 0x040025C8 RID: 9672
	public bool Test;

	// Token: 0x040025C9 RID: 9673
	public bool Open = true;
}
