using UnityEngine;

public class HomeZoomScript : MonoBehaviour
{
	public Transform YandereDestination;

	public bool Zoom;

	private void Update()
	{
		AudioSource component = GetComponent<AudioSource>();
		if (Input.GetKeyDown(KeyCode.Z))
		{
			if (!Zoom)
			{
				Zoom = true;
				component.Play();
			}
			else
			{
				Zoom = false;
			}
		}
		if (Zoom)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, 1.5f, Time.deltaTime * (1f / 30f)), base.transform.localPosition.z);
			YandereDestination.localPosition = Vector3.MoveTowards(YandereDestination.localPosition, new Vector3(-1.5f, 1.5f, 1f), Time.deltaTime * (1f / 30f));
			component.volume += Time.deltaTime * 0.01f;
		}
		else
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, 1f, Time.deltaTime * 10f), base.transform.localPosition.z);
			YandereDestination.localPosition = Vector3.MoveTowards(YandereDestination.localPosition, new Vector3(-2.271312f, 2f, 3.5f), Time.deltaTime * 10f);
			component.volume = 0f;
		}
	}
}
