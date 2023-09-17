using TMPro;
using UnityEngine;
public class Tile : MonoBehaviour
{
    public bool isOccupied = false;

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
    public void CheckOccupation()
    {
        if(isOccupied)
        {

        }
        else
        {
            _renderer.color = Color.grey;
        }
    }
}
