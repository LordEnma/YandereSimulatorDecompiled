using System;
using UnityEngine;

// Token: 0x02000314 RID: 788
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x0600186A RID: 6250 RVA: 0x000EBDA4 File Offset: 0x000E9FA4
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

	// Token: 0x0400244D RID: 9293
	public RagdollScript Corpse;

	// Token: 0x0400244E RID: 9294
	public Collider MyCollider;
}
