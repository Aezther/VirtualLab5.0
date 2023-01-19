using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction end;
    public float speed;
    float dstTravelled;

    void Update()
    {
        dstTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(dstTravelled, end);
        transform.rotation = pathCreator.path.GetRotationAtDistance(dstTravelled, end);
    }
}