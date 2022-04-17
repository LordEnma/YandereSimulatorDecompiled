using System;
using UnityEngine;

// Token: 0x02000335 RID: 821
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018EF RID: 6383 RVA: 0x000F6874 File Offset: 0x000F4A74
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

	// Token: 0x060018F0 RID: 6384 RVA: 0x000F69E2 File Offset: 0x000F4BE2
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x04002651 RID: 9809
	public DropsScript DropMenu;

	// Token: 0x04002652 RID: 9810
	public Transform DropPoint;

	// Token: 0x04002653 RID: 9811
	public GameObject[] Drops;

	// Token: 0x04002654 RID: 9812
	public int[] ItemsToDrop;

	// Token: 0x04002655 RID: 9813
	public int Orders;

	// Token: 0x04002656 RID: 9814
	public int ID;

	// Token: 0x04002657 RID: 9815
	public float Rotation;

	// Token: 0x04002658 RID: 9816
	public float Timer;

	// Token: 0x04002659 RID: 9817
	public bool Dropped;

	// Token: 0x0400265A RID: 9818
	public bool Drop;

	// Token: 0x0400265B RID: 9819
	public bool Test;

	// Token: 0x0400265C RID: 9820
	public bool Open = true;
}
