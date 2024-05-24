using System.Collections;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 rightPos;
    private Vector3 leftPos;
    private bool movingRight = true;

    public float speed = 3f;

    private void Start()
    {
        startPos = transform.position;
        rightPos = startPos + Vector3.right * 3;
        leftPos = startPos - Vector3.right * 3;

        StartCoroutine(MoveBee());
    }

    private IEnumerator MoveBee()
    {
        while (true)
        {
            Vector3 targetPos = movingRight ? rightPos : leftPos;
            while (transform.position != targetPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                yield return null;
            }

            Flip();
            movingRight = !movingRight;
            yield return new WaitForSeconds(1f);
        }
    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Haritanın sınırları
    private float minX = -10f;
    private float maxX = 10f;
    private float minY = -5f;
    private float maxY = 5f;

    private void RespawnBee()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        transform.position = new Vector3(randomX, randomY, 0f);
    }
}
