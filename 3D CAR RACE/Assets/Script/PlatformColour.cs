using UnityEngine;

public class PlatformColour : MonoBehaviour
{ 
    public float speed = 10f;
    public Color startColor;
    public Color endColor;
    public bool repeatable = false;
    float startTime;
    float PlatFormSpeed = 0.01f;

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

        transform.Rotate(new Vector3(0f, 1f, 0f),PlatFormSpeed * Time.fixedTime);
    }
}
