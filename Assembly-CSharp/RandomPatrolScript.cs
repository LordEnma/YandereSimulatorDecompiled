using UnityEngine;

public class RandomPatrolScript : MonoBehaviour
{
	public Transform[] PatrolPoints;

	public int[] Height;

	private void Start()
	{
		for (int i = 1; i < 5; i++)
		{
			Height[i] = Random.Range(1, 5);
			if (Height[i] == 1)
			{
				Height[i] = 0;
			}
			else if (Height[i] == 2)
			{
				Height[i] = 4;
			}
			else if (Height[i] == 3)
			{
				Height[i] = 8;
			}
			else if (Height[i] == 4)
			{
				Height[i] = 12;
			}
		}
		Transform transform = PatrolPoints[1];
		Transform transform2 = PatrolPoints[2];
		Transform transform3 = PatrolPoints[3];
		Transform transform4 = PatrolPoints[4];
		transform.position = new Vector3(Random.Range(-21f, 21f), Height[1], Random.Range(21f, 19f));
		transform2.position = new Vector3(Random.Range(19f, 21f), Height[2], Random.Range(29f, -37f));
		transform3.position = new Vector3(Random.Range(-21f, 21f), Height[3], Random.Range(-21f, -19f));
		transform4.position = new Vector3(Random.Range(-19f, -21f), Height[4], Random.Range(29f, -37f));
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Random.Range(0f, 360f), transform.localEulerAngles.z);
		transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x, Random.Range(0f, 360f), transform2.localEulerAngles.z);
		transform3.localEulerAngles = new Vector3(transform3.localEulerAngles.x, Random.Range(0f, 360f), transform3.localEulerAngles.z);
		transform4.localEulerAngles = new Vector3(transform4.localEulerAngles.x, Random.Range(0f, 360f), transform4.localEulerAngles.z);
	}
}
