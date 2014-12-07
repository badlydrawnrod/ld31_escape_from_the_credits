using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;


public class Populator2 : MonoBehaviour
{
    public Transform collectablePrefab;
    public Transform actorRolePrefab;
    public Transform jobTitlePrefab;
    public Transform bigCentrePrefab;
    public Transform leftPrefab;
    public Transform centrePrefab;
    public Transform rightPrefab;
    public Transform titlePrefab;
    public Transform winPrefab;
    public TextAsset creditResource;

    private IEnumerator<XmlNode> credits;
    private float y;
    private Transform platform;
    private bool first;

    void Awake()
    {
        first = true;
        y = 40;
        platform = null;
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(creditResource.text);
        Process(0, doc.DocumentElement);
    }

    private float Process(float x, XmlNode credit)
    {
        if (credit.Name == "credits")
        {
            y -= 36;
            x = 0;
            platform = Instantiate(bigCentrePrefab, new Vector3(x, y, 0), Quaternion.identity) as Transform;
            platform.SetParent(transform, false);
            platform.GetComponentInChildren<Text>().text = credit.Attributes.GetNamedItem("title").Value;
            y -= 72;
        }
        else if (credit.Name == "section")
        {
            y -= 24;
            x = 0;
            platform = Instantiate(titlePrefab, new Vector3(x, y, 0), Quaternion.identity) as Transform;
            platform.SetParent(transform, false);
            platform.GetComponentInChildren<Text>().text = credit.Attributes.GetNamedItem("title").Value;
            y -= 48;
        }
        else if (credit.Name == "role")
        {
            y -= 12;
            x = -30;
            platform = Instantiate(rightPrefab, new Vector3(x, y, 0), Quaternion.identity) as Transform;
            platform.SetParent(transform, false);
            platform.GetComponentInChildren<Text>().text = credit.Attributes.GetNamedItem("actor").Value;
            x = 30;
            platform = Instantiate(actorRolePrefab, new Vector3(x, y, 0), Quaternion.identity) as Transform;
            platform.SetParent(transform, false);
            platform.GetComponentInChildren<Text>().text = credit.Attributes.GetNamedItem("role").Value;
            y -= 36;
        }
        else if (credit.Name == "job")
        {
            y -= 12;
            x = -20 - 90;
            platform = Instantiate(jobTitlePrefab, new Vector3(x, y, 0), Quaternion.identity) as Transform;
            platform.SetParent(transform, false);
            platform.GetComponentInChildren<Text>().text = credit.Attributes.GetNamedItem("title").Value;
        }
        else if (credit.Name == "name")
        {
            x = 20 + 90;
            platform = Instantiate(leftPrefab, new Vector3(x, y, 0), Quaternion.identity) as Transform;
            platform.SetParent(transform, false);
            platform.GetComponentInChildren<Text>().text = credit.InnerText;
            y -= 36;
        }
        else if (credit.Name == "triple")
        {
            y -= 12;
            x = -60;
            platform = Instantiate(centrePrefab, new Vector3(x, y, 0), Quaternion.identity) as Transform;
            platform.SetParent(transform, false);
            platform.GetComponentInChildren<Text>().text = credit.Attributes.GetNamedItem("a").Value;

            x = 0;
            platform = Instantiate(centrePrefab, new Vector3(x, y, 0), Quaternion.identity) as Transform;
            platform.SetParent(transform, false);
            platform.GetComponentInChildren<Text>().text = credit.Attributes.GetNamedItem("b").Value;

            x = 60;
            platform = Instantiate(centrePrefab, new Vector3(x, y, 0), Quaternion.identity) as Transform;
            platform.SetParent(transform, false);
            platform.GetComponentInChildren<Text>().text = credit.Attributes.GetNamedItem("c").Value;

            y -= 36;
        }
        else if (credit.Name == "single")
        {
            y -= 12;
            x = 0;
            platform = Instantiate(centrePrefab, new Vector3(x, y, 0), Quaternion.identity) as Transform;
            platform.SetParent(transform, false);
            platform.GetComponentInChildren<Text>().text = credit.InnerText;

            y -= 36;
        }
        else if (credit.Name == "win")
        {
            y -= 12;
            x = 0;
            platform = Instantiate(winPrefab, new Vector3(x, y, 0), Quaternion.identity) as Transform;
            platform.SetParent(transform, false);

            y -= 72;
        }

        CheckCollectable(credit);

        if (credit.Name != "name" && credit.Name != "single")
        {
            foreach (XmlNode node in credit.ChildNodes)
            {
                Process(0, node);
            }
        }

        return x;
    }

    private void CheckCollectable(XmlNode credit)
    {
        if (first)
        {
            first = false;
            return;
        }
        if (Random.value < 0.75f)
        {
            var sprite = platform.GetComponentInChildren<SpriteRenderer>() as SpriteRenderer;
            float x = Random.Range(-50.0f, 50.0f);
            float y = sprite.transform.position.y + Random.Range(16.0f, 32.0f);
            Transform t = Instantiate(collectablePrefab, new Vector3(x, y, 0), Quaternion.identity) as Transform;
            t.SetParent(platform, true);
        }
    }
}
