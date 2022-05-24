using System;
using UnityEngine;

// Token: 0x02000336 RID: 822
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018F8 RID: 6392 RVA: 0x000F71C4 File Offset: 0x000F53C4
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

	// Token: 0x060018F9 RID: 6393 RVA: 0x000F7332 File Offset: 0x000F5532
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x04002669 RID: 9833
	public DropsScript DropMenu;

	// Token: 0x0400266A RID: 9834
	public Transform DropPoint;

	// Token: 0x0400266B RID: 9835
	public GameObject[] Drops;

	// Token: 0x0400266C RID: 9836
	public int[] ItemsToDrop;

	// Token: 0x0400266D RID: 9837
	public int Orders;

	// Token: 0x0400266E RID: 9838
	public int ID;

	// Token: 0x0400266F RID: 9839
	public float Rotation;

	// Token: 0x04002670 RID: 9840
	public float Timer;

	// Token: 0x04002671 RID: 9841
	public bool Dropped;

	// Token: 0x04002672 RID: 9842
	public bool Drop;

	// Token: 0x04002673 RID: 9843
	public bool Test;

	// Token: 0x04002674 RID: 9844
	public bool Open = true;
}
