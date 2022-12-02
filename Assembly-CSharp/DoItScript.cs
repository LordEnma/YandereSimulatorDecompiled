using UnityEngine;

public class DoItScript : MonoBehaviour
{
	public UILabel MyLabel;

	public bool Fade;

	private void Start()
	{
		MyLabel.fontSize = Random.Range(50, 100);
	}

	private void Update()
	{
		base.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
		if (!Fade)
		{
			MyLabel.alpha += Time.deltaTime;
			if (MyLabel.alpha >= 1f)
			{
				Fade = true;
			}
		}
		else
		{
			MyLabel.alpha -= Time.deltaTime;
			if (MyLabel.alpha <= 0f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
