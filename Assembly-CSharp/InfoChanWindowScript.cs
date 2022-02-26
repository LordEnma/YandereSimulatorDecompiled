using System;
using UnityEngine;

// Token: 0x02000333 RID: 819
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018D9 RID: 6361 RVA: 0x000F54AC File Offset: 0x000F36AC
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

	// Token: 0x060018DA RID: 6362 RVA: 0x000F561A File Offset: 0x000F381A
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x04002608 RID: 9736
	public DropsScript DropMenu;

	// Token: 0x04002609 RID: 9737
	public Transform DropPoint;

	// Token: 0x0400260A RID: 9738
	public GameObject[] Drops;

	// Token: 0x0400260B RID: 9739
	public int[] ItemsToDrop;

	// Token: 0x0400260C RID: 9740
	public int Orders;

	// Token: 0x0400260D RID: 9741
	public int ID;

	// Token: 0x0400260E RID: 9742
	public float Rotation;

	// Token: 0x0400260F RID: 9743
	public float Timer;

	// Token: 0x04002610 RID: 9744
	public bool Dropped;

	// Token: 0x04002611 RID: 9745
	public bool Drop;

	// Token: 0x04002612 RID: 9746
	public bool Test;

	// Token: 0x04002613 RID: 9747
	public bool Open = true;
}
