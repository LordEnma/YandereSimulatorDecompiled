using System;
using UnityEngine;

// Token: 0x0200044E RID: 1102
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D47 RID: 7495 RVA: 0x0015EF57 File Offset: 0x0015D157
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D48 RID: 7496 RVA: 0x0015EF7C File Offset: 0x0015D17C
	private void Update()
	{
		if (this.StudentManager.DisableFarAnims)
		{
			if (Vector3.Distance(this.Yandere.position, base.transform.position) > 15f)
			{
				if (this.Anim.enabled)
				{
					this.Anim.enabled = false;
					return;
				}
			}
			else if (!this.Anim.enabled)
			{
				this.Anim.enabled = true;
				return;
			}
		}
		else if (!this.Anim.enabled)
		{
			this.Anim.enabled = true;
		}
	}

	// Token: 0x04003572 RID: 13682
	public StudentManagerScript StudentManager;

	// Token: 0x04003573 RID: 13683
	public Transform Yandere;

	// Token: 0x04003574 RID: 13684
	private Animation Anim;
}
