using UnityEngine;

public class NapeScript : MonoBehaviour
{
	public StudentScript MyStudent;

	public GameObject BloodEffect;

	public string Prefix;

	public Collider Nape;

	private void Start()
	{
		Nape.enabled = true;
		Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "0")
		{
			MyStudent.CharacterAnimation[Prefix + "down_22"].speed = 0.1f;
			MyStudent.CharacterAnimation.CrossFade(Prefix + "down_22", 1f);
			MyStudent.Pathfinding.canSearch = false;
			MyStudent.Pathfinding.canMove = false;
			MyStudent.Routine = false;
			MyStudent.DeathType = DeathType.Weapon;
			MyStudent.Yandere.Bloodiness += 20f;
			BloodEffect.SetActive(true);
			Nape.enabled = false;
			base.enabled = false;
		}
	}
}
