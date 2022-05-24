using System;
using UnityEngine;

// Token: 0x02000378 RID: 888
public class NapeScript : MonoBehaviour
{
	// Token: 0x060019FB RID: 6651 RVA: 0x0010B866 File Offset: 0x00109A66
	private void Start()
	{
		this.Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	// Token: 0x060019FC RID: 6652 RVA: 0x0010B88C File Offset: 0x00109A8C
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

	// Token: 0x040029EB RID: 10731
	public StudentScript MyStudent;

	// Token: 0x040029EC RID: 10732
	public GameObject BloodEffect;

	// Token: 0x040029ED RID: 10733
	public string Prefix;

	// Token: 0x040029EE RID: 10734
	public Collider Nape;
}
