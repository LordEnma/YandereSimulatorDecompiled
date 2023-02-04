using UnityEngine;

public class MGPMSpawnerScript : MonoBehaviour
{
	public MGPMManagerScript GameplayManager;

	public MGPMMiyukiScript Miyuki;

	public Transform[] SpawnPositions;

	public float[] SpawnTimers;

	public int[] SpawnEnemies;

	public GameObject[] LoadBearer;

	public GameObject[] Enemy;

	public Transform HealthBar;

	public float SpawnRate;

	public float Timer;

	public bool RandomMode;

	public int Wave;

	public int ID;

	private void Start()
	{
		if (Wave == 8 || Wave == 9)
		{
			for (ID = 1; ID < 100; ID++)
			{
				SpawnTimers[ID] = SpawnTimers[ID - 1] + 0.1f;
			}
			ID = 0;
		}
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (ID < SpawnTimers.Length)
		{
			if (!(Timer > SpawnTimers[ID]))
			{
				return;
			}
			GameObject gameObject = Object.Instantiate(Enemy[SpawnEnemies[ID]], base.transform.position, Quaternion.identity);
			gameObject.transform.parent = base.transform.parent;
			if (SpawnEnemies[ID] == 4 || SpawnEnemies[ID] == 11)
			{
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else if (SpawnEnemies[ID] == 6 || SpawnEnemies[ID] == 9 || SpawnEnemies[ID] == 12)
			{
				gameObject.transform.localScale = new Vector3(128f, 128f, 1f);
			}
			else
			{
				gameObject.transform.localScale = new Vector3(64f, 64f, 1f);
			}
			gameObject.transform.position = SpawnPositions[ID].position;
			MGPMEnemyScript component = gameObject.GetComponent<MGPMEnemyScript>();
			component.GameplayManager = GameplayManager;
			component.Miyuki = Miyuki;
			if (Wave == 9)
			{
				if (ID < 100)
				{
					SpawnPositions[ID].localPosition = new Vector3(Random.Range(-100f, 100f), 0f, 0f);
				}
				else if (ID == 100)
				{
					LoadBearer[1] = gameObject;
				}
				else if (ID == 101)
				{
					LoadBearer[2] = gameObject;
				}
			}
			ID++;
		}
		else if (Wave == 9 && LoadBearer[1] == null && LoadBearer[2] == null)
		{
			GameplayManager.Jukebox.volume = Mathf.MoveTowards(GameplayManager.Jukebox.volume, 0f, Time.deltaTime * 0.5f);
			if (GameplayManager.Jukebox.volume == 0f)
			{
				GameObject obj = Object.Instantiate(Enemy[SpawnEnemies[ID]], base.transform.position, Quaternion.identity);
				obj.transform.parent = base.transform.parent;
				obj.transform.localScale = new Vector3(256f, 128f, 1f);
				obj.transform.position = SpawnPositions[ID].position;
				MGPMEnemyScript component2 = obj.GetComponent<MGPMEnemyScript>();
				component2.GameplayManager = GameplayManager;
				component2.HealthBar = HealthBar;
				component2.Miyuki = Miyuki;
				HealthBar.parent.gameObject.SetActive(value: true);
				GameplayManager.Jukebox.clip = GameplayManager.FinalBoss;
				GameplayManager.Jukebox.volume = 0.5f;
				GameplayManager.Jukebox.Play();
				base.enabled = false;
			}
		}
	}
}
