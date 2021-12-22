using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000515 RID: 1301
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x0600213C RID: 8508 RVA: 0x001E65B0 File Offset: 0x001E47B0
		private void Awake()
		{
			if (this.MyProfile != null)
			{
				if (this.NameLabel != null)
				{
					this.NameLabel.text = this.MyProfile.FirstName + " " + this.MyProfile.LastName;
				}
				if (this.TagLabel != null)
				{
					this.TagLabel.text = this.MyProfile.GetTag(true);
				}
				if (this.ProfilPictureTexture != null)
				{
					this.ProfilPictureTexture.mainTexture = this.MyProfile.ProfilePicture;
				}
				if (this.StatusTexture != null)
				{
					this.StatusTexture.mainTexture = this.GetStatusTexture(this.MyProfile.CurrentStatus);
				}
				base.gameObject.name = this.MyProfile.FirstName + "_Profile";
				return;
			}
			Debug.LogError("[ChatPartnerScript] MyProfile wasn't assgined!");
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x0600213D RID: 8509 RVA: 0x001E66B0 File Offset: 0x001E48B0
		private Texture2D GetStatusTexture(Status currentStatus)
		{
			switch (currentStatus)
			{
			case Status.Online:
				return this.StatusTextures[1];
			case Status.Idle:
				return this.StatusTextures[2];
			case Status.DontDisturb:
				return this.StatusTextures[3];
			case Status.Invisible:
				return this.StatusTextures[4];
			default:
				return null;
			}
		}

		// Token: 0x040048DB RID: 18651
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040048DC RID: 18652
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040048DD RID: 18653
		public UILabel TagLabel;

		// Token: 0x040048DE RID: 18654
		public UITexture ProfilPictureTexture;

		// Token: 0x040048DF RID: 18655
		public UITexture StatusTexture;

		// Token: 0x040048E0 RID: 18656
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
