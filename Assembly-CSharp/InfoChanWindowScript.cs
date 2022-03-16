using System;
using UnityEngine;

// Token: 0x02000333 RID: 819
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018DF RID: 6367 RVA: 0x000F5E78 File Offset: 0x000F4078
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

	// Token: 0x060018E0 RID: 6368 RVA: 0x000F5FE6 File Offset: 0x000F41E6
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x04002633 RID: 9779
	public DropsScript DropMenu;

	// Token: 0x04002634 RID: 9780
	public Transform DropPoint;

	// Token: 0x04002635 RID: 9781
	public GameObject[] Drops;

	// Token: 0x04002636 RID: 9782
	public int[] ItemsToDrop;

	// Token: 0x04002637 RID: 9783
	public int Orders;

	// Token: 0x04002638 RID: 9784
	public int ID;

	// Token: 0x04002639 RID: 9785
	public float Rotation;

	// Token: 0x0400263A RID: 9786
	public float Timer;

	// Token: 0x0400263B RID: 9787
	public bool Dropped;

	// Token: 0x0400263C RID: 9788
	public bool Drop;

	// Token: 0x0400263D RID: 9789
	public bool Test;

	// Token: 0x0400263E RID: 9790
	public bool Open = true;
}
