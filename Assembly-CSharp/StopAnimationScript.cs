using System;
using UnityEngine;

// Token: 0x02000449 RID: 1097
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D24 RID: 7460 RVA: 0x0015C9C7 File Offset: 0x0015ABC7
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D25 RID: 7461 RVA: 0x0015C9EC File Offset: 0x0015ABEC
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

	// Token: 0x0400350B RID: 13579
	public StudentManagerScript StudentManager;

	// Token: 0x0400350C RID: 13580
	public Transform Yandere;

	// Token: 0x0400350D RID: 13581
	private Animation Anim;
}
