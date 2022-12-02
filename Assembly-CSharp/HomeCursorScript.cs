using UnityEngine;

public class HomeCursorScript : MonoBehaviour
{
	public PhotoGalleryScript PhotoGallery;

	public GameObject Photograph;

	public Transform Highlight;

	public GameObject Tack;

	public Transform CircleHighlight;

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == Photograph)
		{
			PhotographNull();
		}
		if (other.gameObject == Tack)
		{
			CircleHighlight.position = new Vector3(CircleHighlight.position.x, 100f, Highlight.position.z);
			Tack = null;
			PhotoGallery.UpdateButtonPrompts();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 16)
		{
			if (Tack == null)
			{
				Photograph = other.gameObject;
				Highlight.localEulerAngles = Photograph.transform.localEulerAngles;
				Highlight.localPosition = Photograph.transform.localPosition;
				Highlight.localScale = new Vector3(Photograph.transform.localScale.x * 1.12f, Photograph.transform.localScale.y * 1.2f, 1f);
				PhotoGallery.UpdateButtonPrompts();
			}
		}
		else if (other.gameObject.name != "SouthWall")
		{
			Tack = other.gameObject;
			CircleHighlight.position = Tack.transform.position;
			PhotoGallery.UpdateButtonPrompts();
			PhotographNull();
		}
	}

	private void PhotographNull()
	{
		Highlight.position = new Vector3(Highlight.position.x, 100f, Highlight.position.z);
		Photograph = null;
		PhotoGallery.UpdateButtonPrompts();
	}
}
