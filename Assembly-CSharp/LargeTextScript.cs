using System;
using UnityEngine;

// Token: 0x0200050C RID: 1292
public class LargeTextScript : MonoBehaviour
{
	// Token: 0x0600217A RID: 8570 RVA: 0x001EEE8B File Offset: 0x001ED08B
	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	// Token: 0x0600217B RID: 8571 RVA: 0x001EEEA5 File Offset: 0x001ED0A5
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}

	// Token: 0x040049D9 RID: 18905
	public UILabel Label;

	// Token: 0x040049DA RID: 18906
	public string[] String;

	// Token: 0x040049DB RID: 18907
	public int ID;
}
