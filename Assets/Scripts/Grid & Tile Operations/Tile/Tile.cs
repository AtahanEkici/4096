using TMPro;
using UnityEngine;
public class Tile : MonoBehaviour
{
    [SerializeField]private bool isOccupied = false;

    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private TextMeshPro Number_Text;
    private void Awake()
    {
        GetReferences();
    }
    private void GetReferences()
    {
        _renderer = GetComponent<SpriteRenderer>();
        Number_Text = GetComponentInChildren<TextMeshPro>();
    }
    public bool CheckOccupation()
    {
        if (Number_Text.text != string.Empty)
        {
            isOccupied = true;
            ChangeOccupation();
            return true;
        }
        else
        {
            isOccupied = false;
            ChangeOccupation();
            return false;
        }
    }
    public void ChangeOccupation()
    {
        if(isOccupied)
        {
            int current_number = int.Parse(Number_Text.text);

            switch (current_number)
            {
                case 32:
                    _renderer.color = Color.blue;
                    break;
                case 16:
                    _renderer.color = Color.red;
                    break;
                case 8:
                    _renderer.color = Color.green;
                    break;
                case 4:
                    _renderer.color = Color.yellow;
                    break;
                case 2:
                    _renderer.color = Color.white;
                    break;
                default:
                    _renderer.color = Color.grey;
                    break;
            }
        }
        else
        {
            _renderer.color = Color.grey;
        }
    }
    public void ChangeNumberText(string givenText)
    {
        Number_Text.text = givenText;
    }
}
