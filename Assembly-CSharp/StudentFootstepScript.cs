using UnityEngine;

public class StudentFootstepScript : MonoBehaviour
{
	public Transform Character;

	public AudioSource MyAudio;

	public AudioClip[] WalkFootsteps;

	public AudioClip[] RunFootsteps;

	public float DownThreshold = 0.02f;

	public float UpThreshold = 0.025f;

	public bool Debugging;

	public bool Running;

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
			Debug.Log("UpThreshold: " + (Character.position.y + UpThreshold) + " | DownThreshold: " + (Character.position.y + DownThreshold) + " | CurrentHeight: " + base.transform.position.y);
		}
		if (!FootUp)
		{
			if (base.transform.position.y > Character.position.y + UpThreshold)
			{
				FootUp = true;
			}
		}
		else if (base.transform.position.y < Character.position.y + DownThreshold)
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
		if (Running)
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
