using System.Collections.Generic;
using UnityEngine;
public class Tile_Manager : MonoBehaviour
{
    public readonly static int Total_Number_Of_Tiles = 16;

    [Header("Tiles ArrayList")]
    [SerializeField] private List<Tile> Tiles = new();
    [SerializeField] private List<Tile> Empty_Tiles = new();

    private static Tile_Manager _instance;
    public static Tile_Manager Instance => _instance;

    private void Awake()
    {
        InitializeArrayList();
        CheckInstance();
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
            //DontDestroyOnLoad(gameObject);
        }
    }
    private void InitializeArrayList()
    {
        if (Tiles == null)
        {
            Tiles = new();
        }
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

        Empty_Tiles[Random_Number].ChangeNumberText(2.ToString());

        GetEmptyTiles();
    }
}
