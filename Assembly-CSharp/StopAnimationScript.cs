using System;
using UnityEngine;

// Token: 0x02000446 RID: 1094
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D0D RID: 7437 RVA: 0x0015981B File Offset: 0x00157A1B
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D0E RID: 7438 RVA: 0x00159840 File Offset: 0x00157A40
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

	// Token: 0x040034CF RID: 13519
	public StudentManagerScript StudentManager;

	// Token: 0x040034D0 RID: 13520
	public Transform Yandere;

	// Token: 0x040034D1 RID: 13521
	private Animation Anim;
}
