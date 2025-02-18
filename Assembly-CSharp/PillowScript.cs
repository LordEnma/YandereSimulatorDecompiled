using UnityEngine;

public class PillowScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public StudentScript Student;

	public YandereScript Yandere;

	public Transform YandereSpot;

	public PromptScript Prompt;

	public Animation Pillow;

	public Collider[] Colliders;

	public bool Display;

	public float Timer;

	public int Phase;

	private void Update()
	{
		if (!Display)
		{
			Timer += Time.deltaTime;
			if (!(Timer > 1f))
			{
				return;
			}
			StudentScript[] students = StudentManager.Students;
			foreach (StudentScript studentScript in students)
			{
				if (studentScript != null && (studentScript.CurrentAction == StudentActionType.Sleep || studentScript.Sedated || studentScript.Sleepy) && Vector3.Distance(base.transform.position, studentScript.transform.position) < 1f)
				{
					Prompt.gameObject.SetActive(value: true);
					Student = studentScript;
					Display = true;
					Timer = 0f;
				}
			}
			return;
		}
		if (Phase == 0)
		{
			if (Vector3.Distance(base.transform.position, Student.transform.position) > 1f || (Student.CurrentAction != StudentActionType.Sleep && !Student.Sedated && !Student.Sleepy))
			{
				Prompt.gameObject.SetActive(value: false);
				Prompt.Hide();
				Student = null;
				Display = false;
			}
			else if (Prompt.Circle[2].fillAmount == 0f)
			{
				Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
				Yandere.MurderousActionTimer = 10f;
				Yandere.CanMove = false;
				Student.MyRenderer.updateWhenOffscreen = true;
				Student.MyController.radius = 0.0001f;
				Student.MyController.enabled = false;
				Student.Pathfinding.canSearch = false;
				Student.Pathfinding.canMove = false;
				Student.transform.parent = base.transform;
				Student.enabled = false;
				Phase++;
			}
			return;
		}
		if (Phase == 1)
		{
			Timer += Time.deltaTime;
			Yandere.MoveTowardsTarget(YandereSpot.position);
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, YandereSpot.rotation, Time.deltaTime * 10f);
			Student.transform.localPosition = Vector3.MoveTowards(Student.transform.localPosition, new Vector3(0f, 0f, 0f), Time.deltaTime);
			if (Timer > 1f)
			{
				Phase++;
			}
			return;
		}
		Yandere.CharacterAnimation.CrossFade("f02_smotherA_00");
		if (!Student.Male)
		{
			Student.CharacterAnimation.CrossFade("f02_smotherB_00");
		}
		else
		{
			Student.CharacterAnimation.CrossFade("smotherB_00");
		}
		Pillow.Play();
		if (Yandere.CharacterAnimation["f02_smotherA_00"].time >= Yandere.CharacterAnimation["f02_smotherA_00"].length)
		{
			Prompt.gameObject.SetActive(value: false);
			Prompt.Hide();
			Colliders[0].enabled = true;
			Colliders[1].enabled = false;
			Colliders[2].enabled = false;
			Student.BecomeRagdoll();
			Student.Ragdoll.BloodPoolSpawner.enabled = false;
			Student.DeathCause = 13;
			Student.DeathType = DeathType.Smothered;
			if (Student.Rival)
			{
				StudentManager.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Accident;
			}
			Yandere.CanMove = true;
			base.enabled = false;
		}
	}
}
