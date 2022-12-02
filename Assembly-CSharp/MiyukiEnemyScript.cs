using UnityEngine;

public class MiyukiEnemyScript : MonoBehaviour
{
	public float Float;

	public float Limit;

	public float Speed;

	public bool Dead;

	public bool Down;

	public GameObject DeathEffect;

	public GameObject HitEffect;

	public GameObject Enemy;

	public Transform[] SpawnPoints;

	public float RespawnTimer;

	public float Health;

	public int ID;

	private void Start()
	{
		base.transform.position = SpawnPoints[ID].position;
		base.transform.rotation = SpawnPoints[ID].rotation;
	}

	private void Update()
	{
		if (Enemy.activeInHierarchy)
		{
			if (!Down)
			{
				Float += Time.deltaTime * Speed;
				if (Float > Limit)
				{
					Down = true;
				}
			}
			else
			{
				Float -= Time.deltaTime * Speed;
				if (Float < -1f * Limit)
				{
					Down = false;
				}
			}
			Enemy.transform.position += new Vector3(0f, Float * Time.deltaTime, 0f);
			if (Enemy.transform.position.y > SpawnPoints[ID].position.y + 1.5f)
			{
				Enemy.transform.position = new Vector3(Enemy.transform.position.x, SpawnPoints[ID].position.y + 1.5f, Enemy.transform.position.z);
			}
			if (Enemy.transform.position.y < SpawnPoints[ID].position.y + 0.5f)
			{
				Enemy.transform.position = new Vector3(Enemy.transform.position.x, SpawnPoints[ID].position.y + 0.5f, Enemy.transform.position.z);
			}
		}
		else
		{
			RespawnTimer += Time.deltaTime;
			if (RespawnTimer > 5f)
			{
				base.transform.position = SpawnPoints[ID].position;
				base.transform.rotation = SpawnPoints[ID].rotation;
				Enemy.SetActive(true);
				RespawnTimer = 0f;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!Enemy.activeInHierarchy || !(other.gameObject.tag == "missile"))
		{
			return;
		}
		Object.Instantiate(HitEffect, other.transform.position, Quaternion.identity);
		Object.Destroy(other.gameObject);
		Health -= 1f;
		if (Health == 0f)
		{
			Object.Instantiate(DeathEffect, other.transform.position, Quaternion.identity);
			Enemy.SetActive(false);
			Health = 50f;
			ID++;
			if (ID >= SpawnPoints.Length)
			{
				ID = 0;
			}
		}
	}
}
