using System.Collections;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 upPos;
    private Vector3 downPos;
    private bool movingUp = true;

    public float moveDistance = 5f;
    public float speed = 3f;

    private void Start()
    {
        startPos = transform.position;
        upPos = startPos + Vector3.up * moveDistance;
        downPos = startPos - Vector3.up * moveDistance;

        StartCoroutine(MoveBird());
    }

    private IEnumerator MoveBird()
    {
        while (true)
        {
            Vector3 targetPos = movingUp ? upPos : downPos;
            while (transform.position != targetPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                yield return null;
            }

            movingUp = !movingUp;
            yield return new WaitForSeconds(1f);
        }
    }
}
