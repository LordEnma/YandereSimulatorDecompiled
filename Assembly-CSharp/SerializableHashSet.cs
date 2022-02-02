using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004A8 RID: 1192
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F61 RID: 8033 RVA: 0x001B9098 File Offset: 0x001B7298
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F62 RID: 8034 RVA: 0x001B90AC File Offset: 0x001B72AC
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F63 RID: 8035 RVA: 0x001B910C File Offset: 0x001B730C
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F64 RID: 8036 RVA: 0x001B9148 File Offset: 0x001B7348
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F65 RID: 8037 RVA: 0x001B914C File Offset: 0x001B734C
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Element");
			T item = (T)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(item);
			reader.MoveToContent();
		}
	}

	// Token: 0x06001F66 RID: 8038 RVA: 0x001B91B0 File Offset: 0x001B73B0
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		foreach (T t in this)
		{
			writer.WriteStartElement("Element");
			xmlSerializer.Serialize(writer, t);
			writer.WriteEndElement();
		}
	}

	// Token: 0x0400416F RID: 16751
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004170 RID: 16752
	private const string XML_Element = "Element";
}
