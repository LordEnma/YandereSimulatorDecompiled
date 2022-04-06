using System;
using UnityEngine;

// Token: 0x0200044E RID: 1102
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D43 RID: 7491 RVA: 0x0015EACB File Offset: 0x0015CCCB
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D44 RID: 7492 RVA: 0x0015EAF0 File Offset: 0x0015CCF0
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

	// Token: 0x04003566 RID: 13670
	public StudentManagerScript StudentManager;

	// Token: 0x04003567 RID: 13671
	public Transform Yandere;

	// Token: 0x04003568 RID: 13672
	private Animation Anim;
}
