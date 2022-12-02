using UnityEngine;

public class MissingPosterManagerScript : MonoBehaviour
{
	public GameObject MissingPoster;

	public int RandomID;

	public int ID;

	private void Start()
	{
		while (ID < 101)
		{
			if (StudentGlobals.GetStudentMissing(ID))
			{
				GameObject gameObject = Object.Instantiate(MissingPoster, base.transform.position, Quaternion.identity);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject.transform.eulerAngles = new Vector3(0f, 0f, Random.Range(-15f, 15f));
				WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + ID + ".png");
				gameObject.GetComponent<MissingPosterScript>().MyRenderer.material.mainTexture = wWW.texture;
				RandomID = Random.Range(1, 3);
				gameObject.transform.localPosition = new Vector3(-16300f + (float)(ID * 500), Random.Range(1300f, 2000f), 0f);
				if (gameObject.transform.localPosition.x > -3700f)
				{
					gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + 7300f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
				}
				if (gameObject.transform.localPosition.x > 15800f)
				{
					Object.Destroy(gameObject);
				}
			}
			ID++;
		}
	}
}
