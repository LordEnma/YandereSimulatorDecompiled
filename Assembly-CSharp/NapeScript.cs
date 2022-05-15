using System;
using UnityEngine;

// Token: 0x02000378 RID: 888
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019FA RID: 6650 RVA: 0x0010B662 File Offset: 0x00109862
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019FB RID: 6651 RVA: 0x0010B688 File Offset: 0x00109888
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

	// Token: 0x040029E4 RID: 10724
	public StudentScript MyStudent;

	// Token: 0x040029E5 RID: 10725
	public GameObject BloodEffect;

	// Token: 0x040029E6 RID: 10726
	public string Prefix;

	// Token: 0x040029E7 RID: 10727
	public Collider Nape;
}
