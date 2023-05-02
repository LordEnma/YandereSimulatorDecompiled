using UnityEngine;

public class AboutScript : MonoBehaviour
{
	public Transform[] Labels;

	public bool[] SlideOut;

	public bool[] SlideIn;

	public UILabel LinkLabel;

	public UITexture Yuno1;

	public UITexture Yuno2;

	public int SlideID;

	public int ID;

	public float Timer;

	private void Start()
	{
		Transform[] labels = Labels;
		foreach (Transform obj in labels)
		{
			Vector3 localPosition = obj.localPosition;
			localPosition.x = 2000f;
			obj.localPosition = localPosition;
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			if (SlideID < Labels.Length)
			{
				SlideIn[SlideID] = true;
			}
			SlideID++;
		}
		if (SlideID < Labels.Length + 1)
		{
			for (ID = 0; ID < Labels.Length; ID++)
			{
				if (SlideIn[ID])
				{
					Transform obj = Labels[ID];
					Vector3 localPosition = obj.localPosition;
					localPosition.x = Mathf.Lerp(localPosition.x, 0f, Time.deltaTime);
					obj.localPosition = localPosition;
				}
			}
			return;
		}
		Timer += Time.deltaTime * 10f;
		for (ID = 0; ID < Labels.Length; ID++)
		{
			if (Timer > (float)ID)
			{
				SlideOut[ID] = true;
				Transform transform = Labels[ID];
				Vector3 localPosition2 = transform.localPosition;
				if (localPosition2.x > 0f)
				{
					localPosition2.x = -0.1f;
					transform.localPosition = localPosition2;
				}
			}
		}
		for (ID = 0; ID < Labels.Length; ID++)
		{
			if (SlideOut[ID])
			{
				Transform obj2 = Labels[ID];
				Vector3 localPosition3 = obj2.localPosition;
				localPosition3.x += localPosition3.x * 0.01f;
				obj2.localPosition = localPosition3;
			}
		}
		if (SlideID > Labels.Length + 1)
		{
			Color color = LinkLabel.color;
			color.a += Time.deltaTime;
			LinkLabel.color = color;
		}
		if (SlideID > Labels.Length + 2)
		{
			Color color2 = Yuno1.color;
			color2.a += Time.deltaTime;
			Yuno1.color = color2;
		}
		if (SlideID > Labels.Length + 3)
		{
			Color color3 = Yuno2.color;
			color3.a += Time.deltaTime;
			Yuno2.color = color3;
			Vector3 localScale = Yuno2.transform.localScale;
			localScale.x += Time.deltaTime * 0.1f;
			localScale.y += Time.deltaTime * 0.1f;
			Yuno2.transform.localScale = localScale;
		}
	}
}
