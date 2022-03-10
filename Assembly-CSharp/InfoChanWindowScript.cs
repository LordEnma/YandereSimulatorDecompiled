using System;
using UnityEngine;

// Token: 0x02000333 RID: 819
public class InfoChanWindowScript : MonoBehaviour
{
	// Token: 0x060018D9 RID: 6361 RVA: 0x000F57EC File Offset: 0x000F39EC
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

	// Token: 0x060018DA RID: 6362 RVA: 0x000F595A File Offset: 0x000F3B5A
	public void DropObject()
	{
		this.Rotation = 0f;
		this.Timer = 0f;
		this.Dropped = false;
		this.Test = false;
		this.Drop = true;
		this.Open = true;
	}

	// Token: 0x0400261D RID: 9757
	public DropsScript DropMenu;

	// Token: 0x0400261E RID: 9758
	public Transform DropPoint;

	// Token: 0x0400261F RID: 9759
	public GameObject[] Drops;

	// Token: 0x04002620 RID: 9760
	public int[] ItemsToDrop;

	// Token: 0x04002621 RID: 9761
	public int Orders;

	// Token: 0x04002622 RID: 9762
	public int ID;

	// Token: 0x04002623 RID: 9763
	public float Rotation;

	// Token: 0x04002624 RID: 9764
	public float Timer;

	// Token: 0x04002625 RID: 9765
	public bool Dropped;

	// Token: 0x04002626 RID: 9766
	public bool Drop;

	// Token: 0x04002627 RID: 9767
	public bool Test;

	// Token: 0x04002628 RID: 9768
	public bool Open = true;
}
