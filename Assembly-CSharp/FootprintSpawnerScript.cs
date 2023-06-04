using UnityEngine;

public class FootprintSpawnerScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject BloodyFootprint;

	public AudioClip[] WalkFootsteps;

	public AudioClip[] RunFootsteps;

	public AudioClip[] WalkBareFootsteps;

	public AudioClip[] RunBareFootsteps;

	public AudioSource MyAudio;

	public Transform BloodParent;

	public Collider MyCollider;

	public Collider GardenArea;

	public Collider PoolStairs;

	public Collider TreeArea;

	public Collider NEStairs;

	public Collider NWStairs;

	public Collider SEStairs;

	public Collider SWStairs;

	public bool Debugging;

	public bool CanSpawn;

	public bool FootUp;

	public float DownThreshold;

	public float UpThreshold;

	public float Height;

	public int Bloodiness;

	public int Collisions;

	public int StudentBloodID;

	private void Start()
	{
		if (MyAudio == null)
		{
			MyAudio = GetComponent<AudioSource>();
		}
		GardenArea = Yandere.StudentManager.GardenArea;
		PoolStairs = Yandere.StudentManager.PoolStairs;
		TreeArea = Yandere.StudentManager.TreeArea;
		NEStairs = Yandere.StudentManager.NEStairs;
		NWStairs = Yandere.StudentManager.NWStairs;
		SEStairs = Yandere.StudentManager.SEStairs;
		SWStairs = Yandere.StudentManager.SWStairs;
	}

	private void Update()
	{
		if (!FootUp)
		{
			if (base.transform.position.y > Yandere.transform.position.y + UpThreshold)
			{
				FootUp = true;
			}
		}
		else
		{
			if (!(base.transform.position.y < Yandere.transform.position.y + DownThreshold))
			{
				return;
			}
			if (Yandere.Stance.Current != StanceType.Crouching && Yandere.Stance.Current != StanceType.Crawling && Yandere.CanMove && !Yandere.NearSenpai && FootUp)
			{
				if (Yandere.Schoolwear == 0 || Yandere.Schoolwear == 2 || (Yandere.ClubAttire && Yandere.Club == ClubType.MartialArts))
				{
					if (Yandere.Running)
					{
						MyAudio.clip = RunBareFootsteps[Random.Range(0, RunBareFootsteps.Length)];
						MyAudio.volume = 0.3f;
					}
					else
					{
						MyAudio.clip = WalkBareFootsteps[Random.Range(0, WalkBareFootsteps.Length)];
						MyAudio.volume = 0.2f;
					}
				}
				else if (Yandere.Running)
				{
					MyAudio.clip = RunFootsteps[Random.Range(0, RunFootsteps.Length)];
					MyAudio.volume = 0.15f;
				}
				else
				{
					MyAudio.clip = WalkFootsteps[Random.Range(0, WalkFootsteps.Length)];
					MyAudio.volume = 0.1f;
				}
				MyAudio.Play();
			}
			FootUp = false;
			if (Bloodiness > 0)
			{
				CanSpawn = !GardenArea.bounds.Contains(base.transform.position) && !PoolStairs.bounds.Contains(base.transform.position) && !TreeArea.bounds.Contains(base.transform.position) && !NEStairs.bounds.Contains(base.transform.position) && !NWStairs.bounds.Contains(base.transform.position) && !SEStairs.bounds.Contains(base.transform.position) && !SWStairs.bounds.Contains(base.transform.position);
				if (base.transform.position.y > -0.1f && base.transform.position.y < 0.1f)
				{
					Height = 0f;
				}
				else if (base.transform.position.y > 3.9f && base.transform.position.y < 4.1f)
				{
					Height = 4f;
				}
				else if (base.transform.position.y > 7.9f && base.transform.position.y < 8.1f)
				{
					Height = 8f;
				}
				else if (base.transform.position.y > 11.9f && base.transform.position.y < 12.1f)
				{
					Height = 12f;
				}
				else
				{
					CanSpawn = false;
				}
				if (base.transform.position.x > 0f && base.transform.position.y > 0.1f && base.transform.position.z > 58f)
				{
					CanSpawn = false;
				}
				if (CanSpawn)
				{
					Debug.Log("Height is: " + Height);
					GameObject gameObject = Object.Instantiate(BloodyFootprint, new Vector3(base.transform.position.x, Height + 0.013f, base.transform.position.z), Quaternion.identity);
					gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, base.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
					FootprintScript component = gameObject.transform.GetChild(0).GetComponent<FootprintScript>();
					gameObject.transform.parent = BloodParent;
					component.Yandere = Yandere;
					component.StudentBloodID = StudentBloodID;
					Bloodiness--;
				}
			}
		}
	}
}
