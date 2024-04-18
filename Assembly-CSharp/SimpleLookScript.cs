using UnityEngine;

public class SimpleLookScript : MonoBehaviour
{
	public StudentScript Student;

	public PerfectLookAt HeadLookAt;

	public PerfectLookAt NeckLookAt;

	public PerfectLookAt SpineLookAt;

	public Transform EyeL;

	public Transform EyeR;

	public Transform Head;

	public Transform Neck;

	public Transform Spine;

	public Transform YandereHead;

	public Transform MyHead;

	public Transform Forward;

	public Transform LookTarget;

	public Transform Yandere;

	public float BlendAmount;

	public float PreviousEye;

	public float PreviousHead;

	public float PreviousNeck;

	public float PreviousSpine;

	public float Rotation;

	public float IgnoreTimer;

	public float LookTimer;

	public float WaveTimer;

	public float Speed;

	public float Timer;

	public bool ReactedToFriend;

	public bool Ignore;

	public bool Suitor;

	public bool Waving;

	public bool Look;

	private void Start()
	{
		LookTarget.parent = base.transform.parent;
		HeadLookAt.enabled = false;
		NeckLookAt.enabled = false;
		SpineLookAt.enabled = false;
		Yandere = Student.Yandere.transform;
		YandereHead = Student.Yandere.Head;
		if (Student.StudentID == Student.StudentManager.SuitorID && Student.StudentManager.Students[Student.StudentManager.RivalID] != null)
		{
			Ignore = true;
			Suitor = true;
			Yandere = Student.StudentManager.Students[Student.StudentManager.RivalID].transform;
			YandereHead = Student.StudentManager.Students[Student.StudentManager.RivalID].Head.transform;
			Student.Cosmetic.MyRenderer.materials[Student.Cosmetic.FaceID].SetTexture("_OverlayTex", Student.StudentManager.LoveManager.ConfessionScene.BlushTexture);
			Student.Cosmetic.MyRenderer.materials[Student.Cosmetic.FaceID].SetFloat("_BlendAmount", 0f);
			Student.Hearts.Stop();
		}
	}

	private void LateUpdate()
	{
		if (Input.GetKeyDown("z"))
		{
			Student.CharacterAnimation[Student.WaveAnim].time = 0f;
			ReactedToFriend = false;
			LookTimer = 0f;
			WaveTimer = 0f;
		}
		if (Student.Routine)
		{
			float num = 0f;
			num = (Suitor ? Vector3.Distance(Student.transform.position, Yandere.transform.position) : Student.DistanceToPlayer);
			if (num < 2f || Look)
			{
				if (Mathf.Abs(Vector3.Angle(-base.transform.forward, Yandere.transform.position - base.transform.position)) >= 90f && num < 2f && !Ignore)
				{
					LookTimer += Time.deltaTime;
					if (!ReactedToFriend && Student.Friend && Student.Yandere.Mask == null && !Student.Emetic && !Student.Lethal && !Student.Sedated && !Student.Headache && !Student.Grudge && !Student.Dying && Student.CurrentAction != StudentActionType.Sunbathe && Student.CurrentAction != StudentActionType.Gaming && Student.CurrentAction != StudentActionType.Mourn && Student.StudentID > 1 && LookTimer > 1f)
					{
						Student.CharacterAnimation[Student.WaveAnim].weight = 0f;
						Student.CharacterAnimation[Student.WaveAnim].time = 0f;
						Student.CharacterAnimation.CrossFade(Student.WaveAnim);
						ReactedToFriend = true;
						Waving = true;
					}
					if (LookTimer > 5f)
					{
						LookTimer = 0f;
						Ignore = true;
					}
					Look = true;
					Timer = 0f;
				}
				else
				{
					if (Ignore)
					{
						IgnoreTimer += Time.deltaTime;
						if (IgnoreTimer > 5f)
						{
							IgnoreTimer = 0f;
							Ignore = false;
						}
					}
					if (Look)
					{
						Timer += Time.deltaTime;
						if (Timer > 2f)
						{
							Look = false;
							Timer = 0f;
						}
					}
				}
			}
		}
		else
		{
			Look = false;
		}
		if (Look)
		{
			float num2 = 0f;
			num2 = (Suitor ? Vector3.Distance(Student.transform.position, Yandere.transform.position) : Student.DistanceToPlayer);
			float f = Vector3.Angle(base.transform.forward, Yandere.transform.position - base.transform.position);
			Vector3 vector = YandereHead.transform.position - MyHead.transform.position;
			float num3 = Vector3.Angle(base.transform.right, new Vector3(vector.x, 0f, vector.z));
			if (Mathf.Abs(f) <= 90f && num2 < 2f && !Ignore)
			{
				if (num3 <= 90f)
				{
					float num4 = (90f - num3) / 90f;
					Rotation = Mathf.Lerp(Rotation, 10f * num4, Time.deltaTime * 3.6f);
				}
				else
				{
					float num5 = (90f - (180f - num3)) / 90f;
					Rotation = Mathf.Lerp(Rotation, -10f * num5, Time.deltaTime * 3.6f);
				}
			}
			else
			{
				Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 3.6f * 0.5f);
			}
			if (EyeL.localEulerAngles.y != PreviousEye)
			{
				EyeL.localEulerAngles += new Vector3(0f, Rotation, 0f);
				EyeR.localEulerAngles += new Vector3(0f, Rotation, 0f);
			}
			if (Head.localEulerAngles.y != PreviousHead)
			{
				Head.localEulerAngles += new Vector3(0f, Rotation * 2f, 0f);
			}
			if (Neck.localEulerAngles.y != PreviousNeck)
			{
				Neck.localEulerAngles += new Vector3(0f, Rotation * 1.5f, 0f);
			}
			if (Spine.localEulerAngles.y != PreviousSpine)
			{
				Spine.localEulerAngles += new Vector3(0f, Rotation * 1f, 0f);
			}
			PreviousEye = EyeL.localEulerAngles.y;
			PreviousHead = Head.localEulerAngles.y;
			PreviousNeck = Neck.localEulerAngles.y;
			PreviousSpine = Spine.localEulerAngles.y;
		}
		if (Suitor)
		{
			if (Ignore)
			{
				if (BlendAmount > 0f)
				{
					BlendAmount = Mathf.MoveTowards(BlendAmount, 0f, Time.deltaTime);
					Student.Cosmetic.MyRenderer.materials[Student.Cosmetic.FaceID].SetFloat("_BlendAmount", BlendAmount);
				}
			}
			else if (BlendAmount < 1f)
			{
				if (BlendAmount == 0f)
				{
					ParticleSystem.EmissionModule emission = Student.Hearts.emission;
					emission.rateOverTime = 10f;
					emission.enabled = true;
					ParticleSystem.MainModule main = Student.Hearts.main;
					main.startLifetime = 5f;
					main.loop = false;
					if (!Student.Hearts.isEmitting)
					{
						main.duration = 4f;
					}
					Student.Hearts.Play();
				}
				BlendAmount = Mathf.MoveTowards(BlendAmount, 1f, Time.deltaTime);
				Student.Cosmetic.MyRenderer.materials[Student.Cosmetic.FaceID].SetFloat("_BlendAmount", BlendAmount);
			}
		}
		if (!Student.Alive || Student.Slave)
		{
			base.enabled = false;
		}
		if (Waving)
		{
			WaveTimer += Time.deltaTime;
			if (WaveTimer < Student.CharacterAnimation[Student.WaveAnim].length - 1f)
			{
				Student.CharacterAnimation[Student.WaveAnim].weight = Mathf.MoveTowards(Student.CharacterAnimation[Student.WaveAnim].weight, 1f, Time.deltaTime);
			}
			else
			{
				Student.CharacterAnimation[Student.WaveAnim].weight = Mathf.MoveTowards(Student.CharacterAnimation[Student.WaveAnim].weight, 0f, Time.deltaTime);
			}
			if (WaveTimer >= Student.CharacterAnimation[Student.WaveAnim].length)
			{
				Student.CharacterAnimation[Student.WaveAnim].weight = 0f;
				Waving = false;
			}
		}
	}
}
