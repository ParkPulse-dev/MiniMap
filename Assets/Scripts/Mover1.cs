using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HeartBeat : MonoBehaviour
{
    public float minScaleFactor = 0.1f;
    public float maxScaleFactor = 1.3f;
    public float pulseSpeed = 1f;

    private bool isGrowing = true;
    private Vector3 initialScale;

    void Start()
    {
        // Save the initial scale for reference
        initialScale = transform.localScale;
    }

    void Update()
    {
        // Calculate the scaling factor based on time and speed
        float scaleChange = pulseSpeed * Time.deltaTime;

        // Determine whether to grow or shrink
        if (isGrowing)
        {
            transform.localScale += new Vector3(initialScale.x * scaleChange, initialScale.y * scaleChange, initialScale.z * scaleChange);

            // Switch to shrinking if reaching the maximum scale
            if (transform.localScale.x >= initialScale.x * maxScaleFactor)
            {
                transform.localScale = new Vector3(initialScale.x * maxScaleFactor, initialScale.y * maxScaleFactor, initialScale.z * maxScaleFactor);
                isGrowing = false;
            }
        }
        else
        {
            transform.localScale -= new Vector3(initialScale.x * scaleChange, initialScale.y * scaleChange, initialScale.z * scaleChange);

            // Switch to growing if reaching the minimum scale
            if (transform.localScale.x <= initialScale.x * minScaleFactor)
            {
                transform.localScale = new Vector3(initialScale.x * minScaleFactor, initialScale.y * minScaleFactor, initialScale.z * minScaleFactor);
                isGrowing = true;
            }
        }

        // Ensure the object stays in the same Y position
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
}










