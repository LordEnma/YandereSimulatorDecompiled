using System;
using UnityEngine;

// Token: 0x02000447 RID: 1095
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D0F RID: 7439 RVA: 0x0015AFB3 File Offset: 0x001591B3
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D10 RID: 7440 RVA: 0x0015AFD8 File Offset: 0x001591D8
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

	// Token: 0x040034D5 RID: 13525
	public StudentManagerScript StudentManager;

	// Token: 0x040034D6 RID: 13526
	public Transform Yandere;

	// Token: 0x040034D7 RID: 13527
	private Animation Anim;
}
