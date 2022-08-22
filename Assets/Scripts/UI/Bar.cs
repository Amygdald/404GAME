using UnityEngine;
using UnityEngine.UI;

namespace ETModel
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    public class Bar : MonoBehaviour
    {
        [Range(0.0f, 1.0f)]
        [Tooltip("血条剩余血量占比")]
        public float Alpha = 1.0f;
        [Tooltip("血条遮罩层组件")]
        public RectTransform FillRectTrans;
        [Tooltip("血条组件")]
        public RectTransform HpFillRectTrans;
        [Tooltip("渐变血条遮罩层组件")]
        public RectTransform TweenRectTrans;
        [Tooltip("渐变血条组件")]
        public RectTransform HpTweenRectTrans;
        [Tooltip("满血血量数值")]
        public int BloodVolume;
        [Tooltip("当前血量数值")]
        [HideInInspector]
        public float CurrentBlood;
        [Tooltip("每一百血量分割线")]
        public Sprite CutLine;

        private float tempBlood;
        private float newBlood;
        private float tweenSpeed;
        private bool isHurt;
        private float time;
        private float width;

        public void Awake()
        {
            InitData();
            DrawLine();
        }

        public void Update()
        {
            FillRectTrans.GetComponent<RectMask2D>().padding = new Vector4(0, 0, (1 - Alpha) * width, 0);
            TweenRectTrans.GetComponent<RectMask2D>().padding = new Vector4(0, 0, width - CurrentBlood * width / BloodVolume, 0);

            if (CurrentBlood != Alpha * BloodVolume)
            {
                if (!isHurt)
                {
                    isHurt = true;
                    tempBlood = newBlood;
                    newBlood = Alpha * BloodVolume;
                }
                else
                {
                    time = 0;
                    tempBlood = CurrentBlood;
                    newBlood = Alpha * BloodVolume;
                }
            }
            if (isHurt)
            {
                time = time >= 1 ? 1 : time + tweenSpeed * Time.deltaTime;
                CurrentBlood = Mathf.Lerp(tempBlood, newBlood, time);
                if (time == 1)
                {
                    isHurt = false;
                    time = 0;
                }
            }
        }

        private void InitData()
        {
            Alpha = 1.0f;
            tweenSpeed = 2.0f;
            newBlood = BloodVolume;
            CurrentBlood = BloodVolume;
            time = 0;
            isHurt = false;
            width = HpFillRectTrans.sizeDelta.x;
        }

        private void DrawLine()
        {
            if (BloodVolume != 0)
            {
                int lineCount = BloodVolume / 100;
                float singleHundred = HpFillRectTrans.sizeDelta.x * 100 / BloodVolume;
                HpFillRectTrans.GetComponent<HorizontalLayoutGroup>().padding.left = (int)singleHundred;
                HpTweenRectTrans.GetComponent<HorizontalLayoutGroup>().padding.left = (int)singleHundred;
                HpFillRectTrans.GetComponent<HorizontalLayoutGroup>().spacing = singleHundred;
                HpTweenRectTrans.GetComponent<HorizontalLayoutGroup>().spacing = singleHundred;
                CreatLine(lineCount, HpFillRectTrans.transform);
                CreatLine(lineCount, HpTweenRectTrans.transform);
            }
        }

        private void CreatLine(int number, Transform parent)
        {
            for (int i = 0; i < number; i++)
            {
                GameObject go = new GameObject();
                Image image = go.AddComponent<Image>();
                image.sprite = CutLine;
                go.transform.SetParent(parent, false);
            }
        }

        void OnGUI()
        {
            if (GUI.Button(new Rect(800, 50, 80, 20), "掉血"))
                Alpha -= 0.1f;
            if (GUI.Button(new Rect(800, 30, 80, 20), "回复"))
            {
                Alpha = 1.0f;
                InitData();
            }
        }
    }
}