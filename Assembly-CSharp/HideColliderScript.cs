using System;
using UnityEngine;

// Token: 0x02000312 RID: 786
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x06001855 RID: 6229 RVA: 0x000EAF8C File Offset: 0x000E918C
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

	// Token: 0x0400241E RID: 9246
	public RagdollScript Corpse;

	// Token: 0x0400241F RID: 9247
	public Collider MyCollider;
}
