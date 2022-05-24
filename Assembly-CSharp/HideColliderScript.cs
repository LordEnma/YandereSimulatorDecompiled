using System;
using UnityEngine;

// Token: 0x02000315 RID: 789
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x06001873 RID: 6259 RVA: 0x000EC6E8 File Offset: 0x000EA8E8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 11)
		{
			GameObject gameObject = other.gameObject.transform.root.gameObject;
			if (!gameObject.GetComponent<StudentScript>().Alive)
			{
				this.Corpse = gameObject.GetComponent<RagdollScript>();
				if (!this.Corpse.Hidden && !this.Corpse.Concealed)
				{
					this.Corpse.HideCollider = this.MyCollider;
					this.Corpse.Police.HiddenCorpses++;
					this.Corpse.Hidden = true;
				}
			}
		}
	}

	// Token: 0x04002462 RID: 9314
	public RagdollScript Corpse;

	// Token: 0x04002463 RID: 9315
	public Collider MyCollider;
}
