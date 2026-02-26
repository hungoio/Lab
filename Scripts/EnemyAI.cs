using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public Transform[] waypoints;
    public float fovRange = 10f;     // Tầm nhìn để phát hiện (ví dụ: 10m)
    public float chaseRange = 20f;   // Tầm đuổi theo tối đa (ví dụ: 20m - xa hơn tầm nhìn chút để kịch tính)
    public LayerMask enemyLayer;

    private Node _topNode;
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree()
    {
        // 1. Nhánh Truy đuổi
        CheckEnemyInFOV checkEnemy = new CheckEnemyInFOV(transform, fovRange, enemyLayer);

        // --- SỬA Ở ĐÂY: Truyền thêm biến chaseRange vào ---
        TaskGoToTarget chaseEnemy = new TaskGoToTarget(transform, _agent, chaseRange);

        Sequence chaseSequence = new Sequence(new List<Node> { checkEnemy, chaseEnemy });

        // 2. Nhánh Đi tuần
        TaskPatrol patrolTask = new TaskPatrol(transform, _agent, waypoints);

        // 3. Gốc
        _topNode = new Selector(new List<Node> { chaseSequence, patrolTask });
    }

    void Update()
    {
        if (_topNode != null) _topNode.Evaluate();
    }

    void OnDrawGizmos()
    {
        // Vẽ vòng tròn phát hiện (Vàng)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fovRange);

        // Vẽ vòng tròn bỏ cuộc (Đỏ) - để dễ căn chỉnh
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}