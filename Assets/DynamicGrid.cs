using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class DynamicGrid : MonoBehaviour
{
    public GameObject prefab; // The prefab to instantiate
    public RectTransform panel; // The panel containing the prefabs
    public int numberOfShips; // Number of prefabs to display
    public Vector2 padding = new Vector2(10, 10); // Padding around the panel
    public Vector2 spacing = new Vector2(5, 5); // Spacing between cells

    public RectTransform mainPanel; // The main panel to instantiate the no ships text

    public TextMeshProUGUI noShipsText;

    private GridLayoutGroup grid;
    private Vector2 lastPanelSize;

 
    void Update()
    {
        // Check if the panel size has changed
        if (panel.rect.size != lastPanelSize)
        {
            lastPanelSize = panel.rect.size;
            UpdateGridLayout();
        }
    }

    public void GeneratePrefabs(ShipsInLaunch ships)
    {
        grid = panel.GetComponent<GridLayoutGroup>();
        // Clear previous prefabs
        foreach (Transform child in panel)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in mainPanel)
        {
            Destroy(child.gameObject);
        }

        this.numberOfShips = ships.getShipsInLaunch().Count;
        if (this.numberOfShips == 0)
        {
            TextMeshProUGUI noShipsFound = Instantiate(noShipsText, mainPanel);
            noShipsFound.text = "No ships involved in this launch...";
        }

        // Instantiate new prefabs
        for (int i = 0; i < numberOfShips; i++)
        {
            GameObject instance = Instantiate(prefab, panel);
            // Example: Set text or identifier
            String info = ships.getShipInfoToDisplay(i);
            
            TextMeshProUGUI infoText = instance.GetComponentInChildren<TextMeshProUGUI>();
            
            infoText.text = info;
            
            if (this.numberOfShips > 4) {
                infoText.enableAutoSizing = false;
                infoText.fontSize = 14;

            }
            else {
                infoText.enableAutoSizing = true;
            }
            
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
        int columns = Mathf.CeilToInt(Mathf.Sqrt(numberOfShips));
        int rows = Mathf.CeilToInt((float)numberOfShips / columns);

        // Calculate cell size
        float cellWidth = (panelWidth - (columns - 1) * spacing.x) / columns;
        float cellHeight = (panelHeight - (rows - 1) * spacing.y) / rows;

        // Update GridLayoutGroup properties
        grid.cellSize = new Vector2(cellWidth, cellHeight);
        grid.spacing = spacing;
        grid.padding = new RectOffset((int)padding.x, (int)padding.x, (int)padding.y, (int)padding.y);
    }
}
