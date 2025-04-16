using UnityEngine;

public class LevelUpEffectScript : MonoBehaviour
{
	public UIPanel Panel;

	public Transform LevelUp;

	public float Speed;

	public float Timer;

	public int Phase;

	private void Start()
	{
		LevelUp.localScale = Vector3.zero;
	}

	private void Update()
	{
		if (Phase == 0)
		{
			LevelUp.localScale = Vector3.Lerp(LevelUp.localScale, Vector3.one, Time.deltaTime * 5f);
			Timer += Time.deltaTime;
			if (Timer > 2.5f)
			{
				Phase++;
			}
		}
		else
		{
			Speed += Time.deltaTime * 5f;
			LevelUp.localScale += new Vector3(Time.deltaTime * Speed, Time.deltaTime * Speed, Time.deltaTime * Speed);
			Panel.alpha -= Time.deltaTime;
		}
	}
}
