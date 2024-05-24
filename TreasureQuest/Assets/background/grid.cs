
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] GameObject greenGridPrefab; // Yeşil gridPrefab
    [SerializeField] GameObject whiteGridPrefab; // Beyaz gridPrefab
    [SerializeField] float gridSize = 1f;
    [SerializeField] int mapSize = 10;
   

    void Start()
    {

        mapSize=mapSize*2;
        // Haritanın orta noktasını hesapla
        Vector3 mapCenter = new Vector3((mapSize - 1) * gridSize / 2, (mapSize - 1) * gridSize / 2, 0f);

        for (int i = 0; i < mapSize; i++)
        {
            for (int y = 0; y < mapSize; y++)
            {
                GameObject gridPrefab; // İstenilen renkte gridPrefab seçmek için değişken

                // Grid'in pozisyonunu hesapla
                float xPosition = i * gridSize - mapCenter.x; // Orta noktadan uzaklık
                float yPosition = y * gridSize - mapCenter.y; // Orta noktadan uzaklık

                if (xPosition < 0) // Sol taraf
                {
                    gridPrefab = greenGridPrefab; // Yeşil gridPrefab'i seç
                }
                else // Sağ taraf
                {
                    gridPrefab = whiteGridPrefab; // Beyaz gridPrefab'i seç
                }

                // GridPrefab'i instantiate et ve pozisyonunu ayarla
                GameObject grid = Instantiate(gridPrefab, new Vector3(xPosition, yPosition, 0f), Quaternion.identity);
                grid.transform.SetParent(transform); // Grid'in alt nesnesi olarak ekleyerek hiyerarşiyi düzenler

                // Kamerayı haritanın tam ortasına konumlandır
                if (i == mapSize / 2 && y == mapSize / 2)
                {
                    Camera.main.transform.position = new Vector3(xPosition, yPosition, Camera.main.transform.position.z);
                }
            }
        }
    }
}
