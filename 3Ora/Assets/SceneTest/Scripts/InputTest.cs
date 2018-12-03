using UnityEngine;

public class InputTest : MonoBehaviour
{
    public float Min = 0;
    public float Max = 2;


    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Debug.Log((int)horizontal);
        Debug.Log((int)vertical);
        
        Clamp(horizontal);
    }

    void Clamp(float value)
    {
        var clampedValue = Mathf.Clamp(value, Min, Max);
        Debug.Log("Clamped Value: " + (int)clampedValue);
    }
}