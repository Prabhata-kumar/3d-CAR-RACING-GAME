using UnityEngine;

public class PlatformColour : MonoBehaviour
{
    /*MeshRenderer cubeMeshRender;
    float LearpTime = 10f;
    [SerializeField] Color[] MyColours;
    int ColourIndex = 0;
    int t = 0;
    float speed = 6f;
    void Start()
    {
        cubeMeshRender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        cubeMeshRender.material.color = Color.Lerp(cubeMeshRender.material.color, MyColours[ColourIndex], LearpTime * Time.deltaTime);
        t = (int)Mathf.Lerp(t, 0f, LearpTime * Time.deltaTime);
        if (t > 0.9f)
        {
            t = (int)0f;
            ColourIndex++;
            ColourIndex = (ColourIndex >= MyColours.Length) ? 0 : ColourIndex;
        }
        
    }*/

    public float speed = 1.0f;
    public Color startColor;
    public Color endColor;
    public bool repeatable = false;
    float startTime;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!repeatable)
        {
            float t = (Time.time - startTime) * speed;
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
        }
        else
        {
            float t = (Mathf.Sin(Time.time - startTime) * speed);
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
        }

        transform.Rotate(new Vector3(0f, 1f, 0f)  * Time.fixedTime);
    }
}
