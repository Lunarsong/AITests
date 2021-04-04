using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FloatingTextSystem : MonoBehaviour
{
    public TMPro.TextMeshPro TextMesh;
    class TextItem
    {
        public float Duration;
        public float Timer;
        public GameObject GameObject;
        public TMPro.TextMeshPro Mesh;
    }
    List<TextItem> m_Items = new List<TextItem>();
    
    void Update()
    {
        Vector3 lookDirection = GetTextLookDirection();
        float deltaTime = Time.deltaTime;
        for (int i = 0; i < m_Items.Count; ++i)
        {
            TextItem item = m_Items[i];
            item.Timer += deltaTime;
            item.GameObject.transform.rotation = Quaternion.LookRotation(lookDirection);
            if (item.Timer >= item.Duration)
            {
                GameObject.Destroy(item.GameObject);
                m_Items.RemoveAt(i--);
            }
        }
    }

    public void Add(string text, Vector3 position, float duration = 2.0f)
    {
        TextItem item = new TextItem();
        item.Mesh = GameObject.Instantiate(TextMesh);
        item.Mesh.text = text;
        item.GameObject = item.Mesh.gameObject;
        item.Duration = duration;
        m_Items.Add(item);
        item.GameObject.transform.localPosition = position;
        item.GameObject.transform.rotation = Quaternion.LookRotation(GetTextLookDirection());
    }

    public void Add(string text, GameObject parent, float duration = 2.0f)
    {
        Vector3 pos = GetBoundsOffset(parent);
        TextItem item = new TextItem();
        item.Mesh = GameObject.Instantiate(TextMesh);
        item.Mesh.text = text;
        item.GameObject = item.Mesh.gameObject;
        item.Duration = duration;
        m_Items.Add(item);
        
        item.GameObject.transform.SetParent(parent.transform);
        item.GameObject.transform.localPosition = pos;
        item.GameObject.transform.rotation = Quaternion.LookRotation(GetTextLookDirection());


    }

    Vector3 GetBoundsOffset(GameObject gameObject)
    {
        MeshFilter parentMesh = gameObject.GetComponent<MeshFilter>();
        if (parentMesh != null)
        {
            return GetBoundsOffset(parentMesh.mesh.bounds);
        }
        Collider parentCollider = gameObject.GetComponent<Collider>();
        if (parentCollider != null)
        {
            return GetBoundsOffset(parentCollider.bounds);
        }
        return Vector3.zero;
    }

    Vector3 GetBoundsOffset(Bounds bounds)
    {
        return new Vector3(0.0f, bounds.extents.y) + Vector3.up * 0.2f;
    }

    Vector3 GetTextLookDirection()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();
        return cameraForward;
    }
}
