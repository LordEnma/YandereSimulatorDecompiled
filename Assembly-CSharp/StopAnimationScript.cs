using System;
using UnityEngine;

// Token: 0x02000447 RID: 1095
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D12 RID: 7442 RVA: 0x0015B68F File Offset: 0x0015988F
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D13 RID: 7443 RVA: 0x0015B6B4 File Offset: 0x001598B4
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

	// Token: 0x040034DF RID: 13535
	public StudentManagerScript StudentManager;

	// Token: 0x040034E0 RID: 13536
	public Transform Yandere;

	// Token: 0x040034E1 RID: 13537
	private Animation Anim;
}
