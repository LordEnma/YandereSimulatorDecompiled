using UnityEngine;

public class RivalBarScript : MonoBehaviour
{
	public int ID;

	public float Speed;

	public float Timer;

	public UISprite[] Bars;

	public float[] TargetHeights;

	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			UpdateBars();
		}
		Timer += Time.deltaTime;
		if (ID < 11)
		{
			if (Timer > 1f)
			{
				UpdateBars();
				Timer = 0f;
			}
		}
		else if (Timer > 2.5f)
		{
			UpdateBars();
			Timer = 0f;
		}
		for (int i = 1; i < ID; i++)
		{
			Bars[i].transform.localScale = Vector3.Lerp(Bars[i].transform.localScale, new Vector3(1f, TargetHeights[i], 1f), Time.deltaTime * Speed);
			Bars[i].color = new Color(TargetHeights[i] / 7f, 1f - TargetHeights[i] / 7f, 0f);
			if (i == 1)
			{
				Debug.Log("R is: " + TargetHeights[i] / 7f + " G is: " + (1f - TargetHeights[i] / 7f));
			}
		}
	}

	private void UpdateBars()
	{
		int i = 1;
		if (ID < 11)
		{
			ID++;
			return;
		}
		for (; i < ID; i++)
		{
			TargetHeights[i] = Random.Range(0.7f, 7f);
		}
	}
}
