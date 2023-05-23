using System.Collections;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float minimumDistance = .2f;
    [SerializeField] private float maximumTime = 1f;
    [SerializeField, Range(0, 1)] private float directionThreshold = .9f;
    [SerializeField] private GameObject trail;
    [SerializeField] private float hitboxRadius = 0.1f;

    private Coroutine coroutine;

    private InputManager inputManager;

    private Vector2 startPosition;
    private float startTime;   
    private Vector2 endPosition;
    private float endTime;
    private Vector2 prevFramePos;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
        inputManager.OnTouchMove += SwipeMove;
    }    
    
    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
        inputManager.OnTouchMove -= SwipeMove;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;

        trail.transform.position = position;
        trail.SetActive(true);
        prevFramePos = position;

        coroutine =  StartCoroutine(Trail());
    }

    private IEnumerator Trail()
    {
        while (true)
        {
            trail.transform.position = inputManager.PrimaryPosition();
            yield return null;
        }
    }

    //private IEnumerator SwipeBetween()
    //{
    //    while (true)
    //    {
    //        if (inputManager.PrimaryDelta().magnitude >= minimumDistance)
    //        {
    //            Vector2 currentPosition = inputManager.PrimaryPosition();
    //            Debug.DrawLine(prevFramePos, currentPosition, Color.blue, 5f);
    //        }

    //        prevFramePos = inputManager.PrimaryPosition();
    //        yield return null;
    //    }
    //}

    public void SwipeMove(Vector2 position, float time)
    {
        if (inputManager.PrimaryDelta().magnitude >= minimumDistance)
        {
            Vector2 currentPosition = inputManager.PrimaryPosition();
            Debug.DrawLine(prevFramePos, currentPosition, Color.blue, 5f);

            Vector3 sphereStart = new Vector3(prevFramePos.x, prevFramePos.y, 0);
            Vector3 sphereDirection = new Vector3(currentPosition.x - prevFramePos.x, currentPosition.y - prevFramePos.y, 0);

            RaycastHit[] hits = Physics.SphereCastAll(sphereStart, hitboxRadius, sphereDirection, .5f);
            foreach (RaycastHit hit in hits)
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.CompareTag("Fruit"))
                {
                    hitObject.SetActive(false);
                }
            }
            //if (hits != null)
            //{
            //    Debug.Log("Hit something");
            //}
            //else
            //{
            //    Debug.Log("No hits");
            //}

        }

        prevFramePos = inputManager.PrimaryPosition();
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        trail.SetActive(false);
        StopCoroutine(coroutine);
        endPosition = position;
        endTime = time;

        //DetectSwipe();
    }

    //public void DetectSwipe()
    //{
    //    if (Vector3.Distance(startPosition, endPosition) >= minimumDistance && 
    //        (endTime - startTime) <= maximumTime)
    //    {
    //        Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
    //        Vector3 direction = endPosition - startPosition;
    //        Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
    //        SwipeDirection(direction2D);
    //    }
    //}

    //private void SwipeDirection(Vector2 direction)
    //{
    //    if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
    //    {
    //        Debug.Log("Swiped up");
    //    }        
    //    else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
    //    {
    //        Debug.Log("Swiped down");
    //    }        
    //    else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
    //    {
    //        Debug.Log("Swiped right");
    //    }        
    //    else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
    //    {
    //        Debug.Log("Swiped left");
    //    }        
    //}
}
