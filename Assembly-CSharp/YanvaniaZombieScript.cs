using UnityEngine;

public class YanvaniaZombieScript : MonoBehaviour
{
	public GameObject ZombieEffect;

	public GameObject BloodEffect;

	public GameObject DeathEffect;

	public GameObject HitEffect;

	public GameObject Character;

	public YanvaniaYanmontScript Yanmont;

	public int HP;

	public float WalkSpeed1;

	public float WalkSpeed2;

	public float Damage;

	public float HitReactTimer;

	public float DeathTimer;

	public float WalkTimer;

	public float Timer;

	public int HitReactState;

	public int WalkType;

	public float LeftBoundary;

	public float RightBoundary;

	public bool EffectSpawned;

	public bool Dying;

	public bool Sink;

	public bool Walk;

	public Texture[] Textures;

	public Renderer MyRenderer;

	public Collider MyCollider;

	public AudioClip DeathSound;

	public AudioClip HitSound;

	public AudioClip RisingSound;

	public AudioClip SinkingSound;

	private void Start()
	{
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, (Yanmont.transform.position.x > base.transform.position.x) ? 90f : (-90f), base.transform.eulerAngles.z);
		Object.Instantiate(ZombieEffect, base.transform.position, Quaternion.identity);
		base.transform.position = new Vector3(base.transform.position.x, -0.63f, base.transform.position.z);
		Animation component = Character.GetComponent<Animation>();
		component["getup1"].speed = 2f;
		component.Play("getup1");
		GetComponent<AudioSource>().PlayOneShot(RisingSound);
		MyRenderer.material.mainTexture = Textures[Random.Range(0, 22)];
		MyCollider.enabled = false;
	}

	private void Update()
	{
		AudioSource component = GetComponent<AudioSource>();
		if (Dying)
		{
			DeathTimer += Time.deltaTime;
			if (DeathTimer > 1f)
			{
				if (!EffectSpawned)
				{
					Object.Instantiate(ZombieEffect, base.transform.position, Quaternion.identity);
					component.PlayOneShot(SinkingSound);
					EffectSpawned = true;
				}
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - Time.deltaTime, base.transform.position.z);
				if (base.transform.position.y < -0.4f)
				{
					Object.Destroy(base.gameObject);
				}
			}
		}
		else
		{
			Animation component2 = Character.GetComponent<Animation>();
			if (Sink)
			{
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - Time.deltaTime * 0.74f, base.transform.position.z);
				if (base.transform.position.y < -0.63f)
				{
					Object.Destroy(base.gameObject);
				}
			}
			else if (Walk)
			{
				WalkTimer += Time.deltaTime;
				if (WalkType == 1)
				{
					base.transform.Translate(Vector3.forward * Time.deltaTime * WalkSpeed1);
					component2.CrossFade("walk1");
				}
				else
				{
					base.transform.Translate(Vector3.forward * Time.deltaTime * WalkSpeed2);
					component2.CrossFade("walk2");
				}
				if (WalkTimer > 10f)
				{
					SinkNow();
				}
			}
			else
			{
				Timer += Time.deltaTime;
				if (base.transform.position.y < 0f)
				{
					base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime * 0.74f, base.transform.position.z);
					if (base.transform.position.y > 0f)
					{
						base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
					}
				}
				if (Timer > 0.85f)
				{
					Walk = true;
					MyCollider.enabled = true;
					WalkType = Random.Range(1, 3);
				}
			}
			if (base.transform.position.x < LeftBoundary)
			{
				base.transform.position = new Vector3(LeftBoundary, base.transform.position.y, base.transform.position.z);
				SinkNow();
			}
			if (base.transform.position.x > RightBoundary)
			{
				base.transform.position = new Vector3(RightBoundary, base.transform.position.y, base.transform.position.z);
				SinkNow();
			}
			if (HP <= 0)
			{
				Object.Instantiate(DeathEffect, new Vector3(base.transform.position.x, base.transform.position.y + 1f, base.transform.position.z), Quaternion.identity);
				component2.Play("die");
				component.PlayOneShot(DeathSound);
				MyCollider.enabled = false;
				Yanmont.EXP += 10f;
				Dying = true;
			}
		}
		if (HitReactTimer < 1f)
		{
			MyRenderer.material.color = new Color(1f, HitReactTimer, HitReactTimer, 1f);
			HitReactTimer += Time.deltaTime * 10f;
			if (HitReactTimer >= 1f)
			{
				MyRenderer.material.color = new Color(1f, 1f, 1f, 1f);
			}
		}
	}

	private void SinkNow()
	{
		Animation component = Character.GetComponent<Animation>();
		component["getup1"].time = component["getup1"].length;
		component["getup1"].speed = -2f;
		component.Play("getup1");
		GetComponent<AudioSource>().PlayOneShot(SinkingSound);
		Object.Instantiate(ZombieEffect, base.transform.position, Quaternion.identity);
		MyCollider.enabled = false;
		Sink = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!Dying)
		{
			if (other.gameObject.tag == "Player")
			{
				Yanmont.TakeDamage(5);
			}
			if (other.gameObject.name == "Heart" && HitReactTimer >= 1f)
			{
				Object.Instantiate(HitEffect, other.transform.position, Quaternion.identity);
				GetComponent<AudioSource>().PlayOneShot(HitSound);
				HitReactTimer = 0f;
				HP -= 20 + (Yanmont.Level * 5 - 5);
			}
		}
	}
}
