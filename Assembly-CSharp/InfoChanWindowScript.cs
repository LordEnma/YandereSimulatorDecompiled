using System;
using UnityEngine;

// Token: 0x02000335 RID: 821
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018EB RID: 6379 RVA: 0x000F65E0 File Offset: 0x000F47E0
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

	// Token: 0x060018EC RID: 6380 RVA: 0x000F674E File Offset: 0x000F494E
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x04002649 RID: 9801
	public DropsScript DropMenu;

	// Token: 0x0400264A RID: 9802
	public Transform DropPoint;

	// Token: 0x0400264B RID: 9803
	public GameObject[] Drops;

	// Token: 0x0400264C RID: 9804
	public int[] ItemsToDrop;

	// Token: 0x0400264D RID: 9805
	public int Orders;

	// Token: 0x0400264E RID: 9806
	public int ID;

	// Token: 0x0400264F RID: 9807
	public float Rotation;

	// Token: 0x04002650 RID: 9808
	public float Timer;

	// Token: 0x04002651 RID: 9809
	public bool Dropped;

	// Token: 0x04002652 RID: 9810
	public bool Drop;

	// Token: 0x04002653 RID: 9811
	public bool Test;

	// Token: 0x04002654 RID: 9812
	public bool Open = true;
}
