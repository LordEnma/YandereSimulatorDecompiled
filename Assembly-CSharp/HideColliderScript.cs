using System;
using UnityEngine;

// Token: 0x0200030E RID: 782
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x06001835 RID: 6197 RVA: 0x000E8D7C File Offset: 0x000E6F7C
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

	// Token: 0x040023C1 RID: 9153
	public RagdollScript Corpse;

	// Token: 0x040023C2 RID: 9154
	public Collider MyCollider;
}
