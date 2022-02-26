using System;
using UnityEngine;

// Token: 0x02000449 RID: 1097
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D22 RID: 7458 RVA: 0x0015C443 File Offset: 0x0015A643
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D23 RID: 7459 RVA: 0x0015C468 File Offset: 0x0015A668
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

	// Token: 0x040034F5 RID: 13557
	public StudentManagerScript StudentManager;

	// Token: 0x040034F6 RID: 13558
	public Transform Yandere;

	// Token: 0x040034F7 RID: 13559
	private Animation Anim;
}
