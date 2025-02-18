using UnityEngine;

public class AnimTestScript1 : MonoBehaviour
{
	public GameObject Explosion;

	public GameObject Blood;

	public GameObject Heart;

	public Animation TargetAnim;

	public Animation MyAnim;

	public Transform TargetHead;

	public Transform TargetNeck;

	public Transform MyHand;

	public Transform MyHead;

	public Transform EyeL;

	public Transform EyeR;

	public float RotationSpeed;

	public float HeadRotation;

	public float EyeRotation;

	public float AnimWeight;

	public float AnimTime;

	public float Speed;

	public int ImpalePhase;

	public bool Impale;

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			TargetAnim["f02_idle_00"].time = 0f;
			MyAnim["f02_idle_00"].time = 0f;
			TargetAnim.Play("f02_idle_00");
			MyAnim.Play("f02_idle_00");
			TargetAnim["f02_snapImpaleB_00"].layer = 1;
			MyAnim["f02_snapImpaleA_00"].layer = 1;
			TargetAnim["f02_snapImpaleB_00"].speed = 0f;
			MyAnim["f02_snapImpaleA_00"].speed = 0f;
			TargetAnim["f02_snapImpaleB_00"].time = 0f;
			MyAnim["f02_snapImpaleA_00"].time = 0f;
			TargetAnim["f02_snapImpaleB_00"].weight = 0f;
			MyAnim["f02_snapImpaleA_00"].weight = 0f;
			TargetAnim.CrossFade("f02_snapImpaleB_00");
			MyAnim.CrossFade("f02_snapImpaleA_00");
			MyHead.localScale = new Vector3(1f, 1f, 1f);
			Heart.SetActive(value: false);
			RotationSpeed = 0f;
			HeadRotation = 0f;
			EyeRotation = 0f;
			ImpalePhase = 0;
			AnimWeight = 0f;
			AnimTime = 0f;
			Speed = 0f;
			Impale = true;
		}
		if (!Impale)
		{
			return;
		}
		if (ImpalePhase == 0)
		{
			Speed += Time.deltaTime;
			AnimWeight = Mathf.Lerp(AnimWeight, 1f, Time.deltaTime * Speed);
			TargetAnim["f02_snapImpaleB_00"].weight = AnimWeight;
			MyAnim["f02_snapImpaleA_00"].weight = AnimWeight;
			if (AnimWeight > 0.99f)
			{
				ImpalePhase++;
				Speed = 0f;
			}
		}
		else if (ImpalePhase == 1)
		{
			Speed += Time.deltaTime * 2f;
			AnimTime = Mathf.Lerp(AnimTime, MyAnim["f02_snapImpaleA_00"].length, Time.deltaTime * Speed);
			TargetAnim["f02_snapImpaleB_00"].time = AnimTime;
			MyAnim["f02_snapImpaleA_00"].time = AnimTime;
			if (Speed > 1.5f && !Heart.activeInHierarchy)
			{
				Object.Instantiate(Blood, MyHand.position, Quaternion.identity);
				Heart.SetActive(value: true);
			}
			if (AnimTime >= MyAnim["f02_snapImpaleA_00"].length * 0.99f)
			{
				TargetAnim["f02_snapImpaleB_00"].speed = -0.02f;
				MyAnim["f02_snapImpaleA_00"].speed = -0.02f;
				ImpalePhase++;
			}
		}
		else if (ImpalePhase == 2)
		{
			RotationSpeed += Time.deltaTime;
			HeadRotation = Mathf.Lerp(HeadRotation, 30f, Time.deltaTime * RotationSpeed);
			EyeRotation = Mathf.Lerp(EyeRotation, 30f, Time.deltaTime * RotationSpeed);
			if (RotationSpeed > 4f)
			{
				RotationSpeed = 0f;
				ImpalePhase++;
			}
		}
		else if (ImpalePhase == 3)
		{
			RotationSpeed += Time.deltaTime;
			HeadRotation = Mathf.Lerp(HeadRotation, 22.5f, Time.deltaTime * RotationSpeed);
			EyeRotation = Mathf.Lerp(EyeRotation, 15f, Time.deltaTime * RotationSpeed);
			if (RotationSpeed > 4f)
			{
				RotationSpeed = 0f;
				ImpalePhase++;
			}
		}
		else if (ImpalePhase == 4)
		{
			RotationSpeed += Time.deltaTime;
			if (RotationSpeed > 4f)
			{
				Object.Instantiate(Explosion, MyHead.position, Quaternion.identity);
				MyHead.localScale = new Vector3(0f, 0f, 0f);
				RotationSpeed = 0f;
				ImpalePhase++;
			}
		}
		else if (ImpalePhase == 5)
		{
			RotationSpeed += Time.deltaTime;
			if (RotationSpeed > 4f)
			{
				TargetAnim["f02_snapImpaleB_00"].weight = 0f;
				MyAnim["f02_snapImpaleA_00"].weight = 0f;
				TargetAnim["f02_idle_00"].time = 0f;
				MyAnim["f02_idle_00"].time = 0f;
				TargetAnim.Play("f02_idle_00");
				MyAnim.Play("f02_idle_00");
			}
		}
	}

	private void LateUpdate()
	{
		TargetNeck.localEulerAngles += new Vector3(HeadRotation, 0f, 0f);
		TargetHead.localEulerAngles += new Vector3(HeadRotation, 0f, 0f);
		EyeR.localEulerAngles -= new Vector3(EyeRotation * 0.66666f, 0f, 0f);
		EyeL.localEulerAngles += new Vector3(EyeRotation * 0.66666f, 0f, 0f);
		if (ImpalePhase == 4)
		{
			MyHead.localEulerAngles = new Vector3(Random.Range(RotationSpeed * 5f, RotationSpeed * -5f), Random.Range(RotationSpeed * 5f, RotationSpeed * -5f), Random.Range(RotationSpeed * 5f, RotationSpeed * -5f));
		}
		else if (ImpalePhase == 5)
		{
			MyHead.localScale = new Vector3(0f, 0f, 0f);
		}
		if (MyAnim["LoveLoveBEAM"].time >= MyAnim["LoveLoveBEAM"].length - 1f)
		{
			MyAnim.CrossFade("f02_idle_00");
		}
	}
}
