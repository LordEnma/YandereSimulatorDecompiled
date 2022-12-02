using UnityEngine;

public class MusicRatingScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public AudioSource SFX;

	public float Speed;

	public float Timer;

	private void Start()
	{
		if (SFX != null)
		{
			SFX.pitch = Random.Range(0.9f, 1.1f);
		}
	}

	private void Update()
	{
		base.transform.localPosition += new Vector3(0f, Speed * Time.deltaTime, 0f);
		base.transform.localScale = Vector3.MoveTowards(base.transform.localScale, new Vector3(0.2f, 0.1f, 0.1f), Time.deltaTime);
		Timer += Time.deltaTime * 5f;
		if (Timer > 1f)
		{
			MyRenderer.material.color = new Color(1f, 1f, 1f, 2f - Timer);
			if (MyRenderer.material.color.a <= 0f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
