using System.Collections.Generic;
using UnityEngine;
public class Grid_Manager : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;

    private void Awake()
    {
        if(_cam == null)
        {
            _cam = Camera.main.transform;
        }
    }

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        GameObject baseObject = new("Tiles");

        _tiles = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.GetComponent<Tile>().CheckOccupation();

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);

                _tiles[new Vector2(x, y)] = spawnedTile;
                spawnedTile.transform.SetParent(baseObject.transform);
            }
        }
        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}
