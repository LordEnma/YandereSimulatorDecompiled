using UnityEngine;

public class StandScript : MonoBehaviour
{
	public AmplifyMotionEffect MotionBlur;

	public FalconPunchScript FalconPunch;

	public StandPunchScript StandPunch;

	public Transform SummonTransform;

	public GameObject SummonEffect;

	public GameObject StandCamera;

	public YandereScript Yandere;

	public GameObject Stand;

	public Transform[] Hands;

	public int FinishPhase;

	public int Finisher;

	public int Weapons;

	public int Phase;

	public AudioClip SummonSFX;

	public bool ReadyForFinisher;

	public bool SFX;

	private void Start()
	{
		if (GameGlobals.LoveSick)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!Stand.activeInHierarchy)
		{
			if (Weapons == 8 && Yandere.transform.position.y > 11.9f && Input.GetButtonDown("RB") && !MissionModeGlobals.MissionMode && !Yandere.Laughing && Yandere.CanMove)
			{
				Yandere.Jojo();
			}
			return;
		}
		if (Phase == 0)
		{
			if (Stand.GetComponent<Animation>()["StandSummon"].time >= 2f && Stand.GetComponent<Animation>()["StandSummon"].time <= 2.5f)
			{
				if (!SFX)
				{
					AudioSource.PlayClipAtPoint(SummonSFX, base.transform.position);
					SFX = true;
				}
				Object.Instantiate(SummonEffect, SummonTransform.position, Quaternion.identity);
			}
			if (Stand.GetComponent<Animation>()["StandSummon"].time >= Stand.GetComponent<Animation>()["StandSummon"].length)
			{
				Stand.GetComponent<Animation>().CrossFade("StandIdle");
				Phase++;
			}
			return;
		}
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		if (Yandere.CanMove)
		{
			Return();
			if (axis != 0f || axis2 != 0f)
			{
				if (Yandere.Running)
				{
					Stand.GetComponent<Animation>().CrossFade("StandRun");
				}
				else
				{
					Stand.GetComponent<Animation>().CrossFade("StandWalk");
				}
			}
			else
			{
				Stand.GetComponent<Animation>().CrossFade("StandIdle");
			}
		}
		else
		{
			if (!Yandere.RPGCamera.enabled)
			{
				return;
			}
			if (Yandere.Laughing)
			{
				if (Vector3.Distance(Stand.transform.localPosition, new Vector3(0f, 0.2f, -0.4f)) > 0.01f)
				{
					Stand.transform.localPosition = Vector3.Lerp(Stand.transform.localPosition, new Vector3(0f, 0.2f, 0.1f), Time.deltaTime * 10f);
					Stand.transform.localEulerAngles = new Vector3(Mathf.Lerp(Stand.transform.localEulerAngles.x, 22.5f, Time.deltaTime * 10f), Stand.transform.localEulerAngles.y, Stand.transform.localEulerAngles.z);
				}
				Stand.GetComponent<Animation>().CrossFade("StandAttack");
				StandPunch.MyCollider.enabled = true;
				ReadyForFinisher = true;
			}
			else
			{
				if (!ReadyForFinisher)
				{
					return;
				}
				if (Phase == 1)
				{
					GetComponent<AudioSource>().Play();
					Finisher = Random.Range(1, 3);
					Stand.GetComponent<Animation>().CrossFade("StandFinisher" + Finisher);
					Phase++;
				}
				else if (Phase == 2)
				{
					if (Stand.GetComponent<Animation>()["StandFinisher" + Finisher].time >= 0.5f)
					{
						FalconPunch.MyCollider.enabled = true;
						StandPunch.MyCollider.enabled = false;
						Phase++;
					}
				}
				else if (Phase == 3 && (StandPunch.MyCollider.enabled || Stand.GetComponent<Animation>()["StandFinisher" + Finisher].time >= Stand.GetComponent<Animation>()["StandFinisher" + Finisher].length))
				{
					Stand.GetComponent<Animation>().CrossFade("StandIdle");
					FalconPunch.MyCollider.enabled = false;
					ReadyForFinisher = false;
					Yandere.CanMove = true;
					Phase = 1;
				}
			}
		}
	}

	public void Spawn()
	{
		FalconPunch.MyCollider.enabled = false;
		StandPunch.MyCollider.enabled = false;
		StandCamera.SetActive(true);
		MotionBlur.enabled = true;
		Stand.SetActive(true);
	}

	private void Return()
	{
		if (Vector3.Distance(Stand.transform.localPosition, new Vector3(0f, 0f, -0.5f)) > 0.01f)
		{
			Stand.transform.localPosition = Vector3.Lerp(Stand.transform.localPosition, new Vector3(0f, 0f, -0.5f), Time.deltaTime * 10f);
			Stand.transform.localEulerAngles = new Vector3(Mathf.Lerp(Stand.transform.localEulerAngles.x, 0f, Time.deltaTime * 10f), Stand.transform.localEulerAngles.y, Stand.transform.localEulerAngles.z);
		}
	}
}
