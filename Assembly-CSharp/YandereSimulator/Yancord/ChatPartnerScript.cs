using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	public class ChatPartnerScript : MonoBehaviour
	{
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		[Space(20f)]
		public UILabel NameLabel;

		public UILabel TagLabel;

		public UITexture ProfilPictureTexture;

		public UITexture StatusTexture;

		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();

		private void Awake()
		{
			if (MyProfile != null)
			{
				if (NameLabel != null)
				{
					NameLabel.text = MyProfile.FirstName + " " + MyProfile.LastName;
				}
				if (TagLabel != null)
				{
					TagLabel.text = MyProfile.GetTag(WithHashtag: true);
				}
				if (ProfilPictureTexture != null)
				{
					ProfilPictureTexture.mainTexture = MyProfile.ProfilePicture;
				}
				if (StatusTexture != null)
				{
					StatusTexture.mainTexture = GetStatusTexture(MyProfile.CurrentStatus);
				}
				base.gameObject.name = MyProfile.FirstName + "_Profile";
			}
			else
			{
				Debug.LogError("[ChatPartnerScript] MyProfile wasn't assgined!");
				Object.Destroy(base.gameObject);
			}
		}

		private Texture2D GetStatusTexture(Status currentStatus)
		{
			return currentStatus switch
			{
				Status.Online => StatusTextures[1], 
				Status.Idle => StatusTextures[2], 
				Status.DontDisturb => StatusTextures[3], 
				Status.Invisible => StatusTextures[4], 
				_ => null, 
			};
		}
	}
}
