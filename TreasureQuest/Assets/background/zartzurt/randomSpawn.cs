using UnityEngine;

public class MultipleObjectPlacer : MonoBehaviour
{
    public GameObject prefab; // Oluşturulacak objenin prefabı
    public int numberOfObjects = 5; // Oluşturulacak obje sayısı
    public float minX = -10f; // X ekseninin minimum değeri
    public float maxX = 10f;  // X ekseninin maksimum değeri
    public float minY = -5f;  // Y ekseninin minimum değeri
    public float maxY = 5f;   // Y ekseninin maksimum değeri

    void Start()
    {
        /*Grid grid = GetComponent<Grid>();
        int value = grid.mapSize;
        minX = -(value /2);
        maxX = value /2;
        
        minY = -(value /2);
        maxY = value /2;*/
        
        PlaceMultipleObjects();
    }

    void PlaceMultipleObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // X ve Y eksenlerinde rastgele konum seç
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            // Prefabı klonla ve konumunu güncelle
            GameObject newObj = Instantiate(prefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);

            // Klonlanan objeyi sahneye ekle
            newObj.transform.parent = transform;
        }
    }
}