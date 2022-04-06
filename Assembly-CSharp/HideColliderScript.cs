using System;
using UnityEngine;

// Token: 0x02000314 RID: 788
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x06001866 RID: 6246 RVA: 0x000EBB04 File Offset: 0x000E9D04
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

	// Token: 0x04002445 RID: 9285
	public RagdollScript Corpse;

	// Token: 0x04002446 RID: 9286
	public Collider MyCollider;
}
