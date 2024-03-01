using UnityEngine;

public class StealthSecurityGuardScript : MonoBehaviour
{
	public Transform[] Node;

	public int CurrentNode;

	public float Timer;

	private void Update()
	{
		if (!(Vector3.Distance(base.transform.position, Node[CurrentNode].position) < 0.0001f))
		{
			return;
		}
		Timer += Time.deltaTime;
		if (Timer > 10f)
		{
			CurrentNode++;
			if (CurrentNode >= Node.Length)
			{
				CurrentNode = 0;
			}
		}
	}
}
