using UnityEngine;

public class YanvaniaWineScript : MonoBehaviour
{
	public GameObject Shards;

	public float Rotation;

	private void Update()
	{
		if (base.transform.parent == null)
		{
			Rotation += Time.deltaTime * 360f;
			base.transform.localEulerAngles = new Vector3(Rotation, Rotation, Rotation);
			if (base.transform.position.y < 6.75f)
			{
				Object.Instantiate(Shards, new Vector3(base.transform.position.x, 6.75f, base.transform.position.z), Quaternion.identity).transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
				AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, base.transform.position);
				Object.Destroy(base.gameObject);
			}
		}
	}
}
