using System;
using UnityEngine;

// Token: 0x02000375 RID: 885
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019E0 RID: 6624 RVA: 0x00109E96 File Offset: 0x00108096
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019E1 RID: 6625 RVA: 0x00109EBC File Offset: 0x001080BC
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

	// Token: 0x040029AB RID: 10667
	public StudentScript MyStudent;

	// Token: 0x040029AC RID: 10668
	public GameObject BloodEffect;

	// Token: 0x040029AD RID: 10669
	public string Prefix;

	// Token: 0x040029AE RID: 10670
	public Collider Nape;
}
