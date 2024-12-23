using UnityEngine;

public class MissingPosterManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public GameObject MissingPoster;

	private void Start()
	{
		bool eighties = GameGlobals.Eighties;
		bool customMode = GameGlobals.CustomMode;
		string text = "";
		int num = 0;
		for (int i = 2; i < 90; i++)
		{
			if (!StudentGlobals.GetStudentMissing(i))
			{
				continue;
			}
			GameObject gameObject = Object.Instantiate(MissingPoster, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = base.transform;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			gameObject.transform.localEulerAngles = new Vector3(0f, 0f, Random.Range(-5f, 5f));
			if (eighties)
			{
				text = "file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_" + i + ".png";
				if (customMode)
				{
					text = "file:///" + Application.streamingAssetsPath + "/PortraitsCustom/Student_" + i + ".png";
				}
			}
			else
			{
				text = "file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + i + ".png";
			}
			WWW wWW = new WWW(text);
			MissingPosterScript component = gameObject.GetComponent<MissingPosterScript>();
			component.MyRenderer.material.mainTexture = wWW.texture;
			if (StudentManager.JSON.Students[i].RealName == "")
			{
				component.NameLabel.text = StudentManager.JSON.Students[i].Name;
			}
			else
			{
				component.NameLabel.text = StudentManager.JSON.Students[i].RealName;
			}
			gameObject.transform.localPosition = new Vector3(5460f - (float)(num * 430), Random.Range(-200f, 200f), 0f);
			num++;
			if (gameObject.transform.localPosition.x < -5460f)
			{
				Object.Destroy(gameObject);
			}
		}
	}
}
