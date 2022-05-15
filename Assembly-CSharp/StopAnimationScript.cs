using System;
using UnityEngine;

// Token: 0x02000450 RID: 1104
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D54 RID: 7508 RVA: 0x00160467 File Offset: 0x0015E667
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D55 RID: 7509 RVA: 0x0016048C File Offset: 0x0015E68C
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

	// Token: 0x04003596 RID: 13718
	public StudentManagerScript StudentManager;

	// Token: 0x04003597 RID: 13719
	public Transform Yandere;

	// Token: 0x04003598 RID: 13720
	private Animation Anim;
}
