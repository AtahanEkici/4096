using UnityEngine;
using System.Collections.Generic;
public class Tile_Manager : MonoBehaviour
{
    public static readonly int Total_Number_Of_Tiles = 16;

    [Header("Tiles ArrayList")]
    [SerializeField] private List<Tile> Tiles = new();
    [SerializeField] private List<Tile> Empty_Tiles = new();

    private static Tile_Manager _instance;
    public static Tile_Manager Instance => _instance;

    private void Awake()
    {
        CheckInstance();
        InitializeLists();
    }
    private void CheckInstance()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void InitializeLists()
    {
        Tiles ??= new();
        Empty_Tiles ??= new();
    }
    public void GetTiles(Dictionary<Vector2, Tile> _tiles)
    {
        foreach (Tile tile in _tiles.Values)
        {
            Tiles.Add(tile);
        }
    }
    public void GetEmptyTiles()
    {
        Empty_Tiles.Clear();

        for (int i=0;i<Tiles.Count;i++)
        {
            if(Tiles[i].CheckOccupation() == false)
            {
                Empty_Tiles.Add(Tiles[i]);
            }
        }
    }
    public void RandomlyAssignATile()
    {
        GetEmptyTiles();

        if (Empty_Tiles.Count == 0)
        {
            Debug.Log("Game Over");
            return;
        }

        int Random_Number = Random.Range(0, Empty_Tiles.Count);

        Empty_Tiles[Random_Number].ChangeNumberText(2.ToString()); // issue a random number //

        GetEmptyTiles();
    }
    public void MoveTiles(Touch_Input_Handler.Directions direction)
    {
        if(direction == Touch_Input_Handler.Directions.LEFT)
        {

        }
        else if (direction == Touch_Input_Handler.Directions.RIGHT)
        {

        }
        else if (direction == Touch_Input_Handler.Directions.DOWN)
        {

        }
        else if (direction == Touch_Input_Handler.Directions.UP)
        {

        }
    }
}
