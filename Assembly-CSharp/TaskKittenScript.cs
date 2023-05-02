using Pathfinding;
using UnityEngine;

public class TaskKittenScript : MonoBehaviour
{
	public Transform TargetDestination;

	public YandereScript Yandere;

	public AIPath Pathfinding;

	public Animation Anim;

	public bool Caught;

	private void Start()
	{
		Anim["A_run"].speed = 2f;
		Anim["E_held"].speed = 0.1f;
	}

	private void Update()
	{
		if (Pathfinding.speed == 0f)
		{
			Quaternion b = Quaternion.LookRotation(Yandere.transform.position - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, 10f * Time.deltaTime);
			Anim.CrossFade("B_idle");
			if (Vector3.Distance(base.transform.position, Yandere.transform.position) < 5f)
			{
				PickDestination();
			}
		}
		else
		{
			Anim.CrossFade("A_run");
			if (Vector3.Distance(base.transform.position, TargetDestination.position) < 1f)
			{
				Stop();
			}
		}
	}

	private void PickDestination()
	{
		if (Yandere.transform.position.x > 0f)
		{
			TargetDestination.position = new Vector3(-44f, 0f, TargetDestination.position.z);
		}
		else
		{
			TargetDestination.position = new Vector3(44f, 0f, TargetDestination.position.z);
		}
		if (Yandere.transform.position.z > 0f)
		{
			TargetDestination.position = new Vector3(TargetDestination.position.x, 0f, -44f);
		}
		else
		{
			TargetDestination.position = new Vector3(TargetDestination.position.x, 0f, 36f);
		}
		Pathfinding.canSearch = true;
		Pathfinding.canMove = true;
		Pathfinding.speed = 6f;
	}

	public void Stop()
	{
		Pathfinding.canSearch = false;
		Pathfinding.canMove = false;
		Pathfinding.speed = 0f;
	}
}
