using System;
using UnityEngine;

// Token: 0x0200044F RID: 1103
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D4E RID: 7502 RVA: 0x0015F7E7 File Offset: 0x0015D9E7
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D4F RID: 7503 RVA: 0x0015F80C File Offset: 0x0015DA0C
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

	// Token: 0x04003581 RID: 13697
	public StudentManagerScript StudentManager;

	// Token: 0x04003582 RID: 13698
	public Transform Yandere;

	// Token: 0x04003583 RID: 13699
	private Animation Anim;
}
