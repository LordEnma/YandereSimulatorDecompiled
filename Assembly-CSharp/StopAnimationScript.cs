using System;
using UnityEngine;

// Token: 0x02000450 RID: 1104
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D55 RID: 7509 RVA: 0x00160723 File Offset: 0x0015E923
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D56 RID: 7510 RVA: 0x00160748 File Offset: 0x0015E948
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

	// Token: 0x0400359E RID: 13726
	public StudentManagerScript StudentManager;

	// Token: 0x0400359F RID: 13727
	public Transform Yandere;

	// Token: 0x040035A0 RID: 13728
	private Animation Anim;
}
