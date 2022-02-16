using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051B RID: 1307
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x06002161 RID: 8545 RVA: 0x001E960C File Offset: 0x001E780C
		public void Awake()
		{
			if (this.MyProfile != null)
			{
				if (this.NameLabel != null)
				{
					this.NameLabel.text = this.MyProfile.FirstName + " " + this.MyProfile.LastName;
				}
				if (this.ProfilPictureTexture != null)
				{
					this.ProfilPictureTexture.mainTexture = this.MyProfile.ProfilePicture;
				}
				base.gameObject.name = this.MyProfile.FirstName + "_Message";
			}
		}

		// Token: 0x04004922 RID: 18722
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004923 RID: 18723
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004924 RID: 18724
		public UILabel MessageLabel;

		// Token: 0x04004925 RID: 18725
		public UITexture ProfilPictureTexture;
	}
}
