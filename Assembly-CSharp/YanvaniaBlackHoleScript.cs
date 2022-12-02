using UnityEngine;

public class YanvaniaBlackHoleScript : MonoBehaviour
{
	public GameObject BlackHoleAttack;

	public int Attacks;

	public float SpawnTimer;

	public float Timer;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > 1f)
		{
			SpawnTimer -= Time.deltaTime;
			if (SpawnTimer <= 0f && Attacks < 5)
			{
				Object.Instantiate(BlackHoleAttack, base.transform.position, Quaternion.identity);
				SpawnTimer = 0.5f;
				Attacks++;
			}
		}
	}
}
