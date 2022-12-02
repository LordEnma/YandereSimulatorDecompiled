using UnityEngine;

public class YanvaniaBossHeadScript : MonoBehaviour
{
	public YanvaniaDraculaScript Dracula;

	public GameObject HitEffect;

	public float Timer;

	private void Update()
	{
		Timer -= Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (Timer <= 0f && Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			GameObject gameObject = Object.Instantiate(HitEffect, base.transform.position, Quaternion.identity);
			if (gameObject.transform.position.y < 7f)
			{
				gameObject.transform.position += new Vector3(0f, 1f, 0f);
			}
			Timer = 1f;
			Dracula.TakeDamage();
		}
	}
}
