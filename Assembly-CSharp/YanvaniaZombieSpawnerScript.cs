using UnityEngine;

public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	public YanvaniaZombieScript NewZombieScript;

	public GameObject Zombie;

	public YanvaniaYanmontScript Yanmont;

	public float SpawnTimer;

	public float RelativePoint;

	public float RightBoundary;

	public float LeftBoundary;

	public int SpawnSide;

	public int ID;

	public GameObject[] Zombies;

	public Vector3[] SpawnPoints;

	private void Update()
	{
		if (!(Yanmont.transform.position.x > 0f) || !(Yanmont.transform.position.x < 51.75f))
		{
			return;
		}
		ID = 0;
		SpawnTimer += Time.deltaTime;
		if (!(SpawnTimer > 1f))
		{
			return;
		}
		while (ID < 4)
		{
			if (Zombies[ID] == null)
			{
				SpawnSide = Random.Range(1, 3);
				if (Yanmont.transform.position.x < LeftBoundary + 5f)
				{
					SpawnSide = 2;
				}
				if (Yanmont.transform.position.x > RightBoundary - 5f)
				{
					SpawnSide = 1;
				}
				if (Yanmont.transform.position.x < LeftBoundary)
				{
					RelativePoint = LeftBoundary;
				}
				else if (Yanmont.transform.position.x > RightBoundary)
				{
					RelativePoint = RightBoundary;
				}
				else
				{
					RelativePoint = Yanmont.transform.position.x;
				}
				if (SpawnSide == 1)
				{
					SpawnPoints[0].x = RelativePoint - 2.5f;
					SpawnPoints[1].x = RelativePoint - 3.5f;
					SpawnPoints[2].x = RelativePoint - 4.5f;
					SpawnPoints[3].x = RelativePoint - 5.5f;
				}
				else
				{
					SpawnPoints[0].x = RelativePoint + 2.5f;
					SpawnPoints[1].x = RelativePoint + 3.5f;
					SpawnPoints[2].x = RelativePoint + 4.5f;
					SpawnPoints[3].x = RelativePoint + 5.5f;
				}
				Zombies[ID] = Object.Instantiate(Zombie, SpawnPoints[ID], Quaternion.identity);
				NewZombieScript = Zombies[ID].GetComponent<YanvaniaZombieScript>();
				NewZombieScript.LeftBoundary = LeftBoundary;
				NewZombieScript.RightBoundary = RightBoundary;
				NewZombieScript.Yanmont = Yanmont;
				break;
			}
			ID++;
		}
		SpawnTimer = 0f;
	}
}
