using System;
using UnityEngine;

// Token: 0x02000313 RID: 787
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x06001860 RID: 6240 RVA: 0x000EBA04 File Offset: 0x000E9C04
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

	// Token: 0x04002442 RID: 9282
	public RagdollScript Corpse;

	// Token: 0x04002443 RID: 9283
	public Collider MyCollider;
}
