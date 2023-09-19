using UnityEngine;
public class Touch_Input_Handler : MonoBehaviour
{
    [Header("Mouse Inputs")]
    [SerializeField] private Vector2 TouchStart;
    [SerializeField] private Vector2 TouchEnd;

    [Header("Minimum Distance for Input Action")]
    [SerializeField] private float minDistance = 50f;

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
            CreateTile();
            DecideInputAction();
            
        }
    }
    private void CreateTile()
    {
        Tile_Manager.Instance.RandomlyAssignATile();
    }
    private void DecideInputAction()
    {
        Vector2 NewVector = TouchStart - TouchEnd;
        float distance = NewVector.magnitude;

        //Debug.Log(distance);
        //Debug.Log(NewVector);

        if(distance < minDistance) // if the distance requirement is not met return early //
        {
            Debug.Log("Minimum distance requirement is not met; Current minimum distance is: "+minDistance+" !"); // Warn the developer about the min distance //
            return;
        }

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
