using UnityEngine;

public class DontLetSenpaiNoticeYouScript : MonoBehaviour
{
	public UILabel[] Letters;

	public Vector3[] Origins;

	public AudioClip Slam;

	public bool Proceed;

	public int ShakeID;

	public int ID;

	private void Start()
	{
		while (ID < Letters.Length)
		{
			UILabel uILabel = Letters[ID];
			uILabel.transform.localScale = new Vector3(10f, 10f, 1f);
			uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 0f);
			Origins[ID] = uILabel.transform.localPosition;
			ID++;
		}
		ID = 0;
	}

	private void Update()
	{
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			Proceed = true;
		}
		if (!Proceed)
		{
			return;
		}
		if (ID < Letters.Length)
		{
			UILabel uILabel = Letters[ID];
			uILabel.transform.localScale = Vector3.MoveTowards(uILabel.transform.localScale, Vector3.one, Time.deltaTime * 100f);
			uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, uILabel.color.a + Time.deltaTime * 10f);
			if (uILabel.transform.localScale == Vector3.one)
			{
				GetComponent<AudioSource>().PlayOneShot(Slam);
				ID++;
			}
		}
		for (ShakeID = 0; ShakeID < Letters.Length; ShakeID++)
		{
			UILabel uILabel2 = Letters[ShakeID];
			Vector3 vector = Origins[ShakeID];
			uILabel2.transform.localPosition = new Vector3(vector.x + Random.Range(-5f, 5f), vector.y + Random.Range(-5f, 5f), uILabel2.transform.localPosition.z);
		}
	}
}
