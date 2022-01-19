using System;
using UnityEngine;

// Token: 0x02000373 RID: 883
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019C5 RID: 6597 RVA: 0x00107F36 File Offset: 0x00106136
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019C6 RID: 6598 RVA: 0x00107F5C File Offset: 0x0010615C
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

	// Token: 0x04002954 RID: 10580
	public StudentScript MyStudent;

	// Token: 0x04002955 RID: 10581
	public GameObject BloodEffect;

	// Token: 0x04002956 RID: 10582
	public string Prefix;

	// Token: 0x04002957 RID: 10583
	public Collider Nape;
}
