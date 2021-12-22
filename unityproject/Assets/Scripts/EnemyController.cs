using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sidz.spaceinvaders
{
    public class EnemyController : MonoBehaviour
    {
        public Transform root;
        [Range(0 , 10)]
        public int iRow =4;
        [Range(0 , 10)]
        public int iCol = 11;
        public float fXSpace = 2.0f;
        public float fYSpace = 2.0f;

        public float fGridMoveDelay = 2;
        public float fGridMoveDistance = 1;
        private int iCurrentStep = 5;
        public int iMaxStep = 5;
        public float fMaxRight;

        [SerializeField]private Camera cam;
        
        [SerializeField]private Bullet resBullet;

        [Header("Settings")]
        public EnemyView resAliens;

        public List<EnemyView> lstEnemiesSpawned;
        [SerializeField] private AnimationCurve movementCurve;
        public float fCurrentMultiplier = 1;
        private void Start()
        {
          
        }
       
    
        [ContextMenu("Test Clean")]
        private void Clean()
        {
            if (lstEnemiesSpawned != null)
            {
                foreach (EnemyView views in lstEnemiesSpawned)
                {
                    DestroyImmediate(views.gameObject);
                }
                lstEnemiesSpawned.Clear();
            }
        }

        [ContextMenu("Test Init")]
        public void Init()
        {
       
            Clean();
            lstEnemiesSpawned = new List<EnemyView>();
            for (int row = 0; row < iRow; row++)
            {
                for (int col = 0; col < iCol; col++)
                {
                    var createdEnemies = Instantiate(resAliens, root);

                    var tempX = createdEnemies.transform.localPosition.x + fXSpace*  col;
                    var tempY = createdEnemies.transform.localPosition.y + fYSpace* row;
                    createdEnemies.transform.localPosition = new Vector3(tempX ,tempY, createdEnemies.transform.localPosition.z);
                    lstEnemiesSpawned.Add(createdEnemies);
                }
             }

            fMaxRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z)).x;
           
            GridMove();

        }
        [ContextMenu("Move Grid")]
        public void GridMove()
        {
            StartCoroutine(coGridMove());

        }
        private IEnumerator coGridMove()
        {
            Vector3 tempDirection = Vector3.right;
            iCurrentStep = 0;
            while (true)
            {
                tempDirection = CheckAndUpdateDirection(tempDirection);

                if (iCurrentStep == 0)
                {
                    root.transform.position -= Vector3.up * fGridMoveDistance ;
                }
                else
                {
                    root.transform.position += tempDirection * fGridMoveDistance;
                }
                yield return new WaitForSeconds(Mathf.Max(0.1f,fGridMoveDelay - fCurrentMultiplier));
                if (UnityEngine.Random.Range(1,100)%2 == 0)
                {
                    int randomIndex = UnityEngine.Random.Range(0, lstEnemiesSpawned.Count);
                    var createdBullet = Instantiate(resBullet, lstEnemiesSpawned[randomIndex].transform.position, lstEnemiesSpawned[randomIndex].transform.rotation);
                    var bulletComp = createdBullet.GetComponent<Bullet>();
                    bulletComp.bEnemyOnly = false;
                    bulletComp.vDirection = -Vector3.up;
                }
                iCurrentStep++;
            }
        }

        private Vector3 CheckAndUpdateDirection(Vector3 current)
        {
            if (iCurrentStep > iMaxStep)
            {
                iCurrentStep = 0;
             //   fCurrentMultiplier += 0.05f;//?? hardcoded !
                return -current;
            }
            return current;
        }


    }
}
