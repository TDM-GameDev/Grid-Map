using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputController : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase replacementTile;
    // [SerializeField] private TilemapRenderer tilemapRenderer;

    public static InputController Instance;

    public Vector2 ClickPosition => clickPosition;

    private PlayerControls playerControls;
    private Vector2 clickPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        playerControls.TilemapInteraction.MouseClick.performed += _ => OnClick();
    }

    private void OnClick()
    {
        clickPosition = playerControls.TilemapInteraction.MousePosition.ReadValue<Vector2>();
        Vector3Int gridPosition = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(clickPosition));
        // Debug.Log(gridPosition);
        if (tilemap.HasTile(gridPosition))
        {
            // Debug.Log($"{gridPosition} has a tile");
            TileBase originaltile = tilemap.GetTile(gridPosition);
            tilemap.SetTile(gridPosition, replacementTile);
        }
    }
}
