using UnityEngine;

public class MusicAudienceScript : MonoBehaviour
{
	public MusicMinigameScript MusicMinigame;

	public float JumpStrength;

	public float Threshold;

	public float Minimum;

	public float Jump;

	private void Start()
	{
		JumpStrength += Random.Range(-0.0001f, 0.0001f);
	}

	private void Update()
	{
		if (MusicMinigame.Health >= Threshold)
		{
			Minimum = Mathf.MoveTowards(Minimum, 0.2f, Time.deltaTime * 0.1f);
		}
		else
		{
			Minimum = Mathf.MoveTowards(Minimum, 0f, Time.deltaTime * 0.1f);
		}
		base.transform.localPosition += new Vector3(0f, Jump, 0f);
		Jump -= Time.deltaTime * 0.01f;
		if (base.transform.localPosition.y < Minimum)
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Minimum, 0f);
			Jump = JumpStrength;
		}
	}
}
