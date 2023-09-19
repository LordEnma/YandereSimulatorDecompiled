using UnityEngine;

public class IronMaidenScript : MonoBehaviour
{
	public GameObject KeepInsideCollider;

	public GameObject ExteriorColliders;

	public GameObject InteriorColliders;

	public GameObject[] Blood;

	public AudioClip FemaleVoice;

	public AudioClip MaleVoice;

	public AudioClip DoorOpen;

	public AudioClip DoorSlam;

	public Transform YandereSpot;

	public Transform VictimSpot;

	public Transform[] Door;

	public RagdollScript Corpse;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public float[] Rotation;

	public float ShakeStrength;

	public float ShoveTimer;

	public int ShovePhase;

	public bool Shut;

	public bool Open;

	public bool ABC;

	private void Start()
	{
		ABC = GameGlobals.AlphabetMode;
	}

	private void Update()
	{
		if (Prompt.Circle[2].fillAmount == 0f)
		{
			Prompt.Circle[2].fillAmount = 1f;
			if (!Shut)
			{
				if (!Prompt.Yandere.Chased && Prompt.Yandere.Chasers == 0)
				{
					if (Prompt.Yandere.Followers > 0 && Prompt.Yandere.Follower.DistanceToPlayer < 1f)
					{
						Prompt.Yandere.Sanity -= (float)((Prompt.Yandere.Panties == 10) ? 10 : 20) * Prompt.Yandere.Numbness;
						Prompt.Yandere.CanMove = false;
						Prompt.Yandere.Follower.CharacterAnimation.CrossFade(Prompt.Yandere.Follower.IdleAnim);
						Prompt.Yandere.Follower.Pathfinding.canSearch = false;
						Prompt.Yandere.Follower.Pathfinding.canMove = false;
						Prompt.Yandere.Follower.enabled = false;
						ExteriorColliders.SetActive(value: false);
						InteriorColliders.SetActive(value: false);
						ShovePhase = 1;
						ShoveTimer = 0f;
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "Bring a victim here first.";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "Bring a victim here first.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			else
			{
				MyAudio.clip = DoorOpen;
				MyAudio.Play();
				Open = true;
				SpitCorpseOut();
			}
		}
		if (ShovePhase > 0)
		{
			if (ShovePhase == 1)
			{
				Prompt.Yandere.MoveTowardsTarget(YandereSpot.position);
				Prompt.Yandere.Follower.MoveTowardsTarget(VictimSpot.position);
				Prompt.Yandere.transform.rotation = Quaternion.Slerp(Prompt.Yandere.transform.rotation, YandereSpot.rotation, Time.deltaTime * 10f);
				Prompt.Yandere.Follower.transform.rotation = Quaternion.Slerp(Prompt.Yandere.Follower.transform.rotation, YandereSpot.rotation, Time.deltaTime * 10f);
				ShoveTimer += Time.deltaTime;
				if (ShoveTimer >= 1f)
				{
					if (Prompt.Yandere.Follower.Male)
					{
						MyAudio.clip = MaleVoice;
					}
					else
					{
						MyAudio.clip = FemaleVoice;
					}
					MyAudio.Play();
					Prompt.Yandere.CharacterAnimation.CrossFade("f02_bookcasePush_00");
					Prompt.Yandere.MurderousActionTimer = 1f;
					if (!Prompt.Yandere.Follower.Male)
					{
						Prompt.Yandere.Follower.CharacterAnimation.CrossFade("f02_roofPushB_00");
					}
					else
					{
						Prompt.Yandere.Follower.CharacterAnimation.CrossFade("roofPushB_00");
					}
					ShoveTimer = 0f;
					ShovePhase++;
				}
			}
			else if (ShovePhase == 2)
			{
				Prompt.Yandere.MoveTowardsTarget(YandereSpot.position);
				Prompt.Yandere.Follower.MoveTowardsTarget(VictimSpot.position);
				Prompt.Yandere.transform.rotation = Quaternion.Slerp(Prompt.Yandere.transform.rotation, YandereSpot.rotation, Time.deltaTime * 10f);
				Prompt.Yandere.Follower.transform.rotation = Quaternion.Slerp(Prompt.Yandere.Follower.transform.rotation, YandereSpot.rotation, Time.deltaTime * 10f);
				ShoveTimer += Time.deltaTime;
				if (ShoveTimer >= 1f)
				{
					MyAudio.clip = DoorSlam;
					MyAudio.Play();
					Prompt.Yandere.CharacterAnimation.CrossFade(Prompt.Yandere.IdleAnim);
					Prompt.Yandere.Follower.CharacterAnimation.CrossFade(Prompt.Yandere.Follower.IdleAnim);
					ShoveTimer = 0f;
					ShovePhase++;
				}
			}
			else if (ShovePhase == 3)
			{
				Prompt.Yandere.MoveTowardsTarget(YandereSpot.position);
				Prompt.Yandere.Follower.MoveTowardsTarget(base.transform.position);
				Rotation[0] = Mathf.MoveTowards(Rotation[0], 0f, Time.deltaTime * 360f);
				Rotation[1] = Mathf.MoveTowards(Rotation[1], 0f, Time.deltaTime * 360f);
				Door[0].transform.localEulerAngles = new Vector3(0f, 6.5f, Rotation[0]);
				Door[1].transform.localEulerAngles = new Vector3(0f, -6.5f, Rotation[1]);
				if (Rotation[0] == 0f)
				{
					KeepInsideCollider.SetActive(value: true);
					Prompt.Label[2].text = "     Open Doors";
					Blood[0].SetActive(value: true);
					Blood[1].SetActive(value: true);
					Blood[2].SetActive(value: true);
					TurnFollowerIntoCorpse();
					Prompt.Yandere.CanMove = true;
					Prompt.Yandere.Zoom.ShakeStrength = 1f;
					ShovePhase = 0;
					ShoveTimer = 0f;
					Shut = true;
				}
			}
		}
		if (Open)
		{
			Rotation[0] = Mathf.Lerp(Rotation[0], -45f, Time.deltaTime);
			Rotation[1] = Mathf.Lerp(Rotation[1], 45f, Time.deltaTime);
			Door[0].transform.localEulerAngles = new Vector3(0f, 6.5f, Rotation[0]);
			Door[1].transform.localEulerAngles = new Vector3(0f, -6.5f, Rotation[1]);
			if (Rotation[0] < -44f)
			{
				Prompt.Label[2].text = "     Push Victim Inside";
				InteriorColliders.SetActive(value: false);
				Open = false;
				Shut = false;
			}
		}
	}

	public void TurnFollowerIntoCorpse()
	{
		Corpse = Prompt.Yandere.Follower.Ragdoll;
		Corpse.Student.BecomeRagdoll();
		Corpse.Student.DeathType = DeathType.Weight;
		Corpse.Student.LiquidProjector.material = Corpse.Student.BloodMaterial;
		Corpse.Student.LiquidProjector.gameObject.SetActive(value: true);
		Corpse.Student.LiquidProjector.enabled = true;
		if (Corpse.AddingToCount)
		{
			Prompt.Yandere.NearBodies--;
			Corpse.AddingToCount = false;
		}
		Prompt.Yandere.NearestCorpseID = 0;
		Prompt.Yandere.CorpseWarning = false;
		Prompt.Yandere.StudentManager.UpdateStudents();
		Corpse.transform.parent = base.transform;
		Corpse.transform.position = base.transform.position + new Vector3(0f, 0f, 0f);
		Corpse.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
		if (Corpse.Police == null)
		{
			Corpse.Police = Corpse.Student.Police;
		}
		Corpse.Police.HiddenCorpses++;
		Corpse.enabled = false;
		Corpse.Hidden = true;
		if (ABC)
		{
			Corpse.DestroyRigidbodies();
		}
		else
		{
			Corpse.BloodSpawnerCollider.enabled = false;
			Corpse.Prompt.MyCollider.enabled = false;
			Corpse.BloodPoolSpawner.enabled = false;
			Corpse.DisableRigidbodies();
		}
		Corpse.Student.CharacterAnimation.enabled = true;
		Corpse.Student.CharacterAnimation.Play("f02_lockerPose_00");
		if (Corpse.Decapitated)
		{
			Corpse.Head.transform.localScale = Vector3.zero;
		}
	}

	public void SpitCorpseOut()
	{
		KeepInsideCollider.SetActive(value: false);
		Corpse.enabled = true;
		Corpse.gameObject.SetActive(value: true);
		Corpse.CharacterAnimation.enabled = false;
		Corpse.transform.position = base.transform.position;
		Corpse.transform.eulerAngles = new Vector3(0f, 180f, 0f);
		Corpse.transform.parent = null;
		Corpse.BloodSpawnerCollider.enabled = true;
		Corpse.Prompt.MyCollider.enabled = true;
		Corpse.BloodPoolSpawner.NearbyBlood = 0;
		Corpse.AddingToCount = false;
		Corpse.EnableRigidbodies();
		if (!Corpse.Cauterized && !Corpse.Concealed)
		{
			Corpse.BloodPoolSpawner.enabled = true;
		}
		for (int i = 0; i < Corpse.Student.FireEmitters.Length; i++)
		{
			Corpse.Student.FireEmitters[i].gameObject.SetActive(value: false);
		}
		Corpse = null;
	}
}
