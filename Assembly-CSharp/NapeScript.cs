using System;
using UnityEngine;

// Token: 0x02000377 RID: 887
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019EC RID: 6636 RVA: 0x0010A652 File Offset: 0x00108852
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019ED RID: 6637 RVA: 0x0010A678 File Offset: 0x00108878
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

	// Token: 0x040029C1 RID: 10689
	public StudentScript MyStudent;

	// Token: 0x040029C2 RID: 10690
	public GameObject BloodEffect;

	// Token: 0x040029C3 RID: 10691
	public string Prefix;

	// Token: 0x040029C4 RID: 10692
	public Collider Nape;
}
