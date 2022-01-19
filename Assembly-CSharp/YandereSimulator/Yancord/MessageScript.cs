using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051A RID: 1306
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x06002151 RID: 8529 RVA: 0x001E839C File Offset: 0x001E659C
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

		// Token: 0x04004905 RID: 18693
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004906 RID: 18694
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004907 RID: 18695
		public UILabel MessageLabel;

		// Token: 0x04004908 RID: 18696
		public UITexture ProfilPictureTexture;
	}
}
