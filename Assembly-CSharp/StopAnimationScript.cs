using System;
using UnityEngine;

// Token: 0x02000443 RID: 1091
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001CF9 RID: 7417 RVA: 0x00158227 File Offset: 0x00156427
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001CFA RID: 7418 RVA: 0x0015824C File Offset: 0x0015644C
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

	// Token: 0x04003489 RID: 13449
	public StudentManagerScript StudentManager;

	// Token: 0x0400348A RID: 13450
	public Transform Yandere;

	// Token: 0x0400348B RID: 13451
	private Animation Anim;
}
