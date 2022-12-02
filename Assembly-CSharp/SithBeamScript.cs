using UnityEngine;

public class SithBeamScript : MonoBehaviour
{
	public GameObject BloodEffect;

	public Collider MyCollider;

	public float Damage = 10f;

	public float Lifespan;

	public int RandomNumber;

	public AudioClip Hit;

	public AudioClip[] FemalePain;

	public AudioClip[] MalePain;

	public bool Projectile;

	private void Update()
	{
		if (Projectile)
		{
			base.transform.Translate(base.transform.forward * Time.deltaTime * 15f, Space.World);
		}
		Lifespan = Mathf.MoveTowards(Lifespan, 0f, Time.deltaTime);
		if (Lifespan == 0f)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer != 9)
		{
			return;
		}
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (!(component != null) || component.StudentID <= 1)
		{
			return;
		}
		AudioSource.PlayClipAtPoint(Hit, base.transform.position);
		RandomNumber = Random.Range(0, 3);
		if (MalePain.Length != 0)
		{
			if (component.Male)
			{
				AudioSource.PlayClipAtPoint(MalePain[RandomNumber], base.transform.position);
			}
			else
			{
				AudioSource.PlayClipAtPoint(FemalePain[RandomNumber], base.transform.position);
			}
		}
		Object.Instantiate(BloodEffect, component.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
		component.Health -= Damage;
		component.HealthBar.transform.parent.gameObject.SetActive(true);
		component.HealthBar.transform.localScale = new Vector3(component.Health / 100f, 1f, 1f);
		component.Character.transform.localScale = new Vector3(component.Character.transform.localScale.x * -1f, component.Character.transform.localScale.y, component.Character.transform.localScale.z);
		if (component.Health <= 0f)
		{
			component.DeathType = DeathType.EasterEgg;
			component.HealthBar.transform.parent.gameObject.SetActive(false);
			component.BecomeRagdoll();
			component.Ragdoll.AllRigidbodies[0].isKinematic = false;
		}
		else
		{
			component.CharacterAnimation[component.SithReactAnim].time = 0f;
			component.CharacterAnimation.Play(component.SithReactAnim);
			component.Pathfinding.canSearch = false;
			component.Pathfinding.canMove = false;
			component.HitReacting = true;
			component.Routine = false;
			component.Fleeing = false;
		}
		if (Projectile)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
