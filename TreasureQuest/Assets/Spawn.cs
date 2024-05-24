using UnityEngine;
using System.Collections.Generic;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Oluşturulacak obje prefablarının listesi
    public int numberOfObjectsPerPrefab = 5; // Her prefab için oluşturulacak obje sayısı
    public float minX, maxX, minY, maxY; // Rastgele konum aralıkları
    private List<Vector3> objectPositions = new List<Vector3>(); // Oluşturulan objelerin konumlarını saklamak için liste

    void Start()
    {
        foreach (GameObject prefab in objectPrefabs)
        {
            for (int i = 0; i < numberOfObjectsPerPrefab; i++)
            {
                // Rastgele konum seç
                float randomX = Random.Range(minX, maxX);
                float randomY = Random.Range(minY, maxY);
                Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

                // Aynı konumda başka bir obje varsa yeni bir konum seç
                while (IsOverlapping(randomPosition))
                {
                    randomX = Random.Range(minX, maxX);
                    randomY = Random.Range(minY, maxY);
                    randomPosition = new Vector3(randomX, randomY, 0f);
                }

                // Klon objeyi oluştur ve konumunu ayarla
                GameObject newObj = Instantiate(prefab, randomPosition, Quaternion.identity);

                // Oluşturulan objenin konumunu listeye ekle
                objectPositions.Add(randomPosition);
            }
        }
    }

    // Verilen konumun başka bir obje ile örtüşüp örtüşmediğini kontrol eden metod
    bool IsOverlapping(Vector3 position)
    {
        foreach (Vector3 objPos in objectPositions)
        {
            if (Vector3.Distance(position, objPos) < 3f) // Örtüşme sınırı, ihtiyaca göre ayarlanabilir
            {
                return true; // Örtüşme varsa true döndür
            }
        }
        return false; // Örtüşme yoksa false döndür
    }
}