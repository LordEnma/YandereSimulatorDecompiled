using Pathfinding;
using UnityEngine;

public class WitnessChanScript : MonoBehaviour
{
	public Animation CharacterAnimation;

	public AIPath Pathfinding;

	public Transform Yandere;

	public string RunAnim;

	public bool Fleeing;

	private void Update()
	{
		if (!Fleeing)
		{
			base.transform.LookAt(Yandere.position);
		}
		else
		{
			CharacterAnimation.CrossFade(RunAnim);
		}
	}
}
