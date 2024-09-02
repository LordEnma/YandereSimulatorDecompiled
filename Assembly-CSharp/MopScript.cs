using UnityEngine;

public class MopScript : MonoBehaviour
{
	public ParticleSystem Sparkles;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public PickUpScript PickUp;

	public Collider HeadCollider;

	public AudioSource MyAudio;

	public Vector3 Rotation;

	public Renderer Blood;

	public Transform Head;

	public float Bloodiness;

	public int StudentBloodID;

	public bool Bleached;

	private void Start()
	{
		Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		MyAudio = GetComponent<AudioSource>();
		HeadCollider.enabled = false;
		UpdateBlood();
	}

	private void Update()
	{
		if (Prompt.PauseScreen.Show)
		{
			return;
		}
		if (Yandere.PickUp == PickUp)
		{
			if (Prompt.HideButton[0])
			{
				Prompt.HideButton[0] = false;
				Prompt.HideButton[3] = true;
				Yandere.Mop = this;
			}
			if (Yandere.Bucket == null)
			{
				if (Bleached)
				{
					Prompt.HideButton[0] = false;
					if (Prompt.Button[0].color.a > 0f)
					{
						Prompt.Label[0].text = "     Sweep";
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							Yandere.Mopping = true;
							HeadCollider.enabled = true;
						}
					}
				}
				else
				{
					Prompt.Label[0].text = "     Dip In Bucket First!";
					Prompt.HideButton[0] = false;
				}
			}
			else if (Prompt.Button[0].color.a > 0f && !Yandere.Chased && Yandere.Chasers == 0)
			{
				if (Yandere.Bucket.Full)
				{
					if (!Yandere.Bucket.Gasoline && !Yandere.Bucket.DyedBrown)
					{
						if (Yandere.Bucket.Bleached)
						{
							if (Yandere.Bucket.Bloodiness < 100f)
							{
								Prompt.Label[0].text = "     Dip";
								if (Input.GetButtonDown(InputNames.Xbox_A))
								{
									if (Yandere.Bucket.transform.position.y < Yandere.transform.position.y + 0.1f)
									{
										Dip();
									}
									else
									{
										Debug.Log("Cannot Dip Now.");
										Yandere.NotificationManager.CustomText = "Lower Bucket First";
										Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
									}
								}
							}
							else
							{
								Prompt.Label[0].text = "     Water Too Bloody!";
							}
						}
						else
						{
							Prompt.Label[0].text = "     Add Bleach First!";
						}
					}
					else if (Yandere.Bucket.Gasoline)
					{
						Prompt.Label[0].text = "     Can't Use Gasoline!";
					}
					else
					{
						Prompt.Label[0].text = "     Can't Use Brown Paint!";
					}
				}
				else
				{
					Prompt.Label[0].text = "     Fill Bucket First!";
				}
			}
			if (Yandere.Mopping)
			{
				Head.LookAt(Head.position + Vector3.down);
				Head.localEulerAngles = new Vector3(Head.localEulerAngles.x + 90f, Head.localEulerAngles.y, 180f);
				if (!MyAudio.isPlaying)
				{
					MyAudio.Play();
				}
			}
			else
			{
				Rotation = Vector3.Lerp(Head.localEulerAngles, Vector3.zero, Time.deltaTime * 10f);
				Head.localEulerAngles = Rotation;
				MyAudio.Stop();
			}
		}
		else
		{
			Prompt.HideButton[0] = true;
			Prompt.HideButton[3] = false;
			if (Yandere.Mop == this)
			{
				Yandere.Mop = null;
			}
		}
		if (!Yandere.Mopping && HeadCollider.enabled)
		{
			HeadCollider.enabled = false;
		}
	}

	public void UpdateBlood()
	{
		if (Bloodiness > 100f)
		{
			Bloodiness = 100f;
			Sparkles.Stop();
			Bleached = false;
		}
		Blood.material.color = new Color(Blood.material.color.r, Blood.material.color.g, Blood.material.color.b, Bloodiness / 100f * 0.9f);
	}

	public void Dip()
	{
		Yandere.YandereVision = false;
		Yandere.CanMove = false;
		Yandere.Dipping = true;
		Prompt.Hide();
		Prompt.enabled = false;
	}
}
