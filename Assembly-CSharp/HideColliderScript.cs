using System;
using UnityEngine;

// Token: 0x0200030F RID: 783
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x0600183C RID: 6204 RVA: 0x000E953C File Offset: 0x000E773C
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

	// Token: 0x040023E1 RID: 9185
	public RagdollScript Corpse;

	// Token: 0x040023E2 RID: 9186
	public Collider MyCollider;
}
