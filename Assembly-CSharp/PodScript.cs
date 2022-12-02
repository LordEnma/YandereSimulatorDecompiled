using UnityEngine;

public class PodScript : MonoBehaviour
{
	public GameObject Projectile;

	public Transform SpawnPoint;

	public Transform PodTarget;

	public Transform AimTarget;

	public float FireRate;

	public float Timer;

	private void Start()
	{
		Timer = 1f;
	}

	private void LateUpdate()
	{
		PodTarget.transform.parent.eulerAngles = new Vector3(0f, AimTarget.parent.eulerAngles.y, 0f);
		base.transform.position = Vector3.Lerp(base.transform.position, PodTarget.position, Time.deltaTime * 100f);
		base.transform.rotation = AimTarget.parent.rotation;
		base.transform.eulerAngles += new Vector3(-15f, 7.5f, 0f);
		if (Input.GetButton("RB"))
		{
			Timer += Time.deltaTime;
			if (Timer > FireRate)
			{
				Object.Instantiate(Projectile, SpawnPoint.position, base.transform.rotation);
				Timer = 0f;
			}
		}
	}
}
