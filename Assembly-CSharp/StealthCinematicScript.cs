using UnityEngine;

public class StealthCinematicScript : MonoBehaviour
{
	public StalkerYandereScript Yandere;

	public Transform FollowTarget;

	public Transform LookAtTarget;

	public Transform[] CardboardTargets;

	public float[] CardboardTimes;

	public Transform[] OfficeTargets;

	public float[] OfficeTimes;

	public Transform[] ConstructTargets;

	public float[] ConstructTimes;

	public Transform[] Target;

	public float[] Times;

	public bool ConstructionSiteJump;

	public bool OfficeBuildingJump;

	public bool CardboardClimb;

	public float Timer;

	public int Phase;

	private void Start()
	{
		Yandere.MyAnimation.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	private void Update()
	{
		if (Timer == 0f && Phase == 0)
		{
			base.transform.position = Target[0].position;
			base.transform.eulerAngles = Target[0].eulerAngles;
			LookAtTarget.transform.position = FollowTarget.transform.position;
		}
		Timer += Time.deltaTime;
		if (ConstructionSiteJump)
		{
			if (Timer >= Times[Phase])
			{
				Phase++;
				Timer = 0f;
				base.transform.position = Target[Phase].position;
				base.transform.eulerAngles = Target[Phase].eulerAngles;
				if (Phase == 1)
				{
					Yandere.transform.position = new Vector3(27.5f, 10.41f, -4.5f);
					Yandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
					Physics.SyncTransforms();
					Yandere.MyAnimation["f02_runAndJump_01"].time = 3f;
					Yandere.MyAnimation.Play("f02_runAndJump_01");
					Yandere.MyAnimation["f02_runAndJump_01"].time = 3f;
				}
			}
			LookAtTarget.transform.position = Vector3.Lerp(LookAtTarget.transform.position, FollowTarget.transform.position, Time.deltaTime * 2f);
			base.transform.LookAt(LookAtTarget);
			if (Phase == 0)
			{
				Yandere.transform.position -= new Vector3(Time.deltaTime * 5f, 0f, 0f);
			}
			if (Yandere.MyAnimation["f02_runAndJump_01"].time >= Yandere.MyAnimation["f02_runAndJump_01"].length)
			{
				Yandere.transform.position = new Vector3(9f, 8.27f, -4.5f);
				Yandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
				Physics.SyncTransforms();
				Yandere.MyAnimation.Play("f02_idleShort_00");
				Yandere.MyAnimation.CrossFade(Yandere.IdleAnim);
				Yandere.RPGCamera.enabled = true;
				Yandere.CanMove = true;
				base.enabled = false;
				Phase = 0;
				Timer = 0f;
			}
		}
		else if (OfficeBuildingJump)
		{
			if (Timer >= Times[Phase])
			{
				Phase++;
				Timer = 0f;
				base.transform.position = Target[Phase].position;
				base.transform.eulerAngles = Target[Phase].eulerAngles;
			}
			LookAtTarget.transform.position = Vector3.Lerp(LookAtTarget.transform.position, FollowTarget.transform.position, Time.deltaTime * 2f);
			base.transform.LookAt(LookAtTarget);
			if (Yandere.MyAnimation["f02_longJump_01"].time >= Yandere.MyAnimation["f02_longJump_01"].length)
			{
				Yandere.transform.position = new Vector3(-0.475f, 4.2625f, 11.5f);
				Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				Physics.SyncTransforms();
				Yandere.MyAnimation.Play("f02_idleShort_00");
				Yandere.MyAnimation.CrossFade(Yandere.IdleAnim);
				Yandere.RPGCamera.enabled = true;
				Yandere.CanMove = true;
				base.enabled = false;
				Phase = 0;
				Timer = 0f;
			}
		}
		else if (CardboardClimb && Yandere.MyAnimation["f02_climbTrellis_00"].time >= Yandere.MyAnimation["f02_climbTrellis_00"].length)
		{
			Yandere.transform.position = new Vector3(2f, 4.263044f, 10.86128f);
			Yandere.transform.eulerAngles = new Vector3(0f, -90f, 0f);
			Physics.SyncTransforms();
			Yandere.MyAnimation.Play("f02_idleShort_00");
			Yandere.MyAnimation.CrossFade(Yandere.IdleAnim);
			Yandere.MyController.enabled = true;
			Yandere.RPGCamera.enabled = true;
			Yandere.CanMove = true;
			base.enabled = false;
			Phase = 0;
			Timer = 0f;
		}
	}
}
