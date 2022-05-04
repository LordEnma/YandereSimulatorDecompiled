using System;
using UnityEngine;

// Token: 0x02000377 RID: 887
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019F4 RID: 6644 RVA: 0x0010ADE2 File Offset: 0x00108FE2
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019F5 RID: 6645 RVA: 0x0010AE08 File Offset: 0x00109008
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

	// Token: 0x040029D2 RID: 10706
	public StudentScript MyStudent;

	// Token: 0x040029D3 RID: 10707
	public GameObject BloodEffect;

	// Token: 0x040029D4 RID: 10708
	public string Prefix;

	// Token: 0x040029D5 RID: 10709
	public Collider Nape;
}
