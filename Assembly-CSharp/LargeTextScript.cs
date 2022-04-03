using System;
using UnityEngine;

// Token: 0x02000509 RID: 1289
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x06002156 RID: 8534 RVA: 0x001EADBF File Offset: 0x001E8FBF
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x06002157 RID: 8535 RVA: 0x001EADD9 File Offset: 0x001E8FD9
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x0400497D RID: 18813
	public UILabel Label;

	// Token: 0x0400497E RID: 18814
	public string[] String;

	// Token: 0x0400497F RID: 18815
	public int ID;
}
