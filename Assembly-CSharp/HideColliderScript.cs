using System;
using UnityEngine;

// Token: 0x0200030F RID: 783
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x0600183E RID: 6206 RVA: 0x000E9820 File Offset: 0x000E7A20
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

	// Token: 0x040023E5 RID: 9189
	public RagdollScript Corpse;

	// Token: 0x040023E6 RID: 9190
	public Collider MyCollider;
}
