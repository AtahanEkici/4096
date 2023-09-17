using UnityEngine;
public class Touch_Input_Handler : MonoBehaviour
{
    [Header("Mouse Inputs")]
    [SerializeField] private Vector2 TouchStart;
    [SerializeField] private Vector2 TouchEnd;

    private void Update()
    {
        RecognizeInput();
    }
    private void RecognizeInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TouchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            TouchEnd = Input.mousePosition;
            DecideInputAction();
        }
    }
    private void DecideInputAction()
    {
        Vector2 NewVector = TouchStart - TouchEnd;
        //Debug.Log(NewVector);

        float x_value = NewVector.x;
        float y_value = NewVector.y;

        bool X_value_Is_Bigger = Mathf.Abs(x_value) > Mathf.Abs(y_value);

        if (X_value_Is_Bigger) // if the x value is greater choose up or down if not choose left or right //
        {
            if (x_value > 0)
            {
                Debug.Log("Left");
            }
            else
            {
                Debug.Log("Right");
            }
        }
        else if(!X_value_Is_Bigger)
        {
            if (y_value > 0)
            {
                Debug.Log("Down");
            }
            else
            {
                Debug.Log("Up");
            }
        }

        
    }

    
}
