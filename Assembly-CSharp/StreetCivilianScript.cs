using Pathfinding;
using UnityEngine;

public class StreetCivilianScript : MonoBehaviour
{
	public CharacterController MyController;

	public Animation MyAnimation;

	public AIPath Pathfinding;

	public Transform[] Destinations;

	public string IdleAnim = "f02_idle_00";

	public string WalkAnim = "f02_newWalk_00";

	public float Timer;

	public int ID;

	private void Start()
	{
		Pathfinding.target = Destinations[0];
	}

	private void Update()
	{
		if (!(Vector3.Distance(base.transform.position, Destinations[ID].position) < 0.55f))
		{
			return;
		}
		MoveTowardsTarget(Destinations[ID].position);
		MyAnimation.CrossFade(IdleAnim);
		Pathfinding.canSearch = false;
		Pathfinding.canMove = false;
		Timer += Time.deltaTime;
		if (Timer > 13.5f)
		{
			MyAnimation.CrossFade(WalkAnim);
			ID++;
			if (ID == Destinations.Length)
			{
				ID = 0;
			}
			Pathfinding.target = Destinations[ID];
			Pathfinding.canSearch = true;
			Pathfinding.canMove = true;
			Timer = 0f;
		}
	}

	public void MoveTowardsTarget(Vector3 target)
	{
		Vector3 vector = target - base.transform.position;
		if (vector.sqrMagnitude > 1E-06f)
		{
			MyController.Move(vector * (Time.deltaTime * 1f / Time.timeScale));
		}
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Destinations[ID].rotation, 10f * Time.deltaTime);
	}
}
