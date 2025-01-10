using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class DynamicGrid : MonoBehaviour
{
    public GameObject prefab; // The prefab to instantiate
    public RectTransform panel; // The panel containing the prefabs
    public int numberOfPrefabs; // Number of prefabs to display
    public Vector2 padding = new Vector2(10, 10); // Padding around the panel
    public Vector2 spacing = new Vector2(5, 5); // Spacing between cells

    private GridLayoutGroup grid;
    private Vector2 lastPanelSize;

    void Start()
    {
        grid = panel.GetComponent<GridLayoutGroup>();
        if (grid == null)
        {
            Debug.LogError("Panel must have a GridLayoutGroup component.");
            return;
        }

        GeneratePrefabs();
    }

    void Update()
    {
        // Check if the panel size has changed
        if (panel.rect.size != lastPanelSize)
        {
            lastPanelSize = panel.rect.size;
            UpdateGridLayout();
        }
    }

    void GeneratePrefabs()
    {
        // Clear previous prefabs
        foreach (Transform child in panel)
        {
            Destroy(child.gameObject);
        }

        // Instantiate new prefabs
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            GameObject instance = Instantiate(prefab, panel);
            // Example: Set text or identifier
            // instance.GetComponentInChildren<Text>().text = (i + 1).ToString();
        }

        UpdateGridLayout();
    }

    void UpdateGridLayout()
    {
        if (grid == null) return;

        // Calculate panel dimensions minus padding
        float panelWidth = panel.rect.width - padding.x * 2;
        float panelHeight = panel.rect.height - padding.y * 2;

        // Determine the number of rows and columns
        int columns = Mathf.CeilToInt(Mathf.Sqrt(numberOfPrefabs));
        int rows = Mathf.CeilToInt((float)numberOfPrefabs / columns);

        // Calculate cell size
        float cellWidth = (panelWidth - (columns - 1) * spacing.x) / columns;
        float cellHeight = (panelHeight - (rows - 1) * spacing.y) / rows;

        // Update GridLayoutGroup properties
        grid.cellSize = new Vector2(cellWidth, cellHeight);
        grid.spacing = spacing;
        grid.padding = new RectOffset((int)padding.x, (int)padding.x, (int)padding.y, (int)padding.y);
    }
}
