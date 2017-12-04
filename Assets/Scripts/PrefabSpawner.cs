using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{

    public GameObject[] prefabs;
    public int count;
    public int fixedGlauqueStep = 0;
    public bool autoGlauque = false;

    private void Awake()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        float radius = collider.radius;
        Vector2 scale = new Vector2(radius, radius);
        Destroy(collider);

        for (int i = 0; i < count; i++)
        {
            Vector2 pos = Random.insideUnitCircle;
            Vector2 scaledPos = new Vector2(pos.x, pos.y);
            scaledPos.Scale(scale);

            GameObject prefab = Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(scaledPos.x, scaledPos.y, 0f), Quaternion.identity) as GameObject;
            prefab.transform.SetParent(gameObject.transform, false);
            prefab.tag = gameObject.tag;

            GlauqueEntity ge = prefab.GetComponent<GlauqueEntity>();
            if (ge != null)
            {
                int step = fixedGlauqueStep;
                if (autoGlauque)
                {
                    int steps = ge.steps.Length;
                    step = Mathf.FloorToInt(pos.magnitude * steps);
                }
                ge.SetStep(step);
            }
        }

        gameObject.tag = "Untagged";
    }

}
