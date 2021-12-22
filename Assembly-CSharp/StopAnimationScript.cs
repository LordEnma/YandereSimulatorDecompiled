using System;
using UnityEngine;

// Token: 0x02000444 RID: 1092
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D01 RID: 7425 RVA: 0x00158B4B File Offset: 0x00156D4B
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D02 RID: 7426 RVA: 0x00158B70 File Offset: 0x00156D70
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

	// Token: 0x040034B4 RID: 13492
	public StudentManagerScript StudentManager;

	// Token: 0x040034B5 RID: 13493
	public Transform Yandere;

	// Token: 0x040034B6 RID: 13494
	private Animation Anim;
}
