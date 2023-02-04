using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
	public TextureCycleScript TextureCycle;

	public Transform Yandere;

	public UITexture Static;

	public UILabel Label;

	public float Intensity;

	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			Label.text = "No...I must complete my mission.";
		}
	}

	private void Update()
	{
		float z = Yandere.position.z;
		if (z < -94f)
		{
			Intensity = -95f + Mathf.Abs(z);
			TextureCycle.gameObject.SetActive(value: true);
			TextureCycle.Sprite.enabled = true;
			TextureCycle.enabled = true;
			Color color = Static.color + new Color(0.0001f, 0.0001f, 0.0001f, 0.0001f);
			Color color2 = Label.color;
			color.a = Intensity / 5f;
			color2.a = Intensity / 5f;
			Static.color = color;
			Label.color = color2;
			GetComponent<AudioSource>().volume = Intensity / 5f * 0.1f;
			Vector3 localPosition = Label.transform.localPosition;
			localPosition.x = Random.Range(-10f, 10f);
			localPosition.y = Random.Range(-10f, 10f);
			Label.transform.localPosition = localPosition;
		}
		else if (TextureCycle.enabled)
		{
			TextureCycle.gameObject.SetActive(value: false);
			TextureCycle.Sprite.enabled = false;
			TextureCycle.enabled = false;
			Color color3 = Static.color;
			Color color4 = Label.color;
			color3.a = 0f;
			color4.a = 0f;
			Static.color = color3;
			Label.color = color4;
			GetComponent<AudioSource>().volume = 0f;
		}
	}
}
