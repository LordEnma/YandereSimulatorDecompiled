using System;
using UnityEngine;

// Token: 0x02000311 RID: 785
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x0600184C RID: 6220 RVA: 0x000EA378 File Offset: 0x000E8578
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

	// Token: 0x040023FB RID: 9211
	public RagdollScript Corpse;

	// Token: 0x040023FC RID: 9212
	public Collider MyCollider;
}
