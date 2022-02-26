using System;
using UnityEngine;

// Token: 0x02000312 RID: 786
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x06001855 RID: 6229 RVA: 0x000EAC5C File Offset: 0x000E8E5C
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

	// Token: 0x0400240A RID: 9226
	public RagdollScript Corpse;

	// Token: 0x0400240B RID: 9227
	public Collider MyCollider;
}
