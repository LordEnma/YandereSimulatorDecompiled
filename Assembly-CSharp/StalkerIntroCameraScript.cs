using UnityEngine;

public class StalkerIntroCameraScript : MonoBehaviour
{
	public Animation YandereAnim;

	public Transform Yandere;

	public float Speed;

	private void Update()
	{
		if (YandereAnim["f02_wallJump_00"].time > YandereAnim["f02_wallJump_00"].length)
		{
			Speed += Time.deltaTime;
			Yandere.position = Vector3.Lerp(Yandere.position, new Vector3(14.33333f, 0f, 15f), Time.deltaTime * Speed);
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(13.75f, 1.4f, 14.5f), Time.deltaTime * Speed);
			base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, new Vector3(15f, 180f, 0f), Time.deltaTime * Speed);
		}
	}
}
