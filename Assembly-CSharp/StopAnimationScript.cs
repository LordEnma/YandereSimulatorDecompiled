using System;
using UnityEngine;

// Token: 0x02000448 RID: 1096
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D19 RID: 7449 RVA: 0x0015B997 File Offset: 0x00159B97
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D1A RID: 7450 RVA: 0x0015B9BC File Offset: 0x00159BBC
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

	// Token: 0x040034E5 RID: 13541
	public StudentManagerScript StudentManager;

	// Token: 0x040034E6 RID: 13542
	public Transform Yandere;

	// Token: 0x040034E7 RID: 13543
	private Animation Anim;
}
