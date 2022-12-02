using UnityEngine;

public class KnifeArrayScript : MonoBehaviour
{
	public GlobalKnifeArrayScript GlobalKnifeArray;

	public Transform KnifeTarget;

	public float[] SpawnTimes;

	public GameObject Knife;

	public float Timer;

	public int ID;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (ID < 10)
		{
			if (Timer > SpawnTimes[ID] && GlobalKnifeArray.ID < 1000)
			{
				GameObject gameObject = Object.Instantiate(Knife, base.transform.position, Quaternion.identity);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 2f), Random.Range(-0.75f, -1.75f));
				gameObject.transform.parent = null;
				gameObject.transform.LookAt(KnifeTarget);
				GlobalKnifeArray.Knives[GlobalKnifeArray.ID] = gameObject.GetComponent<TimeStopKnifeScript>();
				GlobalKnifeArray.ID++;
				ID++;
			}
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}
}
