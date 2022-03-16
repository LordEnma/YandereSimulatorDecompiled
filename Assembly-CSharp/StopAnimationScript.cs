using System;
using UnityEngine;

// Token: 0x0200044A RID: 1098
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D32 RID: 7474 RVA: 0x0015DB77 File Offset: 0x0015BD77
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D33 RID: 7475 RVA: 0x0015DB9C File Offset: 0x0015BD9C
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

	// Token: 0x04003546 RID: 13638
	public StudentManagerScript StudentManager;

	// Token: 0x04003547 RID: 13639
	public Transform Yandere;

	// Token: 0x04003548 RID: 13640
	private Animation Anim;
}
