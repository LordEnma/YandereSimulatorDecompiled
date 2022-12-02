using UnityEngine;

public class BuildingDestructionScript : MonoBehaviour
{
	public Transform NewSchool;

	public bool Sink;

	public int Phase;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Phase++;
			Sink = true;
		}
		if (Sink)
		{
			if (Phase == 1)
			{
				base.transform.position = new Vector3(Random.Range(-1f, 1f), base.transform.position.y - Time.deltaTime * 10f, Random.Range(-19f, -21f));
			}
			else if (NewSchool.position.y != 0f)
			{
				NewSchool.position = new Vector3(NewSchool.position.x, Mathf.MoveTowards(NewSchool.position.y, 0f, Time.deltaTime * 10f), NewSchool.position.z);
				base.transform.position = new Vector3(Random.Range(-1f, 1f), base.transform.position.y, Random.Range(13f, 15f));
			}
			else
			{
				base.transform.position = new Vector3(0f, base.transform.position.y, 14f);
			}
		}
	}
}
