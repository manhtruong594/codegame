using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] List<Transform> BGs = new List<Transform>();
    [SerializeField] List<float> Speeds = new List<float>();

    Vector2 _parallax = Vector2.zero;
    Vector2 periousCamPos;

    // Start is called before the first frame update
    void Start()
    {
        periousCamPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _parallax = (Vector2)Camera.main.transform.position - periousCamPos;
        for(int i = 0; i < BGs.Count; i++)
        {
            if (BGs == null)
                continue;

            Vector2 pos = (Vector2)BGs[i].position + _parallax;

            BGs[i].position = Vector3.Lerp(BGs[i].position, pos, Speeds[i] * Time.deltaTime);

        }

        periousCamPos = Camera.main.transform.position;
    }
}
