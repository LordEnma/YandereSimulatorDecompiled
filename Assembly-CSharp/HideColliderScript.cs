using System;
using UnityEngine;

// Token: 0x02000314 RID: 788
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x0600186E RID: 6254 RVA: 0x000EC26C File Offset: 0x000EA46C
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

	// Token: 0x04002456 RID: 9302
	public RagdollScript Corpse;

	// Token: 0x04002457 RID: 9303
	public Collider MyCollider;
}
