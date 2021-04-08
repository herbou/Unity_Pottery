using UnityEngine ;
using DG.Tweening ;

public class Wood : MonoBehaviour {
   [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer ;
   [SerializeField] private Transform woodTransform ;
   [SerializeField] private Vector3 rotationVector ;
   [SerializeField] private float rotationDuration ;

   private void Start () {
      woodTransform
         .DOLocalRotate (rotationVector, rotationDuration, RotateMode.FastBeyond360)
         .SetLoops (-1, LoopType.Restart)
         .SetEase (Ease.Linear) ;
   }

   public void Hit (int keyIndex, float damage) {
      float colliderHeight = 2.39705f ;
      //Skinned mesh renderer key's value is clamped between 0 & 100
      float newWeight = skinnedMeshRenderer.GetBlendShapeWeight (keyIndex) + damage * (100f / colliderHeight) ;
      skinnedMeshRenderer.SetBlendShapeWeight (keyIndex, newWeight) ;
   }
}
