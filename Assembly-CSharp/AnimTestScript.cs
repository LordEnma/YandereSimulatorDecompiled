using System;
using UnityEngine;

// Token: 0x020000C8 RID: 200
public class AnimTestScript : MonoBehaviour
{
	// Token: 0x060009B7 RID: 2487 RVA: 0x0005118D File Offset: 0x0004F38D
	private void Start()
	{
		Time.timeScale = 1f;
	}

	// Token: 0x060009B8 RID: 2488 RVA: 0x0005119C File Offset: 0x0004F39C
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			if (this.ID > 4)
			{
				this.ID = 1;
			}
		}
		if (this.ID == 1)
		{
			this.CharacterB.transform.eulerAngles = new Vector3(0f, -90f, 0f);
			this.CharacterA.Play("f02_weightHighSanityA_00");
			this.CharacterB.Play("f02_weightHighSanityB_00");
			return;
		}
		if (this.ID == 2)
		{
			this.CharacterA.Play("f02_weightMedSanityA_00");
			this.CharacterB.Play("f02_weightMedSanityB_00");
			return;
		}
		if (this.ID == 3)
		{
			this.CharacterA.Play("f02_weightLowSanityA_00");
			this.CharacterB.Play("f02_weightLowSanityB_00");
			return;
		}
		if (this.ID == 4)
		{
			this.CharacterB.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			this.CharacterA.Play("f02_weightStealthA_00");
			this.CharacterB.Play("f02_weightStealthB_00");
		}
	}

	// Token: 0x04000A17 RID: 2583
	public Animation CharacterA;

	// Token: 0x04000A18 RID: 2584
	public Animation CharacterB;

	// Token: 0x04000A19 RID: 2585
	public int ID;
}
