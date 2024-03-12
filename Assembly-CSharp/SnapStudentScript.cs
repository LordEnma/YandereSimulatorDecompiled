using UnityEngine;

public class SnapStudentScript : MonoBehaviour
{
	public SnappedYandereScript Yandere;

	public Quaternion targetRotation;

	public StudentScript Student;

	public Animation MyAnim;

	public string FearAnim;

	public string[] AttackAnims;

	public bool VoicedConcern;

	public AudioClip[] StudentFear;

	public AudioClip SenpaiFear;

	private void Start()
	{
		MyAnim.enabled = false;
		MyAnim[FearAnim].time = Random.Range(0f, MyAnim[FearAnim].length);
		MyAnim.enabled = true;
	}

	private void Update()
	{
		if (Vector3.Distance(base.transform.position, Yandere.transform.position) < 1f)
		{
			if (Yandere.CanMove)
			{
				if (Student.StudentID == 1)
				{
					if (Yandere.Armed && !Yandere.KillingSenpai)
					{
						Yandere.Knife.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						Yandere.MyAudio.clip = Yandere.EndSNAP;
						Yandere.MyAudio.loop = false;
						Yandere.MyAudio.volume = 1f;
						Yandere.MyAudio.pitch = 1f;
						Yandere.MyAudio.Play();
						Yandere.Speed = 0f;
						Yandere.MyAnim.CrossFade("f02_snapKill_00");
						if (!Student.Male)
						{
							MyAnim.CrossFade("f02_snapDie_00");
						}
						else
						{
							MyAnim.CrossFade("snapDie_00");
						}
						Yandere.TargetStudent = this;
						Yandere.KillingSenpai = true;
						Yandere.CanMove = false;
						base.enabled = false;
					}
				}
				else if (!Yandere.Attacking)
				{
					Yandere.transform.position = base.transform.position + base.transform.forward;
					Yandere.transform.LookAt(base.transform.position);
					Yandere.TargetStudent = this;
					Yandere.Attacking = true;
					Yandere.CanMove = false;
					Yandere.StaticNoise.volume = 0f;
					Yandere.Static.Fade = 0f;
					Yandere.HurryTimer = 0f;
					Yandere.ChooseAttack();
					Student.Pathfinding.enabled = false;
					base.enabled = false;
				}
			}
		}
		else if (Vector3.Distance(base.transform.position, Yandere.transform.position) < 4f)
		{
			if (!VoicedConcern && Yandere.CanMove && !Yandere.SnapVoice.isPlaying)
			{
				if (Student.StudentID == 1)
				{
					Yandere.SnapVoice.clip = SenpaiFear;
					Yandere.SnapVoice.Play();
					Yandere.ListenTimer = 10f;
				}
				else
				{
					int voiceID = Yandere.VoiceID;
					while (Yandere.VoiceID == voiceID)
					{
						Yandere.VoiceID = Random.Range(0, 5);
					}
					Yandere.SnapVoice.clip = StudentFear[Yandere.VoiceID];
					Yandere.SnapVoice.Play();
					Yandere.ListenTimer = 1f;
				}
				VoicedConcern = true;
			}
			MyAnim.Play(FearAnim);
		}
		else
		{
			MyAnim.Play(FearAnim);
		}
		if (!Yandere.Attacking)
		{
			base.transform.LookAt(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z));
		}
	}
}
