using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004A8 RID: 1192
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F5F RID: 8031 RVA: 0x001B8B70 File Offset: 0x001B6D70
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F60 RID: 8032 RVA: 0x001B8B84 File Offset: 0x001B6D84
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F61 RID: 8033 RVA: 0x001B8BE4 File Offset: 0x001B6DE4
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F62 RID: 8034 RVA: 0x001B8C20 File Offset: 0x001B6E20
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F63 RID: 8035 RVA: 0x001B8C24 File Offset: 0x001B6E24
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

	// Token: 0x06001F64 RID: 8036 RVA: 0x001B8C88 File Offset: 0x001B6E88
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

	// Token: 0x04004167 RID: 16743
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004168 RID: 16744
	private const string XML_Element = "Element";
}
