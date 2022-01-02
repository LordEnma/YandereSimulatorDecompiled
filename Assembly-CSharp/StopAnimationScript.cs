using System;
using UnityEngine;

// Token: 0x02000444 RID: 1092
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D03 RID: 7427 RVA: 0x00158F8F File Offset: 0x0015718F
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D04 RID: 7428 RVA: 0x00158FB4 File Offset: 0x001571B4
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

	// Token: 0x040034BB RID: 13499
	public StudentManagerScript StudentManager;

	// Token: 0x040034BC RID: 13500
	public Transform Yandere;

	// Token: 0x040034BD RID: 13501
	private Animation Anim;
}
