using UnityEngine;

public class CheckEnemyInFOV : Node
{
    private Transform _transform;
    private float _range;
    private LayerMask _enemyLayer;

    public CheckEnemyInFOV(Transform transform, float range, LayerMask layer)
    {
        _transform = transform;
        _range = range;
        _enemyLayer = layer;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t != null)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        Collider[] colliders = Physics.OverlapSphere(_transform.position, _range, _enemyLayer);
        if (colliders.Length > 0)
        {
            parent.parent.SetData("target", colliders[0].transform); // Lưu vào node gốc
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}