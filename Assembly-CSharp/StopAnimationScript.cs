using System;
using UnityEngine;

// Token: 0x0200044D RID: 1101
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D3C RID: 7484 RVA: 0x0015E7BF File Offset: 0x0015C9BF
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D3D RID: 7485 RVA: 0x0015E7E4 File Offset: 0x0015C9E4
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

	// Token: 0x04003563 RID: 13667
	public StudentManagerScript StudentManager;

	// Token: 0x04003564 RID: 13668
	public Transform Yandere;

	// Token: 0x04003565 RID: 13669
	private Animation Anim;
}
