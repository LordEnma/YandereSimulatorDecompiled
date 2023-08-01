using UnityEngine;

public class FootstepScript : MonoBehaviour
{
	public StalkerYandereScript StalkerYandere;

	public HomeYandereScript HomeYandere;

	public Transform Yandere;

	public AudioSource MyAudio;

	public AudioClip[] WalkFootsteps;

	public AudioClip[] RunFootsteps;

	public float DownThreshold = 0.02f;

	public float UpThreshold = 0.025f;

	public bool Debugging;

	public bool FootUp;

	public LayerMask GroundMask;

	public Vector3 RayOffset = new Vector3(0f, 0.25f, 0f);

	public FloorSoundInformation Default;

	private void Start()
	{
		GroundMask = 256;
	}

	private void Update()
	{
		if (Debugging)
		{
			Debug.Log("UpThreshold: " + (Yandere.position.y + UpThreshold) + " | DownThreshold: " + (Yandere.position.y + DownThreshold) + " | CurrentHeight: " + base.transform.position.y);
		}
		if (!FootUp)
		{
			if (base.transform.position.y > Yandere.position.y + UpThreshold)
			{
				FootUp = true;
			}
		}
		else if (base.transform.position.y < Yandere.position.y + DownThreshold)
		{
			if (FootUp)
			{
				FindFloorSound();
				MyAudio.Play();
			}
			FootUp = false;
		}
	}

	private void FindFloorSound()
	{
		Transform obj = base.transform;
		if (!Physics.Raycast(direction: obj.TransformDirection(Vector3.up * -1f), origin: obj.position + RayOffset, hitInfo: out var hitInfo, maxDistance: 1.1f, layerMask: GroundMask))
		{
			PlaySound(Default);
			return;
		}
		FloorSoundScript component = hitInfo.transform.GetComponent<FloorSoundScript>();
		if (component == null)
		{
			PlaySound(Default);
		}
		else
		{
			PlaySound(component.Sound);
		}
	}

	private void PlaySound(FloorSoundInformation sound)
	{
		bool flag = false;
		if ((!(HomeYandere != null)) ? StalkerYandere.Running : HomeYandere.Running)
		{
			MyAudio.clip = sound.Run[Random.Range(0, sound.Run.Length)];
			MyAudio.volume = sound.RunVolume;
		}
		else
		{
			MyAudio.clip = sound.Walk[Random.Range(0, sound.Walk.Length)];
			MyAudio.volume = sound.WalkVolume;
		}
		MyAudio.Play();
	}
}
