using DG.Tweening;
using UnityEngine;

public class ViewNPCHiro : MonoBehaviour
{
    [HideInInspector] public NPSHeroController NpsHeroController;

    [HideInInspector] public int _radiusMove;

    private void Start()
    {
        NpsHeroController.StartMoveNPC();
    }

    public void MovementNPC()
    {
        transform.DOMove(new Vector3(Random.Range(-_radiusMove, _radiusMove),
            0.3f, Random.Range(-_radiusMove, _radiusMove)), Random.Range(1, 5)).OnComplete(MovementNPC);
    }
}
