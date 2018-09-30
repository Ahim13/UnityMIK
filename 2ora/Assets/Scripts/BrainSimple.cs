using UnityEngine;

[CreateAssetMenu(fileName = "AIBrain", menuName = "AI/BrainSimple")]
public class BrainSimple : AiBrain
{
    private AIProperties _aiProperties;
    private float _topBorder;
    private float _bottomBorder;
    private Transform _ball;

    public override void Init(GameObject gameObject, AIProperties aiProp, Transform ball)
    {
        _aiProperties = aiProp;
        _topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 1)).y - gameObject.GetComponent<SpriteRenderer>().size.y / 2;
        _bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1)).y + gameObject.GetComponent<SpriteRenderer>().size.y / 2;
        _ball = ball;
    }

    public override void Control( Transform transform)
    {
        if (_ball.position.y < transform.position.y && transform.position.y > _bottomBorder)
        {
//            transform.position -= new Vector3(0, _aiProperties.Speed * Time.deltaTime, 0);
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, _ball.position.y), Time.deltaTime * 20);
        }

        if (_ball.position.y > transform.position.y && transform.position.y < _topBorder)
        {
//            transform.position += new Vector3(0, _aiProperties.Speed * Time.deltaTime, 0);
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, _ball.position.y), Time.deltaTime * 20);
        }
    }
}