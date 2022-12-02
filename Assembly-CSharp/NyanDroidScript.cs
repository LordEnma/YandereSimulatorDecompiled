using Pathfinding;
using UnityEngine;

public class NyanDroidScript : MonoBehaviour
{
	public Animation Character;

	public PromptScript Prompt;

	public AIPath Pathfinding;

	public Vector3 OriginalPosition;

	public string Prefix;

	public float Timer;

	private void Start()
	{
		OriginalPosition = base.transform.position;
	}

	private void Update()
	{
		if (!Pathfinding.canSearch)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Label[0].text = "     Stop";
				Prompt.Circle[0].fillAmount = 1f;
				Pathfinding.canSearch = true;
				Pathfinding.canMove = true;
			}
			return;
		}
		Timer += Time.deltaTime;
		if (Timer > 1f)
		{
			Timer = 0f;
			base.transform.position += new Vector3(0f, 0.0001f, 0f);
			if (base.transform.position.y < 0f)
			{
				base.transform.position = new Vector3(base.transform.position.x, 0.001f, base.transform.position.z);
			}
			Physics.SyncTransforms();
		}
		if (Input.GetButtonDown("RB"))
		{
			base.transform.position = OriginalPosition;
		}
		if (Vector3.Distance(base.transform.position, Pathfinding.target.position) <= 1f)
		{
			Character.CrossFade(Prefix + "_Idle");
			Pathfinding.speed = 0f;
		}
		else if (Vector3.Distance(base.transform.position, Pathfinding.target.position) <= 2f)
		{
			Character.CrossFade(Prefix + "_Walk");
			Pathfinding.speed = 0.5f;
		}
		else
		{
			Character.CrossFade(Prefix + "_Run");
			Pathfinding.speed = 5f;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Label[0].text = "     Follow";
			Prompt.Circle[0].fillAmount = 1f;
			Character.CrossFade(Prefix + "_Idle");
			Pathfinding.canSearch = false;
			Pathfinding.canMove = false;
		}
	}
}
