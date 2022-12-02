using UnityEngine;

public class TimePortalScript : MonoBehaviour
{
	public DelinquentScript[] Delinquent;

	public GameObject BlackHole;

	public float Timer;

	public bool Suck;

	public int ID;

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			Suck = true;
		}
		if (!Suck)
		{
			return;
		}
		Object.Instantiate(BlackHole, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
		Timer += Time.deltaTime;
		if (Timer > 1.1f)
		{
			Delinquent[ID].Suck = true;
			Timer = 1f;
			ID++;
			if (ID > 9)
			{
				base.enabled = false;
			}
		}
	}
}
