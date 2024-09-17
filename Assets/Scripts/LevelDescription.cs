namespace Data
{
    using System.Xml.Serialization;
    using UnityEngine;
    public class LevelDescription
    {
        [XmlAttribute] public string  Name;
        [XmlAttribute] public float  Duration;

        [XmlElement("EnemyDescription")] public EnemyDescription[] Enemies;
    }

    public class EnemyDescription{
        [XmlElement] public float SpawnDate;
        [XmlElement] public Vector2 SpawnPosition;
        [XmlElement] public string PrefabPath;
    }

}

