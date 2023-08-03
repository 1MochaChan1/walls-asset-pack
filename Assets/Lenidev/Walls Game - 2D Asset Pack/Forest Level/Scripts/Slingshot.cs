using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform initialPosition;
    public Transform idlePosition;
    public Transform pullbackPosition;

    public GameObject ball;
    public float launchForce=15f;

    Rigidbody2D ballCollider;
    private bool isFired=false;
    private bool _canShoot=true;
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;

        // Starting point positions
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);


        // Ending point positions
        lineRenderers[0].SetPosition(1, pullbackPosition.position);
        lineRenderers[1].SetPosition(1, pullbackPosition.position);

        ballCollider = ball.GetComponent<Rigidbody2D>();
        ballCollider.isKinematic = true;
        ball.transform.position = pullbackPosition.position;
        ballCollider.transform.right = pullbackPosition.position;
    }


    void Update()
    {

        if(Input.GetMouseButtonDown(0) & !isFired)
        {
            isFired = true;
            ShootBall();
            _canShoot = false;
        }

    
        else if (!_canShoot)
        {
            ResetStrips();
        }

    }



    void ShootBall()
    {
        if (_canShoot & ball!=null)
        {
            ResetStrips();
            ballCollider.isKinematic = false;
            var dir = (ball.transform.position - idlePosition.position).normalized * -launchForce;
            ballCollider.velocity = dir;
        }
    }

    void ResetStrips()
    {
        SetStrips(idlePosition.position);
    }

    void SetStrips(Vector3 targetPos)
    {
        var lerp1 = Vector2.Lerp(lineRenderers[0].GetPosition(1), targetPos, 0.10f);
        lineRenderers[0].SetPosition(1, lerp1);
        lineRenderers[1].SetPosition(1, lerp1);
    }
}
