using System;
using UnityEngine;

// Token: 0x02000376 RID: 886
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019E6 RID: 6630 RVA: 0x0010A552 File Offset: 0x00108752
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019E7 RID: 6631 RVA: 0x0010A578 File Offset: 0x00108778
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

	// Token: 0x040029BE RID: 10686
	public StudentScript MyStudent;

	// Token: 0x040029BF RID: 10687
	public GameObject BloodEffect;

	// Token: 0x040029C0 RID: 10688
	public string Prefix;

	// Token: 0x040029C1 RID: 10689
	public Collider Nape;
}
