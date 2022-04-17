using System;
using UnityEngine;

// Token: 0x02000377 RID: 887
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019F0 RID: 6640 RVA: 0x0010A916 File Offset: 0x00108B16
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019F1 RID: 6641 RVA: 0x0010A93C File Offset: 0x00108B3C
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "0")
		{
			this.MyStudent.CharacterAnimation[this.Prefix + "down_22"].speed = 0.1f;
			this.MyStudent.CharacterAnimation.CrossFade(this.Prefix + "down_22", 1f);
			this.MyStudent.Pathfinding.canSearch = false;
			this.MyStudent.Pathfinding.canMove = false;
			this.MyStudent.Routine = false;
			this.MyStudent.DeathType = DeathType.Weapon;
			this.MyStudent.Yandere.Bloodiness += 20f;
			this.BloodEffect.SetActive(true);
			this.Nape.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x040029C9 RID: 10697
	public StudentScript MyStudent;

	// Token: 0x040029CA RID: 10698
	public GameObject BloodEffect;

	// Token: 0x040029CB RID: 10699
	public string Prefix;

	// Token: 0x040029CC RID: 10700
	public Collider Nape;
}
