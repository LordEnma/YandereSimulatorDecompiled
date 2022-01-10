using System;
using UnityEngine;

// Token: 0x02000310 RID: 784
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x06001842 RID: 6210 RVA: 0x000E9B58 File Offset: 0x000E7D58
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

	// Token: 0x040023E9 RID: 9193
	public RagdollScript Corpse;

	// Token: 0x040023EA RID: 9194
	public Collider MyCollider;
}
