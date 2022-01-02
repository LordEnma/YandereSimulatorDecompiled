using System;
using System.Collections.Generic;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000515 RID: 1301
	public class ChatPartnerScript : MonoBehaviour
	{
		// Token: 0x0600213F RID: 8511 RVA: 0x001E6BA0 File Offset: 0x001E4DA0
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

		// Token: 0x06002140 RID: 8512 RVA: 0x001E6CA0 File Offset: 0x001E4EA0
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

		// Token: 0x040048E4 RID: 18660
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040048E5 RID: 18661
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040048E6 RID: 18662
		public UILabel TagLabel;

		// Token: 0x040048E7 RID: 18663
		public UITexture ProfilPictureTexture;

		// Token: 0x040048E8 RID: 18664
		public UITexture StatusTexture;

		// Token: 0x040048E9 RID: 18665
		[Space(20f)]
		public List<Texture2D> StatusTextures = new List<Texture2D>();
	}
}
