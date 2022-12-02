using UnityEngine;

namespace YandereSimulator.Yancord
{
	public class MessageScript : MonoBehaviour
	{
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		[Space(20f)]
		public UILabel NameLabel;

		public UILabel MessageLabel;

		public UITexture ProfilPictureTexture;

		public void Awake()
		{
			if (MyProfile != null)
			{
				if (NameLabel != null)
				{
					NameLabel.text = MyProfile.FirstName + " " + MyProfile.LastName;
				}
				if (ProfilPictureTexture != null)
				{
					ProfilPictureTexture.mainTexture = MyProfile.ProfilePicture;
				}
				base.gameObject.name = MyProfile.FirstName + "_Message";
			}
		}
	}
}
