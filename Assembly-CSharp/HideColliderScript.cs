using System;
using UnityEngine;

// Token: 0x02000312 RID: 786
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x0600185A RID: 6234 RVA: 0x000EB44C File Offset: 0x000E964C
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

	// Token: 0x0400242F RID: 9263
	public RagdollScript Corpse;

	// Token: 0x04002430 RID: 9264
	public Collider MyCollider;
}
